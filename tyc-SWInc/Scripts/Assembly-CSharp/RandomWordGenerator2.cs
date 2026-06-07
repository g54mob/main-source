using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RandomWordGenerator2
{
	public class WordHolder
	{
		public Dictionary<char, Dictionary<char, float>>[] Map;

		public Dictionary<char, float> StartingLetters;

		public int InputWords;

		public WordHolder(string[] lines, int max)
		{
			Dictionary<char, Dictionary<char, int>>[] array = new Dictionary<char, Dictionary<char, int>>[max];
			for (int i = 0; i < max; i++)
			{
				array[i] = new Dictionary<char, Dictionary<char, int>>();
			}
			Dictionary<char, int> dictionary = new Dictionary<char, int>();
			foreach (string text in lines)
			{
				if (text.Length != max + 1)
				{
					continue;
				}
				InputWords++;
				dictionary.AddUp(text[0]);
				char key = text[0];
				for (int k = 1; k < text.Length; k++)
				{
					char c = text[k];
					array[k - 1].GetOrAdd(key, (char x) => new Dictionary<char, int>()).AddUp(c);
					key = c;
				}
				if (text.Length - 1 < max)
				{
					array[text.Length - 1].GetOrAdd(key, (char x) => new Dictionary<char, int>()).AddUp('/');
				}
			}
			int sum = dictionary.SumSafe((KeyValuePair<char, int> x) => x.Value);
			StartingLetters = dictionary.ToDictionary((KeyValuePair<char, int> x) => x.Key, (KeyValuePair<char, int> x) => (float)x.Value / (float)sum);
			Map = new Dictionary<char, Dictionary<char, float>>[max];
			for (int num = 0; num < max; num++)
			{
				Map[num] = new Dictionary<char, Dictionary<char, float>>();
				foreach (KeyValuePair<char, Dictionary<char, int>> item in array[num])
				{
					int s = item.Value.SumSafe((KeyValuePair<char, int> x) => x.Value);
					Map[num][item.Key] = item.Value.ToDictionary((KeyValuePair<char, int> x) => x.Key, (KeyValuePair<char, int> x) => (float)x.Value / (float)s);
				}
			}
		}

		private char PickRandom(Dictionary<char, float> l, float val)
		{
			float num = 0f;
			foreach (KeyValuePair<char, float> item in l)
			{
				num += item.Value;
				if (num >= val)
				{
					return item.Key;
				}
			}
			return '/';
		}

		public string GenerateWord(Random rng)
		{
			StringBuilder stringBuilder = new StringBuilder();
			char c = PickRandom(StartingLetters, rng.NextFloat());
			stringBuilder.Append(c);
			int num = (Consonants.Contains(c) ? 1 : (-1));
			int num2 = 0;
			while (stringBuilder.Length - 1 < Map.Length && num2 < Map.Length * 4)
			{
				num2++;
				Dictionary<char, float> orNull = Map[stringBuilder.Length - 1].GetOrNull(c);
				if (orNull == null)
				{
					break;
				}
				char c2 = PickRandom(orNull, rng.NextFloat());
				if (c2 == '/')
				{
					break;
				}
				if ((num == 2 && Consonants.Contains(c2)) || (num == -2 && !Consonants.Contains(c2)))
				{
					continue;
				}
				c = c2;
				stringBuilder.Append(c);
				if (Consonants.Contains(c))
				{
					if (num < 0)
					{
						num = 0;
					}
					num++;
				}
				else
				{
					if (num > 0)
					{
						num = 0;
					}
					num--;
				}
			}
			return stringBuilder.ToString();
		}
	}

	public List<WordHolder> Holders;

	public int Sum;

	public static HashSet<char> Consonants = new HashSet<char>
	{
		'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M',
		'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Z'
	};

	public RandomWordGenerator2(string[] lines)
	{
		Holders = new List<WordHolder>();
		int num = lines.MinSafeInt((string x) => x.Length) - 1;
		int num2 = lines.MaxSafeInt((string x) => x.Length) - 1;
		for (int num3 = num; num3 <= num2; num3++)
		{
			Holders.Add(new WordHolder(lines, num3));
		}
		Sum = lines.Length;
	}

	public string GenerateWord(Random rng)
	{
		int num = rng.Next(Sum);
		int num2 = 0;
		for (int i = 0; i < Holders.Count; i++)
		{
			num2 += Holders[i].InputWords;
			if (num2 >= num)
			{
				return Holders[i].GenerateWord(rng);
			}
		}
		return Holders.GetRandom(rng).GenerateWord(rng);
	}
}
