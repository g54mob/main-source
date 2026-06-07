using UnityEngine;

namespace GPUInstancerPro.TerrainModule
{
	public class GPUIBakedDetailTextureModifier : MonoBehaviour
	{
		public GPUITerrainBuiltin terrainBuiltin;

		public void SetBakedDetailTexture0(Texture2D texture)
		{
			if (terrainBuiltin != null)
			{
				terrainBuiltin.SetBakedDetailTexture(0, texture);
			}
		}

		public void SetBakedDetailTexture1(Texture2D texture)
		{
			if (terrainBuiltin != null)
			{
				terrainBuiltin.SetBakedDetailTexture(1, texture);
			}
		}
	}
}
