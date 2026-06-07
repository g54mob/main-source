using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeRingBuffer : IDisposable
	{
		private readonly NativeBuffer ugDapCqSwatVwHFNRCJxFJwpWF;

		private readonly int qvddhAEohNgcpXDiHojyOjpuJQDJ;

		private long HGJurFfjNjfGCFYRWxDZnGCAEjO;

		private long SVLFjmJGbsIyYORCwVzAOYbzBGhK;

		private int CIuxKSRkFIHviBIHYNaubmhEDNZ;

		private bool ygniihRIePHpdIcxueMrXGayAqg;

		private uint xRldAneDJZPOxiRSIjjhSfMkuvBD;

		private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

		public int Capacity
		{
			get
			{
				return qvddhAEohNgcpXDiHojyOjpuJQDJ;
			}
		}

		public int BytesInBuffer
		{
			get
			{
				return CIuxKSRkFIHviBIHYNaubmhEDNZ;
			}
		}

		public bool BufferOverrun
		{
			get
			{
				return ygniihRIePHpdIcxueMrXGayAqg;
			}
		}

		public NativeRingBuffer(int capacity)
		{
			qvddhAEohNgcpXDiHojyOjpuJQDJ = capacity;
			if (capacity <= 0)
			{
				throw new ArgumentOutOfRangeException("sizeInBytes");
			}
			ugDapCqSwatVwHFNRCJxFJwpWF = new NativeBuffer(capacity);
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)HGJurFfjNjfGCFYRWxDZnGCAEjO;
			passId = xRldAneDJZPOxiRSIjjhSfMkuvBD;
			if (!(buffer == IntPtr.Zero))
			{
				int num2 = default(int);
				while (true)
				{
					int num = 1814816054;
					while (true)
					{
						switch (num ^ 0x6C2BE532)
						{
						case 0:
							break;
						case 4:
							goto IL_004e;
						case 6:
							goto end_IL_0020;
						case 2:
							wWhpWVuQBxvgSMVTeUNQuWzRBwG(num2);
							num = 1814816055;
							continue;
						case 1:
							num2 += ugDapCqSwatVwHFNRCJxFJwpWF.TryWriteBytes(buffer, bufferLength, numBytesToWrite - num2, 0, num2);
							num = 1814816048;
							continue;
						case 3:
							goto IL_0097;
						default:
							return num2;
						}
						break;
						IL_004e:
						if (bufferLength <= 0)
						{
							goto end_IL_0020;
						}
						if (numBytesToWrite <= 0)
						{
							num = 1814816052;
							continue;
						}
						if (numBytesToWrite > bufferLength)
						{
							numBytesToWrite = bufferLength;
							num = 1814816049;
							continue;
						}
						goto IL_0097;
						IL_0097:
						num2 = ugDapCqSwatVwHFNRCJxFJwpWF.TryWriteBytes(buffer, bufferLength, numBytesToWrite, (int)HGJurFfjNjfGCFYRWxDZnGCAEjO);
						if (num2 == 0)
						{
							return 0;
						}
						int num3;
						if (num2 >= numBytesToWrite)
						{
							num = 1814816048;
							num3 = num;
						}
						else
						{
							num = 1814816051;
							num3 = num;
						}
					}
					continue;
					end_IL_0020:
					break;
				}
			}
			return 0;
		}

		public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)HGJurFfjNjfGCFYRWxDZnGCAEjO;
			passId = xRldAneDJZPOxiRSIjjhSfMkuvBD;
			int num2 = default(int);
			while (true)
			{
				int num = -903759027;
				while (true)
				{
					switch (num ^ -903759028)
					{
					case 2:
						break;
					case 1:
					{
						if (buffer == null)
						{
							return 0;
						}
						int num3 = buffer.Length;
						if (num3 <= 0)
						{
							goto case 3;
						}
						if (numBytesToWrite <= 0)
						{
							num = -903759025;
							continue;
						}
						if (numBytesToWrite > num3)
						{
							numBytesToWrite = num3;
							num = -903759032;
							continue;
						}
						goto case 4;
					}
					case 3:
						return 0;
					case 0:
						wWhpWVuQBxvgSMVTeUNQuWzRBwG(num2);
						num = -903759031;
						continue;
					case 4:
						num2 = ugDapCqSwatVwHFNRCJxFJwpWF.TryWriteBytes(buffer, numBytesToWrite, (int)HGJurFfjNjfGCFYRWxDZnGCAEjO);
						if (num2 == 0)
						{
							return 0;
						}
						if (num2 < numBytesToWrite)
						{
							num2 += ugDapCqSwatVwHFNRCJxFJwpWF.TryWriteBytes(buffer, numBytesToWrite - num2, 0, num2);
							num = -903759028;
							continue;
						}
						goto case 0;
					default:
						return num2;
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
			if (!(buffer == IntPtr.Zero) && bufferLength > 0)
			{
				int num2 = default(int);
				while (true)
				{
					int num = 1189847342;
					while (true)
					{
						switch (num ^ 0x46EBA128)
						{
						case 3:
							break;
						case 1:
							return 0;
						case 2:
							if (numBytesToRead > CIuxKSRkFIHviBIHYNaubmhEDNZ)
							{
								numBytesToRead = CIuxKSRkFIHviBIHYNaubmhEDNZ;
								num = 1189847328;
								continue;
							}
							goto IL_00d8;
						case 5:
							num2 += ugDapCqSwatVwHFNRCJxFJwpWF.TryReadBytes(buffer, bufferLength, numBytesToRead - num2, 0, num2);
							num = 1189847336;
							continue;
						case 4:
							numBytesToRead = bufferLength;
							num = 1189847338;
							continue;
						case 7:
							goto end_IL_0017;
						case 6:
							goto IL_00c2;
						case 8:
							goto IL_00d8;
						default:
							EndqasNJqPLdoTQweczoxHQENDH(num2);
							return num2;
						}
						break;
						IL_00c2:
						if (numBytesToRead <= 0)
						{
							goto end_IL_0017;
						}
						if (CIuxKSRkFIHviBIHYNaubmhEDNZ != 0)
						{
							int num3;
							if (numBytesToRead > bufferLength)
							{
								num = 1189847340;
								num3 = num;
							}
							else
							{
								num = 1189847338;
								num3 = num;
							}
						}
						else
						{
							num = 1189847343;
						}
						continue;
						IL_00d8:
						num2 = ugDapCqSwatVwHFNRCJxFJwpWF.TryReadBytes(buffer, bufferLength, numBytesToRead, (int)SVLFjmJGbsIyYORCwVzAOYbzBGhK);
						if (num2 > 0)
						{
							int num4;
							if (num2 >= numBytesToRead)
							{
								num = 1189847336;
								num4 = num;
							}
							else
							{
								num = 1189847341;
								num4 = num;
							}
						}
						else
						{
							num = 1189847337;
						}
					}
					continue;
					end_IL_0017:
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
			int num4 = default(int);
			while (true)
			{
				int num2 = -2083746552;
				while (true)
				{
					switch (num2 ^ -2083746545)
					{
					case 0:
						break;
					case 2:
						if (num4 <= 0)
						{
							return 0;
						}
						if (num4 < numBytesToRead)
						{
							num4 += ugDapCqSwatVwHFNRCJxFJwpWF.TryReadBytes(buffer, numBytesToRead - num4, 0, num4);
							num2 = -2083746551;
							continue;
						}
						goto default;
					case 4:
						if (numBytesToRead > 0)
						{
							if (CIuxKSRkFIHviBIHYNaubmhEDNZ == 0)
							{
								num2 = -2083746550;
								continue;
							}
							if (numBytesToRead > num)
							{
								numBytesToRead = num;
								num2 = -2083746546;
								continue;
							}
							goto case 1;
						}
						goto case 5;
					case 7:
					{
						int num3;
						if (num <= 0)
						{
							num2 = -2083746550;
							num3 = num2;
						}
						else
						{
							num2 = -2083746549;
							num3 = num2;
						}
						continue;
					}
					case 1:
						if (numBytesToRead > CIuxKSRkFIHviBIHYNaubmhEDNZ)
						{
							numBytesToRead = CIuxKSRkFIHviBIHYNaubmhEDNZ;
							num2 = -2083746548;
							continue;
						}
						goto case 3;
					case 3:
						num4 = ugDapCqSwatVwHFNRCJxFJwpWF.TryReadBytes(buffer, numBytesToRead, (int)SVLFjmJGbsIyYORCwVzAOYbzBGhK);
						num2 = -2083746547;
						continue;
					case 5:
						return 0;
					default:
						EndqasNJqPLdoTQweczoxHQENDH(num4);
						return num4;
					}
					break;
				}
			}
		}

		public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
		{
			if (!(buffer == IntPtr.Zero) && bufferLength > 0)
			{
				int num2 = default(int);
				while (true)
				{
					int num = 1381042341;
					while (true)
					{
						switch (num ^ 0x525108A3)
						{
						case 0:
							break;
						case 3:
							goto IL_0046;
						case 5:
							goto end_IL_0011;
						case 6:
							goto IL_006e;
						case 2:
							goto IL_008b;
						case 7:
							goto IL_00a4;
						case 4:
							goto IL_00b8;
						default:
							goto IL_00f3;
						}
						break;
						IL_00a4:
						if (readStartIndex < qvddhAEohNgcpXDiHojyOjpuJQDJ)
						{
							if (numBytesToRead > bufferLength)
							{
								numBytesToRead = bufferLength;
								num = 1381042336;
								continue;
							}
							goto IL_0046;
						}
						num = 1381042342;
						continue;
						IL_00b8:
						num2 = ugDapCqSwatVwHFNRCJxFJwpWF.TryReadBytes(buffer, bufferLength, numBytesToRead, readStartIndex);
						if (num2 <= 0)
						{
							return 0;
						}
						if (num2 < numBytesToRead)
						{
							num2 += ugDapCqSwatVwHFNRCJxFJwpWF.TryReadBytes(buffer, bufferLength, numBytesToRead - num2, 0, num2);
							num = 1381042338;
							continue;
						}
						goto IL_00f3;
						IL_006e:
						if (numBytesToRead <= 0)
						{
							goto end_IL_0011;
						}
						int num3;
						if (CIuxKSRkFIHviBIHYNaubmhEDNZ == 0)
						{
							num = 1381042342;
							num3 = num;
						}
						else
						{
							num = 1381042337;
							num3 = num;
						}
						continue;
						IL_0046:
						if (numBytesToRead > CIuxKSRkFIHviBIHYNaubmhEDNZ)
						{
							numBytesToRead = CIuxKSRkFIHviBIHYNaubmhEDNZ;
							num = 1381042343;
							continue;
						}
						goto IL_00b8;
						IL_008b:
						int num4;
						if (readStartIndex < 0)
						{
							num = 1381042342;
							num4 = num;
						}
						else
						{
							num = 1381042340;
							num4 = num;
						}
						continue;
						IL_00f3:
						return num2;
					}
					continue;
					end_IL_0011:
					break;
				}
			}
			return 0;
		}

		public int RandomRead(byte[] buffer, int numBytesToRead, int readStartIndex)
		{
			if (buffer == null)
			{
				goto IL_0003;
			}
			int num = buffer.Length;
			int num2 = -1317302899;
			goto IL_0008;
			IL_0008:
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ -1317302902)
				{
				case 4:
					break;
				case 2:
					if (numBytesToRead > CIuxKSRkFIHviBIHYNaubmhEDNZ)
					{
						numBytesToRead = CIuxKSRkFIHviBIHYNaubmhEDNZ;
						num2 = -1317302902;
						continue;
					}
					goto case 0;
				case 7:
				{
					int num5;
					if (num <= 0)
					{
						num2 = -1317302903;
						num5 = num2;
					}
					else
					{
						num2 = -1317302897;
						num5 = num2;
					}
					continue;
				}
				case 6:
					if (readStartIndex >= 0)
					{
						if (readStartIndex >= qvddhAEohNgcpXDiHojyOjpuJQDJ)
						{
							num2 = -1317302903;
							continue;
						}
						if (numBytesToRead > num)
						{
							numBytesToRead = num;
							num2 = -1317302904;
							continue;
						}
						goto case 2;
					}
					goto case 3;
				case 8:
					return 0;
				case 5:
					if (numBytesToRead > 0)
					{
						int num3;
						if (CIuxKSRkFIHviBIHYNaubmhEDNZ == 0)
						{
							num2 = -1317302903;
							num3 = num2;
						}
						else
						{
							num2 = -1317302900;
							num3 = num2;
						}
						continue;
					}
					goto case 3;
				case 3:
					return 0;
				case 0:
					num4 = ugDapCqSwatVwHFNRCJxFJwpWF.TryReadBytes(buffer, numBytesToRead, readStartIndex);
					if (num4 <= 0)
					{
						return 0;
					}
					if (num4 < numBytesToRead)
					{
						num4 += ugDapCqSwatVwHFNRCJxFJwpWF.TryReadBytes(buffer, numBytesToRead - num4, 0, num4);
						num2 = -1317302901;
						continue;
					}
					goto default;
				default:
					return num4;
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num2 = -1317302910;
			goto IL_0008;
		}

		public bool IsValid(int startIndex, uint passId)
		{
			int num;
			if (startIndex >= 0)
			{
				if (startIndex >= qvddhAEohNgcpXDiHojyOjpuJQDJ)
				{
					goto IL_000d;
				}
				if (startIndex < HGJurFfjNjfGCFYRWxDZnGCAEjO)
				{
					num = -232685564;
				}
				else
				{
					if (startIndex < HGJurFfjNjfGCFYRWxDZnGCAEjO)
					{
						goto IL_0080;
					}
					num = -232685562;
				}
				goto IL_0012;
			}
			goto IL_0033;
			IL_0012:
			while (true)
			{
				switch (num ^ -232685561)
				{
				case 4:
					break;
				case 2:
					goto IL_0033;
				case 3:
					goto IL_0046;
				case 1:
					goto IL_0062;
				default:
					return true;
				}
				break;
				IL_0062:
				if (xRldAneDJZPOxiRSIjjhSfMkuvBD == 0)
				{
					return false;
				}
				if (xRldAneDJZPOxiRSIjjhSfMkuvBD - 1 == passId)
				{
					num = -232685561;
					continue;
				}
				goto IL_0080;
				IL_0046:
				if (passId == xRldAneDJZPOxiRSIjjhSfMkuvBD)
				{
					return true;
				}
				goto IL_0080;
			}
			goto IL_000d;
			IL_000d:
			num = -232685563;
			goto IL_0012;
			IL_0033:
			return false;
			IL_0080:
			return false;
		}

		public void Reset()
		{
			HGJurFfjNjfGCFYRWxDZnGCAEjO = 0L;
			while (true)
			{
				int num = 924506627;
				while (true)
				{
					switch (num ^ 0x371ADA02)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						SVLFjmJGbsIyYORCwVzAOYbzBGhK = 0L;
						num = 924506626;
						continue;
					case 0:
						CIuxKSRkFIHviBIHYNaubmhEDNZ = 0;
						ygniihRIePHpdIcxueMrXGayAqg = false;
						xRldAneDJZPOxiRSIjjhSfMkuvBD = 0u;
						num = 924506625;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void wWhpWVuQBxvgSMVTeUNQuWzRBwG(int P_0)
		{
			if (P_0 <= 0)
			{
				goto IL_0007;
			}
			goto IL_00b3;
			IL_0007:
			int num = 1136178299;
			goto IL_000c;
			IL_000c:
			int num2 = default(int);
			bool flag = default(bool);
			while (true)
			{
				switch (num ^ 0x43B8B470)
				{
				case 9:
					break;
				case 11:
					return;
				case 3:
					if (num2 > SVLFjmJGbsIyYORCwVzAOYbzBGhK)
					{
						goto IL_0065;
					}
					goto case 6;
				case 5:
					num = 1136178288;
					continue;
				case 12:
					if (HGJurFfjNjfGCFYRWxDZnGCAEjO > SVLFjmJGbsIyYORCwVzAOYbzBGhK)
					{
						flag = true;
						num = 1136178293;
						continue;
					}
					goto IL_0195;
				case 10:
					goto IL_00b3;
				case 2:
					if (HGJurFfjNjfGCFYRWxDZnGCAEjO >= qvddhAEohNgcpXDiHojyOjpuJQDJ)
					{
						HGJurFfjNjfGCFYRWxDZnGCAEjO -= qvddhAEohNgcpXDiHojyOjpuJQDJ;
						AChcSiHGLWRHeZCufqxfOXlDvCS();
						num = 1136178296;
						continue;
					}
					goto default;
				case 6:
					if (CIuxKSRkFIHviBIHYNaubmhEDNZ > 0)
					{
						flag = true;
						num = 1136178288;
						continue;
					}
					goto IL_0195;
				case 7:
					SVLFjmJGbsIyYORCwVzAOYbzBGhK -= qvddhAEohNgcpXDiHojyOjpuJQDJ;
					num = 1136178290;
					continue;
				case 4:
					goto IL_0153;
				case 1:
					flag = true;
					num = 1136178288;
					continue;
				case 0:
					goto IL_0195;
				default:
					CIuxKSRkFIHviBIHYNaubmhEDNZ = (int)MathTools.Clamp((long)CIuxKSRkFIHviBIHYNaubmhEDNZ + (long)P_0, 0L, qvddhAEohNgcpXDiHojyOjpuJQDJ);
					return;
				}
				break;
				IL_0153:
				ygniihRIePHpdIcxueMrXGayAqg = true;
				SVLFjmJGbsIyYORCwVzAOYbzBGhK = HGJurFfjNjfGCFYRWxDZnGCAEjO;
				int num3;
				if (SVLFjmJGbsIyYORCwVzAOYbzBGhK >= qvddhAEohNgcpXDiHojyOjpuJQDJ)
				{
					num = 1136178295;
					num3 = num;
				}
				else
				{
					num = 1136178290;
					num3 = num;
				}
				continue;
				IL_0065:
				int num4;
				if (HGJurFfjNjfGCFYRWxDZnGCAEjO - qvddhAEohNgcpXDiHojyOjpuJQDJ <= SVLFjmJGbsIyYORCwVzAOYbzBGhK)
				{
					num = 1136178288;
					num4 = num;
				}
				else
				{
					num = 1136178289;
					num4 = num;
				}
				continue;
				IL_0195:
				int num5;
				if (!flag)
				{
					num = 1136178290;
					num5 = num;
				}
				else
				{
					num = 1136178292;
					num5 = num;
				}
			}
			goto IL_0007;
			IL_00b3:
			num2 = (int)HGJurFfjNjfGCFYRWxDZnGCAEjO;
			HGJurFfjNjfGCFYRWxDZnGCAEjO += P_0;
			flag = false;
			int num6;
			if (num2 >= SVLFjmJGbsIyYORCwVzAOYbzBGhK)
			{
				num = 1136178291;
				num6 = num;
			}
			else
			{
				num = 1136178300;
				num6 = num;
			}
			goto IL_000c;
		}

		private void EndqasNJqPLdoTQweczoxHQENDH(int P_0)
		{
			if (P_0 <= 0)
			{
				return;
			}
			while (true)
			{
				int num;
				if (ygniihRIePHpdIcxueMrXGayAqg)
				{
					ygniihRIePHpdIcxueMrXGayAqg = false;
					num = -2046732994;
					goto IL_000a;
				}
				goto IL_005c;
				IL_000a:
				while (true)
				{
					switch (num ^ -2046732998)
					{
					case 3:
						num = -2046733000;
						continue;
					case 2:
						break;
					case 0:
						SVLFjmJGbsIyYORCwVzAOYbzBGhK -= qvddhAEohNgcpXDiHojyOjpuJQDJ;
						num = -2046732997;
						continue;
					case 4:
						goto IL_005c;
					default:
					{
						long num2 = (long)CIuxKSRkFIHviBIHYNaubmhEDNZ - (long)P_0;
						CIuxKSRkFIHviBIHYNaubmhEDNZ = (int)((num2 >= 0) ? num2 : 0);
						return;
					}
					}
					break;
				}
				continue;
				IL_005c:
				SVLFjmJGbsIyYORCwVzAOYbzBGhK += P_0;
				int num3;
				if (SVLFjmJGbsIyYORCwVzAOYbzBGhK < qvddhAEohNgcpXDiHojyOjpuJQDJ)
				{
					num = -2046732997;
					num3 = num;
				}
				else
				{
					num = -2046732998;
					num3 = num;
				}
				goto IL_000a;
			}
		}

		private void AChcSiHGLWRHeZCufqxfOXlDvCS()
		{
			if (xRldAneDJZPOxiRSIjjhSfMkuvBD == uint.MaxValue)
			{
				while (true)
				{
					switch (-2040516838 ^ -2040516840)
					{
					case 0:
						continue;
					case 2:
						xRldAneDJZPOxiRSIjjhSfMkuvBD = 0u;
						return;
					}
					break;
				}
			}
			xRldAneDJZPOxiRSIjjhSfMkuvBD++;
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
			if (QQqHByfwytAJSuMZiCPjJlZYHKG)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (disposing)
				{
					num = -1798090498;
					num2 = num;
				}
				else
				{
					num = -1798090501;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1798090497)
					{
					case 0:
						num = -1798090500;
						continue;
					default:
						return;
					case 3:
						break;
					case 1:
					{
						int num3;
						if (ugDapCqSwatVwHFNRCJxFJwpWF == null)
						{
							num = -1798090501;
							num3 = num;
						}
						else
						{
							num = -1798090499;
							num3 = num;
						}
						continue;
					}
					case 2:
						ugDapCqSwatVwHFNRCJxFJwpWF.Dispose();
						num = -1798090501;
						continue;
					case 4:
						QQqHByfwytAJSuMZiCPjJlZYHKG = true;
						num = -1798090502;
						continue;
					case 5:
						return;
					}
					break;
				}
			}
		}
	}
}
