using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace WebSocketSharp.Net
{
	public sealed class HttpListenerResponse : IDisposable
	{
		private bool _closeConnection;

		private Encoding _contentEncoding;

		private long _contentLength;

		private string _contentType;

		private HttpListenerContext _context;

		private CookieCollection _cookies;

		private static readonly string _defaultProductName;

		private bool _disposed;

		private WebHeaderCollection _headers;

		private bool _headersSent;

		private bool _keepAlive;

		private ResponseStream _outputStream;

		private Uri _redirectLocation;

		private bool _sendChunked;

		private int _statusCode;

		private string _statusDescription;

		private Version _version;

		internal bool CloseConnection
		{
			get
			{
				return _closeConnection;
			}
			set
			{
				_closeConnection = value;
			}
		}

		internal WebHeaderCollection FullHeaders
		{
			get
			{
				WebHeaderCollection webHeaderCollection = new WebHeaderCollection(HttpHeaderType.Response, internallyUsed: true);
				if (_headers != null)
				{
					webHeaderCollection.Add(_headers);
				}
				if (_contentType != null)
				{
					string value = createContentTypeHeaderText(_contentType, _contentEncoding);
					webHeaderCollection.InternalSet("Content-Type", value, response: true);
				}
				if (webHeaderCollection["Server"] == null)
				{
					webHeaderCollection.InternalSet("Server", _defaultProductName, response: true);
				}
				if (webHeaderCollection["Date"] == null)
				{
					string value2 = DateTime.UtcNow.ToString("r", CultureInfo.InvariantCulture);
					webHeaderCollection.InternalSet("Date", value2, response: true);
				}
				if (_sendChunked)
				{
					webHeaderCollection.InternalSet("Transfer-Encoding", "chunked", response: true);
				}
				else
				{
					string value3 = _contentLength.ToString(CultureInfo.InvariantCulture);
					webHeaderCollection.InternalSet("Content-Length", value3, response: true);
				}
				int reuses = _context.Connection.Reuses;
				if (!_context.Request.KeepAlive || !_keepAlive || reuses >= 100 || _statusCode == 400 || _statusCode == 408 || _statusCode == 411 || _statusCode == 413 || _statusCode == 414 || _statusCode == 500 || _statusCode == 503)
				{
					webHeaderCollection.InternalSet("Connection", "close", response: true);
				}
				else
				{
					string format = "timeout=15,max={0}";
					int num = 100 - reuses;
					string value4 = string.Format(format, num);
					webHeaderCollection.InternalSet("Keep-Alive", value4, response: true);
				}
				if (_redirectLocation != null)
				{
					webHeaderCollection.InternalSet("Location", _redirectLocation.AbsoluteUri, response: true);
				}
				if (_cookies != null)
				{
					foreach (Cookie cookie in _cookies)
					{
						string value5 = cookie.ToResponseString();
						webHeaderCollection.InternalSet("Set-Cookie", value5, response: true);
					}
				}
				return webHeaderCollection;
			}
		}

		internal bool HeadersSent
		{
			get
			{
				return _headersSent;
			}
			set
			{
				_headersSent = value;
			}
		}

		internal string ObjectName => GetType().ToString();

		internal string StatusLine
		{
			get
			{
				string format = "HTTP/{0} {1} {2}\r\n";
				return string.Format(format, _version, _statusCode, _statusDescription);
			}
		}

		public Encoding ContentEncoding
		{
			get
			{
				return _contentEncoding;
			}
			set
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(ObjectName);
				}
				if (_headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				_contentEncoding = value;
			}
		}

		public long ContentLength64
		{
			get
			{
				return _contentLength;
			}
			set
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(ObjectName);
				}
				if (_headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				if (value < 0)
				{
					string paramName = "Less than zero.";
					throw new ArgumentOutOfRangeException(paramName, "value");
				}
				_contentLength = value;
			}
		}

		public string ContentType
		{
			get
			{
				return _contentType;
			}
			set
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(ObjectName);
				}
				if (_headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				if (value == null)
				{
					_contentType = null;
					return;
				}
				if (value.Length == 0)
				{
					throw new ArgumentException("An empty string.", "value");
				}
				if (!isValidForContentType(value))
				{
					string message2 = "It contains an invalid character.";
					throw new ArgumentException(message2, "value");
				}
				_contentType = value;
			}
		}

		public CookieCollection Cookies
		{
			get
			{
				if (_cookies == null)
				{
					_cookies = new CookieCollection();
				}
				return _cookies;
			}
			set
			{
				_cookies = value;
			}
		}

		public WebHeaderCollection Headers
		{
			get
			{
				if (_headers == null)
				{
					_headers = new WebHeaderCollection(HttpHeaderType.Response, internallyUsed: false);
				}
				return _headers;
			}
			set
			{
				if (value == null)
				{
					_headers = null;
					return;
				}
				if (value.State != HttpHeaderType.Response)
				{
					string message = "The value is not valid for a response.";
					throw new InvalidOperationException(message);
				}
				_headers = value;
			}
		}

		public bool KeepAlive
		{
			get
			{
				return _keepAlive;
			}
			set
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(ObjectName);
				}
				if (_headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				_keepAlive = value;
			}
		}

		public Stream OutputStream
		{
			get
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(ObjectName);
				}
				if (_outputStream == null)
				{
					_outputStream = _context.Connection.GetResponseStream();
				}
				return _outputStream;
			}
		}

		public Version ProtocolVersion => _version;

		public string RedirectLocation
		{
			get
			{
				return (_redirectLocation != null) ? _redirectLocation.OriginalString : null;
			}
			set
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(ObjectName);
				}
				if (_headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				if (value == null)
				{
					_redirectLocation = null;
					return;
				}
				if (value.Length == 0)
				{
					throw new ArgumentException("An empty string.", "value");
				}
				if (!Uri.TryCreate(value, UriKind.Absolute, out var result))
				{
					string message2 = "Not an absolute URL.";
					throw new ArgumentException(message2, "value");
				}
				_redirectLocation = result;
			}
		}

		public bool SendChunked
		{
			get
			{
				return _sendChunked;
			}
			set
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(ObjectName);
				}
				if (_headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				_sendChunked = value;
			}
		}

		public int StatusCode
		{
			get
			{
				return _statusCode;
			}
			set
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(ObjectName);
				}
				if (_headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				if (value < 100 || value > 999)
				{
					string message2 = "A value is not between 100 and 999 inclusive.";
					throw new ProtocolViolationException(message2);
				}
				_statusCode = value;
				_statusDescription = value.GetStatusDescription();
			}
		}

		public string StatusDescription
		{
			get
			{
				return _statusDescription;
			}
			set
			{
				if (_disposed)
				{
					throw new ObjectDisposedException(ObjectName);
				}
				if (_headersSent)
				{
					string message = "The response is already being sent.";
					throw new InvalidOperationException(message);
				}
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length == 0)
				{
					_statusDescription = _statusCode.GetStatusDescription();
					return;
				}
				if (!isValidForStatusDescription(value))
				{
					string message2 = "It contains an invalid character.";
					throw new ArgumentException(message2, "value");
				}
				_statusDescription = value;
			}
		}

		static HttpListenerResponse()
		{
			_defaultProductName = "websocket-sharp/1.0";
		}

		internal HttpListenerResponse(HttpListenerContext context)
		{
			_context = context;
			_keepAlive = true;
			_statusCode = 200;
			_statusDescription = "OK";
			_version = HttpVersion.Version11;
		}

		private bool canSetCookie(Cookie cookie)
		{
			List<Cookie> list = findCookie(cookie).ToList();
			if (list.Count == 0)
			{
				return true;
			}
			int version = cookie.Version;
			foreach (Cookie item in list)
			{
				if (item.Version == version)
				{
					return true;
				}
			}
			return false;
		}

		private void close(bool force)
		{
			_disposed = true;
			_context.Connection.Close(force);
		}

		private void close(byte[] responseEntity, int bufferLength, bool willBlock)
		{
			if (willBlock)
			{
				OutputStream.WriteBytes(responseEntity, bufferLength);
				close(force: false);
			}
			else
			{
				OutputStream.WriteBytesAsync(responseEntity, bufferLength, delegate
				{
					close(force: false);
				}, null);
			}
		}

		private static string createContentTypeHeaderText(string value, Encoding encoding)
		{
			if (value.Contains("charset="))
			{
				return value;
			}
			if (encoding == null)
			{
				return value;
			}
			string format = "{0}; charset={1}";
			return string.Format(format, value, encoding.WebName);
		}

		private IEnumerable<Cookie> findCookie(Cookie cookie)
		{
			if (_cookies == null || _cookies.Count == 0)
			{
				yield break;
			}
			foreach (Cookie c in _cookies)
			{
				if (c.EqualsWithoutValueAndVersion(cookie))
				{
					yield return c;
				}
			}
		}

		private static bool isValidForContentType(string value)
		{
			foreach (char c in value)
			{
				if (c < ' ')
				{
					return false;
				}
				if (c > '~')
				{
					return false;
				}
				if ("()<>@:\\[]?{}".IndexOf(c) > -1)
				{
					return false;
				}
			}
			return true;
		}

		private static bool isValidForStatusDescription(string value)
		{
			foreach (char c in value)
			{
				if (c < ' ')
				{
					return false;
				}
				if (c > '~')
				{
					return false;
				}
			}
			return true;
		}

		public void Abort()
		{
			if (!_disposed)
			{
				close(force: true);
			}
		}

		public void AppendCookie(Cookie cookie)
		{
			Cookies.Add(cookie);
		}

		public void AppendHeader(string name, string value)
		{
			Headers.Add(name, value);
		}

		public void Close()
		{
			if (!_disposed)
			{
				close(force: false);
			}
		}

		public void Close(byte[] responseEntity, bool willBlock)
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(ObjectName);
			}
			if (responseEntity == null)
			{
				throw new ArgumentNullException("responseEntity");
			}
			long num = responseEntity.LongLength;
			if (num > int.MaxValue)
			{
				close(responseEntity, 1024, willBlock);
				return;
			}
			Stream stream = OutputStream;
			if (willBlock)
			{
				stream.Write(responseEntity, 0, (int)num);
				close(force: false);
				return;
			}
			stream.BeginWrite(responseEntity, 0, (int)num, delegate(IAsyncResult ar)
			{
				stream.EndWrite(ar);
				close(force: false);
			}, null);
		}

		public void CopyFrom(HttpListenerResponse templateResponse)
		{
			if (templateResponse == null)
			{
				throw new ArgumentNullException("templateResponse");
			}
			WebHeaderCollection headers = templateResponse._headers;
			if (headers != null)
			{
				if (_headers != null)
				{
					_headers.Clear();
				}
				Headers.Add(headers);
			}
			else
			{
				_headers = null;
			}
			_contentLength = templateResponse._contentLength;
			_statusCode = templateResponse._statusCode;
			_statusDescription = templateResponse._statusDescription;
			_keepAlive = templateResponse._keepAlive;
			_version = templateResponse._version;
		}

		public void Redirect(string url)
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(ObjectName);
			}
			if (_headersSent)
			{
				string message = "The response is already being sent.";
				throw new InvalidOperationException(message);
			}
			if (url == null)
			{
				throw new ArgumentNullException("url");
			}
			if (url.Length == 0)
			{
				throw new ArgumentException("An empty string.", "url");
			}
			if (!Uri.TryCreate(url, UriKind.Absolute, out var result))
			{
				string message2 = "Not an absolute URL.";
				throw new ArgumentException(message2, "url");
			}
			_redirectLocation = result;
			_statusCode = 302;
			_statusDescription = "Found";
		}

		public void SetCookie(Cookie cookie)
		{
			if (cookie == null)
			{
				throw new ArgumentNullException("cookie");
			}
			if (!canSetCookie(cookie))
			{
				string message = "It cannot be updated.";
				throw new ArgumentException(message, "cookie");
			}
			Cookies.Add(cookie);
		}

		public void SetHeader(string name, string value)
		{
			Headers.Set(name, value);
		}

		void IDisposable.Dispose()
		{
			if (!_disposed)
			{
				close(force: true);
			}
		}
	}
}
