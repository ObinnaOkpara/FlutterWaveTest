using FlutterTest.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlutterTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class moviesController : ControllerBase
    {

        private readonly IMovieService _movieService;
        public moviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("stats")]
        public IActionResult GetMoviesStats()
        {
            return Ok(_movieService.GetMovieStats());
        }
    }
}
