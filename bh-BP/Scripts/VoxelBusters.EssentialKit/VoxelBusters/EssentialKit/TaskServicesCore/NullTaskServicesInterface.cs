using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.TaskServicesCore
{
	internal class NullTaskServicesInterface : NativeFeatureInterfaceBase, INativeTaskServicesInterface, INativeFeatureInterface, INativeObject, IDisposable
	{
		public NullTaskServicesInterface()
			: base(isAvailable: false)
		{
		}

		private static void LogNotSupported()
		{
		}

		public void StartTaskWithoutInterruption(string taskId, Action onBackgroundProcessingQuotaWillExpire)
		{
		}

		public void CancelTask(string taskId)
		{
		}
	}
}
