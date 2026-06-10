using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;

namespace NSMedieval.Village.Map.Pathfinding
{
	public class PathProcessorManager : MonoSingleton<PathProcessorManager>
	{
		private const int ProcessingThreads = 4;

		private readonly Dictionary<int, PathProcessor> instantProcessors = new Dictionary<int, PathProcessor>();

		private object instantProcessorLock = new object();

		private Thread[] processingThreads = new Thread[4];

		private PathProcessor[] pathProcessorsByThread = new PathProcessor[4];

		private readonly ConcurrentQueue<PathProcessingTask> processQueue = new ConcurrentQueue<PathProcessingTask>();

		private readonly ConcurrentQueue<PathProcessingTask> completedTasks = new ConcurrentQueue<PathProcessingTask>();

		public void InstantProcessPath(Path path)
		{
			if (path.IsInPool)
			{
				throw new Exception("Can not process pooled path");
			}
			if (path.State != PathState.Constructed)
			{
				throw new Exception("Path processing failed. Path is invalid state. " + path.State);
			}
			PathProcessor instantPathProcessor = GetInstantPathProcessor(Thread.CurrentThread.ManagedThreadId);
			try
			{
				instantPathProcessor.ProcessPath(path);
			}
			catch (Exception t)
			{
				instantPathProcessor.Reset();
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(42, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Processing\\PathProcessorManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Exception happened while processing path: ");
					messageBuilder.AppendFormatted(t);
				}
				Log.Warning(messageBuilder);
			}
		}

		public PathProcessingTask ScheduleProcessPath(Path path)
		{
			if (path.IsInPool)
			{
				throw new Exception("Can not process pooled path(s)");
			}
			if (path.State != PathState.Constructed)
			{
				throw new Exception("Path processing failed. Path is invalid state. " + path.State);
			}
			PathProcessingTask pathProcessingTask = new PathProcessingTask(path)
			{
				State = PathProcessingTaskState.WaitingToProcess
			};
			processQueue.Enqueue(pathProcessingTask);
			return pathProcessingTask;
		}

		private PathProcessor GetInstantPathProcessor(int threadId)
		{
			lock (instantProcessorLock)
			{
				if (instantProcessors.TryGetValue(threadId, out var value))
				{
					return value;
				}
				PathProcessor pathProcessor = new PathProcessor();
				instantProcessors[threadId] = pathProcessor;
				return pathProcessor;
			}
		}

		private void Update()
		{
			PathProcessingTask result;
			while (completedTasks.TryDequeue(out result))
			{
				result.OnComplete?.Invoke(result);
				result.OnComplete = null;
			}
		}

		private void Start()
		{
			InitProcessorThread();
		}

		protected override void OnDestroy()
		{
			Thread[] array = processingThreads;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Abort();
			}
			processingThreads = null;
			for (int j = 0; j < pathProcessorsByThread.Length; j++)
			{
				pathProcessorsByThread[j].OnAbort();
			}
			pathProcessorsByThread = null;
			base.OnDestroy();
			PathSearchNodePool.ReturnAllNodesToPool();
		}

		private void ThreadLoop(PathProcessor processor)
		{
			try
			{
				while (true)
				{
					Thread.Sleep(1);
					if (!processQueue.TryDequeue(out var result))
					{
						continue;
					}
					if (result.IsAbort)
					{
						result.State = PathProcessingTaskState.Aborted;
						completedTasks.Enqueue(result);
						continue;
					}
					try
					{
						result.State = PathProcessingTaskState.Processing;
						result.OnInit?.Invoke(result);
						processor.ProcessPath(result.Path);
						switch (result.Path.State)
						{
						case PathState.Calculated:
							result.State = PathProcessingTaskState.Completed;
							break;
						case PathState.Abort:
							result.State = PathProcessingTaskState.Aborted;
							break;
						default:
							result.State = PathProcessingTaskState.Failed;
							break;
						}
						completedTasks.Enqueue(result);
					}
					catch (Exception ex)
					{
						result.State = PathProcessingTaskState.Error;
						completedTasks.Enqueue(result);
						processor.Reset();
						Log.Error("Exception on path processing thread: " + ex, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Processing\\PathProcessorManager.cs");
					}
				}
			}
			catch (ThreadAbortException)
			{
				Log.Debug("Path Thread aborted", "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Processing\\PathProcessorManager.cs");
			}
		}

		private void InitProcessorThread()
		{
			for (int i = 0; i < 4; i++)
			{
				PathProcessor pathProcessor = new PathProcessor();
				pathProcessorsByThread[i] = pathProcessor;
				Thread thread = new Thread((ThreadStart)delegate
				{
					ThreadLoop(pathProcessor);
				});
				processingThreads[i] = thread;
				thread.Start();
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(37, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Pathfinding\\Processing\\PathProcessorManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Initialised ");
				messageBuilder.AppendFormatted(4);
				messageBuilder.AppendLiteral(" path processing threads.");
			}
			Log.Info(messageBuilder);
		}
	}
}
