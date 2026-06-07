using ObservableCollections;

public static class RingBufferExtensions
{
	public static bool TryAddLastUnique<T>(this ObservableFixedSizeRingBuffer<T> buffer, T value)
	{
		if (buffer.Contains(value))
		{
			return false;
		}
		buffer.AddLast(value);
		return true;
	}

	public static bool TryAddFirstUnique<T>(this ObservableFixedSizeRingBuffer<T> buffer, T value)
	{
		if (buffer.Contains(value))
		{
			return false;
		}
		buffer.AddFirst(value);
		return true;
	}
}
