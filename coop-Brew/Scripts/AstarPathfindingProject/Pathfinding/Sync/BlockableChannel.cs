using System.Threading;
using Pathfinding.Collections;

namespace Pathfinding.Sync
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
				this.channel = null;
			}

			public void Close()
			{
			}

			public PopState Receive(out T item)
			{
				item = null;
				return default(PopState);
			}

			public PopState ReceiveNoBlock(bool blockedBefore, out T item)
			{
				item = null;
				return default(PopState);
			}
		}

		private readonly object lockObj;

		private CircularBuffer<T> queue;

		private int waitingReceivers;

		private ManualResetEvent starving;

		private bool blocked;

		public int numReceivers { get; private set; }

		public bool isClosed { get; private set; }

		public bool isEmpty => false;

		public bool allReceiversBlocked => false;

		public bool isBlocked
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private bool isStarving
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void Close()
		{
		}

		public void Reopen()
		{
		}

		public Receiver AddReceiver()
		{
			return default(Receiver);
		}

		public void PushFront(T path)
		{
		}

		public void Push(T path)
		{
		}
	}
}
