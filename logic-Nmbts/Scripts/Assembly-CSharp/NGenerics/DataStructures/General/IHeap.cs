namespace NGenerics.DataStructures.General
{
	public interface IHeap<T>
	{
		T Root { get; }

		void Add(T item);

		T RemoveRoot();
	}
}
