using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.TaskManager;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;

namespace NSEipix
{
	public class TaskController : MonoSingleton<TaskController>
	{
		private readonly ConcurrentBag<Task> tasksToAdd = new ConcurrentBag<Task>();

		private readonly List<Task> tasks = new List<Task>();

		private readonly object tasksLock = new object();

		private readonly ConcurrentDictionary<object, ConcurrentDictionary<string, Task>> optimizedCalls = new ConcurrentDictionary<object, ConcurrentDictionary<string, Task>>();

		public bool IsWorking
		{
			get
			{
				if (!tasksToAdd.IsEmpty)
				{
					return true;
				}
				lock (tasksLock)
				{
					return tasks.Count > 0;
				}
			}
		}

		public static void ExecuteNextFrameUnscaled(Action action)
		{
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(action);
		}

		public Task OptimizedCall(object owner, string tag, Action toExecute, float time = -1f, bool unscaledTime = true)
		{
			if (optimizedCalls.TryGetValue(owner, out var value))
			{
				Task value2 = null;
				if (value != null && value.TryGetValue(tag, out value2))
				{
					if (!value2.IsComplete)
					{
						return value2;
					}
					value2.IsRunning = false;
					value.TryRemove(tag, out var _);
				}
			}
			else
			{
				optimizedCalls.TryAdd(owner, new ConcurrentDictionary<string, Task>());
			}
			float seconds = ((time < 0f) ? 0.01f : time);
			Task task = (unscaledTime ? WaitForUnscaled(seconds) : WaitFor(seconds));
			task = task.Then(delegate
			{
				if (!(owner is IGameDisposable { HasDisposed: not false }))
				{
					if (!LoadingController.IsSceneTransition)
					{
						toExecute();
					}
					else
					{
						bool isEnabled;
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(34, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\Controller\\TaskController.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Exiting, canceling OptimizedCall: ");
							messageBuilder.AppendFormatted(toExecute.Method.Name);
						}
						Log.Info(messageBuilder);
					}
					if (optimizedCalls.TryGetValue(owner, out var value5))
					{
						value5.TryRemove(tag, out var _);
						if (value5.Count == 0)
						{
							optimizedCalls.TryRemove(owner, out var _);
						}
					}
				}
			});
			task.IsRunning = true;
			if (optimizedCalls.TryGetValue(owner, out var value4))
			{
				value4.TryAdd(tag, task);
			}
			return task;
		}

		public Task WaitForNextFrameUnscaled()
		{
			Task task = new Task();
			tasksToAdd.Add(task);
			task.IsRunning = true;
			return task.ThenWaitFor(0.01f, isUnscaled: true);
		}

		public Task WaitForNextFrame()
		{
			Task task = new Task();
			tasksToAdd.Add(task);
			task.IsRunning = true;
			return task.ThenWaitFor(0.01f);
		}

		public Task WaitFor(float seconds)
		{
			Task task = new Task();
			tasksToAdd.Add(task);
			task.IsRunning = true;
			return task.ThenWaitFor(seconds);
		}

		public Task WaitForUnscaled(float seconds)
		{
			Task task = new Task();
			tasksToAdd.Add(task);
			task.IsRunning = true;
			return task.ThenWaitFor(seconds, isUnscaled: true);
		}

		public Task WaitUntil(UntilTaskPredicate condition)
		{
			Task task = new Task();
			tasksToAdd.Add(task);
			task.IsRunning = true;
			return task.ThenWaitUntil(condition);
		}

		public Task DoUntil(Action action, Func<bool> condition)
		{
			Task task = new Task();
			tasksToAdd.Add(task);
			task.IsRunning = true;
			return task.DoUntil(action, condition);
		}

		public void EnqueueCustomTask(Task task)
		{
			tasksToAdd.Add(task);
			task.IsRunning = true;
		}

		public void Stop(Task task)
		{
			task?.Stop();
		}

		public void Stop()
		{
			tasksToAdd.Clear();
			lock (tasksLock)
			{
				foreach (Task task in tasks)
				{
					task.Stop();
				}
				tasks.Clear();
			}
			foreach (ConcurrentDictionary<string, Task> value in optimizedCalls.Values)
			{
				foreach (Task value2 in value.Values)
				{
					value2.Stop();
				}
			}
			optimizedCalls.Clear();
		}

		private void Update()
		{
			TryCleanOptimizedCalls();
			if (!IsWorking)
			{
				return;
			}
			lock (tasksLock)
			{
				Task result;
				while (tasksToAdd.TryTake(out result))
				{
					tasks.Add(result);
				}
				for (int i = 0; i < tasks.Count; i++)
				{
					Task task = tasks[i];
					if (task.IsRunning)
					{
						task.Update();
					}
				}
				for (int num = tasks.Count - 1; num >= 0; num--)
				{
					Task task2 = tasks[num];
					if (task2.IsComplete || !task2.IsRunning)
					{
						tasks.RemoveAt(num);
					}
				}
			}
		}

		private void TryCleanOptimizedCalls()
		{
			if (optimizedCalls == null || optimizedCalls.Count <= 0)
			{
				return;
			}
			using PooledList<object> pooledList = ListPool<object>.GetJanitor();
			using PooledList<string> pooledList2 = ListPool<string>.GetJanitor();
			pooledList.AddRange(optimizedCalls.Keys);
			foreach (object item in pooledList)
			{
				ConcurrentDictionary<string, Task> value2;
				if (!optimizedCalls.TryGetValue(item, out var value) || value.Keys == null)
				{
					optimizedCalls.TryRemove(item, out value2);
					continue;
				}
				pooledList2.Clear();
				pooledList2.AddRange(value.Keys);
				foreach (string item2 in pooledList2)
				{
					if (value.TryGetValue(item2, out var value3) && (value3.IsComplete || !value3.IsRunning))
					{
						value.TryRemove(item2, out var _);
					}
				}
				if (value.Count == 0)
				{
					optimizedCalls.TryRemove(item, out value2);
				}
			}
		}

		private void OnEnable()
		{
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnMainSceneLeaving;
		}

		private void OnDisable()
		{
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= OnMainSceneLeaving;
			}
		}

		private void OnMainSceneLeaving()
		{
			Stop();
		}
	}
}
