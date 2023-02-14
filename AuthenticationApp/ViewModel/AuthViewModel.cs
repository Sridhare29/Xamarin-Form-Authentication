using AuthenticationApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationApp.ViewModel
{
    public class AuthViewModel
    {
        public readonly SQLiteAsyncConnection db;
        public AuthViewModel(string dbpath)
        {
            db = new SQLiteAsyncConnection(dbpath);
            db.CreateTableAsync<User>();

        }
        public Task<int> CreateUser(User user)
        {
            return db.InsertAsync(user);
        }
        public Task<List<User>> ReadUser()
        {
            return db.Table<User>().ToListAsync();
        }
    }
}
