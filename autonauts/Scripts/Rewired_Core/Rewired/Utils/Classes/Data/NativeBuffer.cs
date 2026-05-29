using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class NativeBuffer : IDisposable
	{
		private IntPtr BMlrMjaPgKfOXmbyPBCJKkloGjGF;

		private int xhGgbYsCBztjvEIBRgLFaPOdqHaD;

		private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

		public IntPtr Pointer
		{
			get
			{
				return BMlrMjaPgKfOXmbyPBCJKkloGjGF;
			}
		}

		public int Length
		{
			get
			{
				return xhGgbYsCBztjvEIBRgLFaPOdqHaD;
			}
		}

		public byte this[int index]
		{
			get
			{
				if (index >= 0)
				{
					if (index < xhGgbYsCBztjvEIBRgLFaPOdqHaD)
					{
						goto IL_0038;
					}
					while (true)
					{
						switch (0x3F0E3466 ^ 0x3F0E3467)
						{
						case 2:
							break;
						case 1:
							goto end_IL_000d;
						default:
							goto IL_0038;
						}
						continue;
						end_IL_000d:
						break;
					}
				}
				throw new IndexOutOfRangeException();
				IL_0038:
				return Marshal.ReadByte(BMlrMjaPgKfOXmbyPBCJKkloGjGF, index);
			}
			set
			{
				if (index >= 0)
				{
					if (index < xhGgbYsCBztjvEIBRgLFaPOdqHaD)
					{
						goto IL_0038;
					}
					while (true)
					{
						switch (0x310716E6 ^ 0x310716E7)
						{
						case 0:
							break;
						case 1:
							goto end_IL_000d;
						default:
							goto IL_0038;
						}
						continue;
						end_IL_000d:
						break;
					}
				}
				throw new IndexOutOfRangeException();
				IL_0038:
				Marshal.WriteByte(BMlrMjaPgKfOXmbyPBCJKkloGjGF, index, value);
			}
		}

		public NativeBuffer(int size)
		{
			while (true)
			{
				int num = 1045773165;
				while (true)
				{
					switch (num ^ 0x3E553B6C)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0024;
					case 2:
						return;
					}
					break;
					IL_0024:
					Resize(size, false);
					num = 1045773166;
				}
			}
		}

		public IntPtr GetPointer(int offset = 0)
		{
			if (BMlrMjaPgKfOXmbyPBCJKkloGjGF == IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			if (offset == 0)
			{
				return BMlrMjaPgKfOXmbyPBCJKkloGjGF;
			}
			if (offset >= 0)
			{
				while (true)
				{
					int num = -796922293;
					while (true)
					{
						switch (num ^ -796922296)
						{
						case 0:
							break;
						case 3:
							goto IL_0048;
						case 1:
							goto end_IL_0026;
						default:
							return NativeTools.OffsetIntPtr(BMlrMjaPgKfOXmbyPBCJKkloGjGF, offset);
						}
						break;
						IL_0048:
						int num2;
						if (offset < xhGgbYsCBztjvEIBRgLFaPOdqHaD)
						{
							num = -796922294;
							num2 = num;
						}
						else
						{
							num = -796922295;
							num2 = num;
						}
					}
					continue;
					end_IL_0026:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("offset");
		}

		public string DumpToHexString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num2 = default(int);
			while (true)
			{
				int num = -687529907;
				while (true)
				{
					switch (num ^ -687529908)
					{
					case 2:
						break;
					case 1:
						num2 = 0;
						num = -687529905;
						continue;
					case 0:
						stringBuilder.Append(ReadByte(num2).ToString("x2"));
						stringBuilder.Append(" ");
						num2++;
						num = -687529905;
						continue;
					default:
						if (num2 >= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
						{
							return stringBuilder.ToString();
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public bool ReadBit(int byteIndex, byte bit)
		{
			if (1 + byteIndex <= Length)
			{
				while (true)
				{
					int num = -1019445677;
					while (true)
					{
						switch (num ^ -1019445678)
						{
						case 2:
							break;
						case 1:
							goto IL_0031;
						case 3:
							goto end_IL_000b;
						case 0:
							if (bit >= 8)
							{
								throw new ArgumentOutOfRangeException("bit");
							}
							goto default;
						default:
							return (Marshal.ReadByte(BMlrMjaPgKfOXmbyPBCJKkloGjGF, byteIndex) & (1 << (int)bit)) != 0;
						}
						break;
						IL_0031:
						int num2;
						if (byteIndex >= 0)
						{
							num = -1019445678;
							num2 = num;
						}
						else
						{
							num = -1019445679;
							num2 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("byteIndex");
		}

		public byte ReadByte(int startIndex)
		{
			if (1 + startIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x708D1392 ^ 0x708D1393)
					{
					case 2:
						break;
					case 1:
						goto end_IL_000f;
					default:
						goto IL_003f;
					}
					continue;
					end_IL_000f:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("startIndex");
			IL_003f:
			return Marshal.ReadByte(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex);
		}

		public short ReadShort(int startIndex)
		{
			if (2 + startIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x49C70799 ^ 0x49C7079B)
					{
					case 0:
						break;
					case 2:
						goto end_IL_000f;
					default:
						goto IL_003f;
					}
					continue;
					end_IL_000f:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("startIndex");
			IL_003f:
			return Marshal.ReadInt16(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex);
		}

		public ushort ReadUShort(int startIndex)
		{
			if (2 + startIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				while (true)
				{
					int num = 714309160;
					while (true)
					{
						switch (num ^ 0x2A937E29)
						{
						case 2:
							break;
						case 1:
							goto IL_002d;
						case 3:
							goto end_IL_000b;
						default:
							return (ushort)Marshal.ReadInt16(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex);
						}
						break;
						IL_002d:
						int num2;
						if (startIndex < 0)
						{
							num = 714309162;
							num2 = num;
						}
						else
						{
							num = 714309161;
							num2 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("startIndex");
		}

		public int ReadInt(int startIndex)
		{
			if (4 + startIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (-250100786 ^ -250100785)
					{
					case 2:
						break;
					case 1:
						goto end_IL_000f;
					default:
						goto IL_003f;
					}
					continue;
					end_IL_000f:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("startIndex");
			IL_003f:
			return Marshal.ReadInt32(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex);
		}

		public uint ReadUInt(int startIndex)
		{
			if (4 + startIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x5307001E ^ 0x5307001C)
					{
					case 0:
						break;
					case 2:
						goto end_IL_000f;
					default:
						goto IL_003f;
					}
					continue;
					end_IL_000f:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("startIndex");
			IL_003f:
			return (uint)Marshal.ReadInt32(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex);
		}

		public long ReadLong(int startIndex)
		{
			if (8 + startIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x7B1D952E ^ 0x7B1D952F)
					{
					case 0:
						break;
					case 1:
						goto end_IL_000f;
					default:
						goto IL_003f;
					}
					continue;
					end_IL_000f:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("startIndex");
			IL_003f:
			return Marshal.ReadInt64(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex);
		}

		public ulong ReadULong(int startIndex)
		{
			if (8 + startIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x23E7A1ED ^ 0x23E7A1EF)
					{
					case 0:
						break;
					case 2:
						goto end_IL_000f;
					default:
						goto IL_003f;
					}
					continue;
					end_IL_000f:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("startIndex");
			IL_003f:
			return (ulong)Marshal.ReadInt64(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex);
		}

		public float ReadFloat(int startIndex)
		{
			if (4 + startIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				while (true)
				{
					int num = 908558578;
					while (true)
					{
						switch (num ^ 0x362780F1)
						{
						case 2:
							break;
						case 3:
							goto IL_002d;
						case 0:
							goto end_IL_000b;
						default:
							return new kHIMDCqneJWBAVTPVsEEmFVdjsl(Marshal.ReadInt32(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex)).wkCnxZAaaiEpecdxrCCPDQoCYMZb;
						}
						break;
						IL_002d:
						int num2;
						if (startIndex >= 0)
						{
							num = 908558576;
							num2 = num;
						}
						else
						{
							num = 908558577;
							num2 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("startIndex");
		}

		public double ReadDouble(int startIndex)
		{
			if (8 + startIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (-1011558058 ^ -1011558060)
					{
					case 0:
						break;
					case 2:
						goto end_IL_000f;
					default:
						goto IL_003f;
					}
					continue;
					end_IL_000f:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("startIndex");
			IL_003f:
			return new PJpdsqaAKTXAHuXqgSUsvMtRXUa(Marshal.ReadInt64(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex)).tWbpwkhcMRnCrJjcWdpRcErGQHqr;
		}

		public void Read(byte[] buffer, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("bytes");
			}
			while (true)
			{
				int num = buffer.Length;
				int num2;
				int num3;
				if (num <= 0)
				{
					num2 = -957278685;
					num3 = num2;
				}
				else
				{
					num2 = -957278676;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -957278679)
					{
					case 8:
						num2 = -957278680;
						continue;
					case 0:
					{
						int num5;
						if (numBytesToRead > num)
						{
							num2 = -957278681;
							num5 = num2;
						}
						else
						{
							num2 = -957278675;
							num5 = num2;
						}
						continue;
					}
					case 10:
						throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
					case 11:
					{
						int num4;
						if (readStartIndex < 0)
						{
							num2 = -957278678;
							num4 = num2;
						}
						else
						{
							num2 = -957278673;
							num4 = num2;
						}
						continue;
					}
					case 12:
						if (writeStartIndex >= num)
						{
							throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
						}
						goto case 9;
					case 7:
						if (readStartIndex >= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
						{
							throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
						}
						goto case 11;
					case 4:
						if (numBytesToRead > xhGgbYsCBztjvEIBRgLFaPOdqHaD)
						{
							throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
						}
						goto case 12;
					case 9:
						if (writeStartIndex < 0)
						{
							throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
						}
						goto case 7;
					case 1:
						break;
					case 2:
						if (numBytesToRead + readStartIndex > xhGgbYsCBztjvEIBRgLFaPOdqHaD)
						{
							throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
						}
						goto default;
					case 5:
						if (numBytesToRead <= 0)
						{
							throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
						}
						goto case 0;
					case 3:
						throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
					case 14:
						throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
					case 6:
						if (writeStartIndex + numBytesToRead > num)
						{
							throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
						}
						goto case 2;
					default:
						NativeTools.CopyMemory(BMlrMjaPgKfOXmbyPBCJKkloGjGF, buffer, readStartIndex, writeStartIndex, numBytesToRead);
						return;
					}
					break;
				}
			}
		}

		public void Read(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("bytes");
			}
			while (bufferLength > 0)
			{
				while (true)
				{
					IL_01bd:
					if (numBytesToRead > 0)
					{
						while (true)
						{
							IL_01a5:
							int num;
							int num2;
							if (numBytesToRead <= bufferLength)
							{
								num = 833452053;
								num2 = num;
							}
							else
							{
								num = 833452049;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ 0x31AD7818)
								{
								case 5:
									num = 833452059;
									continue;
								case 1:
									break;
								case 11:
									throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
								case 3:
									goto end_IL_0020;
								case 12:
									if (writeStartIndex < 0)
									{
										throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
									}
									goto case 4;
								case 0:
									goto IL_00d1;
								case 8:
									throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
								case 2:
									throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
								case 13:
									if (numBytesToRead > xhGgbYsCBztjvEIBRgLFaPOdqHaD)
									{
										throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
									}
									goto IL_016a;
								case 10:
									if (writeStartIndex + numBytesToRead > bufferLength)
									{
										throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
									}
									goto IL_00d1;
								case 9:
									throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
								case 14:
									goto IL_016a;
								case 4:
									if (readStartIndex >= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
									{
										throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
									}
									break;
								case 6:
									goto IL_01a5;
								case 7:
									goto IL_01bd;
								default:
									NativeTools.CopyMemory(BMlrMjaPgKfOXmbyPBCJKkloGjGF, buffer, readStartIndex, writeStartIndex, numBytesToRead);
									return;
								}
								int num3;
								if (readStartIndex < 0)
								{
									num = 833452048;
									num3 = num;
								}
								else
								{
									num = 833452050;
									num3 = num;
								}
								continue;
								IL_016a:
								int num4;
								if (writeStartIndex < bufferLength)
								{
									num = 833452052;
									num4 = num;
								}
								else
								{
									num = 833452051;
									num4 = num;
								}
								continue;
								IL_00d1:
								int num5;
								if (numBytesToRead + readStartIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
								{
									num = 833452055;
									num5 = num;
								}
								else
								{
									num = 833452058;
									num5 = num;
								}
								continue;
								end_IL_0020:
								break;
							}
							break;
						}
						break;
					}
					throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
				}
			}
			throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
		}

		public int TryReadBytes(byte[] buffer, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer != null)
			{
				int num2 = default(int);
				while (true)
				{
					int num = -1035234948;
					while (true)
					{
						switch (num ^ -1035234952)
						{
						case 0:
							break;
						case 4:
							goto IL_0040;
						case 6:
							numBytesToRead = num2 - writeStartIndex;
							num = -1035234947;
							continue;
						case 7:
							goto IL_0058;
						case 2:
							goto end_IL_0003;
						case 1:
							writeStartIndex = 0;
							num = -1035234960;
							continue;
						case 9:
							goto IL_0088;
						case 3:
							return 0;
						case 8:
							if (readStartIndex + numBytesToRead > xhGgbYsCBztjvEIBRgLFaPOdqHaD)
							{
								numBytesToRead = xhGgbYsCBztjvEIBRgLFaPOdqHaD - readStartIndex;
								num = -1035234959;
								continue;
							}
							goto IL_0088;
						default:
							goto IL_00e7;
						}
						break;
						IL_0088:
						int num3;
						if (writeStartIndex + numBytesToRead > num2)
						{
							num = -1035234946;
							num3 = num;
						}
						else
						{
							num = -1035234947;
							num3 = num;
						}
						continue;
						IL_0040:
						if (numBytesToRead <= 0)
						{
							num = -1035234950;
							continue;
						}
						num2 = buffer.Length;
						if (num2 == 0)
						{
							num = -1035234949;
							continue;
						}
						if (readStartIndex >= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
						{
							return 0;
						}
						if (writeStartIndex >= num2)
						{
							return 0;
						}
						if (readStartIndex < 0)
						{
							readStartIndex = 0;
							num = -1035234945;
							continue;
						}
						goto IL_0058;
						IL_0058:
						int num4;
						if (writeStartIndex >= 0)
						{
							num = -1035234960;
							num4 = num;
						}
						else
						{
							num = -1035234951;
							num4 = num;
						}
					}
					continue;
					IL_00e7:
					if (numBytesToRead == 0)
					{
						return 0;
					}
					if (!NativeTools.CopyMemory(BMlrMjaPgKfOXmbyPBCJKkloGjGF, buffer, readStartIndex, writeStartIndex, numBytesToRead, false))
					{
						return 0;
					}
					return numBytesToRead;
					continue;
					end_IL_0003:
					break;
				}
			}
			return 0;
		}

		public int TryReadBytes(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer == IntPtr.Zero)
			{
				goto IL_0076;
			}
			if (numBytesToRead <= 0)
			{
				goto IL_0011;
			}
			if (readStartIndex >= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				return 0;
			}
			if (writeStartIndex >= bufferLength)
			{
				return 0;
			}
			int num;
			if (readStartIndex < 0)
			{
				readStartIndex = 0;
				num = -1882075219;
				goto IL_0016;
			}
			goto IL_009d;
			IL_009d:
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
				num = -1882075224;
				goto IL_0016;
			}
			goto IL_00af;
			IL_0011:
			num = -1882075220;
			goto IL_0016;
			IL_0016:
			while (true)
			{
				switch (num ^ -1882075222)
				{
				case 5:
					break;
				case 1:
					goto IL_0046;
				case 0:
					numBytesToRead = xhGgbYsCBztjvEIBRgLFaPOdqHaD - readStartIndex;
					num = -1882075223;
					continue;
				case 6:
					goto IL_0076;
				case 7:
					goto IL_009d;
				case 2:
					goto IL_00af;
				case 3:
					if (writeStartIndex + numBytesToRead > bufferLength)
					{
						numBytesToRead = bufferLength - writeStartIndex;
						num = -1882075221;
						continue;
					}
					goto IL_0046;
				default:
					return 0;
				}
				break;
				IL_0046:
				if (!NativeTools.CopyMemory(BMlrMjaPgKfOXmbyPBCJKkloGjGF, buffer, readStartIndex, writeStartIndex, numBytesToRead, false))
				{
					num = -1882075218;
					continue;
				}
				return numBytesToRead;
			}
			goto IL_0011;
			IL_0076:
			return 0;
			IL_00af:
			int num2;
			if (readStartIndex + numBytesToRead > xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				num = -1882075222;
				num2 = num;
			}
			else
			{
				num = -1882075223;
				num2 = num;
			}
			goto IL_0016;
		}

		public void WriteBit(int byteIndex, byte bit, bool value)
		{
			if (1 + byteIndex > Length)
			{
				goto IL_0077;
			}
			if (byteIndex < 0)
			{
				goto IL_000f;
			}
			goto IL_0089;
			IL_0077:
			throw new ArgumentOutOfRangeException("byteIndex");
			IL_000f:
			int num = 873989907;
			goto IL_0014;
			IL_0014:
			switch (num ^ 0x34180717)
			{
			case 3:
				break;
			case 0:
				throw new ArgumentOutOfRangeException("bit");
			case 1:
				if (value)
				{
					Marshal.WriteByte(BMlrMjaPgKfOXmbyPBCJKkloGjGF, byteIndex, (byte)(Marshal.ReadByte(BMlrMjaPgKfOXmbyPBCJKkloGjGF, byteIndex) | (byte)(1 << (int)bit)));
					return;
				}
				goto default;
			case 4:
				goto IL_0077;
			case 5:
				goto IL_0089;
			default:
				Marshal.WriteByte(BMlrMjaPgKfOXmbyPBCJKkloGjGF, byteIndex, (byte)(Marshal.ReadByte(BMlrMjaPgKfOXmbyPBCJKkloGjGF, byteIndex) & (byte)(~(1 << (int)bit))));
				return;
			}
			goto IL_000f;
			IL_0089:
			int num2;
			if (bit >= 8)
			{
				num = 873989911;
				num2 = num;
			}
			else
			{
				num = 873989910;
				num2 = num;
			}
			goto IL_0014;
		}

		public void Write(byte @byte, int startIndex)
		{
			if (1 + startIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				while (true)
				{
					int num = 205790907;
					while (true)
					{
						switch (num ^ 0xC441EB9)
						{
						case 3:
							break;
						case 2:
							goto IL_002d;
						case 1:
							goto end_IL_000b;
						default:
							Marshal.WriteByte(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex, @byte);
							return;
						}
						break;
						IL_002d:
						int num2;
						if (startIndex < 0)
						{
							num = 205790904;
							num2 = num;
						}
						else
						{
							num = 205790905;
							num2 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("startIndex");
		}

		public void Write(short bytes, int startIndex)
		{
			if (2 + startIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				while (true)
				{
					int num = 1698863835;
					while (true)
					{
						switch (num ^ 0x65429AD8)
						{
						case 0:
							break;
						case 3:
							goto IL_002d;
						case 1:
							goto end_IL_000b;
						default:
							Marshal.WriteInt16(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex, bytes);
							return;
						}
						break;
						IL_002d:
						int num2;
						if (startIndex >= 0)
						{
							num = 1698863834;
							num2 = num;
						}
						else
						{
							num = 1698863833;
							num2 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("startIndex");
		}

		public void Write(ushort bytes, int startIndex)
		{
			if (2 + startIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				while (true)
				{
					int num = 1805954106;
					while (true)
					{
						switch (num ^ 0x6BA4AC3B)
						{
						case 3:
							break;
						case 1:
							goto IL_002d;
						case 0:
							goto end_IL_000b;
						default:
							Marshal.WriteInt16(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex, (short)bytes);
							return;
						}
						break;
						IL_002d:
						int num2;
						if (startIndex >= 0)
						{
							num = 1805954105;
							num2 = num;
						}
						else
						{
							num = 1805954107;
							num2 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("startIndex");
		}

		public void Write(int bytes, int startIndex)
		{
			if (4 + startIndex > xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				goto IL_0031;
			}
			if (startIndex < 0)
			{
				goto IL_000f;
			}
			goto IL_0043;
			IL_0043:
			Marshal.WriteInt32(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex, bytes);
			int num = -924063247;
			goto IL_0014;
			IL_000f:
			num = -924063245;
			goto IL_0014;
			IL_0014:
			switch (num ^ -924063246)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_0031;
			case 2:
				goto IL_0043;
			case 3:
				return;
			}
			goto IL_000f;
			IL_0031:
			throw new ArgumentOutOfRangeException("startIndex");
		}

		public void Write(uint bytes, int startIndex)
		{
			if (4 + startIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x4D2C11D7 ^ 0x4D2C11D6)
					{
					case 2:
						break;
					case 1:
						goto end_IL_000f;
					default:
						goto IL_003f;
					}
					continue;
					end_IL_000f:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("startIndex");
			IL_003f:
			Marshal.WriteInt32(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex, (int)bytes);
		}

		public void Write(long bytes, int startIndex)
		{
			if (8 + startIndex > xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				goto IL_0031;
			}
			if (startIndex < 0)
			{
				goto IL_000f;
			}
			goto IL_0043;
			IL_0031:
			throw new ArgumentOutOfRangeException("startIndex");
			IL_000f:
			int num = 1843803015;
			goto IL_0014;
			IL_0014:
			switch (num ^ 0x6DE63385)
			{
			case 3:
				break;
			default:
				return;
			case 2:
				goto IL_0031;
			case 1:
				goto IL_0043;
			case 0:
				return;
			}
			goto IL_000f;
			IL_0043:
			Marshal.WriteInt64(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex, bytes);
			num = 1843803013;
			goto IL_0014;
		}

		public void Write(ulong bytes, int startIndex)
		{
			if (8 + startIndex > xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				goto IL_0031;
			}
			if (startIndex < 0)
			{
				goto IL_000f;
			}
			goto IL_0043;
			IL_0043:
			Marshal.WriteInt64(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex, (long)bytes);
			int num = 1703679051;
			goto IL_0014;
			IL_000f:
			num = 1703679048;
			goto IL_0014;
			IL_0014:
			switch (num ^ 0x658C1449)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_0031;
			case 3:
				goto IL_0043;
			case 2:
				return;
			}
			goto IL_000f;
			IL_0031:
			throw new ArgumentOutOfRangeException("startIndex");
		}

		public void Write(float bytes, int startIndex)
		{
			if (4 + startIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (-1105816299 ^ -1105816300)
					{
					case 0:
						break;
					case 1:
						goto end_IL_000f;
					default:
						goto IL_003f;
					}
					continue;
					end_IL_000f:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("startIndex");
			IL_003f:
			Marshal.WriteInt32(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex, new kHIMDCqneJWBAVTPVsEEmFVdjsl(bytes).fGPAjzCYdjxGnpfCRjmuMwsMMdK);
		}

		public void Write(double bytes, int startIndex)
		{
			if (8 + startIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
			{
				while (true)
				{
					int num = -564205546;
					while (true)
					{
						switch (num ^ -564205545)
						{
						case 3:
							break;
						case 1:
							goto IL_002d;
						case 2:
							goto end_IL_000b;
						default:
							Marshal.WriteInt64(BMlrMjaPgKfOXmbyPBCJKkloGjGF, startIndex, new PJpdsqaAKTXAHuXqgSUsvMtRXUa(bytes).BKAuUPgfoCVtfGLbRIaUdCXxnpxu);
							return;
						}
						break;
						IL_002d:
						int num2;
						if (startIndex >= 0)
						{
							num = -564205545;
							num2 = num;
						}
						else
						{
							num = -564205547;
							num2 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("startIndex");
		}

		public void Write(byte[] bytes, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException("bytes");
			}
			while (true)
			{
				int num = bytes.Length;
				if (num <= 0)
				{
					break;
				}
				while (true)
				{
					if (numBytesToWrite <= 0)
					{
						throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
					}
					while (true)
					{
						IL_012c:
						if (numBytesToWrite > num)
						{
							throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
						}
						while (true)
						{
							IL_0197:
							if (numBytesToWrite <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
							{
								while (true)
								{
									IL_0161:
									int num2;
									int num3;
									if (readStartIndex < num)
									{
										num2 = -929525509;
										num3 = num2;
									}
									else
									{
										num2 = -929525511;
										num3 = num2;
									}
									while (true)
									{
										switch (num2 ^ -929525518)
										{
										case 10:
											num2 = -929525508;
											continue;
										case 11:
											throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
										case 8:
											break;
										case 13:
											goto IL_008e;
										case 0:
											throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
										case 1:
											throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
										case 6:
											if (numBytesToWrite + writeStartIndex > xhGgbYsCBztjvEIBRgLFaPOdqHaD)
											{
												throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
											}
											goto default;
										case 9:
											if (readStartIndex < 0)
											{
												throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
											}
											break;
										case 7:
											goto end_IL_0016;
										case 3:
											goto IL_012c;
										case 12:
											if (writeStartIndex < 0)
											{
												throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
											}
											goto IL_008e;
										case 2:
											goto IL_0161;
										case 14:
											goto end_IL_0113;
										case 4:
											goto IL_0197;
										default:
											NativeTools.CopyMemory(bytes, BMlrMjaPgKfOXmbyPBCJKkloGjGF, readStartIndex, writeStartIndex, numBytesToWrite);
											return;
										}
										int num4;
										if (writeStartIndex >= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
										{
											num2 = -929525517;
											num4 = num2;
										}
										else
										{
											num2 = -929525506;
											num4 = num2;
										}
										continue;
										IL_008e:
										int num5;
										if (readStartIndex + numBytesToWrite > num)
										{
											num2 = -929525518;
											num5 = num2;
										}
										else
										{
											num2 = -929525516;
											num5 = num2;
										}
										continue;
										end_IL_0016:
										break;
									}
									break;
								}
								break;
							}
							throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
						}
						break;
					}
					continue;
					end_IL_0113:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
		}

		public void Write(IntPtr bytes, int bufferLength, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == IntPtr.Zero)
			{
				throw new ArgumentNullException("bytes");
			}
			while (true)
			{
				int num;
				int num2;
				if (bufferLength > 0)
				{
					num = 1922934066;
					num2 = num;
				}
				else
				{
					num = 1922934076;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x729DA53C)
					{
					case 5:
						num = 1922934075;
						continue;
					case 7:
						break;
					case 13:
						if (readStartIndex < 0)
						{
							throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
						}
						goto case 8;
					case 9:
						if (readStartIndex + numBytesToWrite > bufferLength)
						{
							throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
						}
						goto case 1;
					case 6:
						if (numBytesToWrite > bufferLength)
						{
							throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
						}
						goto case 2;
					case 4:
						throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
					case 0:
						throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
					case 11:
						throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
					case 14:
						if (numBytesToWrite <= 0)
						{
							throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
						}
						goto case 6;
					case 8:
					{
						int num3;
						if (writeStartIndex < xhGgbYsCBztjvEIBRgLFaPOdqHaD)
						{
							num = 1922934079;
							num3 = num;
						}
						else
						{
							num = 1922934071;
							num3 = num;
						}
						continue;
					}
					case 3:
						if (writeStartIndex < 0)
						{
							throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
						}
						goto case 9;
					case 2:
						if (numBytesToWrite > xhGgbYsCBztjvEIBRgLFaPOdqHaD)
						{
							throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
						}
						goto case 12;
					case 12:
					{
						int num4;
						if (readStartIndex >= bufferLength)
						{
							num = 1922934072;
							num4 = num;
						}
						else
						{
							num = 1922934065;
							num4 = num;
						}
						continue;
					}
					case 1:
						if (numBytesToWrite + writeStartIndex > xhGgbYsCBztjvEIBRgLFaPOdqHaD)
						{
							throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
						}
						goto default;
					default:
						NativeTools.CopyMemory(bytes, BMlrMjaPgKfOXmbyPBCJKkloGjGF, readStartIndex, writeStartIndex, numBytesToWrite);
						return;
					}
					break;
				}
			}
		}

		public int TryWriteBytes(byte[] bytes, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == null)
			{
				return 0;
			}
			int num = bytes.Length;
			while (true)
			{
				int num2 = 1112436870;
				while (true)
				{
					switch (num2 ^ 0x424E7085)
					{
					case 6:
						break;
					case 0:
						readStartIndex = 0;
						num2 = 1112436865;
						continue;
					case 8:
					{
						int num5;
						if (numBytesToWrite <= 0)
						{
							num2 = 1112436866;
							num5 = num2;
						}
						else
						{
							num2 = 1112436871;
							num5 = num2;
						}
						continue;
					}
					case 1:
					{
						int num3;
						if (numBytesToWrite + writeStartIndex <= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
						{
							num2 = 1112436879;
							num3 = num2;
						}
						else
						{
							num2 = 1112436864;
							num3 = num2;
						}
						continue;
					}
					case 7:
						return 0;
					case 5:
						numBytesToWrite = xhGgbYsCBztjvEIBRgLFaPOdqHaD - writeStartIndex;
						num2 = 1112436879;
						continue;
					case 4:
						if (writeStartIndex < 0)
						{
							writeStartIndex = 0;
							num2 = 1112436876;
							continue;
						}
						goto case 9;
					case 2:
						if (readStartIndex < num)
						{
							if (writeStartIndex < xhGgbYsCBztjvEIBRgLFaPOdqHaD)
							{
								int num6;
								if (readStartIndex >= 0)
								{
									num2 = 1112436865;
									num6 = num2;
								}
								else
								{
									num2 = 1112436869;
									num6 = num2;
								}
							}
							else
							{
								num2 = 1112436866;
							}
							continue;
						}
						goto case 7;
					case 3:
					{
						int num4;
						if (num != 0)
						{
							num2 = 1112436877;
							num4 = num2;
						}
						else
						{
							num2 = 1112436866;
							num4 = num2;
						}
						continue;
					}
					case 9:
						if (readStartIndex + numBytesToWrite > num)
						{
							numBytesToWrite = num - readStartIndex;
							num2 = 1112436868;
							continue;
						}
						goto case 1;
					default:
						if (!NativeTools.CopyMemory(bytes, BMlrMjaPgKfOXmbyPBCJKkloGjGF, readStartIndex, writeStartIndex, numBytesToWrite, false))
						{
							return 0;
						}
						return numBytesToWrite;
					}
					break;
				}
			}
		}

		public int TryWriteBytes(IntPtr bytes, int bufferLength, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			int num;
			if (!(bytes == IntPtr.Zero) && bufferLength > 0 && numBytesToWrite > 0 && readStartIndex < bufferLength)
			{
				if (writeStartIndex >= xhGgbYsCBztjvEIBRgLFaPOdqHaD)
				{
					goto IL_0024;
				}
				int num2;
				if (readStartIndex < 0)
				{
					num = 1408887750;
					num2 = num;
				}
				else
				{
					num = 1408887744;
					num2 = num;
				}
				goto IL_0029;
			}
			goto IL_0070;
			IL_0029:
			while (true)
			{
				switch (num ^ 0x53F9EBC0)
				{
				case 2:
					break;
				case 1:
					if (readStartIndex + numBytesToWrite > bufferLength)
					{
						numBytesToWrite = bufferLength - readStartIndex;
						num = 1408887749;
						continue;
					}
					goto case 5;
				case 6:
					readStartIndex = 0;
					num = 1408887744;
					continue;
				case 4:
					goto IL_0070;
				case 5:
					if (numBytesToWrite + writeStartIndex > xhGgbYsCBztjvEIBRgLFaPOdqHaD)
					{
						numBytesToWrite = xhGgbYsCBztjvEIBRgLFaPOdqHaD - writeStartIndex;
						num = 1408887747;
						continue;
					}
					goto IL_00b8;
				case 0:
					if (writeStartIndex < 0)
					{
						writeStartIndex = 0;
						num = 1408887745;
						continue;
					}
					goto case 1;
				default:
					goto IL_00b8;
				}
				break;
			}
			goto IL_0024;
			IL_0070:
			return 0;
			IL_00b8:
			if (!NativeTools.CopyMemory(bytes, BMlrMjaPgKfOXmbyPBCJKkloGjGF, readStartIndex, writeStartIndex, numBytesToWrite, false))
			{
				return 0;
			}
			return numBytesToWrite;
			IL_0024:
			num = 1408887748;
			goto IL_0029;
		}

		public bool Resize(int size, bool preserveData)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			if (xhGgbYsCBztjvEIBRgLFaPOdqHaD == size)
			{
				return true;
			}
			if (size == 0)
			{
				Release();
				return true;
			}
			IntPtr intPtr;
			int num;
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
				int bytesToCopy = MathTools.Min(size, xhGgbYsCBztjvEIBRgLFaPOdqHaD);
				if (!NativeTools.CopyMemory(BMlrMjaPgKfOXmbyPBCJKkloGjGF, intPtr, 0, 0, bytesToCopy, false))
				{
					Marshal.FreeHGlobal(intPtr);
					goto IL_0075;
				}
				if (size > xhGgbYsCBztjvEIBRgLFaPOdqHaD)
				{
					NativeTools.FillMemory(intPtr, xhGgbYsCBztjvEIBRgLFaPOdqHaD, size - xhGgbYsCBztjvEIBRgLFaPOdqHaD, 0, false);
					num = 1135323145;
					goto IL_007a;
				}
				goto IL_00d0;
			}
			goto IL_00dd;
			IL_0075:
			num = 1135323144;
			goto IL_007a;
			IL_00d0:
			Release();
			num = 1135323147;
			goto IL_007a;
			IL_00dd:
			Release();
			try
			{
				intPtr = Marshal.AllocHGlobal(size);
				while (true)
				{
					switch (0x43ABA80B ^ 0x43ABA809)
					{
					case 0:
						break;
					default:
						goto end_IL_00ea;
					case 2:
						if (intPtr == IntPtr.Zero)
						{
							return false;
						}
						goto end_IL_00ea;
					case 1:
						goto end_IL_00ea;
					}
					continue;
					end_IL_00ea:
					break;
				}
			}
			catch
			{
				return false;
			}
			NativeTools.ZeroFillMemory(intPtr, size);
			goto IL_012e;
			IL_0133:
			int num2;
			switch (num2 ^ 0x43ABA809)
			{
			case 0:
				break;
			case 2:
				goto IL_014c;
			default:
				return true;
			}
			goto IL_012e;
			IL_012e:
			num2 = 1135323147;
			goto IL_0133;
			IL_014c:
			BMlrMjaPgKfOXmbyPBCJKkloGjGF = intPtr;
			xhGgbYsCBztjvEIBRgLFaPOdqHaD = size;
			num2 = 1135323144;
			goto IL_0133;
			IL_007a:
			switch (num ^ 0x43ABA809)
			{
			case 3:
				break;
			case 1:
				return false;
			case 0:
				goto IL_00d0;
			default:
				goto IL_00dd;
			case 2:
				goto IL_014c;
			}
			goto IL_0075;
		}

		public void Clear()
		{
			if (xhGgbYsCBztjvEIBRgLFaPOdqHaD == 0)
			{
				while (true)
				{
					switch (-1750502848 ^ -1750502846)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			NativeTools.ZeroFillMemory(BMlrMjaPgKfOXmbyPBCJKkloGjGF, xhGgbYsCBztjvEIBRgLFaPOdqHaD);
		}

		public void Release()
		{
			if (BMlrMjaPgKfOXmbyPBCJKkloGjGF != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(Pointer);
				goto IL_001d;
			}
			goto IL_0051;
			IL_0051:
			xhGgbYsCBztjvEIBRgLFaPOdqHaD = 0;
			int num = -1473591853;
			goto IL_0022;
			IL_001d:
			num = -1473591855;
			goto IL_0022;
			IL_0022:
			while (true)
			{
				switch (num ^ -1473591853)
				{
				case 3:
					break;
				default:
					return;
				case 2:
					BMlrMjaPgKfOXmbyPBCJKkloGjGF = IntPtr.Zero;
					num = -1473591854;
					continue;
				case 1:
					goto IL_0051;
				case 0:
					return;
				}
				break;
			}
			goto IL_001d;
		}

		public override string ToString()
		{
			return "Length = " + xhGgbYsCBztjvEIBRgLFaPOdqHaD + "\nPointer = " + BMlrMjaPgKfOXmbyPBCJKkloGjGF + "\n";
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~NativeBuffer()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (QQqHByfwytAJSuMZiCPjJlZYHKG)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -1618276296;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1618276295)
			{
			case 2:
				break;
			case 1:
				return;
			case 3:
				goto IL_0032;
			default:
				Release();
				QQqHByfwytAJSuMZiCPjJlZYHKG = true;
				return;
			}
			goto IL_0008;
			IL_0032:
			num = -1618276295;
			goto IL_000d;
		}

		public static implicit operator IntPtr(NativeBuffer buffer)
		{
			if (buffer == null)
			{
				return IntPtr.Zero;
			}
			return buffer.BMlrMjaPgKfOXmbyPBCJKkloGjGF;
		}

		public static bool Copy(NativeBuffer source, NativeBuffer destination)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			while (true)
			{
				int num;
				int num2;
				if (destination != null)
				{
					num = -877623568;
					num2 = num;
				}
				else
				{
					num = -877623561;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -877623563)
					{
					case 4:
						num = -877623562;
						continue;
					case 0:
						destination.Release();
						num = -877623564;
						continue;
					case 5:
						if (source.xhGgbYsCBztjvEIBRgLFaPOdqHaD == 0)
						{
							num = -877623563;
							continue;
						}
						if (destination.Resize(source.xhGgbYsCBztjvEIBRgLFaPOdqHaD, false))
						{
							return NativeTools.CopyMemory(source.BMlrMjaPgKfOXmbyPBCJKkloGjGF, destination.BMlrMjaPgKfOXmbyPBCJKkloGjGF, 0, 0, source.xhGgbYsCBztjvEIBRgLFaPOdqHaD, false);
						}
						return false;
					case 2:
						throw new ArgumentNullException("destination");
					case 3:
						break;
					default:
						return true;
					}
					break;
				}
			}
		}
	}
}
