using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace April30
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Student> students = new ObservableCollection<Student>();

        public MainPage()
        {
            InitializeComponent();
            StudentListView.ItemsSource = students;
        }

        private void AddStudentButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(StudentNumberEntry.Text) && ProgramPicker.SelectedItem != null && GetSelectedYearLevel() != null && !string.IsNullOrEmpty(UnitsEnrolledEntry.Text))
            {
                // Create a new student object
                Student newStudent = new Student
                {
                    StudentNumber = StudentNumberEntry.Text,
                    ProgramCourse = ProgramPicker.SelectedItem.ToString(),
                    YearLevel = GetSelectedYearLevel(),
                    NumberOfUnitsEnrolled = double.Parse(UnitsEnrolledEntry.Text)
                };

                // Calculate tuition fee, down payment, and balance
                double ratePerUnit = GetRatePerUnit(newStudent.YearLevel);
                newStudent.TuitionFee = newStudent.NumberOfUnitsEnrolled * ratePerUnit;
                newStudent.DownPayment = 0.3 * newStudent.TuitionFee;
                newStudent.Balance = newStudent.TuitionFee - newStudent.DownPayment;

                // Add the student to the collection
                students.Add(newStudent);

                // Clear input fields after adding the student
                ClearInputFields();
            }
            else
            {
                DisplayAlert("Error", "Please fill in all required fields.", "OK");
            }
        }

        private void SearchStudentButton_Clicked(object sender, EventArgs e)
        {
            // Implementation for searching students goes here
        }

        private string GetSelectedYearLevel()
        {
            if (Year1RadioButton.IsChecked) return "Freshman";
            if (Year2RadioButton.IsChecked) return "Sophomore";
            if (Year3RadioButton.IsChecked) return "Junior";
            if (Year4RadioButton.IsChecked) return "Senior";
            return null;
        }

        private double GetRatePerUnit(string yearLevel)
        {
            switch (yearLevel)
            {
                case "Freshman":
                    return 1500;
                case "Sophomore":
                    return 1800;
                case "Junior":
                    return 2000;
                case "Senior":
                    return 2300;
                default:
                    return 0;
            }
        }

        private void ClearInputFields()
        {
            StudentNumberEntry.Text = string.Empty;
            UnitsEnrolledEntry.Text = string.Empty;
            ProgramPicker.SelectedItem = null;
            Year1RadioButton.IsChecked = false;
            Year2RadioButton.IsChecked = false;
            Year3RadioButton.IsChecked = false;
            Year4RadioButton.IsChecked = false;
        }
    }
}
