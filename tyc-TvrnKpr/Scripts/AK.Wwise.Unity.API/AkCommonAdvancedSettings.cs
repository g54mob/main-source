using System;
using UnityEngine;

[Serializable]
public class AkCommonAdvancedSettings
{
	[Tooltip("Size of memory pool for I/O (for automatic streams). It is rounded down to a multiple of uGranularity and then passed directly to AK::MemoryMgr::CreatePool().")]
	public uint m_IOMemorySize;

	[Tooltip("Targeted automatic stream buffer length (ms). When a stream reaches that buffering, it stops being scheduled for I/O except if the scheduler is idle.")]
	public float m_TargetAutoStreamBufferLengthMs;

	[Tooltip("If true the device attempts to reuse IO buffers that have already been streamed from disk. This is particularly useful when streaming small looping sounds. The drawback is a small CPU hit when allocating memory, and a slightly larger memory footprint in the StreamManager pool.")]
	public bool m_UseStreamCache;

	[Tooltip("Default settings for loading banks.This setting can be overriden by each bank.")]
	public bool m_LoadBankAsynchronously;

	[Tooltip("Maximum number of bytes that can be \"pinned\" using AK::SoundEngine::PinEventInStreamCache() or AK::IAkStreamMgr::PinFileInCache()")]
	public uint m_MaximumPinnedBytesInCache;

	[Tooltip("Set to true to enable AK::SoundEngine::PrepareGameSync usage.")]
	public bool m_EnableGameSyncPreparation;

	[Tooltip("Number of quanta ahead when continuous containers instantiate a new voice before the following sounds start playing. This look-ahead time allows I/O to occur, and is especially useful to reduce the latency of continuous containers with trigger rate or sample-accurate transitions.")]
	public uint m_ContinuousPlaybackLookAhead;

	[Tooltip("Size of the monitoring queue pool. This parameter is ignored in Release build.")]
	public uint m_MonitorQueuePoolSize;

	[Tooltip("Time (in milliseconds) to wait to wait for hardware devices to trigger an audio interrupt. If there is no interrupt after that time, the sound engine reverts to silent mode and continues operating until the hardware responds.")]
	public uint m_MaximumHardwareTimeoutMs;

	[Tooltip("Debug setting: Enable checks for out-of-range (and NAN) floats in the processing code. Do not enable in any normal usage because this setting uses a lot of CPU. It prints error messages in the log if invalid values are found at various points in the pipeline. Contact AK Support with the new error messages for more information.")]
	public bool m_DebugOutOfRangeCheckEnabled;

	[Tooltip("Debug setting: Only used when bDebugOutOfRangeCheckEnabled is true. This defines the maximum values samples can have. Normal audio must be contained within +1/-1. Set this limit to a value greater than 1 to allow temporary or short excursions out of range. The default value is 16.")]
	public float m_DebugOutOfRangeLimit;

	[Tooltip("Whether to suspend the Wwise SoundEngine when the application loses focus.")]
	public bool m_SuspendAudioDuringFocusLoss;

	[Tooltip("Only used when \"Suspend Audio During Focus Loss\" is enabled. The state of the \"in_bRenderAnyway\" argument passed to the AkUnitySoundEngine.Suspend() function when the \"OnApplicationFocus\" Unity callback is received with \"false\" as its argument.")]
	public bool m_RenderDuringFocusLoss;

	[Tooltip("Sets the sub-folder underneath UnityEngine.Application.persistentDataPath that will be used as the SoundBank base path. This is useful when the Init.bnk needs to be downloaded. Setting this to an empty string uses the typical SoundBank base path resolution. Setting this to \".\" uses UnityEngine.Application.persistentDataPath.")]
	public string m_SoundBankPersistentDataPath;

	[Tooltip("Configures whether sub-folders are created in output folders. This needs to match the \"Create sub-folders for generated files\" SoundBank setting in Wwise Authoring.")]
	public bool m_UseSubFoldersForGeneratedFiles;

	[Tooltip("Initial size of SBA portion of the Primary Memory Arena.")]
	public uint m_MemoryPrimarySbaInitSize;

	[Tooltip("Initial size of TLSF portion of the Primary Memory Arena.")]
	public uint m_MemoryPrimaryTlsfInitSize;

	[Tooltip("Size of each secondary span initialized for TLSF portion of the Primary Memory Arena.")]
	public uint m_MemoryPrimaryTlsfSpanSize;

	[Tooltip("Maximum amount of memory will be reserved for the Primary Memory Arena. A value of 0 will indicate no limit.")]
	public uint m_MemoryPrimaryReservedLimit;

	[Tooltip("Minimum size of allocations to be considered 'Huge' for the Primary Memory Arena. Huge allocations are put into standalone spans, separate from the TLSF spans")]
	public uint m_MemoryPrimaryAllocSizeHuge;

	[Tooltip("Initial size of TLSF portion of the Media Memory Arena.")]
	public uint m_MemoryMediaTlsfInitSize;

	[Tooltip("Size of each secondary span initialized for TLSF portion of the Media Memory Arena.")]
	public uint m_MemoryMediaTlsfSpanSize;

	[Tooltip("Maximum amount of memory will be reserved for the Media Memory Arena. A value of 0 will indicate no limit.")]
	public uint m_MemoryMediaReservedLimit;

	[Tooltip("Minimum size of allocations to be considered 'Huge' for the Media Memory Arena. Huge allocations are put into standalone spans, separate from the TLSF spans")]
	public uint m_MemoryMediaAllocSizeHuge;

	[Tooltip("Memory allocator debug level. For use under Audiokinetic Support supervision.")]
	public uint m_MemoryDebugLevel;

	public virtual void CopyTo(AkDeviceSettings settings)
	{
	}

	public virtual void CopyTo(AkInitSettings settings)
	{
	}

	public virtual void CopyTo(AkPlatformInitSettings settings)
	{
	}
}
