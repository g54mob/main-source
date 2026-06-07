using System;

internal class yyyhZKnFmAtVQJFjwzUwkNmTnujq : IDisposable
{
	private readonly QJksuagGosrsxPeZMzvQjeSveRsf uQvJsKpDankDdDyTzangZYlwmjxW;

	private bool[] UrBbsWkjIoXvRerPqKcpFqCdVmixB;

	protected readonly int JXIwaoqoxolqvgoixIhBbHaAtzkQA;

	protected readonly int lWANowKeThsClnEuQAbjbOOOIrNaA;

	private bool vbqfEfJIbLcbKIJgiGJXMoRJivRrA;

	public int bmsAxrJSIMmjXnOTkMIWGoQLIynG => JXIwaoqoxolqvgoixIhBbHaAtzkQA;

	public int orqErqCUOiPMefXLzMiWoErDMQsyA => lWANowKeThsClnEuQAbjbOOOIrNaA;

	public bool[] CFVdHaMAQJfdNYVCMiApDJJEsRuZ => UrBbsWkjIoXvRerPqKcpFqCdVmixB ?? (UrBbsWkjIoXvRerPqKcpFqCdVmixB = new bool[JXIwaoqoxolqvgoixIhBbHaAtzkQA]);

	public yyyhZKnFmAtVQJFjwzUwkNmTnujq(int P_0, int P_1)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("entryBitSize");
		}
		lWANowKeThsClnEuQAbjbOOOIrNaA = P_0;
		JXIwaoqoxolqvgoixIhBbHaAtzkQA = P_1;
		int num = P_0 * P_1;
		uQvJsKpDankDdDyTzangZYlwmjxW = new QJksuagGosrsxPeZMzvQjeSveRsf(num / 8 + ((num % 8 != 0) ? 1 : 0));
	}

	public unsafe void GevupyiWSPTJBPxMdsfnJlDXOrtB(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= lWANowKeThsClnEuQAbjbOOOIrNaA)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 < JXIwaoqoxolqvgoixIhBbHaAtzkQA)
		{
			int jXIwaoqoxolqvgoixIhBbHaAtzkQA = JXIwaoqoxolqvgoixIhBbHaAtzkQA;
			throw new Exception("Buffer is too small to hold the data. Must be at least " + jXIwaoqoxolqvgoixIhBbHaAtzkQA + " bits.");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < JXIwaoqoxolqvgoixIhBbHaAtzkQA; i++)
		{
			YIaoGwgGvxhABHmmRgibCqpkEyPsA(P_0, i, out var num3, out var b);
			P_1[i] = (uQvJsKpDankDdDyTzangZYlwmjxW.XOouJHofYbsEVgmExlbZpTVUYvuK(num3, b) ? ((byte)(P_1[num] | (1 << num2))) : ((byte)(P_1[num] & ~(1 << num2))));
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void dnpzvUeGQKZZIgDBLDIOjWbthzZN(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		GevupyiWSPTJBPxMdsfnJlDXOrtB(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void BFTYvGfhkncCOCfFmeRERgPRkBXj(int P_0, out byte P_1)
	{
		byte b = 0;
		byte* ptr = &b;
		GevupyiWSPTJBPxMdsfnJlDXOrtB(P_0, ptr, 64);
		P_1 = b;
	}

	public void zSzyPqcKHhZXsOCUcsBRUKqAFUZdA(int P_0, out sbyte P_1)
	{
		BFTYvGfhkncCOCfFmeRERgPRkBXj(P_0, out var b);
		P_1 = (sbyte)b;
	}

	public unsafe void mGjFRaTiDzkdKeVYlvfbkCJzIclg(int P_0, out short P_1)
	{
		short num = 0;
		byte* ptr = (byte*)(&num);
		GevupyiWSPTJBPxMdsfnJlDXOrtB(P_0, ptr, 64);
		P_1 = num;
	}

	public void ZmrqnXKlfltXWDRYRaWIUSETRMnq(int P_0, out ushort P_1)
	{
		mGjFRaTiDzkdKeVYlvfbkCJzIclg(P_0, out var num);
		P_1 = (ushort)num;
	}

	public unsafe void YLNgCmJVymRMdQwuxjmKbPDVxaVuA(int P_0, out int P_1)
	{
		int num = 0;
		byte* ptr = (byte*)(&num);
		GevupyiWSPTJBPxMdsfnJlDXOrtB(P_0, ptr, 64);
		P_1 = num;
	}

	public void lBjyifgGQbHsYLXdbIaLdsyPahhm(int P_0, out uint P_1)
	{
		YLNgCmJVymRMdQwuxjmKbPDVxaVuA(P_0, out var num);
		P_1 = (uint)num;
	}

	public unsafe void qBgNBaXDQYaYnepBvTurxODvYxTE(int P_0, out long P_1)
	{
		long num = 0L;
		byte* ptr = (byte*)(&num);
		GevupyiWSPTJBPxMdsfnJlDXOrtB(P_0, ptr, 64);
		P_1 = num;
	}

	public void AVspSZsLXckbXhOybzYFIRFlLelH(int P_0, out ulong P_1)
	{
		qBgNBaXDQYaYnepBvTurxODvYxTE(P_0, out var num);
		P_1 = (ulong)num;
	}

	public void MTkfqoApyWQJBxfnZdGKnYFySEsdA(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= lWANowKeThsClnEuQAbjbOOOIrNaA)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < JXIwaoqoxolqvgoixIhBbHaAtzkQA)
		{
			int jXIwaoqoxolqvgoixIhBbHaAtzkQA = JXIwaoqoxolqvgoixIhBbHaAtzkQA;
			throw new Exception("valueBuffer.Length must be >= " + jXIwaoqoxolqvgoixIhBbHaAtzkQA);
		}
		for (int i = 0; i < JXIwaoqoxolqvgoixIhBbHaAtzkQA; i++)
		{
			YIaoGwgGvxhABHmmRgibCqpkEyPsA(P_0, i, out var num, out var b);
			P_1[i] = uQvJsKpDankDdDyTzangZYlwmjxW.XOouJHofYbsEVgmExlbZpTVUYvuK(num, b);
		}
	}

	public unsafe void NNdBIkCzIETKleMTKenSksHClkkA(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= lWANowKeThsClnEuQAbjbOOOIrNaA)
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
		for (int i = 0; i < JXIwaoqoxolqvgoixIhBbHaAtzkQA; i++)
		{
			YIaoGwgGvxhABHmmRgibCqpkEyPsA(P_0, i, out var num3, out var b);
			bool flag = i < P_2 && (flag = (P_1[num] & (1 << num2)) != 0);
			uQvJsKpDankDdDyTzangZYlwmjxW.UsbexhEQkWRUehtCxqgKCIJYRoUMA(num3, b, flag);
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void xaEmMGhirzmMzYhLhyhlPAOtuOLk(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		NNdBIkCzIETKleMTKenSksHClkkA(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void lhLDDDQTrLRXDRgqDPasAyPikjsK(int P_0, byte P_1)
	{
		byte* ptr = &P_1;
		NNdBIkCzIETKleMTKenSksHClkkA(P_0, ptr, 8);
	}

	public void bxdddAJrXKUuSeAlaLRJGlRCfZOiA(int P_0, sbyte P_1)
	{
		lhLDDDQTrLRXDRgqDPasAyPikjsK(P_0, (byte)P_1);
	}

	public unsafe void leuHrBmyJVTGCwoWfcAYOGaSDcYP(int P_0, short P_1)
	{
		byte* ptr = (byte*)(&P_1);
		NNdBIkCzIETKleMTKenSksHClkkA(P_0, ptr, 16);
	}

	public void hnMtQpbzFxmbtiSwscCwwICaJllw(int P_0, ushort P_1)
	{
		leuHrBmyJVTGCwoWfcAYOGaSDcYP(P_0, (short)P_1);
	}

	public unsafe void kUyiItkoYFgFqgVWYQXtcVifIHXwA(int P_0, int P_1)
	{
		byte* ptr = (byte*)(&P_1);
		NNdBIkCzIETKleMTKenSksHClkkA(P_0, ptr, 32);
	}

	public void CDQyZBGKoYYwWWHtzrYNFfgIaayc(int P_0, uint P_1)
	{
		kUyiItkoYFgFqgVWYQXtcVifIHXwA(P_0, (int)P_1);
	}

	public unsafe void iSxvFaNedKMFwATNJNFDvljzgmLV(int P_0, long P_1)
	{
		byte* ptr = (byte*)(&P_1);
		NNdBIkCzIETKleMTKenSksHClkkA(P_0, ptr, 64);
	}

	public void bbXoXJIdocquHAiFVobrGMDOGFCI(int P_0, ulong P_1)
	{
		iSxvFaNedKMFwATNJNFDvljzgmLV(P_0, (long)P_1);
	}

	public void JKOoQghiXyGaAglFCsLWRQcJDwTq(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= lWANowKeThsClnEuQAbjbOOOIrNaA)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < JXIwaoqoxolqvgoixIhBbHaAtzkQA)
		{
			int jXIwaoqoxolqvgoixIhBbHaAtzkQA = JXIwaoqoxolqvgoixIhBbHaAtzkQA;
			throw new Exception("valueBuffer.Length must be >= " + jXIwaoqoxolqvgoixIhBbHaAtzkQA);
		}
		for (int i = 0; i < JXIwaoqoxolqvgoixIhBbHaAtzkQA; i++)
		{
			YIaoGwgGvxhABHmmRgibCqpkEyPsA(P_0, i, out var num, out var b);
			uQvJsKpDankDdDyTzangZYlwmjxW.UsbexhEQkWRUehtCxqgKCIJYRoUMA(num, b, P_1[i]);
		}
	}

	private void YIaoGwgGvxhABHmmRgibCqpkEyPsA(int P_0, int P_1, out int P_2, out byte P_3)
	{
		if (P_0 < 0 || P_0 >= lWANowKeThsClnEuQAbjbOOOIrNaA)
		{
			throw new IndexOutOfRangeException("entryIndex");
		}
		if (P_1 < 0 || P_1 >= JXIwaoqoxolqvgoixIhBbHaAtzkQA)
		{
			throw new ArgumentOutOfRangeException("bitOffset");
		}
		int num = P_0 * JXIwaoqoxolqvgoixIhBbHaAtzkQA + P_1;
		P_2 = num / JXIwaoqoxolqvgoixIhBbHaAtzkQA;
		P_3 = (byte)(num - P_2 * JXIwaoqoxolqvgoixIhBbHaAtzkQA);
	}

	private int yEjCthoiBASxeHoieIswFscLFgPr(int P_0, out byte P_1)
	{
		if (P_0 < 0 || P_0 >= lWANowKeThsClnEuQAbjbOOOIrNaA * JXIwaoqoxolqvgoixIhBbHaAtzkQA)
		{
			throw new IndexOutOfRangeException("bitIndex");
		}
		int num = P_0 / JXIwaoqoxolqvgoixIhBbHaAtzkQA;
		P_1 = (byte)(P_0 - num * JXIwaoqoxolqvgoixIhBbHaAtzkQA);
		return num;
	}

	public void Dispose()
	{
		VaDRVqDcVxHnFBsOSComCBWEWTct(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void qdtXYuxLRiIIJWxDXJyGXiwCqWFG()
	{
		try
		{
			VaDRVqDcVxHnFBsOSComCBWEWTct(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void VaDRVqDcVxHnFBsOSComCBWEWTct(bool P_0)
	{
		if (!vbqfEfJIbLcbKIJgiGJXMoRJivRrA)
		{
			if (P_0 && uQvJsKpDankDdDyTzangZYlwmjxW != null)
			{
				uQvJsKpDankDdDyTzangZYlwmjxW.Dispose();
			}
			vbqfEfJIbLcbKIJgiGJXMoRJivRrA = true;
		}
	}
}
