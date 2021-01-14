using MVVMExample.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
        string dbPath;
        #endregion

        #region Public Properties
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            dgStudentList.ItemsSource = new ObservableCollection<StudentModel>();
            dbPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Data\\students.xml");
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This function adds a new student to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            var list = dgStudentList.ItemsSource as ObservableCollection<StudentModel>;  
            int firstAvailable = Enumerable.Range(0, list.Count + 1).Except(list.Select(s => s.ID).ToList()).First();

            list.Add(new StudentModel(
                firstAvailable,
                "Please Enter First Name",
                "Please Enter Last Name",
                "Please Enter Adress",
                99,
                0
                ));
        }

        /// <summary>
        /// This function removes the selected student from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveSutdentButton_Click(object sender, RoutedEventArgs e)
        {
            StudentModel selectedItem = dgStudentList.SelectedItem as StudentModel;
            if (selectedItem == null) return;

            var list = dgStudentList.ItemsSource as ObservableCollection<StudentModel>;
            list.Remove(selectedItem);
        }


        /// <summary>
        /// This function loads the student database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadStudentsButton_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer reader = new XmlSerializer(typeof(ObservableCollection<StudentModel>));
            StreamReader file = new StreamReader(dbPath);
            ObservableCollection<StudentModel> list = (ObservableCollection<StudentModel>)reader.Deserialize(file);
            file.Close();
            dgStudentList.ItemsSource = list;
        }

        /// <summary>
        /// This function saves the current list to the student database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveStudentsButton_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer writer = new XmlSerializer(typeof(ObservableCollection<StudentModel>));
            ObservableCollection<StudentModel> studentlist = dgStudentList.ItemsSource as ObservableCollection<StudentModel>;

            FileStream file = File.Create(dbPath);

            writer.Serialize(file, studentlist);
            file.Close();

            MessageBox.Show("Student List stored to file. ");
        }


        #endregion

        #region Public Methods
        #endregion
    }
}
