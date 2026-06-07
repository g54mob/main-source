using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Profiling;

namespace Pathfinding
{
	public class PathProcessor
	{
		public struct GraphUpdateLock : IDisposable
		{
			private PathProcessor pathProcessor;

			private int id;

			public bool Held
			{
				get
				{
					if (pathProcessor != null)
					{
						return pathProcessor.locks.Contains(id);
					}
					return false;
				}
			}

			public GraphUpdateLock(PathProcessor pathProcessor, bool block)
			{
				this.pathProcessor = pathProcessor;
				id = pathProcessor.Lock(block);
			}

			public void Release()
			{
				pathProcessor.Unlock(id);
			}

			void IDisposable.Dispose()
			{
				Release();
			}
		}

		internal BlockableChannel<Path> queue;

		private readonly AstarPath astar;

		private readonly PathReturnQueue returnQueue;

		private PathHandler[] pathHandlers;

		private Thread[] threads;

		private bool multithreaded;

		private IEnumerator threadCoroutine;

		private BlockableChannel<Path>.Receiver coroutineReceiver;

		private readonly List<int> locks = new List<int>();

		private int nextLockID;

		private static readonly ProfilerMarker MarkerCalculatePath = new ProfilerMarker("Calculating Path");

		private static readonly ProfilerMarker MarkerPreparePath = new ProfilerMarker("Prepare Path");

		public int NumThreads => pathHandlers.Length;

		public bool IsUsingMultithreading => multithreaded;

		public event Action<Path> OnPathPreSearch;

		public event Action<Path> OnPathPostSearch;

		public event Action OnQueueUnblocked;

		internal PathProcessor(AstarPath astar, PathReturnQueue returnQueue, int processors, bool multithreaded)
		{
			this.astar = astar;
			this.returnQueue = returnQueue;
			queue = new BlockableChannel<Path>();
			threads = null;
			threadCoroutine = null;
			pathHandlers = new PathHandler[0];
		}

		public void SetThreadCount(int processors, bool multithreaded)
		{
			if (threads != null || threadCoroutine != null || pathHandlers.Length != 0)
			{
				throw new Exception("Call StopThreads before setting the thread count");
			}
			if (processors < 1)
			{
				throw new ArgumentOutOfRangeException("processors");
			}
			if (!multithreaded && processors != 1)
			{
				throw new Exception("Only a single non-multithreaded processor is allowed");
			}
			pathHandlers = new PathHandler[processors];
			this.multithreaded = multithreaded;
			for (int i = 0; i < processors; i++)
			{
				pathHandlers[i] = new PathHandler(astar.nodeStorage, i, processors);
			}
			astar.nodeStorage.SetThreadCount(processors);
			StartThreads();
		}

		private void StartThreads()
		{
			if (threads != null || threadCoroutine != null)
			{
				throw new Exception("Call StopThreads before starting threads");
			}
			queue.Reopen();
			astar.nodeStorage.SetThreadCount(pathHandlers.Length);
			if (multithreaded)
			{
				threads = new Thread[pathHandlers.Length];
				for (int i = 0; i < pathHandlers.Length; i++)
				{
					PathHandler pathHandler = pathHandlers[i];
					BlockableChannel<Path>.Receiver receiver = queue.AddReceiver();
					threads[i] = new Thread((ThreadStart)delegate
					{
						CalculatePathsThreaded(pathHandler, receiver);
					});
					threads[i].Name = "Pathfinding Thread " + i;
					threads[i].IsBackground = true;
					threads[i].Start();
				}
			}
			else
			{
				coroutineReceiver = queue.AddReceiver();
				threadCoroutine = CalculatePaths(pathHandlers[0]);
			}
		}

		private int Lock(bool block)
		{
			queue.isBlocked = true;
			if (block)
			{
				while (!queue.allReceiversBlocked)
				{
					if (IsUsingMultithreading)
					{
						Thread.Sleep(1);
					}
					else
					{
						TickNonMultithreaded();
					}
				}
			}
			nextLockID++;
			locks.Add(nextLockID);
			return nextLockID;
		}

		private void Unlock(int id)
		{
			if (!locks.Remove(id))
			{
				throw new ArgumentException("This lock has already been released");
			}
			if (locks.Count == 0)
			{
				if (this.OnQueueUnblocked != null)
				{
					this.OnQueueUnblocked();
				}
				queue.isBlocked = false;
			}
		}

		public GraphUpdateLock PausePathfinding(bool block)
		{
			return new GraphUpdateLock(this, block);
		}

		public void TickNonMultithreaded()
		{
			if (threadCoroutine == null)
			{
				throw new InvalidOperationException("Cannot tick non-multithreaded pathfinding when no coroutine has been started");
			}
			try
			{
				if (!threadCoroutine.MoveNext())
				{
					threadCoroutine = null;
					coroutineReceiver.Close();
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.LogError("Unhandled exception during pathfinding. Terminating.");
				queue.Close();
				threadCoroutine = null;
				coroutineReceiver.Close();
			}
		}

		public void StopThreads()
		{
			queue.Close();
			if (threads != null)
			{
				for (int i = 0; i < threads.Length; i++)
				{
					if (!threads[i].Join(200))
					{
						Debug.LogError("Could not terminate pathfinding thread[" + i + "] in 200ms, trying Thread.Abort");
						threads[i].Abort();
					}
				}
				threads = null;
			}
			if (threadCoroutine != null)
			{
				while (queue.numReceivers > 0)
				{
					TickNonMultithreaded();
				}
			}
			for (int j = 0; j < pathHandlers.Length; j++)
			{
				pathHandlers[j].Dispose();
			}
			pathHandlers = new PathHandler[0];
		}

		public void Dispose()
		{
			StopThreads();
		}

		private void CalculatePathsThreaded(PathHandler pathHandler, BlockableChannel<Path>.Receiver receiver)
		{
			try
			{
				long num = 100000L;
				long targetTick = DateTime.UtcNow.Ticks + num;
				Path item;
				while (receiver.Receive(out item) != BlockableChannel<Path>.PopState.Closed)
				{
					IPathInternals pathInternals = item;
					pathInternals.PrepareBase(pathHandler);
					pathInternals.AdvanceState(PathState.Processing);
					if (this.OnPathPreSearch != null)
					{
						this.OnPathPreSearch(item);
					}
					long ticks = DateTime.UtcNow.Ticks;
					pathInternals.Prepare();
					if (item.CompleteState == PathCompleteState.NotCalculated)
					{
						astar.debugPathData = pathInternals.PathHandler;
						astar.debugPathID = item.pathID;
						while (item.CompleteState == PathCompleteState.NotCalculated)
						{
							pathInternals.CalculateStep(targetTick);
							targetTick = DateTime.UtcNow.Ticks + num;
							if (queue.isClosed)
							{
								item.FailWithError("AstarPath object destroyed");
							}
						}
						item.duration = (float)(DateTime.UtcNow.Ticks - ticks) * 0.0001f;
					}
					pathInternals.Cleanup();
					pathHandler.heap.Clear(pathHandler.pathNodes);
					if (item.immediateCallback != null)
					{
						item.immediateCallback(item);
					}
					if (this.OnPathPostSearch != null)
					{
						this.OnPathPostSearch(item);
					}
					returnQueue.Enqueue(item);
					pathInternals.AdvanceState(PathState.ReturnQueue);
				}
				if (astar.logPathResults == PathLog.Heavy)
				{
					Debug.LogWarning("Shutting down pathfinding thread #" + pathHandler.threadID);
				}
				receiver.Close();
				return;
			}
			catch (Exception ex)
			{
				if (ex is ThreadAbortException)
				{
					if (astar.logPathResults == PathLog.Heavy)
					{
						Debug.LogWarning("Shutting down pathfinding thread #" + pathHandler.threadID);
					}
					receiver.Close();
					return;
				}
				Debug.LogException(ex);
				Debug.LogError("Unhandled exception during pathfinding. Terminating.");
				queue.Close();
			}
			finally
			{
				Profiler.EndThreadProfiling();
			}
			Debug.LogError("Error : This part should never be reached.");
			receiver.Close();
		}

		private IEnumerator CalculatePaths(PathHandler pathHandler)
		{
			long maxTicks = (long)(astar.maxFrameTime * 10000f);
			long targetTick = DateTime.UtcNow.Ticks + maxTicks;
			while (true)
			{
				Path p = null;
				bool blockedBefore = false;
				while (p == null)
				{
					switch (coroutineReceiver.ReceiveNoBlock(blockedBefore, out p))
					{
					case BlockableChannel<Path>.PopState.Wait:
						blockedBefore = true;
						yield return null;
						break;
					case BlockableChannel<Path>.PopState.Closed:
						yield break;
					}
				}
				IPathInternals ip = p;
				maxTicks = (long)(astar.maxFrameTime * 10000f);
				ip.PrepareBase(pathHandler);
				ip.AdvanceState(PathState.Processing);
				this.OnPathPreSearch?.Invoke(p);
				long ticks = DateTime.UtcNow.Ticks;
				long totalTicks = 0L;
				ip.Prepare();
				if (p.CompleteState == PathCompleteState.NotCalculated)
				{
					astar.debugPathData = ip.PathHandler;
					astar.debugPathID = p.pathID;
					while (p.CompleteState == PathCompleteState.NotCalculated)
					{
						ip.CalculateStep(targetTick);
						if (p.CompleteState != PathCompleteState.NotCalculated)
						{
							break;
						}
						totalTicks += DateTime.UtcNow.Ticks - ticks;
						yield return null;
						ticks = DateTime.UtcNow.Ticks;
						if (queue.isClosed)
						{
							p.FailWithError("AstarPath object destroyed");
						}
						targetTick = DateTime.UtcNow.Ticks + maxTicks;
					}
					totalTicks += DateTime.UtcNow.Ticks - ticks;
					p.duration = (float)totalTicks * 0.0001f;
				}
				ip.Cleanup();
				pathHandler.heap.Clear(pathHandler.pathNodes);
				p.immediateCallback?.Invoke(p);
				this.OnPathPostSearch?.Invoke(p);
				returnQueue.Enqueue(p);
				ip.AdvanceState(PathState.ReturnQueue);
				if (DateTime.UtcNow.Ticks > targetTick)
				{
					yield return null;
					targetTick = DateTime.UtcNow.Ticks + maxTicks;
				}
			}
		}
	}
}
