using System;
using System.Diagnostics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace Barmetler.RoadSystem.Util
{
	[DebuggerDisplay("Length = {Length}")]
	[DebuggerTypeProxy(typeof(ExtendedTwoDimensionalNativeArrayDebugView<>))]
	[GenerateTestsForBurstCompatibility(GenericTypeArguments = new Type[] { typeof(int) })]
	public struct ExtendedTwoDimensionalNativeArray<T> where T : struct
	{
		private enum Location
		{
			Horizontal = 0,
			Vertical = 1,
			Data = 2
		}

		public readonly int Width;

		public readonly int Height;

		public readonly int StartX;

		public readonly int StartY;

		public readonly int Length;

		private TwoDimensionalNativeArray<T> _data;

		private TwoDimensionalNativeArray<T> _horizontal;

		private TwoDimensionalNativeArray<T> _vertical;

		public bool IsCreated => _data.IsCreated;

		public T this[int x, int y]
		{
			get
			{
				GetDataLocation(x, y, out var location, out var index);
				return location switch
				{
					Location.Horizontal => _horizontal[index], 
					Location.Vertical => _vertical[index], 
					Location.Data => _data[index], 
					_ => default(T), 
				};
			}
			set
			{
				GetDataLocation(x, y, out var location, out var index);
				switch (location)
				{
				case Location.Horizontal:
					_horizontal[index] = value;
					break;
				case Location.Vertical:
					_vertical[index] = value;
					break;
				case Location.Data:
					_data[index] = value;
					break;
				}
			}
		}

		public T this[int index]
		{
			get
			{
				return this[index % Width, index / Width];
			}
			set
			{
				this[index % Width, index / Width] = value;
			}
		}

		public ExtendedTwoDimensionalNativeArray(TwoDimensionalNativeArray<T> data, int startX, int startY, int width, int height, Allocator allocator)
		{
			if (startX + data.Width > width || startY + data.Height > height)
			{
				throw new ArgumentException("Data does not fit into the array.");
			}
			Width = width;
			Height = height;
			StartX = startX;
			StartY = startY;
			Length = width * height;
			_data = data;
			_horizontal = new TwoDimensionalNativeArray<T>(width, height - _data.Height, allocator);
			_vertical = new TwoDimensionalNativeArray<T>(width - _data.Width, _data.Height, allocator);
		}

		[WriteAccessRequired]
		public void Dispose()
		{
			_horizontal.Dispose();
			_vertical.Dispose();
		}

		public void Dispose(JobHandle inputDeps)
		{
			_horizontal.Dispose(inputDeps);
			_vertical.Dispose(inputDeps);
		}

		private void GetDataLocation(int x, int y, out Location location, out int index)
		{
			if (y < StartY)
			{
				location = Location.Horizontal;
				index = y * Width + x;
			}
			else if (y >= StartY + _data.Height)
			{
				location = Location.Horizontal;
				index = (y - _data.Height) * Width + x;
			}
			else if (x < StartX)
			{
				location = Location.Vertical;
				index = (y - StartY) * _vertical.Width + x;
			}
			else if (x >= StartX + _data.Width)
			{
				location = Location.Vertical;
				index = (y - StartY) * _vertical.Width + (x - _data.Width);
			}
			else
			{
				location = Location.Data;
				index = (y - StartY) * _data.Width + (x - StartX);
			}
		}

		public unsafe ref T ElementAt(int x, int y)
		{
			GetDataLocation(x, y, out var location, out var index);
			return location switch
			{
				Location.Horizontal => ref _horizontal.ElementAt(index), 
				Location.Vertical => ref _vertical.ElementAt(index), 
				Location.Data => ref _data.ElementAt(index), 
				_ => ref UnsafeUtility.AsRef<T>(null), 
			};
		}

		public ref T ElementAt(int index)
		{
			return ref ElementAt(index % Width, index / Width);
		}

		public T[] ToArray()
		{
			NativeArray<T> thisArray = new NativeArray<T>(Length, Allocator.Temp);
			NativeArray<T> thisArray2 = _horizontal.AsNativeArray();
			NativeArray<T> thisArray3 = _vertical.AsNativeArray();
			NativeArray<T> nativeArray = _data.AsNativeArray();
			if (StartY > 0)
			{
				thisArray.Slice(0, StartY * Width).CopyFrom(thisArray2.Slice(0, StartY * Width));
			}
			if (Width == _data.Width)
			{
				thisArray.Slice(StartY * Width, _data.Length).CopyFrom(nativeArray);
			}
			else
			{
				for (int i = 0; i < _data.Height; i++)
				{
					if (StartX > 0)
					{
						thisArray.Slice((StartY + i) * Width, StartX).CopyFrom(thisArray3.Slice(i * _vertical.Width, StartX));
					}
					if (_data.Width > 0)
					{
						thisArray.Slice((StartY + i) * Width + StartX, _data.Width).CopyFrom(nativeArray.Slice(i * _data.Width, _data.Width));
					}
					if (StartX + _data.Width < Width)
					{
						thisArray.Slice((StartY + i) * Width + StartX + _data.Width, Width - StartX - _data.Width).CopyFrom(thisArray3.Slice(i * _vertical.Width + StartX, Width - StartX - _data.Width));
					}
				}
			}
			if (StartY + _data.Height < Height)
			{
				thisArray.Slice((StartY + _data.Height) * Width, (Height - StartY - _data.Height) * Width).CopyFrom(thisArray2.Slice((Height - StartY - _data.Height) * Width));
			}
			T[] result = thisArray.ToArray();
			thisArray.Dispose();
			return result;
		}
	}
}
