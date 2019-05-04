using MovieStore2019.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStore2019.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        //[Min18YearsIfMember]
        public DateTime? BirthDate { get; set; } //This property is optional(nullable)

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; } //Here is a foreign key for the Customer entity
    }
}