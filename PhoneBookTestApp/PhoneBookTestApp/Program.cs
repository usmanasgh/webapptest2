using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                              
                DatabaseUtil.initializeDatabase();
                /* TODO: create person objects and put them in the PhoneBook and database
                * John Smith, (248) 123-4567, 1234 Sand Hill Dr, Royal Oak, MI
                * Cynthia Smith, (824) 128-8758, 875 Main St, Ann Arbor, MI
                */
                Program program = new Program();
                PhoneBook phonebook = new PhoneBook();
                Person person = new Person();

                phonebook.addPerson(program.FillPerson("John Smith", "(248) 123-4567", "1234 Sand Hill Dr, Royal Oak, MI"));
                phonebook.addPerson(program.FillPerson("Cynthia Smith", "(824) 128-8758", "875 Main St, Ann Arbor, MI"));

                // TODO: print the phone book out to System.out
                Console.WriteLine(phonebook.printPhonebook());
                // TODO: find Cynthia Smith and print out just her entry
                person = phonebook.findPerson("Cynthia", "Smith");
                Console.WriteLine("Result Found"+" ** "+ person.name + " " + person.phoneNumber + " " + person.address);
                // TODO: insert the new person objects into the database
                phonebook.addPerson(program.FillPerson(person.name, person.phoneNumber, person.address));
      
            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
            public Person FillPerson(string name,string phoneNumber, string address)
        {
            Person person = new Person();
            person.name = name;
            person.phoneNumber = phoneNumber;
            person.address = address;
            return person;
        }
    
    }
}
