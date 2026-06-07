using UnityEngine;

internal static class oemUzSlcTcGNlIreexVbrpyyrLKd
{
	private static int AUPMlYNcgrSHLfbwcKGBzytAEmfR;

	private static int KorITzkUWrapWSEcrMKEngxzFXIp;

	private static double[] ZXaNitWaknTcfuwxyqccqQXXEWYv;

	private static int calQKpWxrxahQcFCjhmDhDnyVNhqA;

	private static double HjhviVkdIQaLFZBjaiVqinTfAVee;

	private static int ppLpVLowmzzqtFBKlkVHrpdTMkyg;

	public static double whdmaXpxejnggeyNiTJNhCDjIpyP => HjhviVkdIQaLFZBjaiVqinTfAVee;

	public static int OgMbUbypYpOVUvWhQzaXkiSgRnqd
	{
		get
		{
			return AUPMlYNcgrSHLfbwcKGBzytAEmfR;
		}
		set
		{
			if (num <= 0)
			{
				num = 1;
			}
			if (num != AUPMlYNcgrSHLfbwcKGBzytAEmfR)
			{
				AUPMlYNcgrSHLfbwcKGBzytAEmfR = num;
				XKZIxwRUwDpNhkICJrLjGrsjhGsn();
			}
		}
	}

	static oemUzSlcTcGNlIreexVbrpyyrLKd()
	{
		AUPMlYNcgrSHLfbwcKGBzytAEmfR = 30;
		XKZIxwRUwDpNhkICJrLjGrsjhGsn();
	}

	public static void DsDuSUaDcVanpNAhDLIRqjKndMGi()
	{
		int frameCount = Time.frameCount;
		if (ppLpVLowmzzqtFBKlkVHrpdTMkyg < frameCount)
		{
			ZXaNitWaknTcfuwxyqccqQXXEWYv[KorITzkUWrapWSEcrMKEngxzFXIp] = Time.deltaTime;
			if (calQKpWxrxahQcFCjhmDhDnyVNhqA < AUPMlYNcgrSHLfbwcKGBzytAEmfR)
			{
				calQKpWxrxahQcFCjhmDhDnyVNhqA++;
			}
			double num = 0.0;
			for (int i = 0; i < calQKpWxrxahQcFCjhmDhDnyVNhqA; i++)
			{
				num += ZXaNitWaknTcfuwxyqccqQXXEWYv[i];
			}
			HjhviVkdIQaLFZBjaiVqinTfAVee = num / (double)calQKpWxrxahQcFCjhmDhDnyVNhqA;
			KorITzkUWrapWSEcrMKEngxzFXIp++;
			if (KorITzkUWrapWSEcrMKEngxzFXIp >= AUPMlYNcgrSHLfbwcKGBzytAEmfR)
			{
				KorITzkUWrapWSEcrMKEngxzFXIp = 0;
			}
			ppLpVLowmzzqtFBKlkVHrpdTMkyg = frameCount;
		}
	}

	public static void XKZIxwRUwDpNhkICJrLjGrsjhGsn()
	{
		if (ZXaNitWaknTcfuwxyqccqQXXEWYv == null || ZXaNitWaknTcfuwxyqccqQXXEWYv.Length != AUPMlYNcgrSHLfbwcKGBzytAEmfR)
		{
			ZXaNitWaknTcfuwxyqccqQXXEWYv = new double[AUPMlYNcgrSHLfbwcKGBzytAEmfR];
		}
		calQKpWxrxahQcFCjhmDhDnyVNhqA = 0;
		KorITzkUWrapWSEcrMKEngxzFXIp = 0;
		ppLpVLowmzzqtFBKlkVHrpdTMkyg = 0;
	}
}
