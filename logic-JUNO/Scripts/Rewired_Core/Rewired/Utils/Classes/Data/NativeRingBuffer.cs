using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeRingBuffer : IDisposable
	{
		private readonly NativeBuffer BQjMWIiYHniOrbiFcxZaLryUFmdo;

		private readonly int gKOfnvFWRwlIKHOZmcXCecHPLinf;

		private long uXuiacPksQoFJyBBQiPAxDKDCZGiA;

		private long eBWbPeknIUDrQOMoaMSyghHxtQik;

		private int WUQAKrXGqhjrNAbQGSnXqSBeAGmJ;

		private bool cOeZxjtiNwFzMdCdohAhidRFlQaoA;

		private uint VxsTwHKsZfbdgehSQIfiEKnSKadb;

		private bool WUlAqyxWMOvIpqInyEEkjIkdJTNVA;

		public int Capacity => gKOfnvFWRwlIKHOZmcXCecHPLinf;

		public int BytesInBuffer => WUQAKrXGqhjrNAbQGSnXqSBeAGmJ;

		public bool BufferOverrun => cOeZxjtiNwFzMdCdohAhidRFlQaoA;

		public int ReadPosition => (int)eBWbPeknIUDrQOMoaMSyghHxtQik;

		public long WritePosition => uXuiacPksQoFJyBBQiPAxDKDCZGiA;

		public NativeRingBuffer(int P_0)
		{
			gKOfnvFWRwlIKHOZmcXCecHPLinf = P_0;
			if (P_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("sizeInBytes");
			}
			BQjMWIiYHniOrbiFcxZaLryUFmdo = new NativeBuffer(P_0);
		}

		public IntPtr Allocate(int bufferLength, bool zeroFill, out uint passId)
		{
			IntPtr pointer = BQjMWIiYHniOrbiFcxZaLryUFmdo.GetPointer((int)uXuiacPksQoFJyBBQiPAxDKDCZGiA);
			passId = VxsTwHKsZfbdgehSQIfiEKnSKadb;
			if (zeroFill)
			{
				int num = 0;
				BQjMWIiYHniOrbiFcxZaLryUFmdo.TryFill(0, bufferLength, (int)uXuiacPksQoFJyBBQiPAxDKDCZGiA);
				if (num == 0)
				{
					return IntPtr.Zero;
				}
				if (num < bufferLength)
				{
					num += BQjMWIiYHniOrbiFcxZaLryUFmdo.TryFill(0, bufferLength - num, num);
				}
			}
			fdtLAUchIcQoTWrlTmzvURtlesre(bufferLength);
			return pointer;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)uXuiacPksQoFJyBBQiPAxDKDCZGiA;
			passId = VxsTwHKsZfbdgehSQIfiEKnSKadb;
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0)
			{
				return 0;
			}
			if (numBytesToWrite > bufferLength)
			{
				numBytesToWrite = bufferLength;
			}
			int num = BQjMWIiYHniOrbiFcxZaLryUFmdo.TryWriteBytes(buffer, bufferLength, numBytesToWrite, (int)uXuiacPksQoFJyBBQiPAxDKDCZGiA);
			if (num == 0)
			{
				return 0;
			}
			if (num < numBytesToWrite)
			{
				num += BQjMWIiYHniOrbiFcxZaLryUFmdo.TryWriteBytes(buffer, bufferLength, numBytesToWrite - num, 0, num);
			}
			fdtLAUchIcQoTWrlTmzvURtlesre(num);
			return num;
		}

		public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)uXuiacPksQoFJyBBQiPAxDKDCZGiA;
			passId = VxsTwHKsZfbdgehSQIfiEKnSKadb;
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
			int num2 = BQjMWIiYHniOrbiFcxZaLryUFmdo.TryWriteBytes(buffer, numBytesToWrite, (int)uXuiacPksQoFJyBBQiPAxDKDCZGiA);
			if (num2 == 0)
			{
				return 0;
			}
			if (num2 < numBytesToWrite)
			{
				num2 += BQjMWIiYHniOrbiFcxZaLryUFmdo.TryWriteBytes(buffer, numBytesToWrite - num2, 0, num2);
			}
			fdtLAUchIcQoTWrlTmzvURtlesre(num2);
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
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || WUQAKrXGqhjrNAbQGSnXqSBeAGmJ == 0)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > WUQAKrXGqhjrNAbQGSnXqSBeAGmJ)
			{
				numBytesToRead = WUQAKrXGqhjrNAbQGSnXqSBeAGmJ;
			}
			int num = BQjMWIiYHniOrbiFcxZaLryUFmdo.TryReadBytes(buffer, bufferLength, numBytesToRead, (int)eBWbPeknIUDrQOMoaMSyghHxtQik);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += BQjMWIiYHniOrbiFcxZaLryUFmdo.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
			}
			ZxObXEJpzylKXTfuueAMRLxHvHtD(num);
			return num;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToRead <= 0 || WUQAKrXGqhjrNAbQGSnXqSBeAGmJ == 0)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > WUQAKrXGqhjrNAbQGSnXqSBeAGmJ)
			{
				numBytesToRead = WUQAKrXGqhjrNAbQGSnXqSBeAGmJ;
			}
			int num2 = BQjMWIiYHniOrbiFcxZaLryUFmdo.TryReadBytes(buffer, numBytesToRead, (int)eBWbPeknIUDrQOMoaMSyghHxtQik);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += BQjMWIiYHniOrbiFcxZaLryUFmdo.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
			}
			ZxObXEJpzylKXTfuueAMRLxHvHtD(num2);
			return num2;
		}

		public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
		{
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || WUQAKrXGqhjrNAbQGSnXqSBeAGmJ == 0 || readStartIndex < 0 || readStartIndex >= gKOfnvFWRwlIKHOZmcXCecHPLinf)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > WUQAKrXGqhjrNAbQGSnXqSBeAGmJ)
			{
				numBytesToRead = WUQAKrXGqhjrNAbQGSnXqSBeAGmJ;
			}
			int num = BQjMWIiYHniOrbiFcxZaLryUFmdo.TryReadBytes(buffer, bufferLength, numBytesToRead, readStartIndex);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += BQjMWIiYHniOrbiFcxZaLryUFmdo.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
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
			if (num <= 0 || numBytesToRead <= 0 || WUQAKrXGqhjrNAbQGSnXqSBeAGmJ == 0 || readStartIndex < 0 || readStartIndex >= gKOfnvFWRwlIKHOZmcXCecHPLinf)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > WUQAKrXGqhjrNAbQGSnXqSBeAGmJ)
			{
				numBytesToRead = WUQAKrXGqhjrNAbQGSnXqSBeAGmJ;
			}
			int num2 = BQjMWIiYHniOrbiFcxZaLryUFmdo.TryReadBytes(buffer, numBytesToRead, readStartIndex);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += BQjMWIiYHniOrbiFcxZaLryUFmdo.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
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
			return BQjMWIiYHniOrbiFcxZaLryUFmdo.GetPointer(offsetFromReadPosition);
		}

		public int GetOffsetFromReadPosition(int offset)
		{
			int num = (int)eBWbPeknIUDrQOMoaMSyghHxtQik + offset;
			if (num >= gKOfnvFWRwlIKHOZmcXCecHPLinf)
			{
				num -= gKOfnvFWRwlIKHOZmcXCecHPLinf;
			}
			else if (num < 0)
			{
				num += gKOfnvFWRwlIKHOZmcXCecHPLinf;
			}
			if (num < 0 || num >= gKOfnvFWRwlIKHOZmcXCecHPLinf)
			{
				return -1;
			}
			return num;
		}

		public bool IsValid(int startIndex, uint passId)
		{
			if (startIndex < 0 || startIndex >= gKOfnvFWRwlIKHOZmcXCecHPLinf)
			{
				return false;
			}
			if (startIndex < uXuiacPksQoFJyBBQiPAxDKDCZGiA)
			{
				if (passId == VxsTwHKsZfbdgehSQIfiEKnSKadb)
				{
					return true;
				}
			}
			else if (startIndex >= uXuiacPksQoFJyBBQiPAxDKDCZGiA)
			{
				if (VxsTwHKsZfbdgehSQIfiEKnSKadb == 0)
				{
					return false;
				}
				if (VxsTwHKsZfbdgehSQIfiEKnSKadb - 1 == passId)
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
			if (gKOfnvFWRwlIKHOZmcXCecHPLinf != other.gKOfnvFWRwlIKHOZmcXCecHPLinf)
			{
				throw new Exception("Buffer does not have the same capacity. Cannot copy.");
			}
			uXuiacPksQoFJyBBQiPAxDKDCZGiA = other.uXuiacPksQoFJyBBQiPAxDKDCZGiA;
			eBWbPeknIUDrQOMoaMSyghHxtQik = other.eBWbPeknIUDrQOMoaMSyghHxtQik;
			WUQAKrXGqhjrNAbQGSnXqSBeAGmJ = other.WUQAKrXGqhjrNAbQGSnXqSBeAGmJ;
			cOeZxjtiNwFzMdCdohAhidRFlQaoA = other.cOeZxjtiNwFzMdCdohAhidRFlQaoA;
			VxsTwHKsZfbdgehSQIfiEKnSKadb = other.VxsTwHKsZfbdgehSQIfiEKnSKadb;
			BQjMWIiYHniOrbiFcxZaLryUFmdo.CopyFrom(other.BQjMWIiYHniOrbiFcxZaLryUFmdo);
		}

		public void Reset()
		{
			uXuiacPksQoFJyBBQiPAxDKDCZGiA = 0L;
			eBWbPeknIUDrQOMoaMSyghHxtQik = 0L;
			WUQAKrXGqhjrNAbQGSnXqSBeAGmJ = 0;
			cOeZxjtiNwFzMdCdohAhidRFlQaoA = false;
			VxsTwHKsZfbdgehSQIfiEKnSKadb = 0u;
		}

		private void fdtLAUchIcQoTWrlTmzvURtlesre(int P_0)
		{
			if (P_0 <= 0)
			{
				return;
			}
			int num = (int)uXuiacPksQoFJyBBQiPAxDKDCZGiA;
			uXuiacPksQoFJyBBQiPAxDKDCZGiA += P_0;
			bool flag = false;
			if (num < eBWbPeknIUDrQOMoaMSyghHxtQik)
			{
				if (uXuiacPksQoFJyBBQiPAxDKDCZGiA > eBWbPeknIUDrQOMoaMSyghHxtQik)
				{
					flag = true;
				}
			}
			else if (num > eBWbPeknIUDrQOMoaMSyghHxtQik)
			{
				if (uXuiacPksQoFJyBBQiPAxDKDCZGiA - gKOfnvFWRwlIKHOZmcXCecHPLinf > eBWbPeknIUDrQOMoaMSyghHxtQik)
				{
					flag = true;
				}
			}
			else if (WUQAKrXGqhjrNAbQGSnXqSBeAGmJ > 0)
			{
				flag = true;
			}
			if (flag)
			{
				cOeZxjtiNwFzMdCdohAhidRFlQaoA = true;
				eBWbPeknIUDrQOMoaMSyghHxtQik = uXuiacPksQoFJyBBQiPAxDKDCZGiA;
				if (eBWbPeknIUDrQOMoaMSyghHxtQik >= gKOfnvFWRwlIKHOZmcXCecHPLinf)
				{
					eBWbPeknIUDrQOMoaMSyghHxtQik -= gKOfnvFWRwlIKHOZmcXCecHPLinf;
				}
			}
			if (uXuiacPksQoFJyBBQiPAxDKDCZGiA >= gKOfnvFWRwlIKHOZmcXCecHPLinf)
			{
				uXuiacPksQoFJyBBQiPAxDKDCZGiA -= gKOfnvFWRwlIKHOZmcXCecHPLinf;
				oRmPuFmYBGYUtYtlxuhupsTJdFrk();
			}
			WUQAKrXGqhjrNAbQGSnXqSBeAGmJ = (int)MathTools.Clamp((long)WUQAKrXGqhjrNAbQGSnXqSBeAGmJ + (long)P_0, 0L, gKOfnvFWRwlIKHOZmcXCecHPLinf);
		}

		private void ZxObXEJpzylKXTfuueAMRLxHvHtD(int P_0)
		{
			if (P_0 > 0)
			{
				if (cOeZxjtiNwFzMdCdohAhidRFlQaoA)
				{
					cOeZxjtiNwFzMdCdohAhidRFlQaoA = false;
				}
				eBWbPeknIUDrQOMoaMSyghHxtQik += P_0;
				if (eBWbPeknIUDrQOMoaMSyghHxtQik >= gKOfnvFWRwlIKHOZmcXCecHPLinf)
				{
					eBWbPeknIUDrQOMoaMSyghHxtQik -= gKOfnvFWRwlIKHOZmcXCecHPLinf;
				}
				long num = (long)WUQAKrXGqhjrNAbQGSnXqSBeAGmJ - (long)P_0;
				WUQAKrXGqhjrNAbQGSnXqSBeAGmJ = (int)((num >= 0) ? num : 0);
			}
		}

		private void oRmPuFmYBGYUtYtlxuhupsTJdFrk()
		{
			if (VxsTwHKsZfbdgehSQIfiEKnSKadb == uint.MaxValue)
			{
				VxsTwHKsZfbdgehSQIfiEKnSKadb = 0u;
			}
			else
			{
				VxsTwHKsZfbdgehSQIfiEKnSKadb++;
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
			if (!WUlAqyxWMOvIpqInyEEkjIkdJTNVA)
			{
				if (disposing && BQjMWIiYHniOrbiFcxZaLryUFmdo != null)
				{
					BQjMWIiYHniOrbiFcxZaLryUFmdo.Dispose();
				}
				WUlAqyxWMOvIpqInyEEkjIkdJTNVA = true;
			}
		}
	}
}
