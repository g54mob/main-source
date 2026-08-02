using UnityEngine;

namespace CritiasFoliage
{
	[ExecuteInEditMode]
	public class FoliageTerrainListener : MonoBehaviour
	{
		public FoliagePainter m_FoliagePainter;

		private void OnTerrainChanged(TerrainChangedFlags flags)
		{
			_ = flags & TerrainChangedFlags.Heightmap;
			_ = flags & TerrainChangedFlags.DelayedHeightmapUpdate;
		}
	}
}
