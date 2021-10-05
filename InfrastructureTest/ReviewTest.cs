using System;
using System.Collections.Generic;
using MovieCompulsory.Core.Models;
using MovieCompulsory.DataJson.Repository;
using MovieCompulsory.Domain.IRepository;
using Xunit;
using Assert = Xunit.Assert;

namespace InfrastructureTest
{
    public class ReviewTest
    {
        private readonly List<BEReview> _reviews;
        public ReviewTest()
        {
            _reviews = new List<BEReview>();
            _reviews.Add(new BEReview
            {
                Grade = 5,
                Movie = 1,
                ReviewDate = new DateTime(2001, 08, 10),
                Reviewer = 1
            });
            _reviews.Add(new BEReview
            {
                Grade = 1,
                Movie = 1,
                ReviewDate = new DateTime(2001, 08, 10),
                Reviewer = 1
            });
            _reviews.Add(new BEReview
            {
                Grade = 1,
                Movie = 1,
                ReviewDate = new DateTime(2001, 08, 10),
                Reviewer = 2
            });
            _reviews.Add(new BEReview
            {
                Grade = 1,
                Movie = 1,
                ReviewDate = new DateTime(2001, 08, 10),
                Reviewer = 3
            });
            _reviews.Add(new BEReview
            {
                Grade = 1,
                Movie = 1,
                ReviewDate = new DateTime(2001, 08, 10),
                Reviewer = 4
            });          
            _reviews.Add(new BEReview
            {
                Grade = 1,
                Movie = 1,
                ReviewDate = new DateTime(2001, 08, 10),
                Reviewer = 5
            });
            _reviews.Add(new BEReview
            {
                Grade = 1,
                Movie = 1,
                ReviewDate = new DateTime(2001, 08, 10),
                Reviewer = 5
            });
            _reviews.Add(new BEReview
            {
                Grade = 1,
                Movie = 1,
                ReviewDate = new DateTime(2001, 08, 10),
                Reviewer = 5
            });
        }
        [Fact]
        public void GetNumberOfReviewsFromReviewer()
        {
            IReviewRepository repository = new ReviewRepository(_reviews);
            int result = repository.GetNumberOfReviewsFromReviewer(1);
            
            Assert.Equal(2,result);
        }
        
        [Fact]
        public void GetNumberOfReviewsFromReviewerZero()
        {
            int reviewer = 0;
            IReviewRepository repository = new ReviewRepository(_reviews);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetNumberOfReviewsFromReviewer(reviewer));
            Assert.Equal("No reviewer was found with id " + reviewer ,ex.Message);
        }
        
        [Fact]
        public void GetAverageRateFromReviewer()
        {
            IReviewRepository repository = new ReviewRepository(_reviews);
            double result = repository.GetAverageRateFromReviewer(1);
            
            Assert.Equal(3,result);
        }
        
        [Fact]
        public void GetAverageRateFromReviewerZero()
        {
            int reviewer = 0;
            IReviewRepository repository = new ReviewRepository(_reviews);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetAverageRateFromReviewer(reviewer));
            Assert.Equal("No reviewer was found with id " + reviewer ,ex.Message);
        }
        
        [Fact]
        public void GetNumberOfRatesByReviewer()
        {
            IReviewRepository repository = new ReviewRepository(_reviews);
            double result = repository.GetNumberOfRatesByReviewer(1, 5);
            
            Assert.Equal(1,result);
        }
        
        [Fact]
        public void GetNumberOfReviews()
        {
            IReviewRepository repository = new ReviewRepository(_reviews);
            double result = repository.GetNumberOfReviews(1);
            
            Assert.Equal(8,result);
        }

        [Fact]
        public void GetAverageRateOfMovie()
        {
            IReviewRepository repository = new ReviewRepository(_reviews);
            double result = repository.GetAverageRateOfMovie(1);
            
            Assert.Equal(1.5,result);
        }

        [Fact]
        public void GetNumberOfRates()
        {
            IReviewRepository repository = new ReviewRepository(_reviews);
            double result = repository.GetNumberOfRates(1,1);
            
            Assert.Equal(7,result);
        }
        
        [Fact]
        public void GetMoviesWithHighestNumberOfTopRates()
        {
            IReviewRepository repository = new ReviewRepository(_reviews);
            List<int> result = repository.GetMoviesWithHighestNumberOfTopRates();
            
            Assert.Equal(new List<int>{1},result);
        }
        
        [Fact]
        public void GetMostProductiveReviewers()
        {
            //How to make sure to test them correctly
            IReviewRepository repository = new ReviewRepository(_reviews);
            List<int> result = repository.GetMostProductiveReviewers();
            
            Assert.Equal(result, result);
        }
        
        [Fact]
        public void GetTopRatedMovies()
        {
            IReviewRepository repository = new ReviewRepository(_reviews);
            List<int> result = repository.GetTopRatedMovies(4);
            
            Assert.Equal(new List<int>{1}, result);
        }

        [Fact]
        public void GetTopMoviesByReviewer()
        {
            IReviewRepository repository = new ReviewRepository(_reviews);
            List<int> result = repository.GetTopMoviesByReviewer(2);
            
            Assert.Equal(new List<int>{1}, result);
        }

        [Fact]
        public void GetReviewersByMovie()
        {
            IReviewRepository repository = new ReviewRepository(_reviews);
            List<int> result = repository.GetReviewersByMovie(4);
            
            Assert.Equal(result, result);
        }

        
        
        
    }
}