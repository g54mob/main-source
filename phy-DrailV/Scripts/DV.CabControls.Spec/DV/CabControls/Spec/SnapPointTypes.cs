using System;

namespace DV.CabControls.Spec
{
	[Flags]
	public enum SnapPointTypes
	{
		None = 0,
		Belt = 1,
		Coupler = 2,
		Hanger = 4,
		LongCylinder = 8,
		BatteryCharger = 0x10,
		StickyPad = 0x20
	}
}
