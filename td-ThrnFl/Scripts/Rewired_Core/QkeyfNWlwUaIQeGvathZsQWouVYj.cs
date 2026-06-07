using UnityEngine;

internal static class QkeyfNWlwUaIQeGvathZsQWouVYj
{
	private static int PFeJcGIjpJvFkGSHcdTjNmhJFDhv;

	private static int kFzsASZUAgTbIZdRxuHGITbZhcZc;

	private static double[] DlZXhcqVPbQIyGEOacXcWThXbokW;

	private static int QPbNhvfuxTaeHWjYCarmjwAaeiwt;

	private static double NbMjkuzrpYBpkOMrtCkDJoZbzvPE;

	private static int TpCEkwIecUjxIEDrKhimLdzCfsajC;

	public static double MGaBxGdJXIqVTyWmkqUcKnCcKJjl => NbMjkuzrpYBpkOMrtCkDJoZbzvPE;

	public static int DSPMjCnhMqgOsyHcuQyugaSvroRI
	{
		get
		{
			return PFeJcGIjpJvFkGSHcdTjNmhJFDhv;
		}
		set
		{
			if (num <= 0)
			{
				num = 1;
			}
			if (num != PFeJcGIjpJvFkGSHcdTjNmhJFDhv)
			{
				PFeJcGIjpJvFkGSHcdTjNmhJFDhv = num;
				RAPkbbcgrGeeRmtbbhzLbPiSVsjeA();
			}
		}
	}

	static QkeyfNWlwUaIQeGvathZsQWouVYj()
	{
		PFeJcGIjpJvFkGSHcdTjNmhJFDhv = 30;
		RAPkbbcgrGeeRmtbbhzLbPiSVsjeA();
	}

	public static void ojraMGCuaiFqtOuqdNSVcvqXZltV()
	{
		int frameCount = Time.frameCount;
		if (TpCEkwIecUjxIEDrKhimLdzCfsajC < frameCount)
		{
			DlZXhcqVPbQIyGEOacXcWThXbokW[kFzsASZUAgTbIZdRxuHGITbZhcZc] = Time.deltaTime;
			if (QPbNhvfuxTaeHWjYCarmjwAaeiwt < PFeJcGIjpJvFkGSHcdTjNmhJFDhv)
			{
				QPbNhvfuxTaeHWjYCarmjwAaeiwt++;
			}
			double num = 0.0;
			for (int i = 0; i < QPbNhvfuxTaeHWjYCarmjwAaeiwt; i++)
			{
				num += DlZXhcqVPbQIyGEOacXcWThXbokW[i];
			}
			NbMjkuzrpYBpkOMrtCkDJoZbzvPE = num / (double)QPbNhvfuxTaeHWjYCarmjwAaeiwt;
			kFzsASZUAgTbIZdRxuHGITbZhcZc++;
			if (kFzsASZUAgTbIZdRxuHGITbZhcZc >= PFeJcGIjpJvFkGSHcdTjNmhJFDhv)
			{
				kFzsASZUAgTbIZdRxuHGITbZhcZc = 0;
			}
			TpCEkwIecUjxIEDrKhimLdzCfsajC = frameCount;
		}
	}

	public static void RAPkbbcgrGeeRmtbbhzLbPiSVsjeA()
	{
		if (DlZXhcqVPbQIyGEOacXcWThXbokW == null || DlZXhcqVPbQIyGEOacXcWThXbokW.Length != PFeJcGIjpJvFkGSHcdTjNmhJFDhv)
		{
			DlZXhcqVPbQIyGEOacXcWThXbokW = new double[PFeJcGIjpJvFkGSHcdTjNmhJFDhv];
		}
		QPbNhvfuxTaeHWjYCarmjwAaeiwt = 0;
		kFzsASZUAgTbIZdRxuHGITbZhcZc = 0;
		TpCEkwIecUjxIEDrKhimLdzCfsajC = 0;
	}
}
