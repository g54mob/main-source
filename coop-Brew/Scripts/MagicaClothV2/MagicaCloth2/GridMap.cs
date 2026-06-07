using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;

namespace MagicaCloth2
{
	public class GridMap<T> : IDisposable where T : struct
	{
		public struct GridEnumerator : IEnumerator<int3>, IEnumerator, IDisposable
		{
			internal NativeParallelMultiHashMap<int3, T> gridMap;

			internal int3 startGrid;

			internal int3 endGrid;

			internal int3 currentGrid;

			internal bool isFirst;

			public int3 Current => default(int3);

			object IEnumerator.Current => null;

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				return false;
			}

			public void Reset()
			{
			}

			public GridEnumerator GetEnumerator()
			{
				return default(GridEnumerator);
			}
		}

		private NativeParallelMultiHashMap<int3, T> gridMap;

		public int DataCount => 0;

		public GridMap(int capacity = 0)
		{
		}

		public void Dispose()
		{
		}

		public NativeParallelMultiHashMap<int3, T> GetMultiHashMap()
		{
			return default(NativeParallelMultiHashMap<int3, T>);
		}

		public static GridEnumerator GetArea(int3 startGrid, int3 endGrid, NativeParallelMultiHashMap<int3, T> gridMap)
		{
			return default(GridEnumerator);
		}

		public static GridEnumerator GetArea(float3 pos, float radius, NativeParallelMultiHashMap<int3, T> gridMap, float gridSize)
		{
			return default(GridEnumerator);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 GetGrid(float3 pos, float gridSize)
		{
			return default(int3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddGrid(int3 grid, T data, NativeParallelMultiHashMap<int3, T> gridMap)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 AddGrid(float3 pos, T data, NativeParallelMultiHashMap<int3, T> gridMap, float gridSize)
		{
			return default(int3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 AddGrid(float3 pos, T data, NativeParallelMultiHashMap<int3, T>.ParallelWriter gridMap, float gridSize)
		{
			return default(int3);
		}

		public static bool RemoveGrid(int3 grid, T data, NativeParallelMultiHashMap<int3, T> gridMap)
		{
			return false;
		}

		public static bool MoveGrid(int3 fromGrid, int3 toGrid, T data, NativeParallelMultiHashMap<int3, T> gridMap)
		{
			return false;
		}
	}
}
