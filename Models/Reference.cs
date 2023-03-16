using System;
using System.ComponentModel.DataAnnotations;

namespace CodeHelpRepoWebApp.Models
{
	public class Reference
	{

        [Key]
		public int Id { get; set; }

        [Required]
		public string Language { get; set; }
        [Required]
		public string Link { get; set; }
        [Required]
		public string Keyphrase { get; set; }
        [Required]
        public string ProjectName { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public Reference()
        {
            Language = String.Empty;
            Link = String.Empty;
            Keyphrase = String.Empty;
            ProjectName = String.Empty;


        }
    }
}

