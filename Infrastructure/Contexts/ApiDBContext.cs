using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class ApiDBContext(DbContextOptions<ApiDBContext> options) : DbContext(options)
{
    public DbSet<SubscriberEntity> Subscriptions { get; set; }
    public DbSet<CoursesEntity> Courses { get; set; }
}
