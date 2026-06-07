using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class RandomNameGenerator
{
	[Serializable]
	public class RandomWord
	{
		public string Word;

		public int Chance;

		public RandomWord()
		{
		}

		public RandomWord(string word)
		{
			Word = word;
			Chance = 100;
		}

		public override string ToString()
		{
			return Word + ": " + Chance;
		}
	}

	private readonly string Start;

	private readonly Dictionary<string, string[]> Groups;

	private readonly Dictionary<string, string[]> Jumps;

	private readonly Dictionary<string, string[]> ForbiddenJumps = new Dictionary<string, string[]>();

	private Dictionary<string, RandomWord[]> Chances;

	public bool Replace;

	public byte FailCount;

	public RandomNameGenerator(string start, Dictionary<string, string[]> groups, Dictionary<string, string[]> jumps, Dictionary<string, string[]> forbiddenJumps, bool replace)
	{
		Start = start;
		Groups = groups;
		Chances = groups.ToDictionary((KeyValuePair<string, string[]> x) => x.Key, (KeyValuePair<string, string[]> x) => x.Value.SelectInPlace((string y) => new RandomWord(y)));
		Jumps = jumps;
		ForbiddenJumps = forbiddenJumps;
		Replace = replace;
	}

	public RandomNameGenerator()
	{
	}

	public RandomNameGenerator Clone()
	{
		return new RandomNameGenerator(Start, Groups.ToDictionary((KeyValuePair<string, string[]> x) => x.Key, (KeyValuePair<string, string[]> x) => x.Value), Jumps.ToDictionary((KeyValuePair<string, string[]> x) => x.Key, (KeyValuePair<string, string[]> x) => x.Value), ForbiddenJumps.ToDictionary((KeyValuePair<string, string[]> x) => x.Key, (KeyValuePair<string, string[]> x) => x.Value), Replace);
	}

	public void Uniqify()
	{
		foreach (string item in Groups.Keys.ToList())
		{
			Groups[item] = Groups[item].Distinct().ToArray();
		}
	}

	public void MergeWith(RandomNameGenerator rng)
	{
		foreach (KeyValuePair<string, string[]> forbiddenJump in rng.ForbiddenJumps)
		{
			if (ForbiddenJumps.ContainsKey(forbiddenJump.Key))
			{
				ForbiddenJumps[forbiddenJump.Key] = ForbiddenJumps[forbiddenJump.Key].Concat(forbiddenJump.Value).ToArray();
			}
			else
			{
				ForbiddenJumps.Add(forbiddenJump.Key, forbiddenJump.Value);
			}
		}
		foreach (KeyValuePair<string, string[]> jump in rng.Jumps)
		{
			if (Jumps.ContainsKey(jump.Key))
			{
				Jumps[jump.Key] = Jumps[jump.Key].Concat(jump.Value).ToArray();
			}
			else
			{
				Jumps.Add(jump.Key, jump.Value);
			}
		}
		foreach (KeyValuePair<string, string[]> group in rng.Groups)
		{
			if (Groups.ContainsKey(group.Key))
			{
				Groups[group.Key] = Groups[group.Key].Concat(group.Value).ToArray();
			}
			else
			{
				Groups.Add(group.Key, group.Value);
			}
			Chances[group.Key] = Groups[group.Key].SelectInPlace((string x) => new RandomWord(x));
		}
	}

	public static RandomNameGenerator Load(string[] lines)
	{
		Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
		Dictionary<string, string[]> dictionary2 = new Dictionary<string, string[]>();
		Dictionary<string, List<string>> dictionary3 = new Dictionary<string, List<string>>();
		string key = "";
		string text = null;
		bool replace = false;
		foreach (string text2 in lines)
		{
			if ("[REPLACE]".Equals(text2))
			{
				replace = true;
			}
			else if (text2.Length > 0 && text2[0] == '-')
			{
				string[] array = text2.Split('(');
				string text3 = array[0].Substring(1).Trim().ToUpper();
				int num = array[1].IndexOf(')');
				if (num < 0)
				{
					continue;
				}
				string[] array2 = ((num == 0) ? new string[0] : array[1].Substring(0, num).Split(',').SelectInPlace((string x) => x.Trim().ToUpper()));
				dictionary3[text3] = new List<string>();
				if (array2.Any((string x) => x.StartsWith("-")))
				{
					dictionary[text3] = array2.Where((string x) => !x.StartsWith("-")).ToArray();
					dictionary2[text3] = array2.WhereSelect((string x) => x.StartsWith("-"), (string x) => x.Substring(1)).ToArray();
				}
				else
				{
					dictionary[text3] = array2;
				}
				key = text3;
				if (text == null)
				{
					text = text3;
				}
			}
			else
			{
				dictionary3[key].Add(text2);
			}
		}
		return new RandomNameGenerator(text, dictionary3.ToDictionary((KeyValuePair<string, List<string>> x) => x.Key, (KeyValuePair<string, List<string>> y) => y.Value.ToArray()), dictionary, dictionary2, replace);
	}

	public void ErrorCheck()
	{
		foreach (string[] value2 in Jumps.Values)
		{
			foreach (string text in value2)
			{
				if (!"STOP".Equals(text) && !Groups.ContainsKey(text))
				{
					throw new Exception("Group '" + text + "' does not exist");
				}
			}
		}
		foreach (string[] value3 in ForbiddenJumps.Values)
		{
			foreach (string value in value3)
			{
				if ("STOP".Equals(value))
				{
					throw new Exception("Cannot forbid stop");
				}
			}
		}
	}

	private string GetValue(string group, System.Random rng)
	{
		RandomWord[] value;
		if (!Chances.TryGetValue(group, out value))
		{
			Debug.Log("Got invalid jump in name generator: " + group);
			return "";
		}
		if (value == null || value.Length == 0)
		{
			return "";
		}
		RandomWord randomWord = value[0];
		int chance = randomWord.Chance;
		int num = randomWord.Chance;
		float num2 = rng.NextFloat();
		for (int i = 1; i < value.Length; i++)
		{
			RandomWord randomWord2 = value[i];
			num = Mathf.Min(num, randomWord2.Chance);
			if (randomWord2.Chance >= chance)
			{
				float num3 = rng.NextFloat();
				if (randomWord2.Chance > chance || num3 > num2)
				{
					chance = randomWord2.Chance;
					num2 = num3;
					randomWord = randomWord2;
				}
			}
		}
		if (chance - num > 25)
		{
			for (int j = 0; j < value.Length; j++)
			{
				value[j].Chance = 100;
			}
		}
		randomWord.Chance--;
		if (randomWord.Chance <= 0)
		{
			for (int k = 0; k < value.Length; k++)
			{
				value[k].Chance += 100;
			}
		}
		return FunctionWord(randomWord.Word, rng);
	}

	public string FunctionWord(string word, System.Random rng)
	{
		if (word.StartsWith("/"))
		{
			string text = word.Substring(1);
			if (text.StartsWith("Random:"))
			{
				string text2 = text.Substring(7);
				return text2[rng.Next(0, text2.Length)].ToString();
			}
			if (text.Equals("Word"))
			{
				return GameData.GenerateWord(rng);
			}
			Debug.Log("Got nonexistent name generator function:" + word);
			return "";
		}
		return word;
	}

	public string GenerateName(System.Random rnd)
	{
		int num = 0;
		HashSet<string> forbidden = ((ForbiddenJumps.Count > 0) ? new HashSet<string>() : null);
		StringBuilder stringBuilder = new StringBuilder();
		string text = Start;
		while (text != null && num < Groups.Count && !"STOP".Equals(text))
		{
			stringBuilder.Append(GetValue(text, rnd));
			string[] value;
			if (forbidden != null && ForbiddenJumps.TryGetValue(text, out value))
			{
				forbidden.AddRange(value);
			}
			string[] value2;
			if (!Jumps.TryGetValue(text, out value2) || value2.Length == 0)
			{
				break;
			}
			HashSet<string> hashSet = forbidden;
			text = ((hashSet != null && hashSet.Count > 0) ? value2.GetRandomWhere((string x) => x == null || !forbidden.Contains(x)) : value2.GetRandom(rnd));
			num++;
		}
		return stringBuilder.ToString();
	}

	private string LongestInGroup(string group)
	{
		string text = "";
		RandomWord[] value;
		if (Chances.TryGetValue(group, out value))
		{
			foreach (RandomWord randomWord in value)
			{
				if (randomWord.Word.Length > text.Length)
				{
					text = randomWord.Word;
				}
			}
		}
		return text;
	}

	public string GetLongestName(string start = null, int length = 0, HashSet<string> forbidden = null)
	{
		string text = "";
		forbidden = forbidden ?? ((ForbiddenJumps.Count > 0) ? new HashSet<string>() : null);
		string text2 = start ?? Start;
		if (length < Groups.Count && !"STOP".Equals(text2))
		{
			string[] value;
			if (forbidden != null && ForbiddenJumps.TryGetValue(text2, out value))
			{
				forbidden.AddRange(value);
			}
			text += LongestInGroup(text2);
			string text3 = "";
			foreach (string item in Jumps.GetOrDefault(text2, Array.Empty<string>()).Distinct())
			{
				if (item != null && (forbidden == null || !forbidden.Contains(item)))
				{
					string longestName = GetLongestName(item, length + 1, (forbidden != null) ? forbidden.ToHashSet() : null);
					if (longestName.Length > text3.Length)
					{
						text3 = longestName;
					}
				}
			}
			text += text3;
		}
		return text;
	}
}
