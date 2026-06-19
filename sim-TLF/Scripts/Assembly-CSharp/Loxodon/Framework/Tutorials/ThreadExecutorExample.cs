using System.Collections;
using System.Text;
using System.Threading;
using Loxodon.Framework.Asynchronous;
using Loxodon.Framework.Execution;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class ThreadExecutorExample : MonoBehaviour
	{
		private IThreadExecutor executor;

		private IEnumerator Start()
		{
			executor = new ThreadExecutor();
			IAsyncResult asyncResult = executor.Execute(Task1);
			yield return asyncResult.WaitForDone();
			IAsyncResult asyncResult2 = executor.Execute(delegate(IPromise promise)
			{
				Task2(promise);
			});
			yield return asyncResult2.WaitForDone();
			IAsyncResult<string> r3 = executor.Execute(delegate(IPromise<string> promise)
			{
				Task3(promise);
			});
			yield return new WaitForSeconds(0.5f);
			r3.Cancel();
			yield return r3.WaitForDone();
			Debug.LogFormat("Task3 IsCalcelled:{0}", r3.IsCancelled);
			IProgressResult<float, string> r4 = executor.Execute(delegate(IProgressPromise<float, string> promise)
			{
				Task4(promise);
			});
			while (!r4.IsDone)
			{
				yield return null;
				Debug.LogFormat("Task4 Progress:{0}%", Mathf.FloorToInt(r4.Progress * 100f));
			}
			Debug.LogFormat("Task4 Result:{0}", r4.Result);
		}

		private void Task1()
		{
			Debug.Log("The task1 is running.");
		}

		private void Task2(IPromise promise)
		{
			Debug.Log("The task2 start");
			Thread.Sleep(100);
			promise.SetResult();
			Debug.Log("The task2 end");
		}

		private void Task3(IPromise<string> promise)
		{
			Debug.Log("The task3 start");
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < 50; i++)
			{
				if (promise.IsCancellationRequested)
				{
					promise.SetCancelled();
					break;
				}
				stringBuilder.Append(i).Append(" ");
				Thread.Sleep(100);
			}
			promise.SetResult(stringBuilder.ToString());
			Debug.Log("The task3 end");
		}

		private void Task4(IProgressPromise<float, string> promise)
		{
			Debug.Log("The task4 start");
			int num = 10;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i <= num; i++)
			{
				if (promise.IsCancellationRequested)
				{
					promise.SetCancelled();
					break;
				}
				stringBuilder.Append(i).Append(" ");
				promise.UpdateProgress((float)i / (float)num);
				Thread.Sleep(100);
			}
			promise.SetResult(stringBuilder.ToString());
			Debug.Log("The task4 end");
		}
	}
}
