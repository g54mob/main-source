using System.Collections.Generic;

public class SortedLinkedList<T1, T2>
{
	private class Node
	{
		public T1 Key;

		public T2 Value;

		public Node Lower;

		public Node Higher;

		public Node Parent;

		public Node(T1 key, T2 value)
		{
			Key = key;
			Value = value;
		}
	}

	private Node root;

	private Node lowest;

	private IComparer<T1> Comparer;

	private List<Node> pool = new List<Node>();

	private int currentNode;

	public SortedLinkedList(IComparer<T1> comp)
	{
		Comparer = comp;
	}

	private Node CreateNode(T1 key, T2 value)
	{
		if (currentNode < pool.Count)
		{
			Node node = pool[currentNode];
			node.Key = key;
			node.Value = value;
			node.Parent = null;
			node.Lower = null;
			node.Higher = null;
			currentNode++;
			return node;
		}
		Node node2 = new Node(key, value);
		pool.Add(node2);
		currentNode++;
		return node2;
	}

	public void Add(T1 key, T2 value)
	{
		Node node = CreateNode(key, value);
		Add(node, root);
		if (lowest == null || Comparer.Compare(node.Key, lowest.Key) < 0)
		{
			lowest = node;
		}
	}

	public void Clear()
	{
		root = null;
		lowest = null;
		currentNode = 0;
	}

	public T2 Pop()
	{
		Node node = lowest;
		Remove(node);
		return node.Value;
	}

	private void Add(Node node, Node from)
	{
		if (root == null)
		{
			root = node;
			lowest = node;
			return;
		}
		while (from != null)
		{
			if (Comparer.Compare(node.Key, from.Key) < 0)
			{
				if (from.Lower == null)
				{
					from.Lower = node;
					node.Parent = from;
					break;
				}
				from = from.Lower;
			}
			else
			{
				if (from.Higher == null)
				{
					from.Higher = node;
					node.Parent = from;
					break;
				}
				from = from.Higher;
			}
		}
	}

	private Node FindLowestFrom(Node node)
	{
		if (node == null)
		{
			return null;
		}
		for (Node node2 = node; node2 != null; node2 = node2.Lower)
		{
			if (node2.Lower == null)
			{
				return node2;
			}
		}
		return null;
	}

	private Node FindHighestFrom(Node node)
	{
		if (node == null)
		{
			return null;
		}
		for (Node node2 = node; node2 != null; node2 = node2.Higher)
		{
			if (node2.Higher == null)
			{
				return node2;
			}
		}
		return null;
	}

	private void Remove(Node node)
	{
		if (root == node)
		{
			if (node.Lower != null)
			{
				root = node.Lower;
				node.Lower.Parent = null;
			}
			else if (node.Higher != null)
			{
				root = node.Higher;
				node.Higher.Parent = null;
			}
			else
			{
				root = null;
			}
		}
		if (lowest == node)
		{
			if (node.Lower != null)
			{
				lowest = FindLowestFrom(node.Lower);
			}
			else if (node.Higher != null)
			{
				lowest = FindLowestFrom(node.Higher);
			}
			else if (node.Parent != null)
			{
				lowest = node.Parent;
			}
			else
			{
				lowest = FindLowestFrom(root);
			}
		}
		if (node.Parent != null)
		{
			if (node.Parent.Lower == node)
			{
				node.Parent.Lower = null;
				if (node.Higher != null)
				{
					node.Parent.Lower = node.Higher;
					node.Higher.Parent = node.Parent;
					if (node.Lower != null)
					{
						Node node2 = FindLowestFrom(node.Higher);
						node2.Lower = node.Lower;
						node.Lower.Parent = node2;
					}
				}
				else if (node.Lower != null)
				{
					node.Parent.Lower = node.Lower;
					node.Lower.Parent = node.Parent;
				}
			}
			else if (node.Parent.Higher == node)
			{
				node.Parent.Higher = null;
				if (node.Lower != null)
				{
					node.Parent.Higher = node.Lower;
					node.Lower.Parent = node.Parent;
					if (node.Higher != null)
					{
						Node node3 = FindHighestFrom(node.Lower);
						node3.Higher = node.Higher;
						node.Higher.Parent = node3;
					}
				}
				else if (node.Higher != null)
				{
					node.Parent.Higher = node.Higher;
					node.Higher.Parent = node.Parent;
				}
			}
		}
		node.Parent = null;
		node.Lower = null;
		node.Higher = null;
	}
}
