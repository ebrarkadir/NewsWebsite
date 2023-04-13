using NewsApplication2.Models;
using System.Linq.Expressions;

namespace NewsApplication2.DataAccess.Concrete
{
    public class EfNewsDal
    {
        public void Add(News entity)
        {

            using (NewsContext context = new NewsContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }

        }

        public void DeleteNewsByDate(DateTime date)
        {
            using(NewsContext context = new NewsContext())
            {
                context.news.RemoveRange(context.news.Where(s=>s.PublishDate == date));
                context.SaveChanges();
            }
        }

        public News GetNewsByTitle(string title)
        {
            var news = new News();
            using(NewsContext context = new NewsContext())
            {
                news = context.news.Where(s=>s.Title== title).SingleOrDefault();
            }
            return news;
        }

        public List<News> GetAll()
        {
            var newsList = new List<News>();
            
            using(NewsContext context = new NewsContext())
            {
                newsList = context.news.ToList();
            }

            if(newsList.Count == 0) {
                return null;
            }
            return newsList;

        }


    }
}
