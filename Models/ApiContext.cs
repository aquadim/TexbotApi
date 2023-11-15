using Microsoft.EntityFrameworkCore;

namespace TexbotApi.Models;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options) : base(options) {}

    public DbSet<Group> Groups { get; set; } = null!;
}