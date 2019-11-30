using System.Collections.Generic;
using System.Net;

namespace CapturePackageCLib
{
    public abstract class WebPage
    {
        private string path;
        private Dictionary<HttpRequestHeader, string> headers;
        private string method;
        private string contentType;
        private long contentLength;
        private int timeout;
        private string userAgent;
        private bool preAuthenticate;
        private bool keepAlive;
        private ICredentials credentials;

        protected WebPage()
            : this(string.Empty)
        { }

        public WebPage(string path)
        {
            this.path = path;
            this.headers = new Dictionary<HttpRequestHeader, string>();
            contentLength = -1;
            timeout = 10 * 1000;
            preAuthenticate = true;
            keepAlive = false;
        }

        public string Path
        {
            get { return this.path; }
            set { this.path = value; }
        }

        public Dictionary<HttpRequestHeader, string> Headers
        {
            get { return this.headers; }
        }

        public string Method
        {
            get { return this.method; }
            set { this.method = value; }
        }

        public string ContentType
        {
            get { return this.contentType; }
            set { this.contentType = value; }
        }

        public long ContentLength
        {
            get { return this.contentLength; }
            set { this.contentLength = value; }
        }

        public int Timeout
        {
            get { return this.timeout; }
            set { this.timeout = value; }
        }

        public string UserAgent
        {
            get { return this.userAgent; }
            set { this.userAgent = value; }
        }

        public bool PreAuthenticate
        {
            get { return this.preAuthenticate; }
            set { this.preAuthenticate = value; }
        }

        public bool KeepAlive
        {
            get { return this.keepAlive; }
            set { this.keepAlive = value; }
        }

        public ICredentials Credentials
        {
            get { return this.credentials; }
            set { this.credentials = value; }
        }

        public string DownloadWebPageContent()
        {
            if (string.IsNullOrEmpty(this.path) || string.IsNullOrWhiteSpace(this.path))
                return string.Empty;

            return DownloadWebPageContentCore();
        }

        protected abstract string DownloadWebPageContentCore();
    }
}
