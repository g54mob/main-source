using System;

namespace NodeCanvas.Framework
{
	[Obsolete]
	public interface ISubTasksContainer
	{
		Task[] GetSubTasks();
	}
}
