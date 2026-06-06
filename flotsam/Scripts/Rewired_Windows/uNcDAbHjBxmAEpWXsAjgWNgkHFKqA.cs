using System;

internal class uNcDAbHjBxmAEpWXsAjgWNgkHFKqA : IDisposable
{
	private readonly GhZlVkTHikiQVkHTKPgKHUKBJNyUb BjQBEyQkXLYUZmQurBsYNqQsEOPIA;

	private bool[] xiAhAyslIBUroXKedQtFtLxNaeoq;

	protected readonly int RXpnemNvOqXsdyHaESphkiAdNEnd;

	protected readonly int JEhMkuFzuxEtjERQEMbbbAMQlTJI;

	private bool yTFgBHDxUnZCCAzelJdAYXCxNHsi;

	public int tDeUpTwHaotElAJxPMXdgFWvtgYk => RXpnemNvOqXsdyHaESphkiAdNEnd;

	public int wXdnrQwHcrZeRuFFAIcoZsmlEeAh => JEhMkuFzuxEtjERQEMbbbAMQlTJI;

	public bool[] kjNTQBnHFvqaynykEVAgXlNdJrsS => xiAhAyslIBUroXKedQtFtLxNaeoq ?? (xiAhAyslIBUroXKedQtFtLxNaeoq = new bool[RXpnemNvOqXsdyHaESphkiAdNEnd]);

	public uNcDAbHjBxmAEpWXsAjgWNgkHFKqA(int P_0, int P_1)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("entryBitSize");
		}
		JEhMkuFzuxEtjERQEMbbbAMQlTJI = P_0;
		RXpnemNvOqXsdyHaESphkiAdNEnd = P_1;
		int num = P_0 * P_1;
		int num2 = num / 8 + ((num % 8 != 0) ? 1 : 0);
		BjQBEyQkXLYUZmQurBsYNqQsEOPIA = new GhZlVkTHikiQVkHTKPgKHUKBJNyUb(num2);
	}

	public unsafe void PFnGgwBxOpWjXRdJuuBnCXbJXgplA(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= JEhMkuFzuxEtjERQEMbbbAMQlTJI)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 < RXpnemNvOqXsdyHaESphkiAdNEnd)
		{
			int rXpnemNvOqXsdyHaESphkiAdNEnd = RXpnemNvOqXsdyHaESphkiAdNEnd;
			throw new Exception("Buffer is too small to hold the data. Must be at least " + rXpnemNvOqXsdyHaESphkiAdNEnd + " bits.");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < RXpnemNvOqXsdyHaESphkiAdNEnd; i++)
		{
			tGBZBeLyqLMpWfBCPFouydAdvSB(P_0, i, out var num3, out var b);
			P_1[i] = (BjQBEyQkXLYUZmQurBsYNqQsEOPIA.mpzgqNEmZVVFKsrBjufAfPsDOBtKA(num3, b) ? ((byte)(P_1[num] | (1 << num2))) : ((byte)(P_1[num] & ~(1 << num2))));
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void swJacMjEssEtQXqeEoGmmBxSHrBR(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		PFnGgwBxOpWjXRdJuuBnCXbJXgplA(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void prwrYZHBpTApbjRPbyHBKEncfoKFb(int P_0, out byte P_1)
	{
		byte b = 0;
		byte* ptr = &b;
		PFnGgwBxOpWjXRdJuuBnCXbJXgplA(P_0, ptr, 64);
		P_1 = b;
	}

	public void kHxtqTvjKftrcKddgDLuWFEVIqLf(int P_0, out sbyte P_1)
	{
		prwrYZHBpTApbjRPbyHBKEncfoKFb(P_0, out var b);
		P_1 = (sbyte)b;
	}

	public unsafe void hUDcznjZCvhHRuQIaaUfGSzvezBS(int P_0, out short P_1)
	{
		short num = 0;
		byte* ptr = (byte*)(&num);
		PFnGgwBxOpWjXRdJuuBnCXbJXgplA(P_0, ptr, 64);
		P_1 = num;
	}

	public void qgNDTHFeCgkmPUcGclvGOFCSTvNh(int P_0, out ushort P_1)
	{
		hUDcznjZCvhHRuQIaaUfGSzvezBS(P_0, out var num);
		P_1 = (ushort)num;
	}

	public unsafe void XrKYoajFFEUmSZwnQjOQbXfXqykI(int P_0, out int P_1)
	{
		int num = 0;
		byte* ptr = (byte*)(&num);
		PFnGgwBxOpWjXRdJuuBnCXbJXgplA(P_0, ptr, 64);
		P_1 = num;
	}

	public void DCMtRryiJgumMsQexogBcrErQLms(int P_0, out uint P_1)
	{
		XrKYoajFFEUmSZwnQjOQbXfXqykI(P_0, out var num);
		P_1 = (uint)num;
	}

	public unsafe void ndPhbVaqQlEUGsyZEeAeKotEOmFmA(int P_0, out long P_1)
	{
		long num = 0L;
		byte* ptr = (byte*)(&num);
		PFnGgwBxOpWjXRdJuuBnCXbJXgplA(P_0, ptr, 64);
		P_1 = num;
	}

	public void VRiQGbSjmjHUqzyqGIdUjHfwwUse(int P_0, out ulong P_1)
	{
		ndPhbVaqQlEUGsyZEeAeKotEOmFmA(P_0, out var num);
		P_1 = (ulong)num;
	}

	public void fSuZsHHywmotTNRosWOcWntrPqFA(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= JEhMkuFzuxEtjERQEMbbbAMQlTJI)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < RXpnemNvOqXsdyHaESphkiAdNEnd)
		{
			int rXpnemNvOqXsdyHaESphkiAdNEnd = RXpnemNvOqXsdyHaESphkiAdNEnd;
			throw new Exception("valueBuffer.Length must be >= " + rXpnemNvOqXsdyHaESphkiAdNEnd);
		}
		for (int i = 0; i < RXpnemNvOqXsdyHaESphkiAdNEnd; i++)
		{
			tGBZBeLyqLMpWfBCPFouydAdvSB(P_0, i, out var num, out var b);
			P_1[i] = BjQBEyQkXLYUZmQurBsYNqQsEOPIA.mpzgqNEmZVVFKsrBjufAfPsDOBtKA(num, b);
		}
	}

	public unsafe void yCIbibndEnkmwPWnHfTqSCOxDoNcA(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= JEhMkuFzuxEtjERQEMbbbAMQlTJI)
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
		for (int i = 0; i < RXpnemNvOqXsdyHaESphkiAdNEnd; i++)
		{
			tGBZBeLyqLMpWfBCPFouydAdvSB(P_0, i, out var num3, out var b);
			bool flag = i < P_2 && (flag = (P_1[num] & (1 << num2)) != 0);
			BjQBEyQkXLYUZmQurBsYNqQsEOPIA.wdOmIdGavwSAIZjPtuDYrcOHDjQHA(num3, b, flag);
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void WxgETwSqMGGRWCgoxjsbqwJgmoXvA(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		yCIbibndEnkmwPWnHfTqSCOxDoNcA(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void YcSbCniWNxMzvDwzdkAiGGyaoacUA(int P_0, byte P_1)
	{
		byte* ptr = &P_1;
		yCIbibndEnkmwPWnHfTqSCOxDoNcA(P_0, ptr, 8);
	}

	public void idfLbajfckNgOZhffGVeclVVpShM(int P_0, sbyte P_1)
	{
		YcSbCniWNxMzvDwzdkAiGGyaoacUA(P_0, (byte)P_1);
	}

	public unsafe void MJKNafXzOmMmMcqpfcxhDoZYQYxI(int P_0, short P_1)
	{
		byte* ptr = (byte*)(&P_1);
		yCIbibndEnkmwPWnHfTqSCOxDoNcA(P_0, ptr, 16);
	}

	public void dlfFLsDRdVddSlskhlNrEkpIHMQNB(int P_0, ushort P_1)
	{
		MJKNafXzOmMmMcqpfcxhDoZYQYxI(P_0, (short)P_1);
	}

	public unsafe void oitWLaPLjyXXGNnfyMpaqojkyeUh(int P_0, int P_1)
	{
		byte* ptr = (byte*)(&P_1);
		yCIbibndEnkmwPWnHfTqSCOxDoNcA(P_0, ptr, 32);
	}

	public void CiWeuLoIFhIlWDUHopVGSqSEkOKO(int P_0, uint P_1)
	{
		oitWLaPLjyXXGNnfyMpaqojkyeUh(P_0, (int)P_1);
	}

	public unsafe void TvgCDcHvqgKaGxdIWLfFARckCIpub(int P_0, long P_1)
	{
		byte* ptr = (byte*)(&P_1);
		yCIbibndEnkmwPWnHfTqSCOxDoNcA(P_0, ptr, 64);
	}

	public void KIucIHITOsqSZgnPnJFqDNHmlPdDb(int P_0, ulong P_1)
	{
		TvgCDcHvqgKaGxdIWLfFARckCIpub(P_0, (long)P_1);
	}

	public void MzBAIQAeJvNyKPNXIwLnbYAIhZIFA(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= JEhMkuFzuxEtjERQEMbbbAMQlTJI)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < RXpnemNvOqXsdyHaESphkiAdNEnd)
		{
			int rXpnemNvOqXsdyHaESphkiAdNEnd = RXpnemNvOqXsdyHaESphkiAdNEnd;
			throw new Exception("valueBuffer.Length must be >= " + rXpnemNvOqXsdyHaESphkiAdNEnd);
		}
		for (int i = 0; i < RXpnemNvOqXsdyHaESphkiAdNEnd; i++)
		{
			tGBZBeLyqLMpWfBCPFouydAdvSB(P_0, i, out var num, out var b);
			BjQBEyQkXLYUZmQurBsYNqQsEOPIA.wdOmIdGavwSAIZjPtuDYrcOHDjQHA(num, b, P_1[i]);
		}
	}

	private void tGBZBeLyqLMpWfBCPFouydAdvSB(int P_0, int P_1, out int P_2, out byte P_3)
	{
		if (P_0 < 0 || P_0 >= JEhMkuFzuxEtjERQEMbbbAMQlTJI)
		{
			throw new IndexOutOfRangeException("entryIndex");
		}
		if (P_1 < 0 || P_1 >= RXpnemNvOqXsdyHaESphkiAdNEnd)
		{
			throw new ArgumentOutOfRangeException("bitOffset");
		}
		int num = P_0 * RXpnemNvOqXsdyHaESphkiAdNEnd + P_1;
		P_2 = num / RXpnemNvOqXsdyHaESphkiAdNEnd;
		P_3 = (byte)(num - P_2 * RXpnemNvOqXsdyHaESphkiAdNEnd);
	}

	private int zvDYXSNwoymMYIEIHpUgCsMlEUzP(int P_0, out byte P_1)
	{
		if (P_0 < 0 || P_0 >= JEhMkuFzuxEtjERQEMbbbAMQlTJI * RXpnemNvOqXsdyHaESphkiAdNEnd)
		{
			throw new IndexOutOfRangeException("bitIndex");
		}
		int num = P_0 / RXpnemNvOqXsdyHaESphkiAdNEnd;
		P_1 = (byte)(P_0 - num * RXpnemNvOqXsdyHaESphkiAdNEnd);
		return num;
	}

	public void Dispose()
	{
		VyVywSEqGPVKOOXtDISPbAVEyvHi(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void LwefiMaIoyQAUNpoxIdTrugYWqGLA()
	{
		try
		{
			VyVywSEqGPVKOOXtDISPbAVEyvHi(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void VyVywSEqGPVKOOXtDISPbAVEyvHi(bool P_0)
	{
		if (!yTFgBHDxUnZCCAzelJdAYXCxNHsi)
		{
			if (P_0 && BjQBEyQkXLYUZmQurBsYNqQsEOPIA != null)
			{
				BjQBEyQkXLYUZmQurBsYNqQsEOPIA.Dispose();
			}
			yTFgBHDxUnZCCAzelJdAYXCxNHsi = true;
		}
	}
}
