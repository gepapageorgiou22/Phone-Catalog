using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneBook.Model
{
    public class Entry
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public int PhoneBookId { get; set; }
    }
}
