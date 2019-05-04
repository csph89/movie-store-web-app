using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStore2019.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        // We made these fields "readonly" so we don't accidentally change it somewhere else in our code.
        // So once we initialize it here, if we try to change it somewhere else in the code we'll get a compilation error.
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}