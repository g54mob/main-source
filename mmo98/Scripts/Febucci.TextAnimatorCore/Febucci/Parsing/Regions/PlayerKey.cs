using System;

namespace Febucci.Parsing.Regions
{
	internal readonly struct PlayerKey : IEquatable<PlayerKey>
	{
		public readonly string tagId;

		public readonly RegionParameters parameters;

		public PlayerKey(string tagId, RegionParameters parameters)
		{
			this.tagId = tagId;
			this.parameters = parameters;
		}

		public bool Equals(PlayerKey other)
		{
			if (tagId != other.tagId)
			{
				return false;
			}
			if (parameters == null && other.parameters == null)
			{
				return true;
			}
			if (parameters == null || other.parameters == null)
			{
				return false;
			}
			return parameters.Equals(other.parameters);
		}

		public override bool Equals(object obj)
		{
			if (obj is PlayerKey other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ((tagId?.GetHashCode() ?? 0) * 397) ^ (parameters?.GetHashCode() ?? 0);
		}
	}
}
