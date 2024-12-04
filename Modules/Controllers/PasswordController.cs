using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC317PassManagerP2Starter.Modules.Controllers;
using CSC317PassManagerP2Starter.Modules.Models;
using CSC317PassManagerP2Starter.Modules.Views;

namespace CSC317PassManagerP2Starter.Modules.Controllers
{
    public class PasswordController
    {
        private List<PasswordModel> passwords = new List<PasswordModel>();
        private int counter = 1;

        public void GenTestPasswords()
        {
            passwords.Add(new PasswordModel { ID = counter++, UserID = 1, PlatformName = "Facebook", PlatformUserName = "fbuser", PasswordText = PasswordCrypto.Encrypt("password123", App.login_controller.GetCurrentUser().Key, App.login_controller.GetCurrentUser().IV) });
        }

        // PasswordController
        // PasswordController
        public void AddPassword(string platform, string username, string password)
        {
            var currentUser = App.login_controller.GetCurrentUser();
            passwords.Add(new PasswordModel
            {
                ID = counter++,
                UserID = currentUser.ID,
                PlatformName = platform,
                PlatformUserName = username,
                PasswordText = PasswordCrypto.Encrypt(password, currentUser.Key, currentUser.IV) // Adjust here
            });
        }





        public PasswordModel GetPassword(int ID)
        {
            return passwords.FirstOrDefault(p => p.ID == ID);
        }

        public bool UpdatePassword(PasswordModel updatedPassword)
        {
            var existing = passwords.FirstOrDefault(p => p.ID == updatedPassword.ID);
            if (existing == null) return false;

            existing.PlatformName = updatedPassword.PlatformName;
            existing.PlatformUserName = updatedPassword.PlatformUserName;
            existing.PasswordText = updatedPassword.PasswordText;

            return true;
        }

        public bool RemovePassword(int ID)
        {
            var password = passwords.FirstOrDefault(p => p.ID == ID);
            if (password == null) return false;

            passwords.Remove(password);
            return true;
        }

        public void PopulatePasswordView(ObservableCollection<PasswordRow> source, string searchCriteria = null)
        {
            source.Clear();
            foreach (var password in passwords)
            {
                if (string.IsNullOrEmpty(searchCriteria) ||
                    password.PlatformName.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase) ||
                    password.PlatformUserName.Contains(searchCriteria, StringComparison.OrdinalIgnoreCase))
                {
                    source.Add(new PasswordRow(password));
                }
            }
        }
    }
}
