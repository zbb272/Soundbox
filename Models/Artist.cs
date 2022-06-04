using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Soundbox.Validations;


namespace Soundbox.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [Remote(action: "VerifyName", controller: "Artists")]
        public string Name { get; set; }

        [Range(0, 150)]
        public int Age { get; set; }

        [Range(0, 1000)]
        public int NetWorth { get; set; }

        public bool Retired { get; set; }

        [EmailWebsite("google.com")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        

        public ICollection<Song> Songs { get; set; }
    }
}
