using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Collections;

namespace Aggro.Core
{
	public class TaskCollection
	{
		private const int INTERNAL_CAPACITY = 1024;

		private List<Task> _tasks = new List<Task>(1024);

		public void AddTask(Task task)
		{
			if (!task.IsCompleted)
			{
				_tasks.Add(task);
			}
		}

		public IEnumerator WaitForTasksCo()
		{
			while (_tasks.Count > 0)
			{
				if (CheckTask(_tasks[0]))
				{
					_tasks.RemoveAtSwapBack(0);
				}
				else
				{
					yield return null;
				}
			}
		}

		public async Task WaitForTasksAsync()
		{
			while (_tasks.Count > 0)
			{
				if (CheckTask(_tasks[0]))
				{
					_tasks.RemoveAtSwapBack(0);
				}
				else
				{
					await Task.Yield();
				}
			}
		}

		private bool CheckTask(Task task)
		{
			return task.IsCompleted;
		}
	}
}
