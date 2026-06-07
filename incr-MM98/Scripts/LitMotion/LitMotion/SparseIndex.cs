using System;

namespace LitMotion
{
	internal readonly struct SparseIndex : IEquatable<SparseIndex>
	{
		public int Index { get; }

		public int Version { get; }

		public SparseIndex(int index, int version)
		{
			Index = index;
			Version = version;
		}

		public override bool Equals(object obj)
		{
			if (obj is SparseIndex other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(SparseIndex other)
		{
			if (Index == other.Index)
			{
				return Version == other.Version;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Index, Version);
		}
	}
}
