using System;
using System.Collections;
using Loxodon.Framework.Asynchronous;
using Loxodon.Framework.Execution;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class InterceptableEnumeratorExample : MonoBehaviour
	{
		private IEnumerator Start()
		{
			yield return TestInterceptException();
		}

		protected IEnumerator TestInterceptException()
		{
			ProgressResult<float, bool> progressResult = new ProgressResult<float, bool>(cancelable: true);
			progressResult.Callbackable().OnProgressCallback(delegate(float p)
			{
				Debug.LogFormat("Progress:{0}%", p * 100f);
			});
			progressResult.Callbackable().OnCallback(delegate(IProgressResult<float, bool> r)
			{
				Debug.LogFormat("The task is finished. IsCancelled:{0} Result:{1} Exception:{2}", r.IsCancelled, r.Result, r.Exception);
			});
			InterceptableEnumerator interceptableEnumerator = InterceptableEnumerator.Create(DoTask(progressResult));
			interceptableEnumerator.RegisterCatchBlock(delegate(Exception e)
			{
				Debug.LogError(e);
			});
			interceptableEnumerator.RegisterFinallyBlock(delegate
			{
				Debug.Log("this is a finally block.");
			});
			StartCoroutine(interceptableEnumerator);
			yield break;
		}

		protected IEnumerator TestInterceptMoveNextMethod()
		{
			ProgressResult<float, bool> result = new ProgressResult<float, bool>(cancelable: true);
			result.Callbackable().OnProgressCallback(delegate(float p)
			{
				Debug.LogFormat("Progress:{0}%", p * 100f);
			});
			result.Callbackable().OnCallback(delegate(IProgressResult<float, bool> r)
			{
				Debug.LogFormat("The task is finished. IsCancelled:{0} Result:{1} Exception:{2}", r.IsCancelled, r.Result, r.Exception);
			});
			InterceptableEnumerator interceptableEnumerator = InterceptableEnumerator.Create(DoTask(result));
			interceptableEnumerator.RegisterConditionBlock(() => !result.IsCancellationRequested);
			interceptableEnumerator.RegisterFinallyBlock(delegate
			{
				Debug.Log("this is a finally block.");
			});
			StartCoroutine(interceptableEnumerator);
			yield return new WaitForSeconds(0.5f);
			result.Cancel();
		}

		protected IEnumerator DoTask(IProgressPromise<float, bool> promise)
		{
			int n = 50;
			for (int i = 0; i < n; i++)
			{
				promise.UpdateProgress((float)i / (float)n);
				yield return new WaitForSeconds(0.1f);
				if (i == 20)
				{
					throw new Exception("This is a test, not a bug.");
				}
			}
			promise.SetResult(result: true);
		}
	}
}
