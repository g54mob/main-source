using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeBuffer : IDisposable
	{
		private IntPtr qawyuVUqikxdikiplGlJOfLxZvo;

		private int IcJFBoUiFFMMGSOSpNHPpigsAzI;

		private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

		public IntPtr Pointer => qawyuVUqikxdikiplGlJOfLxZvo;

		public int Length => IcJFBoUiFFMMGSOSpNHPpigsAzI;

		public byte this[int index]
		{
			get
			{
				if (index < 0 || index >= IcJFBoUiFFMMGSOSpNHPpigsAzI)
				{
					throw new IndexOutOfRangeException();
				}
				return Marshal.ReadByte(qawyuVUqikxdikiplGlJOfLxZvo, index);
			}
			set
			{
				if (index < 0 || index >= IcJFBoUiFFMMGSOSpNHPpigsAzI)
				{
					throw new IndexOutOfRangeException();
				}
				Marshal.WriteByte(qawyuVUqikxdikiplGlJOfLxZvo, index, value);
			}
		}

		public NativeBuffer(int size)
		{
			Resize(size, preserveData: false);
		}

		public IntPtr GetPointer(int offset = 0)
		{
			if (qawyuVUqikxdikiplGlJOfLxZvo == IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			if (offset == 0)
			{
				return qawyuVUqikxdikiplGlJOfLxZvo;
			}
			if (offset < 0 || offset >= IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			return NativeTools.OffsetIntPtr(qawyuVUqikxdikiplGlJOfLxZvo, offset);
		}

		public string DumpToHexString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < IcJFBoUiFFMMGSOSpNHPpigsAzI; i++)
			{
				stringBuilder.Append(ReadByte(i).ToString("x2"));
				stringBuilder.Append(" ");
			}
			return stringBuilder.ToString();
		}

		public bool ReadBit(int byteIndex, byte bit)
		{
			if (1 + byteIndex > Length || byteIndex < 0)
			{
				throw new ArgumentOutOfRangeException("byteIndex");
			}
			if (bit >= 8)
			{
				throw new ArgumentOutOfRangeException("bit");
			}
			return (Marshal.ReadByte(qawyuVUqikxdikiplGlJOfLxZvo, byteIndex) & (1 << (int)bit)) != 0;
		}

		public byte ReadByte(int startIndex)
		{
			if (1 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadByte(qawyuVUqikxdikiplGlJOfLxZvo, startIndex);
		}

		public short ReadShort(int startIndex)
		{
			if (2 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadInt16(qawyuVUqikxdikiplGlJOfLxZvo, startIndex);
		}

		public ushort ReadUShort(int startIndex)
		{
			if (2 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return (ushort)Marshal.ReadInt16(qawyuVUqikxdikiplGlJOfLxZvo, startIndex);
		}

		public int ReadInt(int startIndex)
		{
			if (4 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadInt32(qawyuVUqikxdikiplGlJOfLxZvo, startIndex);
		}

		public uint ReadUInt(int startIndex)
		{
			if (4 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return (uint)Marshal.ReadInt32(qawyuVUqikxdikiplGlJOfLxZvo, startIndex);
		}

		public long ReadLong(int startIndex)
		{
			if (8 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadInt64(qawyuVUqikxdikiplGlJOfLxZvo, startIndex);
		}

		public ulong ReadULong(int startIndex)
		{
			if (8 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return (ulong)Marshal.ReadInt64(qawyuVUqikxdikiplGlJOfLxZvo, startIndex);
		}

		public float ReadFloat(int startIndex)
		{
			if (4 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return new vIAxrSRutHHlKLKXzybedQfwSDa(Marshal.ReadInt32(qawyuVUqikxdikiplGlJOfLxZvo, startIndex)).VLsVdAusIYSFclcZQWXkyWFXkz;
		}

		public double ReadDouble(int startIndex)
		{
			if (8 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return new qDaBYKAOIhGtoQepOCIuRPFAskW(Marshal.ReadInt64(qawyuVUqikxdikiplGlJOfLxZvo, startIndex)).OamWJIREoxpGELdtwrmHsIPTjWE;
		}

		public void Read(byte[] buffer, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = buffer.Length;
			if (num <= 0)
			{
				throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
			}
			if (numBytesToRead <= 0)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
			}
			if (numBytesToRead > num)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
			}
			if (numBytesToRead > IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
			}
			if (writeStartIndex >= num)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
			}
			if (writeStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
			}
			if (readStartIndex >= IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
			}
			if (readStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
			}
			if (writeStartIndex + numBytesToRead > num)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
			}
			if (numBytesToRead + readStartIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(qawyuVUqikxdikiplGlJOfLxZvo, buffer, readStartIndex, writeStartIndex, numBytesToRead);
		}

		public void Read(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("bytes");
			}
			if (bufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
			}
			if (numBytesToRead <= 0)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
			}
			if (numBytesToRead > bufferLength)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
			}
			if (numBytesToRead > IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
			}
			if (writeStartIndex >= bufferLength)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
			}
			if (writeStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
			}
			if (readStartIndex >= IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
			}
			if (readStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
			}
			if (writeStartIndex + numBytesToRead > bufferLength)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
			}
			if (numBytesToRead + readStartIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(qawyuVUqikxdikiplGlJOfLxZvo, buffer, readStartIndex, writeStartIndex, numBytesToRead);
		}

		public int TryReadBytes(byte[] buffer, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer == null || numBytesToRead <= 0)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num == 0)
			{
				return 0;
			}
			if (readStartIndex >= IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				return 0;
			}
			if (writeStartIndex >= num)
			{
				return 0;
			}
			if (readStartIndex < 0)
			{
				readStartIndex = 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (readStartIndex + numBytesToRead > IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				numBytesToRead = IcJFBoUiFFMMGSOSpNHPpigsAzI - readStartIndex;
			}
			if (writeStartIndex + numBytesToRead > num)
			{
				numBytesToRead = num - writeStartIndex;
			}
			if (numBytesToRead == 0)
			{
				return 0;
			}
			if (!NativeTools.CopyMemory(qawyuVUqikxdikiplGlJOfLxZvo, buffer, readStartIndex, writeStartIndex, numBytesToRead, throwOnError: false))
			{
				return 0;
			}
			return numBytesToRead;
		}

		public int TryReadBytes(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer == IntPtr.Zero || numBytesToRead <= 0)
			{
				return 0;
			}
			if (readStartIndex >= IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				return 0;
			}
			if (writeStartIndex >= bufferLength)
			{
				return 0;
			}
			if (readStartIndex < 0)
			{
				readStartIndex = 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (readStartIndex + numBytesToRead > IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				numBytesToRead = IcJFBoUiFFMMGSOSpNHPpigsAzI - readStartIndex;
			}
			if (writeStartIndex + numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength - writeStartIndex;
			}
			if (!NativeTools.CopyMemory(qawyuVUqikxdikiplGlJOfLxZvo, buffer, readStartIndex, writeStartIndex, numBytesToRead, throwOnError: false))
			{
				return 0;
			}
			return numBytesToRead;
		}

		public void WriteBit(int byteIndex, byte bit, bool value)
		{
			if (1 + byteIndex > Length || byteIndex < 0)
			{
				throw new ArgumentOutOfRangeException("byteIndex");
			}
			if (bit >= 8)
			{
				throw new ArgumentOutOfRangeException("bit");
			}
			if (value)
			{
				Marshal.WriteByte(qawyuVUqikxdikiplGlJOfLxZvo, byteIndex, (byte)(Marshal.ReadByte(qawyuVUqikxdikiplGlJOfLxZvo, byteIndex) | (byte)(1 << (int)bit)));
			}
			else
			{
				Marshal.WriteByte(qawyuVUqikxdikiplGlJOfLxZvo, byteIndex, (byte)(Marshal.ReadByte(qawyuVUqikxdikiplGlJOfLxZvo, byteIndex) & (byte)(~(1 << (int)bit))));
			}
		}

		public void Write(byte @byte, int startIndex)
		{
			if (1 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteByte(qawyuVUqikxdikiplGlJOfLxZvo, startIndex, @byte);
		}

		public void Write(short bytes, int startIndex)
		{
			if (2 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt16(qawyuVUqikxdikiplGlJOfLxZvo, startIndex, bytes);
		}

		public void Write(ushort bytes, int startIndex)
		{
			if (2 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt16(qawyuVUqikxdikiplGlJOfLxZvo, startIndex, (short)bytes);
		}

		public void Write(int bytes, int startIndex)
		{
			if (4 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt32(qawyuVUqikxdikiplGlJOfLxZvo, startIndex, bytes);
		}

		public void Write(uint bytes, int startIndex)
		{
			if (4 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt32(qawyuVUqikxdikiplGlJOfLxZvo, startIndex, (int)bytes);
		}

		public void Write(long bytes, int startIndex)
		{
			if (8 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt64(qawyuVUqikxdikiplGlJOfLxZvo, startIndex, bytes);
		}

		public void Write(ulong bytes, int startIndex)
		{
			if (8 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt64(qawyuVUqikxdikiplGlJOfLxZvo, startIndex, (long)bytes);
		}

		public void Write(float bytes, int startIndex)
		{
			if (4 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt32(qawyuVUqikxdikiplGlJOfLxZvo, startIndex, new vIAxrSRutHHlKLKXzybedQfwSDa(bytes).AtCpsPqXKROQCfagvWtskiAZxym);
		}

		public void Write(double bytes, int startIndex)
		{
			if (8 + startIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt64(qawyuVUqikxdikiplGlJOfLxZvo, startIndex, new qDaBYKAOIhGtoQepOCIuRPFAskW(bytes).oOViPvSeokUxOQBijGgKkbzwLHD);
		}

		public void Write(byte[] bytes, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			int num = bytes.Length;
			if (num <= 0)
			{
				throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
			}
			if (numBytesToWrite <= 0)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
			}
			if (numBytesToWrite > num)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
			}
			if (numBytesToWrite > IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
			}
			if (readStartIndex >= num)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
			}
			if (readStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
			}
			if (writeStartIndex >= IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
			}
			if (writeStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
			}
			if (readStartIndex + numBytesToWrite > num)
			{
				throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
			}
			if (numBytesToWrite + writeStartIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(bytes, qawyuVUqikxdikiplGlJOfLxZvo, readStartIndex, writeStartIndex, numBytesToWrite);
		}

		public void Write(IntPtr bytes, int bufferLength, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == IntPtr.Zero)
			{
				throw new ArgumentNullException("bytes");
			}
			if (bufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
			}
			if (numBytesToWrite <= 0)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
			}
			if (numBytesToWrite > bufferLength)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
			}
			if (numBytesToWrite > IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
			}
			if (readStartIndex >= bufferLength)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
			}
			if (readStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
			}
			if (writeStartIndex >= IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
			}
			if (writeStartIndex < 0)
			{
				throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
			}
			if (readStartIndex + numBytesToWrite > bufferLength)
			{
				throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
			}
			if (numBytesToWrite + writeStartIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(bytes, qawyuVUqikxdikiplGlJOfLxZvo, readStartIndex, writeStartIndex, numBytesToWrite);
		}

		public int TryWriteBytes(byte[] bytes, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == null)
			{
				return 0;
			}
			int num = bytes.Length;
			if (num == 0 || numBytesToWrite <= 0 || readStartIndex >= num || writeStartIndex >= IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				return 0;
			}
			if (readStartIndex < 0)
			{
				readStartIndex = 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (readStartIndex + numBytesToWrite > num)
			{
				numBytesToWrite = num - readStartIndex;
			}
			if (numBytesToWrite + writeStartIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				numBytesToWrite = IcJFBoUiFFMMGSOSpNHPpigsAzI - writeStartIndex;
			}
			if (!NativeTools.CopyMemory(bytes, qawyuVUqikxdikiplGlJOfLxZvo, readStartIndex, writeStartIndex, numBytesToWrite, throwOnError: false))
			{
				return 0;
			}
			return numBytesToWrite;
		}

		public int TryWriteBytes(IntPtr bytes, int bufferLength, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0 || readStartIndex >= bufferLength || writeStartIndex >= IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				return 0;
			}
			if (readStartIndex < 0)
			{
				readStartIndex = 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (readStartIndex + numBytesToWrite > bufferLength)
			{
				numBytesToWrite = bufferLength - readStartIndex;
			}
			if (numBytesToWrite + writeStartIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				numBytesToWrite = IcJFBoUiFFMMGSOSpNHPpigsAzI - writeStartIndex;
			}
			if (!NativeTools.CopyMemory(bytes, qawyuVUqikxdikiplGlJOfLxZvo, readStartIndex, writeStartIndex, numBytesToWrite, throwOnError: false))
			{
				return 0;
			}
			return numBytesToWrite;
		}

		public int TryFill(byte value, int numBytesToWrite, int writeStartIndex = 0)
		{
			if (numBytesToWrite <= 0 || writeStartIndex >= IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				return 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (numBytesToWrite + writeStartIndex > IcJFBoUiFFMMGSOSpNHPpigsAzI)
			{
				numBytesToWrite = IcJFBoUiFFMMGSOSpNHPpigsAzI - writeStartIndex;
			}
			if (!NativeTools.FillMemory(qawyuVUqikxdikiplGlJOfLxZvo, writeStartIndex, numBytesToWrite, value, throwOnError: false))
			{
				return 0;
			}
			return numBytesToWrite;
		}

		public bool Resize(int size, bool preserveData)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			if (IcJFBoUiFFMMGSOSpNHPpigsAzI == size)
			{
				return true;
			}
			if (size == 0)
			{
				Release();
				return true;
			}
			IntPtr intPtr;
			if (preserveData)
			{
				try
				{
					intPtr = Marshal.AllocHGlobal(size);
					if (intPtr == IntPtr.Zero)
					{
						return false;
					}
				}
				catch
				{
					return false;
				}
				int bytesToCopy = MathTools.Min(size, IcJFBoUiFFMMGSOSpNHPpigsAzI);
				if (!NativeTools.CopyMemory(qawyuVUqikxdikiplGlJOfLxZvo, intPtr, 0, 0, bytesToCopy, throwOnError: false))
				{
					Marshal.FreeHGlobal(intPtr);
					return false;
				}
				if (size > IcJFBoUiFFMMGSOSpNHPpigsAzI)
				{
					NativeTools.FillMemory(intPtr, IcJFBoUiFFMMGSOSpNHPpigsAzI, size - IcJFBoUiFFMMGSOSpNHPpigsAzI, 0, throwOnError: false);
				}
				Release();
			}
			else
			{
				Release();
				try
				{
					intPtr = Marshal.AllocHGlobal(size);
					if (intPtr == IntPtr.Zero)
					{
						return false;
					}
				}
				catch
				{
					return false;
				}
				NativeTools.ZeroFillMemory(intPtr, size);
			}
			qawyuVUqikxdikiplGlJOfLxZvo = intPtr;
			IcJFBoUiFFMMGSOSpNHPpigsAzI = size;
			return true;
		}

		public void Clear()
		{
			if (IcJFBoUiFFMMGSOSpNHPpigsAzI != 0)
			{
				NativeTools.ZeroFillMemory(qawyuVUqikxdikiplGlJOfLxZvo, IcJFBoUiFFMMGSOSpNHPpigsAzI);
			}
		}

		public void Release()
		{
			if (qawyuVUqikxdikiplGlJOfLxZvo != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(Pointer);
				qawyuVUqikxdikiplGlJOfLxZvo = IntPtr.Zero;
			}
			IcJFBoUiFFMMGSOSpNHPpigsAzI = 0;
		}

		public void CopyFrom(NativeBuffer other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (!(qawyuVUqikxdikiplGlJOfLxZvo == IntPtr.Zero) && !(other.Pointer == IntPtr.Zero))
			{
				int bytesToCopy = MathTools.Min(IcJFBoUiFFMMGSOSpNHPpigsAzI, other.IcJFBoUiFFMMGSOSpNHPpigsAzI);
				NativeTools.CopyMemory(other.qawyuVUqikxdikiplGlJOfLxZvo, qawyuVUqikxdikiplGlJOfLxZvo, 0, 0, bytesToCopy);
			}
		}

		public override string ToString()
		{
			return "Length = " + IcJFBoUiFFMMGSOSpNHPpigsAzI + "\nPointer = " + qawyuVUqikxdikiplGlJOfLxZvo + "\n";
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~NativeBuffer()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!jgbpvYJovPcfzmcAEJzdxdrBmcm)
			{
				Release();
				jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
			}
		}

		public static implicit operator IntPtr(NativeBuffer buffer)
		{
			return buffer?.qawyuVUqikxdikiplGlJOfLxZvo ?? IntPtr.Zero;
		}

		public static bool Copy(NativeBuffer source, NativeBuffer destination)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (source.IcJFBoUiFFMMGSOSpNHPpigsAzI == 0)
			{
				destination.Release();
				return true;
			}
			if (destination.Resize(source.IcJFBoUiFFMMGSOSpNHPpigsAzI, preserveData: false))
			{
				return NativeTools.CopyMemory(source.qawyuVUqikxdikiplGlJOfLxZvo, destination.qawyuVUqikxdikiplGlJOfLxZvo, 0, 0, source.IcJFBoUiFFMMGSOSpNHPpigsAzI, throwOnError: false);
			}
			return false;
		}
	}
}
