namespace Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is 50")]
        [Index("Team_Name_League_Index", IsUnique = true, Order = 1)]
        [Display(Name = "Team")]
        public string Name { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        [StringLength(3, ErrorMessage = "The length for field {0} must be {1} characters", MinimumLength = 3)]
        [Index("Team_Initials_League_Index", IsUnique = true, Order = 1)]
        public string Initials { get; set; }

        [Index("Team_Name_League_Index", IsUnique = true, Order = 2)]
        [Index("Team_Initials_League_Index", IsUnique = true, Order = 2)]
        [Display(Name = "League")]
        public int LeagueId { get; set; }

        public virtual League League { get; set; }
    }
}
