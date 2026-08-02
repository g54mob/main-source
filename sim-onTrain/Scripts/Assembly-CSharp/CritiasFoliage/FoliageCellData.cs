using System.Collections.Generic;
using UnityEngine;

namespace CritiasFoliage
{
	public class FoliageCellData
	{
		public Bounds m_Bounds;

		public Bounds m_BoundsExtended;

		public FoliageCell m_Position;

		public Dictionary<int, Dictionary<string, List<FoliageInstance>>> m_TypeHashLocationsEditor = new Dictionary<int, Dictionary<string, List<FoliageInstance>>>();

		public Dictionary<int, FoliageCellSubdividedData> m_FoliageDataSubdivided = new Dictionary<int, FoliageCellSubdividedData>();
	}
}
