using CRUD.Models;
using CRUD.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/news")]
    public class NewsController : ControllerBase
    {
        private readonly NewsRepository _newsRepository;

        public NewsController(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet]
        public IActionResult GetAllNews()
        {
            var news = _newsRepository.GetAllNews();
            return Ok(news);
        }

        [HttpGet("{id}")]
        public IActionResult GetNewsById(int id)
        {
            var news = _newsRepository.GetNewsById(id);
            if (news == null)
            {
                return NotFound();
            }
            return Ok(news);
        }

        [HttpPost]
        public IActionResult AddNews(News news)
        {
            _newsRepository.AddNews(news);
            return CreatedAtAction(nameof(GetNewsById), new { id = news.Id }, news);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateNews(int id, News updatedNews)
        {
            var news = _newsRepository.GetNewsById(id);
            if (news == null)
            {
                return NotFound();
            }
            updatedNews.Id = id;
            _newsRepository.UpdateNews(updatedNews);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNews(int id)
        {
            var news = _newsRepository.GetNewsById(id);
            if (news == null)
            {
                return NotFound();
            }
            _newsRepository.DeleteNews(news);
            return NoContent();
        }
    }
}
