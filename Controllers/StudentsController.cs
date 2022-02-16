using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie2.Models;
using System.IO;
using CsvHelper;
using System.Globalization;
using Zadanie2.CSVrds;

namespace Zadanie2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        List<Student> studentList;
        Reader rd;
        public StudentsController()
        {
            rd = new Reader(@"DataBase\student.csv");
            studentList = rd.ReadCsvFile();
        }


        [HttpGet]
        public IActionResult GetStudendts()
        {
            return Ok(studentList);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(string id)
        {
            Student student = studentList.Find(s => s.Index == id);
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(Student student, string id)
        {
            Student s = studentList.Find(s => s.Index == id);
            int index = studentList.IndexOf(s);
            studentList[index] = student;
            rd.WriteCsvFile();
            return Ok();
        }

        [HttpPost]

        public IActionResult InsertStudent(Student student)
        { 
            studentList.Add(student);
            rd.WriteCsvFile();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(string id)
        {
            Student s = studentList.Find(s => s.Index == id);
            int index = studentList.IndexOf(s);
            studentList.RemoveAt(index);
            rd.WriteCsvFile();
            return Ok(studentList.Count);
        }
    }
}
