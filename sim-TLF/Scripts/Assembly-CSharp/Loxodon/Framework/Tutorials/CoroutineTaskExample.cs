using System;
using System.Collections;
using Loxodon.Framework.Asynchronous;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class CoroutineTaskExample : MonoBehaviour
	{
		private IEnumerator Start()
		{
			Debug.LogFormat("Wait for 2 seconds");
			yield return CoroutineTask.Delay(2f).WaitForDone();
			CoroutineTask task = new CoroutineTask(DoTask()).ContinueWith(DoContinueTask(), CoroutineTaskContinuationOptions.OnCompleted | CoroutineTaskContinuationOptions.OnFaulted).ContinueWith((Action)delegate
			{
				Debug.Log("The task is completed");
			}, CoroutineTaskContinuationOptions.None);
			yield return task.WaitForDone();
			Debug.LogFormat("IsDone:{0} IsCompleted:{1} IsFaulted:{2} IsCancelled:{3}", task.IsDone, task.IsCompleted, task.IsFaulted, task.IsCancelled);
		}

		protected IEnumerator DoTask()
		{
			int n = 10;
			for (int i = 0; i < n; i++)
			{
				Debug.LogFormat("Task:i = {0}", i);
				yield return new WaitForSeconds(0.5f);
			}
		}

		protected IEnumerator DoContinueTask()
		{
			int n = 10;
			for (int i = 0; i < n; i++)
			{
				Debug.LogFormat("ContinueTask:i = {0}", i);
				yield return new WaitForSeconds(0.5f);
			}
		}
	}
}
