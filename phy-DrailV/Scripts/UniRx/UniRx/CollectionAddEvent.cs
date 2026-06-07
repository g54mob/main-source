using System;
using System.Collections.Generic;

namespace UniRx
{
	public struct CollectionAddEvent<T> : IEquatable<CollectionAddEvent<T>>
	{
		public int Index { get; private set; }

		public T Value { get; private set; }

		public CollectionAddEvent(int index, T value)
		{
			this = default(CollectionAddEvent<T>);
			Index = index;
			Value = value;
		}

		public override string ToString()
		{
			return $"Index:{Index} Value:{Value}";
		}

		public override int GetHashCode()
		{
			return Index.GetHashCode() ^ (EqualityComparer<T>.Default.GetHashCode(Value) << 2);
		}

		public bool Equals(CollectionAddEvent<T> other)
		{
			if (Index.Equals(other.Index))
			{
				return EqualityComparer<T>.Default.Equals(Value, other.Value);
			}
			return false;
		}
	}
}
