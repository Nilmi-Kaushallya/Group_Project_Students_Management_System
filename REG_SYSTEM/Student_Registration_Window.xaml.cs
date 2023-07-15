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
    /// Interaction logic for Student_Registration_Window.xaml
    /// </summary>
    public partial class Student_Registration_Window : Window
    {
        public List<Students> DatabaseUsers { get; private set; }

        public Student_Registration_Window()
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
                var address = AddressTextBox.Text;
                //want to change the variable type
                /*
                var EE3301 = EE3301TextBox.Text; 
                var EE3302 = EE3302TextBox.Text;
                var EE3303 = EE3303TextBox.Text;
                var gpa = GPATextBox.Text;
                */

                if (name != null && address != null)//&& EE3301!=null && EE3302 != null && EE3303 != null && gpa !=null
                {
                    context.Students.Add(new Students()
                    {
                        Name = name,
                        Address = address
                        //EE3301 = EE3301,
                        //EE3302 = EE3302,
                        //EE3303= marks_EE3303,
                        //GPA=gpa
                    });
                    context.SaveChanges();

                }

                
            }

        }

        public void Read()
        {
            using (UserDataContext context = new UserDataContext()) 
            {
                DatabaseUsers = context.Students.ToList();
                Itemlist.ItemsSource = DatabaseUsers;
            }
        }

        public void Update()
        {
            using (UserDataContext context = new UserDataContext())
            {
                Students selectedStudents = Itemlist.SelectedItem as Students;

                var name = NameTextBox.Text;
                var address = AddressTextBox.Text;
                //want to change the name
                /*
                var EE3301 = EE3301TextBox.Text;   
                var EE3302 = EE3302TextBox.Text;
                var EE3303 = EE3303TextBox.Text;
                var gpa = GPATextBox.Text;
                */

                if (name != null && address != null)//&& EE3301 != null && EE3302 != null && EE3303 != null && gpa != null
                {
                    Students Student = context.Students.Find(selectedStudents.Reg_No);
                    Student.Name = name;
                    Student.Address = address;
                    //Students.EE3301 = EE3301;
                    //Students.EE3302 = EE3302TextBox.Text;
                    //Students.EE3303 = EE3303TextBox.Text;
                    //Students.GPA = GPATextBox.Text;

                    context.SaveChanges();
                }
            }

        }

        public void Delete()
        {
            using (UserDataContext context = new UserDataContext())
            {
                Students selectedStudents = Itemlist.SelectedItem as Students;

                if(selectedStudents != null) 
                {
                    Students Students = context.Students.Single(x=> x.Reg_No == selectedStudents.Reg_No);

                    context.Remove(Students);
                    context.SaveChanges();

                }
                 

            }
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Itemlist.Items.Clear();
        }
    }
}
