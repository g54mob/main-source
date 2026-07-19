using System;
using System.Collections.Generic;

namespace DepthFirstScheduler
{
	public interface ISchedulable
	{
		IScheduler Scheduler { get; }

		ISchedulable Parent { get; set; }

		ExecutionStatus Execute();

		Exception GetError();

		void AddChild(ISchedulable child);

		IEnumerable<ISchedulable> Traverse();
	}
}
