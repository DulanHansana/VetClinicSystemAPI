using System.ComponentModel.DataAnnotations;

namespace VetClinicSystemAPI.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        public string MicrochipId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Species { get; set; }

        // Foreign key
        public int VetDoctorId { get; set; }

        public VetDoctor? VetDoctor { get; set; }

        public PetProfile? PetProfile { get; set; }
    }
}
