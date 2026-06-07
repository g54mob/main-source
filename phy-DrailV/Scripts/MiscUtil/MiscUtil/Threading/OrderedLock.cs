using System.Threading;

namespace MiscUtil.Threading
{
	public class OrderedLock : SyncLock
	{
		private int count;

		private volatile Thread owner;

		private volatile OrderedLock innerLock;

		public Thread Owner => owner;

		public OrderedLock InnerLock
		{
			get
			{
				return innerLock;
			}
			set
			{
				innerLock = value;
			}
		}

		public OrderedLock()
		{
		}

		public OrderedLock(string name)
			: base(name)
		{
		}

		public OrderedLock(int defaultTimeout)
			: base(defaultTimeout)
		{
		}

		public OrderedLock(string name, int defaultTimeout)
			: base(name, defaultTimeout)
		{
		}

		public OrderedLock SetInnerLock(OrderedLock inner)
		{
			InnerLock = inner;
			return this;
		}

		public override LockToken Lock(int timeout)
		{
			OrderedLock orderedLock = InnerLock;
			if (orderedLock != null)
			{
				Thread currentThread = Thread.CurrentThread;
				if (Owner != currentThread)
				{
					while (orderedLock != null)
					{
						if (orderedLock.Owner == currentThread)
						{
							throw new LockOrderException("Unable to acquire lock {0} as lock {1} is already held", base.Name, orderedLock.Name);
						}
						orderedLock = orderedLock.InnerLock;
					}
				}
			}
			LockToken result = base.Lock(timeout);
			if (Interlocked.Increment(ref count) == 1)
			{
				owner = Thread.CurrentThread;
			}
			return result;
		}

		protected internal override void Unlock()
		{
			base.Unlock();
			if (Interlocked.Decrement(ref count) == 0)
			{
				owner = null;
			}
		}
	}
}
