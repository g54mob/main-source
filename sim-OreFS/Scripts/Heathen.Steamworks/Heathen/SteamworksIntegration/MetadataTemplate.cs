using System;
using UnityEngine;

namespace Heathen.SteamworksIntegration
{
	[Serializable]
	public struct MetadataTemplate : IEquatable<MetadataTemplate>
	{
		[Tooltip("The key or field name to be used. names will not be duplicated, if you add another field of the same name it will overwrite, not duplicate")]
		public string key;

		[Tooltip("The value of the field to be applied, empty values are ignored")]
		public string value;

		public readonly bool Equals(MetadataTemplate other)
		{
			if (key == other.key)
			{
				return value == other.value;
			}
			return false;
		}

		public override readonly bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj.GetType() != typeof(MetadataTemplate))
			{
				return false;
			}
			return Equals((MetadataTemplate)obj);
		}

		public override readonly int GetHashCode()
		{
			return HashCode.Combine(key, value);
		}

		public override readonly string ToString()
		{
			return key + ":" + value;
		}

		public static bool operator ==(MetadataTemplate l, MetadataTemplate r)
		{
			if (l.key == r.key)
			{
				return l.value == r.value;
			}
			return false;
		}

		public static bool operator !=(MetadataTemplate l, MetadataTemplate r)
		{
			if (l.key != r.key)
			{
				return l.value != r.value;
			}
			return false;
		}
	}
}
