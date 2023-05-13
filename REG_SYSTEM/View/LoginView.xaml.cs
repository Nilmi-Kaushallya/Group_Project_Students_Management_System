using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace REG_SYSTEM.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton== MouseButtonState.Pressed) 
                DragMove();
        }

        private void btnminimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }



        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            var Username = txtUser.Text;
            var Password = txtPass.Password;

            
            using (UserDataContext context = new UserDataContext())
            {
                
                bool userfound = context.Users.Any(user => user.Name == Username && user.Password == Password);
                
                if(userfound) 
                {
                    GrantAccess();
                    Close();
                }

                else
                {
                    MessageBox.Show("User Not Found");
                }

            }
            
        }





        public void GrantAccess()
        {
            MainWindow main = new MainWindow();
            main.Show();
        }

        
    }
}
