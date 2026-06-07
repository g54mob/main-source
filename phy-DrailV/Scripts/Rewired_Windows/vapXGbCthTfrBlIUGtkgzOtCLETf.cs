using Rewired.Utils.Classes.Data;

internal class vapXGbCthTfrBlIUGtkgzOtCLETf : YszNVDBZreQueMHaxAPTEUkXgqRz
{
	public int QGEPzKgIedvthGPliWOduwXNjWui;

	public double YxFdZozJytryXOxcRaQAmySLFHVc;

	public readonly int NFBfIavLmQumHiFjQGXsgfhnLmUeA;

	public readonly int LMvFEAtZBwQRlFfEWyZfAAUImHJg;

	public readonly bool jpOYScPJzgoRVtkuhHhSZGnnkzEr;

	public readonly int dzEwyOuvibmWJysIGRHDlqlIWbdv;

	public readonly int OWChBGaORrpUFZZNAMbneFRanRIK;

	public readonly int RlldEXEYJXNHdfRJaRjdqgrcQlWiA;

	public vapXGbCthTfrBlIUGtkgzOtCLETf(byte P_0, HIDInfo P_1, bool P_2, int P_3)
		: base(P_0, P_1)
	{
		NFBfIavLmQumHiFjQGXsgfhnLmUeA = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		LMvFEAtZBwQRlFfEWyZfAAUImHJg = P_1.dataIndex;
		jpOYScPJzgoRVtkuhHhSZGnnkzEr = P_2;
		dzEwyOuvibmWJysIGRHDlqlIWbdv = P_1.logicalMin;
		OWChBGaORrpUFZZNAMbneFRanRIK = P_1.logicalMax;
		RlldEXEYJXNHdfRJaRjdqgrcQlWiA = P_3;
	}

	public override void trsfRiBFSIjLrLMemKcGjgULCoSi(NativeBuffer P_0, double P_1)
	{
		if (P_0 == null || P_0[0] != UQBUMeskXtetUCCacGGybviytBzpA)
		{
			return;
		}
		YxFdZozJytryXOxcRaQAmySLFHVc = P_1;
		int num = 0;
		if (NFBfIavLmQumHiFjQGXsgfhnLmUeA > 1)
		{
			for (int i = 0; i < NFBfIavLmQumHiFjQGXsgfhnLmUeA; i++)
			{
				num |= P_0[LMvFEAtZBwQRlFfEWyZfAAUImHJg + i] << 8 * i;
			}
		}
		else
		{
			num = P_0[LMvFEAtZBwQRlFfEWyZfAAUImHJg];
		}
		QGEPzKgIedvthGPliWOduwXNjWui = num;
	}
}
