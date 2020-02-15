using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Sem4_Lab2_EntityFramework_Task2.Models
{
    public class PhonebookContext : DbContext
    {
        public PhonebookContext() : base("DefaultConnection")
        {
            // always drop and re-create the schema
            Database.SetInitializer<PhonebookContext>(new DropCreateDatabaseAlways<PhonebookContext>());
        }
        public DbSet<Phonebook> Phonebooks { get; set; }
    }
}
