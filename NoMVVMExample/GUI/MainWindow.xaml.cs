using MVVMExample.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace NoMVVMExample.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Fields
        #endregion

        #region Public Properties
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            dgStudentList.ItemsSource = new ObservableCollection<StudentModel>();
        }
        #endregion

        #region Private Methods
        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var list = dgStudentList.ItemsSource as ObservableCollection<StudentModel>;

            list.Add(new StudentModel(
                list.Count,
                "Please Enter First Name",
                "Please Enter Last Name",
                "Please Enter Adress",
                99,
                0
                ));

        }

        private void RemoveSutdentButton_Click(object sender, RoutedEventArgs e)
        {
            StudentModel selectedItem = dgStudentList.SelectedItem as StudentModel;
            if (selectedItem == null) return;

            var list = dgStudentList.ItemsSource as ObservableCollection<StudentModel>;
            list.Remove(selectedItem);
        }

        private void LoadStudentsButton_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer reader = new XmlSerializer(typeof(ObservableCollection<StudentModel>));
            StreamReader file = new StreamReader(@"Students.xml");
            ObservableCollection<StudentModel> list = (ObservableCollection<StudentModel>)reader.Deserialize(file);
            file.Close();
            dgStudentList.ItemsSource = list;
        }

        private void SaveStudentsButton_Click(object sender, RoutedEventArgs e)
        {

            XmlSerializer writer = new XmlSerializer(typeof(ObservableCollection<StudentModel>));
            ObservableCollection<StudentModel> studentlist = dgStudentList.ItemsSource as ObservableCollection<StudentModel>;

            string path = "Students.xml";
            FileStream file = File.Create(path);

            writer.Serialize(file, studentlist);
            file.Close();

            MessageBox.Show("Student List stored to file. ");
        }


        #endregion

        #region Public Methods
        #endregion
    }
}
