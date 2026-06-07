using System;
using Unity.Collections;

namespace MagicaCloth2
{
	public class ExSimpleNativeArray<T> : IDisposable where T : struct
	{
		[Serializable]
		public class SerializationData
		{
			public int count;

			public int length;

			public byte[] arrayBytes;
		}

		private NativeArray<T> nativeArray;

		private int count;

		private int length;

		public bool IsValid => false;

		public int Count => 0;

		public int Length => 0;

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

		public ExSimpleNativeArray()
		{
		}

		public ExSimpleNativeArray(int dataLength, bool areaOnly = false)
		{
		}

		public ExSimpleNativeArray(T[] dataArray)
		{
		}

		public ExSimpleNativeArray(NativeArray<T> array)
		{
		}

		public ExSimpleNativeArray(NativeList<T> array)
		{
		}

		public ExSimpleNativeArray(SerializationData sdata)
		{
		}

		public void Dispose()
		{
		}

		public void SetCount(int newCount)
		{
		}

		public void SetLength(int newLength)
		{
		}

		public void AddRange(int dataLength)
		{
		}

		public void AddRange(T[] dataArray)
		{
		}

		public void AddRange(T[] dataArray, int cnt)
		{
		}

		public void AddRange(int dataLength, T fillData = default(T))
		{
		}

		public void AddRange(NativeArray<T> narray)
		{
		}

		public void AddRange(NativeArray<T> narray, int start, int length)
		{
		}

		public void AddRange(NativeList<T> nlist)
		{
		}

		public void AddRange(ExSimpleNativeArray<T> exarray)
		{
		}

		public void AddRange<U>(U[] array) where U : struct
		{
		}

		public void AddRangeTypeChange<U>(U[] array) where U : struct
		{
		}

		public void AddRangeTypeChange<U>(NativeArray<U> array) where U : struct
		{
		}

		public void AddRangeStride<U>(U[] array) where U : struct
		{
		}

		public void Add(T data)
		{
		}

		public T[] ToArray()
		{
			return null;
		}

		public void CopyTo(T[] array)
		{
		}

		public void CopyTo<U>(U[] array) where U : struct
		{
		}

		public void CopyToWithTypeChange<U>(U[] array) where U : struct
		{
		}

		public void CopyToWithTypeChangeStride<U>(U[] array) where U : struct
		{
		}

		public void CopyFrom(NativeArray<T> array)
		{
		}

		public void CopyFrom<U>(NativeArray<U> array) where U : struct
		{
		}

		public void CopyFromWithTypeChangeStride<U>(NativeArray<U> array) where U : struct
		{
		}

		public void Fill(int startIndex, int dataLength, T fillData = default(T))
		{
		}

		private void FillInternal(int start, int size, T fillData = default(T))
		{
		}

		public NativeArray<T> GetNativeArray()
		{
			return default(NativeArray<T>);
		}

		public NativeArray<U> GetNativeArray<U>() where U : struct
		{
			return default(NativeArray<U>);
		}

		private void Expand(int dataLength, bool force = false, bool copy = true)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public SerializationData Serialize()
		{
			return null;
		}

		public bool Deserialize(SerializationData data)
		{
			return false;
		}
	}
}
