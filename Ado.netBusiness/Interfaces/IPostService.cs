using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.netBusiness.Interfaces;

public interface IPostService
{
    public void AddToDatabaseWithId(int? Id);
    public Task<int> GetCountPostFromDatabase(int? userId);
}
