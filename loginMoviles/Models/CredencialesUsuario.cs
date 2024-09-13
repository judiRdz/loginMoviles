﻿
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace loginMoviles.Models
{
    //[Keyless]

    public class CredencialesUsuario
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
