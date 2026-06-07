using System;
using System.Runtime.CompilerServices;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Jundroo.Common.Math
{
	[Serializable]
	public struct RangeFloat : IEquatable<RangeFloat>
	{
		public float Length;

		public float Start;

		public readonly float End => Start + Length;

		public RangeFloat(float length)
		{
			Start = 0f;
			Length = length;
		}

		public RangeFloat(float start, float length)
		{
			Start = start;
			Length = length;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(RangeFloat lhs, RangeFloat rhs)
		{
			return !lhs.Equals(rhs);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(RangeFloat lhs, RangeFloat rhs)
		{
			return lhs.Equals(rhs);
		}

		public bool Equals(RangeFloat other)
		{
			if (Utilities.CompareFloats(Start, other.Start))
			{
				return Utilities.CompareFloats(Length, other.Length);
			}
			return false;
		}

		public bool Equals(RangeFloat other, float epsilon)
		{
			if (Utilities.CompareFloats(Start, other.Start, epsilon))
			{
				return Utilities.CompareFloats(Length, other.Length, epsilon);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is RangeFloat))
			{
				return false;
			}
			return Equals((RangeFloat)obj);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return Start.GetHashCode() ^ (Length.GetHashCode() << 2);
		}

		public float RandomValue()
		{
			return UnityEngine.Random.Range(Start, End);
		}

		public override string ToString()
		{
			return $"({Start}, {End})";
		}

		public string ToString(string format)
		{
			return "(" + Start.ToString(format) + ", " + End.ToString(format) + ")";
		}
	}
}
