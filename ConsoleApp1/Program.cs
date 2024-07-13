using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace _21_DataAnnotations
{
    [Serializable]
    class User
    {
        [Required(ErrorMessage = "Id not setted")]
        [Range(1000, 9999, ErrorMessage = "They are not five-digit...")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name not setted")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Incorrect lenght")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age not setted")]
        [Range(1, 120, ErrorMessage = "Error age")]
        public int Age { get; set; }
        [Phone]
        [RegularExpression(@"\+38\d{10}")]
        public string Phone { get; set; }//+38098654654654
        [EmailAddress]
        public string Email { get; set; }//khfjf@gmail.com
        [Required]
        [RegularExpression("[A-Za-z]")]
        public string Login { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "Incorrect password!")]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Not confirm password")]
        [StringLength(8, ErrorMessage = "Incorrect password!")]
        public string ConfirmPassword { get; set; }
    
        [RegularExpression(@"\d{17}")]
        public string CreditCard { get;set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            bool isValid = true;
            do
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter age");
                int age = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Login");
                string login = Console.ReadLine();

                Console.WriteLine("Enter password");

                string password = Console.ReadLine();

                Console.WriteLine("Confirm password");
                string confirmPassword = Console.ReadLine();

                Console.WriteLine("Enter email");
                string email = Console.ReadLine(); 

                Console.WriteLine("Enter phone");
                Console.Write("+38-");
                string phone = Console.ReadLine();

                Console.WriteLine("Credit card");
                string creditCard = Console.ReadLine();
                user.Id = 1;
                user.Name = name;
                user.Age = age;
                user.Password = password;
                user.ConfirmPassword = confirmPassword;
                user.Email = email;
                user.Phone = phone;
                user.Login = login;
                user.CreditCard = creditCard;

                var result = new List<ValidationResult>();
                var contex = new ValidationContext(user);
                if (!(isValid = Validator.TryValidateObject(user, contex, result, true)))
                {
                    foreach (ValidationResult error in result)
                    {
                        Console.WriteLine(error.MemberNames.FirstOrDefault() + ": " + error.ErrorMessage);
                    }
                }


            } while (!isValid);

            Console.WriteLine("Model is valid");
        }
    }
}