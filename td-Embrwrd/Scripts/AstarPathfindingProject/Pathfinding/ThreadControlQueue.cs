using System;
using System.Threading;

namespace Pathfinding
{
	internal class ThreadControlQueue
	{
		public class QueueTerminationException : Exception
		{
		}

		private Path head;

		private Path tail;

		private readonly object lockObj;

		private readonly int numReceivers;

		private bool blocked;

		private int blockedReceivers;

		private bool starving;

		private bool terminate;

		private ManualResetEvent block;

		public bool IsEmpty => false;

		public bool IsTerminating => false;

		public bool AllReceiversBlocked => false;

		public ThreadControlQueue(int numReceivers)
		{
		}

		public void Block()
		{
		}

		public void Unblock()
		{
		}

		public void Lock()
		{
		}

		public void Unlock()
		{
		}

		public void PushFront(Path path)
		{
		}

		public void Push(Path path)
		{
		}

		private void Starving()
		{
		}

		public void TerminateReceivers()
		{
		}

		public Path Pop()
		{
			return null;
		}

		public void ReceiverTerminated()
		{
		}

		public Path PopNoBlock(bool blockedBefore)
		{
			return null;
		}
	}
}
