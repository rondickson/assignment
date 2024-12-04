using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC317PassManagerP2Starter.Modules.Models;



/* This module contains the class definition for Password Row.
 * 
 * The methods are missing their bodies.  Fill in the method definitions below.
 * 
 */
namespace CSC317PassManagerP2Starter.Modules.Views
{
    public class PasswordRow : INotifyPropertyChanged
    {
        private PasswordModel pass;
        private bool isVisible;
        private bool editing;

        public PasswordRow(PasswordModel source)
        {
            pass = source;
            isVisible = false;
            editing = false;
        }

        public string PlatformName
        {
            get => pass.PlatformName;
            set
            {
                pass.PlatformName = value;
                OnPropertyChanged(nameof(PlatformName));
            }
        }

        public string PlatformUserName
        {
            get => pass.PlatformUserName;
            set
            {
                pass.PlatformUserName = value;
                OnPropertyChanged(nameof(PlatformUserName));
            }
        }

        // PasswordRow.cs
        public string PlatformPassword
        {
            get
            {
                var currentUser = App.login_controller.GetCurrentUser();
                return isVisible ? PasswordCrypto.Decrypt(pass.PasswordText) : "<hidden>";
            }
            set
            {
                pass.PasswordText = PasswordCrypto.Encrypt(value);
                OnPropertyChanged(nameof(PlatformPassword));
            }
        }



        public int PasswordID => pass.ID;

        public bool IsShown
        {
            get => isVisible;
            set
            {
                isVisible = value;
                OnPropertyChanged(nameof(IsShown));
            }
        }

        public bool Editing
        {
            get => editing;
            set
            {
                editing = value;
                OnPropertyChanged(nameof(Editing));
            }
        }

        public void RefreshRow() => OnPropertyChanged(string.Empty);

        public void SavePassword() => App.password_controller.UpdatePassword(pass);

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
