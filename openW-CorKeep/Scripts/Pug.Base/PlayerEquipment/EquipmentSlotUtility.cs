namespace PlayerEquipment
{
	public static class EquipmentSlotUtility
	{
		public static bool IsMeleeWeaponSlotWithSound(EquipmentSlotType slotType)
		{
			if (slotType != EquipmentSlotType.MeleeWeaponSlot && slotType != EquipmentSlotType.ShovelSlot && slotType != EquipmentSlotType.HoeSlot && slotType != EquipmentSlotType.BugNet)
			{
				return slotType == EquipmentSlotType.BeamWeaponSlot;
			}
			return true;
		}

		public static bool IsWeaponSlot(EquipmentSlotType slotType)
		{
			if (slotType != EquipmentSlotType.MeleeWeaponSlot && slotType != EquipmentSlotType.RangeWeaponSlot)
			{
				return slotType == EquipmentSlotType.BeamWeaponSlot;
			}
			return true;
		}
	}
}
