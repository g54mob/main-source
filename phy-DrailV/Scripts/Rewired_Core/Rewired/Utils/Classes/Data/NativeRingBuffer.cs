using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class NativeRingBuffer : IDisposable
	{
		private readonly NativeBuffer AZhOpEySqnsCppTWoSwmihdKNPNM;

		private readonly int WjcVbvWkFCKGROUlyUKFoxBEwNHJ;

		private long lrODEeXOlwbTmYRKxsQmyNqeAHUN;

		private long yZURCDsUBnCxqEpRZIZtJgLZkkfg;

		private int wnfaOnbafXPXEUHUlATHqoJuYlFM;

		private bool CbmlKAfBEGubDPAgRORSAySCLsys;

		private uint TwwgaOtYbKqoFKOPEOgAwKmWXQHf;

		private bool wFtxnVROnubhehGUBaPWAtQsiPAD;

		public int Capacity => WjcVbvWkFCKGROUlyUKFoxBEwNHJ;

		public int BytesInBuffer => wnfaOnbafXPXEUHUlATHqoJuYlFM;

		public bool BufferOverrun => CbmlKAfBEGubDPAgRORSAySCLsys;

		public int ReadPosition => (int)yZURCDsUBnCxqEpRZIZtJgLZkkfg;

		public long WritePosition => lrODEeXOlwbTmYRKxsQmyNqeAHUN;

		public NativeRingBuffer(int P_0)
		{
			WjcVbvWkFCKGROUlyUKFoxBEwNHJ = P_0;
			if (P_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("sizeInBytes");
			}
			AZhOpEySqnsCppTWoSwmihdKNPNM = new NativeBuffer(P_0);
		}

		public IntPtr Allocate(int bufferLength, bool zeroFill, out uint passId)
		{
			IntPtr pointer = AZhOpEySqnsCppTWoSwmihdKNPNM.GetPointer((int)lrODEeXOlwbTmYRKxsQmyNqeAHUN);
			passId = TwwgaOtYbKqoFKOPEOgAwKmWXQHf;
			if (zeroFill)
			{
				int num = 0;
				AZhOpEySqnsCppTWoSwmihdKNPNM.TryFill(0, bufferLength, (int)lrODEeXOlwbTmYRKxsQmyNqeAHUN);
				if (num == 0)
				{
					return IntPtr.Zero;
				}
				if (num < bufferLength)
				{
					num += AZhOpEySqnsCppTWoSwmihdKNPNM.TryFill(0, bufferLength - num, num);
				}
			}
			ESaEVuiMrcMBuHJEVudhGxLtVfATA(bufferLength);
			return pointer;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)lrODEeXOlwbTmYRKxsQmyNqeAHUN;
			passId = TwwgaOtYbKqoFKOPEOgAwKmWXQHf;
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0)
			{
				return 0;
			}
			if (numBytesToWrite > bufferLength)
			{
				numBytesToWrite = bufferLength;
			}
			int num = AZhOpEySqnsCppTWoSwmihdKNPNM.TryWriteBytes(buffer, bufferLength, numBytesToWrite, (int)lrODEeXOlwbTmYRKxsQmyNqeAHUN);
			if (num == 0)
			{
				return 0;
			}
			if (num < numBytesToWrite)
			{
				num += AZhOpEySqnsCppTWoSwmihdKNPNM.TryWriteBytes(buffer, bufferLength, numBytesToWrite - num, 0, num);
			}
			ESaEVuiMrcMBuHJEVudhGxLtVfATA(num);
			return num;
		}

		public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)lrODEeXOlwbTmYRKxsQmyNqeAHUN;
			passId = TwwgaOtYbKqoFKOPEOgAwKmWXQHf;
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToWrite <= 0)
			{
				return 0;
			}
			if (numBytesToWrite > num)
			{
				numBytesToWrite = num;
			}
			int num2 = AZhOpEySqnsCppTWoSwmihdKNPNM.TryWriteBytes(buffer, numBytesToWrite, (int)lrODEeXOlwbTmYRKxsQmyNqeAHUN);
			if (num2 == 0)
			{
				return 0;
			}
			if (num2 < numBytesToWrite)
			{
				num2 += AZhOpEySqnsCppTWoSwmihdKNPNM.TryWriteBytes(buffer, numBytesToWrite - num2, 0, num2);
			}
			ESaEVuiMrcMBuHJEVudhGxLtVfATA(num2);
			return num2;
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
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || wnfaOnbafXPXEUHUlATHqoJuYlFM == 0)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > wnfaOnbafXPXEUHUlATHqoJuYlFM)
			{
				numBytesToRead = wnfaOnbafXPXEUHUlATHqoJuYlFM;
			}
			int num = AZhOpEySqnsCppTWoSwmihdKNPNM.TryReadBytes(buffer, bufferLength, numBytesToRead, (int)yZURCDsUBnCxqEpRZIZtJgLZkkfg);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += AZhOpEySqnsCppTWoSwmihdKNPNM.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
			}
			mAwYRUxKTITALKdqRIVmosvonNTB(num);
			return num;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToRead <= 0 || wnfaOnbafXPXEUHUlATHqoJuYlFM == 0)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > wnfaOnbafXPXEUHUlATHqoJuYlFM)
			{
				numBytesToRead = wnfaOnbafXPXEUHUlATHqoJuYlFM;
			}
			int num2 = AZhOpEySqnsCppTWoSwmihdKNPNM.TryReadBytes(buffer, numBytesToRead, (int)yZURCDsUBnCxqEpRZIZtJgLZkkfg);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += AZhOpEySqnsCppTWoSwmihdKNPNM.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
			}
			mAwYRUxKTITALKdqRIVmosvonNTB(num2);
			return num2;
		}

		public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
		{
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || wnfaOnbafXPXEUHUlATHqoJuYlFM == 0 || readStartIndex < 0 || readStartIndex >= WjcVbvWkFCKGROUlyUKFoxBEwNHJ)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > wnfaOnbafXPXEUHUlATHqoJuYlFM)
			{
				numBytesToRead = wnfaOnbafXPXEUHUlATHqoJuYlFM;
			}
			int num = AZhOpEySqnsCppTWoSwmihdKNPNM.TryReadBytes(buffer, bufferLength, numBytesToRead, readStartIndex);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += AZhOpEySqnsCppTWoSwmihdKNPNM.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
			}
			return num;
		}

		public int RandomRead(byte[] buffer, int numBytesToRead, int readStartIndex)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToRead <= 0 || wnfaOnbafXPXEUHUlATHqoJuYlFM == 0 || readStartIndex < 0 || readStartIndex >= WjcVbvWkFCKGROUlyUKFoxBEwNHJ)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > wnfaOnbafXPXEUHUlATHqoJuYlFM)
			{
				numBytesToRead = wnfaOnbafXPXEUHUlATHqoJuYlFM;
			}
			int num2 = AZhOpEySqnsCppTWoSwmihdKNPNM.TryReadBytes(buffer, numBytesToRead, readStartIndex);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += AZhOpEySqnsCppTWoSwmihdKNPNM.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
			}
			return num2;
		}

		public IntPtr GetPointerFromReadPosition(int offset)
		{
			int offsetFromReadPosition = GetOffsetFromReadPosition(offset);
			if (offsetFromReadPosition < 0)
			{
				return IntPtr.Zero;
			}
			return AZhOpEySqnsCppTWoSwmihdKNPNM.GetPointer(offsetFromReadPosition);
		}

		public int GetOffsetFromReadPosition(int offset)
		{
			int num = (int)yZURCDsUBnCxqEpRZIZtJgLZkkfg + offset;
			if (num >= WjcVbvWkFCKGROUlyUKFoxBEwNHJ)
			{
				num -= WjcVbvWkFCKGROUlyUKFoxBEwNHJ;
			}
			else if (num < 0)
			{
				num += WjcVbvWkFCKGROUlyUKFoxBEwNHJ;
			}
			if (num < 0 || num >= WjcVbvWkFCKGROUlyUKFoxBEwNHJ)
			{
				return -1;
			}
			return num;
		}

		public bool IsValid(int startIndex, uint passId)
		{
			if (startIndex < 0 || startIndex >= WjcVbvWkFCKGROUlyUKFoxBEwNHJ)
			{
				return false;
			}
			if (startIndex < lrODEeXOlwbTmYRKxsQmyNqeAHUN)
			{
				if (passId == TwwgaOtYbKqoFKOPEOgAwKmWXQHf)
				{
					return true;
				}
			}
			else if (startIndex >= lrODEeXOlwbTmYRKxsQmyNqeAHUN)
			{
				if (TwwgaOtYbKqoFKOPEOgAwKmWXQHf == 0)
				{
					return false;
				}
				if (TwwgaOtYbKqoFKOPEOgAwKmWXQHf - 1 == passId)
				{
					return true;
				}
			}
			return false;
		}

		public void CopyFrom(NativeRingBuffer other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (WjcVbvWkFCKGROUlyUKFoxBEwNHJ != other.WjcVbvWkFCKGROUlyUKFoxBEwNHJ)
			{
				throw new Exception("Buffer does not have the same capacity. Cannot copy.");
			}
			lrODEeXOlwbTmYRKxsQmyNqeAHUN = other.lrODEeXOlwbTmYRKxsQmyNqeAHUN;
			yZURCDsUBnCxqEpRZIZtJgLZkkfg = other.yZURCDsUBnCxqEpRZIZtJgLZkkfg;
			wnfaOnbafXPXEUHUlATHqoJuYlFM = other.wnfaOnbafXPXEUHUlATHqoJuYlFM;
			CbmlKAfBEGubDPAgRORSAySCLsys = other.CbmlKAfBEGubDPAgRORSAySCLsys;
			TwwgaOtYbKqoFKOPEOgAwKmWXQHf = other.TwwgaOtYbKqoFKOPEOgAwKmWXQHf;
			AZhOpEySqnsCppTWoSwmihdKNPNM.CopyFrom(other.AZhOpEySqnsCppTWoSwmihdKNPNM);
		}

		public void Reset()
		{
			lrODEeXOlwbTmYRKxsQmyNqeAHUN = 0L;
			yZURCDsUBnCxqEpRZIZtJgLZkkfg = 0L;
			wnfaOnbafXPXEUHUlATHqoJuYlFM = 0;
			CbmlKAfBEGubDPAgRORSAySCLsys = false;
			TwwgaOtYbKqoFKOPEOgAwKmWXQHf = 0u;
		}

		private void ESaEVuiMrcMBuHJEVudhGxLtVfATA(int P_0)
		{
			if (P_0 <= 0)
			{
				return;
			}
			int num = (int)lrODEeXOlwbTmYRKxsQmyNqeAHUN;
			lrODEeXOlwbTmYRKxsQmyNqeAHUN += P_0;
			bool flag = false;
			if (num < yZURCDsUBnCxqEpRZIZtJgLZkkfg)
			{
				if (lrODEeXOlwbTmYRKxsQmyNqeAHUN > yZURCDsUBnCxqEpRZIZtJgLZkkfg)
				{
					flag = true;
				}
			}
			else if (num > yZURCDsUBnCxqEpRZIZtJgLZkkfg)
			{
				if (lrODEeXOlwbTmYRKxsQmyNqeAHUN - WjcVbvWkFCKGROUlyUKFoxBEwNHJ > yZURCDsUBnCxqEpRZIZtJgLZkkfg)
				{
					flag = true;
				}
			}
			else if (wnfaOnbafXPXEUHUlATHqoJuYlFM > 0)
			{
				flag = true;
			}
			if (flag)
			{
				CbmlKAfBEGubDPAgRORSAySCLsys = true;
				yZURCDsUBnCxqEpRZIZtJgLZkkfg = lrODEeXOlwbTmYRKxsQmyNqeAHUN;
				if (yZURCDsUBnCxqEpRZIZtJgLZkkfg >= WjcVbvWkFCKGROUlyUKFoxBEwNHJ)
				{
					yZURCDsUBnCxqEpRZIZtJgLZkkfg -= WjcVbvWkFCKGROUlyUKFoxBEwNHJ;
				}
			}
			if (lrODEeXOlwbTmYRKxsQmyNqeAHUN >= WjcVbvWkFCKGROUlyUKFoxBEwNHJ)
			{
				lrODEeXOlwbTmYRKxsQmyNqeAHUN -= WjcVbvWkFCKGROUlyUKFoxBEwNHJ;
				cWaEUNbqlBOhYUJjQcHSJbHpVXIv();
			}
			wnfaOnbafXPXEUHUlATHqoJuYlFM = (int)MathTools.Clamp((long)wnfaOnbafXPXEUHUlATHqoJuYlFM + (long)P_0, 0L, WjcVbvWkFCKGROUlyUKFoxBEwNHJ);
		}

		private void mAwYRUxKTITALKdqRIVmosvonNTB(int P_0)
		{
			if (P_0 > 0)
			{
				if (CbmlKAfBEGubDPAgRORSAySCLsys)
				{
					CbmlKAfBEGubDPAgRORSAySCLsys = false;
				}
				yZURCDsUBnCxqEpRZIZtJgLZkkfg += P_0;
				if (yZURCDsUBnCxqEpRZIZtJgLZkkfg >= WjcVbvWkFCKGROUlyUKFoxBEwNHJ)
				{
					yZURCDsUBnCxqEpRZIZtJgLZkkfg -= WjcVbvWkFCKGROUlyUKFoxBEwNHJ;
				}
				long num = (long)wnfaOnbafXPXEUHUlATHqoJuYlFM - (long)P_0;
				wnfaOnbafXPXEUHUlATHqoJuYlFM = (int)((num >= 0) ? num : 0);
			}
		}

		private void cWaEUNbqlBOhYUJjQcHSJbHpVXIv()
		{
			if (TwwgaOtYbKqoFKOPEOgAwKmWXQHf == uint.MaxValue)
			{
				TwwgaOtYbKqoFKOPEOgAwKmWXQHf = 0u;
			}
			else
			{
				TwwgaOtYbKqoFKOPEOgAwKmWXQHf++;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~NativeRingBuffer()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!wFtxnVROnubhehGUBaPWAtQsiPAD)
			{
				if (disposing && AZhOpEySqnsCppTWoSwmihdKNPNM != null)
				{
					AZhOpEySqnsCppTWoSwmihdKNPNM.Dispose();
				}
				wFtxnVROnubhehGUBaPWAtQsiPAD = true;
			}
		}
	}
}
