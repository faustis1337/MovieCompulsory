﻿using System;
using System.Collections.Generic;
using System.Linq;
using MovieCompulsory.Core.Models;
using MovieCompulsory.Domain.IRepository;

namespace MovieCompulsory.DataJson.Repository
{
    public class ReviewRepository : IReviewRepository

    {
        private readonly List<BEReview> _allReviews;
        public ReviewRepository()
        {
            _allReviews = new JsonData().GetAllReviews();
        }
        
        public ReviewRepository(List<BEReview> reviews)
        {
            _allReviews = reviews;
        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            int numberOfReviews= _allReviews.Count(r => r.Reviewer == reviewer);
            if (numberOfReviews == 0)
            {
                throw new InvalidOperationException("No reviewer was found with id " + reviewer);
            }

            return numberOfReviews;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            int numberOfReviews = GetNumberOfReviewsFromReviewer(reviewer);
            IEnumerable<int> totalReviewsArray = _allReviews.Where(r => r.Reviewer == reviewer).Select(r => r.Grade);
            int totalReviews = 0;
            
            if (totalReviewsArray.Count() == null)
            {
                throw new InvalidOperationException("No reviewer was found with id " + reviewer);
            }
            
            foreach (var review in totalReviewsArray)
            {
                totalReviews += review;
            }
            
            double averageRate = (double) totalReviews / numberOfReviews;
            return averageRate;
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            return _allReviews
                .Where(r => r.Reviewer == reviewer).Count(rt => rt.Grade == rate);
        }

        public int GetNumberOfReviews(int movie)
        {
            return _allReviews.Count(r => r.Movie == movie);
        }

        public double GetAverageRateOfMovie(int movie)
        {
            int numberOfReviews = GetNumberOfReviews(movie);
            IEnumerable<int> totalReviewsArray = _allReviews.Where(r => r.Movie == movie).Select(r => r.Grade);
            int totalReviews = 0;

            foreach (var review in totalReviewsArray)
            {
                totalReviews += review;
            }
            
            double averageRate = (double) totalReviews / numberOfReviews;
            return averageRate;
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            return _allReviews
                .Where(r => r.Movie == movie).Count(rt => rt.Grade == rate);
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            int highestId = _allReviews.Max(m => m.Movie);
            List<int> highestTopRates = new List<int>(5);

            for (int i = 1; i <= highestId; i++)
            {
                int numberOfTopScores = _allReviews.Where(m => m.Movie == i).Count(m => m.Grade == 5);
                if (i < 6)
                {
                    highestTopRates.Add(i);
                }else if (highestTopRates.Min() < numberOfTopScores)
                {
                    highestTopRates.Remove(highestTopRates.Min());
                    highestTopRates.Add(i);
                }
            }



            return highestTopRates;
        }

        public List<int> GetMostProductiveReviewers()
        {
            int highestReviewerId = _allReviews.Max(m => m.Reviewer);
            Dictionary<int, int> reviewerProductivity = new Dictionary<int, int>();

            for (int i = 1; i < highestReviewerId; i++)
            {
                int id = i;
                int count = _allReviews.Count(r => r.Reviewer == id);
                reviewerProductivity.Add(i,count);
            }
            
            return reviewerProductivity.OrderByDescending(key => key.Value).Select(value => value.Key).ToList();
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            return _allReviews.OrderByDescending(review => review.Grade).Select(review => review.Movie).Distinct().Take(amount).ToList(); 
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            return _allReviews.OrderByDescending(review => review.Grade).ThenByDescending(review => review.ReviewDate)
                .Where(review => review.Reviewer == reviewer).Select(review => review.Movie).ToList();
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            return _allReviews.OrderByDescending(review => review.Grade).ThenByDescending(review => review.ReviewDate)
                .Where(review => review.Movie == movie).Select(review => review.Reviewer).ToList();
        }
    }
}