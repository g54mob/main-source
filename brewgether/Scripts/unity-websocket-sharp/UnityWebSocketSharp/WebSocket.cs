using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using UnityWebSocketSharp.Net;
using UnityWebSocketSharp.Net.WebSockets;

namespace UnityWebSocketSharp
{
	internal class WebSocket : IDisposable
	{
		[CompilerGenerated]
		private sealed class _003Cget_Cookies_003Ed__69 : IEnumerable<Cookie>, IEnumerable, IEnumerator<Cookie>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Cookie _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public WebSocket _003C_003E4__this;

			private object _003C_003E7__wrap1;

			private bool _003C_003E7__wrap2;

			private IEnumerator<Cookie> _003C_003E7__wrap3;

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
			public _003Cget_Cookies_003Ed__69(int _003C_003E1__state)
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

			private void _003C_003Em__Finally2()
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

		private AuthenticationChallenge _authChallenge;

		private string _base64Key;

		private bool _client;

		private Action _closeContext;

		private CompressionMethod _compression;

		private WebSocketContext _context;

		private CookieCollection _cookies;

		private NetworkCredential _credentials;

		private bool _emitOnPing;

		private bool _enableRedirection;

		private string _extensions;

		private bool _extensionsRequested;

		private object _forMessageEventQueue;

		private object _forPing;

		private object _forSend;

		private object _forState;

		private MemoryStream _fragmentsBuffer;

		private bool _fragmentsCompressed;

		private Opcode _fragmentsOpcode;

		private const string _guid = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";

		private Func<WebSocketContext, string> _handshakeRequestChecker;

		private bool _ignoreExtensions;

		private bool _inContinuation;

		private bool _inMessage;

		private Logger _log;

		private static readonly int _maxRetryCountForConnect;

		private Action<MessageEventArgs> _message;

		private Queue<MessageEventArgs> _messageEventQueue;

		private uint _nonceCount;

		private string _origin;

		private ManualResetEvent _pongReceived;

		private bool _preAuth;

		private string _protocol;

		private string[] _protocols;

		private bool _protocolsRequested;

		private NetworkCredential _proxyCredentials;

		private Uri _proxyUri;

		private WebSocketState _readyState;

		private ManualResetEvent _receivingExited;

		private int _retryCountForConnect;

		private bool _secure;

		private ClientSslConfiguration _sslConfig;

		private Stream _stream;

		private Uri _uri;

		private const string _version = "13";

		private TimeSpan _waitTime;

		internal static readonly byte[] EmptyBytes;

		internal static readonly int FragmentLength;

		internal static readonly RandomNumberGenerator RandomNumber;

		internal CookieCollection CookieCollection => null;

		internal Func<WebSocketContext, string> CustomHandshakeRequestChecker
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal Func<string, int, Stream> GetNetworkStream { get; set; }

		internal bool IgnoreExtensions
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public CompressionMethod Compression
		{
			get
			{
				return default(CompressionMethod);
			}
			set
			{
			}
		}

		public IEnumerable<Cookie> Cookies
		{
			[IteratorStateMachine(typeof(_003Cget_Cookies_003Ed__69))]
			get
			{
				return null;
			}
		}

		public NetworkCredential Credentials => null;

		public bool EmitOnPing
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool EnableRedirection
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string Extensions => null;

		public bool IsAlive => false;

		public bool IsSecure => false;

		public Logger Log
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string Origin
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Protocol
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public WebSocketState ReadyState => default(WebSocketState);

		public ClientSslConfiguration SslConfiguration => null;

		public Uri Url => null;

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

		public event EventHandler<CloseEventArgs> OnClose
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

		public event EventHandler<ErrorEventArgs> OnError
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

		public event EventHandler<MessageEventArgs> OnMessage
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

		public event EventHandler OnOpen
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

		static WebSocket()
		{
		}

		internal WebSocket(HttpListenerWebSocketContext context, string protocol)
		{
		}

		internal WebSocket(TcpListenerWebSocketContext context, string protocol)
		{
		}

		public WebSocket(string url, params string[] protocols)
		{
		}

		private void abort(string reason, Exception exception)
		{
		}

		private void abort(ushort code, string reason)
		{
		}

		private bool accept()
		{
			return false;
		}

		private bool acceptHandshake()
		{
			return false;
		}

		private bool canSet()
		{
			return false;
		}

		private bool checkHandshakeRequest(WebSocketContext context, out string message)
		{
			message = null;
			return false;
		}

		private bool checkHandshakeResponse(HttpResponse response, out string message)
		{
			message = null;
			return false;
		}

		private static bool checkProtocols(string[] protocols, out string message)
		{
			message = null;
			return false;
		}

		private bool checkProxyConnectResponse(HttpResponse response, out string message)
		{
			message = null;
			return false;
		}

		private bool checkReceivedFrame(WebSocketFrame frame, out string message)
		{
			message = null;
			return false;
		}

		private void close(ushort code, string reason)
		{
		}

		private void close(PayloadData payloadData, bool send, bool received)
		{
		}

		private void closeAsync(ushort code, string reason)
		{
		}

		private void closeAsync(PayloadData payloadData, bool send, bool received)
		{
		}

		private bool closeHandshake(PayloadData payloadData, bool send, bool received)
		{
			return false;
		}

		private bool connect()
		{
			return false;
		}

		private AuthenticationResponse createAuthenticationResponse()
		{
			return null;
		}

		private string createExtensions()
		{
			return null;
		}

		private HttpResponse createHandshakeFailureResponse()
		{
			return null;
		}

		private HttpRequest createHandshakeRequest()
		{
			return null;
		}

		private HttpResponse createHandshakeResponse()
		{
			return null;
		}

		private bool customCheckHandshakeRequest(WebSocketContext context, out string message)
		{
			message = null;
			return false;
		}

		private MessageEventArgs dequeueFromMessageEventQueue()
		{
			return null;
		}

		private bool doHandshake()
		{
			return false;
		}

		private void enqueueToMessageEventQueue(MessageEventArgs e)
		{
		}

		private void error(string message, Exception exception)
		{
		}

		private ClientSslConfiguration getSslConfiguration()
		{
			return null;
		}

		private void init()
		{
		}

		private void message()
		{
		}

		private void messagec(MessageEventArgs e)
		{
		}

		private void messages(MessageEventArgs e)
		{
		}

		private void open()
		{
		}

		private bool ping(byte[] data)
		{
			return false;
		}

		private bool processCloseFrame(WebSocketFrame frame)
		{
			return false;
		}

		private bool processDataFrame(WebSocketFrame frame)
		{
			return false;
		}

		private bool processFragmentFrame(WebSocketFrame frame)
		{
			return false;
		}

		private bool processPingFrame(WebSocketFrame frame)
		{
			return false;
		}

		private bool processPongFrame(WebSocketFrame frame)
		{
			return false;
		}

		private bool processReceivedFrame(WebSocketFrame frame)
		{
			return false;
		}

		private void processSecWebSocketExtensionsClientHeader(string value)
		{
		}

		private bool processUnsupportedFrame(WebSocketFrame frame)
		{
			return false;
		}

		private void refuseHandshake(ushort code, string reason)
		{
		}

		private void releaseClientResources()
		{
		}

		private void releaseCommonResources()
		{
		}

		private void releaseResources()
		{
		}

		private void releaseServerResources()
		{
		}

		private bool send(byte[] rawFrame)
		{
			return false;
		}

		private bool send(Opcode opcode, Stream sourceStream)
		{
			return false;
		}

		private bool send(Opcode opcode, Stream dataStream, bool compressed)
		{
			return false;
		}

		private bool send(Fin fin, Opcode opcode, byte[] data, bool compressed)
		{
			return false;
		}

		private void sendAsync(Opcode opcode, Stream sourceStream, Action<bool> completed)
		{
		}

		private bool sendBytes(byte[] bytes)
		{
			return false;
		}

		private HttpResponse sendHandshakeRequest()
		{
			return null;
		}

		private HttpResponse sendProxyConnectRequest()
		{
			return null;
		}

		private void setClientStream()
		{
		}

		private void startReceiving()
		{
		}

		private bool validateSecWebSocketExtensionsServerHeader(string value)
		{
			return false;
		}

		internal void Accept()
		{
		}

		internal void AcceptAsync()
		{
		}

		internal void Close(PayloadData payloadData, byte[] rawFrame)
		{
		}

		internal static string CreateBase64Key()
		{
			return null;
		}

		internal static string CreateResponseKey(string base64Key)
		{
			return null;
		}

		internal bool Ping(byte[] rawFrame)
		{
			return false;
		}

		internal void Send(Opcode opcode, byte[] data, Dictionary<CompressionMethod, byte[]> cache)
		{
		}

		internal void Send(Opcode opcode, Stream sourceStream, Dictionary<CompressionMethod, Stream> cache)
		{
		}

		public void Close()
		{
		}

		public void Close(ushort code)
		{
		}

		public void Close(CloseStatusCode code)
		{
		}

		public void Close(ushort code, string reason)
		{
		}

		public void Close(CloseStatusCode code, string reason)
		{
		}

		public void CloseAsync()
		{
		}

		public void CloseAsync(ushort code)
		{
		}

		public void CloseAsync(CloseStatusCode code)
		{
		}

		public void CloseAsync(ushort code, string reason)
		{
		}

		public void CloseAsync(CloseStatusCode code, string reason)
		{
		}

		public void Connect()
		{
		}

		public void ConnectAsync()
		{
		}

		public bool Ping()
		{
			return false;
		}

		public bool Ping(string message)
		{
			return false;
		}

		public void Send(byte[] data)
		{
		}

		public void Send(FileInfo fileInfo)
		{
		}

		public void Send(string data)
		{
		}

		public void Send(Stream stream, int length)
		{
		}

		public void SendAsync(byte[] data, Action<bool> completed)
		{
		}

		public void SendAsync(FileInfo fileInfo, Action<bool> completed)
		{
		}

		public void SendAsync(string data, Action<bool> completed)
		{
		}

		public void SendAsync(Stream stream, int length, Action<bool> completed)
		{
		}

		public void SetCookie(Cookie cookie)
		{
		}

		public void SetCredentials(string username, string password, bool preAuth)
		{
		}

		public void SetProxy(string url, string username, string password)
		{
		}

		void IDisposable.Dispose()
		{
		}
	}
}
