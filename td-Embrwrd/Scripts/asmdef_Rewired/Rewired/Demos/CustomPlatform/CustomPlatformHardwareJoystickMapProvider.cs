using System;
using System.Collections.Generic;
using Rewired.Data.Mapping;
using Rewired.Platforms.Custom;

namespace Rewired.Demos.CustomPlatform
{
	[Serializable]
	public class CustomPlatformHardwareJoystickMapProvider : IHardwareJoystickMapCustomPlatformMapProvider
	{
		[Serializable]
		public class PlatformDataSet
		{
			public CustomPlatformType platformType;

			public CustomPlatformHardwareJoystickMapPlatformDataSet dataSet;
		}

		public List<PlatformDataSet> platformJoystickDataSets;

		public HardwareJoystickMap.Platform GetPlatformMap(int customPlatformId, Guid hardwareTypeGuid)
		{
			return null;
		}

		private CustomPlatformHardwareJoystickMapPlatformDataSet GetPlatformDataSet(int customPlatformId)
		{
			return null;
		}

		private static HardwareJoystickMap.Platform GetPlatformMap(CustomPlatformHardwareJoystickMapPlatformDataSet platformDataSet, Guid hardwareTypeGuid)
		{
			return null;
		}
	}
}
