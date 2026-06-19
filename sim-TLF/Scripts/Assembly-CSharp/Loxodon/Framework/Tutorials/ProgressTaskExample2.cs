using System;
using System.Collections;
using System.Text;
using System.Threading;
using Loxodon.Framework.Asynchronous;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class ProgressTaskExample2 : MonoBehaviour
	{
		protected IEnumerator Start()
		{
			ProgressTask<float, string> task = new ProgressTask<float, string>(DoTask, runOnMainThread: false, cancelable: true);
			task.OnPreExecute(delegate
			{
				Debug.Log("The task has started.");
			}).OnPostExecute(delegate(string result)
			{
				Debug.LogFormat("The task has completed. result:{0}", result);
			}).OnProgressUpdate(delegate(float progress)
			{
				Debug.LogFormat("The current progress:{0}%", (int)(progress * 100f));
			})
				.OnError(delegate(Exception e)
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

		protected void DoTask(IProgressPromise<float, string> promise)
		{
			try
			{
				int num = 50;
				float num2 = 0f;
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < num; i++)
				{
					if (promise.IsCancellationRequested)
					{
						promise.SetCancelled();
						break;
					}
					num2 = (float)i / (float)num;
					stringBuilder.Append(" ").Append(i);
					promise.UpdateProgress(num2);
					Thread.Sleep(200);
				}
				promise.UpdateProgress(1f);
				promise.SetResult(stringBuilder.ToString());
			}
			catch (Exception exception)
			{
				promise.SetException(exception);
			}
		}

		protected IEnumerator DoCancel(Loxodon.Framework.Asynchronous.IAsyncResult result)
		{
			yield return new WaitForSeconds(3f);
			result.Cancel();
		}
	}
}
