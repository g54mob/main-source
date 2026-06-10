using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "materialgroup_data", menuName = "Database/Decor/Material Group Preset")]
public class MaterialGroupPreset : SoCustomComparison
{
	[Serializable]
	public class MaterialSettings
	{
		public DesignStylePreset designStyle;

		[Range(1f, 5f)]
		public int weighting;
	}

	public enum MaterialType
	{
		walls = 0,
		floor = 1,
		ceiling = 2,
		other = 3
	}

	public enum MaterialColour
	{
		anyPrimary = 0,
		anySecondary = 1,
		anyPrimaryOrNeutral = 2,
		anySecondaryOrNeutral = 3,
		any1 = 4,
		any2 = 5,
		any1OrNeutral = 6,
		any2OrNeutral = 7,
		any = 8,
		primary1 = 9,
		primary2 = 10,
		secondary1 = 11,
		secondary2 = 12,
		neutral = 13,
		wood = 14,
		none = 15,
		anyPrimaryOrSecondary = 16
	}

	[Serializable]
	public class MaterialVariation
	{
		public string name;

		public MaterialColour main;

		public MaterialColour colour1;

		public MaterialColour colour2;

		public MaterialColour colour3;
	}

	[Header("Material")]
	public Material material;

	[Header("Material Variations")]
	[ReorderableList]
	public List<MaterialVariation> variations;

	[Header("Material Properties")]
	[Range(0f, 1f)]
	public float concrete;

	[Range(0f, 1f)]
	public float plaster;

	[Range(0f, 1f)]
	public float wood;

	[Range(0f, 1f)]
	public float carpet;

	[Range(0f, 1f)]
	public float tile;

	[Range(0f, 1f)]
	public float metal;

	[Range(0f, 1f)]
	public float glass;

	[Range(0f, 1f)]
	public float fabric;

	[Tooltip("If this is assigned and the node has no floor, instead use this material.")]
	public MaterialGroupPreset noFloorReplacement;

	public bool allowFootprints;

	[Range(-1f, 1f)]
	public float affectFootprintDirt;

	[Tooltip("If this material is grubby, use this multiplier to add to footprint dirt")]
	public float grubFootprintDirtMultiplier;

	[Header("Suitability")]
	public MaterialType materialType;

	[Range(0f, 1f)]
	public float minimumWealth;

	[ReorderableList]
	public List<MaterialSettings> designStyles;

	[ReorderableList]
	[Tooltip("The furniture is only allowed in these room types")]
	public List<RoomTypeFilter> allowedRoomFilters;

	[Header("In-Game")]
	public bool purchasable;

	public int price;

	public Sprite decorSprite;
}
