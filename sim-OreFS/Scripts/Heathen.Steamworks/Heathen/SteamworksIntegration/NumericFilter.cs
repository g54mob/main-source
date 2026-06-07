using System;
using Steamworks;

namespace Heathen.SteamworksIntegration
{
	[Serializable]
	public struct NumericFilter : IEquatable<NumericFilter>, IComparable<NumericFilter>
	{
		public string key;

		public int value;

		public ELobbyComparison comparison;

		public readonly int CompareTo(NumericFilter other)
		{
			if (key.CompareTo(other.key) != 0)
			{
				return key.CompareTo(other.key);
			}
			return value.CompareTo(other.value);
		}

		public readonly bool Equals(NumericFilter other)
		{
			if (key.Equals(other.key))
			{
				return value.Equals(other.value);
			}
			return false;
		}

		public override readonly bool Equals(object obj)
		{
			if (obj.GetType() == typeof(NumericFilter))
			{
				return this == (NumericFilter)obj;
			}
			if (obj.GetType() == typeof(MetadataTemplate))
			{
				MetadataTemplate metadataTemplate = (MetadataTemplate)obj;
				if (int.TryParse(metadataTemplate.value, out var result))
				{
					if (key == metadataTemplate.key)
					{
						return value == result;
					}
					return false;
				}
				return false;
			}
			return false;
		}

		public override readonly int GetHashCode()
		{
			return key.GetHashCode() ^ value.GetHashCode();
		}

		public static bool operator ==(NumericFilter l, NumericFilter r)
		{
			if (l.key == r.key && l.value == r.value)
			{
				return l.comparison == r.comparison;
			}
			return false;
		}

		public static bool operator !=(NumericFilter l, NumericFilter r)
		{
			if (!(l.key != r.key) && l.value == r.value)
			{
				return l.comparison != r.comparison;
			}
			return true;
		}
	}
}
