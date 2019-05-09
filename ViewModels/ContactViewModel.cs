using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Website_ASPNET.ViewModels
{
  public class ContactViewModel
  {
    [Required]
    [MinLength(1)]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Subject { get; set; }
    [Required]
    [MaxLength(250, ErrorMessage = "Too Long")]
    public string Message { get; set; }
  }
}
