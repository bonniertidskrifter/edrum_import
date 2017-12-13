using Import_Edrum.Model;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Import_Edrum
{
    public class WPClient
    {
        public WPClient (List<Posts> posts, List<Postmeta> postmetas, List<Category> categorys, List<CategoryRelationship> categoryRelationships, List<User> users, List<Usermeta> usermetas)
        { 
            try
            {
                var password = "dev!";
                var hostName = "127.0.0.1";
                var database = "gardochtorp_seagal";
                var userName = "dev";

                var connectionString = $"Server={hostName}; Database={database}; Uid={userName}; Pwd={password}";

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (var post in posts)
                    {
                        var sql = "INSERT INTO wp_posts(`ID`, `post_author`, `post_date`, `post_date_gmt`, `post_content`, `post_title`, `post_excerpt`, `post_status`, `comment_status`, `ping_status`, `post_password`, `post_name`, `to_ping`, `pinged`, `post_modified`, `post_modified_gmt`, `post_content_filtered`, `post_parent`, `guid`, `menu_order`, `post_type`, `post_mime_type`, `comment_count`) " +
                            $@"VALUES ({post.Id},
                                    {post.Author},
                                    '{MySqlHelper.EscapeString(new MySqlDateTime(post.Date).ToString())}',
                                    '{MySqlHelper.EscapeString(new MySqlDateTime(post.Date_gmt).ToString())}',
                                    '{MySqlHelper.EscapeString(post.Content ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(post.Title ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(post.Excerpt ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(post.Status ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(post.CommentStatus ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(post.PingStatus ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(post.Password ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(post.Name ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(post.ToPing ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(post.Pinged ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(new MySqlDateTime(post.Modified).ToString())}',
                                    '{MySqlHelper.EscapeString(new MySqlDateTime(post.Modified_gmt).ToString())}',
                                    '{MySqlHelper.EscapeString(post.ContentFiltered ?? string.Empty)}',
                                    {post.Parent},
                                    '{MySqlHelper.EscapeString(post.Guid ?? string.Empty)}',
                                    {post.MenuOrder},
                                    '{MySqlHelper.EscapeString(post.Type ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(post.MimeType ?? string.Empty)}',
                                    {post.CommentCount})";
                        MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);
                        mySqlCommand.ExecuteNonQuery();
                    }

                    foreach (var postmeta in postmetas)
                    {
                        var sql = "INSERT INTO wp_postmeta(`post_id`, `meta_key`, `meta_value`) " +
                            $@"VALUES ({postmeta.PostId},
                                    '{MySqlHelper.EscapeString(postmeta.Key)}',
                                    '{MySqlHelper.EscapeString(postmeta.Value)}')";
                        MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);
                        mySqlCommand.ExecuteNonQuery();
                    }

                    foreach (var user in users)
                    {
                        var sql = "INSERT INTO wp_users(id, user_login, user_email, user_pass, user_nicename, user_registered, display_name) " +
                            $@"VALUES ({user.Id},
                                    '{MySqlHelper.EscapeString(user.Login ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(user.Email ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(user.Pass ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(user.Nicename ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(new MySqlDateTime(user.Registered).ToString())}',
                                    '{MySqlHelper.EscapeString(user.DisplayName ?? string.Empty)}')";
                        MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);
                        mySqlCommand.ExecuteNonQuery();
                    }

                    foreach (var usermeta in usermetas)
                    {
                        var sql = "INSERT INTO wp_usermeta(`user_id`, `meta_key`, `meta_value`) " +
                            $@"VALUES ({usermeta.UserId},
                                    '{MySqlHelper.EscapeString(usermeta.Key)}',
                                    '{MySqlHelper.EscapeString(usermeta.Value)}')";
                        MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);
                        mySqlCommand.ExecuteNonQuery();
                    }

                    foreach (var categoryRelationship in categoryRelationships)
                    {
                        var sql = "INSERT INTO wp_term_relationships(`object_id`,`term_taxonomy_id`,`term_order`) " +
                            $@"VALUES ({categoryRelationship.ObjectId},
                                    {categoryRelationship.TaxonomyId},
                                    {categoryRelationship.TermOrder})";
                        MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);
                        mySqlCommand.ExecuteNonQuery();
                    }

                    foreach (var category in categorys)
                    {
                        var sql = "INSERT INTO wp_terms(`term_id`,`name`,`slug`,`term_group`) " +
                            $@"VALUES ({category.Id},
                                    '{MySqlHelper.EscapeString(category.Name ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(category.Slug ?? string.Empty)}',
                                    {category.Group})";
                        MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);
                        mySqlCommand.ExecuteNonQuery();

                        sql = "INSERT INTO wp_term_taxonomy(`term_taxonomy_id`,`term_id`,`taxonomy`,`description`,`parent`,`count`) " +
                            $@"VALUES ({category.TaxonomyId},
                                     {category.Id},
                                    '{MySqlHelper.EscapeString(category.Taxonomy ?? string.Empty)}',
                                    '{MySqlHelper.EscapeString(category.Description ?? string.Empty)}',
                                    {category.ParentId},
                                    {category.Count})";
                        mySqlCommand.CommandText = sql;
                        mySqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
