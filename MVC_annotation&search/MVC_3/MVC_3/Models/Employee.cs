//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Employee
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Please enter Your First name"),MaxLength(12)]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Please enter Your Last name"), MaxLength(12)]

        public string Last_Name { get; set; }
        [Required(ErrorMessage = "Please enter Your Email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string E_mail { get; set; }
        [Required(ErrorMessage ="Please Enter Your Phone")]
        [RegularExpression(@"^(077|078|079)\d{7}$",ErrorMessage ="The phone number is not valid")]


        public string Phone { get; set; }
        [Range(18,50,ErrorMessage ="Your Age Should Be between 18 and 50")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please Enter Your JOB Title"),MaxLength(10)]
        public string Job_Title { get; set; }

        public Nullable<bool> Gender { get; set; }
    }
}
