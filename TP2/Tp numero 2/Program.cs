using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Abstract;
using System.Data.SqlClient;
using TP2.Connection;
using System.Data;
//using MySql.Data.MySqlClient;

namespace TP2
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("ABSTRACT CLASS");
            Console.WriteLine("===============\n");
            Teacher t1 = new Teacher("M<uyisa", "Richard", "+243970686262");
            Student s1 = new Student("Mungumwa", "Leonnie", "22lsi202233");

            t1.Add();
            s1.Add();

            t1.show(1);
            Console.WriteLine("\n===============\n");
            s1.show(1);

            Console.WriteLine("\n===============\n");


            Console.WriteLine("INTERFACE ");
            Console.WriteLine("===============\n");

            Interfaces.Teacher t2 = new Interfaces.Teacher("Bobette", "leonnie", "7263hdj");
            Interfaces.Student s2 = new Interfaces.Student("Mupenzi", "Mata", "22lsil764523");

            t2.Add();
            s2.Add();

            t2.show(2);
            Console.WriteLine("\n===============\n");
            s2.show(2);

            Console.WriteLine("\n===============\n");



            Console.ReadLine();

        }
    }
}
