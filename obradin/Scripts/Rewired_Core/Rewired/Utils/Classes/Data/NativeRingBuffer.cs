using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class NativeRingBuffer : IDisposable
	{
		private readonly NativeBuffer HaaYbekkYkVzqIEKjXoDUBlmwQE;

		private readonly int ZQtXcXYFxPSVYxnpniroAAvoIDE;

		private long eSDdjSVXrpQWppMZyfdHMKkSkBV;

		private long xuRVibkStwYJzfDZINhAtRbfsJa;

		private int lakhHRvvHYCEDhrWoTamMOvOGCOA;

		private bool LnRforneFjeSPukYMublsguMNfU;

		private uint MPvtJorjPXvtIhcDDDtlhGMqkgSA;

		private bool vsurYtRlepcrpAzAENwjqjJEZPT;

		public int Capacity
		{
			get
			{
				return ZQtXcXYFxPSVYxnpniroAAvoIDE;
			}
		}

		public int BytesInBuffer
		{
			get
			{
				return lakhHRvvHYCEDhrWoTamMOvOGCOA;
			}
		}

		public bool BufferOverrun
		{
			get
			{
				return LnRforneFjeSPukYMublsguMNfU;
			}
		}

		public NativeRingBuffer(int capacity)
		{
			ZQtXcXYFxPSVYxnpniroAAvoIDE = capacity;
			if (capacity <= 0)
			{
				throw new ArgumentOutOfRangeException("sizeInBytes");
			}
			HaaYbekkYkVzqIEKjXoDUBlmwQE = new NativeBuffer(capacity);
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)eSDdjSVXrpQWppMZyfdHMKkSkBV;
			passId = MPvtJorjPXvtIhcDDDtlhGMqkgSA;
			if (buffer == IntPtr.Zero || bufferLength <= 0)
			{
				goto IL_0052;
			}
			if (numBytesToWrite <= 0)
			{
				goto IL_0028;
			}
			int num;
			if (numBytesToWrite > bufferLength)
			{
				numBytesToWrite = bufferLength;
				num = 285564999;
				goto IL_002d;
			}
			goto IL_0084;
			IL_002d:
			int num2 = default(int);
			switch (num ^ 0x11056045)
			{
			case 4:
				break;
			case 3:
				goto IL_0052;
			case 1:
				return 0;
			case 2:
				goto IL_0084;
			case 0:
				goto IL_00a5;
			default:
				return num2;
			}
			goto IL_0028;
			IL_0052:
			return 0;
			IL_0084:
			num2 = HaaYbekkYkVzqIEKjXoDUBlmwQE.TryWriteBytes(buffer, bufferLength, numBytesToWrite, (int)eSDdjSVXrpQWppMZyfdHMKkSkBV);
			if (num2 != 0)
			{
				if (num2 >= numBytesToWrite)
				{
					goto IL_00a5;
				}
				num2 += HaaYbekkYkVzqIEKjXoDUBlmwQE.TryWriteBytes(buffer, bufferLength, numBytesToWrite - num2, 0, num2);
				num = 285564997;
			}
			else
			{
				num = 285564996;
			}
			goto IL_002d;
			IL_00a5:
			VGdBuWGqPpjEfjkGGPOSNVjFMEHI(num2);
			num = 285564992;
			goto IL_002d;
			IL_0028:
			num = 285564998;
			goto IL_002d;
		}

		public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)eSDdjSVXrpQWppMZyfdHMKkSkBV;
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num = -1528038817;
				while (true)
				{
					switch (num ^ -1528038820)
					{
					case 2:
						break;
					case 4:
						numBytesToWrite = num2;
						num = -1528038828;
						continue;
					case 8:
						num3 = HaaYbekkYkVzqIEKjXoDUBlmwQE.TryWriteBytes(buffer, numBytesToWrite, (int)eSDdjSVXrpQWppMZyfdHMKkSkBV);
						num = -1528038820;
						continue;
					case 7:
					{
						int num5;
						if (num2 <= 0)
						{
							num = -1528038823;
							num5 = num;
						}
						else
						{
							num = -1528038819;
							num5 = num;
						}
						continue;
					}
					case 1:
					{
						int num4;
						if (numBytesToWrite <= 0)
						{
							num = -1528038823;
						}
						else if (numBytesToWrite <= num2)
						{
							num = -1528038828;
							num4 = num;
						}
						else
						{
							num = -1528038824;
							num4 = num;
						}
						continue;
					}
					case 0:
						if (num3 == 0)
						{
							num = -1528038827;
							continue;
						}
						if (num3 < numBytesToWrite)
						{
							num3 += HaaYbekkYkVzqIEKjXoDUBlmwQE.TryWriteBytes(buffer, numBytesToWrite - num3, 0, num3);
							num = -1528038822;
							continue;
						}
						goto default;
					case 9:
						return 0;
					case 3:
						passId = MPvtJorjPXvtIhcDDDtlhGMqkgSA;
						if (buffer == null)
						{
							return 0;
						}
						num2 = buffer.Length;
						num = -1528038821;
						continue;
					case 5:
						return 0;
					default:
						VGdBuWGqPpjEfjkGGPOSNVjFMEHI(num3);
						return num3;
					}
					break;
				}
			}
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite)
		{
			int startOffset;
			uint passId;
			return Write(buffer, bufferLength, numBytesToWrite, out startOffset, out passId);
		}

		public int Write(byte[] buffer, int numBytesToWrite)
		{
			int startOffset;
			uint passId;
			return Write(buffer, numBytesToWrite, out startOffset, out passId);
		}

		public int Read(IntPtr buffer, int bufferLength, int numBytesToRead)
		{
			if (!(buffer == IntPtr.Zero))
			{
				int num2 = default(int);
				while (true)
				{
					int num = -977262803;
					while (true)
					{
						switch (num ^ -977262805)
						{
						case 0:
							break;
						case 6:
							goto IL_003e;
						case 4:
							goto end_IL_000d;
						case 1:
							goto IL_0065;
						case 3:
							goto IL_0073;
						case 2:
							goto IL_00b3;
						default:
							return num2;
						}
						break;
						IL_003e:
						if (bufferLength <= 0 || numBytesToRead <= 0)
						{
							goto end_IL_000d;
						}
						if (lakhHRvvHYCEDhrWoTamMOvOGCOA == 0)
						{
							num = -977262801;
							continue;
						}
						if (numBytesToRead > bufferLength)
						{
							numBytesToRead = bufferLength;
							num = -977262807;
							continue;
						}
						goto IL_00b3;
						IL_0065:
						rZfgvnvVyLImXvEbSdviOPICNOS(num2);
						num = -977262802;
						continue;
						IL_0073:
						num2 = HaaYbekkYkVzqIEKjXoDUBlmwQE.TryReadBytes(buffer, bufferLength, numBytesToRead, (int)xuRVibkStwYJzfDZINhAtRbfsJa);
						if (num2 <= 0)
						{
							return 0;
						}
						if (num2 < numBytesToRead)
						{
							num2 += HaaYbekkYkVzqIEKjXoDUBlmwQE.TryReadBytes(buffer, bufferLength, numBytesToRead - num2, 0, num2);
							num = -977262806;
							continue;
						}
						goto IL_0065;
						IL_00b3:
						if (numBytesToRead > lakhHRvvHYCEDhrWoTamMOvOGCOA)
						{
							numBytesToRead = lakhHRvvHYCEDhrWoTamMOvOGCOA;
							num = -977262808;
							continue;
						}
						goto IL_0073;
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			return 0;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			int num6 = default(int);
			while (true)
			{
				int num2 = -2071215080;
				while (true)
				{
					switch (num2 ^ -2071215075)
					{
					case 0:
						break;
					case 8:
						return 0;
					case 4:
						num6 = HaaYbekkYkVzqIEKjXoDUBlmwQE.TryReadBytes(buffer, numBytesToRead, (int)xuRVibkStwYJzfDZINhAtRbfsJa);
						if (num6 <= 0)
						{
							return 0;
						}
						if (num6 < numBytesToRead)
						{
							num6 += HaaYbekkYkVzqIEKjXoDUBlmwQE.TryReadBytes(buffer, numBytesToRead - num6, 0, num6);
							num2 = -2071215076;
							continue;
						}
						goto default;
					case 2:
						numBytesToRead = lakhHRvvHYCEDhrWoTamMOvOGCOA;
						num2 = -2071215079;
						continue;
					case 3:
						if (lakhHRvvHYCEDhrWoTamMOvOGCOA != 0)
						{
							int num4;
							if (numBytesToRead > num)
							{
								num2 = -2071215078;
								num4 = num2;
							}
							else
							{
								num2 = -2071215077;
								num4 = num2;
							}
						}
						else
						{
							num2 = -2071215083;
						}
						continue;
					case 7:
						numBytesToRead = num;
						num2 = -2071215077;
						continue;
					case 5:
						if (num > 0)
						{
							int num5;
							if (numBytesToRead > 0)
							{
								num2 = -2071215074;
								num5 = num2;
							}
							else
							{
								num2 = -2071215083;
								num5 = num2;
							}
							continue;
						}
						goto case 8;
					case 6:
					{
						int num3;
						if (numBytesToRead <= lakhHRvvHYCEDhrWoTamMOvOGCOA)
						{
							num2 = -2071215079;
							num3 = num2;
						}
						else
						{
							num2 = -2071215073;
							num3 = num2;
						}
						continue;
					}
					default:
						rZfgvnvVyLImXvEbSdviOPICNOS(num6);
						return num6;
					}
					break;
				}
			}
		}

		public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
		{
			if (!(buffer == IntPtr.Zero) && bufferLength > 0 && numBytesToRead > 0 && lakhHRvvHYCEDhrWoTamMOvOGCOA != 0)
			{
				int num2 = default(int);
				while (true)
				{
					int num = 656325207;
					while (true)
					{
						switch (num ^ 0x271EBA52)
						{
						case 0:
							break;
						case 5:
							goto IL_005e;
						case 7:
							goto IL_0074;
						case 4:
							return 0;
						case 1:
							goto IL_00a7;
						case 6:
							goto end_IL_0029;
						case 3:
							goto IL_00d5;
						default:
							goto IL_00f5;
						}
						break;
						IL_0074:
						if (readStartIndex >= ZQtXcXYFxPSVYxnpniroAAvoIDE)
						{
							num = 656325204;
							continue;
						}
						if (numBytesToRead > bufferLength)
						{
							numBytesToRead = bufferLength;
							num = 656325203;
							continue;
						}
						goto IL_00a7;
						IL_00f5:
						return num2;
						IL_00d5:
						num2 = HaaYbekkYkVzqIEKjXoDUBlmwQE.TryReadBytes(buffer, bufferLength, numBytesToRead, readStartIndex);
						if (num2 > 0)
						{
							if (num2 < numBytesToRead)
							{
								num2 += HaaYbekkYkVzqIEKjXoDUBlmwQE.TryReadBytes(buffer, bufferLength, numBytesToRead - num2, 0, num2);
								num = 656325200;
								continue;
							}
							goto IL_00f5;
						}
						num = 656325206;
						continue;
						IL_005e:
						int num3;
						if (readStartIndex < 0)
						{
							num = 656325204;
							num3 = num;
						}
						else
						{
							num = 656325205;
							num3 = num;
						}
						continue;
						IL_00a7:
						if (numBytesToRead > lakhHRvvHYCEDhrWoTamMOvOGCOA)
						{
							numBytesToRead = lakhHRvvHYCEDhrWoTamMOvOGCOA;
							num = 656325201;
							continue;
						}
						goto IL_00d5;
					}
					continue;
					end_IL_0029:
					break;
				}
			}
			return 0;
		}

		public int RandomRead(byte[] buffer, int numBytesToRead, int readStartIndex)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			int num3 = default(int);
			while (true)
			{
				int num2 = -792708643;
				while (true)
				{
					switch (num2 ^ -792708642)
					{
					case 7:
						break;
					case 3:
						if (num > 0 && numBytesToRead > 0 && lakhHRvvHYCEDhrWoTamMOvOGCOA != 0 && readStartIndex >= 0)
						{
							int num4;
							if (readStartIndex >= ZQtXcXYFxPSVYxnpniroAAvoIDE)
							{
								num2 = -792708644;
							}
							else if (numBytesToRead > num)
							{
								num2 = -792708648;
								num4 = num2;
							}
							else
							{
								num2 = -792708642;
								num4 = num2;
							}
							continue;
						}
						goto case 2;
					case 1:
						num3 = HaaYbekkYkVzqIEKjXoDUBlmwQE.TryReadBytes(buffer, numBytesToRead, readStartIndex);
						num2 = -792708650;
						continue;
					case 0:
					{
						int num5;
						if (numBytesToRead <= lakhHRvvHYCEDhrWoTamMOvOGCOA)
						{
							num2 = -792708641;
							num5 = num2;
						}
						else
						{
							num2 = -792708646;
							num5 = num2;
						}
						continue;
					}
					case 8:
						if (num3 <= 0)
						{
							return 0;
						}
						if (num3 < numBytesToRead)
						{
							num3 += HaaYbekkYkVzqIEKjXoDUBlmwQE.TryReadBytes(buffer, numBytesToRead - num3, 0, num3);
							num2 = -792708645;
							continue;
						}
						goto default;
					case 6:
						numBytesToRead = num;
						num2 = -792708642;
						continue;
					case 4:
						numBytesToRead = lakhHRvvHYCEDhrWoTamMOvOGCOA;
						num2 = -792708641;
						continue;
					case 2:
						return 0;
					default:
						return num3;
					}
					break;
				}
			}
		}

		public bool IsValid(int startIndex, uint passId)
		{
			if (startIndex >= 0)
			{
				while (true)
				{
					int num = -528954166;
					while (true)
					{
						switch (num ^ -528954167)
						{
						case 0:
							break;
						case 4:
							goto IL_002a;
						case 1:
							goto end_IL_0004;
						case 3:
							goto IL_0061;
						default:
							return false;
						}
						break;
						IL_0061:
						if (startIndex < ZQtXcXYFxPSVYxnpniroAAvoIDE)
						{
							if (startIndex >= eSDdjSVXrpQWppMZyfdHMKkSkBV)
							{
								if (startIndex >= eSDdjSVXrpQWppMZyfdHMKkSkBV)
								{
									if (MPvtJorjPXvtIhcDDDtlhGMqkgSA == 0)
									{
										num = -528954165;
										continue;
									}
									if (MPvtJorjPXvtIhcDDDtlhGMqkgSA - 1 == passId)
									{
										return true;
									}
								}
								goto IL_0080;
							}
							num = -528954163;
							continue;
						}
						num = -528954168;
						continue;
						IL_002a:
						if (passId == MPvtJorjPXvtIhcDDDtlhGMqkgSA)
						{
							return true;
						}
						goto IL_0080;
						IL_0080:
						return false;
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			return false;
		}

		public void Reset()
		{
			eSDdjSVXrpQWppMZyfdHMKkSkBV = 0L;
			xuRVibkStwYJzfDZINhAtRbfsJa = 0L;
			lakhHRvvHYCEDhrWoTamMOvOGCOA = 0;
			LnRforneFjeSPukYMublsguMNfU = false;
			MPvtJorjPXvtIhcDDDtlhGMqkgSA = 0u;
		}

		private void VGdBuWGqPpjEfjkGGPOSNVjFMEHI(int P_0)
		{
			if (P_0 <= 0)
			{
				goto IL_0007;
			}
			goto IL_00bf;
			IL_0007:
			int num = 1748850356;
			goto IL_000c;
			IL_000c:
			bool flag = default(bool);
			while (true)
			{
				switch (num ^ 0x683D56B2)
				{
				case 10:
					break;
				default:
					return;
				case 3:
					if (xuRVibkStwYJzfDZINhAtRbfsJa >= ZQtXcXYFxPSVYxnpniroAAvoIDE)
					{
						xuRVibkStwYJzfDZINhAtRbfsJa -= ZQtXcXYFxPSVYxnpniroAAvoIDE;
						num = 1748850352;
						continue;
					}
					goto IL_0141;
				case 11:
					nyzhfttLDYyCPlHxXwExnunHcrN();
					num = 1748850357;
					continue;
				case 5:
					flag = true;
					num = 1748850358;
					continue;
				case 7:
					goto IL_0096;
				case 8:
					goto IL_00bf;
				case 0:
					xuRVibkStwYJzfDZINhAtRbfsJa = eSDdjSVXrpQWppMZyfdHMKkSkBV;
					num = 1748850353;
					continue;
				case 1:
					goto IL_0115;
				case 2:
					goto IL_0141;
				case 6:
					return;
				case 9:
					goto IL_017c;
				case 4:
					goto IL_0199;
				case 12:
					return;
				}
				break;
			}
			goto IL_0007;
			IL_0096:
			lakhHRvvHYCEDhrWoTamMOvOGCOA = (int)MathTools.Clamp((long)lakhHRvvHYCEDhrWoTamMOvOGCOA + (long)P_0, 0L, ZQtXcXYFxPSVYxnpniroAAvoIDE);
			num = 1748850366;
			goto IL_000c;
			IL_017c:
			int num2;
			if (lakhHRvvHYCEDhrWoTamMOvOGCOA > 0)
			{
				num = 1748850359;
				num2 = num;
			}
			else
			{
				num = 1748850358;
				num2 = num;
			}
			goto IL_000c;
			IL_0199:
			if (flag)
			{
				LnRforneFjeSPukYMublsguMNfU = true;
				num = 1748850354;
				goto IL_000c;
			}
			goto IL_0141;
			IL_0141:
			if (eSDdjSVXrpQWppMZyfdHMKkSkBV >= ZQtXcXYFxPSVYxnpniroAAvoIDE)
			{
				eSDdjSVXrpQWppMZyfdHMKkSkBV -= ZQtXcXYFxPSVYxnpniroAAvoIDE;
				num = 1748850361;
				goto IL_000c;
			}
			goto IL_0096;
			IL_00bf:
			int num3 = (int)eSDdjSVXrpQWppMZyfdHMKkSkBV;
			eSDdjSVXrpQWppMZyfdHMKkSkBV += P_0;
			flag = false;
			if (num3 >= xuRVibkStwYJzfDZINhAtRbfsJa)
			{
				goto IL_0115;
			}
			if (eSDdjSVXrpQWppMZyfdHMKkSkBV > xuRVibkStwYJzfDZINhAtRbfsJa)
			{
				flag = true;
				num = 1748850358;
				goto IL_000c;
			}
			goto IL_0199;
			IL_0115:
			if (num3 <= xuRVibkStwYJzfDZINhAtRbfsJa)
			{
				goto IL_017c;
			}
			if (eSDdjSVXrpQWppMZyfdHMKkSkBV - ZQtXcXYFxPSVYxnpniroAAvoIDE > xuRVibkStwYJzfDZINhAtRbfsJa)
			{
				flag = true;
				num = 1748850358;
				goto IL_000c;
			}
			goto IL_0199;
		}

		private void rZfgvnvVyLImXvEbSdviOPICNOS(int P_0)
		{
			if (P_0 <= 0)
			{
				return;
			}
			while (true)
			{
				int num;
				if (LnRforneFjeSPukYMublsguMNfU)
				{
					LnRforneFjeSPukYMublsguMNfU = false;
					num = -681049423;
					goto IL_000a;
				}
				goto IL_003d;
				IL_000a:
				while (true)
				{
					switch (num ^ -681049422)
					{
					case 0:
						num = -681049424;
						continue;
					case 2:
						break;
					case 3:
						goto IL_003d;
					default:
						goto end_IL_0027;
					}
					break;
				}
				continue;
				IL_003d:
				xuRVibkStwYJzfDZINhAtRbfsJa += P_0;
				if (xuRVibkStwYJzfDZINhAtRbfsJa < ZQtXcXYFxPSVYxnpniroAAvoIDE)
				{
					break;
				}
				xuRVibkStwYJzfDZINhAtRbfsJa -= ZQtXcXYFxPSVYxnpniroAAvoIDE;
				num = -681049421;
				goto IL_000a;
				continue;
				end_IL_0027:
				break;
			}
			long num2 = (long)lakhHRvvHYCEDhrWoTamMOvOGCOA - (long)P_0;
			lakhHRvvHYCEDhrWoTamMOvOGCOA = (int)((num2 >= 0) ? num2 : 0);
		}

		private void nyzhfttLDYyCPlHxXwExnunHcrN()
		{
			if (MPvtJorjPXvtIhcDDDtlhGMqkgSA == uint.MaxValue)
			{
				MPvtJorjPXvtIhcDDDtlhGMqkgSA = 0u;
			}
			else
			{
				MPvtJorjPXvtIhcDDDtlhGMqkgSA++;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~NativeRingBuffer()
		{
			Dispose(false);
		}

		protected void Dispose(bool disposing)
		{
			if (vsurYtRlepcrpAzAENwjqjJEZPT)
			{
				return;
			}
			while (true)
			{
				int num;
				if (disposing)
				{
					int num2;
					if (HaaYbekkYkVzqIEKjXoDUBlmwQE != null)
					{
						num = -532987003;
						num2 = num;
					}
					else
					{
						num = -532987004;
						num2 = num;
					}
					goto IL_000e;
				}
				goto IL_005d;
				IL_000e:
				while (true)
				{
					switch (num ^ -532987003)
					{
					case 2:
						num = -532987002;
						continue;
					default:
						return;
					case 3:
						break;
					case 0:
						HaaYbekkYkVzqIEKjXoDUBlmwQE.Dispose();
						num = -532987004;
						continue;
					case 1:
						goto IL_005d;
					case 4:
						return;
					}
					break;
				}
				continue;
				IL_005d:
				vsurYtRlepcrpAzAENwjqjJEZPT = true;
				num = -532987007;
				goto IL_000e;
			}
		}
	}
}
