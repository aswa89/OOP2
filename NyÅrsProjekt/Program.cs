using System;
using System.Data.SqlClient; 

namespace NyÅrsProjekt
{
    class Program
    {
        private static bool Menu()
        {
            string constr = @"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = testdatabase; Integrated Security = True";

            switch (Console.ReadLine())
            {
                // Add package to database
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

                    Console.WriteLine("Enter package weight (max 50000) (g):");
                    package.Weight = Int32.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("Enter package width (min 90) (mm):");
                    package.Width = Int32.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("Enter package length 140-1500(mm):");
                    package.Length = Int32.Parse(Console.ReadLine());
                    Console.Clear();

                    Console.WriteLine("Enter package height (min 15) (mm):");
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

                        SqlConnection conn = new SqlConnection(constr); 
                   
                        conn.Open();
                          
                        SqlDataAdapter adap = new SqlDataAdapter();

                        string sqlAddress = $"INSERT INTO Address VALUES('{package.Receiver.Address.Street}', {package.Receiver.Address.StreetNumber}, {package.Receiver.Address.ApartmentNumber}, {package.Receiver.Address.ZipCode}, '{package.Receiver.Address.City}', '{package.Receiver.Address.Province}') SELECT SCOPE_IDENTITY()";

                        adap.InsertCommand = new SqlCommand(sqlAddress, conn);
                        int addressId = Convert.ToInt32(adap.InsertCommand.ExecuteScalar());

                        string sqlPersonAddress = $"INSERT INTO PersonAddress VALUES('{package.Receiver.Name}', '{package.Receiver.CareOf}', {addressId}) SELECT SCOPE_IDENTITY()";

                        adap.InsertCommand = new SqlCommand(sqlPersonAddress, conn);
                        int personAddressId = Convert.ToInt32(adap.InsertCommand.ExecuteScalar());

                        string sqlPackage = $"INSERT INTO Package VALUES({package.Weight}, {package.Width}, {package.Height}, {package.Length}, {personAddressId}, {0}) SELECT SCOPE_IDENTITY()";  

                        adap.InsertCommand = new SqlCommand(sqlPackage, conn);
                        int insertedId = Convert.ToInt32(adap.InsertCommand.ExecuteScalar());

                        Console.WriteLine($"Inserted packaged #{insertedId}");

                        conn.Close();
                    }
                    else
                    {
                        Console.WriteLine("Invalid package dimensions");
                    }

                    return true;

                // Search database for package ID
                case "2":
                    Console.WriteLine("Enter package id:");
                    int packageId = Int32.Parse(Console.ReadLine());
                    {
                        SqlConnection conn = new SqlConnection(constr);
                        conn.Open();
                        SqlCommand cmd;
                        SqlDataReader dreader;

                        string sql, output = "";

                        sql = $"SELECT Package.Id, PersonAddress.Name, Address.Street FROM Package JOIN PersonAddress ON Package.Receiver=PersonAddress.Id JOIN Address ON PersonAddress.Address=Address.Id WHERE Package.Id={packageId}";

                        cmd = new SqlCommand(sql, conn);

                        dreader = cmd.ExecuteReader();

                        while (dreader.Read())
                        {
                            output +=
                                "ID: " + dreader.GetValue(0) + "\n" +
                                "Name: " + dreader.GetValue(1) + "\n" +
                                "Street: " + dreader.GetValue(2) + "\n" +
                                "\n";
                        }

                        if (output.Length == 0)
                        {
                            output = "No packages found!\n";
                        }

                        Console.Write(output);

                        dreader.Close();
                        cmd.Dispose();
                        conn.Close();
                    }
                    return true;
                case "3":
                    return false;
                default:
                    Console.WriteLine("Invalid command!");
                    return true;
            }
        }
        
        static void Main(string[] args)
        {
            string menu = "Welcome!\n1) Send a package\n2) Pick up a package\n3) Exit";
            Console.WriteLine(menu);
            while (Menu())
            {
                Console.WriteLine("Press Enter to return to menu...");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine(menu);
            }
        }
    }
}
