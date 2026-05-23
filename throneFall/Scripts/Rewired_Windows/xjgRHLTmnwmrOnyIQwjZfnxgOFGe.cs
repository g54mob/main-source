using System;

internal static class xjgRHLTmnwmrOnyIQwjZfnxgOFGe
{
	public const float GbFOMrodXqLBialslJAsNrFliCSI = 1E-06f;

	public const float sCkYpTyafXZztuzFVbVlpYfdJbxO = MathF.PI;

	public const float NpEEJJVWcIMMFqgRuoaPLpzovSiQ = MathF.PI * 2f;

	public const float lJVkUGeftZFaoqENVCTBeQVqepPt = MathF.PI / 2f;

	public const float wzTBNnfXAtWoVystkWSfAwbJbJUP = MathF.PI / 4f;

	public unsafe static bool nvMPdJoFZOtQUOTLtZnITxcKmjAG(float P_0, float P_1)
	{
		if (sbGglkJNtoClcIZejhaOEPxbXfWHA(P_0 - P_1))
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

	public static bool sbGglkJNtoClcIZejhaOEPxbXfWHA(float P_0)
	{
		return Math.Abs(P_0) < 1E-06f;
	}

	public static bool WXzuUGgLUAwLLuQmEkHsnoqbWGEm(float P_0)
	{
		return sbGglkJNtoClcIZejhaOEPxbXfWHA(P_0 - 1f);
	}

	public static bool sidoRmLijbfwCzPZwftYDdfDzEibA(float P_0, float P_1, float P_2)
	{
		float num = P_0 - P_1;
		if (0f - P_2 <= num)
		{
			return num <= P_2;
		}
		return false;
	}

	public static float ZvWPipnWjDMxnBjuNbRrOUUSdjAV(float P_0)
	{
		return P_0 * 360f;
	}

	public static float WZFTovsbPkCLJAtghSdsnCoxRqiv(float P_0)
	{
		return P_0 * (MathF.PI * 2f);
	}

	public static float yzACjWsupgQXdJgsdaXQpfpbQxq(float P_0)
	{
		return P_0 * 400f;
	}

	public static float wihRefdzxrjGMlCtrqlTcEJchPn(float P_0)
	{
		return P_0 / 360f;
	}

	public static float dQhTwMfJyChSMIFERdoKGkuaYErd(float P_0)
	{
		return P_0 * (MathF.PI / 180f);
	}

	public static float mDedvoarDCkoCIEAVqtDrlVJBPUoA(float P_0)
	{
		return P_0 / (MathF.PI * 2f);
	}

	public static float OQaSpLwZXrkgjYgHLYYSnmzXmvxx(float P_0)
	{
		return P_0 * (200f / MathF.PI);
	}

	public static float sMUFkvetSaiUyyuwBiKFanlfYhMTb(float P_0)
	{
		return P_0 / 400f;
	}

	public static float fCkcKIptnSscThcwYWmZwJHymXAP(float P_0)
	{
		return P_0 * 0.9f;
	}

	public static float syhUwEbyNnaNqTxxMIcDLMDGYuGH(float P_0)
	{
		return P_0 * (MathF.PI / 200f);
	}

	public static float zmsRmHoIyZFKtDBJlBJedlBEkqvEB(float P_0)
	{
		return P_0 * (180f / MathF.PI);
	}

	public static float mVcxBRoMpSLLbkRtVkdzWRHSeUAr(float P_0, float P_1, float P_2)
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

	public static int kiTJqFvtjoAYacAMYwdcxxlLBIfK(int P_0, int P_1, int P_2)
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

	public static double WjTDToWpVecwoppFOgVAbmmZOsOSA(double P_0, double P_1, double P_2)
	{
		return (1.0 - P_2) * P_0 + P_2 * P_1;
	}

	public static float SMzNELvnibrxwPcxJSLIIZiYPQKd(float P_0, float P_1, float P_2)
	{
		return (1f - P_2) * P_0 + P_2 * P_1;
	}

	public static byte dIFIhAzsWIJVGsYEWvRiszunRjkT(byte P_0, byte P_1, float P_2)
	{
		return (byte)SMzNELvnibrxwPcxJSLIIZiYPQKd((int)P_0, (int)P_1, P_2);
	}

	public static float cVfEAElWvPTaNPgMBrTmCXFZLIhP(float P_0)
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

	public static float aexWDpHhCspwgpSBagPlfybMGoMf(float P_0)
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

	public static float aMkDJdfaiVoXMEgMzxGZZJxnhjYiA(float P_0, float P_1)
	{
		if (P_1 == 0f)
		{
			return P_0;
		}
		return P_0 % P_1;
	}

	public static float OvNKggZbHBGOYMpHhOzyxQEGrpvd(float P_0)
	{
		return aMkDJdfaiVoXMEgMzxGZZJxnhjYiA(P_0, MathF.PI * 2f);
	}

	public static int nQdPzcQXngAsyLqucIlLdiXQOUlo(int P_0, int P_1, int P_2)
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

	public static float gBnHDuBLQvYnlqZMCeXPRoZTAkyqA(float P_0, float P_1, float P_2)
	{
		if (nvMPdJoFZOtQUOTLtZnITxcKmjAG(P_1, P_2))
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

	public static float YXQdWRirnblvLgEiJILJvLmiQWkR(float P_0, float P_1, float P_2, float P_3, float P_4, float P_5, float P_6)
	{
		return (float)GyHGZzjPPZBKQWWmLNzkCZjSpqsM(P_0, P_1, P_2, P_3, P_4, P_5, P_6);
	}

	public static double GyHGZzjPPZBKQWWmLNzkCZjSpqsM(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6)
	{
		return P_0 * Math.E - (Math.Pow(P_1 - P_3 / 2.0, 2.0) / (2.0 * Math.Pow(P_5, 2.0)) + Math.Pow(P_2 - P_4 / 2.0, 2.0) / (2.0 * Math.Pow(P_6, 2.0)));
	}
}
