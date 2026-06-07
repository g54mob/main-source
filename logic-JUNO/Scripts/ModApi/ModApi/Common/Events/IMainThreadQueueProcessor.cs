using System;

namespace ModApi.Common.Events
{
	public interface IMainThreadQueueProcessor
	{
		void Complete();

		void Enqueue(Action action);

		void WaitForQueue();
	}
}
