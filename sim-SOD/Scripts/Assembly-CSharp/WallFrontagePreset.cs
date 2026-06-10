using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "wallfrontage_data", menuName = "Database/Decor/Wall Frontage Preset")]
public class WallFrontagePreset : SoCustomComparison
{
	[Header("Visuals")]
	public GameObject gameObject;

	[Tooltip("If true this will seach for identical furniture in a room to batch with")]
	public bool allowStaticBatching;

	[Tooltip("Can this feature a rainy window texture?")]
	public bool isRainyWindow;

	[EnableIf("isRainyWindow")]
	[Tooltip("The non-rainy window material")]
	public Material regularGlass;

	[Tooltip("The rainy window material")]
	[EnableIf("isRainyWindow")]
	public Material rainyGlass;

	[Tooltip("If true use across all design styles")]
	[Header("Decor Settings")]
	public bool universalDesignStyle;

	public List<DesignStylePreset> designStyles;

	[Space(7f)]
	public bool inheritColouringFromDecor;

	[Tooltip("If true the same material colours will be shared over all instances of this furniture for the room")]
	public FurniturePreset.ShareColours shareColours;

	public List<MaterialGroupPreset.MaterialVariation> variations;

	[Header("Interactables")]
	[Tooltip("What interatables will be instanced on this? These won't be spawned but created and searched for within the furniture prefab")]
	public List<FurniturePreset.IntegratedInteractable> integratedInteractables;

	[Header("Classes")]
	public List<WallFrontageClass> classes;
}
