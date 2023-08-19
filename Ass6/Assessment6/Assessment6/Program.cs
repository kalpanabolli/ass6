using System;
using System.Data.SqlClient;
using System.Text;

namespace Assessment6
{
    internal class Program
    {
        static SqlDataReader reader;
        static SqlCommand cmd;
        static SqlConnection con;
        static string conStr = "server=DESKTOP-898SEC1;database=ProductInventoryDb; trusted_connection=true;";
        static void Main(string[] args)
        {
            try
            {
                repeat:
                con = new SqlConnection(conStr);
                cmd = new SqlCommand("Select* from Products", con);
                Console.WriteLine("Find out 1.view 2.Insert 3.Update 4.Delete , Enter your choice 1,2, 3, or 4");

                Console.WriteLine("Enter your Choice");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            con.Open();
                            reader = cmd.ExecuteReader();
                            Console.WriteLine("PId \t PName \t Price \t Quantity \t MfDate \t ExpDate ");
                            while (reader.Read())
                            {

                                Console.Write(reader["PId"] + "\t\t");
                                Console.Write(reader["PName"] + "\t \t");
                                Console.Write(reader["Price"] + "\t\t");
                                Console.Write(reader["Quantity"] + "\t\t");
                                Console.Write(reader["MfDate"] + "\t");
                                Console.Write(reader["ExpDate"] + "\t");
                                Console.WriteLine("\n");

                            }
                            break;
                        }
                    case 2:
                        {




                            con = new SqlConnection(conStr);
                            cmd = new SqlCommand()
                            {
                                CommandText = "insert into Products(PID,PName,Price,Quantity,MfDate,ExpDate)values(@Pid,@Pn,@Pp,@Quan,@MfD,@ExpD)",
                                Connection = con
                            };




                            Console.WriteLine("Enter Product PId");
                            cmd.Parameters.AddWithValue("@Pid", int.Parse(Console.ReadLine()));
                            Console.WriteLine("Enter Product PName");
                            cmd.Parameters.AddWithValue("@Pn", Console.ReadLine());
                            Console.WriteLine("Enter Product Price");
                            cmd.Parameters.AddWithValue("@Pp", Console.ReadLine());
                            Console.WriteLine("Enter Product Quantity");
                            cmd.Parameters.AddWithValue("@Quan", double.Parse(Console.ReadLine()));
                            Console.WriteLine("Enter Product MfDate");
                            cmd.Parameters.AddWithValue("@MfD", Console.ReadLine());
                            Console.WriteLine("Enter Product ExpDate");
                            cmd.Parameters.AddWithValue("@ExpD", Console.ReadLine());
                            con.Open();
                            int nor = cmd.ExecuteNonQuery();

                            if (nor >= 1)
                            {
                                Console.WriteLine("Record Inserted!!!");
                            }

                            con.Close();


                            break;
                        }
                    case 3:
                        {
                            int PId;

                            Console.WriteLine("Enter Products PId to update details ");

                            PId = int.Parse(Console.ReadLine());

                            con = new SqlConnection(conStr);

                            cmd = new SqlCommand()

                            {
                                CommandText = "select * from Products where PId=@Pid ",

                                Connection = con
                            };
                            cmd.Parameters.AddWithValue("@Pid", PId);
                            con.Open();
                            reader = cmd.ExecuteReader();

                            if (reader.HasRows)
                            {

                                con.Close();

                                con.Open();

                                cmd.CommandText = "update Products set  Quantity=@Quan where PId=@Pid";


                                Console.WriteLine("Enter New Quantity");

                                cmd.Parameters.AddWithValue("@Quan", Console.ReadLine());



                                cmd.ExecuteNonQuery(); Console.WriteLine("Record Updated");

                            }

                            else
                            {
                                Console.WriteLine($"No Such PId {PId} exist in our database");
                            }

                            break;
                        }


                    case 4:
                        {
                            cmd = new SqlCommand()
                            {
                                CommandText = "delete from Products where PId=@Pid",
                                Connection = con
                            };
                            Console.WriteLine("Enter Product PId to Delete");
                            cmd.Parameters.AddWithValue("@Pid", int.Parse(Console.ReadLine()));

                            con.Open();
                            int nor = cmd.ExecuteNonQuery();
                            if (nor >= 1)
                            {
                                Console.WriteLine("Record Deleted!!!");
                            }
                        }
                        break;

                }

                Console.WriteLine("Wanna Try Again? \nIf Yes Type '1'");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                    goto repeat;
                else
                    Console.WriteLine("End Of The Funtion\nGood Bye!!!");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
        
    }
}