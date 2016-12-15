﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Evodia.Core.Models
{
    public class FeedbackSurvey
    {
        [DisplayName("Name")]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [DisplayName("Email address")]
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [DisplayName("Telephone")]
        [Required(ErrorMessage = "Please enter your telephone number")]
        public string Telephone { get; set; }

        [DisplayName("Company name")]
        public string CompanyName { get; set; }

        [DisplayName("Message")]
        [Required(ErrorMessage = "Please enter your message")]
        public string Message { get; set; }
    }
}