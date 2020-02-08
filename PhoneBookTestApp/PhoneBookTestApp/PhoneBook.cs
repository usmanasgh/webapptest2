namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        public void addPerson(Person newPerson)
        {
            DatabaseUtil.AddPerson(newPerson.name, newPerson.phoneNumber, newPerson.address);
        }

        public Person findPerson(string firstName, string lastName)
        {
            Person findPerson = new Person();
            findPerson = DatabaseUtil.findPerson(firstName, lastName);
            return findPerson;
        }
         
        public string printPhonebook()
        {
            return DatabaseUtil.printPhonebook();
        }
    }
}