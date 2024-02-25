using System;
using System.Collections.Generic;

namespace API;

public partial class Request
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Kcal { get; set; }

    public int Proteins { get; set; }

    public int Fats { get; set; }

    public int Carbohydrates { get; set; }

    public bool Status { get; set; }
}
