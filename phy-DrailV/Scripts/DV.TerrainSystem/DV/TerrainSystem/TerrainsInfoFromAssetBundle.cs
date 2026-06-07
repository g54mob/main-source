using UnityEngine;

namespace DV.TerrainSystem
{
	public class TerrainsInfoFromAssetBundle : ScriptableObject
	{
		public int version = 1;

		public float terrainSizeInWorld;

		public int numberOfTerrains;

		public int TerrainsPerAxis => (int)Mathf.Sqrt(numberOfTerrains);
	}
}
