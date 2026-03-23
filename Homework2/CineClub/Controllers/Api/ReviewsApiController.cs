using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineClub.Data;
using Microsoft.AspNetCore.Identity;

namespace CineClub.Controllers.Api
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewsApiController : ControllerBase
    {
        private readonly CineDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReviewsApiController(CineDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetReviewsByMovie(int movieId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.MovieId == movieId)
                .ToListAsync();

            var result = new List<object>();

            foreach (var r in reviews)
            {
                string username = "Unknown";
                if (!string.IsNullOrEmpty(r.UserId))
                {
                    var user = await _userManager.FindByIdAsync(r.UserId);
                    username = user?.UserName ?? "Unknown";
                }
                result.Add(new
                {
                    review = r.Content,
                    reviewRate = r.Rating,
                    reviewDate = r.CreatedAtUtc,
                    username = username
                });
            }

            return Ok(result);
        }
    }
}