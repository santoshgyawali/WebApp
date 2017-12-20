using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Customer
    {
        public int Id  { get; set; }
        [Required (ErrorMessage="Please Enter Customer's Name")]
        [StringLength(255)]
        public String Name { get; set; }
        public bool IsSubsribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        [Min18YearsifAMember]
        public DateTime? Birthday { get; set; }
       
        
        /* public byte Id { get; set; }
        public String Name { get; set; }
        /* 
    
         */
       
    }
}