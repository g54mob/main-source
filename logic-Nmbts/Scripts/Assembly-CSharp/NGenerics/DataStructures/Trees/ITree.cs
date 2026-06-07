using System;

namespace NGenerics.DataStructures.Trees
{
	public interface ITree<T>
	{
		T Data { get; }

		int Degree { get; }

		int Height { get; }

		bool IsLeafNode { get; }

		ITree<T> Parent { get; }

		void Add(ITree<T> child);

		ITree<T> GetChild(int index);

		bool Remove(ITree<T> child);

		ITree<T> FindNode(Predicate<T> condition);
	}
}
