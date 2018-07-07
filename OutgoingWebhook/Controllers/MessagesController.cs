using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Schema;
using MicrosoftTeams.OutgoingWebhook.Services;

namespace MicrosoftTeams.OutgoingWebhook.Controllers
{
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ITeamsAuthProvider _teamsAuth;

        public MessagesController(ITeamsAuthProvider teamsAuth)
        {
            _teamsAuth = teamsAuth;
        }

        [HttpPost]
        [Route("api/message")]
        public Activity GetMessage([FromBody]Activity activity)
        {
            var authResult = _teamsAuth.Validate(this.Request);
            if (!authResult.AuthSuccessful)
            {
                return new Activity()
                {
                    Text = "You are not authorized to call into this end point."
                };
            }

            Attachment attachment = null;
            if (activity.Text.Contains("hero", StringComparison.InvariantCultureIgnoreCase))
            {
                var card = CreateSampleHeroCard();
                attachment = new Attachment()
                {
                    ContentType = HeroCard.ContentType,
                    Content = card
                };
            }
            else if (activity.Text.Contains("thumbnail", StringComparison.InvariantCultureIgnoreCase))
            {
                var card = CreateSampleThumbnailCard();
                attachment = new Attachment()
                {
                    ContentType = ThumbnailCard.ContentType,
                    Content = card
                };
            }

            if (attachment != null)
            {
                return new Activity()
                {
                    Attachments = new List<Attachment>() { attachment }
                };
            }

            return new Activity()
            {
                Text = "Try to type <b>hero</b> or <b>thumbnail</b>."
            };
        }

        private HeroCard CreateSampleHeroCard()
        {
            return new HeroCard()
            {
                Title = "Superhero",
                Subtitle = "An incredible hero",
                Text = "Microsoft Teams",
                Images = new List<CardImage>()
                {
                    new CardImage()
                    {
                        Url = "https://docs.microsoft.com/en-us/MicrosoftTeams/media/overview_of_a_microsoft_teams_deployment_image1.png"
                    }
                },
                Buttons = new List<CardAction>()
                {
                    new CardAction()
                    {
                        Type = "openUrl",
                        Title = "Visit",
                        Value = "http://www.microsoft.com"
                    }
                }
            };
        }

        private ThumbnailCard CreateSampleThumbnailCard()
        {
            return new ThumbnailCard()
            {
                Title = "Teams Sample",
                Subtitle = "Outgoing Webhook sample",
                Images = new List<CardImage>()
                {
                    new CardImage()
                    {
                        Url = "https://avatars0.githubusercontent.com/u/11069971?s=460&v=4"
                    }
                },
                Buttons = new List<CardAction>()
                {
                    new CardAction()
                    {
                        Type = "openUrl",
                        Title = "Visit",
                        Value = "http://www.bing.com"
                    }
                }
            };
        }

    }
}
