using System;

internal class brGYxilvogFlgfSYdOtbQXOpBTKo : IDisposable
{
	private readonly XDbjydBaRflbbcCWXMsNJdiGwFsu OlabzfIkgEvSdRIleGiJAWsrcADV;

	private bool[] qmsQtvaPrWAIWbgpgNtMRaLCNegmA;

	protected readonly int SWlOIfDETHeFWDIwBAhktkUyNcdL;

	protected readonly int CIFlvbXYDcbgFfHUPGUuitiNjQVF;

	private bool tXxBXEFChqakefzburBLNfagwLaS;

	public int iScrKoLXpVSZpneIhMecrqwMfKDb => SWlOIfDETHeFWDIwBAhktkUyNcdL;

	public int nBZMwiwungePUJMqJWCtGOLgGaAd => CIFlvbXYDcbgFfHUPGUuitiNjQVF;

	public bool[] vhdgvMhjsspTCdYhRUGlUQjcAzatA => qmsQtvaPrWAIWbgpgNtMRaLCNegmA ?? (qmsQtvaPrWAIWbgpgNtMRaLCNegmA = new bool[SWlOIfDETHeFWDIwBAhktkUyNcdL]);

	public brGYxilvogFlgfSYdOtbQXOpBTKo(int P_0, int P_1)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("entryBitSize");
		}
		CIFlvbXYDcbgFfHUPGUuitiNjQVF = P_0;
		SWlOIfDETHeFWDIwBAhktkUyNcdL = P_1;
		int num = P_0 * P_1;
		int num2 = num / 8 + ((num % 8 != 0) ? 1 : 0);
		OlabzfIkgEvSdRIleGiJAWsrcADV = new XDbjydBaRflbbcCWXMsNJdiGwFsu(num2);
	}

	public unsafe void CiXuFhvGbaIEzcMIfwPiEMJMHgppA(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= CIFlvbXYDcbgFfHUPGUuitiNjQVF)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 < SWlOIfDETHeFWDIwBAhktkUyNcdL)
		{
			int sWlOIfDETHeFWDIwBAhktkUyNcdL = SWlOIfDETHeFWDIwBAhktkUyNcdL;
			throw new Exception("Buffer is too small to hold the data. Must be at least " + sWlOIfDETHeFWDIwBAhktkUyNcdL + " bits.");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < SWlOIfDETHeFWDIwBAhktkUyNcdL; i++)
		{
			gzaafUidmrmvgvlkRPlSjxOHphlj(P_0, i, out var num3, out var b);
			P_1[i] = (OlabzfIkgEvSdRIleGiJAWsrcADV.nKHWBAkKoSFoaCdUcXvROwAQmRzr(num3, b) ? ((byte)(P_1[num] | (1 << num2))) : ((byte)(P_1[num] & ~(1 << num2))));
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void vxlTDPlXhtfwuwpPugphjZJzbVKA(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		CiXuFhvGbaIEzcMIfwPiEMJMHgppA(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void qnEHhOHDKESYVamIsJPUBuBdiyGS(int P_0, out byte P_1)
	{
		byte b = 0;
		byte* ptr = &b;
		CiXuFhvGbaIEzcMIfwPiEMJMHgppA(P_0, ptr, 64);
		P_1 = b;
	}

	public void bVwMKrcpwuMMfFuvfTlBXqSbELxA(int P_0, out sbyte P_1)
	{
		qnEHhOHDKESYVamIsJPUBuBdiyGS(P_0, out var b);
		P_1 = (sbyte)b;
	}

	public unsafe void cxnMAajLfeauxVTTtSdoHaDyavJU(int P_0, out short P_1)
	{
		short num = 0;
		byte* ptr = (byte*)(&num);
		CiXuFhvGbaIEzcMIfwPiEMJMHgppA(P_0, ptr, 64);
		P_1 = num;
	}

	public void hrPmWFixpSBrrgRfgdLaFgZoTBqA(int P_0, out ushort P_1)
	{
		cxnMAajLfeauxVTTtSdoHaDyavJU(P_0, out var num);
		P_1 = (ushort)num;
	}

	public unsafe void SMsjrnjwKPzwJecHRrELuPjEgzyd(int P_0, out int P_1)
	{
		int num = 0;
		byte* ptr = (byte*)(&num);
		CiXuFhvGbaIEzcMIfwPiEMJMHgppA(P_0, ptr, 64);
		P_1 = num;
	}

	public void KewGkgioujdHmPCrgquGxWumUByx(int P_0, out uint P_1)
	{
		SMsjrnjwKPzwJecHRrELuPjEgzyd(P_0, out var num);
		P_1 = (uint)num;
	}

	public unsafe void iFzUYMarzuKtsHBAHRYrfTZLufRl(int P_0, out long P_1)
	{
		long num = 0L;
		byte* ptr = (byte*)(&num);
		CiXuFhvGbaIEzcMIfwPiEMJMHgppA(P_0, ptr, 64);
		P_1 = num;
	}

	public void IvGjuaCGscwIAEhsXWLRqtQrkeqC(int P_0, out ulong P_1)
	{
		iFzUYMarzuKtsHBAHRYrfTZLufRl(P_0, out var num);
		P_1 = (ulong)num;
	}

	public void ysqqadPHTtPdHwvEnYvBJHXaRfaH(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= CIFlvbXYDcbgFfHUPGUuitiNjQVF)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < SWlOIfDETHeFWDIwBAhktkUyNcdL)
		{
			int sWlOIfDETHeFWDIwBAhktkUyNcdL = SWlOIfDETHeFWDIwBAhktkUyNcdL;
			throw new Exception("valueBuffer.Length must be >= " + sWlOIfDETHeFWDIwBAhktkUyNcdL);
		}
		for (int i = 0; i < SWlOIfDETHeFWDIwBAhktkUyNcdL; i++)
		{
			gzaafUidmrmvgvlkRPlSjxOHphlj(P_0, i, out var num, out var b);
			P_1[i] = OlabzfIkgEvSdRIleGiJAWsrcADV.nKHWBAkKoSFoaCdUcXvROwAQmRzr(num, b);
		}
	}

	public unsafe void pZmSichMduHEAyloQTexRKaeyVVg(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= CIFlvbXYDcbgFfHUPGUuitiNjQVF)
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
		for (int i = 0; i < SWlOIfDETHeFWDIwBAhktkUyNcdL; i++)
		{
			gzaafUidmrmvgvlkRPlSjxOHphlj(P_0, i, out var num3, out var b);
			bool flag = i < P_2 && (flag = (P_1[num] & (1 << num2)) != 0);
			OlabzfIkgEvSdRIleGiJAWsrcADV.rhmOfkYHYhvhiwYGaMJRklyGpSMK(num3, b, flag);
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void PVWQabWnhJMycVnfgxsmzQvdggPv(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		pZmSichMduHEAyloQTexRKaeyVVg(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void XgqDbqcOymLONAXcCgYvUHKItekQc(int P_0, byte P_1)
	{
		byte* ptr = &P_1;
		pZmSichMduHEAyloQTexRKaeyVVg(P_0, ptr, 8);
	}

	public void vZJiblrDmtibkoaygNNlxzOEEOre(int P_0, sbyte P_1)
	{
		XgqDbqcOymLONAXcCgYvUHKItekQc(P_0, (byte)P_1);
	}

	public unsafe void LGgawoPxlbNziZDqqNogYbdXcQjeA(int P_0, short P_1)
	{
		byte* ptr = (byte*)(&P_1);
		pZmSichMduHEAyloQTexRKaeyVVg(P_0, ptr, 16);
	}

	public void gMPtgbZnUKcYiZyfcuFkhQNAsUSv(int P_0, ushort P_1)
	{
		LGgawoPxlbNziZDqqNogYbdXcQjeA(P_0, (short)P_1);
	}

	public unsafe void pMLcnpZnYndeyewaluMnldFdVaQy(int P_0, int P_1)
	{
		byte* ptr = (byte*)(&P_1);
		pZmSichMduHEAyloQTexRKaeyVVg(P_0, ptr, 32);
	}

	public void DKaTzUwQcuWzywIifHgLXBmNYWIf(int P_0, uint P_1)
	{
		pMLcnpZnYndeyewaluMnldFdVaQy(P_0, (int)P_1);
	}

	public unsafe void MrOScldeDptNgIsDFcvWKkWJwAbV(int P_0, long P_1)
	{
		byte* ptr = (byte*)(&P_1);
		pZmSichMduHEAyloQTexRKaeyVVg(P_0, ptr, 64);
	}

	public void REWZjUTMdxOdzIMKwjVfWCprfPfhA(int P_0, ulong P_1)
	{
		MrOScldeDptNgIsDFcvWKkWJwAbV(P_0, (long)P_1);
	}

	public void HwdyrFqOesNJyyzSHQHeJPeFbPCjA(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= CIFlvbXYDcbgFfHUPGUuitiNjQVF)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < SWlOIfDETHeFWDIwBAhktkUyNcdL)
		{
			int sWlOIfDETHeFWDIwBAhktkUyNcdL = SWlOIfDETHeFWDIwBAhktkUyNcdL;
			throw new Exception("valueBuffer.Length must be >= " + sWlOIfDETHeFWDIwBAhktkUyNcdL);
		}
		for (int i = 0; i < SWlOIfDETHeFWDIwBAhktkUyNcdL; i++)
		{
			gzaafUidmrmvgvlkRPlSjxOHphlj(P_0, i, out var num, out var b);
			OlabzfIkgEvSdRIleGiJAWsrcADV.rhmOfkYHYhvhiwYGaMJRklyGpSMK(num, b, P_1[i]);
		}
	}

	private void gzaafUidmrmvgvlkRPlSjxOHphlj(int P_0, int P_1, out int P_2, out byte P_3)
	{
		if (P_0 < 0 || P_0 >= CIFlvbXYDcbgFfHUPGUuitiNjQVF)
		{
			throw new IndexOutOfRangeException("entryIndex");
		}
		if (P_1 < 0 || P_1 >= SWlOIfDETHeFWDIwBAhktkUyNcdL)
		{
			throw new ArgumentOutOfRangeException("bitOffset");
		}
		int num = P_0 * SWlOIfDETHeFWDIwBAhktkUyNcdL + P_1;
		P_2 = num / SWlOIfDETHeFWDIwBAhktkUyNcdL;
		P_3 = (byte)(num - P_2 * SWlOIfDETHeFWDIwBAhktkUyNcdL);
	}

	private int sszdoBBHFvTpaRxDObShdJqIgIpic(int P_0, out byte P_1)
	{
		if (P_0 < 0 || P_0 >= CIFlvbXYDcbgFfHUPGUuitiNjQVF * SWlOIfDETHeFWDIwBAhktkUyNcdL)
		{
			throw new IndexOutOfRangeException("bitIndex");
		}
		int num = P_0 / SWlOIfDETHeFWDIwBAhktkUyNcdL;
		P_1 = (byte)(P_0 - num * SWlOIfDETHeFWDIwBAhktkUyNcdL);
		return num;
	}

	public void Dispose()
	{
		EBrNTJIjbMbakdLmIWAMmuvPCcXq(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void GRMvRFSrZpKlwGMfevvSpvSRTgSS()
	{
		try
		{
			EBrNTJIjbMbakdLmIWAMmuvPCcXq(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void EBrNTJIjbMbakdLmIWAMmuvPCcXq(bool P_0)
	{
		if (!tXxBXEFChqakefzburBLNfagwLaS)
		{
			if (P_0 && OlabzfIkgEvSdRIleGiJAWsrcADV != null)
			{
				OlabzfIkgEvSdRIleGiJAWsrcADV.Dispose();
			}
			tXxBXEFChqakefzburBLNfagwLaS = true;
		}
	}
}
