using System;
using System.Collections;
using System.Collections.Generic;

namespace Mystery.Graphing
{
	public class NodeSet<N> : ICollection<N>, IEnumerable<N>, IEnumerable, ICollection
	{
		private LinkedList<N> nodes = new LinkedList<N>();

		public N First => nodes.First.Value;

		public N Second => nodes.First.Next.Value;

		public N Last => nodes.Last.Value;

		public int Count => nodes.Count;

		bool ICollection<N>.IsReadOnly => false;

		public object SyncRoot => null;

		public bool IsSynchronized => false;

		public void AddNode(N node)
		{
			nodes.AddLast(node);
		}

		protected void AddNodeAfter(LinkedListNode<N> linkedListNode, N node)
		{
			nodes.AddAfter(linkedListNode, node);
		}

		public virtual void Clear()
		{
			nodes.Clear();
		}

		void ICollection<N>.Add(N item)
		{
			AddNode(item);
		}

		public bool Contains(N item)
		{
			return nodes.Contains(item);
		}

		void ICollection<N>.CopyTo(N[] array, int arrayIndex)
		{
			nodes.CopyTo(array, arrayIndex);
		}

		public bool Remove(N item)
		{
			return nodes.Remove(item);
		}

		public void RemoveFirst()
		{
			nodes.RemoveFirst();
		}

		public void RemoveLast()
		{
			nodes.RemoveLast();
		}

		protected IEnumerator<LinkedListNode<N>> GetLinkedListNodeEnumerator()
		{
			for (LinkedListNode<N> linkedNode = nodes.First; linkedNode != null; linkedNode = linkedNode.Next)
			{
				yield return linkedNode;
			}
		}

		public IEnumerator<N> GetEnumerator()
		{
			return nodes.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return nodes.GetEnumerator();
		}

		public void CopyTo(Array array, int index)
		{
			((ICollection)nodes).CopyTo(array, index);
		}
	}
}
