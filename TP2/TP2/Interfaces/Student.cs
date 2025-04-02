using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TP2.Connection;
using System.Data;
using MySql.Data.MySqlClient;

namespace TP2.Interfaces
{
    class Student : IPerson
    {
        private String name, lname,refNum;
        public Student(String name, String lname, String refNum) 
        {
            this.name = name;
            this.lname = lname;
            this.refNum = refNum;
        }

        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public String Lname
        {
            get
            {
                return this.lname;
            }
            set
            {
                this.lname = value;
            }
        }
        public String Refnum
        {
            get
            {
                return this.refNum;
            }
            set
            {
                this.refNum = value;
            }
        }

        public void Add()
        {
            dbConnection db = new dbConnection();
            SqlConnection sqlcon = db.GetSqlConnection();
            //MySqlConnection mysqlcon = db.GetMySqlConnection();

            try
            {
                sqlcon.Open();
                //mysqlcon.Open();
                if (sqlcon.State == ConnectionState.Open)
                {
                    String sql = "INSERT INTO students(nom,lname,refnum)VALUES('" + name + "','" + lname + "','" + refNum + "')";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        Console.WriteLine("students Inserted Successfully!!\n");
                    }
                    else
                    {
                        Console.WriteLine("students Not Inserted!!\n");
                    }
                }
                else
                {
                    Console.WriteLine("AN ERROR WAS OCCURED WHILE TRYING TO CONNECT TO SQL SERVER");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }

        }

        public void show(int id)
        {
            dbConnection db = new dbConnection();
            SqlConnection sqlcon = db.GetSqlConnection();
           // MySqlConnection mysqlcon = db.GetMySqlConnection();

            try
            {
                sqlcon.Open();
                //mysqlcon.Open();
                if (sqlcon.State == ConnectionState.Open)
                {
                    SqlDataReader dr;
                    String sql = "select * from students where id=" + id;
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Console.WriteLine(String.Format("Name : {0}\nLasteName : {1}\nReference Number : {2}", dr.GetString(1), dr.GetString(2), dr.GetString(3)));

                    }
                    else
                    {
                        Console.WriteLine("Student Not found!!");
                    }
                }
                else
                {
                    Console.WriteLine("AN ERROR WAS OCCURED WHILE TRYING TO CONNECT TO SQL SERVER");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
        }
    }
}
