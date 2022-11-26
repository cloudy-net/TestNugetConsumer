using Cloudy.CMS.SingletonSupport;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website.Models
{
    public class SiteSettings : ISingleton
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SiteName { get; set; }
    }
}
