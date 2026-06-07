using System;

public abstract class IHeapItem<T> : IComparable<T>
{
	public int HeapIndex;

	public abstract int CompareTo(T other);
}
