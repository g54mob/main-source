using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	internal sealed class HttpListenerRequest
	{
		private static readonly byte[] _100continue;

		private string[] _acceptTypes;

		private bool _chunked;

		private HttpConnection _connection;

		private Encoding _contentEncoding;

		private long _contentLength;

		private HttpListenerContext _context;

		private CookieCollection _cookies;

		private static readonly Encoding _defaultEncoding;

		private WebHeaderCollection _headers;

		private string _httpMethod;

		private Stream _inputStream;

		private Version _protocolVersion;

		private NameValueCollection _queryString;

		private string _rawUrl;

		private Guid _requestTraceIdentifier;

		private Uri _url;

		private Uri _urlReferrer;

		private bool _urlSet;

		private string _userHostName;

		private string[] _userLanguages;

		public string[] AcceptTypes => null;

		public int ClientCertificateError => 0;

		public Encoding ContentEncoding => null;

		public long ContentLength64 => 0L;

		public string ContentType => null;

		public CookieCollection Cookies => null;

		public bool HasEntityBody => false;

		public NameValueCollection Headers => null;

		public string HttpMethod => null;

		public Stream InputStream => null;

		public bool IsAuthenticated => false;

		public bool IsLocal => false;

		public bool IsSecureConnection => false;

		public bool IsWebSocketRequest => false;

		public bool KeepAlive => false;

		public IPEndPoint LocalEndPoint => null;

		public Version ProtocolVersion => null;

		public NameValueCollection QueryString => null;

		public string RawUrl => null;

		public IPEndPoint RemoteEndPoint => null;

		public Guid RequestTraceIdentifier => default(Guid);

		public Uri Url => null;

		public Uri UrlReferrer => null;

		public string UserAgent => null;

		public string UserHostAddress => null;

		public string UserHostName => null;

		public string[] UserLanguages => null;

		static HttpListenerRequest()
		{
		}

		internal HttpListenerRequest(HttpListenerContext context)
		{
		}

		private Encoding getContentEncoding()
		{
			return null;
		}

		internal void AddHeader(string headerField)
		{
		}

		internal void FinishInitialization()
		{
		}

		internal bool FlushInput()
		{
			return false;
		}

		internal bool IsUpgradeRequest(string protocol)
		{
			return false;
		}

		internal void SetRequestLine(string requestLine)
		{
		}

		public IAsyncResult BeginGetClientCertificate(AsyncCallback requestCallback, object state)
		{
			return null;
		}

		public X509Certificate2 EndGetClientCertificate(IAsyncResult asyncResult)
		{
			return null;
		}

		public X509Certificate2 GetClientCertificate()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
