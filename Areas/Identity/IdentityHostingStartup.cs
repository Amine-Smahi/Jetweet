using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Jetweet.Areas.Identity;
using Jetweet.Data;

[assembly : HostingStartup (typeof (IdentityHostingStartup))]

namespace Jetweet.Areas.Identity {
  public class IdentityHostingStartup : IHostingStartup {
    public void Configure (IWebHostBuilder builder) {
      builder.ConfigureServices ((context, services) => { });
    }
  }
}