using System;

public class RollingAverage<T>
{
	private readonly T[] buffer;

	private readonly Func<T, T, T> add;

	private readonly Func<T, T, T> sub;

	private readonly Func<T, float, T> div;

	private int head;

	private int count;

	private T sum;

	public T Average => default(T);

	public int Count => 0;

	public int Capacity => 0;

	public RollingAverage(int capacity, Func<T, T, T> add, Func<T, T, T> sub, Func<T, float, T> div)
	{
	}

	public void Add(T value)
	{
	}

	public void Clear()
	{
	}
}
