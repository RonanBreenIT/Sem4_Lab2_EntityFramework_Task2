using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sem4_Lab2_EntityFramework_Task2;
using Sem4_Lab2_EntityFramework_Task2.Models;

namespace EF_Task2_UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNewPhonebook()
        {
            Phonebook p1 = new Phonebook("0872878566", "Ronan", "1 Main Street");
            Phonebook p2 = new Phonebook("1111111111", "Rick", "2 Main Street");
            Phonebook p3 = new Phonebook("1122211111", "Rachel", "5 Main Street");
          
            //Console.WriteLine(p1.ToString());
            string expected = "\nContact Name: Ronan" +  "\nContact Number: 0872878566" + "\nAddress: 1 Main Street";
            string actual = p1.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertPhonebookMethod()
        {
            Phonebook p1 = new Phonebook("0872878566", "Ronan", "1 Main Street");
            p1.InsertPhonebook(p1);

            PhonebookContext phCtx = new PhonebookContext();
            



        }
    }


}
