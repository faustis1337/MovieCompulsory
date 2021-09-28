using System;
using System.Collections.Generic;
using MovieCompulsory.DataJson;
using MovieCompulsory.DataJson.Repository;
using MovieCompulsory.Domain.IRepository;
using Xunit;

namespace InfrastructureTest
{
    public class ReviewTest
    {
        private readonly JsonData data = new JsonData();
        
        [Fact]
        public void GetNumberOfReviewsFromReviewerTest()
        {
            IReviewRepository repository = new ReviewRepository(data);
            int result = repository.GetNumberOfReviewsFromReviewer(1);
            
            Assert.Equal(5,result);
        }
        
        [Fact]
        public void GetNumberOfReviewsFromReviewerTestZero()
        {
            int reviewer = 0;
            IReviewRepository repository = new ReviewRepository(data);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetNumberOfReviewsFromReviewer(reviewer));
            Assert.Equal("No reviewer was found with id " + reviewer ,ex.Message);
        }
        
        [Fact]
        public void GetAverageRateFromReviewerTest()
        {
            IReviewRepository repository = new ReviewRepository(data);
            double result = repository.GetAverageRateFromReviewer(1);
            
            Assert.Equal(3.8,result);
        }
        
        [Fact]
        public void GetAverageRateFromReviewerTestZero()
        {
            int reviewer = 0;
            IReviewRepository repository = new ReviewRepository(data);

            var ex = Assert.Throws<InvalidOperationException>(() => repository.GetAverageRateFromReviewer(reviewer));
            Assert.Equal("No reviewer was found with id " + reviewer ,ex.Message);
        }
        
        [Fact]
        public void GetNumberOfRatesByReviewerTest()
        {
            IReviewRepository repository = new ReviewRepository(data);
            double result = repository.GetNumberOfRatesByReviewer(1, 4);
            
            Assert.Equal(2,result);
        }
        
        [Fact]
        public void GetNumberOfReviewsTest()
        {
            IReviewRepository repository = new ReviewRepository(data);
            double result = repository.GetNumberOfReviews(2);
            
            Assert.Equal(10,result);
        }

        [Fact]
        public void GetAverageRateOfMovieTest()
        {
            IReviewRepository repository = new ReviewRepository(data);
            double result = repository.GetAverageRateOfMovie(1);
            
            Assert.Equal(3.7,result);
        }
        
        [Fact]
        public void GetNumberOfRates()
        {
            IReviewRepository repository = new ReviewRepository(data);
            double result = repository.GetNumberOfRates(1,1);
            
            Assert.Equal(1,result);
        }
        
        [Fact]
        public void GetMoviesWithHighestNumberOfTopRates()
        {
            IReviewRepository repository = new ReviewRepository(data);
            List<int> result = repository.GetMoviesWithHighestNumberOfTopRates();
            
            Assert.Equal(new List<int>{1,2,3,4,5},result);
        }
        
        
        
        
    }
}