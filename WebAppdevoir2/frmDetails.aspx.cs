using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppdevoir2
{
    public partial class frmDetails : System.Web.UI.Page
    {
        Film film = _default.films.ElementAt(_default.index);

        public const string stringVideo = @"https://api.themoviedb.org/3/movie/{0}/videos?api_key=a07e22bc18f5cb106bfe4cc1f83ad8ed";

        protected void Page_Load(object sender, EventArgs e)
        {
            String reponse = "";
            string youtubeKey = "";
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    reponse = webClient.DownloadString(String.Format(stringVideo, film.id));
                }
                //Console.WriteLine(retVal);
                using (JsonDocument document = JsonDocument.Parse(reponse))
                {
                    JsonElement root = document.RootElement;
                    JsonElement resultsList = root.GetProperty("results");

                    int i = 0;
                    while (true)
                    {
                        String type = resultsList[i].GetProperty("type").ToString();
                        youtubeKey = resultsList[i].GetProperty("key").ToString();
                        if (type.Equals("Clip"))
                        {
                            break;
                        }
                        i++;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            displayVideo(youtubeKey);
            display_film();

        }

        private void displayVideo(String id)
        {
            youtubeVideo.Text = String.Format("<html><head>" +
                    "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
                    "</head><body>" +
                    "<iframe width=\"50%\" height=\"325\" src=\"https://www.youtube.com/embed/{0}?autoplay=1\"" +
                    "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" +
                    "</body></html>", id);
        }

        private void display_film()
        {
            
            lbTitle.Text = film.title;
            lbDescription.Text = film.overview;
            lbOriginalLanguange.Text = "Languange: " + film.original_language;
            lbReleaseDate.Text = "release_date: " + film.release_date;
            lbVoteAverage.Text = "vote_average: " + film.vote_average.ToString();
            lbVoteCount.Text = "vote_count: " + film.vote_count.ToString();
        }
       

    }
}