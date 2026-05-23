using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal class IqsHgpsNGmhEzRneRjnEpMqUOie : IEnumerable<byte>, IDisposable, IEnumerable
{
	private struct nJdmLiEEAWkNnhoKyqcSWuTJZHH : IEnumerator<byte>, IDisposable, IEnumerator
	{
		private IqsHgpsNGmhEzRneRjnEpMqUOie MnafyoefNTdTFnInytBnVAWWFIp;

		private int VSKChvFShkQRUaciguvSUgAHmpJ;

		public byte Current
		{
			get
			{
				return MnafyoefNTdTFnInytBnVAWWFIp[VSKChvFShkQRUaciguvSUgAHmpJ];
			}
		}

		object IEnumerator.Current
		{
			get
			{
				return MnafyoefNTdTFnInytBnVAWWFIp[VSKChvFShkQRUaciguvSUgAHmpJ];
			}
		}

		public nJdmLiEEAWkNnhoKyqcSWuTJZHH(IqsHgpsNGmhEzRneRjnEpMqUOie array)
		{
			MnafyoefNTdTFnInytBnVAWWFIp = array;
			VSKChvFShkQRUaciguvSUgAHmpJ = -1;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (VSKChvFShkQRUaciguvSUgAHmpJ >= MnafyoefNTdTFnInytBnVAWWFIp.iUHbgjNVCGChwQiUTfqPepfoqGj - 1)
			{
				return false;
			}
			VSKChvFShkQRUaciguvSUgAHmpJ++;
			return true;
		}

		public void Reset()
		{
			VSKChvFShkQRUaciguvSUgAHmpJ = 0;
		}
	}

	private int iUHbgjNVCGChwQiUTfqPepfoqGj;

	private unsafe byte* yRgEOFBkubxfaGxeTsHFHKIayhyR;

	public int Length
	{
		get
		{
			return iUHbgjNVCGChwQiUTfqPepfoqGj;
		}
	}

	public unsafe bool IsValid
	{
		get
		{
			if (iUHbgjNVCGChwQiUTfqPepfoqGj <= 0)
			{
				return true;
			}
			return yRgEOFBkubxfaGxeTsHFHKIayhyR != null;
		}
	}

	public unsafe byte this[int index]
	{
		get
		{
			if (index < 0 || index >= iUHbgjNVCGChwQiUTfqPepfoqGj)
			{
				throw new IndexOutOfRangeException();
			}
			return yRgEOFBkubxfaGxeTsHFHKIayhyR[index];
		}
		set
		{
			if (index < 0 || index >= iUHbgjNVCGChwQiUTfqPepfoqGj)
			{
				throw new IndexOutOfRangeException();
			}
			yRgEOFBkubxfaGxeTsHFHKIayhyR[index] = value;
		}
	}

	public IqsHgpsNGmhEzRneRjnEpMqUOie(int length)
	{
		vcQVsNQJjICkKZlvTwHrmCNfVZD(length);
	}

	public unsafe IqsHgpsNGmhEzRneRjnEpMqUOie(params byte[] source)
		: this(source.Length)
	{
		Marshal.Copy(source, 0, (IntPtr)yRgEOFBkubxfaGxeTsHFHKIayhyR, source.Length);
	}

	public IqsHgpsNGmhEzRneRjnEpMqUOie(IqsHgpsNGmhEzRneRjnEpMqUOie source)
		: this(source.iUHbgjNVCGChwQiUTfqPepfoqGj)
	{
		source.bbemxaOoQUNKbWdRFEfkIPPxltKh(this, 0, source.iUHbgjNVCGChwQiUTfqPepfoqGj);
	}

	public unsafe IqsHgpsNGmhEzRneRjnEpMqUOie(byte* source, int sourceLength)
		: this(sourceLength)
	{
		iDmPgLoZjlLdrlGLlipujkvVHRKy.paUzUKGciuAmJnjIrFfoiXQPbNEU(source, yRgEOFBkubxfaGxeTsHFHKIayhyR, 0, 0, sourceLength);
	}

	public unsafe bool bbemxaOoQUNKbWdRFEfkIPPxltKh(byte* P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= iUHbgjNVCGChwQiUTfqPepfoqGj || P_2 >= P_1)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > iUHbgjNVCGChwQiUTfqPepfoqGj || P_3 > P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_3 + P_2;
		if (num >= iUHbgjNVCGChwQiUTfqPepfoqGj || num >= P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return iDmPgLoZjlLdrlGLlipujkvVHRKy.paUzUKGciuAmJnjIrFfoiXQPbNEU(yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0, P_2, P_2, P_3);
	}

	public unsafe bool bbemxaOoQUNKbWdRFEfkIPPxltKh(IqsHgpsNGmhEzRneRjnEpMqUOie P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return bbemxaOoQUNKbWdRFEfkIPPxltKh(P_0.yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0.iUHbgjNVCGChwQiUTfqPepfoqGj, P_1, P_2, P_3);
	}

	public unsafe bool bbemxaOoQUNKbWdRFEfkIPPxltKh(byte[] P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= iUHbgjNVCGChwQiUTfqPepfoqGj || P_1 >= P_0.Length)
		{
			if (P_3)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 <= 0 || P_2 > iUHbgjNVCGChwQiUTfqPepfoqGj || P_2 > P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_2 + P_1;
		if (num >= iUHbgjNVCGChwQiUTfqPepfoqGj || num >= P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0, P_1, P_1, P_2, P_3);
	}

	public unsafe bool bbemxaOoQUNKbWdRFEfkIPPxltKh(byte* P_0, int P_1, int P_2, int P_3, int P_4, bool P_5 = true)
	{
		if (P_0 == null)
		{
			if (P_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= iUHbgjNVCGChwQiUTfqPepfoqGj)
		{
			if (P_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 < 0 || P_3 >= P_1)
		{
			if (P_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_4 <= 0 || P_4 > iUHbgjNVCGChwQiUTfqPepfoqGj || P_4 > P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_4 + P_2 >= iUHbgjNVCGChwQiUTfqPepfoqGj)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex + length must be < source.Length");
			}
			return false;
		}
		if (P_4 + P_3 >= P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex + length must be < destination.Length");
			}
			return false;
		}
		return iDmPgLoZjlLdrlGLlipujkvVHRKy.paUzUKGciuAmJnjIrFfoiXQPbNEU(yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0, P_2, P_3, P_4);
	}

	public unsafe bool bbemxaOoQUNKbWdRFEfkIPPxltKh(IqsHgpsNGmhEzRneRjnEpMqUOie P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return bbemxaOoQUNKbWdRFEfkIPPxltKh(P_0.yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0.iUHbgjNVCGChwQiUTfqPepfoqGj, P_1, P_2, P_3, P_4);
	}

	public unsafe bool bbemxaOoQUNKbWdRFEfkIPPxltKh(byte[] P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= iUHbgjNVCGChwQiUTfqPepfoqGj)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= P_0.Length)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > iUHbgjNVCGChwQiUTfqPepfoqGj || P_3 > P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_3 + P_1 >= iUHbgjNVCGChwQiUTfqPepfoqGj)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex + length must be < source.Length");
			}
			return false;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex + length must be < destination.Length");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool vcmDNMPvJMVSmObsEAODbFnesU(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= iUHbgjNVCGChwQiUTfqPepfoqGj || P_2 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		int num = P_3 + P_2;
		if (num >= iUHbgjNVCGChwQiUTfqPepfoqGj)
		{
			P_3 = iUHbgjNVCGChwQiUTfqPepfoqGj - P_2;
		}
		if (num >= P_1)
		{
			P_3 = P_1 - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return iDmPgLoZjlLdrlGLlipujkvVHRKy.paUzUKGciuAmJnjIrFfoiXQPbNEU(yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0, P_2, P_2, P_3);
	}

	public unsafe bool vcmDNMPvJMVSmObsEAODbFnesU(IqsHgpsNGmhEzRneRjnEpMqUOie P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		return vcmDNMPvJMVSmObsEAODbFnesU(P_0.yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0.iUHbgjNVCGChwQiUTfqPepfoqGj, P_1, P_2);
	}

	public unsafe bool vcmDNMPvJMVSmObsEAODbFnesU(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= iUHbgjNVCGChwQiUTfqPepfoqGj || P_1 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		int num = P_2 + P_1;
		if (num >= iUHbgjNVCGChwQiUTfqPepfoqGj)
		{
			P_2 = iUHbgjNVCGChwQiUTfqPepfoqGj - P_1;
		}
		if (num >= P_0.Length)
		{
			P_2 = P_0.Length - P_1;
		}
		if (P_2 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0, P_1, P_1, P_2, false);
	}

	public unsafe bool vcmDNMPvJMVSmObsEAODbFnesU(byte* P_0, int P_1, int P_2, int P_3, int P_4)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= iUHbgjNVCGChwQiUTfqPepfoqGj)
		{
			return false;
		}
		if (P_3 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 + P_2 >= iUHbgjNVCGChwQiUTfqPepfoqGj)
		{
			P_4 = iUHbgjNVCGChwQiUTfqPepfoqGj - P_2;
		}
		if (P_4 + P_3 >= P_1)
		{
			P_4 = P_1 - P_3;
		}
		if (P_4 <= 0)
		{
			return false;
		}
		return iDmPgLoZjlLdrlGLlipujkvVHRKy.paUzUKGciuAmJnjIrFfoiXQPbNEU(yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0, P_2, P_3, P_4);
	}

	public unsafe bool vcmDNMPvJMVSmObsEAODbFnesU(IqsHgpsNGmhEzRneRjnEpMqUOie P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		return vcmDNMPvJMVSmObsEAODbFnesU(P_0.yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0.iUHbgjNVCGChwQiUTfqPepfoqGj, P_1, P_2, P_3);
	}

	public unsafe bool vcmDNMPvJMVSmObsEAODbFnesU(byte[] P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= iUHbgjNVCGChwQiUTfqPepfoqGj)
		{
			return false;
		}
		if (P_2 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 + P_1 >= iUHbgjNVCGChwQiUTfqPepfoqGj)
		{
			P_3 = iUHbgjNVCGChwQiUTfqPepfoqGj - P_1;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			P_3 = P_0.Length - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)yRgEOFBkubxfaGxeTsHFHKIayhyR, P_0, P_1, P_2, P_3, false);
	}

	public void WotzQgfiuWMSMRqZcQFLfFyIfrg(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("length must be >= 0");
		}
		if (iUHbgjNVCGChwQiUTfqPepfoqGj != P_0)
		{
			vcQVsNQJjICkKZlvTwHrmCNfVZD(P_0);
		}
	}

	public unsafe void fWzuAFjFXxdRoqxypOAIFkBEHOX()
	{
		if (iUHbgjNVCGChwQiUTfqPepfoqGj != 0 && yRgEOFBkubxfaGxeTsHFHKIayhyR != null)
		{
			iDmPgLoZjlLdrlGLlipujkvVHRKy.xArZVAsTQiQDizbGaorpAUpxdvS(yRgEOFBkubxfaGxeTsHFHKIayhyR, iUHbgjNVCGChwQiUTfqPepfoqGj);
		}
	}

	private unsafe void vcQVsNQJjICkKZlvTwHrmCNfVZD(int P_0)
	{
		if (P_0 == iUHbgjNVCGChwQiUTfqPepfoqGj)
		{
			fWzuAFjFXxdRoqxypOAIFkBEHOX();
			return;
		}
		if (iUHbgjNVCGChwQiUTfqPepfoqGj > 0)
		{
			qJmqONHtjqaSJcQlCIrSQMzZFrx();
		}
		yRgEOFBkubxfaGxeTsHFHKIayhyR = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		if (yRgEOFBkubxfaGxeTsHFHKIayhyR == null)
		{
			throw new Exception("Could not allocate memory for array.");
		}
		iUHbgjNVCGChwQiUTfqPepfoqGj = P_0;
		fWzuAFjFXxdRoqxypOAIFkBEHOX();
	}

	private unsafe void qJmqONHtjqaSJcQlCIrSQMzZFrx()
	{
		if (yRgEOFBkubxfaGxeTsHFHKIayhyR != null)
		{
			Marshal.FreeHGlobal((IntPtr)yRgEOFBkubxfaGxeTsHFHKIayhyR);
		}
		yRgEOFBkubxfaGxeTsHFHKIayhyR = null;
		iUHbgjNVCGChwQiUTfqPepfoqGj = 0;
	}

	public void Dispose()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~IqsHgpsNGmhEzRneRjnEpMqUOie()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
	}

	protected void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
	{
		qJmqONHtjqaSJcQlCIrSQMzZFrx();
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return new nJdmLiEEAWkNnhoKyqcSWuTJZHH(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new nJdmLiEEAWkNnhoKyqcSWuTJZHH(this);
	}
}
