using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class NativeBuffer : IDisposable
	{
		private IntPtr faoeEyKYaPehQfvscfkWrXjEZQuB;

		private int HXTZQzGHjkZnNBFYaezmUlsRnusi;

		private bool wFtxnVROnubhehGUBaPWAtQsiPAD;

		public IntPtr Pointer => faoeEyKYaPehQfvscfkWrXjEZQuB;

		public int Length => HXTZQzGHjkZnNBFYaezmUlsRnusi;

		public byte this[int index]
		{
			get
			{
				if (index < 0 || index >= HXTZQzGHjkZnNBFYaezmUlsRnusi)
				{
					throw new IndexOutOfRangeException();
				}
				return Marshal.ReadByte(faoeEyKYaPehQfvscfkWrXjEZQuB, index);
			}
			set
			{
				if (index < 0 || index >= HXTZQzGHjkZnNBFYaezmUlsRnusi)
				{
					throw new IndexOutOfRangeException();
				}
				Marshal.WriteByte(faoeEyKYaPehQfvscfkWrXjEZQuB, index, value);
			}
		}

		public NativeBuffer(int P_0)
		{
			Resize(P_0, preserveData: false);
		}

		public IntPtr GetPointer(int offset = 0)
		{
			if (faoeEyKYaPehQfvscfkWrXjEZQuB == IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			if (offset == 0)
			{
				return faoeEyKYaPehQfvscfkWrXjEZQuB;
			}
			if (offset < 0 || offset >= HXTZQzGHjkZnNBFYaezmUlsRnusi)
			{
				throw new ArgumentOutOfRangeException("offset");
			}
			return NativeTools.OffsetIntPtr(faoeEyKYaPehQfvscfkWrXjEZQuB, offset);
		}

		public string DumpToHexString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < HXTZQzGHjkZnNBFYaezmUlsRnusi; i++)
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
			return (Marshal.ReadByte(faoeEyKYaPehQfvscfkWrXjEZQuB, byteIndex) & (1 << (int)bit)) != 0;
		}

		public byte ReadByte(int startIndex)
		{
			if (1 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadByte(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex);
		}

		public short ReadShort(int startIndex)
		{
			if (2 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadInt16(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex);
		}

		public ushort ReadUShort(int startIndex)
		{
			if (2 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return (ushort)Marshal.ReadInt16(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex);
		}

		public int ReadInt(int startIndex)
		{
			if (4 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadInt32(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex);
		}

		public uint ReadUInt(int startIndex)
		{
			if (4 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return (uint)Marshal.ReadInt32(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex);
		}

		public long ReadLong(int startIndex)
		{
			if (8 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return Marshal.ReadInt64(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex);
		}

		public ulong ReadULong(int startIndex)
		{
			if (8 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return (ulong)Marshal.ReadInt64(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex);
		}

		public float ReadFloat(int startIndex)
		{
			if (4 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return new aKMbUZDTJgAyRWaLsNCZUPtPKgWI(Marshal.ReadInt32(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex)).OOBHaVuOxQLUYaeWMfscJSdqmZwB;
		}

		public double ReadDouble(int startIndex)
		{
			if (8 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			return new xdsvSHKoqGdcdkjdRSxPsfThbwwbA(Marshal.ReadInt64(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex)).HaUePFesYkgJSEzpObaDcNqtPuh;
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
			if (numBytesToRead > HXTZQzGHjkZnNBFYaezmUlsRnusi)
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
			if (readStartIndex >= HXTZQzGHjkZnNBFYaezmUlsRnusi)
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
			if (numBytesToRead + readStartIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(faoeEyKYaPehQfvscfkWrXjEZQuB, buffer, readStartIndex, writeStartIndex, numBytesToRead);
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
			if (numBytesToRead > HXTZQzGHjkZnNBFYaezmUlsRnusi)
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
			if (readStartIndex >= HXTZQzGHjkZnNBFYaezmUlsRnusi)
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
			if (numBytesToRead + readStartIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi)
			{
				throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(faoeEyKYaPehQfvscfkWrXjEZQuB, buffer, readStartIndex, writeStartIndex, numBytesToRead);
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
			if (readStartIndex >= HXTZQzGHjkZnNBFYaezmUlsRnusi)
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
			if (readStartIndex + numBytesToRead > HXTZQzGHjkZnNBFYaezmUlsRnusi)
			{
				numBytesToRead = HXTZQzGHjkZnNBFYaezmUlsRnusi - readStartIndex;
			}
			if (writeStartIndex + numBytesToRead > num)
			{
				numBytesToRead = num - writeStartIndex;
			}
			if (numBytesToRead == 0)
			{
				return 0;
			}
			if (!NativeTools.CopyMemory(faoeEyKYaPehQfvscfkWrXjEZQuB, buffer, readStartIndex, writeStartIndex, numBytesToRead, throwOnError: false))
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
			if (readStartIndex >= HXTZQzGHjkZnNBFYaezmUlsRnusi)
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
			if (readStartIndex + numBytesToRead > HXTZQzGHjkZnNBFYaezmUlsRnusi)
			{
				numBytesToRead = HXTZQzGHjkZnNBFYaezmUlsRnusi - readStartIndex;
			}
			if (writeStartIndex + numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength - writeStartIndex;
			}
			if (!NativeTools.CopyMemory(faoeEyKYaPehQfvscfkWrXjEZQuB, buffer, readStartIndex, writeStartIndex, numBytesToRead, throwOnError: false))
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
				Marshal.WriteByte(faoeEyKYaPehQfvscfkWrXjEZQuB, byteIndex, (byte)(Marshal.ReadByte(faoeEyKYaPehQfvscfkWrXjEZQuB, byteIndex) | (byte)(1 << (int)bit)));
			}
			else
			{
				Marshal.WriteByte(faoeEyKYaPehQfvscfkWrXjEZQuB, byteIndex, (byte)(Marshal.ReadByte(faoeEyKYaPehQfvscfkWrXjEZQuB, byteIndex) & (byte)(~(1 << (int)bit))));
			}
		}

		public void Write(byte @byte, int startIndex)
		{
			if (1 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteByte(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex, @byte);
		}

		public void Write(short bytes, int startIndex)
		{
			if (2 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt16(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex, bytes);
		}

		public void Write(ushort bytes, int startIndex)
		{
			if (2 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt16(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex, (short)bytes);
		}

		public void Write(int bytes, int startIndex)
		{
			if (4 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt32(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex, bytes);
		}

		public void Write(uint bytes, int startIndex)
		{
			if (4 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt32(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex, (int)bytes);
		}

		public void Write(long bytes, int startIndex)
		{
			if (8 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt64(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex, bytes);
		}

		public void Write(ulong bytes, int startIndex)
		{
			if (8 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt64(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex, (long)bytes);
		}

		public void Write(float bytes, int startIndex)
		{
			if (4 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt32(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex, new aKMbUZDTJgAyRWaLsNCZUPtPKgWI(bytes).ZsSlaOgmwaaNNmQowHIHJpMmUeAq);
		}

		public void Write(double bytes, int startIndex)
		{
			if (8 + startIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi || startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			Marshal.WriteInt64(faoeEyKYaPehQfvscfkWrXjEZQuB, startIndex, new xdsvSHKoqGdcdkjdRSxPsfThbwwbA(bytes).dQHwweSgELcNRVougQRxVvjHwXxp);
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
			if (numBytesToWrite > HXTZQzGHjkZnNBFYaezmUlsRnusi)
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
			if (writeStartIndex >= HXTZQzGHjkZnNBFYaezmUlsRnusi)
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
			if (numBytesToWrite + writeStartIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(bytes, faoeEyKYaPehQfvscfkWrXjEZQuB, readStartIndex, writeStartIndex, numBytesToWrite);
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
			if (numBytesToWrite > HXTZQzGHjkZnNBFYaezmUlsRnusi)
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
			if (writeStartIndex >= HXTZQzGHjkZnNBFYaezmUlsRnusi)
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
			if (numBytesToWrite + writeStartIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
			}
			NativeTools.CopyMemory(bytes, faoeEyKYaPehQfvscfkWrXjEZQuB, readStartIndex, writeStartIndex, numBytesToWrite);
		}

		public int TryWriteBytes(byte[] bytes, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == null)
			{
				return 0;
			}
			int num = bytes.Length;
			if (num == 0 || numBytesToWrite <= 0 || readStartIndex >= num || writeStartIndex >= HXTZQzGHjkZnNBFYaezmUlsRnusi)
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
			if (numBytesToWrite + writeStartIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi)
			{
				numBytesToWrite = HXTZQzGHjkZnNBFYaezmUlsRnusi - writeStartIndex;
			}
			if (!NativeTools.CopyMemory(bytes, faoeEyKYaPehQfvscfkWrXjEZQuB, readStartIndex, writeStartIndex, numBytesToWrite, throwOnError: false))
			{
				return 0;
			}
			return numBytesToWrite;
		}

		public int TryWriteBytes(IntPtr bytes, int bufferLength, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0 || readStartIndex >= bufferLength || writeStartIndex >= HXTZQzGHjkZnNBFYaezmUlsRnusi)
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
			if (numBytesToWrite + writeStartIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi)
			{
				numBytesToWrite = HXTZQzGHjkZnNBFYaezmUlsRnusi - writeStartIndex;
			}
			if (!NativeTools.CopyMemory(bytes, faoeEyKYaPehQfvscfkWrXjEZQuB, readStartIndex, writeStartIndex, numBytesToWrite, throwOnError: false))
			{
				return 0;
			}
			return numBytesToWrite;
		}

		public int TryFill(byte value, int numBytesToWrite, int writeStartIndex = 0)
		{
			if (numBytesToWrite <= 0 || writeStartIndex >= HXTZQzGHjkZnNBFYaezmUlsRnusi)
			{
				return 0;
			}
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
			}
			if (numBytesToWrite + writeStartIndex > HXTZQzGHjkZnNBFYaezmUlsRnusi)
			{
				numBytesToWrite = HXTZQzGHjkZnNBFYaezmUlsRnusi - writeStartIndex;
			}
			if (!NativeTools.FillMemory(faoeEyKYaPehQfvscfkWrXjEZQuB, writeStartIndex, numBytesToWrite, value, throwOnError: false))
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
			if (HXTZQzGHjkZnNBFYaezmUlsRnusi == size)
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
				int bytesToCopy = MathTools.Min(size, HXTZQzGHjkZnNBFYaezmUlsRnusi);
				if (!NativeTools.CopyMemory(faoeEyKYaPehQfvscfkWrXjEZQuB, intPtr, 0, 0, bytesToCopy, throwOnError: false))
				{
					Marshal.FreeHGlobal(intPtr);
					return false;
				}
				if (size > HXTZQzGHjkZnNBFYaezmUlsRnusi)
				{
					NativeTools.FillMemory(intPtr, HXTZQzGHjkZnNBFYaezmUlsRnusi, size - HXTZQzGHjkZnNBFYaezmUlsRnusi, 0, throwOnError: false);
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
			faoeEyKYaPehQfvscfkWrXjEZQuB = intPtr;
			HXTZQzGHjkZnNBFYaezmUlsRnusi = size;
			return true;
		}

		public void Clear()
		{
			if (HXTZQzGHjkZnNBFYaezmUlsRnusi != 0)
			{
				NativeTools.ZeroFillMemory(faoeEyKYaPehQfvscfkWrXjEZQuB, HXTZQzGHjkZnNBFYaezmUlsRnusi);
			}
		}

		public void Release()
		{
			if (faoeEyKYaPehQfvscfkWrXjEZQuB != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(Pointer);
				faoeEyKYaPehQfvscfkWrXjEZQuB = IntPtr.Zero;
			}
			HXTZQzGHjkZnNBFYaezmUlsRnusi = 0;
		}

		public void CopyFrom(NativeBuffer other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (!(faoeEyKYaPehQfvscfkWrXjEZQuB == IntPtr.Zero) && !(other.Pointer == IntPtr.Zero))
			{
				int bytesToCopy = MathTools.Min(HXTZQzGHjkZnNBFYaezmUlsRnusi, other.HXTZQzGHjkZnNBFYaezmUlsRnusi);
				NativeTools.CopyMemory(other.faoeEyKYaPehQfvscfkWrXjEZQuB, faoeEyKYaPehQfvscfkWrXjEZQuB, 0, 0, bytesToCopy);
			}
		}

		public override string ToString()
		{
			return "Length = " + HXTZQzGHjkZnNBFYaezmUlsRnusi + "\nPointer = " + faoeEyKYaPehQfvscfkWrXjEZQuB + "\n";
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
			if (!wFtxnVROnubhehGUBaPWAtQsiPAD)
			{
				Release();
				wFtxnVROnubhehGUBaPWAtQsiPAD = true;
			}
		}

		public static implicit operator IntPtr(NativeBuffer buffer)
		{
			return buffer?.faoeEyKYaPehQfvscfkWrXjEZQuB ?? IntPtr.Zero;
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
			if (source.HXTZQzGHjkZnNBFYaezmUlsRnusi == 0)
			{
				destination.Release();
				return true;
			}
			if (destination.Resize(source.HXTZQzGHjkZnNBFYaezmUlsRnusi, preserveData: false))
			{
				return NativeTools.CopyMemory(source.faoeEyKYaPehQfvscfkWrXjEZQuB, destination.faoeEyKYaPehQfvscfkWrXjEZQuB, 0, 0, source.HXTZQzGHjkZnNBFYaezmUlsRnusi, throwOnError: false);
			}
			return false;
		}
	}
}
