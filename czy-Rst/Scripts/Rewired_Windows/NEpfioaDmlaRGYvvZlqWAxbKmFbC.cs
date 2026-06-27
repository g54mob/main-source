using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[DefaultMember("Item")]
internal struct NEpfioaDmlaRGYvvZlqWAxbKmFbC : IEquatable<NEpfioaDmlaRGYvvZlqWAxbKmFbC>, IFormattable
{
	public static readonly int VRTKWUtGjIhTZiKCrzLSCQPYMBWO = Marshal.SizeOf(typeof(NEpfioaDmlaRGYvvZlqWAxbKmFbC));

	public static readonly NEpfioaDmlaRGYvvZlqWAxbKmFbC ZodtkgcRPgOkVzMqtruzKotzGCWkA = default(NEpfioaDmlaRGYvvZlqWAxbKmFbC);

	public static readonly NEpfioaDmlaRGYvvZlqWAxbKmFbC cPcuHRtrRAGLWQzyzaUeEWuOGDf = new NEpfioaDmlaRGYvvZlqWAxbKmFbC(1f, 0f);

	public static readonly NEpfioaDmlaRGYvvZlqWAxbKmFbC htxQSqxnPOcqZXgpDiGXcxOTVrmvA = new NEpfioaDmlaRGYvvZlqWAxbKmFbC(0f, 1f);

	public static readonly NEpfioaDmlaRGYvvZlqWAxbKmFbC ReVRdsXvAaPdjYHHYSpoZBplfLVeA = new NEpfioaDmlaRGYvvZlqWAxbKmFbC(1f, 1f);

	public float lAvaVoARhWHJkYTWOmrWUYIskDjz;

	public float APkJNCuxOQoibCaGGFcaBkNpTqbS;

	public bool eqEnrqwZdzoYchGkSeRwASfuksZs => dfKKdXwCgxajpRVshUjJCvNXwXRV.AoXfGlDCDNrZqEeytluEAEbOZIXD(lAvaVoARhWHJkYTWOmrWUYIskDjz * lAvaVoARhWHJkYTWOmrWUYIskDjz + APkJNCuxOQoibCaGGFcaBkNpTqbS * APkJNCuxOQoibCaGGFcaBkNpTqbS);

	public bool ujWhjZZMiDMYWjHabjJvRCtOJDof
	{
		get
		{
			if (lAvaVoARhWHJkYTWOmrWUYIskDjz == 0f)
			{
				return APkJNCuxOQoibCaGGFcaBkNpTqbS == 0f;
			}
			return false;
		}
	}

	public float khwlzyFzFVSXYNbTBufYyZmuJgnu
	{
		get
		{
			return P_0 switch
			{
				0 => lAvaVoARhWHJkYTWOmrWUYIskDjz, 
				1 => APkJNCuxOQoibCaGGFcaBkNpTqbS, 
				_ => throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive."), 
			};
		}
		set
		{
			switch (num)
			{
			case 0:
				lAvaVoARhWHJkYTWOmrWUYIskDjz = aPkJNCuxOQoibCaGGFcaBkNpTqbS;
				break;
			case 1:
				APkJNCuxOQoibCaGGFcaBkNpTqbS = aPkJNCuxOQoibCaGGFcaBkNpTqbS;
				break;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
	}

	public NEpfioaDmlaRGYvvZlqWAxbKmFbC(float P_0)
	{
		lAvaVoARhWHJkYTWOmrWUYIskDjz = P_0;
		APkJNCuxOQoibCaGGFcaBkNpTqbS = P_0;
	}

	public NEpfioaDmlaRGYvvZlqWAxbKmFbC(float P_0, float P_1)
	{
		lAvaVoARhWHJkYTWOmrWUYIskDjz = P_0;
		APkJNCuxOQoibCaGGFcaBkNpTqbS = P_1;
	}

	public NEpfioaDmlaRGYvvZlqWAxbKmFbC(float[] P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("values");
		}
		if (P_0.Length != 2)
		{
			throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
		}
		lAvaVoARhWHJkYTWOmrWUYIskDjz = P_0[0];
		APkJNCuxOQoibCaGGFcaBkNpTqbS = P_0[1];
	}

	public float cOriUQeCCqfdBfHmGYUAbjTWOKpAA()
	{
		return (float)Math.Sqrt(lAvaVoARhWHJkYTWOmrWUYIskDjz * lAvaVoARhWHJkYTWOmrWUYIskDjz + APkJNCuxOQoibCaGGFcaBkNpTqbS * APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public float DopiuGVCCgPphqOWlcReIAkjMKaq()
	{
		return lAvaVoARhWHJkYTWOmrWUYIskDjz * lAvaVoARhWHJkYTWOmrWUYIskDjz + APkJNCuxOQoibCaGGFcaBkNpTqbS * APkJNCuxOQoibCaGGFcaBkNpTqbS;
	}

	public void gnKcpDbYxFVFmSHKDuUSLdAsaSQY()
	{
		float num = cOriUQeCCqfdBfHmGYUAbjTWOKpAA();
		if (!dfKKdXwCgxajpRVshUjJCvNXwXRV.wxstcwgGxlxmqnLcOUdOcCJWyoBt(num))
		{
			float num2 = 1f / num;
			lAvaVoARhWHJkYTWOmrWUYIskDjz *= num2;
			APkJNCuxOQoibCaGGFcaBkNpTqbS *= num2;
		}
	}

	public float[] rHhWbbooRmPXewZzoyXIgleTyOoc()
	{
		return new float[2] { lAvaVoARhWHJkYTWOmrWUYIskDjz, APkJNCuxOQoibCaGGFcaBkNpTqbS };
	}

	public static void ifQevJjxyAiFwtAfakDwEEdUGNlhA(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2)
	{
		P_2 = new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz + P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS + P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC jtyGyobHcGwKhmrDrfxqdthJxrYnB(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz + P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS + P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public static void DkaUIvfLXvakpklqqSbUbswIUacoA(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref float P_1, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2)
	{
		P_2 = new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz + P_1, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS + P_1);
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC dyhSZUbwUlQvVLahagOoJCpZmTofA(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, float P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz + P_1, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS + P_1);
	}

	public static void wyhURerlUlAXThIRmissNyVCXGwU(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2)
	{
		P_2 = new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz - P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS - P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC qzxryNddxCyAdYeJGGufHyLXXcdL(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz - P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS - P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public static void gUJRteFUDKEnCABFPhHsGRxIPXCX(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref float P_1, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2)
	{
		P_2 = new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz - P_1, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS - P_1);
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC rWlsucGJbhAcSumucqtQTFHWODRy(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, float P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz - P_1, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS - P_1);
	}

	public static void iKaHJIFedMVTGVsYDOvDhaOfLmK(ref float P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2)
	{
		P_2 = new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0 - P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0 - P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC HkWAaIfTqXWJeoDjshNrPIWdEYFI(float P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0 - P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0 - P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public static void JVwSqNiGcegZjOIBbRoRrzCVlDAR(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, float P_1, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2)
	{
		P_2 = new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz * P_1, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS * P_1);
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC znymmLzqhphaIKgJOwRjGiUvICLr(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, float P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz * P_1, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS * P_1);
	}

	public static void QrJkZcpXugNJIjekWfStYNjpBiOP(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2)
	{
		P_2 = new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz * P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS * P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC DgSxJwNmutMTPSaKXEVQFYiPGaQHA(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz * P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS * P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public static void SaoiTWkzgWNgvWpQDNCaCbcnpOkO(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, float P_1, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2)
	{
		P_2 = new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz / P_1, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS / P_1);
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC UhROkRJEqjWhTQWQdqcTJKsmCfKy(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, float P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz / P_1, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS / P_1);
	}

	public static void vcZCxjezBOEejHduKAtNPGyapvDtC(float P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2)
	{
		P_2 = new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0 / P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0 / P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC fvMHAnYKAmXxwXalbxfCIBUdCHuV(float P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0 / P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0 / P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public static void EcpwrJNlRWOmCnKihFvQmrqVLkMT(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		P_1 = new NEpfioaDmlaRGYvvZlqWAxbKmFbC(0f - P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz, 0f - P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC BRpHESSPXNQNOWkCCrBEqaiKKNWo(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(0f - P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz, 0f - P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public static void bHkOFxgppPxrVZbheACoTqPoxATC(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2, float P_3, float P_4, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_5)
	{
		P_5 = new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz + P_3 * (P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz - P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz) + P_4 * (P_2.lAvaVoARhWHJkYTWOmrWUYIskDjz - P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz), P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS + P_3 * (P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS - P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS) + P_4 * (P_2.APkJNCuxOQoibCaGGFcaBkNpTqbS - P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS));
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC muudKwsXSoiWNieIudlScGLenyziA(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2, float P_3, float P_4)
	{
		bHkOFxgppPxrVZbheACoTqPoxATC(ref P_0, ref P_1, ref P_2, P_3, P_4, out var result);
		return result;
	}

	public static void KIHDsWhfYxBYXisNInIeeazNwwotA(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_3)
	{
		float num = P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz;
		num = ((num > P_2.lAvaVoARhWHJkYTWOmrWUYIskDjz) ? P_2.lAvaVoARhWHJkYTWOmrWUYIskDjz : num);
		num = ((num < P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz) ? P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz : num);
		float aPkJNCuxOQoibCaGGFcaBkNpTqbS = P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS;
		aPkJNCuxOQoibCaGGFcaBkNpTqbS = ((aPkJNCuxOQoibCaGGFcaBkNpTqbS > P_2.APkJNCuxOQoibCaGGFcaBkNpTqbS) ? P_2.APkJNCuxOQoibCaGGFcaBkNpTqbS : aPkJNCuxOQoibCaGGFcaBkNpTqbS);
		aPkJNCuxOQoibCaGGFcaBkNpTqbS = ((aPkJNCuxOQoibCaGGFcaBkNpTqbS < P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS) ? P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS : aPkJNCuxOQoibCaGGFcaBkNpTqbS);
		P_3 = new NEpfioaDmlaRGYvvZlqWAxbKmFbC(num, aPkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC CGSodZboZWMFjScQReuKtWxlfwoB(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2)
	{
		KIHDsWhfYxBYXisNInIeeazNwwotA(ref P_0, ref P_1, ref P_2, out var result);
		return result;
	}

	public void olgAWgicMVhjoxnERgirZWVpRnPRA()
	{
		lAvaVoARhWHJkYTWOmrWUYIskDjz = ((lAvaVoARhWHJkYTWOmrWUYIskDjz < 0f) ? 0f : ((lAvaVoARhWHJkYTWOmrWUYIskDjz > 1f) ? 1f : lAvaVoARhWHJkYTWOmrWUYIskDjz));
		APkJNCuxOQoibCaGGFcaBkNpTqbS = ((APkJNCuxOQoibCaGGFcaBkNpTqbS < 0f) ? 0f : ((APkJNCuxOQoibCaGGFcaBkNpTqbS > 1f) ? 1f : APkJNCuxOQoibCaGGFcaBkNpTqbS));
	}

	public static void OhDmawTRllOyXEUJXuSoqlMvcpwj(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, out float P_2)
	{
		float num = P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz - P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz;
		float num2 = P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS - P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS;
		P_2 = (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float MimCLoIKFfoYgPXiQhuWQQTKsaZFA(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		float num = P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz - P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz;
		float num2 = P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS - P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static void qekBDjarPAJFnBofdJOXPMBcFpMYB(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, out float P_2)
	{
		float num = P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz - P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz;
		float num2 = P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS - P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS;
		P_2 = num * num + num2 * num2;
	}

	public static float tiNcqIgnBccBVQcDOrqDvjKNPDZRA(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		float num = P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz - P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz;
		float num2 = P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS - P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS;
		return num * num + num2 * num2;
	}

	public static void VPYhZhWUFuEoBuZkdmxrbAHKQAAO(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, out float P_2)
	{
		P_2 = P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz * P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz + P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS * P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS;
	}

	public static float aDtYtAusVsSwEHLtSqmgdknPXkTT(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		return P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz * P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz + P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS * P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS;
	}

	public static void bvtxyPXlOcHdZfBHYcWHYZnOIdJ(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		P_1 = P_0;
		P_1.gnKcpDbYxFVFmSHKDuUSLdAsaSQY();
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC vdmCHmCiYUKeLdvdgskmOKTFwKue(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0)
	{
		P_0.gnKcpDbYxFVFmSHKDuUSLdAsaSQY();
		return P_0;
	}

	public static void ycNSGrotCGkHSOpvlUUNISldRALm(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, float P_2, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_3)
	{
		P_3.lAvaVoARhWHJkYTWOmrWUYIskDjz = dfKKdXwCgxajpRVshUjJCvNXwXRV.EzFOqLYofyupidgaaPlOfnTzSaBF(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_2);
		P_3.APkJNCuxOQoibCaGGFcaBkNpTqbS = dfKKdXwCgxajpRVshUjJCvNXwXRV.EzFOqLYofyupidgaaPlOfnTzSaBF(P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS, P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS, P_2);
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC ecRfsQdzPlxBOLqCrfMYaXKGrGSjc(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, float P_2)
	{
		ycNSGrotCGkHSOpvlUUNISldRALm(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void ADOZodejGOClbPfeQiRTnFIWPKfb(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, float P_2, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_3)
	{
		P_2 = dfKKdXwCgxajpRVshUjJCvNXwXRV.idVUTIGpdMNbZlMKgEGqxkbsfBgR(P_2);
		ycNSGrotCGkHSOpvlUUNISldRALm(ref P_0, ref P_1, P_2, out P_3);
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC zbDuhcOpTkshpZQYjugdApRVfeRt(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, float P_2)
	{
		ADOZodejGOClbPfeQiRTnFIWPKfb(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void WpUcexMRKPvTIpuTxQMVipnvoiOl(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_3, float P_4, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + P_4;
		float num6 = num2 - num;
		P_5.lAvaVoARhWHJkYTWOmrWUYIskDjz = P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz * num3 + P_2.lAvaVoARhWHJkYTWOmrWUYIskDjz * num4 + P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz * num5 + P_3.lAvaVoARhWHJkYTWOmrWUYIskDjz * num6;
		P_5.APkJNCuxOQoibCaGGFcaBkNpTqbS = P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS * num3 + P_2.APkJNCuxOQoibCaGGFcaBkNpTqbS * num4 + P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS * num5 + P_3.APkJNCuxOQoibCaGGFcaBkNpTqbS * num6;
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC ABNXEVAFMIRkDzzkdnxjzoEsRKHh(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_3, float P_4)
	{
		WpUcexMRKPvTIpuTxQMVipnvoiOl(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void xJaEBqbeNHmDWcIjdyIRDeNbJxGX(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_3, float P_4, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		P_5.lAvaVoARhWHJkYTWOmrWUYIskDjz = 0.5f * (2f * P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz + (0f - P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz + P_2.lAvaVoARhWHJkYTWOmrWUYIskDjz) * P_4 + (2f * P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz - 5f * P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz + 4f * P_2.lAvaVoARhWHJkYTWOmrWUYIskDjz - P_3.lAvaVoARhWHJkYTWOmrWUYIskDjz) * num + (0f - P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz + 3f * P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz - 3f * P_2.lAvaVoARhWHJkYTWOmrWUYIskDjz + P_3.lAvaVoARhWHJkYTWOmrWUYIskDjz) * num2);
		P_5.APkJNCuxOQoibCaGGFcaBkNpTqbS = 0.5f * (2f * P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS + (0f - P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS + P_2.APkJNCuxOQoibCaGGFcaBkNpTqbS) * P_4 + (2f * P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS - 5f * P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS + 4f * P_2.APkJNCuxOQoibCaGGFcaBkNpTqbS - P_3.APkJNCuxOQoibCaGGFcaBkNpTqbS) * num + (0f - P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS + 3f * P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS - 3f * P_2.APkJNCuxOQoibCaGGFcaBkNpTqbS + P_3.APkJNCuxOQoibCaGGFcaBkNpTqbS) * num2);
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC NcTqmezmzYnrQuLHxMKvuQFEaald(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_3, float P_4)
	{
		xJaEBqbeNHmDWcIjdyIRDeNbJxGX(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void FOrSHcWFxfjbOeSTiHyLYkruDUEo(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2)
	{
		P_2.lAvaVoARhWHJkYTWOmrWUYIskDjz = ((P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz > P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz) ? P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz : P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz);
		P_2.APkJNCuxOQoibCaGGFcaBkNpTqbS = ((P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS > P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS) ? P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS : P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC gBIuDUYfsXZuIvvRLMeQdiDBmqXs(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		FOrSHcWFxfjbOeSTiHyLYkruDUEo(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void aNayMBNTZwjrGkFporeIHnbZRXln(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2)
	{
		P_2.lAvaVoARhWHJkYTWOmrWUYIskDjz = ((P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz < P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz) ? P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz : P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz);
		P_2.APkJNCuxOQoibCaGGFcaBkNpTqbS = ((P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS < P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS) ? P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS : P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC FJopjEHepLpgSfvHjgGivjlAIsNo(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		aNayMBNTZwjrGkFporeIHnbZRXln(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void WuRbycbNJnEvgYMzQZrOdpTeaawDA(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1, out NEpfioaDmlaRGYvvZlqWAxbKmFbC P_2)
	{
		float num = P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz * P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz + P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS * P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS;
		P_2.lAvaVoARhWHJkYTWOmrWUYIskDjz = P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz - 2f * num * P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz;
		P_2.APkJNCuxOQoibCaGGFcaBkNpTqbS = P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS - 2f * num * P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS;
	}

	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC JveXfFloEiUjnxjVxCMPUwiOOhDq(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		WuRbycbNJnEvgYMzQZrOdpTeaawDA(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void OoJrLJtdcxdHFjKViVjYPbLgfLibA(NEpfioaDmlaRGYvvZlqWAxbKmFbC[] P_0, params NEpfioaDmlaRGYvvZlqWAxbKmFbC[] P_1)
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
			NEpfioaDmlaRGYvvZlqWAxbKmFbC nEpfioaDmlaRGYvvZlqWAxbKmFbC = P_1[i];
			for (int j = 0; j < i; j++)
			{
				nEpfioaDmlaRGYvvZlqWAxbKmFbC = IvqjlHAQhhAEjLrmQeZrewmAqjuPA(nEpfioaDmlaRGYvvZlqWAxbKmFbC, BABhLZSJEQBoBgxTZUwGOcLNIJhT(aDtYtAusVsSwEHLtSqmgdknPXkTT(P_0[j], nEpfioaDmlaRGYvvZlqWAxbKmFbC) / aDtYtAusVsSwEHLtSqmgdknPXkTT(P_0[j], P_0[j]), P_0[j]));
			}
			P_0[i] = nEpfioaDmlaRGYvvZlqWAxbKmFbC;
		}
	}

	public static void naYpApDSiRuaogqkdmQUDeAikPFU(NEpfioaDmlaRGYvvZlqWAxbKmFbC[] P_0, params NEpfioaDmlaRGYvvZlqWAxbKmFbC[] P_1)
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
			NEpfioaDmlaRGYvvZlqWAxbKmFbC nEpfioaDmlaRGYvvZlqWAxbKmFbC = P_1[i];
			for (int j = 0; j < i; j++)
			{
				nEpfioaDmlaRGYvvZlqWAxbKmFbC = IvqjlHAQhhAEjLrmQeZrewmAqjuPA(nEpfioaDmlaRGYvvZlqWAxbKmFbC, BABhLZSJEQBoBgxTZUwGOcLNIJhT(aDtYtAusVsSwEHLtSqmgdknPXkTT(P_0[j], nEpfioaDmlaRGYvvZlqWAxbKmFbC), P_0[j]));
			}
			nEpfioaDmlaRGYvvZlqWAxbKmFbC.gnKcpDbYxFVFmSHKDuUSLdAsaSQY();
			P_0[i] = nEpfioaDmlaRGYvvZlqWAxbKmFbC;
		}
	}

	[SpecialName]
	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC yxYERJQATALpgknIUVjXUQUJOHkh(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz + P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS + P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	[SpecialName]
	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC TVuGOXAPtrWRVaVHDBdhkSHhSSFl(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz * P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS * P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	[SpecialName]
	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC gMraOIZkgcHOGNhMYDDSxdJcvQPT(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0)
	{
		return P_0;
	}

	[SpecialName]
	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC IvqjlHAQhhAEjLrmQeZrewmAqjuPA(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz - P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS - P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	[SpecialName]
	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC FWjEDZPwhqAizCuNXYluXtHEwvPI(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(0f - P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz, 0f - P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	[SpecialName]
	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC BABhLZSJEQBoBgxTZUwGOcLNIJhT(float P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz * P_0, P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS * P_0);
	}

	[SpecialName]
	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC kzrFRXxIdkxjyswIirrkShBQCWIu(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, float P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz * P_1, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS * P_1);
	}

	[SpecialName]
	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC wbSJYmiyodsbceeDgHHckiHAYgGhA(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, float P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz / P_1, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS / P_1);
	}

	[SpecialName]
	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC sWPEsdmFHOgHwhVunNBEpQsMABNNA(float P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0 / P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0 / P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	[SpecialName]
	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC uMGIMSErCQJJqHCZfGgKNfeZefRJA(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz / P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS / P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	[SpecialName]
	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC plWurjJMqEDFTtNYGgUtkvxDULXw(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, float P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz + P_1, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS + P_1);
	}

	[SpecialName]
	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC pdhNQHkGephqhRMKigDBKAoobEkKA(float P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0 + P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0 + P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	[SpecialName]
	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC DWrwFuxopbAxCUIfjSLSsAmTamZf(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, float P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz - P_1, P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS - P_1);
	}

	[SpecialName]
	public static NEpfioaDmlaRGYvvZlqWAxbKmFbC mHghtIxMthnkiitCpvQWtpjjuGxb(float P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		return new NEpfioaDmlaRGYvvZlqWAxbKmFbC(P_0 - P_1.lAvaVoARhWHJkYTWOmrWUYIskDjz, P_0 - P_1.APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	[SpecialName]
	public static bool ZZPwGVBszrCNSUXHIAneihgfCxHGA(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		return P_0.bKCUTLRsjsukBPDqNIUfsdmKPcEy(ref P_1);
	}

	[SpecialName]
	public static bool dCGeSEGqFTndPHWGccZyeCkelFOtc(NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0, NEpfioaDmlaRGYvvZlqWAxbKmFbC P_1)
	{
		return !P_0.bKCUTLRsjsukBPDqNIUfsdmKPcEy(ref P_1);
	}

	public string lFkGDMHFgCQaEwKfQMvLDmdQLBye()
	{
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", lAvaVoARhWHJkYTWOmrWUYIskDjz, APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public string ntGARmnnlOkfvEdVRQcVmLQuNHSR(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", lAvaVoARhWHJkYTWOmrWUYIskDjz.ToString(P_0, CultureInfo.CurrentCulture), APkJNCuxOQoibCaGGFcaBkNpTqbS.ToString(P_0, CultureInfo.CurrentCulture));
	}

	public string wrhtRgWdrySpUsLCGIJlvTVufDcfA(IFormatProvider P_0)
	{
		return string.Format(P_0, "X:{0} Y:{1}", lAvaVoARhWHJkYTWOmrWUYIskDjz, APkJNCuxOQoibCaGGFcaBkNpTqbS);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			wrhtRgWdrySpUsLCGIJlvTVufDcfA(formatProvider);
		}
		return string.Format(formatProvider, "X:{0} Y:{1}", lAvaVoARhWHJkYTWOmrWUYIskDjz.ToString(format, formatProvider), APkJNCuxOQoibCaGGFcaBkNpTqbS.ToString(format, formatProvider));
	}

	string IFormattable.ToString(string format, IFormatProvider formatProvider)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ToString
		return this.ToString(format, formatProvider);
	}

	public int WioQzaMAKjLXpTAWOHAbIzsFkJWs()
	{
		return (lAvaVoARhWHJkYTWOmrWUYIskDjz.GetHashCode() * 397) ^ APkJNCuxOQoibCaGGFcaBkNpTqbS.GetHashCode();
	}

	public bool bKCUTLRsjsukBPDqNIUfsdmKPcEy(ref NEpfioaDmlaRGYvvZlqWAxbKmFbC P_0)
	{
		if (dfKKdXwCgxajpRVshUjJCvNXwXRV.fymKkBVmLJiiIavPOMMGkxRhnXZG(P_0.lAvaVoARhWHJkYTWOmrWUYIskDjz, lAvaVoARhWHJkYTWOmrWUYIskDjz))
		{
			return dfKKdXwCgxajpRVshUjJCvNXwXRV.fymKkBVmLJiiIavPOMMGkxRhnXZG(P_0.APkJNCuxOQoibCaGGFcaBkNpTqbS, APkJNCuxOQoibCaGGFcaBkNpTqbS);
		}
		return false;
	}

	public bool Equals(NEpfioaDmlaRGYvvZlqWAxbKmFbC other)
	{
		return bKCUTLRsjsukBPDqNIUfsdmKPcEy(ref other);
	}

	bool IEquatable<NEpfioaDmlaRGYvvZlqWAxbKmFbC>.Equals(NEpfioaDmlaRGYvvZlqWAxbKmFbC other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool okvQyoLQgeobBrqzzjsmYPOzwAKo(object P_0)
	{
		if (!(P_0 is NEpfioaDmlaRGYvvZlqWAxbKmFbC nEpfioaDmlaRGYvvZlqWAxbKmFbC))
		{
			return false;
		}
		return bKCUTLRsjsukBPDqNIUfsdmKPcEy(ref nEpfioaDmlaRGYvvZlqWAxbKmFbC);
	}
}
