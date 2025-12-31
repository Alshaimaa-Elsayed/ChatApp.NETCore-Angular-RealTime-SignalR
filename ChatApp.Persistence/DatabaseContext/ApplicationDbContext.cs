
namespace ChatApp.Persistence.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
                                                          IdentityRole<int>,
                                                          int,
                                                          IdentityUserClaim<int>,
                                                          IdentityUserRole<int>,
                                                          IdentityUserLogin<int>,
                                                          IdentityRoleClaim<int>,
                                                          IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}
