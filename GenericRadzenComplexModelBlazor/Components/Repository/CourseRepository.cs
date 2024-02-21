using GenericRadzenComplexModelBlazor.Components.Model;
using Microsoft.EntityFrameworkCore;

namespace GenericRadzenComplexModelBlazor.Components.Repository
{
    public class CourseRepository : GenericRepository<Course>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;

        public CourseRepository(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Course>> Get()
        {
            using var db = await _context.CreateDbContextAsync();
            return await db.Courses.Include("Department").ToListAsync();
        }
    }
}

