using System;
using System.Collections.Generic;
using System.IO;
using MovieCompulsory.Core.Models;
using MovieCompulsory.DataJson.Repository;
using MovieCompulsory.Domain.IRepository;
using Xunit;
using Assert = Xunit.Assert;

namespace InfrastructureTest
{
    public class ReviewTest
    {
        private readonly TextReader _mockReader = new StreamReader(@"../../../../../MovieCompulsory/InfrastructureTest/MockData/ratings_mock.json");

        #region GetNumberOfReviewsFromReviewer
        [Fact]
        public void GetNumberOfReviewsFromReviewer()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);
            int result = repository.GetNumberOfReviewsFromReviewer(1);
            
            Assert.Equal(5,result);
        }
        
        [Fact]
        public void GetNumberOfReviewsFromReviewerZero()
        {
            int reviewer = 0;
            IReviewRepository repository = new ReviewRepository(_mockReader);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetNumberOfReviewsFromReviewer(reviewer));
            Assert.Equal("No reviewer was found with id " + reviewer ,ex.Message);
        }
        #endregion

        #region GetAverageRateFromReviewer
        [Fact]
        public void GetAverageRateFromReviewer()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);
            double result = repository.GetAverageRateFromReviewer(1);
            
            Assert.Equal(3.8,result);
        }
        
        [Fact]
        public void GetAverageRateFromReviewerZero()
        {
            int reviewer = 0;
            IReviewRepository repository = new ReviewRepository(_mockReader);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetAverageRateFromReviewer(reviewer));
            Assert.Equal("No reviewer was found with id " + reviewer ,ex.Message);
        }
        #endregion

        #region GetNumberOfRatesByReviewer
        [Fact]
        public void GetNumberOfRatesByReviewer()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);
            double result = repository.GetNumberOfRatesByReviewer(1, 5);
            
            Assert.Equal(1,result);
        }

        [Fact]
        public void GetNumberOfRatesByReviewerNoReviewer()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetNumberOfRatesByReviewer(100, 5));
            Assert.Equal("No rates where found for reviewer" ,ex.Message);
        }
        
        [Fact]
        public void GetNumberOfRatesByReviewerRatingAboveRange()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetNumberOfRatesByReviewer(1, 15));
            Assert.Equal("The rating is above range" ,ex.Message);
        }
        
        [Fact]
        public void GetNumberOfRatesByReviewerRatingBellowRange()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetNumberOfRatesByReviewer(1, -5));
            Assert.Equal("The rating is bellow range" ,ex.Message);
        }
        
        [Fact]
        public void GetNumberOfRatesByReviewerRatingNotFound()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetNumberOfRatesByReviewer(29, 5));
            Assert.Equal("No rates where found for reviewer" ,ex.Message);
        }
        #endregion
        
        #region GetNumberOfReviews
        [Fact]
        public void GetNumberOfReviews()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);
            double result = repository.GetNumberOfReviews(1);
            
            Assert.Equal(10,result);
        }
        #endregion

        #region GetAverageRateOfMovie
        [Fact]
        public void GetAverageRateOfMovie()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);
            double result = repository.GetAverageRateOfMovie(1);
            
            Assert.Equal(3.7,result);
        }
        #endregion

        #region GetNumberOfRates
        [Fact]
        public void GetNumberOfRates()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);
            double result = repository.GetNumberOfRates(1,1);
            
            Assert.Equal(1,result);
        }
        
        [Fact]
        public void GetNumberOfRatesMovieBellowZero()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetNumberOfRates(-1,1));
            Assert.Equal("Movie id must be above zero" ,ex.Message);
        }
        
        [Fact]
        public void GetNumberOfRatesRateOutsideTheRangeBellowZero()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetNumberOfRates(1,-11));
            Assert.Equal("Rate is outside of the range" ,ex.Message);
        }
        
        [Fact]
        public void GetNumberOfRatesRateOutsideTheRangeAboveFive()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetNumberOfRates(1,10));
            Assert.Equal("Rate is outside of the range" ,ex.Message);
        }
        #endregion

        #region GetMoviesWithHighestNumberOfTopRates
        [Fact]
        public void GetMoviesWithHighestNumberOfTopRates()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);
            List<int> result = repository.GetMoviesWithHighestNumberOfTopRates();
            
            Assert.Equal(new List<int>{1,2,3,4,5},result);
        }
        #endregion

        #region GetMostProductiveReviewers
        [Fact]
        public void GetMostProductiveReviewers()
        {
            //How to make sure to test them correctly
            IReviewRepository repository = new ReviewRepository(_mockReader);
            List<int> result = repository.GetMostProductiveReviewers();
            
            Assert.Equal(result, result);
        }
        #endregion

        #region GetTopRatedMovies
        [Fact]
        public void GetTopRatedMovies()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);
            List<int> result = repository.GetTopRatedMovies(4);
            
            Assert.Equal(new List<int>{2,1,5,3}, result);
        }
        
        [Fact]
        public void GetTopRatedMoviesAmountBellowZero()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetTopRatedMovies(-1));
            Assert.Equal("Amount must be above zero" ,ex.Message);
        }
        
        [Fact]
        public void GetTopRatedMoviesAmountOutsideTheRange()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetTopRatedMovies(500));
            Assert.Equal("Amount is outside the range" ,ex.Message);
        }
        #endregion

        #region GetTopMoviesByReviewer
        [Fact]
        public void GetTopMoviesByReviewer()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);
            List<int> result = repository.GetTopMoviesByReviewer(2);
            
            Assert.Equal(new List<int>{4,3}, result);
        }
        
        [Fact]
        public void GetTopMoviesByReviewerIdBellowZero()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetTopMoviesByReviewer(-2));
            Assert.Equal("Id must be above zero" ,ex.Message);
        }
        
        [Fact]
        public void GetTopMoviesByReviewerIdAboveTheRange()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetTopMoviesByReviewer(200));
            Assert.Equal("Id is outside of the range" ,ex.Message);
        }
        #endregion

        #region GetReviewersByMovie
        [Fact]
        public void GetReviewersByMovie()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);
            List<int> result = repository.GetReviewersByMovie(4);
            
            Assert.Equal(result, result);
        }
        
        [Fact]
        public void GetReviewersByMovieIdBellowZero()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetReviewersByMovie(-2));
            Assert.Equal("Id must be above zero" ,ex.Message);
        }
        
        [Fact]
        public void GetReviewersByMovieIdAboveTheRange()
        {
            IReviewRepository repository = new ReviewRepository(_mockReader);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetReviewersByMovie(200));
            Assert.Equal("Id is outside of the range" ,ex.Message);
        }



        #endregion
    }

}