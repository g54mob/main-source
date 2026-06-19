using System;
using System.Threading;
using Loxodon.Framework.Execution;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class MainLoopExecutorExample : MonoBehaviour
	{
		private IMainLoopExecutor executor;

		private void Start()
		{
			executor = new MainLoopExecutor();
			Debug.LogFormat("ThreadID:{0}", Thread.CurrentThread.ManagedThreadId);
			Executors.RunAsync((Action)delegate
			{
				executor.RunOnMainThread(Task1, waitForExecution: true);
				executor.RunOnMainThread((Func<string>)Task2);
				Debug.LogFormat("run on the backgound thread. ThreadID:{0}", Thread.CurrentThread.ManagedThreadId);
			});
		}

		private void Task1()
		{
			Debug.LogFormat("This is a task1,run on the main thread. ThreadID:{0}", Thread.CurrentThread.ManagedThreadId);
		}

		private string Task2()
		{
			Debug.LogFormat("This is a task2,run on the main thread. ThreadID:{0}", Thread.CurrentThread.ManagedThreadId);
			return base.name;
		}
	}
}
