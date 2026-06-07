using System;

internal class yCixsGWcKNDrNGEkfCdAJleeWmJlA : IDisposable
{
	private readonly SoDaUPyxhCljCRyOJyRmuMKFqYxD njPEqelkqUAXHcVOBySkfuuGgySaA;

	private bool[] JXMRcnaljJmECoDrOvjdSEKIUbol;

	protected readonly int zTpTwlWyyiKXTGYvSoXMYaxKVxuJ;

	protected readonly int AZhQJGaSuJAjHcWRLuegYXjYvVYw;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	public int FvZwBPNAkefWpAkcNDLQAVoPjWmkA => zTpTwlWyyiKXTGYvSoXMYaxKVxuJ;

	public int yIVYFnpBLClvFaTdWwokHpQgDIPu => AZhQJGaSuJAjHcWRLuegYXjYvVYw;

	public bool[] HLwlieoKhknBiSWPFCoDLjgtjxMCA => JXMRcnaljJmECoDrOvjdSEKIUbol ?? (JXMRcnaljJmECoDrOvjdSEKIUbol = new bool[zTpTwlWyyiKXTGYvSoXMYaxKVxuJ]);

	public yCixsGWcKNDrNGEkfCdAJleeWmJlA(int P_0, int P_1)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("entryBitSize");
		}
		AZhQJGaSuJAjHcWRLuegYXjYvVYw = P_0;
		zTpTwlWyyiKXTGYvSoXMYaxKVxuJ = P_1;
		int num = P_0 * P_1;
		njPEqelkqUAXHcVOBySkfuuGgySaA = new SoDaUPyxhCljCRyOJyRmuMKFqYxD(num / 8 + ((num % 8 != 0) ? 1 : 0));
	}

	public unsafe void fVLHNuxQpNlIbohWMFEGfxYENFfO(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 < zTpTwlWyyiKXTGYvSoXMYaxKVxuJ)
		{
			throw new Exception("Buffer is too small to hold the data. Must be at least " + zTpTwlWyyiKXTGYvSoXMYaxKVxuJ + " bits.");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < zTpTwlWyyiKXTGYvSoXMYaxKVxuJ; i++)
		{
			RTdnSGqyRjhuywJXLcbLJbwTrmIJA(P_0, i, out var num3, out var b);
			P_1[i] = (njPEqelkqUAXHcVOBySkfuuGgySaA.mWxBJRSErtjwVDxODMHEjbIeilQz(num3, b) ? ((byte)(P_1[num] | (1 << num2))) : ((byte)(P_1[num] & ~(1 << num2))));
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void fVLHNuxQpNlIbohWMFEGfxYENFfO(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		fVLHNuxQpNlIbohWMFEGfxYENFfO(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void fVLHNuxQpNlIbohWMFEGfxYENFfO(int P_0, out byte P_1)
	{
		byte b = 0;
		byte* ptr = &b;
		fVLHNuxQpNlIbohWMFEGfxYENFfO(P_0, ptr, 64);
		P_1 = b;
	}

	public void fVLHNuxQpNlIbohWMFEGfxYENFfO(int P_0, out sbyte P_1)
	{
		fVLHNuxQpNlIbohWMFEGfxYENFfO(P_0, out byte b);
		P_1 = (sbyte)b;
	}

	public unsafe void fVLHNuxQpNlIbohWMFEGfxYENFfO(int P_0, out short P_1)
	{
		short num = 0;
		byte* ptr = (byte*)(&num);
		fVLHNuxQpNlIbohWMFEGfxYENFfO(P_0, ptr, 64);
		P_1 = num;
	}

	public void fVLHNuxQpNlIbohWMFEGfxYENFfO(int P_0, out ushort P_1)
	{
		fVLHNuxQpNlIbohWMFEGfxYENFfO(P_0, out short num);
		P_1 = (ushort)num;
	}

	public unsafe void fVLHNuxQpNlIbohWMFEGfxYENFfO(int P_0, out int P_1)
	{
		int num = 0;
		byte* ptr = (byte*)(&num);
		fVLHNuxQpNlIbohWMFEGfxYENFfO(P_0, ptr, 64);
		P_1 = num;
	}

	public void fVLHNuxQpNlIbohWMFEGfxYENFfO(int P_0, out uint P_1)
	{
		fVLHNuxQpNlIbohWMFEGfxYENFfO(P_0, out int num);
		P_1 = (uint)num;
	}

	public unsafe void fVLHNuxQpNlIbohWMFEGfxYENFfO(int P_0, out long P_1)
	{
		long num = 0L;
		byte* ptr = (byte*)(&num);
		fVLHNuxQpNlIbohWMFEGfxYENFfO(P_0, ptr, 64);
		P_1 = num;
	}

	public void fVLHNuxQpNlIbohWMFEGfxYENFfO(int P_0, out ulong P_1)
	{
		fVLHNuxQpNlIbohWMFEGfxYENFfO(P_0, out long num);
		P_1 = (ulong)num;
	}

	public void fVLHNuxQpNlIbohWMFEGfxYENFfO(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < zTpTwlWyyiKXTGYvSoXMYaxKVxuJ)
		{
			throw new Exception("valueBuffer.Length must be >= " + zTpTwlWyyiKXTGYvSoXMYaxKVxuJ);
		}
		for (int i = 0; i < zTpTwlWyyiKXTGYvSoXMYaxKVxuJ; i++)
		{
			RTdnSGqyRjhuywJXLcbLJbwTrmIJA(P_0, i, out var num, out var b);
			P_1[i] = njPEqelkqUAXHcVOBySkfuuGgySaA.mWxBJRSErtjwVDxODMHEjbIeilQz(num, b);
		}
	}

	public unsafe void TBPPzgWuguKbGbwgzGoaAckRXMzv(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
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
		for (int i = 0; i < zTpTwlWyyiKXTGYvSoXMYaxKVxuJ; i++)
		{
			RTdnSGqyRjhuywJXLcbLJbwTrmIJA(P_0, i, out var num3, out var b);
			bool flag = i < P_2 && (flag = (P_1[num] & (1 << num2)) != 0);
			njPEqelkqUAXHcVOBySkfuuGgySaA.SXhpeDQySIupWNFTUijCFiMVZcAH(num3, b, flag);
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void TBPPzgWuguKbGbwgzGoaAckRXMzv(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		TBPPzgWuguKbGbwgzGoaAckRXMzv(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void TBPPzgWuguKbGbwgzGoaAckRXMzv(int P_0, byte P_1)
	{
		byte* ptr = &P_1;
		TBPPzgWuguKbGbwgzGoaAckRXMzv(P_0, ptr, 8);
	}

	public void TBPPzgWuguKbGbwgzGoaAckRXMzv(int P_0, sbyte P_1)
	{
		TBPPzgWuguKbGbwgzGoaAckRXMzv(P_0, (byte)P_1);
	}

	public unsafe void TBPPzgWuguKbGbwgzGoaAckRXMzv(int P_0, short P_1)
	{
		byte* ptr = (byte*)(&P_1);
		TBPPzgWuguKbGbwgzGoaAckRXMzv(P_0, ptr, 16);
	}

	public void TBPPzgWuguKbGbwgzGoaAckRXMzv(int P_0, ushort P_1)
	{
		TBPPzgWuguKbGbwgzGoaAckRXMzv(P_0, (short)P_1);
	}

	public unsafe void TBPPzgWuguKbGbwgzGoaAckRXMzv(int P_0, int P_1)
	{
		byte* ptr = (byte*)(&P_1);
		TBPPzgWuguKbGbwgzGoaAckRXMzv(P_0, ptr, 32);
	}

	public void TBPPzgWuguKbGbwgzGoaAckRXMzv(int P_0, uint P_1)
	{
		TBPPzgWuguKbGbwgzGoaAckRXMzv(P_0, (int)P_1);
	}

	public unsafe void TBPPzgWuguKbGbwgzGoaAckRXMzv(int P_0, long P_1)
	{
		byte* ptr = (byte*)(&P_1);
		TBPPzgWuguKbGbwgzGoaAckRXMzv(P_0, ptr, 64);
	}

	public void TBPPzgWuguKbGbwgzGoaAckRXMzv(int P_0, ulong P_1)
	{
		TBPPzgWuguKbGbwgzGoaAckRXMzv(P_0, (long)P_1);
	}

	public void TBPPzgWuguKbGbwgzGoaAckRXMzv(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < zTpTwlWyyiKXTGYvSoXMYaxKVxuJ)
		{
			throw new Exception("valueBuffer.Length must be >= " + zTpTwlWyyiKXTGYvSoXMYaxKVxuJ);
		}
		for (int i = 0; i < zTpTwlWyyiKXTGYvSoXMYaxKVxuJ; i++)
		{
			RTdnSGqyRjhuywJXLcbLJbwTrmIJA(P_0, i, out var num, out var b);
			njPEqelkqUAXHcVOBySkfuuGgySaA.SXhpeDQySIupWNFTUijCFiMVZcAH(num, b, P_1[i]);
		}
	}

	private void RTdnSGqyRjhuywJXLcbLJbwTrmIJA(int P_0, int P_1, out int P_2, out byte P_3)
	{
		if (P_0 < 0 || P_0 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw)
		{
			throw new IndexOutOfRangeException("entryIndex");
		}
		if (P_1 < 0 || P_1 >= zTpTwlWyyiKXTGYvSoXMYaxKVxuJ)
		{
			throw new ArgumentOutOfRangeException("bitOffset");
		}
		int num = P_0 * zTpTwlWyyiKXTGYvSoXMYaxKVxuJ + P_1;
		P_2 = num / zTpTwlWyyiKXTGYvSoXMYaxKVxuJ;
		P_3 = (byte)(num - P_2 * zTpTwlWyyiKXTGYvSoXMYaxKVxuJ);
	}

	private int PlMPIikRaWCBvHbvbErRclqqcfzDb(int P_0, out byte P_1)
	{
		if (P_0 < 0 || P_0 >= AZhQJGaSuJAjHcWRLuegYXjYvVYw * zTpTwlWyyiKXTGYvSoXMYaxKVxuJ)
		{
			throw new IndexOutOfRangeException("bitIndex");
		}
		int num = P_0 / zTpTwlWyyiKXTGYvSoXMYaxKVxuJ;
		P_1 = (byte)(P_0 - num * zTpTwlWyyiKXTGYvSoXMYaxKVxuJ);
		return num;
	}

	public void Dispose()
	{
		vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
	{
		try
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (!JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			if (P_0 && njPEqelkqUAXHcVOBySkfuuGgySaA != null)
			{
				njPEqelkqUAXHcVOBySkfuuGgySaA.Dispose();
			}
			JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
		}
	}
}
