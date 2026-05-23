using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[DefaultMember("Item")]
internal struct LmNgBsPyZshzCkvasaMebNljdBcg : IEquatable<LmNgBsPyZshzCkvasaMebNljdBcg>, IFormattable
{
	public static readonly int HyzHRWGdpLQsNGKMQMRKjElrITTF = Marshal.SizeOf(typeof(LmNgBsPyZshzCkvasaMebNljdBcg));

	public static readonly LmNgBsPyZshzCkvasaMebNljdBcg TCXgjsLzRvSlJDFsEDrnalDOrRPkA = default(LmNgBsPyZshzCkvasaMebNljdBcg);

	public static readonly LmNgBsPyZshzCkvasaMebNljdBcg eOnrMZojlCBRNaIdBmPWNccTZIGg = new LmNgBsPyZshzCkvasaMebNljdBcg(1f, 0f);

	public static readonly LmNgBsPyZshzCkvasaMebNljdBcg bFPEJiAEJLDtBddtiaNHpUitestDB = new LmNgBsPyZshzCkvasaMebNljdBcg(0f, 1f);

	public static readonly LmNgBsPyZshzCkvasaMebNljdBcg NutgswFqQjekhOwDpqugOgZMQYWDA = new LmNgBsPyZshzCkvasaMebNljdBcg(1f, 1f);

	public float vrVgYmgBbVHIwxfAxrsAvmcTcSan;

	public float KcKChCXgWJdizkLEnhrcaPdUfwmJ;

	public bool mfudmiIBruSXadDcpaIsilPhLdMtb => xjgRHLTmnwmrOnyIQwjZfnxgOFGe.WXzuUGgLUAwLLuQmEkHsnoqbWGEm(vrVgYmgBbVHIwxfAxrsAvmcTcSan * vrVgYmgBbVHIwxfAxrsAvmcTcSan + KcKChCXgWJdizkLEnhrcaPdUfwmJ * KcKChCXgWJdizkLEnhrcaPdUfwmJ);

	public bool ikSoBadaCxHUTCaKlcjqjqrCKrGA
	{
		get
		{
			if (vrVgYmgBbVHIwxfAxrsAvmcTcSan == 0f)
			{
				return KcKChCXgWJdizkLEnhrcaPdUfwmJ == 0f;
			}
			return false;
		}
	}

	public float iQYCeajeBAiYKWhJafqKqJGDajsCb
	{
		get
		{
			return P_0 switch
			{
				0 => vrVgYmgBbVHIwxfAxrsAvmcTcSan, 
				1 => KcKChCXgWJdizkLEnhrcaPdUfwmJ, 
				_ => throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive."), 
			};
		}
		set
		{
			switch (num)
			{
			case 0:
				vrVgYmgBbVHIwxfAxrsAvmcTcSan = kcKChCXgWJdizkLEnhrcaPdUfwmJ;
				break;
			case 1:
				KcKChCXgWJdizkLEnhrcaPdUfwmJ = kcKChCXgWJdizkLEnhrcaPdUfwmJ;
				break;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
	}

	public LmNgBsPyZshzCkvasaMebNljdBcg(float P_0)
	{
		vrVgYmgBbVHIwxfAxrsAvmcTcSan = P_0;
		KcKChCXgWJdizkLEnhrcaPdUfwmJ = P_0;
	}

	public LmNgBsPyZshzCkvasaMebNljdBcg(float P_0, float P_1)
	{
		vrVgYmgBbVHIwxfAxrsAvmcTcSan = P_0;
		KcKChCXgWJdizkLEnhrcaPdUfwmJ = P_1;
	}

	public LmNgBsPyZshzCkvasaMebNljdBcg(float[] P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("values");
		}
		if (P_0.Length != 2)
		{
			throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
		}
		vrVgYmgBbVHIwxfAxrsAvmcTcSan = P_0[0];
		KcKChCXgWJdizkLEnhrcaPdUfwmJ = P_0[1];
	}

	public float kHLTTERkKfZmZvryzbJKOLnpGZaaA()
	{
		return (float)Math.Sqrt(vrVgYmgBbVHIwxfAxrsAvmcTcSan * vrVgYmgBbVHIwxfAxrsAvmcTcSan + KcKChCXgWJdizkLEnhrcaPdUfwmJ * KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public float PiJTnMayWrGifYgQEOQsxHCSoZfr()
	{
		return vrVgYmgBbVHIwxfAxrsAvmcTcSan * vrVgYmgBbVHIwxfAxrsAvmcTcSan + KcKChCXgWJdizkLEnhrcaPdUfwmJ * KcKChCXgWJdizkLEnhrcaPdUfwmJ;
	}

	public void knuLiXhkxOFMywnIqHNEqsmDaDPn()
	{
		float num = kHLTTERkKfZmZvryzbJKOLnpGZaaA();
		if (!xjgRHLTmnwmrOnyIQwjZfnxgOFGe.sbGglkJNtoClcIZejhaOEPxbXfWHA(num))
		{
			float num2 = 1f / num;
			vrVgYmgBbVHIwxfAxrsAvmcTcSan *= num2;
			KcKChCXgWJdizkLEnhrcaPdUfwmJ *= num2;
		}
	}

	public float[] rKHTxbJHsdOzDMeHDjIRFdNahvDl()
	{
		return new float[2] { vrVgYmgBbVHIwxfAxrsAvmcTcSan, KcKChCXgWJdizkLEnhrcaPdUfwmJ };
	}

	public static void mjmlRwMofJpdcXrjDGggpXvbCCeC(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, out LmNgBsPyZshzCkvasaMebNljdBcg P_2)
	{
		P_2 = new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan + P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ + P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg xCOrtuiceZsJrHvTUjccQkJGLkFs(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan + P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ + P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public static void ThOhBnKIDwjlxfBqBRgWVDCjIrlab(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref float P_1, out LmNgBsPyZshzCkvasaMebNljdBcg P_2)
	{
		P_2 = new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan + P_1, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ + P_1);
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg nAHGGAGsWyWaHjcdFgNgAjRmjGvHA(LmNgBsPyZshzCkvasaMebNljdBcg P_0, float P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan + P_1, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ + P_1);
	}

	public static void ySXESqCeMgjKTicRDJhahNlroNtFA(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, out LmNgBsPyZshzCkvasaMebNljdBcg P_2)
	{
		P_2 = new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan - P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ - P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg mPPsJnObLJrjEkLDdDtDavpaAkXb(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan - P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ - P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public static void ugnGiukTBZIwSieTgcQkZaNvEMFnA(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref float P_1, out LmNgBsPyZshzCkvasaMebNljdBcg P_2)
	{
		P_2 = new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan - P_1, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ - P_1);
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg tzFDlkazraPjMESoXceSBelhKSSJA(LmNgBsPyZshzCkvasaMebNljdBcg P_0, float P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan - P_1, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ - P_1);
	}

	public static void yNerLVnjmsNQDoqovEQtgEIpubpk(ref float P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, out LmNgBsPyZshzCkvasaMebNljdBcg P_2)
	{
		P_2 = new LmNgBsPyZshzCkvasaMebNljdBcg(P_0 - P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0 - P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg DgkDAOKkHUPoGUzZXytZakCODKnB(float P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0 - P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0 - P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public static void BYMVRHZgqhIUpoDxAbhVAaUeOjBD(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, float P_1, out LmNgBsPyZshzCkvasaMebNljdBcg P_2)
	{
		P_2 = new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan * P_1, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ * P_1);
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg pMAetDSvloXnAubFlwQpnpsQPLIN(LmNgBsPyZshzCkvasaMebNljdBcg P_0, float P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan * P_1, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ * P_1);
	}

	public static void MdnzWwAOwjdSEPhmrRVjpINKYbZr(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, out LmNgBsPyZshzCkvasaMebNljdBcg P_2)
	{
		P_2 = new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan * P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ * P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg BTaJKgiEwyQGRacOafIQCnUurjBFA(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan * P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ * P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public static void YVITQMPIwVFfjAkMsKHsWzIUxBhN(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, float P_1, out LmNgBsPyZshzCkvasaMebNljdBcg P_2)
	{
		P_2 = new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan / P_1, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ / P_1);
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg YldchDEekeyoVSkMSnbLVyQFUqDkA(LmNgBsPyZshzCkvasaMebNljdBcg P_0, float P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan / P_1, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ / P_1);
	}

	public static void vvxlghEGRDbjleFcxgqJZlOMWwax(float P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, out LmNgBsPyZshzCkvasaMebNljdBcg P_2)
	{
		P_2 = new LmNgBsPyZshzCkvasaMebNljdBcg(P_0 / P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0 / P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg zojKfgzOarKoqrhuSkSLtgEGUcvD(float P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0 / P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0 / P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public static void GWZFoRcdLThdYeDgYqcQcHUkwpZQA(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, out LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		P_1 = new LmNgBsPyZshzCkvasaMebNljdBcg(0f - P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan, 0f - P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg NLTWKqdTUCXITmSjAmWxTGrbWFMA(LmNgBsPyZshzCkvasaMebNljdBcg P_0)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(0f - P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan, 0f - P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public static void bEUXDlVDpYhghtKjRHDmcoWLeuYfb(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, ref LmNgBsPyZshzCkvasaMebNljdBcg P_2, float P_3, float P_4, out LmNgBsPyZshzCkvasaMebNljdBcg P_5)
	{
		P_5 = new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan + P_3 * (P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan - P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan) + P_4 * (P_2.vrVgYmgBbVHIwxfAxrsAvmcTcSan - P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan), P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ + P_3 * (P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ - P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ) + P_4 * (P_2.KcKChCXgWJdizkLEnhrcaPdUfwmJ - P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ));
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg mtMTdqNKSdVZFOhKDsoAnVvJfOwK(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1, LmNgBsPyZshzCkvasaMebNljdBcg P_2, float P_3, float P_4)
	{
		bEUXDlVDpYhghtKjRHDmcoWLeuYfb(ref P_0, ref P_1, ref P_2, P_3, P_4, out var result);
		return result;
	}

	public static void GIpVvMUaAuHNPhSPvzNacPLyvlzUA(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, ref LmNgBsPyZshzCkvasaMebNljdBcg P_2, out LmNgBsPyZshzCkvasaMebNljdBcg P_3)
	{
		float num = P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan;
		num = ((num > P_2.vrVgYmgBbVHIwxfAxrsAvmcTcSan) ? P_2.vrVgYmgBbVHIwxfAxrsAvmcTcSan : num);
		num = ((num < P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan) ? P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan : num);
		float kcKChCXgWJdizkLEnhrcaPdUfwmJ = P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ;
		kcKChCXgWJdizkLEnhrcaPdUfwmJ = ((kcKChCXgWJdizkLEnhrcaPdUfwmJ > P_2.KcKChCXgWJdizkLEnhrcaPdUfwmJ) ? P_2.KcKChCXgWJdizkLEnhrcaPdUfwmJ : kcKChCXgWJdizkLEnhrcaPdUfwmJ);
		kcKChCXgWJdizkLEnhrcaPdUfwmJ = ((kcKChCXgWJdizkLEnhrcaPdUfwmJ < P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ) ? P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ : kcKChCXgWJdizkLEnhrcaPdUfwmJ);
		P_3 = new LmNgBsPyZshzCkvasaMebNljdBcg(num, kcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg OMkduLYtyFDjHknekxhmIvcAmmrJ(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1, LmNgBsPyZshzCkvasaMebNljdBcg P_2)
	{
		GIpVvMUaAuHNPhSPvzNacPLyvlzUA(ref P_0, ref P_1, ref P_2, out var result);
		return result;
	}

	public void iHUnHeXlYEEgocXAugfzClrEAuCCB()
	{
		vrVgYmgBbVHIwxfAxrsAvmcTcSan = ((vrVgYmgBbVHIwxfAxrsAvmcTcSan < 0f) ? 0f : ((vrVgYmgBbVHIwxfAxrsAvmcTcSan > 1f) ? 1f : vrVgYmgBbVHIwxfAxrsAvmcTcSan));
		KcKChCXgWJdizkLEnhrcaPdUfwmJ = ((KcKChCXgWJdizkLEnhrcaPdUfwmJ < 0f) ? 0f : ((KcKChCXgWJdizkLEnhrcaPdUfwmJ > 1f) ? 1f : KcKChCXgWJdizkLEnhrcaPdUfwmJ));
	}

	public static void YDxliTkpIaTRPqXDexgWTuzIzhrB(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, out float P_2)
	{
		float num = P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan - P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan;
		float num2 = P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ - P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ;
		P_2 = (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float AsQLEibNFozLkhOmbkjIvwhrGpGq(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		float num = P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan - P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan;
		float num2 = P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ - P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static void ivKHCdOXFBkQzUObmILHxDxgJoNQ(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, out float P_2)
	{
		float num = P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan - P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan;
		float num2 = P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ - P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ;
		P_2 = num * num + num2 * num2;
	}

	public static float zRxLrQMMDpXMBEJJrHtZYkcuHSWq(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		float num = P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan - P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan;
		float num2 = P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ - P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ;
		return num * num + num2 * num2;
	}

	public static void VIkUAdbNLxIbZOOmWyilSWffwPNN(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, out float P_2)
	{
		P_2 = P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan * P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan + P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ * P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ;
	}

	public static float grVkaYJUDjOpYfEnnCzkOTFwBrYeA(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		return P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan * P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan + P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ * P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ;
	}

	public static void fnDqJiatDTbjbnMFcPdQcbrIKXiq(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, out LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		P_1 = P_0;
		P_1.knuLiXhkxOFMywnIqHNEqsmDaDPn();
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg jpGRcPnqyZPxqRbhJxUgtsgmzElG(LmNgBsPyZshzCkvasaMebNljdBcg P_0)
	{
		P_0.knuLiXhkxOFMywnIqHNEqsmDaDPn();
		return P_0;
	}

	public static void ifdHlcRUZbjESidWcNDIzHASYCcB(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, float P_2, out LmNgBsPyZshzCkvasaMebNljdBcg P_3)
	{
		P_3.vrVgYmgBbVHIwxfAxrsAvmcTcSan = xjgRHLTmnwmrOnyIQwjZfnxgOFGe.SMzNELvnibrxwPcxJSLIIZiYPQKd(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_2);
		P_3.KcKChCXgWJdizkLEnhrcaPdUfwmJ = xjgRHLTmnwmrOnyIQwjZfnxgOFGe.SMzNELvnibrxwPcxJSLIIZiYPQKd(P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ, P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ, P_2);
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg wYnqnEEAFqwWEEXSUjPQiHqOlFZP(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1, float P_2)
	{
		ifdHlcRUZbjESidWcNDIzHASYCcB(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void ICnALmDPhHFbfjxxntJDGezxWeJF(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, float P_2, out LmNgBsPyZshzCkvasaMebNljdBcg P_3)
	{
		P_2 = xjgRHLTmnwmrOnyIQwjZfnxgOFGe.cVfEAElWvPTaNPgMBrTmCXFZLIhP(P_2);
		ifdHlcRUZbjESidWcNDIzHASYCcB(ref P_0, ref P_1, P_2, out P_3);
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg hUlegeBdPbfavYhIEqnlGpzAgfGNb(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1, float P_2)
	{
		ICnALmDPhHFbfjxxntJDGezxWeJF(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void KdojlxpEvKsMbHFgCBeXVPPWrfJE(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, ref LmNgBsPyZshzCkvasaMebNljdBcg P_2, ref LmNgBsPyZshzCkvasaMebNljdBcg P_3, float P_4, out LmNgBsPyZshzCkvasaMebNljdBcg P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + P_4;
		float num6 = num2 - num;
		P_5.vrVgYmgBbVHIwxfAxrsAvmcTcSan = P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan * num3 + P_2.vrVgYmgBbVHIwxfAxrsAvmcTcSan * num4 + P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan * num5 + P_3.vrVgYmgBbVHIwxfAxrsAvmcTcSan * num6;
		P_5.KcKChCXgWJdizkLEnhrcaPdUfwmJ = P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ * num3 + P_2.KcKChCXgWJdizkLEnhrcaPdUfwmJ * num4 + P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ * num5 + P_3.KcKChCXgWJdizkLEnhrcaPdUfwmJ * num6;
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg MNnSLLdZGPOPXVOoYqWzAJyBMhQI(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1, LmNgBsPyZshzCkvasaMebNljdBcg P_2, LmNgBsPyZshzCkvasaMebNljdBcg P_3, float P_4)
	{
		KdojlxpEvKsMbHFgCBeXVPPWrfJE(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void tJQUCqCnHSHIEWwpQLXDidvOqqDO(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, ref LmNgBsPyZshzCkvasaMebNljdBcg P_2, ref LmNgBsPyZshzCkvasaMebNljdBcg P_3, float P_4, out LmNgBsPyZshzCkvasaMebNljdBcg P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		P_5.vrVgYmgBbVHIwxfAxrsAvmcTcSan = 0.5f * (2f * P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan + (0f - P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan + P_2.vrVgYmgBbVHIwxfAxrsAvmcTcSan) * P_4 + (2f * P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan - 5f * P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan + 4f * P_2.vrVgYmgBbVHIwxfAxrsAvmcTcSan - P_3.vrVgYmgBbVHIwxfAxrsAvmcTcSan) * num + (0f - P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan + 3f * P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan - 3f * P_2.vrVgYmgBbVHIwxfAxrsAvmcTcSan + P_3.vrVgYmgBbVHIwxfAxrsAvmcTcSan) * num2);
		P_5.KcKChCXgWJdizkLEnhrcaPdUfwmJ = 0.5f * (2f * P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ + (0f - P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ + P_2.KcKChCXgWJdizkLEnhrcaPdUfwmJ) * P_4 + (2f * P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ - 5f * P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ + 4f * P_2.KcKChCXgWJdizkLEnhrcaPdUfwmJ - P_3.KcKChCXgWJdizkLEnhrcaPdUfwmJ) * num + (0f - P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ + 3f * P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ - 3f * P_2.KcKChCXgWJdizkLEnhrcaPdUfwmJ + P_3.KcKChCXgWJdizkLEnhrcaPdUfwmJ) * num2);
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg XMvhUcAzwBmyQOcJSPxKZfkjjSaF(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1, LmNgBsPyZshzCkvasaMebNljdBcg P_2, LmNgBsPyZshzCkvasaMebNljdBcg P_3, float P_4)
	{
		tJQUCqCnHSHIEWwpQLXDidvOqqDO(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void RCRGEazKposaYIpNVThNxkLXjBDAA(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, out LmNgBsPyZshzCkvasaMebNljdBcg P_2)
	{
		P_2.vrVgYmgBbVHIwxfAxrsAvmcTcSan = ((P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan > P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan) ? P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan : P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan);
		P_2.KcKChCXgWJdizkLEnhrcaPdUfwmJ = ((P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ > P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ) ? P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ : P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg yukDICkhkOhxCQJJmlzQeKpoKzOcb(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		RCRGEazKposaYIpNVThNxkLXjBDAA(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void ghWILZoVVxRwIEPvDfbIecBsxImM(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, out LmNgBsPyZshzCkvasaMebNljdBcg P_2)
	{
		P_2.vrVgYmgBbVHIwxfAxrsAvmcTcSan = ((P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan < P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan) ? P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan : P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan);
		P_2.KcKChCXgWJdizkLEnhrcaPdUfwmJ = ((P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ < P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ) ? P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ : P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg LdImNMgEvSCcSNXHSUrwMQNfFfEo(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		ghWILZoVVxRwIEPvDfbIecBsxImM(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void GtblcmAkJisseoKjpagIYqfLlupF(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0, ref LmNgBsPyZshzCkvasaMebNljdBcg P_1, out LmNgBsPyZshzCkvasaMebNljdBcg P_2)
	{
		float num = P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan * P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan + P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ * P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ;
		P_2.vrVgYmgBbVHIwxfAxrsAvmcTcSan = P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan - 2f * num * P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan;
		P_2.KcKChCXgWJdizkLEnhrcaPdUfwmJ = P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ - 2f * num * P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ;
	}

	public static LmNgBsPyZshzCkvasaMebNljdBcg VSlUZGWOBbRzkFLdSDhXrMDbqoQE(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		GtblcmAkJisseoKjpagIYqfLlupF(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void YApiHXMgvcAbJPAFHyMEcKdVYCbl(LmNgBsPyZshzCkvasaMebNljdBcg[] P_0, params LmNgBsPyZshzCkvasaMebNljdBcg[] P_1)
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
			LmNgBsPyZshzCkvasaMebNljdBcg lmNgBsPyZshzCkvasaMebNljdBcg = P_1[i];
			for (int j = 0; j < i; j++)
			{
				lmNgBsPyZshzCkvasaMebNljdBcg = WWQvcNjlnmGFnEjmbdAxPNYnpwzQA(lmNgBsPyZshzCkvasaMebNljdBcg, PyvsSLjTWRidLGANkmRSlPlqRQeq(grVkaYJUDjOpYfEnnCzkOTFwBrYeA(P_0[j], lmNgBsPyZshzCkvasaMebNljdBcg) / grVkaYJUDjOpYfEnnCzkOTFwBrYeA(P_0[j], P_0[j]), P_0[j]));
			}
			P_0[i] = lmNgBsPyZshzCkvasaMebNljdBcg;
		}
	}

	public static void jsgAwzsmcYkjwSCaUjbSKcyHMQECb(LmNgBsPyZshzCkvasaMebNljdBcg[] P_0, params LmNgBsPyZshzCkvasaMebNljdBcg[] P_1)
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
			LmNgBsPyZshzCkvasaMebNljdBcg lmNgBsPyZshzCkvasaMebNljdBcg = P_1[i];
			for (int j = 0; j < i; j++)
			{
				lmNgBsPyZshzCkvasaMebNljdBcg = WWQvcNjlnmGFnEjmbdAxPNYnpwzQA(lmNgBsPyZshzCkvasaMebNljdBcg, PyvsSLjTWRidLGANkmRSlPlqRQeq(grVkaYJUDjOpYfEnnCzkOTFwBrYeA(P_0[j], lmNgBsPyZshzCkvasaMebNljdBcg), P_0[j]));
			}
			lmNgBsPyZshzCkvasaMebNljdBcg.knuLiXhkxOFMywnIqHNEqsmDaDPn();
			P_0[i] = lmNgBsPyZshzCkvasaMebNljdBcg;
		}
	}

	[SpecialName]
	public static LmNgBsPyZshzCkvasaMebNljdBcg aqsJWXneZLAIoIbKhYQVxawqgBnS(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan + P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ + P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	[SpecialName]
	public static LmNgBsPyZshzCkvasaMebNljdBcg NwQXRZjwrsQWXGNDgBetNPxKBVQiA(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan * P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ * P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	[SpecialName]
	public static LmNgBsPyZshzCkvasaMebNljdBcg miBDzGooclEQKnBGlqKUQjjHeHGJA(LmNgBsPyZshzCkvasaMebNljdBcg P_0)
	{
		return P_0;
	}

	[SpecialName]
	public static LmNgBsPyZshzCkvasaMebNljdBcg WWQvcNjlnmGFnEjmbdAxPNYnpwzQA(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan - P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ - P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	[SpecialName]
	public static LmNgBsPyZshzCkvasaMebNljdBcg RWHZHYwhslJxAkZFcVEomdMpvvGE(LmNgBsPyZshzCkvasaMebNljdBcg P_0)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(0f - P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan, 0f - P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	[SpecialName]
	public static LmNgBsPyZshzCkvasaMebNljdBcg PyvsSLjTWRidLGANkmRSlPlqRQeq(float P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan * P_0, P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ * P_0);
	}

	[SpecialName]
	public static LmNgBsPyZshzCkvasaMebNljdBcg iUJTODSfzrameKTATxyufnntoLPW(LmNgBsPyZshzCkvasaMebNljdBcg P_0, float P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan * P_1, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ * P_1);
	}

	[SpecialName]
	public static LmNgBsPyZshzCkvasaMebNljdBcg mQcZHiZPugVuyUAHDHUcbPtnXtFDA(LmNgBsPyZshzCkvasaMebNljdBcg P_0, float P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan / P_1, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ / P_1);
	}

	[SpecialName]
	public static LmNgBsPyZshzCkvasaMebNljdBcg yuzurtViPVxCwrqwUCSOFhYrTUUBA(float P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0 / P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0 / P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	[SpecialName]
	public static LmNgBsPyZshzCkvasaMebNljdBcg osDyOxaKJUDcxvFIphMuAGoIsGw(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan / P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ / P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	[SpecialName]
	public static LmNgBsPyZshzCkvasaMebNljdBcg fIqHibcUyXIMDZYElFEhByJmWwWi(LmNgBsPyZshzCkvasaMebNljdBcg P_0, float P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan + P_1, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ + P_1);
	}

	[SpecialName]
	public static LmNgBsPyZshzCkvasaMebNljdBcg zLRYNBBwTytbTjWYLUBotEDFHbrB(float P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0 + P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0 + P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	[SpecialName]
	public static LmNgBsPyZshzCkvasaMebNljdBcg RuXzbaWhIwRcAsGbMVJCVFGcvPEi(LmNgBsPyZshzCkvasaMebNljdBcg P_0, float P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan - P_1, P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ - P_1);
	}

	[SpecialName]
	public static LmNgBsPyZshzCkvasaMebNljdBcg sTvsfxCjEwqyaYljEsyYEnXOxpPh(float P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		return new LmNgBsPyZshzCkvasaMebNljdBcg(P_0 - P_1.vrVgYmgBbVHIwxfAxrsAvmcTcSan, P_0 - P_1.KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	[SpecialName]
	public static bool HxvKPPmMrcIAWuxLnAauRYEUKqGW(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		return P_0.nsFBsybmrtBsbexiDhtFKvtpTIb(ref P_1);
	}

	[SpecialName]
	public static bool nveMTUJlTWUqLwiSVpQslHCEGGFZ(LmNgBsPyZshzCkvasaMebNljdBcg P_0, LmNgBsPyZshzCkvasaMebNljdBcg P_1)
	{
		return !P_0.nsFBsybmrtBsbexiDhtFKvtpTIb(ref P_1);
	}

	public string vyvJbFqmNdBimEsChVffgAGzAWvl()
	{
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", vrVgYmgBbVHIwxfAxrsAvmcTcSan, KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public string jzaGrcOkhNegveTVolmLXLaBOuVf(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", vrVgYmgBbVHIwxfAxrsAvmcTcSan.ToString(P_0, CultureInfo.CurrentCulture), KcKChCXgWJdizkLEnhrcaPdUfwmJ.ToString(P_0, CultureInfo.CurrentCulture));
	}

	public string uEBGYylYrzdwKAQIvwWjGXfDTMdr(IFormatProvider P_0)
	{
		return string.Format(P_0, "X:{0} Y:{1}", vrVgYmgBbVHIwxfAxrsAvmcTcSan, KcKChCXgWJdizkLEnhrcaPdUfwmJ);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			uEBGYylYrzdwKAQIvwWjGXfDTMdr(formatProvider);
		}
		return string.Format(formatProvider, "X:{0} Y:{1}", vrVgYmgBbVHIwxfAxrsAvmcTcSan.ToString(format, formatProvider), KcKChCXgWJdizkLEnhrcaPdUfwmJ.ToString(format, formatProvider));
	}

	string IFormattable.ToString(string format, IFormatProvider formatProvider)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ToString
		return this.ToString(format, formatProvider);
	}

	public int MNGEuabnEoCKfqfUhSLjIhMwBMBNA()
	{
		return (vrVgYmgBbVHIwxfAxrsAvmcTcSan.GetHashCode() * 397) ^ KcKChCXgWJdizkLEnhrcaPdUfwmJ.GetHashCode();
	}

	public bool nsFBsybmrtBsbexiDhtFKvtpTIb(ref LmNgBsPyZshzCkvasaMebNljdBcg P_0)
	{
		if (xjgRHLTmnwmrOnyIQwjZfnxgOFGe.nvMPdJoFZOtQUOTLtZnITxcKmjAG(P_0.vrVgYmgBbVHIwxfAxrsAvmcTcSan, vrVgYmgBbVHIwxfAxrsAvmcTcSan))
		{
			return xjgRHLTmnwmrOnyIQwjZfnxgOFGe.nvMPdJoFZOtQUOTLtZnITxcKmjAG(P_0.KcKChCXgWJdizkLEnhrcaPdUfwmJ, KcKChCXgWJdizkLEnhrcaPdUfwmJ);
		}
		return false;
	}

	public bool Equals(LmNgBsPyZshzCkvasaMebNljdBcg other)
	{
		return nsFBsybmrtBsbexiDhtFKvtpTIb(ref other);
	}

	bool IEquatable<LmNgBsPyZshzCkvasaMebNljdBcg>.Equals(LmNgBsPyZshzCkvasaMebNljdBcg other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool qQNEfahgsfFwRkRrAifucxqUpNTaA(object P_0)
	{
		if (!(P_0 is LmNgBsPyZshzCkvasaMebNljdBcg lmNgBsPyZshzCkvasaMebNljdBcg))
		{
			return false;
		}
		return nsFBsybmrtBsbexiDhtFKvtpTIb(ref lmNgBsPyZshzCkvasaMebNljdBcg);
	}
}
