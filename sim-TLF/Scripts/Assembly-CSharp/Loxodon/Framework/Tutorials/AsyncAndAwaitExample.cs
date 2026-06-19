using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Loxodon.Framework.Asynchronous;
using Loxodon.Framework.Execution;
using UnityEngine;
using UnityEngine.Networking;

namespace Loxodon.Framework.Tutorials
{
	public class AsyncAndAwaitExample : MonoBehaviour
	{
		private async void Start()
		{
			await new WaitForSeconds(2f);
			Debug.Log("WaitForSeconds  End");
			await Task.Delay(1000);
			Debug.Log("Delay  End");
			UnityWebRequest unityWebRequest = await UnityWebRequest.Get("http://www.baidu.com").SendWebRequest();
			if (!unityWebRequest.isHttpError && !unityWebRequest.isNetworkError)
			{
				Debug.Log(unityWebRequest.downloadHandler.text);
			}
			int num = await Calculate();
			Debug.LogFormat("Calculate Result = {0} Calculate Task End,Current Thread ID:{1}", num, Thread.CurrentThread.ManagedThreadId);
			await new WaitForMainThread();
			Debug.LogFormat("Switch to the main thread,Current Thread ID:{0}", Thread.CurrentThread.ManagedThreadId);
			await new WaitForSecondsRealtime(1f);
			Debug.Log("WaitForSecondsRealtime  End");
			await DoTask(5);
			Debug.Log("DoTask End");
		}

		private IAsyncResult<int> Calculate()
		{
			return Executors.RunAsync(delegate
			{
				Debug.LogFormat("Calculate Task ThreadId:{0}", Thread.CurrentThread.ManagedThreadId);
				int num = 0;
				for (int i = 0; i < 20; i++)
				{
					num += i;
					try
					{
						Thread.Sleep(100);
					}
					catch (Exception)
					{
					}
				}
				return num;
			});
		}

		private IEnumerator DoTask(int n)
		{
			yield return new WaitForSeconds(1f);
			for (int i = 0; i < n; i++)
			{
				yield return null;
			}
		}
	}
}
