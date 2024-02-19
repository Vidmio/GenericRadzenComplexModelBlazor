using GenericRadzenComplexModelBlazor.Components.Repository.Interface;
using GenericRadzenComplexModelBlazor.Components.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace GenericRadzenComplexModelBlazor.Components.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly IDbContextFactory<ApplicationDbContext> _context;
        private string errorMessage;

        public GenericRepository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context;
        }

        public virtual async Task<List<TEntity>> Get()
        {
            using var db = await _context.CreateDbContextAsync();
            return await Task.Run(() => db.Set<TEntity>().ToListAsync());
        }

        public async Task<TEntity?> Get(int id)
        {
            using var db = await _context.CreateDbContextAsync();
            return await db.Set<TEntity>().FindAsync(id);
        }

        public bool Add(in TEntity sender)
        {
            using var db = _context.CreateDbContext();
            db.Entry(sender).State = EntityState.Added;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage ="GRESKA: "+ex.Message + " InnerException: " + ex.InnerException.Message;
                Console.WriteLine(errorMessage);
                return false;
            }
        }

        public bool Update(in TEntity sender)
        {
            using var db = _context.CreateDbContext();
            db.Entry(sender).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message + " InnerException: " + ex.InnerException.Message;
                Console.WriteLine(errorMessage);
                return false;
            }
        }

        public bool Delete(in TEntity sender)
        {
            using var db = _context.CreateDbContext();
            try
            {
                db.Remove(sender);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
