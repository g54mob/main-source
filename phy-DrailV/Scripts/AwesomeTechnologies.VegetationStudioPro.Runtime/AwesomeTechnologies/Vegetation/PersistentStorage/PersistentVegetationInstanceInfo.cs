using System;
using System.Collections.Generic;

namespace AwesomeTechnologies.Vegetation.PersistentStorage
{
	[Serializable]
	public class PersistentVegetationInstanceInfo
	{
		public string VegetationItemID;

		public int Count;

		public List<SourceCount> SourceCountList = new List<SourceCount>();

		public void AddSourceCountList(List<SourceCount> sourceCountList)
		{
			for (int i = 0; i <= sourceCountList.Count - 1; i++)
			{
				AddSourceCount(sourceCountList[i]);
			}
		}

		public void AddSourceCount(SourceCount sourceCount)
		{
			SourceCount sourceCount2 = GetSourceCount(sourceCount.VegetationSourceID);
			if (sourceCount2 == null)
			{
				sourceCount2 = new SourceCount
				{
					VegetationSourceID = sourceCount.VegetationSourceID
				};
				SourceCountList.Add(sourceCount2);
			}
			sourceCount2.Count += sourceCount.Count;
		}

		private SourceCount GetSourceCount(byte vegetationSourceID)
		{
			for (int i = 0; i <= SourceCountList.Count - 1; i++)
			{
				if (SourceCountList[i].VegetationSourceID == vegetationSourceID)
				{
					return SourceCountList[i];
				}
			}
			return null;
		}
	}
}
