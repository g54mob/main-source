using System;
using System.Collections.Generic;
using System.Linq;

public class HintTextGetter
{
	private Dictionary<int, Dictionary<int, Dictionary<int, string>>> hintTexts;

	public HintTextGetter(string filename)
	{
		hintTexts = new Dictionary<int, Dictionary<int, Dictionary<int, string>>>();
		List<string[]> list = ResourcesManager.GetCSV(filename).ToList();
		for (int i = 0; i < list.Count; i++)
		{
			string[] array = list[i];
			int key = int.Parse(array[0]);
			int key2 = int.Parse(array[1]);
			int key3 = int.Parse(array[2]);
			string value = array[3];
			if (!hintTexts.ContainsKey(key))
			{
				hintTexts[key] = new Dictionary<int, Dictionary<int, string>>();
			}
			if (!hintTexts[key].ContainsKey(key2))
			{
				hintTexts[key][key2] = new Dictionary<int, string>();
			}
			hintTexts[key][key2][key3] = value;
		}
	}

	public string GetHint(int level, int stage, int hintsGiven)
	{
		if (!hintTexts.ContainsKey(level))
		{
			throw new ArgumentException($"No hints for level={level}");
		}
		if (!hintTexts[level].ContainsKey(stage))
		{
			throw new ArgumentException($"No hints for level={level}, stage={stage}");
		}
		int key = hintsGiven;
		if (!hintTexts[level][stage].ContainsKey(hintsGiven))
		{
			int num = 0;
			foreach (int key2 in hintTexts[level][stage].Keys)
			{
				if (key2 > num)
				{
					num = key2;
				}
			}
			key = num;
		}
		return hintTexts[level][stage][key].Replace("\\\\n", "\n");
	}
}
