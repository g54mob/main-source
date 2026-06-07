using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	public abstract class GPUIProceduralDetailObject : ScriptableObject
	{
		[SerializeField]
		public bool isReadTerrainDetails = true;

		public abstract void Execute(GPUITerrain gpuiTerrain, int detailLayer);
	}
}
