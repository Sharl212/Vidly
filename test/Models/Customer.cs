using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public bool isSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}