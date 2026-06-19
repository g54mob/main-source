using System;

internal class JKVPRVrVudLGCpDTgKKoDfKthJPp : IDisposable
{
	private readonly fFicYORCqoZwZowJIRdCWZeAXNjG mgzKPIKkHVJLLRysnlRGFTgbQQIu;

	private bool[] ARbTVQemUBuFaktsjWkHzLWKkipg;

	protected readonly int oteWcKNqrMzCcVDRAudtkwQaPTyk;

	protected readonly int yEYTHMFYbdKVblVBKNbjfgkTHlYEA;

	private bool TrsHdtDWCbnMIdqovIsKIWumkFfJA;

	public int YiJBXbEuoqeuhCjzeJlnqgsmTbTHb => oteWcKNqrMzCcVDRAudtkwQaPTyk;

	public int JdWvoXsmLfXOmBbRAybkNvAgAUFy => yEYTHMFYbdKVblVBKNbjfgkTHlYEA;

	public bool[] FEcDkhxREvzleGohWbmsFnSsvane => ARbTVQemUBuFaktsjWkHzLWKkipg ?? (ARbTVQemUBuFaktsjWkHzLWKkipg = new bool[oteWcKNqrMzCcVDRAudtkwQaPTyk]);

	public JKVPRVrVudLGCpDTgKKoDfKthJPp(int P_0, int P_1)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("entryBitSize");
		}
		yEYTHMFYbdKVblVBKNbjfgkTHlYEA = P_0;
		oteWcKNqrMzCcVDRAudtkwQaPTyk = P_1;
		int num = P_0 * P_1;
		int num2 = num / 8 + ((num % 8 != 0) ? 1 : 0);
		mgzKPIKkHVJLLRysnlRGFTgbQQIu = new fFicYORCqoZwZowJIRdCWZeAXNjG(num2);
	}

	public unsafe void kGQfRQdQSpshLMFxuyvdVHZCslyC(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= yEYTHMFYbdKVblVBKNbjfgkTHlYEA)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 < oteWcKNqrMzCcVDRAudtkwQaPTyk)
		{
			int num = oteWcKNqrMzCcVDRAudtkwQaPTyk;
			throw new Exception("Buffer is too small to hold the data. Must be at least " + num + " bits.");
		}
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < oteWcKNqrMzCcVDRAudtkwQaPTyk; i++)
		{
			UkxzErkbLkSCMjOtCcgRirIZgtwu(P_0, i, out var num4, out var b);
			P_1[i] = (mgzKPIKkHVJLLRysnlRGFTgbQQIu.NjIldxshPLOpSOLJpEUONQMYDjem(num4, b) ? ((byte)(P_1[num2] | (1 << num3))) : ((byte)(P_1[num2] & ~(1 << num3))));
			num3++;
			if (num3 >= 8)
			{
				num2++;
				num3 = 0;
			}
		}
	}

	public unsafe void TqyZfijkkuTSGqamIeFcmmVTrnQT(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		kGQfRQdQSpshLMFxuyvdVHZCslyC(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void CkVAVbJLlHhajssRnOsTErDdNuFx(int P_0, out byte P_1)
	{
		byte b = 0;
		byte* ptr = &b;
		kGQfRQdQSpshLMFxuyvdVHZCslyC(P_0, ptr, 64);
		P_1 = b;
	}

	public void VhSByvvTKtgiohbfiXymrMsCKIYPA(int P_0, out sbyte P_1)
	{
		CkVAVbJLlHhajssRnOsTErDdNuFx(P_0, out var b);
		P_1 = (sbyte)b;
	}

	public unsafe void GGqNuJrrYvOOFTLGqPrzMCJqUfGv(int P_0, out short P_1)
	{
		short num = 0;
		byte* ptr = (byte*)(&num);
		kGQfRQdQSpshLMFxuyvdVHZCslyC(P_0, ptr, 64);
		P_1 = num;
	}

	public void BgwbKzkFQoRpDfrQciOMFSgEPJSHB(int P_0, out ushort P_1)
	{
		GGqNuJrrYvOOFTLGqPrzMCJqUfGv(P_0, out var num);
		P_1 = (ushort)num;
	}

	public unsafe void qKneTEKlLOFTAGupHQSKIrFPEmjnc(int P_0, out int P_1)
	{
		int num = 0;
		byte* ptr = (byte*)(&num);
		kGQfRQdQSpshLMFxuyvdVHZCslyC(P_0, ptr, 64);
		P_1 = num;
	}

	public void ewdSHNscToCnAVLkhNQDoGuiRUbl(int P_0, out uint P_1)
	{
		qKneTEKlLOFTAGupHQSKIrFPEmjnc(P_0, out var num);
		P_1 = (uint)num;
	}

	public unsafe void MzomPjsGmtFDSBVQAjHaaRSLoEWF(int P_0, out long P_1)
	{
		long num = 0L;
		byte* ptr = (byte*)(&num);
		kGQfRQdQSpshLMFxuyvdVHZCslyC(P_0, ptr, 64);
		P_1 = num;
	}

	public void sgLxFDYcbvDWmdYyOxdIUjzbGmzMA(int P_0, out ulong P_1)
	{
		MzomPjsGmtFDSBVQAjHaaRSLoEWF(P_0, out var num);
		P_1 = (ulong)num;
	}

	public void UYlvSSNMooCtnmzLkFnWMMLgENhw(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= yEYTHMFYbdKVblVBKNbjfgkTHlYEA)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < oteWcKNqrMzCcVDRAudtkwQaPTyk)
		{
			int num = oteWcKNqrMzCcVDRAudtkwQaPTyk;
			throw new Exception("valueBuffer.Length must be >= " + num);
		}
		for (int i = 0; i < oteWcKNqrMzCcVDRAudtkwQaPTyk; i++)
		{
			UkxzErkbLkSCMjOtCcgRirIZgtwu(P_0, i, out var num2, out var b);
			P_1[i] = mgzKPIKkHVJLLRysnlRGFTgbQQIu.NjIldxshPLOpSOLJpEUONQMYDjem(num2, b);
		}
	}

	public unsafe void XjdriPlqWjMvwkxbLWimCcwqGyEcA(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= yEYTHMFYbdKVblVBKNbjfgkTHlYEA)
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
		for (int i = 0; i < oteWcKNqrMzCcVDRAudtkwQaPTyk; i++)
		{
			UkxzErkbLkSCMjOtCcgRirIZgtwu(P_0, i, out var num3, out var b);
			bool flag = i < P_2 && (flag = (P_1[num] & (1 << num2)) != 0);
			mgzKPIKkHVJLLRysnlRGFTgbQQIu.FXjZEREwdcToIqKTbcREbVcCvpBL(num3, b, flag);
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void rALQGYMzMWQSYLsffTjjqAvjuSMF(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		XjdriPlqWjMvwkxbLWimCcwqGyEcA(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void ztqJTaYXnMuvzLxnuxmGAKzTwxFA(int P_0, byte P_1)
	{
		byte* ptr = &P_1;
		XjdriPlqWjMvwkxbLWimCcwqGyEcA(P_0, ptr, 8);
	}

	public void XXIESKdzmoFIWNojzgccVmhKxKez(int P_0, sbyte P_1)
	{
		ztqJTaYXnMuvzLxnuxmGAKzTwxFA(P_0, (byte)P_1);
	}

	public unsafe void rOdiCXVbGiAVQFufdHFleBpTCKywA(int P_0, short P_1)
	{
		byte* ptr = (byte*)(&P_1);
		XjdriPlqWjMvwkxbLWimCcwqGyEcA(P_0, ptr, 16);
	}

	public void ABQEmQPdLJmmKXoJzsDlaaBEOJPi(int P_0, ushort P_1)
	{
		rOdiCXVbGiAVQFufdHFleBpTCKywA(P_0, (short)P_1);
	}

	public unsafe void HqCjFOHovkOOOaPjqzvwwiXvJkTT(int P_0, int P_1)
	{
		byte* ptr = (byte*)(&P_1);
		XjdriPlqWjMvwkxbLWimCcwqGyEcA(P_0, ptr, 32);
	}

	public void luhqvfuLXlluGePJmaqACCeJUIDO(int P_0, uint P_1)
	{
		HqCjFOHovkOOOaPjqzvwwiXvJkTT(P_0, (int)P_1);
	}

	public unsafe void yPDIQEteqcpCTWEeCEePDAdLMpkd(int P_0, long P_1)
	{
		byte* ptr = (byte*)(&P_1);
		XjdriPlqWjMvwkxbLWimCcwqGyEcA(P_0, ptr, 64);
	}

	public void hTFLmnPgEkBeNKVXxwygBatjBqig(int P_0, ulong P_1)
	{
		yPDIQEteqcpCTWEeCEePDAdLMpkd(P_0, (long)P_1);
	}

	public void dZeNLgkBLhdAUslHCsmjQkxJHbVG(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= yEYTHMFYbdKVblVBKNbjfgkTHlYEA)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < oteWcKNqrMzCcVDRAudtkwQaPTyk)
		{
			int num = oteWcKNqrMzCcVDRAudtkwQaPTyk;
			throw new Exception("valueBuffer.Length must be >= " + num);
		}
		for (int i = 0; i < oteWcKNqrMzCcVDRAudtkwQaPTyk; i++)
		{
			UkxzErkbLkSCMjOtCcgRirIZgtwu(P_0, i, out var num2, out var b);
			mgzKPIKkHVJLLRysnlRGFTgbQQIu.FXjZEREwdcToIqKTbcREbVcCvpBL(num2, b, P_1[i]);
		}
	}

	private void UkxzErkbLkSCMjOtCcgRirIZgtwu(int P_0, int P_1, out int P_2, out byte P_3)
	{
		if (P_0 < 0 || P_0 >= yEYTHMFYbdKVblVBKNbjfgkTHlYEA)
		{
			throw new IndexOutOfRangeException("entryIndex");
		}
		if (P_1 < 0 || P_1 >= oteWcKNqrMzCcVDRAudtkwQaPTyk)
		{
			throw new ArgumentOutOfRangeException("bitOffset");
		}
		int num = P_0 * oteWcKNqrMzCcVDRAudtkwQaPTyk + P_1;
		P_2 = num / oteWcKNqrMzCcVDRAudtkwQaPTyk;
		P_3 = (byte)(num - P_2 * oteWcKNqrMzCcVDRAudtkwQaPTyk);
	}

	private int GFqIkWNisgHIcfGhBrjkOuTmMLaD(int P_0, out byte P_1)
	{
		if (P_0 < 0 || P_0 >= yEYTHMFYbdKVblVBKNbjfgkTHlYEA * oteWcKNqrMzCcVDRAudtkwQaPTyk)
		{
			throw new IndexOutOfRangeException("bitIndex");
		}
		int num = P_0 / oteWcKNqrMzCcVDRAudtkwQaPTyk;
		P_1 = (byte)(P_0 - num * oteWcKNqrMzCcVDRAudtkwQaPTyk);
		return num;
	}

	public void Dispose()
	{
		wZcDvqYJYPCwEnHhHFrHnwjZQsIP(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void sgBteySuGqNeMQKarOiReRUJmmPF()
	{
		try
		{
			wZcDvqYJYPCwEnHhHFrHnwjZQsIP(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void wZcDvqYJYPCwEnHhHFrHnwjZQsIP(bool P_0)
	{
		if (!TrsHdtDWCbnMIdqovIsKIWumkFfJA)
		{
			if (P_0 && mgzKPIKkHVJLLRysnlRGFTgbQQIu != null)
			{
				mgzKPIKkHVJLLRysnlRGFTgbQQIu.Dispose();
			}
			TrsHdtDWCbnMIdqovIsKIWumkFfJA = true;
		}
	}
}
