using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Jundroo.Common.Math
{
	[Serializable]
	public struct RangeInteger : IEquatable<RangeInteger>, IEnumerable<int>, IEnumerable
	{
		private struct RangeIntegerEnumerator : IEnumerator<int>, IEnumerator, IDisposable
		{
			private readonly RangeInteger _range;

			private int _index;

			public int Current
			{
				get
				{
					if (_index == -1 || _index >= _range.Length)
					{
						throw new IndexOutOfRangeException($"Unable to enumerate the range. The index is out of range {_range}: {_index}");
					}
					return _range.Start + _index;
				}
			}

			object IEnumerator.Current => Current;

			public RangeIntegerEnumerator(RangeInteger range)
			{
				_range = range;
				_index = -1;
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (_index < _range.Length - 1)
				{
					_index++;
					return true;
				}
				return false;
			}

			public void Reset()
			{
				_index = -1;
			}
		}

		public int Length;

		public int Start;

		public readonly int EndExclusive
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Start + Length;
			}
		}

		public readonly int EndInclusive
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Start + (Length - 1);
			}
		}

		public RangeInteger(int length)
		{
			Start = 0;
			Length = length;
		}

		public RangeInteger(int start, int length)
		{
			Start = start;
			Length = length;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(RangeInteger lhs, RangeInteger rhs)
		{
			if (lhs.Start == rhs.Start)
			{
				return lhs.Length != rhs.Length;
			}
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(RangeInteger lhs, RangeInteger rhs)
		{
			if (lhs.Start == rhs.Start)
			{
				return lhs.Length == rhs.Length;
			}
			return false;
		}

		public static RangeInteger Exclusive(int start, int endExclusive)
		{
			return new RangeInteger(start, endExclusive - start);
		}

		public static RangeInteger Inclusive(int start, int endInclusive)
		{
			return new RangeInteger(start, endInclusive - start + 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(RangeInteger other)
		{
			if (Start == other.Start)
			{
				return Length == other.Length;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is RangeInteger))
			{
				return false;
			}
			return Equals((RangeInteger)obj);
		}

		public IEnumerator<int> GetEnumerator()
		{
			return new RangeIntegerEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return Start ^ (Length << 2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int RandomValue()
		{
			return UnityEngine.Random.Range(Start, EndExclusive);
		}

		public override string ToString()
		{
			return $"({Start}, {EndExclusive})";
		}
	}
}
