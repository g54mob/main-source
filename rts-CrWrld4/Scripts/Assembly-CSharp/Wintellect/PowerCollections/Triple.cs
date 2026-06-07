using System;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	public struct Triple<TFirst, TSecond, TThird> : IComparable, IComparable<Triple<TFirst, TSecond, TThird>>
	{
		private static readonly IComparer<TFirst> firstComparer;

		private static readonly IComparer<TSecond> secondComparer;

		private static readonly IComparer<TThird> thirdComparer;

		private static readonly IEqualityComparer<TFirst> firstEqualityComparer;

		private static readonly IEqualityComparer<TSecond> secondEqualityComparer;

		private static readonly IEqualityComparer<TThird> thirdEqualityComparer;

		public TFirst First;

		public TSecond Second;

		public TThird Third;

		public Triple(TFirst first, TSecond second, TThird third)
		{
			First = default(TFirst);
			Second = default(TSecond);
			Third = default(TThird);
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Triple<TFirst, TSecond, TThird> other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public int CompareTo(Triple<TFirst, TSecond, TThird> other)
		{
			return 0;
		}

		int IComparable.CompareTo(object obj)
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}

		public static bool operator ==(Triple<TFirst, TSecond, TThird> pair1, Triple<TFirst, TSecond, TThird> pair2)
		{
			return false;
		}

		public static bool operator !=(Triple<TFirst, TSecond, TThird> pair1, Triple<TFirst, TSecond, TThird> pair2)
		{
			return false;
		}
	}
}
