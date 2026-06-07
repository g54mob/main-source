using System.Collections.Generic;

public class FixedSizedQueue<T> : Queue<T>
{
	public int size { get; private set; }

	public FixedSizedQueue(int size)
	{
	}

	public new void Enqueue(T obj)
	{
	}
}
