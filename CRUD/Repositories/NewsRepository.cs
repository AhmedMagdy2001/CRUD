using System.Collections.Generic;
using System.Linq;
using CRUD.Data;
using CRUD.Models;

namespace CRUD.Repositories
{
    public class NewsRepository
    {
        private readonly NewsDbContext _dbContext;

        public NewsRepository(NewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<News> GetAllNews()
        {
            return _dbContext.News.ToList();
        }

        public News GetNewsById(int id)
        {
            return _dbContext.News.FirstOrDefault(n => n.Id == id);
        }

        public void AddNews(News news)
        {
            _dbContext.News.Add(news);
            _dbContext.SaveChanges();
        }

        public void UpdateNews(News news)
        {
            var existingNews = _dbContext.News.Find(news.Id);
            if (existingNews != null) //to check if a news with this id exists 
            {
                existingNews.Title = news.Title;
                existingNews.Description = news.Description;
                _dbContext.SaveChanges();
            }
        }


        public void DeleteNews(News news)
        {
            _dbContext.News.Remove(news);
            _dbContext.SaveChanges();
        }
    }
}
