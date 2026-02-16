using API_Task.Models;

namespace API_Task.DTO;

public class StudentRespone
{
    public StudentRespone(Student student)
    {
        Id = student.Id;
        Name = student.Name;
        Age = student.Age;
        Phone = student.Phone;
        BloodType = student.MedicalReport?.BloodType;
        Height = student.MedicalReport.Height;
        Weight = student.MedicalReport.Weight;
    }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Phone { get; set; } = null!;

    public string BloodType { get; set; } = null!;

    public int Height { get; set; }

    public int Weight { get; set; }

}
