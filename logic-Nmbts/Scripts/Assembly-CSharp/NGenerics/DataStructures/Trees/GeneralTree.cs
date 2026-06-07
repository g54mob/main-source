using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NGenerics.Patterns.Visitor;
using NGenerics.Sorting;
using NGenerics.Util;

namespace NGenerics.DataStructures.Trees
{
	[Serializable]
	public class GeneralTree<T> : ICollection<T>, IEnumerable<T>, IEnumerable, ITree<T>, ISortable<GeneralTree<T>>
	{
		private T nodeData;

		private GeneralTree<T> parent;

		private readonly List<GeneralTree<T>> childNodes = new List<GeneralTree<T>>();

		public int Count
		{
			get
			{
				return childNodes.Count;
			}
		}

		public bool IsEmpty
		{
			get
			{
				return Count == 0;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		ITree<T> ITree<T>.Parent
		{
			get
			{
				return parent;
			}
		}

		public IList<GeneralTree<T>> Ancestors
		{
			get
			{
				return GetPath((GeneralTree<T> x) => x);
			}
		}

		public IList<GeneralTree<T>> ChildNodes
		{
			get
			{
				return new ReadOnlyCollection<GeneralTree<T>>(childNodes);
			}
		}

		public GeneralTree<T> Parent
		{
			get
			{
				return parent;
			}
			set
			{
				Guard.ArgumentNotNull(value, "value");
				value.Add(this);
			}
		}

		public int Degree
		{
			get
			{
				return childNodes.Count;
			}
		}

		public int Height
		{
			get
			{
				if (Degree == 0)
				{
					return 0;
				}
				return 1 + FindMaximumChildHeight();
			}
		}

		public T Data
		{
			get
			{
				return nodeData;
			}
			set
			{
				Guard.ArgumentNotNull(value, "value");
				nodeData = value;
			}
		}

		public virtual bool IsLeafNode
		{
			get
			{
				return Degree == 0;
			}
		}

		public GeneralTree<T> this[int index]
		{
			get
			{
				return GetChild(index);
			}
		}

		public GeneralTree(T data)
		{
			Guard.ArgumentNotNull(data, "data");
			nodeData = data;
		}

		public bool Contains(T item)
		{
			using (IEnumerator<T> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					if (item.Equals(current))
					{
						return true;
					}
				}
			}
			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			Guard.ArgumentNotNull(array, "array");
			using (IEnumerator<T> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					if (arrayIndex >= array.Length)
					{
						throw new ArgumentException("Not enough space in the target array.", "array");
					}
					array[arrayIndex++] = current;
				}
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			Stack<GeneralTree<T>> stack = new Stack<GeneralTree<T>>();
			stack.Push(this);
			while (stack.Count > 0)
			{
				GeneralTree<T> tree = stack.Pop();
				if (tree != null)
				{
					yield return tree.Data;
					for (int i = 0; i < tree.Degree; i++)
					{
						stack.Push(tree.GetChild(i));
					}
				}
			}
		}

		public virtual void Clear()
		{
			childNodes.Clear();
		}

		void ICollection<T>.Add(T item)
		{
			GeneralTree<T> item2 = new GeneralTree<T>(item);
			InsertItem(Count, item2);
		}

		public GeneralTree<T> Add(T item)
		{
			GeneralTree<T> generalTree = new GeneralTree<T>(item);
			InsertItem(Count, generalTree);
			return generalTree;
		}

		protected virtual void InsertItem(int index, GeneralTree<T> item)
		{
			if (item.parent != null)
			{
				item.parent.Remove(item);
			}
			if (!childNodes.Contains(item))
			{
				childNodes.Add(item);
				item.parent = this;
			}
		}

		public bool Remove(T item)
		{
			return RemoveItem(item);
		}

		protected virtual bool RemoveItem(T item)
		{
			for (int i = 0; i < childNodes.Count; i++)
			{
				GeneralTree<T> generalTree = childNodes[i];
				if (generalTree.Data.Equals(item))
				{
					generalTree.parent = null;
					childNodes.RemoveAt(i);
					return true;
				}
			}
			return false;
		}

		void ITree<T>.Add(ITree<T> child)
		{
			Add((GeneralTree<T>)child);
		}

		ITree<T> ITree<T>.GetChild(int index)
		{
			return GetChild(index);
		}

		bool ITree<T>.Remove(ITree<T> child)
		{
			return Remove((GeneralTree<T>)child);
		}

		ITree<T> ITree<T>.FindNode(Predicate<T> condition)
		{
			return FindNode(condition);
		}

		public GeneralTree<T> FindNode(Predicate<T> condition)
		{
			Guard.ArgumentNotNull(condition, "condition");
			if (condition(Data))
			{
				return this;
			}
			for (int i = 0; i < Degree; i++)
			{
				GeneralTree<T> generalTree = childNodes[i].FindNode(condition);
				if (generalTree != null)
				{
					return generalTree;
				}
			}
			return null;
		}

		public GeneralTree<T> GetChild(int index)
		{
			return childNodes[index];
		}

		public IList<GeneralTree<T>> GetPath()
		{
			return GetPath((GeneralTree<T> x) => x);
		}

		public IList<TOutput> GetPath<TOutput>(Converter<GeneralTree<T>, TOutput> converter)
		{
			if (converter == null)
			{
				throw new ArgumentNullException("converter");
			}
			return GetPath(converter, false);
		}

		public void DepthFirstTraversal(OrderedVisitor<T> orderedVisitor)
		{
			Guard.ArgumentNotNull(orderedVisitor, "orderedVisitor");
			if (orderedVisitor.HasCompleted)
			{
				return;
			}
			orderedVisitor.VisitPreOrder(Data);
			for (int i = 0; i < Degree; i++)
			{
				if (GetChild(i) != null)
				{
					GetChild(i).DepthFirstTraversal(orderedVisitor);
				}
			}
			orderedVisitor.VisitPostOrder(Data);
		}

		public void BreadthFirstTraversal(IVisitor<T> visitor)
		{
			Queue<GeneralTree<T>> queue = new Queue<GeneralTree<T>>();
			queue.Enqueue(this);
			while (queue.Count > 0)
			{
				GeneralTree<T> generalTree = queue.Dequeue();
				visitor.Visit(generalTree.Data);
				for (int i = 0; i < generalTree.Degree; i++)
				{
					GeneralTree<T> child = generalTree.GetChild(i);
					if (child != null)
					{
						queue.Enqueue(child);
					}
				}
			}
		}

		public void Add(GeneralTree<T> child)
		{
			InsertItem(Count, child);
		}

		public bool Remove(GeneralTree<T> child)
		{
			int num = childNodes.IndexOf(child);
			if (num > -1)
			{
				RemoveItem(num, child);
				return true;
			}
			return false;
		}

		public void RemoveAt(int index)
		{
			RemoveItem(index, childNodes[index]);
		}

		protected virtual void RemoveItem(int index, GeneralTree<T> item)
		{
			item.parent = null;
			childNodes.RemoveAt(index);
		}

		public void SortAllDescendants(IComparisonSorter<GeneralTree<T>> sorter, Comparison<GeneralTree<T>> comparison)
		{
			Guard.ArgumentNotNull(sorter, "sorter");
			Guard.ArgumentNotNull(comparison, "comparison");
			childNodes.Sort(sorter, comparison);
			for (int i = 0; i < childNodes.Count; i++)
			{
				childNodes[i].SortAllDescendants(sorter, comparison);
			}
		}

		public void SortAllDescendants(IComparisonSorter<GeneralTree<T>> sorter, IComparer<GeneralTree<T>> comparer)
		{
			Guard.ArgumentNotNull(sorter, "sorter");
			Guard.ArgumentNotNull(comparer, "comparer");
			childNodes.Sort(sorter, comparer);
			for (int i = 0; i < childNodes.Count; i++)
			{
				childNodes[i].SortAllDescendants(sorter, comparer);
			}
		}

		public void SortAllDescendants(ISorter<GeneralTree<T>> sorter, SortOrder order)
		{
			Guard.ArgumentNotNull(sorter, "sorter");
			childNodes.Sort(sorter, order);
			for (int i = 0; i < childNodes.Count; i++)
			{
				childNodes[i].SortAllDescendants(sorter, order);
			}
		}

		protected IList<TOutput> GetPath<TOutput>(Converter<GeneralTree<T>, TOutput> converter, bool includeThis)
		{
			List<TOutput> list = new List<TOutput>();
			if (includeThis)
			{
				list.Add(converter(this));
			}
			for (GeneralTree<T> generalTree = Parent; generalTree != null; generalTree = generalTree.Parent)
			{
				list.Add(converter(generalTree));
			}
			list.Reverse();
			return list;
		}

		private int FindMaximumChildHeight()
		{
			int num = 0;
			for (int i = 0; i < Degree; i++)
			{
				int height = GetChild(i).Height;
				if (height > num)
				{
					num = height;
				}
			}
			return num;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		void ISortable<GeneralTree<T>>.Sort(ISorter<GeneralTree<T>> sorter)
		{
			throw new NotSupportedException();
		}

		public void Sort(IComparisonSorter<GeneralTree<T>> sorter, Comparison<GeneralTree<T>> comparison)
		{
			Guard.ArgumentNotNull(sorter, "sorter");
			Guard.ArgumentNotNull(comparison, "comparison");
			childNodes.Sort(sorter, comparison);
		}

		public void Sort(IComparisonSorter<GeneralTree<T>> sorter, IComparer<GeneralTree<T>> comparer)
		{
			Guard.ArgumentNotNull(sorter, "sorter");
			Guard.ArgumentNotNull(comparer, "comparer");
			childNodes.Sort(sorter, comparer);
		}

		public void Sort(ISorter<GeneralTree<T>> sorter, SortOrder order)
		{
			Guard.ArgumentNotNull(sorter, "sorter");
			childNodes.Sort(sorter, order);
		}

		public override string ToString()
		{
			return Data.ToString();
		}
	}
}
