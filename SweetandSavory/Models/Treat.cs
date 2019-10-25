using System.Collections.Generic;
using System;

namespace SweetandSavory.Models
{
  public class Treat
  {
    public Treat()
    {
      this.Flavor = new HashSet<TreatFlavor>();
    }

    public int TreatId { get; set; }
    public string TreatName { get; set; }
    public virtual ICollection<TreatFlavor> Flavor { get; set; }
  }
}