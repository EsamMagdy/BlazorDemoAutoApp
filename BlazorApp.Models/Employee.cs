﻿namespace BlazorApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public Genders Gender { get; set; }
        public Country Country { get; set; }
    }
}
