using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeBuffer : IDisposable
	{
		private IntPtr izvhHmSvmUBneSslrLADBhxqUkP;

		private int MwElyJEsJpEEOifMfHHXevYlDKfg;

		private bool vsurYtRlepcrpAzAENwjqjJEZPT;

		public IntPtr Pointer
		{
			get
			{
				return izvhHmSvmUBneSslrLADBhxqUkP;
			}
		}

		public int Length
		{
			get
			{
				return MwElyJEsJpEEOifMfHHXevYlDKfg;
			}
		}

		public byte this[int index]
		{
			get
			{
				if (index >= 0)
				{
					while (true)
					{
						int num = 942351805;
						while (true)
						{
							switch (num ^ 0x382B25BF)
							{
							case 3:
								break;
							case 2:
								goto IL_0026;
							case 1:
								goto end_IL_0004;
							default:
								return Marshal.ReadByte(izvhHmSvmUBneSslrLADBhxqUkP, index);
							}
							break;
							IL_0026:
							int num2;
							if (index >= MwElyJEsJpEEOifMfHHXevYlDKfg)
							{
								num = 942351806;
								num2 = num;
							}
							else
							{
								num = 942351807;
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
					if (index < MwElyJEsJpEEOifMfHHXevYlDKfg)
					{
						goto IL_0038;
					}
					while (true)
					{
						switch (0x225B2567 ^ 0x225B2565)
						{
						case 0:
							break;
						case 2:
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
				Marshal.WriteByte(izvhHmSvmUBneSslrLADBhxqUkP, index, value);
			}
		}

		public NativeBuffer(int size)
		{
			while (true)
			{
				int num = 387446524;
				while (true)
				{
					switch (num ^ 0x1717F6FD)
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
					num = 387446527;
				}
			}
		}

		public IntPtr GetPointer(int offset = 0)
		{
			if (izvhHmSvmUBneSslrLADBhxqUkP == IntPtr.Zero)
			{
				goto IL_0012;
			}
			int num;
			if (offset == 0)
			{
				num = 247644987;
			}
			else
			{
				if (offset < 0)
				{
					goto IL_0048;
				}
				int num2;
				if (offset < MwElyJEsJpEEOifMfHHXevYlDKfg)
				{
					num = 247644985;
					num2 = num;
				}
				else
				{
					num = 247644990;
					num2 = num;
				}
			}
			goto IL_0017;
			IL_0048:
			throw new ArgumentOutOfRangeException("offset");
			IL_0017:
			switch (num ^ 0xEC2C33A)
			{
			case 0:
				break;
			case 2:
				return IntPtr.Zero;
			case 4:
				goto IL_0048;
			case 1:
				return izvhHmSvmUBneSslrLADBhxqUkP;
			default:
				return NativeTools.OffsetIntPtr(izvhHmSvmUBneSslrLADBhxqUkP, offset);
			}
			goto IL_0012;
			IL_0012:
			num = 247644984;
			goto IL_0017;
		}

		public string DumpToHexString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			while (true)
			{
				int num2 = 1376579468;
				while (true)
				{
					switch (num2 ^ 0x520CEF88)
					{
					case 0:
						break;
					case 2:
						num++;
						num2 = 1376579465;
						continue;
					case 3:
						stringBuilder.Append(ReadByte(num).ToString("x2"));
						stringBuilder.Append(" ");
						num2 = 1376579466;
						continue;
					case 4:
						num2 = 1376579465;
						continue;
					default:
						if (num >= MwElyJEsJpEEOifMfHHXevYlDKfg)
						{
							return stringBuilder.ToString();
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public bool ReadBit(int byteIndex, byte bit)
		{
			if (1 + byteIndex <= Length)
			{
				if (byteIndex >= 0)
				{
					goto IL_0043;
				}
				while (true)
				{
					switch (0xF25E4A1 ^ 0xF25E4A0)
					{
					case 2:
						break;
					case 1:
						goto end_IL_000f;
					case 0:
						goto IL_0043;
					default:
						goto IL_0059;
					}
					continue;
					end_IL_000f:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("byteIndex");
			IL_0059:
			return (Marshal.ReadByte(izvhHmSvmUBneSslrLADBhxqUkP, byteIndex) & (1 << (int)bit)) != 0;
			IL_0043:
			if (bit >= 8)
			{
				throw new ArgumentOutOfRangeException("bit");
			}
			goto IL_0059;
		}

		public byte ReadByte(int startIndex)
		{
			if (1 + startIndex <= MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x646BC9D ^ 0x646BC9C)
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
			return Marshal.ReadByte(izvhHmSvmUBneSslrLADBhxqUkP, startIndex);
		}

		public short ReadShort(int startIndex)
		{
			if (2 + startIndex <= MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				while (true)
				{
					int num = -1845081333;
					while (true)
					{
						switch (num ^ -1845081335)
						{
						case 0:
							break;
						case 2:
							goto IL_002d;
						case 3:
							goto end_IL_000b;
						default:
							return Marshal.ReadInt16(izvhHmSvmUBneSslrLADBhxqUkP, startIndex);
						}
						break;
						IL_002d:
						int num2;
						if (startIndex >= 0)
						{
							num = -1845081336;
							num2 = num;
						}
						else
						{
							num = -1845081334;
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
			if (2 + startIndex <= MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (-2140959083 ^ -2140959084)
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
			return (ushort)Marshal.ReadInt16(izvhHmSvmUBneSslrLADBhxqUkP, startIndex);
		}

		public int ReadInt(int startIndex)
		{
			if (4 + startIndex <= MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x2A4A2CE0 ^ 0x2A4A2CE1)
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
			return Marshal.ReadInt32(izvhHmSvmUBneSslrLADBhxqUkP, startIndex);
		}

		public uint ReadUInt(int startIndex)
		{
			if (4 + startIndex <= MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x741295A1 ^ 0x741295A0)
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
			return (uint)Marshal.ReadInt32(izvhHmSvmUBneSslrLADBhxqUkP, startIndex);
		}

		public long ReadLong(int startIndex)
		{
			if (8 + startIndex <= MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x7E4D7FB0 ^ 0x7E4D7FB2)
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
			return Marshal.ReadInt64(izvhHmSvmUBneSslrLADBhxqUkP, startIndex);
		}

		public ulong ReadULong(int startIndex)
		{
			if (8 + startIndex <= MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				while (true)
				{
					int num = -249018073;
					while (true)
					{
						switch (num ^ -249018075)
						{
						case 3:
							break;
						case 2:
							goto IL_002d;
						case 1:
							goto end_IL_000b;
						default:
							return (ulong)Marshal.ReadInt64(izvhHmSvmUBneSslrLADBhxqUkP, startIndex);
						}
						break;
						IL_002d:
						int num2;
						if (startIndex >= 0)
						{
							num = -249018075;
							num2 = num;
						}
						else
						{
							num = -249018076;
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

		public float ReadFloat(int startIndex)
		{
			if (4 + startIndex <= MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (-360152166 ^ -360152165)
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
			return new DrCVuAQjyJxGvtUHjcNKVFTnwWi(Marshal.ReadInt32(izvhHmSvmUBneSslrLADBhxqUkP, startIndex)).ZaSHqGaegeESZbFeVfARQhwYXVKp;
		}

		public double ReadDouble(int startIndex)
		{
			if (8 + startIndex <= MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x675ACB9A ^ 0x675ACB9B)
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
			return new swhxTzSuEFvsmSdxWAEgUEbTFkh(Marshal.ReadInt64(izvhHmSvmUBneSslrLADBhxqUkP, startIndex)).ENlkzzJDAXKhKfEnmxnBfZjEJCp;
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
				int num2 = -1659787590;
				while (true)
				{
					switch (num2 ^ -1659787598)
					{
					case 2:
						goto IL_0011;
					case 5:
						if (numBytesToRead + readStartIndex > MwElyJEsJpEEOifMfHHXevYlDKfg)
						{
							throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
						}
						goto default;
					case 11:
						if (numBytesToRead > num)
						{
							throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
						}
						goto case 4;
					case 3:
						if (writeStartIndex >= num)
						{
							throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
						}
						goto case 12;
					case 12:
						if (writeStartIndex < 0)
						{
							throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
						}
						goto case 0;
					case 8:
						if (num <= 0)
						{
							throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
						}
						goto case 6;
					case 7:
						break;
					case 0:
						if (readStartIndex >= MwElyJEsJpEEOifMfHHXevYlDKfg)
						{
							throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
						}
						goto case 10;
					case 1:
						if (writeStartIndex + numBytesToRead > num)
						{
							throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
						}
						goto case 5;
					case 4:
						if (numBytesToRead > MwElyJEsJpEEOifMfHHXevYlDKfg)
						{
							throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
						}
						goto case 3;
					case 10:
						if (readStartIndex < 0)
						{
							throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
						}
						goto case 1;
					case 6:
						if (numBytesToRead <= 0)
						{
							throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
						}
						goto case 11;
					default:
						NativeTools.CopyMemory(izvhHmSvmUBneSslrLADBhxqUkP, buffer, readStartIndex, writeStartIndex, numBytesToRead);
						return;
					}
					break;
					IL_0011:
					num2 = -1659787595;
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
					if (numBytesToRead > 0)
					{
						while (true)
						{
							if (numBytesToRead > bufferLength)
							{
								throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
							}
							while (true)
							{
								IL_0181:
								if (numBytesToRead <= MwElyJEsJpEEOifMfHHXevYlDKfg)
								{
									while (true)
									{
										if (writeStartIndex < bufferLength)
										{
											while (true)
											{
												int num;
												int num2;
												if (writeStartIndex >= 0)
												{
													num = -1856248893;
													num2 = num;
												}
												else
												{
													num = -1856248896;
													num2 = num;
												}
												while (true)
												{
													switch (num ^ -1856248892)
													{
													case 6:
														num = -1856248884;
														continue;
													case 4:
														throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
													case 9:
														break;
													case 13:
														if (readStartIndex < 0)
														{
															throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
														}
														break;
													case 0:
														throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
													case 11:
														goto end_IL_0020;
													case 5:
														if (numBytesToRead + readStartIndex > MwElyJEsJpEEOifMfHHXevYlDKfg)
														{
															throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
														}
														goto default;
													case 3:
														goto end_IL_00c5;
													case 1:
														goto end_IL_0102;
													case 7:
														goto IL_0135;
													case 10:
														throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
													case 14:
														goto end_IL_011c;
													case 2:
														goto IL_0181;
													case 8:
														goto end_IL_0168;
													default:
														NativeTools.CopyMemory(izvhHmSvmUBneSslrLADBhxqUkP, buffer, readStartIndex, writeStartIndex, numBytesToRead);
														return;
													}
													int num3;
													if (writeStartIndex + numBytesToRead > bufferLength)
													{
														num = -1856248882;
														num3 = num;
													}
													else
													{
														num = -1856248895;
														num3 = num;
													}
													continue;
													IL_0135:
													int num4;
													if (readStartIndex < MwElyJEsJpEEOifMfHHXevYlDKfg)
													{
														num = -1856248887;
														num4 = num;
													}
													else
													{
														num = -1856248892;
														num4 = num;
													}
													continue;
													end_IL_0020:
													break;
												}
												continue;
												end_IL_00c5:
												break;
											}
											continue;
										}
										throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
										continue;
										end_IL_0102:
										break;
									}
									break;
								}
								throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
							}
							continue;
							end_IL_011c:
							break;
						}
						continue;
					}
					throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
					continue;
					end_IL_0168:
					break;
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
					goto IL_0007;
				}
				num = buffer.Length;
				if (num == 0)
				{
					return 0;
				}
				if (readStartIndex >= MwElyJEsJpEEOifMfHHXevYlDKfg)
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
					num2 = 650546828;
					goto IL_000c;
				}
				goto IL_0054;
			}
			goto IL_0063;
			IL_00d4:
			if (numBytesToRead == 0)
			{
				return 0;
			}
			if (!NativeTools.CopyMemory(izvhHmSvmUBneSslrLADBhxqUkP, buffer, readStartIndex, writeStartIndex, numBytesToRead, false))
			{
				return 0;
			}
			return numBytesToRead;
			IL_000c:
			while (true)
			{
				switch (num2 ^ 0x26C68E8E)
				{
				case 4:
					break;
				case 7:
					goto IL_003c;
				case 2:
					goto IL_0054;
				case 6:
					goto IL_0063;
				case 5:
					goto IL_0091;
				case 1:
					numBytesToRead = num - writeStartIndex;
					num2 = 650546829;
					continue;
				case 0:
					numBytesToRead = MwElyJEsJpEEOifMfHHXevYlDKfg - readStartIndex;
					num2 = 650546825;
					continue;
				default:
					goto IL_00d4;
				}
				break;
				IL_003c:
				int num3;
				if (writeStartIndex + numBytesToRead <= num)
				{
					num2 = 650546829;
					num3 = num2;
				}
				else
				{
					num2 = 650546831;
					num3 = num2;
				}
			}
			goto IL_0007;
			IL_0007:
			num2 = 650546824;
			goto IL_000c;
			IL_0063:
			return 0;
			IL_0054:
			if (writeStartIndex < 0)
			{
				writeStartIndex = 0;
				num2 = 650546827;
				goto IL_000c;
			}
			goto IL_0091;
			IL_0091:
			int num4;
			if (readStartIndex + numBytesToRead <= MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				num2 = 650546825;
				num4 = num2;
			}
			else
			{
				num2 = 650546830;
				num4 = num2;
			}
			goto IL_000c;
		}

		public int TryReadBytes(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex = 0, int writeStartIndex = 0)
		{
			int num;
			if (!(buffer == IntPtr.Zero))
			{
				if (numBytesToRead <= 0)
				{
					goto IL_0011;
				}
				if (readStartIndex >= MwElyJEsJpEEOifMfHHXevYlDKfg)
				{
					num = -1798893535;
				}
				else
				{
					if (writeStartIndex >= bufferLength)
					{
						return 0;
					}
					int num2;
					if (readStartIndex >= 0)
					{
						num = -1798893534;
						num2 = num;
					}
					else
					{
						num = -1798893536;
						num2 = num;
					}
				}
				goto IL_0016;
			}
			goto IL_0078;
			IL_00cc:
			if (!NativeTools.CopyMemory(izvhHmSvmUBneSslrLADBhxqUkP, buffer, readStartIndex, writeStartIndex, numBytesToRead, false))
			{
				return 0;
			}
			return numBytesToRead;
			IL_0078:
			return 0;
			IL_0011:
			num = -1798893531;
			goto IL_0016;
			IL_0016:
			while (true)
			{
				switch (num ^ -1798893535)
				{
				case 2:
					break;
				case 6:
					if (readStartIndex + numBytesToRead > MwElyJEsJpEEOifMfHHXevYlDKfg)
					{
						numBytesToRead = MwElyJEsJpEEOifMfHHXevYlDKfg - readStartIndex;
						num = -1798893530;
						continue;
					}
					goto case 7;
				case 7:
					if (writeStartIndex + numBytesToRead > bufferLength)
					{
						numBytesToRead = bufferLength - writeStartIndex;
						num = -1798893532;
						continue;
					}
					goto IL_00cc;
				case 4:
					goto IL_0078;
				case 0:
					return 0;
				case 1:
					readStartIndex = 0;
					num = -1798893534;
					continue;
				case 3:
					if (writeStartIndex < 0)
					{
						writeStartIndex = 0;
						num = -1798893529;
						continue;
					}
					goto case 6;
				default:
					goto IL_00cc;
				}
				break;
			}
			goto IL_0011;
		}

		public void WriteBit(int byteIndex, byte bit, bool value)
		{
			if (1 + byteIndex <= Length)
			{
				while (true)
				{
					int num = -739160551;
					while (true)
					{
						switch (num ^ -739160547)
						{
						case 0:
							break;
						default:
							return;
						case 5:
							if (value)
							{
								Marshal.WriteByte(izvhHmSvmUBneSslrLADBhxqUkP, byteIndex, (byte)(Marshal.ReadByte(izvhHmSvmUBneSslrLADBhxqUkP, byteIndex) | (byte)(1 << (int)bit)));
								num = -739160545;
								continue;
							}
							goto case 6;
						case 8:
							goto end_IL_000b;
						case 6:
							Marshal.WriteByte(izvhHmSvmUBneSslrLADBhxqUkP, byteIndex, (byte)(Marshal.ReadByte(izvhHmSvmUBneSslrLADBhxqUkP, byteIndex) & (byte)(~(1 << (int)bit))));
							num = -739160550;
							continue;
						case 2:
							return;
						case 1:
							throw new ArgumentOutOfRangeException("bit");
						case 4:
							goto IL_00cd;
						case 3:
							goto IL_00e5;
						case 7:
							return;
						}
						break;
						IL_00e5:
						int num2;
						if (bit >= 8)
						{
							num = -739160548;
							num2 = num;
						}
						else
						{
							num = -739160552;
							num2 = num;
						}
						continue;
						IL_00cd:
						int num3;
						if (byteIndex < 0)
						{
							num = -739160555;
							num3 = num;
						}
						else
						{
							num = -739160546;
							num3 = num;
						}
					}
					continue;
					end_IL_000b:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("byteIndex");
		}

		public void Write(byte @byte, int startIndex)
		{
			if (1 + startIndex <= MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				while (true)
				{
					int num = -2071663659;
					while (true)
					{
						switch (num ^ -2071663657)
						{
						case 0:
							break;
						case 2:
							goto IL_002d;
						case 1:
							goto end_IL_000b;
						default:
							Marshal.WriteByte(izvhHmSvmUBneSslrLADBhxqUkP, startIndex, @byte);
							return;
						}
						break;
						IL_002d:
						int num2;
						if (startIndex < 0)
						{
							num = -2071663658;
							num2 = num;
						}
						else
						{
							num = -2071663660;
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
			if (2 + startIndex > MwElyJEsJpEEOifMfHHXevYlDKfg)
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
			int num = -1857523832;
			goto IL_0014;
			IL_0014:
			switch (num ^ -1857523829)
			{
			case 2:
				break;
			default:
				return;
			case 3:
				goto IL_0031;
			case 0:
				goto IL_0043;
			case 1:
				return;
			}
			goto IL_000f;
			IL_0043:
			Marshal.WriteInt16(izvhHmSvmUBneSslrLADBhxqUkP, startIndex, bytes);
			num = -1857523830;
			goto IL_0014;
		}

		public void Write(ushort bytes, int startIndex)
		{
			if (2 + startIndex <= MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x32E35755 ^ 0x32E35757)
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
			Marshal.WriteInt16(izvhHmSvmUBneSslrLADBhxqUkP, startIndex, (short)bytes);
		}

		public void Write(int bytes, int startIndex)
		{
			if (4 + startIndex > MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				goto IL_0031;
			}
			if (startIndex < 0)
			{
				goto IL_000f;
			}
			goto IL_0043;
			IL_0043:
			Marshal.WriteInt32(izvhHmSvmUBneSslrLADBhxqUkP, startIndex, bytes);
			int num = -1788477008;
			goto IL_0014;
			IL_000f:
			num = -1788477006;
			goto IL_0014;
			IL_0014:
			switch (num ^ -1788477005)
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
			if (4 + startIndex <= MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x2CACA62B ^ 0x2CACA62A)
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
			Marshal.WriteInt32(izvhHmSvmUBneSslrLADBhxqUkP, startIndex, (int)bytes);
		}

		public void Write(long bytes, int startIndex)
		{
			if (8 + startIndex > MwElyJEsJpEEOifMfHHXevYlDKfg)
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
			int num = 779198142;
			goto IL_0014;
			IL_0014:
			switch (num ^ 0x2E719EBD)
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
			Marshal.WriteInt64(izvhHmSvmUBneSslrLADBhxqUkP, startIndex, bytes);
			num = 779198143;
			goto IL_0014;
		}

		public void Write(ulong bytes, int startIndex)
		{
			if (8 + startIndex <= MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				if (startIndex >= 0)
				{
					goto IL_003f;
				}
				while (true)
				{
					switch (0x41420A03 ^ 0x41420A02)
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
			Marshal.WriteInt64(izvhHmSvmUBneSslrLADBhxqUkP, startIndex, (long)bytes);
		}

		public void Write(float bytes, int startIndex)
		{
			if (4 + startIndex <= MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				while (true)
				{
					int num = -1560394094;
					while (true)
					{
						switch (num ^ -1560394093)
						{
						case 0:
							break;
						case 1:
							goto IL_002d;
						case 3:
							goto end_IL_000b;
						default:
							Marshal.WriteInt32(izvhHmSvmUBneSslrLADBhxqUkP, startIndex, new DrCVuAQjyJxGvtUHjcNKVFTnwWi(bytes).STDVTaiFAxQvCFmkpbnahHeOGHF);
							return;
						}
						break;
						IL_002d:
						int num2;
						if (startIndex >= 0)
						{
							num = -1560394095;
							num2 = num;
						}
						else
						{
							num = -1560394096;
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
			if (8 + startIndex <= MwElyJEsJpEEOifMfHHXevYlDKfg)
			{
				while (true)
				{
					int num = -1779951475;
					while (true)
					{
						switch (num ^ -1779951476)
						{
						case 2:
							break;
						case 1:
							goto IL_002d;
						case 0:
							goto end_IL_000b;
						default:
							Marshal.WriteInt64(izvhHmSvmUBneSslrLADBhxqUkP, startIndex, new swhxTzSuEFvsmSdxWAEgUEbTFkh(bytes).mcQDZGCWoSEMGSmcvrwKruFzcwa);
							return;
						}
						break;
						IL_002d:
						int num2;
						if (startIndex < 0)
						{
							num = -1779951476;
							num2 = num;
						}
						else
						{
							num = -1779951473;
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
					IL_01a2:
					int num2;
					int num3;
					if (numBytesToWrite <= 0)
					{
						num2 = -1082369380;
						num3 = num2;
					}
					else
					{
						num2 = -1082369384;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -1082369380)
						{
						case 10:
							num2 = -1082369388;
							continue;
						default:
							return;
						case 8:
							break;
						case 12:
							if (readStartIndex >= num)
							{
								throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
							}
							goto IL_0093;
						case 5:
							goto IL_0093;
						case 13:
							if (writeStartIndex < 0)
							{
								throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
							}
							goto case 7;
						case 9:
							throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
						case 7:
							if (readStartIndex + numBytesToWrite > num)
							{
								throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
							}
							goto case 6;
						case 4:
							if (numBytesToWrite > num)
							{
								throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
							}
							goto case 2;
						case 11:
							NativeTools.CopyMemory(bytes, izvhHmSvmUBneSslrLADBhxqUkP, readStartIndex, writeStartIndex, numBytesToWrite);
							num2 = -1082369390;
							continue;
						case 6:
							if (numBytesToWrite + writeStartIndex > MwElyJEsJpEEOifMfHHXevYlDKfg)
							{
								throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
							}
							goto case 11;
						case 1:
							if (writeStartIndex >= MwElyJEsJpEEOifMfHHXevYlDKfg)
							{
								throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
							}
							goto case 13;
						case 2:
							if (numBytesToWrite > MwElyJEsJpEEOifMfHHXevYlDKfg)
							{
								throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
							}
							goto case 12;
						case 0:
							throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
						case 3:
							goto IL_01a2;
						case 14:
							return;
						}
						break;
						IL_0093:
						int num4;
						if (readStartIndex < 0)
						{
							num2 = -1082369387;
							num4 = num2;
						}
						else
						{
							num2 = -1082369379;
							num4 = num2;
						}
					}
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
			while (bufferLength > 0)
			{
				while (true)
				{
					IL_00ae:
					int num;
					int num2;
					if (numBytesToWrite <= 0)
					{
						num = 1086261199;
						num2 = num;
					}
					else
					{
						num = 1086261198;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x40BF07CE)
						{
						case 9:
							num = 1086261193;
							continue;
						case 7:
							break;
						case 15:
							throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
						case 3:
							goto IL_0095;
						case 6:
							goto IL_00ae;
						case 4:
							if (readStartIndex + numBytesToWrite > bufferLength)
							{
								throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
							}
							goto IL_0147;
						case 1:
							throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
						case 8:
							if (writeStartIndex < 0)
							{
								throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
							}
							goto case 4;
						case 0:
							if (numBytesToWrite > bufferLength)
							{
								throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
							}
							goto IL_012a;
						case 2:
							goto IL_012a;
						case 11:
							goto IL_0147;
						case 13:
							if (writeStartIndex >= MwElyJEsJpEEOifMfHHXevYlDKfg)
							{
								throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
							}
							goto case 8;
						case 5:
							if (readStartIndex < 0)
							{
								throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
							}
							goto case 13;
						case 10:
							throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
						case 12:
							throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
						default:
							NativeTools.CopyMemory(bytes, izvhHmSvmUBneSslrLADBhxqUkP, readStartIndex, writeStartIndex, numBytesToWrite);
							return;
						}
						break;
						IL_012a:
						int num3;
						if (numBytesToWrite <= MwElyJEsJpEEOifMfHHXevYlDKfg)
						{
							num = 1086261197;
							num3 = num;
						}
						else
						{
							num = 1086261185;
							num3 = num;
						}
						continue;
						IL_0147:
						int num4;
						if (numBytesToWrite + writeStartIndex > MwElyJEsJpEEOifMfHHXevYlDKfg)
						{
							num = 1086261188;
							num4 = num;
						}
						else
						{
							num = 1086261184;
							num4 = num;
						}
						continue;
						IL_0095:
						int num5;
						if (readStartIndex < bufferLength)
						{
							num = 1086261195;
							num5 = num;
						}
						else
						{
							num = 1086261186;
							num5 = num;
						}
					}
					break;
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
			if (num != 0)
			{
				int num3;
				if (numBytesToWrite > 0)
				{
					num2 = -1449348744;
					num3 = num2;
				}
				else
				{
					num2 = -1449348740;
					num3 = num2;
				}
				goto IL_000b;
			}
			goto IL_004d;
			IL_0006:
			num2 = -1449348738;
			goto IL_000b;
			IL_000b:
			while (true)
			{
				switch (num2 ^ -1449348737)
				{
				case 2:
					break;
				case 6:
					if (writeStartIndex < 0)
					{
						writeStartIndex = 0;
						num2 = -1449348745;
						continue;
					}
					goto case 8;
				case 3:
					goto IL_004d;
				case 0:
					readStartIndex = 0;
					num2 = -1449348743;
					continue;
				case 5:
					if (numBytesToWrite + writeStartIndex > MwElyJEsJpEEOifMfHHXevYlDKfg)
					{
						numBytesToWrite = MwElyJEsJpEEOifMfHHXevYlDKfg - writeStartIndex;
						num2 = -1449348741;
						continue;
					}
					goto IL_00de;
				case 1:
					return 0;
				case 8:
					if (readStartIndex + numBytesToWrite > num)
					{
						numBytesToWrite = num - readStartIndex;
						num2 = -1449348742;
						continue;
					}
					goto case 5;
				case 7:
					goto IL_00c3;
				default:
					goto IL_00de;
				}
				break;
				IL_00c3:
				if (readStartIndex < num)
				{
					if (writeStartIndex < MwElyJEsJpEEOifMfHHXevYlDKfg)
					{
						int num4;
						if (readStartIndex >= 0)
						{
							num2 = -1449348743;
							num4 = num2;
						}
						else
						{
							num2 = -1449348737;
							num4 = num2;
						}
					}
					else
					{
						num2 = -1449348740;
					}
					continue;
				}
				goto IL_004d;
			}
			goto IL_0006;
			IL_00de:
			if (!NativeTools.CopyMemory(bytes, izvhHmSvmUBneSslrLADBhxqUkP, readStartIndex, writeStartIndex, numBytesToWrite, false))
			{
				return 0;
			}
			return numBytesToWrite;
			IL_004d:
			return 0;
		}

		public int TryWriteBytes(IntPtr bytes, int bufferLength, int numBytesToWrite, int writeStartIndex = 0, int readStartIndex = 0)
		{
			if (!(bytes == IntPtr.Zero) && bufferLength > 0 && numBytesToWrite > 0 && readStartIndex < bufferLength)
			{
				while (true)
				{
					int num = 1455376572;
					while (true)
					{
						switch (num ^ 0x56BF48BF)
						{
						case 4:
							break;
						case 0:
							numBytesToWrite = bufferLength - readStartIndex;
							num = 1455376570;
							continue;
						case 2:
							goto end_IL_001a;
						case 5:
							if (numBytesToWrite + writeStartIndex > MwElyJEsJpEEOifMfHHXevYlDKfg)
							{
								numBytesToWrite = MwElyJEsJpEEOifMfHHXevYlDKfg - writeStartIndex;
								num = 1455376568;
								continue;
							}
							goto IL_00c6;
						case 1:
							goto IL_0088;
						case 6:
							goto IL_0097;
						case 3:
							goto IL_00b2;
						default:
							goto IL_00c6;
						}
						break;
						IL_00b2:
						if (writeStartIndex < MwElyJEsJpEEOifMfHHXevYlDKfg)
						{
							if (readStartIndex < 0)
							{
								readStartIndex = 0;
								num = 1455376574;
								continue;
							}
							goto IL_0088;
						}
						num = 1455376573;
						continue;
						IL_0097:
						int num2;
						if (readStartIndex + numBytesToWrite > bufferLength)
						{
							num = 1455376575;
							num2 = num;
						}
						else
						{
							num = 1455376570;
							num2 = num;
						}
						continue;
						IL_0088:
						if (writeStartIndex < 0)
						{
							writeStartIndex = 0;
							num = 1455376569;
							continue;
						}
						goto IL_0097;
					}
					continue;
					IL_00c6:
					if (!NativeTools.CopyMemory(bytes, izvhHmSvmUBneSslrLADBhxqUkP, readStartIndex, writeStartIndex, numBytesToWrite, false))
					{
						return 0;
					}
					return numBytesToWrite;
					continue;
					end_IL_001a:
					break;
				}
			}
			return 0;
		}

		public bool Resize(int size, bool preserveData)
		{
			if (size < 0)
			{
				while (true)
				{
					switch (-611103132 ^ -611103131)
					{
					case 2:
						continue;
					case 1:
						throw new ArgumentOutOfRangeException("size");
					}
					break;
				}
			}
			if (MwElyJEsJpEEOifMfHHXevYlDKfg == size)
			{
				return true;
			}
			if (size == 0)
			{
				Release();
				return true;
			}
			IntPtr intPtr;
			bool result = default(bool);
			if (preserveData)
			{
				try
				{
					intPtr = Marshal.AllocHGlobal(size);
					if (intPtr == IntPtr.Zero)
					{
						result = false;
						while (true)
						{
							switch (-611103132 ^ -611103131)
							{
							case 2:
								break;
							default:
								goto end_IL_0066;
							case 0:
								goto end_IL_0066;
							case 1:
								goto IL_01a8;
							}
							continue;
							end_IL_0066:
							break;
						}
					}
				}
				catch
				{
					result = false;
					goto IL_01a8;
				}
				int bytesToCopy = MathTools.Min(size, MwElyJEsJpEEOifMfHHXevYlDKfg);
				if (!NativeTools.CopyMemory(izvhHmSvmUBneSslrLADBhxqUkP, intPtr, 0, 0, bytesToCopy, false))
				{
					Marshal.FreeHGlobal(intPtr);
					return false;
				}
				if (size > MwElyJEsJpEEOifMfHHXevYlDKfg)
				{
					goto IL_00ca;
				}
				goto IL_011a;
			}
			goto IL_0127;
			IL_0198:
			izvhHmSvmUBneSslrLADBhxqUkP = intPtr;
			MwElyJEsJpEEOifMfHHXevYlDKfg = size;
			return true;
			IL_011a:
			Release();
			int num = -611103135;
			goto IL_00cf;
			IL_01a8:
			return result;
			IL_00cf:
			while (true)
			{
				switch (num ^ -611103131)
				{
				case 0:
					break;
				case 3:
					NativeTools.FillMemory(intPtr, MwElyJEsJpEEOifMfHHXevYlDKfg, size - MwElyJEsJpEEOifMfHHXevYlDKfg, 0, false);
					num = -611103129;
					continue;
				case 2:
					goto IL_011a;
				default:
					goto IL_0127;
				case 4:
					goto IL_0198;
				}
				break;
			}
			goto IL_00ca;
			IL_00ca:
			num = -611103130;
			goto IL_00cf;
			IL_0127:
			Release();
			try
			{
				intPtr = Marshal.AllocHGlobal(size);
				while (true)
				{
					IL_0134:
					int num2 = -611103129;
					while (true)
					{
						switch (num2 ^ -611103131)
						{
						case 0:
							break;
						default:
							goto end_IL_0139;
						case 2:
						{
							int num3;
							if (intPtr == IntPtr.Zero)
							{
								num2 = -611103135;
								num3 = num2;
							}
							else
							{
								num2 = -611103130;
								num3 = num2;
							}
							continue;
						}
						case 4:
							result = false;
							num2 = -611103132;
							continue;
						case 3:
							goto end_IL_0139;
						case 1:
							goto IL_01a8;
						}
						goto IL_0134;
						continue;
						end_IL_0139:
						break;
					}
					break;
				}
			}
			catch
			{
				result = false;
				goto IL_01a8;
			}
			NativeTools.ZeroFillMemory(intPtr, size);
			goto IL_0198;
		}

		public void Clear()
		{
			if (MwElyJEsJpEEOifMfHHXevYlDKfg == 0)
			{
				while (true)
				{
					switch (-1616732723 ^ -1616732721)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			NativeTools.ZeroFillMemory(izvhHmSvmUBneSslrLADBhxqUkP, MwElyJEsJpEEOifMfHHXevYlDKfg);
		}

		public void Release()
		{
			if (izvhHmSvmUBneSslrLADBhxqUkP != IntPtr.Zero)
			{
				goto IL_0012;
			}
			goto IL_004a;
			IL_0012:
			int num = -1193625567;
			goto IL_0017;
			IL_0017:
			while (true)
			{
				switch (num ^ -1193625566)
				{
				case 4:
					break;
				default:
					return;
				case 3:
					Marshal.FreeHGlobal(Pointer);
					num = -1193625565;
					continue;
				case 2:
					goto IL_004a;
				case 1:
					izvhHmSvmUBneSslrLADBhxqUkP = IntPtr.Zero;
					num = -1193625568;
					continue;
				case 0:
					return;
				}
				break;
			}
			goto IL_0012;
			IL_004a:
			MwElyJEsJpEEOifMfHHXevYlDKfg = 0;
			num = -1193625566;
			goto IL_0017;
		}

		public override string ToString()
		{
			return "Length = " + MwElyJEsJpEEOifMfHHXevYlDKfg + "\nPointer = " + izvhHmSvmUBneSslrLADBhxqUkP + "\n";
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
			if (vsurYtRlepcrpAzAENwjqjJEZPT)
			{
				return;
			}
			while (true)
			{
				int num = 707328753;
				while (true)
				{
					switch (num ^ 0x2A28FAF3)
					{
					case 0:
						goto IL_0009;
					case 1:
						break;
					default:
						Release();
						vsurYtRlepcrpAzAENwjqjJEZPT = true;
						return;
					}
					break;
					IL_0009:
					num = 707328754;
				}
			}
		}

		public static implicit operator IntPtr(NativeBuffer buffer)
		{
			if (buffer == null)
			{
				return IntPtr.Zero;
			}
			return buffer.izvhHmSvmUBneSslrLADBhxqUkP;
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
				if (destination == null)
				{
					num = 1190209003;
					num2 = num;
				}
				else
				{
					num = 1190209004;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x46F125EF)
					{
					case 0:
						num = 1190209006;
						continue;
					case 1:
						break;
					case 3:
						if (source.MwElyJEsJpEEOifMfHHXevYlDKfg == 0)
						{
							destination.Release();
							return true;
						}
						if (destination.Resize(source.MwElyJEsJpEEOifMfHHXevYlDKfg, false))
						{
							num = 1190209005;
							continue;
						}
						return false;
					case 4:
						throw new ArgumentNullException("destination");
					default:
						return NativeTools.CopyMemory(source.izvhHmSvmUBneSslrLADBhxqUkP, destination.izvhHmSvmUBneSslrLADBhxqUkP, 0, 0, source.MwElyJEsJpEEOifMfHHXevYlDKfg, false);
					}
					break;
				}
			}
		}
	}
}
