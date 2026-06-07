using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeBuffer : IDisposable
	{
		private IntPtr ZKOnjQgFmcKjMvNPzecwjPfjWeRV;

		private int haSlhmQoRTrTOUjujfTSBpWEBBBp;

		private bool kMcWeAdBNvAINbdkOdolHBWSTGSi;

		public IntPtr Pointer => ZKOnjQgFmcKjMvNPzecwjPfjWeRV;

		public int Length => haSlhmQoRTrTOUjujfTSBpWEBBBp;

		public byte this[int index]
		{
			get
			{
				if (index < 0 || index >= haSlhmQoRTrTOUjujfTSBpWEBBBp)
				{
					throw new IndexOutOfRangeException();
				}
				return Marshal.ReadByte(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, index);
			}
			set
			{
				if (index < 0 || index >= haSlhmQoRTrTOUjujfTSBpWEBBBp)
				{
					throw new IndexOutOfRangeException();
				}
				Marshal.WriteByte(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, index, value);
			}
		}

		public NativeBuffer(int P_0)
		{
			Resize(P_0, preserveData: false);
		}

		public IntPtr GetPointer(int offset = 0)
		{
			if (ZKOnjQgFmcKjMvNPzecwjPfjWeRV == IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			if (offset == 0)
			{
				return ZKOnjQgFmcKjMvNPzecwjPfjWeRV;
			}
			if (offset < 0 || offset >= haSlhmQoRTrTOUjujfTSBpWEBBBp)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			return NativeTools.OffsetIntPtr(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, offset);
		}

		public string DumpToHexString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < haSlhmQoRTrTOUjujfTSBpWEBBBp; i++)
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
			return (Marshal.ReadByte(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, byteIndex) & (1 << (int)bit)) != 0;
		}

		public byte ReadByte(int startIndex)
		{
			if (1 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadByte(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex);
		}

		public short ReadShort(int startIndex)
		{
			if (2 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadInt16(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex);
		}

		public ushort ReadUShort(int startIndex)
		{
			if (2 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return (ushort)Marshal.ReadInt16(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex);
		}

		public int ReadInt(int startIndex)
		{
			if (4 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadInt32(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex);
		}

		public uint ReadUInt(int startIndex)
		{
			if (4 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return (uint)Marshal.ReadInt32(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex);
		}

		public long ReadLong(int startIndex)
		{
			if (8 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadInt64(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex);
		}

		public ulong ReadULong(int startIndex)
		{
			if (8 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return (ulong)Marshal.ReadInt64(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex);
		}

		public float ReadFloat(int startIndex)
		{
			if (4 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return new pkqsyCeiOpeyJhDMJthvAjsyMfKR(Marshal.ReadInt32(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex)).gQyOWSPhpJJPAdALInsnOahefrmm;
		}

		public double ReadDouble(int startIndex)
		{
			if (8 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return new wqOHiKdxtVKuhQcaqFXlwIUSTUgj(Marshal.ReadInt64(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex)).CZeykRIphwHSOrVOhfCzgnqIGAQzA;
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
			if (numBytesToRead > haSlhmQoRTrTOUjujfTSBpWEBBBp)
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
			if (readStartIndex >= haSlhmQoRTrTOUjujfTSBpWEBBBp)
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
			if (numBytesToRead + readStartIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, buffer, readStartIndex, writeStartIndex, numBytesToRead);
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
			if (numBytesToRead > haSlhmQoRTrTOUjujfTSBpWEBBBp)
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
			if (readStartIndex >= haSlhmQoRTrTOUjujfTSBpWEBBBp)
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
			if (numBytesToRead + readStartIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, buffer, readStartIndex, writeStartIndex, numBytesToRead);
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
			if (readStartIndex >= haSlhmQoRTrTOUjujfTSBpWEBBBp)
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
			if (readStartIndex + numBytesToRead > haSlhmQoRTrTOUjujfTSBpWEBBBp)
			{
				numBytesToRead = haSlhmQoRTrTOUjujfTSBpWEBBBp - readStartIndex;
			}
			if (writeStartIndex + numBytesToRead > num)
			{
				numBytesToRead = num - writeStartIndex;
			}
			if (numBytesToRead == 0)
			{
				return 0;
			}
			if (!NativeTools.CopyMemory(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, buffer, readStartIndex, writeStartIndex, numBytesToRead, throwOnError: false))
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
			if (readStartIndex >= haSlhmQoRTrTOUjujfTSBpWEBBBp)
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
			if (readStartIndex + numBytesToRead > haSlhmQoRTrTOUjujfTSBpWEBBBp)
			{
				numBytesToRead = haSlhmQoRTrTOUjujfTSBpWEBBBp - readStartIndex;
			}
			if (writeStartIndex + numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength - writeStartIndex;
			}
			if (!NativeTools.CopyMemory(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, buffer, readStartIndex, writeStartIndex, numBytesToRead, throwOnError: false))
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
				Marshal.WriteByte(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, byteIndex, (byte)(Marshal.ReadByte(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, byteIndex) | (byte)(1 << (int)bit)));
			}
			else
			{
				Marshal.WriteByte(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, byteIndex, (byte)(Marshal.ReadByte(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, byteIndex) & (byte)(~(1 << (int)bit))));
			}
		}

		public void Write(byte @byte, int startIndex)
		{
			if (1 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteByte(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex, @byte);
		}

		public void Write(short bytes, int startIndex)
		{
			if (2 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt16(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex, bytes);
		}

		public void Write(ushort bytes, int startIndex)
		{
			if (2 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt16(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex, (short)bytes);
		}

		public void Write(int bytes, int startIndex)
		{
			if (4 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt32(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex, bytes);
		}

		public void Write(uint bytes, int startIndex)
		{
			if (4 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt32(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex, (int)bytes);
		}

		public void Write(long bytes, int startIndex)
		{
			if (8 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt64(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex, bytes);
		}

		public void Write(ulong bytes, int startIndex)
		{
			if (8 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt64(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex, (long)bytes);
		}

		public void Write(float bytes, int startIndex)
		{
			if (4 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt32(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex, new pkqsyCeiOpeyJhDMJthvAjsyMfKR(bytes).KJilWQAMgzdwTiaDYLpNdotbDOpm);
		}

		public void Write(double bytes, int startIndex)
		{
			if (8 + startIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt64(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, startIndex, new wqOHiKdxtVKuhQcaqFXlwIUSTUgj(bytes).WZHLeqwuoCfQbNXQrSYybQDptzxc);
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
			if (numBytesToWrite > haSlhmQoRTrTOUjujfTSBpWEBBBp)
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
			if (writeStartIndex >= haSlhmQoRTrTOUjujfTSBpWEBBBp)
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
			if (numBytesToWrite + writeStartIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(bytes, ZKOnjQgFmcKjMvNPzecwjPfjWeRV, readStartIndex, writeStartIndex, numBytesToWrite);
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
			if (numBytesToWrite > haSlhmQoRTrTOUjujfTSBpWEBBBp)
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
			if (writeStartIndex >= haSlhmQoRTrTOUjujfTSBpWEBBBp)
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
			if (numBytesToWrite + writeStartIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(bytes, ZKOnjQgFmcKjMvNPzecwjPfjWeRV, readStartIndex, writeStartIndex, numBytesToWrite);
		}

		public int TryWriteBytes(byte[] bytes, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == null)
			{
				return 0;
			}
			int num = bytes.Length;
			if (num == 0 || numBytesToWrite <= 0 || readStartIndex >= num || writeStartIndex >= haSlhmQoRTrTOUjujfTSBpWEBBBp)
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
			if (numBytesToWrite + writeStartIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp)
			{
				numBytesToWrite = haSlhmQoRTrTOUjujfTSBpWEBBBp - writeStartIndex;
			}
			if (!NativeTools.CopyMemory(bytes, ZKOnjQgFmcKjMvNPzecwjPfjWeRV, readStartIndex, writeStartIndex, numBytesToWrite, throwOnError: false))
			{
				return 0;
			}
			return numBytesToWrite;
		}

		public int TryWriteBytes(IntPtr bytes, int bufferLength, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0 || readStartIndex >= bufferLength || writeStartIndex >= haSlhmQoRTrTOUjujfTSBpWEBBBp)
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
			if (numBytesToWrite + writeStartIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp)
			{
				numBytesToWrite = haSlhmQoRTrTOUjujfTSBpWEBBBp - writeStartIndex;
			}
			if (!NativeTools.CopyMemory(bytes, ZKOnjQgFmcKjMvNPzecwjPfjWeRV, readStartIndex, writeStartIndex, numBytesToWrite, throwOnError: false))
			{
				return 0;
			}
			return numBytesToWrite;
		}

		public int TryFill(byte value, int numBytesToWrite, int writeStartIndex = 0)
		{
			if (numBytesToWrite <= 0 || writeStartIndex >= haSlhmQoRTrTOUjujfTSBpWEBBBp)
			{
				return 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (numBytesToWrite + writeStartIndex > haSlhmQoRTrTOUjujfTSBpWEBBBp)
			{
				numBytesToWrite = haSlhmQoRTrTOUjujfTSBpWEBBBp - writeStartIndex;
			}
			if (!NativeTools.FillMemory(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, writeStartIndex, numBytesToWrite, value, throwOnError: false))
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
			if (haSlhmQoRTrTOUjujfTSBpWEBBBp == size)
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
				int bytesToCopy = MathTools.Min(size, haSlhmQoRTrTOUjujfTSBpWEBBBp);
				if (!NativeTools.CopyMemory(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, intPtr, 0, 0, bytesToCopy, throwOnError: false))
				{
					Marshal.FreeHGlobal(intPtr);
					return false;
				}
				if (size > haSlhmQoRTrTOUjujfTSBpWEBBBp)
				{
					NativeTools.FillMemory(intPtr, haSlhmQoRTrTOUjujfTSBpWEBBBp, size - haSlhmQoRTrTOUjujfTSBpWEBBBp, 0, throwOnError: false);
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
			ZKOnjQgFmcKjMvNPzecwjPfjWeRV = intPtr;
			haSlhmQoRTrTOUjujfTSBpWEBBBp = size;
			return true;
		}

		public void Clear()
		{
			if (haSlhmQoRTrTOUjujfTSBpWEBBBp != 0)
			{
				NativeTools.ZeroFillMemory(ZKOnjQgFmcKjMvNPzecwjPfjWeRV, haSlhmQoRTrTOUjujfTSBpWEBBBp);
			}
		}

		public void Release()
		{
			if (ZKOnjQgFmcKjMvNPzecwjPfjWeRV != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(Pointer);
				ZKOnjQgFmcKjMvNPzecwjPfjWeRV = IntPtr.Zero;
			}
			haSlhmQoRTrTOUjujfTSBpWEBBBp = 0;
		}

		public void CopyFrom(NativeBuffer other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (!(ZKOnjQgFmcKjMvNPzecwjPfjWeRV == IntPtr.Zero) && !(other.Pointer == IntPtr.Zero))
			{
				int bytesToCopy = MathTools.Min(haSlhmQoRTrTOUjujfTSBpWEBBBp, other.haSlhmQoRTrTOUjujfTSBpWEBBBp);
				NativeTools.CopyMemory(other.ZKOnjQgFmcKjMvNPzecwjPfjWeRV, ZKOnjQgFmcKjMvNPzecwjPfjWeRV, 0, 0, bytesToCopy);
			}
		}

		public override string ToString()
		{
			return "Length = " + haSlhmQoRTrTOUjujfTSBpWEBBBp + "\nPointer = " + ZKOnjQgFmcKjMvNPzecwjPfjWeRV + "\n";
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~NativeBuffer()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!kMcWeAdBNvAINbdkOdolHBWSTGSi)
			{
				Release();
				kMcWeAdBNvAINbdkOdolHBWSTGSi = true;
			}
		}

		public static implicit operator IntPtr(NativeBuffer buffer)
		{
			return buffer?.ZKOnjQgFmcKjMvNPzecwjPfjWeRV ?? IntPtr.Zero;
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
			if (source.haSlhmQoRTrTOUjujfTSBpWEBBBp == 0)
			{
				destination.Release();
				return true;
			}
			if (destination.Resize(source.haSlhmQoRTrTOUjujfTSBpWEBBBp, preserveData: false))
			{
				return NativeTools.CopyMemory(source.ZKOnjQgFmcKjMvNPzecwjPfjWeRV, destination.ZKOnjQgFmcKjMvNPzecwjPfjWeRV, 0, 0, source.haSlhmQoRTrTOUjujfTSBpWEBBBp, throwOnError: false);
			}
			return false;
		}
	}
}
