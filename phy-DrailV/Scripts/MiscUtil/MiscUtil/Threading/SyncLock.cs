using System;
using System.Threading;

namespace MiscUtil.Threading
{
	public class SyncLock
	{
		private static object staticLock = new object();

		private static int defaultDefaultTimeout = -1;

		private int defaultTimeout;

		private string name;

		private object monitor = new object();

		private static int DefaultDefaultTimeout
		{
			get
			{
				lock (staticLock)
				{
					return defaultDefaultTimeout;
				}
			}
			set
			{
				if (value < -1)
				{
					throw new ArgumentOutOfRangeException("Invalid timeout specified");
				}
				lock (staticLock)
				{
					defaultDefaultTimeout = value;
				}
			}
		}

		public int DefaultTimeout => defaultTimeout;

		public string Name => name;

		public object Monitor => monitor;

		public SyncLock()
			: this(null, DefaultDefaultTimeout)
		{
		}

		public SyncLock(string name)
			: this(name, DefaultDefaultTimeout)
		{
		}

		public SyncLock(int defaultTimeout)
			: this(null, defaultTimeout)
		{
		}

		public SyncLock(string name, int defaultTimeout)
		{
			if (defaultTimeout < -1)
			{
				throw new ArgumentOutOfRangeException("Invalid timeout specified");
			}
			if (name == null)
			{
				name = "Anonymous Lock";
			}
			this.name = name;
			this.defaultTimeout = defaultTimeout;
		}

		public LockToken Lock()
		{
			return Lock(defaultTimeout);
		}

		public LockToken Lock(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num < -1 || num > int.MaxValue)
			{
				throw new ArgumentOutOfRangeException("Invalid timeout specified");
			}
			return Lock((int)num);
		}

		public virtual LockToken Lock(int timeout)
		{
			if (timeout < -1)
			{
				throw new ArgumentOutOfRangeException("Invalid timeout specified");
			}
			if (!System.Threading.Monitor.TryEnter(monitor, timeout))
			{
				throw new LockTimeoutException("Failed to acquire lock {0}", name);
			}
			return new LockToken(this);
		}

		protected internal virtual void Unlock()
		{
			System.Threading.Monitor.Exit(monitor);
		}
	}
}
