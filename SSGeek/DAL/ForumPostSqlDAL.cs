using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSGeek.Models;
using System.Data.SqlClient;

namespace SSGeek.DAL
{
    public class ForumPostSqlDAL : IForumPostDAL
    {
        private string _connectionString;

        public ForumPostSqlDAL(string connectionString)
        {
            _connectionString = connectionString;
        }


        public List<ForumPost> GetAllPosts()
        {
            var posts = new List<ForumPost>();

            string sql = "SELECT * FROM forum_post;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader r = cmd.ExecuteReader();

                while(r.Read())
                {
                    ForumPost p = new ForumPost() { Id = Convert.ToInt32(r["id"]), Username = Convert.ToString(r["username"]), Subject = Convert.ToString(r["subject"]), Message = Convert.ToString(r["message"]), PostDate = Convert.ToDateTime(r["post_date"]) };
                    posts.Add(p);
                }
            }
            return posts;
        }

        public bool SaveNewPost(ForumPost post)
        {
            ForumPost p = new ForumPost() { Username = post.Username, Subject = post.Subject, Message = post.Message };
      
            string sql = "INSERT INTO forum_post (UserName, Subject, Message) VALUES (@username, @subject, @message);" +
                "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@username", p.Username));
                cmd.Parameters.Add(new SqlParameter("@subject", p.Subject));
                cmd.Parameters.Add(new SqlParameter("@message", p.Message));

                int newId = (int)cmd.ExecuteScalar();
                p.Id = newId;
            }

            return true;
        }

    }
}