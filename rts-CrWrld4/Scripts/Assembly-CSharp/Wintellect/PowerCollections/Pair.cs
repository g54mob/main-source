using System;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	[Serializable]
	public struct Pair<TFirst, TSecond> : IComparable, IComparable<Pair<TFirst, TSecond>>
	{
		private static readonly IComparer<TFirst> firstComparer;

		private static readonly IComparer<TSecond> secondComparer;

		private static readonly IEqualityComparer<TFirst> firstEqualityComparer;

		private static readonly IEqualityComparer<TSecond> secondEqualityComparer;

		public TFirst First;

		public TSecond Second;

		public Pair(TFirst first, TSecond second)
		{
			First = default(TFirst);
			Second = default(TSecond);
		}

		public Pair(KeyValuePair<TFirst, TSecond> keyAndValue)
		{
			First = default(TFirst);
			Second = default(TSecond);
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Pair<TFirst, TSecond> other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public int CompareTo(Pair<TFirst, TSecond> other)
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

		public static bool operator ==(Pair<TFirst, TSecond> pair1, Pair<TFirst, TSecond> pair2)
		{
			return false;
		}

		public static bool operator !=(Pair<TFirst, TSecond> pair1, Pair<TFirst, TSecond> pair2)
		{
			return false;
		}

		public static explicit operator KeyValuePair<TFirst, TSecond>(Pair<TFirst, TSecond> pair)
		{
			return default(KeyValuePair<TFirst, TSecond>);
		}

		public KeyValuePair<TFirst, TSecond> ToKeyValuePair()
		{
			return default(KeyValuePair<TFirst, TSecond>);
		}

		public static explicit operator Pair<TFirst, TSecond>(KeyValuePair<TFirst, TSecond> keyAndValue)
		{
			return default(Pair<TFirst, TSecond>);
		}
	}
}
