using System.Threading;
using System.Threading.Tasks;
using Loxodon.Framework.Asynchronous;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class AsyncAndAwaitSwitchThreadsExample : MonoBehaviour
	{
		private async void Start()
		{
			Debug.LogFormat("1. ThreadID:{0}", Thread.CurrentThread.ManagedThreadId);
			await new WaitForBackgroundThread();
			Debug.LogFormat("2.After the WaitForBackgroundThread.ThreadID:{0}", Thread.CurrentThread.ManagedThreadId);
			await new WaitForMainThread();
			Debug.LogFormat("3.After the WaitForMainThread.ThreadID:{0}", Thread.CurrentThread.ManagedThreadId);
			await Task.Delay(3000).ConfigureAwait(continueOnCapturedContext: false);
			Debug.LogFormat("4.After the Task.Delay.ThreadID:{0}", Thread.CurrentThread.ManagedThreadId);
			await new WaitForSeconds(1f);
			Debug.LogFormat("5.After the WaitForSeconds.ThreadID:{0}", Thread.CurrentThread.ManagedThreadId);
		}
	}
}
