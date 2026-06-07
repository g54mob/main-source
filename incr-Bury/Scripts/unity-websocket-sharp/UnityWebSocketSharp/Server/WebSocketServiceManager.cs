using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityWebSocketSharp.Server
{
	internal class WebSocketServiceManager
	{
		private Dictionary<string, WebSocketServiceHost> _hosts;

		private volatile bool _keepClean;

		private Logger _log;

		private volatile ServerState _state;

		private object _sync;

		private TimeSpan _waitTime;

		public int Count
		{
			get
			{
				lock (_sync)
				{
					return _hosts.Count;
				}
			}
		}

		public IEnumerable<WebSocketServiceHost> Hosts
		{
			get
			{
				lock (_sync)
				{
					return _hosts.Values.ToList();
				}
			}
		}

		public WebSocketServiceHost this[string path]
		{
			get
			{
				if (path == null)
				{
					throw new ArgumentNullException("path");
				}
				if (path.Length == 0)
				{
					throw new ArgumentException("An empty string.", "path");
				}
				if (path[0] != '/')
				{
					throw new ArgumentException("Not an absolute path.", "path");
				}
				if (path.IndexOfAny(new char[2] { '?', '#' }) > -1)
				{
					throw new ArgumentException("It includes either or both query and fragment components.", "path");
				}
				InternalTryGetServiceHost(path, out var host);
				return host;
			}
		}

		public bool KeepClean
		{
			get
			{
				return _keepClean;
			}
			set
			{
				lock (_sync)
				{
					if (!canSet())
					{
						return;
					}
					foreach (WebSocketServiceHost value2 in _hosts.Values)
					{
						value2.KeepClean = value;
					}
					_keepClean = value;
				}
			}
		}

		public IEnumerable<string> Paths
		{
			get
			{
				lock (_sync)
				{
					return _hosts.Keys.ToList();
				}
			}
		}

		public TimeSpan WaitTime
		{
			get
			{
				return _waitTime;
			}
			set
			{
				if (value <= TimeSpan.Zero)
				{
					string message = "Zero or less.";
					throw new ArgumentOutOfRangeException("value", message);
				}
				lock (_sync)
				{
					if (!canSet())
					{
						return;
					}
					foreach (WebSocketServiceHost value2 in _hosts.Values)
					{
						value2.WaitTime = value;
					}
					_waitTime = value;
				}
			}
		}

		internal WebSocketServiceManager(Logger log)
		{
			_log = log;
			_hosts = new Dictionary<string, WebSocketServiceHost>();
			_keepClean = true;
			_state = ServerState.Ready;
			_sync = ((ICollection)_hosts).SyncRoot;
			_waitTime = TimeSpan.FromSeconds(1.0);
		}

		private bool canSet()
		{
			if (_state != ServerState.Ready)
			{
				return _state == ServerState.Stop;
			}
			return true;
		}

		internal bool InternalTryGetServiceHost(string path, out WebSocketServiceHost host)
		{
			path = path.TrimSlashFromEnd();
			lock (_sync)
			{
				return _hosts.TryGetValue(path, out host);
			}
		}

		internal void Start()
		{
			lock (_sync)
			{
				foreach (WebSocketServiceHost value in _hosts.Values)
				{
					value.Start();
				}
				_state = ServerState.Start;
			}
		}

		internal void Stop(ushort code, string reason)
		{
			lock (_sync)
			{
				_state = ServerState.ShuttingDown;
				foreach (WebSocketServiceHost value in _hosts.Values)
				{
					value.Stop(code, reason);
				}
				_state = ServerState.Stop;
			}
		}

		public void AddService<TBehavior>(string path, Action<TBehavior> initializer) where TBehavior : WebSocketBehavior, new()
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			if (path[0] != '/')
			{
				throw new ArgumentException("Not an absolute path.", "path");
			}
			if (path.IndexOfAny(new char[2] { '?', '#' }) > -1)
			{
				throw new ArgumentException("It includes either or both query and fragment components.", "path");
			}
			path = path.TrimSlashFromEnd();
			lock (_sync)
			{
				if (_hosts.TryGetValue(path, out var value))
				{
					throw new ArgumentException("It is already in use.", "path");
				}
				value = new WebSocketServiceHost<TBehavior>(path, initializer, _log);
				if (!_keepClean)
				{
					value.KeepClean = false;
				}
				if (_waitTime != value.WaitTime)
				{
					value.WaitTime = _waitTime;
				}
				if (_state == ServerState.Start)
				{
					value.Start();
				}
				_hosts.Add(path, value);
			}
		}

		public void Clear()
		{
			List<WebSocketServiceHost> list = null;
			lock (_sync)
			{
				list = _hosts.Values.ToList();
				_hosts.Clear();
			}
			foreach (WebSocketServiceHost item in list)
			{
				if (item.State == ServerState.Start)
				{
					item.Stop(1001, string.Empty);
				}
			}
		}

		public bool RemoveService(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			if (path[0] != '/')
			{
				throw new ArgumentException("Not an absolute path.", "path");
			}
			if (path.IndexOfAny(new char[2] { '?', '#' }) > -1)
			{
				throw new ArgumentException("It includes either or both query and fragment components.", "path");
			}
			path = path.TrimSlashFromEnd();
			WebSocketServiceHost value;
			lock (_sync)
			{
				if (!_hosts.TryGetValue(path, out value))
				{
					return false;
				}
				_hosts.Remove(path);
			}
			if (value.State == ServerState.Start)
			{
				value.Stop(1001, string.Empty);
			}
			return true;
		}

		public bool TryGetServiceHost(string path, out WebSocketServiceHost host)
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				throw new ArgumentException("An empty string.", "path");
			}
			if (path[0] != '/')
			{
				throw new ArgumentException("Not an absolute path.", "path");
			}
			if (path.IndexOfAny(new char[2] { '?', '#' }) > -1)
			{
				throw new ArgumentException("It includes either or both query and fragment components.", "path");
			}
			return InternalTryGetServiceHost(path, out host);
		}
	}
}
