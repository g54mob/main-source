using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security.Principal;
using UnityWebSocketSharp.Net;
using UnityWebSocketSharp.Net.WebSockets;

namespace UnityWebSocketSharp.Server
{
	internal abstract class WebSocketBehavior : IWebSocketSession
	{
		private WebSocketContext _context;

		private Func<UnityWebSocketSharp.Net.CookieCollection, UnityWebSocketSharp.Net.CookieCollection, bool> _cookiesValidator;

		private bool _emitOnPing;

		private Func<string, bool> _hostValidator;

		private string _id;

		private bool _ignoreExtensions;

		private Func<string, bool> _originValidator;

		private string _protocol;

		private WebSocketSessionManager _sessions;

		private DateTime _startTime;

		private WebSocket _websocket;

		protected NameValueCollection Headers => null;

		protected bool IsAlive => false;

		protected NameValueCollection QueryString => null;

		protected WebSocketState ReadyState => default(WebSocketState);

		protected WebSocketSessionManager Sessions => null;

		protected IPrincipal User => null;

		protected IPEndPoint UserEndPoint => null;

		public Func<UnityWebSocketSharp.Net.CookieCollection, UnityWebSocketSharp.Net.CookieCollection, bool> CookiesValidator
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

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

		public Func<string, bool> HostValidator
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string ID => null;

		public bool IgnoreExtensions
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Func<string, bool> OriginValidator
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
			set
			{
			}
		}

		public DateTime StartTime => default(DateTime);

		WebSocket IWebSocketSession.WebSocket => null;

		private string checkHandshakeRequest(WebSocketContext context)
		{
			return null;
		}

		private void onClose(object sender, CloseEventArgs e)
		{
		}

		private void onError(object sender, ErrorEventArgs e)
		{
		}

		private void onMessage(object sender, MessageEventArgs e)
		{
		}

		private void onOpen(object sender, EventArgs e)
		{
		}

		internal void Start(WebSocketContext context, WebSocketSessionManager sessions)
		{
		}

		protected void Close()
		{
		}

		protected void Close(ushort code, string reason)
		{
		}

		protected void Close(CloseStatusCode code, string reason)
		{
		}

		protected void CloseAsync()
		{
		}

		protected void CloseAsync(ushort code, string reason)
		{
		}

		protected void CloseAsync(CloseStatusCode code, string reason)
		{
		}

		protected virtual void OnClose(CloseEventArgs e)
		{
		}

		protected virtual void OnError(ErrorEventArgs e)
		{
		}

		protected virtual void OnMessage(MessageEventArgs e)
		{
		}

		protected virtual void OnOpen()
		{
		}

		protected bool Ping()
		{
			return false;
		}

		protected bool Ping(string message)
		{
			return false;
		}

		protected void Send(byte[] data)
		{
		}

		protected void Send(FileInfo fileInfo)
		{
		}

		protected void Send(string data)
		{
		}

		protected void Send(Stream stream, int length)
		{
		}

		protected void SendAsync(byte[] data, Action<bool> completed)
		{
		}

		protected void SendAsync(FileInfo fileInfo, Action<bool> completed)
		{
		}

		protected void SendAsync(string data, Action<bool> completed)
		{
		}

		protected void SendAsync(Stream stream, int length, Action<bool> completed)
		{
		}
	}
}
