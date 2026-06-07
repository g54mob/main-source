using System;

namespace ModApi.Common.Events
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
