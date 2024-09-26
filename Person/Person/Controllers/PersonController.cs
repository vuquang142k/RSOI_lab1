using Microsoft.AspNetCore.Mvc;
using Person.Model;
using Person.Service;

namespace Person.Controllers
{
    [Route("/api/v1/persons")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService personService;
        public PersonController(PersonService personService)
        {
            this.personService = personService;
        }

        //GetAll
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            return StatusCode(StatusCodes.Status200OK, personService.getAllPerson());
        }
        //Get
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                var res = personService.FindById(id);
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
        //Add
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Add(People obj)
        {
            try
            {
                var res = personService.Add(obj);
                return StatusCode(StatusCodes.Status201Created, res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
        //Update
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult updateItem(int id, People person)
        {
            try
            {
                var res = personService.updatePerson(id, person);
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
        //Delete
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                int res = personService.deletePerson(id);
                return StatusCode(StatusCodes.Status204NoContent, res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
    }
}
