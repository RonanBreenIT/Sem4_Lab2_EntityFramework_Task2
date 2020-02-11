using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sem4_Lab2_EntityFramework_Task2.Models;

namespace Sem4_Lab2_EntityFramework_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            PhonebookContext phCtx = new PhonebookContext();

            // Create a phonebook instance
            Phonebook repo = new Phonebook();
            Phonebook p1 = new Phonebook("0872878566", "Ronan", "1 Main Street");
            Phonebook p2 = new Phonebook("1111111111", "Rick", "2 Main Street");
            Phonebook p3 = new Phonebook("1122211111", "Rachel", "5 Main Street");


            // Test can add instance to PhoneBooks db
            repo.InsertPhonebook(p1);
            repo.InsertPhonebook(p2);
            repo.InsertPhonebook(p3);
            //phCtx.Phonebooks.Add(p1);
            //p1.InsertPhonebook(p1);


            // Test can update Phonebook contact
            repo.UpdatePhonebookContact(new Phonebook { Name = "Ronan", Number = "09812270809", Address = "3 Main Sreet", PhoneID = 1 });

            // Test can remove Phonebook contact
            repo.DeleteContact(p3);

            // Report Full list
            repo.ReportContactList();

            // Report contact details by number
            repo.FindNumber(p2);

            // Report contact details by name
            Phonebook p4 = new Phonebook("888888888", "Ronan", "6 Main Street");
            p4.InsertPhonebook(p4); // To test it finds all "Ronans"
            repo.FindName(p1);

            
        }
    }
}
