using System;
using Rewired.Utils.Classes.Data;

internal class cqHyUHXvbVNypcmuagNrSpCNtoPi : tNSBtIwTqUeWpGtNoXsrdaEOoFDcA
{
	public enum oaalkyhwIjdpUanFwyKoHcGZndSr
	{
		Default = 0,
		Custom = 1
	}

	public int GGagnQIPilUVMqLufzRKBTRofiRiA;

	public double pLMpGLFgQlFrjxYpCTnbyfedrNYb;

	public readonly int mHcauwHqAvLXoMuiBkehUKpLYFijA;

	public readonly int VqbrTKPFsHtclvDKnkFWfaANXzAp;

	public readonly oaalkyhwIjdpUanFwyKoHcGZndSr rVinWbizeFvurqKQglOCsOBZdfrdA;

	private Func<int, int> hzMSZBJjUMbAgcBGVvJaRLaFGTWv;

	public cqHyUHXvbVNypcmuagNrSpCNtoPi(byte P_0, HIDInfo P_1, oaalkyhwIjdpUanFwyKoHcGZndSr P_2)
		: base(P_0, P_1)
	{
		rVinWbizeFvurqKQglOCsOBZdfrdA = P_2;
		mHcauwHqAvLXoMuiBkehUKpLYFijA = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		VqbrTKPFsHtclvDKnkFWfaANXzAp = P_1.dataIndex;
	}

	public cqHyUHXvbVNypcmuagNrSpCNtoPi(byte P_0, HIDInfo P_1, Func<int, int> P_2)
		: this(P_0, P_1, oaalkyhwIjdpUanFwyKoHcGZndSr.Custom)
	{
		hzMSZBJjUMbAgcBGVvJaRLaFGTWv = P_2;
	}

	public virtual void PbBrbBghofqmceJEDBRjhaoxEdNd(NativeBuffer P_0, double P_1)
	{
		if (P_0 == null || P_0[0] != ZfhixqygedAFuxvJkiAMIicmaEDTA)
		{
			return;
		}
		pLMpGLFgQlFrjxYpCTnbyfedrNYb = P_1;
		if (mHcauwHqAvLXoMuiBkehUKpLYFijA == 1)
		{
			GGagnQIPilUVMqLufzRKBTRofiRiA = P_0[VqbrTKPFsHtclvDKnkFWfaANXzAp];
		}
		else
		{
			GGagnQIPilUVMqLufzRKBTRofiRiA = 0;
			for (int i = 0; i < mHcauwHqAvLXoMuiBkehUKpLYFijA; i++)
			{
				GGagnQIPilUVMqLufzRKBTRofiRiA |= P_0[VqbrTKPFsHtclvDKnkFWfaANXzAp + i] << 8 * i;
			}
		}
		if (rVinWbizeFvurqKQglOCsOBZdfrdA == oaalkyhwIjdpUanFwyKoHcGZndSr.Custom && hzMSZBJjUMbAgcBGVvJaRLaFGTWv != null)
		{
			GGagnQIPilUVMqLufzRKBTRofiRiA = hzMSZBJjUMbAgcBGVvJaRLaFGTWv(GGagnQIPilUVMqLufzRKBTRofiRiA);
		}
	}
}
