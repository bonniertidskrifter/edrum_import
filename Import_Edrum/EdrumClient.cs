using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Import_Edrum.Model;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace Import_Edrum
{
    public class EdrumClient
    {
        public EdrumClient()
        { 
            SqlConnection myConnection = new SqlConnection("server=WS461121\\SQLEXPRESS;" +
                                           "Trusted_Connection=yes;" +
                                           "database=edrum_gardtorp; ");

            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from dbo.Export_posts",
                                                         myConnection);
                myReader = myCommand.ExecuteReader();
                List<Posts> posts = new List<Posts>();
                while (myReader.Read())
                {
                    Posts post = new Posts
                    {
                        Id = System.Convert.ToInt64(myReader["id"]),
                        Author = System.Convert.ToInt64(myReader["post_author"]),
                        Date = System.Convert.ToDateTime(myReader["Post_date"]),
                        Date_gmt = System.Convert.ToDateTime(myReader["Post_date_gmt"]),
                        Content = myReader["Post_content"].ToString(),
                        Title = myReader["Post_title"].ToString(),
                        Excerpt = myReader["Post_excerpt"].ToString(),
                        Status = myReader["Post_status"].ToString(),
                        CommentStatus = myReader["Comment_status"].ToString(),
                        PingStatus = myReader["Ping_status"].ToString(),
                        Password = myReader["Post_password"].ToString(),
                        Name = myReader["Post_name"].ToString(),
                        ToPing = myReader["To_ping"].ToString(),
                        Pinged = myReader["Pinged"].ToString(),
                        Modified = System.Convert.ToDateTime(myReader["Post_modified"]),
                        Modified_gmt = System.Convert.ToDateTime(myReader["Post_modified_gmt"]),
                        ContentFiltered = myReader["Post_content_filtered"].ToString(),
                        Parent = System.Convert.ToUInt64(myReader["Post_parent"]),
                        Guid = myReader["Guid"].ToString(),
                        MenuOrder = System.Convert.ToInt32(myReader["Menu_order"]),
                        Type = myReader["Post_type"].ToString(),
                        MimeType = myReader["post_mime_type"].ToString(),
                        CommentCount = System.Convert.ToInt64(myReader["comment_count"])
                    };
                    posts.Add(post);
                }

                myReader.Close();
                myCommand.CommandText = "select * from dbo.Export_postmeta";
                myReader = myCommand.ExecuteReader();
                List<Postmeta> postmetas = new List<Postmeta>();
                while (myReader.Read())
                {
                    Postmeta postmeta = new Postmeta
                    {
                        PostId = System.Convert.ToUInt64(myReader["post_id"]),
                        Key = myReader["meta_key"].ToString(),
                        Value = myReader["meta_value"].ToString()
                    };
                    postmetas.Add(postmeta);
                }

                myReader.Close();
                myCommand.CommandText = "select * from dbo.Export_users";
                myReader = myCommand.ExecuteReader();
                List<User> users = new List<User>();
                while (myReader.Read())
                {
                    User user = new User
                    {
                        Id = System.Convert.ToUInt64(myReader["id"]),
                        Login = myReader["user_login"].ToString(),
                        Email = myReader["user_email"].ToString(),
                        Pass = myReader["user_pass"].ToString(),
                        Nicename = myReader["user_nicename"].ToString(),
                        Registered = System.Convert.ToDateTime(myReader["user_registred"]),
                        DisplayName = myReader["display_name"].ToString(),
                    };
                    users.Add(user);
                }

                myReader.Close();
                myCommand.CommandText = "select * from dbo.Export_usermeta";
                myReader = myCommand.ExecuteReader();
                List<Usermeta> usermetas = new List<Usermeta>();
                while (myReader.Read())
                {
                    Usermeta usermeta = new Usermeta
                    {
                        UserId = System.Convert.ToUInt64(myReader["userid"]),
                        Key = myReader["meta_key"].ToString(),
                        Value = myReader["meta_value"].ToString()
                    };
                    usermetas.Add(usermeta);
                }

                myReader.Close();
                myCommand.CommandText = "select * from dbo.Export_term_relationships";
                myReader = myCommand.ExecuteReader();
                List<CategoryRelationship> categoryRelationships = new List<CategoryRelationship>();
                while (myReader.Read())
                {
                    CategoryRelationship categoryRelationship = new CategoryRelationship
                    {
                        ObjectId = System.Convert.ToUInt64(myReader["object_id"]),
                        TaxonomyId = System.Convert.ToUInt64(myReader["term_taxonomy_id"]),
                        TermOrder = System.Convert.ToInt32(myReader["term_order"])
                    };

                    switch (categoryRelationship.TaxonomyId)
                    {
                        case 1:
                            categoryRelationship.TaxonomyId = 5;
                            break;
                        case 3:
                            categoryRelationship.TaxonomyId = 6;
                            break;
                        case 4:
                            categoryRelationship.TaxonomyId = 7;
                            break;
                        default:
                            break;
                    }
                    categoryRelationships.Add(categoryRelationship);
                }

                myReader.Close();
                myCommand.CommandText = "select * from dbo.Export_MenyCategory";
                myReader = myCommand.ExecuteReader();
                List<Category> categorys = new List<Category>();
                while (myReader.Read())
                {
                    Category category = new Category
                    {
                        Id = System.Convert.ToUInt64(myReader["id"]),
                        Name = myReader["name"].ToString(),
                        Slug = myReader["name"].ToString().ToLower().Replace(" ", "").Replace("/", "").Replace("-", "").Replace("#http://www.gardochtorp.se/hantverkstorget/index.aspx?category=119", "").Replace("&", "").Replace("!", "").Replace("#http://premiumshoppen.se/tidning/gardochtorp/", "").Replace('å', 'a').Replace('ä', 'a').Replace( 'ö', 'o'),
                        Group = 0,
                        TaxonomyId = System.Convert.ToUInt64(myReader["id"]),
                        ParentId = System.Convert.ToUInt64(myReader["parentId"]),
                        Taxonomy = "category",
                        Description = ""
                    };
                    switch (category.Id)
                    {
                        case 1:
                            category.Id = 5;
                            break;
                        case 3:
                            category.Id = 6;
                            break;
                        case 4:
                            category.Id = 7;
                            break;
                        default:
                            break;
                    }

                    switch (category.TaxonomyId)
                    {
                        case 1:
                            category.TaxonomyId = 5;
                            break;
                        case 3:
                            category.TaxonomyId = 6;
                            break;
                        case 4:
                            category.TaxonomyId = 7;
                            break;
                        default:
                            break;
                    }

                    switch (category.ParentId)
                    {
                        case 1:
                            category.ParentId = 5;
                            break;
                        case 3:
                            category.ParentId = 6;
                            break;
                        case 4:
                            category.ParentId = 7;
                            break;
                        default:
                            break;
                    }

                    categorys.Add(category);
                }

                myConnection.Close();

                WPClient wpClient = new WPClient(posts, postmetas, categorys, categoryRelationships, users, usermetas);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
