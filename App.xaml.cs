using CSC317PassManagerP2Starter.Modules.Controllers;
using CSC317PassManagerP2Starter.Modules.Views;

namespace CSC317PassManagerP2Starter
{
    public partial class App : Application
    {
        public static LoginController login_controller = new();
        public static PasswordController password_controller = new();

        public App()
        {
            InitializeComponent();
            MainPage = new LoginView();
        }
    }
}
