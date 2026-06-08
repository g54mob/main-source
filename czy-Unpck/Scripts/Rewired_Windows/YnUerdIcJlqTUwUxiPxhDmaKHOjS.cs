using System;
using Rewired.Utils;

internal class YnUerdIcJlqTUwUxiPxhDmaKHOjS : IDisposable
{
	private readonly RvpFEucvSEfCvSDLylfXUdcnldG EAkChchgpneGPakFUTPVByHUjQB;

	private readonly int KsbBaXgXZOCuziLyKRlsDXzKvAZL;

	private long zJLjnEIxAehZUBHvZhgRRETcpUt;

	private long eSDDufAbZnvsUOFYdwzIscbDiAjZ;

	private int qKgURPmydBWlwXgXXKycVghoyLN;

	private bool YJdjlewiEADBdEqhbcAbjpeCSqy;

	private uint PvzFDagytMDIlkTGalfxlVAMUlPO;

	private bool inweGjIgYacXYohFlYRlpMFkgKMi;

	public int Capacity => KsbBaXgXZOCuziLyKRlsDXzKvAZL;

	public int BytesInBuffer => qKgURPmydBWlwXgXXKycVghoyLN;

	public bool BufferOverrun => YJdjlewiEADBdEqhbcAbjpeCSqy;

	public YnUerdIcJlqTUwUxiPxhDmaKHOjS(int capacity)
	{
		KsbBaXgXZOCuziLyKRlsDXzKvAZL = capacity;
		if (capacity <= 0)
		{
			throw new ArgumentOutOfRangeException("sizeInBytes");
		}
		EAkChchgpneGPakFUTPVByHUjQB = new RvpFEucvSEfCvSDLylfXUdcnldG(capacity);
	}

	public unsafe int pqcPIshdVNrBiKWuGFpklSuavkZ(byte* P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		P_3 = (int)zJLjnEIxAehZUBHvZhgRRETcpUt;
		P_4 = PvzFDagytMDIlkTGalfxlVAMUlPO;
		if (P_0 == null || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		int num = EAkChchgpneGPakFUTPVByHUjQB.zZzsGwjMBLoeIAhRqCUiKPGrylo(P_0, P_1, P_2, (int)zJLjnEIxAehZUBHvZhgRRETcpUt);
		if (num == 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += EAkChchgpneGPakFUTPVByHUjQB.zZzsGwjMBLoeIAhRqCUiKPGrylo(P_0 + num, P_1 - num, P_2 - num);
		}
		YZngDWDuxojHWClJtWMAKcbvPvM(num);
		return num;
	}

	public unsafe int pqcPIshdVNrBiKWuGFpklSuavkZ(IntPtr P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			P_3 = (int)zJLjnEIxAehZUBHvZhgRRETcpUt;
			P_4 = PvzFDagytMDIlkTGalfxlVAMUlPO;
			return 0;
		}
		return pqcPIshdVNrBiKWuGFpklSuavkZ((byte*)(void*)P_0, P_1, P_2, out P_3, out P_4);
	}

	public unsafe int pqcPIshdVNrBiKWuGFpklSuavkZ(byte[] P_0, int P_1, out int P_2, out uint P_3)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = (int)zJLjnEIxAehZUBHvZhgRRETcpUt;
			P_3 = PvzFDagytMDIlkTGalfxlVAMUlPO;
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return pqcPIshdVNrBiKWuGFpklSuavkZ(ptr, P_0.Length, P_1, out P_2, out P_3);
		}
	}

	public unsafe int pqcPIshdVNrBiKWuGFpklSuavkZ(byte* P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return pqcPIshdVNrBiKWuGFpklSuavkZ(P_0, P_1, P_2, out num, out num2);
	}

	public int pqcPIshdVNrBiKWuGFpklSuavkZ(IntPtr P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return pqcPIshdVNrBiKWuGFpklSuavkZ(P_0, P_1, P_2, out num, out num2);
	}

	public int pqcPIshdVNrBiKWuGFpklSuavkZ(byte[] P_0, int P_1)
	{
		int num;
		uint num2;
		return pqcPIshdVNrBiKWuGFpklSuavkZ(P_0, P_1, out num, out num2);
	}

	public unsafe int AFeHJojxqfbjmBllWvAWerjcLiqH(byte* P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || qKgURPmydBWlwXgXXKycVghoyLN == 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > qKgURPmydBWlwXgXXKycVghoyLN)
		{
			P_2 = qKgURPmydBWlwXgXXKycVghoyLN;
		}
		int num = EAkChchgpneGPakFUTPVByHUjQB.DhaISRjAMlEKlpHHfedEmdxuyVp(P_0, P_1, P_2, (int)eSDDufAbZnvsUOFYdwzIscbDiAjZ);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += EAkChchgpneGPakFUTPVByHUjQB.DhaISRjAMlEKlpHHfedEmdxuyVp(P_0 + num, P_1 - num, P_2 - num);
		}
		aJnPlpktQAonsTPkxpTeHCWsBkR(num);
		return num;
	}

	public unsafe int AFeHJojxqfbjmBllWvAWerjcLiqH(byte[] P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return AFeHJojxqfbjmBllWvAWerjcLiqH(ptr, P_0.Length, P_1);
		}
	}

	public unsafe int AFeHJojxqfbjmBllWvAWerjcLiqH(IntPtr P_0, int P_1, int P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		return AFeHJojxqfbjmBllWvAWerjcLiqH((byte*)(void*)P_0, P_1, P_2);
	}

	public unsafe int rYbXKtmIcQfPnKoenkNgjULYOFV(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || qKgURPmydBWlwXgXXKycVghoyLN == 0 || P_3 < 0 || P_3 >= KsbBaXgXZOCuziLyKRlsDXzKvAZL)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > qKgURPmydBWlwXgXXKycVghoyLN)
		{
			P_2 = qKgURPmydBWlwXgXXKycVghoyLN;
		}
		int num = EAkChchgpneGPakFUTPVByHUjQB.DhaISRjAMlEKlpHHfedEmdxuyVp(P_0, P_1, P_2, P_3);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += EAkChchgpneGPakFUTPVByHUjQB.DhaISRjAMlEKlpHHfedEmdxuyVp(P_0 + num, P_1 - num, P_2 - num);
		}
		return num;
	}

	public unsafe int rYbXKtmIcQfPnKoenkNgjULYOFV(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return rYbXKtmIcQfPnKoenkNgjULYOFV(ptr, P_0.Length, P_1, P_2);
		}
	}

	public unsafe int rYbXKtmIcQfPnKoenkNgjULYOFV(IntPtr P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_3 <= 0)
		{
			return 0;
		}
		return rYbXKtmIcQfPnKoenkNgjULYOFV((byte*)(void*)P_0, P_1, P_2, P_3);
	}

	public bool ckbPgbaOEagjXFRelDQXyZclxuj(int P_0, uint P_1)
	{
		if (P_0 < 0 || P_0 >= KsbBaXgXZOCuziLyKRlsDXzKvAZL)
		{
			return false;
		}
		if (P_0 < zJLjnEIxAehZUBHvZhgRRETcpUt)
		{
			if (P_1 == PvzFDagytMDIlkTGalfxlVAMUlPO)
			{
				return true;
			}
		}
		else if (P_0 >= zJLjnEIxAehZUBHvZhgRRETcpUt)
		{
			if (PvzFDagytMDIlkTGalfxlVAMUlPO == 0)
			{
				return false;
			}
			if (PvzFDagytMDIlkTGalfxlVAMUlPO - 1 == P_1)
			{
				return true;
			}
		}
		return false;
	}

	public void VxWYhSWcyHtpXhSDbelOvWQxsme()
	{
		zJLjnEIxAehZUBHvZhgRRETcpUt = 0L;
		eSDDufAbZnvsUOFYdwzIscbDiAjZ = 0L;
		qKgURPmydBWlwXgXXKycVghoyLN = 0;
		YJdjlewiEADBdEqhbcAbjpeCSqy = false;
		PvzFDagytMDIlkTGalfxlVAMUlPO = 0u;
	}

	private void YZngDWDuxojHWClJtWMAKcbvPvM(int P_0)
	{
		if (P_0 <= 0)
		{
			return;
		}
		int num = (int)zJLjnEIxAehZUBHvZhgRRETcpUt;
		zJLjnEIxAehZUBHvZhgRRETcpUt += P_0;
		bool flag = false;
		if (num < eSDDufAbZnvsUOFYdwzIscbDiAjZ)
		{
			if (zJLjnEIxAehZUBHvZhgRRETcpUt > eSDDufAbZnvsUOFYdwzIscbDiAjZ)
			{
				flag = true;
			}
		}
		else if (num > eSDDufAbZnvsUOFYdwzIscbDiAjZ)
		{
			if (zJLjnEIxAehZUBHvZhgRRETcpUt - KsbBaXgXZOCuziLyKRlsDXzKvAZL > eSDDufAbZnvsUOFYdwzIscbDiAjZ)
			{
				flag = true;
			}
		}
		else if (qKgURPmydBWlwXgXXKycVghoyLN > 0)
		{
			flag = true;
		}
		if (flag)
		{
			YJdjlewiEADBdEqhbcAbjpeCSqy = true;
			eSDDufAbZnvsUOFYdwzIscbDiAjZ = zJLjnEIxAehZUBHvZhgRRETcpUt;
			if (eSDDufAbZnvsUOFYdwzIscbDiAjZ >= KsbBaXgXZOCuziLyKRlsDXzKvAZL)
			{
				eSDDufAbZnvsUOFYdwzIscbDiAjZ -= KsbBaXgXZOCuziLyKRlsDXzKvAZL;
			}
		}
		if (zJLjnEIxAehZUBHvZhgRRETcpUt >= KsbBaXgXZOCuziLyKRlsDXzKvAZL)
		{
			zJLjnEIxAehZUBHvZhgRRETcpUt -= KsbBaXgXZOCuziLyKRlsDXzKvAZL;
			yfpzovgpnDTAkFGggszxkFbpjnG();
		}
		qKgURPmydBWlwXgXXKycVghoyLN = (int)MathTools.Clamp((long)qKgURPmydBWlwXgXXKycVghoyLN + (long)P_0, 0L, KsbBaXgXZOCuziLyKRlsDXzKvAZL);
	}

	private void aJnPlpktQAonsTPkxpTeHCWsBkR(int P_0)
	{
		if (P_0 > 0)
		{
			if (YJdjlewiEADBdEqhbcAbjpeCSqy)
			{
				YJdjlewiEADBdEqhbcAbjpeCSqy = false;
			}
			eSDDufAbZnvsUOFYdwzIscbDiAjZ += P_0;
			if (eSDDufAbZnvsUOFYdwzIscbDiAjZ >= KsbBaXgXZOCuziLyKRlsDXzKvAZL)
			{
				eSDDufAbZnvsUOFYdwzIscbDiAjZ -= KsbBaXgXZOCuziLyKRlsDXzKvAZL;
			}
			long num = (long)qKgURPmydBWlwXgXXKycVghoyLN - (long)P_0;
			qKgURPmydBWlwXgXXKycVghoyLN = (int)((num >= 0) ? num : 0);
		}
	}

	private void yfpzovgpnDTAkFGggszxkFbpjnG()
	{
		if (PvzFDagytMDIlkTGalfxlVAMUlPO == uint.MaxValue)
		{
			PvzFDagytMDIlkTGalfxlVAMUlPO = 0u;
		}
		else
		{
			PvzFDagytMDIlkTGalfxlVAMUlPO++;
		}
	}

	public void Dispose()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~YnUerdIcJlqTUwUxiPxhDmaKHOjS()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	protected void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
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
