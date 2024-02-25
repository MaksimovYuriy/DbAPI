using System;
using System.Collections.Generic;

namespace API;

public partial class UserProduct
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdProduct { get; set; }

    public DateOnly Date { get; set; }

    public int Sum { get; set; }

    public int Kcal { get; set; }

    public int Proteins { get; set; }

    public int Fats { get; set; }

    public int Carbohydrates { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
