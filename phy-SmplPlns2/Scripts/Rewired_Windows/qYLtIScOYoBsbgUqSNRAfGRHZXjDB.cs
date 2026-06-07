using System;

internal static class qYLtIScOYoBsbgUqSNRAfGRHZXjDB
{
	public const float ZSaBBiaBfcAXcADgnumpBwlYkrtEb = 1E-06f;

	public const float zPdgMjZFPSfdeFJLIqgSAJQCqGYA = MathF.PI;

	public const float MzzSMSeuIKSJFPfBkNWSeENXXrBK = MathF.PI * 2f;

	public const float mziizXHzTTLRgXAZBMkQVIhZSkcs = MathF.PI / 2f;

	public const float dkwEjiubmtkmLFBxedrezkBaXEhr = MathF.PI / 4f;

	public unsafe static bool gKdWOWHWdYvhMdQHzVaBufBvzlbW(float P_0, float P_1)
	{
		if (tltcDnabXcCvuqGercBRksLKYydQA(P_0 - P_1))
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

	public static bool tltcDnabXcCvuqGercBRksLKYydQA(float P_0)
	{
		return Math.Abs(P_0) < 1E-06f;
	}

	public static bool XNQHfXJPqKOwLDQwInHfEkYOSLrn(float P_0)
	{
		return tltcDnabXcCvuqGercBRksLKYydQA(P_0 - 1f);
	}

	public static bool rUKCGdsDDbceSQxFsfAHcGToXHLOA(float P_0, float P_1, float P_2)
	{
		float num = P_0 - P_1;
		if (0f - P_2 <= num)
		{
			return num <= P_2;
		}
		return false;
	}

	public static float IhrAhmIrLNkAbqDyTUoqpGcfckfGA(float P_0)
	{
		return P_0 * 360f;
	}

	public static float NokqKiBddutTBfQarvUxWqKOuvXT(float P_0)
	{
		return P_0 * (MathF.PI * 2f);
	}

	public static float rzAvNsxXYbAYTGhmyAHWpDTKZNKp(float P_0)
	{
		return P_0 * 400f;
	}

	public static float pWLvgfSsXzczIjYGxiImaEusokaO(float P_0)
	{
		return P_0 / 360f;
	}

	public static float ijIESHjKxGnvQzsDNiKRjvWPzXGFA(float P_0)
	{
		return P_0 * (MathF.PI / 180f);
	}

	public static float jKJyplAcnWsqEpAWHGWUILlmeObr(float P_0)
	{
		return P_0 / (MathF.PI * 2f);
	}

	public static float LXTsEpDzejwAhzTeHtqZSLJmuFAC(float P_0)
	{
		return P_0 * (200f / MathF.PI);
	}

	public static float lWvbPcAiDkEaqViaNfdUGNLdcKzI(float P_0)
	{
		return P_0 / 400f;
	}

	public static float eSVmDJIgTSzkPGZqQPVWZhxTaAlt(float P_0)
	{
		return P_0 * 0.9f;
	}

	public static float vLKmZDOhjrkxyoZfCbpKybppNitI(float P_0)
	{
		return P_0 * (MathF.PI / 200f);
	}

	public static float wWNbIQDgQXAUrobNlKohMJhXBfEW(float P_0)
	{
		return P_0 * (180f / MathF.PI);
	}

	public static float hPUTOHfFWPLlVHtDFAmpBhraXfcA(float P_0, float P_1, float P_2)
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

	public static int nXwIKCAMNkHAcZNWSiFhOnRwgOIV(int P_0, int P_1, int P_2)
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

	public static double JUkErlpMxcqisWQFUinHREGaitvv(double P_0, double P_1, double P_2)
	{
		return (1.0 - P_2) * P_0 + P_2 * P_1;
	}

	public static float LEAVQAGJZbdlgePuHbvPpwbhMYnQ(float P_0, float P_1, float P_2)
	{
		return (1f - P_2) * P_0 + P_2 * P_1;
	}

	public static byte muwcDDCmoMPNKLzQGgLnZLIKgDFl(byte P_0, byte P_1, float P_2)
	{
		return (byte)LEAVQAGJZbdlgePuHbvPpwbhMYnQ((int)P_0, (int)P_1, P_2);
	}

	public static float pGWRzXYTRXmKFgBIFokpnzbwXYAh(float P_0)
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

	public static float juQfFcjweaNfqiYHatVeYxNtyBlX(float P_0)
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

	public static float vVDEosZcQJTSGNbMrrtQscPSmjjg(float P_0, float P_1)
	{
		if (P_1 == 0f)
		{
			return P_0;
		}
		return P_0 % P_1;
	}

	public static float JKeaTlkaxHrUEjbpxthxDCcxNmYuA(float P_0)
	{
		return vVDEosZcQJTSGNbMrrtQscPSmjjg(P_0, MathF.PI * 2f);
	}

	public static int mAIDwznsZegkukNucNIYIMzzyRYM(int P_0, int P_1, int P_2)
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

	public static float zlYUcdqikxlhrwoCWcUKNRzavjNj(float P_0, float P_1, float P_2)
	{
		if (gKdWOWHWdYvhMdQHzVaBufBvzlbW(P_1, P_2))
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

	public static float PkxnZKNWZrixZZWgZPsGMJYJeTXS(float P_0, float P_1, float P_2, float P_3, float P_4, float P_5, float P_6)
	{
		return (float)DlwQBiWNhZAYSzKwTKKdlJJrzPJj(P_0, P_1, P_2, P_3, P_4, P_5, P_6);
	}

	public static double DlwQBiWNhZAYSzKwTKKdlJJrzPJj(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6)
	{
		return P_0 * Math.E - (Math.Pow(P_1 - P_3 / 2.0, 2.0) / (2.0 * Math.Pow(P_5, 2.0)) + Math.Pow(P_2 - P_4 / 2.0, 2.0) / (2.0 * Math.Pow(P_6, 2.0)));
	}
}
