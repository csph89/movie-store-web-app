using MovieStore2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore2019.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0) //An uparxei hdh o pelaths shmainei oti ginetai Edit.
                    return "Edit Customer";
                return "New Customer"; //Alliws shmainei oti eisagoume enan kainourio sth vash mas.
            }
        }

    }
}