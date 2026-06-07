using System;
using System.Threading;
using Pathfinding.Util;

namespace Pathfinding
{
	internal class BlockableChannel<T> where T : class
	{
		public enum PopState
		{
			Ok = 0,
			Wait = 1,
			Closed = 2
		}

		public struct Receiver
		{
			private BlockableChannel<T> channel;

			public Receiver(BlockableChannel<T> channel)
			{
				this.channel = channel;
			}

			public void Close()
			{
				lock (channel.lockObj)
				{
					channel.numReceivers--;
				}
				channel = null;
			}

			public PopState Receive(out T item)
			{
				Interlocked.Increment(ref channel.waitingReceivers);
				while (true)
				{
					channel.starving.WaitOne();
					lock (channel.lockObj)
					{
						if (channel.isClosed)
						{
							Interlocked.Decrement(ref channel.waitingReceivers);
							item = null;
							return PopState.Closed;
						}
						if (channel.queue.Length == 0)
						{
							channel.isStarving = true;
						}
						if (channel.isStarving)
						{
							continue;
						}
						Interlocked.Decrement(ref channel.waitingReceivers);
						item = channel.queue.PopStart();
						return PopState.Ok;
					}
				}
			}

			public PopState ReceiveNoBlock(bool blockedBefore, out T item)
			{
				item = null;
				if (!blockedBefore)
				{
					Interlocked.Increment(ref channel.waitingReceivers);
				}
				while (!channel.isStarving)
				{
					lock (channel.lockObj)
					{
						if (channel.isClosed)
						{
							Interlocked.Decrement(ref channel.waitingReceivers);
							return PopState.Closed;
						}
						if (channel.queue.Length == 0)
						{
							channel.isStarving = true;
						}
						if (channel.isStarving)
						{
							continue;
						}
						Interlocked.Decrement(ref channel.waitingReceivers);
						item = channel.queue.PopStart();
						return PopState.Ok;
					}
				}
				return PopState.Wait;
			}
		}

		private readonly object lockObj = new object();

		private CircularBuffer<T> queue = new CircularBuffer<T>(16);

		private volatile int waitingReceivers;

		private ManualResetEvent starving = new ManualResetEvent(initialState: false);

		private bool blocked;

		public int numReceivers { get; private set; }

		public bool isClosed { get; private set; }

		public bool isEmpty
		{
			get
			{
				lock (lockObj)
				{
					return queue.Length == 0;
				}
			}
		}

		public bool allReceiversBlocked
		{
			get
			{
				if (blocked)
				{
					return waitingReceivers == numReceivers;
				}
				return false;
			}
		}

		public bool isBlocked
		{
			get
			{
				return blocked;
			}
			set
			{
				lock (lockObj)
				{
					blocked = value;
					if (!isClosed)
					{
						isStarving = value || queue.Length == 0;
					}
				}
			}
		}

		private bool isStarving
		{
			get
			{
				return !starving.WaitOne(0);
			}
			set
			{
				if (value)
				{
					starving.Reset();
				}
				else
				{
					starving.Set();
				}
			}
		}

		public void Close()
		{
			lock (lockObj)
			{
				isClosed = true;
				isStarving = false;
			}
		}

		public void Reopen()
		{
			lock (lockObj)
			{
				if (numReceivers != 0)
				{
					throw new InvalidOperationException("Can only reopen a channel after Close has been called on all receivers");
				}
				isClosed = false;
				isBlocked = false;
			}
		}

		public Receiver AddReceiver()
		{
			lock (lockObj)
			{
				if (isClosed)
				{
					throw new InvalidOperationException("Channel is closed");
				}
				numReceivers++;
				return new Receiver(this);
			}
		}

		public void PushFront(T path)
		{
			lock (lockObj)
			{
				if (isClosed)
				{
					throw new InvalidOperationException("Channel is closed");
				}
				queue.PushStart(path);
				if (!blocked)
				{
					isStarving = false;
				}
			}
		}

		public void Push(T path)
		{
			lock (lockObj)
			{
				if (isClosed)
				{
					throw new InvalidOperationException("Channel is closed");
				}
				queue.PushEnd(path);
				if (!blocked)
				{
					isStarving = false;
				}
			}
		}
	}
}
