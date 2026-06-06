using System;

public abstract class HeapItem<T> : IComparable<T>
{
	public T Reference;

	public int Index;

	public abstract int CompareTo(T other);

	public int CompareTo(HeapItem<T> other)
	{
		return CompareTo(other.Reference);
	}
}
