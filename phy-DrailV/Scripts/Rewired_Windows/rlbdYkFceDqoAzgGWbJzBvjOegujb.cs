using System;

internal static class rlbdYkFceDqoAzgGWbJzBvjOegujb
{
	public const float EBfjVYHyYtIJdBYbdrSAJTAWQnzb = 1E-06f;

	public const float OgswLHSLMrIZSwBkwXSyDnuvKoqi = (float)Math.PI;

	public const float FyjNDUsTBliuxmYRgvIhlEnFxDEq = (float)Math.PI * 2f;

	public const float kdhqXFzKLspoOkhAqcnCFRDMTyQW = (float)Math.PI / 2f;

	public const float xaLgRvtbYOcVGUaOYokNBuPdCPhW = (float)Math.PI / 4f;

	public unsafe static bool NIYWKOoTvlXaeIxoMZMnBneCeJZH(float P_0, float P_1)
	{
		if (bVHYyCaIdSBdbqMrrqVHtsqsKsAG(P_0 - P_1))
		{
			return true;
		}
		int num = *(int*)(&P_0);
		int num2 = *(int*)(&P_1);
		if (num < 0 != num2 < 0)
		{
			return false;
		}
		return Math.Abs(num - num2) <= 4;
	}

	public static bool bVHYyCaIdSBdbqMrrqVHtsqsKsAG(float P_0)
	{
		return Math.Abs(P_0) < 1E-06f;
	}

	public static bool ntyFDpbBkBvWGtdeMjzxoxxpnGNo(float P_0)
	{
		return bVHYyCaIdSBdbqMrrqVHtsqsKsAG(P_0 - 1f);
	}

	public static bool BguBrHhwhIOWqKGWUWiuMFUfhgIrA(float P_0, float P_1, float P_2)
	{
		float num = P_0 - P_1;
		if (0f - P_2 <= num)
		{
			return num <= P_2;
		}
		return false;
	}

	public static float cWjxNZmTEWsWqeuEeUvXWWLMygnL(float P_0)
	{
		return P_0 * 360f;
	}

	public static float YdWsBskfBknygoZVTFfVsokcugoX(float P_0)
	{
		return P_0 * ((float)Math.PI * 2f);
	}

	public static float bOLcQLaPedaLtFwSnYJamIvIIJgOA(float P_0)
	{
		return P_0 * 400f;
	}

	public static float OtrdKxWeENhmpAeHvgHigWgBsgxc(float P_0)
	{
		return P_0 / 360f;
	}

	public static float fDADMlIitQhnAxKcScIEZAzolrooA(float P_0)
	{
		return P_0 * ((float)Math.PI / 180f);
	}

	public static float dpplMOzLBWjvteyAbNnXevTeKgbIA(float P_0)
	{
		return P_0 / ((float)Math.PI * 2f);
	}

	public static float oLnClxJyPDloASqyRzMFtObjuFhe(float P_0)
	{
		return P_0 * (200f / (float)Math.PI);
	}

	public static float QmowWBvczOwOjeJwHYneayChXymJ(float P_0)
	{
		return P_0 / 400f;
	}

	public static float fUvICXaFsvbYGGfwGJfKsBWQuROFA(float P_0)
	{
		return P_0 * 0.9f;
	}

	public static float mxySEDepEmEBsCaKaLyDkUoWxwXI(float P_0)
	{
		return P_0 * ((float)Math.PI / 200f);
	}

	public static float bCCPiFshRCwEoyRpZMWOCxxRaSOe(float P_0)
	{
		return P_0 * (180f / (float)Math.PI);
	}

	public static float OqFQVnvGyHCpJRlrPqDycaEnGbGl(float P_0, float P_1, float P_2)
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

	public static int OqFQVnvGyHCpJRlrPqDycaEnGbGl(int P_0, int P_1, int P_2)
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

	public static double UzFgBwLZowNfbsoFiTklGhdksSjf(double P_0, double P_1, double P_2)
	{
		return (1.0 - P_2) * P_0 + P_2 * P_1;
	}

	public static float UzFgBwLZowNfbsoFiTklGhdksSjf(float P_0, float P_1, float P_2)
	{
		return (1f - P_2) * P_0 + P_2 * P_1;
	}

	public static byte UzFgBwLZowNfbsoFiTklGhdksSjf(byte P_0, byte P_1, float P_2)
	{
		return (byte)UzFgBwLZowNfbsoFiTklGhdksSjf((int)P_0, (int)P_1, P_2);
	}

	public static float OaKwnBbLvDRekONeOqEutgaQHJFDA(float P_0)
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

	public static float bZLDfYxKQoMxiJdXqyDsBQbOlNeP(float P_0)
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

	public static float KXTvFSXwlFInsOUCwGizaukdMCtC(float P_0, float P_1)
	{
		if (P_1 == 0f)
		{
			return P_0;
		}
		return P_0 % P_1;
	}

	public static float dTSAOGsVApRQxUWeNnXJSMRLYesl(float P_0)
	{
		return KXTvFSXwlFInsOUCwGizaukdMCtC(P_0, (float)Math.PI * 2f);
	}

	public static int SjrsyAGiNXzGKDhHodCaTNFfwrAE(int P_0, int P_1, int P_2)
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

	public static float SjrsyAGiNXzGKDhHodCaTNFfwrAE(float P_0, float P_1, float P_2)
	{
		if (NIYWKOoTvlXaeIxoMZMnBneCeJZH(P_1, P_2))
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

	public static float HGMToHKEIiqjPRkbWHNFnyvSVQci(float P_0, float P_1, float P_2, float P_3, float P_4, float P_5, float P_6)
	{
		return (float)HGMToHKEIiqjPRkbWHNFnyvSVQci((double)P_0, (double)P_1, (double)P_2, (double)P_3, (double)P_4, (double)P_5, (double)P_6);
	}

	public static double HGMToHKEIiqjPRkbWHNFnyvSVQci(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6)
	{
		return P_0 * Math.E - (Math.Pow(P_1 - P_3 / 2.0, 2.0) / (2.0 * Math.Pow(P_5, 2.0)) + Math.Pow(P_2 - P_4 / 2.0, 2.0) / (2.0 * Math.Pow(P_6, 2.0)));
	}
}
