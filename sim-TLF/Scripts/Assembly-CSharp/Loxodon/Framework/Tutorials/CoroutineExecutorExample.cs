using System.Collections;
using System.Text;
using Loxodon.Framework.Asynchronous;
using Loxodon.Framework.Execution;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class CoroutineExecutorExample : MonoBehaviour
	{
		private ICoroutineExecutor executor;

		private IEnumerator Start()
		{
			executor = new CoroutineExecutor();
			IAsyncResult asyncResult = executor.RunOnCoroutine(Task1());
			yield return asyncResult.WaitForDone();
			IAsyncResult asyncResult2 = executor.RunOnCoroutine((IPromise promise) => Task2(promise));
			yield return asyncResult2.WaitForDone();
			IAsyncResult<string> r3 = executor.RunOnCoroutine((IPromise<string> promise) => Task3(promise));
			yield return new WaitForSeconds(0.5f);
			r3.Cancel();
			yield return r3.WaitForDone();
			Debug.LogFormat("Task3 IsCalcelled:{0}", r3.IsCancelled);
			IProgressResult<float, string> r4 = executor.RunOnCoroutine((IProgressPromise<float, string> promise) => Task4(promise));
			while (!r4.IsDone)
			{
				yield return null;
				Debug.LogFormat("Task4 Progress:{0}%", Mathf.FloorToInt(r4.Progress * 100f));
			}
			Debug.LogFormat("Task4 Result:{0}", r4.Result);
		}

		private IEnumerator Task1()
		{
			Debug.Log("The task1 start");
			yield return null;
			Debug.Log("The task1 end");
		}

		private IEnumerator Task2(IPromise promise)
		{
			Debug.Log("The task2 start");
			yield return null;
			promise.SetResult();
			Debug.Log("The task2 end");
		}

		private IEnumerator Task3(IPromise<string> promise)
		{
			Debug.Log("The task3 start");
			StringBuilder buf = new StringBuilder();
			for (int i = 0; i < 50; i++)
			{
				if (promise.IsCancellationRequested)
				{
					promise.SetCancelled();
					yield break;
				}
				buf.Append(i).Append(" ");
				yield return null;
			}
			promise.SetResult(buf.ToString());
			Debug.Log("The task3 end");
		}

		private IEnumerator Task4(IProgressPromise<float, string> promise)
		{
			Debug.Log("The task4 start");
			int n = 10;
			StringBuilder buf = new StringBuilder();
			for (int i = 1; i <= n; i++)
			{
				if (promise.IsCancellationRequested)
				{
					promise.SetCancelled();
					yield break;
				}
				buf.Append(i).Append(" ");
				promise.UpdateProgress((float)i / (float)n);
				yield return null;
			}
			promise.SetResult(buf.ToString());
			Debug.Log("The task4 end");
		}
	}
}
