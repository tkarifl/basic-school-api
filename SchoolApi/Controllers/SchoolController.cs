using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private static List<StudentModel> studentList = new List<StudentModel>()
        {
            new StudentModel(){Id=1,CourseId=100,Name="John",Surname="Doe",Gender='M'},
            new StudentModel(){Id=2,CourseId=100,Name="Liza",Surname="Koter",Gender='F'},
            new StudentModel(){Id=3,CourseId=200,Name="Fin",Surname="Olemna",Gender='F'},
            new StudentModel(){Id=4,CourseId=300,Name="Eve",Surname="Lesto",Gender='F'},
            new StudentModel(){Id=5,CourseId=320,Name="Abraham",Surname="Lincoln",Gender='M'},
            new StudentModel(){Id=6,CourseId=320,Name="George",Surname="Gratt",Gender='M'},
            new StudentModel(){Id=7,CourseId=320,Name="Ralph",Surname="Sutre",Gender='M'},
            new StudentModel(){Id=8,CourseId=400,Name="Daniella",Surname="Ekto",Gender='F'}
        };

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(studentList);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = studentList.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                return Ok(student);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult AddStudent([FromBody]StudentModel student)
        {
            if (ModelState.IsValid)
            {
                studentList.Add(student);
                return Created($"api/students/{student.Id}",student);
            }
            return BadRequest();
        }

    }
}
