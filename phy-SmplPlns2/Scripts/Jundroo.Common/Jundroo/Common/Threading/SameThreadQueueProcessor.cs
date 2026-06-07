using System;

namespace Jundroo.Common.Threading
{
	public class SameThreadQueueProcessor : IMainThreadQueueProcessor
	{
		public void Complete()
		{
		}

		public void Enqueue(Action action)
		{
			action();
		}

		public void WaitForQueue()
		{
		}
	}
}
