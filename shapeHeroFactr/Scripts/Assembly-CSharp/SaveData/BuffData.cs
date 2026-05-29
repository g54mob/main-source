using System;
using System.Collections.Generic;

namespace SaveData
{
	[Serializable]
	public class BuffData
	{
		public List<eArchiveCategory> sourceCategories;

		public List<string> sourceIds;

		public List<float> values;

		public List<bool> persistences;

		public int ListCount => 0;

		public float GetPoint => 0f;

		public void AddBuff(eArchiveCategory category, string id, float value, bool persistence)
		{
		}

		public void RemoveOneWave(eArchiveCategory categoryFilter = eArchiveCategory.None)
		{
		}

		public void RemoveBySrouceCategory(eArchiveCategory category)
		{
		}

		private void RemoveMultiIndex(List<int> removeIdx)
		{
		}
	}
}
