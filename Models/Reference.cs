using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CodeHelpRepoWebApp.Models
{
	public class Reference
	{

        [Key]
		public int Id { get; set; }

        [Required]
		public string Language { get; set; }
        [Required]
        [UrlAttribute()]
		public string Link { get; set; }
        [Required]
		public string Keyphrase { get; set; }
        [Required]
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now.ToUniversalTime();

        public Reference()
        {
            Language = String.Empty;
            Link = String.Empty;
            Keyphrase = String.Empty;
            ProjectName = String.Empty;


        }
    }
}

