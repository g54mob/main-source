using System;

namespace Rewired.Platforms.Custom
{
	[Serializable]
	public class HardwareJoystickMapCustomPlatformMapSimpleBase : HardwareJoystickMapCustomPlatformMap<HardwareJoystickMapCustomPlatformMapSimpleBase.MatchingCriteria>
	{
		[Serializable]
		public new sealed class MatchingCriteria : HardwareJoystickMapCustomPlatformMap.MatchingCriteria
		{
			protected override object CreateInstance()
			{
				return null;
			}
		}

		protected override object CreateInstance()
		{
			return null;
		}
	}
}
