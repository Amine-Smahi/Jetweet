using System;
using System.ComponentModel.DataAnnotations;

namespace Jetweet.Models {
  public class Tweet {
    public int Id { get; set; }

    [Required] public string Text { get; set; }

    [Required] public string ImageUrl { get; set; }
  }
}