using System;

internal class oTMVElnMimKqHAHVEfbZEiDlCuME : IDisposable
{
	private readonly OrGbzVsUcUYnmShreCvhbuxVmzF DBZCtHAzIvFuQOarCKsttoMaNgUG;

	private bool[] fCQcQIkYTgdFJJToRAHiLJqoHMm;

	protected readonly int JLhojUQsSVEwElbWVmCXBjFsBFi;

	protected readonly int qHbYWrgTCguIMVDkMGGdBRJkMDQd;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	public int ValueBitSize => JLhojUQsSVEwElbWVmCXBjFsBFi;

	public int Length => qHbYWrgTCguIMVDkMGGdBRJkMDQd;

	public bool[] ValueWorkBuffer => fCQcQIkYTgdFJJToRAHiLJqoHMm ?? (fCQcQIkYTgdFJJToRAHiLJqoHMm = new bool[JLhojUQsSVEwElbWVmCXBjFsBFi]);

	public oTMVElnMimKqHAHVEfbZEiDlCuME(int length, int valueBitSize)
	{
		if (length <= 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (valueBitSize <= 0)
		{
			throw new ArgumentOutOfRangeException("entryBitSize");
		}
		qHbYWrgTCguIMVDkMGGdBRJkMDQd = length;
		JLhojUQsSVEwElbWVmCXBjFsBFi = valueBitSize;
		int num = length * valueBitSize;
		DBZCtHAzIvFuQOarCKsttoMaNgUG = new OrGbzVsUcUYnmShreCvhbuxVmzF(num / 8 + ((num % 8 != 0) ? 1 : 0));
	}

	public unsafe void RKDIoTrFWiGBiTdsPoHVwcVsFYl(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 < JLhojUQsSVEwElbWVmCXBjFsBFi)
		{
			throw new Exception("Buffer is too small to hold the data. Must be at least " + JLhojUQsSVEwElbWVmCXBjFsBFi + " bits.");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < JLhojUQsSVEwElbWVmCXBjFsBFi; i++)
		{
			dntUNziPnCNVnVJaUEZGAyUlnyMN(P_0, i, out var num3, out var b);
			P_1[i] = (DBZCtHAzIvFuQOarCKsttoMaNgUG.SftSuGxTUNXYwWlGMlHcDgCQzU(num3, b) ? ((byte)(P_1[num] | (1 << num2))) : ((byte)(P_1[num] & ~(1 << num2))));
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void RKDIoTrFWiGBiTdsPoHVwcVsFYl(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		RKDIoTrFWiGBiTdsPoHVwcVsFYl(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void RKDIoTrFWiGBiTdsPoHVwcVsFYl(int P_0, out byte P_1)
	{
		byte b = 0;
		byte* ptr = &b;
		RKDIoTrFWiGBiTdsPoHVwcVsFYl(P_0, ptr, 64);
		P_1 = b;
	}

	public void RKDIoTrFWiGBiTdsPoHVwcVsFYl(int P_0, out sbyte P_1)
	{
		RKDIoTrFWiGBiTdsPoHVwcVsFYl(P_0, out byte b);
		P_1 = (sbyte)b;
	}

	public unsafe void RKDIoTrFWiGBiTdsPoHVwcVsFYl(int P_0, out short P_1)
	{
		short num = 0;
		byte* ptr = (byte*)(&num);
		RKDIoTrFWiGBiTdsPoHVwcVsFYl(P_0, ptr, 64);
		P_1 = num;
	}

	public void RKDIoTrFWiGBiTdsPoHVwcVsFYl(int P_0, out ushort P_1)
	{
		RKDIoTrFWiGBiTdsPoHVwcVsFYl(P_0, out short num);
		P_1 = (ushort)num;
	}

	public unsafe void RKDIoTrFWiGBiTdsPoHVwcVsFYl(int P_0, out int P_1)
	{
		int num = 0;
		byte* ptr = (byte*)(&num);
		RKDIoTrFWiGBiTdsPoHVwcVsFYl(P_0, ptr, 64);
		P_1 = num;
	}

	public void RKDIoTrFWiGBiTdsPoHVwcVsFYl(int P_0, out uint P_1)
	{
		RKDIoTrFWiGBiTdsPoHVwcVsFYl(P_0, out int num);
		P_1 = (uint)num;
	}

	public unsafe void RKDIoTrFWiGBiTdsPoHVwcVsFYl(int P_0, out long P_1)
	{
		long num = 0L;
		byte* ptr = (byte*)(&num);
		RKDIoTrFWiGBiTdsPoHVwcVsFYl(P_0, ptr, 64);
		P_1 = num;
	}

	public void RKDIoTrFWiGBiTdsPoHVwcVsFYl(int P_0, out ulong P_1)
	{
		RKDIoTrFWiGBiTdsPoHVwcVsFYl(P_0, out long num);
		P_1 = (ulong)num;
	}

	public void RKDIoTrFWiGBiTdsPoHVwcVsFYl(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < JLhojUQsSVEwElbWVmCXBjFsBFi)
		{
			throw new Exception("valueBuffer.Length must be >= " + JLhojUQsSVEwElbWVmCXBjFsBFi);
		}
		for (int i = 0; i < JLhojUQsSVEwElbWVmCXBjFsBFi; i++)
		{
			dntUNziPnCNVnVJaUEZGAyUlnyMN(P_0, i, out var num, out var b);
			P_1[i] = DBZCtHAzIvFuQOarCKsttoMaNgUG.SftSuGxTUNXYwWlGMlHcDgCQzU(num, b);
		}
	}

	public unsafe void jkNSmPKHAFDYNAMFgsQtdPCvKWfn(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
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
		for (int i = 0; i < JLhojUQsSVEwElbWVmCXBjFsBFi; i++)
		{
			dntUNziPnCNVnVJaUEZGAyUlnyMN(P_0, i, out var num3, out var b);
			bool flag = i < P_2 && (flag = (P_1[num] & (1 << num2)) != 0);
			DBZCtHAzIvFuQOarCKsttoMaNgUG.icfuJaKhkvPCRwBmPIrNKHmxBwI(num3, b, flag);
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void jkNSmPKHAFDYNAMFgsQtdPCvKWfn(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		jkNSmPKHAFDYNAMFgsQtdPCvKWfn(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void jkNSmPKHAFDYNAMFgsQtdPCvKWfn(int P_0, byte P_1)
	{
		byte* ptr = &P_1;
		jkNSmPKHAFDYNAMFgsQtdPCvKWfn(P_0, ptr, 8);
	}

	public void jkNSmPKHAFDYNAMFgsQtdPCvKWfn(int P_0, sbyte P_1)
	{
		jkNSmPKHAFDYNAMFgsQtdPCvKWfn(P_0, (byte)P_1);
	}

	public unsafe void jkNSmPKHAFDYNAMFgsQtdPCvKWfn(int P_0, short P_1)
	{
		byte* ptr = (byte*)(&P_1);
		jkNSmPKHAFDYNAMFgsQtdPCvKWfn(P_0, ptr, 16);
	}

	public void jkNSmPKHAFDYNAMFgsQtdPCvKWfn(int P_0, ushort P_1)
	{
		jkNSmPKHAFDYNAMFgsQtdPCvKWfn(P_0, (short)P_1);
	}

	public unsafe void jkNSmPKHAFDYNAMFgsQtdPCvKWfn(int P_0, int P_1)
	{
		byte* ptr = (byte*)(&P_1);
		jkNSmPKHAFDYNAMFgsQtdPCvKWfn(P_0, ptr, 32);
	}

	public void jkNSmPKHAFDYNAMFgsQtdPCvKWfn(int P_0, uint P_1)
	{
		jkNSmPKHAFDYNAMFgsQtdPCvKWfn(P_0, (int)P_1);
	}

	public unsafe void jkNSmPKHAFDYNAMFgsQtdPCvKWfn(int P_0, long P_1)
	{
		byte* ptr = (byte*)(&P_1);
		jkNSmPKHAFDYNAMFgsQtdPCvKWfn(P_0, ptr, 64);
	}

	public void jkNSmPKHAFDYNAMFgsQtdPCvKWfn(int P_0, ulong P_1)
	{
		jkNSmPKHAFDYNAMFgsQtdPCvKWfn(P_0, (long)P_1);
	}

	public void jkNSmPKHAFDYNAMFgsQtdPCvKWfn(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < JLhojUQsSVEwElbWVmCXBjFsBFi)
		{
			throw new Exception("valueBuffer.Length must be >= " + JLhojUQsSVEwElbWVmCXBjFsBFi);
		}
		for (int i = 0; i < JLhojUQsSVEwElbWVmCXBjFsBFi; i++)
		{
			dntUNziPnCNVnVJaUEZGAyUlnyMN(P_0, i, out var num, out var b);
			DBZCtHAzIvFuQOarCKsttoMaNgUG.icfuJaKhkvPCRwBmPIrNKHmxBwI(num, b, P_1[i]);
		}
	}

	private void dntUNziPnCNVnVJaUEZGAyUlnyMN(int P_0, int P_1, out int P_2, out byte P_3)
	{
		if (P_0 < 0 || P_0 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd)
		{
			throw new IndexOutOfRangeException("entryIndex");
		}
		if (P_1 < 0 || P_1 >= JLhojUQsSVEwElbWVmCXBjFsBFi)
		{
			throw new ArgumentOutOfRangeException("bitOffset");
		}
		int num = P_0 * JLhojUQsSVEwElbWVmCXBjFsBFi + P_1;
		P_2 = num / JLhojUQsSVEwElbWVmCXBjFsBFi;
		P_3 = (byte)(num - P_2 * JLhojUQsSVEwElbWVmCXBjFsBFi);
	}

	private int fTGSXPqXWzraumwAeUPKocAOExt(int P_0, out byte P_1)
	{
		if (P_0 < 0 || P_0 >= qHbYWrgTCguIMVDkMGGdBRJkMDQd * JLhojUQsSVEwElbWVmCXBjFsBFi)
		{
			throw new IndexOutOfRangeException("bitIndex");
		}
		int num = P_0 / JLhojUQsSVEwElbWVmCXBjFsBFi;
		P_1 = (byte)(P_0 - num * JLhojUQsSVEwElbWVmCXBjFsBFi);
		return num;
	}

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~oTMVElnMimKqHAHVEfbZEiDlCuME()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (!dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			if (P_0 && DBZCtHAzIvFuQOarCKsttoMaNgUG != null)
			{
				DBZCtHAzIvFuQOarCKsttoMaNgUG.Dispose();
			}
			dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
		}
	}
}
