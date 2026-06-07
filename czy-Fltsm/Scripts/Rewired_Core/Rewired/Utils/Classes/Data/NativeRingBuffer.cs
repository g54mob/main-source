using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class NativeRingBuffer : IDisposable
	{
		private readonly NativeBuffer RHhUmeotZAZoJHgPjJTRCcvNWZsi;

		private readonly int afGGlBHiZFKiwddNffahvTvSYner;

		private long cvaYmGLjcxdftAGNNoTreaVCdjLhb;

		private long owWkVYomUzwaokrkpkYPpiGiEDfr;

		private int QfSzMFPUwMqsngnELOYspkKjCcfR;

		private bool awuEJFxlDJuwsXbnnYRQqxKOiMrg;

		private uint DNpdHYMsmweoBSvnHEAMJZLgZcrhA;

		private bool QpxImQhMAffBJUsvdjUNVAvuVrCo;

		public int Capacity => afGGlBHiZFKiwddNffahvTvSYner;

		public int BytesInBuffer => QfSzMFPUwMqsngnELOYspkKjCcfR;

		public bool BufferOverrun => awuEJFxlDJuwsXbnnYRQqxKOiMrg;

		public int ReadPosition => (int)owWkVYomUzwaokrkpkYPpiGiEDfr;

		public long WritePosition => cvaYmGLjcxdftAGNNoTreaVCdjLhb;

		public NativeRingBuffer(int P_0)
		{
			afGGlBHiZFKiwddNffahvTvSYner = P_0;
			if (P_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("sizeInBytes");
			}
			RHhUmeotZAZoJHgPjJTRCcvNWZsi = new NativeBuffer(P_0);
		}

		public IntPtr Allocate(int bufferLength, bool zeroFill, out uint passId)
		{
			IntPtr pointer = RHhUmeotZAZoJHgPjJTRCcvNWZsi.GetPointer((int)cvaYmGLjcxdftAGNNoTreaVCdjLhb);
			passId = DNpdHYMsmweoBSvnHEAMJZLgZcrhA;
			if (zeroFill)
			{
				int num = 0;
				RHhUmeotZAZoJHgPjJTRCcvNWZsi.TryFill(0, bufferLength, (int)cvaYmGLjcxdftAGNNoTreaVCdjLhb);
				if (num == 0)
				{
					return IntPtr.Zero;
				}
				if (num < bufferLength)
				{
					num += RHhUmeotZAZoJHgPjJTRCcvNWZsi.TryFill(0, bufferLength - num, num);
				}
			}
			fczIZqikfHGJhjgbEIoGvBUiRSysA(bufferLength);
			return pointer;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)cvaYmGLjcxdftAGNNoTreaVCdjLhb;
			passId = DNpdHYMsmweoBSvnHEAMJZLgZcrhA;
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0)
			{
				return 0;
			}
			if (numBytesToWrite > bufferLength)
			{
				numBytesToWrite = bufferLength;
			}
			int num = RHhUmeotZAZoJHgPjJTRCcvNWZsi.TryWriteBytes(buffer, bufferLength, numBytesToWrite, (int)cvaYmGLjcxdftAGNNoTreaVCdjLhb);
			if (num == 0)
			{
				return 0;
			}
			if (num < numBytesToWrite)
			{
				num += RHhUmeotZAZoJHgPjJTRCcvNWZsi.TryWriteBytes(buffer, bufferLength, numBytesToWrite - num, 0, num);
			}
			fczIZqikfHGJhjgbEIoGvBUiRSysA(num);
			return num;
		}

		public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)cvaYmGLjcxdftAGNNoTreaVCdjLhb;
			passId = DNpdHYMsmweoBSvnHEAMJZLgZcrhA;
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
			int num2 = RHhUmeotZAZoJHgPjJTRCcvNWZsi.TryWriteBytes(buffer, numBytesToWrite, (int)cvaYmGLjcxdftAGNNoTreaVCdjLhb);
			if (num2 == 0)
			{
				return 0;
			}
			if (num2 < numBytesToWrite)
			{
				num2 += RHhUmeotZAZoJHgPjJTRCcvNWZsi.TryWriteBytes(buffer, numBytesToWrite - num2, 0, num2);
			}
			fczIZqikfHGJhjgbEIoGvBUiRSysA(num2);
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
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || QfSzMFPUwMqsngnELOYspkKjCcfR == 0)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > QfSzMFPUwMqsngnELOYspkKjCcfR)
			{
				numBytesToRead = QfSzMFPUwMqsngnELOYspkKjCcfR;
			}
			int num = RHhUmeotZAZoJHgPjJTRCcvNWZsi.TryReadBytes(buffer, bufferLength, numBytesToRead, (int)owWkVYomUzwaokrkpkYPpiGiEDfr);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += RHhUmeotZAZoJHgPjJTRCcvNWZsi.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
			}
			VvGzrsRUzVOutfFnnqizQmCOjFejA(num);
			return num;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToRead <= 0 || QfSzMFPUwMqsngnELOYspkKjCcfR == 0)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > QfSzMFPUwMqsngnELOYspkKjCcfR)
			{
				numBytesToRead = QfSzMFPUwMqsngnELOYspkKjCcfR;
			}
			int num2 = RHhUmeotZAZoJHgPjJTRCcvNWZsi.TryReadBytes(buffer, numBytesToRead, (int)owWkVYomUzwaokrkpkYPpiGiEDfr);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += RHhUmeotZAZoJHgPjJTRCcvNWZsi.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
			}
			VvGzrsRUzVOutfFnnqizQmCOjFejA(num2);
			return num2;
		}

		public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
		{
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || QfSzMFPUwMqsngnELOYspkKjCcfR == 0 || readStartIndex < 0 || readStartIndex >= afGGlBHiZFKiwddNffahvTvSYner)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > QfSzMFPUwMqsngnELOYspkKjCcfR)
			{
				numBytesToRead = QfSzMFPUwMqsngnELOYspkKjCcfR;
			}
			int num = RHhUmeotZAZoJHgPjJTRCcvNWZsi.TryReadBytes(buffer, bufferLength, numBytesToRead, readStartIndex);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += RHhUmeotZAZoJHgPjJTRCcvNWZsi.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
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
			if (num <= 0 || numBytesToRead <= 0 || QfSzMFPUwMqsngnELOYspkKjCcfR == 0 || readStartIndex < 0 || readStartIndex >= afGGlBHiZFKiwddNffahvTvSYner)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > QfSzMFPUwMqsngnELOYspkKjCcfR)
			{
				numBytesToRead = QfSzMFPUwMqsngnELOYspkKjCcfR;
			}
			int num2 = RHhUmeotZAZoJHgPjJTRCcvNWZsi.TryReadBytes(buffer, numBytesToRead, readStartIndex);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += RHhUmeotZAZoJHgPjJTRCcvNWZsi.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
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
			return RHhUmeotZAZoJHgPjJTRCcvNWZsi.GetPointer(offsetFromReadPosition);
		}

		public int GetOffsetFromReadPosition(int offset)
		{
			int num = (int)owWkVYomUzwaokrkpkYPpiGiEDfr + offset;
			if (num >= afGGlBHiZFKiwddNffahvTvSYner)
			{
				num -= afGGlBHiZFKiwddNffahvTvSYner;
			}
			else if (num < 0)
			{
				num += afGGlBHiZFKiwddNffahvTvSYner;
			}
			if (num < 0 || num >= afGGlBHiZFKiwddNffahvTvSYner)
			{
				return -1;
			}
			return num;
		}

		public bool IsValid(int startIndex, uint passId)
		{
			if (startIndex < 0 || startIndex >= afGGlBHiZFKiwddNffahvTvSYner)
			{
				return false;
			}
			if (startIndex < cvaYmGLjcxdftAGNNoTreaVCdjLhb)
			{
				if (passId == DNpdHYMsmweoBSvnHEAMJZLgZcrhA)
				{
					return true;
				}
			}
			else if (startIndex >= cvaYmGLjcxdftAGNNoTreaVCdjLhb)
			{
				if (DNpdHYMsmweoBSvnHEAMJZLgZcrhA == 0)
				{
					return false;
				}
				if (DNpdHYMsmweoBSvnHEAMJZLgZcrhA - 1 == passId)
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
			if (afGGlBHiZFKiwddNffahvTvSYner != other.afGGlBHiZFKiwddNffahvTvSYner)
			{
				throw new Exception("Buffer does not have the same capacity. Cannot copy.");
			}
			cvaYmGLjcxdftAGNNoTreaVCdjLhb = other.cvaYmGLjcxdftAGNNoTreaVCdjLhb;
			owWkVYomUzwaokrkpkYPpiGiEDfr = other.owWkVYomUzwaokrkpkYPpiGiEDfr;
			QfSzMFPUwMqsngnELOYspkKjCcfR = other.QfSzMFPUwMqsngnELOYspkKjCcfR;
			awuEJFxlDJuwsXbnnYRQqxKOiMrg = other.awuEJFxlDJuwsXbnnYRQqxKOiMrg;
			DNpdHYMsmweoBSvnHEAMJZLgZcrhA = other.DNpdHYMsmweoBSvnHEAMJZLgZcrhA;
			RHhUmeotZAZoJHgPjJTRCcvNWZsi.CopyFrom(other.RHhUmeotZAZoJHgPjJTRCcvNWZsi);
		}

		public void Reset()
		{
			cvaYmGLjcxdftAGNNoTreaVCdjLhb = 0L;
			owWkVYomUzwaokrkpkYPpiGiEDfr = 0L;
			QfSzMFPUwMqsngnELOYspkKjCcfR = 0;
			awuEJFxlDJuwsXbnnYRQqxKOiMrg = false;
			DNpdHYMsmweoBSvnHEAMJZLgZcrhA = 0u;
		}

		private void fczIZqikfHGJhjgbEIoGvBUiRSysA(int P_0)
		{
			if (P_0 <= 0)
			{
				return;
			}
			int num = (int)cvaYmGLjcxdftAGNNoTreaVCdjLhb;
			cvaYmGLjcxdftAGNNoTreaVCdjLhb += P_0;
			bool flag = false;
			if (num < owWkVYomUzwaokrkpkYPpiGiEDfr)
			{
				if (cvaYmGLjcxdftAGNNoTreaVCdjLhb > owWkVYomUzwaokrkpkYPpiGiEDfr)
				{
					flag = true;
				}
			}
			else if (num > owWkVYomUzwaokrkpkYPpiGiEDfr)
			{
				if (cvaYmGLjcxdftAGNNoTreaVCdjLhb - afGGlBHiZFKiwddNffahvTvSYner > owWkVYomUzwaokrkpkYPpiGiEDfr)
				{
					flag = true;
				}
			}
			else if (QfSzMFPUwMqsngnELOYspkKjCcfR > 0)
			{
				flag = true;
			}
			if (flag)
			{
				awuEJFxlDJuwsXbnnYRQqxKOiMrg = true;
				owWkVYomUzwaokrkpkYPpiGiEDfr = cvaYmGLjcxdftAGNNoTreaVCdjLhb;
				if (owWkVYomUzwaokrkpkYPpiGiEDfr >= afGGlBHiZFKiwddNffahvTvSYner)
				{
					owWkVYomUzwaokrkpkYPpiGiEDfr -= afGGlBHiZFKiwddNffahvTvSYner;
				}
			}
			if (cvaYmGLjcxdftAGNNoTreaVCdjLhb >= afGGlBHiZFKiwddNffahvTvSYner)
			{
				cvaYmGLjcxdftAGNNoTreaVCdjLhb -= afGGlBHiZFKiwddNffahvTvSYner;
				qmekBdwgLbzPPkydaNwRuLOIQDsV();
			}
			QfSzMFPUwMqsngnELOYspkKjCcfR = (int)MathTools.Clamp((long)QfSzMFPUwMqsngnELOYspkKjCcfR + (long)P_0, 0L, afGGlBHiZFKiwddNffahvTvSYner);
		}

		private void VvGzrsRUzVOutfFnnqizQmCOjFejA(int P_0)
		{
			if (P_0 > 0)
			{
				if (awuEJFxlDJuwsXbnnYRQqxKOiMrg)
				{
					awuEJFxlDJuwsXbnnYRQqxKOiMrg = false;
				}
				owWkVYomUzwaokrkpkYPpiGiEDfr += P_0;
				if (owWkVYomUzwaokrkpkYPpiGiEDfr >= afGGlBHiZFKiwddNffahvTvSYner)
				{
					owWkVYomUzwaokrkpkYPpiGiEDfr -= afGGlBHiZFKiwddNffahvTvSYner;
				}
				long num = (long)QfSzMFPUwMqsngnELOYspkKjCcfR - (long)P_0;
				QfSzMFPUwMqsngnELOYspkKjCcfR = (int)((num >= 0) ? num : 0);
			}
		}

		private void qmekBdwgLbzPPkydaNwRuLOIQDsV()
		{
			if (DNpdHYMsmweoBSvnHEAMJZLgZcrhA == uint.MaxValue)
			{
				DNpdHYMsmweoBSvnHEAMJZLgZcrhA = 0u;
			}
			else
			{
				DNpdHYMsmweoBSvnHEAMJZLgZcrhA++;
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
			if (!QpxImQhMAffBJUsvdjUNVAvuVrCo)
			{
				if (disposing && RHhUmeotZAZoJHgPjJTRCcvNWZsi != null)
				{
					RHhUmeotZAZoJHgPjJTRCcvNWZsi.Dispose();
				}
				QpxImQhMAffBJUsvdjUNVAvuVrCo = true;
			}
		}
	}
}
