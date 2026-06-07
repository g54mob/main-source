using System;
using System.Collections.Generic;
using System.Threading;

namespace ModApi.Common.Events
{
	public class MainThreadQueueProcessor : IMainThreadQueueProcessor
	{
		private readonly object _syncLock = new object();

		private bool _complete;

		private bool _empty = true;

		private Queue<Action> _queue = new Queue<Action>();

		public bool IsComplete => _complete;

		public Action OnComplete { get; set; }

		public void Complete()
		{
			_complete = true;
		}

		public void Enqueue(Action action)
		{
			lock (_queue)
			{
				_empty = false;
				_queue.Enqueue(action);
			}
		}

		public void Process()
		{
			if (!_complete)
			{
				lock (_queue)
				{
					if (_queue.Count > 0)
					{
						_queue.Dequeue()();
						if (_queue.Count == 0)
						{
							lock (_syncLock)
							{
								_empty = true;
								Monitor.PulseAll(_syncLock);
								return;
							}
						}
					}
					return;
				}
			}
			if (OnComplete != null)
			{
				OnComplete();
				OnComplete = null;
			}
		}

		public void WaitForQueue()
		{
			while (!_empty)
			{
				lock (_syncLock)
				{
					Monitor.Wait(_syncLock);
				}
			}
		}
	}
}
