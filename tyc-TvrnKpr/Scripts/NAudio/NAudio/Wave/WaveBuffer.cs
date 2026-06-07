using System;
using System.Runtime.InteropServices;

namespace NAudio.Wave
{
	[StructLayout((LayoutKind)2)]
	public class WaveBuffer : IWaveBuffer
	{
		[FieldOffset(16)]
		public int numberOfBytes;

		[FieldOffset(24)]
		private byte[] byteBuffer;

		[FieldOffset(24)]
		private float[] floatBuffer;

		[FieldOffset(24)]
		private short[] shortBuffer;

		[FieldOffset(24)]
		private int[] intBuffer;

		public byte[] ByteBuffer => null;

		public float[] FloatBuffer => null;

		public short[] ShortBuffer => null;

		public int[] IntBuffer => null;

		public int MaxSize => 0;

		public int ByteBufferCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int FloatBufferCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int ShortBufferCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int IntBufferCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public WaveBuffer(int sizeToAllocateInBytes)
		{
		}

		public WaveBuffer(byte[] bufferToBoundTo)
		{
		}

		public void BindTo(byte[] bufferToBoundTo)
		{
		}

		public static implicit operator byte[](WaveBuffer waveBuffer)
		{
			return null;
		}

		public static implicit operator float[](WaveBuffer waveBuffer)
		{
			return null;
		}

		public static implicit operator int[](WaveBuffer waveBuffer)
		{
			return null;
		}

		public static implicit operator short[](WaveBuffer waveBuffer)
		{
			return null;
		}

		public void Clear()
		{
		}

		public void Copy(Array destinationArray)
		{
		}

		private int CheckValidityCount(string argName, int value, int sizeOfValue)
		{
			return 0;
		}
	}
}
