using System;

internal class bGjvCMrdEqwIIGOzGIJpJgMTrhH : IDisposable
{
	private readonly RvpFEucvSEfCvSDLylfXUdcnldG EAkChchgpneGPakFUTPVByHUjQB;

	private bool[] iadhlhsntaIFGVbMZGyIcixKuVjr;

	protected readonly int CTOUNvQScLsNJhKcZtklkAUIDQz;

	protected readonly int tZUnOAwcHyObLXQsSrSXeWYWQaD;

	private bool inweGjIgYacXYohFlYRlpMFkgKMi;

	public int ValueBitSize => CTOUNvQScLsNJhKcZtklkAUIDQz;

	public int Length => tZUnOAwcHyObLXQsSrSXeWYWQaD;

	public bool[] ValueWorkBuffer => iadhlhsntaIFGVbMZGyIcixKuVjr ?? (iadhlhsntaIFGVbMZGyIcixKuVjr = new bool[CTOUNvQScLsNJhKcZtklkAUIDQz]);

	public bGjvCMrdEqwIIGOzGIJpJgMTrhH(int length, int valueBitSize)
	{
		if (length <= 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (valueBitSize <= 0)
		{
			throw new ArgumentOutOfRangeException("entryBitSize");
		}
		tZUnOAwcHyObLXQsSrSXeWYWQaD = length;
		CTOUNvQScLsNJhKcZtklkAUIDQz = valueBitSize;
		int num = length * valueBitSize;
		EAkChchgpneGPakFUTPVByHUjQB = new RvpFEucvSEfCvSDLylfXUdcnldG(num / 8 + ((num % 8 != 0) ? 1 : 0));
	}

	public unsafe void WRsTbcdWlcwAvJMBHsZpVmdYjEe(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 < CTOUNvQScLsNJhKcZtklkAUIDQz)
		{
			throw new Exception("Buffer is too small to hold the data. Must be at least " + CTOUNvQScLsNJhKcZtklkAUIDQz + " bits.");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < CTOUNvQScLsNJhKcZtklkAUIDQz; i++)
		{
			isCyIEekTCLCaDYKUcukHeDBxmR(P_0, i, out var num3, out var b);
			P_1[i] = (EAkChchgpneGPakFUTPVByHUjQB.FfUIlJEIfAGTVBuTHAIvVHnQieRM(num3, b) ? ((byte)(P_1[num] | (1 << num2))) : ((byte)(P_1[num] & ~(1 << num2))));
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void WRsTbcdWlcwAvJMBHsZpVmdYjEe(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		WRsTbcdWlcwAvJMBHsZpVmdYjEe(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void WRsTbcdWlcwAvJMBHsZpVmdYjEe(int P_0, out byte P_1)
	{
		byte b = 0;
		byte* ptr = &b;
		WRsTbcdWlcwAvJMBHsZpVmdYjEe(P_0, ptr, 64);
		P_1 = b;
	}

	public void WRsTbcdWlcwAvJMBHsZpVmdYjEe(int P_0, out sbyte P_1)
	{
		WRsTbcdWlcwAvJMBHsZpVmdYjEe(P_0, out byte b);
		P_1 = (sbyte)b;
	}

	public unsafe void WRsTbcdWlcwAvJMBHsZpVmdYjEe(int P_0, out short P_1)
	{
		short num = 0;
		byte* ptr = (byte*)(&num);
		WRsTbcdWlcwAvJMBHsZpVmdYjEe(P_0, ptr, 64);
		P_1 = num;
	}

	public void WRsTbcdWlcwAvJMBHsZpVmdYjEe(int P_0, out ushort P_1)
	{
		WRsTbcdWlcwAvJMBHsZpVmdYjEe(P_0, out short num);
		P_1 = (ushort)num;
	}

	public unsafe void WRsTbcdWlcwAvJMBHsZpVmdYjEe(int P_0, out int P_1)
	{
		int num = 0;
		byte* ptr = (byte*)(&num);
		WRsTbcdWlcwAvJMBHsZpVmdYjEe(P_0, ptr, 64);
		P_1 = num;
	}

	public void WRsTbcdWlcwAvJMBHsZpVmdYjEe(int P_0, out uint P_1)
	{
		WRsTbcdWlcwAvJMBHsZpVmdYjEe(P_0, out int num);
		P_1 = (uint)num;
	}

	public unsafe void WRsTbcdWlcwAvJMBHsZpVmdYjEe(int P_0, out long P_1)
	{
		long num = 0L;
		byte* ptr = (byte*)(&num);
		WRsTbcdWlcwAvJMBHsZpVmdYjEe(P_0, ptr, 64);
		P_1 = num;
	}

	public void WRsTbcdWlcwAvJMBHsZpVmdYjEe(int P_0, out ulong P_1)
	{
		WRsTbcdWlcwAvJMBHsZpVmdYjEe(P_0, out long num);
		P_1 = (ulong)num;
	}

	public void WRsTbcdWlcwAvJMBHsZpVmdYjEe(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < CTOUNvQScLsNJhKcZtklkAUIDQz)
		{
			throw new Exception("valueBuffer.Length must be >= " + CTOUNvQScLsNJhKcZtklkAUIDQz);
		}
		for (int i = 0; i < CTOUNvQScLsNJhKcZtklkAUIDQz; i++)
		{
			isCyIEekTCLCaDYKUcukHeDBxmR(P_0, i, out var num, out var b);
			P_1[i] = EAkChchgpneGPakFUTPVByHUjQB.FfUIlJEIfAGTVBuTHAIvVHnQieRM(num, b);
		}
	}

	public unsafe void uWiFSgYCiROiIGGpgcpFqrNJeRm(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
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
		for (int i = 0; i < CTOUNvQScLsNJhKcZtklkAUIDQz; i++)
		{
			isCyIEekTCLCaDYKUcukHeDBxmR(P_0, i, out var num3, out var b);
			bool flag = i < P_2 && (flag = (P_1[num] & (1 << num2)) != 0);
			EAkChchgpneGPakFUTPVByHUjQB.ddExXXSCOxlTMssMRshxxCrRWUR(num3, b, flag);
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void uWiFSgYCiROiIGGpgcpFqrNJeRm(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		uWiFSgYCiROiIGGpgcpFqrNJeRm(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void uWiFSgYCiROiIGGpgcpFqrNJeRm(int P_0, byte P_1)
	{
		byte* ptr = &P_1;
		uWiFSgYCiROiIGGpgcpFqrNJeRm(P_0, ptr, 8);
	}

	public void uWiFSgYCiROiIGGpgcpFqrNJeRm(int P_0, sbyte P_1)
	{
		uWiFSgYCiROiIGGpgcpFqrNJeRm(P_0, (byte)P_1);
	}

	public unsafe void uWiFSgYCiROiIGGpgcpFqrNJeRm(int P_0, short P_1)
	{
		byte* ptr = (byte*)(&P_1);
		uWiFSgYCiROiIGGpgcpFqrNJeRm(P_0, ptr, 16);
	}

	public void uWiFSgYCiROiIGGpgcpFqrNJeRm(int P_0, ushort P_1)
	{
		uWiFSgYCiROiIGGpgcpFqrNJeRm(P_0, (short)P_1);
	}

	public unsafe void uWiFSgYCiROiIGGpgcpFqrNJeRm(int P_0, int P_1)
	{
		byte* ptr = (byte*)(&P_1);
		uWiFSgYCiROiIGGpgcpFqrNJeRm(P_0, ptr, 32);
	}

	public void uWiFSgYCiROiIGGpgcpFqrNJeRm(int P_0, uint P_1)
	{
		uWiFSgYCiROiIGGpgcpFqrNJeRm(P_0, (int)P_1);
	}

	public unsafe void uWiFSgYCiROiIGGpgcpFqrNJeRm(int P_0, long P_1)
	{
		byte* ptr = (byte*)(&P_1);
		uWiFSgYCiROiIGGpgcpFqrNJeRm(P_0, ptr, 64);
	}

	public void uWiFSgYCiROiIGGpgcpFqrNJeRm(int P_0, ulong P_1)
	{
		uWiFSgYCiROiIGGpgcpFqrNJeRm(P_0, (long)P_1);
	}

	public void uWiFSgYCiROiIGGpgcpFqrNJeRm(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < CTOUNvQScLsNJhKcZtklkAUIDQz)
		{
			throw new Exception("valueBuffer.Length must be >= " + CTOUNvQScLsNJhKcZtklkAUIDQz);
		}
		for (int i = 0; i < CTOUNvQScLsNJhKcZtklkAUIDQz; i++)
		{
			isCyIEekTCLCaDYKUcukHeDBxmR(P_0, i, out var num, out var b);
			EAkChchgpneGPakFUTPVByHUjQB.ddExXXSCOxlTMssMRshxxCrRWUR(num, b, P_1[i]);
		}
	}

	private void isCyIEekTCLCaDYKUcukHeDBxmR(int P_0, int P_1, out int P_2, out byte P_3)
	{
		if (P_0 < 0 || P_0 >= tZUnOAwcHyObLXQsSrSXeWYWQaD)
		{
			throw new IndexOutOfRangeException("entryIndex");
		}
		if (P_1 < 0 || P_1 >= CTOUNvQScLsNJhKcZtklkAUIDQz)
		{
			throw new ArgumentOutOfRangeException("bitOffset");
		}
		int num = P_0 * CTOUNvQScLsNJhKcZtklkAUIDQz + P_1;
		P_2 = num / CTOUNvQScLsNJhKcZtklkAUIDQz;
		P_3 = (byte)(num - P_2 * CTOUNvQScLsNJhKcZtklkAUIDQz);
	}

	private int ynposewFcxsyrmmwowIkVEDygkw(int P_0, out byte P_1)
	{
		if (P_0 < 0 || P_0 >= tZUnOAwcHyObLXQsSrSXeWYWQaD * CTOUNvQScLsNJhKcZtklkAUIDQz)
		{
			throw new IndexOutOfRangeException("bitIndex");
		}
		int num = P_0 / CTOUNvQScLsNJhKcZtklkAUIDQz;
		P_1 = (byte)(P_0 - num * CTOUNvQScLsNJhKcZtklkAUIDQz);
		return num;
	}

	public void Dispose()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~bGjvCMrdEqwIIGOzGIJpJgMTrhH()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (!inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			if (P_0 && EAkChchgpneGPakFUTPVByHUjQB != null)
			{
				EAkChchgpneGPakFUTPVByHUjQB.Dispose();
			}
			inweGjIgYacXYohFlYRlpMFkgKMi = true;
		}
	}
}
