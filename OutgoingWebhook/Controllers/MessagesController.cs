using System;
using Microsoft.AspNetCore.Mvc;

namespace MicrosoftTeams.Templates.Controllers
{
    public class MessagesController : Controller
    {
        // GET api/values
        [HttpPost]
        [Route("api/messages")]
        public IActionResult ReplyMessage()
        {
            return Ok("{\"text\":\"reply message\"}");
        }

    }
}
