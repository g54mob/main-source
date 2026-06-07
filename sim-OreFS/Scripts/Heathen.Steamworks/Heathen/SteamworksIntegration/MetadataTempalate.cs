using System;

namespace Heathen.SteamworksIntegration
{
	[Obsolete("Please use MetadataTemplate")]
	public struct MetadataTempalate : IEquatable<MetadataTemplate>
	{
		public string key;

		public string value;

		public bool Equals(MetadataTemplate other)
		{
			if (key == other.key)
			{
				return value == other.value;
			}
			return false;
		}

		public static implicit operator MetadataTempalate(MetadataTemplate other)
		{
			return new MetadataTempalate
			{
				key = other.key,
				value = other.value
			};
		}

		public static implicit operator MetadataTemplate(MetadataTempalate other)
		{
			return new MetadataTemplate
			{
				key = other.key,
				value = other.value
			};
		}
	}
}
