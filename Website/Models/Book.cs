using System.ComponentModel.DataAnnotations.Schema;
using System;
using Cloudy.CMS.ContentSupport;
using System.ComponentModel.DataAnnotations;
using Cloudy.CMS.UI.FormSupport.FieldTypes;

namespace Website.Models
{
    [Display(Description = "Your own personal library.")]
    public class Book : INameable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Select(typeof(Author))]
        public Guid AuthorId { get; set; }
    }
}
