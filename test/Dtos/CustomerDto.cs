using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using test.Models;

namespace test.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public bool isSubscribedToNewsLetter { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}