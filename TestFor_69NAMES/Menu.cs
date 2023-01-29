using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;

namespace TestFor_69NAMES
{
    public class Menu
    {
        public void DoAction()
        {
            while (true)
            {
                var userChoice = Convert.ToInt32(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                    case 5:
                        Task5();
                        break;
                    default:
                        Console.WriteLine("Выберите корректное значение от [1] до [5]");
                        break;
                }
            }
        }
        private class TableObject
        {
            public string surname;
            public string name;
            public string email;
            public string number;
            public string _birthday;
        }
        
        public void Task1()
        {
            string connectionString = "Server=MAGNAT;Database=test;Trusted_Connection=True;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Contracts_ WHERE(Date_of_signing) > '01.01.2023  00:00:00' ", sqlConnection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader[i].ToString() + " ");
                            }

                            Console.WriteLine();
                        }
                    }
                }
                
                sqlConnection.Close();
            }
        }

        public void Task2()
        {
            string connectionString = "Server=MAGNAT;Database=test;Trusted_Connection=True;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand =
                       new SqlCommand(
                           "SELECT Contract_sum FROM Contracts_ JOIN Juridical_entity ON Juridicalllll_ID = Juridical_ID WHERE country_='Russia';  ",
                           sqlConnection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        int sum = 0;
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                sum += Convert.ToInt32(reader[i]);
                            }
                        }

                        Console.WriteLine(sum);
                    }
                }

                sqlConnection.Close();
            }
        }

        public void Task3()
        {
            string connectionString = "Server=MAGNAT;Database=test;Trusted_Connection=True;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(
                           "SELECT e_mail FROM Juridical_entity JOIN Contracts_ ON Juridicalllll_ID = Juridical_ID JOIN Physical_entity ON Authorized_ID = individual_ID WHERE Date_of_signing BETWEEN DATEADD(DAY , -30 , GETDATE()) AND GETDATE() AND Contract_sum > 40000",
                           sqlConnection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader[i].ToString() + " ");
                            }

                            Console.WriteLine();
                        }
                    }
                }


                sqlConnection.Close();
            }
        }

        public void Task4()
        {
            string connectionString = "Server=MAGNAT;Database=test;Trusted_Connection=True;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(
                           " UPDATE Contracts_ SET Status_= 'signed' FROM Juridical_entity JOIN Contracts_ ON Juridicalllll_ID = Juridical_ID JOIN Physical_entity ON Authorized_ID = individual_ID WHERE age_ >= 60;",
                           sqlConnection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader[i].ToString() + " ");
                            }

                            Console.WriteLine();
                        }
                    }
                }


                sqlConnection.Close();
            }
        }

        public void Task5()
        {
            List<TableObject> jsonFile = new List<TableObject>();
            string connectionString = "Server=MAGNAT;Database=test;Trusted_Connection=True;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(
                           "SELECT surname_,name_,patronymic_,e_mail,mobile_number,birth_date FROM Physical_entity JOIN Contracts_ ON individual_ID = Juridical_ID JOIN Juridical_entity ON Authorized_ID = Juridicalllll_ID WHERE city__ = 'Moscow' AND Status_ = 'Signed';",
                           sqlConnection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            TableObject json = new TableObject();
                            
                            json.name = reader.GetString(0);
                            json.surname = reader.GetString(1);
                            json.email = reader.GetString(2);
                            json._birthday = reader.GetString(3);
                            json.number = reader.GetString(4);
                            
                            jsonFile.Add(json);
                        }
                    }
                }
            }

            SerializationAndSave(jsonFile);
        }
        
        public void SerializationAndSave<T>(List<T> checks)
        {
            string json = JsonConvert.SerializeObject(checks);
            File.WriteAllText("D://Json.json", json);
        }
    }
}