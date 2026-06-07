using UnityEngine;

namespace DV.WorldTools
{
	public class CopyTerrainLayers : MonoBehaviour
	{
		public Terrain copyFrom;

		public Terrain[] copyTo;

		[InspectorButton("Copy", true, true)]
		public bool copy;

		private void Copy()
		{
			Terrain[] array = copyTo;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].terrainData.terrainLayers = copyFrom.terrainData.terrainLayers;
			}
		}
	}
}
