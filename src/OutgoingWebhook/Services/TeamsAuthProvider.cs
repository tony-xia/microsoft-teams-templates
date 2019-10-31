using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MicrosoftTeams.OutgoingWebhook.Services
{
    /// <summary>
    /// Provides authentication results.
    /// </summary>
    public class TeamsAuthProvider : ITeamsAuthProvider
    {
        private readonly ILogger<TeamsAuthProvider> _logger;
        private readonly string _securityToken;

        public TeamsAuthProvider(ILogger<TeamsAuthProvider> logger, IConfiguration configuration)
        {
            _logger = logger;
            _securityToken = configuration.GetValue<string>("TeamsAppSecurityToken");
        }

        /// <summary>
        /// Validates the specified authentication header value.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <returns>
        /// Response containing result of validation.
        /// </returns>
        public TeamsAuthResponse Validate(HttpRequest request)
        {
            request.Body.Seek(0, SeekOrigin.Begin);
            string messageContent = new StreamReader(request.Body).ReadToEnd();
            var authenticationHeaderValue = request.Headers["Authorization"];

            if (authenticationHeaderValue.Count <= 0)
            {
                return new TeamsAuthResponse(false, "Authentication header not present on request.");
            }

            if (!authenticationHeaderValue[0].StartsWith("HMAC"))
            {
                return new TeamsAuthResponse(false, "Incorrect authorization header scheme.");
            }

            // Reject all empty messages
            if (string.IsNullOrEmpty(messageContent))
            {
                return new TeamsAuthResponse(false, "Unable to validate authentication header for messages with empty body.");
            }

            string providedHmacValue = authenticationHeaderValue[0].Substring("HMAC".Length).Trim();
            string calculatedHmacValue = null;
            try
            {
                byte[] serializedPayloadBytes = Encoding.UTF8.GetBytes(messageContent);

                byte[] keyBytes = Convert.FromBase64String(_securityToken);
                using (HMACSHA256 hmacSHA256 = new HMACSHA256(keyBytes))
                {
                    byte[] hashBytes = hmacSHA256.ComputeHash(serializedPayloadBytes);
                    calculatedHmacValue = Convert.ToBase64String(hashBytes);
                }

                if (string.Equals(providedHmacValue, calculatedHmacValue))
                {
                    return new TeamsAuthResponse(true, null);
                }
                else
                {
                    string errorMessage = string.Format(
                        "AuthHeaderValueMismatch. Expected:'{0}' Provided:'{1}'",
                        calculatedHmacValue,
                        providedHmacValue);
                    return new TeamsAuthResponse(false, errorMessage);
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Exception occured while verifying HMAC on the incoming request.");
                return new TeamsAuthResponse(false, "Exception thrown while verifying MAC on incoming request.");
            }
        }
    }
}
