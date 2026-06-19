using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Aggro.Core
{
	[Serializable]
	public struct TagContext : IEquatable<TagContext>, IComparable<TagContext>
	{
		[SerializeField]
		internal int contextId;

		public static TagContext invalid => default(TagContext);

		public bool isValid => contextId != 0;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal TagContext(int contextId)
		{
			this.contextId = contextId;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(TagContext other)
		{
			return contextId == other.contextId;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int CompareTo(TagContext other)
		{
			return contextId.CompareTo(other.contextId);
		}

		public override bool Equals(object obj)
		{
			if (obj is TagContext other)
			{
				return Equals(other);
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return contextId.GetHashCode();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(TagContext a, TagContext b)
		{
			return a.contextId == b.contextId;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(TagContext a, TagContext b)
		{
			return !(a == b);
		}

		public override string ToString()
		{
			return $"Context: {contextId}";
		}
	}
}
