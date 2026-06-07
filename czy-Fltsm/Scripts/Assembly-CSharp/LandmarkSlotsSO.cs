using UnityEngine;

[CreateAssetMenu(fileName = "LandmarkSlotsAsset", menuName = "Flotsam/Landmarks/Assets/SlotsAsset")]
public class LandmarkSlotsSO : ScriptableObject
{
	public LandmarkSlotsType LandmarkSlotsType;

	public LandmarkSlotSO[] SlotTypes;
}
