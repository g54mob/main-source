using System.Collections;
using Loxodon.Framework.Asynchronous;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class AsyncResultExample : MonoBehaviour
	{
		protected IEnumerator Start()
		{
			AsyncResult result = new AsyncResult(cancelable: true);
			StartCoroutine(DoTask(result));
			StartCoroutine(DoCancel(result));
			yield return result.WaitForDone();
			Debug.LogFormat("IsDone:{0} IsCanceled:{1} Exception:{2}", result.IsDone, result.IsCancelled, result.Exception);
		}

		protected IEnumerator DoTask(IPromise promise)
		{
			for (int i = 0; i < 20; i++)
			{
				if (promise.IsCancellationRequested)
				{
					promise.SetCancelled();
					yield break;
				}
				Debug.LogFormat("i = {0}", i);
				yield return new WaitForSeconds(0.5f);
			}
			promise.SetResult();
		}

		protected IEnumerator DoCancel(IAsyncResult result)
		{
			yield return new WaitForSeconds(3f);
			result.Cancel();
		}
	}
}
