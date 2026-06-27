using UnityEngine;

internal static class uwdeJePnmYRDmtXmbbaaXWafrWoR
{
	private static int xUjLuhDQhLohSRLCxOrCehTGdYBI;

	private static int WZywRpWlMqTksYBswUjqjHhGAVxQ;

	private static double[] dcUhoBnMJvdjGXkHbmCBhWNWJUMy;

	private static int qGyeyYynbDeJbFwFREoHWDqjTCOr;

	private static double lWXVQVyKnICyGVhTsdFamzOoQHxO;

	private static int xbXTAVzFgCMpiCHiqitFKsJwwMDw;

	public static double mXzOCbkZLGRLdvenxhrPAnipMyXLA => lWXVQVyKnICyGVhTsdFamzOoQHxO;

	public static int rgMFddDaMeaHKfnrbWZHWRcwGLpdb
	{
		get
		{
			return xUjLuhDQhLohSRLCxOrCehTGdYBI;
		}
		set
		{
			if (num <= 0)
			{
				num = 1;
			}
			if (num != xUjLuhDQhLohSRLCxOrCehTGdYBI)
			{
				xUjLuhDQhLohSRLCxOrCehTGdYBI = num;
				hqMIIMrOrCRlnximuepoiHQTfWPS();
			}
		}
	}

	static uwdeJePnmYRDmtXmbbaaXWafrWoR()
	{
		xUjLuhDQhLohSRLCxOrCehTGdYBI = 30;
		hqMIIMrOrCRlnximuepoiHQTfWPS();
	}

	public static void KpqjudxgJqDABfxPeHSaPABWXDXE()
	{
		int frameCount = Time.frameCount;
		if (xbXTAVzFgCMpiCHiqitFKsJwwMDw < frameCount)
		{
			dcUhoBnMJvdjGXkHbmCBhWNWJUMy[WZywRpWlMqTksYBswUjqjHhGAVxQ] = Time.deltaTime;
			if (qGyeyYynbDeJbFwFREoHWDqjTCOr < xUjLuhDQhLohSRLCxOrCehTGdYBI)
			{
				qGyeyYynbDeJbFwFREoHWDqjTCOr++;
			}
			double num = 0.0;
			for (int i = 0; i < qGyeyYynbDeJbFwFREoHWDqjTCOr; i++)
			{
				num += dcUhoBnMJvdjGXkHbmCBhWNWJUMy[i];
			}
			lWXVQVyKnICyGVhTsdFamzOoQHxO = num / (double)qGyeyYynbDeJbFwFREoHWDqjTCOr;
			WZywRpWlMqTksYBswUjqjHhGAVxQ++;
			if (WZywRpWlMqTksYBswUjqjHhGAVxQ >= xUjLuhDQhLohSRLCxOrCehTGdYBI)
			{
				WZywRpWlMqTksYBswUjqjHhGAVxQ = 0;
			}
			xbXTAVzFgCMpiCHiqitFKsJwwMDw = frameCount;
		}
	}

	public static void hqMIIMrOrCRlnximuepoiHQTfWPS()
	{
		if (dcUhoBnMJvdjGXkHbmCBhWNWJUMy == null || dcUhoBnMJvdjGXkHbmCBhWNWJUMy.Length != xUjLuhDQhLohSRLCxOrCehTGdYBI)
		{
			dcUhoBnMJvdjGXkHbmCBhWNWJUMy = new double[xUjLuhDQhLohSRLCxOrCehTGdYBI];
		}
		qGyeyYynbDeJbFwFREoHWDqjTCOr = 0;
		WZywRpWlMqTksYBswUjqjHhGAVxQ = 0;
		xbXTAVzFgCMpiCHiqitFKsJwwMDw = 0;
	}
}
