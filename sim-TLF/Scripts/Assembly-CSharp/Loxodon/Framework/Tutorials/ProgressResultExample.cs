using System.Collections;
using System.Text;
using Loxodon.Framework.Asynchronous;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class ProgressResultExample : MonoBehaviour
	{
		protected IEnumerator Start()
		{
			ProgressResult<Progress, string> result = new ProgressResult<Progress, string>(cancelable: true);
			StartCoroutine(DoTask(result));
			while (!result.IsDone)
			{
				Debug.LogFormat("Percentage: {0}% ", result.Progress.Percentage);
				yield return null;
			}
			Debug.LogFormat("IsDone:{0} Result:{1}", result.IsDone, result.Result);
		}

		protected IEnumerator DoTask(IProgressPromise<Progress, string> promise)
		{
			int n = 50;
			Progress progress = new Progress
			{
				TotalBytes = n,
				bytes = 0
			};
			StringBuilder buf = new StringBuilder();
			for (int i = 0; i < n; i++)
			{
				if (promise.IsCancellationRequested)
				{
					promise.SetCancelled();
					yield break;
				}
				progress.bytes++;
				buf.Append(" ").Append(i);
				promise.UpdateProgress(progress);
				yield return new WaitForSeconds(0.01f);
			}
			promise.SetResult(buf.ToString());
		}
	}
}
