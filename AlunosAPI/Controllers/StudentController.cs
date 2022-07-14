using AlunosAPI.Interfaces;
using AlunosAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlunosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudent studentService;

        public StudentController(IStudent student)
        {
            this.studentService = student;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Student>>> GetStudents()
        {
            var students = await studentService.GetStudents();

            //if (students.Count < 0)
            //    return BadRequest("Error to get all students");

            return Ok(students);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> PostStudent(Student? student)
        {
            var response = await studentService.PostStudent(student);

            return Ok(response);
        }
    }
}
