using System;

namespace Gh
{
	public class Tuple<T, K> : IEquatable<Tuple<T, K>>
	{
		public T First { get; set; }

		public K Second { get; set; }

		public Tuple()
		{
		}

		public Tuple(T first, K second)
		{
		}

		public static Tuple<T, K> Create(T first, K second)
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Tuple<T, K> other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
