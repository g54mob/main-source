using System.Collections.Generic;

namespace AwesomeTechnologies.VegetationSystem
{
	public class VegetationInfoComparer : IComparer<int>
	{
		public List<VegetationItemInfoPro> VegetationInfoList;

		public int Compare(int a, int b)
		{
			int vegetationType = (int)VegetationInfoList[a].VegetationType;
			int vegetationType2 = (int)VegetationInfoList[b].VegetationType;
			return vegetationType2.CompareTo(vegetationType);
		}
	}
}
