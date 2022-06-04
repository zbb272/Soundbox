using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Soundbox.Models;

namespace Soundbox.Validations
{
    public class EmailWebsiteAttribute : ValidationAttribute
    {
        private string _domain;

        public EmailWebsiteAttribute(string domain)
        {
            _domain = domain;
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var artist = (Artist) validationContext.ObjectInstance;
            var email = (String)value;
            var i = artist.Email.Contains("google.com");

            if (i)
            {
                return new ValidationResult($"Email must use {_domain} email address.");
            }

            return ValidationResult.Success;
        }
    }
}
