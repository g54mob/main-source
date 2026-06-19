using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Loxodon.Framework.Asynchronous;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class TaskToCoroutineExample : MonoBehaviour
	{
		private IEnumerator Start()
		{
			Task task = Task.Run(delegate
			{
				for (int i = 0; i < 5; i++)
				{
					try
					{
						Thread.Sleep(200);
					}
					catch (Exception)
					{
					}
					Debug.LogFormat("Task ThreadId:{0}", Thread.CurrentThread.ManagedThreadId);
				}
			});
			yield return task.AsCoroutine();
			Debug.LogFormat("Task End,Current Thread ID:{0}", Thread.CurrentThread.ManagedThreadId);
			yield return Task.Delay(1000).AsCoroutine();
			Debug.LogFormat("Delay End");
		}
	}
}
