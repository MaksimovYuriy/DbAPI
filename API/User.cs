using System;
using System.Collections.Generic;

namespace API;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public int IdAim { get; set; }

    public double InitWeight { get; set; }

    public double CurWeight { get; set; }

    public double AimWeight { get; set; }

    public int IdActivity { get; set; }

    public int KcalPerDay { get; set; }

    public virtual Activity IdActivityNavigation { get; set; } = null!;

    public virtual Aim IdAimNavigation { get; set; } = null!;

    public virtual ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();

    public virtual Weight? Weight { get; set; }
}
