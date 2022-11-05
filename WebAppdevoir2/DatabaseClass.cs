using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebAppdevoir2
{
    public class DatabaseClass
    {
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_rdr;

        public static List<Film> films;
        



        public byte[] ImageToByte(Image image, System.Drawing.Imaging.ImageFormat format)
        {


            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }


        public Image ByteToImage(byte[] imageBytes)
        {
            // Convert byte[] to Image
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);
            return image;
        }



        /// <summary>
        /// Create database
        /// </summary>
        public void CreateDatabase()
        {
            films = Utilities.getMovieDbList();


            // create a new database connection:
            using (SQLiteConnection sqlite_conn = new SQLiteConnection(MyConnection()))
            {

                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

                // Let the SQLiteCommand object know our SQL-Query:
                sqlite_cmd.CommandText = "CREATE TABLE IF NOT EXISTS Films (id integer, title varchar(30), overview varchar(200), original_language varchar(30), release_date varchar(30), vote_count integer, vote_average decimal, popularity decimal, poster_path1 BLOB, " +
                "Unique(id, title, overview, original_language, release_date, vote_count, vote_average, popularity, poster_path1))";

                // Now lets execute the SQL ;D
                sqlite_cmd.ExecuteNonQuery();

                foreach (Film film in films)
                {
                    Image backdrop;

                    using (WebClient webClient = new WebClient())
                    {
                        using (Stream stream = webClient.OpenRead(@"https://image.tmdb.org/t/p/w342" + film.backdrop_path))
                        {
                            backdrop = new Bitmap(Image.FromStream(stream));
                        }

                    }

                    byte[] data = ImageToByte(backdrop, System.Drawing.Imaging.ImageFormat.Jpeg);

                    // Lets insert something into our new table:
                    sqlite_cmd.CommandText = "INSERT OR IGNORE INTO Films(id, title, overview, original_language, release_date, vote_count, vote_average, popularity, poster_path1) VALUES(@id, @title, @overview, @original_language, @release_date, @vote_count, @vote_average, @popularity, @poster_path1)";


                    sqlite_cmd.Parameters.AddWithValue("@id", film.id);
                    sqlite_cmd.Parameters.AddWithValue("@title", film.title);
                    sqlite_cmd.Parameters.AddWithValue("@overview", film.overview);
                    sqlite_cmd.Parameters.AddWithValue("@original_language", film.original_language);
                    sqlite_cmd.Parameters.AddWithValue("@release_date", film.release_date);
                    sqlite_cmd.Parameters.AddWithValue("@vote_count", film.vote_count);
                    sqlite_cmd.Parameters.AddWithValue("@vote_average", film.vote_average);
                    sqlite_cmd.Parameters.AddWithValue("@popularity", film.popularity);
                    sqlite_cmd.Parameters.AddWithValue("@poster_path1", data);

                    sqlite_cmd.Prepare();

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();

                }

            }


        }



        /// <summary>
        /// Method to Select data from database
        /// </summary>
        /// <returns></returns>
        public List<Film> DataFromDatabase()
        {
            var Lesfilms = new List<Film>();

            using (SQLiteConnection sqlite_conn = new SQLiteConnection(MyConnection()))
            {
                // open the connection:
                sqlite_conn.Open();

                string stm = "SELECT * FROM Films;";
                sqlite_cmd = new SQLiteCommand(stm, sqlite_conn);
                sqlite_rdr = sqlite_cmd.ExecuteReader();
                while (sqlite_rdr.Read())
                {
                    Film MonFilm = new Film();
                    MonFilm.id = sqlite_rdr.GetInt32(0);
                    MonFilm.title = sqlite_rdr.GetString(1);
                    MonFilm.overview = sqlite_rdr.GetString(2);
                    MonFilm.original_language = sqlite_rdr.GetString(3);
                    MonFilm.release_date = sqlite_rdr.GetString(4);
                    MonFilm.vote_count = sqlite_rdr.GetInt32(5);
                    MonFilm.vote_average = sqlite_rdr.GetFloat(6);
                    MonFilm.popularity = sqlite_rdr.GetFloat(7);
                    byte[] imagee = (System.Byte[])sqlite_rdr[8];
                    MonFilm.imgbyte = imagee;
                    Lesfilms.Add(MonFilm);
                }
            }
            return Lesfilms;

        }


        /// <summary>
        /// Method to make the connection with the database
        /// </summary>
        /// <returns></returns>
        public static string MyConnection()
        {

            string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string dbpath = Path.GetDirectoryName(path) + "/films.db";

            String connectionString = $"Data Source={dbpath};Version=3";
            return connectionString;

        }
    }
}