using CapturePackageCLib;
using System.Net;

namespace CapturePackageCLibTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args[0];

            var novelWebPage = new NovelWebPage(path);

            novelWebPage.KeepAlive = false;
            novelWebPage.PreAuthenticate = true;
            novelWebPage.Method = "GET";
            novelWebPage.ContentType = "text/xml";
            novelWebPage.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36";

            novelWebPage.Headers.Add(HttpRequestHeader.ContentEncoding, "gzip, deflate, br");
            novelWebPage.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9");
            novelWebPage.Headers.Add(HttpRequestHeader.Pragma, "no-cache");

            var novelContent = novelWebPage.DownloadWebPageContent();
        }
    }
}
