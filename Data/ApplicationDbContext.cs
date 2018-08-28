using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Jetweet.Models;

namespace Jetweet.Data {
  public class ApplicationDbContext : IdentityDbContext {
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) { }

    public DbSet<Tweet> Tweet { get; set; }
  }
}