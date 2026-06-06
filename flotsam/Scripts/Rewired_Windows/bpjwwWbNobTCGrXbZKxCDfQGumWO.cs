using Rewired.Utils.Classes.Data;

internal class bpjwwWbNobTCGrXbZKxCDfQGumWO : OYzieseEeYXDrIqXsZAdwVmBBsCg
{
	public int GBRfctCquVDcQYutoktolbVReARh;

	public double TcDiwnaVRibyvGKtKcdyyPUTGpnj;

	public readonly int QZMDtbcLshGsBuBuOMrRyzRixQUs;

	public readonly int DhZGsbWwJFurgGRFtxBgFamEFtEO;

	public readonly bool OYTreTWlSFnljFVEMCBWmVcNgeMc;

	public readonly int wFmzwhemaNfcMWtxvSxHleOxFvPe;

	public readonly int bwKsRsgKHTLJIwqJYEWQZyklLHkt;

	public readonly int pshaBFkeFPJwddorBnLyIBvXcGBIB;

	public bpjwwWbNobTCGrXbZKxCDfQGumWO(byte P_0, HIDInfo P_1, bool P_2, int P_3)
		: base(P_0, P_1)
	{
		QZMDtbcLshGsBuBuOMrRyzRixQUs = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		DhZGsbWwJFurgGRFtxBgFamEFtEO = P_1.dataIndex;
		OYTreTWlSFnljFVEMCBWmVcNgeMc = P_2;
		wFmzwhemaNfcMWtxvSxHleOxFvPe = P_1.logicalMin;
		bwKsRsgKHTLJIwqJYEWQZyklLHkt = P_1.logicalMax;
		pshaBFkeFPJwddorBnLyIBvXcGBIB = P_3;
	}

	public virtual void jOHidzTbgtMaabkOGNOXuaeYJnLC(NativeBuffer P_0, double P_1)
	{
		if (P_0 == null || P_0[0] != wVMsnOmodjAbsSEDwjTEwlMnMPQg)
		{
			return;
		}
		TcDiwnaVRibyvGKtKcdyyPUTGpnj = P_1;
		int num = 0;
		if (QZMDtbcLshGsBuBuOMrRyzRixQUs > 1)
		{
			for (int i = 0; i < QZMDtbcLshGsBuBuOMrRyzRixQUs; i++)
			{
				num |= P_0[DhZGsbWwJFurgGRFtxBgFamEFtEO + i] << 8 * i;
			}
		}
		else
		{
			num = P_0[DhZGsbWwJFurgGRFtxBgFamEFtEO];
		}
		GBRfctCquVDcQYutoktolbVReARh = num;
	}
}
