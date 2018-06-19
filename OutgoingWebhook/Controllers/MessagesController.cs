using System;
using Microsoft.Bot.Schema;
using Microsoft.AspNetCore.Mvc;

namespace MicrosoftTeams.Templates.Controllers
{
    public class MessagesController : Controller
    {
        [HttpPost]
        [Route("api/messages")]
        public Activity ReplyMessage([FromBody]Activity message)
        {
            return new Activity()
            {
                Text = "echo: " + message.Text
            };
        }

    }
}
