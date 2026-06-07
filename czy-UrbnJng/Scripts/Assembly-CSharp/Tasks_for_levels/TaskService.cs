using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;

namespace Tasks_for_levels
{
	public class TaskService : ITaskService, IService
	{
		private ITask currentLevelTask;

		private IPersistentProgressService _progressService;

		public TaskService(IPersistentProgressService progressService)
		{
			_progressService = progressService;
		}

		public void SetCurrentTask(ITask task)
		{
			currentLevelTask = task;
		}

		public ITask GetCurrentTask()
		{
			return currentLevelTask ?? null;
		}

		public void ClearCurrentTask()
		{
			currentLevelTask = null;
		}
	}
}
