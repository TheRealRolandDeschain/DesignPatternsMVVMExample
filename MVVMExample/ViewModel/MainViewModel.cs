
using MVVMExample.Model;
using MVVMExample.Utilities;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using System.Xml.Serialization;

namespace MVVMExample.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Private Fields
        private string dbPath;
        private bool saveStudendsButtonEnabled;
        private StudentModel selectedStudent;
        private ObservableCollection<StudentModel> studentList;

        private ICommand addStudentButtonPress;
        private ICommand removeStudentButtonPress;
        private ICommand loadStudentsButtonPress;
        private ICommand saveStudentsButtonPress;
        #endregion

        #region Public Properties
        public ObservableCollection<StudentModel> StudentList
        {
            get { return studentList; }
            set { SetProperty<ObservableCollection<StudentModel>>(ref studentList, value); }
        }


        /// <summary>
        /// The currently selected Student
        /// </summary>
        public StudentModel SelectedStudent
        {
            get { return selectedStudent; }
            set { SetProperty<StudentModel>(ref selectedStudent, value); }
        }

        /// <summary>
        /// Defines whether the save students button can be clicked
        /// </summary>
        public bool SaveStudentsButtonEnabled
        {
            get { return saveStudendsButtonEnabled; }
            set { SetProperty<bool>(ref saveStudendsButtonEnabled, value); }
        }

        /// <summary>
        /// Command for add student button
        /// </summary>
        public ICommand AddStudentButtonPress
        {
            get
            {
                return addStudentButtonPress ?? (addStudentButtonPress = new RelayCommand(command => AddStudentButtonPressed()));
            }
        }

        /// <summary>
        /// Command for remove student button
        /// </summary>
        public ICommand RemoveStudentButtonPress
        {
            get
            {
                return removeStudentButtonPress ?? (removeStudentButtonPress = new RelayCommand(command => RemoveStudentButtonPressed()));
            }
        }

        /// <summary>
        /// Command for load students button
        /// </summary>
        public ICommand LoadStudentsButtonPress
        {
            get
            {
                return loadStudentsButtonPress ?? (loadStudentsButtonPress = new RelayCommand(command => LoadStudentButtonPressed()));
            }
        }

        /// <summary>
        /// Command for save students button
        /// </summary>
        public ICommand SaveStudentsButtonPress
        {
            get
            {
                return saveStudentsButtonPress ?? (saveStudentsButtonPress = new RelayCommand(command => SaveStudentButtonPressed()));
            }
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            dbPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Data\\students.xml");
            SaveStudentsButtonEnabled = true;
            StudentList = new ObservableCollection<StudentModel>();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// This function adds a new student to the list
        /// </summary>
        public void AddStudentButtonPressed()
        {
            int firstAvailable = Enumerable.Range(0, StudentList.Count + 1).Except(StudentList.Select(s => s.ID).ToList()).First();

            StudentList.Add(new StudentModel(
                firstAvailable,
                "Please Enter First Name",
                "Please Enter Last Name",
                "Please Enter Adress",
                99,
                0
                ));
            SaveStudentsButtonEnabled = true;
        }

        /// <summary>
        /// This function removes the selected student from the list
        /// </summary>
        public void RemoveStudentButtonPressed()
        {
            if (SelectedStudent == null) return;
            StudentList.Remove(SelectedStudent);

            SaveStudentsButtonEnabled = true;
        }

        /// <summary>
        /// This function loads the student database
        /// </summary>
        public void LoadStudentButtonPressed()
        {
            XmlSerializer reader = new XmlSerializer(typeof(ObservableCollection<StudentModel>));
            StreamReader file = new StreamReader(dbPath);
            StudentList = (ObservableCollection<StudentModel>)reader.Deserialize(file);
            file.Close();

            SaveStudentsButtonEnabled = false;
        }


        /// <summary>
        /// This function saves the current list to the student database
        /// </summary>
        public void SaveStudentButtonPressed()
        {
            XmlSerializer writer = new XmlSerializer(typeof(ObservableCollection<StudentModel>));
            FileStream file = File.Create(dbPath);

            writer.Serialize(file, StudentList);
            file.Close();
            SaveStudentsButtonEnabled = false;
        }
        #endregion

        #region Public Properties
        #endregion
    }
}
