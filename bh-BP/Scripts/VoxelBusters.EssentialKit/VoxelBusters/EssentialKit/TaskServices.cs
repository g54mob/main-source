using System.Threading.Tasks;
using VoxelBusters.CoreLibrary;
using VoxelBusters.EssentialKit.TaskServicesCore;

namespace VoxelBusters.EssentialKit
{
	public static class TaskServices
	{
		[ClearOnReload]
		private static INativeTaskServicesInterface s_nativeInterface;

		public static TaskServicesUnitySettings UnitySettings { get; private set; }

		public static bool IsAvailable()
		{
			return false;
		}

		public static void Initialize(TaskServicesUnitySettings settings)
		{
		}

		public static Task AllowRunningApplicationInBackgroundUntilTaskCompletion(Task task, Callback onBackgroundProcessingQuotaWillExpireCallback = null)
		{
			return null;
		}

		public static Task<TResult> AllowRunningApplicationInBackgroundUntilTaskCompletion<TResult>(Task<TResult> task, Callback onBackgroundProcessingQuotaWillExpireCallback = null)
		{
			return null;
		}

		public static Task AllowRunningApplicationInBackgroundUntilCompletion(this Task task, Callback onBackgroundProcessingQuotaWillExpireCallback = null)
		{
			return null;
		}

		public static Task<TResult> AllowRunningApplicationInBackgroundUntilCompletion<TResult>(this Task<TResult> task, Callback onBackgroundProcessingQuotaWillExpireCallback = null)
		{
			return null;
		}

		private static string StartTaskWithoutInterruption(Callback onBackgroundProcessingQuotaWillExpireCallback)
		{
			return null;
		}
	}
}
