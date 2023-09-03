using Art.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Art.Models;

public class IndexViewModel
{

    /*Validations*/

    [Required(ErrorMessage = "Lütfen seçiniz!")]
    public IFormFile? File { get; set; }

    [Required(ErrorMessage = "Lütfen doldurunuz!")]
    public string? Order { get; set; }

    [Required(ErrorMessage = "Lütfen doldurunuz!")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Lütfen doldurunuz!")]
    public string? Subtitle { get; set; }

    [Required(ErrorMessage = "Lütfen doldurunuz!")]
    public string? Url { get; set; }

    [Required(ErrorMessage = "Lütfen seçiniz!")]
    public string? Target { get; set; }

    [Required(ErrorMessage = "Lütfen doldurunuz!")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Lütfen doldurunuz!")]
    public string? Lastname { get; set; }

    [Required(ErrorMessage = "Lütfen doldurunuz!")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-mail adresi giriniz!")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Lütfen doldurunuz!")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Lütfen doldurunuz!")]
    public string? Message { get; set; }

    [Required(ErrorMessage = "Lütfen doldurunuz!")]
    public string? Subject { get; set; }





    /*Others*/
    public Site? Site { get; set; }

    public Slide? Slide { get; set; }
    public IEnumerable<Slide>? Slides { get; set; }

    public Blog? Blog { get; set; }
    public IEnumerable<Blog>? Blogs { get; set; }

    public Event? Event { get; set; }
    public IEnumerable<Event>? Events { get; set; }

    public Work? Work { get; set; }
    public IEnumerable<Work>? Works { get; set; }
    public IEnumerable<Work>? AllWorks { get; set; }

    public Workcat? Workcat { get; set; }
    public IEnumerable<Workcat>? Workcats { get; set; }

    public IEnumerable<Comment>? Comments { get; set; }
    public IEnumerable<Like>? Likes { get; set; }

    public About? About { get; set; }

    public User? User { get; set; }
    public IEnumerable<User>? Users { get; set; }


}
