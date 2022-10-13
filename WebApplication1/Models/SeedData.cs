﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebApplication1.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDBContext(serviceProvider.GetRequiredService<DbContextOptions<AppDBContext>>()))
            {
                if (context.Personal.Any())
                {
                    return;
                }


                context.Personal.AddRange(
                    new PersonalInformations
                    {
                        Login = "user1@user.com",
                        Password = "qwerty123",
                        FirstName = "John",
                        LastName = "Smith",
                        Gender = "Male",
                        YearOfBirth = DateTime.Now
                    },
                     new PersonalInformations
                     {
                         Login = "user2@user.com",
                         Password = "qwerty123",
                         FirstName = "Jack",
                         LastName = "Sparrow", 
                         Gender = "Female",
                         YearOfBirth = DateTime.Now
                     },
                      new PersonalInformations
                      {
                          Login = "user3@user.com",
                          Password = "qwerty123",
                          FirstName = "Peter",
                          LastName = "Parker",
                          Gender = "Male",
                          YearOfBirth = DateTime.Now
                      },
                       new PersonalInformations
                       {
                           Login = "user4@user.com",
                           Password = "qwerty123",
                           FirstName = "Mario",
                           LastName = "Mario",
                           Gender = "Female",
                           YearOfBirth = DateTime.Now
                       },
                        new PersonalInformations
                        {
                            Login = "user5@user.com",
                            Password = "qwerty123",
                            FirstName = "Luigy",
                            LastName = "Mario",
                            Gender = "Male",
                            YearOfBirth = DateTime.Now
                        }
                    );

                context.SaveChanges();
            }

        }

    }
}
