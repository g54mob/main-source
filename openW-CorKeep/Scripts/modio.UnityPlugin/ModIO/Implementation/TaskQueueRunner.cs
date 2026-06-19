using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModIO.Implementation
{
	internal class TaskQueueRunner
	{
		private class TaskQueueItem
		{
			public Task task;

			public int taskSize;

			public TaskPriority priority;

			public bool useSeparateThread;
		}

		private List<TaskQueueItem> tasks = new List<TaskQueueItem>();

		private int upperTasksBoundary;

		private bool runsAutomatically;

		private bool isAutoRunning;

		private bool synchronizedJobs = true;

		public TaskQueueRunner(int upperTasksBoundary, bool runsAutomatically = false, bool synchronizedJobs = false)
		{
			this.upperTasksBoundary = upperTasksBoundary;
			this.runsAutomatically = runsAutomatically;
			this.synchronizedJobs = synchronizedJobs;
		}

		private async void AutoRun()
		{
			if (isAutoRunning)
			{
				return;
			}
			isAutoRunning = true;
			while (HasTasks())
			{
				try
				{
					await PerformTasks();
				}
				catch (Exception ex)
				{
					Logger.Log(LogLevel.Warning, "[TQR] Unhandled exception  thrown in AutoRun. Exception: " + ex.Message + " - Inner Exception: " + ex.InnerException?.Message);
				}
			}
			isAutoRunning = false;
		}

		public async Task PerformTasks()
		{
			List<TaskQueueItem> list = new List<TaskQueueItem>();
			try
			{
				lock (tasks)
				{
					int taskAmount = 0;
					list.AddRange(GetTasks(TaskPriority.HIGH, upperTasksBoundary, ref taskAmount, tasks));
					list.AddRange(GetTasks(TaskPriority.LOW, upperTasksBoundary, ref taskAmount, tasks));
					tasks = tasks.Except(list).ToList();
					if (list.Count == 0)
					{
						return;
					}
				}
				await RunTasksAsync(list, synchronizedJobs);
			}
			catch (Exception ex)
			{
				Logger.Log(LogLevel.Warning, "[TQR] Unhandled exception thrown in PerformTasks operation. Exception: " + ex.Message + " - Inner Exception: " + ex.InnerException?.Message);
			}
		}

		public bool HasTasks()
		{
			return tasks.Count > 0;
		}

		public Task<T> AddTask<T>(TaskPriority prio, int taskSize, Func<Task<T>> taskFunc, bool useSeparateThread = false)
		{
			TaskCompletionSource<T> taskCompletionSource = new TaskCompletionSource<T>();
			Task task = new Task(async delegate
			{
				try
				{
					T result = await taskFunc();
					taskCompletionSource.SetResult(result);
				}
				catch (Exception exception)
				{
					taskCompletionSource.SetException(exception);
				}
			});
			lock (tasks)
			{
				tasks.Add(new TaskQueueItem
				{
					task = task,
					taskSize = taskSize,
					priority = prio,
					useSeparateThread = useSeparateThread
				});
				if (runsAutomatically)
				{
					AutoRun();
				}
			}
			return taskCompletionSource.Task;
		}

		private static List<TaskQueueItem> GetTasks(TaskPriority p, int upperTasksBoundary, ref int taskAmount, List<TaskQueueItem> operations)
		{
			int taskAmountCache = taskAmount;
			List<TaskQueueItem> result = (from x in operations
				where x.priority == p
				orderby x.taskSize
				select x).Where(delegate(TaskQueueItem x)
			{
				if (taskAmountCache + x.taskSize <= upperTasksBoundary)
				{
					taskAmountCache += x.taskSize;
					return true;
				}
				return false;
			}).ToList();
			taskAmount = taskAmountCache;
			return result;
		}

		private static async Task RunTasksAsync(List<TaskQueueItem> items, bool synchronizedJobs)
		{
			if (synchronizedJobs)
			{
				foreach (TaskQueueItem item in items)
				{
					if (item.task.IsCanceled || item.task.IsFaulted)
					{
						continue;
					}
					try
					{
						if (item.useSeparateThread)
						{
							await Task.Run(delegate
							{
								item.task.Start();
							});
						}
						else
						{
							item.task.Start();
							item.task.Wait();
							await item.task;
						}
					}
					catch (Exception ex)
					{
						Logger.Log(LogLevel.Warning, "[TQR] Unhandled exception thrown in synchronized RunTasksAsync() operation. Exception: " + ex.Message + " - Inner Exception: " + ex.InnerException?.Message);
					}
				}
				return;
			}
			foreach (TaskQueueItem item2 in items)
			{
				if (item2.task.IsCanceled || item2.task.IsFaulted)
				{
					continue;
				}
				try
				{
					if (item2.useSeparateThread)
					{
						await Task.Run(delegate
						{
							item2.task.Start();
						});
					}
					else
					{
						item2.task.Start();
					}
				}
				catch (Exception ex2)
				{
					Logger.Log(LogLevel.Warning, "[TQR] Unhandled exception thrown in non-synchronized RunTasksAsync() operation. Exception: " + ex2.Message + " - Inner Exception: " + ex2.InnerException?.Message);
				}
			}
			await Task.WhenAll(items.Select((TaskQueueItem x) => x.task).ToArray());
		}
	}
}
