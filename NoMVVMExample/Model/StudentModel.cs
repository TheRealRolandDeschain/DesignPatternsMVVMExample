namespace MVVMExample.Model
{
    
    public class StudentModel
    {
        #region Private Fields
        #endregion

        #region Public Properties
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public uint Age { get; set; }
        public decimal StudentFee { get; set; }
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
