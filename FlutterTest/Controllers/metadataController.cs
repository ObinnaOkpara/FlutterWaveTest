using FlutterTest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlutterTest.ViewModels.MetaData;
using FlutterTest.Interface;

namespace FlutterTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class metadataController : ControllerBase
    {

        private readonly IMetaDataService _metaDataService;
        public metadataController(IMetaDataService metaDataService)
        {
            _metaDataService = metaDataService;
        }

        [HttpPost]
        public IActionResult PostMetaData([FromBody] MetaDataVM data)
        {
            if (_metaDataService.PostMetaData(data))
            {
                return Ok("Saved Successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{movieId}")]
        public IActionResult GetMetaData(int movieId)
        {
            var result = _metaDataService.GetMetaDataByMovieId(movieId);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
