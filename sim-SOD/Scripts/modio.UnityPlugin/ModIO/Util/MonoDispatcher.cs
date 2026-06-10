using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ModIO.Util
{
	public class MonoDispatcher : SelfInstancingMonoSingleton<MonoDispatcher>
	{
		private Thread mainThread;

		private readonly ConcurrentQueue<Action> actions;

		protected override void Awake()
		{
		}

		public bool MainThread()
		{
			return false;
		}

		public void Run(Action action)
		{
		}

		private void Update()
		{
		}
	}
}
