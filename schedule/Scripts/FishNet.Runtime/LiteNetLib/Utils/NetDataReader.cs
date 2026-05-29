using System;
using System.Net;
using System.Text;

namespace LiteNetLib.Utils
{
	public class NetDataReader
	{
		protected byte[] _data;

		protected int _position;

		protected int _dataSize;

		private int _offset;

		private static readonly UTF8Encoding _uTF8Encoding;

		public byte[] RawData => null;

		public int RawDataSize => 0;

		public int UserDataOffset => 0;

		public int UserDataSize => 0;

		public bool IsNull => false;

		public int Position => 0;

		public bool EndOfData => false;

		public int AvailableBytes => 0;

		public void SkipBytes(int count)
		{
		}

		public void SetPosition(int position)
		{
		}

		public void SetSource(NetDataWriter dataWriter)
		{
		}

		public void SetSource(byte[] source)
		{
		}

		public void SetSource(byte[] source, int offset, int maxSize)
		{
		}

		public NetDataReader()
		{
		}

		public NetDataReader(NetDataWriter writer)
		{
		}

		public NetDataReader(byte[] source)
		{
		}

		public NetDataReader(byte[] source, int offset, int maxSize)
		{
		}

		public IPEndPoint GetNetEndPoint()
		{
			return null;
		}

		public byte GetByte()
		{
			return 0;
		}

		public sbyte GetSByte()
		{
			return 0;
		}

		public bool[] GetBoolArray()
		{
			return null;
		}

		public ushort[] GetUShortArray()
		{
			return null;
		}

		public short[] GetShortArray()
		{
			return null;
		}

		public long[] GetLongArray()
		{
			return null;
		}

		public ulong[] GetULongArray()
		{
			return null;
		}

		public int[] GetIntArray()
		{
			return null;
		}

		public uint[] GetUIntArray()
		{
			return null;
		}

		public float[] GetFloatArray()
		{
			return null;
		}

		public double[] GetDoubleArray()
		{
			return null;
		}

		public string[] GetStringArray()
		{
			return null;
		}

		public string[] GetStringArray(int maxStringLength)
		{
			return null;
		}

		public bool GetBool()
		{
			return false;
		}

		public char GetChar()
		{
			return '\0';
		}

		public ushort GetUShort()
		{
			return 0;
		}

		public short GetShort()
		{
			return 0;
		}

		public long GetLong()
		{
			return 0L;
		}

		public ulong GetULong()
		{
			return 0uL;
		}

		public int GetInt()
		{
			return 0;
		}

		public uint GetUInt()
		{
			return 0u;
		}

		public float GetFloat()
		{
			return 0f;
		}

		public double GetDouble()
		{
			return 0.0;
		}

		public string GetString(int maxLength)
		{
			return null;
		}

		public string GetString()
		{
			return null;
		}

		public ArraySegment<byte> GetBytesSegment(int count)
		{
			return default(ArraySegment<byte>);
		}

		public ArraySegment<byte> GetRemainingBytesSegment()
		{
			return default(ArraySegment<byte>);
		}

		public T Get<T>() where T : INetSerializable, new()
		{
			return default(T);
		}

		public byte[] GetRemainingBytes()
		{
			return null;
		}

		public void GetBytes(byte[] destination, int start, int count)
		{
		}

		public void GetBytes(byte[] destination, int count)
		{
		}

		public sbyte[] GetSBytesWithLength()
		{
			return null;
		}

		public byte[] GetBytesWithLength()
		{
			return null;
		}

		public byte PeekByte()
		{
			return 0;
		}

		public sbyte PeekSByte()
		{
			return 0;
		}

		public bool PeekBool()
		{
			return false;
		}

		public char PeekChar()
		{
			return '\0';
		}

		public ushort PeekUShort()
		{
			return 0;
		}

		public short PeekShort()
		{
			return 0;
		}

		public long PeekLong()
		{
			return 0L;
		}

		public ulong PeekULong()
		{
			return 0uL;
		}

		public int PeekInt()
		{
			return 0;
		}

		public uint PeekUInt()
		{
			return 0u;
		}

		public float PeekFloat()
		{
			return 0f;
		}

		public double PeekDouble()
		{
			return 0.0;
		}

		public string PeekString(int maxLength)
		{
			return null;
		}

		public string PeekString()
		{
			return null;
		}

		public bool TryGetByte(out byte result)
		{
			result = default(byte);
			return false;
		}

		public bool TryGetSByte(out sbyte result)
		{
			result = default(sbyte);
			return false;
		}

		public bool TryGetBool(out bool result)
		{
			result = default(bool);
			return false;
		}

		public bool TryGetChar(out char result)
		{
			result = default(char);
			return false;
		}

		public bool TryGetShort(out short result)
		{
			result = default(short);
			return false;
		}

		public bool TryGetUShort(out ushort result)
		{
			result = default(ushort);
			return false;
		}

		public bool TryGetInt(out int result)
		{
			result = default(int);
			return false;
		}

		public bool TryGetUInt(out uint result)
		{
			result = default(uint);
			return false;
		}

		public bool TryGetLong(out long result)
		{
			result = default(long);
			return false;
		}

		public bool TryGetULong(out ulong result)
		{
			result = default(ulong);
			return false;
		}

		public bool TryGetFloat(out float result)
		{
			result = default(float);
			return false;
		}

		public bool TryGetDouble(out double result)
		{
			result = default(double);
			return false;
		}

		public bool TryGetString(out string result)
		{
			result = null;
			return false;
		}

		public bool TryGetStringArray(out string[] result)
		{
			result = null;
			return false;
		}

		public bool TryGetBytesWithLength(out byte[] result)
		{
			result = null;
			return false;
		}

		public void Clear()
		{
		}
	}
}
