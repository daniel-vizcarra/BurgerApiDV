using System;
using System.Collections.Generic;

namespace ApiBurgerDV.Data.Models;

public partial class BurgerDv
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool WithCheese { get; set; }

    public decimal Precio { get; set; }

    public virtual ICollection<PromoDv> PromoDvs { get; set; } = new List<PromoDv>();
}
