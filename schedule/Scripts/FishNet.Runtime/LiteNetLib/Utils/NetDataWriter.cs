using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

namespace LiteNetLib.Utils
{
	public class NetDataWriter
	{
		protected byte[] _data;

		protected int _position;

		private const int InitialSize = 64;

		private readonly bool _autoResize;

		private static readonly UTF8Encoding _uTF8Encoding;

		public const int StringBufferMaxLength = 32768;

		private readonly byte[] _stringBuffer;

		public int Capacity => 0;

		public byte[] Data => null;

		public int Length => 0;

		public NetDataWriter()
		{
		}

		public NetDataWriter(bool autoResize)
		{
		}

		public NetDataWriter(bool autoResize, int initialSize)
		{
		}

		public static NetDataWriter FromBytes(byte[] bytes, bool copy)
		{
			return null;
		}

		public static NetDataWriter FromBytes(byte[] bytes, int offset, int length)
		{
			return null;
		}

		public static NetDataWriter FromString(string value)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ResizeIfNeed(int newSize)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void EnsureFit(int additionalSize)
		{
		}

		public void Reset(int size)
		{
		}

		public void Reset()
		{
		}

		public byte[] CopyData()
		{
			return null;
		}

		public int SetPosition(int position)
		{
			return 0;
		}

		public void Put(float value)
		{
		}

		public void Put(double value)
		{
		}

		public void Put(long value)
		{
		}

		public void Put(ulong value)
		{
		}

		public void Put(int value)
		{
		}

		public void Put(uint value)
		{
		}

		public void Put(char value)
		{
		}

		public void Put(ushort value)
		{
		}

		public void Put(short value)
		{
		}

		public void Put(sbyte value)
		{
		}

		public void Put(byte value)
		{
		}

		public void Put(byte[] data, int offset, int length)
		{
		}

		public void Put(byte[] data)
		{
		}

		public void PutSBytesWithLength(sbyte[] data, int offset, int length)
		{
		}

		public void PutSBytesWithLength(sbyte[] data)
		{
		}

		public void PutBytesWithLength(byte[] data, int offset, int length)
		{
		}

		public void PutBytesWithLength(byte[] data)
		{
		}

		public void Put(bool value)
		{
		}

		private void PutArray(Array arr, int sz)
		{
		}

		public void PutArray(float[] value)
		{
		}

		public void PutArray(double[] value)
		{
		}

		public void PutArray(long[] value)
		{
		}

		public void PutArray(ulong[] value)
		{
		}

		public void PutArray(int[] value)
		{
		}

		public void PutArray(uint[] value)
		{
		}

		public void PutArray(ushort[] value)
		{
		}

		public void PutArray(short[] value)
		{
		}

		public void PutArray(bool[] value)
		{
		}

		public void PutArray(string[] value)
		{
		}

		public void PutArray(string[] value, int strMaxLength)
		{
		}

		public void Put(IPEndPoint endPoint)
		{
		}

		public void Put(string value)
		{
		}

		public void Put(string value, int maxLength)
		{
		}

		public void Put<T>(T obj) where T : INetSerializable
		{
		}
	}
}
