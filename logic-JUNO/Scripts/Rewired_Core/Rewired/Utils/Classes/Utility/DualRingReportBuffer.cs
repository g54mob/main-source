using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualRingReportBuffer : IDisposable
	{
		private readonly int qevjObktRWBzJBqspxxcahZYMAMMA;

		private readonly int YCrevXpZUdLCnnMWzaSIioVNDbfIA;

		private readonly int wYwtdRuXPulycZUsSDIKOenraUwr;

		private NativeRingBuffer QVNsTSAwarVizshSBhxOJRyeXiOk;

		private NativeRingBuffer VGpoblOJbtSXAjGElOpitnYfqcdx;

		private byte[] QsOlOkKizBMgrXChlIUKPLBEuZeU;

		private byte[] GAEXfqdHFcbVmDeLEkGaBCIHRQPNb;

		private int cFJdivuclOQEqwjSAgHHACvgNAnS;

		private bool ElplgZdeTsDzlGxlmXHCVJSKJoMj;

		public int BufferLength => qevjObktRWBzJBqspxxcahZYMAMMA;

		public int BytesInBuffer => VGpoblOJbtSXAjGElOpitnYfqcdx.BytesInBuffer;

		public int EntriesInBuffer => VGpoblOJbtSXAjGElOpitnYfqcdx.BytesInBuffer / YCrevXpZUdLCnnMWzaSIioVNDbfIA;

		public byte[] ReadBuffer => GAEXfqdHFcbVmDeLEkGaBCIHRQPNb;

		public int LastNumBytesRead => cFJdivuclOQEqwjSAgHHACvgNAnS;

		public DualRingReportBuffer(int P_0, int P_1)
		{
			if (P_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("entryByteLength must be > 0.");
			}
			if (P_1 < 1)
			{
				throw new ArgumentOutOfRangeException("entryCapacity must be >= 1.");
			}
			YCrevXpZUdLCnnMWzaSIioVNDbfIA = P_0;
			wYwtdRuXPulycZUsSDIKOenraUwr = P_1;
			qevjObktRWBzJBqspxxcahZYMAMMA = P_0 * P_1;
			QVNsTSAwarVizshSBhxOJRyeXiOk = new NativeRingBuffer(qevjObktRWBzJBqspxxcahZYMAMMA);
			VGpoblOJbtSXAjGElOpitnYfqcdx = new NativeRingBuffer(qevjObktRWBzJBqspxxcahZYMAMMA);
			QsOlOkKizBMgrXChlIUKPLBEuZeU = new byte[P_0];
			GAEXfqdHFcbVmDeLEkGaBCIHRQPNb = new byte[P_0];
		}

		public int StartRead()
		{
			drXifxrsOoCmSgFTYevOghgJKRHwA();
			return VGpoblOJbtSXAjGElOpitnYfqcdx.BytesInBuffer;
		}

		public int Read()
		{
			int result = 0;
			lock (VGpoblOJbtSXAjGElOpitnYfqcdx)
			{
				result = VGpoblOJbtSXAjGElOpitnYfqcdx.Read(GAEXfqdHFcbVmDeLEkGaBCIHRQPNb, YCrevXpZUdLCnnMWzaSIioVNDbfIA);
			}
			cFJdivuclOQEqwjSAgHHACvgNAnS = result;
			return result;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (numBytesToRead < 0 || numBytesToRead > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite");
			}
			int result = 0;
			lock (VGpoblOJbtSXAjGElOpitnYfqcdx)
			{
				result = VGpoblOJbtSXAjGElOpitnYfqcdx.Read(buffer, numBytesToRead);
			}
			cFJdivuclOQEqwjSAgHHACvgNAnS = result;
			return result;
		}

		public int Read(IntPtr buffer, int bufferLength, int numBytesToRead)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			if (bufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferLength");
			}
			if (numBytesToRead < 0 || numBytesToRead > bufferLength)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite");
			}
			int result = 0;
			lock (VGpoblOJbtSXAjGElOpitnYfqcdx)
			{
				result = VGpoblOJbtSXAjGElOpitnYfqcdx.Read(buffer, bufferLength, bufferLength);
			}
			cFJdivuclOQEqwjSAgHHACvgNAnS = result;
			return result;
		}

		public int Write(byte[] buffer, int numBytesToWrite)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (numBytesToWrite < 0 || numBytesToWrite > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite");
			}
			int num = 0;
			lock (QVNsTSAwarVizshSBhxOJRyeXiOk)
			{
				return QVNsTSAwarVizshSBhxOJRyeXiOk.Write(buffer, numBytesToWrite);
			}
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			if (bufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferLength");
			}
			if (numBytesToWrite < 0 || numBytesToWrite > bufferLength)
			{
				throw new ArgumentOutOfRangeException("numBytesToWrite");
			}
			int num = 0;
			lock (QVNsTSAwarVizshSBhxOJRyeXiOk)
			{
				return QVNsTSAwarVizshSBhxOJRyeXiOk.Write(buffer, bufferLength, numBytesToWrite);
			}
		}

		public void Clear()
		{
			lock (QVNsTSAwarVizshSBhxOJRyeXiOk)
			{
				lock (VGpoblOJbtSXAjGElOpitnYfqcdx)
				{
					VGpoblOJbtSXAjGElOpitnYfqcdx.Reset();
					QVNsTSAwarVizshSBhxOJRyeXiOk.Reset();
				}
			}
		}

		private void drXifxrsOoCmSgFTYevOghgJKRHwA()
		{
			lock (QVNsTSAwarVizshSBhxOJRyeXiOk)
			{
				lock (VGpoblOJbtSXAjGElOpitnYfqcdx)
				{
					MiscTools.Swap(ref QVNsTSAwarVizshSBhxOJRyeXiOk, ref VGpoblOJbtSXAjGElOpitnYfqcdx);
				}
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

		~DualRingReportBuffer()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!ElplgZdeTsDzlGxlmXHCVJSKJoMj)
			{
				ElplgZdeTsDzlGxlmXHCVJSKJoMj = true;
			}
		}
	}
}
