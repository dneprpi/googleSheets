using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSheets
{
  public class Model
  {
    public string Number { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string DaysOff { get; set; }

    public Model (IList<object> list)
    {
      Number = (string)list[0];
      Name = (string)list[1];
      Phone = (string)list[2];
      DaysOff = (string)list[3];
    }

  }
}
