using System;
using Unity.Collections;

namespace MagicaCloth2
{
	public class MultiDataBuilder<T> : IDisposable where T : struct
	{
		private int indexCount;

		public NativeParallelMultiHashMap<int, T> Map;

		public MultiDataBuilder(int indexCount, int dataCapacity)
		{
		}

		public void Dispose()
		{
		}

		public int Count()
		{
			return 0;
		}

		public int GetDataCount(int index)
		{
			return 0;
		}

		public void Add(int key, T data)
		{
		}

		public int CountValuesForKey(int key)
		{
			return 0;
		}

		public (T[], uint[]) ToArray()
		{
			return default((T[], uint[]));
		}

		public uint[] ToIndexArray()
		{
			return null;
		}

		public void ToNativeArray(out NativeArray<uint> indexArray, out NativeArray<T> dataArray)
		{
			indexArray = default(NativeArray<uint>);
			dataArray = default(NativeArray<T>);
		}
	}
}
