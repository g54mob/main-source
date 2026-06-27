using System;

internal class oMDlWjvHMzeomsfEGTVsUvGjBOwf : IDisposable
{
	private readonly WCkkisRdteszJrItqAKVBwrIDACB NYfzpsUqIBfurWrzNSYOYlqpWurk;

	private bool[] xPfjwecTeDFHIlzsNXzFqJqKgHOg;

	protected readonly int RkcOCwFHiQBlKOQIczmflSGmqBXM;

	protected readonly int HYSQhwHEktukDmNYeCybdacBkpdgb;

	private bool gNkcBTHPVtatmtsxVhdUpTkybDWtA;

	public int twDIzVgQvaNLZiMkfqsvjnggjhyu => RkcOCwFHiQBlKOQIczmflSGmqBXM;

	public int qBErOnkIYhXzUGiYktoiGwWsRIgV => HYSQhwHEktukDmNYeCybdacBkpdgb;

	public bool[] eeslsLjFOdGKGXUjeBusUDdiXrWX => xPfjwecTeDFHIlzsNXzFqJqKgHOg ?? (xPfjwecTeDFHIlzsNXzFqJqKgHOg = new bool[RkcOCwFHiQBlKOQIczmflSGmqBXM]);

	public oMDlWjvHMzeomsfEGTVsUvGjBOwf(int P_0, int P_1)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("entryBitSize");
		}
		HYSQhwHEktukDmNYeCybdacBkpdgb = P_0;
		RkcOCwFHiQBlKOQIczmflSGmqBXM = P_1;
		int num = P_0 * P_1;
		NYfzpsUqIBfurWrzNSYOYlqpWurk = new WCkkisRdteszJrItqAKVBwrIDACB(num / 8 + ((num % 8 != 0) ? 1 : 0));
	}

	public unsafe void ZBWBIwrAJtFDxFbEYnplSlDOEsFBA(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= HYSQhwHEktukDmNYeCybdacBkpdgb)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 < RkcOCwFHiQBlKOQIczmflSGmqBXM)
		{
			int rkcOCwFHiQBlKOQIczmflSGmqBXM = RkcOCwFHiQBlKOQIczmflSGmqBXM;
			throw new Exception("Buffer is too small to hold the data. Must be at least " + rkcOCwFHiQBlKOQIczmflSGmqBXM + " bits.");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < RkcOCwFHiQBlKOQIczmflSGmqBXM; i++)
		{
			xelNeHuxAqItiikmcEfXhtIVlpZR(P_0, i, out var num3, out var b);
			P_1[i] = (NYfzpsUqIBfurWrzNSYOYlqpWurk.cyYLjLunMFfNePcODBLCUxCKoBXV(num3, b) ? ((byte)(P_1[num] | (1 << num2))) : ((byte)(P_1[num] & ~(1 << num2))));
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void yocKFSxqfkDusdcpwaUaHtLZVnvUA(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		ZBWBIwrAJtFDxFbEYnplSlDOEsFBA(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void vnTnXKLkdHZVIzKOLhTiTFUhasRb(int P_0, out byte P_1)
	{
		byte b = 0;
		byte* ptr = &b;
		ZBWBIwrAJtFDxFbEYnplSlDOEsFBA(P_0, ptr, 64);
		P_1 = b;
	}

	public void wxQIARrfZhRVMaKgWSniNoiSKUrT(int P_0, out sbyte P_1)
	{
		vnTnXKLkdHZVIzKOLhTiTFUhasRb(P_0, out var b);
		P_1 = (sbyte)b;
	}

	public unsafe void rGyzUzjIFrmfxUDXYeehJBTaUflwA(int P_0, out short P_1)
	{
		short num = 0;
		byte* ptr = (byte*)(&num);
		ZBWBIwrAJtFDxFbEYnplSlDOEsFBA(P_0, ptr, 64);
		P_1 = num;
	}

	public void qYcJmZBiFwfExgaTKAXABRcKPBvfB(int P_0, out ushort P_1)
	{
		rGyzUzjIFrmfxUDXYeehJBTaUflwA(P_0, out var num);
		P_1 = (ushort)num;
	}

	public unsafe void BupgvalkOGbmeJxasLPExeDGoiWJA(int P_0, out int P_1)
	{
		int num = 0;
		byte* ptr = (byte*)(&num);
		ZBWBIwrAJtFDxFbEYnplSlDOEsFBA(P_0, ptr, 64);
		P_1 = num;
	}

	public void BBlcJjoAOmEGcMnBZAWHfcOwRnGD(int P_0, out uint P_1)
	{
		BupgvalkOGbmeJxasLPExeDGoiWJA(P_0, out var num);
		P_1 = (uint)num;
	}

	public unsafe void xzkWpPasZngbsMqIwiOkfaLHgevi(int P_0, out long P_1)
	{
		long num = 0L;
		byte* ptr = (byte*)(&num);
		ZBWBIwrAJtFDxFbEYnplSlDOEsFBA(P_0, ptr, 64);
		P_1 = num;
	}

	public void RiVqftWwilMjCFZzybiUkJhrGyQQ(int P_0, out ulong P_1)
	{
		xzkWpPasZngbsMqIwiOkfaLHgevi(P_0, out var num);
		P_1 = (ulong)num;
	}

	public void xPhPscNvbuCIPdqWIPcAJcPqyREY(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= HYSQhwHEktukDmNYeCybdacBkpdgb)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < RkcOCwFHiQBlKOQIczmflSGmqBXM)
		{
			int rkcOCwFHiQBlKOQIczmflSGmqBXM = RkcOCwFHiQBlKOQIczmflSGmqBXM;
			throw new Exception("valueBuffer.Length must be >= " + rkcOCwFHiQBlKOQIczmflSGmqBXM);
		}
		for (int i = 0; i < RkcOCwFHiQBlKOQIczmflSGmqBXM; i++)
		{
			xelNeHuxAqItiikmcEfXhtIVlpZR(P_0, i, out var num, out var b);
			P_1[i] = NYfzpsUqIBfurWrzNSYOYlqpWurk.cyYLjLunMFfNePcODBLCUxCKoBXV(num, b);
		}
	}

	public unsafe void mfdWIbdMPjpKGzhshzdeLKamForn(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= HYSQhwHEktukDmNYeCybdacBkpdgb)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 <= 0)
		{
			throw new Exception("bufferSize must be >= 0");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < RkcOCwFHiQBlKOQIczmflSGmqBXM; i++)
		{
			xelNeHuxAqItiikmcEfXhtIVlpZR(P_0, i, out var num3, out var b);
			bool flag = i < P_2 && (flag = (P_1[num] & (1 << num2)) != 0);
			NYfzpsUqIBfurWrzNSYOYlqpWurk.ebrrIfEDaskkmxOGZfoQmlcGbRcj(num3, b, flag);
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void KHRqUsEFyUbUkYnVFEVzbjAlsFnF(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		mfdWIbdMPjpKGzhshzdeLKamForn(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void KavbphCEAlVLFMmqPjycPBIzNyEw(int P_0, byte P_1)
	{
		byte* ptr = &P_1;
		mfdWIbdMPjpKGzhshzdeLKamForn(P_0, ptr, 8);
	}

	public void qFUfugzyvgbdcfncRLrmtbnKrMNp(int P_0, sbyte P_1)
	{
		KavbphCEAlVLFMmqPjycPBIzNyEw(P_0, (byte)P_1);
	}

	public unsafe void SZrcazgTPsWeabCoZTOthOpXXMLHA(int P_0, short P_1)
	{
		byte* ptr = (byte*)(&P_1);
		mfdWIbdMPjpKGzhshzdeLKamForn(P_0, ptr, 16);
	}

	public void rxWadwXWaZLIoEdzPzzxnUTCIWoi(int P_0, ushort P_1)
	{
		SZrcazgTPsWeabCoZTOthOpXXMLHA(P_0, (short)P_1);
	}

	public unsafe void kYEcduDHoeFtiFbukAeaixTbtwFgC(int P_0, int P_1)
	{
		byte* ptr = (byte*)(&P_1);
		mfdWIbdMPjpKGzhshzdeLKamForn(P_0, ptr, 32);
	}

	public void YuvuVTgPOdNFstJMCkhSRIeFZQar(int P_0, uint P_1)
	{
		kYEcduDHoeFtiFbukAeaixTbtwFgC(P_0, (int)P_1);
	}

	public unsafe void ZrBiCifCvagWaFdLemLNQpALoQZR(int P_0, long P_1)
	{
		byte* ptr = (byte*)(&P_1);
		mfdWIbdMPjpKGzhshzdeLKamForn(P_0, ptr, 64);
	}

	public void KfLzAXRmRkasfFBQTtmaKxlfTpHI(int P_0, ulong P_1)
	{
		ZrBiCifCvagWaFdLemLNQpALoQZR(P_0, (long)P_1);
	}

	public void MHsxfSouShWNklESopitPEyZTIqL(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= HYSQhwHEktukDmNYeCybdacBkpdgb)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < RkcOCwFHiQBlKOQIczmflSGmqBXM)
		{
			int rkcOCwFHiQBlKOQIczmflSGmqBXM = RkcOCwFHiQBlKOQIczmflSGmqBXM;
			throw new Exception("valueBuffer.Length must be >= " + rkcOCwFHiQBlKOQIczmflSGmqBXM);
		}
		for (int i = 0; i < RkcOCwFHiQBlKOQIczmflSGmqBXM; i++)
		{
			xelNeHuxAqItiikmcEfXhtIVlpZR(P_0, i, out var num, out var b);
			NYfzpsUqIBfurWrzNSYOYlqpWurk.ebrrIfEDaskkmxOGZfoQmlcGbRcj(num, b, P_1[i]);
		}
	}

	private void xelNeHuxAqItiikmcEfXhtIVlpZR(int P_0, int P_1, out int P_2, out byte P_3)
	{
		if (P_0 < 0 || P_0 >= HYSQhwHEktukDmNYeCybdacBkpdgb)
		{
			throw new IndexOutOfRangeException("entryIndex");
		}
		if (P_1 < 0 || P_1 >= RkcOCwFHiQBlKOQIczmflSGmqBXM)
		{
			throw new ArgumentOutOfRangeException("bitOffset");
		}
		int num = P_0 * RkcOCwFHiQBlKOQIczmflSGmqBXM + P_1;
		P_2 = num / RkcOCwFHiQBlKOQIczmflSGmqBXM;
		P_3 = (byte)(num - P_2 * RkcOCwFHiQBlKOQIczmflSGmqBXM);
	}

	private int ltierULZvoqpoiRNlqqcHdywbKTn(int P_0, out byte P_1)
	{
		if (P_0 < 0 || P_0 >= HYSQhwHEktukDmNYeCybdacBkpdgb * RkcOCwFHiQBlKOQIczmflSGmqBXM)
		{
			throw new IndexOutOfRangeException("bitIndex");
		}
		int num = P_0 / RkcOCwFHiQBlKOQIczmflSGmqBXM;
		P_1 = (byte)(P_0 - num * RkcOCwFHiQBlKOQIczmflSGmqBXM);
		return num;
	}

	public void Dispose()
	{
		DfaGTQaAFDyfoLgmbQeNFafVHahyA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void RsDNRGMRzkidaXOnLVJPzpMFwlmi()
	{
		try
		{
			DfaGTQaAFDyfoLgmbQeNFafVHahyA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void DfaGTQaAFDyfoLgmbQeNFafVHahyA(bool P_0)
	{
		if (!gNkcBTHPVtatmtsxVhdUpTkybDWtA)
		{
			if (P_0 && NYfzpsUqIBfurWrzNSYOYlqpWurk != null)
			{
				NYfzpsUqIBfurWrzNSYOYlqpWurk.Dispose();
			}
			gNkcBTHPVtatmtsxVhdUpTkybDWtA = true;
		}
	}
}
