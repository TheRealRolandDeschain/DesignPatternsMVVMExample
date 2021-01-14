using MVVMExample.ViewModel;

namespace MVVMExample.Model
{
    public class StudentModel : ViewModelBase
    {
        #region Private Fields
        private int id;
        private string firstName;
        private string lastName;
        private uint age;
        private string adress;
        private decimal studentFee;
        #endregion

        #region Public Properties
        public int ID 
        { 
            get { return id; }
            set { SetProperty<int>(ref id, value); }
        }

        public string FirstName
        {
            get { return firstName; }
            set { SetProperty<string>(ref firstName, value); }
        }

        public string LastName
        {
            get { return lastName; }
            set { SetProperty<string>(ref lastName, value); }
        }

        public uint Age
        {
            get { return age; }
            set { SetProperty<uint>(ref age, value); }
        }

        public string Adress
        {
            get { return adress; }
            set { SetProperty<string>(ref adress, value); }
        }

        public decimal StudentFee
        {
            get { return studentFee; }
            set { SetProperty<decimal>(ref studentFee, value); }
        }
        #endregion

        #region Constructors
        public StudentModel() { }

        public StudentModel(int _id, string _firstname, string _lastname, string _adress, uint _age, decimal _studentfee)
        {
            ID = _id;
            FirstName = _firstname;
            LastName = _lastname;
            Adress = _adress;
            Age = _age;
            StudentFee = _studentfee;
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion
    }
}
