using System.Collections;

namespace VoxelBusters.CoreLibrary
{
	public static class Scheduler
	{
		[ClearOnReload]
		private static IScheduler s_scheduler;

		public static event Callback Update
		{
			add
			{
			}
			remove
			{
			}
		}

		public static void StartCoroutine(IEnumerator routine)
		{
		}

		public static void StopCoroutine(IEnumerator routine)
		{
		}

		public static void StopAllCoroutines()
		{
		}

		private static void EnsureInitialised()
		{
		}
	}
}
