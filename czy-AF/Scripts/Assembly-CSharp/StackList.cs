using System.Collections.Generic;

public class StackList<T>
{
	private List<T> items = new List<T>();

	public void Push(T item)
	{
		items.Add(item);
	}

	public T Pop()
	{
		if (items.Count > 0)
		{
			T result = items[items.Count - 1];
			items.RemoveAt(items.Count - 1);
			return result;
		}
		return default(T);
	}

	public T Shift()
	{
		if (items.Count > 0)
		{
			T result = items[0];
			items.RemoveAt(0);
			return result;
		}
		return default(T);
	}

	public void Clear()
	{
		items.Clear();
	}

	public int Count()
	{
		return items.Count;
	}

	public void Remove(int itemAtPosition)
	{
		items.RemoveAt(itemAtPosition);
	}
}
