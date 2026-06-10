using System.Collections;
using System.Collections.Generic;

namespace NSMedieval.DataStructures.Trees
{
	public sealed class Tree<T> : IEnumerable<Node<T>>, IEnumerable
	{
		private Node<T> root;

		public Node<T> Root => root;

		public Tree(Node<T> root)
		{
			this.root = root;
		}

		public Node<T> GetNode(Node<T> inputNode)
		{
			using (IEnumerator<Node<T>> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Node<T> current = enumerator.Current;
					if (current.Data.Equals(inputNode.Data))
					{
						return current;
					}
				}
			}
			return null;
		}

		public Node<T> GetNode(T nodeData)
		{
			using (IEnumerator<Node<T>> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Node<T> current = enumerator.Current;
					if (current.Data.Equals(nodeData))
					{
						return current;
					}
				}
			}
			return null;
		}

		public Node<T> AddChild(Node<T> parent, T data)
		{
			Node<T> child = new Node<T>(data, parent);
			parent.SetChild(child);
			return parent.Child;
		}

		public IEnumerator<Node<T>> GetEnumerator()
		{
			return Enumerate(root).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private IEnumerable<Node<T>> Enumerate(Node<T> root)
		{
			for (Node<T> node = root; node != null; node = node.Next)
			{
				yield return node;
				foreach (Node<T> item in Enumerate(node.Child))
				{
					yield return item;
				}
			}
		}
	}
}
