using UnityEngine;

namespace JBooth.MicroSplat
{
	[ExecuteInEditMode]
	public class MicroSplatUseInstanceNormal : MonoBehaviour
	{
		private MicroSplatTerrain mst;

		private void LateUpdate()
		{
			if (mst == null)
			{
				mst = GetComponent<MicroSplatTerrain>();
			}
			if (mst != null && mst.blendMatInstance != null)
			{
				mst.blendMatInstance.SetTexture("_PerPixelNormal", mst.terrain.normalmapTexture);
			}
		}
	}
}
