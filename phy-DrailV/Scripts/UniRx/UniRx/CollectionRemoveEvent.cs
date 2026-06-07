using System;
using System.Collections.Generic;

namespace UniRx
{
	public struct CollectionRemoveEvent<T> : IEquatable<CollectionRemoveEvent<T>>
	{
		public int Index { get; private set; }

		public T Value { get; private set; }

		public CollectionRemoveEvent(int index, T value)
		{
			this = default(CollectionRemoveEvent<T>);
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

		public bool Equals(CollectionRemoveEvent<T> other)
		{
			if (Index.Equals(other.Index))
			{
				return EqualityComparer<T>.Default.Equals(Value, other.Value);
			}
			return false;
		}
	}
}
