using System;
using System.Collections.Generic;

namespace API_Task.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Phone { get; set; } = null!;

    public virtual MedicalReport? MedicalReport { get; set; }
}
