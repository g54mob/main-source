using UnityEngine;

[CreateAssetMenu(fileName = "LandmarkAsset", menuName = "Flotsam/Landmarks/Assets/LandmarkAsset")]
public class LandmarkSO : ScriptableObject
{
	[Header("Prefabs")]
	public GameObject[] PrefabList;

	[Header("Settings")]
	public int Width;

	public int Length;

	public LandmarkCellType Type;

	public bool IsSalvagable;

	[ConditionalHide("IsSalvagable", true)]
	public CountedItemProperty ItemProperty;
}
