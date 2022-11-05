using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAppdevoir2
{

    /// <summary>
    /// Nom: Mydleyka Dimanche
    /// Devoir4
    /// </summary>
    public partial class _default : System.Web.UI.Page
    {
        public static List<Film> films;
        public static int index = 0;
        DatabaseClass databaseClass = new DatabaseClass();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Utilities.IsConnectedToInternet())
            {

                databaseClass.CreateDatabase();
                films = Utilities.getMovieDbList();
                button1.BackColor = System.Drawing.Color.Blue;


            }
            else
            {
                films = databaseClass.DataFromDatabase();
                button1.BackColor = System.Drawing.Color.Red;

            }


            display_film();

        }


        private void display_film()
        {
            Film film = films.ElementAt(index);
            lbTitle.Text = film.title;
            lbDescription.Text = film.overview;

            if (Utilities.IsConnectedToInternet())
            {
                pbImageFilm.ImageUrl = @"https://image.tmdb.org/t/p/w342" + film.backdrop_path;
            }
            else
            {
                string strBase64 = Convert.ToBase64String(film.imgbyte);
                pbImageFilm.ImageUrl = "data:image/Png;base64," + strBase64;
            }
            

            if (index == 0)
            {
                btnPrevious.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = true;
            }

            if (index == films.Count - 1)
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            index--;
            display_film();

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            index++;
            display_film();

        }

        
    }
}