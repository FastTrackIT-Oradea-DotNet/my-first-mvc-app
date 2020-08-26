using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstMvcApp.Models
{
    public class ContactListEntry
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Contact Type")]
        [Required]
        public ContactType ContactType { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Upload)]
        public byte[] AvatarContent { get; set; }

        [NotMapped]
        [Display(Name = "Avatar Image")]
        public IFormFile PostedAvatarFile { get; set; }

        [NotMapped]
        [FileExtensions(Extensions = "png")]
        public string PostedAvatarFileName
        {
            get
            {
                return PostedAvatarFile?.FileName ?? "None.png";
            }
        }

        [NotMapped]
        public string SrcBase64
        {
            get
            {
                if ((AvatarContent?.Length ?? 0) <= 0)
                {
                    return "/img/no-content.png";
                }

                return $"data:image/png;base64,{Convert.ToBase64String(AvatarContent)}";
            }
        }
    }
}
