using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using UnityEngine;

namespace Assets.Scripts.Terrain
{
	public class AsynchronousJobProcessor : IDisposable
	{
		private readonly object _lock = new object();

		private Queue<QuadSphereJob> _completedJobs;

		private Queue<QuadSphereJob> _completedJobsTemp;

		private Func<CreateQuadData> _createQuadDataFactory;

		private bool _disposed;

		private int _jobsBeingProcessed;

		private Queue<QuadSphereJob> _pendingJobs;

		private Stack<QuadSplitJob> _quadSplitJobPool;

		private AutoResetEvent _resetEvent;

		private Queue<QuadScript> _uninitializedQuadSplitJobs;

		private List<BackgroundWorker> _workers;

		public int QuadSplitJobPoolSize => _quadSplitJobPool.Count;

		public AsynchronousJobProcessor(Func<CreateQuadData> createQuadDataFactory)
		{
			int num = Math.Max(SystemInfo.processorCount - 1, 1);
			int num2 = num * 2;
			_createQuadDataFactory = createQuadDataFactory;
			_pendingJobs = new Queue<QuadSphereJob>(num2);
			_completedJobs = new Queue<QuadSphereJob>(num2);
			_completedJobsTemp = new Queue<QuadSphereJob>(num2);
			_resetEvent = new AutoResetEvent(initialState: false);
			_uninitializedQuadSplitJobs = new Queue<QuadScript>(300);
			_quadSplitJobPool = new Stack<QuadSplitJob>(num2);
			for (int i = 0; i < num2; i++)
			{
				_quadSplitJobPool.Push(new QuadSplitJob(_createQuadDataFactory));
			}
			_workers = new List<BackgroundWorker>(num);
			for (int j = 0; j < num; j++)
			{
				BackgroundWorker backgroundWorker = new BackgroundWorker();
				backgroundWorker.WorkerReportsProgress = false;
				backgroundWorker.WorkerSupportsCancellation = false;
				backgroundWorker.DoWork += ProcessJobs;
				backgroundWorker.RunWorkerCompleted += ProcessJobsCompleted;
				_workers.Add(backgroundWorker);
				backgroundWorker.RunWorkerAsync();
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}

		public int GetCompletedJobCount()
		{
			lock (_lock)
			{
				return _completedJobs.Count;
			}
		}

		public int GetJobCount()
		{
			lock (_lock)
			{
				return _uninitializedQuadSplitJobs.Count + _pendingJobs.Count + _jobsBeingProcessed + _completedJobs.Count;
			}
		}

		public int GetPendingJobCount()
		{
			lock (_lock)
			{
				return _pendingJobs.Count;
			}
		}

		public int ProcessCompletedJobs(int maxJobs)
		{
			if (_completedJobs.Count == 0)
			{
				return 0;
			}
			lock (_lock)
			{
				if (_completedJobs.Count <= maxJobs)
				{
					Queue<QuadSphereJob> completedJobs = _completedJobs;
					_completedJobs = _completedJobsTemp;
					_completedJobsTemp = completedJobs;
				}
				else
				{
					while (--maxJobs >= 0 && _completedJobs.Count > 0)
					{
						_completedJobsTemp.Enqueue(_completedJobs.Dequeue());
					}
				}
			}
			foreach (QuadSphereJob item2 in _completedJobsTemp)
			{
				item2.Complete();
			}
			lock (_lock)
			{
				foreach (QuadSphereJob item3 in _completedJobsTemp)
				{
					if (item3 is QuadSplitJob item)
					{
						_quadSplitJobPool.Push(item);
					}
				}
			}
			int count = _completedJobsTemp.Count;
			_completedJobsTemp.Clear();
			return count;
		}

		public void ProcessUninitializedJobs()
		{
			if (_uninitializedQuadSplitJobs.Count == 0)
			{
				return;
			}
			lock (_lock)
			{
				while (_uninitializedQuadSplitJobs.Count > 0 && _quadSplitJobPool.Count > 0)
				{
					QuadScript quadScript = _uninitializedQuadSplitJobs.Dequeue();
					if (!quadScript.IsSubdivisionPending)
					{
						CancelUninitializedJob(quadScript);
						continue;
					}
					QuadSplitJob quadSplitJob = _quadSplitJobPool.Pop();
					quadSplitJob.Initialize(quadScript);
					_pendingJobs.Enqueue(quadSplitJob);
				}
			}
			_resetEvent.Set();
		}

		public void QueueQuadRefreshJob(QuadScript quad)
		{
			lock (_lock)
			{
				QuadRefreshJob quadRefreshJob = new QuadRefreshJob(_createQuadDataFactory);
				quadRefreshJob.Initialize(quad);
				_pendingJobs.Enqueue(quadRefreshJob);
			}
			_resetEvent.Set();
		}

		public void QueueQuadSplitJob(QuadScript quad)
		{
			lock (_lock)
			{
				quad.IsSubdivisionPending = true;
				quad.IsSplitJobQueued = true;
				if (_quadSplitJobPool.Count == 0)
				{
					_uninitializedQuadSplitJobs.Enqueue(quad);
					return;
				}
				QuadSplitJob quadSplitJob = _quadSplitJobPool.Pop();
				quadSplitJob.Initialize(quad);
				_pendingJobs.Enqueue(quadSplitJob);
			}
			_resetEvent.Set();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}
			_disposed = true;
			if (!disposing)
			{
				return;
			}
			lock (_lock)
			{
				foreach (QuadScript uninitializedQuadSplitJob in _uninitializedQuadSplitJobs)
				{
					CancelUninitializedJob(uninitializedQuadSplitJob);
				}
				_uninitializedQuadSplitJobs.Clear();
				foreach (QuadSphereJob pendingJob in _pendingJobs)
				{
					_completedJobs.Enqueue(pendingJob);
				}
			}
			_resetEvent.Set();
		}

		private void CancelUninitializedJob(QuadScript quad)
		{
			if (quad.IsPendingReturnToPool)
			{
				quad.ReturnToPool();
			}
		}

		private void ProcessJobs(object sender, DoWorkEventArgs e)
		{
			while (!_disposed)
			{
				_resetEvent.WaitOne();
				if (_disposed)
				{
					_resetEvent.Set();
					break;
				}
				while (_pendingJobs.Count > 0 && !_disposed)
				{
					QuadSphereJob quadSphereJob = null;
					lock (_lock)
					{
						if (_pendingJobs.Count > 0)
						{
							quadSphereJob = _pendingJobs.Dequeue();
							_jobsBeingProcessed++;
						}
					}
					if (quadSphereJob == null)
					{
						break;
					}
					try
					{
						quadSphereJob.Process();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
					lock (_lock)
					{
						_completedJobs.Enqueue(quadSphereJob);
						_jobsBeingProcessed--;
					}
				}
			}
		}

		private void ProcessJobsCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			BackgroundWorker item = (BackgroundWorker)sender;
			if (e.Error != null)
			{
				Debug.LogException(e.Error);
			}
			bool flag = false;
			lock (_lock)
			{
				_workers.Remove(item);
				flag = _workers.Count == 0;
			}
			if (!flag)
			{
				return;
			}
			_resetEvent.Close();
			foreach (QuadSphereJob completedJob in _completedJobs)
			{
				completedJob.CancelJob(isMainThread: false);
			}
		}
	}
}
