using System;
using System.Collections.Generic;

namespace ApiBurgerDV.Data.Models;

public partial class ArtPieceDv
{
    public int ArtPieceId { get; set; }

    public string? Title { get; set; }

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public int ArtistId { get; set; }

    public virtual Artist Artist { get; set; } = null!;
}
