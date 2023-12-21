using PokemonWebApi.Data;
using PokemonWebApi.Interfaces;
using PokemonWebApi.Models;

namespace PokemonWebApi.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context)
        {
            _context = context;
        }
        public Review GetReview(int id)
        {
            var review = _context.Reviews.Where(r => r.Id.Equals(id)).FirstOrDefault();
            return review;
        }

        public ICollection<Review> GetReviews()
        {
            var reviews = _context.Reviews.ToList();
            return reviews;
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeID)
        {
           return _context.Reviews.Where( r => r.Pokemon.Id.Equals(pokeID)).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.Where(r => r.Id.Equals(reviewId)).Any();
        }
    }
}
