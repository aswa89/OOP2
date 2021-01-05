using System;

namespace NyÅrsProjekt
{
    class Program
    {
        private static bool Menu()
        {
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();

                    Console.WriteLine("Enter your firstname:");
                    string senderName = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Enter your lastname:");
                    senderName += " " + Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Enter your identification number:");
                    int senderId = Int32.Parse(Console.ReadLine());
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

                    Person sender = new Person();
                    sender.Name = senderName;
                    sender.Id = senderId;

                    if (package.ValidateDimensions())
                    {
                        Console.WriteLine(
                        $"Sender: {sender.Name}\n" +
                        $"============\n" +
                        $"Receiver: {receiver.Name}\n" +
                        $"Street: {receiver.Address.Street}\n" +
                        $"Street number: {receiver.Address.StreetNumber}\n" +
                        $"Apartment number: {receiver.Address.ApartmentNumber}\n" +
                        $"Zip code:{receiver.Address.ZipCode}\n" +
                        $"City: {receiver.Address.City}\n" + 
                        $"Province: {receiver.Address.Province}\n" +
                        $"Price: {package.Price}kr");
                    }
                    else
                    {
                        Console.WriteLine("Not valid package dimensions");
                    }

                    return true;
                case "2":
                    Console.WriteLine("blabla");
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome!\n1) Send a package\n2) Pick up a package");
            bool ShowMenu = true;
            while (ShowMenu)
            {
                ShowMenu = Menu();
            }
            Console.WriteLine("Hello World!");
        }
    }
}
