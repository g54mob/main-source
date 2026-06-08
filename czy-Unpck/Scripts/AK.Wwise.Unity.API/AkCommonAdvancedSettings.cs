using System;
using UnityEngine;

[Serializable]
public class AkCommonAdvancedSettings
{
	[Tooltip("Size of memory pool for I/O (for automatic streams). It is passed directly to AK::MemoryMgr::CreatePool(), after having been rounded down to a multiple of uGranularity.")]
	public uint m_IOMemorySize = 2097152u;

	[Tooltip("Targeted automatic stream buffer length (ms). When a stream reaches that buffering, it stops being scheduled for I/O except if the scheduler is idle.")]
	public float m_TargetAutoStreamBufferLengthMs = 380f;

	[Tooltip("If true the device attempts to reuse IO buffers that have already been streamed from disk. This is particularly useful when streaming small looping sounds. The drawback is a small CPU hit when allocating memory, and a slightly larger memory footprint in the StreamManager pool.")]
	public bool m_UseStreamCache;

	[Tooltip("Maximum number of bytes that can be \"pinned\" using AK::SoundEngine::PinEventInStreamCache() or AK::IAkStreamMgr::PinFileInCache()")]
	public uint m_MaximumPinnedBytesInCache = uint.MaxValue;

	[Tooltip("Set to true to enable AK::SoundEngine::PrepareGameSync usage.")]
	public bool m_EnableGameSyncPreparation;

	[Tooltip("Number of quanta ahead when continuous containers should instantiate a new voice before which next sounds should start playing. This look-ahead time allows I/O to occur, and is especially useful to reduce the latency of continuous containers with trigger rate or sample-accurate transitions.")]
	public uint m_ContinuousPlaybackLookAhead = 1u;

	[Tooltip("Size of the monitoring queue pool. This parameter is not used in Release build.")]
	public uint m_MonitorQueuePoolSize = 1048576u;

	[Tooltip("Amount of time to wait for hardware devices to trigger an audio interrupt. If there is no interrupt after that time, the sound engine will revert to silent mode and continue operating until the hardware finally comes back.")]
	public uint m_MaximumHardwareTimeoutMs = 1000u;

	[Tooltip("Debug setting: Enable checks for out-of-range (and NAN) floats in the processing code. Do not enable in any normal usage, this setting uses a lot of CPU. Will print error messages in the log if invalid values are found at various point in the pipeline. Contact AK Support with the new error messages for more information.")]
	public bool m_DebugOutOfRangeCheckEnabled;

	[Tooltip("Debug setting: Only used when bDebugOutOfRangeCheckEnabled is true. This defines the maximum values samples can have. Normal audio must be contained within +1/-1. This limit should be set higher to allow temporary or short excursions out of range. Default is 16.")]
	public float m_DebugOutOfRangeLimit = 16f;

	[Tooltip("The state of the \"in_bRenderAnyway\" argument passed to the AkSoundEngine.Suspend() function when the \"OnApplicationFocus\" Unity callback is received with \"false\" as its argument.")]
	public bool m_RenderDuringFocusLoss;

	[Tooltip("Sets the sub-folder underneath UnityEngine.Application.persistentDataPath that will be used as the SoundBank base path. This is useful when the Init.bnk needs to be downloaded. Setting this to an empty string uses the typical SoundBank base path resolution. Setting this to \".\" uses UnityEngine.Application.persistentDataPath.")]
	public string m_SoundBankPersistentDataPath;

	[Tooltip("Use Async Open in the low-level IO hook.")]
	public bool m_UseAsyncOpen;

	public virtual void CopyTo(AkDeviceSettings settings)
	{
		settings.uIOMemorySize = m_IOMemorySize;
		settings.fTargetAutoStmBufferLength = m_TargetAutoStreamBufferLengthMs;
		settings.bUseStreamCache = m_UseStreamCache;
		settings.uMaxCachePinnedBytes = m_MaximumPinnedBytesInCache;
	}

	public virtual void CopyTo(AkInitSettings settings)
	{
		settings.bEnableGameSyncPreparation = m_EnableGameSyncPreparation;
		settings.uContinuousPlaybackLookAhead = m_ContinuousPlaybackLookAhead;
		settings.uMonitorQueuePoolSize = m_MonitorQueuePoolSize;
		settings.uMaxHardwareTimeoutMs = m_MaximumHardwareTimeoutMs;
		settings.bDebugOutOfRangeCheckEnabled = m_DebugOutOfRangeCheckEnabled;
		settings.fDebugOutOfRangeLimit = m_DebugOutOfRangeLimit;
	}

	public virtual void CopyTo(AkPlatformInitSettings settings)
	{
	}

	public virtual void CopyTo(AkUnityPlatformSpecificSettings settings)
	{
	}
}
