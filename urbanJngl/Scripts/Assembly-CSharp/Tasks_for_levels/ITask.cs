using System;
using Infrastructure.Services.PersistentProgress;

namespace Tasks_for_levels
{
	public interface ITask : ISavedProgress, ISavedProgressReader
	{
		event Action TaskFinished;

		void UpdateSliders();

		void CheckTasks();

		string GetFinalTasksCount();
	}
}
