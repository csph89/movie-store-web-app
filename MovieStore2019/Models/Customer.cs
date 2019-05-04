using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStore2019.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; } //This property is optional(nullable)

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; } //Here we have a navigation property

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } //Here is a foreign key for the Customer entity
    }
}