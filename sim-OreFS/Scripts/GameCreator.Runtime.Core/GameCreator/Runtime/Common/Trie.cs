using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GameCreator.Runtime.Common
{
	public class Trie<T> : IEnumerable<Trie<T>>, IEnumerable
	{
		public readonly string id;

		public T Data { get; }

		public Trie<T> Parent { get; private set; }

		public Dictionary<string, Trie<T>> Children { get; }

		private Trie()
		{
			id = string.Empty;
			Data = default(T);
			Children = new Dictionary<string, Trie<T>>();
		}

		public Trie(string id, T data)
		{
			this.id = id;
			Data = data;
			Children = new Dictionary<string, Trie<T>>();
		}

		public Trie<T> AddChild(Trie<T> item)
		{
			item.Parent?.Children.Remove(item.id);
			item.Parent = this;
			if (Children.ContainsKey(item.id))
			{
				return null;
			}
			Children.Add(item.id, item);
			return Children[item.id];
		}

		public static Trie<T> Create()
		{
			return new Trie<T>();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			BuildString(stringBuilder, this, 0);
			return stringBuilder.ToString();
		}

		public static string BuildString(Trie<T> trie)
		{
			StringBuilder stringBuilder = new StringBuilder();
			BuildString(stringBuilder, trie, 0);
			return stringBuilder.ToString();
		}

		private static void BuildString(StringBuilder sb, Trie<T> node, int depth)
		{
			sb.AppendLine(node.id.PadLeft(node.id.Length + depth));
			foreach (Trie<T> item in node)
			{
				BuildString(sb, item, depth + 1);
			}
		}

		public IEnumerator<Trie<T>> GetEnumerator()
		{
			return Children.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
