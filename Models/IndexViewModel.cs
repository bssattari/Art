using Art.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Art.Models;

public class IndexViewModel
{

    /* Validation */
    [Required(ErrorMessage = "Lutfen doldurunuz!")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Lutfen doldurunuz!")]
    public string? Lastname { get; set; }

    [Required(ErrorMessage = "Lutfen doldurunuz!")]
    [EmailAddress(ErrorMessage = "Gecerli bir Email adresi giriniz!")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Lutfen doldurunuz!")]
    public string? Message { get; set; }

    [Required(ErrorMessage = "Lutfen doldurunuz!")]
    public string? Subject { get; set; }







    /* Others */
    public Site? Site { get; set; }
    public IEnumerable<Slide>? Slides { get; set; }
    public Blog? Blog { get; set; }
    public IEnumerable<Blog>? Blogs { get; set; }
    public Event? Event { get; set; }
    public IEnumerable<Event>? Events { get; set; }
    public Work? Work { get; set; }
    public IEnumerable<Work>? Works { get; set; }
    public IEnumerable<Work>? AllWorks { get; set; }
    public IEnumerable<Workcat>? Workcats { get; set; }
     public Workcat? Workcat { get; set; }
    public IEnumerable<Comment>? Comments { get; set; }
    /* public Contactform? Contactform { get; set; }
    public IEnumerable<Contactform>? Contactforms { get; set; } */
    public IEnumerable<Like>? Likes { get; set; }
    public About? About { get; internal set; }
}

