using System;
using System.Collections.Generic;

namespace API_Task.Models;

public partial class MedicalReport
{
    public int Id { get; set; }

    public string BloodType { get; set; } = null!;

    public int Height { get; set; }

    public int Weight { get; set; }

    public int stdId { get; set; }

    public virtual Student std { get; set; } = null!;
}
