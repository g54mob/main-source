using Rewired.Utils.Classes.Data;

internal class dnWPfQfDfnEmaJKgzGFSEYqFnsqm : QAOlVgyStIKpRmoWAGbpIzIYHZwjA
{
	public int AFeCCnfGrZdxczugCbIwzuDEkotAA;

	public double TFkIJldqSkkPNFsiiqYofhqyQQLNc;

	public readonly int OJtURdoxzdOdrCdKuPcXrblvQQwF;

	public readonly int LAyinrKIIPSEUFsWXGPkTAQHZlaDA;

	public readonly bool KaquSmCIgIgDLCnMqwwPhhrAacAVA;

	public readonly int gyLEKdibfJVFesZwBelJgzUaPXdj;

	public readonly int tcfgEscQERdpsSMOkehIKHSqBsAJ;

	public readonly int foOwnHqQELChNQyoBdokMxBhMvvH;

	public dnWPfQfDfnEmaJKgzGFSEYqFnsqm(byte P_0, HIDInfo P_1, bool P_2, int P_3)
		: base(P_0, P_1)
	{
		OJtURdoxzdOdrCdKuPcXrblvQQwF = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		LAyinrKIIPSEUFsWXGPkTAQHZlaDA = P_1.dataIndex;
		KaquSmCIgIgDLCnMqwwPhhrAacAVA = P_2;
		gyLEKdibfJVFesZwBelJgzUaPXdj = P_1.logicalMin;
		tcfgEscQERdpsSMOkehIKHSqBsAJ = P_1.logicalMax;
		foOwnHqQELChNQyoBdokMxBhMvvH = P_3;
	}

	public virtual void xUopRlDKsdmtEVYjmjkBzHKHRyzh(NativeBuffer P_0, double P_1)
	{
		if (P_0 == null || P_0[0] != gijfZOkdrxcTAgIIOZwUzEqukUux)
		{
			return;
		}
		TFkIJldqSkkPNFsiiqYofhqyQQLNc = P_1;
		int num = 0;
		if (OJtURdoxzdOdrCdKuPcXrblvQQwF > 1)
		{
			for (int i = 0; i < OJtURdoxzdOdrCdKuPcXrblvQQwF; i++)
			{
				num |= P_0[LAyinrKIIPSEUFsWXGPkTAQHZlaDA + i] << 8 * i;
			}
		}
		else
		{
			num = P_0[LAyinrKIIPSEUFsWXGPkTAQHZlaDA];
		}
		AFeCCnfGrZdxczugCbIwzuDEkotAA = num;
	}
}
