using API_Task.Data;
using API_Task.DTO;
using API_Task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Task.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController(SchoolContext context) : ControllerBase
{
    [HttpGet("")]
    public IActionResult Get() =>
        Ok(context.Student.Include(x => x.MedicalReport)
            .Select(x => new StudentRespone(x))
            .ToList());



    [HttpGet("{id}")]
    public IActionResult GetOne(int id)
    {
        var student = context.Student.Include(x => x.MedicalReport)
            .FirstOrDefault(x => x.Id == id);
            
        return student is not null ? Ok(new StudentRespone(student)) : NotFound();
    }

    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] Student student)
    {
        await context.Student.AddAsync(student);
        context.SaveChanges();
        return CreatedAtAction(nameof(GetOne), new { student.Id }, student);
    }

    [HttpPut()]
    public async Task<IActionResult> Update(Student student)
    {
        var currentStudent = context.Student.FirstOrDefault(y => y.Id == student.Id);
        if (currentStudent == null)
            return NotFound();

        currentStudent.Name = student.Name;
        currentStudent.Phone = student.Phone;
        currentStudent.Age = student.Age;
        currentStudent.MedicalReport = student.MedicalReport;

        context.Student.Update(currentStudent);
        context.SaveChanges();

        return NoContent();

    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id) {
        var student = context.Student.FirstOrDefault(s => s.Id == id);
        if (student == null) return NotFound();

        var medicalReport = context.MedicalReport.FirstOrDefault(x => x.stdId == student.Id);
        if (medicalReport != null)
        {
            context.Remove(medicalReport);
        }

        context.Remove(student);
        context.SaveChanges();

        return NoContent();
    
    }


}