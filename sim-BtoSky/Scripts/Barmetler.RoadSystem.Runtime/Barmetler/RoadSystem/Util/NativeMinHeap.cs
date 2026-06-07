using System;
using System.Diagnostics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Barmetler.RoadSystem.Util
{
	[GenerateTestsForBurstCompatibility]
	[DebuggerDisplay("Length = {Count}/{_nodes.Length}")]
	public struct NativeMinHeap
	{
		private struct Node
		{
			public int Index;

			public float Priority;
		}

		private NativeArray<Node> _nodes;

		private NativeArray<int> _indices;

		public int Count { get; private set; }

		public int Min => _nodes[0].Index;

		public NativeMinHeap(int size, Allocator allocator)
		{
			_nodes = new NativeArray<Node>(size, allocator);
			_indices = new NativeArray<int>(size, allocator);
			Count = 0;
			for (int i = 0; i < _indices.Length; i++)
			{
				_indices[i] = -1;
			}
		}

		private static int Parent(int i)
		{
			return (i - 1) / 2;
		}

		private static int Left(int i)
		{
			return 2 * i + 1;
		}

		private static int Right(int i)
		{
			return 2 * i + 2;
		}

		[WriteAccessRequired]
		public void Insert(int index, float priority)
		{
			_nodes[Count] = new Node
			{
				Index = index,
				Priority = priority
			};
			_indices[index] = Count;
			int count = Count + 1;
			Count = count;
			SiftUp(Count - 1);
		}

		[WriteAccessRequired]
		public int ExtractMin()
		{
			int min = Min;
			Swap(0, Count - 1);
			_indices[min] = -1;
			int count = Count - 1;
			Count = count;
			SiftDown(0);
			return min;
		}

		[WriteAccessRequired]
		public void Update(int index, float priority)
		{
			int num = _indices[index];
			float priority2 = _nodes[num].Priority;
			_nodes[num] = new Node
			{
				Index = index,
				Priority = priority
			};
			if (priority < priority2)
			{
				SiftUp(num);
			}
			else
			{
				SiftDown(num);
			}
		}

		public bool Contains(int index)
		{
			return _indices[index] != -1;
		}

		[WriteAccessRequired]
		public void InsertOrUpdate(int index, float priority)
		{
			if (Contains(index))
			{
				Update(index, priority);
			}
			else
			{
				Insert(index, priority);
			}
		}

		[WriteAccessRequired]
		public void Dispose()
		{
			_nodes.Dispose();
			_indices.Dispose();
			Count = 0;
		}

		public void Dispose(JobHandle inputDeps)
		{
			_nodes.Dispose(inputDeps);
			_indices.Dispose(inputDeps);
		}

		public int[] ToArray()
		{
			NativeMinHeap destination = new NativeMinHeap(_nodes.Length, Allocator.Temp);
			Copy(in this, ref destination);
			int[] array = new int[Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = destination.ExtractMin();
			}
			destination.Dispose();
			return array;
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private static void CheckCopyLengths(int sourceLength, int destinationLength)
		{
			if (sourceLength != destinationLength)
			{
				throw new InvalidOperationException("source and destination length must be the same");
			}
		}

		[WriteAccessRequired]
		public void CopyFrom(in NativeMinHeap other)
		{
			Copy(in other, ref this);
		}

		public void CopyTo(ref NativeMinHeap other)
		{
			Copy(in this, ref other);
		}

		public static void Copy(in NativeMinHeap source, ref NativeMinHeap destination)
		{
			destination.Count = source.Count;
			NativeArray<Node>.Copy(source._nodes, destination._nodes);
			NativeArray<int>.Copy(source._indices, destination._indices);
		}

		private void Swap(int a, int b)
		{
			int index = _nodes[a].Index;
			int index2 = _nodes[b].Index;
			_indices[index] = b;
			_indices[index2] = a;
			Node value = _nodes[a];
			_nodes[a] = _nodes[b];
			_nodes[b] = value;
		}

		private void SiftUp(int i)
		{
			while (i != 0 && _nodes[Parent(i)].Priority > _nodes[i].Priority)
			{
				Swap(i, Parent(i));
				i = Parent(i);
			}
		}

		private void SiftDown(int i)
		{
			while (Left(i) < Count)
			{
				if (Right(i) >= Count)
				{
					if (_nodes[i].Priority > _nodes[Left(i)].Priority)
					{
						Swap(i, Left(i));
					}
					break;
				}
				if (_nodes[i].Priority <= _nodes[Left(i)].Priority && _nodes[i].Priority <= _nodes[Right(i)].Priority)
				{
					break;
				}
				if (_nodes[Left(i)].Priority < _nodes[Right(i)].Priority)
				{
					Swap(i, Left(i));
					i = Left(i);
				}
				else
				{
					Swap(i, Right(i));
					i = Right(i);
				}
			}
		}
	}
}
