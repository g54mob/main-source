using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "streettile_data", menuName = "Database/Street Tile Preset")]
public class StreetTilePreset : SoCustomComparison
{
	[Serializable]
	public class StreetSectionModel
	{
		public GameObject prefab;

		[Tooltip("When raindrops are disabled, use this material...")]
		public Material normalMaterial;

		[Tooltip("When raindrops are enabled, use this material...")]
		public Material rainMaterial;
	}

	public enum StreetSection
	{
		streetLong = 0,
		streetShort = 1,
		streetInsideCorner = 2,
		streetJunctionCorner = 3,
		streetOutsideCorner = 4,
		joinerLong = 5,
		joinerShort = 6
	}

	[Header("Setup")]
	public StreetSection sectionType;

	[ReorderableList]
	public List<StreetSectionModel> prefabList;
}
