using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class NativeRingBuffer : IDisposable
	{
		private readonly NativeBuffer rFLAGvDUpBFmqIrakAVIcTSKRJFP;

		private readonly int doAsGrtKlisSXEPfwnlOTedRuDB;

		private long MIcZtDgkaImthEFarIlCJxPvcFMI;

		private long BNcoBgHGiRitlKpdPduVqaYOeRr;

		private int NHHRlQEKkljXRWgajymtXtyvtMZ;

		private bool pmKWzdEwJavBSNoCTlsqxjlFDsgB;

		private uint iKSPdEKsNcQKeKtUIraTVHCDHDv;

		private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

		public int Capacity => doAsGrtKlisSXEPfwnlOTedRuDB;

		public int BytesInBuffer => NHHRlQEKkljXRWgajymtXtyvtMZ;

		public bool BufferOverrun => pmKWzdEwJavBSNoCTlsqxjlFDsgB;

		public int ReadPosition => (int)BNcoBgHGiRitlKpdPduVqaYOeRr;

		public long WritePosition => MIcZtDgkaImthEFarIlCJxPvcFMI;

		public NativeRingBuffer(int capacity)
		{
			doAsGrtKlisSXEPfwnlOTedRuDB = capacity;
			if (capacity <= 0)
			{
				throw new ArgumentOutOfRangeException("sizeInBytes");
			}
			rFLAGvDUpBFmqIrakAVIcTSKRJFP = new NativeBuffer(capacity);
		}

		public IntPtr Allocate(int bufferLength, bool zeroFill, out uint passId)
		{
			IntPtr pointer = rFLAGvDUpBFmqIrakAVIcTSKRJFP.GetPointer((int)MIcZtDgkaImthEFarIlCJxPvcFMI);
			passId = iKSPdEKsNcQKeKtUIraTVHCDHDv;
			if (zeroFill)
			{
				int num = 0;
				rFLAGvDUpBFmqIrakAVIcTSKRJFP.TryFill(0, bufferLength, (int)MIcZtDgkaImthEFarIlCJxPvcFMI);
				if (num == 0)
				{
					return IntPtr.Zero;
				}
				if (num < bufferLength)
				{
					num += rFLAGvDUpBFmqIrakAVIcTSKRJFP.TryFill(0, bufferLength - num, num);
				}
			}
			pwGqmJzauWmpvLpcHGQJeEacazGz(bufferLength);
			return pointer;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)MIcZtDgkaImthEFarIlCJxPvcFMI;
			passId = iKSPdEKsNcQKeKtUIraTVHCDHDv;
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0)
			{
				return 0;
			}
			if (numBytesToWrite > bufferLength)
			{
				numBytesToWrite = bufferLength;
			}
			int num = rFLAGvDUpBFmqIrakAVIcTSKRJFP.TryWriteBytes(buffer, bufferLength, numBytesToWrite, (int)MIcZtDgkaImthEFarIlCJxPvcFMI);
			if (num == 0)
			{
				return 0;
			}
			if (num < numBytesToWrite)
			{
				num += rFLAGvDUpBFmqIrakAVIcTSKRJFP.TryWriteBytes(buffer, bufferLength, numBytesToWrite - num, 0, num);
			}
			pwGqmJzauWmpvLpcHGQJeEacazGz(num);
			return num;
		}

		public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)MIcZtDgkaImthEFarIlCJxPvcFMI;
			passId = iKSPdEKsNcQKeKtUIraTVHCDHDv;
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
			int num2 = rFLAGvDUpBFmqIrakAVIcTSKRJFP.TryWriteBytes(buffer, numBytesToWrite, (int)MIcZtDgkaImthEFarIlCJxPvcFMI);
			if (num2 == 0)
			{
				return 0;
			}
			if (num2 < numBytesToWrite)
			{
				num2 += rFLAGvDUpBFmqIrakAVIcTSKRJFP.TryWriteBytes(buffer, numBytesToWrite - num2, 0, num2);
			}
			pwGqmJzauWmpvLpcHGQJeEacazGz(num2);
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
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || NHHRlQEKkljXRWgajymtXtyvtMZ == 0)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > NHHRlQEKkljXRWgajymtXtyvtMZ)
			{
				numBytesToRead = NHHRlQEKkljXRWgajymtXtyvtMZ;
			}
			int num = rFLAGvDUpBFmqIrakAVIcTSKRJFP.TryReadBytes(buffer, bufferLength, numBytesToRead, (int)BNcoBgHGiRitlKpdPduVqaYOeRr);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += rFLAGvDUpBFmqIrakAVIcTSKRJFP.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
			}
			NMCxwgMqXojcXAcHFBrdNEHtQrP(num);
			return num;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToRead <= 0 || NHHRlQEKkljXRWgajymtXtyvtMZ == 0)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > NHHRlQEKkljXRWgajymtXtyvtMZ)
			{
				numBytesToRead = NHHRlQEKkljXRWgajymtXtyvtMZ;
			}
			int num2 = rFLAGvDUpBFmqIrakAVIcTSKRJFP.TryReadBytes(buffer, numBytesToRead, (int)BNcoBgHGiRitlKpdPduVqaYOeRr);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += rFLAGvDUpBFmqIrakAVIcTSKRJFP.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
			}
			NMCxwgMqXojcXAcHFBrdNEHtQrP(num2);
			return num2;
		}

		public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
		{
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || NHHRlQEKkljXRWgajymtXtyvtMZ == 0 || readStartIndex < 0 || readStartIndex >= doAsGrtKlisSXEPfwnlOTedRuDB)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > NHHRlQEKkljXRWgajymtXtyvtMZ)
			{
				numBytesToRead = NHHRlQEKkljXRWgajymtXtyvtMZ;
			}
			int num = rFLAGvDUpBFmqIrakAVIcTSKRJFP.TryReadBytes(buffer, bufferLength, numBytesToRead, readStartIndex);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += rFLAGvDUpBFmqIrakAVIcTSKRJFP.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
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
			if (num <= 0 || numBytesToRead <= 0 || NHHRlQEKkljXRWgajymtXtyvtMZ == 0 || readStartIndex < 0 || readStartIndex >= doAsGrtKlisSXEPfwnlOTedRuDB)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > NHHRlQEKkljXRWgajymtXtyvtMZ)
			{
				numBytesToRead = NHHRlQEKkljXRWgajymtXtyvtMZ;
			}
			int num2 = rFLAGvDUpBFmqIrakAVIcTSKRJFP.TryReadBytes(buffer, numBytesToRead, readStartIndex);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += rFLAGvDUpBFmqIrakAVIcTSKRJFP.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
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
			return rFLAGvDUpBFmqIrakAVIcTSKRJFP.GetPointer(offsetFromReadPosition);
		}

		public int GetOffsetFromReadPosition(int offset)
		{
			int num = (int)BNcoBgHGiRitlKpdPduVqaYOeRr + offset;
			if (num >= doAsGrtKlisSXEPfwnlOTedRuDB)
			{
				num -= doAsGrtKlisSXEPfwnlOTedRuDB;
			}
			else if (num < 0)
			{
				num += doAsGrtKlisSXEPfwnlOTedRuDB;
			}
			if (num < 0 || num >= doAsGrtKlisSXEPfwnlOTedRuDB)
			{
				return -1;
			}
			return num;
		}

		public bool IsValid(int startIndex, uint passId)
		{
			if (startIndex < 0 || startIndex >= doAsGrtKlisSXEPfwnlOTedRuDB)
			{
				return false;
			}
			if (startIndex < MIcZtDgkaImthEFarIlCJxPvcFMI)
			{
				if (passId == iKSPdEKsNcQKeKtUIraTVHCDHDv)
				{
					return true;
				}
			}
			else if (startIndex >= MIcZtDgkaImthEFarIlCJxPvcFMI)
			{
				if (iKSPdEKsNcQKeKtUIraTVHCDHDv == 0)
				{
					return false;
				}
				if (iKSPdEKsNcQKeKtUIraTVHCDHDv - 1 == passId)
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
			if (doAsGrtKlisSXEPfwnlOTedRuDB != other.doAsGrtKlisSXEPfwnlOTedRuDB)
			{
				throw new Exception("Buffer does not have the same capacity. Cannot copy.");
			}
			MIcZtDgkaImthEFarIlCJxPvcFMI = other.MIcZtDgkaImthEFarIlCJxPvcFMI;
			BNcoBgHGiRitlKpdPduVqaYOeRr = other.BNcoBgHGiRitlKpdPduVqaYOeRr;
			NHHRlQEKkljXRWgajymtXtyvtMZ = other.NHHRlQEKkljXRWgajymtXtyvtMZ;
			pmKWzdEwJavBSNoCTlsqxjlFDsgB = other.pmKWzdEwJavBSNoCTlsqxjlFDsgB;
			iKSPdEKsNcQKeKtUIraTVHCDHDv = other.iKSPdEKsNcQKeKtUIraTVHCDHDv;
			rFLAGvDUpBFmqIrakAVIcTSKRJFP.CopyFrom(other.rFLAGvDUpBFmqIrakAVIcTSKRJFP);
		}

		public void Reset()
		{
			MIcZtDgkaImthEFarIlCJxPvcFMI = 0L;
			BNcoBgHGiRitlKpdPduVqaYOeRr = 0L;
			NHHRlQEKkljXRWgajymtXtyvtMZ = 0;
			pmKWzdEwJavBSNoCTlsqxjlFDsgB = false;
			iKSPdEKsNcQKeKtUIraTVHCDHDv = 0u;
		}

		private void pwGqmJzauWmpvLpcHGQJeEacazGz(int P_0)
		{
			if (P_0 <= 0)
			{
				return;
			}
			int num = (int)MIcZtDgkaImthEFarIlCJxPvcFMI;
			MIcZtDgkaImthEFarIlCJxPvcFMI += P_0;
			bool flag = false;
			if (num < BNcoBgHGiRitlKpdPduVqaYOeRr)
			{
				if (MIcZtDgkaImthEFarIlCJxPvcFMI > BNcoBgHGiRitlKpdPduVqaYOeRr)
				{
					flag = true;
				}
			}
			else if (num > BNcoBgHGiRitlKpdPduVqaYOeRr)
			{
				if (MIcZtDgkaImthEFarIlCJxPvcFMI - doAsGrtKlisSXEPfwnlOTedRuDB > BNcoBgHGiRitlKpdPduVqaYOeRr)
				{
					flag = true;
				}
			}
			else if (NHHRlQEKkljXRWgajymtXtyvtMZ > 0)
			{
				flag = true;
			}
			if (flag)
			{
				pmKWzdEwJavBSNoCTlsqxjlFDsgB = true;
				BNcoBgHGiRitlKpdPduVqaYOeRr = MIcZtDgkaImthEFarIlCJxPvcFMI;
				if (BNcoBgHGiRitlKpdPduVqaYOeRr >= doAsGrtKlisSXEPfwnlOTedRuDB)
				{
					BNcoBgHGiRitlKpdPduVqaYOeRr -= doAsGrtKlisSXEPfwnlOTedRuDB;
				}
			}
			if (MIcZtDgkaImthEFarIlCJxPvcFMI >= doAsGrtKlisSXEPfwnlOTedRuDB)
			{
				MIcZtDgkaImthEFarIlCJxPvcFMI -= doAsGrtKlisSXEPfwnlOTedRuDB;
				RdEYdwYNahAHPKzFIouwuCmuCDE();
			}
			NHHRlQEKkljXRWgajymtXtyvtMZ = (int)MathTools.Clamp((long)NHHRlQEKkljXRWgajymtXtyvtMZ + (long)P_0, 0L, doAsGrtKlisSXEPfwnlOTedRuDB);
		}

		private void NMCxwgMqXojcXAcHFBrdNEHtQrP(int P_0)
		{
			if (P_0 > 0)
			{
				if (pmKWzdEwJavBSNoCTlsqxjlFDsgB)
				{
					pmKWzdEwJavBSNoCTlsqxjlFDsgB = false;
				}
				BNcoBgHGiRitlKpdPduVqaYOeRr += P_0;
				if (BNcoBgHGiRitlKpdPduVqaYOeRr >= doAsGrtKlisSXEPfwnlOTedRuDB)
				{
					BNcoBgHGiRitlKpdPduVqaYOeRr -= doAsGrtKlisSXEPfwnlOTedRuDB;
				}
				long num = (long)NHHRlQEKkljXRWgajymtXtyvtMZ - (long)P_0;
				NHHRlQEKkljXRWgajymtXtyvtMZ = (int)((num >= 0) ? num : 0);
			}
		}

		private void RdEYdwYNahAHPKzFIouwuCmuCDE()
		{
			if (iKSPdEKsNcQKeKtUIraTVHCDHDv == uint.MaxValue)
			{
				iKSPdEKsNcQKeKtUIraTVHCDHDv = 0u;
			}
			else
			{
				iKSPdEKsNcQKeKtUIraTVHCDHDv++;
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
			if (!JtZAxieDBYjDdfBgPPJgrNSxYmS)
			{
				if (disposing && rFLAGvDUpBFmqIrakAVIcTSKRJFP != null)
				{
					rFLAGvDUpBFmqIrakAVIcTSKRJFP.Dispose();
				}
				JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
			}
		}
	}
}
