using System;
using System.Globalization;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
internal struct mNdPDLRsRmwAzTIAhhGfLUmNaON : IEquatable<mNdPDLRsRmwAzTIAhhGfLUmNaON>, IFormattable
{
	public static readonly int CmUrWxzrDOOFaLLneGWJOPxhfZiC = Marshal.SizeOf(typeof(mNdPDLRsRmwAzTIAhhGfLUmNaON));

	public static readonly mNdPDLRsRmwAzTIAhhGfLUmNaON efXYRwJzdNWmZXhhkhunVKEPjxba = default(mNdPDLRsRmwAzTIAhhGfLUmNaON);

	public static readonly mNdPDLRsRmwAzTIAhhGfLUmNaON XnAUdvSkPKlJXJyQhWFGFjmzzvO = new mNdPDLRsRmwAzTIAhhGfLUmNaON(1f, 0f);

	public static readonly mNdPDLRsRmwAzTIAhhGfLUmNaON kvSuiPrMROAtfMlnZGJGKBBTQhf = new mNdPDLRsRmwAzTIAhhGfLUmNaON(0f, 1f);

	public static readonly mNdPDLRsRmwAzTIAhhGfLUmNaON QPKvksdIjLCJunXjXNaBmtbIJWx = new mNdPDLRsRmwAzTIAhhGfLUmNaON(1f, 1f);

	public float wrxROzSuvTCIlUkzpetQcPCiLlim;

	public float OmnFwaftRtPzAJrBzVkXEvVueKV;

	public bool IsNormalized => AQYemuIPagqJGSVHXgWSGPEYkvxe.ChRWvvhrkqASESlbZqTGWcStETQ(wrxROzSuvTCIlUkzpetQcPCiLlim * wrxROzSuvTCIlUkzpetQcPCiLlim + OmnFwaftRtPzAJrBzVkXEvVueKV * OmnFwaftRtPzAJrBzVkXEvVueKV);

	public bool IsZero
	{
		get
		{
			if (wrxROzSuvTCIlUkzpetQcPCiLlim == 0f)
			{
				return OmnFwaftRtPzAJrBzVkXEvVueKV == 0f;
			}
			return false;
		}
	}

	public float this[int index]
	{
		get
		{
			switch (index)
			{
			case 0:
				return wrxROzSuvTCIlUkzpetQcPCiLlim;
			case 1:
				return OmnFwaftRtPzAJrBzVkXEvVueKV;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
		set
		{
			switch (index)
			{
			case 0:
				wrxROzSuvTCIlUkzpetQcPCiLlim = value;
				break;
			case 1:
				OmnFwaftRtPzAJrBzVkXEvVueKV = value;
				break;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
	}

	public mNdPDLRsRmwAzTIAhhGfLUmNaON(float value)
	{
		wrxROzSuvTCIlUkzpetQcPCiLlim = value;
		OmnFwaftRtPzAJrBzVkXEvVueKV = value;
	}

	public mNdPDLRsRmwAzTIAhhGfLUmNaON(float x, float y)
	{
		wrxROzSuvTCIlUkzpetQcPCiLlim = x;
		OmnFwaftRtPzAJrBzVkXEvVueKV = y;
	}

	public mNdPDLRsRmwAzTIAhhGfLUmNaON(float[] values)
	{
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		if (values.Length != 2)
		{
			throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
		}
		wrxROzSuvTCIlUkzpetQcPCiLlim = values[0];
		OmnFwaftRtPzAJrBzVkXEvVueKV = values[1];
	}

	public float DEktClpMPdUrZZBcVpqTnEduNAK()
	{
		return (float)Math.Sqrt(wrxROzSuvTCIlUkzpetQcPCiLlim * wrxROzSuvTCIlUkzpetQcPCiLlim + OmnFwaftRtPzAJrBzVkXEvVueKV * OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public float BVxxNfJthagvRihCOiFOHhBMRVQ()
	{
		return wrxROzSuvTCIlUkzpetQcPCiLlim * wrxROzSuvTCIlUkzpetQcPCiLlim + OmnFwaftRtPzAJrBzVkXEvVueKV * OmnFwaftRtPzAJrBzVkXEvVueKV;
	}

	public void RThrINUEZBnjyIDZKnjraLDfYcq()
	{
		float num = DEktClpMPdUrZZBcVpqTnEduNAK();
		if (!AQYemuIPagqJGSVHXgWSGPEYkvxe.OEgAmAEgpnUgrOBkmkfqaDFucRFu(num))
		{
			float num2 = 1f / num;
			wrxROzSuvTCIlUkzpetQcPCiLlim *= num2;
			OmnFwaftRtPzAJrBzVkXEvVueKV *= num2;
		}
	}

	public float[] caySsIWMHCfMSHxKkxitHnDGPGf()
	{
		return new float[2] { wrxROzSuvTCIlUkzpetQcPCiLlim, OmnFwaftRtPzAJrBzVkXEvVueKV };
	}

	public static void rpnlSvitBVRCTsadCjlQJJORRhi(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_2)
	{
		P_2 = new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim + P_1.wrxROzSuvTCIlUkzpetQcPCiLlim, P_0.OmnFwaftRtPzAJrBzVkXEvVueKV + P_1.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON rpnlSvitBVRCTsadCjlQJJORRhi(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim + P_1.wrxROzSuvTCIlUkzpetQcPCiLlim, P_0.OmnFwaftRtPzAJrBzVkXEvVueKV + P_1.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static void rpnlSvitBVRCTsadCjlQJJORRhi(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref float P_1, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_2)
	{
		P_2 = new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim + P_1, P_0.OmnFwaftRtPzAJrBzVkXEvVueKV + P_1);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON rpnlSvitBVRCTsadCjlQJJORRhi(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, float P_1)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim + P_1, P_0.OmnFwaftRtPzAJrBzVkXEvVueKV + P_1);
	}

	public static void ODxxCjoRDnVGkaoIKBFObtmLGQa(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_2)
	{
		P_2 = new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim - P_1.wrxROzSuvTCIlUkzpetQcPCiLlim, P_0.OmnFwaftRtPzAJrBzVkXEvVueKV - P_1.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON ODxxCjoRDnVGkaoIKBFObtmLGQa(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim - P_1.wrxROzSuvTCIlUkzpetQcPCiLlim, P_0.OmnFwaftRtPzAJrBzVkXEvVueKV - P_1.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static void ODxxCjoRDnVGkaoIKBFObtmLGQa(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref float P_1, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_2)
	{
		P_2 = new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim - P_1, P_0.OmnFwaftRtPzAJrBzVkXEvVueKV - P_1);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON ODxxCjoRDnVGkaoIKBFObtmLGQa(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, float P_1)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim - P_1, P_0.OmnFwaftRtPzAJrBzVkXEvVueKV - P_1);
	}

	public static void ODxxCjoRDnVGkaoIKBFObtmLGQa(ref float P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_2)
	{
		P_2 = new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0 - P_1.wrxROzSuvTCIlUkzpetQcPCiLlim, P_0 - P_1.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON ODxxCjoRDnVGkaoIKBFObtmLGQa(float P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0 - P_1.wrxROzSuvTCIlUkzpetQcPCiLlim, P_0 - P_1.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static void qZZSVZLearZpVoUNAtJhMNiCeQtJ(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, float P_1, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_2)
	{
		P_2 = new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim * P_1, P_0.OmnFwaftRtPzAJrBzVkXEvVueKV * P_1);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON qZZSVZLearZpVoUNAtJhMNiCeQtJ(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, float P_1)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim * P_1, P_0.OmnFwaftRtPzAJrBzVkXEvVueKV * P_1);
	}

	public static void qZZSVZLearZpVoUNAtJhMNiCeQtJ(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_2)
	{
		P_2 = new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim * P_1.wrxROzSuvTCIlUkzpetQcPCiLlim, P_0.OmnFwaftRtPzAJrBzVkXEvVueKV * P_1.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON qZZSVZLearZpVoUNAtJhMNiCeQtJ(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim * P_1.wrxROzSuvTCIlUkzpetQcPCiLlim, P_0.OmnFwaftRtPzAJrBzVkXEvVueKV * P_1.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static void adiapGFiQBppehPzIoFaIyJjRCI(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, float P_1, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_2)
	{
		P_2 = new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim / P_1, P_0.OmnFwaftRtPzAJrBzVkXEvVueKV / P_1);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON adiapGFiQBppehPzIoFaIyJjRCI(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, float P_1)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim / P_1, P_0.OmnFwaftRtPzAJrBzVkXEvVueKV / P_1);
	}

	public static void adiapGFiQBppehPzIoFaIyJjRCI(float P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_2)
	{
		P_2 = new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0 / P_1.wrxROzSuvTCIlUkzpetQcPCiLlim, P_0 / P_1.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON adiapGFiQBppehPzIoFaIyJjRCI(float P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0 / P_1.wrxROzSuvTCIlUkzpetQcPCiLlim, P_0 / P_1.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static void LybemKedbWCmcMZEdInYFaOBHSA(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_1)
	{
		P_1 = new mNdPDLRsRmwAzTIAhhGfLUmNaON(0f - P_0.wrxROzSuvTCIlUkzpetQcPCiLlim, 0f - P_0.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON LybemKedbWCmcMZEdInYFaOBHSA(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(0f - P_0.wrxROzSuvTCIlUkzpetQcPCiLlim, 0f - P_0.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static void vmhYXRTvVpyxZhghZPUJercKODs(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_2, float P_3, float P_4, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_5)
	{
		P_5 = new mNdPDLRsRmwAzTIAhhGfLUmNaON(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim + P_3 * (P_1.wrxROzSuvTCIlUkzpetQcPCiLlim - P_0.wrxROzSuvTCIlUkzpetQcPCiLlim) + P_4 * (P_2.wrxROzSuvTCIlUkzpetQcPCiLlim - P_0.wrxROzSuvTCIlUkzpetQcPCiLlim), P_0.OmnFwaftRtPzAJrBzVkXEvVueKV + P_3 * (P_1.OmnFwaftRtPzAJrBzVkXEvVueKV - P_0.OmnFwaftRtPzAJrBzVkXEvVueKV) + P_4 * (P_2.OmnFwaftRtPzAJrBzVkXEvVueKV - P_0.OmnFwaftRtPzAJrBzVkXEvVueKV));
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON vmhYXRTvVpyxZhghZPUJercKODs(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, mNdPDLRsRmwAzTIAhhGfLUmNaON P_2, float P_3, float P_4)
	{
		vmhYXRTvVpyxZhghZPUJercKODs(ref P_0, ref P_1, ref P_2, P_3, P_4, out var result);
		return result;
	}

	public static void fjwpwrnVwedUFkeyAHxVKlzpDQR(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_2, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_3)
	{
		float num = P_0.wrxROzSuvTCIlUkzpetQcPCiLlim;
		num = ((num > P_2.wrxROzSuvTCIlUkzpetQcPCiLlim) ? P_2.wrxROzSuvTCIlUkzpetQcPCiLlim : num);
		num = ((num < P_1.wrxROzSuvTCIlUkzpetQcPCiLlim) ? P_1.wrxROzSuvTCIlUkzpetQcPCiLlim : num);
		float omnFwaftRtPzAJrBzVkXEvVueKV = P_0.OmnFwaftRtPzAJrBzVkXEvVueKV;
		omnFwaftRtPzAJrBzVkXEvVueKV = ((omnFwaftRtPzAJrBzVkXEvVueKV > P_2.OmnFwaftRtPzAJrBzVkXEvVueKV) ? P_2.OmnFwaftRtPzAJrBzVkXEvVueKV : omnFwaftRtPzAJrBzVkXEvVueKV);
		omnFwaftRtPzAJrBzVkXEvVueKV = ((omnFwaftRtPzAJrBzVkXEvVueKV < P_1.OmnFwaftRtPzAJrBzVkXEvVueKV) ? P_1.OmnFwaftRtPzAJrBzVkXEvVueKV : omnFwaftRtPzAJrBzVkXEvVueKV);
		P_3 = new mNdPDLRsRmwAzTIAhhGfLUmNaON(num, omnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON fjwpwrnVwedUFkeyAHxVKlzpDQR(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, mNdPDLRsRmwAzTIAhhGfLUmNaON P_2)
	{
		fjwpwrnVwedUFkeyAHxVKlzpDQR(ref P_0, ref P_1, ref P_2, out var result);
		return result;
	}

	public void tQgYucIYxJMtNYfPPcJZcLHtnuBc()
	{
		wrxROzSuvTCIlUkzpetQcPCiLlim = ((wrxROzSuvTCIlUkzpetQcPCiLlim < 0f) ? 0f : ((wrxROzSuvTCIlUkzpetQcPCiLlim > 1f) ? 1f : wrxROzSuvTCIlUkzpetQcPCiLlim));
		OmnFwaftRtPzAJrBzVkXEvVueKV = ((OmnFwaftRtPzAJrBzVkXEvVueKV < 0f) ? 0f : ((OmnFwaftRtPzAJrBzVkXEvVueKV > 1f) ? 1f : OmnFwaftRtPzAJrBzVkXEvVueKV));
	}

	public static void wjBYPiaibCulYtyoKiZFeWuXkHm(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, out float P_2)
	{
		float num = P_0.wrxROzSuvTCIlUkzpetQcPCiLlim - P_1.wrxROzSuvTCIlUkzpetQcPCiLlim;
		float num2 = P_0.OmnFwaftRtPzAJrBzVkXEvVueKV - P_1.OmnFwaftRtPzAJrBzVkXEvVueKV;
		P_2 = (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float wjBYPiaibCulYtyoKiZFeWuXkHm(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1)
	{
		float num = P_0.wrxROzSuvTCIlUkzpetQcPCiLlim - P_1.wrxROzSuvTCIlUkzpetQcPCiLlim;
		float num2 = P_0.OmnFwaftRtPzAJrBzVkXEvVueKV - P_1.OmnFwaftRtPzAJrBzVkXEvVueKV;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static void NwCnZwqHyJPVPiKNbNcPncYMNXh(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, out float P_2)
	{
		float num = P_0.wrxROzSuvTCIlUkzpetQcPCiLlim - P_1.wrxROzSuvTCIlUkzpetQcPCiLlim;
		float num2 = P_0.OmnFwaftRtPzAJrBzVkXEvVueKV - P_1.OmnFwaftRtPzAJrBzVkXEvVueKV;
		P_2 = num * num + num2 * num2;
	}

	public static float NwCnZwqHyJPVPiKNbNcPncYMNXh(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1)
	{
		float num = P_0.wrxROzSuvTCIlUkzpetQcPCiLlim - P_1.wrxROzSuvTCIlUkzpetQcPCiLlim;
		float num2 = P_0.OmnFwaftRtPzAJrBzVkXEvVueKV - P_1.OmnFwaftRtPzAJrBzVkXEvVueKV;
		return num * num + num2 * num2;
	}

	public static void TReZkJqIgIOOXbOlKNZXAsNVxiK(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, out float P_2)
	{
		P_2 = P_0.wrxROzSuvTCIlUkzpetQcPCiLlim * P_1.wrxROzSuvTCIlUkzpetQcPCiLlim + P_0.OmnFwaftRtPzAJrBzVkXEvVueKV * P_1.OmnFwaftRtPzAJrBzVkXEvVueKV;
	}

	public static float TReZkJqIgIOOXbOlKNZXAsNVxiK(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1)
	{
		return P_0.wrxROzSuvTCIlUkzpetQcPCiLlim * P_1.wrxROzSuvTCIlUkzpetQcPCiLlim + P_0.OmnFwaftRtPzAJrBzVkXEvVueKV * P_1.OmnFwaftRtPzAJrBzVkXEvVueKV;
	}

	public static void RThrINUEZBnjyIDZKnjraLDfYcq(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_1)
	{
		P_1 = P_0;
		P_1.RThrINUEZBnjyIDZKnjraLDfYcq();
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON RThrINUEZBnjyIDZKnjraLDfYcq(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0)
	{
		P_0.RThrINUEZBnjyIDZKnjraLDfYcq();
		return P_0;
	}

	public static void vAuwCiJrkNoerHrElvUAeCWwDleD(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, float P_2, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_3)
	{
		P_3.wrxROzSuvTCIlUkzpetQcPCiLlim = AQYemuIPagqJGSVHXgWSGPEYkvxe.vAuwCiJrkNoerHrElvUAeCWwDleD(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim, P_1.wrxROzSuvTCIlUkzpetQcPCiLlim, P_2);
		P_3.OmnFwaftRtPzAJrBzVkXEvVueKV = AQYemuIPagqJGSVHXgWSGPEYkvxe.vAuwCiJrkNoerHrElvUAeCWwDleD(P_0.OmnFwaftRtPzAJrBzVkXEvVueKV, P_1.OmnFwaftRtPzAJrBzVkXEvVueKV, P_2);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON vAuwCiJrkNoerHrElvUAeCWwDleD(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, float P_2)
	{
		vAuwCiJrkNoerHrElvUAeCWwDleD(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void barZLFxjxgDZkrtrLqFDHyJCBWW(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, float P_2, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_3)
	{
		P_2 = AQYemuIPagqJGSVHXgWSGPEYkvxe.barZLFxjxgDZkrtrLqFDHyJCBWW(P_2);
		vAuwCiJrkNoerHrElvUAeCWwDleD(ref P_0, ref P_1, P_2, out P_3);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON barZLFxjxgDZkrtrLqFDHyJCBWW(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, float P_2)
	{
		barZLFxjxgDZkrtrLqFDHyJCBWW(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void nOYAbKiJiGgYTmRDTQnCXzIywaGq(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_2, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_3, float P_4, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + P_4;
		float num6 = num2 - num;
		P_5.wrxROzSuvTCIlUkzpetQcPCiLlim = P_0.wrxROzSuvTCIlUkzpetQcPCiLlim * num3 + P_2.wrxROzSuvTCIlUkzpetQcPCiLlim * num4 + P_1.wrxROzSuvTCIlUkzpetQcPCiLlim * num5 + P_3.wrxROzSuvTCIlUkzpetQcPCiLlim * num6;
		P_5.OmnFwaftRtPzAJrBzVkXEvVueKV = P_0.OmnFwaftRtPzAJrBzVkXEvVueKV * num3 + P_2.OmnFwaftRtPzAJrBzVkXEvVueKV * num4 + P_1.OmnFwaftRtPzAJrBzVkXEvVueKV * num5 + P_3.OmnFwaftRtPzAJrBzVkXEvVueKV * num6;
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON nOYAbKiJiGgYTmRDTQnCXzIywaGq(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, mNdPDLRsRmwAzTIAhhGfLUmNaON P_2, mNdPDLRsRmwAzTIAhhGfLUmNaON P_3, float P_4)
	{
		nOYAbKiJiGgYTmRDTQnCXzIywaGq(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void eskapJgzWuDNogSUJUyuNKqbKuql(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_2, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_3, float P_4, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		P_5.wrxROzSuvTCIlUkzpetQcPCiLlim = 0.5f * (2f * P_1.wrxROzSuvTCIlUkzpetQcPCiLlim + (0f - P_0.wrxROzSuvTCIlUkzpetQcPCiLlim + P_2.wrxROzSuvTCIlUkzpetQcPCiLlim) * P_4 + (2f * P_0.wrxROzSuvTCIlUkzpetQcPCiLlim - 5f * P_1.wrxROzSuvTCIlUkzpetQcPCiLlim + 4f * P_2.wrxROzSuvTCIlUkzpetQcPCiLlim - P_3.wrxROzSuvTCIlUkzpetQcPCiLlim) * num + (0f - P_0.wrxROzSuvTCIlUkzpetQcPCiLlim + 3f * P_1.wrxROzSuvTCIlUkzpetQcPCiLlim - 3f * P_2.wrxROzSuvTCIlUkzpetQcPCiLlim + P_3.wrxROzSuvTCIlUkzpetQcPCiLlim) * num2);
		P_5.OmnFwaftRtPzAJrBzVkXEvVueKV = 0.5f * (2f * P_1.OmnFwaftRtPzAJrBzVkXEvVueKV + (0f - P_0.OmnFwaftRtPzAJrBzVkXEvVueKV + P_2.OmnFwaftRtPzAJrBzVkXEvVueKV) * P_4 + (2f * P_0.OmnFwaftRtPzAJrBzVkXEvVueKV - 5f * P_1.OmnFwaftRtPzAJrBzVkXEvVueKV + 4f * P_2.OmnFwaftRtPzAJrBzVkXEvVueKV - P_3.OmnFwaftRtPzAJrBzVkXEvVueKV) * num + (0f - P_0.OmnFwaftRtPzAJrBzVkXEvVueKV + 3f * P_1.OmnFwaftRtPzAJrBzVkXEvVueKV - 3f * P_2.OmnFwaftRtPzAJrBzVkXEvVueKV + P_3.OmnFwaftRtPzAJrBzVkXEvVueKV) * num2);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON eskapJgzWuDNogSUJUyuNKqbKuql(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, mNdPDLRsRmwAzTIAhhGfLUmNaON P_2, mNdPDLRsRmwAzTIAhhGfLUmNaON P_3, float P_4)
	{
		eskapJgzWuDNogSUJUyuNKqbKuql(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void qbdZbsqWfSImlgZRMrHQcJxVvjv(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_2)
	{
		P_2.wrxROzSuvTCIlUkzpetQcPCiLlim = ((P_0.wrxROzSuvTCIlUkzpetQcPCiLlim > P_1.wrxROzSuvTCIlUkzpetQcPCiLlim) ? P_0.wrxROzSuvTCIlUkzpetQcPCiLlim : P_1.wrxROzSuvTCIlUkzpetQcPCiLlim);
		P_2.OmnFwaftRtPzAJrBzVkXEvVueKV = ((P_0.OmnFwaftRtPzAJrBzVkXEvVueKV > P_1.OmnFwaftRtPzAJrBzVkXEvVueKV) ? P_0.OmnFwaftRtPzAJrBzVkXEvVueKV : P_1.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON qbdZbsqWfSImlgZRMrHQcJxVvjv(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1)
	{
		qbdZbsqWfSImlgZRMrHQcJxVvjv(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void lAziIomDMTdCNpXGgqeiCzdpHbD(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_2)
	{
		P_2.wrxROzSuvTCIlUkzpetQcPCiLlim = ((P_0.wrxROzSuvTCIlUkzpetQcPCiLlim < P_1.wrxROzSuvTCIlUkzpetQcPCiLlim) ? P_0.wrxROzSuvTCIlUkzpetQcPCiLlim : P_1.wrxROzSuvTCIlUkzpetQcPCiLlim);
		P_2.OmnFwaftRtPzAJrBzVkXEvVueKV = ((P_0.OmnFwaftRtPzAJrBzVkXEvVueKV < P_1.OmnFwaftRtPzAJrBzVkXEvVueKV) ? P_0.OmnFwaftRtPzAJrBzVkXEvVueKV : P_1.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON lAziIomDMTdCNpXGgqeiCzdpHbD(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1)
	{
		lAziIomDMTdCNpXGgqeiCzdpHbD(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void TDfASmqIcpTtwYHmJaVutPEoYIQ(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_1, out mNdPDLRsRmwAzTIAhhGfLUmNaON P_2)
	{
		float num = P_0.wrxROzSuvTCIlUkzpetQcPCiLlim * P_1.wrxROzSuvTCIlUkzpetQcPCiLlim + P_0.OmnFwaftRtPzAJrBzVkXEvVueKV * P_1.OmnFwaftRtPzAJrBzVkXEvVueKV;
		P_2.wrxROzSuvTCIlUkzpetQcPCiLlim = P_0.wrxROzSuvTCIlUkzpetQcPCiLlim - 2f * num * P_1.wrxROzSuvTCIlUkzpetQcPCiLlim;
		P_2.OmnFwaftRtPzAJrBzVkXEvVueKV = P_0.OmnFwaftRtPzAJrBzVkXEvVueKV - 2f * num * P_1.OmnFwaftRtPzAJrBzVkXEvVueKV;
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON TDfASmqIcpTtwYHmJaVutPEoYIQ(mNdPDLRsRmwAzTIAhhGfLUmNaON P_0, mNdPDLRsRmwAzTIAhhGfLUmNaON P_1)
	{
		TDfASmqIcpTtwYHmJaVutPEoYIQ(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void AlXrolmUtZCiUXJKwDzgPNAHykA(mNdPDLRsRmwAzTIAhhGfLUmNaON[] P_0, params mNdPDLRsRmwAzTIAhhGfLUmNaON[] P_1)
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
			mNdPDLRsRmwAzTIAhhGfLUmNaON mNdPDLRsRmwAzTIAhhGfLUmNaON2 = P_1[i];
			for (int j = 0; j < i; j++)
			{
				mNdPDLRsRmwAzTIAhhGfLUmNaON2 -= TReZkJqIgIOOXbOlKNZXAsNVxiK(P_0[j], mNdPDLRsRmwAzTIAhhGfLUmNaON2) / TReZkJqIgIOOXbOlKNZXAsNVxiK(P_0[j], P_0[j]) * P_0[j];
			}
			P_0[i] = mNdPDLRsRmwAzTIAhhGfLUmNaON2;
		}
	}

	public static void TvutMlRVDJTxIiylALJeoLcBHOF(mNdPDLRsRmwAzTIAhhGfLUmNaON[] P_0, params mNdPDLRsRmwAzTIAhhGfLUmNaON[] P_1)
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
			mNdPDLRsRmwAzTIAhhGfLUmNaON mNdPDLRsRmwAzTIAhhGfLUmNaON2 = P_1[i];
			for (int j = 0; j < i; j++)
			{
				mNdPDLRsRmwAzTIAhhGfLUmNaON2 -= TReZkJqIgIOOXbOlKNZXAsNVxiK(P_0[j], mNdPDLRsRmwAzTIAhhGfLUmNaON2) * P_0[j];
			}
			mNdPDLRsRmwAzTIAhhGfLUmNaON2.RThrINUEZBnjyIDZKnjraLDfYcq();
			P_0[i] = mNdPDLRsRmwAzTIAhhGfLUmNaON2;
		}
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON operator +(mNdPDLRsRmwAzTIAhhGfLUmNaON left, mNdPDLRsRmwAzTIAhhGfLUmNaON right)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(left.wrxROzSuvTCIlUkzpetQcPCiLlim + right.wrxROzSuvTCIlUkzpetQcPCiLlim, left.OmnFwaftRtPzAJrBzVkXEvVueKV + right.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON operator *(mNdPDLRsRmwAzTIAhhGfLUmNaON left, mNdPDLRsRmwAzTIAhhGfLUmNaON right)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(left.wrxROzSuvTCIlUkzpetQcPCiLlim * right.wrxROzSuvTCIlUkzpetQcPCiLlim, left.OmnFwaftRtPzAJrBzVkXEvVueKV * right.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON operator +(mNdPDLRsRmwAzTIAhhGfLUmNaON value)
	{
		return value;
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON operator -(mNdPDLRsRmwAzTIAhhGfLUmNaON left, mNdPDLRsRmwAzTIAhhGfLUmNaON right)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(left.wrxROzSuvTCIlUkzpetQcPCiLlim - right.wrxROzSuvTCIlUkzpetQcPCiLlim, left.OmnFwaftRtPzAJrBzVkXEvVueKV - right.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON operator -(mNdPDLRsRmwAzTIAhhGfLUmNaON value)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(0f - value.wrxROzSuvTCIlUkzpetQcPCiLlim, 0f - value.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON operator *(float scale, mNdPDLRsRmwAzTIAhhGfLUmNaON value)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(value.wrxROzSuvTCIlUkzpetQcPCiLlim * scale, value.OmnFwaftRtPzAJrBzVkXEvVueKV * scale);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON operator *(mNdPDLRsRmwAzTIAhhGfLUmNaON value, float scale)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(value.wrxROzSuvTCIlUkzpetQcPCiLlim * scale, value.OmnFwaftRtPzAJrBzVkXEvVueKV * scale);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON operator /(mNdPDLRsRmwAzTIAhhGfLUmNaON value, float scale)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(value.wrxROzSuvTCIlUkzpetQcPCiLlim / scale, value.OmnFwaftRtPzAJrBzVkXEvVueKV / scale);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON operator /(float scale, mNdPDLRsRmwAzTIAhhGfLUmNaON value)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(scale / value.wrxROzSuvTCIlUkzpetQcPCiLlim, scale / value.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON operator /(mNdPDLRsRmwAzTIAhhGfLUmNaON value, mNdPDLRsRmwAzTIAhhGfLUmNaON scale)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(value.wrxROzSuvTCIlUkzpetQcPCiLlim / scale.wrxROzSuvTCIlUkzpetQcPCiLlim, value.OmnFwaftRtPzAJrBzVkXEvVueKV / scale.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON operator +(mNdPDLRsRmwAzTIAhhGfLUmNaON value, float scalar)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(value.wrxROzSuvTCIlUkzpetQcPCiLlim + scalar, value.OmnFwaftRtPzAJrBzVkXEvVueKV + scalar);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON operator +(float scalar, mNdPDLRsRmwAzTIAhhGfLUmNaON value)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(scalar + value.wrxROzSuvTCIlUkzpetQcPCiLlim, scalar + value.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON operator -(mNdPDLRsRmwAzTIAhhGfLUmNaON value, float scalar)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(value.wrxROzSuvTCIlUkzpetQcPCiLlim - scalar, value.OmnFwaftRtPzAJrBzVkXEvVueKV - scalar);
	}

	public static mNdPDLRsRmwAzTIAhhGfLUmNaON operator -(float scalar, mNdPDLRsRmwAzTIAhhGfLUmNaON value)
	{
		return new mNdPDLRsRmwAzTIAhhGfLUmNaON(scalar - value.wrxROzSuvTCIlUkzpetQcPCiLlim, scalar - value.OmnFwaftRtPzAJrBzVkXEvVueKV);
	}

	public static bool operator ==(mNdPDLRsRmwAzTIAhhGfLUmNaON left, mNdPDLRsRmwAzTIAhhGfLUmNaON right)
	{
		return left.uxGAirIytVqwSOxUUxSKDfDVCZe(ref right);
	}

	public static bool operator !=(mNdPDLRsRmwAzTIAhhGfLUmNaON left, mNdPDLRsRmwAzTIAhhGfLUmNaON right)
	{
		return !left.uxGAirIytVqwSOxUUxSKDfDVCZe(ref right);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", new object[2] { wrxROzSuvTCIlUkzpetQcPCiLlim, OmnFwaftRtPzAJrBzVkXEvVueKV });
	}

	public string xTkYeHqBZWJlRSAWGtjqDfOHERd(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", new object[2]
		{
			wrxROzSuvTCIlUkzpetQcPCiLlim.ToString(P_0, CultureInfo.CurrentCulture),
			OmnFwaftRtPzAJrBzVkXEvVueKV.ToString(P_0, CultureInfo.CurrentCulture)
		});
	}

	public string xTkYeHqBZWJlRSAWGtjqDfOHERd(IFormatProvider P_0)
	{
		return string.Format(P_0, "X:{0} Y:{1}", new object[2] { wrxROzSuvTCIlUkzpetQcPCiLlim, OmnFwaftRtPzAJrBzVkXEvVueKV });
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			xTkYeHqBZWJlRSAWGtjqDfOHERd(formatProvider);
		}
		return string.Format(formatProvider, "X:{0} Y:{1}", new object[2]
		{
			wrxROzSuvTCIlUkzpetQcPCiLlim.ToString(format, formatProvider),
			OmnFwaftRtPzAJrBzVkXEvVueKV.ToString(format, formatProvider)
		});
	}

	public override int GetHashCode()
	{
		return (wrxROzSuvTCIlUkzpetQcPCiLlim.GetHashCode() * 397) ^ OmnFwaftRtPzAJrBzVkXEvVueKV.GetHashCode();
	}

	public bool uxGAirIytVqwSOxUUxSKDfDVCZe(ref mNdPDLRsRmwAzTIAhhGfLUmNaON P_0)
	{
		if (AQYemuIPagqJGSVHXgWSGPEYkvxe.isbzmUuxrYpgwjlrRoYEbyBSjdY(P_0.wrxROzSuvTCIlUkzpetQcPCiLlim, wrxROzSuvTCIlUkzpetQcPCiLlim))
		{
			return AQYemuIPagqJGSVHXgWSGPEYkvxe.isbzmUuxrYpgwjlrRoYEbyBSjdY(P_0.OmnFwaftRtPzAJrBzVkXEvVueKV, OmnFwaftRtPzAJrBzVkXEvVueKV);
		}
		return false;
	}

	public bool Equals(mNdPDLRsRmwAzTIAhhGfLUmNaON other)
	{
		return uxGAirIytVqwSOxUUxSKDfDVCZe(ref other);
	}

	public override bool Equals(object value)
	{
		if (!(value is mNdPDLRsRmwAzTIAhhGfLUmNaON mNdPDLRsRmwAzTIAhhGfLUmNaON2))
		{
			return false;
		}
		return uxGAirIytVqwSOxUUxSKDfDVCZe(ref mNdPDLRsRmwAzTIAhhGfLUmNaON2);
	}
}
