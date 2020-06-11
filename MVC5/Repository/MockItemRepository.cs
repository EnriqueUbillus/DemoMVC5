using Microsoft.Ajax.Utilities;
using MVC5.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC5.Repository
{
    public class MockItem : IItemRepository
    {

        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ItemContext"].ConnectionString;

        public IEnumerable<Item> GetItems()
        {
            List<Item> items = new List<Item>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                //SqlCommand cmd = new SqlCommand("spGetItems", con);
                //cmd.CommandType = CommandType.StoredProcedure;

                SqlCommand cmd = new SqlCommand("SElect * from Items", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var item = new Item()
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        Description = rdr["Description"].ToString(),
                        ObjectType = (ItemType)rdr["ObjectType"]
                    };
                    items.Add(item);
                }
                return items;
            }
        }

        public Item GetItemById(int? id)
        {
            Item item = new Item();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SElect * from Items", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    item.Id = Convert.ToInt32(rdr["Id"]);
                    item.Description = rdr["Description"].ToString();
                    item.ObjectType = (ItemType)rdr["ObjectType"];
                }
                return item;
            }
        }

        public void InsertItem(Item item)
        {
            string sqlQuery = "INSERT INTO Items(Description, ObjectType) VALUES(@param1,@param2)";
            CreateUpdateItem(item, sqlQuery);
        }

        private void CreateUpdateItem(Item item, string sqlQuery)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    cmd.Parameters.AddWithValue("@param1", item.Description); // implicit casting AddWithValue
                    cmd.Parameters.AddWithValue("@param2", item.ObjectType);

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            };
        }

        public void UpdateItem(Item item)
        {
            string sqlQuery = $"UPDATE Items SET Description = @param1, ObjectType = @param2 WHERE Id = {item.Id}" ;
            CreateUpdateItem(item, sqlQuery);
        }

        public void DeleteItem(Item item)
        {
            string sqlQuery = $"DELETE FROM Items WHERE Id = {item.Id}";


            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                var cmd = new SqlCommand(sqlQuery, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                //cmd.Parameters.AddWithValue("@Id", item.Id); // to qork with stored procedure
                cmd.ExecuteNonQuery();
            }
        }
    }
}