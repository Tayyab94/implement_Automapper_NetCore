using AutoMapper;
using MapperApp.Models;
using MapperApp.Models.DTOS.IncomingDTOs;
using MapperApp.Models.DTOS.OutgoingDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MapperApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly ILogger<DriversController> _logger;

        private static List<Driver> drivers= new List<Driver>();

        private readonly IMapper _mapper;
        public DriversController(ILogger<DriversController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDrivers()
        {
            var allDrivers = drivers.Where(s=> s.status==1).ToList();
            if(!allDrivers.Any()) {
                return new JsonResult("No Dirver are in the Database yet!") { StatusCode = 401 };
            }

            var _driversList = _mapper.Map<IEnumerable<DriverDTO>>(allDrivers);

            return Ok(_driversList);
        }


        //[HttpPost]
        //public IActionResult CreateDriver(Driver driver)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        drivers.Add(driver);
        //        return CreatedAtAction("GetDriver", routeValues: new { id= driver.Id },value: driver);
        //    }

        //    return new JsonResult("Something went wrong") { StatusCode = 500 };
        //}

        [HttpPost]
        public IActionResult CreateDriver(DriverForCreationDTO data)
        {
            if (ModelState.IsValid)
            {
                // this is without Mapping the object
                //var driver = new Driver()
                //{
                //    FirstName = data.FirstName,
                //    LastName = data.LastName,
                //    WorldChampianShip = data.WorldChampianship,
                //    DriverNumber = data.DriverNumber,
                //    AddedDate = DateTime.UtcNow,
                //    status = 1,
                //    UpdatedDate = DateTime.UtcNow,
                //    Id = Guid.NewGuid(),
                //};
                
                 var driver = _mapper.Map<Driver>(data);

                drivers.Add(driver);

                var CreatedDriver = _mapper.Map<DriverDTO>(driver);
                return CreatedAtAction("GetDriver", routeValues: new { id = driver.Id }, value: CreatedDriver);
            }

            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpGet(template:"{id}", Name = "GetDriver")]
        public IActionResult GetDriver(Guid id)
        {
            var item = drivers.FirstOrDefault(s => s.Id == id);

            if (item is null)
                return NotFound();

            return Ok(item);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateDriver(Guid id,Driver driver) {
            if(id!= driver.Id)
                return BadRequest();

            var existingDriver = drivers.FirstOrDefault(s => s.Id == id);

            if (existingDriver is null)
                return NotFound();

            existingDriver.FirstName = driver.FirstName;
            existingDriver.LastName = driver.LastName;
            existingDriver.UpdatedDate = driver.UpdatedDate;
            existingDriver.DriverNumber = driver.DriverNumber;
            existingDriver.AddedDate = driver.AddedDate;
            existingDriver.status = driver.status;
            existingDriver.WorldChampianShip= driver.WorldChampianShip;

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteDriver(Guid id)
        {

            var driver = drivers.FirstOrDefault(s => s.Id == id);
            if (driver is null)
                return NotFound();

            driver.status = 0;

            return NoContent();
        }
    }
}
