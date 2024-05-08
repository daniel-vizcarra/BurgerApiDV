using System;
using System.Collections.Generic;

namespace ApiBurgerDV.Data.Models;

public partial class Artist
{
    public int ArtistId { get; set; }

    public string? Name { get; set; }

    public string? Bio { get; set; }

    public virtual ICollection<ArtPieceDv> ArtPieceDvs { get; set; } = new List<ArtPieceDv>();
}
