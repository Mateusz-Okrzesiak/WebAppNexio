using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppNexio.Models.Person
{
    public class Person
    {
        [DisplayName("Imię")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Wiek")]
        public DateTime Age { get; set; }

        [DisplayName("Wzrost")]
        [Required]
        public int height { get; set; }
        [DisplayName("Kolor")]
        public string Color { get; set; }
        public SelectList  ColorItems { get; set; }
        public static List<Person> PersonList = new List<Person>();

        public Person()
        {

            this.Age = DateTime.Today;
            ColorItems = new SelectList(new[] { "Czerwony", "Zielony", "Niebieski" });
            Color = "---";
        }
        public static bool Compare()
        {
            int success = 0;
            var person = Person.PersonList.ToArray();

            if (person[0].Color == person[1].Color)
                success++;
            if (person[0].height - person[1].height > 5)
                success++;

            TimeSpan span = person[0].Age - person[1].Age;

            if (person[0].Age > person[1].Age && (person[0].Age.AddYears(-person[1].Age.Year).Year <= 5 ) || person[0].Age < person[1].Age && (person[1].Age.AddYears(-person[0].Age.Year).Year <= 5))
                success++;

            if (success>1)
                return true;
            else
                return false;

        }
    }
}