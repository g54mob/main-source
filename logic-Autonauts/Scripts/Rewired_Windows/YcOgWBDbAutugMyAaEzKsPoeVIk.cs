using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Rewired.Utils;

internal class YcOgWBDbAutugMyAaEzKsPoeVIk : IEnumerable<byte>, IDisposable, IEnumerable
{
	private struct saVDhnejQQTFMkEcgNqyoPUmflIp : IEnumerator<byte>, IDisposable, IEnumerator
	{
		private YcOgWBDbAutugMyAaEzKsPoeVIk IgGEeWHUxLFaMDuyZZrxGEMeZFzl;

		private int XgkMiFqovuBCLHlCNQvAKFSzXpBr;

		public byte Current
		{
			get
			{
				return IgGEeWHUxLFaMDuyZZrxGEMeZFzl[XgkMiFqovuBCLHlCNQvAKFSzXpBr];
			}
		}

		object IEnumerator.Current
		{
			get
			{
				return IgGEeWHUxLFaMDuyZZrxGEMeZFzl[XgkMiFqovuBCLHlCNQvAKFSzXpBr];
			}
		}

		public saVDhnejQQTFMkEcgNqyoPUmflIp(YcOgWBDbAutugMyAaEzKsPoeVIk array)
		{
			IgGEeWHUxLFaMDuyZZrxGEMeZFzl = array;
			XgkMiFqovuBCLHlCNQvAKFSzXpBr = -1;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (XgkMiFqovuBCLHlCNQvAKFSzXpBr >= IgGEeWHUxLFaMDuyZZrxGEMeZFzl.othlrJwXEOggtDFssdiPbwxSvUx - 1)
			{
				return false;
			}
			XgkMiFqovuBCLHlCNQvAKFSzXpBr++;
			return true;
		}

		public void Reset()
		{
			XgkMiFqovuBCLHlCNQvAKFSzXpBr = 0;
		}
	}

	private int othlrJwXEOggtDFssdiPbwxSvUx;

	private unsafe byte* cdCFllFuKnaFteUUiDaHTeGMzno;

	public int Length
	{
		get
		{
			return othlrJwXEOggtDFssdiPbwxSvUx;
		}
	}

	public unsafe bool IsValid
	{
		get
		{
			if (othlrJwXEOggtDFssdiPbwxSvUx <= 0)
			{
				return true;
			}
			return cdCFllFuKnaFteUUiDaHTeGMzno != null;
		}
	}

	public unsafe byte this[int index]
	{
		get
		{
			if (index < 0 || index >= othlrJwXEOggtDFssdiPbwxSvUx)
			{
				throw new IndexOutOfRangeException();
			}
			return cdCFllFuKnaFteUUiDaHTeGMzno[index];
		}
		set
		{
			if (index < 0 || index >= othlrJwXEOggtDFssdiPbwxSvUx)
			{
				throw new IndexOutOfRangeException();
			}
			cdCFllFuKnaFteUUiDaHTeGMzno[index] = value;
		}
	}

	public YcOgWBDbAutugMyAaEzKsPoeVIk(int length)
	{
		xVijxMtzmKdJKIZiwPverJmHDTc(length);
	}

	public unsafe YcOgWBDbAutugMyAaEzKsPoeVIk(params byte[] source)
		: this(source.Length)
	{
		Marshal.Copy(source, 0, (IntPtr)cdCFllFuKnaFteUUiDaHTeGMzno, source.Length);
	}

	public YcOgWBDbAutugMyAaEzKsPoeVIk(YcOgWBDbAutugMyAaEzKsPoeVIk source)
		: this(source.othlrJwXEOggtDFssdiPbwxSvUx)
	{
		source.zlOqaMjoQCNNyXrzqpjmIuHRnfO(this, 0, source.othlrJwXEOggtDFssdiPbwxSvUx);
	}

	public unsafe YcOgWBDbAutugMyAaEzKsPoeVIk(byte* source, int sourceLength)
		: this(sourceLength)
	{
		srQAjpRGjtjqkatjQItsCdtbKROA.jZaoqafpmcVnUamkQHboGxYtgDI(source, cdCFllFuKnaFteUUiDaHTeGMzno, 0, 0, sourceLength);
	}

	public unsafe bool zlOqaMjoQCNNyXrzqpjmIuHRnfO(byte* P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= othlrJwXEOggtDFssdiPbwxSvUx || P_2 >= P_1)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > othlrJwXEOggtDFssdiPbwxSvUx || P_3 > P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_3 + P_2;
		if (num >= othlrJwXEOggtDFssdiPbwxSvUx || num >= P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return srQAjpRGjtjqkatjQItsCdtbKROA.jZaoqafpmcVnUamkQHboGxYtgDI(cdCFllFuKnaFteUUiDaHTeGMzno, P_0, P_2, P_2, P_3);
	}

	public unsafe bool zlOqaMjoQCNNyXrzqpjmIuHRnfO(YcOgWBDbAutugMyAaEzKsPoeVIk P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return zlOqaMjoQCNNyXrzqpjmIuHRnfO(P_0.cdCFllFuKnaFteUUiDaHTeGMzno, P_0.othlrJwXEOggtDFssdiPbwxSvUx, P_1, P_2, P_3);
	}

	public unsafe bool zlOqaMjoQCNNyXrzqpjmIuHRnfO(byte[] P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= othlrJwXEOggtDFssdiPbwxSvUx || P_1 >= P_0.Length)
		{
			if (P_3)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 <= 0 || P_2 > othlrJwXEOggtDFssdiPbwxSvUx || P_2 > P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_2 + P_1;
		if (num >= othlrJwXEOggtDFssdiPbwxSvUx || num >= P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)cdCFllFuKnaFteUUiDaHTeGMzno, P_0, P_1, P_1, P_2, P_3);
	}

	public unsafe bool zlOqaMjoQCNNyXrzqpjmIuHRnfO(byte* P_0, int P_1, int P_2, int P_3, int P_4, bool P_5 = true)
	{
		if (P_0 == null)
		{
			if (P_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= othlrJwXEOggtDFssdiPbwxSvUx)
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
		if (P_4 <= 0 || P_4 > othlrJwXEOggtDFssdiPbwxSvUx || P_4 > P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_4 + P_2 >= othlrJwXEOggtDFssdiPbwxSvUx)
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
		return srQAjpRGjtjqkatjQItsCdtbKROA.jZaoqafpmcVnUamkQHboGxYtgDI(cdCFllFuKnaFteUUiDaHTeGMzno, P_0, P_2, P_3, P_4);
	}

	public unsafe bool zlOqaMjoQCNNyXrzqpjmIuHRnfO(YcOgWBDbAutugMyAaEzKsPoeVIk P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return zlOqaMjoQCNNyXrzqpjmIuHRnfO(P_0.cdCFllFuKnaFteUUiDaHTeGMzno, P_0.othlrJwXEOggtDFssdiPbwxSvUx, P_1, P_2, P_3, P_4);
	}

	public unsafe bool zlOqaMjoQCNNyXrzqpjmIuHRnfO(byte[] P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= othlrJwXEOggtDFssdiPbwxSvUx)
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
		if (P_3 <= 0 || P_3 > othlrJwXEOggtDFssdiPbwxSvUx || P_3 > P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_3 + P_1 >= othlrJwXEOggtDFssdiPbwxSvUx)
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
		return NativeTools.CopyMemory((IntPtr)cdCFllFuKnaFteUUiDaHTeGMzno, P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool pUSYjbjpnPmFXzLZVQKWMMRZZkC(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= othlrJwXEOggtDFssdiPbwxSvUx || P_2 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		int num = P_3 + P_2;
		if (num >= othlrJwXEOggtDFssdiPbwxSvUx)
		{
			P_3 = othlrJwXEOggtDFssdiPbwxSvUx - P_2;
		}
		if (num >= P_1)
		{
			P_3 = P_1 - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return srQAjpRGjtjqkatjQItsCdtbKROA.jZaoqafpmcVnUamkQHboGxYtgDI(cdCFllFuKnaFteUUiDaHTeGMzno, P_0, P_2, P_2, P_3);
	}

	public unsafe bool pUSYjbjpnPmFXzLZVQKWMMRZZkC(YcOgWBDbAutugMyAaEzKsPoeVIk P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		return pUSYjbjpnPmFXzLZVQKWMMRZZkC(P_0.cdCFllFuKnaFteUUiDaHTeGMzno, P_0.othlrJwXEOggtDFssdiPbwxSvUx, P_1, P_2);
	}

	public unsafe bool pUSYjbjpnPmFXzLZVQKWMMRZZkC(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= othlrJwXEOggtDFssdiPbwxSvUx || P_1 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		int num = P_2 + P_1;
		if (num >= othlrJwXEOggtDFssdiPbwxSvUx)
		{
			P_2 = othlrJwXEOggtDFssdiPbwxSvUx - P_1;
		}
		if (num >= P_0.Length)
		{
			P_2 = P_0.Length - P_1;
		}
		if (P_2 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)cdCFllFuKnaFteUUiDaHTeGMzno, P_0, P_1, P_1, P_2, false);
	}

	public unsafe bool pUSYjbjpnPmFXzLZVQKWMMRZZkC(byte* P_0, int P_1, int P_2, int P_3, int P_4)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= othlrJwXEOggtDFssdiPbwxSvUx)
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
		if (P_4 + P_2 >= othlrJwXEOggtDFssdiPbwxSvUx)
		{
			P_4 = othlrJwXEOggtDFssdiPbwxSvUx - P_2;
		}
		if (P_4 + P_3 >= P_1)
		{
			P_4 = P_1 - P_3;
		}
		if (P_4 <= 0)
		{
			return false;
		}
		return srQAjpRGjtjqkatjQItsCdtbKROA.jZaoqafpmcVnUamkQHboGxYtgDI(cdCFllFuKnaFteUUiDaHTeGMzno, P_0, P_2, P_3, P_4);
	}

	public unsafe bool pUSYjbjpnPmFXzLZVQKWMMRZZkC(YcOgWBDbAutugMyAaEzKsPoeVIk P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		return pUSYjbjpnPmFXzLZVQKWMMRZZkC(P_0.cdCFllFuKnaFteUUiDaHTeGMzno, P_0.othlrJwXEOggtDFssdiPbwxSvUx, P_1, P_2, P_3);
	}

	public unsafe bool pUSYjbjpnPmFXzLZVQKWMMRZZkC(byte[] P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= othlrJwXEOggtDFssdiPbwxSvUx)
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
		if (P_3 + P_1 >= othlrJwXEOggtDFssdiPbwxSvUx)
		{
			P_3 = othlrJwXEOggtDFssdiPbwxSvUx - P_1;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			P_3 = P_0.Length - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)cdCFllFuKnaFteUUiDaHTeGMzno, P_0, P_1, P_2, P_3, false);
	}

	public void SPuHKELaAJVLAexJrJVkeakSxe(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("length must be >= 0");
		}
		if (othlrJwXEOggtDFssdiPbwxSvUx != P_0)
		{
			xVijxMtzmKdJKIZiwPverJmHDTc(P_0);
		}
	}

	public unsafe void bVJfbjSJHtCUhxVYYaQYFCJuPMDE()
	{
		if (othlrJwXEOggtDFssdiPbwxSvUx != 0 && cdCFllFuKnaFteUUiDaHTeGMzno != null)
		{
			srQAjpRGjtjqkatjQItsCdtbKROA.bThCwINQylQxFgoBLlhRRhQHrCe(cdCFllFuKnaFteUUiDaHTeGMzno, othlrJwXEOggtDFssdiPbwxSvUx);
		}
	}

	private unsafe void xVijxMtzmKdJKIZiwPverJmHDTc(int P_0)
	{
		if (P_0 == othlrJwXEOggtDFssdiPbwxSvUx)
		{
			bVJfbjSJHtCUhxVYYaQYFCJuPMDE();
			return;
		}
		if (othlrJwXEOggtDFssdiPbwxSvUx > 0)
		{
			oiQJvxyfnubrAHjDzBYInRxtLBvA();
		}
		cdCFllFuKnaFteUUiDaHTeGMzno = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		if (cdCFllFuKnaFteUUiDaHTeGMzno == null)
		{
			throw new Exception("Could not allocate memory for array.");
		}
		othlrJwXEOggtDFssdiPbwxSvUx = P_0;
		bVJfbjSJHtCUhxVYYaQYFCJuPMDE();
	}

	private unsafe void oiQJvxyfnubrAHjDzBYInRxtLBvA()
	{
		if (cdCFllFuKnaFteUUiDaHTeGMzno != null)
		{
			Marshal.FreeHGlobal((IntPtr)cdCFllFuKnaFteUUiDaHTeGMzno);
		}
		cdCFllFuKnaFteUUiDaHTeGMzno = null;
		othlrJwXEOggtDFssdiPbwxSvUx = 0;
	}

	public void Dispose()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~YcOgWBDbAutugMyAaEzKsPoeVIk()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	protected void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		oiQJvxyfnubrAHjDzBYInRxtLBvA();
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return new saVDhnejQQTFMkEcgNqyoPUmflIp(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new saVDhnejQQTFMkEcgNqyoPUmflIp(this);
	}
}
