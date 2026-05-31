using System;

internal static class CkEGbSjYizEFwFszszFTBPspHuob
{
	public const float rUoeSlEMwsSpnQPnTTbsxKWlPMj = 1E-06f;

	public const float lNVtBpZfONQjobATKRZMdyfIWvs = (float)Math.PI;

	public const float kuCuKqpHXRTdLtPyGWERJgaaEPQ = (float)Math.PI * 2f;

	public const float VpCwJrkfVIBSepOpKzeadvAxsoC = (float)Math.PI / 2f;

	public const float IuqZDNcmAsfaoGXtwZexAhSIPZto = (float)Math.PI / 4f;

	public unsafe static bool mlfTtstFxHQkEDuBkHVDxIjrIgH(float P_0, float P_1)
	{
		if (SXktbuttrkwuTniKXJmbHqxZqAG(P_0 - P_1))
		{
			return true;
		}
		int num = *(int*)(&P_0);
		int num2 = *(int*)(&P_1);
		if (num < 0 != num2 < 0)
		{
			return false;
		}
		int num3 = Math.Abs(num - num2);
		return num3 <= 4;
	}

	public static bool SXktbuttrkwuTniKXJmbHqxZqAG(float P_0)
	{
		return Math.Abs(P_0) < 1E-06f;
	}

	public static bool UAZzaXyOcbJIggCTgTdBYLiCFQDf(float P_0)
	{
		return SXktbuttrkwuTniKXJmbHqxZqAG(P_0 - 1f);
	}

	public static bool eOPAEdlPjqOrGZepcagYalLQAuEK(float P_0, float P_1, float P_2)
	{
		float num = P_0 - P_1;
		if (0f - P_2 <= num)
		{
			return num <= P_2;
		}
		return false;
	}

	public static float FXGuevlfAgebQtuzInSlugUlbszc(float P_0)
	{
		return P_0 * 360f;
	}

	public static float rOxewGzBLCHkMheXrrfxIjfNcyX(float P_0)
	{
		return P_0 * ((float)Math.PI * 2f);
	}

	public static float IhkFftbbiJOcZdddFLFGmggpEVsu(float P_0)
	{
		return P_0 * 400f;
	}

	public static float fySjGsJUcnSKGDYNVDabAcXwmyi(float P_0)
	{
		return P_0 / 360f;
	}

	public static float QrztJTzGvyhWyBrLmKSkkuyJrqw(float P_0)
	{
		return P_0 * ((float)Math.PI / 180f);
	}

	public static float YcIhyukFboKtTfnBDhOnZKvRwjn(float P_0)
	{
		return P_0 / ((float)Math.PI * 2f);
	}

	public static float BESflLOoqdgOCCPHdlpumNFCwcxF(float P_0)
	{
		return P_0 * (200f / (float)Math.PI);
	}

	public static float jHNzBbcRxsfBPbzVxMlGGTVKThy(float P_0)
	{
		return P_0 / 400f;
	}

	public static float ExSrdopekLvugqPtevkAvVJrRGg(float P_0)
	{
		return P_0 * 0.9f;
	}

	public static float RTFHbrvznAJzKHXxEXoxKRbtzDN(float P_0)
	{
		return P_0 * ((float)Math.PI / 200f);
	}

	public static float SOhksjhelaQPIxgkxpSuqacaFsOF(float P_0)
	{
		return P_0 * (180f / (float)Math.PI);
	}

	public static float hCeslVsamdWtrWFAzXcKGwRWlYQ(float P_0, float P_1, float P_2)
	{
		if (!(P_0 < P_1))
		{
			if (!(P_0 > P_2))
			{
				return P_0;
			}
			return P_2;
		}
		return P_1;
	}

	public static int hCeslVsamdWtrWFAzXcKGwRWlYQ(int P_0, int P_1, int P_2)
	{
		if (P_0 >= P_1)
		{
			if (P_0 <= P_2)
			{
				return P_0;
			}
			return P_2;
		}
		return P_1;
	}

	public static double nUkwRCCEqSRiBfomCbTByDmHQib(double P_0, double P_1, double P_2)
	{
		return (1.0 - P_2) * P_0 + P_2 * P_1;
	}

	public static float nUkwRCCEqSRiBfomCbTByDmHQib(float P_0, float P_1, float P_2)
	{
		return (1f - P_2) * P_0 + P_2 * P_1;
	}

	public static byte nUkwRCCEqSRiBfomCbTByDmHQib(byte P_0, byte P_1, float P_2)
	{
		return (byte)nUkwRCCEqSRiBfomCbTByDmHQib((int)P_0, (int)P_1, P_2);
	}

	public static float pSjObtuRtbZcOLsNgMHELnxtNdJ(float P_0)
	{
		if (!(P_0 <= 0f))
		{
			if (!(P_0 >= 1f))
			{
				return P_0 * P_0 * (3f - 2f * P_0);
			}
			return 1f;
		}
		return 0f;
	}

	public static float OwdOateYIeWIWYyKIFCFtezcVqs(float P_0)
	{
		if (!(P_0 <= 0f))
		{
			if (!(P_0 >= 1f))
			{
				return P_0 * P_0 * P_0 * (P_0 * (P_0 * 6f - 15f) + 10f);
			}
			return 1f;
		}
		return 0f;
	}

	public static float dtuhGwIfwpIrNPZrYnALKhzIGSr(float P_0, float P_1)
	{
		if (P_1 == 0f)
		{
			return P_0;
		}
		return P_0 % P_1;
	}

	public static float GctjhmKpITPuRsVDbCpdNoMgKMee(float P_0)
	{
		return dtuhGwIfwpIrNPZrYnALKhzIGSr(P_0, (float)Math.PI * 2f);
	}

	public static int jiWlTiZDujaIcCQYGUrYezCKQoS(int P_0, int P_1, int P_2)
	{
		if (P_1 > P_2)
		{
			throw new ArgumentException($"min {P_1} should be less than or equal to max {P_2}", "min");
		}
		int num = P_2 - P_1 + 1;
		if (P_0 < P_1)
		{
			P_0 += num * ((P_1 - P_0) / num + 1);
		}
		return P_1 + (P_0 - P_1) % num;
	}

	public static float jiWlTiZDujaIcCQYGUrYezCKQoS(float P_0, float P_1, float P_2)
	{
		if (mlfTtstFxHQkEDuBkHVDxIjrIgH(P_1, P_2))
		{
			return P_1;
		}
		double num = P_1;
		double num2 = P_2;
		double num3 = P_0;
		if (num > num2)
		{
			throw new ArgumentException($"min {P_1} should be less than or equal to max {P_2}", "min");
		}
		double num4 = num2 - num;
		return (float)(num + (num3 - num) - num4 * Math.Floor((num3 - num) / num4));
	}

	public static float aLpoadZiCAeTdbIGwSNbSNwfuDo(float P_0, float P_1, float P_2, float P_3, float P_4, float P_5, float P_6)
	{
		return (float)aLpoadZiCAeTdbIGwSNbSNwfuDo((double)P_0, (double)P_1, (double)P_2, (double)P_3, (double)P_4, (double)P_5, (double)P_6);
	}

	public static double aLpoadZiCAeTdbIGwSNbSNwfuDo(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6)
	{
		return P_0 * Math.E - (Math.Pow(P_1 - P_3 / 2.0, 2.0) / (2.0 * Math.Pow(P_5, 2.0)) + Math.Pow(P_2 - P_4 / 2.0, 2.0) / (2.0 * Math.Pow(P_6, 2.0)));
	}
}
