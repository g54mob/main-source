using System;

namespace ProtoBuf
{
	public enum DataFormat
	{
		Default = 0,
		ZigZag = 1,
		TwosComplement = 2,
		FixedSize = 3,
		Group = 4,
		[Obsolete("This option is replaced with CompatibilityLevel, and is only used for Level200, where it changes this field to Level240", false)]
		WellKnown = 5
	}
}
