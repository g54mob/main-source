using System;
using System.Collections.Generic;
using CTS.Core;

namespace CTS
{
	[Serializable]
	public struct StatsSaveStruct
	{
		public Dictionary<string, int> SavedStats;

		public static StatsSaveStruct CreateSaveStruct(List<PrestigeUIStatsSO> statsSO)
		{
			StatsSaveStruct result = new StatsSaveStruct
			{
				SavedStats = new Dictionary<string, int>()
			};
			for (int i = 0; i < statsSO.Count; i++)
			{
				if (!result.SavedStats.ContainsKey(statsSO[i].name))
				{
					result.SavedStats.Add(statsSO[i].name, statsSO[i].CurrentValue);
				}
			}
			return result;
		}

		public static StatsSaveStruct CreateFromSerializedDictionary(SerializableDictionary<string, int> dico)
		{
			StatsSaveStruct result = new StatsSaveStruct
			{
				SavedStats = new Dictionary<string, int>()
			};
			foreach (string key in dico.Keys)
			{
				result.SavedStats.Add(key, dico[key]);
			}
			return result;
		}

		public static SerializableDictionary<string, int> CreateFromSerializedDictionary(StatsSaveStruct save)
		{
			SerializableDictionary<string, int> serializableDictionary = new SerializableDictionary<string, int>();
			foreach (string key in save.SavedStats.Keys)
			{
				serializableDictionary.Add(key, save.SavedStats[key]);
			}
			return serializableDictionary;
		}
	}
}
