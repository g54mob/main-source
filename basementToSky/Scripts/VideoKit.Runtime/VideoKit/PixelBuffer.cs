using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using VideoKit.Internal;

namespace VideoKit
{
	public readonly struct PixelBuffer : IDisposable
	{
		public enum Format
		{
			Unknown = 0,
			YCbCr420 = 1,
			RGBA8888 = 2,
			BGRA8888 = 3
		}

		public enum Rotation
		{
			_0 = 0,
			_90 = 3,
			_180 = 2,
			_270 = 1
		}

		public readonly struct Plane
		{
			private readonly IntPtr pixelBuffer;

			private readonly int index;

			public unsafe NativeArray<byte> data
			{
				get
				{
					pixelBuffer.GetPixelBufferPlaneData(index, out var planeData).Throw();
					pixelBuffer.GetPixelBufferPlaneDataSize(index, out var dataSize).Throw();
					return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(planeData, dataSize, Allocator.None);
				}
			}

			public int width
			{
				get
				{
					if (pixelBuffer.GetPixelBufferPlaneWidth(index, out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
					{
						return 0;
					}
					return result;
				}
			}

			public int height
			{
				get
				{
					if (pixelBuffer.GetPixelBufferPlaneHeight(index, out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
					{
						return 0;
					}
					return result;
				}
			}

			public int rowStride
			{
				get
				{
					if (pixelBuffer.GetPixelBufferPlaneRowStride(index, out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
					{
						return 0;
					}
					return result;
				}
			}

			public int pixelStride
			{
				get
				{
					if (pixelBuffer.GetPixelBufferPlanePixelStride(index, out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
					{
						return 0;
					}
					return result;
				}
			}

			internal Plane(IntPtr pixelBuffer, int index)
			{
				this.pixelBuffer = pixelBuffer;
				this.index = index;
			}
		}

		private readonly struct NativePlanes : IReadOnlyList<Plane>, IEnumerable<Plane>, IEnumerable, IReadOnlyCollection<Plane>
		{
			private readonly IntPtr pixelBuffer;

			int IReadOnlyCollection<Plane>.Count
			{
				get
				{
					if (pixelBuffer.GetPixelBufferPlaneCount(out var planeCount) != VideoKit.Internal.VideoKit.Status.Ok)
					{
						return 0;
					}
					return planeCount;
				}
			}

			Plane IReadOnlyList<Plane>.this[int index] => new Plane(pixelBuffer, index);

			public NativePlanes(IntPtr pixelBuffer)
			{
				this.pixelBuffer = pixelBuffer;
			}

			IEnumerator<Plane> IEnumerable<Plane>.GetEnumerator()
			{
				pixelBuffer.GetPixelBufferPlaneCount(out var count);
				int idx = 0;
				while (idx < count)
				{
					yield return new Plane(pixelBuffer, idx);
					int num = idx + 1;
					idx = num;
				}
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Plane>)this).GetEnumerator();
			}
		}

		private readonly IntPtr handle;

		private readonly NativeArray<byte> dataBuffer;

		public unsafe NativeArray<byte> data
		{
			get
			{
				if (dataBuffer.IsCreated)
				{
					return dataBuffer;
				}
				handle.GetPixelBufferData(out var ptr);
				handle.GetPixelBufferDataSize(out var size);
				if (ptr == null)
				{
					return default(NativeArray<byte>);
				}
				return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>(ptr, size, Allocator.None);
			}
		}

		public Format format
		{
			get
			{
				if (handle.GetPixelBufferFormat(out var result) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return Format.Unknown;
				}
				return result;
			}
		}

		public int width
		{
			get
			{
				if (handle.GetPixelBufferWidth(out var result) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0;
				}
				return result;
			}
		}

		public int height
		{
			get
			{
				if (handle.GetPixelBufferHeight(out var result) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0;
				}
				return result;
			}
		}

		public int rowStride
		{
			get
			{
				if (handle.GetPixelBufferRowStride(out var result) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0;
				}
				return result;
			}
		}

		public long timestamp
		{
			get
			{
				if (handle.GetSampleBufferTimestamp(out var result) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0L;
				}
				return result;
			}
		}

		public bool verticallyMirrored
		{
			get
			{
				if (handle.GetPixelBufferIsVerticallyMirrored(out var mirrored) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return false;
				}
				return mirrored;
			}
		}

		public IReadOnlyList<Plane>? planes
		{
			get
			{
				IReadOnlyList<Plane> readOnlyList = new NativePlanes(this);
				if (readOnlyList.Count <= 0)
				{
					return null;
				}
				return readOnlyList;
			}
		}

		public Dictionary<string, object>? metadata
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(8192);
				if (handle.CopyPixelBufferMetadata(stringBuilder, stringBuilder.Capacity) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return null;
				}
				return JsonConvert.DeserializeObject<Dictionary<string, object>>(stringBuilder.ToString());
			}
		}

		public PixelBuffer(Texture2D texture, long timestamp = 0L, bool mirrored = false)
			: this(texture.width, texture.height, ToImageFormat(texture.format), texture.GetRawTextureData<byte>(), 0, timestamp, mirrored)
		{
		}

		public PixelBuffer(int width, int height, Format format, byte[] data, int rowStride = 0, long timestamp = 0L, bool mirrored = false)
			: this(width, height, format, rowStride, timestamp, mirrored)
		{
			dataBuffer.CopyFrom(data);
		}

		public unsafe PixelBuffer(int width, int height, Format format, NativeArray<byte> data, int rowStride = 0, long timestamp = 0L, bool mirrored = false)
			: this(width, height, format, (byte*)data.GetUnsafePtr(), rowStride, timestamp, mirrored)
		{
		}

		public unsafe PixelBuffer(int width, int height, Format format, byte* data, int rowStride = 0, long timestamp = 0L, bool mirrored = false)
		{
			VideoKit.Internal.VideoKit.CreatePixelBuffer(width, height, format, data, (rowStride > 0) ? rowStride : GetDefaultStride(format, width), timestamp, mirrored, out handle).Throw();
			dataBuffer = default(NativeArray<byte>);
		}

		public void Dispose()
		{
			handle.ReleaseSampleBuffer();
			dataBuffer.Dispose();
		}

		public void CopyTo(PixelBuffer destination, Rotation rotation = Rotation._0)
		{
			handle.CopyToPixelBuffer(destination, rotation).Throw();
		}

		internal PixelBuffer(IntPtr handle)
		{
			this.handle = handle;
			dataBuffer = default(NativeArray<byte>);
		}

		internal unsafe PixelBuffer(int width, int height, Format format, int rowStride = 0, long timestamp = 0L, bool mirrored = false)
		{
			rowStride = ((rowStride > 0) ? rowStride : GetDefaultStride(format, width));
			dataBuffer = new NativeArray<byte>(rowStride * height, Allocator.Persistent);
			VideoKit.Internal.VideoKit.CreatePixelBuffer(width, height, format, (byte*)dataBuffer.GetUnsafePtr(), rowStride, timestamp, mirrored, out handle).Throw();
		}

		public static implicit operator IntPtr(PixelBuffer pixelBuffer)
		{
			return pixelBuffer.handle;
		}

		private static Format ToImageFormat(TextureFormat format)
		{
			return format switch
			{
				TextureFormat.RGBA32 => Format.RGBA8888, 
				TextureFormat.BGRA32 => Format.BGRA8888, 
				_ => throw new ArgumentException($"Cannot create pixel buffer from texture with format: {format}"), 
			};
		}

		private static int GetDefaultStride(Format format, int width)
		{
			return format switch
			{
				Format.RGBA8888 => width * 4, 
				Format.BGRA8888 => width * 4, 
				_ => throw new ArgumentException($"Cannot infer default stride for format: {format}"), 
			};
		}
	}
}
