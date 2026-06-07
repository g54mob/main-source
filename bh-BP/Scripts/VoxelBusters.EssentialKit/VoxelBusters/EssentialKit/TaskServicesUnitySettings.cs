using System;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class TaskServicesUnitySettings : SettingsPropertyGroup
	{
		public TaskServicesUnitySettings(bool isEnabled = true)
			: base(null, isEnabled: false)
		{
		}
	}
}
