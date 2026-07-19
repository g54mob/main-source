using System;

namespace DepthFirstScheduler
{
	public class NoParentException : Exception
	{
		public NoParentException()
			: base("No parent task can't ContinueWith or OnExecute. First AddTask")
		{
		}
	}
}
