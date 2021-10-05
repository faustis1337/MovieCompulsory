using System.Collections.Generic;
using MovieCompulsory.Core.IServices;
using MovieCompulsory.Domain.IRepository;

namespace MovieCompulsory.Domain.Services
{
    public class ReviewService:IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        
        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            return _reviewRepository.GetNumberOfReviewsFromReviewer(reviewer);
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            return _reviewRepository.GetAverageRateFromReviewer(reviewer);
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            return _reviewRepository.GetNumberOfRatesByReviewer(reviewer, rate);
        }

        public int GetNumberOfReviews(int movie)
        {
            return _reviewRepository.GetNumberOfReviews(movie);
        }

        public double GetAverageRateOfMovie(int movie)
        {
            return _reviewRepository.GetAverageRateOfMovie(movie);
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            return _reviewRepository.GetNumberOfRates(movie, rate);
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            return _reviewRepository.GetMoviesWithHighestNumberOfTopRates();
        }

        public List<int> GetMostProductiveReviewers()
        {
            return _reviewRepository.GetMostProductiveReviewers();
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            return _reviewRepository.GetTopRatedMovies(amount);
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            return _reviewRepository.GetTopMoviesByReviewer(reviewer);
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            return _reviewRepository.GetReviewersByMovie(movie);
        }
    }
}