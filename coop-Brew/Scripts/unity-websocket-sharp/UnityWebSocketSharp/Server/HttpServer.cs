using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Threading;
using UnityWebSocketSharp.Net;
using UnityWebSocketSharp.Net.WebSockets;

namespace UnityWebSocketSharp.Server
{
	internal class HttpServer
	{
		private IPAddress _address;

		private string _docRootPath;

		private string _hostname;

		private UnityWebSocketSharp.Net.HttpListener _listener;

		private Logger _log;

		private int _port;

		private Thread _receiveThread;

		private bool _secure;

		private WebSocketServiceManager _services;

		private ServerState _state;

		private object _sync;

		public IPAddress Address => null;

		public UnityWebSocketSharp.Net.AuthenticationSchemes AuthenticationSchemes
		{
			get
			{
				return default(UnityWebSocketSharp.Net.AuthenticationSchemes);
			}
			set
			{
			}
		}

		public string DocumentRootPath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsListening => false;

		public bool IsSecure => false;

		public bool KeepClean
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Logger Log => null;

		public int Port => 0;

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

		public bool ReuseAddress
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ServerSslConfiguration SslConfiguration => null;

		public Func<IIdentity, UnityWebSocketSharp.Net.NetworkCredential> UserCredentialsFinder
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public TimeSpan WaitTime
		{
			get
			{
				return default(TimeSpan);
			}
			set
			{
			}
		}

		public WebSocketServiceManager WebSocketServices => null;

		public event EventHandler<HttpRequestEventArgs> OnConnect
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<HttpRequestEventArgs> OnDelete
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<HttpRequestEventArgs> OnGet
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<HttpRequestEventArgs> OnHead
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<HttpRequestEventArgs> OnOptions
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<HttpRequestEventArgs> OnPost
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<HttpRequestEventArgs> OnPut
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler<HttpRequestEventArgs> OnTrace
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public HttpServer()
		{
		}

		public HttpServer(int port)
		{
		}

		public HttpServer(string url)
		{
		}

		public HttpServer(int port, bool secure)
		{
		}

		public HttpServer(IPAddress address, int port)
		{
		}

		public HttpServer(IPAddress address, int port, bool secure)
		{
		}

		private void abort()
		{
		}

		private bool canSet()
		{
			return false;
		}

		private bool checkCertificate(out string message)
		{
			message = null;
			return false;
		}

		private static UnityWebSocketSharp.Net.HttpListener createListener(string hostname, int port, bool secure)
		{
			return null;
		}

		private void init(string hostname, IPAddress address, int port, bool secure)
		{
		}

		private void processRequest(UnityWebSocketSharp.Net.HttpListenerContext context)
		{
		}

		private void processRequest(HttpListenerWebSocketContext context)
		{
		}

		private void receiveRequest()
		{
		}

		private void start()
		{
		}

		private void startReceiving()
		{
		}

		private void stop(ushort code, string reason)
		{
		}

		private void stopReceiving(int millisecondsTimeout)
		{
		}

		private static bool tryCreateUri(string uriString, out Uri result, out string message)
		{
			result = null;
			message = null;
			return false;
		}

		public void AddWebSocketService<TBehavior>(string path) where TBehavior : WebSocketBehavior, new()
		{
		}

		public void AddWebSocketService<TBehavior>(string path, Action<TBehavior> initializer) where TBehavior : WebSocketBehavior, new()
		{
		}

		public bool RemoveWebSocketService(string path)
		{
			return false;
		}

		public void Start()
		{
		}

		public void Stop()
		{
		}
	}
}
