using System;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class SharingServicesUnitySettings : SettingsPropertyGroup
	{
		public SharingServicesUnitySettings(bool isEnabled = true)
			: base(null, isEnabled: false)
		{
		}
	}
}
