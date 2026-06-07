using System;
using System.Collections.Generic;
using System.Diagnostics;
using Pathfinding.Util;
using Unity.Collections;
using UnityEngine;

namespace Pathfinding.Graphs.Navmesh
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
					return (flags & 0x40000000) != 0;
				}
				set
				{
					flags = (flags & 0xBFFFFFFFu) | (uint)(value ? 1073741824 : 0);
				}
			}

			public bool subtreePartiallyTagged
			{
				get
				{
					return (flags & 0x80000000u) != 0;
				}
				set
				{
					flags = (flags & 0x7FFFFFFF) | (uint)(value ? int.MinValue : 0);
				}
			}

			public bool isAllocated
			{
				get
				{
					return (flags & 0x20000000) != 0;
				}
				set
				{
					flags = (flags & 0xDFFFFFFFu) | (uint)(value ? 536870912 : 0);
				}
			}

			public bool isLeaf => left == -1;

			public int parent
			{
				get
				{
					return (int)(flags & 0x1FFFFFFF);
				}
				set
				{
					flags = (flags & 0xE0000000u) | (uint)value;
				}
			}
		}

		public readonly struct Key
		{
			internal readonly int value;

			public int node => value - 1;

			public bool isValid => value != 0;

			internal Key(int node)
			{
				value = node + 1;
			}
		}

		private struct AABBComparer : IComparer<int>
		{
			public Node[] nodes;

			public int dim;

			public int Compare(int a, int b)
			{
				return nodes[a].bounds.center[dim].CompareTo(nodes[b].bounds.center[dim]);
			}
		}

		private Node[] nodes = new Node[0];

		private int root = -1;

		private readonly Stack<int> freeNodes = new Stack<int>();

		private int rebuildCounter = 64;

		private const int NoNode = -1;

		public T this[Key key] => nodes[key.node].value;

		private static float ExpansionRequired(Bounds b, Bounds b2)
		{
			Bounds bounds = b;
			bounds.Encapsulate(b2);
			return bounds.size.x * bounds.size.y * bounds.size.z - b.size.x * b.size.y * b.size.z;
		}

		public Bounds GetBounds(Key key)
		{
			if (!key.isValid)
			{
				throw new ArgumentException("Key is not valid");
			}
			Node node = nodes[key.node];
			if (!node.isAllocated)
			{
				throw new ArgumentException("Key does not point to an allocated node");
			}
			if (!node.isLeaf)
			{
				throw new ArgumentException("Key does not point to a leaf node");
			}
			return node.bounds;
		}

		private int AllocNode()
		{
			if (!freeNodes.TryPop(out var result))
			{
				int num = nodes.Length;
				Memory.Realloc(ref nodes, Mathf.Max(8, nodes.Length * 2));
				for (int num2 = nodes.Length - 1; num2 >= num; num2--)
				{
					FreeNode(num2);
				}
				return freeNodes.Pop();
			}
			return result;
		}

		private void FreeNode(int node)
		{
			nodes[node].isAllocated = false;
			nodes[node].value = default(T);
			freeNodes.Push(node);
		}

		public void Rebuild()
		{
			UnsafeSpan<int> unsafeSpan = new UnsafeSpan<int>(Allocator.Temp, nodes.Length);
			int num = 0;
			for (int i = 0; i < nodes.Length; i++)
			{
				if (nodes[i].isAllocated)
				{
					if (nodes[i].isLeaf)
					{
						unsafeSpan[num++] = i;
					}
					else
					{
						FreeNode(i);
					}
				}
			}
			root = Rebuild(unsafeSpan.Slice(0, num), 536870911);
			rebuildCounter = Mathf.Max(64, num / 3);
		}

		public void Clear()
		{
			for (int i = 0; i < nodes.Length; i++)
			{
				if (nodes[i].isAllocated)
				{
					FreeNode(i);
				}
			}
			root = -1;
			rebuildCounter = 64;
		}

		private static int ArgMax(Vector3 v)
		{
			float num = Mathf.Max(v.x, Mathf.Max(v.y, v.z));
			if (num != v.x)
			{
				if (num != v.y)
				{
					return 2;
				}
				return 1;
			}
			return 0;
		}

		private int Rebuild(UnsafeSpan<int> leaves, int parent)
		{
			if (leaves.Length == 0)
			{
				return -1;
			}
			if (leaves.Length == 1)
			{
				nodes[leaves[0]].parent = parent;
				return leaves[0];
			}
			Bounds bounds = nodes[leaves[0]].bounds;
			for (int i = 1; i < leaves.Length; i++)
			{
				bounds.Encapsulate(nodes[leaves[i]].bounds);
			}
			leaves.Sort(new AABBComparer
			{
				nodes = nodes,
				dim = ArgMax(bounds.extents)
			});
			int num = AllocNode();
			nodes[num] = new Node
			{
				bounds = bounds,
				left = Rebuild(leaves.Slice(0, leaves.Length / 2), num),
				right = Rebuild(leaves.Slice(leaves.Length / 2), num),
				parent = parent,
				isAllocated = true
			};
			return num;
		}

		public void Move(Key key, Bounds bounds)
		{
			T value = nodes[key.node].value;
			Remove(key);
			Add(bounds, value);
		}

		[Conditional("VALIDATE_AABB_TREE")]
		private void Validate(int node)
		{
			if (node != -1)
			{
				Node node2 = nodes[node];
				_ = root;
				_ = node2.isLeaf;
			}
		}

		public Bounds Remove(Key key)
		{
			if (!key.isValid)
			{
				throw new ArgumentException("Key is not valid");
			}
			Node node = nodes[key.node];
			if (!node.isAllocated)
			{
				throw new ArgumentException("Key does not point to an allocated node");
			}
			if (!node.isLeaf)
			{
				throw new ArgumentException("Key does not point to a leaf node");
			}
			if (key.node == root)
			{
				root = -1;
				FreeNode(key.node);
				return node.bounds;
			}
			int parent = node.parent;
			Node node2 = nodes[parent];
			int num = ((node2.left == key.node) ? node2.right : node2.left);
			FreeNode(parent);
			FreeNode(key.node);
			nodes[num].parent = node2.parent;
			if (node2.parent == 536870911)
			{
				root = num;
			}
			else if (nodes[node2.parent].left == parent)
			{
				nodes[node2.parent].left = num;
			}
			else
			{
				nodes[node2.parent].right = num;
			}
			int parent2 = nodes[num].parent;
			while (parent2 != 536870911)
			{
				ref Node reference = ref nodes[parent2];
				Bounds bounds = nodes[reference.left].bounds;
				bounds.Encapsulate(nodes[reference.right].bounds);
				reference.bounds = bounds;
				reference.subtreePartiallyTagged = nodes[reference.left].subtreePartiallyTagged | nodes[reference.right].subtreePartiallyTagged;
				parent2 = reference.parent;
			}
			return node.bounds;
		}

		public Key Add(Bounds bounds, T value)
		{
			int num = AllocNode();
			nodes[num] = new Node
			{
				bounds = bounds,
				parent = 536870911,
				left = -1,
				right = -1,
				value = value,
				isAllocated = true
			};
			if (root == -1)
			{
				root = num;
				return new Key(num);
			}
			int num2 = root;
			Node node;
			while (true)
			{
				node = nodes[num2];
				nodes[num2].wholeSubtreeTagged = false;
				if (node.isLeaf)
				{
					break;
				}
				nodes[num2].bounds.Encapsulate(bounds);
				float num3 = ExpansionRequired(nodes[node.left].bounds, bounds);
				float num4 = ExpansionRequired(nodes[node.right].bounds, bounds);
				num2 = ((num3 < num4) ? node.left : node.right);
			}
			int num5 = AllocNode();
			if (node.parent != 536870911)
			{
				if (nodes[node.parent].left == num2)
				{
					nodes[node.parent].left = num5;
				}
				else
				{
					nodes[node.parent].right = num5;
				}
			}
			bounds.Encapsulate(node.bounds);
			nodes[num5] = new Node
			{
				bounds = bounds,
				left = num2,
				right = num,
				parent = node.parent,
				isAllocated = true
			};
			ref Node reference = ref nodes[num];
			int parent = (nodes[num2].parent = num5);
			reference.parent = parent;
			if (root == num2)
			{
				root = num5;
			}
			if (rebuildCounter-- <= 0)
			{
				Rebuild();
			}
			return new Key(num);
		}

		public void Query(Bounds bounds, List<T> buffer)
		{
			QueryNode(root, bounds, buffer);
		}

		private void QueryNode(int node, Bounds bounds, List<T> buffer)
		{
			if (node != -1 && bounds.Intersects(nodes[node].bounds))
			{
				if (nodes[node].isLeaf)
				{
					buffer.Add(nodes[node].value);
					return;
				}
				QueryNode(nodes[node].left, bounds, buffer);
				QueryNode(nodes[node].right, bounds, buffer);
			}
		}

		public void QueryTagged(List<T> buffer, bool clearTags = false)
		{
			QueryTaggedNode(root, clearTags, buffer);
		}

		private void QueryTaggedNode(int node, bool clearTags, List<T> buffer)
		{
			if (node != -1 && nodes[node].subtreePartiallyTagged)
			{
				if (clearTags)
				{
					nodes[node].wholeSubtreeTagged = false;
					nodes[node].subtreePartiallyTagged = false;
				}
				if (nodes[node].isLeaf)
				{
					buffer.Add(nodes[node].value);
					return;
				}
				QueryTaggedNode(nodes[node].left, clearTags, buffer);
				QueryTaggedNode(nodes[node].right, clearTags, buffer);
			}
		}

		public void Tag(Key key)
		{
			if (!key.isValid)
			{
				throw new ArgumentException("Key is not valid");
			}
			if (key.node < 0 || key.node >= nodes.Length)
			{
				throw new ArgumentException("Key does not point to a valid node");
			}
			ref Node reference = ref nodes[key.node];
			if (!reference.isAllocated)
			{
				throw new ArgumentException("Key does not point to an allocated node");
			}
			if (!reference.isLeaf)
			{
				throw new ArgumentException("Key does not point to a leaf node");
			}
			reference.wholeSubtreeTagged = true;
			for (int num = key.node; num != 536870911; num = nodes[num].parent)
			{
				nodes[num].subtreePartiallyTagged = true;
			}
		}

		public void Tag(Bounds bounds)
		{
			TagNode(root, bounds);
		}

		private bool TagNode(int node, Bounds bounds)
		{
			if (node == -1 || nodes[node].wholeSubtreeTagged)
			{
				return true;
			}
			if (!bounds.Intersects(nodes[node].bounds))
			{
				return false;
			}
			nodes[node].subtreePartiallyTagged = true;
			if (nodes[node].isLeaf)
			{
				return nodes[node].wholeSubtreeTagged = true;
			}
			return nodes[node].wholeSubtreeTagged = TagNode(nodes[node].left, bounds) & TagNode(nodes[node].right, bounds);
		}
	}
}
