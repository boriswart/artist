using artist.Models;
using artist.Services;
using Microsoft.AspNetCore.Mvc;

namespace artist.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WorksController : ControllerBase
  {
    private readonly WorksService _workService;

    public WorksController(WorksService workService)
    {
      _workService = workService;
    }

    [HttpPost]
    public ActionResult<Work> create([FromBody] Work workService)
    {
      try
      {
        return Ok(_workService.Create(workService));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}