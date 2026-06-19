using System;
using System.Runtime.CompilerServices;

namespace Aggro.Core
{
	[Serializable]
	public struct Tag : IEquatable<Tag>, IComparable<Tag>
	{
		public TagContext context;

		public int bit;

		public static Tag invalid => default(Tag);

		public bool isValid => context.isValid;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal Tag(TagContext context, int bit)
		{
			this.context = context;
			this.bit = bit;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public TagMask GetMask()
		{
			return new TagMask(context, 1 << bit);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Tag other)
		{
			if (context == other.context)
			{
				return bit == other.bit;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int CompareTo(Tag other)
		{
			int num = context.CompareTo(other.context);
			if (num != 0)
			{
				return num;
			}
			return bit.CompareTo(other.bit);
		}

		public override bool Equals(object obj)
		{
			if (obj is Tag other)
			{
				return Equals(other);
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return HashCode.Combine(bit, context);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Tag a, Tag b)
		{
			if (a.context == b.context)
			{
				return a.bit == b.bit;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Tag a, Tag b)
		{
			return !(a == b);
		}

		public override string ToString()
		{
			if (!context.isValid)
			{
				return "<INVALID>";
			}
			return $"Context: {context.contextId} Bit: {bit}";
		}
	}
}
