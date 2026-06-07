using UnityEngine;

namespace Assets.Scripts.Environment
{
	[CreateAssetMenu(fileName = "NewBuildingStyle", menuName = "Building Style", order = 1)]
	public class BuildingStyle : ScriptableObject
	{
		public string StyleName = "Default";

		[Range(3f, 12f)]
		public float StreetLevelHeight = 5f;

		[Range(2f, 12f)]
		public float TileWidth = 5f;

		[Range(2f, 12f)]
		public float TileHeight = 3f;

		public Vector2[] RoofProfile = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0f, 1f),
			new Vector2(1f, 1f),
			new Vector2(1f, 0f)
		};

		public Material StreetLevelMaterial;

		public Material FacadeMaterial;

		public Material RoofMaterial;

		public Material SideMaterial;

		public Material RoofTopMaterial;
	}
}
