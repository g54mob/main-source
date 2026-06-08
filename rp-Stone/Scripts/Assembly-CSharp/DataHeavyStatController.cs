using System.Collections.Generic;
using UnityEngine;

public class DataHeavyStatController : MonoBehaviour
{
	public TextAsset[] balanceFiles;

	private Dictionary<string, string> filesByItem = new Dictionary<string, string>();

	private Dictionary<string, Dictionary<string, DataHeavyStat>> statsPerItem = new Dictionary<string, Dictionary<string, DataHeavyStat>>();

	public static DataHeavyStatController singleton { get; private set; }

	public DataHeavyStat GetStat(string itemId, string statId)
	{
		if (statsPerItem.ContainsKey(itemId))
		{
			Dictionary<string, DataHeavyStat> dictionary = statsPerItem[itemId];
			if (dictionary.ContainsKey(statId))
			{
				return dictionary[statId];
			}
			DataHeavyStat dataHeavyStat = new DataHeavyStat();
			dataHeavyStat.itemId = itemId;
			dataHeavyStat.statId = statId;
			string sjson = filesByItem[itemId];
			dataHeavyStat.data = SlimJson.ParseArray(sjson, statId, Utils.ParseFloat);
			dictionary.Add(statId, dataHeavyStat);
			return dataHeavyStat;
		}
		Utils.LogErrorIfEditor("Could not find data-heavy stats file for item " + itemId + " (statId = " + statId + ")");
		return null;
	}

	private void LoadBalanceFile(string sjson)
	{
		string key = SlimJson.Parse(sjson, "id");
		filesByItem.Add(key, sjson);
		statsPerItem.Add(key, new Dictionary<string, DataHeavyStat>());
	}

	private void Load()
	{
		for (int i = 0; i < balanceFiles.Length; i++)
		{
			if (balanceFiles[i] != null)
			{
				LoadBalanceFile(balanceFiles[i].text);
			}
		}
	}

	private void Awake()
	{
		singleton = this;
		Load();
	}
}
