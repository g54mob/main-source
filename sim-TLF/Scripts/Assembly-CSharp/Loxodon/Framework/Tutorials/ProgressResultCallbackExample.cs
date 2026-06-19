using System.Collections;
using Loxodon.Framework.Asynchronous;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class ProgressResultCallbackExample : MonoBehaviour
	{
		private void Start()
		{
			ProgressResult<float, bool> progressResult = new ProgressResult<float, bool>();
			progressResult.Callbackable().OnProgressCallback(delegate(float p)
			{
				Debug.LogFormat("Progress:{0}%", p * 100f);
			});
			progressResult.Callbackable().OnCallback(delegate(IProgressResult<float, bool> r)
			{
				if (r.Exception != null)
				{
					Debug.LogFormat("The task is finished.IsDone:{0} Exception:{1}", r.IsDone, r.Exception);
				}
				else
				{
					Debug.LogFormat("The task is finished. IsDone:{0} Result:{1}", r.IsDone, r.Result);
				}
			});
			StartCoroutine(DoTask(progressResult));
		}

		protected IEnumerator DoTask(IProgressPromise<float, bool> promise)
		{
			int n = 50;
			for (int i = 0; i < n; i++)
			{
				promise.UpdateProgress((float)i / (float)n);
				yield return new WaitForSeconds(0.1f);
			}
			promise.SetResult(result: true);
		}
	}
}
