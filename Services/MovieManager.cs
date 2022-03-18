using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MovieManager
    {
        private ApplicationDbContext _context;

        public MovieManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Movie movie)
        {
           await _context.Movies.AddAsync(movie);
           await _context.SaveChangesAsync();
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            var movieList = await _context.Movies
                .Include(c => c.MovieToCategories)
                .ThenInclude(c => c.Category)
                .ToListAsync();
            return movieList;
        }

        public async Task<Movie?> GetById(int id)
        {
            var movieDetail = await _context.Movies
                .Include(c => c.MovieToCategories)
                .ThenInclude(c => c.Category)
                .FirstOrDefaultAsync(c=>c.Id==id);
            return movieDetail;
        }

        public async Task UpdateMovie(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

    }
}
