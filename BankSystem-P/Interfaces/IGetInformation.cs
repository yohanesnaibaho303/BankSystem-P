using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem_P.Interfaces
{
    /* Another way to achieve abstraction in C#, is with interfaces.
    An interface is a completely "abstract class"
    Interfaces can contain properties and methods, but not fields.
    By default, members of an interface are abstract and public. */

    interface IGetInformation
    {
        string GetInformation(); // interface method (does not have a body)
    }
}
