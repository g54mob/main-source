using System;
using System.Collections.Generic;

namespace UnityWebSocketSharp.Server
{
	internal class WebSocketServiceManager
	{
		private Dictionary<string, WebSocketServiceHost> _hosts;

		private bool _keepClean;

		private Logger _log;

		private ServerState _state;

		private object _sync;

		private TimeSpan _waitTime;

		public int Count => 0;

		public IEnumerable<WebSocketServiceHost> Hosts => null;

		public WebSocketServiceHost this[string path] => null;

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

		public IEnumerable<string> Paths => null;

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

		internal WebSocketServiceManager(Logger log)
		{
		}

		private bool canSet()
		{
			return false;
		}

		internal bool InternalTryGetServiceHost(string path, out WebSocketServiceHost host)
		{
			host = null;
			return false;
		}

		internal void Start()
		{
		}

		internal void Stop(ushort code, string reason)
		{
		}

		public void AddService<TBehavior>(string path, Action<TBehavior> initializer) where TBehavior : WebSocketBehavior, new()
		{
		}

		public void Clear()
		{
		}

		public bool RemoveService(string path)
		{
			return false;
		}

		public bool TryGetServiceHost(string path, out WebSocketServiceHost host)
		{
			host = null;
			return false;
		}
	}
}
