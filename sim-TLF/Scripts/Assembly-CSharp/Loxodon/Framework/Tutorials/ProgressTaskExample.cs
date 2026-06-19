using System;
using System.Collections;
using System.Text;
using Loxodon.Framework.Asynchronous;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class ProgressTaskExample : MonoBehaviour
	{
		protected IEnumerator Start()
		{
			ProgressTask<float, string> task = new ProgressTask<float, string>(DoTask, cancelable: true);
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
			yield return task.WaitForDone();
			Debug.LogFormat("IsDone:{0} IsCanceled:{1} Exception:{2}", task.IsDone, task.IsCancelled, task.Exception);
		}

		protected IEnumerator DoTask(IProgressPromise<float, string> promise)
		{
			int n = 50;
			StringBuilder buf = new StringBuilder();
			for (int i = 0; i < n; i++)
			{
				if (promise.IsCancellationRequested)
				{
					promise.SetCancelled();
					yield break;
				}
				float progress = (float)i / (float)n;
				buf.Append(" ").Append(i);
				promise.UpdateProgress(progress);
				yield return new WaitForSeconds(0.01f);
			}
			promise.UpdateProgress(1f);
			promise.SetResult(buf.ToString());
		}

		protected IEnumerator DoCancel(Loxodon.Framework.Asynchronous.IAsyncResult result)
		{
			yield return new WaitForSeconds(3f);
			result.Cancel();
		}
	}
}
