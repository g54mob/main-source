using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.NotBurstCompatible;
using Unity.Mathematics;

namespace Pug.UnityExtensions
{
	[GenerateTestsForBurstCompatibility]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(NativeUnionFindDebugView))]
	public struct NativeUnionFind : IDisposable
	{
		private NativeList<int> _parent;

		private NativeList<int> _rank;

		public int Count => _parent.Length;

		public NativeUnionFind(int size, AllocatorManager.AllocatorHandle allocator, int initialCapacity = -1)
		{
			initialCapacity = math.max(size, initialCapacity);
			_parent = new NativeList<int>(initialCapacity, allocator);
			_rank = new NativeList<int>(initialCapacity, allocator);
			ResizeAndReset(size);
		}

		public void Dispose()
		{
			_parent.Dispose();
			_rank.Dispose();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ResizeAndReset(int newSize)
		{
			_parent.ResizeUninitialized(newSize);
			_rank.ResizeUninitialized(newSize);
			Reset();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Reset()
		{
			for (int i = 0; i < _parent.Length; i++)
			{
				_parent[i] = i;
				_rank[i] = 0;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Merge(int a, int b)
		{
			a = FindRoot(a);
			b = FindRoot(b);
			if (a != b)
			{
				if (_rank[a] > _rank[b])
				{
					_parent[b] = a;
					return;
				}
				if (_rank[a] < _rank[b])
				{
					_parent[a] = b;
					return;
				}
				_parent[a] = b;
				_rank[b]++;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool AreInSameSet(int a, int b)
		{
			return FindRoot(a) == FindRoot(b);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int FindRoot(int a)
		{
			int num = a;
			while (_parent[num] != num)
			{
				num = _parent[num];
			}
			while (_parent[a] != num)
			{
				int num2 = _parent[a];
				_parent[a] = num;
				a = num2;
			}
			return num;
		}

		internal int[] ToArray()
		{
			return _parent.ToArrayNBC();
		}
	}
}
