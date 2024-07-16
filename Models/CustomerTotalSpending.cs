using System;
using System.Collections.Generic;

namespace BikeStore.Models;

public partial class CustomerTotalSpending
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal? TotalSpending { get; set; }
}
