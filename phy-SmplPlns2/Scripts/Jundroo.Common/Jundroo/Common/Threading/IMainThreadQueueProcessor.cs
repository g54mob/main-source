using System;

namespace Jundroo.Common.Threading
{
	public interface IMainThreadQueueProcessor
	{
		void Complete();

		void Enqueue(Action action);

		void WaitForQueue();
	}
}
