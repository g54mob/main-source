using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace UnityWebSocketSharp.Net
{
	internal sealed class HttpListener : IDisposable
	{
		private AuthenticationSchemes _authSchemes;

		private Func<HttpListenerRequest, AuthenticationSchemes> _authSchemeSelector;

		private string _certFolderPath;

		private Queue<HttpListenerContext> _contextQueue;

		private LinkedList<HttpListenerContext> _contextRegistry;

		private object _contextRegistrySync;

		private static readonly string _defaultRealm;

		private bool _disposed;

		private bool _ignoreWriteExceptions;

		private bool _listening;

		private Logger _log;

		private string _objectName;

		private HttpListenerPrefixCollection _prefixes;

		private string _realm;

		private bool _reuseAddress;

		private ServerSslConfiguration _sslConfig;

		private object _sync;

		private Func<IIdentity, NetworkCredential> _userCredFinder;

		private Queue<HttpListenerAsyncResult> _waitQueue;

		internal bool ReuseAddress
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public AuthenticationSchemes AuthenticationSchemes
		{
			get
			{
				return default(AuthenticationSchemes);
			}
			set
			{
			}
		}

		public Func<HttpListenerRequest, AuthenticationSchemes> AuthenticationSchemeSelector
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string CertificateFolderPath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IgnoreWriteExceptions
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsListening => false;

		public static bool IsSupported => false;

		public Logger Log => null;

		public HttpListenerPrefixCollection Prefixes => null;

		public string Realm
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ServerSslConfiguration SslConfiguration => null;

		public bool UnsafeConnectionNtlmAuthentication
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Func<IIdentity, NetworkCredential> UserCredentialsFinder
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		static HttpListener()
		{
		}

		private bool authenticateClient(HttpListenerContext context)
		{
			return false;
		}

		private HttpListenerAsyncResult beginGetContext(AsyncCallback callback, object state)
		{
			return null;
		}

		private void cleanupContextQueue(bool force)
		{
		}

		private void cleanupContextRegistry()
		{
		}

		private void cleanupWaitQueue(string message)
		{
		}

		private void close(bool force)
		{
		}

		private string getRealm()
		{
			return null;
		}

		private bool registerContext(HttpListenerContext context)
		{
			return false;
		}

		private AuthenticationSchemes selectAuthenticationScheme(HttpListenerRequest request)
		{
			return default(AuthenticationSchemes);
		}

		internal void CheckDisposed()
		{
		}

		internal bool RegisterContext(HttpListenerContext context)
		{
			return false;
		}

		internal void UnregisterContext(HttpListenerContext context)
		{
		}

		public void Abort()
		{
		}

		public IAsyncResult BeginGetContext(AsyncCallback callback, object state)
		{
			return null;
		}

		public void Close()
		{
		}

		public HttpListenerContext EndGetContext(IAsyncResult asyncResult)
		{
			return null;
		}

		public HttpListenerContext GetContext()
		{
			return null;
		}

		public void Start()
		{
		}

		public void Stop()
		{
		}

		void IDisposable.Dispose()
		{
		}
	}
}
