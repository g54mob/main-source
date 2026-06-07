using System;
using System.Collections.Generic;
using System.Threading;
using MiscUtil.Collections;

namespace MiscUtil.Threading
{
	public class CustomThreadPool
	{
		private class PriorityComparer : IComparer<ThreadPoolWorkItem>
		{
			internal static readonly IComparer<ThreadPoolWorkItem> Instance = new PriorityComparer();

			private PriorityComparer()
			{
			}

			public int Compare(ThreadPoolWorkItem x, ThreadPoolWorkItem y)
			{
				if (x == null)
				{
					throw new ArgumentException("x");
				}
				if (y == null)
				{
					throw new ArgumentException("y");
				}
				if (x.Priority >= y.Priority)
				{
					return -1;
				}
				return 1;
			}
		}

		private const int DefaultIdlePeriod = 60000;

		private const int DefaultMinThreads = 5;

		private const int DefaultMaxThreads = 10;

		private const int MinWaitPeriod = 60000;

		private const int MaxWaitPeriod = 300000;

		private static object staticLock = new object();

		private static int instanceCount = 0;

		private object stateLock = new object();

		private object queueLock = new object();

		private RandomAccessQueue<ThreadPoolWorkItem> queue = new RandomAccessQueue<ThreadPoolWorkItem>();

		private int threadCounter;

		private int idlePeriod = 60000;

		private string name;

		private int minThreads = 5;

		private int maxThreads = 10;

		private int workingThreads;

		private int totalThreads;

		private ThreadPriority workerThreadPriority = ThreadPriority.Normal;

		private bool workerThreadsAreBackground = true;

		private object eventLock = new object();

		private ThreadPoolExceptionHandler exceptionHandler;

		private BeforeWorkItemHandler beforeWorkItem;

		private AfterWorkItemHandler afterWorkItem;

		private ThreadProgress workerThreadExit;

		public int IdlePeriod
		{
			get
			{
				lock (stateLock)
				{
					return idlePeriod;
				}
			}
			set
			{
				if (value < 0 && value != -1)
				{
					throw new ArgumentException("IdlePeriod must be non-negative.", "IdlePeriod");
				}
				lock (stateLock)
				{
					idlePeriod = value;
				}
			}
		}

		public string Name
		{
			get
			{
				lock (stateLock)
				{
					return name;
				}
			}
		}

		public int MinThreads
		{
			get
			{
				lock (stateLock)
				{
					return minThreads;
				}
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("MinThreads must be non-negative", "MinThreads");
				}
				lock (stateLock)
				{
					if (value > maxThreads)
					{
						throw new ArgumentOutOfRangeException("MinThreads must be less than or equal to MaxThreads");
					}
					minThreads = value;
				}
			}
		}

		public int MaxThreads
		{
			get
			{
				lock (stateLock)
				{
					return maxThreads;
				}
			}
			set
			{
				if (value < 1)
				{
					throw new ArgumentException("MaxThreads must be at least 1", "MaxThreads");
				}
				lock (stateLock)
				{
					if (value < minThreads)
					{
						throw new ArgumentOutOfRangeException("MaxThreads must be greater than or equal to MinThreads");
					}
					maxThreads = value;
				}
			}
		}

		public int QueueLength
		{
			get
			{
				lock (queueLock)
				{
					return queue.Count;
				}
			}
		}

		public int WorkingThreads
		{
			get
			{
				lock (stateLock)
				{
					return workingThreads;
				}
			}
		}

		public int TotalThreads => totalThreads;

		public ThreadPriority WorkerThreadPriority
		{
			get
			{
				lock (stateLock)
				{
					return workerThreadPriority;
				}
			}
			set
			{
				lock (stateLock)
				{
					workerThreadPriority = value;
				}
			}
		}

		public bool WorkerThreadsAreBackground
		{
			get
			{
				lock (stateLock)
				{
					return workerThreadsAreBackground;
				}
			}
			set
			{
				lock (stateLock)
				{
					workerThreadsAreBackground = value;
				}
			}
		}

		public event ThreadPoolExceptionHandler WorkerException
		{
			add
			{
				lock (eventLock)
				{
					exceptionHandler = (ThreadPoolExceptionHandler)Delegate.Combine(exceptionHandler, value);
				}
			}
			remove
			{
				lock (eventLock)
				{
					exceptionHandler = (ThreadPoolExceptionHandler)Delegate.Remove(exceptionHandler, value);
				}
			}
		}

		public event BeforeWorkItemHandler BeforeWorkItem
		{
			add
			{
				lock (eventLock)
				{
					beforeWorkItem = (BeforeWorkItemHandler)Delegate.Combine(beforeWorkItem, value);
				}
			}
			remove
			{
				lock (eventLock)
				{
					beforeWorkItem = (BeforeWorkItemHandler)Delegate.Remove(beforeWorkItem, value);
				}
			}
		}

		public event AfterWorkItemHandler AfterWorkItem
		{
			add
			{
				lock (eventLock)
				{
					afterWorkItem = (AfterWorkItemHandler)Delegate.Combine(afterWorkItem, value);
				}
			}
			remove
			{
				lock (eventLock)
				{
					afterWorkItem = (AfterWorkItemHandler)Delegate.Remove(afterWorkItem, value);
				}
			}
		}

		public event ThreadProgress WorkerThreadExit
		{
			add
			{
				lock (eventLock)
				{
					workerThreadExit = (ThreadProgress)Delegate.Combine(workerThreadExit, value);
				}
			}
			remove
			{
				lock (eventLock)
				{
					workerThreadExit = (ThreadProgress)Delegate.Remove(workerThreadExit, value);
				}
			}
		}

		public CustomThreadPool()
		{
			lock (staticLock)
			{
				instanceCount++;
				lock (stateLock)
				{
					name = "CustomThreadPool-" + instanceCount;
				}
			}
		}

		public CustomThreadPool(string name)
		{
			lock (staticLock)
			{
				instanceCount++;
			}
			lock (stateLock)
			{
				this.name = name;
			}
		}

		public void SetMinMaxThreads(int min, int max)
		{
			lock (stateLock)
			{
				MinThreads = 0;
				MaxThreads = max;
				MinThreads = min;
			}
		}

		private void OnException(ThreadPoolWorkItem workItem, Exception e)
		{
			ThreadPoolExceptionHandler threadPoolExceptionHandler;
			lock (eventLock)
			{
				threadPoolExceptionHandler = exceptionHandler;
			}
			if (threadPoolExceptionHandler == null)
			{
				return;
			}
			Delegate[] invocationList = threadPoolExceptionHandler.GetInvocationList();
			bool handled = false;
			Delegate[] array = invocationList;
			for (int i = 0; i < array.Length; i++)
			{
				ThreadPoolExceptionHandler threadPoolExceptionHandler2 = (ThreadPoolExceptionHandler)array[i];
				threadPoolExceptionHandler2(this, workItem, e, ref handled);
				if (handled)
				{
					break;
				}
			}
		}

		private void OnBeforeWorkItem(ThreadPoolWorkItem workItem, out bool cancel)
		{
			cancel = false;
			BeforeWorkItemHandler beforeWorkItemHandler;
			lock (eventLock)
			{
				beforeWorkItemHandler = beforeWorkItem;
			}
			if (beforeWorkItemHandler == null)
			{
				return;
			}
			Delegate[] invocationList = beforeWorkItemHandler.GetInvocationList();
			Delegate[] array = invocationList;
			for (int i = 0; i < array.Length; i++)
			{
				BeforeWorkItemHandler beforeWorkItemHandler2 = (BeforeWorkItemHandler)array[i];
				beforeWorkItemHandler2(this, workItem, ref cancel);
				if (cancel)
				{
					break;
				}
			}
		}

		private void OnAfterWorkItem(ThreadPoolWorkItem workItem)
		{
			AfterWorkItemHandler afterWorkItemHandler;
			lock (eventLock)
			{
				afterWorkItemHandler = afterWorkItem;
			}
			afterWorkItemHandler?.Invoke(this, workItem);
		}

		private void OnWorkerThreadExit()
		{
			try
			{
				ThreadProgress threadProgress;
				lock (eventLock)
				{
					threadProgress = workerThreadExit;
				}
				threadProgress?.Invoke(this);
			}
			catch
			{
			}
			lock (stateLock)
			{
				totalThreads--;
			}
		}

		public void StartMinThreads()
		{
			lock (stateLock)
			{
				while (TotalThreads < MinThreads)
				{
					StartWorkerThread();
				}
			}
		}

		public void AddWorkItem(Delegate workItemDelegate, params object[] parameters)
		{
			if ((object)workItemDelegate == null)
			{
				throw new ArgumentNullException("workItemDelegate");
			}
			AddWorkItem(new ThreadPoolWorkItem(workItemDelegate, parameters));
		}

		public void AddWorkItem(Delegate workItemDelegate)
		{
			if ((object)workItemDelegate == null)
			{
				throw new ArgumentNullException("workItemDelegate");
			}
			AddWorkItem(new ThreadPoolWorkItem(workItemDelegate, null));
		}

		public void AddWorkItem(ThreadPoolWorkItem workItem)
		{
			if (workItem == null)
			{
				throw new ArgumentNullException("workItem");
			}
			bool flag;
			lock (stateLock)
			{
				lock (queueLock)
				{
					if (queue.Count == 0)
					{
						queue.Enqueue(workItem);
					}
					else if (queue[queue.Count - 1].Priority >= workItem.Priority)
					{
						queue.Enqueue(workItem);
					}
					else
					{
						int num = queue.BinarySearch(workItem, PriorityComparer.Instance);
						queue.Enqueue(workItem, ~num);
					}
					flag = WorkingThreads + queue.Count > TotalThreads && TotalThreads < MaxThreads;
					Monitor.Pulse(queueLock);
				}
			}
			if (flag)
			{
				StartWorkerThread();
			}
		}

		public bool CancelWorkItem(object id)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}
			lock (queueLock)
			{
				for (int i = 0; i < queue.Count; i++)
				{
					ThreadPoolWorkItem threadPoolWorkItem = queue[i];
					object iD = threadPoolWorkItem.ID;
					if (iD != null && id.Equals(iD))
					{
						queue.RemoveAt(i);
						return true;
					}
				}
			}
			return false;
		}

		public void CancelAllWorkItems()
		{
			lock (queueLock)
			{
				queue.Clear();
			}
		}

		private void StartWorkerThread()
		{
			bool isBackground;
			lock (stateLock)
			{
				threadCounter++;
				totalThreads++;
				isBackground = workerThreadsAreBackground;
			}
			Thread thread = new Thread(WorkerThreadLoop);
			thread.Name = Name + " thread " + threadCounter;
			thread.IsBackground = isBackground;
			thread.Start();
		}

		private void WorkerThreadLoop()
		{
			try
			{
				DateTime utcNow = DateTime.UtcNow;
				while (true)
				{
					lock (stateLock)
					{
						if (TotalThreads > MaxThreads)
						{
							break;
						}
					}
					int waitPeriod = CalculateWaitPeriod(utcNow);
					ThreadPoolWorkItem nextWorkItem = GetNextWorkItem(waitPeriod);
					if (nextWorkItem == null)
					{
						if (CheckIfThreadShouldQuit(utcNow))
						{
							break;
						}
					}
					else
					{
						ExecuteWorkItem(nextWorkItem);
						utcNow = DateTime.UtcNow;
					}
				}
			}
			finally
			{
				OnWorkerThreadExit();
			}
		}

		private int CalculateWaitPeriod(DateTime lastJob)
		{
			lock (stateLock)
			{
				int num = IdlePeriod;
				if (num != -1)
				{
					num = (int)(DateTime.UtcNow - lastJob).TotalMilliseconds;
					if (num < 0)
					{
						num = 0;
					}
				}
				if (TotalThreads <= MinThreads && num < 60000 && num != -1)
				{
					num = 60000;
				}
				if (num > 300000 || num == -1)
				{
					num = 300000;
				}
				return num;
			}
		}

		private ThreadPoolWorkItem GetNextWorkItem(int waitPeriod)
		{
			lock (queueLock)
			{
				if (queue.Count != 0)
				{
					return queue.Dequeue();
				}
				Monitor.Wait(queueLock, waitPeriod);
				if (queue.Count != 0)
				{
					return queue.Dequeue();
				}
				return null;
			}
		}

		private bool CheckIfThreadShouldQuit(DateTime lastJob)
		{
			lock (stateLock)
			{
				if (TotalThreads > MinThreads)
				{
					TimeSpan timeSpan = DateTime.UtcNow - lastJob;
					if (IdlePeriod != -1 && (double)IdlePeriod < timeSpan.TotalMilliseconds)
					{
						return true;
					}
				}
				return false;
			}
		}

		private void ExecuteWorkItem(ThreadPoolWorkItem job)
		{
			lock (stateLock)
			{
				workingThreads++;
				Thread.CurrentThread.Priority = workerThreadPriority;
				Thread.CurrentThread.IsBackground = workerThreadsAreBackground;
			}
			try
			{
				OnBeforeWorkItem(job, out var cancel);
				if (!cancel)
				{
					try
					{
						job.Invoke();
					}
					catch (Exception e)
					{
						OnException(job, e);
						return;
					}
					OnAfterWorkItem(job);
				}
			}
			finally
			{
				lock (stateLock)
				{
					Thread.CurrentThread.Priority = workerThreadPriority;
					Thread.CurrentThread.IsBackground = workerThreadsAreBackground;
					workingThreads--;
				}
			}
		}
	}
}
