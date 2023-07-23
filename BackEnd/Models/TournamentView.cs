using Domain;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BackEnd.Models
{
    public class TournamentView : Tournament
    {
        [Display(Name = "Logo")]
        public HttpPostedFileBase LogoFile { get; set; }
    }
}