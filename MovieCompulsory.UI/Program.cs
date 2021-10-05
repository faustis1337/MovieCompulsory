using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MovieCompulsory.Core.IServices;
using MovieCompulsory.Core.Models;
using MovieCompulsory.DataJson;
using MovieCompulsory.DataJson.Repository;
using MovieCompulsory.Domain.IRepository;
using MovieCompulsory.Domain.Services;

namespace MovieCompulsory.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IReviewRepository,ReviewRepository>();
            serviceCollection.AddScoped<IReviewService, ReviewService>();
            serviceCollection.AddScoped<TextReader>(_ => new StreamReader(@"../../../../MovieCompulsory.DataJson/ratings.json"));
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var reviewService = serviceProvider.GetRequiredService<IReviewService>();

            foreach (var movie in reviewService.GetMostProductiveReviewers())
            {
                Console.WriteLine(movie);
            }
        }
    }
}