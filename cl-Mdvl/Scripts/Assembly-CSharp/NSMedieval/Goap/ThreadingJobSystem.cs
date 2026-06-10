using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Threading;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Map;
using UnityEngine;
using UnityEngine.Profiling;

namespace NSMedieval.Goap
{
	public class ThreadingJobSystem : MonoSingleton<ThreadingJobSystem>
	{
		public delegate bool TaskDelegate();

		public delegate void DoneCallback(bool result);

		public class ThreadedTaskData
		{
			public DoneCallback Callback { get; set; }

			public TaskDelegate Task { get; set; }

			public bool Result { get; set; }

			public bool ResultFailOverride { get; set; }
		}

		private Thread[] threads;

		private ConcurrentQueue<ThreadedTaskData> taskDoneCallbacks = new ConcurrentQueue<ThreadedTaskData>();

		private ConcurrentQueue<ThreadedTaskData> taskQueue = new ConcurrentQueue<ThreadedTaskData>();

		public Thread MainThread { get; private set; }

		public int TasksCount => taskQueue.Count;

		public static bool IsMainThread => Thread.CurrentThread.ManagedThreadId == 1;

		public ThreadedTaskData QueueTask(TaskDelegate task, DoneCallback doneCallback)
		{
			ThreadedTaskData threadedTaskData = new ThreadedTaskData
			{
				Task = task,
				Callback = doneCallback
			};
			taskQueue.Enqueue(threadedTaskData);
			return threadedTaskData;
		}

		public void ExecuteOnMainThread(Action action)
		{
			if (Thread.CurrentThread == MainThread)
			{
				action?.Invoke();
				return;
			}
			ThreadedTaskData threadedTaskData = new ThreadedTaskData();
			threadedTaskData.Callback = delegate
			{
				action?.Invoke();
			};
			threadedTaskData.Result = true;
			threadedTaskData.Task = () => true;
			taskDoneCallbacks.Enqueue(threadedTaskData);
		}

		public void ExecuteOnMainThreadBlocking(Action action)
		{
			int opResult = 0;
			MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThread(delegate
			{
				try
				{
					action?.Invoke();
					opResult = 1;
				}
				catch (Exception t)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(51, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Threading\\ThreadingJobSystem.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Exception occurred while executing on main thread: ");
						messageBuilder.AppendFormatted(t);
					}
					Log.Error(messageBuilder);
					opResult = -1;
				}
			});
			while (opResult == 0)
			{
			}
			if (opResult == -1)
			{
				throw new Exception("Exception occurred while executing on main thread, see previous error log for details");
			}
		}

		private void Tick(float deltaTime)
		{
			while (!taskDoneCallbacks.IsEmpty)
			{
				if (!taskDoneCallbacks.TryDequeue(out var result))
				{
					continue;
				}
				try
				{
					result.Callback(!result.ResultFailOverride && result.Result);
				}
				catch (Exception t)
				{
					bool isEnabled;
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(64, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Threading\\ThreadingJobSystem.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Exception during GOAP threaded task completion callback step: \n ");
						messageBuilder.AppendFormatted(t);
					}
					Log.Error(messageBuilder);
				}
			}
		}

		private void InitWorkerThreads(int threadsCnt)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Threading\\ThreadingJobSystem.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Threading job system utilising ");
				messageBuilder.AppendFormatted(threadsCnt);
				messageBuilder.AppendLiteral(" threads");
			}
			Log.Info(messageBuilder);
			threads = new Thread[threadsCnt];
			for (int i = 0; i < threadsCnt; i++)
			{
				int i2 = i;
				Thread thread = new Thread((ThreadStart)delegate
				{
					ThreadMainLoop(i2);
				});
				threads[i] = thread;
				thread.Start();
			}
			MonoSingleton<SceneController>.Instance.Tick += Tick;
		}

		private void ThreadMainLoop(int threadIndex)
		{
			try
			{
				while (true)
				{
					if (taskQueue.TryDequeue(out var result))
					{
						ExecuteTask(result);
					}
					Thread.Sleep(1);
				}
			}
			catch (ThreadAbortException)
			{
				Log.Trace("Thread aborted", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Threading\\ThreadingJobSystem.cs");
			}
			Profiler.EndThreadProfiling();
		}

		private void ExecuteTask(ThreadedTaskData taskData)
		{
			bool result = false;
			if (taskData.ResultFailOverride)
			{
				taskData.Result = false;
				taskDoneCallbacks.Enqueue(taskData);
				return;
			}
			try
			{
				result = taskData.Task();
			}
			catch (ThreadAbortException)
			{
				Log.Trace("Thread aborted", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Threading\\ThreadingJobSystem.cs");
			}
			catch (Exception t)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(39, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Core\\Threading\\ThreadingJobSystem.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Exception during GOAP threaded task: \n ");
					messageBuilder.AppendFormatted(t);
				}
				Log.Warning(messageBuilder);
				result = false;
			}
			taskData.Result = result;
			taskDoneCallbacks.Enqueue(taskData);
		}

		private IEnumerator InitSystem()
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			int num = SystemInfo.processorCount;
			if (num > 4)
			{
				num /= 2;
				num--;
				if (num < 4)
				{
					num = 4;
				}
			}
			InitWorkerThreads(num);
		}

		private void Start()
		{
			MainThread = Thread.CurrentThread;
			MonoSingleton<World>.Instance.MapLoadedEvent += delegate
			{
				StartCoroutine(InitSystem());
			};
		}

		protected override void OnDestroy()
		{
			if (threads != null)
			{
				Thread[] array = threads;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Abort();
				}
				threads = null;
				if (MonoSingleton<SceneController>.IsInstantiated())
				{
					MonoSingleton<SceneController>.Instance.Tick -= Tick;
				}
				base.OnDestroy();
			}
		}
	}
}
