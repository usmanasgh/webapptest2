namespace PhoneBookTestApp
{
    public class Person
    {
        string _name;
        public string name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        string _phoneNumber;
        public string phoneNumber
        {
            get
            {
                return this._phoneNumber;
            }
            set
            {
                this._phoneNumber = value;
            }
        }

        string _address;
        public string address
        {
            get
            {
                return this._address;
            }
            set
            {
                this._address = value;
            }
        }
    }
}