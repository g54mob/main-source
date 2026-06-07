using System;
using System.Collections.Generic;
using Rewired.Data.Mapping;
using Rewired.Platforms.Custom;

namespace Rewired.Demos.CustomPlatform
{
	public sealed class MyPlatformHardwareJoystickMapPlatformMap : HardwareJoystickMapCustomPlatformMapSO
	{
		[Serializable]
		public class PlatformMapBase : HardwareJoystickMapCustomPlatformMap<MatchingCriteria>
		{
			protected override object CreateInstance()
			{
				return null;
			}
		}

		[Serializable]
		public sealed class PlatformMap : PlatformMapBase
		{
			public PlatformMapBase[] variants;

			public override IList<HardwareJoystickMap.Platform> GetVariants()
			{
				return null;
			}

			protected override object CreateInstance()
			{
				return null;
			}
		}

		[Serializable]
		public sealed class MatchingCriteria : HardwareJoystickMapCustomPlatformMap.MatchingCriteria
		{
			public uint vendorId;

			public uint productId;

			public override bool Matches(object customIdentifier)
			{
				return false;
			}

			protected override object CreateInstance()
			{
				return null;
			}

			protected override void DeepClone(object destination)
			{
			}
		}

		public PlatformMap platformMap;

		public override HardwareJoystickMap.Platform GetPlatformMap()
		{
			return null;
		}
	}
}
