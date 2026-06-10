using System;
using System.Collections.Generic;

namespace NSMedieval
{
	internal class OptimizedTwitchNameCollection
	{
		private Dictionary<string, int> nameToIndex = new Dictionary<string, int>();

		private List<string> names = new List<string>();

		private Random rng = new Random();

		public int Count => names.Count;

		public bool AddName(string name)
		{
			if (name == null || nameToIndex.ContainsKey(name))
			{
				return false;
			}
			nameToIndex.Add(name, names.Count);
			names.Add(name);
			return true;
		}

		public bool RemoveName(string name)
		{
			if (name == null || !nameToIndex.TryGetValue(name, out var value))
			{
				return false;
			}
			List<string> list = names;
			string text = list[list.Count - 1];
			names[value] = text;
			nameToIndex[text] = value;
			nameToIndex.Remove(name);
			names.RemoveAt(names.Count - 1);
			return true;
		}

		public bool Contains(string name)
		{
			if (name == null)
			{
				return false;
			}
			return nameToIndex.ContainsKey(name);
		}

		public string GetRandomName()
		{
			if (names.Count == 0)
			{
				return null;
			}
			int index = rng.Next(0, names.Count);
			return names[index];
		}
	}
}
