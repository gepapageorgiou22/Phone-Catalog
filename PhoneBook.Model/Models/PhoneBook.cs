using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Model
{
    public class PhoneBook 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Entry> Entries { get; set; }
    }
}
