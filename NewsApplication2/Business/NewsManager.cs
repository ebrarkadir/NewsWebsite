using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NewsApplication2.DataAccess.Concrete;
using NewsApplication2.Models;
using NewsApplication2.Services;

namespace NewsApplication2.Business
{
	public class NewsManager
	{
		EfNewsDal efNewsDal = new EfNewsDal();
		int pageCount = 0;
		public void AddNewsOnDB(News news)
		{
			CheckBoundDate();
			var checkNews = efNewsDal.GetNewsByTitle(news.Title);

			if (checkNews != null)
			{
				return;
			}
			efNewsDal.Add(news);

		}

		public void CheckBoundDate()
		{

			string dateWhichDeletedNews = DateTime.Today.AddDays(-2).ToString("yyyy/MM/dd HH:mm:ss");


			DateTime testtime = DateTime.Parse(dateWhichDeletedNews);


			efNewsDal.DeleteNewsByDate(testtime);
		}


		public List<News> GetNewsOnAPI(DateTime date, int page, string searchNews)
		{
			var gettedNews = NewsAPIService.GetNews(DateTime.Now, page, searchNews);
			var news = new List<News>();

			foreach (var item in gettedNews)
			{
				AddNewsOnDB(item);
			}

			pageCount = (int)Math.Ceiling((double)gettedNews.Count / 15);
			int startIndex = (page - 1) * 15;

			if (startIndex >= gettedNews.Count)
			{
				startIndex = gettedNews.Count - 1;
			}

			int count = Math.Min(15, gettedNews.Count - startIndex);
			news = gettedNews.GetRange(startIndex, count);
			return news;

		}




		public int GetPageCount()
		{
			return pageCount;
		}

	}
}
