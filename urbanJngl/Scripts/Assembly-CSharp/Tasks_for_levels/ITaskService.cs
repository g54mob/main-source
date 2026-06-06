using Infrastructure.Services;

namespace Tasks_for_levels
{
	public interface ITaskService : IService
	{
		void SetCurrentTask(ITask task);

		ITask GetCurrentTask();

		void ClearCurrentTask();
	}
}
