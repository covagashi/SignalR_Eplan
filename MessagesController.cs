using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using EGC.Hubs;

namespace EGC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IHubContext<TestHub> _hubContext;

        public MessagesController(IHubContext<TestHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MessageModel message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message.Message);
            return Ok();
        }
    }

    public class MessageModel
    {
        public string Message { get; set; }
    }
}