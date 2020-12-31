using MVVMExample.ViewModel;

namespace MVVMExample.Model
{
    public class StudentModel : ViewModelBase
    {
        #region Private Fields
        private long id;
        private string firstName;
        private string lastName;
        private uint age;
        private string adress;
        private decimal studentFee;
        #endregion

        #region Public Properties
        public long ID 
        { 
            get { return id; }
            set { SetProperty<long>(ref id, value); }
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
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion
    }
}
