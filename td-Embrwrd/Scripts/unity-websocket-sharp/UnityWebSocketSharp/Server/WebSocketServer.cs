using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Threading;
using UnityWebSocketSharp.Net;
using UnityWebSocketSharp.Net.WebSockets;

namespace UnityWebSocketSharp.Server
{
	internal class WebSocketServer
	{
		private IPAddress _address;

		private UnityWebSocketSharp.Net.AuthenticationSchemes _authSchemes;

		private static readonly string _defaultRealm;

		private bool _dnsStyle;

		private string _hostname;

		private TcpListener _listener;

		private Logger _log;

		private int _port;

		private string _realm;

		private string _realmInUse;

		private Thread _receiveThread;

		private bool _reuseAddress;

		private bool _secure;

		private WebSocketServiceManager _services;

		private ServerSslConfiguration _sslConfig;

		private ServerSslConfiguration _sslConfigInUse;

		private ServerState _state;

		private object _sync;

		private Func<IIdentity, UnityWebSocketSharp.Net.NetworkCredential> _userCredFinder;

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

		static WebSocketServer()
		{
		}

		public WebSocketServer()
		{
		}

		public WebSocketServer(int port)
		{
		}

		public WebSocketServer(string url)
		{
		}

		public WebSocketServer(int port, bool secure)
		{
		}

		public WebSocketServer(IPAddress address, int port)
		{
		}

		public WebSocketServer(IPAddress address, int port, bool secure)
		{
		}

		private void abort()
		{
		}

		private bool authenticateClient(TcpListenerWebSocketContext context)
		{
			return false;
		}

		private bool canSet()
		{
			return false;
		}

		private bool checkHostNameForRequest(string name)
		{
			return false;
		}

		private string getRealm()
		{
			return null;
		}

		private ServerSslConfiguration getSslConfiguration()
		{
			return null;
		}

		private void init(string hostname, IPAddress address, int port, bool secure)
		{
		}

		private void processRequest(TcpListenerWebSocketContext context)
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
