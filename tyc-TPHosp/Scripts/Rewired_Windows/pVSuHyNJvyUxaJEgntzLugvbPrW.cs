using System;
using System.Globalization;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
internal struct pVSuHyNJvyUxaJEgntzLugvbPrW : IEquatable<pVSuHyNJvyUxaJEgntzLugvbPrW>, IFormattable
{
	public static readonly int PLbvaIrVdOXHhDjPmAjbjnwZjAt = Marshal.SizeOf(typeof(pVSuHyNJvyUxaJEgntzLugvbPrW));

	public static readonly pVSuHyNJvyUxaJEgntzLugvbPrW dxogOPZTjJkMCZRqwHORwFHluia = default(pVSuHyNJvyUxaJEgntzLugvbPrW);

	public static readonly pVSuHyNJvyUxaJEgntzLugvbPrW AbtSTIKBlIDcARHkhAaikXnBWwP = new pVSuHyNJvyUxaJEgntzLugvbPrW(1f, 0f);

	public static readonly pVSuHyNJvyUxaJEgntzLugvbPrW rodpRepWrIdWqKzRFVfarkYjIRy = new pVSuHyNJvyUxaJEgntzLugvbPrW(0f, 1f);

	public static readonly pVSuHyNJvyUxaJEgntzLugvbPrW JwlZfDlFvBTclfaJFHVfDVagJla = new pVSuHyNJvyUxaJEgntzLugvbPrW(1f, 1f);

	public float lSOdwKYaTJSJyAWJnADwkSPKwkp;

	public float ZqYMkLdonrbLPbHprxydzkIAizSD;

	public bool IsNormalized => ZvnBPrLKFiDHPIhVHtaZiLpeksK.VhsEKWlHKmAJFWQLTNhsxgHHdSH(lSOdwKYaTJSJyAWJnADwkSPKwkp * lSOdwKYaTJSJyAWJnADwkSPKwkp + ZqYMkLdonrbLPbHprxydzkIAizSD * ZqYMkLdonrbLPbHprxydzkIAizSD);

	public bool IsZero
	{
		get
		{
			if (lSOdwKYaTJSJyAWJnADwkSPKwkp == 0f)
			{
				return ZqYMkLdonrbLPbHprxydzkIAizSD == 0f;
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
				0 => lSOdwKYaTJSJyAWJnADwkSPKwkp, 
				1 => ZqYMkLdonrbLPbHprxydzkIAizSD, 
				_ => throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive."), 
			};
		}
		set
		{
			switch (index)
			{
			case 0:
				lSOdwKYaTJSJyAWJnADwkSPKwkp = value;
				break;
			case 1:
				ZqYMkLdonrbLPbHprxydzkIAizSD = value;
				break;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
	}

	public pVSuHyNJvyUxaJEgntzLugvbPrW(float value)
	{
		lSOdwKYaTJSJyAWJnADwkSPKwkp = value;
		ZqYMkLdonrbLPbHprxydzkIAizSD = value;
	}

	public pVSuHyNJvyUxaJEgntzLugvbPrW(float x, float y)
	{
		lSOdwKYaTJSJyAWJnADwkSPKwkp = x;
		ZqYMkLdonrbLPbHprxydzkIAizSD = y;
	}

	public pVSuHyNJvyUxaJEgntzLugvbPrW(float[] values)
	{
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		if (values.Length != 2)
		{
			throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
		}
		lSOdwKYaTJSJyAWJnADwkSPKwkp = values[0];
		ZqYMkLdonrbLPbHprxydzkIAizSD = values[1];
	}

	public float KyBrWGhjlptUSFhGBWQdYDaYhUF()
	{
		return (float)Math.Sqrt(lSOdwKYaTJSJyAWJnADwkSPKwkp * lSOdwKYaTJSJyAWJnADwkSPKwkp + ZqYMkLdonrbLPbHprxydzkIAizSD * ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public float QcYyGWDjTclkOenFUuHmaQAakWT()
	{
		return lSOdwKYaTJSJyAWJnADwkSPKwkp * lSOdwKYaTJSJyAWJnADwkSPKwkp + ZqYMkLdonrbLPbHprxydzkIAizSD * ZqYMkLdonrbLPbHprxydzkIAizSD;
	}

	public void WIOZWgQagBlrnKFpQZCPLMEFqTd()
	{
		float num = KyBrWGhjlptUSFhGBWQdYDaYhUF();
		if (!ZvnBPrLKFiDHPIhVHtaZiLpeksK.JJNPRbqNhtcUqFEqkMAGyJOGMFQ(num))
		{
			float num2 = 1f / num;
			lSOdwKYaTJSJyAWJnADwkSPKwkp *= num2;
			ZqYMkLdonrbLPbHprxydzkIAizSD *= num2;
		}
	}

	public float[] hHVPBjOphUChFRzgeVtTckWyROi()
	{
		return new float[2] { lSOdwKYaTJSJyAWJnADwkSPKwkp, ZqYMkLdonrbLPbHprxydzkIAizSD };
	}

	public static void iWIBGnFoTZKBQXySUtUicuMvsElb(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, out pVSuHyNJvyUxaJEgntzLugvbPrW P_2)
	{
		P_2 = new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp + P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD + P_1.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW iWIBGnFoTZKBQXySUtUicuMvsElb(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp + P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD + P_1.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static void iWIBGnFoTZKBQXySUtUicuMvsElb(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref float P_1, out pVSuHyNJvyUxaJEgntzLugvbPrW P_2)
	{
		P_2 = new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp + P_1, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD + P_1);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW iWIBGnFoTZKBQXySUtUicuMvsElb(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, float P_1)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp + P_1, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD + P_1);
	}

	public static void VVOnvQwjVhCudcaXKicwUdLfDLj(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, out pVSuHyNJvyUxaJEgntzLugvbPrW P_2)
	{
		P_2 = new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp - P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD - P_1.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW VVOnvQwjVhCudcaXKicwUdLfDLj(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp - P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD - P_1.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static void VVOnvQwjVhCudcaXKicwUdLfDLj(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref float P_1, out pVSuHyNJvyUxaJEgntzLugvbPrW P_2)
	{
		P_2 = new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp - P_1, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD - P_1);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW VVOnvQwjVhCudcaXKicwUdLfDLj(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, float P_1)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp - P_1, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD - P_1);
	}

	public static void VVOnvQwjVhCudcaXKicwUdLfDLj(ref float P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, out pVSuHyNJvyUxaJEgntzLugvbPrW P_2)
	{
		P_2 = new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0 - P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_0 - P_1.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW VVOnvQwjVhCudcaXKicwUdLfDLj(float P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0 - P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_0 - P_1.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static void tZyydgNjCpvoMaZpIynVhhpmPbw(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, float P_1, out pVSuHyNJvyUxaJEgntzLugvbPrW P_2)
	{
		P_2 = new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp * P_1, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD * P_1);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW tZyydgNjCpvoMaZpIynVhhpmPbw(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, float P_1)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp * P_1, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD * P_1);
	}

	public static void tZyydgNjCpvoMaZpIynVhhpmPbw(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, out pVSuHyNJvyUxaJEgntzLugvbPrW P_2)
	{
		P_2 = new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp * P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD * P_1.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW tZyydgNjCpvoMaZpIynVhhpmPbw(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp * P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD * P_1.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static void bGLjInPusHJnxprFWUJQhIOHeIDb(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, float P_1, out pVSuHyNJvyUxaJEgntzLugvbPrW P_2)
	{
		P_2 = new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp / P_1, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD / P_1);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW bGLjInPusHJnxprFWUJQhIOHeIDb(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, float P_1)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp / P_1, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD / P_1);
	}

	public static void bGLjInPusHJnxprFWUJQhIOHeIDb(float P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, out pVSuHyNJvyUxaJEgntzLugvbPrW P_2)
	{
		P_2 = new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0 / P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_0 / P_1.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW bGLjInPusHJnxprFWUJQhIOHeIDb(float P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0 / P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_0 / P_1.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static void EcUjZdiCXAqqhGHsbvSyeeJryHV(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, out pVSuHyNJvyUxaJEgntzLugvbPrW P_1)
	{
		P_1 = new pVSuHyNJvyUxaJEgntzLugvbPrW(0f - P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp, 0f - P_0.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW EcUjZdiCXAqqhGHsbvSyeeJryHV(pVSuHyNJvyUxaJEgntzLugvbPrW P_0)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(0f - P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp, 0f - P_0.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static void ksOmviTUtjKeCpSJLBspDDdkwRp(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_2, float P_3, float P_4, out pVSuHyNJvyUxaJEgntzLugvbPrW P_5)
	{
		P_5 = new pVSuHyNJvyUxaJEgntzLugvbPrW(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp + P_3 * (P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp - P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp) + P_4 * (P_2.lSOdwKYaTJSJyAWJnADwkSPKwkp - P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp), P_0.ZqYMkLdonrbLPbHprxydzkIAizSD + P_3 * (P_1.ZqYMkLdonrbLPbHprxydzkIAizSD - P_0.ZqYMkLdonrbLPbHprxydzkIAizSD) + P_4 * (P_2.ZqYMkLdonrbLPbHprxydzkIAizSD - P_0.ZqYMkLdonrbLPbHprxydzkIAizSD));
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW ksOmviTUtjKeCpSJLBspDDdkwRp(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1, pVSuHyNJvyUxaJEgntzLugvbPrW P_2, float P_3, float P_4)
	{
		ksOmviTUtjKeCpSJLBspDDdkwRp(ref P_0, ref P_1, ref P_2, P_3, P_4, out var result);
		return result;
	}

	public static void krPBIAlLEsxcAqhWYOwtrZcVMJY(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_2, out pVSuHyNJvyUxaJEgntzLugvbPrW P_3)
	{
		float num = P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp;
		num = ((num > P_2.lSOdwKYaTJSJyAWJnADwkSPKwkp) ? P_2.lSOdwKYaTJSJyAWJnADwkSPKwkp : num);
		num = ((num < P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp) ? P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp : num);
		float zqYMkLdonrbLPbHprxydzkIAizSD = P_0.ZqYMkLdonrbLPbHprxydzkIAizSD;
		zqYMkLdonrbLPbHprxydzkIAizSD = ((zqYMkLdonrbLPbHprxydzkIAizSD > P_2.ZqYMkLdonrbLPbHprxydzkIAizSD) ? P_2.ZqYMkLdonrbLPbHprxydzkIAizSD : zqYMkLdonrbLPbHprxydzkIAizSD);
		zqYMkLdonrbLPbHprxydzkIAizSD = ((zqYMkLdonrbLPbHprxydzkIAizSD < P_1.ZqYMkLdonrbLPbHprxydzkIAizSD) ? P_1.ZqYMkLdonrbLPbHprxydzkIAizSD : zqYMkLdonrbLPbHprxydzkIAizSD);
		P_3 = new pVSuHyNJvyUxaJEgntzLugvbPrW(num, zqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW krPBIAlLEsxcAqhWYOwtrZcVMJY(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1, pVSuHyNJvyUxaJEgntzLugvbPrW P_2)
	{
		krPBIAlLEsxcAqhWYOwtrZcVMJY(ref P_0, ref P_1, ref P_2, out var result);
		return result;
	}

	public void kqFJrNWZUVzBYAteJultuGvLrwK()
	{
		lSOdwKYaTJSJyAWJnADwkSPKwkp = ((lSOdwKYaTJSJyAWJnADwkSPKwkp < 0f) ? 0f : ((lSOdwKYaTJSJyAWJnADwkSPKwkp > 1f) ? 1f : lSOdwKYaTJSJyAWJnADwkSPKwkp));
		ZqYMkLdonrbLPbHprxydzkIAizSD = ((ZqYMkLdonrbLPbHprxydzkIAizSD < 0f) ? 0f : ((ZqYMkLdonrbLPbHprxydzkIAizSD > 1f) ? 1f : ZqYMkLdonrbLPbHprxydzkIAizSD));
	}

	public static void tQkTfZqMREeuDctIWrJveLZhcfdq(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, out float P_2)
	{
		float num = P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp - P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp;
		float num2 = P_0.ZqYMkLdonrbLPbHprxydzkIAizSD - P_1.ZqYMkLdonrbLPbHprxydzkIAizSD;
		P_2 = (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float tQkTfZqMREeuDctIWrJveLZhcfdq(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1)
	{
		float num = P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp - P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp;
		float num2 = P_0.ZqYMkLdonrbLPbHprxydzkIAizSD - P_1.ZqYMkLdonrbLPbHprxydzkIAizSD;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static void EBjRANuoYBCRACsjjNmxCEVmcMsY(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, out float P_2)
	{
		float num = P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp - P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp;
		float num2 = P_0.ZqYMkLdonrbLPbHprxydzkIAizSD - P_1.ZqYMkLdonrbLPbHprxydzkIAizSD;
		P_2 = num * num + num2 * num2;
	}

	public static float EBjRANuoYBCRACsjjNmxCEVmcMsY(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1)
	{
		float num = P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp - P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp;
		float num2 = P_0.ZqYMkLdonrbLPbHprxydzkIAizSD - P_1.ZqYMkLdonrbLPbHprxydzkIAizSD;
		return num * num + num2 * num2;
	}

	public static void SfHUoyisOWeMIdmuGLgltMjrmwZ(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, out float P_2)
	{
		P_2 = P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp * P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp + P_0.ZqYMkLdonrbLPbHprxydzkIAizSD * P_1.ZqYMkLdonrbLPbHprxydzkIAizSD;
	}

	public static float SfHUoyisOWeMIdmuGLgltMjrmwZ(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1)
	{
		return P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp * P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp + P_0.ZqYMkLdonrbLPbHprxydzkIAizSD * P_1.ZqYMkLdonrbLPbHprxydzkIAizSD;
	}

	public static void WIOZWgQagBlrnKFpQZCPLMEFqTd(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, out pVSuHyNJvyUxaJEgntzLugvbPrW P_1)
	{
		P_1 = P_0;
		P_1.WIOZWgQagBlrnKFpQZCPLMEFqTd();
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW WIOZWgQagBlrnKFpQZCPLMEFqTd(pVSuHyNJvyUxaJEgntzLugvbPrW P_0)
	{
		P_0.WIOZWgQagBlrnKFpQZCPLMEFqTd();
		return P_0;
	}

	public static void mbZbkPHgUBubgHFynbIeTjFMFiv(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, float P_2, out pVSuHyNJvyUxaJEgntzLugvbPrW P_3)
	{
		P_3.lSOdwKYaTJSJyAWJnADwkSPKwkp = ZvnBPrLKFiDHPIhVHtaZiLpeksK.mbZbkPHgUBubgHFynbIeTjFMFiv(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_2);
		P_3.ZqYMkLdonrbLPbHprxydzkIAizSD = ZvnBPrLKFiDHPIhVHtaZiLpeksK.mbZbkPHgUBubgHFynbIeTjFMFiv(P_0.ZqYMkLdonrbLPbHprxydzkIAizSD, P_1.ZqYMkLdonrbLPbHprxydzkIAizSD, P_2);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW mbZbkPHgUBubgHFynbIeTjFMFiv(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1, float P_2)
	{
		mbZbkPHgUBubgHFynbIeTjFMFiv(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void yLCLswbeVcKFjplBTqczeWQeEZN(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, float P_2, out pVSuHyNJvyUxaJEgntzLugvbPrW P_3)
	{
		P_2 = ZvnBPrLKFiDHPIhVHtaZiLpeksK.yLCLswbeVcKFjplBTqczeWQeEZN(P_2);
		mbZbkPHgUBubgHFynbIeTjFMFiv(ref P_0, ref P_1, P_2, out P_3);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW yLCLswbeVcKFjplBTqczeWQeEZN(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1, float P_2)
	{
		yLCLswbeVcKFjplBTqczeWQeEZN(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void kZxOdnXGpOCIOBjlVUHcGENAznL(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_2, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_3, float P_4, out pVSuHyNJvyUxaJEgntzLugvbPrW P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + P_4;
		float num6 = num2 - num;
		P_5.lSOdwKYaTJSJyAWJnADwkSPKwkp = P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp * num3 + P_2.lSOdwKYaTJSJyAWJnADwkSPKwkp * num4 + P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp * num5 + P_3.lSOdwKYaTJSJyAWJnADwkSPKwkp * num6;
		P_5.ZqYMkLdonrbLPbHprxydzkIAizSD = P_0.ZqYMkLdonrbLPbHprxydzkIAizSD * num3 + P_2.ZqYMkLdonrbLPbHprxydzkIAizSD * num4 + P_1.ZqYMkLdonrbLPbHprxydzkIAizSD * num5 + P_3.ZqYMkLdonrbLPbHprxydzkIAizSD * num6;
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW kZxOdnXGpOCIOBjlVUHcGENAznL(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1, pVSuHyNJvyUxaJEgntzLugvbPrW P_2, pVSuHyNJvyUxaJEgntzLugvbPrW P_3, float P_4)
	{
		kZxOdnXGpOCIOBjlVUHcGENAznL(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void jKBKJkxgnyFllQsyCROUntkevrL(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_2, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_3, float P_4, out pVSuHyNJvyUxaJEgntzLugvbPrW P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		P_5.lSOdwKYaTJSJyAWJnADwkSPKwkp = 0.5f * (2f * P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp + (0f - P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp + P_2.lSOdwKYaTJSJyAWJnADwkSPKwkp) * P_4 + (2f * P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp - 5f * P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp + 4f * P_2.lSOdwKYaTJSJyAWJnADwkSPKwkp - P_3.lSOdwKYaTJSJyAWJnADwkSPKwkp) * num + (0f - P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp + 3f * P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp - 3f * P_2.lSOdwKYaTJSJyAWJnADwkSPKwkp + P_3.lSOdwKYaTJSJyAWJnADwkSPKwkp) * num2);
		P_5.ZqYMkLdonrbLPbHprxydzkIAizSD = 0.5f * (2f * P_1.ZqYMkLdonrbLPbHprxydzkIAizSD + (0f - P_0.ZqYMkLdonrbLPbHprxydzkIAizSD + P_2.ZqYMkLdonrbLPbHprxydzkIAizSD) * P_4 + (2f * P_0.ZqYMkLdonrbLPbHprxydzkIAizSD - 5f * P_1.ZqYMkLdonrbLPbHprxydzkIAizSD + 4f * P_2.ZqYMkLdonrbLPbHprxydzkIAizSD - P_3.ZqYMkLdonrbLPbHprxydzkIAizSD) * num + (0f - P_0.ZqYMkLdonrbLPbHprxydzkIAizSD + 3f * P_1.ZqYMkLdonrbLPbHprxydzkIAizSD - 3f * P_2.ZqYMkLdonrbLPbHprxydzkIAizSD + P_3.ZqYMkLdonrbLPbHprxydzkIAizSD) * num2);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW jKBKJkxgnyFllQsyCROUntkevrL(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1, pVSuHyNJvyUxaJEgntzLugvbPrW P_2, pVSuHyNJvyUxaJEgntzLugvbPrW P_3, float P_4)
	{
		jKBKJkxgnyFllQsyCROUntkevrL(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void hnGUyZiHsQmIukppEkdsHCepoqm(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, out pVSuHyNJvyUxaJEgntzLugvbPrW P_2)
	{
		P_2.lSOdwKYaTJSJyAWJnADwkSPKwkp = ((P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp > P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp) ? P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp : P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp);
		P_2.ZqYMkLdonrbLPbHprxydzkIAizSD = ((P_0.ZqYMkLdonrbLPbHprxydzkIAizSD > P_1.ZqYMkLdonrbLPbHprxydzkIAizSD) ? P_0.ZqYMkLdonrbLPbHprxydzkIAizSD : P_1.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW hnGUyZiHsQmIukppEkdsHCepoqm(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1)
	{
		hnGUyZiHsQmIukppEkdsHCepoqm(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void gNxfBfccpKkhHfPnQVJITfoTXIgR(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, out pVSuHyNJvyUxaJEgntzLugvbPrW P_2)
	{
		P_2.lSOdwKYaTJSJyAWJnADwkSPKwkp = ((P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp < P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp) ? P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp : P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp);
		P_2.ZqYMkLdonrbLPbHprxydzkIAizSD = ((P_0.ZqYMkLdonrbLPbHprxydzkIAizSD < P_1.ZqYMkLdonrbLPbHprxydzkIAizSD) ? P_0.ZqYMkLdonrbLPbHprxydzkIAizSD : P_1.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW gNxfBfccpKkhHfPnQVJITfoTXIgR(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1)
	{
		gNxfBfccpKkhHfPnQVJITfoTXIgR(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void MIOIzPgWShLrpAmMBukCKPPMUJT(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, ref pVSuHyNJvyUxaJEgntzLugvbPrW P_1, out pVSuHyNJvyUxaJEgntzLugvbPrW P_2)
	{
		float num = P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp * P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp + P_0.ZqYMkLdonrbLPbHprxydzkIAizSD * P_1.ZqYMkLdonrbLPbHprxydzkIAizSD;
		P_2.lSOdwKYaTJSJyAWJnADwkSPKwkp = P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp - 2f * num * P_1.lSOdwKYaTJSJyAWJnADwkSPKwkp;
		P_2.ZqYMkLdonrbLPbHprxydzkIAizSD = P_0.ZqYMkLdonrbLPbHprxydzkIAizSD - 2f * num * P_1.ZqYMkLdonrbLPbHprxydzkIAizSD;
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW MIOIzPgWShLrpAmMBukCKPPMUJT(pVSuHyNJvyUxaJEgntzLugvbPrW P_0, pVSuHyNJvyUxaJEgntzLugvbPrW P_1)
	{
		MIOIzPgWShLrpAmMBukCKPPMUJT(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void JWooQWmaZLWMLHzmycaWqtZbThX(pVSuHyNJvyUxaJEgntzLugvbPrW[] P_0, params pVSuHyNJvyUxaJEgntzLugvbPrW[] P_1)
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
			pVSuHyNJvyUxaJEgntzLugvbPrW pVSuHyNJvyUxaJEgntzLugvbPrW2 = P_1[i];
			for (int j = 0; j < i; j++)
			{
				pVSuHyNJvyUxaJEgntzLugvbPrW2 -= SfHUoyisOWeMIdmuGLgltMjrmwZ(P_0[j], pVSuHyNJvyUxaJEgntzLugvbPrW2) / SfHUoyisOWeMIdmuGLgltMjrmwZ(P_0[j], P_0[j]) * P_0[j];
			}
			P_0[i] = pVSuHyNJvyUxaJEgntzLugvbPrW2;
		}
	}

	public static void IoRtQAZbxLbnZuHIOmyIZzWpJGM(pVSuHyNJvyUxaJEgntzLugvbPrW[] P_0, params pVSuHyNJvyUxaJEgntzLugvbPrW[] P_1)
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
			pVSuHyNJvyUxaJEgntzLugvbPrW pVSuHyNJvyUxaJEgntzLugvbPrW2 = P_1[i];
			for (int j = 0; j < i; j++)
			{
				pVSuHyNJvyUxaJEgntzLugvbPrW2 -= SfHUoyisOWeMIdmuGLgltMjrmwZ(P_0[j], pVSuHyNJvyUxaJEgntzLugvbPrW2) * P_0[j];
			}
			pVSuHyNJvyUxaJEgntzLugvbPrW2.WIOZWgQagBlrnKFpQZCPLMEFqTd();
			P_0[i] = pVSuHyNJvyUxaJEgntzLugvbPrW2;
		}
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW operator +(pVSuHyNJvyUxaJEgntzLugvbPrW left, pVSuHyNJvyUxaJEgntzLugvbPrW right)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(left.lSOdwKYaTJSJyAWJnADwkSPKwkp + right.lSOdwKYaTJSJyAWJnADwkSPKwkp, left.ZqYMkLdonrbLPbHprxydzkIAizSD + right.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW operator *(pVSuHyNJvyUxaJEgntzLugvbPrW left, pVSuHyNJvyUxaJEgntzLugvbPrW right)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(left.lSOdwKYaTJSJyAWJnADwkSPKwkp * right.lSOdwKYaTJSJyAWJnADwkSPKwkp, left.ZqYMkLdonrbLPbHprxydzkIAizSD * right.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW operator +(pVSuHyNJvyUxaJEgntzLugvbPrW value)
	{
		return value;
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW operator -(pVSuHyNJvyUxaJEgntzLugvbPrW left, pVSuHyNJvyUxaJEgntzLugvbPrW right)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(left.lSOdwKYaTJSJyAWJnADwkSPKwkp - right.lSOdwKYaTJSJyAWJnADwkSPKwkp, left.ZqYMkLdonrbLPbHprxydzkIAizSD - right.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW operator -(pVSuHyNJvyUxaJEgntzLugvbPrW value)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(0f - value.lSOdwKYaTJSJyAWJnADwkSPKwkp, 0f - value.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW operator *(float scale, pVSuHyNJvyUxaJEgntzLugvbPrW value)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(value.lSOdwKYaTJSJyAWJnADwkSPKwkp * scale, value.ZqYMkLdonrbLPbHprxydzkIAizSD * scale);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW operator *(pVSuHyNJvyUxaJEgntzLugvbPrW value, float scale)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(value.lSOdwKYaTJSJyAWJnADwkSPKwkp * scale, value.ZqYMkLdonrbLPbHprxydzkIAizSD * scale);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW operator /(pVSuHyNJvyUxaJEgntzLugvbPrW value, float scale)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(value.lSOdwKYaTJSJyAWJnADwkSPKwkp / scale, value.ZqYMkLdonrbLPbHprxydzkIAizSD / scale);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW operator /(float scale, pVSuHyNJvyUxaJEgntzLugvbPrW value)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(scale / value.lSOdwKYaTJSJyAWJnADwkSPKwkp, scale / value.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW operator /(pVSuHyNJvyUxaJEgntzLugvbPrW value, pVSuHyNJvyUxaJEgntzLugvbPrW scale)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(value.lSOdwKYaTJSJyAWJnADwkSPKwkp / scale.lSOdwKYaTJSJyAWJnADwkSPKwkp, value.ZqYMkLdonrbLPbHprxydzkIAizSD / scale.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW operator +(pVSuHyNJvyUxaJEgntzLugvbPrW value, float scalar)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(value.lSOdwKYaTJSJyAWJnADwkSPKwkp + scalar, value.ZqYMkLdonrbLPbHprxydzkIAizSD + scalar);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW operator +(float scalar, pVSuHyNJvyUxaJEgntzLugvbPrW value)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(scalar + value.lSOdwKYaTJSJyAWJnADwkSPKwkp, scalar + value.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW operator -(pVSuHyNJvyUxaJEgntzLugvbPrW value, float scalar)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(value.lSOdwKYaTJSJyAWJnADwkSPKwkp - scalar, value.ZqYMkLdonrbLPbHprxydzkIAizSD - scalar);
	}

	public static pVSuHyNJvyUxaJEgntzLugvbPrW operator -(float scalar, pVSuHyNJvyUxaJEgntzLugvbPrW value)
	{
		return new pVSuHyNJvyUxaJEgntzLugvbPrW(scalar - value.lSOdwKYaTJSJyAWJnADwkSPKwkp, scalar - value.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public static bool operator ==(pVSuHyNJvyUxaJEgntzLugvbPrW left, pVSuHyNJvyUxaJEgntzLugvbPrW right)
	{
		return left.lpfGDOSkHRGqZKIqCGEaicWfABrw(ref right);
	}

	public static bool operator !=(pVSuHyNJvyUxaJEgntzLugvbPrW left, pVSuHyNJvyUxaJEgntzLugvbPrW right)
	{
		return !left.lpfGDOSkHRGqZKIqCGEaicWfABrw(ref right);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", new object[2] { lSOdwKYaTJSJyAWJnADwkSPKwkp, ZqYMkLdonrbLPbHprxydzkIAizSD });
	}

	public string iSLKngyzvSeBOWhcUVCKwoJrNEm(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", new object[2]
		{
			lSOdwKYaTJSJyAWJnADwkSPKwkp.ToString(P_0, CultureInfo.CurrentCulture),
			ZqYMkLdonrbLPbHprxydzkIAizSD.ToString(P_0, CultureInfo.CurrentCulture)
		});
	}

	public string iSLKngyzvSeBOWhcUVCKwoJrNEm(IFormatProvider P_0)
	{
		return string.Format(P_0, "X:{0} Y:{1}", new object[2] { lSOdwKYaTJSJyAWJnADwkSPKwkp, ZqYMkLdonrbLPbHprxydzkIAizSD });
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			iSLKngyzvSeBOWhcUVCKwoJrNEm(formatProvider);
		}
		return string.Format(formatProvider, "X:{0} Y:{1}", new object[2]
		{
			lSOdwKYaTJSJyAWJnADwkSPKwkp.ToString(format, formatProvider),
			ZqYMkLdonrbLPbHprxydzkIAizSD.ToString(format, formatProvider)
		});
	}

	public override int GetHashCode()
	{
		return (lSOdwKYaTJSJyAWJnADwkSPKwkp.GetHashCode() * 397) ^ ZqYMkLdonrbLPbHprxydzkIAizSD.GetHashCode();
	}

	public bool lpfGDOSkHRGqZKIqCGEaicWfABrw(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0)
	{
		if (ZvnBPrLKFiDHPIhVHtaZiLpeksK.zRKPPfiBPYeKnjHUBnDeSKiuiIX(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp, lSOdwKYaTJSJyAWJnADwkSPKwkp))
		{
			return ZvnBPrLKFiDHPIhVHtaZiLpeksK.zRKPPfiBPYeKnjHUBnDeSKiuiIX(P_0.ZqYMkLdonrbLPbHprxydzkIAizSD, ZqYMkLdonrbLPbHprxydzkIAizSD);
		}
		return false;
	}

	public bool Equals(pVSuHyNJvyUxaJEgntzLugvbPrW other)
	{
		return lpfGDOSkHRGqZKIqCGEaicWfABrw(ref other);
	}

	public override bool Equals(object value)
	{
		if (!(value is pVSuHyNJvyUxaJEgntzLugvbPrW pVSuHyNJvyUxaJEgntzLugvbPrW2))
		{
			return false;
		}
		return lpfGDOSkHRGqZKIqCGEaicWfABrw(ref pVSuHyNJvyUxaJEgntzLugvbPrW2);
	}
}
