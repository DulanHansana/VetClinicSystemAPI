using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetClinicSystemAPI.Models
{
    public class VetDoctor
    {
        public int Id { get; set; }  // PK

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Specialty { get; set; }

        public ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}
