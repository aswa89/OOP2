using System;
using System.Data.SqlClient; 

namespace NyÅrsProjekt
{
    class Program
    {
        private static bool Menu()
        {

            // Data Source is the name of the  
            // server on which the database is stored. 
            // The Initial Catalog is used to specify 
            // the name of the database 
            // The UserID and Password are the credentials 
            // required to connect to the database. 
            //string constr = @"Data Source=DESKTOP-GP8F496;Initial Catalog=Demodb;User ID=sa;Password=24518300";
            //string constr = @"Data Source=DESKTOP-P64IP0G;Initial Catalog=testdatabase;User ID=robin;Password=";
            string constr = @"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = testdatabase; Integrated Security = True";
            //source = DESKTOP-P64IP0G

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();

                    PersonAddress receiver = new PersonAddress();
                    receiver.Address = new Address();

                    Console.WriteLine("Enter receivers firstname:");
                    receiver.Name = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Enter receivers lastname:");
                    receiver.Name += " " + Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Enter receivers street:");
                    receiver.Address.Street = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Enter receivers street number:");
                    receiver.Address.StreetNumber = Int32.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("Enter receivers apartment number:");
                    receiver.Address.ApartmentNumber = Int32.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("Enter receivers zip code:");
                    receiver.Address.ZipCode = Int32.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("Enter receivers city:");
                    receiver.Address.City = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Enter receivers province:");
                    receiver.Address.Province = Console.ReadLine();
                    Console.Clear();

                    Package package = new Package();
                    package.Receiver = receiver;

                    Console.WriteLine("Enter package weigth:");
                    package.Weight = Int32.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("Enter package width:");
                    package.Width = Int32.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("Enter package length:");
                    package.Length = Int32.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("Enter package height:");
                    package.Height = Int32.Parse(Console.ReadLine());
                    Console.Clear();

                    if (package.ValidateDimensions())
                    {
                        Console.WriteLine(
                        $"Receiver: {receiver.Name}\n" +
                        $"Street: {receiver.Address.Street}\n" +
                        $"Street number: {receiver.Address.StreetNumber}\n" +
                        $"Apartment number: {receiver.Address.ApartmentNumber}\n" +
                        $"Zip code:{receiver.Address.ZipCode}\n" +
                        $"City: {receiver.Address.City}\n" + 
                        $"Province: {receiver.Address.Province}\n" +
                        $"Price: {package.Price}kr");

                        // for the connection to  
                        // sql server database 
                        SqlConnection conn = new SqlConnection(constr); 
                   
                        // to open the connection 
                        conn.Open();
                          
                        // data adapter object is use to  
                        // insert, update or delete commands 
                        SqlDataAdapter adap = new SqlDataAdapter();

                        // TODO: get inserted IDs

                        string sqlAddress = $"INSERT INTO Address VALUES('{package.Receiver.Address.Street}', {package.Receiver.Address.StreetNumber}, {package.Receiver.Address.ApartmentNumber}, {package.Receiver.Address.ZipCode}, '{package.Receiver.Address.City}', '{package.Receiver.Address.Province}')";

                        adap.InsertCommand = new SqlCommand(sqlAddress, conn);
                        adap.InsertCommand.ExecuteNonQuery();

                        string sqlPersonAddress = $"INSERT INTO PersonAddress VALUES('{package.Receiver.Name}', '{package.Receiver.CareOf}', {0})";

                        adap.InsertCommand = new SqlCommand(sqlPersonAddress, conn);
                        adap.InsertCommand.ExecuteNonQuery();

                        string sqlPackage = $"INSERT INTO Package VALUES({package.Weight}, {package.Width}, {package.Height}, {package.Length}, {0}, {0})";  

                        adap.InsertCommand = new SqlCommand(sqlPackage, conn);
                        adap.InsertCommand.ExecuteNonQuery();
                          
                        // closing all the objects 
                        // cmd.Dispose();
                        conn.Close();
                    }
                    else
                    {
                        Console.WriteLine("Invalid package dimensions");
                    }

                    return true;
                case "2":
                    string packageIdTxt = Console.ReadLine();
                    int packageId = int.Parse(packageIdTxt);
                    // SELECT * WHERE ID={packageId} blabla bla 

                    {
                        // for the connection to  
                        // sql server database 
                        SqlConnection conn = new SqlConnection(constr);

                        // to open the connection 
                        conn.Open();

                        // use to perform read and write 
                        // operations in the database 
                        SqlCommand cmd;

                        // use to read a row in 
                        // table one by one 
                        SqlDataReader dreader;

                        // to sore SQL command and 
                        // the output of SQL command 
                        string sql, output = "";

                        // use to fetch rwos from demo table 
                        sql = $"SELECT * FROM Package WHERE Id={packageId}";

                        // to execute the sql statement 
                        cmd = new SqlCommand(sql, conn);

                        // fetch all the rows  
                        // from the demo table 
                        dreader = cmd.ExecuteReader();

                        // for one by one reading row 
                        while (dreader.Read())
                        {
                            // Change
                            output = output + dreader.GetValue(0) + " - " + dreader.GetValue(1) + "\n";
                        }

                        // to display the output 
                        Console.Write(output);

                        // to close all the objects 
                        dreader.Close();
                        cmd.Dispose();
                        conn.Close();
                    }
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!\n1) Send a package\n2) Pick up a package\n3) Exit");
            while (Menu()) { }
        }
    }
}
