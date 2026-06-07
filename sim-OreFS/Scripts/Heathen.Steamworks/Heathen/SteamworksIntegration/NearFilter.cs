using System;

namespace Heathen.SteamworksIntegration
{
	[Serializable]
	public struct NearFilter : IEquatable<NearFilter>, IComparable<NearFilter>
	{
		public string key;

		public int value;

		public readonly int CompareTo(NearFilter other)
		{
			if (key.CompareTo(other.key) != 0)
			{
				return key.CompareTo(other.key);
			}
			return value.CompareTo(other.value);
		}

		public readonly bool Equals(NearFilter other)
		{
			if (key.Equals(other.key))
			{
				return value.Equals(other.value);
			}
			return false;
		}

		public override readonly bool Equals(object obj)
		{
			if (obj.GetType() == typeof(NearFilter))
			{
				return this == (NearFilter)obj;
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

		public static bool operator ==(NearFilter l, NearFilter r)
		{
			if (l.key == r.key)
			{
				return l.value == r.value;
			}
			return false;
		}

		public static bool operator !=(NearFilter l, NearFilter r)
		{
			if (!(l.key != r.key))
			{
				return l.value != r.value;
			}
			return true;
		}
	}
}
