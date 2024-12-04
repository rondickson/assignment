using CSC317PassManagerP2Starter.Modules.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC317PassManagerP2Starter.Modules.Controllers
{
    public enum AuthenticationError { NONE, INVALIDUSERNAME, INVALIDPASSWORD }
    public class LoginController
    {
        private UserModel user;

        public enum AuthenticationError { NONE, INVALIDUSERNAME, INVALIDPASSWORD }

        public LoginController()
        {
            // Create a dummy user for testing
            var (key, iv) = PasswordCrypto.GenKey();
            user = new UserModel
            {
                ID = 1,
                FirstName = "John",
                LastName = "Doe",
                UserName = "test",
                PasswordHash = PasswordCrypto.GetHash("ab1234"),
                Key = key,
                IV = iv
            };
        }

        public AuthenticationError Authenticate(string username, string password)
        {
            if (user.UserName != username)
                return AuthenticationError.INVALIDUSERNAME;

            var inputHash = PasswordCrypto.GetHash(password);
            if (!PasswordCrypto.CompareBytes(user.PasswordHash, inputHash))
                return AuthenticationError.INVALIDPASSWORD;

            return AuthenticationError.NONE;
        }

        public UserModel GetCurrentUser()
        {
            return user;
        }


        
    }

}
