﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Customer
    {
        public int Id  { get; set; }
        [Required]
        [StringLength(255)]
        public String Name { get; set; }
        public bool IsSubsribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime Dob { get; set; }
    }
}