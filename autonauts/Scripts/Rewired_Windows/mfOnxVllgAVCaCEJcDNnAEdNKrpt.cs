using System;

internal class mfOnxVllgAVCaCEJcDNnAEdNKrpt : IDisposable
{
	private readonly SbUIvncwPygDdWhgMeEVPFknbZc BnTkMddEMRIYxgTpcAWVDYoOLbph;

	private bool[] bKJvihqLWzreBJwzYdGcbWCjFPb;

	protected readonly int XztzKiIuQpqYbjnUhBqxzVxCgSP;

	protected readonly int othlrJwXEOggtDFssdiPbwxSvUx;

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	public int ValueBitSize
	{
		get
		{
			return XztzKiIuQpqYbjnUhBqxzVxCgSP;
		}
	}

	public int Length
	{
		get
		{
			return othlrJwXEOggtDFssdiPbwxSvUx;
		}
	}

	public bool[] ValueWorkBuffer
	{
		get
		{
			return bKJvihqLWzreBJwzYdGcbWCjFPb ?? (bKJvihqLWzreBJwzYdGcbWCjFPb = new bool[XztzKiIuQpqYbjnUhBqxzVxCgSP]);
		}
	}

	public mfOnxVllgAVCaCEJcDNnAEdNKrpt(int length, int valueBitSize)
	{
		if (length <= 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (valueBitSize <= 0)
		{
			throw new ArgumentOutOfRangeException("entryBitSize");
		}
		othlrJwXEOggtDFssdiPbwxSvUx = length;
		XztzKiIuQpqYbjnUhBqxzVxCgSP = valueBitSize;
		int num = length * valueBitSize;
		BnTkMddEMRIYxgTpcAWVDYoOLbph = new SbUIvncwPygDdWhgMeEVPFknbZc(num / 8 + ((num % 8 != 0) ? 1 : 0));
	}

	public unsafe void ZXVtezfIBEytZDtvfIxdEQUIAmA(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= othlrJwXEOggtDFssdiPbwxSvUx)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 < XztzKiIuQpqYbjnUhBqxzVxCgSP)
		{
			throw new Exception("Buffer is too small to hold the data. Must be at least " + XztzKiIuQpqYbjnUhBqxzVxCgSP + " bits.");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < XztzKiIuQpqYbjnUhBqxzVxCgSP; i++)
		{
			int num3;
			byte b;
			pzrrgPgspoChUDZkeWzmGBwPLbz(P_0, i, out num3, out b);
			P_1[i] = (BnTkMddEMRIYxgTpcAWVDYoOLbph.OzzanGOzVaCzvyIfaqNhIQGusRb(num3, b) ? ((byte)(P_1[num] | (1 << num2))) : ((byte)(P_1[num] & ~(1 << num2))));
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void ZXVtezfIBEytZDtvfIxdEQUIAmA(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		ZXVtezfIBEytZDtvfIxdEQUIAmA(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void ZXVtezfIBEytZDtvfIxdEQUIAmA(int P_0, out byte P_1)
	{
		byte b = 0;
		byte* ptr = &b;
		ZXVtezfIBEytZDtvfIxdEQUIAmA(P_0, ptr, 64);
		P_1 = b;
	}

	public void ZXVtezfIBEytZDtvfIxdEQUIAmA(int P_0, out sbyte P_1)
	{
		byte b;
		ZXVtezfIBEytZDtvfIxdEQUIAmA(P_0, out b);
		P_1 = (sbyte)b;
	}

	public unsafe void ZXVtezfIBEytZDtvfIxdEQUIAmA(int P_0, out short P_1)
	{
		short num = 0;
		byte* ptr = (byte*)(&num);
		ZXVtezfIBEytZDtvfIxdEQUIAmA(P_0, ptr, 64);
		P_1 = num;
	}

	public void ZXVtezfIBEytZDtvfIxdEQUIAmA(int P_0, out ushort P_1)
	{
		short num;
		ZXVtezfIBEytZDtvfIxdEQUIAmA(P_0, out num);
		P_1 = (ushort)num;
	}

	public unsafe void ZXVtezfIBEytZDtvfIxdEQUIAmA(int P_0, out int P_1)
	{
		int num = 0;
		byte* ptr = (byte*)(&num);
		ZXVtezfIBEytZDtvfIxdEQUIAmA(P_0, ptr, 64);
		P_1 = num;
	}

	public void ZXVtezfIBEytZDtvfIxdEQUIAmA(int P_0, out uint P_1)
	{
		int num;
		ZXVtezfIBEytZDtvfIxdEQUIAmA(P_0, out num);
		P_1 = (uint)num;
	}

	public unsafe void ZXVtezfIBEytZDtvfIxdEQUIAmA(int P_0, out long P_1)
	{
		long num = 0L;
		byte* ptr = (byte*)(&num);
		ZXVtezfIBEytZDtvfIxdEQUIAmA(P_0, ptr, 64);
		P_1 = num;
	}

	public void ZXVtezfIBEytZDtvfIxdEQUIAmA(int P_0, out ulong P_1)
	{
		long num;
		ZXVtezfIBEytZDtvfIxdEQUIAmA(P_0, out num);
		P_1 = (ulong)num;
	}

	public void ZXVtezfIBEytZDtvfIxdEQUIAmA(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= othlrJwXEOggtDFssdiPbwxSvUx)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < XztzKiIuQpqYbjnUhBqxzVxCgSP)
		{
			throw new Exception("valueBuffer.Length must be >= " + XztzKiIuQpqYbjnUhBqxzVxCgSP);
		}
		for (int i = 0; i < XztzKiIuQpqYbjnUhBqxzVxCgSP; i++)
		{
			int num;
			byte b;
			pzrrgPgspoChUDZkeWzmGBwPLbz(P_0, i, out num, out b);
			P_1[i] = BnTkMddEMRIYxgTpcAWVDYoOLbph.OzzanGOzVaCzvyIfaqNhIQGusRb(num, b);
		}
	}

	public unsafe void jxLpHlOKCtqycCWHEKeVlpoLGRG(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= othlrJwXEOggtDFssdiPbwxSvUx)
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
		for (int i = 0; i < XztzKiIuQpqYbjnUhBqxzVxCgSP; i++)
		{
			int num3;
			byte b;
			pzrrgPgspoChUDZkeWzmGBwPLbz(P_0, i, out num3, out b);
			bool flag = i < P_2 && (flag = (P_1[num] & (1 << num2)) != 0);
			BnTkMddEMRIYxgTpcAWVDYoOLbph.qphZcGYPkTxUyiRixeofeTKROcx(num3, b, flag);
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void jxLpHlOKCtqycCWHEKeVlpoLGRG(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		jxLpHlOKCtqycCWHEKeVlpoLGRG(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void jxLpHlOKCtqycCWHEKeVlpoLGRG(int P_0, byte P_1)
	{
		byte* ptr = &P_1;
		jxLpHlOKCtqycCWHEKeVlpoLGRG(P_0, ptr, 8);
	}

	public void jxLpHlOKCtqycCWHEKeVlpoLGRG(int P_0, sbyte P_1)
	{
		jxLpHlOKCtqycCWHEKeVlpoLGRG(P_0, (byte)P_1);
	}

	public unsafe void jxLpHlOKCtqycCWHEKeVlpoLGRG(int P_0, short P_1)
	{
		byte* ptr = (byte*)(&P_1);
		jxLpHlOKCtqycCWHEKeVlpoLGRG(P_0, ptr, 16);
	}

	public void jxLpHlOKCtqycCWHEKeVlpoLGRG(int P_0, ushort P_1)
	{
		jxLpHlOKCtqycCWHEKeVlpoLGRG(P_0, (short)P_1);
	}

	public unsafe void jxLpHlOKCtqycCWHEKeVlpoLGRG(int P_0, int P_1)
	{
		byte* ptr = (byte*)(&P_1);
		jxLpHlOKCtqycCWHEKeVlpoLGRG(P_0, ptr, 32);
	}

	public void jxLpHlOKCtqycCWHEKeVlpoLGRG(int P_0, uint P_1)
	{
		jxLpHlOKCtqycCWHEKeVlpoLGRG(P_0, (int)P_1);
	}

	public unsafe void jxLpHlOKCtqycCWHEKeVlpoLGRG(int P_0, long P_1)
	{
		byte* ptr = (byte*)(&P_1);
		jxLpHlOKCtqycCWHEKeVlpoLGRG(P_0, ptr, 64);
	}

	public void jxLpHlOKCtqycCWHEKeVlpoLGRG(int P_0, ulong P_1)
	{
		jxLpHlOKCtqycCWHEKeVlpoLGRG(P_0, (long)P_1);
	}

	public void jxLpHlOKCtqycCWHEKeVlpoLGRG(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= othlrJwXEOggtDFssdiPbwxSvUx)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < XztzKiIuQpqYbjnUhBqxzVxCgSP)
		{
			throw new Exception("valueBuffer.Length must be >= " + XztzKiIuQpqYbjnUhBqxzVxCgSP);
		}
		for (int i = 0; i < XztzKiIuQpqYbjnUhBqxzVxCgSP; i++)
		{
			int num;
			byte b;
			pzrrgPgspoChUDZkeWzmGBwPLbz(P_0, i, out num, out b);
			BnTkMddEMRIYxgTpcAWVDYoOLbph.qphZcGYPkTxUyiRixeofeTKROcx(num, b, P_1[i]);
		}
	}

	private void pzrrgPgspoChUDZkeWzmGBwPLbz(int P_0, int P_1, out int P_2, out byte P_3)
	{
		if (P_0 < 0 || P_0 >= othlrJwXEOggtDFssdiPbwxSvUx)
		{
			throw new IndexOutOfRangeException("entryIndex");
		}
		if (P_1 < 0 || P_1 >= XztzKiIuQpqYbjnUhBqxzVxCgSP)
		{
			throw new ArgumentOutOfRangeException("bitOffset");
		}
		int num = P_0 * XztzKiIuQpqYbjnUhBqxzVxCgSP + P_1;
		P_2 = num / XztzKiIuQpqYbjnUhBqxzVxCgSP;
		P_3 = (byte)(num - P_2 * XztzKiIuQpqYbjnUhBqxzVxCgSP);
	}

	private int fGCRqfmYYHDOZaLKQHlwJKkwhgEY(int P_0, out byte P_1)
	{
		if (P_0 < 0 || P_0 >= othlrJwXEOggtDFssdiPbwxSvUx * XztzKiIuQpqYbjnUhBqxzVxCgSP)
		{
			throw new IndexOutOfRangeException("bitIndex");
		}
		int num = P_0 / XztzKiIuQpqYbjnUhBqxzVxCgSP;
		P_1 = (byte)(P_0 - num * XztzKiIuQpqYbjnUhBqxzVxCgSP);
		return num;
	}

	public void Dispose()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~mfOnxVllgAVCaCEJcDNnAEdNKrpt()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		if (!nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			if (P_0 && BnTkMddEMRIYxgTpcAWVDYoOLbph != null)
			{
				BnTkMddEMRIYxgTpcAWVDYoOLbph.Dispose();
			}
			nNxUslIcGUpqKgpPZYhuimcvWyC = true;
		}
	}
}
