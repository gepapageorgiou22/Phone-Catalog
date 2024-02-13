using PhoneBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API
{
    public class DataSeeder
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.PhoneBooks.Any())
            {
                var phonebooks = new List<Model.PhoneBook>()
                 {
                    new Model.PhoneBook
                    {
                        Name = "Work",
                        Entries = new List<Model.Entry>
                        {
                            new Model.Entry() { Name = "John Smith", PhoneNumber = "0214568834" },
                            new Model.Entry() { Name = "Ziva Salinas", PhoneNumber = "0113453456" },
                            new Model.Entry() { Name = "Stefania Dickerson", PhoneNumber = "0723455322" },
                            new Model.Entry() { Name = "Fallon Ashton", PhoneNumber = "0823455303" }
                        }
                    },
                    new Model.PhoneBook
                    {
                        Name = "Home",
                        Entries = new List<Model.Entry>
                        {
                            new Model.Entry() { Name = "Victoria Drummond", PhoneNumber = "0217900452" },
                            new Model.Entry() { Name = "Arbaaz Walker", PhoneNumber = "0314549633" },
                            new Model.Entry() { Name = "Thomas Hollis", PhoneNumber = "0212954386" }
                        }
                    }
                 };
                context.PhoneBooks.AddRange(phonebooks);
                context.SaveChanges();
            }


        }
    }
}
