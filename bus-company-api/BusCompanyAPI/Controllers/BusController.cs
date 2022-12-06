using Amazon.DynamoDBv2.DataModel;
using BusCompanyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BusCompanyAPI.Model;

namespace BusCompanyAPI.Controllers
{
    [ApiController]
    [Route("api/bus")]    
    public class BusController : ControllerBase
    {
        private readonly IDynamoDBContext _dbcontext;
        public BusController(IDynamoDBContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllBuses()
        {
            var list = await _dbcontext.ScanAsync<Bus>(default).GetRemainingAsync();
            return Ok(list);
        }


        [HttpGet("{licensePlate}")]
        public async Task<IActionResult> GetBusDetail(string licensePlate)
        {
            var entity = await _dbcontext.LoadAsync<Bus>(licensePlate.ToUpper());
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBus([FromBody] Bus busRequest)
        {
            busRequest.LicensePlate = busRequest.LicensePlate.ToUpper().Trim();
            
            var bus = await _dbcontext.LoadAsync<Bus>(busRequest.LicensePlate);
            if (bus != null) return BadRequest($"Bus with Id: {busRequest.LicensePlate} Already Exists");
    
            await _dbcontext.SaveAsync(busRequest);
            return Ok(busRequest);
        }

        [HttpDelete("{licensePlate}")]
        public async Task<IActionResult> DeleteBus(string licensePlate)
        {
            var bus = await _dbcontext.LoadAsync<Bus>(licensePlate);
            if (bus == null) return NotFound();
            await _dbcontext.DeleteAsync(bus);
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateBus([FromBody] Bus busRequest)
        {
            var bus = await _dbcontext.LoadAsync<Bus>(busRequest.LicensePlate.ToUpper());            
            if (bus == null) return NotFound();
            await _dbcontext.SaveAsync(busRequest);
            return Ok(busRequest);
        }
    }
}
