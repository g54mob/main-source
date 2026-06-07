using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[DefaultMember("Item")]
internal struct rqovTKRrfKfknAWEFGTyqOPJLPnE : IEquatable<rqovTKRrfKfknAWEFGTyqOPJLPnE>, IFormattable
{
	public static readonly int dGOCOjAUXtbUikmzzaeWfqwNjoGZA = Marshal.SizeOf(typeof(rqovTKRrfKfknAWEFGTyqOPJLPnE));

	public static readonly rqovTKRrfKfknAWEFGTyqOPJLPnE hkaTcTVOfTeleEpHvFXlKwWwKrISA = default(rqovTKRrfKfknAWEFGTyqOPJLPnE);

	public static readonly rqovTKRrfKfknAWEFGTyqOPJLPnE KGNmorqXqHHkbWWGuOEmMxIxbRSc = new rqovTKRrfKfknAWEFGTyqOPJLPnE(1f, 0f);

	public static readonly rqovTKRrfKfknAWEFGTyqOPJLPnE NyyqCXMijfqpiZHSXehXhNjWbGsWA = new rqovTKRrfKfknAWEFGTyqOPJLPnE(0f, 1f);

	public static readonly rqovTKRrfKfknAWEFGTyqOPJLPnE jZEPvHgLsXDyUAKqKfCmptKsMoDRA = new rqovTKRrfKfknAWEFGTyqOPJLPnE(1f, 1f);

	public float DmuyZHmeJdvQJXOlYIQWuwpzsKvj;

	public float gKdHntFYuhblKScnERnydokeJbzF;

	public bool IKXMxDJOTCqBVdPHEKeckOEzZNNs => HQVERiRRUOeDMJXHtGXPymqWuaVH.sdWrdiekjmmFiWNmxGcokAdFiwBg(DmuyZHmeJdvQJXOlYIQWuwpzsKvj * DmuyZHmeJdvQJXOlYIQWuwpzsKvj + gKdHntFYuhblKScnERnydokeJbzF * gKdHntFYuhblKScnERnydokeJbzF);

	public bool CfVlligLUmDIpxsXpGdpnmnVixuG
	{
		get
		{
			if (DmuyZHmeJdvQJXOlYIQWuwpzsKvj == 0f)
			{
				return gKdHntFYuhblKScnERnydokeJbzF == 0f;
			}
			return false;
		}
	}

	public float AwzKpRooxmoUtJccTSMIUxPboNlV
	{
		get
		{
			return P_0 switch
			{
				0 => DmuyZHmeJdvQJXOlYIQWuwpzsKvj, 
				1 => gKdHntFYuhblKScnERnydokeJbzF, 
				_ => throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive."), 
			};
		}
		set
		{
			switch (num)
			{
			case 0:
				DmuyZHmeJdvQJXOlYIQWuwpzsKvj = dmuyZHmeJdvQJXOlYIQWuwpzsKvj;
				break;
			case 1:
				gKdHntFYuhblKScnERnydokeJbzF = dmuyZHmeJdvQJXOlYIQWuwpzsKvj;
				break;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
	}

	public rqovTKRrfKfknAWEFGTyqOPJLPnE(float P_0)
	{
		DmuyZHmeJdvQJXOlYIQWuwpzsKvj = P_0;
		gKdHntFYuhblKScnERnydokeJbzF = P_0;
	}

	public rqovTKRrfKfknAWEFGTyqOPJLPnE(float P_0, float P_1)
	{
		DmuyZHmeJdvQJXOlYIQWuwpzsKvj = P_0;
		gKdHntFYuhblKScnERnydokeJbzF = P_1;
	}

	public rqovTKRrfKfknAWEFGTyqOPJLPnE(float[] P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("values");
		}
		if (P_0.Length != 2)
		{
			throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
		}
		DmuyZHmeJdvQJXOlYIQWuwpzsKvj = P_0[0];
		gKdHntFYuhblKScnERnydokeJbzF = P_0[1];
	}

	public float OzufSjBuwRNcePpXEkvSJdyZWdvm()
	{
		return (float)Math.Sqrt(DmuyZHmeJdvQJXOlYIQWuwpzsKvj * DmuyZHmeJdvQJXOlYIQWuwpzsKvj + gKdHntFYuhblKScnERnydokeJbzF * gKdHntFYuhblKScnERnydokeJbzF);
	}

	public float pZiFaxubsLrqQmPbdbawyvNoQroP()
	{
		return DmuyZHmeJdvQJXOlYIQWuwpzsKvj * DmuyZHmeJdvQJXOlYIQWuwpzsKvj + gKdHntFYuhblKScnERnydokeJbzF * gKdHntFYuhblKScnERnydokeJbzF;
	}

	public void OHJChiFzPaqYFNEvRDtQnhdpUzCbA()
	{
		float num = OzufSjBuwRNcePpXEkvSJdyZWdvm();
		if (!HQVERiRRUOeDMJXHtGXPymqWuaVH.CIltkRLjXOTlLjMHIrSGOfmZrZBs(num))
		{
			float num2 = 1f / num;
			DmuyZHmeJdvQJXOlYIQWuwpzsKvj *= num2;
			gKdHntFYuhblKScnERnydokeJbzF *= num2;
		}
	}

	public float[] RceECSBGlPQwFuireXXDAQjSRAIE()
	{
		return new float[2] { DmuyZHmeJdvQJXOlYIQWuwpzsKvj, gKdHntFYuhblKScnERnydokeJbzF };
	}

	public static void AQRsKsOtEnpPVjdKgyiwkJMTiltg(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_2)
	{
		P_2 = new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj + P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0.gKdHntFYuhblKScnERnydokeJbzF + P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE FXbGwHcTMbjPGzworeQacVQyDEIuA(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj + P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0.gKdHntFYuhblKScnERnydokeJbzF + P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	public static void dOtuOMUabCfjEknVgaMIfONdRBeYB(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref float P_1, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_2)
	{
		P_2 = new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj + P_1, P_0.gKdHntFYuhblKScnERnydokeJbzF + P_1);
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE JjysPnKlaYNwoNBWsEdaauIMRgmQA(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, float P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj + P_1, P_0.gKdHntFYuhblKScnERnydokeJbzF + P_1);
	}

	public static void CNgWHRGveWsAgQNmwAXwDYiXpjqtA(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_2)
	{
		P_2 = new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj - P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0.gKdHntFYuhblKScnERnydokeJbzF - P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE UNwbjaGQHdxUWSBgCzQvrkkUwJpF(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj - P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0.gKdHntFYuhblKScnERnydokeJbzF - P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	public static void KzKrdLkRbfSojEAiJDgkBnMHTeEmA(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref float P_1, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_2)
	{
		P_2 = new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj - P_1, P_0.gKdHntFYuhblKScnERnydokeJbzF - P_1);
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE FsmRePfJXCufjsKRowYWnUeFJwPT(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, float P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj - P_1, P_0.gKdHntFYuhblKScnERnydokeJbzF - P_1);
	}

	public static void QHPewmpGKoBwxSTGhihjnHJBSeDc(ref float P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_2)
	{
		P_2 = new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0 - P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0 - P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE zoZEyvODSaLhVybCmFMxdfrmOnHv(float P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0 - P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0 - P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	public static void xGpYPcPHCFEWOQkeplHRPznKiwGr(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, float P_1, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_2)
	{
		P_2 = new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj * P_1, P_0.gKdHntFYuhblKScnERnydokeJbzF * P_1);
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE LsrmgyABXCPddGhmCqatoCbahrRY(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, float P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj * P_1, P_0.gKdHntFYuhblKScnERnydokeJbzF * P_1);
	}

	public static void cwKJRPWxMHErtndHKjzrkXCowTAq(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_2)
	{
		P_2 = new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj * P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0.gKdHntFYuhblKScnERnydokeJbzF * P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE lARXRLaMIGkQuObvPDsWdyVKgFGtA(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj * P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0.gKdHntFYuhblKScnERnydokeJbzF * P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	public static void kOhiZpJoOnQjASqvXJtigAFohxoY(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, float P_1, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_2)
	{
		P_2 = new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj / P_1, P_0.gKdHntFYuhblKScnERnydokeJbzF / P_1);
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE cdYOiiytMIaeyOvnpwPZdGRpFSEGA(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, float P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj / P_1, P_0.gKdHntFYuhblKScnERnydokeJbzF / P_1);
	}

	public static void PrGdrWGKljWlSIjNYNINMwHifQfzA(float P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_2)
	{
		P_2 = new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0 / P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0 / P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE ZFFXZYhuNJMbNVISbADKsBvwmwaH(float P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0 / P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0 / P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	public static void orwwbouIjbGjnnSBtHYWCUDIqZQFA(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		P_1 = new rqovTKRrfKfknAWEFGTyqOPJLPnE(0f - P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, 0f - P_0.gKdHntFYuhblKScnERnydokeJbzF);
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE jcwJfjrTnkFgbGirCgAGGoFJBcQM(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(0f - P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, 0f - P_0.gKdHntFYuhblKScnERnydokeJbzF);
	}

	public static void BwjKHGBTKcwcCBWPudhatJwnIKRe(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_2, float P_3, float P_4, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_5)
	{
		P_5 = new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj + P_3 * (P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj - P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj) + P_4 * (P_2.DmuyZHmeJdvQJXOlYIQWuwpzsKvj - P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj), P_0.gKdHntFYuhblKScnERnydokeJbzF + P_3 * (P_1.gKdHntFYuhblKScnERnydokeJbzF - P_0.gKdHntFYuhblKScnERnydokeJbzF) + P_4 * (P_2.gKdHntFYuhblKScnERnydokeJbzF - P_0.gKdHntFYuhblKScnERnydokeJbzF));
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE GpxCIPNMgXZxkufjcIEKeBspzNdO(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, rqovTKRrfKfknAWEFGTyqOPJLPnE P_2, float P_3, float P_4)
	{
		BwjKHGBTKcwcCBWPudhatJwnIKRe(ref P_0, ref P_1, ref P_2, P_3, P_4, out var result);
		return result;
	}

	public static void coEeapUwaITZwidsExhcMIQQVRcv(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_2, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_3)
	{
		float dmuyZHmeJdvQJXOlYIQWuwpzsKvj = P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj;
		dmuyZHmeJdvQJXOlYIQWuwpzsKvj = ((dmuyZHmeJdvQJXOlYIQWuwpzsKvj > P_2.DmuyZHmeJdvQJXOlYIQWuwpzsKvj) ? P_2.DmuyZHmeJdvQJXOlYIQWuwpzsKvj : dmuyZHmeJdvQJXOlYIQWuwpzsKvj);
		dmuyZHmeJdvQJXOlYIQWuwpzsKvj = ((dmuyZHmeJdvQJXOlYIQWuwpzsKvj < P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj) ? P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj : dmuyZHmeJdvQJXOlYIQWuwpzsKvj);
		float num = P_0.gKdHntFYuhblKScnERnydokeJbzF;
		num = ((num > P_2.gKdHntFYuhblKScnERnydokeJbzF) ? P_2.gKdHntFYuhblKScnERnydokeJbzF : num);
		num = ((num < P_1.gKdHntFYuhblKScnERnydokeJbzF) ? P_1.gKdHntFYuhblKScnERnydokeJbzF : num);
		P_3 = new rqovTKRrfKfknAWEFGTyqOPJLPnE(dmuyZHmeJdvQJXOlYIQWuwpzsKvj, num);
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE ksNecDYSuvHuHUHXJLqOBfuoMmBB(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, rqovTKRrfKfknAWEFGTyqOPJLPnE P_2)
	{
		coEeapUwaITZwidsExhcMIQQVRcv(ref P_0, ref P_1, ref P_2, out var result);
		return result;
	}

	public void EqzaMZFHweDmFllpRpFlgaceMUTDA()
	{
		DmuyZHmeJdvQJXOlYIQWuwpzsKvj = ((DmuyZHmeJdvQJXOlYIQWuwpzsKvj < 0f) ? 0f : ((DmuyZHmeJdvQJXOlYIQWuwpzsKvj > 1f) ? 1f : DmuyZHmeJdvQJXOlYIQWuwpzsKvj));
		gKdHntFYuhblKScnERnydokeJbzF = ((gKdHntFYuhblKScnERnydokeJbzF < 0f) ? 0f : ((gKdHntFYuhblKScnERnydokeJbzF > 1f) ? 1f : gKdHntFYuhblKScnERnydokeJbzF));
	}

	public static void umKkZJoeZULUoMGyFZAqYYtyFoaF(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, out float P_2)
	{
		float num = P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj - P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj;
		float num2 = P_0.gKdHntFYuhblKScnERnydokeJbzF - P_1.gKdHntFYuhblKScnERnydokeJbzF;
		P_2 = (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float iMpcJBgnfGmDZFTJKZTUomsLXTFNA(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		float num = P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj - P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj;
		float num2 = P_0.gKdHntFYuhblKScnERnydokeJbzF - P_1.gKdHntFYuhblKScnERnydokeJbzF;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static void QPvzPAOBbztIGgFERTvBkCsATWEP(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, out float P_2)
	{
		float num = P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj - P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj;
		float num2 = P_0.gKdHntFYuhblKScnERnydokeJbzF - P_1.gKdHntFYuhblKScnERnydokeJbzF;
		P_2 = num * num + num2 * num2;
	}

	public static float PNKCwbeWfFzYcOyqWcVRUHfEluLab(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		float num = P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj - P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj;
		float num2 = P_0.gKdHntFYuhblKScnERnydokeJbzF - P_1.gKdHntFYuhblKScnERnydokeJbzF;
		return num * num + num2 * num2;
	}

	public static void hBHHBMhqzFsnkqAZjZYtPLqPmhWm(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, out float P_2)
	{
		P_2 = P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj * P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj + P_0.gKdHntFYuhblKScnERnydokeJbzF * P_1.gKdHntFYuhblKScnERnydokeJbzF;
	}

	public static float QymwvjFDzJVzzFkOEWJaVqKQFBFw(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		return P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj * P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj + P_0.gKdHntFYuhblKScnERnydokeJbzF * P_1.gKdHntFYuhblKScnERnydokeJbzF;
	}

	public static void PoGpJSklnitIyZgTDjISfokLnjbA(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		P_1 = P_0;
		P_1.OHJChiFzPaqYFNEvRDtQnhdpUzCbA();
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE ZHfEoojSCvDEHpQquPayyEnIHrmf(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0)
	{
		P_0.OHJChiFzPaqYFNEvRDtQnhdpUzCbA();
		return P_0;
	}

	public static void ChKYiGJxgdnNxIACrHbNwPEeykBR(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, float P_2, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_3)
	{
		P_3.DmuyZHmeJdvQJXOlYIQWuwpzsKvj = HQVERiRRUOeDMJXHtGXPymqWuaVH.guCKsahsZHrCVnDVeCkSBXIaknRQ(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_2);
		P_3.gKdHntFYuhblKScnERnydokeJbzF = HQVERiRRUOeDMJXHtGXPymqWuaVH.guCKsahsZHrCVnDVeCkSBXIaknRQ(P_0.gKdHntFYuhblKScnERnydokeJbzF, P_1.gKdHntFYuhblKScnERnydokeJbzF, P_2);
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE WhOFydAKxWBYljulxCzCQlzcDzEPA(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, float P_2)
	{
		ChKYiGJxgdnNxIACrHbNwPEeykBR(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void aWNZLDRDxRTIFCOMCFRTlsDHeKy(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, float P_2, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_3)
	{
		P_2 = HQVERiRRUOeDMJXHtGXPymqWuaVH.WrSvVxfaRpCwkzldyjjuIRQtCaaeb(P_2);
		ChKYiGJxgdnNxIACrHbNwPEeykBR(ref P_0, ref P_1, P_2, out P_3);
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE LmGrpXhPfZciEDqjbtLhonwWxVNp(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, float P_2)
	{
		aWNZLDRDxRTIFCOMCFRTlsDHeKy(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void ukDqFGlQyqiadttobvQXCaCcCPWs(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_2, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_3, float P_4, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + P_4;
		float num6 = num2 - num;
		P_5.DmuyZHmeJdvQJXOlYIQWuwpzsKvj = P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj * num3 + P_2.DmuyZHmeJdvQJXOlYIQWuwpzsKvj * num4 + P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj * num5 + P_3.DmuyZHmeJdvQJXOlYIQWuwpzsKvj * num6;
		P_5.gKdHntFYuhblKScnERnydokeJbzF = P_0.gKdHntFYuhblKScnERnydokeJbzF * num3 + P_2.gKdHntFYuhblKScnERnydokeJbzF * num4 + P_1.gKdHntFYuhblKScnERnydokeJbzF * num5 + P_3.gKdHntFYuhblKScnERnydokeJbzF * num6;
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE ygKNikpGwxKiwtRItKGhTdbzmdZJ(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, rqovTKRrfKfknAWEFGTyqOPJLPnE P_2, rqovTKRrfKfknAWEFGTyqOPJLPnE P_3, float P_4)
	{
		ukDqFGlQyqiadttobvQXCaCcCPWs(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void PpteVHIHpavErahYtzjJvekoNIUn(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_2, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_3, float P_4, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		P_5.DmuyZHmeJdvQJXOlYIQWuwpzsKvj = 0.5f * (2f * P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj + (0f - P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj + P_2.DmuyZHmeJdvQJXOlYIQWuwpzsKvj) * P_4 + (2f * P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj - 5f * P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj + 4f * P_2.DmuyZHmeJdvQJXOlYIQWuwpzsKvj - P_3.DmuyZHmeJdvQJXOlYIQWuwpzsKvj) * num + (0f - P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj + 3f * P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj - 3f * P_2.DmuyZHmeJdvQJXOlYIQWuwpzsKvj + P_3.DmuyZHmeJdvQJXOlYIQWuwpzsKvj) * num2);
		P_5.gKdHntFYuhblKScnERnydokeJbzF = 0.5f * (2f * P_1.gKdHntFYuhblKScnERnydokeJbzF + (0f - P_0.gKdHntFYuhblKScnERnydokeJbzF + P_2.gKdHntFYuhblKScnERnydokeJbzF) * P_4 + (2f * P_0.gKdHntFYuhblKScnERnydokeJbzF - 5f * P_1.gKdHntFYuhblKScnERnydokeJbzF + 4f * P_2.gKdHntFYuhblKScnERnydokeJbzF - P_3.gKdHntFYuhblKScnERnydokeJbzF) * num + (0f - P_0.gKdHntFYuhblKScnERnydokeJbzF + 3f * P_1.gKdHntFYuhblKScnERnydokeJbzF - 3f * P_2.gKdHntFYuhblKScnERnydokeJbzF + P_3.gKdHntFYuhblKScnERnydokeJbzF) * num2);
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE hrUukPYGgnmTxwoOnpHSUzwPFTde(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, rqovTKRrfKfknAWEFGTyqOPJLPnE P_2, rqovTKRrfKfknAWEFGTyqOPJLPnE P_3, float P_4)
	{
		PpteVHIHpavErahYtzjJvekoNIUn(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void bkssNPlsBQIyxmEcsgXJuWYnnbCP(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_2)
	{
		P_2.DmuyZHmeJdvQJXOlYIQWuwpzsKvj = ((P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj > P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj) ? P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj : P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj);
		P_2.gKdHntFYuhblKScnERnydokeJbzF = ((P_0.gKdHntFYuhblKScnERnydokeJbzF > P_1.gKdHntFYuhblKScnERnydokeJbzF) ? P_0.gKdHntFYuhblKScnERnydokeJbzF : P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE OnJsLptkGaTxdrwgTNRULGkUTXJS(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		bkssNPlsBQIyxmEcsgXJuWYnnbCP(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void KBhACwkstXQqndaAeELADvGFCiplb(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_2)
	{
		P_2.DmuyZHmeJdvQJXOlYIQWuwpzsKvj = ((P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj < P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj) ? P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj : P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj);
		P_2.gKdHntFYuhblKScnERnydokeJbzF = ((P_0.gKdHntFYuhblKScnERnydokeJbzF < P_1.gKdHntFYuhblKScnERnydokeJbzF) ? P_0.gKdHntFYuhblKScnERnydokeJbzF : P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE lUthurqLbqqpjdkPnHDkLSJTLfNf(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		KBhACwkstXQqndaAeELADvGFCiplb(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void wOYbaPGKpGNsBCmCAYEKPSqxiXgQ(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_1, out rqovTKRrfKfknAWEFGTyqOPJLPnE P_2)
	{
		float num = P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj * P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj + P_0.gKdHntFYuhblKScnERnydokeJbzF * P_1.gKdHntFYuhblKScnERnydokeJbzF;
		P_2.DmuyZHmeJdvQJXOlYIQWuwpzsKvj = P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj - 2f * num * P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj;
		P_2.gKdHntFYuhblKScnERnydokeJbzF = P_0.gKdHntFYuhblKScnERnydokeJbzF - 2f * num * P_1.gKdHntFYuhblKScnERnydokeJbzF;
	}

	public static rqovTKRrfKfknAWEFGTyqOPJLPnE vFhFCuQpyZZUMzqGdraPwBVBYaZF(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		wOYbaPGKpGNsBCmCAYEKPSqxiXgQ(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void ujQbMyQeWWEIonJqmBGGCrqzaccPA(rqovTKRrfKfknAWEFGTyqOPJLPnE[] P_0, params rqovTKRrfKfknAWEFGTyqOPJLPnE[] P_1)
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
			rqovTKRrfKfknAWEFGTyqOPJLPnE rqovTKRrfKfknAWEFGTyqOPJLPnE2 = P_1[i];
			for (int j = 0; j < i; j++)
			{
				rqovTKRrfKfknAWEFGTyqOPJLPnE2 = mPzjjytCLKcHOHsJEiopBABJQQqFA(rqovTKRrfKfknAWEFGTyqOPJLPnE2, pPSGFmhasnqnumTiHbbKoAyIzyxO(QymwvjFDzJVzzFkOEWJaVqKQFBFw(P_0[j], rqovTKRrfKfknAWEFGTyqOPJLPnE2) / QymwvjFDzJVzzFkOEWJaVqKQFBFw(P_0[j], P_0[j]), P_0[j]));
			}
			P_0[i] = rqovTKRrfKfknAWEFGTyqOPJLPnE2;
		}
	}

	public static void ZKDrpGmJUqrHJiRPrZMIjtflmmHj(rqovTKRrfKfknAWEFGTyqOPJLPnE[] P_0, params rqovTKRrfKfknAWEFGTyqOPJLPnE[] P_1)
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
			rqovTKRrfKfknAWEFGTyqOPJLPnE rqovTKRrfKfknAWEFGTyqOPJLPnE2 = P_1[i];
			for (int j = 0; j < i; j++)
			{
				rqovTKRrfKfknAWEFGTyqOPJLPnE2 = mPzjjytCLKcHOHsJEiopBABJQQqFA(rqovTKRrfKfknAWEFGTyqOPJLPnE2, pPSGFmhasnqnumTiHbbKoAyIzyxO(QymwvjFDzJVzzFkOEWJaVqKQFBFw(P_0[j], rqovTKRrfKfknAWEFGTyqOPJLPnE2), P_0[j]));
			}
			rqovTKRrfKfknAWEFGTyqOPJLPnE2.OHJChiFzPaqYFNEvRDtQnhdpUzCbA();
			P_0[i] = rqovTKRrfKfknAWEFGTyqOPJLPnE2;
		}
	}

	[SpecialName]
	public static rqovTKRrfKfknAWEFGTyqOPJLPnE QIRKryppwbIjDsluEmcTeAlIxkyE(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj + P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0.gKdHntFYuhblKScnERnydokeJbzF + P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	[SpecialName]
	public static rqovTKRrfKfknAWEFGTyqOPJLPnE xabJEibcZQgQqbigXJKtwQeyStZjA(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj * P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0.gKdHntFYuhblKScnERnydokeJbzF * P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	[SpecialName]
	public static rqovTKRrfKfknAWEFGTyqOPJLPnE CbwiBrctCRObpZwlMeNKXFcbdbRy(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0)
	{
		return P_0;
	}

	[SpecialName]
	public static rqovTKRrfKfknAWEFGTyqOPJLPnE mPzjjytCLKcHOHsJEiopBABJQQqFA(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj - P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0.gKdHntFYuhblKScnERnydokeJbzF - P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	[SpecialName]
	public static rqovTKRrfKfknAWEFGTyqOPJLPnE vrgEGomxDNPzSASiBjsotGwFLRBl(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(0f - P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, 0f - P_0.gKdHntFYuhblKScnERnydokeJbzF);
	}

	[SpecialName]
	public static rqovTKRrfKfknAWEFGTyqOPJLPnE pPSGFmhasnqnumTiHbbKoAyIzyxO(float P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj * P_0, P_1.gKdHntFYuhblKScnERnydokeJbzF * P_0);
	}

	[SpecialName]
	public static rqovTKRrfKfknAWEFGTyqOPJLPnE UngiBiKlXLYkJmZfuEIyedmFdbCKA(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, float P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj * P_1, P_0.gKdHntFYuhblKScnERnydokeJbzF * P_1);
	}

	[SpecialName]
	public static rqovTKRrfKfknAWEFGTyqOPJLPnE EwDHOZXiGGOcNcCgsDkwaAaZsXIDb(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, float P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj / P_1, P_0.gKdHntFYuhblKScnERnydokeJbzF / P_1);
	}

	[SpecialName]
	public static rqovTKRrfKfknAWEFGTyqOPJLPnE CmKHyOHPtrpKXXxTpumQobZBfmDdA(float P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0 / P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0 / P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	[SpecialName]
	public static rqovTKRrfKfknAWEFGTyqOPJLPnE SXRIZlpgafWJPXEkxHZItnVIULVF(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj / P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0.gKdHntFYuhblKScnERnydokeJbzF / P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	[SpecialName]
	public static rqovTKRrfKfknAWEFGTyqOPJLPnE PPFUjUkMGroCyxMjOhxlAoEGeuBY(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, float P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj + P_1, P_0.gKdHntFYuhblKScnERnydokeJbzF + P_1);
	}

	[SpecialName]
	public static rqovTKRrfKfknAWEFGTyqOPJLPnE PHeVTqRCAKFpWVLbwJsJyATvtriw(float P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0 + P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0 + P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	[SpecialName]
	public static rqovTKRrfKfknAWEFGTyqOPJLPnE fBmevFKPPWRLrITAvjnUCmJYFZVj(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, float P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj - P_1, P_0.gKdHntFYuhblKScnERnydokeJbzF - P_1);
	}

	[SpecialName]
	public static rqovTKRrfKfknAWEFGTyqOPJLPnE WlQzCOUasQkHGiSWfWUMPEcwTeAD(float P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		return new rqovTKRrfKfknAWEFGTyqOPJLPnE(P_0 - P_1.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, P_0 - P_1.gKdHntFYuhblKScnERnydokeJbzF);
	}

	[SpecialName]
	public static bool reUYIiyHFQuOjYWcWeIqOlRabSRv(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		return P_0.RvHMEusrBBdxyJbXJdOzMrRBNIIk(ref P_1);
	}

	[SpecialName]
	public static bool HrFEQrDZzoXesjUroSyusgRilkIZA(rqovTKRrfKfknAWEFGTyqOPJLPnE P_0, rqovTKRrfKfknAWEFGTyqOPJLPnE P_1)
	{
		return !P_0.RvHMEusrBBdxyJbXJdOzMrRBNIIk(ref P_1);
	}

	public string FKAumaelRDlFcjxUrXbfnFZckuk()
	{
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", DmuyZHmeJdvQJXOlYIQWuwpzsKvj, gKdHntFYuhblKScnERnydokeJbzF);
	}

	public string JHNdJTWiTbngEAeqDxPJSMtzuaSS(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", DmuyZHmeJdvQJXOlYIQWuwpzsKvj.ToString(P_0, CultureInfo.CurrentCulture), gKdHntFYuhblKScnERnydokeJbzF.ToString(P_0, CultureInfo.CurrentCulture));
	}

	public string EmotZBviHXySvsDlWDgbLIaxdskcA(IFormatProvider P_0)
	{
		return string.Format(P_0, "X:{0} Y:{1}", DmuyZHmeJdvQJXOlYIQWuwpzsKvj, gKdHntFYuhblKScnERnydokeJbzF);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			EmotZBviHXySvsDlWDgbLIaxdskcA(formatProvider);
		}
		return string.Format(formatProvider, "X:{0} Y:{1}", DmuyZHmeJdvQJXOlYIQWuwpzsKvj.ToString(format, formatProvider), gKdHntFYuhblKScnERnydokeJbzF.ToString(format, formatProvider));
	}

	string IFormattable.ToString(string format, IFormatProvider formatProvider)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ToString
		return this.ToString(format, formatProvider);
	}

	public int etjorNhAmUsIORldEfprGsZIVuQOA()
	{
		return (DmuyZHmeJdvQJXOlYIQWuwpzsKvj.GetHashCode() * 397) ^ gKdHntFYuhblKScnERnydokeJbzF.GetHashCode();
	}

	public bool RvHMEusrBBdxyJbXJdOzMrRBNIIk(ref rqovTKRrfKfknAWEFGTyqOPJLPnE P_0)
	{
		if (HQVERiRRUOeDMJXHtGXPymqWuaVH.BCnStqyKtyvVrmkkSbOIAiooKYPu(P_0.DmuyZHmeJdvQJXOlYIQWuwpzsKvj, DmuyZHmeJdvQJXOlYIQWuwpzsKvj))
		{
			return HQVERiRRUOeDMJXHtGXPymqWuaVH.BCnStqyKtyvVrmkkSbOIAiooKYPu(P_0.gKdHntFYuhblKScnERnydokeJbzF, gKdHntFYuhblKScnERnydokeJbzF);
		}
		return false;
	}

	public bool Equals(rqovTKRrfKfknAWEFGTyqOPJLPnE other)
	{
		return RvHMEusrBBdxyJbXJdOzMrRBNIIk(ref other);
	}

	bool IEquatable<rqovTKRrfKfknAWEFGTyqOPJLPnE>.Equals(rqovTKRrfKfknAWEFGTyqOPJLPnE other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool WUoosDaGMFCwmCpIvlTgBgrGwxQTb(object P_0)
	{
		if (!(P_0 is rqovTKRrfKfknAWEFGTyqOPJLPnE rqovTKRrfKfknAWEFGTyqOPJLPnE2))
		{
			return false;
		}
		return RvHMEusrBBdxyJbXJdOzMrRBNIIk(ref rqovTKRrfKfknAWEFGTyqOPJLPnE2);
	}
}
