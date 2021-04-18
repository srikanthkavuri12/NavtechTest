using Dapper;
using DataManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using static System.Data.CommandType;
using DataManagement.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataManagement.Repository
{
    public class UserRepository : BaseRepository,
    IUserRepository
    {

        public bool AddUser(User user)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                SqlParameter P = new SqlParameter();
                parameters.Add("@UserName", user.UserName);
                parameters.Add("@UserMobile", user.UserMobile);
                parameters.Add("@UserEmail", user.UserEmail);
                parameters.Add("@FaceBookUrl", user.FaceBookUrl);
                parameters.Add("@LinkedInUrl", user.LinkedInUrl);
                parameters.Add("@TwitterUrl", user.TwitterUrl);
                parameters.Add("@PersonalWebUrl", user.PersonalWebUrl);
                parameters.Add("@result", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                SqlMapper.Execute(con, "AddUser", param: parameters, commandType: StoredProcedure);
                var result = parameters.Get<string>("@result");

                if(result!=null)
                {
                    user.UserEmail = "User already exists";
                }
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteUser(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            SqlMapper.Execute(con, "DeleteUser", param: parameters, commandType: StoredProcedure);
            return true;
        }
        public IList<User> GetAllUser()
        {
            IList<User> customerList = SqlMapper.Query<User>(con, "GetAllUsers", commandType: StoredProcedure).ToList();
            return customerList;
        }
        public User GetUserById(int userId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);
                return SqlMapper.Query<User>((SqlConnection)con, "GetUserById", parameters, commandType: StoredProcedure).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateUser(User user)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("@UserId", user.UserId);
                parameters.Add("@UserName", user.UserName);
                parameters.Add("@UserMobile", user.UserMobile);
                parameters.Add("@UserEmail", user.UserEmail);
                parameters.Add("@FaceBookUrl", user.FaceBookUrl);
                parameters.Add("@LinkedInUrl", user.LinkedInUrl);
                parameters.Add("@TwitterUrl", user.TwitterUrl);
                parameters.Add("@PersonalWebUrl", user.PersonalWebUrl);
                SqlMapper.Execute(con, "UpdateUser", param: parameters, commandType: StoredProcedure);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}