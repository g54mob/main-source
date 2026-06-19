using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Loxodon.Framework.Binding.Paths
{
	[Serializable]
	public class Path : IEnumerator<IPathNode>, IEnumerator, IDisposable
	{
		private readonly List<IPathNode> nodes = new List<IPathNode>();

		private int index = -1;

		private bool disposed;

		public IPathNode this[int index] => nodes[index];

		public bool IsEmpty => nodes.Count == 0;

		public int Count => nodes.Count;

		public bool IsStatic => nodes.Exists((IPathNode n) => n.IsStatic);

		public IPathNode Current => nodes[index];

		object IEnumerator.Current => nodes[index];

		public Path()
			: this(null)
		{
		}

		public Path(IPathNode root)
		{
			if (root != null)
			{
				Prepend(root);
			}
		}

		public List<IPathNode> ToList()
		{
			return new List<IPathNode>(nodes);
		}

		public void Append(IPathNode node)
		{
			nodes.Add(node);
		}

		public void Prepend(IPathNode node)
		{
			nodes.Insert(0, node);
		}

		public void PrependIndexed(string indexValue)
		{
			Prepend(new StringIndexedNode(indexValue));
		}

		public void PrependIndexed(int indexValue)
		{
			Prepend(new IntegerIndexedNode(indexValue));
		}

		public void AppendIndexed(string indexValue)
		{
			Append(new StringIndexedNode(indexValue));
		}

		public void AppendIndexed(int indexValue)
		{
			Append(new IntegerIndexedNode(indexValue));
		}

		public PathToken AsPathToken()
		{
			if (nodes.Count <= 0)
			{
				throw new InvalidOperationException("The path node is empty");
			}
			return new PathToken(this, 0);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (IPathNode node in nodes)
			{
				node.AppendTo(stringBuilder);
			}
			return stringBuilder.ToString();
		}

		public bool MoveNext()
		{
			index++;
			if (index >= 0)
			{
				return index < nodes.Count;
			}
			return false;
		}

		public void Reset()
		{
			index = -1;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					nodes.Clear();
					index = -1;
				}
				disposed = true;
			}
		}

		~Path()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
