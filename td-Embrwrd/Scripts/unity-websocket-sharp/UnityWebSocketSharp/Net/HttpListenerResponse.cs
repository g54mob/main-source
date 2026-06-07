using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	internal sealed class HttpListenerResponse : IDisposable
	{
		[CompilerGenerated]
		private sealed class _003CfindCookie_003Ed__65 : IEnumerable<Cookie>, IEnumerable, IEnumerator<Cookie>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Cookie _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public HttpListenerResponse _003C_003E4__this;

			private Cookie cookie;

			public Cookie _003C_003E3__cookie;

			private IEnumerator<Cookie> _003C_003E7__wrap1;

			Cookie IEnumerator<Cookie>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CfindCookie_003Ed__65(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<Cookie> IEnumerable<Cookie>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private bool _closeConnection;

		private Encoding _contentEncoding;

		private long _contentLength;

		private string _contentType;

		private HttpListenerContext _context;

		private CookieCollection _cookies;

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
				return false;
			}
			set
			{
			}
		}

		internal WebHeaderCollection FullHeaders => null;

		internal bool HeadersSent
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal string StatusLine => null;

		public Encoding ContentEncoding
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public long ContentLength64
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public string ContentType
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CookieCollection Cookies
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public WebHeaderCollection Headers
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool KeepAlive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Stream OutputStream => null;

		public Version ProtocolVersion => null;

		public string RedirectLocation
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool SendChunked
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int StatusCode
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public string StatusDescription
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal HttpListenerResponse(HttpListenerContext context)
		{
		}

		private bool canSetCookie(Cookie cookie)
		{
			return false;
		}

		private void close(bool force)
		{
		}

		private void close(byte[] responseEntity, int bufferLength, bool willBlock)
		{
		}

		private static string createContentTypeHeaderText(string value, Encoding encoding)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CfindCookie_003Ed__65))]
		private IEnumerable<Cookie> findCookie(Cookie cookie)
		{
			return null;
		}

		private static bool isValidForContentType(string value)
		{
			return false;
		}

		private static bool isValidForStatusDescription(string value)
		{
			return false;
		}

		public void Abort()
		{
		}

		public void AppendCookie(Cookie cookie)
		{
		}

		public void AppendHeader(string name, string value)
		{
		}

		public void Close()
		{
		}

		public void Close(byte[] responseEntity, bool willBlock)
		{
		}

		public void CopyFrom(HttpListenerResponse templateResponse)
		{
		}

		public void Redirect(string url)
		{
		}

		public void SetCookie(Cookie cookie)
		{
		}

		public void SetHeader(string name, string value)
		{
		}

		void IDisposable.Dispose()
		{
		}
	}
}
