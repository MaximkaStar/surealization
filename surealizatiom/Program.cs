using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace surealizatiom
{
    class Program
    {
        static void Main(string[] args)
        {
            const string WAY = "source.bin";

            List<BookProperty> bk = new List<BookProperty>
            {
                new BookProperty()
                {
                    Title = "IF I Stay",
                    Author = "Gail Forman",
                    PublishDate = new DateTime(2012,8,11),
                    Cost = 5000
                },
                new BookProperty()
                {
                    Title = "Were She Went",
                    Author = "Gail Forman",
                    PublishDate = new DateTime(2014,9,9),
                    Cost = 6000,
                }
            };

            BinaryFormatter changer = new BinaryFormatter();

            using (FileStream author = new FileStream(WAY, FileMode.Create))
            {
                changer.Serialize(author, bk.ToArray());
            }

            List<BookProperty> newBk;

            using (FileStream readman = new FileStream(WAY, FileMode.OpenOrCreate))
            {
                newBk = new List<BookProperty>(changer.Deserialize(readman) as BookProperty[]);
            }

            newBk.ForEach(BookProperty =>
            {
                WriteLine("Name: {0}", BookProperty.Title);
                WriteLine("Author: {0}", BookProperty.Author);
                WriteLine("Publish Date: {0}", BookProperty.PublishDate);
                WriteLine("Cost: {0}", BookProperty.Cost);

            });
            Console.ReadLine();
            Console.Clear();
        }
    }
}
