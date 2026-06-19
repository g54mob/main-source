using System;
using System.Collections;
using Loxodon.Framework.Asynchronous;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class AsyncTaskExample : MonoBehaviour
	{
		protected IEnumerator Start()
		{
			AsyncTask task = new AsyncTask(DoTask(), cancelable: true);
			task.OnPreExecute(delegate
			{
				Debug.Log("The task has started.");
			}).OnPostExecute(delegate
			{
				Debug.Log("The task has completed.");
			}).OnError(delegate(Exception e)
			{
				Debug.LogFormat("An error occurred:{0}", e);
			})
				.OnFinish(delegate
				{
					Debug.Log("The task has been finished.");
				})
				.Start();
			StartCoroutine(DoCancel(task));
			yield return task.WaitForDone();
			Debug.LogFormat("IsDone:{0} IsCanceled:{1} Exception:{2}", task.IsDone, task.IsCancelled, task.Exception);
		}

		protected IEnumerator DoTask()
		{
			int n = 10;
			for (int i = 0; i < n; i++)
			{
				Debug.LogFormat("i = {0}", i);
				yield return new WaitForSeconds(0.5f);
			}
		}

		protected IEnumerator DoCancel(Loxodon.Framework.Asynchronous.IAsyncResult result)
		{
			yield return new WaitForSeconds(3f);
			result.Cancel();
		}
	}
}
