using System;
using System.Runtime.CompilerServices;

namespace Aggro.Core
{
	public struct EntityKey : IEquatable<EntityKey>, IComparable<EntityKey>
	{
		public readonly int index;

		public readonly uint version;

		public static readonly EntityKey invalid = new EntityKey(0, 0u);

		public bool isValid
		{
			get
			{
				if (version != 0)
				{
					return index >= 0;
				}
				return false;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal EntityKey(int index, uint version)
		{
			this.index = index;
			this.version = version;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(EntityKey other)
		{
			if (index == other.index)
			{
				return version == other.version;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is EntityKey other)
			{
				return Equals(other);
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return HashCode.Combine(index, version);
		}

		public override string ToString()
		{
			return $"({index}, {version})";
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(EntityKey e1, EntityKey e2)
		{
			return e1.Equals(e2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(EntityKey e1, EntityKey e2)
		{
			return !(e1 == e2);
		}

		public int CompareTo(EntityKey other)
		{
			return index.CompareTo(other.index);
		}
	}
}
