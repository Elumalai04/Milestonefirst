using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace EMS
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await studentService.GetAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            var students = await studentService.GetAllAsync();

            return Ok(students);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Insert")]
        public async Task<ActionResult<int>> Insert(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await studentService.InsertAsync(student);

            return Ok(result); ;
        }

        [HttpPost("Update")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Update(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await studentService.UpdateAsync(student);

            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var student = await studentService.GetAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            var result = await studentService.DeleteAsync(id);

            return Ok(result);
        }
    }
}