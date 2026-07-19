using System;
using System.Collections.Generic;
using System.Threading;

namespace DepthFirstScheduler
{
	public static class Scheduler
	{
		public class CurrentThreadScheduler : IScheduler, IDisposable
		{
			[ThreadStatic]
			private static Queue<TaskChain> queue;

			private bool disposedValue;

			private static Queue<TaskChain> GetQueue()
			{
				return queue;
			}

			private static void SetQueue(Queue<TaskChain> newQueue)
			{
				queue = newQueue;
			}

			public void Enqueue(TaskChain item)
			{
				Queue<TaskChain> queue = GetQueue();
				if (queue == null)
				{
					queue = new Queue<TaskChain>(5);
					queue.Enqueue(item);
					SetQueue(queue);
					try
					{
						Trampoline.Run(queue);
						return;
					}
					finally
					{
						SetQueue(null);
					}
				}
				queue.Enqueue(item);
			}

			protected virtual void Dispose(bool disposing)
			{
				if (!disposedValue)
				{
					if (disposing)
					{
						GetQueue()?.Clear();
						SetQueue(null);
					}
					disposedValue = true;
				}
			}

			public void Dispose()
			{
				Dispose(disposing: true);
			}
		}

		private static class Trampoline
		{
			public static void Run(Queue<TaskChain> queue)
			{
				while (queue.Count > 0)
				{
					TaskChain taskChain = queue.Dequeue();
					while (taskChain.Next() == ExecutionStatus.Continue)
					{
					}
				}
			}
		}

		public class StepScheduler : IScheduler, IDisposable
		{
			private LockQueue<TaskChain> m_taskQueue = new LockQueue<TaskChain>();

			private TaskChain m_chain;

			public void Enqueue(TaskChain item)
			{
				m_taskQueue.Enqueue(item);
			}

			public int UpdateAndGetTaskCount()
			{
				if (m_chain != null)
				{
					if (m_chain.Next() == ExecutionStatus.Continue)
					{
						return m_taskQueue.Count;
					}
					m_chain = null;
				}
				m_chain = m_taskQueue.Dequeue(out var remain);
				return remain;
			}

			public void Dispose()
			{
			}
		}

		public class ThreadPoolScheduler : IScheduler, IDisposable
		{
			public void Enqueue(TaskChain item)
			{
				System.Threading.ThreadPool.QueueUserWorkItem(delegate
				{
					if (item != null)
					{
						while (item.Next() == ExecutionStatus.Continue)
						{
						}
					}
				});
			}

			public void Dispose()
			{
			}
		}

		public class ThreadScheduler : IScheduler, IDisposable
		{
			private MonitorQueue<TaskChain> m_queue = new MonitorQueue<TaskChain>();

			private Thread m_thread;

			private bool disposedValue;

			public ThreadScheduler()
			{
				m_thread = new Thread(Worker);
				m_thread.Start(m_queue);
			}

			private static void Worker(object arg)
			{
				MonitorQueue<TaskChain> monitorQueue = (MonitorQueue<TaskChain>)arg;
				while (true)
				{
					TaskChain taskChain = monitorQueue.Dequeue();
					if (taskChain != null)
					{
						while (taskChain.Next() == ExecutionStatus.Continue)
						{
						}
						continue;
					}
					break;
				}
			}

			public void Enqueue(TaskChain item)
			{
				m_queue.Enqueue(item);
			}

			protected virtual void Dispose(bool disposing)
			{
				if (!disposedValue)
				{
					if (disposing && m_thread != null)
					{
						m_queue.Enqueue(null);
						m_thread.Join();
						m_thread = null;
					}
					disposedValue = true;
				}
			}

			public void Dispose()
			{
				Dispose(disposing: true);
			}
		}

		private static IScheduler currentThread;

		private static StepScheduler mainThread;

		private static IScheduler threadPool;

		private static IScheduler singleWorkerThread;

		public static IScheduler CurrentThread => currentThread ?? (currentThread = new CurrentThreadScheduler());

		public static StepScheduler MainThread
		{
			get
			{
				if (mainThread != null)
				{
					return mainThread;
				}
				mainThread = new StepScheduler();
				MainThreadDispatcher.Initialize();
				return mainThread;
			}
		}

		public static IScheduler ThreadPool => threadPool ?? (threadPool = new ThreadPoolScheduler());

		public static IScheduler SingleWorkerThread => singleWorkerThread ?? (singleWorkerThread = new ThreadScheduler());
	}
}
