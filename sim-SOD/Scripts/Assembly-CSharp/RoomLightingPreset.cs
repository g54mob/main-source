using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "roomlighting_data", menuName = "Database/Room Lighting Preset")]
public class RoomLightingPreset : SoCustomComparison
{
	public enum StairwellLightRule
	{
		noStairwells = 0,
		onlyStairwells = 1,
		either = 2
	}

	public bool disable;

	[ReorderableList]
	[Header("Light Objects")]
	public List<InteractablePreset> lightObjects;

	public LightingPreset lightingPreset;

	[Header("Room Compatibility")]
	[ReorderableList]
	public List<RoomConfiguration> roomCompatibility;

	public int minimumRoomSize;

	public int maximumRoomSize;

	[Header("Building Compatibility")]
	public List<BuildingPreset> onlyAllowInBuildings;

	public List<BuildingPreset> banFromBuildings;

	public StairwellLightRule stairwellRule;

	[Header("Design Style Compatibility")]
	[ReorderableList]
	public List<DesignStylePreset> designStyleCompatibility;

	[Header("Ceiling Fan Compatibility")]
	[ReorderableList]
	public List<GameObject> ceilingFans;

	[Header("Misc.")]
	[Tooltip("How often these appear compared to others")]
	public int frequency;
}
