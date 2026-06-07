using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class ApplicationSettings
	{
		[SerializeField]
		private DebugLogger.LogLevel m_logLevel;

		[SerializeField]
		[Tooltip("Stores the registration ids of this app.")]
		private RuntimePlatformConstantSet m_appStoreIds;

		[SerializeField]
		[Tooltip("Usage permission settings.")]
		private NativeFeatureUsagePermissionSettings m_usagePermissionSettings;

		[SerializeField]
		[Tooltip("Stores the registration ids of this app.")]
		private AdditionalPlatformSupportSettings m_additionalPlatformSupportSettings;

		public DebugLogger.LogLevel LogLevel => default(DebugLogger.LogLevel);

		public NativeFeatureUsagePermissionSettings UsagePermissionSettings => null;

		public ApplicationSettings(RuntimePlatformConstantSet appStoreIds = null, NativeFeatureUsagePermissionSettings usagePermissionSettings = null, DebugLogger.LogLevel logLevel = DebugLogger.LogLevel.Critical, AdditionalPlatformSupportSettings additionalPlatformSupportSettings = null)
		{
		}

		public string GetAppStoreIdForPlatform(RuntimePlatform platform)
		{
			return null;
		}

		public string GetAppStoreIdForActivePlatform()
		{
			return null;
		}

		public string GetAppStoreIdForActiveOrSimulationPlatform()
		{
			return null;
		}

		public bool IsAndroidPcSupported()
		{
			return false;
		}
	}
}
