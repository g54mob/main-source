namespace ZLinq
{
	public interface IValueEnumerable<TEnumerator, T> where TEnumerator : struct, IValueEnumerator<T>
	{
		ValueEnumerable<TEnumerator, T> AsValueEnumerable();
	}
}
