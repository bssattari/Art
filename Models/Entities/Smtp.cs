using System;
using System.Collections.Generic;

namespace Art.Models.Entities;

public partial class Smtp
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Server { get; set; } = null!;

    public int Port { get; set; }

    public bool Ssl { get; set; }
}
