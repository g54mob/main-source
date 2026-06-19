using System;
using System.Collections.Generic;
using PlayerEquipment;
using Pug.UnityExtensions;
using UnityEngine;

public class EquippedObjectAuthoring : MonoBehaviour
{
	[Serializable]
	public struct EquipmentSlotData
	{
		public EquipmentSlotType equipmentSlotType;

		public MonoBehaviour equipmentSlot;
	}

	[ArrayElementTitle("equipmentSlotType")]
	public List<EquipmentSlotData> equipmentSlots;

	public int equippedSlotIndex;

	public bool isHoldingOffHand;

	private void OnValidate()
	{
		if (equipmentSlots == null)
		{
			equipmentSlots = new List<EquipmentSlotData>();
		}
		Array values = Enum.GetValues(typeof(EquipmentSlotType));
		if (equipmentSlots.Count != values.Length)
		{
			equipmentSlots.Resize(default(EquipmentSlotData), values.Length);
		}
		int num = 0;
		foreach (EquipmentSlotType item in values)
		{
			EquipmentSlotData value = equipmentSlots[num];
			value.equipmentSlotType = item;
			equipmentSlots[num] = value;
			num++;
		}
	}
}
