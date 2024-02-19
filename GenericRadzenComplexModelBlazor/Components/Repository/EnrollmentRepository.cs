using GenericRadzenComplexModelBlazor.Components.Model;
using Microsoft.EntityFrameworkCore;

namespace GenericRadzenComplexModelBlazor.Components.Repository
{
    public class EnrollmentRepository : GenericRepository<Enrollment>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public EnrollmentRepository(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Enrollment>> Get()
        {
            using var db = await _context.CreateDbContextAsync();
            return await db.Enrollments.Include("Student").Include("Course").ToListAsync();
        }
    }
}
