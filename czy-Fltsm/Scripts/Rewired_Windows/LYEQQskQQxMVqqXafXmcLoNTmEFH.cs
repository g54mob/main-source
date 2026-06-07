using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[DefaultMember("Item")]
internal struct LYEQQskQQxMVqqXafXmcLoNTmEFH : IEquatable<LYEQQskQQxMVqqXafXmcLoNTmEFH>, IFormattable
{
	public static readonly int LRsxnIpSyGJflAHBFulCBxvRhFoO = Marshal.SizeOf(typeof(LYEQQskQQxMVqqXafXmcLoNTmEFH));

	public static readonly LYEQQskQQxMVqqXafXmcLoNTmEFH LmYaJaatCawAvBVrDbWpNJXmaCqV = default(LYEQQskQQxMVqqXafXmcLoNTmEFH);

	public static readonly LYEQQskQQxMVqqXafXmcLoNTmEFH ufiOTRZquLuSpwHmKgZChtkjrWbR = new LYEQQskQQxMVqqXafXmcLoNTmEFH(1f, 0f);

	public static readonly LYEQQskQQxMVqqXafXmcLoNTmEFH lRUloOpWzIYzInuvbeLpccKWzMxB = new LYEQQskQQxMVqqXafXmcLoNTmEFH(0f, 1f);

	public static readonly LYEQQskQQxMVqqXafXmcLoNTmEFH LamMoaTZRaDwRgGPmBmkEZJsBDjd = new LYEQQskQQxMVqqXafXmcLoNTmEFH(1f, 1f);

	public float vAYCwgFCkQdvQFnDqDRMzRibrDXDA;

	public float YrLvwUilJMBQPiJPoHOqSDlgzqFX;

	public bool aJbQujgmsdaWrPrvydiTJDgvyxQB => dWbFbVEkpbNXZvdpRyFJsVzUjJzHA.URiRGAJNJVGPtcwbTUTwiPuXZJvcA(vAYCwgFCkQdvQFnDqDRMzRibrDXDA * vAYCwgFCkQdvQFnDqDRMzRibrDXDA + YrLvwUilJMBQPiJPoHOqSDlgzqFX * YrLvwUilJMBQPiJPoHOqSDlgzqFX);

	public bool wxfBUNDBfPSqwrNbJQNhUAcZlHYIA
	{
		get
		{
			if (vAYCwgFCkQdvQFnDqDRMzRibrDXDA == 0f)
			{
				return YrLvwUilJMBQPiJPoHOqSDlgzqFX == 0f;
			}
			return false;
		}
	}

	public float adNGgwNANDvgfhAmzDKbjQEtciTC
	{
		get
		{
			return P_0 switch
			{
				0 => vAYCwgFCkQdvQFnDqDRMzRibrDXDA, 
				1 => YrLvwUilJMBQPiJPoHOqSDlgzqFX, 
				_ => throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive."), 
			};
		}
		set
		{
			switch (num)
			{
			case 0:
				vAYCwgFCkQdvQFnDqDRMzRibrDXDA = yrLvwUilJMBQPiJPoHOqSDlgzqFX;
				break;
			case 1:
				YrLvwUilJMBQPiJPoHOqSDlgzqFX = yrLvwUilJMBQPiJPoHOqSDlgzqFX;
				break;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
	}

	public LYEQQskQQxMVqqXafXmcLoNTmEFH(float P_0)
	{
		vAYCwgFCkQdvQFnDqDRMzRibrDXDA = P_0;
		YrLvwUilJMBQPiJPoHOqSDlgzqFX = P_0;
	}

	public LYEQQskQQxMVqqXafXmcLoNTmEFH(float P_0, float P_1)
	{
		vAYCwgFCkQdvQFnDqDRMzRibrDXDA = P_0;
		YrLvwUilJMBQPiJPoHOqSDlgzqFX = P_1;
	}

	public LYEQQskQQxMVqqXafXmcLoNTmEFH(float[] P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("values");
		}
		if (P_0.Length != 2)
		{
			throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
		}
		vAYCwgFCkQdvQFnDqDRMzRibrDXDA = P_0[0];
		YrLvwUilJMBQPiJPoHOqSDlgzqFX = P_0[1];
	}

	public float mOEtqQaNQcJBlbJdokjUoxhROzNh()
	{
		return (float)Math.Sqrt(vAYCwgFCkQdvQFnDqDRMzRibrDXDA * vAYCwgFCkQdvQFnDqDRMzRibrDXDA + YrLvwUilJMBQPiJPoHOqSDlgzqFX * YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public float ZoQVOCJRzgNwVOTgDjYuXWrgOvSD()
	{
		return vAYCwgFCkQdvQFnDqDRMzRibrDXDA * vAYCwgFCkQdvQFnDqDRMzRibrDXDA + YrLvwUilJMBQPiJPoHOqSDlgzqFX * YrLvwUilJMBQPiJPoHOqSDlgzqFX;
	}

	public void etfSCXEukBvYAoRZviEMGaaxQSwh()
	{
		float num = mOEtqQaNQcJBlbJdokjUoxhROzNh();
		if (!dWbFbVEkpbNXZvdpRyFJsVzUjJzHA.oIPARqmkixiCQPuracZAlWrRgopX(num))
		{
			float num2 = 1f / num;
			vAYCwgFCkQdvQFnDqDRMzRibrDXDA *= num2;
			YrLvwUilJMBQPiJPoHOqSDlgzqFX *= num2;
		}
	}

	public float[] zvSMnnmwdqFltGxKAoEJtfVMDmqDA()
	{
		return new float[2] { vAYCwgFCkQdvQFnDqDRMzRibrDXDA, YrLvwUilJMBQPiJPoHOqSDlgzqFX };
	}

	public static void wwfGNVHfrGAUYKNiIafcnFHLNRDhA(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_2)
	{
		P_2 = new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA + P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX + P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH tpVBmyHlxUcOZLKITVukoiZgjRwH(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA + P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX + P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public static void DXJzjzvCUlGOLLDxYOPQlqYTCyWz(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref float P_1, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_2)
	{
		P_2 = new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA + P_1, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX + P_1);
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH vjOauMnmNzJunrFyYkOcXZLOVMYI(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, float P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA + P_1, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX + P_1);
	}

	public static void kISqjchAXbhzjaGGSQEazezRFYUhA(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_2)
	{
		P_2 = new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA - P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX - P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH snCcSJJfqYLIBlcMaMuneItBKTBwB(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA - P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX - P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public static void qQwSqSRWHGNeimEVfxemUJLPZmnb(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref float P_1, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_2)
	{
		P_2 = new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA - P_1, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX - P_1);
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH pCEDFwAiSxWHyMzcCXeUKhTRRwpE(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, float P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA - P_1, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX - P_1);
	}

	public static void aghpJHWbbdFehhcjcppxsIKDInEQA(ref float P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_2)
	{
		P_2 = new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0 - P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0 - P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH PDbEjYcdnVboYPWwEOVhBWkeJYdhA(float P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0 - P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0 - P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public static void RlLVlFwuhkzQLkASZHCZqpmQVDwm(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, float P_1, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_2)
	{
		P_2 = new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA * P_1, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX * P_1);
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH tJJBTIxkbnYyLiKLufnmHojaKenE(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, float P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA * P_1, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX * P_1);
	}

	public static void SpwiZcbvbsnOuDjrwsefHiFuyscI(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_2)
	{
		P_2 = new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA * P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX * P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH XApEkcPKlpRjnoqFzqpKBwOUCeqX(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA * P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX * P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public static void QkRwNEanzWOMDoPqxaccLbAkMaEm(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, float P_1, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_2)
	{
		P_2 = new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA / P_1, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX / P_1);
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH KabFNUVxxlHfkvNTySFOfGzebuHA(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, float P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA / P_1, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX / P_1);
	}

	public static void vKsIevvoKMGWHXdfaHDTBoKknCVk(float P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_2)
	{
		P_2 = new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0 / P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0 / P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH tmvecnWsHgClMbUwJwNABBeceZSiA(float P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0 / P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0 / P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public static void YJQUfDFcCAkCmNXzLMRAvxSCGwuT(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		P_1 = new LYEQQskQQxMVqqXafXmcLoNTmEFH(0f - P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, 0f - P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH JlCdyOCMCRauawiVeGREYnUHvVcdA(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(0f - P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, 0f - P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public static void xXZnjdakiRIXRtoeWbqwWEUdOppR(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_2, float P_3, float P_4, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_5)
	{
		P_5 = new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA + P_3 * (P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA - P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA) + P_4 * (P_2.vAYCwgFCkQdvQFnDqDRMzRibrDXDA - P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA), P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX + P_3 * (P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX - P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX) + P_4 * (P_2.YrLvwUilJMBQPiJPoHOqSDlgzqFX - P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX));
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH kjXyjmwXBgsepIpVEnZUJjfnQcVr(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, LYEQQskQQxMVqqXafXmcLoNTmEFH P_2, float P_3, float P_4)
	{
		xXZnjdakiRIXRtoeWbqwWEUdOppR(ref P_0, ref P_1, ref P_2, P_3, P_4, out var result);
		return result;
	}

	public static void EWiVPYfRvjaJpMQHgiLstXnCmICg(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_2, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_3)
	{
		float num = P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA;
		num = ((num > P_2.vAYCwgFCkQdvQFnDqDRMzRibrDXDA) ? P_2.vAYCwgFCkQdvQFnDqDRMzRibrDXDA : num);
		num = ((num < P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA) ? P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA : num);
		float yrLvwUilJMBQPiJPoHOqSDlgzqFX = P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX;
		yrLvwUilJMBQPiJPoHOqSDlgzqFX = ((yrLvwUilJMBQPiJPoHOqSDlgzqFX > P_2.YrLvwUilJMBQPiJPoHOqSDlgzqFX) ? P_2.YrLvwUilJMBQPiJPoHOqSDlgzqFX : yrLvwUilJMBQPiJPoHOqSDlgzqFX);
		yrLvwUilJMBQPiJPoHOqSDlgzqFX = ((yrLvwUilJMBQPiJPoHOqSDlgzqFX < P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX) ? P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX : yrLvwUilJMBQPiJPoHOqSDlgzqFX);
		P_3 = new LYEQQskQQxMVqqXafXmcLoNTmEFH(num, yrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH GyhsLLzLjYhqxuhnlwGmoxkuWrIX(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, LYEQQskQQxMVqqXafXmcLoNTmEFH P_2)
	{
		EWiVPYfRvjaJpMQHgiLstXnCmICg(ref P_0, ref P_1, ref P_2, out var result);
		return result;
	}

	public void cXDhgmkVLTHJYPOHzMctHTbcptbh()
	{
		vAYCwgFCkQdvQFnDqDRMzRibrDXDA = ((vAYCwgFCkQdvQFnDqDRMzRibrDXDA < 0f) ? 0f : ((vAYCwgFCkQdvQFnDqDRMzRibrDXDA > 1f) ? 1f : vAYCwgFCkQdvQFnDqDRMzRibrDXDA));
		YrLvwUilJMBQPiJPoHOqSDlgzqFX = ((YrLvwUilJMBQPiJPoHOqSDlgzqFX < 0f) ? 0f : ((YrLvwUilJMBQPiJPoHOqSDlgzqFX > 1f) ? 1f : YrLvwUilJMBQPiJPoHOqSDlgzqFX));
	}

	public static void WAoeXwDWwpVytsqCpWWehHsudkEV(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, out float P_2)
	{
		float num = P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA - P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA;
		float num2 = P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX - P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX;
		P_2 = (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float WeZwAyAjWrwNWpehkAeERSxVarlh(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		float num = P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA - P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA;
		float num2 = P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX - P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static void ccZBozzJOUEpBkConLkNoHdGdzgkA(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, out float P_2)
	{
		float num = P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA - P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA;
		float num2 = P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX - P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX;
		P_2 = num * num + num2 * num2;
	}

	public static float pEcRbWjnCcnChOLYuEfDaJsABmvG(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		float num = P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA - P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA;
		float num2 = P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX - P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX;
		return num * num + num2 * num2;
	}

	public static void TNfsMdUKgkKctMIzXRhdiUxREUoh(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, out float P_2)
	{
		P_2 = P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA * P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA + P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX * P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX;
	}

	public static float kYWbAGwQWwNOmjkowUtwqCVYGwlT(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		return P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA * P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA + P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX * P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX;
	}

	public static void fGSpUkRXOADONtHIdMqIMtdsQAFr(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		P_1 = P_0;
		P_1.etfSCXEukBvYAoRZviEMGaaxQSwh();
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH phTLbPShpSnaUDkwAYCyNmmOBgQt(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0)
	{
		P_0.etfSCXEukBvYAoRZviEMGaaxQSwh();
		return P_0;
	}

	public static void sgcbllFeVELSsZmoDkaFhXVevHpjb(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, float P_2, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_3)
	{
		P_3.vAYCwgFCkQdvQFnDqDRMzRibrDXDA = dWbFbVEkpbNXZvdpRyFJsVzUjJzHA.YCqHhLhUucbWYgTvaEvQMkZmsUzJb(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_2);
		P_3.YrLvwUilJMBQPiJPoHOqSDlgzqFX = dWbFbVEkpbNXZvdpRyFJsVzUjJzHA.YCqHhLhUucbWYgTvaEvQMkZmsUzJb(P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX, P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX, P_2);
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH yLeTdKhFUpglgKWFZnsGWOcwTMeM(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, float P_2)
	{
		sgcbllFeVELSsZmoDkaFhXVevHpjb(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void AriOskaQwSNoVnPgqCYVAwdTOHwgA(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, float P_2, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_3)
	{
		P_2 = dWbFbVEkpbNXZvdpRyFJsVzUjJzHA.mKuokIIFqQIPrXSXEleasrPreHIz(P_2);
		sgcbllFeVELSsZmoDkaFhXVevHpjb(ref P_0, ref P_1, P_2, out P_3);
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH jXaCqcOMNqBLPjFFZIFfJzWWiDve(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, float P_2)
	{
		AriOskaQwSNoVnPgqCYVAwdTOHwgA(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void OQxCDrhIRPFFqRJEDhmTYfPisecwA(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_2, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_3, float P_4, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + P_4;
		float num6 = num2 - num;
		P_5.vAYCwgFCkQdvQFnDqDRMzRibrDXDA = P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA * num3 + P_2.vAYCwgFCkQdvQFnDqDRMzRibrDXDA * num4 + P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA * num5 + P_3.vAYCwgFCkQdvQFnDqDRMzRibrDXDA * num6;
		P_5.YrLvwUilJMBQPiJPoHOqSDlgzqFX = P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX * num3 + P_2.YrLvwUilJMBQPiJPoHOqSDlgzqFX * num4 + P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX * num5 + P_3.YrLvwUilJMBQPiJPoHOqSDlgzqFX * num6;
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH ODmeeTQMHKAtxGRpDSJjwuajGRhxA(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, LYEQQskQQxMVqqXafXmcLoNTmEFH P_2, LYEQQskQQxMVqqXafXmcLoNTmEFH P_3, float P_4)
	{
		OQxCDrhIRPFFqRJEDhmTYfPisecwA(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void tvHiWuvGPDfdoAayNsjJOnnshPmg(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_2, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_3, float P_4, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		P_5.vAYCwgFCkQdvQFnDqDRMzRibrDXDA = 0.5f * (2f * P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA + (0f - P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA + P_2.vAYCwgFCkQdvQFnDqDRMzRibrDXDA) * P_4 + (2f * P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA - 5f * P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA + 4f * P_2.vAYCwgFCkQdvQFnDqDRMzRibrDXDA - P_3.vAYCwgFCkQdvQFnDqDRMzRibrDXDA) * num + (0f - P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA + 3f * P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA - 3f * P_2.vAYCwgFCkQdvQFnDqDRMzRibrDXDA + P_3.vAYCwgFCkQdvQFnDqDRMzRibrDXDA) * num2);
		P_5.YrLvwUilJMBQPiJPoHOqSDlgzqFX = 0.5f * (2f * P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX + (0f - P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX + P_2.YrLvwUilJMBQPiJPoHOqSDlgzqFX) * P_4 + (2f * P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX - 5f * P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX + 4f * P_2.YrLvwUilJMBQPiJPoHOqSDlgzqFX - P_3.YrLvwUilJMBQPiJPoHOqSDlgzqFX) * num + (0f - P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX + 3f * P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX - 3f * P_2.YrLvwUilJMBQPiJPoHOqSDlgzqFX + P_3.YrLvwUilJMBQPiJPoHOqSDlgzqFX) * num2);
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH RBqHByllhYOTeQmSPjqAdksFQkDx(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, LYEQQskQQxMVqqXafXmcLoNTmEFH P_2, LYEQQskQQxMVqqXafXmcLoNTmEFH P_3, float P_4)
	{
		tvHiWuvGPDfdoAayNsjJOnnshPmg(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void NmUameUdgnfNoHMSEMOBxDTpLKapA(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_2)
	{
		P_2.vAYCwgFCkQdvQFnDqDRMzRibrDXDA = ((P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA > P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA) ? P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA : P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA);
		P_2.YrLvwUilJMBQPiJPoHOqSDlgzqFX = ((P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX > P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX) ? P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX : P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH gylgQwOdiLUiMHYcdWGNcxjSyAbD(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		NmUameUdgnfNoHMSEMOBxDTpLKapA(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void avNAhHJPGotHuGJoEZMAGxPErJBP(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_2)
	{
		P_2.vAYCwgFCkQdvQFnDqDRMzRibrDXDA = ((P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA < P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA) ? P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA : P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA);
		P_2.YrLvwUilJMBQPiJPoHOqSDlgzqFX = ((P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX < P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX) ? P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX : P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH HOHEKEPniHbFsLKORoCmayBZsTxL(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		avNAhHJPGotHuGJoEZMAGxPErJBP(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void AjiYVipxYhmHCshqstBCeWpjEcSM(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_1, out LYEQQskQQxMVqqXafXmcLoNTmEFH P_2)
	{
		float num = P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA * P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA + P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX * P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX;
		P_2.vAYCwgFCkQdvQFnDqDRMzRibrDXDA = P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA - 2f * num * P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA;
		P_2.YrLvwUilJMBQPiJPoHOqSDlgzqFX = P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX - 2f * num * P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX;
	}

	public static LYEQQskQQxMVqqXafXmcLoNTmEFH XmHCiDrXPkAcThFMLPyHcBKkXpvVB(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		AjiYVipxYhmHCshqstBCeWpjEcSM(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void ONwUOLfNpxjppbPYYZFArAbpHNYxA(LYEQQskQQxMVqqXafXmcLoNTmEFH[] P_0, params LYEQQskQQxMVqqXafXmcLoNTmEFH[] P_1)
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
			LYEQQskQQxMVqqXafXmcLoNTmEFH lYEQQskQQxMVqqXafXmcLoNTmEFH = P_1[i];
			for (int j = 0; j < i; j++)
			{
				lYEQQskQQxMVqqXafXmcLoNTmEFH = KfTGrHKjmfsKXvZvcbPrtEYTxoGf(lYEQQskQQxMVqqXafXmcLoNTmEFH, RieyWBKZpGIPbUYojkwGDxVCHbLE(kYWbAGwQWwNOmjkowUtwqCVYGwlT(P_0[j], lYEQQskQQxMVqqXafXmcLoNTmEFH) / kYWbAGwQWwNOmjkowUtwqCVYGwlT(P_0[j], P_0[j]), P_0[j]));
			}
			P_0[i] = lYEQQskQQxMVqqXafXmcLoNTmEFH;
		}
	}

	public static void dfdjUxLPlHiSOdYhZnOWGAmdjNtfb(LYEQQskQQxMVqqXafXmcLoNTmEFH[] P_0, params LYEQQskQQxMVqqXafXmcLoNTmEFH[] P_1)
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
			LYEQQskQQxMVqqXafXmcLoNTmEFH lYEQQskQQxMVqqXafXmcLoNTmEFH = P_1[i];
			for (int j = 0; j < i; j++)
			{
				lYEQQskQQxMVqqXafXmcLoNTmEFH = KfTGrHKjmfsKXvZvcbPrtEYTxoGf(lYEQQskQQxMVqqXafXmcLoNTmEFH, RieyWBKZpGIPbUYojkwGDxVCHbLE(kYWbAGwQWwNOmjkowUtwqCVYGwlT(P_0[j], lYEQQskQQxMVqqXafXmcLoNTmEFH), P_0[j]));
			}
			lYEQQskQQxMVqqXafXmcLoNTmEFH.etfSCXEukBvYAoRZviEMGaaxQSwh();
			P_0[i] = lYEQQskQQxMVqqXafXmcLoNTmEFH;
		}
	}

	[SpecialName]
	public static LYEQQskQQxMVqqXafXmcLoNTmEFH ocbJnJSvQKmxQKaBqtdHRgiCpWMO(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA + P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX + P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	[SpecialName]
	public static LYEQQskQQxMVqqXafXmcLoNTmEFH XjRdrRAGonbebAEOnjTvdYliVShS(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA * P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX * P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	[SpecialName]
	public static LYEQQskQQxMVqqXafXmcLoNTmEFH qYIgTAJpneBnafbPeWnKIavlHKngA(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0)
	{
		return P_0;
	}

	[SpecialName]
	public static LYEQQskQQxMVqqXafXmcLoNTmEFH KfTGrHKjmfsKXvZvcbPrtEYTxoGf(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA - P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX - P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	[SpecialName]
	public static LYEQQskQQxMVqqXafXmcLoNTmEFH DKMfhXbRkargNCyOxiqaqWzZWktZ(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(0f - P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, 0f - P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	[SpecialName]
	public static LYEQQskQQxMVqqXafXmcLoNTmEFH RieyWBKZpGIPbUYojkwGDxVCHbLE(float P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA * P_0, P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX * P_0);
	}

	[SpecialName]
	public static LYEQQskQQxMVqqXafXmcLoNTmEFH kGQyoVbeGqFxCCXxUTcyXjjJKkoC(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, float P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA * P_1, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX * P_1);
	}

	[SpecialName]
	public static LYEQQskQQxMVqqXafXmcLoNTmEFH oYfzJegBvbHTISHQGlYuxBpVuwsi(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, float P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA / P_1, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX / P_1);
	}

	[SpecialName]
	public static LYEQQskQQxMVqqXafXmcLoNTmEFH khaZlfeQGAlEEpkhJvKANeUPHNvH(float P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0 / P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0 / P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	[SpecialName]
	public static LYEQQskQQxMVqqXafXmcLoNTmEFH ytlBrQaANYztQFlQVMSAACKOmttrA(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA / P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX / P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	[SpecialName]
	public static LYEQQskQQxMVqqXafXmcLoNTmEFH rwxSIxHctItsfZzZqsylxeXCRsdf(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, float P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA + P_1, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX + P_1);
	}

	[SpecialName]
	public static LYEQQskQQxMVqqXafXmcLoNTmEFH dFIToDgMbbYYDtjXCJzZRxKxFWGT(float P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0 + P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0 + P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	[SpecialName]
	public static LYEQQskQQxMVqqXafXmcLoNTmEFH PqUFHejbuvokmgysTmwAZtCEradCb(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, float P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA - P_1, P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX - P_1);
	}

	[SpecialName]
	public static LYEQQskQQxMVqqXafXmcLoNTmEFH mMulGlnqJheFOSuyJHiWweHkgakq(float P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		return new LYEQQskQQxMVqqXafXmcLoNTmEFH(P_0 - P_1.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, P_0 - P_1.YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	[SpecialName]
	public static bool ZnmbnZFqstgjijuOwnJaZbKuzdpGA(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		return P_0.pQvAzDaNcgyMxslvtjcbTnGFSygFA(ref P_1);
	}

	[SpecialName]
	public static bool tlvtwGsYtBBFbkBZYjBsJFUmPTuJ(LYEQQskQQxMVqqXafXmcLoNTmEFH P_0, LYEQQskQQxMVqqXafXmcLoNTmEFH P_1)
	{
		return !P_0.pQvAzDaNcgyMxslvtjcbTnGFSygFA(ref P_1);
	}

	public string xlcojVXjAwCmSOxBiYyrOeQTPBGQ()
	{
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", vAYCwgFCkQdvQFnDqDRMzRibrDXDA, YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public string pvhycsrhgABRFKcYteIVgvsczPiub(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", vAYCwgFCkQdvQFnDqDRMzRibrDXDA.ToString(P_0, CultureInfo.CurrentCulture), YrLvwUilJMBQPiJPoHOqSDlgzqFX.ToString(P_0, CultureInfo.CurrentCulture));
	}

	public string oOKAcwADysaHwCAHiaxnUgnzVDYZ(IFormatProvider P_0)
	{
		return string.Format(P_0, "X:{0} Y:{1}", vAYCwgFCkQdvQFnDqDRMzRibrDXDA, YrLvwUilJMBQPiJPoHOqSDlgzqFX);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			oOKAcwADysaHwCAHiaxnUgnzVDYZ(formatProvider);
		}
		return string.Format(formatProvider, "X:{0} Y:{1}", vAYCwgFCkQdvQFnDqDRMzRibrDXDA.ToString(format, formatProvider), YrLvwUilJMBQPiJPoHOqSDlgzqFX.ToString(format, formatProvider));
	}

	string IFormattable.ToString(string format, IFormatProvider formatProvider)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ToString
		return this.ToString(format, formatProvider);
	}

	public int WRLUKaOFrxnoJfDnaqKrXUiMRUaD()
	{
		return (vAYCwgFCkQdvQFnDqDRMzRibrDXDA.GetHashCode() * 397) ^ YrLvwUilJMBQPiJPoHOqSDlgzqFX.GetHashCode();
	}

	public bool pQvAzDaNcgyMxslvtjcbTnGFSygFA(ref LYEQQskQQxMVqqXafXmcLoNTmEFH P_0)
	{
		if (dWbFbVEkpbNXZvdpRyFJsVzUjJzHA.tpVgrZXQWJXMiSZUclgKrLnihpfV(P_0.vAYCwgFCkQdvQFnDqDRMzRibrDXDA, vAYCwgFCkQdvQFnDqDRMzRibrDXDA))
		{
			return dWbFbVEkpbNXZvdpRyFJsVzUjJzHA.tpVgrZXQWJXMiSZUclgKrLnihpfV(P_0.YrLvwUilJMBQPiJPoHOqSDlgzqFX, YrLvwUilJMBQPiJPoHOqSDlgzqFX);
		}
		return false;
	}

	public bool Equals(LYEQQskQQxMVqqXafXmcLoNTmEFH other)
	{
		return pQvAzDaNcgyMxslvtjcbTnGFSygFA(ref other);
	}

	bool IEquatable<LYEQQskQQxMVqqXafXmcLoNTmEFH>.Equals(LYEQQskQQxMVqqXafXmcLoNTmEFH other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool oTEVjuBzqcNBvJhkPUScBLmeEUyG(object P_0)
	{
		if (!(P_0 is LYEQQskQQxMVqqXafXmcLoNTmEFH lYEQQskQQxMVqqXafXmcLoNTmEFH))
		{
			return false;
		}
		return pQvAzDaNcgyMxslvtjcbTnGFSygFA(ref lYEQQskQQxMVqqXafXmcLoNTmEFH);
	}
}
