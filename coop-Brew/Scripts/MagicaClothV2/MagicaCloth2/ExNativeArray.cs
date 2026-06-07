using System;
using System.Collections.Generic;
using Unity.Collections;

namespace MagicaCloth2
{
	public class ExNativeArray<T> : IDisposable where T : struct
	{
		private NativeArray<T> nativeArray;

		private List<DataChunk> emptyChunks;

		private int useCount;

		public bool IsValid => false;

		public int Length => 0;

		public int Count => 0;

		public T this[int index]
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public void Dispose()
		{
		}

		public ExNativeArray()
		{
		}

		public ExNativeArray(int emptyLength, bool create = false)
		{
		}

		public ExNativeArray(int emptyLength, T fillData)
		{
		}

		public ExNativeArray(NativeArray<T> dataArray)
		{
		}

		public ExNativeArray(T[] dataArray)
		{
		}

		public DataChunk AddRange(int dataLength)
		{
			return default(DataChunk);
		}

		public DataChunk AddRange(int dataLength, T fillData = default(T))
		{
			return default(DataChunk);
		}

		public DataChunk AddRange(T[] array)
		{
			return default(DataChunk);
		}

		public DataChunk AddRange(NativeArray<T> narray, int length = 0)
		{
			return default(DataChunk);
		}

		public DataChunk AddRange(ExNativeArray<T> exarray)
		{
			return default(DataChunk);
		}

		public DataChunk AddRange(ExSimpleNativeArray<T> exarray)
		{
			return default(DataChunk);
		}

		public DataChunk AddRange<U>(U[] array) where U : struct
		{
			return default(DataChunk);
		}

		public DataChunk AddRange<U>(NativeArray<U> udata) where U : struct
		{
			return default(DataChunk);
		}

		public DataChunk AddRangeTypeChange<U>(U[] array) where U : struct
		{
			return default(DataChunk);
		}

		public DataChunk AddRangeStride<U>(U[] array) where U : struct
		{
			return default(DataChunk);
		}

		public DataChunk Add(T data)
		{
			return default(DataChunk);
		}

		public DataChunk Expand(DataChunk c, int newDataLength)
		{
			return default(DataChunk);
		}

		public DataChunk ExpandAndFill(DataChunk c, int newDataLength, T fillData = default(T), T clearData = default(T))
		{
			return default(DataChunk);
		}

		public T[] ToArray()
		{
			return null;
		}

		public void CopyTo(T[] array)
		{
		}

		public void CopyTo(T[] array, int startIndex)
		{
		}

		public void CopyTo<U>(U[] array) where U : struct
		{
		}

		public void CopyFrom(NativeArray<T> array)
		{
		}

		public void CopyFrom(T[] array, int startIndex)
		{
		}

		public void CopyFrom<U>(NativeArray<U> array) where U : struct
		{
		}

		public void CopyFrom<U>(NativeArray<U> array, int dstIndex, int length) where U : struct
		{
		}

		public void CopyTypeChange<U>(U[] array) where U : struct
		{
		}

		public void CopyTypeChangeStride<U>(U[] array) where U : struct
		{
		}

		public void AddEmpty(int dataLength)
		{
		}

		public void Remove(DataChunk chunk)
		{
		}

		public void Remove(int index)
		{
		}

		public void RemoveAndFill(DataChunk chunk, T clearData = default(T))
		{
		}

		public void Fill(T fillData = default(T))
		{
		}

		public void Fill(DataChunk chunk, T fillData = default(T))
		{
		}

		private void FillInternal(int start, int size, T fillData = default(T))
		{
		}

		public void Clear()
		{
		}

		public ref T GetRef(int index)
		{
			throw null;
		}

		public NativeArray<T> GetNativeArray()
		{
			return default(NativeArray<T>);
		}

		public NativeArray<U> GetNativeArray<U>() where U : struct
		{
			return default(NativeArray<U>);
		}

		private DataChunk GetEmptyChunk(int dataLength)
		{
			return default(DataChunk);
		}

		private void AddEmptyChunk(DataChunk chunk)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public string ToSummary()
		{
			return null;
		}
	}
}
