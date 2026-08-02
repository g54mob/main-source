using UnityEngine;

namespace CritiasFoliage
{
	public class FoliageCellDataRuntime
	{
		public Bounds m_Bounds;

		public FoliageCell m_Position;

		public FoliageKeyValuePair<int, FoliageTuple<FoliageInstance[]>>[] m_TypeHashLocationsRuntime;

		public FoliageKeyValuePair<int, FoliageCellSubdividedDataRuntime>[] m_FoliageDataSubdivided;
	}
}
