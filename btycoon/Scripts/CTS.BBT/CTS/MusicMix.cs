using System;
using System.Collections.Generic;
using System.Linq;

namespace CTS
{
	public class MusicMix : IEquatable<MusicMix>
	{
		public EBarStyle[] _ponderation;

		public bool Equals(MusicMix other)
		{
			if (other == null)
			{
				return false;
			}
			if (_ponderation == null)
			{
				return other._ponderation == null;
			}
			if (other._ponderation.Length != _ponderation.Length)
			{
				return false;
			}
			return _ponderation.OrderBy((EBarStyle x) => x).SequenceEqual(other._ponderation.OrderBy((EBarStyle x) => x));
		}

		public override bool Equals(object obj)
		{
			if (obj is MusicMix other)
			{
				return Equals(other);
			}
			return false;
		}

		public Dictionary<EBarStyle, int> GetStyleDifferences(MusicMix other)
		{
			Dictionary<EBarStyle, int> dictionary = new Dictionary<EBarStyle, int>();
			EBarStyle[] ponderation = _ponderation;
			int val = ((ponderation != null) ? ponderation.Length : 0);
			EBarStyle[] ponderation2 = other._ponderation;
			int num = Math.Max(val, (ponderation2 != null) ? ponderation2.Length : 0);
			for (int i = 0; i < num; i++)
			{
				if (_ponderation != null && i < _ponderation.Length)
				{
					dictionary[_ponderation[i]] = dictionary.GetValueOrDefault(_ponderation[i], 0) + 1;
				}
				if (other._ponderation != null && i < other._ponderation.Length)
				{
					dictionary[other._ponderation[i]] = dictionary.GetValueOrDefault(other._ponderation[i], 0) - 1;
				}
			}
			List<EBarStyle> list = new List<EBarStyle>();
			foreach (KeyValuePair<EBarStyle, int> item in dictionary)
			{
				if (item.Value == 0)
				{
					list.Add(item.Key);
				}
			}
			foreach (EBarStyle item2 in list)
			{
				dictionary.Remove(item2);
			}
			return dictionary;
		}
	}
}
