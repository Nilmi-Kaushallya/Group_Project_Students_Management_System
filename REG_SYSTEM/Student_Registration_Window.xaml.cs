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
            using (DataContext context = new DataContext())
            {
                var name = NameTextBox.Text;
                var address = AddressTextBox.Text;
                //var marks_Is3301 = MarksIS3301TextBox.Text;
                //var marks_EE3302 = MarksEE3302TextBox.Text;
                //var marks_EE3251 = MarksEE3251TextBox;
                //var gpa = GPATextBox.Text;

                if (name != null && address != null)
                {
                    context.Users.Add(new Students()
                    {
                        Name = name,
                        Address = address,
                        //Marks_IS3301 = marks_Is3301,
                        // Marks_EE3302 = marks_EE3302,
                        // Marks_EE3251=marks_EE3251,
                        //GPA=gpa
                    });
                    context.SaveChanges();

                }

                
            }

        }

        public void Read()
        {
            using (DataContext context = new DataContext()) 
            {
                DatabaseUsers = context.Users.ToList();
                Itemlist.ItemsSource = DatabaseUsers;
            }
        }

        public void Update()
        {
            using (DataContext context = new DataContext())
            {
                Students selectedStudent = Itemlist.SelectedItem as Students;

                var name = NameTextBox.Text;
                var address = AddressTextBox.Text;

                if(name != null && address != null) 
                {
                    Students students = context.Users.Find(selectedStudent.Reg_No);
                    students.Name = name;
                    students.Address = address;

                    context.SaveChanges();
                }
            }

        }

        public void Delete()
        {
            using (DataContext context = new DataContext())
            {
                Students selectedStudent = Itemlist.SelectedItem as Students;

                if(selectedStudent != null) 
                {
                    Students students = context.Users.Single(x=> x.Reg_No == selectedStudent.Reg_No);

                    context.Remove(students);
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
