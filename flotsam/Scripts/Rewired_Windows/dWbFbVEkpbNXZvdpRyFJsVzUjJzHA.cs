using System;

internal static class dWbFbVEkpbNXZvdpRyFJsVzUjJzHA
{
	public const float EwEWyjZqGjNiSqShsUmirFLTEvxFA = 1E-06f;

	public const float wpzPAZZAwSCCFoqOSwHnJHtBDwSP = MathF.PI;

	public const float FCVxkXqdzLtRpshYbgXTvvnGRZXl = MathF.PI * 2f;

	public const float vWEnGADgiQUwGmqCQWwBUvJMAauX = MathF.PI / 2f;

	public const float yfEzvJeXIaBpQsuDzlenyrTjCqjC = MathF.PI / 4f;

	public unsafe static bool tpVgrZXQWJXMiSZUclgKrLnihpfV(float P_0, float P_1)
	{
		if (oIPARqmkixiCQPuracZAlWrRgopX(P_0 - P_1))
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

	public static bool oIPARqmkixiCQPuracZAlWrRgopX(float P_0)
	{
		return Math.Abs(P_0) < 1E-06f;
	}

	public static bool URiRGAJNJVGPtcwbTUTwiPuXZJvcA(float P_0)
	{
		return oIPARqmkixiCQPuracZAlWrRgopX(P_0 - 1f);
	}

	public static bool cWurbaysuiFpqzuYtKxIZgbbVoTK(float P_0, float P_1, float P_2)
	{
		float num = P_0 - P_1;
		if (0f - P_2 <= num)
		{
			return num <= P_2;
		}
		return false;
	}

	public static float LkVGdvMeuMAvHHhvYtepocEkVmpy(float P_0)
	{
		return P_0 * 360f;
	}

	public static float KkSgddBrWvZmfKgvijQuVleXfUNm(float P_0)
	{
		return P_0 * (MathF.PI * 2f);
	}

	public static float kwwZsbjxfqwrvjHptiLFuTnFgZGy(float P_0)
	{
		return P_0 * 400f;
	}

	public static float qThaLcFOaeFAaSIPyLOzUlKttigbA(float P_0)
	{
		return P_0 / 360f;
	}

	public static float rKsszKWXCJgOcKKUQxSAkdwMUVMu(float P_0)
	{
		return P_0 * (MathF.PI / 180f);
	}

	public static float egrJcSWQqPFkiODlWCJQDZbzKfsB(float P_0)
	{
		return P_0 / (MathF.PI * 2f);
	}

	public static float CbpTVDHSrgBeFGCSMnJMNbNboYIE(float P_0)
	{
		return P_0 * (200f / MathF.PI);
	}

	public static float qSXOBxUTXzjnQoppGvvJZtxiyThd(float P_0)
	{
		return P_0 / 400f;
	}

	public static float xUzhkOQyiNkFbhSlJTZPOrTOqAlp(float P_0)
	{
		return P_0 * 0.9f;
	}

	public static float kImJuEGpOcSBQXIuHUpDrONymTxP(float P_0)
	{
		return P_0 * (MathF.PI / 200f);
	}

	public static float ltpOUZJQrGfHPJZUosPqPJJAzpQL(float P_0)
	{
		return P_0 * (180f / MathF.PI);
	}

	public static float ybrhIHXjyZcGNggiQWAdqQVmNOjl(float P_0, float P_1, float P_2)
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

	public static int gBSNrFAKqxptMwtBLmPcHZvhpKEW(int P_0, int P_1, int P_2)
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

	public static double MsGjOclZGxTXWvgYNafSUcmbvnlF(double P_0, double P_1, double P_2)
	{
		return (1.0 - P_2) * P_0 + P_2 * P_1;
	}

	public static float YCqHhLhUucbWYgTvaEvQMkZmsUzJb(float P_0, float P_1, float P_2)
	{
		return (1f - P_2) * P_0 + P_2 * P_1;
	}

	public static byte rYOALSIYRPMkswnLBBceWSgXXmFx(byte P_0, byte P_1, float P_2)
	{
		return (byte)YCqHhLhUucbWYgTvaEvQMkZmsUzJb((int)P_0, (int)P_1, P_2);
	}

	public static float mKuokIIFqQIPrXSXEleasrPreHIz(float P_0)
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

	public static float iPyvedwMNnsAAfQQbpLdTqjgsLtR(float P_0)
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

	public static float gxmfpZNjOhyyiiHoEfJOljZPixGA(float P_0, float P_1)
	{
		if (P_1 == 0f)
		{
			return P_0;
		}
		return P_0 % P_1;
	}

	public static float SGGXyuuEWOMroWSauVxaFGKezuMr(float P_0)
	{
		return gxmfpZNjOhyyiiHoEfJOljZPixGA(P_0, MathF.PI * 2f);
	}

	public static int xCsPhkdQctHMGLIlhMXTPPNuVfWl(int P_0, int P_1, int P_2)
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

	public static float uNcthqiTvyOoTRLKBsCNGPYlfFPC(float P_0, float P_1, float P_2)
	{
		if (tpVgrZXQWJXMiSZUclgKrLnihpfV(P_1, P_2))
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

	public static float GMBIuRPiwkwEpqRrOcwHRtaAnTZu(float P_0, float P_1, float P_2, float P_3, float P_4, float P_5, float P_6)
	{
		return (float)MjMCtlIjWSBvmcSdUgQssmrcRfVeA(P_0, P_1, P_2, P_3, P_4, P_5, P_6);
	}

	public static double MjMCtlIjWSBvmcSdUgQssmrcRfVeA(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6)
	{
		return P_0 * Math.E - (Math.Pow(P_1 - P_3 / 2.0, 2.0) / (2.0 * Math.Pow(P_5, 2.0)) + Math.Pow(P_2 - P_4 / 2.0, 2.0) / (2.0 * Math.Pow(P_6, 2.0)));
	}
}
