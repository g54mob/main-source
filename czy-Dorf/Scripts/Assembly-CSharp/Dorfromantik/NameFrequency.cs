using System;
using System.Collections.Generic;
using System.Linq;

namespace Dorfromantik
{
	public class NameFrequency
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<NameFrequency, int> _003C_003E9__6_0;

			internal int _003CSortSubNameFrequencies_003Eb__6_0(NameFrequency x)
			{
				return x.count;
			}
		}

		public string name;

		public int count;

		public int subNameCount;

		public List<NameFrequency> subNameFrequencies = new List<NameFrequency>();

		public Dictionary<string, NameFrequency> subNameFrequencyByName = new Dictionary<string, NameFrequency>();

		public void MergeWithSubNameFrequencies()
		{
			if (subNameFrequencies == null || subNameFrequencies.Count == 0)
			{
				return;
			}
			if (subNameFrequencies.Count == 1)
			{
				NameFrequency nameFrequency = subNameFrequencies[0];
				name = nameFrequency.name;
				subNameFrequencies = nameFrequency.subNameFrequencies;
				subNameFrequencyByName = nameFrequency.subNameFrequencyByName;
				MergeWithSubNameFrequencies();
			}
			else
			{
				if (subNameFrequencies.Count <= 1)
				{
					return;
				}
				foreach (NameFrequency subNameFrequency in subNameFrequencies)
				{
					subNameFrequency.MergeWithSubNameFrequencies();
				}
			}
		}

		public void SortSubNameFrequencies()
		{
			subNameCount = 0;
			foreach (NameFrequency subNameFrequency in subNameFrequencies)
			{
				subNameCount += subNameFrequency.count;
			}
			subNameFrequencies = Enumerable.ToList(Enumerable.OrderByDescending(subNameFrequencies, (NameFrequency x) => x.count));
			foreach (NameFrequency subNameFrequency2 in subNameFrequencies)
			{
				subNameFrequency2.SortSubNameFrequencies();
			}
		}

		public List<string> GetNameFrequencyLines()
		{
			List<string> list = new List<string>();
			if (count > 10)
			{
				list.Add($"{name.Replace(',', ' ')},{count},{subNameCount}");
				foreach (NameFrequency subNameFrequency in subNameFrequencies)
				{
					list.AddRange(subNameFrequency.GetNameFrequencyLines());
				}
			}
			return list;
		}
	}
}
