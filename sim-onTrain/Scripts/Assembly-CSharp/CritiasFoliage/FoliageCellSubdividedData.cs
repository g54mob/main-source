using System.Collections.Generic;
using UnityEngine;

namespace CritiasFoliage
{
	public class FoliageCellSubdividedData
	{
		public Bounds m_Bounds;

		public FoliageCell m_Position;

		public Dictionary<int, Dictionary<string, List<FoliageInstance>>> m_TypeHashLocationsEditor = new Dictionary<int, Dictionary<string, List<FoliageInstance>>>();
	}
}
