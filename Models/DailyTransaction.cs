using System;
using System.Collections.Generic;

namespace BikeStore.Models;

public partial class DailyTransaction
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Myvalue { get; set; }
}
