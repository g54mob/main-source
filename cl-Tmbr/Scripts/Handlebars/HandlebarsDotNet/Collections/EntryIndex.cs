using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace HandlebarsDotNet.Collections
{
	[DebuggerDisplay("{Index}")]
	public readonly struct EntryIndex<TKey> : IEquatable<EntryIndex<TKey>>
	{
		public readonly int Index;

		public readonly byte Version;

		public readonly bool IsNotEmpty;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal EntryIndex(in int index, in byte version)
		{
			Version = version;
			Index = index;
			IsNotEmpty = true;
		}

		public bool Equals(EntryIndex<TKey> other)
		{
			if (IsNotEmpty == other.IsNotEmpty && Version == other.Version)
			{
				return Index == other.Index;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is EntryIndex<TKey> other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((Index * 397) ^ Version) * 397) ^ IsNotEmpty.GetHashCode();
		}
	}
}
