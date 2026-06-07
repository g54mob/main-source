using System;
using System.Diagnostics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Barmetler.RoadSystem.Util
{
	[DebuggerDisplay("Length = {Length}")]
	[DebuggerTypeProxy(typeof(TwoDimensionalNativeArrayDebugView<>))]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[] { typeof(int) })]
	public struct TwoDimensionalNativeArray<T> where T : struct
	{
		public readonly int Width;

		public readonly int Height;

		public readonly int Length;

		private NativeArray<T> _data;

		public bool IsCreated => _data.IsCreated;

		public T this[int x, int y]
		{
			get
			{
				return _data[x + y * Width];
			}
			[WriteAccessRequired]
			set
			{
				_data[x + y * Width] = value;
			}
		}

		public T this[int index]
		{
			get
			{
				return _data[index];
			}
			[WriteAccessRequired]
			set
			{
				_data[index] = value;
			}
		}

		public TwoDimensionalNativeArray(int width, int height, Allocator allocator)
		{
			if (width < 0 || height < 0)
			{
				throw new ArgumentException("Width and height must be >= 0");
			}
			Width = width;
			Height = height;
			Length = width * height;
			_data = new NativeArray<T>(width * height, allocator);
		}

		[WriteAccessRequired]
		public void Dispose()
		{
			_data.Dispose();
		}

		public void Dispose(JobHandle inputDeps)
		{
			_data.Dispose(inputDeps);
		}

		public unsafe ref T ElementAt(int x, int y)
		{
			return ref UnsafeUtility.ArrayElementAsRef<T>(_data.GetUnsafePtr(), x + y * Width);
		}

		public unsafe ref T ElementAt(int index)
		{
			return ref UnsafeUtility.ArrayElementAsRef<T>(_data.GetUnsafePtr(), index);
		}

		public unsafe void* GetUnsafePtr()
		{
			return _data.GetUnsafePtr();
		}

		public NativeArray<T> AsNativeArray()
		{
			return _data;
		}

		public T[] ToArray()
		{
			return _data.ToArray();
		}

		public void CopyFrom(T[] array)
		{
			_data.CopyFrom(array);
		}
	}
}
