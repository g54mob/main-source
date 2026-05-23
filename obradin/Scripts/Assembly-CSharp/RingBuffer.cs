using System;
using System.Collections.Generic;

public class RingBuffer<T>
{
	public readonly int maxLength;

	private int count;

	private List<T> buf;

	public bool isEmpty
	{
		get
		{
			return buf.Count == 0;
		}
	}

	public RingBuffer(int maxLength_)
	{
		maxLength = maxLength_;
		count = 0;
		buf = new List<T>();
	}

	public void Clear()
	{
		count = 0;
		buf.Clear();
	}

	public void Add(T t)
	{
		if (buf.Count < maxLength)
		{
			buf.Add(t);
		}
		else
		{
			buf[count % maxLength] = t;
		}
		count++;
	}

	public void Fill(T t)
	{
		for (int i = 0; i < buf.Count; i++)
		{
			buf[i] = t;
		}
		while (buf.Count < maxLength)
		{
			buf.Add(t);
		}
	}

	public T Get(int distFromEnd)
	{
		if (count == 0 || distFromEnd < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (distFromEnd > count - 1)
		{
			distFromEnd = count - 1;
		}
		if (distFromEnd > maxLength - 1)
		{
			distFromEnd = maxLength - 1;
		}
		int num = (count - 1) % maxLength;
		int index = (num - distFromEnd + 10 * maxLength) % maxLength;
		return buf[index];
	}

	public static void Test()
	{
		RingBuffer<int> ringBuffer = new RingBuffer<int>(3);
		ringBuffer.Add(1);
		ringBuffer.Add(2);
		ringBuffer.Add(3);
		ringBuffer.Add(4);
	}
}
