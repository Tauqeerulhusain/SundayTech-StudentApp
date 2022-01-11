using Microsoft.AspNetCore.Mvc;
using StudentBAL.Interface;
using StudentDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _studentRepository.GetStudents();
        }

        [HttpPost]
        public void Post([FromBody] Student std)
        {
            _studentRepository.SaveStudents(std);
        }

        [HttpPut]
        public void Put([FromBody] Student std)
        {
            _studentRepository.UpdateStudents(std);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _studentRepository.DeleteStudent(id);
        }
    }
}
