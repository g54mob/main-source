using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeBuffer : IDisposable
	{
		private IntPtr EZsCuCHgalQBruIpAhrZSeDAWgHg;

		private int uTNuLjiNVSbmTIyYOGaJVuiPGEdC;

		private bool PrvylHtjoIHWmYgGfZyfZonoJFJ;

		public IntPtr Pointer => (IntPtr)0;

		public int Length => 0;

		public byte this[int index]
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public NativeBuffer(int size)
		{
		}

		public IntPtr GetPointer(int offset = 0)
		{
			return (IntPtr)0;
		}

		public string DumpToHexString()
		{
			return null;
		}

		public bool ReadBit(int byteIndex, byte bit)
		{
			return false;
		}

		public byte ReadByte(int startIndex)
		{
			return 0;
		}

		public short ReadShort(int startIndex)
		{
			return 0;
		}

		public ushort ReadUShort(int startIndex)
		{
			return 0;
		}

		public int ReadInt(int startIndex)
		{
			return 0;
		}

		public uint ReadUInt(int startIndex)
		{
			return 0u;
		}

		public long ReadLong(int startIndex)
		{
			return 0L;
		}

		public ulong ReadULong(int startIndex)
		{
			return 0uL;
		}

		public float ReadFloat(int startIndex)
		{
			return 0f;
		}

		public double ReadDouble(int startIndex)
		{
			return 0.0;
		}

		public void Read(byte[] buffer, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
		}

		public void Read(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
		}

		public int TryReadBytes(byte[] buffer, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			return 0;
		}

		public int TryReadBytes(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			return 0;
		}

		public void WriteBit(int byteIndex, byte bit, bool value)
		{
		}

		public void Write(byte @byte, int startIndex)
		{
		}

		public void Write(short bytes, int startIndex)
		{
		}

		public void Write(ushort bytes, int startIndex)
		{
		}

		public void Write(int bytes, int startIndex)
		{
		}

		public void Write(uint bytes, int startIndex)
		{
		}

		public void Write(long bytes, int startIndex)
		{
		}

		public void Write(ulong bytes, int startIndex)
		{
		}

		public void Write(float bytes, int startIndex)
		{
		}

		public void Write(double bytes, int startIndex)
		{
		}

		public void Write(byte[] bytes, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
		}

		public void Write(IntPtr bytes, int bufferLength, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
		}

		public int TryWriteBytes(byte[] bytes, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			return 0;
		}

		public int TryWriteBytes(IntPtr bytes, int bufferLength, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			return 0;
		}

		public int TryFill(byte value, int numBytesToWrite, int writeStartIndex = 0)
		{
			return 0;
		}

		public bool Resize(int size, bool preserveData)
		{
			return false;
		}

		public void Clear()
		{
		}

		public void Release()
		{
		}

		public void CopyFrom(NativeBuffer other)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public void Dispose()
		{
		}

		~NativeBuffer()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public static implicit operator IntPtr(NativeBuffer buffer)
		{
			return (IntPtr)0;
		}

		public static bool Copy(NativeBuffer source, NativeBuffer destination)
		{
			return false;
		}
	}
}
