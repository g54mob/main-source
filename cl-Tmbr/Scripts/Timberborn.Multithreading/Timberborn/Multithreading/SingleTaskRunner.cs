using System;

namespace Timberborn.Multithreading
{
	internal readonly struct SingleTaskRunner<T> : ITaskRunner where T : struct, IParallelizerSingleTask
	{
		private readonly T _task;

		public int ExpectedRuns => 1;

		public SingleTaskRunner(T task)
		{
			_task = task;
		}

		public void Run(int runIndex)
		{
			if (runIndex != 0)
			{
				throw new ArgumentException("runIndex must be zero");
			}
			_task.Run();
		}
	}
}
