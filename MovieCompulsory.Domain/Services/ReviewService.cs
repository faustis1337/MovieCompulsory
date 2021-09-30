using MovieCompulsory.Domain.IRepository;

namespace MovieCompulsory.Domain.Services
{
    public class ReviewService
    {
        private IReviewRepository _reviewRepository;
        
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

    }
}