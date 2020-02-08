using System;
using System.Data;
using System.Data.SQLite;

namespace PhoneBookTestApp
{
    public class DatabaseUtil
    {
        public static void initializeDatabase()
        {
            //CleanUp();
            var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
            dbConnection.Open();

            try
            {
                SQLiteCommand command =
                    new SQLiteCommand(
                        "create table PHONEBOOK (NAME varchar(255), PHONENUMBER varchar(255), ADDRESS varchar(255))",
                        dbConnection);
                command.ExecuteNonQuery();

                command =
                    new SQLiteCommand(
                        "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('Chris Johnson','(321) 231-7876', '452 Freeman Drive, Algonac, MI')",
                        dbConnection);
                command.ExecuteNonQuery();

                command =
                    new SQLiteCommand(
                        "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('Dave Williams','(231) 502-1236', '285 Huron St, Port Austin, MI')",
                        dbConnection);
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public static void AddPerson(string name, string phoneNumber, string address)
        {
            var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
            dbConnection.Open();

            try
            {
                SQLiteCommand command =
                    new SQLiteCommand(
                        "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('"+name+"','"+phoneNumber+"', '"+address+"')",
                        dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public static Person findPerson(string firstName, string lastName)
        {
            var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
            dbConnection.Open();
            Person person = new Person();

            try
            {
                string Query = "SELECT * FROM PHONEBOOK WHERE NAME Like '%" + firstName + "%' And Name Like '%" + lastName + "%'";
                SQLiteCommand command =
                    new SQLiteCommand(Query, dbConnection);
                SQLiteDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                    person.name = $"{ Reader.GetString(0)}";
                    person.phoneNumber = $"{ Reader.GetString(1)}";
                    person.address = $"{ Reader.GetString(2)}";
                }
                Reader.Close();
                return person;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public static string printPhonebook()
        {
            var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
            dbConnection.Open();

            try
            {
                string result = "******      PHONEBOOK      ******" + System.Environment.NewLine;
                string Query = "SELECT * FROM PHONEBOOK";
                SQLiteCommand command =
                    new SQLiteCommand(Query,dbConnection);
                SQLiteDataReader Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    result += ($"{Reader.GetString(0)} {Reader.GetString(1)} {Reader.GetString(2)}" + System.Environment.NewLine);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        public static SQLiteConnection GetConnection()
        {
            var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
            dbConnection.Open();

            return dbConnection;
        }

        public static void CleanUp()
        {
            var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
            dbConnection.Open();

            try
            {
                SQLiteCommand command =
                    new SQLiteCommand(
                        "drop table PHONEBOOK",
                        dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}