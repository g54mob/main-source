using System;

internal static class HQVERiRRUOeDMJXHtGXPymqWuaVH
{
	public const float kVebBGuDrEmFVGoXOAdmQoIDDOZiA = 1E-06f;

	public const float WuVkagoIVhWbEGlsialfcXqNHVil = MathF.PI;

	public const float vJtvCqFMKmAAeCUqXHOPwMcGOufAb = MathF.PI * 2f;

	public const float PbsxvfuRJvHXxOeGcrZTrSBODYDB = MathF.PI / 2f;

	public const float OEgMGEJIgVbgicIQLMazeTehsdHsA = MathF.PI / 4f;

	public unsafe static bool BCnStqyKtyvVrmkkSbOIAiooKYPu(float P_0, float P_1)
	{
		if (CIltkRLjXOTlLjMHIrSGOfmZrZBs(P_0 - P_1))
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

	public static bool CIltkRLjXOTlLjMHIrSGOfmZrZBs(float P_0)
	{
		return Math.Abs(P_0) < 1E-06f;
	}

	public static bool sdWrdiekjmmFiWNmxGcokAdFiwBg(float P_0)
	{
		return CIltkRLjXOTlLjMHIrSGOfmZrZBs(P_0 - 1f);
	}

	public static bool CPUZYPFNNFxatFogTuNMmYudQehS(float P_0, float P_1, float P_2)
	{
		float num = P_0 - P_1;
		if (0f - P_2 <= num)
		{
			return num <= P_2;
		}
		return false;
	}

	public static float nCzfnMavXdIYCglNasztaFPakVFJc(float P_0)
	{
		return P_0 * 360f;
	}

	public static float sfsCrOozeWZBqsfFKTLcqHpLdOjw(float P_0)
	{
		return P_0 * (MathF.PI * 2f);
	}

	public static float SbQBoOYNMHMqqZMPTUmJDKqVkGuH(float P_0)
	{
		return P_0 * 400f;
	}

	public static float QYJebZvtBDvLzcchYGXjOdLpdNCbA(float P_0)
	{
		return P_0 / 360f;
	}

	public static float LlUaWdvWrwtltawggKZGVzxIEccV(float P_0)
	{
		return P_0 * (MathF.PI / 180f);
	}

	public static float SHVlqNhxlsdwlimvuuLPwwQnobDT(float P_0)
	{
		return P_0 / (MathF.PI * 2f);
	}

	public static float siJGaioFfXZqOglaeqiKsUmnwXyT(float P_0)
	{
		return P_0 * (200f / MathF.PI);
	}

	public static float OsxpnCbpsGVODEgXwKeNkKssNRBV(float P_0)
	{
		return P_0 / 400f;
	}

	public static float RvJPLtxbPsyrmPRVnWZDjEvWzCZG(float P_0)
	{
		return P_0 * 0.9f;
	}

	public static float ErSBkltFdVwYPzpEdslLGBAggIHI(float P_0)
	{
		return P_0 * (MathF.PI / 200f);
	}

	public static float ZUVdlkfcIvNGAVfcEtziqaYIpGyIA(float P_0)
	{
		return P_0 * (180f / MathF.PI);
	}

	public static float YoPkAeauTsCFSQQQcQRtLQIoGmTP(float P_0, float P_1, float P_2)
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

	public static int QwiQcfvTYwGLUKvttOccmkbLnot(int P_0, int P_1, int P_2)
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

	public static double mfsVSTAInMlaXHOalvnEzQnxCUPX(double P_0, double P_1, double P_2)
	{
		return (1.0 - P_2) * P_0 + P_2 * P_1;
	}

	public static float guCKsahsZHrCVnDVeCkSBXIaknRQ(float P_0, float P_1, float P_2)
	{
		return (1f - P_2) * P_0 + P_2 * P_1;
	}

	public static byte LdeAelxWeobBhgMjtqlqIjdZmHrrA(byte P_0, byte P_1, float P_2)
	{
		return (byte)guCKsahsZHrCVnDVeCkSBXIaknRQ((int)P_0, (int)P_1, P_2);
	}

	public static float WrSvVxfaRpCwkzldyjjuIRQtCaaeb(float P_0)
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

	public static float OlAHSMNBkYJzPDeiNfIzGcggpgTIb(float P_0)
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

	public static float GQNnKIwfQbeJxGQzKSeNQUgNPZPTA(float P_0, float P_1)
	{
		if (P_1 == 0f)
		{
			return P_0;
		}
		return P_0 % P_1;
	}

	public static float sPaCXNJdlpbGdEkIQFmyhsHciJeiB(float P_0)
	{
		return GQNnKIwfQbeJxGQzKSeNQUgNPZPTA(P_0, MathF.PI * 2f);
	}

	public static int XXUbwVOkTOZuXhKTBbTVCeQyoiqLA(int P_0, int P_1, int P_2)
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

	public static float ChCqSNHraPbhSfIxlepTEbQtjGlGb(float P_0, float P_1, float P_2)
	{
		if (BCnStqyKtyvVrmkkSbOIAiooKYPu(P_1, P_2))
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

	public static float ecfPRisCZFvhcSuLinOLyKhCwZdG(float P_0, float P_1, float P_2, float P_3, float P_4, float P_5, float P_6)
	{
		return (float)wTuxSMzXfvGXfozXsVQcTJwiMPxI(P_0, P_1, P_2, P_3, P_4, P_5, P_6);
	}

	public static double wTuxSMzXfvGXfozXsVQcTJwiMPxI(double P_0, double P_1, double P_2, double P_3, double P_4, double P_5, double P_6)
	{
		return P_0 * Math.E - (Math.Pow(P_1 - P_3 / 2.0, 2.0) / (2.0 * Math.Pow(P_5, 2.0)) + Math.Pow(P_2 - P_4 / 2.0, 2.0) / (2.0 * Math.Pow(P_6, 2.0)));
	}
}
