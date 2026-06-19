using System;
using System.Collections.Generic;

namespace TMPEffects.Tags
{
	public readonly struct TMPEffectTagIndices : IComparable<TMPEffectTagIndices>, IEquatable<TMPEffectTagIndices>
	{
		private readonly int startIndex;

		private readonly int endIndex;

		private readonly int orderAtIndex;

		public int StartIndex => startIndex;

		public int EndIndex => endIndex;

		public int OrderAtIndex => orderAtIndex;

		public bool IsOpen => endIndex == -1;

		public int Length
		{
			get
			{
				if (!IsOpen)
				{
					return endIndex - startIndex;
				}
				return endIndex;
			}
		}

		public bool IsEmpty => startIndex == endIndex;

		public IEnumerable<int> ContainedIndices
		{
			get
			{
				for (int i = startIndex; i < EndIndex; i++)
				{
					yield return i;
				}
			}
		}

		public bool Contains(int index)
		{
			if (!IsEmpty && index >= startIndex)
			{
				return index < endIndex;
			}
			return false;
		}

		public TMPEffectTagIndices(int startIndex, int endIndex, int orderAtIndex)
		{
			if (startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			if (endIndex < -1)
			{
				throw new ArgumentOutOfRangeException("endIndex");
			}
			if (endIndex != -1 && endIndex < startIndex)
			{
				throw new ArgumentOutOfRangeException("endIndex");
			}
			this.startIndex = startIndex;
			this.endIndex = endIndex;
			this.orderAtIndex = orderAtIndex;
		}

		public int CompareTo(TMPEffectTagIndices other)
		{
			int num = startIndex.CompareTo(other.startIndex);
			if (num == 0)
			{
				return orderAtIndex.CompareTo(other.orderAtIndex);
			}
			return num;
		}

		public static bool operator ==(TMPEffectTagIndices c1, TMPEffectTagIndices c2)
		{
			return c1.Equals(c2);
		}

		public static bool operator !=(TMPEffectTagIndices c1, TMPEffectTagIndices c2)
		{
			return !c1.Equals(c2);
		}

		public static bool operator >(TMPEffectTagIndices c1, TMPEffectTagIndices c2)
		{
			return c1.CompareTo(c2) > 0;
		}

		public static bool operator <(TMPEffectTagIndices c1, TMPEffectTagIndices c2)
		{
			return c1.CompareTo(c2) < 0;
		}

		public override bool Equals(object obj)
		{
			if (obj is TMPEffectTagIndices)
			{
				return Equals((TMPEffectTagIndices)obj);
			}
			return false;
		}

		public bool Equals(TMPEffectTagIndices other)
		{
			if (startIndex == other.startIndex && endIndex == other.endIndex)
			{
				return orderAtIndex == other.orderAtIndex;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(startIndex, endIndex, orderAtIndex);
		}
	}
}
