using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Connector.Teams;
using Microsoft.Bot.Connector.Teams.Models;
using Microsoft.Bot.Schema;

namespace MicrosoftTeams.MessagingExtension.Controllers
{
    [ApiController]
    public class MessagingExtensionController : ControllerBase
    {
        private static readonly string[] s_sampleCities = new string[] { "Shanghai", "ShenZhen", "Sydney", "Melbourne", "Tokyo", "Osaka", "KualaLumpur" };

        [HttpPost]
        [Route("api/extension")]
        public IActionResult Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Invoke)
            {
                if (activity.IsComposeExtensionQuery())
                {
                    // This is the response object that will get sent back to the messaging extension request.
                    var invokeResponse = new ComposeExtensionResponse();

                    // This helper method gets the query as an object.
                    var query = activity.GetComposeExtensionQueryData();

                    if (query.CommandId != null && query.Parameters != null && query.Parameters.Count > 0)
                    {
                        string[] cities;
                        if (query.Parameters[0].Name == "initialRun")
                        {
                            cities = s_sampleCities;
                        }
                        else
                        {
                            var keyword = query.Parameters[0].Value.ToString();
                            cities = s_sampleCities
                                        .Where(c => c.Contains(keyword, StringComparison.InvariantCultureIgnoreCase))
                                        .ToArray();
                        }

                        var results = new ComposeExtensionResult()
                        {
                            AttachmentLayout = "list",
                            Type = "result",
                            Attachments = BuildAttachments(cities)
                        };
                        invokeResponse.ComposeExtension = results;
                    }

                    // Return the response
                    return Ok(invokeResponse);
                }
            }

            // Failure case catch-all.
            return BadRequest("Invalid request! This API supports only messaging extension requests. Check your query and try again");
        }

        private List<ComposeExtensionAttachment> BuildAttachments(IList<string> cities)
        {
            var attachments = new List<ComposeExtensionAttachment>();
            foreach (var city in cities)
            {
                var attachment = new ComposeExtensionAttachment
                {
                    ContentType = ThumbnailCard.ContentType,
                    Content = CreateSampleThumbnailCard(city, false),
                    Preview = new Attachment()
                    {
                        ContentType = ThumbnailCard.ContentType,
                        Content = CreateSampleThumbnailCard(city, true),
                    }
                };
                attachments.Add(attachment);
            }
            return attachments;
        }

        private ThumbnailCard CreateSampleThumbnailCard(string city, bool preview)
        {
            return new ThumbnailCard()
            {
                Title = city,
                Images = new List<CardImage>()
                {
                    new CardImage()
                    {
                        Url = "https://github.com/tony-xia/microsoft-teams-templates/raw/master/images/cities/" + city.ToLowerInvariant() + ".jpg"
                    }
                },
                Tap = preview ? null : new CardAction()
                {
                    Type = "openUrl",
                    Title = "Bing this city",
                    Value = "https://www.bing.com/images/search?q=" + city
                },
            };
        }

    }
}
