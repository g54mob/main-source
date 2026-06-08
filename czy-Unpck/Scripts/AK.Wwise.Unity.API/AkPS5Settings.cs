using System;
using UnityEngine;

public class AkPS5Settings : AkWwiseInitializationSettings.PlatformSettings
{
	[Serializable]
	public class PlatformAdvancedSettings : AkCommonAdvancedSettings
	{
		[Tooltip("The number of ports to initialize the audioOut2Context with. May need to be increased if using many sinks")]
		public uint NumAudioOut2Ports = 16u;

		[Tooltip("The number of object ports to initialize the audioOut2Context with. Will need to be increased depending on sceAudio3D usage and configuration.")]
		public uint NumAudioOut2ObjectPorts;

		[Tooltip("se low latency mode for hardware codecs such as ATRAC9.  If true, decoding jobs are submitted at the beginning of the Wwise update and it will be necessary to wait for the result.")]
		public bool HwCodecLowLatencyMode = true;

		[Tooltip("Decode all Vorbis sources on PS5's audio co-processor, similar to ATRAC9. Please refer to the PS5-specific section of the Wwise SDK documentation for more information on advantages and limitations of hardware decoders.")]
		public bool VorbisHwAcceleration;

		public override void CopyTo(AkPlatformInitSettings settings)
		{
		}
	}

	[HideInInspector]
	public AkCommonUserSettings UserSettings = new AkCommonUserSettings
	{
		m_SamplesPerFrame = 512u
	};

	[HideInInspector]
	public PlatformAdvancedSettings AdvancedSettings = new PlatformAdvancedSettings
	{
		m_RenderDuringFocusLoss = true
	};

	[HideInInspector]
	public AkCommonCommSettings CommsSettings;

	public AkPS5Settings()
	{
		IgnorePropertyValue("UserSettings.m_SampleRate");
		SetUseGlobalPropertyValue("AdvancedSettings.m_RenderDuringFocusLoss", use: false);
	}

	protected override AkCommonUserSettings GetUserSettings()
	{
		return UserSettings;
	}

	protected override AkCommonAdvancedSettings GetAdvancedSettings()
	{
		return AdvancedSettings;
	}

	protected override AkCommonCommSettings GetCommsSettings()
	{
		return CommsSettings;
	}
}
