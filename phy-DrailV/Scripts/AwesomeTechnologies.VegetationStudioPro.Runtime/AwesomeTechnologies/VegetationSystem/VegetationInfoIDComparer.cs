using System.Collections.Generic;

namespace AwesomeTechnologies.VegetationSystem
{
	public class VegetationInfoIDComparer : IComparer<string>
	{
		public List<VegetationItemInfoPro> VegetationInfoList;

		public int Compare(string a, string b)
		{
			int indexFromID = GetIndexFromID(a);
			int indexFromID2 = GetIndexFromID(b);
			if (indexFromID < 0 || indexFromID2 < 0)
			{
				return -1;
			}
			int vegetationType = (int)VegetationInfoList[indexFromID].VegetationType;
			int vegetationType2 = (int)VegetationInfoList[indexFromID2].VegetationType;
			return vegetationType2.CompareTo(vegetationType);
		}

		private int GetIndexFromID(string id)
		{
			for (int i = 0; i <= VegetationInfoList.Count - 1; i++)
			{
				if (VegetationInfoList[i].VegetationItemID == id)
				{
					return i;
				}
			}
			return -1;
		}
	}
}
