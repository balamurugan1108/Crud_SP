using Entities;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Stored_Procedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly ILogicLayer _logicLayer;
        public PlayersController(ILogicLayer logicLayer)
        {
            _logicLayer = logicLayer;
        }

        [HttpGet("GetPlayersDetails")]
        public IActionResult getAll()
        {
            return Ok(_logicLayer.getAll());
        }

        [HttpPost("AddPlayerDetails")]
        public IActionResult addPlayers(SP_PostModel postDatas)
        {
            return Ok(_logicLayer.addPlayers(postDatas));
        }

        [HttpPut("UpdatePlayerDetails")]
        public IActionResult updatePlayers(SPModel updateDatas)
        {
            return Ok(_logicLayer.updatePlayers(updateDatas));
        }

        [HttpDelete("DeletePlayerDetails")]
        public IActionResult deletePlayers(int id)
        {
            return Ok(_logicLayer.deletePlayers(id));
        }
    }
}
