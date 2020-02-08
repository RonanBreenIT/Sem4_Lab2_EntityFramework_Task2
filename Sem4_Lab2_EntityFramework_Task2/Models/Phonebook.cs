using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sem4_Lab2_EntityFramework_Task2.Models;

/*         /*
         Task 2 – Entity Framework (PhoneBookv1)

Design and implement a console application which allows adding, updating, 
and deleting of data in a phone book database. Use the Entity Framework for this purpose, 
Code First approach. A SQL Server Express LocalDB will suffice. Each entry in the phone book 
contains a phone number (unique), a name, and an address. Have the application insert, update, 
and delete entries, and provide the following queries:
*/

namespace Sem4_Lab2_EntityFramework_Task2
{
    public class Phonebook
    {
        [Key]
        public int PhoneID { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Name { get; set; }
        public string Address { get; set; }

        //public virtual Phonebook Phonebooks { get; set; }

        public Phonebook(string _number, string _name, string _address)
        {
            this.Number = _number;
            this.Name = _name;
            this.Address = _address;
        }

        public Phonebook()
        {

        }



        // Void to Insert
        public void InsertPhonebook(Phonebook _contact)
        {
            using (PhonebookContext db = new PhonebookContext())
            {
                try
                {
                    db.Phonebooks.Add(_contact);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }


        // Void to Update
        public void UpdatePhonebookContact(Phonebook contact)
        {
            using (PhonebookContext db = new PhonebookContext())
            {
                // Loop to look for a match based on name
                var found = db.Phonebooks.FirstOrDefault(c => c.Name.ToUpper() == contact.Name.ToUpper());
                if (found == null)
                {
                    throw new ArgumentException("No contact found");
                }
                else 
                {
                        found.Number = contact.Number;
                        found.Address = contact.Address;
                        db.SaveChanges();
                }
            }
        }

        // Delete Contact
        public void DeleteContact(Phonebook contact)
        {
            using (PhonebookContext db = new PhonebookContext())
            {
                try
                {
                    var found = db.Phonebooks.FirstOrDefault(c => c.Name.ToUpper() == contact.Name.ToUpper());
                    //Loop to look for a match based on name
                    if (found != null)
                    {
                        db.Phonebooks.Remove(contact);
                        db.SaveChanges();
                        //throw new ArgumentException("Contact could not be found");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

            // 1.Report the full contents of the phone book in name order
        public void ReportContactList()
        {
            using (PhonebookContext db = new PhonebookContext())
            {
                var fullcontents = db.Phonebooks.OrderBy(c => c.Name);
                Console.WriteLine("\n---- Contact list in name order -----");
                foreach (Phonebook contact in fullcontents)
                {
                    Console.WriteLine("\nContact Name: " + contact.Name + "\nContact Number: " + contact.Number + "\nAddress: " + contact.Address);
                }
            }
        }

        // 2. Report the name and address for specified phone number.
        public void FindNumber(Phonebook _contact)
        {
            using (PhonebookContext db = new PhonebookContext())
            {
                var findContact = db.Phonebooks.FirstOrDefault(c => c.Number == _contact.Number);
                if (findContact == null)
                {
                    throw new ArgumentException("Number not found");
                }
                else
                {

                    Console.WriteLine("\n---- Contact Found -----");
                    Console.WriteLine("\nContact Name: " + findContact.Name + "\nContact Number: " + findContact.Number + "\nAddress: " + findContact.Address);
                }
            }
        }

        // 3. Report phone numbers and addresses matching a specified name.
        public void FindName(Phonebook contact)
        {
            using (PhonebookContext db = new PhonebookContext()) 
            {
                foreach (Phonebook item in db.Phonebooks)
                {
                    var locateName = db.Phonebooks.Select(c => c.Name == contact.Name);
                    if (locateName == null)
                    {
                        Console.WriteLine("No matching contact name in the Phonebook");
                    }
                    else
                    {
                        Console.WriteLine("\nContact Name: " + item.Name + "\nContact Number: " + item.Number + "\nAddress: " + item.Address);
                    }
                }
   
            }
        }  
    }
}




