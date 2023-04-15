using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI;
using NewsApplication2.Models;

namespace NewsApplication2.Services
{
    public static class NewsAPIService
    {
        private static string _apiKey { get; set; } = "58ca996094324626802c5ddbfa0a8015";

        private static List<News> _news = new List<News>();

        public static List<News> GetNews(DateTime date, int? page, string saerchNews)
        {
            _news.Clear();
            var newsApiClient = new NewsApiClient(_apiKey);

            
            var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            {
                Q = saerchNews,
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = date.Date,
                To = date.AddDays(-4),
                
            }); 
            if (articlesResponse.Status == Statuses.Ok)
            {

                for (int i = 0; i < articlesResponse.Articles.Count; i++)
                {
                    var item = articlesResponse.Articles[i];
                    var haber = new News();

                    haber.Title = item.Title;
                    haber.Content = item.Content;
                    haber.Image = item.UrlToImage;
                    haber.SourceUrl = item.Url;
                    haber.PublishDate = item.PublishedAt.Value.Date;

                    _news.Add(haber);
                }


                return _news;
            }

            return null;
        }

    }
}
