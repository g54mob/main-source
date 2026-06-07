using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SentenceGenerator
{
	public class Node
	{
		public readonly string Name;

		public string[] Sentences;

		public int Index;

		public float LowerBound;

		public float UpperBound;

		public string[] Children;

		public bool HasReq;

		public Node(string name)
		{
			Name = name;
		}

		public string GetLocKey(string parentName)
		{
			return "Article" + parentName + Name;
		}

		public string GetSentence(string parentName)
		{
			if (Sentences.Length == 1)
			{
				return GetLocKey(parentName).Loc();
			}
			return (GetLocKey(parentName) + (Utilities.RandomRange(0, Sentences.Length) + 1)).Loc();
		}
	}

	private Dictionary<string, Node> Nodes = new Dictionary<string, Node>();

	public readonly string Name;

	public IEnumerable<Node> GetSentences()
	{
		foreach (Node value in Nodes.Values)
		{
			yield return value;
		}
	}

	public SentenceGenerator(string genName, string[] input)
	{
		Name = genName;
		int num = 0;
		Node node = null;
		List<string> list = new List<string>();
		for (int i = 0; i < input.Length; i++)
		{
			string text = input[i];
			switch (num)
			{
			case 0:
			{
				if (text.Length <= 0 || text[0] != '-')
				{
					break;
				}
				int num2 = text.IndexOf('(');
				int num3 = text.IndexOf(')');
				int num4 = text.IndexOf('[');
				int num5 = text.IndexOf(']');
				string text2 = text.Substring(1, num2 - 1);
				node = new Node(text2);
				Nodes[text2] = node;
				node.Children = ((num2 == num3 - 1) ? new string[0] : text.Substring(num2 + 1, num3 - num2 - 1).Split(','));
				if (num4 == num5 - 1 || num4 < 0)
				{
					node.HasReq = false;
				}
				else
				{
					float[] array = (from x in text.Substring(num4 + 1, num5 - num4 - 1).Split(',')
						select (float)Convert.ToDouble(x)).ToArray();
					node.HasReq = true;
					node.LowerBound = array[0];
					node.Index = (int)array[1];
					node.UpperBound = array[2];
				}
				num = 1;
				break;
			}
			case 1:
				if (string.IsNullOrEmpty(text.Trim()) || text[0] == '-' || text[0] == '>')
				{
					node.Sentences = list.ToArray();
					list.Clear();
					i--;
					num = 0;
				}
				else
				{
					list.Add(text);
				}
				break;
			}
		}
		if (node != null && node.Sentences == null)
		{
			node.Sentences = list.ToArray();
		}
	}

	public string GenerateSentence(Node node, params float[] values)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (node.Sentences.Length != 0)
		{
			stringBuilder.Append(node.GetSentence(Name) + " ");
		}
		foreach (Node item in node.Children.Select((string x) => Nodes[x]))
		{
			if (!item.HasReq || (values[item.Index] >= item.LowerBound && values[item.Index] < item.UpperBound))
			{
				stringBuilder.Append(GenerateSentence(item, values));
			}
		}
		return stringBuilder.ToString();
	}

	public string GenerateSentence(string fromNode, params float[] values)
	{
		return GenerateSentence(Nodes[fromNode], values);
	}
}
