using UnityEngine;

namespace CritiasFoliage
{
	public class FoliageCellSubdividedDataRuntime
	{
		public Bounds m_Bounds;

		public FoliageCell m_Position;

		public FoliageKeyValuePair<int, FoliageTuple<Matrix4x4[][]>>[] m_TypeHashLocationsRuntime;
	}
}
