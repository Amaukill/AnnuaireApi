using AnnuaireApi.Model;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AnnuaireApi.Data
{
    public class DataAccess
    {

        private string DB;
        public DataAccess(IConfiguration configuration)
        {
            DB = configuration.GetConnectionString("DBconnect");
        }
        public List<Contact> GetAllContacts()
        {
            MySqlConnection conn = new MySqlConnection(@DB);  
            string sql = " Select * From clients ";
            MySqlCommand result = new MySqlCommand(sql, conn);
            conn.Open();
            List<Contact> contacts = new List<Contact>();
            MySqlDataReader reader = result.ExecuteReader();
            while (reader.Read())
            {
                Contact contact = new Contact();
                contact.Guid = reader.GetGuid(0);
                contact.First = reader.GetString(1);
                contact.Last = reader.GetString(2);
                contact.Street = reader.GetString(3);
                contact.City = reader.GetString(4);
                contact.Zip = reader.GetString(5);
                contacts.Add(contact);
            }
            return contacts;

        }
        public List<Contact> GetContactsByParameters(string first = null, string last =null,string city=null,string street=null,int? zip = null )
        {
            string sql = " Select * From clients ";
            if (first != null || last != null || city != null || street != null || zip != null)
            {
                sql += "where ";
                if(first != null)
                {
                    sql += $"first like \"%{first}%\" and ";
                }
                if(last != null)
                {
                    sql += $"last like \"%{last}%\" and ";
                }
                if (city != null)
                {
                    sql += $"city like \"%{city}%\" and ";
                }
                if (street != null)
                {
                    sql += $"street like \"%{street}%\" and ";
                }
                if (zip != null)
                {
                    sql += $"zip like \"%{zip}%\" and ";
                }
                sql = sql.Remove(sql.LastIndexOf("and"),3);
            }

            MySqlConnection conn = new MySqlConnection(@DB);            
            MySqlCommand result = new MySqlCommand(sql, conn);
            conn.Open();
            List<Contact> contacts = new List<Contact>();
            MySqlDataReader reader = result.ExecuteReader();
            while (reader.Read())
            {
                Contact contact = new Contact();
                contact.Guid = reader.GetGuid(0);
                contact.First = reader.GetString(1);
                contact.Last = reader.GetString(2);
                contact.Street = reader.GetString(3);
                contact.City = reader.GetString(4);
                contact.Zip = reader.GetString(5);
                contacts.Add(contact);
            }
            return contacts;

        }
    }
}
