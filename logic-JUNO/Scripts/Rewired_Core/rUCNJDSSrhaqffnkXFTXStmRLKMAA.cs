using UnityEngine;

internal static class rUCNJDSSrhaqffnkXFTXStmRLKMAA
{
	private static int ooMTpKQIeggDTFQYFGjfEeVyPvlN;

	private static int HtHbHSNsNPyLvSncOKGXVFhkpJLw;

	private static double[] ewfRmoiwYSPYZXaNBglkbHTwpCwqA;

	private static int tIBQgrzSsmRiyLKXhdZiAuiXCMwWA;

	private static double oxeAMkGzedeDBTBBYBmNfAUkEJPtb;

	private static int esmNdmivettzvYoBCSngmBIKKfff;

	public static double bnOECKrHQfokornpBAGgThwPmmdv => oxeAMkGzedeDBTBBYBmNfAUkEJPtb;

	public static int wmftnOhkDZbgPabnJAomBdcJIRFhB
	{
		get
		{
			return ooMTpKQIeggDTFQYFGjfEeVyPvlN;
		}
		set
		{
			if (num <= 0)
			{
				num = 1;
			}
			if (num != ooMTpKQIeggDTFQYFGjfEeVyPvlN)
			{
				ooMTpKQIeggDTFQYFGjfEeVyPvlN = num;
				etrYFpmywxccoxywULhJIIUlGcbK();
			}
		}
	}

	static rUCNJDSSrhaqffnkXFTXStmRLKMAA()
	{
		ooMTpKQIeggDTFQYFGjfEeVyPvlN = 30;
		etrYFpmywxccoxywULhJIIUlGcbK();
	}

	public static void TVNbWkipGBwjUphjGwaJthMiHqfJ()
	{
		int frameCount = Time.frameCount;
		if (esmNdmivettzvYoBCSngmBIKKfff < frameCount)
		{
			ewfRmoiwYSPYZXaNBglkbHTwpCwqA[HtHbHSNsNPyLvSncOKGXVFhkpJLw] = Time.deltaTime;
			if (tIBQgrzSsmRiyLKXhdZiAuiXCMwWA < ooMTpKQIeggDTFQYFGjfEeVyPvlN)
			{
				tIBQgrzSsmRiyLKXhdZiAuiXCMwWA++;
			}
			double num = 0.0;
			for (int i = 0; i < tIBQgrzSsmRiyLKXhdZiAuiXCMwWA; i++)
			{
				num += ewfRmoiwYSPYZXaNBglkbHTwpCwqA[i];
			}
			oxeAMkGzedeDBTBBYBmNfAUkEJPtb = num / (double)tIBQgrzSsmRiyLKXhdZiAuiXCMwWA;
			HtHbHSNsNPyLvSncOKGXVFhkpJLw++;
			if (HtHbHSNsNPyLvSncOKGXVFhkpJLw >= ooMTpKQIeggDTFQYFGjfEeVyPvlN)
			{
				HtHbHSNsNPyLvSncOKGXVFhkpJLw = 0;
			}
			esmNdmivettzvYoBCSngmBIKKfff = frameCount;
		}
	}

	public static void etrYFpmywxccoxywULhJIIUlGcbK()
	{
		if (ewfRmoiwYSPYZXaNBglkbHTwpCwqA == null || ewfRmoiwYSPYZXaNBglkbHTwpCwqA.Length != ooMTpKQIeggDTFQYFGjfEeVyPvlN)
		{
			ewfRmoiwYSPYZXaNBglkbHTwpCwqA = new double[ooMTpKQIeggDTFQYFGjfEeVyPvlN];
		}
		tIBQgrzSsmRiyLKXhdZiAuiXCMwWA = 0;
		HtHbHSNsNPyLvSncOKGXVFhkpJLw = 0;
		esmNdmivettzvYoBCSngmBIKKfff = 0;
	}
}
