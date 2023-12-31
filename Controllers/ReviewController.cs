﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonWebApi.Interfaces;
using PokemonWebApi.Models;
using PokemonWebApi.DTO;
namespace PokemonWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper; 
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviews()
        {
            var reviews =_mapper.Map<List<ReviewDTO>>(_reviewRepository.GetReviews());
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(reviews);
        }

        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]

        public IActionResult GetReview(int reviewId)
        {
            if(!_reviewRepository.ReviewExists(reviewId))
            {
                return NotFound();
            }

            var review =_mapper.Map<ReviewDTO>(_reviewRepository.GetReview(reviewId));
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(review);
        }

        [HttpGet("pokemon/{pokeId}")]
        [ProducesResponseType(200, Type =typeof(IEnumerable<Review>))]
        [ProducesResponseType(400)]

        public IActionResult GetReviewFromAPokemon(int pokeId)
        {
            var review = _mapper.Map<List<ReviewDTO>>(_reviewRepository.GetReviewsOfAPokemon(pokeId));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(review);
        }

        

        
    }
}
