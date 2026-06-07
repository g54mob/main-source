using System;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Flags]
	public enum FuselageType
	{
		Body = 1,
		Cone = 2,
		Inlet = 4,
		Hollow = 8,
		Glass = 0x10,
		HollowGlass = 0x18
	}
}
