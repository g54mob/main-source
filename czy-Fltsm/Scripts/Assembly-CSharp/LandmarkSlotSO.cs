using UnityEngine;

[CreateAssetMenu(fileName = "LandmarkSlotAsset", menuName = "Flotsam/Landmarks/Assets/SlotAsset")]
public class LandmarkSlotSO : ScriptableObject
{
	public GameObject[] Prefabs;

	public bool IsSalvageable = true;

	[ConditionalHide("_isSalvageable", true)]
	public CountedItemProperty ItemProperty;
}
