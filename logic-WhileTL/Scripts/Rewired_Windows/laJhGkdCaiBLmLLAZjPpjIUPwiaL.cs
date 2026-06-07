using System;

internal static class laJhGkdCaiBLmLLAZjPpjIUPwiaL
{
	public const float AOpWVVloabhqdpUsoBAWVHcNEOxk = 1E-06f;

	public const float AyWHVIwQaIjoxEmjxxkiTTwgQgkb = (float)Math.PI;

	public const float LgLAkYfODQsRXKtZnCedEhIYDFURA = (float)Math.PI * 2f;

	public const float oULAmHaZZRlFcaYIniJYtTmHPaWZA = (float)Math.PI / 2f;

	public const float bqbZqdRHIrwGmsQCRUmNFCygDXzF = (float)Math.PI / 4f;

	public unsafe static bool ZamnwYIndGkCTcqBBxfrPTgVuRVd(float P_0, float P_1)
	{
		if (nntnaKAzJxegDOjKkABLlAJrUNQh(P_0 - P_1))
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

	public static bool nntnaKAzJxegDOjKkABLlAJrUNQh(float P_0)
	{
		return Math.Abs(P_0) < 1E-06f;
	}

	public static bool xkWsphDwssSoMVmHJXhDoSUiCNZb(float P_0)
	{
		return nntnaKAzJxegDOjKkABLlAJrUNQh(P_0 - 1f);
	}

	public static bool PyOOIXUohtRjYeEEXzUoHNncwUUL(float P_0, float P_1, float P_2)
	{
		float num = P_0 - P_1;
		if (0f - P_2 <= num)
		{
			return num <= P_2;
		}
		return false;
	}

	public static float glVEyXKgYlEnMWRCpNqNYZyDuajv(float P_0)
	{
		return P_0 * 360f;
	}

	public static float ELqdiqDEXPFJADQFAKRRGkDbbiaqE(float P_0)
	{
		return P_0 * ((float)Math.PI * 2f);
	}

	public static float pVvljHQspKccRAUOaxgcKQMJRcch(float P_0)
	{
		return P_0 * 400f;
	}

	public static float WDLWxGwcimGLIcqosIoLkyrYwOoJ(float P_0)
	{
		return P_0 / 360f;
	}

	public static float btmsjvOejdnIueJsZDgKKNGvipqm(float P_0)
	{
		return P_0 * ((float)Math.PI / 180f);
	}

	public static float lHVfnGcFHhUEPEMAwjJJUpmrgwbdb(float P_0)
	{
		return P_0 / ((float)Math.PI * 2f);
	}

	public static float qWJbexdgkgAIUwjmKnHUpltgekbw(float P_0)
	{
		return P_0 * (200f / (float)Math.PI);
	}

	public static float QBInfVBljjnrBCgiWAmmfqjkpBuwA(float P_0)
	{
		return P_0 / 400f;
	}

	public static float hOHVvTOecMRzmTqkTPwMVBnNAZWv(float P_0)
	{
		return P_0 * 0.9f;
	}

	public static float kfObqRGPpLvJQqIGvbIVgvRDttRJ(float P_0)
	{
		return P_0 * ((float)Math.PI / 200f);
	}

	public static float jnuceRKurpZuOMBTCiZIEAOCseGE(float P_0)
	{
		return P_0 * (180f / (float)Math.PI);
	}

	public static float OAfahxDzocbfhnPtCbWwEincbMSWA(float P_0, float P_1, float P_2)
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

	public static int OAfahxDzocbfhnPtCbWwEincbMSWA(int P_0, int P_1, int P_2)
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

	public static double OejXaIbuXVkFJWJtdnzyCCGhcnNB(double P_0, double P_1, double P_2)
	{
		return (1.0 - P_2) * P_0 + P_2 * P_1;
	}

	public static float OejXaIbuXVkFJWJtdnzyCCGhcnNB(float P_0, float P_1, float P_2)
	{
		return (1f - P_2) * P_0 + P_2 * P_1;
	}

	public static byte OejXaIbuXVkFJWJtdnzyCCGhcnNB(byte P_0, byte P_1, float P_2)
	{
		return (byte)OejXaIbuXVkFJWJtdnzyCCGhcnNB((int)P_0, (int)P_1, P_2);
	}

	public static float SPgKCLBBnmRVYcKoXlmspLTXGPTGA(float P_0)
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

	public static float rulyWSXUYJMUCfkXfcfuFaYVmHum(float P_0)
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

	public static float YFvOqIdVagxlDaCIdAmjgNTgcKfJA(float P_0, float P_1)
	{
		if (P_1 == 0f)
		{
			return P_0;
		}
		return P_0 % P_1;
	}

	public static float piuhsGQCEQccDaJuOLkFQEqOHMgQ(float P_0)
	{
		return YFvOqIdVagxlDaCIdAmjgNTgcKfJA(P_0, (float)Math.PI * 2f);
	}

	public static int GUNBXCaCimFWmBprxYDuHZkqweEwA(int P_0, int P_1, int P_2)
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

	public static float GUNBXCaCimFWmBprxYDuHZkqweEwA(float P_0, float P_1, float P_2)
	{
		if (ZamnwYIndGkCTcqBBxfrPTgVuRVd(P_1, P_2))
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

	public static float HsckvLgXGZBxlbmlPzpFduCHVYgH(float P_0, float P_1, float P_2, float P_3, float P_4, float P_5, float P_6)
	{
		return (float)HsckvLgXGZBxlbmlPzpFduCHVYgH((double)P_0, (double)P_1, (double)P_2, (double)P_3, (double)P_4, (double)P_5, (double)P_6);
	}

	public static double HsckvLgXGZBxlbmlPzpFduCHVYgH(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6)
	{
		return P_0 * Math.E - (Math.Pow(P_1 - P_3 / 2.0, 2.0) / (2.0 * Math.Pow(P_5, 2.0)) + Math.Pow(P_2 - P_4 / 2.0, 2.0) / (2.0 * Math.Pow(P_6, 2.0)));
	}
}
