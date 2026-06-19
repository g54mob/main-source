using System;
using System.Runtime.CompilerServices;

namespace Aggro.Core
{
	[Serializable]
	public struct TagMask : IEquatable<TagMask>, IComparable<TagMask>
	{
		public int value;

		public TagContext context;

		public static TagMask invalid => default(TagMask);

		public readonly bool isValid => context.isValid;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public TagMask(TagContext context, int value)
		{
			this.value = value;
			this.context = context;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool Has(Tag tag)
		{
			return HasAny(tag.GetMask());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool HasAny(TagMask mask)
		{
			return (value & mask.value) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool HasAll(TagMask mask)
		{
			return (value & mask.value) == mask.value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool HasNone(TagMask mask)
		{
			return (value & mask.value) == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TagMask Or(TagMask a, TagMask b)
		{
			return new TagMask(a.context, a.value | b.value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TagMask And(TagMask a, TagMask b)
		{
			return new TagMask(a.context, a.value & b.value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TagMask XOr(TagMask a, TagMask b)
		{
			return new TagMask(a.context, a.value ^ b.value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TagMask Not(TagMask a)
		{
			return new TagMask(a.context, ~a.value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(TagMask other)
		{
			if (context == other.context)
			{
				return value == other.value;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int CompareTo(TagMask other)
		{
			int num = context.CompareTo(other.context);
			if (num != 0)
			{
				return num;
			}
			return value.CompareTo(other.value);
		}

		public override bool Equals(object obj)
		{
			if (obj is TagMask other)
			{
				return Equals(other);
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return HashCode.Combine(value, context);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(TagMask a, TagMask b)
		{
			if (a.value == b.value)
			{
				return a.context == b.context;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(TagMask a, TagMask b)
		{
			return !(a == b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TagMask operator |(TagMask a, TagMask b)
		{
			return Or(a, b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TagMask operator &(TagMask a, TagMask b)
		{
			return And(a, b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TagMask operator ^(TagMask a, TagMask b)
		{
			return XOr(a, b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TagMask operator ~(TagMask a)
		{
			return Not(a);
		}

		public override string ToString()
		{
			return $"Context: {context} Tag: 0x{value:X8}";
		}
	}
}
