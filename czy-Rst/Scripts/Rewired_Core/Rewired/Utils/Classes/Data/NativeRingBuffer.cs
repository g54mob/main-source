using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeRingBuffer : IDisposable
	{
		private readonly NativeBuffer IzUhUdtIKWZrodPZMyrXjCqwJwBs;

		private readonly int lddzzYAoWDIEPRsFEVOrIEabaPDy;

		private long jLMcHHExdVXAAaVoKuxTPKrOHmab;

		private long hHpJvPtDWvWEFUjqQxhVKvLBrZQG;

		private int BDhMEvWbFKAWECGQcrymITLYMKPB;

		private bool xlRNvIarUTEUFbdbGhHQJtTlKoAG;

		private uint IWGVfNLgvyMjuiwfchsCkCKPCCGo;

		private bool NMKcGLkxNlhRwqGlKpsPcdyDPnjg;

		public int Capacity => lddzzYAoWDIEPRsFEVOrIEabaPDy;

		public int BytesInBuffer => BDhMEvWbFKAWECGQcrymITLYMKPB;

		public bool BufferOverrun => xlRNvIarUTEUFbdbGhHQJtTlKoAG;

		public int ReadPosition => (int)hHpJvPtDWvWEFUjqQxhVKvLBrZQG;

		public long WritePosition => jLMcHHExdVXAAaVoKuxTPKrOHmab;

		public NativeRingBuffer(int P_0)
		{
			lddzzYAoWDIEPRsFEVOrIEabaPDy = P_0;
			if (P_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("sizeInBytes");
			}
			IzUhUdtIKWZrodPZMyrXjCqwJwBs = new NativeBuffer(P_0);
		}

		public IntPtr Allocate(int bufferLength, bool zeroFill, out uint passId)
		{
			IntPtr pointer = IzUhUdtIKWZrodPZMyrXjCqwJwBs.GetPointer((int)jLMcHHExdVXAAaVoKuxTPKrOHmab);
			passId = IWGVfNLgvyMjuiwfchsCkCKPCCGo;
			if (zeroFill)
			{
				int num = 0;
				IzUhUdtIKWZrodPZMyrXjCqwJwBs.TryFill(0, bufferLength, (int)jLMcHHExdVXAAaVoKuxTPKrOHmab);
				if (num == 0)
				{
					return IntPtr.Zero;
				}
				if (num < bufferLength)
				{
					num += IzUhUdtIKWZrodPZMyrXjCqwJwBs.TryFill(0, bufferLength - num, num);
				}
			}
			mCYFjhpmqFfGWGbbtNSCcjZVuCLk(bufferLength);
			return pointer;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)jLMcHHExdVXAAaVoKuxTPKrOHmab;
			passId = IWGVfNLgvyMjuiwfchsCkCKPCCGo;
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0)
			{
				return 0;
			}
			if (numBytesToWrite > bufferLength)
			{
				numBytesToWrite = bufferLength;
			}
			int num = IzUhUdtIKWZrodPZMyrXjCqwJwBs.TryWriteBytes(buffer, bufferLength, numBytesToWrite, (int)jLMcHHExdVXAAaVoKuxTPKrOHmab);
			if (num == 0)
			{
				return 0;
			}
			if (num < numBytesToWrite)
			{
				num += IzUhUdtIKWZrodPZMyrXjCqwJwBs.TryWriteBytes(buffer, bufferLength, numBytesToWrite - num, 0, num);
			}
			mCYFjhpmqFfGWGbbtNSCcjZVuCLk(num);
			return num;
		}

		public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)jLMcHHExdVXAAaVoKuxTPKrOHmab;
			passId = IWGVfNLgvyMjuiwfchsCkCKPCCGo;
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
			int num2 = IzUhUdtIKWZrodPZMyrXjCqwJwBs.TryWriteBytes(buffer, numBytesToWrite, (int)jLMcHHExdVXAAaVoKuxTPKrOHmab);
			if (num2 == 0)
			{
				return 0;
			}
			if (num2 < numBytesToWrite)
			{
				num2 += IzUhUdtIKWZrodPZMyrXjCqwJwBs.TryWriteBytes(buffer, numBytesToWrite - num2, 0, num2);
			}
			mCYFjhpmqFfGWGbbtNSCcjZVuCLk(num2);
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
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || BDhMEvWbFKAWECGQcrymITLYMKPB == 0)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > BDhMEvWbFKAWECGQcrymITLYMKPB)
			{
				numBytesToRead = BDhMEvWbFKAWECGQcrymITLYMKPB;
			}
			int num = IzUhUdtIKWZrodPZMyrXjCqwJwBs.TryReadBytes(buffer, bufferLength, numBytesToRead, (int)hHpJvPtDWvWEFUjqQxhVKvLBrZQG);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += IzUhUdtIKWZrodPZMyrXjCqwJwBs.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
			}
			OfmljFWaDKCMPPjEpXbQhTdtdLcA(num);
			return num;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToRead <= 0 || BDhMEvWbFKAWECGQcrymITLYMKPB == 0)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > BDhMEvWbFKAWECGQcrymITLYMKPB)
			{
				numBytesToRead = BDhMEvWbFKAWECGQcrymITLYMKPB;
			}
			int num2 = IzUhUdtIKWZrodPZMyrXjCqwJwBs.TryReadBytes(buffer, numBytesToRead, (int)hHpJvPtDWvWEFUjqQxhVKvLBrZQG);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += IzUhUdtIKWZrodPZMyrXjCqwJwBs.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
			}
			OfmljFWaDKCMPPjEpXbQhTdtdLcA(num2);
			return num2;
		}

		public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
		{
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || BDhMEvWbFKAWECGQcrymITLYMKPB == 0 || readStartIndex < 0 || readStartIndex >= lddzzYAoWDIEPRsFEVOrIEabaPDy)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > BDhMEvWbFKAWECGQcrymITLYMKPB)
			{
				numBytesToRead = BDhMEvWbFKAWECGQcrymITLYMKPB;
			}
			int num = IzUhUdtIKWZrodPZMyrXjCqwJwBs.TryReadBytes(buffer, bufferLength, numBytesToRead, readStartIndex);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += IzUhUdtIKWZrodPZMyrXjCqwJwBs.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
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
			if (num <= 0 || numBytesToRead <= 0 || BDhMEvWbFKAWECGQcrymITLYMKPB == 0 || readStartIndex < 0 || readStartIndex >= lddzzYAoWDIEPRsFEVOrIEabaPDy)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > BDhMEvWbFKAWECGQcrymITLYMKPB)
			{
				numBytesToRead = BDhMEvWbFKAWECGQcrymITLYMKPB;
			}
			int num2 = IzUhUdtIKWZrodPZMyrXjCqwJwBs.TryReadBytes(buffer, numBytesToRead, readStartIndex);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += IzUhUdtIKWZrodPZMyrXjCqwJwBs.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
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
			return IzUhUdtIKWZrodPZMyrXjCqwJwBs.GetPointer(offsetFromReadPosition);
		}

		public int GetOffsetFromReadPosition(int offset)
		{
			int num = (int)hHpJvPtDWvWEFUjqQxhVKvLBrZQG + offset;
			if (num >= lddzzYAoWDIEPRsFEVOrIEabaPDy)
			{
				num -= lddzzYAoWDIEPRsFEVOrIEabaPDy;
			}
			else if (num < 0)
			{
				num += lddzzYAoWDIEPRsFEVOrIEabaPDy;
			}
			if (num < 0 || num >= lddzzYAoWDIEPRsFEVOrIEabaPDy)
			{
				return -1;
			}
			return num;
		}

		public bool IsValid(int startIndex, uint passId)
		{
			if (startIndex < 0 || startIndex >= lddzzYAoWDIEPRsFEVOrIEabaPDy)
			{
				return false;
			}
			if (startIndex < jLMcHHExdVXAAaVoKuxTPKrOHmab)
			{
				if (passId == IWGVfNLgvyMjuiwfchsCkCKPCCGo)
				{
					return true;
				}
			}
			else if (startIndex >= jLMcHHExdVXAAaVoKuxTPKrOHmab)
			{
				if (IWGVfNLgvyMjuiwfchsCkCKPCCGo == 0)
				{
					return false;
				}
				if (IWGVfNLgvyMjuiwfchsCkCKPCCGo - 1 == passId)
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
			if (lddzzYAoWDIEPRsFEVOrIEabaPDy != other.lddzzYAoWDIEPRsFEVOrIEabaPDy)
			{
				throw new Exception("Buffer does not have the same capacity. Cannot copy.");
			}
			jLMcHHExdVXAAaVoKuxTPKrOHmab = other.jLMcHHExdVXAAaVoKuxTPKrOHmab;
			hHpJvPtDWvWEFUjqQxhVKvLBrZQG = other.hHpJvPtDWvWEFUjqQxhVKvLBrZQG;
			BDhMEvWbFKAWECGQcrymITLYMKPB = other.BDhMEvWbFKAWECGQcrymITLYMKPB;
			xlRNvIarUTEUFbdbGhHQJtTlKoAG = other.xlRNvIarUTEUFbdbGhHQJtTlKoAG;
			IWGVfNLgvyMjuiwfchsCkCKPCCGo = other.IWGVfNLgvyMjuiwfchsCkCKPCCGo;
			IzUhUdtIKWZrodPZMyrXjCqwJwBs.CopyFrom(other.IzUhUdtIKWZrodPZMyrXjCqwJwBs);
		}

		public void Reset()
		{
			jLMcHHExdVXAAaVoKuxTPKrOHmab = 0L;
			hHpJvPtDWvWEFUjqQxhVKvLBrZQG = 0L;
			BDhMEvWbFKAWECGQcrymITLYMKPB = 0;
			xlRNvIarUTEUFbdbGhHQJtTlKoAG = false;
			IWGVfNLgvyMjuiwfchsCkCKPCCGo = 0u;
		}

		private void mCYFjhpmqFfGWGbbtNSCcjZVuCLk(int P_0)
		{
			if (P_0 <= 0)
			{
				return;
			}
			int num = (int)jLMcHHExdVXAAaVoKuxTPKrOHmab;
			jLMcHHExdVXAAaVoKuxTPKrOHmab += P_0;
			bool flag = false;
			if (num < hHpJvPtDWvWEFUjqQxhVKvLBrZQG)
			{
				if (jLMcHHExdVXAAaVoKuxTPKrOHmab > hHpJvPtDWvWEFUjqQxhVKvLBrZQG)
				{
					flag = true;
				}
			}
			else if (num > hHpJvPtDWvWEFUjqQxhVKvLBrZQG)
			{
				if (jLMcHHExdVXAAaVoKuxTPKrOHmab - lddzzYAoWDIEPRsFEVOrIEabaPDy > hHpJvPtDWvWEFUjqQxhVKvLBrZQG)
				{
					flag = true;
				}
			}
			else if (BDhMEvWbFKAWECGQcrymITLYMKPB > 0)
			{
				flag = true;
			}
			if (flag)
			{
				xlRNvIarUTEUFbdbGhHQJtTlKoAG = true;
				hHpJvPtDWvWEFUjqQxhVKvLBrZQG = jLMcHHExdVXAAaVoKuxTPKrOHmab;
				if (hHpJvPtDWvWEFUjqQxhVKvLBrZQG >= lddzzYAoWDIEPRsFEVOrIEabaPDy)
				{
					hHpJvPtDWvWEFUjqQxhVKvLBrZQG -= lddzzYAoWDIEPRsFEVOrIEabaPDy;
				}
			}
			if (jLMcHHExdVXAAaVoKuxTPKrOHmab >= lddzzYAoWDIEPRsFEVOrIEabaPDy)
			{
				jLMcHHExdVXAAaVoKuxTPKrOHmab -= lddzzYAoWDIEPRsFEVOrIEabaPDy;
				xrNBAwroIvlEoOPtHRHLVRBnzWXj();
			}
			BDhMEvWbFKAWECGQcrymITLYMKPB = (int)MathTools.Clamp((long)BDhMEvWbFKAWECGQcrymITLYMKPB + (long)P_0, 0L, lddzzYAoWDIEPRsFEVOrIEabaPDy);
		}

		private void OfmljFWaDKCMPPjEpXbQhTdtdLcA(int P_0)
		{
			if (P_0 > 0)
			{
				if (xlRNvIarUTEUFbdbGhHQJtTlKoAG)
				{
					xlRNvIarUTEUFbdbGhHQJtTlKoAG = false;
				}
				hHpJvPtDWvWEFUjqQxhVKvLBrZQG += P_0;
				if (hHpJvPtDWvWEFUjqQxhVKvLBrZQG >= lddzzYAoWDIEPRsFEVOrIEabaPDy)
				{
					hHpJvPtDWvWEFUjqQxhVKvLBrZQG -= lddzzYAoWDIEPRsFEVOrIEabaPDy;
				}
				long num = (long)BDhMEvWbFKAWECGQcrymITLYMKPB - (long)P_0;
				BDhMEvWbFKAWECGQcrymITLYMKPB = (int)((num >= 0) ? num : 0);
			}
		}

		private void xrNBAwroIvlEoOPtHRHLVRBnzWXj()
		{
			if (IWGVfNLgvyMjuiwfchsCkCKPCCGo == uint.MaxValue)
			{
				IWGVfNLgvyMjuiwfchsCkCKPCCGo = 0u;
			}
			else
			{
				IWGVfNLgvyMjuiwfchsCkCKPCCGo++;
			}
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

		~NativeRingBuffer()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!NMKcGLkxNlhRwqGlKpsPcdyDPnjg)
			{
				if (disposing && IzUhUdtIKWZrodPZMyrXjCqwJwBs != null)
				{
					IzUhUdtIKWZrodPZMyrXjCqwJwBs.Dispose();
				}
				NMKcGLkxNlhRwqGlKpsPcdyDPnjg = true;
			}
		}
	}
}
