using System.Collections.Generic;

namespace SweetandSavory.Models
{
  public class Flavor
  {
    public Flavor()
    {
      this.Treat = new HashSet<TreatFlavor>();
    }

    public int FlavorId { get; set; }
    public string FlavorName { get; set; }

    public virtual ICollection<TreatFlavor> Treat { get; set; }
  }
}