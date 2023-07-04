using System.ComponentModel.DataAnnotations;

namespace FemKampAPI.Models
{
    public class ResourceGroup
    {
        [Key]
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string CreatedBy { get; set; }    
        public string? TeamCaptain { get; set; }
        public int? Members { get; set; }
    }
}
