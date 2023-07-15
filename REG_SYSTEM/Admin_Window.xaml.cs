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

namespace REG_SYSTEM
{
    /// <summary>
    /// Interaction logic for Admin_Window.xaml
    /// </summary>
    public partial class Admin_Window : Window
    {
        public List<User> DatabaseUsers { get; private set; }

        public Admin_Window()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
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


        public void Create()
        {
            using (UserDataContext context = new UserDataContext())
            {
               var name = NameTextBox.Text;
               var password = PasswordTextBox.Text;
               

                if (name != null && password!= null)
                {
                    context.Users.Add(new User()
                    {
                        Name = name,
                        Password = password
                                            
                    });
                    context.SaveChanges();

                }


            }

        }

        public void Read()
        {
            using (UserDataContext context = new UserDataContext())
            {
                DatabaseUsers = context.Users.ToList();
                Itemlist.ItemsSource = DatabaseUsers;
            }
        }

        public void Update()
        {
            using (UserDataContext context = new UserDataContext())
            {
                User selectedUser = Itemlist.SelectedItem as User;

                var name = NameTextBox.Text;
                var password = PasswordTextBox.Text;

                if (name != null && password != null)
                {
                    User user = context.Users.Find(selectedUser.Id);
                    user.Name = name;
                    user.Password = password;

                    context.SaveChanges();
                }
            }

        }

        public void Delete()
        {
            using (UserDataContext context = new UserDataContext())
            {
                User selectedUser = Itemlist.SelectedItem as User;

                if (selectedUser != null)
                {
                   User user = context.Users.Single(x=> x.Id == selectedUser.Id);

                    context.Remove(user);
                    context.SaveChanges();

                }


            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Itemlist.Items.Clear();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();

        }
    }
}

