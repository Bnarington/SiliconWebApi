using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class SubscriberEntity
{
    [Key]
    [Required]
    public string Email { get; set; } = null!;
}
