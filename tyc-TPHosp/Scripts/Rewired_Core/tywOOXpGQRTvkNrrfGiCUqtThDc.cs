using UnityEngine;

internal static class tywOOXpGQRTvkNrrfGiCUqtThDc
{
	private static int ZZBorRBpWOSYGqAsfArgOabxAmPJ;

	private static int FMfGoswTmMzBNBPokzjvUBjQbHe;

	private static double[] WxomokYLAIwhwjPjzCPVeNXeVIaS;

	private static int nUbnQcAKFIpcNvDQuEZsakvRpNPI;

	private static double AHxtOKsPBtzKNILzxXXfHzGYUOx;

	private static int uOZpNEmWISaOyOQYcLiqGrdoMOY;

	public static double smoothDeltaTime => AHxtOKsPBtzKNILzxXXfHzGYUOx;

	public static int framesToSmooth
	{
		get
		{
			return ZZBorRBpWOSYGqAsfArgOabxAmPJ;
		}
		set
		{
			if (value <= 0)
			{
				value = 1;
			}
			if (value != ZZBorRBpWOSYGqAsfArgOabxAmPJ)
			{
				ZZBorRBpWOSYGqAsfArgOabxAmPJ = value;
				QjNHfjHnCmaQyvCGKbwODraSxUWC();
			}
		}
	}

	static tywOOXpGQRTvkNrrfGiCUqtThDc()
	{
		ZZBorRBpWOSYGqAsfArgOabxAmPJ = 30;
		QjNHfjHnCmaQyvCGKbwODraSxUWC();
	}

	public static void QTPiZFmnRsxmyQYmMuIoBQkOtfg()
	{
		int frameCount = Time.frameCount;
		if (uOZpNEmWISaOyOQYcLiqGrdoMOY < frameCount)
		{
			WxomokYLAIwhwjPjzCPVeNXeVIaS[FMfGoswTmMzBNBPokzjvUBjQbHe] = Time.deltaTime;
			if (nUbnQcAKFIpcNvDQuEZsakvRpNPI < ZZBorRBpWOSYGqAsfArgOabxAmPJ)
			{
				nUbnQcAKFIpcNvDQuEZsakvRpNPI++;
			}
			double num = 0.0;
			for (int i = 0; i < nUbnQcAKFIpcNvDQuEZsakvRpNPI; i++)
			{
				num += WxomokYLAIwhwjPjzCPVeNXeVIaS[i];
			}
			AHxtOKsPBtzKNILzxXXfHzGYUOx = num / (double)nUbnQcAKFIpcNvDQuEZsakvRpNPI;
			FMfGoswTmMzBNBPokzjvUBjQbHe++;
			if (FMfGoswTmMzBNBPokzjvUBjQbHe >= ZZBorRBpWOSYGqAsfArgOabxAmPJ)
			{
				FMfGoswTmMzBNBPokzjvUBjQbHe = 0;
			}
			uOZpNEmWISaOyOQYcLiqGrdoMOY = frameCount;
		}
	}

	public static void QjNHfjHnCmaQyvCGKbwODraSxUWC()
	{
		if (WxomokYLAIwhwjPjzCPVeNXeVIaS == null || WxomokYLAIwhwjPjzCPVeNXeVIaS.Length != ZZBorRBpWOSYGqAsfArgOabxAmPJ)
		{
			WxomokYLAIwhwjPjzCPVeNXeVIaS = new double[ZZBorRBpWOSYGqAsfArgOabxAmPJ];
		}
		nUbnQcAKFIpcNvDQuEZsakvRpNPI = 0;
		FMfGoswTmMzBNBPokzjvUBjQbHe = 0;
		uOZpNEmWISaOyOQYcLiqGrdoMOY = 0;
	}
}
