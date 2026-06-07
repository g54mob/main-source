using System;

internal class sAjmlKOWVynyDYSdRKwHrkcSEbWb : IDisposable
{
	private readonly GPQlDciUdfdOnXgKBdRMipKfgYXfA TyDHgevLGYdtvsDxsgHIplEGbDgGA;

	private bool[] pWXoKcJzTEALQFOvaWUJPsldnURJ;

	protected readonly int ZnWZLwipkDFcGEwIFXlnCOyHFKUlA;

	protected readonly int VckEcwegeyvhFsAMNZjlTVMkViyWA;

	private bool gMULUXgLDoVcwKujkMsCkNKNwOPr;

	public int pypVgFJXrzwKDIseQcttIWALckjqA => ZnWZLwipkDFcGEwIFXlnCOyHFKUlA;

	public int uRoGPnhRKePkEimCFPpqzhuHZPxDb => VckEcwegeyvhFsAMNZjlTVMkViyWA;

	public bool[] cNCorJAWliXQOplqZllmhXCPejTG => pWXoKcJzTEALQFOvaWUJPsldnURJ ?? (pWXoKcJzTEALQFOvaWUJPsldnURJ = new bool[ZnWZLwipkDFcGEwIFXlnCOyHFKUlA]);

	public sAjmlKOWVynyDYSdRKwHrkcSEbWb(int P_0, int P_1)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("entryBitSize");
		}
		VckEcwegeyvhFsAMNZjlTVMkViyWA = P_0;
		ZnWZLwipkDFcGEwIFXlnCOyHFKUlA = P_1;
		int num = P_0 * P_1;
		TyDHgevLGYdtvsDxsgHIplEGbDgGA = new GPQlDciUdfdOnXgKBdRMipKfgYXfA(num / 8 + ((num % 8 != 0) ? 1 : 0));
	}

	public unsafe void XrwEwqGPbkEtalAozknXrnlDbSab(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= VckEcwegeyvhFsAMNZjlTVMkViyWA)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 < ZnWZLwipkDFcGEwIFXlnCOyHFKUlA)
		{
			int znWZLwipkDFcGEwIFXlnCOyHFKUlA = ZnWZLwipkDFcGEwIFXlnCOyHFKUlA;
			throw new Exception("Buffer is too small to hold the data. Must be at least " + znWZLwipkDFcGEwIFXlnCOyHFKUlA + " bits.");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < ZnWZLwipkDFcGEwIFXlnCOyHFKUlA; i++)
		{
			zQRabBfZYhJaooYcVpgJeYwyacUSA(P_0, i, out var num3, out var b);
			P_1[i] = (TyDHgevLGYdtvsDxsgHIplEGbDgGA.svsAPXXUySysQfQeaKQytwvRGGDb(num3, b) ? ((byte)(P_1[num] | (1 << num2))) : ((byte)(P_1[num] & ~(1 << num2))));
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void alAzCCIylhkbiRatTaJaACxaHsqFb(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		XrwEwqGPbkEtalAozknXrnlDbSab(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void dYvmURyLiIEDVZKKcaPHuppEzQdH(int P_0, out byte P_1)
	{
		byte b = 0;
		byte* ptr = &b;
		XrwEwqGPbkEtalAozknXrnlDbSab(P_0, ptr, 64);
		P_1 = b;
	}

	public void iZwvDRKoViCtEWAmlGuksuMnqNsx(int P_0, out sbyte P_1)
	{
		dYvmURyLiIEDVZKKcaPHuppEzQdH(P_0, out var b);
		P_1 = (sbyte)b;
	}

	public unsafe void tlOJDbUeFeCovhaTpBtdXobBWmaUA(int P_0, out short P_1)
	{
		short num = 0;
		byte* ptr = (byte*)(&num);
		XrwEwqGPbkEtalAozknXrnlDbSab(P_0, ptr, 64);
		P_1 = num;
	}

	public void mAUxfVyPJzzTbYYZfrCUceIuFQwEA(int P_0, out ushort P_1)
	{
		tlOJDbUeFeCovhaTpBtdXobBWmaUA(P_0, out var num);
		P_1 = (ushort)num;
	}

	public unsafe void BdVAukiQGFgtyPNaDKOSYHljJvNiA(int P_0, out int P_1)
	{
		int num = 0;
		byte* ptr = (byte*)(&num);
		XrwEwqGPbkEtalAozknXrnlDbSab(P_0, ptr, 64);
		P_1 = num;
	}

	public void VRDbazNDQdDPuofrqUVFMxSLKENw(int P_0, out uint P_1)
	{
		BdVAukiQGFgtyPNaDKOSYHljJvNiA(P_0, out var num);
		P_1 = (uint)num;
	}

	public unsafe void fMQTkVXTtotmvmYZBdaCGdCepoVc(int P_0, out long P_1)
	{
		long num = 0L;
		byte* ptr = (byte*)(&num);
		XrwEwqGPbkEtalAozknXrnlDbSab(P_0, ptr, 64);
		P_1 = num;
	}

	public void PNzfuxFpyojiGXphDJlEFDJAMzNJB(int P_0, out ulong P_1)
	{
		fMQTkVXTtotmvmYZBdaCGdCepoVc(P_0, out var num);
		P_1 = (ulong)num;
	}

	public void tHBbjwaVzjcHPaFMbAzEPczVxWThA(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= VckEcwegeyvhFsAMNZjlTVMkViyWA)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < ZnWZLwipkDFcGEwIFXlnCOyHFKUlA)
		{
			int znWZLwipkDFcGEwIFXlnCOyHFKUlA = ZnWZLwipkDFcGEwIFXlnCOyHFKUlA;
			throw new Exception("valueBuffer.Length must be >= " + znWZLwipkDFcGEwIFXlnCOyHFKUlA);
		}
		for (int i = 0; i < ZnWZLwipkDFcGEwIFXlnCOyHFKUlA; i++)
		{
			zQRabBfZYhJaooYcVpgJeYwyacUSA(P_0, i, out var num, out var b);
			P_1[i] = TyDHgevLGYdtvsDxsgHIplEGbDgGA.svsAPXXUySysQfQeaKQytwvRGGDb(num, b);
		}
	}

	public unsafe void cOHFLdCiRssLWNIyUMeqmHCNXbcM(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= VckEcwegeyvhFsAMNZjlTVMkViyWA)
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
		for (int i = 0; i < ZnWZLwipkDFcGEwIFXlnCOyHFKUlA; i++)
		{
			zQRabBfZYhJaooYcVpgJeYwyacUSA(P_0, i, out var num3, out var b);
			bool flag = i < P_2 && (flag = (P_1[num] & (1 << num2)) != 0);
			TyDHgevLGYdtvsDxsgHIplEGbDgGA.qrBcmhfqolxpaBWYkpoQBXEhlkpy(num3, b, flag);
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void YhhazyxMLBJqkuPngsLdAODWUdcu(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		cOHFLdCiRssLWNIyUMeqmHCNXbcM(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void SnXaKhpfIuQePyLocdlymFwUArZx(int P_0, byte P_1)
	{
		byte* ptr = &P_1;
		cOHFLdCiRssLWNIyUMeqmHCNXbcM(P_0, ptr, 8);
	}

	public void aQqwnyIDldWkgBUiwwukWEJtjFSR(int P_0, sbyte P_1)
	{
		SnXaKhpfIuQePyLocdlymFwUArZx(P_0, (byte)P_1);
	}

	public unsafe void MwXQvfaoXvRhyqlyyIJthRLibXEt(int P_0, short P_1)
	{
		byte* ptr = (byte*)(&P_1);
		cOHFLdCiRssLWNIyUMeqmHCNXbcM(P_0, ptr, 16);
	}

	public void bwoxuJaiwGCicwneegirUfrnHWvC(int P_0, ushort P_1)
	{
		MwXQvfaoXvRhyqlyyIJthRLibXEt(P_0, (short)P_1);
	}

	public unsafe void cBsOgmuCsvqmuJTmxutmKppOfdvjA(int P_0, int P_1)
	{
		byte* ptr = (byte*)(&P_1);
		cOHFLdCiRssLWNIyUMeqmHCNXbcM(P_0, ptr, 32);
	}

	public void SWRfCHXxQyTWuJWQhkyYajGuDJlS(int P_0, uint P_1)
	{
		cBsOgmuCsvqmuJTmxutmKppOfdvjA(P_0, (int)P_1);
	}

	public unsafe void TBdxjyYxHnHgsxHJXAARtiqeFqAF(int P_0, long P_1)
	{
		byte* ptr = (byte*)(&P_1);
		cOHFLdCiRssLWNIyUMeqmHCNXbcM(P_0, ptr, 64);
	}

	public void YKraDiaRgfpDdvGxgyemvNROQpOE(int P_0, ulong P_1)
	{
		TBdxjyYxHnHgsxHJXAARtiqeFqAF(P_0, (long)P_1);
	}

	public void YFMmWCJUIiBkuPGGDuaniDUcKdlj(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= VckEcwegeyvhFsAMNZjlTVMkViyWA)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < ZnWZLwipkDFcGEwIFXlnCOyHFKUlA)
		{
			int znWZLwipkDFcGEwIFXlnCOyHFKUlA = ZnWZLwipkDFcGEwIFXlnCOyHFKUlA;
			throw new Exception("valueBuffer.Length must be >= " + znWZLwipkDFcGEwIFXlnCOyHFKUlA);
		}
		for (int i = 0; i < ZnWZLwipkDFcGEwIFXlnCOyHFKUlA; i++)
		{
			zQRabBfZYhJaooYcVpgJeYwyacUSA(P_0, i, out var num, out var b);
			TyDHgevLGYdtvsDxsgHIplEGbDgGA.qrBcmhfqolxpaBWYkpoQBXEhlkpy(num, b, P_1[i]);
		}
	}

	private void zQRabBfZYhJaooYcVpgJeYwyacUSA(int P_0, int P_1, out int P_2, out byte P_3)
	{
		if (P_0 < 0 || P_0 >= VckEcwegeyvhFsAMNZjlTVMkViyWA)
		{
			throw new IndexOutOfRangeException("entryIndex");
		}
		if (P_1 < 0 || P_1 >= ZnWZLwipkDFcGEwIFXlnCOyHFKUlA)
		{
			throw new ArgumentOutOfRangeException("bitOffset");
		}
		int num = P_0 * ZnWZLwipkDFcGEwIFXlnCOyHFKUlA + P_1;
		P_2 = num / ZnWZLwipkDFcGEwIFXlnCOyHFKUlA;
		P_3 = (byte)(num - P_2 * ZnWZLwipkDFcGEwIFXlnCOyHFKUlA);
	}

	private int pzObmWeGzhzykETqYhfooGVLJHKf(int P_0, out byte P_1)
	{
		if (P_0 < 0 || P_0 >= VckEcwegeyvhFsAMNZjlTVMkViyWA * ZnWZLwipkDFcGEwIFXlnCOyHFKUlA)
		{
			throw new IndexOutOfRangeException("bitIndex");
		}
		int num = P_0 / ZnWZLwipkDFcGEwIFXlnCOyHFKUlA;
		P_1 = (byte)(P_0 - num * ZnWZLwipkDFcGEwIFXlnCOyHFKUlA);
		return num;
	}

	public void Dispose()
	{
		HrWrMWfITWHicGjuYRhBPDDobxcz(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void DYdAKCjhiprmarfEwSLBKetmhEtC()
	{
		try
		{
			HrWrMWfITWHicGjuYRhBPDDobxcz(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void HrWrMWfITWHicGjuYRhBPDDobxcz(bool P_0)
	{
		if (!gMULUXgLDoVcwKujkMsCkNKNwOPr)
		{
			if (P_0 && TyDHgevLGYdtvsDxsgHIplEGbDgGA != null)
			{
				TyDHgevLGYdtvsDxsgHIplEGbDgGA.Dispose();
			}
			gMULUXgLDoVcwKujkMsCkNKNwOPr = true;
		}
	}
}
