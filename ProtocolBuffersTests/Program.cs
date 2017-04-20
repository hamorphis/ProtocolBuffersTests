using System;
using System.IO;
using Google.Protobuf;
using static ProtocolBuffersTests.Person.Types;

namespace ProtocolBuffersTests
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();

            Person rossen = new Person
            {
                Id = 1234,
                Name = "Rossen Hristov",
                Email = "rossen.hristov@chaosgroup.com",
                Phones = { new PhoneNumber { Number = "+359887442902", Type = PhoneType.Mobile } }
            };

            addressBook.People.Add(rossen);

            Console.WriteLine(addressBook.CalculateSize());

            using (var output = File.Create("rossen.dat"))
            {
                rossen.WriteTo(output);
            }

            Console.ReadLine();
        }
    }

}
