using System;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class UtilityUnitySettings : SettingsPropertyGroup
	{
		public UtilityUnitySettings(bool isEnabled = true)
			: base(null, isEnabled: false)
		{
		}
	}
}
