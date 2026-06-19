using System;
using System.Collections;
using Loxodon.Framework.Asynchronous;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class AsyncTaskExample2 : MonoBehaviour
	{
		protected IEnumerator Start()
		{
			AsyncTask<int> task = new AsyncTask<int>((Func<IPromise<int>, IEnumerator>)DoTask, true);
			task.OnPreExecute(delegate
			{
				Debug.Log("The task has started.");
			}).OnPostExecute(delegate(int result)
			{
				Debug.LogFormat("The task has completed.result={0}", result);
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
			Debug.LogFormat("IsDone:{0} IsCanceled:{1} Exception:{2} Result:{3}", task.IsDone, task.IsCancelled, task.Exception, task.Result);
		}

		protected IEnumerator DoTask(IPromise<int> promise)
		{
			int n = 10;
			for (int i = 0; i < n; i++)
			{
				if (promise.IsCancellationRequested)
				{
					promise.SetCancelled();
					yield break;
				}
				Debug.LogFormat("i = {0}", i);
				yield return new WaitForSeconds(0.5f);
			}
			promise.SetResult(n);
		}

		protected IEnumerator DoCancel(Loxodon.Framework.Asynchronous.IAsyncResult result)
		{
			yield return new WaitForSeconds(3f);
			result.Cancel();
		}
	}
}
