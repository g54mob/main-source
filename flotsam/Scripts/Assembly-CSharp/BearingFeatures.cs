using System;

[Flags]
public enum BearingFeatures
{
	None = 0,
	Compass = 1,
	Marker = 2,
	Disabled = 0x8000
}
