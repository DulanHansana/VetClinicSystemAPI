using System.ComponentModel.DataAnnotations;

namespace VetClinicSystemAPI.Models
{
    public class PetProfile
    {
        public int Id { get; set; }

        [Required]
        public int PetId { get; set; }   // foreign key

        public string? VetNotes { get; set; }

        public Pet? Pet { get; set; }
    }
}
