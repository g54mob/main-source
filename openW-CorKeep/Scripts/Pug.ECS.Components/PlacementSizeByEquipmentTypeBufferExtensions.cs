using System.Runtime.CompilerServices;
using PlayerEquipment;
using Unity.Entities;
using UnityEngine;

public static class PlacementSizeByEquipmentTypeBufferExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ref PlacementSizeByEquipmentTypeBuffer GetElementForEquipment(this DynamicBuffer<PlacementSizeByEquipmentTypeBuffer> buffer, EquipmentSlotType equipmentType)
	{
		switch (equipmentType)
		{
		case EquipmentSlotType.ShovelSlot:
			return ref buffer.ElementAt(0);
		case EquipmentSlotType.WaterCanSlot:
			return ref buffer.ElementAt(1);
		case EquipmentSlotType.HoeSlot:
			return ref buffer.ElementAt(2);
		case EquipmentSlotType.RoofingToolSlot:
			return ref buffer.ElementAt(3);
		case EquipmentSlotType.SeederSlot:
			return ref buffer.ElementAt(4);
		default:
			Debug.LogError($"{equipmentType} not found in PlacementSizeByEquipmentTypeBufferExtensions.GetElementForEquipment");
			return ref buffer.ElementAt(0);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool HasSizeVariationForEquipment(EquipmentSlotType equipmentType)
	{
		if (equipmentType != EquipmentSlotType.ShovelSlot && equipmentType != EquipmentSlotType.WaterCanSlot && equipmentType != EquipmentSlotType.HoeSlot && equipmentType != EquipmentSlotType.RoofingToolSlot)
		{
			return equipmentType == EquipmentSlotType.SeederSlot;
		}
		return true;
	}
}
