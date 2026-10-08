using System;
using System.Collections.Generic;

namespace Postgres.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string City { get; set; } = null!;

    public DateOnly RegisteredAt { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public override string ToString() =>
    $"Id={Id}, {FullName}, {City}, {RegisteredAt}";
}
