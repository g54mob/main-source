using System.Collections.Generic;

namespace AwesomeTechnologies.VegetationSystem.Biomes
{
	public class BiomeMaskSortOrderComparer : IComparer<PolygonBiomeMask>
	{
		public int Compare(PolygonBiomeMask x, PolygonBiomeMask y)
		{
			if (x != null && y != null)
			{
				return x.BiomeSortOrder.CompareTo(y.BiomeSortOrder);
			}
			return 0;
		}
	}
}
