using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Pathfinding.Collections
{
	public class AABBTree<T>
	{
		private struct Node
		{
			public Bounds bounds;

			public uint flags;

			private const uint TagInsideBit = 1073741824u;

			private const uint TagPartiallyInsideBit = 2147483648u;

			private const uint AllocatedBit = 536870912u;

			private const uint ParentMask = 536870911u;

			public const int InvalidParent = 536870911;

			public int left;

			public int right;

			public T value;

			public bool wholeSubtreeTagged
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool subtreePartiallyTagged
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool isAllocated
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool isLeaf => false;

			public int parent
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}
		}

		public readonly struct Key
		{
			internal readonly int value;

			public int node => 0;

			public bool isValid => false;

			internal Key(int node)
			{
				value = 0;
			}
		}

		private struct AABBComparer : IComparer<int>
		{
			public Node[] nodes;

			public int dim;

			public int Compare(int a, int b)
			{
				return 0;
			}
		}

		private Node[] nodes;

		private int root;

		private readonly Stack<int> freeNodes;

		private int rebuildCounter;

		private const int NoNode = -1;

		public T this[Key key] => default(T);

		private static float ExpansionRequired(Bounds b, Bounds b2)
		{
			return 0f;
		}

		public Bounds GetBounds(Key key)
		{
			return default(Bounds);
		}

		private int AllocNode()
		{
			return 0;
		}

		private void FreeNode(int node)
		{
		}

		public void Rebuild()
		{
		}

		public void Clear()
		{
		}

		private static int ArgMax(Vector3 v)
		{
			return 0;
		}

		private int Rebuild(UnsafeSpan<int> leaves, int parent)
		{
			return 0;
		}

		public void Move(Key key, Bounds bounds)
		{
		}

		[Conditional("VALIDATE_AABB_TREE")]
		private void Validate(int node)
		{
		}

		public Bounds Remove(Key key)
		{
			return default(Bounds);
		}

		public Key Add(Bounds bounds, T value)
		{
			return default(Key);
		}

		public void Query(Bounds bounds, List<T> buffer)
		{
		}

		private void QueryNode(int node, Bounds bounds, List<T> buffer)
		{
		}

		public void QueryTagged(List<T> buffer, bool clearTags = false)
		{
		}

		private void QueryTaggedNode(int node, bool clearTags, List<T> buffer)
		{
		}

		public void Tag(Key key)
		{
		}

		public void Tag(Bounds bounds)
		{
		}

		private bool TagNode(int node, Bounds bounds)
		{
			return false;
		}
	}
}
