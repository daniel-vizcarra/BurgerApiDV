using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiBurgerDV.Data.Models;

public partial class PromoDv
{
    [Key]
    public int PromoId { get; set; }

    public string? Descripcion { get; set; }

    public DateTime FechaPromo { get; set; }

    public int BurgerId { get; set; }

    public virtual BurgerDv Burger { get; set; } = null!;
}
