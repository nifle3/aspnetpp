﻿using System.Linq;
using WebApplication2rrr.Models;

namespace WebApplication2rrr
{
    public class SampleData
    {
        public static void Initialize(MobileContext context, IWebHostEnvironment env)
        {
            if (!context.Phones.Any())
            {
                context.Phones.AddRange(
                    new Phone
                    {
                        Name = "iPhone X",
                        Company = "Apple",
                        Price = 600
                    },
                    new Phone
                    {
                        Name = "Samsung Galaxy Edge",
                        Company = "Samsung",
                        Price = 550
                    },
                    new Phone
                    {
                        Name = "Pixel 3",
                        Company = "Google",
                        Price = 500
                    }
                );
                context.SaveChanges();
            }
            /*
            if (!context.Users.Any())
            {
                context.Users.Add(new User
                {
                    Name = "Artem",
                    NumberTelephone = "8800553535",
                    Role = "not an admin",
                    Sex = false
                }) ;
                context.SaveChanges();
            }
            */
        }
    }
}
