using System;
using System.Globalization;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
internal struct ohzRQrGKZflWBjCqYONwTQYejHY : IEquatable<ohzRQrGKZflWBjCqYONwTQYejHY>, IFormattable
{
	public static readonly int QEWmJHgBHVcNOgjNZFRWREBWgUxe = Marshal.SizeOf(typeof(ohzRQrGKZflWBjCqYONwTQYejHY));

	public static readonly ohzRQrGKZflWBjCqYONwTQYejHY mlHwKYEqjUXizzlBBRzwZZoggsm = default(ohzRQrGKZflWBjCqYONwTQYejHY);

	public static readonly ohzRQrGKZflWBjCqYONwTQYejHY TuQzqPNXJVJZtxuwElIRJyWIoEX = new ohzRQrGKZflWBjCqYONwTQYejHY(1f, 0f);

	public static readonly ohzRQrGKZflWBjCqYONwTQYejHY iBWflnePZFMcLweDeLnZSXvkDoo = new ohzRQrGKZflWBjCqYONwTQYejHY(0f, 1f);

	public static readonly ohzRQrGKZflWBjCqYONwTQYejHY SjUxxWoNpSDZYNcPuerQfoZfPZgC = new ohzRQrGKZflWBjCqYONwTQYejHY(1f, 1f);

	public float aKhnJLPlzQqMJcsXANqZDKcXdkvk;

	public float CfrGUAcJZiBIgrKhIOoWYteVjgS;

	public bool IsNormalized => CkEGbSjYizEFwFszszFTBPspHuob.UAZzaXyOcbJIggCTgTdBYLiCFQDf(aKhnJLPlzQqMJcsXANqZDKcXdkvk * aKhnJLPlzQqMJcsXANqZDKcXdkvk + CfrGUAcJZiBIgrKhIOoWYteVjgS * CfrGUAcJZiBIgrKhIOoWYteVjgS);

	public bool IsZero
	{
		get
		{
			if (aKhnJLPlzQqMJcsXANqZDKcXdkvk == 0f)
			{
				return CfrGUAcJZiBIgrKhIOoWYteVjgS == 0f;
			}
			return false;
		}
	}

	public float this[int index]
	{
		get
		{
			return index switch
			{
				0 => aKhnJLPlzQqMJcsXANqZDKcXdkvk, 
				1 => CfrGUAcJZiBIgrKhIOoWYteVjgS, 
				_ => throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive."), 
			};
		}
		set
		{
			switch (index)
			{
			case 0:
				aKhnJLPlzQqMJcsXANqZDKcXdkvk = value;
				break;
			case 1:
				CfrGUAcJZiBIgrKhIOoWYteVjgS = value;
				break;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
	}

	public ohzRQrGKZflWBjCqYONwTQYejHY(float value)
	{
		aKhnJLPlzQqMJcsXANqZDKcXdkvk = value;
		CfrGUAcJZiBIgrKhIOoWYteVjgS = value;
	}

	public ohzRQrGKZflWBjCqYONwTQYejHY(float x, float y)
	{
		aKhnJLPlzQqMJcsXANqZDKcXdkvk = x;
		CfrGUAcJZiBIgrKhIOoWYteVjgS = y;
	}

	public ohzRQrGKZflWBjCqYONwTQYejHY(float[] values)
	{
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		if (values.Length != 2)
		{
			throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
		}
		aKhnJLPlzQqMJcsXANqZDKcXdkvk = values[0];
		CfrGUAcJZiBIgrKhIOoWYteVjgS = values[1];
	}

	public float ZlqkBHsBFcjMlbgSwtsQjPHHaWR()
	{
		return (float)Math.Sqrt(aKhnJLPlzQqMJcsXANqZDKcXdkvk * aKhnJLPlzQqMJcsXANqZDKcXdkvk + CfrGUAcJZiBIgrKhIOoWYteVjgS * CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public float TphsZXUzRnmBnYLchrnVRtxfUlV()
	{
		return aKhnJLPlzQqMJcsXANqZDKcXdkvk * aKhnJLPlzQqMJcsXANqZDKcXdkvk + CfrGUAcJZiBIgrKhIOoWYteVjgS * CfrGUAcJZiBIgrKhIOoWYteVjgS;
	}

	public void VhLcxXrAYavAbozbLuaegdMOPlO()
	{
		float num = ZlqkBHsBFcjMlbgSwtsQjPHHaWR();
		if (!CkEGbSjYizEFwFszszFTBPspHuob.SXktbuttrkwuTniKXJmbHqxZqAG(num))
		{
			float num2 = 1f / num;
			aKhnJLPlzQqMJcsXANqZDKcXdkvk *= num2;
			CfrGUAcJZiBIgrKhIOoWYteVjgS *= num2;
		}
	}

	public float[] gtemzmTXPVEugpVyNpLyFDbnXhk()
	{
		return new float[2] { aKhnJLPlzQqMJcsXANqZDKcXdkvk, CfrGUAcJZiBIgrKhIOoWYteVjgS };
	}

	public static void fjNiqfPnUABhMqOfzqJBJzslGp(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, out ohzRQrGKZflWBjCqYONwTQYejHY P_2)
	{
		P_2 = new ohzRQrGKZflWBjCqYONwTQYejHY(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk + P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS + P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY fjNiqfPnUABhMqOfzqJBJzslGp(ohzRQrGKZflWBjCqYONwTQYejHY P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk + P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS + P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static void fjNiqfPnUABhMqOfzqJBJzslGp(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref float P_1, out ohzRQrGKZflWBjCqYONwTQYejHY P_2)
	{
		P_2 = new ohzRQrGKZflWBjCqYONwTQYejHY(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk + P_1, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS + P_1);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY fjNiqfPnUABhMqOfzqJBJzslGp(ohzRQrGKZflWBjCqYONwTQYejHY P_0, float P_1)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk + P_1, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS + P_1);
	}

	public static void MkjvRDjfLknCKKrknrWHhRQurFb(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, out ohzRQrGKZflWBjCqYONwTQYejHY P_2)
	{
		P_2 = new ohzRQrGKZflWBjCqYONwTQYejHY(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk - P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS - P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY MkjvRDjfLknCKKrknrWHhRQurFb(ohzRQrGKZflWBjCqYONwTQYejHY P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk - P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS - P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static void MkjvRDjfLknCKKrknrWHhRQurFb(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref float P_1, out ohzRQrGKZflWBjCqYONwTQYejHY P_2)
	{
		P_2 = new ohzRQrGKZflWBjCqYONwTQYejHY(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk - P_1, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS - P_1);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY MkjvRDjfLknCKKrknrWHhRQurFb(ohzRQrGKZflWBjCqYONwTQYejHY P_0, float P_1)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk - P_1, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS - P_1);
	}

	public static void MkjvRDjfLknCKKrknrWHhRQurFb(ref float P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, out ohzRQrGKZflWBjCqYONwTQYejHY P_2)
	{
		P_2 = new ohzRQrGKZflWBjCqYONwTQYejHY(P_0 - P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_0 - P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY MkjvRDjfLknCKKrknrWHhRQurFb(float P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(P_0 - P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_0 - P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static void stXVGjMNgwdddKSrtUAwEAKhmTqz(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, float P_1, out ohzRQrGKZflWBjCqYONwTQYejHY P_2)
	{
		P_2 = new ohzRQrGKZflWBjCqYONwTQYejHY(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk * P_1, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS * P_1);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY stXVGjMNgwdddKSrtUAwEAKhmTqz(ohzRQrGKZflWBjCqYONwTQYejHY P_0, float P_1)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk * P_1, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS * P_1);
	}

	public static void stXVGjMNgwdddKSrtUAwEAKhmTqz(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, out ohzRQrGKZflWBjCqYONwTQYejHY P_2)
	{
		P_2 = new ohzRQrGKZflWBjCqYONwTQYejHY(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk * P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS * P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY stXVGjMNgwdddKSrtUAwEAKhmTqz(ohzRQrGKZflWBjCqYONwTQYejHY P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk * P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS * P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static void cWgaiaIpWIqfYXtPbifdYktMcKH(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, float P_1, out ohzRQrGKZflWBjCqYONwTQYejHY P_2)
	{
		P_2 = new ohzRQrGKZflWBjCqYONwTQYejHY(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk / P_1, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS / P_1);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY cWgaiaIpWIqfYXtPbifdYktMcKH(ohzRQrGKZflWBjCqYONwTQYejHY P_0, float P_1)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk / P_1, P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS / P_1);
	}

	public static void cWgaiaIpWIqfYXtPbifdYktMcKH(float P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, out ohzRQrGKZflWBjCqYONwTQYejHY P_2)
	{
		P_2 = new ohzRQrGKZflWBjCqYONwTQYejHY(P_0 / P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_0 / P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY cWgaiaIpWIqfYXtPbifdYktMcKH(float P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(P_0 / P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_0 / P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static void DsrazolHtJjwIitoKAuBHRyuHHT(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, out ohzRQrGKZflWBjCqYONwTQYejHY P_1)
	{
		P_1 = new ohzRQrGKZflWBjCqYONwTQYejHY(0f - P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk, 0f - P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY DsrazolHtJjwIitoKAuBHRyuHHT(ohzRQrGKZflWBjCqYONwTQYejHY P_0)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(0f - P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk, 0f - P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static void zfjZYpQDBaoDbPAXqcKCgACdXRj(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, ref ohzRQrGKZflWBjCqYONwTQYejHY P_2, float P_3, float P_4, out ohzRQrGKZflWBjCqYONwTQYejHY P_5)
	{
		P_5 = new ohzRQrGKZflWBjCqYONwTQYejHY(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk + P_3 * (P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk - P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk) + P_4 * (P_2.aKhnJLPlzQqMJcsXANqZDKcXdkvk - P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk), P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS + P_3 * (P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS - P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS) + P_4 * (P_2.CfrGUAcJZiBIgrKhIOoWYteVjgS - P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS));
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY zfjZYpQDBaoDbPAXqcKCgACdXRj(ohzRQrGKZflWBjCqYONwTQYejHY P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1, ohzRQrGKZflWBjCqYONwTQYejHY P_2, float P_3, float P_4)
	{
		zfjZYpQDBaoDbPAXqcKCgACdXRj(ref P_0, ref P_1, ref P_2, P_3, P_4, out var result);
		return result;
	}

	public static void hCeslVsamdWtrWFAzXcKGwRWlYQ(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, ref ohzRQrGKZflWBjCqYONwTQYejHY P_2, out ohzRQrGKZflWBjCqYONwTQYejHY P_3)
	{
		float num = P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk;
		num = ((num > P_2.aKhnJLPlzQqMJcsXANqZDKcXdkvk) ? P_2.aKhnJLPlzQqMJcsXANqZDKcXdkvk : num);
		num = ((num < P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk) ? P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk : num);
		float cfrGUAcJZiBIgrKhIOoWYteVjgS = P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS;
		cfrGUAcJZiBIgrKhIOoWYteVjgS = ((cfrGUAcJZiBIgrKhIOoWYteVjgS > P_2.CfrGUAcJZiBIgrKhIOoWYteVjgS) ? P_2.CfrGUAcJZiBIgrKhIOoWYteVjgS : cfrGUAcJZiBIgrKhIOoWYteVjgS);
		cfrGUAcJZiBIgrKhIOoWYteVjgS = ((cfrGUAcJZiBIgrKhIOoWYteVjgS < P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS) ? P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS : cfrGUAcJZiBIgrKhIOoWYteVjgS);
		P_3 = new ohzRQrGKZflWBjCqYONwTQYejHY(num, cfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY hCeslVsamdWtrWFAzXcKGwRWlYQ(ohzRQrGKZflWBjCqYONwTQYejHY P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1, ohzRQrGKZflWBjCqYONwTQYejHY P_2)
	{
		hCeslVsamdWtrWFAzXcKGwRWlYQ(ref P_0, ref P_1, ref P_2, out var result);
		return result;
	}

	public void hJyThCLinIHvbfafgoAWJLtSmvWD()
	{
		aKhnJLPlzQqMJcsXANqZDKcXdkvk = ((aKhnJLPlzQqMJcsXANqZDKcXdkvk < 0f) ? 0f : ((aKhnJLPlzQqMJcsXANqZDKcXdkvk > 1f) ? 1f : aKhnJLPlzQqMJcsXANqZDKcXdkvk));
		CfrGUAcJZiBIgrKhIOoWYteVjgS = ((CfrGUAcJZiBIgrKhIOoWYteVjgS < 0f) ? 0f : ((CfrGUAcJZiBIgrKhIOoWYteVjgS > 1f) ? 1f : CfrGUAcJZiBIgrKhIOoWYteVjgS));
	}

	public static void aCBHpSblgNkDsBfIbhRUcxgqdxj(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, out float P_2)
	{
		float num = P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk - P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk;
		float num2 = P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS - P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS;
		P_2 = (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float aCBHpSblgNkDsBfIbhRUcxgqdxj(ohzRQrGKZflWBjCqYONwTQYejHY P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1)
	{
		float num = P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk - P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk;
		float num2 = P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS - P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static void FqOwmWtrqSLKrIbhEEOKzzcxmSu(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, out float P_2)
	{
		float num = P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk - P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk;
		float num2 = P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS - P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS;
		P_2 = num * num + num2 * num2;
	}

	public static float FqOwmWtrqSLKrIbhEEOKzzcxmSu(ohzRQrGKZflWBjCqYONwTQYejHY P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1)
	{
		float num = P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk - P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk;
		float num2 = P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS - P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS;
		return num * num + num2 * num2;
	}

	public static void HKkGLxpkHXEjtFqilMrAYEyoeHU(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, out float P_2)
	{
		P_2 = P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk * P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk + P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS * P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS;
	}

	public static float HKkGLxpkHXEjtFqilMrAYEyoeHU(ohzRQrGKZflWBjCqYONwTQYejHY P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1)
	{
		return P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk * P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk + P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS * P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS;
	}

	public static void VhLcxXrAYavAbozbLuaegdMOPlO(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, out ohzRQrGKZflWBjCqYONwTQYejHY P_1)
	{
		P_1 = P_0;
		P_1.VhLcxXrAYavAbozbLuaegdMOPlO();
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY VhLcxXrAYavAbozbLuaegdMOPlO(ohzRQrGKZflWBjCqYONwTQYejHY P_0)
	{
		P_0.VhLcxXrAYavAbozbLuaegdMOPlO();
		return P_0;
	}

	public static void nUkwRCCEqSRiBfomCbTByDmHQib(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, float P_2, out ohzRQrGKZflWBjCqYONwTQYejHY P_3)
	{
		P_3.aKhnJLPlzQqMJcsXANqZDKcXdkvk = CkEGbSjYizEFwFszszFTBPspHuob.nUkwRCCEqSRiBfomCbTByDmHQib(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk, P_2);
		P_3.CfrGUAcJZiBIgrKhIOoWYteVjgS = CkEGbSjYizEFwFszszFTBPspHuob.nUkwRCCEqSRiBfomCbTByDmHQib(P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS, P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS, P_2);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY nUkwRCCEqSRiBfomCbTByDmHQib(ohzRQrGKZflWBjCqYONwTQYejHY P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1, float P_2)
	{
		nUkwRCCEqSRiBfomCbTByDmHQib(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void pSjObtuRtbZcOLsNgMHELnxtNdJ(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, float P_2, out ohzRQrGKZflWBjCqYONwTQYejHY P_3)
	{
		P_2 = CkEGbSjYizEFwFszszFTBPspHuob.pSjObtuRtbZcOLsNgMHELnxtNdJ(P_2);
		nUkwRCCEqSRiBfomCbTByDmHQib(ref P_0, ref P_1, P_2, out P_3);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY pSjObtuRtbZcOLsNgMHELnxtNdJ(ohzRQrGKZflWBjCqYONwTQYejHY P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1, float P_2)
	{
		pSjObtuRtbZcOLsNgMHELnxtNdJ(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void zVUgoyEYqXxQhbprekkLSzwDSjHt(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, ref ohzRQrGKZflWBjCqYONwTQYejHY P_2, ref ohzRQrGKZflWBjCqYONwTQYejHY P_3, float P_4, out ohzRQrGKZflWBjCqYONwTQYejHY P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + P_4;
		float num6 = num2 - num;
		P_5.aKhnJLPlzQqMJcsXANqZDKcXdkvk = P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk * num3 + P_2.aKhnJLPlzQqMJcsXANqZDKcXdkvk * num4 + P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk * num5 + P_3.aKhnJLPlzQqMJcsXANqZDKcXdkvk * num6;
		P_5.CfrGUAcJZiBIgrKhIOoWYteVjgS = P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS * num3 + P_2.CfrGUAcJZiBIgrKhIOoWYteVjgS * num4 + P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS * num5 + P_3.CfrGUAcJZiBIgrKhIOoWYteVjgS * num6;
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY zVUgoyEYqXxQhbprekkLSzwDSjHt(ohzRQrGKZflWBjCqYONwTQYejHY P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1, ohzRQrGKZflWBjCqYONwTQYejHY P_2, ohzRQrGKZflWBjCqYONwTQYejHY P_3, float P_4)
	{
		zVUgoyEYqXxQhbprekkLSzwDSjHt(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void qzkEivjoCjHXMCiqevxhqGIaxrCz(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, ref ohzRQrGKZflWBjCqYONwTQYejHY P_2, ref ohzRQrGKZflWBjCqYONwTQYejHY P_3, float P_4, out ohzRQrGKZflWBjCqYONwTQYejHY P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		P_5.aKhnJLPlzQqMJcsXANqZDKcXdkvk = 0.5f * (2f * P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk + (0f - P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk + P_2.aKhnJLPlzQqMJcsXANqZDKcXdkvk) * P_4 + (2f * P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk - 5f * P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk + 4f * P_2.aKhnJLPlzQqMJcsXANqZDKcXdkvk - P_3.aKhnJLPlzQqMJcsXANqZDKcXdkvk) * num + (0f - P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk + 3f * P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk - 3f * P_2.aKhnJLPlzQqMJcsXANqZDKcXdkvk + P_3.aKhnJLPlzQqMJcsXANqZDKcXdkvk) * num2);
		P_5.CfrGUAcJZiBIgrKhIOoWYteVjgS = 0.5f * (2f * P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS + (0f - P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS + P_2.CfrGUAcJZiBIgrKhIOoWYteVjgS) * P_4 + (2f * P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS - 5f * P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS + 4f * P_2.CfrGUAcJZiBIgrKhIOoWYteVjgS - P_3.CfrGUAcJZiBIgrKhIOoWYteVjgS) * num + (0f - P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS + 3f * P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS - 3f * P_2.CfrGUAcJZiBIgrKhIOoWYteVjgS + P_3.CfrGUAcJZiBIgrKhIOoWYteVjgS) * num2);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY qzkEivjoCjHXMCiqevxhqGIaxrCz(ohzRQrGKZflWBjCqYONwTQYejHY P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1, ohzRQrGKZflWBjCqYONwTQYejHY P_2, ohzRQrGKZflWBjCqYONwTQYejHY P_3, float P_4)
	{
		qzkEivjoCjHXMCiqevxhqGIaxrCz(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void oHnWgCjMnJacPOfhraKHeyNmyei(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, out ohzRQrGKZflWBjCqYONwTQYejHY P_2)
	{
		P_2.aKhnJLPlzQqMJcsXANqZDKcXdkvk = ((P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk > P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk) ? P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk : P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk);
		P_2.CfrGUAcJZiBIgrKhIOoWYteVjgS = ((P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS > P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS) ? P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS : P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY oHnWgCjMnJacPOfhraKHeyNmyei(ohzRQrGKZflWBjCqYONwTQYejHY P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1)
	{
		oHnWgCjMnJacPOfhraKHeyNmyei(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void xrKtegjBPLvaovjTjtBzOPtWETk(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, out ohzRQrGKZflWBjCqYONwTQYejHY P_2)
	{
		P_2.aKhnJLPlzQqMJcsXANqZDKcXdkvk = ((P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk < P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk) ? P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk : P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk);
		P_2.CfrGUAcJZiBIgrKhIOoWYteVjgS = ((P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS < P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS) ? P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS : P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY xrKtegjBPLvaovjTjtBzOPtWETk(ohzRQrGKZflWBjCqYONwTQYejHY P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1)
	{
		xrKtegjBPLvaovjTjtBzOPtWETk(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void VxxANSxvwcNjOebEsVYxxEsHLJZ(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0, ref ohzRQrGKZflWBjCqYONwTQYejHY P_1, out ohzRQrGKZflWBjCqYONwTQYejHY P_2)
	{
		float num = P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk * P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk + P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS * P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS;
		P_2.aKhnJLPlzQqMJcsXANqZDKcXdkvk = P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk - 2f * num * P_1.aKhnJLPlzQqMJcsXANqZDKcXdkvk;
		P_2.CfrGUAcJZiBIgrKhIOoWYteVjgS = P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS - 2f * num * P_1.CfrGUAcJZiBIgrKhIOoWYteVjgS;
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY VxxANSxvwcNjOebEsVYxxEsHLJZ(ohzRQrGKZflWBjCqYONwTQYejHY P_0, ohzRQrGKZflWBjCqYONwTQYejHY P_1)
	{
		VxxANSxvwcNjOebEsVYxxEsHLJZ(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void SEDabRnGlYcUgppyJoIxNwscAhR(ohzRQrGKZflWBjCqYONwTQYejHY[] P_0, params ohzRQrGKZflWBjCqYONwTQYejHY[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.Length < P_1.Length)
		{
			throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
		}
		for (int i = 0; i < P_1.Length; i++)
		{
			ohzRQrGKZflWBjCqYONwTQYejHY ohzRQrGKZflWBjCqYONwTQYejHY2 = P_1[i];
			for (int j = 0; j < i; j++)
			{
				ohzRQrGKZflWBjCqYONwTQYejHY2 -= HKkGLxpkHXEjtFqilMrAYEyoeHU(P_0[j], ohzRQrGKZflWBjCqYONwTQYejHY2) / HKkGLxpkHXEjtFqilMrAYEyoeHU(P_0[j], P_0[j]) * P_0[j];
			}
			P_0[i] = ohzRQrGKZflWBjCqYONwTQYejHY2;
		}
	}

	public static void FCwaRLeGNYWdiUUTxqEtciKJeVYj(ohzRQrGKZflWBjCqYONwTQYejHY[] P_0, params ohzRQrGKZflWBjCqYONwTQYejHY[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.Length < P_1.Length)
		{
			throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
		}
		for (int i = 0; i < P_1.Length; i++)
		{
			ohzRQrGKZflWBjCqYONwTQYejHY ohzRQrGKZflWBjCqYONwTQYejHY2 = P_1[i];
			for (int j = 0; j < i; j++)
			{
				ohzRQrGKZflWBjCqYONwTQYejHY2 -= HKkGLxpkHXEjtFqilMrAYEyoeHU(P_0[j], ohzRQrGKZflWBjCqYONwTQYejHY2) * P_0[j];
			}
			ohzRQrGKZflWBjCqYONwTQYejHY2.VhLcxXrAYavAbozbLuaegdMOPlO();
			P_0[i] = ohzRQrGKZflWBjCqYONwTQYejHY2;
		}
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY operator +(ohzRQrGKZflWBjCqYONwTQYejHY left, ohzRQrGKZflWBjCqYONwTQYejHY right)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(left.aKhnJLPlzQqMJcsXANqZDKcXdkvk + right.aKhnJLPlzQqMJcsXANqZDKcXdkvk, left.CfrGUAcJZiBIgrKhIOoWYteVjgS + right.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY operator *(ohzRQrGKZflWBjCqYONwTQYejHY left, ohzRQrGKZflWBjCqYONwTQYejHY right)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(left.aKhnJLPlzQqMJcsXANqZDKcXdkvk * right.aKhnJLPlzQqMJcsXANqZDKcXdkvk, left.CfrGUAcJZiBIgrKhIOoWYteVjgS * right.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY operator +(ohzRQrGKZflWBjCqYONwTQYejHY value)
	{
		return value;
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY operator -(ohzRQrGKZflWBjCqYONwTQYejHY left, ohzRQrGKZflWBjCqYONwTQYejHY right)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(left.aKhnJLPlzQqMJcsXANqZDKcXdkvk - right.aKhnJLPlzQqMJcsXANqZDKcXdkvk, left.CfrGUAcJZiBIgrKhIOoWYteVjgS - right.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY operator -(ohzRQrGKZflWBjCqYONwTQYejHY value)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(0f - value.aKhnJLPlzQqMJcsXANqZDKcXdkvk, 0f - value.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY operator *(float scale, ohzRQrGKZflWBjCqYONwTQYejHY value)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(value.aKhnJLPlzQqMJcsXANqZDKcXdkvk * scale, value.CfrGUAcJZiBIgrKhIOoWYteVjgS * scale);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY operator *(ohzRQrGKZflWBjCqYONwTQYejHY value, float scale)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(value.aKhnJLPlzQqMJcsXANqZDKcXdkvk * scale, value.CfrGUAcJZiBIgrKhIOoWYteVjgS * scale);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY operator /(ohzRQrGKZflWBjCqYONwTQYejHY value, float scale)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(value.aKhnJLPlzQqMJcsXANqZDKcXdkvk / scale, value.CfrGUAcJZiBIgrKhIOoWYteVjgS / scale);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY operator /(float scale, ohzRQrGKZflWBjCqYONwTQYejHY value)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(scale / value.aKhnJLPlzQqMJcsXANqZDKcXdkvk, scale / value.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY operator /(ohzRQrGKZflWBjCqYONwTQYejHY value, ohzRQrGKZflWBjCqYONwTQYejHY scale)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(value.aKhnJLPlzQqMJcsXANqZDKcXdkvk / scale.aKhnJLPlzQqMJcsXANqZDKcXdkvk, value.CfrGUAcJZiBIgrKhIOoWYteVjgS / scale.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY operator +(ohzRQrGKZflWBjCqYONwTQYejHY value, float scalar)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(value.aKhnJLPlzQqMJcsXANqZDKcXdkvk + scalar, value.CfrGUAcJZiBIgrKhIOoWYteVjgS + scalar);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY operator +(float scalar, ohzRQrGKZflWBjCqYONwTQYejHY value)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(scalar + value.aKhnJLPlzQqMJcsXANqZDKcXdkvk, scalar + value.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY operator -(ohzRQrGKZflWBjCqYONwTQYejHY value, float scalar)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(value.aKhnJLPlzQqMJcsXANqZDKcXdkvk - scalar, value.CfrGUAcJZiBIgrKhIOoWYteVjgS - scalar);
	}

	public static ohzRQrGKZflWBjCqYONwTQYejHY operator -(float scalar, ohzRQrGKZflWBjCqYONwTQYejHY value)
	{
		return new ohzRQrGKZflWBjCqYONwTQYejHY(scalar - value.aKhnJLPlzQqMJcsXANqZDKcXdkvk, scalar - value.CfrGUAcJZiBIgrKhIOoWYteVjgS);
	}

	public static bool operator ==(ohzRQrGKZflWBjCqYONwTQYejHY left, ohzRQrGKZflWBjCqYONwTQYejHY right)
	{
		return left.sDUAvZTXlEIwugPidIgHPcnkQFr(ref right);
	}

	public static bool operator !=(ohzRQrGKZflWBjCqYONwTQYejHY left, ohzRQrGKZflWBjCqYONwTQYejHY right)
	{
		return !left.sDUAvZTXlEIwugPidIgHPcnkQFr(ref right);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", new object[2] { aKhnJLPlzQqMJcsXANqZDKcXdkvk, CfrGUAcJZiBIgrKhIOoWYteVjgS });
	}

	public string jbeeBfpyRHgFdsemtguxfVuwPCaA(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", new object[2]
		{
			aKhnJLPlzQqMJcsXANqZDKcXdkvk.ToString(P_0, CultureInfo.CurrentCulture),
			CfrGUAcJZiBIgrKhIOoWYteVjgS.ToString(P_0, CultureInfo.CurrentCulture)
		});
	}

	public string jbeeBfpyRHgFdsemtguxfVuwPCaA(IFormatProvider P_0)
	{
		return string.Format(P_0, "X:{0} Y:{1}", new object[2] { aKhnJLPlzQqMJcsXANqZDKcXdkvk, CfrGUAcJZiBIgrKhIOoWYteVjgS });
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			jbeeBfpyRHgFdsemtguxfVuwPCaA(formatProvider);
		}
		return string.Format(formatProvider, "X:{0} Y:{1}", new object[2]
		{
			aKhnJLPlzQqMJcsXANqZDKcXdkvk.ToString(format, formatProvider),
			CfrGUAcJZiBIgrKhIOoWYteVjgS.ToString(format, formatProvider)
		});
	}

	public override int GetHashCode()
	{
		return (aKhnJLPlzQqMJcsXANqZDKcXdkvk.GetHashCode() * 397) ^ CfrGUAcJZiBIgrKhIOoWYteVjgS.GetHashCode();
	}

	public bool sDUAvZTXlEIwugPidIgHPcnkQFr(ref ohzRQrGKZflWBjCqYONwTQYejHY P_0)
	{
		if (CkEGbSjYizEFwFszszFTBPspHuob.mlfTtstFxHQkEDuBkHVDxIjrIgH(P_0.aKhnJLPlzQqMJcsXANqZDKcXdkvk, aKhnJLPlzQqMJcsXANqZDKcXdkvk))
		{
			return CkEGbSjYizEFwFszszFTBPspHuob.mlfTtstFxHQkEDuBkHVDxIjrIgH(P_0.CfrGUAcJZiBIgrKhIOoWYteVjgS, CfrGUAcJZiBIgrKhIOoWYteVjgS);
		}
		return false;
	}

	public bool Equals(ohzRQrGKZflWBjCqYONwTQYejHY other)
	{
		return sDUAvZTXlEIwugPidIgHPcnkQFr(ref other);
	}

	public override bool Equals(object value)
	{
		if (!(value is ohzRQrGKZflWBjCqYONwTQYejHY ohzRQrGKZflWBjCqYONwTQYejHY2))
		{
			return false;
		}
		return sDUAvZTXlEIwugPidIgHPcnkQFr(ref ohzRQrGKZflWBjCqYONwTQYejHY2);
	}
}
