using System;

namespace Moq
{
	internal readonly struct Pair<T1, T2> : IEquatable<Pair<T1, T2>>
	{
		public readonly T1 Item1;

		public readonly T2 Item2;

		public Pair(T1 item1, T2 item2)
		{
			Item1 = item1;
			Item2 = item2;
		}

		public void Deconstruct(out T1 item1, out T2 item2)
		{
			item1 = Item1;
			item2 = Item2;
		}

		public bool Equals(Pair<T1, T2> other)
		{
			if (object.Equals(Item1, other.Item1))
			{
				return object.Equals(Item2, other.Item2);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is Pair<T1, T2> other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			T1 item = Item1;
			int? num = 1001 * ((item != null) ? new int?(item.GetHashCode()) : ((int?)null));
			if (!num.HasValue)
			{
				T2 item2 = Item2;
				return (101 + ((item2 != null) ? new int?(item2.GetHashCode()) : ((int?)null))) ?? 11;
			}
			return num.GetValueOrDefault();
		}
	}
}
