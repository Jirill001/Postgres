using System;
using System.Collections.Generic;

namespace Postgres.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public override string ToString() =>
    $"Id={Id}, Name={Name}, Price={Price}, Stock={Stock}";
}
