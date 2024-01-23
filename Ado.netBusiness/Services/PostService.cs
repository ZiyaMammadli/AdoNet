using Ado.netBusiness.Interfaces;
using Ado.netCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ado.netDataAccess.Contexts;
using Ado.netBusiness.Utilities.Exceptions;
using System.Data.SqlClient;
namespace Ado.netBusiness.Services;

public class PostService : IPostService
{
    public async void AddToDatabaseWithId(int? Id)
    {
        if (Id is null) throw new ArgumentNullException();
        Post? Dbpost= AdonetDbContext.DbPost.Find(c=>c.Id==Id);
        if (Dbpost is null) throw new NotFoundException($"{Id} is not found");
        string connString = @"Server=WIN-PRIFU0D7GO7\SQLEXPRESS;Database=PersonDb;Trusted_Connection=true;";
        string query = $"Insert into Persons values({Dbpost.userId},'{Dbpost.title}','{Dbpost.body}')";
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                int affectedRow = await cmd.ExecuteNonQueryAsync();
                if (affectedRow > 0)
                {
                    Console.WriteLine("Succesfully added");
                }
                else
                {
                    throw new NonSuccesfullyException("added Failed");
                }
            }
        }
    }
    
    public async Task<int> GetCountPostFromDatabase(int? userId)
    {
        if(userId is null) throw new ArgumentNullException();
        string connString = @"Server=WIN-PRIFU0D7GO7\SQLEXPRESS;Database=PersonDb;Trusted_Connection=true;";
        int result;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            try
            {
                conn.Open();
                string query = "Select count(*) from Persons";
                using(SqlCommand cmd=new SqlCommand(query,conn))
                {
                    result = (int)await cmd.ExecuteScalarAsync();
                    return result;
                }
            }
            catch (Exception)
            {

                throw new NotFoundException($"{userId} is not found from database");
            }
        }
    }
}
