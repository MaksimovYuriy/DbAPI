using System;
using System.Collections.Generic;

namespace API;

public partial class Weight
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public double Weight1 { get; set; }

    public DateOnly Date { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
