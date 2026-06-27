using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace FluentAssertions.Xml.Equivalency
{
	internal sealed class Node
	{
		private readonly List<Node> children = new List<Node>();

		private readonly string name;

		private int count;

		public Node Parent { get; }

		public static Node CreateRoot()
		{
			return new Node(null, null);
		}

		private Node(Node parent, string name)
		{
			Parent = parent;
			this.name = name;
		}

		public string GetXPath()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Node item in GetPath().Reverse())
			{
				if (item.count > 1)
				{
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "/{0}[{1}]", item.name, item.count);
				}
				else
				{
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "/{0}", item.name);
				}
			}
			if (stringBuilder.Length == 0)
			{
				return "/";
			}
			return stringBuilder.ToString();
		}

		private IEnumerable<Node> GetPath()
		{
			Node current = this;
			while (current.Parent != null)
			{
				yield return current;
				current = current.Parent;
			}
		}

		public Node Push(string localName)
		{
			Node obj = children.Find((Node e) => e.name == localName) ?? AddChildNode(localName);
			obj.count++;
			return obj;
		}

		public void Pop()
		{
			children.Clear();
		}

		private Node AddChildNode(string name)
		{
			Node node = new Node(this, name);
			children.Add(node);
			return node;
		}
	}
}
