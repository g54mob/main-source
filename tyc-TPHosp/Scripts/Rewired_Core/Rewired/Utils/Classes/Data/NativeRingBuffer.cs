using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class NativeRingBuffer : IDisposable
	{
		private readonly NativeBuffer RSxKjXmDMKxHgwqOxhLLABffNJxA;

		private readonly int VEmNteWmpdRTYXxUtdCoLGPlsxd;

		private long qSYhWfRaRDXAtXFOuczRfLgVsTyn;

		private long duEJUMgVrKHXzDsDMlKCqLVmsZX;

		private int hurovcpABuEGHZuGuMiwFGLZvbx;

		private bool FFcHQJhnufuiSYIsGOgrtbCtwiE;

		private uint SxokxZbbFrtqOJFJXrrxDtwnFVj;

		private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

		public int Capacity => VEmNteWmpdRTYXxUtdCoLGPlsxd;

		public int BytesInBuffer => hurovcpABuEGHZuGuMiwFGLZvbx;

		public bool BufferOverrun => FFcHQJhnufuiSYIsGOgrtbCtwiE;

		public int ReadPosition => (int)duEJUMgVrKHXzDsDMlKCqLVmsZX;

		public long WritePosition => qSYhWfRaRDXAtXFOuczRfLgVsTyn;

		public NativeRingBuffer(int capacity)
		{
			VEmNteWmpdRTYXxUtdCoLGPlsxd = capacity;
			if (capacity <= 0)
			{
				throw new ArgumentOutOfRangeException("sizeInBytes");
			}
			RSxKjXmDMKxHgwqOxhLLABffNJxA = new NativeBuffer(capacity);
		}

		public IntPtr Allocate(int bufferLength, bool zeroFill, out uint passId)
		{
			IntPtr pointer = RSxKjXmDMKxHgwqOxhLLABffNJxA.GetPointer((int)qSYhWfRaRDXAtXFOuczRfLgVsTyn);
			passId = SxokxZbbFrtqOJFJXrrxDtwnFVj;
			if (zeroFill)
			{
				int num = 0;
				RSxKjXmDMKxHgwqOxhLLABffNJxA.TryFill(0, bufferLength, (int)qSYhWfRaRDXAtXFOuczRfLgVsTyn);
				if (num == 0)
				{
					return IntPtr.Zero;
				}
				if (num < bufferLength)
				{
					num += RSxKjXmDMKxHgwqOxhLLABffNJxA.TryFill(0, bufferLength - num, num);
				}
			}
			ZSmFDvAKTZTEziEIWeQUmKXIQpqu(bufferLength);
			return pointer;
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)qSYhWfRaRDXAtXFOuczRfLgVsTyn;
			passId = SxokxZbbFrtqOJFJXrrxDtwnFVj;
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0)
			{
				return 0;
			}
			if (numBytesToWrite > bufferLength)
			{
				numBytesToWrite = bufferLength;
			}
			int num = RSxKjXmDMKxHgwqOxhLLABffNJxA.TryWriteBytes(buffer, bufferLength, numBytesToWrite, (int)qSYhWfRaRDXAtXFOuczRfLgVsTyn);
			if (num == 0)
			{
				return 0;
			}
			if (num < numBytesToWrite)
			{
				num += RSxKjXmDMKxHgwqOxhLLABffNJxA.TryWriteBytes(buffer, bufferLength, numBytesToWrite - num, 0, num);
			}
			ZSmFDvAKTZTEziEIWeQUmKXIQpqu(num);
			return num;
		}

		public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
		{
			startOffset = (int)qSYhWfRaRDXAtXFOuczRfLgVsTyn;
			passId = SxokxZbbFrtqOJFJXrrxDtwnFVj;
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
			int num2 = RSxKjXmDMKxHgwqOxhLLABffNJxA.TryWriteBytes(buffer, numBytesToWrite, (int)qSYhWfRaRDXAtXFOuczRfLgVsTyn);
			if (num2 == 0)
			{
				return 0;
			}
			if (num2 < numBytesToWrite)
			{
				num2 += RSxKjXmDMKxHgwqOxhLLABffNJxA.TryWriteBytes(buffer, numBytesToWrite - num2, 0, num2);
			}
			ZSmFDvAKTZTEziEIWeQUmKXIQpqu(num2);
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
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || hurovcpABuEGHZuGuMiwFGLZvbx == 0)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > hurovcpABuEGHZuGuMiwFGLZvbx)
			{
				numBytesToRead = hurovcpABuEGHZuGuMiwFGLZvbx;
			}
			int num = RSxKjXmDMKxHgwqOxhLLABffNJxA.TryReadBytes(buffer, bufferLength, numBytesToRead, (int)duEJUMgVrKHXzDsDMlKCqLVmsZX);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += RSxKjXmDMKxHgwqOxhLLABffNJxA.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
			}
			nZiYcWfoQfAeXThqSdsuBaFNzol(num);
			return num;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				return 0;
			}
			int num = buffer.Length;
			if (num <= 0 || numBytesToRead <= 0 || hurovcpABuEGHZuGuMiwFGLZvbx == 0)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > hurovcpABuEGHZuGuMiwFGLZvbx)
			{
				numBytesToRead = hurovcpABuEGHZuGuMiwFGLZvbx;
			}
			int num2 = RSxKjXmDMKxHgwqOxhLLABffNJxA.TryReadBytes(buffer, numBytesToRead, (int)duEJUMgVrKHXzDsDMlKCqLVmsZX);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += RSxKjXmDMKxHgwqOxhLLABffNJxA.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
			}
			nZiYcWfoQfAeXThqSdsuBaFNzol(num2);
			return num2;
		}

		public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
		{
			if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || hurovcpABuEGHZuGuMiwFGLZvbx == 0 || readStartIndex < 0 || readStartIndex >= VEmNteWmpdRTYXxUtdCoLGPlsxd)
			{
				return 0;
			}
			if (numBytesToRead > bufferLength)
			{
				numBytesToRead = bufferLength;
			}
			if (numBytesToRead > hurovcpABuEGHZuGuMiwFGLZvbx)
			{
				numBytesToRead = hurovcpABuEGHZuGuMiwFGLZvbx;
			}
			int num = RSxKjXmDMKxHgwqOxhLLABffNJxA.TryReadBytes(buffer, bufferLength, numBytesToRead, readStartIndex);
			if (num <= 0)
			{
				return 0;
			}
			if (num < numBytesToRead)
			{
				num += RSxKjXmDMKxHgwqOxhLLABffNJxA.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
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
			if (num <= 0 || numBytesToRead <= 0 || hurovcpABuEGHZuGuMiwFGLZvbx == 0 || readStartIndex < 0 || readStartIndex >= VEmNteWmpdRTYXxUtdCoLGPlsxd)
			{
				return 0;
			}
			if (numBytesToRead > num)
			{
				numBytesToRead = num;
			}
			if (numBytesToRead > hurovcpABuEGHZuGuMiwFGLZvbx)
			{
				numBytesToRead = hurovcpABuEGHZuGuMiwFGLZvbx;
			}
			int num2 = RSxKjXmDMKxHgwqOxhLLABffNJxA.TryReadBytes(buffer, numBytesToRead, readStartIndex);
			if (num2 <= 0)
			{
				return 0;
			}
			if (num2 < numBytesToRead)
			{
				num2 += RSxKjXmDMKxHgwqOxhLLABffNJxA.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
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
			return RSxKjXmDMKxHgwqOxhLLABffNJxA.GetPointer(offsetFromReadPosition);
		}

		public int GetOffsetFromReadPosition(int offset)
		{
			int num = (int)duEJUMgVrKHXzDsDMlKCqLVmsZX + offset;
			if (num >= VEmNteWmpdRTYXxUtdCoLGPlsxd)
			{
				num -= VEmNteWmpdRTYXxUtdCoLGPlsxd;
			}
			else if (num < 0)
			{
				num += VEmNteWmpdRTYXxUtdCoLGPlsxd;
			}
			if (num < 0 || num >= VEmNteWmpdRTYXxUtdCoLGPlsxd)
			{
				return -1;
			}
			return num;
		}

		public bool IsValid(int startIndex, uint passId)
		{
			if (startIndex < 0 || startIndex >= VEmNteWmpdRTYXxUtdCoLGPlsxd)
			{
				return false;
			}
			if (startIndex < qSYhWfRaRDXAtXFOuczRfLgVsTyn)
			{
				if (passId == SxokxZbbFrtqOJFJXrrxDtwnFVj)
				{
					return true;
				}
			}
			else if (startIndex >= qSYhWfRaRDXAtXFOuczRfLgVsTyn)
			{
				if (SxokxZbbFrtqOJFJXrrxDtwnFVj == 0)
				{
					return false;
				}
				if (SxokxZbbFrtqOJFJXrrxDtwnFVj - 1 == passId)
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
			if (VEmNteWmpdRTYXxUtdCoLGPlsxd != other.VEmNteWmpdRTYXxUtdCoLGPlsxd)
			{
				throw new Exception("Buffer does not have the same capacity. Cannot copy.");
			}
			qSYhWfRaRDXAtXFOuczRfLgVsTyn = other.qSYhWfRaRDXAtXFOuczRfLgVsTyn;
			duEJUMgVrKHXzDsDMlKCqLVmsZX = other.duEJUMgVrKHXzDsDMlKCqLVmsZX;
			hurovcpABuEGHZuGuMiwFGLZvbx = other.hurovcpABuEGHZuGuMiwFGLZvbx;
			FFcHQJhnufuiSYIsGOgrtbCtwiE = other.FFcHQJhnufuiSYIsGOgrtbCtwiE;
			SxokxZbbFrtqOJFJXrrxDtwnFVj = other.SxokxZbbFrtqOJFJXrrxDtwnFVj;
			RSxKjXmDMKxHgwqOxhLLABffNJxA.CopyFrom(other.RSxKjXmDMKxHgwqOxhLLABffNJxA);
		}

		public void Reset()
		{
			qSYhWfRaRDXAtXFOuczRfLgVsTyn = 0L;
			duEJUMgVrKHXzDsDMlKCqLVmsZX = 0L;
			hurovcpABuEGHZuGuMiwFGLZvbx = 0;
			FFcHQJhnufuiSYIsGOgrtbCtwiE = false;
			SxokxZbbFrtqOJFJXrrxDtwnFVj = 0u;
		}

		private void ZSmFDvAKTZTEziEIWeQUmKXIQpqu(int P_0)
		{
			if (P_0 <= 0)
			{
				return;
			}
			int num = (int)qSYhWfRaRDXAtXFOuczRfLgVsTyn;
			qSYhWfRaRDXAtXFOuczRfLgVsTyn += P_0;
			bool flag = false;
			if (num < duEJUMgVrKHXzDsDMlKCqLVmsZX)
			{
				if (qSYhWfRaRDXAtXFOuczRfLgVsTyn > duEJUMgVrKHXzDsDMlKCqLVmsZX)
				{
					flag = true;
				}
			}
			else if (num > duEJUMgVrKHXzDsDMlKCqLVmsZX)
			{
				if (qSYhWfRaRDXAtXFOuczRfLgVsTyn - VEmNteWmpdRTYXxUtdCoLGPlsxd > duEJUMgVrKHXzDsDMlKCqLVmsZX)
				{
					flag = true;
				}
			}
			else if (hurovcpABuEGHZuGuMiwFGLZvbx > 0)
			{
				flag = true;
			}
			if (flag)
			{
				FFcHQJhnufuiSYIsGOgrtbCtwiE = true;
				duEJUMgVrKHXzDsDMlKCqLVmsZX = qSYhWfRaRDXAtXFOuczRfLgVsTyn;
				if (duEJUMgVrKHXzDsDMlKCqLVmsZX >= VEmNteWmpdRTYXxUtdCoLGPlsxd)
				{
					duEJUMgVrKHXzDsDMlKCqLVmsZX -= VEmNteWmpdRTYXxUtdCoLGPlsxd;
				}
			}
			if (qSYhWfRaRDXAtXFOuczRfLgVsTyn >= VEmNteWmpdRTYXxUtdCoLGPlsxd)
			{
				qSYhWfRaRDXAtXFOuczRfLgVsTyn -= VEmNteWmpdRTYXxUtdCoLGPlsxd;
				xWkiOIjeVamoBTBtROqvuXXOmNk();
			}
			hurovcpABuEGHZuGuMiwFGLZvbx = (int)MathTools.Clamp((long)hurovcpABuEGHZuGuMiwFGLZvbx + (long)P_0, 0L, VEmNteWmpdRTYXxUtdCoLGPlsxd);
		}

		private void nZiYcWfoQfAeXThqSdsuBaFNzol(int P_0)
		{
			if (P_0 > 0)
			{
				if (FFcHQJhnufuiSYIsGOgrtbCtwiE)
				{
					FFcHQJhnufuiSYIsGOgrtbCtwiE = false;
				}
				duEJUMgVrKHXzDsDMlKCqLVmsZX += P_0;
				if (duEJUMgVrKHXzDsDMlKCqLVmsZX >= VEmNteWmpdRTYXxUtdCoLGPlsxd)
				{
					duEJUMgVrKHXzDsDMlKCqLVmsZX -= VEmNteWmpdRTYXxUtdCoLGPlsxd;
				}
				long num = (long)hurovcpABuEGHZuGuMiwFGLZvbx - (long)P_0;
				hurovcpABuEGHZuGuMiwFGLZvbx = (int)((num >= 0) ? num : 0);
			}
		}

		private void xWkiOIjeVamoBTBtROqvuXXOmNk()
		{
			if (SxokxZbbFrtqOJFJXrrxDtwnFVj == uint.MaxValue)
			{
				SxokxZbbFrtqOJFJXrrxDtwnFVj = 0u;
			}
			else
			{
				SxokxZbbFrtqOJFJXrrxDtwnFVj++;
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
			if (!jgbpvYJovPcfzmcAEJzdxdrBmcm)
			{
				if (disposing && RSxKjXmDMKxHgwqOxhLLABffNJxA != null)
				{
					RSxKjXmDMKxHgwqOxhLLABffNJxA.Dispose();
				}
				jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
			}
		}
	}
}
