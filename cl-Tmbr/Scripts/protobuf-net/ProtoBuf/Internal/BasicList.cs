using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ProtoBuf.Internal
{
	internal sealed class BasicList : IEnumerable
	{
		[StructLayout(LayoutKind.Auto)]
		public struct NodeEnumerator : IEnumerator
		{
			private int position;

			private readonly Node node;

			public readonly object Current => node[position];

			internal NodeEnumerator(Node node)
			{
				position = -1;
				this.node = node;
			}

			void IEnumerator.Reset()
			{
				position = -1;
			}

			public bool MoveNext()
			{
				int length = node.Length;
				if (position <= length)
				{
					return ++position < length;
				}
				return false;
			}
		}

		[StructLayout(LayoutKind.Auto)]
		internal readonly struct Node
		{
			private readonly object[] data;

			public object this[int index]
			{
				get
				{
					if (index >= 0 && index < Length)
					{
						return data[index];
					}
					throw new ArgumentOutOfRangeException("index");
				}
				set
				{
					if (index >= 0 && index < Length)
					{
						data[index] = value;
						return;
					}
					throw new ArgumentOutOfRangeException("index");
				}
			}

			public int Length { get; }

			internal Node(object[] data, int length)
			{
				this.data = data;
				Length = length;
			}

			public Node Append(object value)
			{
				int length = Length + 1;
				object[] array;
				if (data == null)
				{
					array = new object[10];
				}
				else if (Length == data.Length)
				{
					array = new object[data.Length * 2];
					Array.Copy(data, array, Length);
				}
				else
				{
					array = data;
				}
				array[Length] = value;
				return new Node(array, length);
			}

			internal int IndexOfReference(object instance)
			{
				for (int i = 0; i < Length; i++)
				{
					if (instance == data[i])
					{
						return i;
					}
				}
				return -1;
			}

			internal int IndexOf(MatchPredicate predicate, object ctx)
			{
				for (int i = 0; i < Length; i++)
				{
					if (predicate(data[i], ctx))
					{
						return i;
					}
				}
				return -1;
			}
		}

		internal delegate bool MatchPredicate(object value, object ctx);

		[StructLayout(LayoutKind.Auto)]
		internal readonly struct Group<T>
		{
			public readonly int First;

			public readonly List<T> Items;

			public bool IsEmpty => Items == null;

			public Group(int first)
			{
				First = first;
				Items = new List<T>();
			}
		}

		private static readonly Node nil = new Node(null, 0);

		private Node head = nil;

		public object this[int index] => head[index];

		public int Count => head.Length;

		public int Add(object value)
		{
			Node node = (head = head.Append(value));
			return node.Length - 1;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new NodeEnumerator(head);
		}

		public NodeEnumerator GetEnumerator()
		{
			return new NodeEnumerator(head);
		}

		internal int IndexOf(MatchPredicate predicate, object ctx)
		{
			return head.IndexOf(predicate, ctx);
		}

		internal bool Contains(object value)
		{
			NodeEnumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				if (object.Equals(current, value))
				{
					return true;
				}
			}
			return false;
		}

		internal static List<Group<T>> GetContiguousGroups<T>(int[] keys, T[] values)
		{
			if (keys == null)
			{
				throw new ArgumentNullException("keys");
			}
			if (values == null)
			{
				throw new ArgumentNullException("values");
			}
			if (values.Length < keys.Length)
			{
				throw new ArgumentException("Not all keys are covered by values", "values");
			}
			List<Group<T>> list = new List<Group<T>>();
			Group<T> item = default(Group<T>);
			for (int i = 0; i < keys.Length; i++)
			{
				if (i == 0 || keys[i] != keys[i - 1])
				{
					item = default(Group<T>);
				}
				if (item.IsEmpty)
				{
					item = new Group<T>(keys[i]);
					list.Add(item);
				}
				item.Items.Add(values[i]);
			}
			return list;
		}

		internal bool Any()
		{
			return Count != 0;
		}
	}
}
