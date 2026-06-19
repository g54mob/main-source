using System;
using Rewired.Utils.Classes.Data;

internal class JIxBNLfOAPhdPBxkKRDEqbmYHLnib : tNSBtIwTqUeWpGtNoXsrdaEOoFDcA
{
	public readonly float[] idaOHKBnMGIFbSErnXWBOkCLqsFq;

	public double oayaianiTDuZRllDRWQKJQLmaCRx;

	public readonly int jLRWgflYJupJFAzqRgETQAptariw;

	private readonly byte[] HcrkmYIPLyXZfRwCcjsjArpqRZym;

	private readonly int LCAbjjLTCiQimTihzjLFRFqQOKKI;

	private readonly int PVFDnraEjwmyvhxglsDdfkLViihV;

	private readonly Action<byte[], float[]> pZzChDZyqraThXklEWgCKFizeBQh;

	public JIxBNLfOAPhdPBxkKRDEqbmYHLnib(byte P_0, HIDInfo P_1, int P_2, Action<byte[], float[]> P_3)
		: base(P_0, P_1)
	{
		jLRWgflYJupJFAzqRgETQAptariw = P_2;
		pZzChDZyqraThXklEWgCKFizeBQh = P_3;
		LCAbjjLTCiQimTihzjLFRFqQOKKI = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		PVFDnraEjwmyvhxglsDdfkLViihV = P_1.dataIndex;
		HcrkmYIPLyXZfRwCcjsjArpqRZym = new byte[LCAbjjLTCiQimTihzjLFRFqQOKKI];
		idaOHKBnMGIFbSErnXWBOkCLqsFq = new float[P_2];
	}

	public virtual void pTKbqyHfdMowrpddKmPlcWdDgzRIb(NativeBuffer P_0, double P_1)
	{
		if (P_0 != null && P_0[0] == ZfhixqygedAFuxvJkiAMIicmaEDTA)
		{
			oayaianiTDuZRllDRWQKJQLmaCRx = P_1;
			for (int i = 0; i < LCAbjjLTCiQimTihzjLFRFqQOKKI; i++)
			{
				HcrkmYIPLyXZfRwCcjsjArpqRZym[i] = P_0[PVFDnraEjwmyvhxglsDdfkLViihV + i];
			}
			if (pZzChDZyqraThXklEWgCKFizeBQh != null)
			{
				pZzChDZyqraThXklEWgCKFizeBQh(HcrkmYIPLyXZfRwCcjsjArpqRZym, idaOHKBnMGIFbSErnXWBOkCLqsFq);
			}
		}
	}

	public void FOTNgOYLYkCJqAfboKnKgGniLRbFB(float[] P_0, double P_1)
	{
		oayaianiTDuZRllDRWQKJQLmaCRx = P_1;
		for (int i = 0; i < jLRWgflYJupJFAzqRgETQAptariw; i++)
		{
			idaOHKBnMGIFbSErnXWBOkCLqsFq[i] = P_0[i];
		}
	}
}
