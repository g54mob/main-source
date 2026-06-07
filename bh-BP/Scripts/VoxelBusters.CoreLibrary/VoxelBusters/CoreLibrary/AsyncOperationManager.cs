using System.Collections.Generic;

namespace VoxelBusters.CoreLibrary
{
	internal static class AsyncOperationManager
	{
		[ClearOnReload]
		private static List<IAsyncOperationUpdateHandler> s_targets;

		public static void ScheduleUpdate(IAsyncOperationUpdateHandler target)
		{
		}

		public static void UnscheduleUpdate(IAsyncOperationUpdateHandler target)
		{
		}

		private static void Update()
		{
		}

		private static void EnsureInitialised()
		{
		}

		private static void UpdateTargets()
		{
		}
	}
}
