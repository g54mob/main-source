using System.Collections;
using Loxodon.Framework.Asynchronous;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class AsyncResultCallbackExample : MonoBehaviour
	{
		private void Start()
		{
			AsyncResult asyncResult = new AsyncResult();
			asyncResult.Callbackable().OnCallback(delegate(IAsyncResult r)
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
			StartCoroutine(DoTask(asyncResult));
		}

		protected IEnumerator DoTask(IPromise promise)
		{
			yield return new WaitForSeconds(0.5f);
			promise.SetResult();
		}
	}
}
