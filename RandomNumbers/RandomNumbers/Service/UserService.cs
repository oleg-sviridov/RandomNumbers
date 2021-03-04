using Microsoft.EntityFrameworkCore;
using RandomNumbers.Database;
using RandomNumbers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomNumbers.Service
{
    public class UserService
    {
        public DataContext _datacontext;

        public UserService(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task<User> Authenticate(string login, string password)
        {
             var user = await _datacontext.Users.FirstOrDefaultAsync(
                x=> x.Login== login && x.Password== password);

            return user;
        }

    }
}
