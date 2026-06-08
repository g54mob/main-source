using System;

namespace Castle.Core
{
	public class Pair<TFirst, TSecond> : IEquatable<Pair<TFirst, TSecond>>
	{
		private readonly TFirst first;

		private readonly TSecond second;

		public TFirst First => first;

		public TSecond Second => second;

		public Pair(TFirst first, TSecond second)
		{
			this.first = first;
			this.second = second;
		}

		public override string ToString()
		{
			return string.Concat(first, " ", second);
		}

		public bool Equals(Pair<TFirst, TSecond> other)
		{
			if (other == null)
			{
				return false;
			}
			if (object.Equals(first, other.first))
			{
				return object.Equals(second, other.second);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			return Equals(obj as Pair<TFirst, TSecond>);
		}

		public override int GetHashCode()
		{
			return first.GetHashCode() + 29 * second.GetHashCode();
		}
	}
}
