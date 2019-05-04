using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStore2019.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Here we implement our validation logic.

            // First we need to check the selected membership type.
            // Through validationContext variable we have access to the class that this validation logic is applied through the Min18YearsIfAmember attribute.
            // In this case Customer class.
            var customer = (Customer)validationContext.ObjectInstance;

            // Now we can check the selected membership type.
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo) // If this customer is with PayAsYouGo membership type
            {
                return ValidationResult.Success;
            }

            // Here we check ig the BirthDate property is null.
            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required");
            }

            // We calculate the age in order to check if the customer is above tha age of 18.
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to go on a membership");

        }
    }
}