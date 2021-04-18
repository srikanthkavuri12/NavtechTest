using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataManagement.Repository
{
    public class BaseRepository:IDisposable
    {
        
        protected IDbConnection con;

        public BaseRepository()
    {
            string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DataManagement;Data Source=DESKTOP-O155UKJ\\MSSQLSERVER02";
            con = new SqlConnection(connectionString);
    }
       
        public void Dispose()
    {
        //throw new NotImplementedException();  
    }
}  
}  