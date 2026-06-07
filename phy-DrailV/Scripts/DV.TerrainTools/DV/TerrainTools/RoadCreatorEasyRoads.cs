using UnityEngine;

namespace DV.TerrainTools
{
	[ExecuteInEditMode]
	public class RoadCreatorEasyRoads : RoadTool
	{
		public Material cloneSurfaceMaterial;

		public float roadWidth = 0.1f;

		public float minIndent = 3f;

		[HideInInspector]
		public int version = 1;
	}
}
