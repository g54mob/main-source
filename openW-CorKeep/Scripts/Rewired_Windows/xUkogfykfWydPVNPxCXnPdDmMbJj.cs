using Rewired.Utils;

internal class xUkogfykfWydPVNPxCXnPdDmMbJj : ZhMLSvLZpoJWXrVckJkGInbXfymg
{
	public readonly int nQJmhnZiAuFEmstaIgCDkreXzhrB;

	public readonly int QvZdMzCbUtHKovNLmBylopcaPzzS;

	public readonly int eUmTuSVapkRPHuBYLZtDLcqTXNsb;

	public readonly int XZTaEJdYEzgbuUQlhHfKYjOTmvWnA;

	public readonly int vNmfhkQsfsDbfXGGeXIqiIdzNqwA;

	public readonly int FjKLItLbYtDFsAHWcYcrUxwBwxac;

	public readonly uint JCrEhQCupMCLPwtKslLWcFCgHhpqA;

	public readonly uint iDvBKsHJZaxHAKRBdTFcFuPjPblhb;

	public readonly int MYpGpFaacxCVXPojOlTwfUvyonCm;

	private readonly int AzVpqmGyJbcNCVgGNhivXoxBUVlW;

	public uint RceibuJrKbjOUaaiGnbvjYbjyMXy;

	public int LEfYAYmbrCPINQpzzXPjivWRULeC
	{
		get
		{
			if (RceibuJrKbjOUaaiGnbvjYbjyMXy < nQJmhnZiAuFEmstaIgCDkreXzhrB || RceibuJrKbjOUaaiGnbvjYbjyMXy > QvZdMzCbUtHKovNLmBylopcaPzzS)
			{
				return -1;
			}
			int num = (int)((RceibuJrKbjOUaaiGnbvjYbjyMXy - nQJmhnZiAuFEmstaIgCDkreXzhrB) / AzVpqmGyJbcNCVgGNhivXoxBUVlW * 4500);
			if (num >= 36000)
			{
				num = 0;
			}
			return num;
		}
	}

	public xUkogfykfWydPVNPxCXnPdDmMbJj(byte P_0, ushort P_1, ushort P_2, int P_3, int P_4, int P_5, int P_6, int P_7, int P_8, uint P_9, uint P_10, int P_11)
		: base(P_0, P_1, P_2, P_3, P_4)
	{
		nQJmhnZiAuFEmstaIgCDkreXzhrB = P_5;
		QvZdMzCbUtHKovNLmBylopcaPzzS = P_6;
		JCrEhQCupMCLPwtKslLWcFCgHhpqA = P_9;
		iDvBKsHJZaxHAKRBdTFcFuPjPblhb = P_10;
		MYpGpFaacxCVXPojOlTwfUvyonCm = P_11;
		eUmTuSVapkRPHuBYLZtDLcqTXNsb = P_5 - 1;
		if (eUmTuSVapkRPHuBYLZtDLcqTXNsb < 0)
		{
			eUmTuSVapkRPHuBYLZtDLcqTXNsb = P_6 + 1;
		}
		FjKLItLbYtDFsAHWcYcrUxwBwxac = -1;
		int num = P_6 - P_5 + 1;
		AzVpqmGyJbcNCVgGNhivXoxBUVlW = MathTools.Clamp(num / 8, 1, int.MaxValue);
		WLpCgmTeuIfcoKwzZXMvTrveLQmtA();
	}

	public virtual void YMzfUXqhVwRGKfBeAfPcLCexGKPp()
	{
		RceibuJrKbjOUaaiGnbvjYbjyMXy = (uint)eUmTuSVapkRPHuBYLZtDLcqTXNsb;
	}
}
