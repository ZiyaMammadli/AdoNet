using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.netBusiness.Utilities.Exceptions;

public class NonSuccesfullyException:Exception
{
    public NonSuccesfullyException(string message) : base(message) { }
}
