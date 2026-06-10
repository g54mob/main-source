using System;
using System.Collections.Generic;
using System.Threading;
using ModIO.Util;

namespace ModIOBrowser.Implementation
{
	internal class UnityDispatcher : SelfInstancingMonoSingleton<UnityDispatcher>
	{
		private static Thread mainThread;

		private static object lockItem;

		private static readonly Queue<Action> _actions;

		protected override void Awake()
		{
		}

		public static bool MainThread()
		{
			return false;
		}

		public void InvokeAsync(Action action)
		{
		}

		private void Update()
		{
		}
	}
}
