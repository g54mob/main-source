using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ModIO.Util
{
	public class MonoDispatcher : SelfInstancingMonoSingleton<MonoDispatcher>
	{
		private Thread mainThread;

		private readonly ConcurrentQueue<Action> actions = new ConcurrentQueue<Action>();

		protected override void Awake()
		{
			base.Awake();
			mainThread = Thread.CurrentThread;
		}

		public bool MainThread()
		{
			return Thread.CurrentThread == mainThread;
		}

		public void Run(Action action)
		{
			if (MainThread())
			{
				action();
				return;
			}
			lock (actions)
			{
				actions.Enqueue(action);
			}
		}

		private void Update()
		{
			lock (actions)
			{
				while (actions.Count > 0)
				{
					if (actions.TryDequeue(out var result))
					{
						result();
						continue;
					}
					throw new Exception("Failed to dequeue action!");
				}
			}
		}
	}
}
