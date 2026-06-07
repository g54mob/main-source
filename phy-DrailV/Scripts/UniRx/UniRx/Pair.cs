using System;
using System.Collections.Generic;

namespace UniRx
{
	[Serializable]
	public struct Pair<T> : IEquatable<Pair<T>>
	{
		private readonly T previous;

		private readonly T current;

		public T Previous => previous;

		public T Current => current;

		public Pair(T previous, T current)
		{
			this.previous = previous;
			this.current = current;
		}

		public override int GetHashCode()
		{
			EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
			int hashCode = equalityComparer.GetHashCode(previous);
			return ((hashCode << 5) + hashCode) ^ equalityComparer.GetHashCode(current);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Pair<T>))
			{
				return false;
			}
			return Equals((Pair<T>)obj);
		}

		public bool Equals(Pair<T> other)
		{
			EqualityComparer<T> equalityComparer = EqualityComparer<T>.Default;
			if (equalityComparer.Equals(previous, other.Previous))
			{
				return equalityComparer.Equals(current, other.Current);
			}
			return false;
		}

		public override string ToString()
		{
			return $"({previous}, {current})";
		}
	}
}
