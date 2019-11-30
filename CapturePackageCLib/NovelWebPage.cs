using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace CapturePackageCLib
{
    public class NovelWebPage : WebPage
    {
        protected NovelWebPage()
            : this(string.Empty)
        { }

        public NovelWebPage(string path)
            : base(path)
        { }

        protected override string DownloadWebPageContentCore()
        {
            var request = (HttpWebRequest)WebRequest.Create(Path);

            if (Headers != null)
                foreach (var header in Headers)
                    request.Headers.Add(header.Key, header.Value);

            if (ContentLength > 0)
                request.ContentLength = ContentLength;

            if (!string.IsNullOrEmpty(UserAgent))
                request.UserAgent = UserAgent;

            request.Timeout = Timeout;

            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {

                }
            }

            return string.Empty;
        }
    }
}
