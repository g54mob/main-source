using System;
using UnityEngine;

[Serializable]
public class LandmarkSlot
{
	public Transform Transform;

	public LandmarkSlotsSO[] LandmarkPrefabSlots;

	public LandmarkSlotsType LandmarkSlotsType;
}
