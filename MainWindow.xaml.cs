using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalMannMehta
{
        public partial class MainWindow : Window
        {
            private StudentContext _context;

            public MainWindow()
            {
                InitializeComponent();
                _context = new StudentContext();
            }

            private void AddStudentButton_Click(object sender, RoutedEventArgs e)
            {
                
                    double gpa;
                    if (double.TryParse(GPATextBox.Text, out gpa) && gpa >= 0.0 && gpa <= 4.0)
                    {
                        var student = new Student
                        {
                            Name = NameTextBox.Text,
                            Age = int.TryParse(AgeTextBox.Text, out int age) ? age : 0,
                            GPA = gpa,
                            IsHonors = gpa >= 3.5
                        };

                        _context.Students.Add(student);
                        _context.SaveChanges();
                        MessageBox.Show("Student added successfully!");
                        LoadStudents();
                    }
                    else
                    {
                        MessageBox.Show("GPA must be between 0.0 and 4.0.", "Input Error");
                    }
                
              
            }

            private void LoadStudentsButton_Click(object sender, RoutedEventArgs e)
            {
                LoadStudents();
            }

            private void ClearFieldsButton_Click(object sender, RoutedEventArgs e)
            {
                NameTextBox.Clear();
                AgeTextBox.Clear();
                GPATextBox.Clear();
                StudentsDataGrid.ItemsSource = null;  // Clears the DataGrid
            }

            private void LoadStudents()
            {
                StudentsDataGrid.ItemsSource = _context.Students.ToList();  // Loads all students into the DataGrid
            }
        }
    }