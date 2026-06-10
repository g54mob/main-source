using System;

namespace NSMedieval.Types
{
	[Flags]
	public enum EquipmentSlotType
	{
		None = 0,
		RightHand = 1,
		LeftHand = 2,
		Head = 4,
		Body = 8,
		BodyArmor = 0x10
	}
}
