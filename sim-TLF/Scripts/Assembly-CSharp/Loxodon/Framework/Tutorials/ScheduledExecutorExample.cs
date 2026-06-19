using Loxodon.Framework.Execution;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class ScheduledExecutorExample : MonoBehaviour
	{
		private IScheduledExecutor scheduled;

		private void Start()
		{
			scheduled = new ThreadScheduledExecutor();
			scheduled.Start();
			scheduled.ScheduleAtFixedRate(delegate
			{
				Debug.Log("This is a test.");
			}, 1000L, 2000L);
		}

		private void OnDestroy()
		{
			if (scheduled != null)
			{
				scheduled.Stop();
				scheduled = null;
			}
		}
	}
}
