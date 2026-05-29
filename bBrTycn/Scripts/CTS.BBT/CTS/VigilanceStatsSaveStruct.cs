using System;
using System.Collections.Generic;

namespace CTS
{
	[Serializable]
	public struct VigilanceStatsSaveStruct
	{
		[Serializable]
		public struct VigilanceElementStats
		{
			public int Current;

			public int[] Last;
		}

		public Dictionary<string, VigilanceElementStats> SavedStats;

		public static VigilanceStatsSaveStruct CreateSaveStruct(List<PrestigeUIStatsSO> statsSO)
		{
			VigilanceStatsSaveStruct result = new VigilanceStatsSaveStruct
			{
				SavedStats = new Dictionary<string, VigilanceElementStats>()
			};
			for (int i = 0; i < statsSO.Count; i++)
			{
				if (!result.SavedStats.ContainsKey(statsSO[i].name))
				{
					result.SavedStats.Add(statsSO[i].name, new VigilanceElementStats
					{
						Current = statsSO[i].CurrentValue,
						Last = statsSO[i].LastMounthValues.ToArray()
					});
				}
			}
			return result;
		}
	}
}
