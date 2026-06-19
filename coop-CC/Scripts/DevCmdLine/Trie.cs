using System.Collections.Generic;

public class Trie
{
	public class Node
	{
		public readonly char value;

		public readonly int depth;

		public bool isCompleteString;

		private Dictionary<char, Node> _childrenToNode = new Dictionary<char, Node>();

		private List<Node> _children = new List<Node>();

		public int childrenCount => _childrenToNode.Count;

		public Node(char value, int depth)
		{
			this.value = value;
			this.depth = depth;
		}

		public Node GetChild(char c, bool caseInsensitive)
		{
			Node result2;
			if (caseInsensitive)
			{
				if (_childrenToNode.TryGetValue(char.ToLower(c), out var result))
				{
					return result;
				}
				if (_childrenToNode.TryGetValue(char.ToUpper(c), out result))
				{
					return result;
				}
			}
			else if (_childrenToNode.TryGetValue(c, out result2))
			{
				return result2;
			}
			return null;
		}

		public void AddChild(Node node)
		{
			if (!_childrenToNode.ContainsKey(node.value))
			{
				_childrenToNode[node.value] = node;
				_children.Add(node);
			}
		}

		public Node GetFirstChild()
		{
			if (_children.Count <= 0)
			{
				return null;
			}
			return _children[0];
		}

		public Node[] GetChildren()
		{
			return _children.ToArray();
		}
	}

	public readonly Node root;

	public Trie()
	{
		root = new Node('\0', 0);
	}

	public Node Prefix(string s, bool caseInsensitive = false)
	{
		Node child = root;
		Node result = child;
		foreach (char c in s)
		{
			child = child.GetChild(c, caseInsensitive);
			if (child == null)
			{
				break;
			}
			result = child;
		}
		return result;
	}

	public bool Search(string s, bool caseInsensitive = false)
	{
		Node node = Prefix(s, caseInsensitive);
		if (node.depth == s.Length)
		{
			return node.isCompleteString;
		}
		return false;
	}

	public void Add(IEnumerable<string> items)
	{
		foreach (string item in items)
		{
			Add(item);
		}
	}

	public void Add(string[] items)
	{
		for (int i = 0; i < items.Length; i++)
		{
			Add(items[i]);
		}
	}

	public void Add(string s)
	{
		Node node = Prefix(s);
		for (int i = node.depth; i < s.Length; i++)
		{
			Node node2 = new Node(s[i], node.depth + 1);
			node.AddChild(node2);
			node = node2;
		}
		node.isCompleteString = true;
	}
}
