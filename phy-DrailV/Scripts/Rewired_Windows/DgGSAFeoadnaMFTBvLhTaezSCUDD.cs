using System;
using Rewired.Utils.Classes.Data;

internal class DgGSAFeoadnaMFTBvLhTaezSCUDD : YszNVDBZreQueMHaxAPTEUkXgqRz
{
	public enum kjKxnlTanlAHHiMoCkdfdyyngeGK
	{
		Default = 0,
		Custom = 1
	}

	public int QGEPzKgIedvthGPliWOduwXNjWui;

	public double YxFdZozJytryXOxcRaQAmySLFHVc;

	public readonly int NFBfIavLmQumHiFjQGXsgfhnLmUeA;

	public readonly int LMvFEAtZBwQRlFfEWyZfAAUImHJg;

	public readonly kjKxnlTanlAHHiMoCkdfdyyngeGK vwXQQHFBJrsmGgoRIAbOFEOWEDyP;

	private Func<int, int> zovEYMDwzpRetqGCitWoSXfGWxUAA;

	public DgGSAFeoadnaMFTBvLhTaezSCUDD(byte P_0, HIDInfo P_1, kjKxnlTanlAHHiMoCkdfdyyngeGK P_2)
		: base(P_0, P_1)
	{
		vwXQQHFBJrsmGgoRIAbOFEOWEDyP = P_2;
		NFBfIavLmQumHiFjQGXsgfhnLmUeA = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		LMvFEAtZBwQRlFfEWyZfAAUImHJg = P_1.dataIndex;
	}

	public DgGSAFeoadnaMFTBvLhTaezSCUDD(byte P_0, HIDInfo P_1, Func<int, int> P_2)
		: this(P_0, P_1, kjKxnlTanlAHHiMoCkdfdyyngeGK.Custom)
	{
		zovEYMDwzpRetqGCitWoSXfGWxUAA = P_2;
	}

	public override void trsfRiBFSIjLrLMemKcGjgULCoSi(NativeBuffer P_0, double P_1)
	{
		if (P_0 == null || P_0[0] != UQBUMeskXtetUCCacGGybviytBzpA)
		{
			return;
		}
		YxFdZozJytryXOxcRaQAmySLFHVc = P_1;
		if (NFBfIavLmQumHiFjQGXsgfhnLmUeA == 1)
		{
			QGEPzKgIedvthGPliWOduwXNjWui = P_0[LMvFEAtZBwQRlFfEWyZfAAUImHJg];
		}
		else
		{
			QGEPzKgIedvthGPliWOduwXNjWui = 0;
			for (int i = 0; i < NFBfIavLmQumHiFjQGXsgfhnLmUeA; i++)
			{
				QGEPzKgIedvthGPliWOduwXNjWui |= P_0[LMvFEAtZBwQRlFfEWyZfAAUImHJg + i] << 8 * i;
			}
		}
		if (vwXQQHFBJrsmGgoRIAbOFEOWEDyP == kjKxnlTanlAHHiMoCkdfdyyngeGK.Custom && zovEYMDwzpRetqGCitWoSXfGWxUAA != null)
		{
			QGEPzKgIedvthGPliWOduwXNjWui = zovEYMDwzpRetqGCitWoSXfGWxUAA(QGEPzKgIedvthGPliWOduwXNjWui);
		}
	}
}
