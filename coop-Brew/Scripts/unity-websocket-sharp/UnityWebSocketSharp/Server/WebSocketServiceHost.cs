using System;
using UnityWebSocketSharp.Net.WebSockets;

namespace UnityWebSocketSharp.Server
{
	internal abstract class WebSocketServiceHost
	{
		private Logger _log;

		private string _path;

		private WebSocketSessionManager _sessions;

		internal ServerState State => default(ServerState);

		protected Logger Log => null;

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

		public string Path => null;

		public WebSocketSessionManager Sessions => null;

		public abstract Type BehaviorType { get; }

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

		protected WebSocketServiceHost(string path, Logger log)
		{
		}

		internal void Start()
		{
		}

		internal void StartSession(WebSocketContext context)
		{
		}

		internal void Stop(ushort code, string reason)
		{
		}

		protected abstract WebSocketBehavior CreateSession();
	}
	internal class WebSocketServiceHost<TBehavior> : WebSocketServiceHost where TBehavior : WebSocketBehavior, new()
	{
		private Func<TBehavior> _creator;

		public override Type BehaviorType => null;

		internal WebSocketServiceHost(string path, Action<TBehavior> initializer, Logger log)
			: base(null, null)
		{
		}

		private static Func<TBehavior> createSessionCreator(Action<TBehavior> initializer)
		{
			return null;
		}

		protected override WebSocketBehavior CreateSession()
		{
			return null;
		}
	}
}
