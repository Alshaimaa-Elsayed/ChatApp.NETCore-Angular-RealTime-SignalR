

namespace ChatApp.Domain.Entities
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string ImageUrl { get; set; } = default!;
        public string City { get; set; } = default!;
        public string? bio { get; set; }
        public string? Intersts { get; set; }
        public PrecensStatus PrecensStatus { get; set; } = PrecensStatus.Online;
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
    }
}
