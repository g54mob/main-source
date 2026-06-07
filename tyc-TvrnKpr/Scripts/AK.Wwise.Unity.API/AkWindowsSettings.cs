using System;
using UnityEngine;

public class AkWindowsSettings : AkWwiseInitializationSettings.PlatformSettings
{
	[Serializable]
	public class PlatformAdvancedSettings : AkCommonAdvancedSettings
	{
		[Tooltip("Maximum number of System Audio Objects to reserve. Other processes will not be able to use them. Default is 128.")]
		public uint MaxSystemAudioObjects;

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
