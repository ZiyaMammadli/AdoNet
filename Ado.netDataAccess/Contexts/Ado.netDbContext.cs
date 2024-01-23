using Ado.netCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.netDataAccess.Contexts;

public class AdonetDbContext
{
    public static List<Post> DbPost { get; set; } = new List<Post>();
}
	