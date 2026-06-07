using System.Collections.Generic;

namespace AwesomeTechnologies.VegetationSystem
{
	public class BiomeSortOrderComparer : IComparer<VegetationPackagePro>
	{
		public int Compare(VegetationPackagePro x, VegetationPackagePro y)
		{
			if (x != null && y != null)
			{
				return x.BiomeSortOrder.CompareTo(y.BiomeSortOrder);
			}
			return 0;
		}
	}
}
