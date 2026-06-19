using System;
using System.Collections;
using Loxodon.Framework.Asynchronous;
using Loxodon.Framework.Execution;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class ExecutorExample : MonoBehaviour
	{
		private IEnumerator Start()
		{
			Executors.RunAsync((Action)delegate
			{
				Debug.LogFormat("RunAsync ");
			});
			Executors.RunAsync((Action)delegate
			{
				Executors.RunOnMainThread(delegate
				{
					Debug.LogFormat("RunOnMainThread Time:{0} frame:{1}", Time.time, Time.frameCount);
				}, waitForExecution: true);
			});
			Executors.RunOnMainThread(delegate
			{
				Debug.LogFormat("RunOnMainThread 2 Time:{0} frame:{1}", Time.time, Time.frameCount);
			});
			Loxodon.Framework.Asynchronous.IAsyncResult asyncResult = Executors.RunOnCoroutine(DoRun());
			yield return asyncResult.WaitForDone();
			Debug.LogFormat("============finished=============");
		}

		private IEnumerator DoRun()
		{
			for (int i = 0; i < 10; i++)
			{
				Debug.LogFormat("i = {0}", i);
				yield return null;
			}
		}
	}
}
