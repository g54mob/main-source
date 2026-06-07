using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tyd;

[Serializable]
public class RandomWordGenerator
{
	public Dictionary<string, float> StartingStrings = new Dictionary<string, float>();

	public Dictionary<string, HashSet<string>> IllegalStarts = new Dictionary<string, HashSet<string>>();

	public HashSet<string> IllegalEnds = new HashSet<string>();

	public Dictionary<string, Dictionary<string, float>> Nodes = new Dictionary<string, Dictionary<string, float>>();

	public static HashSet<string> Consonants = new HashSet<string>
	{
		"B", "C", "D", "F", "G", "H", "J", "K", "L", "M",
		"N", "P", "Q", "R", "S", "T", "V", "W", "X", "Z"
	};

	public static HashSet<string> BadEnds = new HashSet<string> { "B", "C", "G", "H", "J", "V", "W" };

	public RandomWordGenerator(TydDocument doc)
	{
		TydList child = doc.GetChild<TydList>("Starting", true);
		string[] array = child.GetChildValues().ToArray();
		for (int i = 0; i < array.Length; i += 2)
		{
			string key = array[i];
			float value = array[i + 1].ConvertToFloat("Starting value chance");
			StartingStrings[key] = value;
		}
		child = doc.GetChild<TydList>("IllegalStarts", true);
		array = child.GetChildValues().ToArray();
		for (int j = 0; j < array.Length; j++)
		{
			string key2 = array[j][0].ToString();
			string element = array[j][1].ToString();
			IllegalStarts.Append(key2, element);
		}
		child = doc.GetChild<TydList>("IllegalEnds", true);
		IllegalEnds.AddRange(child.GetChildValues());
		foreach (TydTable item in doc.Nodes.OfType<TydTable>())
		{
			string childValue = item.GetChildValue("Value");
			Dictionary<string, float> dictionary = (Nodes[childValue] = new Dictionary<string, float>());
			Dictionary<string, float> dictionary3 = dictionary;
			string[] array2 = item.GetChild<TydList>("Chances").GetChildValues().ToArray();
			float num = 0f;
			for (int k = 0; k < array2.Length; k += 2)
			{
				string text = array2[k];
				float num2 = array2[k + 1].ConvertToFloat("Chance from " + childValue + " -> " + text);
				num += num2;
				dictionary3[text] = num2;
			}
			for (int l = 0; l < array2.Length; l += 2)
			{
				dictionary3[array2[l]] /= num;
			}
		}
	}

	private static string PickRandom(Dictionary<string, float> l, float val)
	{
		float num = 0f;
		foreach (KeyValuePair<string, float> item in l)
		{
			num += item.Value;
			if (num >= val)
			{
				return item.Key;
			}
		}
		return "";
	}

	public string GenerateWord(Random rng, int min, int max)
	{
		StringBuilder stringBuilder = new StringBuilder();
		string text = PickRandom(StartingStrings, rng.NextFloat());
		string key = text;
		stringBuilder.Append(text);
		int num = 0;
		int num2 = (Consonants.Contains(text) ? 1 : (-1));
		while (stringBuilder.Length < max && num < max * 4)
		{
			num++;
			Dictionary<string, float> orNull = Nodes.GetOrNull(text);
			if (orNull == null)
			{
				if (stringBuilder.Length >= min)
				{
					break;
				}
				text = PickRandom(StartingStrings, rng.NextFloat());
				continue;
			}
			string text2 = PickRandom(orNull, rng.NextFloat());
			if (string.IsNullOrEmpty(text2))
			{
				if (stringBuilder.Length >= min)
				{
					break;
				}
				if (orNull.Count == 1)
				{
					text = PickRandom(StartingStrings, rng.NextFloat());
				}
			}
			else
			{
				HashSet<string> value;
				if ((stringBuilder.Length == 1 && IllegalStarts.TryGetValue(key, out value) && value.Contains(text2)) || (num2 == 2 && Consonants.Contains(text2)) || (num2 == -2 && !Consonants.Contains(text2)))
				{
					continue;
				}
				text = text2;
				stringBuilder.Append(text);
				if (Consonants.Contains(text))
				{
					if (num2 < 0)
					{
						num2 = 0;
					}
					num2++;
				}
				else
				{
					if (num2 > 0)
					{
						num2 = 0;
					}
					num2--;
				}
			}
		}
		string text3 = stringBuilder.ToString();
		if (text3.Length > 2 && IllegalEnds.Contains(text3.Substring(text3.Length - 2, 2)))
		{
			text3 = text3.Substring(0, text3.Length - 1);
		}
		if (text3.Length > 1 && BadEnds.Contains(text3[text3.Length - 1].ToString()))
		{
			text3 = text3.Substring(0, text3.Length - 1);
		}
		return text3;
	}
}
