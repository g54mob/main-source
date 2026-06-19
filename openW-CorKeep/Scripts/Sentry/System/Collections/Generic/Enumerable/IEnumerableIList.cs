namespace System.Collections.Generic.Enumerable
{
	internal interface IEnumerableIList<T> : IEnumerable<T>, IEnumerable
	{
		new EnumeratorIList<T> GetEnumerator();
	}
}
