using System;
using UnityEngine;

public class AkMacSettings : AkWwiseInitializationSettings.PlatformSettings
{
	[Serializable]
	public class PlatformAdvancedSettings : AkCommonAdvancedSettings
	{
		[Tooltip("Number of Apple Spatial Audio point sources to allocate for 3D audio use (each point source is a system audio object).")]
		public uint NumSpatialAudioPointSources;

		[Tooltip("Print debug information related to audio device initialization in the system log.")]
		public bool VerboseSystemOutput;

		public override void CopyTo(AkPlatformInitSettings settings)
		{
		}
	}

	[HideInInspector]
	public AkCommonUserSettings UserSettings;

	[HideInInspector]
	public PlatformAdvancedSettings AdvancedSettings;

	[HideInInspector]
	public AkCommonCommSettings CommsSettings;

	protected override AkCommonUserSettings GetUserSettings()
	{
		return null;
	}

	protected override AkCommonAdvancedSettings GetAdvancedSettings()
	{
		return null;
	}

	protected override AkCommonCommSettings GetCommsSettings()
	{
		return null;
	}
}
