using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class NativeBuffer : IDisposable
	{
		private IntPtr gNjdluGtZYcXOByPMlpGoZVhqyt;

		private int MiEKlFCVmtuVkzPoSyHENjasCYN;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		public IntPtr Pointer => gNjdluGtZYcXOByPMlpGoZVhqyt;

		public int Length => MiEKlFCVmtuVkzPoSyHENjasCYN;

		public byte this[int index]
		{
			get
			{
				if (index >= 0)
				{
					while (true)
					{
						int num = -440914028;
						while (true)
						{
							switch (num ^ -440914027)
							{
							case 3:
								break;
							case 1:
								goto IL_0026;
							case 2:
								goto end_IL_0004;
							default:
								return Marshal.ReadByte(gNjdluGtZYcXOByPMlpGoZVhqyt, index);
							}
							break;
							IL_0026:
							int num2;
							if (index < MiEKlFCVmtuVkzPoSyHENjasCYN)
							{
								num = -440914027;
								num2 = num;
							}
							else
							{
								num = -440914025;
								num2 = num;
							}
						}
						continue;
						end_IL_0004:
						break;
					}
				}
				throw new IndexOutOfRangeException();
			}
			set
			{
				if (index >= 0)
				{
					while (true)
					{
						int num = 1361392680;
						while (true)
						{
							switch (num ^ 0x5125342A)
							{
							case 3:
								break;
							case 2:
								goto IL_0026;
							case 1:
								goto end_IL_0004;
							default:
								Marshal.WriteByte(gNjdluGtZYcXOByPMlpGoZVhqyt, index, value);
								return;
							}
							break;
							IL_0026:
							int num2;
							if (index >= MiEKlFCVmtuVkzPoSyHENjasCYN)
							{
								num = 1361392683;
								num2 = num;
							}
							else
							{
								num = 1361392682;
								num2 = num;
							}
						}
						continue;
						end_IL_0004:
						break;
					}
				}
				throw new IndexOutOfRangeException();
			}
		}

		public NativeBuffer(int size)
		{
			Resize(size, preserveData: false);
		}

		public IntPtr GetPointer(int offset = 0)
		{
			if (gNjdluGtZYcXOByPMlpGoZVhqyt == IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			if (offset == 0)
			{
				return gNjdluGtZYcXOByPMlpGoZVhqyt;
			}
			if (offset >= 0)
			{
				if (offset < MiEKlFCVmtuVkzPoSyHENjasCYN)
				{
					goto IL_005f;
				}
				while (true)
				{
					switch (-1130062251 ^ -1130062249)
					{
					case 0:
						break;
					case 2:
						goto end_IL_002f;
					default:
						goto IL_005f;
					}
					continue;
					end_IL_002f:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("offset");
			IL_005f:
			return NativeTools.OffsetIntPtr(gNjdluGtZYcXOByPMlpGoZVhqyt, offset);
		}

		public string DumpToHexString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			while (true)
			{
				int num2 = 602978712;
				while (true)
				{
					switch (num2 ^ 0x23F0B999)
					{
					case 4:
						break;
					case 1:
						num2 = 602978714;
						continue;
					case 0:
						stringBuilder.Append(" ");
						num2 = 602978715;
						continue;
					case 5:
						stringBuilder.Append(ReadByte(num).ToString("x2"));
						num2 = 602978713;
						continue;
					case 2:
						num++;
						num2 = 602978714;
						continue;
					default:
						if (num >= MiEKlFCVmtuVkzPoSyHENjasCYN)
						{
							return stringBuilder.ToString();
						}
						goto case 5;
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
					int num = 133411079;
					while (true)
					{
						switch (num ^ 0x7F3B103)
						{
						case 0:
							break;
						case 2:
							if (bit >= 8)
							{
								throw new ArgumentOutOfRangeException("bit");
							}
							goto default;
						case 3:
							goto end_IL_000b;
						case 4:
							goto IL_0059;
						default:
							return (Marshal.ReadByte(gNjdluGtZYcXOByPMlpGoZVhqyt, byteIndex) & (1 << (int)bit)) != 0;
						}
						break;
						IL_0059:
						int num2;
						if (byteIndex >= 0)
						{
							num = 133411073;
							num2 = num;
						}
						else
						{
							num = 133411072;
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
			if (1 + startIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
			{
				while (true)
				{
					int num = -1586217661;
					while (true)
					{
						switch (num ^ -1586217662)
						{
						case 3:
							break;
						case 1:
							goto IL_002d;
						case 0:
							goto end_IL_000b;
						default:
							return Marshal.ReadByte(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex);
						}
						break;
						IL_002d:
						int num2;
						if (startIndex >= 0)
						{
							num = -1586217664;
							num2 = num;
						}
						else
						{
							num = -1586217662;
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

		public short ReadShort(int startIndex)
		{
			if (2 + startIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
			{
				while (true)
				{
					int num = 1899823644;
					while (true)
					{
						switch (num ^ 0x713D021F)
						{
						case 0:
							break;
						case 3:
							goto IL_002d;
						case 1:
							goto end_IL_000b;
						default:
							return Marshal.ReadInt16(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex);
						}
						break;
						IL_002d:
						int num2;
						if (startIndex < 0)
						{
							num = 1899823646;
							num2 = num;
						}
						else
						{
							num = 1899823645;
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

		public ushort ReadUShort(int startIndex)
		{
			if (2 + startIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (-161587389 ^ -161587390)
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
			return (ushort)Marshal.ReadInt16(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex);
		}

		public int ReadInt(int startIndex)
		{
			if (4 + startIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x2AD0D4 ^ 0x2AD0D5)
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
			return Marshal.ReadInt32(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex);
		}

		public uint ReadUInt(int startIndex)
		{
			if (4 + startIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x49787DE6 ^ 0x49787DE7)
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
			return (uint)Marshal.ReadInt32(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex);
		}

		public long ReadLong(int startIndex)
		{
			if (8 + startIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (-175325677 ^ -175325678)
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
			return Marshal.ReadInt64(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex);
		}

		public ulong ReadULong(int startIndex)
		{
			if (8 + startIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x55A933B6 ^ 0x55A933B7)
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
			return (ulong)Marshal.ReadInt64(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex);
		}

		public float ReadFloat(int startIndex)
		{
			if (4 + startIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
			{
				while (true)
				{
					int num = 778106991;
					while (true)
					{
						switch (num ^ 0x2E60F86C)
						{
						case 0:
							break;
						case 3:
							goto IL_002d;
						case 1:
							goto end_IL_000b;
						default:
							return new deFkfjHJIndjmwybARqvXpzyvbn(Marshal.ReadInt32(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex)).VlYIlGajNcGszIOIaHnUWsGNPwm;
						}
						break;
						IL_002d:
						int num2;
						if (startIndex >= 0)
						{
							num = 778106990;
							num2 = num;
						}
						else
						{
							num = 778106989;
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
			if (8 + startIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
			{
				while (true)
				{
					int num = 397358167;
					while (true)
					{
						switch (num ^ 0x17AF3456)
						{
						case 3:
							break;
						case 1:
							goto IL_002d;
						case 0:
							goto end_IL_000b;
						default:
							return new uNdRRhMGtXyZOXbPnexvfpFKZJDn(Marshal.ReadInt64(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex)).UXdbVhPdvRMFwgXLHmAEWhFVQOJ;
						}
						break;
						IL_002d:
						int num2;
						if (startIndex >= 0)
						{
							num = 397358164;
							num2 = num;
						}
						else
						{
							num = 397358166;
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

		public void Read(byte[] buffer, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("bytes");
			}
			while (true)
			{
				int num = buffer.Length;
				if (num <= 0)
				{
					break;
				}
				while (true)
				{
					IL_0184:
					if (numBytesToRead > 0)
					{
						while (true)
						{
							int num2;
							int num3;
							if (numBytesToRead <= num)
							{
								num2 = -439351252;
								num3 = num2;
							}
							else
							{
								num2 = -439351253;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ -439351264)
								{
								case 9:
									num2 = -439351254;
									continue;
								case 5:
									if (readStartIndex >= MiEKlFCVmtuVkzPoSyHENjasCYN)
									{
										throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
									}
									goto IL_00ab;
								case 2:
									if (writeStartIndex >= num)
									{
										throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
									}
									goto case 1;
								case 3:
									break;
								case 13:
									goto IL_00ab;
								case 7:
									if (writeStartIndex + numBytesToRead > num)
									{
										throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
									}
									goto case 0;
								case 12:
									if (numBytesToRead > MiEKlFCVmtuVkzPoSyHENjasCYN)
									{
										throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
									}
									goto case 2;
								case 0:
									if (numBytesToRead + readStartIndex > MiEKlFCVmtuVkzPoSyHENjasCYN)
									{
										throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
									}
									goto default;
								case 10:
									goto end_IL_0093;
								case 4:
									throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
								case 1:
									if (writeStartIndex < 0)
									{
										throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
									}
									goto case 5;
								case 11:
									throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
								case 8:
									goto IL_0184;
								default:
									NativeTools.CopyMemory(gNjdluGtZYcXOByPMlpGoZVhqyt, buffer, readStartIndex, writeStartIndex, numBytesToRead);
									return;
								}
								break;
								IL_00ab:
								int num4;
								if (readStartIndex >= 0)
								{
									num2 = -439351257;
									num4 = num2;
								}
								else
								{
									num2 = -439351260;
									num4 = num2;
								}
							}
							continue;
							end_IL_0093:
							break;
						}
						break;
					}
					throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
				}
			}
			throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
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
					IL_011a:
					if (numBytesToRead > 0)
					{
						while (true)
						{
							IL_00b8:
							if (numBytesToRead <= bufferLength)
							{
								while (true)
								{
									IL_009b:
									int num;
									int num2;
									if (numBytesToRead <= MiEKlFCVmtuVkzPoSyHENjasCYN)
									{
										num = 719620798;
										num2 = num;
									}
									else
									{
										num = 719620788;
										num2 = num;
									}
									while (true)
									{
										switch (num ^ 0x2AE48AB6)
										{
										case 0:
											num = 719620799;
											continue;
										case 9:
											break;
										case 4:
											if (numBytesToRead + readStartIndex > MiEKlFCVmtuVkzPoSyHENjasCYN)
											{
												throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
											}
											goto default;
										case 6:
											goto IL_009b;
										case 3:
											goto IL_00b8;
										case 2:
											throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
										case 8:
											if (writeStartIndex >= bufferLength)
											{
												throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
											}
											goto case 1;
										case 1:
											if (writeStartIndex < 0)
											{
												throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
											}
											goto case 7;
										case 10:
											goto IL_011a;
										case 7:
											if (readStartIndex >= MiEKlFCVmtuVkzPoSyHENjasCYN)
											{
												throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
											}
											goto case 5;
										case 5:
											if (readStartIndex < 0)
											{
												throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
											}
											goto case 12;
										case 12:
											if (writeStartIndex + numBytesToRead > bufferLength)
											{
												throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
											}
											goto case 4;
										default:
											NativeTools.CopyMemory(gNjdluGtZYcXOByPMlpGoZVhqyt, buffer, readStartIndex, writeStartIndex, numBytesToRead);
											return;
										}
										break;
									}
									break;
								}
								break;
							}
							throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
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
			int num = default(int);
			int num2;
			if (buffer != null)
			{
				if (numBytesToRead <= 0)
				{
					goto IL_000d;
				}
				num = buffer.Length;
				num2 = -1235205252;
				goto IL_0012;
			}
			goto IL_0115;
			IL_0012:
			while (true)
			{
				switch (num2 ^ -1235205258)
				{
				case 0:
					break;
				case 7:
					goto IL_0056;
				case 4:
					return 0;
				case 10:
					goto IL_008c;
				case 11:
					goto IL_00a4;
				case 12:
					numBytesToRead = MiEKlFCVmtuVkzPoSyHENjasCYN - readStartIndex;
					num2 = -1235205263;
					continue;
				case 6:
					readStartIndex = 0;
					num2 = -1235205260;
					continue;
				case 1:
					return 0;
				case 2:
					if (writeStartIndex < 0)
					{
						writeStartIndex = 0;
						num2 = -1235205251;
						continue;
					}
					goto IL_00a4;
				case 3:
					goto IL_0115;
				case 9:
					goto IL_0125;
				case 5:
					numBytesToRead = num - writeStartIndex;
					num2 = -1235205249;
					continue;
				default:
					return 0;
				}
				break;
				IL_0125:
				if (numBytesToRead != 0)
				{
					if (NativeTools.CopyMemory(gNjdluGtZYcXOByPMlpGoZVhqyt, buffer, readStartIndex, writeStartIndex, numBytesToRead, throwOnError: false))
					{
						return numBytesToRead;
					}
					num2 = -1235205250;
				}
				else
				{
					num2 = -1235205257;
				}
				continue;
				IL_0056:
				int num3;
				if (writeStartIndex + numBytesToRead > num)
				{
					num2 = -1235205261;
					num3 = num2;
				}
				else
				{
					num2 = -1235205249;
					num3 = num2;
				}
				continue;
				IL_00a4:
				int num4;
				if (readStartIndex + numBytesToRead <= MiEKlFCVmtuVkzPoSyHENjasCYN)
				{
					num2 = -1235205263;
					num4 = num2;
				}
				else
				{
					num2 = -1235205254;
					num4 = num2;
				}
				continue;
				IL_008c:
				if (num == 0)
				{
					return 0;
				}
				if (readStartIndex < MiEKlFCVmtuVkzPoSyHENjasCYN)
				{
					if (writeStartIndex >= num)
					{
						return 0;
					}
					int num5;
					if (readStartIndex < 0)
					{
						num2 = -1235205264;
						num5 = num2;
					}
					else
					{
						num2 = -1235205260;
						num5 = num2;
					}
				}
				else
				{
					num2 = -1235205262;
				}
			}
			goto IL_000d;
			IL_0115:
			return 0;
			IL_000d:
			num2 = -1235205259;
			goto IL_0012;
		}

		public int TryReadBytes(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			int num;
			if (!(buffer == IntPtr.Zero))
			{
				if (numBytesToRead <= 0)
				{
					goto IL_0017;
				}
				if (readStartIndex < MiEKlFCVmtuVkzPoSyHENjasCYN)
				{
					if (writeStartIndex >= bufferLength)
					{
						return 0;
					}
					if (readStartIndex >= 0)
					{
						goto IL_00c5;
					}
					readStartIndex = 0;
					num = -149574768;
				}
				else
				{
					num = -149574759;
				}
				goto IL_001c;
			}
			goto IL_00fc;
			IL_00fc:
			return 0;
			IL_001c:
			while (true)
			{
				switch (num ^ -149574759)
				{
				case 2:
					break;
				case 4:
					if (writeStartIndex + numBytesToRead > bufferLength)
					{
						numBytesToRead = bufferLength - writeStartIndex;
						num = -149574767;
						continue;
					}
					goto IL_00de;
				case 7:
					goto IL_006b;
				case 0:
					return 0;
				case 6:
					writeStartIndex = 0;
					num = -149574754;
					continue;
				case 3:
					numBytesToRead = MiEKlFCVmtuVkzPoSyHENjasCYN - readStartIndex;
					num = -149574755;
					continue;
				case 9:
					goto IL_00c5;
				case 8:
					goto IL_00de;
				case 5:
					goto IL_00fc;
				default:
					return 0;
				}
				break;
				IL_006b:
				int num2;
				if (readStartIndex + numBytesToRead > MiEKlFCVmtuVkzPoSyHENjasCYN)
				{
					num = -149574758;
					num2 = num;
				}
				else
				{
					num = -149574755;
					num2 = num;
				}
				continue;
				IL_00de:
				if (!NativeTools.CopyMemory(gNjdluGtZYcXOByPMlpGoZVhqyt, buffer, readStartIndex, writeStartIndex, numBytesToRead, throwOnError: false))
				{
					num = -149574760;
					continue;
				}
				return numBytesToRead;
			}
			goto IL_0017;
			IL_0017:
			num = -149574756;
			goto IL_001c;
			IL_00c5:
			int num3;
			if (writeStartIndex >= 0)
			{
				num = -149574754;
				num3 = num;
			}
			else
			{
				num = -149574753;
				num3 = num;
			}
			goto IL_001c;
		}

		public void WriteBit(int byteIndex, byte bit, bool value)
		{
			if (1 + byteIndex <= Length)
			{
				if (byteIndex >= 0)
				{
					goto IL_0047;
				}
				while (true)
				{
					switch (-667303518 ^ -667303514)
					{
					case 3:
						break;
					case 4:
						goto end_IL_000f;
					case 2:
						goto IL_0047;
					case 0:
						goto IL_005d;
					default:
						goto IL_0089;
					}
					continue;
					end_IL_000f:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("byteIndex");
			IL_0089:
			Marshal.WriteByte(gNjdluGtZYcXOByPMlpGoZVhqyt, byteIndex, (byte)(Marshal.ReadByte(gNjdluGtZYcXOByPMlpGoZVhqyt, byteIndex) & (byte)(~(1 << (int)bit))));
			return;
			IL_005d:
			if (value)
			{
				Marshal.WriteByte(gNjdluGtZYcXOByPMlpGoZVhqyt, byteIndex, (byte)(Marshal.ReadByte(gNjdluGtZYcXOByPMlpGoZVhqyt, byteIndex) | (byte)(1 << (int)bit)));
				return;
			}
			goto IL_0089;
			IL_0047:
			if (bit >= 8)
			{
				throw new ArgumentOutOfRangeException("bit");
			}
			goto IL_005d;
		}

		public void Write(byte @byte, int startIndex)
		{
			if (1 + startIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
			{
				while (true)
				{
					int num = 1376711445;
					while (true)
					{
						switch (num ^ 0x520EF314)
						{
						case 2:
							break;
						case 1:
							goto IL_002d;
						case 0:
							goto end_IL_000b;
						default:
							Marshal.WriteByte(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex, @byte);
							return;
						}
						break;
						IL_002d:
						int num2;
						if (startIndex >= 0)
						{
							num = 1376711447;
							num2 = num;
						}
						else
						{
							num = 1376711444;
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
			if (2 + startIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
			{
				while (true)
				{
					int num = 1558611752;
					while (true)
					{
						switch (num ^ 0x5CE68729)
						{
						case 2:
							break;
						case 1:
							goto IL_002d;
						case 3:
							goto end_IL_000b;
						default:
							Marshal.WriteInt16(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex, bytes);
							return;
						}
						break;
						IL_002d:
						int num2;
						if (startIndex < 0)
						{
							num = 1558611754;
							num2 = num;
						}
						else
						{
							num = 1558611753;
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
			if (2 + startIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
			{
				while (true)
				{
					int num = 1497958428;
					while (true)
					{
						switch (num ^ 0x5949081F)
						{
						case 0:
							break;
						case 3:
							goto IL_002d;
						case 2:
							goto end_IL_000b;
						default:
							Marshal.WriteInt16(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex, (short)bytes);
							return;
						}
						break;
						IL_002d:
						int num2;
						if (startIndex < 0)
						{
							num = 1497958429;
							num2 = num;
						}
						else
						{
							num = 1497958430;
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
			if (4 + startIndex > MiEKlFCVmtuVkzPoSyHENjasCYN)
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
			int num = 1712938484;
			goto IL_0014;
			IL_0014:
			switch (num ^ 0x66195DF5)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				goto IL_0031;
			case 0:
				goto IL_0043;
			case 2:
				return;
			}
			goto IL_000f;
			IL_0043:
			Marshal.WriteInt32(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex, bytes);
			num = 1712938487;
			goto IL_0014;
		}

		public void Write(uint bytes, int startIndex)
		{
			if (4 + startIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
			{
				while (true)
				{
					int num = 1060087839;
					while (true)
					{
						switch (num ^ 0x3F2FA81D)
						{
						case 0:
							break;
						case 2:
							goto IL_002d;
						case 1:
							goto end_IL_000b;
						default:
							Marshal.WriteInt32(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex, (int)bytes);
							return;
						}
						break;
						IL_002d:
						int num2;
						if (startIndex >= 0)
						{
							num = 1060087838;
							num2 = num;
						}
						else
						{
							num = 1060087836;
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

		public void Write(long bytes, int startIndex)
		{
			if (8 + startIndex > MiEKlFCVmtuVkzPoSyHENjasCYN)
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
			int num = 1678930339;
			goto IL_0014;
			IL_0014:
			switch (num ^ 0x641271A0)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				goto IL_0031;
			case 1:
				goto IL_0043;
			case 2:
				return;
			}
			goto IL_000f;
			IL_0043:
			Marshal.WriteInt64(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex, bytes);
			num = 1678930338;
			goto IL_0014;
		}

		public void Write(ulong bytes, int startIndex)
		{
			if (8 + startIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
			{
				while (true)
				{
					int num = 1767439318;
					while (true)
					{
						switch (num ^ 0x6958FBD7)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_0031;
						case 4:
							Marshal.WriteInt64(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex, (long)bytes);
							num = 1767439316;
							continue;
						case 0:
							goto end_IL_000b;
						case 3:
							return;
						}
						break;
						IL_0031:
						int num2;
						if (startIndex < 0)
						{
							num = 1767439319;
							num2 = num;
						}
						else
						{
							num = 1767439315;
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

		public void Write(float bytes, int startIndex)
		{
			if (4 + startIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
			{
				while (true)
				{
					int num = -484307639;
					while (true)
					{
						switch (num ^ -484307640)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_0031;
						case 4:
							Marshal.WriteInt32(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex, new deFkfjHJIndjmwybARqvXpzyvbn(bytes).OIPYdeiAtjrgmUOEAKGdQjUXXZz);
							num = -484307640;
							continue;
						case 3:
							goto end_IL_000b;
						case 0:
							return;
						}
						break;
						IL_0031:
						int num2;
						if (startIndex >= 0)
						{
							num = -484307636;
							num2 = num;
						}
						else
						{
							num = -484307637;
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

		public void Write(double bytes, int startIndex)
		{
			if (8 + startIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x3098F283 ^ 0x3098F281)
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
			Marshal.WriteInt64(gNjdluGtZYcXOByPMlpGoZVhqyt, startIndex, new uNdRRhMGtXyZOXbPnexvfpFKZJDn(bytes).cCsxCABHQVoqpNKCtTBYcfylgG);
		}

		public void Write(byte[] bytes, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == null)
			{
				goto IL_0006;
			}
			goto IL_012c;
			IL_0006:
			int num = -642734777;
			goto IL_000b;
			IL_000b:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -642734769)
				{
				case 0:
					break;
				case 10:
					throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
				case 1:
					if (readStartIndex + numBytesToWrite > num2)
					{
						throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
					}
					goto IL_0095;
				case 4:
					goto IL_0095;
				case 11:
					if (numBytesToWrite > MiEKlFCVmtuVkzPoSyHENjasCYN)
					{
						throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
					}
					goto IL_0169;
				case 7:
					goto IL_00d5;
				case 14:
					throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
				case 17:
					throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
				case 6:
					throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
				case 3:
					goto IL_012c;
				case 8:
					throw new ArgumentNullException("bytes");
				case 15:
					if (readStartIndex < 0)
					{
						throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
					}
					goto IL_0182;
				case 13:
					goto IL_0169;
				case 2:
					goto IL_0182;
				case 9:
					throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
				case 12:
					if (numBytesToWrite > num2)
					{
						throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
					}
					goto case 11;
				case 16:
					goto IL_01d0;
				case 5:
					if (numBytesToWrite <= 0)
					{
						throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
					}
					goto case 12;
				default:
					NativeTools.CopyMemory(bytes, gNjdluGtZYcXOByPMlpGoZVhqyt, readStartIndex, writeStartIndex, numBytesToWrite);
					return;
				}
				break;
				IL_01d0:
				int num3;
				if (writeStartIndex < 0)
				{
					num = -642734754;
					num3 = num;
				}
				else
				{
					num = -642734770;
					num3 = num;
				}
				continue;
				IL_0095:
				int num4;
				if (numBytesToWrite + writeStartIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
				{
					num = -642734755;
					num4 = num;
				}
				else
				{
					num = -642734779;
					num4 = num;
				}
				continue;
				IL_00d5:
				int num5;
				if (num2 > 0)
				{
					num = -642734774;
					num5 = num;
				}
				else
				{
					num = -642734778;
					num5 = num;
				}
				continue;
				IL_0182:
				int num6;
				if (writeStartIndex < MiEKlFCVmtuVkzPoSyHENjasCYN)
				{
					num = -642734753;
					num6 = num;
				}
				else
				{
					num = -642734775;
					num6 = num;
				}
				continue;
				IL_0169:
				int num7;
				if (readStartIndex >= num2)
				{
					num = -642734783;
					num7 = num;
				}
				else
				{
					num = -642734784;
					num7 = num;
				}
			}
			goto IL_0006;
			IL_012c:
			num2 = bytes.Length;
			num = -642734776;
			goto IL_000b;
		}

		public void Write(IntPtr bytes, int bufferLength, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == IntPtr.Zero)
			{
				throw new ArgumentNullException("bytes");
			}
			while (bufferLength > 0)
			{
				while (true)
				{
					IL_01f6:
					if (numBytesToWrite > 0)
					{
						while (true)
						{
							IL_013e:
							int num;
							int num2;
							if (numBytesToWrite > bufferLength)
							{
								num = 1676424123;
								num2 = num;
							}
							else
							{
								num = 1676424124;
								num2 = num;
							}
							while (true)
							{
								switch (num ^ 0x63EC33B5)
								{
								case 15:
									num = 1676424116;
									continue;
								default:
									return;
								case 4:
									break;
								case 17:
									goto IL_008e;
								case 12:
									throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
								case 1:
									goto end_IL_0020;
								case 13:
									throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
								case 2:
									if (readStartIndex >= bufferLength)
									{
										throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
									}
									goto case 6;
								case 14:
									throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
								case 3:
									NativeTools.CopyMemory(bytes, gNjdluGtZYcXOByPMlpGoZVhqyt, readStartIndex, writeStartIndex, numBytesToWrite);
									num = 1676424126;
									continue;
								case 16:
									goto IL_013e;
								case 6:
									if (readStartIndex < 0)
									{
										throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
									}
									goto IL_008e;
								case 0:
									if (readStartIndex + numBytesToWrite > bufferLength)
									{
										throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
									}
									goto IL_01a4;
								case 5:
									throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
								case 7:
									goto IL_01a4;
								case 9:
									goto IL_01c4;
								case 8:
									throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
								case 10:
									goto IL_01f6;
								case 11:
									return;
								}
								int num3;
								if (writeStartIndex >= 0)
								{
									num = 1676424117;
									num3 = num;
								}
								else
								{
									num = 1676424125;
									num3 = num;
								}
								continue;
								IL_01c4:
								int num4;
								if (numBytesToWrite > MiEKlFCVmtuVkzPoSyHENjasCYN)
								{
									num = 1676424120;
									num4 = num;
								}
								else
								{
									num = 1676424119;
									num4 = num;
								}
								continue;
								IL_008e:
								int num5;
								if (writeStartIndex >= MiEKlFCVmtuVkzPoSyHENjasCYN)
								{
									num = 1676424121;
									num5 = num;
								}
								else
								{
									num = 1676424113;
									num5 = num;
								}
								continue;
								IL_01a4:
								int num6;
								if (numBytesToWrite + writeStartIndex <= MiEKlFCVmtuVkzPoSyHENjasCYN)
								{
									num = 1676424118;
									num6 = num;
								}
								else
								{
									num = 1676424112;
									num6 = num;
								}
								continue;
								end_IL_0020:
								break;
							}
							break;
						}
						break;
					}
					throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
				}
			}
			throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
		}

		public int TryWriteBytes(byte[] bytes, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (bytes == null)
			{
				goto IL_0006;
			}
			int num = bytes.Length;
			int num2;
			int num3;
			if (num == 0)
			{
				num2 = 485960325;
				num3 = num2;
			}
			else
			{
				num2 = 485960321;
				num3 = num2;
			}
			goto IL_000b;
			IL_0006:
			num2 = 485960324;
			goto IL_000b;
			IL_000b:
			while (true)
			{
				switch (num2 ^ 0x1CF72A81)
				{
				case 6:
					break;
				case 1:
					if (readStartIndex + numBytesToWrite > num)
					{
						numBytesToWrite = num - readStartIndex;
						num2 = 485960326;
						continue;
					}
					goto case 7;
				case 0:
					if (numBytesToWrite <= 0 || readStartIndex >= num)
					{
						goto case 4;
					}
					if (writeStartIndex >= MiEKlFCVmtuVkzPoSyHENjasCYN)
					{
						num2 = 485960325;
						continue;
					}
					if (readStartIndex < 0)
					{
						readStartIndex = 0;
						num2 = 485960323;
						continue;
					}
					goto case 2;
				case 4:
					return 0;
				case 7:
					if (numBytesToWrite + writeStartIndex > MiEKlFCVmtuVkzPoSyHENjasCYN)
					{
						numBytesToWrite = MiEKlFCVmtuVkzPoSyHENjasCYN - writeStartIndex;
						num2 = 485960322;
						continue;
					}
					goto default;
				case 5:
					return 0;
				case 2:
					if (writeStartIndex < 0)
					{
						writeStartIndex = 0;
						num2 = 485960320;
						continue;
					}
					goto case 1;
				default:
					if (!NativeTools.CopyMemory(bytes, gNjdluGtZYcXOByPMlpGoZVhqyt, readStartIndex, writeStartIndex, numBytesToWrite, throwOnError: false))
					{
						return 0;
					}
					return numBytesToWrite;
				}
				break;
			}
			goto IL_0006;
		}

		public int TryWriteBytes(IntPtr bytes, int bufferLength, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (!(bytes == IntPtr.Zero))
			{
				while (true)
				{
					int num = 1747860908;
					while (true)
					{
						switch (num ^ 0x682E3DAD)
						{
						case 9:
							break;
						case 5:
							goto end_IL_000d;
						case 8:
							goto IL_005b;
						case 4:
							goto IL_0070;
						case 1:
							goto IL_0086;
						case 2:
							goto IL_009e;
						case 0:
							if (readStartIndex + numBytesToWrite > bufferLength)
							{
								numBytesToWrite = bufferLength - readStartIndex;
								num = 1747860910;
								continue;
							}
							goto case 3;
						case 3:
							if (numBytesToWrite + writeStartIndex > MiEKlFCVmtuVkzPoSyHENjasCYN)
							{
								numBytesToWrite = MiEKlFCVmtuVkzPoSyHENjasCYN - writeStartIndex;
								num = 1747860906;
								continue;
							}
							goto IL_00fc;
						case 6:
							writeStartIndex = 0;
							num = 1747860909;
							continue;
						default:
							goto IL_00fc;
						}
						break;
						IL_0086:
						int num2;
						if (bufferLength <= 0)
						{
							num = 1747860904;
							num2 = num;
						}
						else
						{
							num = 1747860901;
							num2 = num;
						}
						continue;
						IL_009e:
						int num3;
						if (writeStartIndex >= 0)
						{
							num = 1747860909;
							num3 = num;
						}
						else
						{
							num = 1747860907;
							num3 = num;
						}
						continue;
						IL_005b:
						int num4;
						if (numBytesToWrite > 0)
						{
							num = 1747860905;
							num4 = num;
						}
						else
						{
							num = 1747860904;
							num4 = num;
						}
						continue;
						IL_0070:
						if (readStartIndex >= bufferLength)
						{
							goto end_IL_000d;
						}
						if (writeStartIndex < MiEKlFCVmtuVkzPoSyHENjasCYN)
						{
							if (readStartIndex < 0)
							{
								readStartIndex = 0;
								num = 1747860911;
								continue;
							}
							goto IL_009e;
						}
						num = 1747860904;
					}
					continue;
					IL_00fc:
					if (!NativeTools.CopyMemory(bytes, gNjdluGtZYcXOByPMlpGoZVhqyt, readStartIndex, writeStartIndex, numBytesToWrite, throwOnError: false))
					{
						return 0;
					}
					return numBytesToWrite;
					continue;
					end_IL_000d:
					break;
				}
			}
			return 0;
		}

		public int TryFill(byte value, int numBytesToWrite, int writeStartIndex = 0)
		{
			if (numBytesToWrite > 0)
			{
				while (true)
				{
					int num = 579724436;
					while (true)
					{
						switch (num ^ 0x228DE492)
						{
						case 5:
							break;
						case 0:
							numBytesToWrite = MiEKlFCVmtuVkzPoSyHENjasCYN - writeStartIndex;
							num = 579724432;
							continue;
						case 3:
							goto end_IL_0004;
						case 4:
							goto IL_0053;
						case 2:
							goto IL_006f;
						case 6:
							goto IL_0087;
						default:
							return 0;
						}
						break;
						IL_0087:
						if (writeStartIndex < MiEKlFCVmtuVkzPoSyHENjasCYN)
						{
							if (writeStartIndex < 0)
							{
								writeStartIndex = 0;
								num = 579724438;
								continue;
							}
							goto IL_0053;
						}
						num = 579724433;
						continue;
						IL_0053:
						int num2;
						if (numBytesToWrite + writeStartIndex > MiEKlFCVmtuVkzPoSyHENjasCYN)
						{
							num = 579724434;
							num2 = num;
						}
						else
						{
							num = 579724432;
							num2 = num;
						}
						continue;
						IL_006f:
						if (!NativeTools.FillMemory(gNjdluGtZYcXOByPMlpGoZVhqyt, writeStartIndex, numBytesToWrite, value, throwOnError: false))
						{
							num = 579724435;
							continue;
						}
						return numBytesToWrite;
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			return 0;
		}

		public bool Resize(int size, bool preserveData)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException("size");
			}
			if (MiEKlFCVmtuVkzPoSyHENjasCYN == size)
			{
				return true;
			}
			if (size == 0)
			{
				Release();
				return true;
			}
			IntPtr intPtr;
			bool result;
			int num;
			if (preserveData)
			{
				try
				{
					intPtr = Marshal.AllocHGlobal(size);
					if (intPtr == IntPtr.Zero)
					{
						result = false;
						goto IL_0130;
					}
				}
				catch
				{
					result = false;
					goto IL_0130;
				}
				int bytesToCopy = MathTools.Min(size, MiEKlFCVmtuVkzPoSyHENjasCYN);
				if (!NativeTools.CopyMemory(gNjdluGtZYcXOByPMlpGoZVhqyt, intPtr, 0, 0, bytesToCopy, throwOnError: false))
				{
					goto IL_006f;
				}
				if (size > MiEKlFCVmtuVkzPoSyHENjasCYN)
				{
					NativeTools.FillMemory(intPtr, MiEKlFCVmtuVkzPoSyHENjasCYN, size - MiEKlFCVmtuVkzPoSyHENjasCYN, 0, throwOnError: false);
					num = 551026362;
					goto IL_0074;
				}
				goto IL_00c0;
			}
			goto IL_00cf;
			IL_006f:
			num = 551026361;
			goto IL_0074;
			IL_00c0:
			Release();
			goto IL_0120;
			IL_00cf:
			Release();
			try
			{
				intPtr = Marshal.AllocHGlobal(size);
				if (intPtr == IntPtr.Zero)
				{
					result = false;
					while (true)
					{
						switch (0x20D7FEBB ^ 0x20D7FEBA)
						{
						case 2:
							break;
						default:
							goto end_IL_00eb;
						case 0:
							goto end_IL_00eb;
						case 1:
							goto IL_0130;
						}
						continue;
						end_IL_00eb:
						break;
					}
				}
			}
			catch
			{
				result = false;
				goto IL_0130;
			}
			NativeTools.ZeroFillMemory(intPtr, size);
			goto IL_0120;
			IL_0074:
			switch (num ^ 0x20D7FEBA)
			{
			case 2:
				break;
			case 3:
				Marshal.FreeHGlobal(intPtr);
				return false;
			case 0:
				goto IL_00c0;
			default:
				goto IL_00cf;
			}
			goto IL_006f;
			IL_0120:
			gNjdluGtZYcXOByPMlpGoZVhqyt = intPtr;
			MiEKlFCVmtuVkzPoSyHENjasCYN = size;
			return true;
			IL_0130:
			return result;
		}

		public void Clear()
		{
			if (MiEKlFCVmtuVkzPoSyHENjasCYN == 0)
			{
				return;
			}
			while (true)
			{
				NativeTools.ZeroFillMemory(gNjdluGtZYcXOByPMlpGoZVhqyt, MiEKlFCVmtuVkzPoSyHENjasCYN);
				int num = 1901997217;
				while (true)
				{
					switch (num ^ 0x715E2CA1)
					{
					case 2:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0009:
					num = 1901997216;
				}
			}
		}

		public void Release()
		{
			if (gNjdluGtZYcXOByPMlpGoZVhqyt != IntPtr.Zero)
			{
				goto IL_0012;
			}
			goto IL_0051;
			IL_0012:
			int num = 1494219526;
			goto IL_0017;
			IL_0017:
			while (true)
			{
				switch (num ^ 0x590FFB04)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					Marshal.FreeHGlobal(Pointer);
					gNjdluGtZYcXOByPMlpGoZVhqyt = IntPtr.Zero;
					num = 1494219525;
					continue;
				case 1:
					goto IL_0051;
				case 3:
					return;
				}
				break;
			}
			goto IL_0012;
			IL_0051:
			MiEKlFCVmtuVkzPoSyHENjasCYN = 0;
			num = 1494219527;
			goto IL_0017;
		}

		public void CopyFrom(NativeBuffer other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			while (!(gNjdluGtZYcXOByPMlpGoZVhqyt == IntPtr.Zero))
			{
				while (true)
				{
					IL_0067:
					if (other.Pointer == IntPtr.Zero)
					{
						return;
					}
					while (true)
					{
						IL_004e:
						int bytesToCopy = MathTools.Min(MiEKlFCVmtuVkzPoSyHENjasCYN, other.MiEKlFCVmtuVkzPoSyHENjasCYN);
						int num = 3907892;
						while (true)
						{
							switch (num ^ 0x3BA137)
							{
							case 4:
								num = 3907894;
								continue;
							case 1:
								break;
							case 2:
								goto IL_004e;
							case 0:
								goto IL_0067;
							default:
								NativeTools.CopyMemory(other.gNjdluGtZYcXOByPMlpGoZVhqyt, gNjdluGtZYcXOByPMlpGoZVhqyt, 0, 0, bytesToCopy);
								return;
							}
							break;
						}
						break;
					}
					break;
				}
			}
		}

		public override string ToString()
		{
			return "Length = " + MiEKlFCVmtuVkzPoSyHENjasCYN + "\nPointer = " + gNjdluGtZYcXOByPMlpGoZVhqyt + "\n";
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
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				return;
			}
			while (true)
			{
				int num = -1115939461;
				while (true)
				{
					switch (num ^ -1115939463)
					{
					case 0:
						goto IL_0009;
					case 1:
						break;
					default:
						Release();
						xRygqjRmTtURDPiwlgMmFcdNBrr = true;
						return;
					}
					break;
					IL_0009:
					num = -1115939464;
				}
			}
		}

		public static implicit operator IntPtr(NativeBuffer buffer)
		{
			return buffer?.gNjdluGtZYcXOByPMlpGoZVhqyt ?? IntPtr.Zero;
		}

		public static bool Copy(NativeBuffer source, NativeBuffer destination)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			while (destination != null)
			{
				while (true)
				{
					IL_0045:
					if (source.MiEKlFCVmtuVkzPoSyHENjasCYN == 0)
					{
						int num = -865552992;
						while (true)
						{
							switch (num ^ -865552991)
							{
							case 2:
								num = -865552990;
								continue;
							case 3:
								break;
							case 0:
								goto IL_0045;
							default:
								destination.Release();
								return true;
							}
							break;
						}
						break;
					}
					if (destination.Resize(source.MiEKlFCVmtuVkzPoSyHENjasCYN, preserveData: false))
					{
						return NativeTools.CopyMemory(source.gNjdluGtZYcXOByPMlpGoZVhqyt, destination.gNjdluGtZYcXOByPMlpGoZVhqyt, 0, 0, source.MiEKlFCVmtuVkzPoSyHENjasCYN, throwOnError: false);
					}
					return false;
				}
			}
			throw new ArgumentNullException("destination");
		}
	}
}
