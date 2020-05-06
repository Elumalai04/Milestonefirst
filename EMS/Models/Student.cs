using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required, DataType(DataType.DateTime)]
        [Column(TypeName = "DateTime")]
        [Display(Name = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Column(TypeName = "boolean")]
        [Display(Name = "Gender")]
        public bool Gender { get; set; }

        [Required]
        [Column(TypeName = "varchar(240)")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "int")]
        [Display(Name = "PhoneNumber")]
        public int PhoneNumber { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [ForeignKey("School")]
        [Required]
        [Column(TypeName = "int")]
        [Display(Name = "Id")]
        public int SchoolId { get; set; }

        [NotMapped]
        public string SchoolName { get; set; }
    }
}

