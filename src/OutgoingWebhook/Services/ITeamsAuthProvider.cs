using Microsoft.AspNetCore.Http;

namespace MicrosoftTeams.OutgoingWebhook.Services;

public interface ITeamsAuthProvider
{
    /// <summary>
    /// Validates the specified authentication header value.
    /// </summary>
    /// <param name="request">The HTTP request message.</param>
    /// <returns>
    /// Response containing result of validation.
    /// </returns>
    TeamsAuthResponse Validate(HttpRequest request);
}
