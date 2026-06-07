using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.TaskServicesCore
{
	public interface INativeTaskServicesInterface : INativeFeatureInterface, INativeObject, IDisposable
	{
		void StartTaskWithoutInterruption(string taskId, Action onBackgroundProcessingQuotaWillExpire);

		void CancelTask(string taskId);
	}
}
