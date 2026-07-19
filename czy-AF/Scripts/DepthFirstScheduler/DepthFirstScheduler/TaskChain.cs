using System;
using System.Collections.Generic;

namespace DepthFirstScheduler
{
	public class TaskChain
	{
		public IEnumerator<ISchedulable> Enumerator;

		public Action<Exception> OnError;

		public ChainStatus ChainStatus;

		public static TaskChain Schedule(ISchedulable schedulable, Action<Exception> onError)
		{
			TaskChain taskChain = new TaskChain
			{
				Enumerator = schedulable.Traverse().GetEnumerator(),
				OnError = onError
			};
			if (taskChain.Enumerator.MoveNext())
			{
				if (taskChain.Enumerator.Current.Scheduler == null)
				{
					Scheduler.MainThread.Enqueue(taskChain);
				}
				else
				{
					taskChain.Enumerator.Current.Scheduler.Enqueue(taskChain);
				}
			}
			return taskChain;
		}

		public ExecutionStatus Next()
		{
			if (ChainStatus == ChainStatus.Done || ChainStatus == ChainStatus.Error)
			{
				return ExecutionStatus.Done;
			}
			ExecutionStatus num = Enumerator.Current.Execute();
			if (num == ExecutionStatus.Error)
			{
				ChainStatus = ChainStatus.Error;
				OnError(Enumerator.Current.GetError());
			}
			if (num == ExecutionStatus.Continue)
			{
				ChainStatus = ChainStatus.Continue;
				return ExecutionStatus.Continue;
			}
			if (!Enumerator.MoveNext())
			{
				ChainStatus = ChainStatus.Done;
				return ExecutionStatus.Done;
			}
			if (Enumerator.Current.Scheduler != null)
			{
				ChainStatus = ChainStatus.Continue;
				Enumerator.Current.Scheduler.Enqueue(this);
				return ExecutionStatus.Done;
			}
			return Next();
		}
	}
}
