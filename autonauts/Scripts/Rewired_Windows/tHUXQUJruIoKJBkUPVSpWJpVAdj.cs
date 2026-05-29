using System;
using System.Globalization;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
internal struct tHUXQUJruIoKJBkUPVSpWJpVAdj : IEquatable<tHUXQUJruIoKJBkUPVSpWJpVAdj>, IFormattable
{
	public static readonly int ByzSfspgdqdOOLYHWDlTPuSrZJK = Marshal.SizeOf(typeof(tHUXQUJruIoKJBkUPVSpWJpVAdj));

	public static readonly tHUXQUJruIoKJBkUPVSpWJpVAdj xliDcbLfHtfKtBNZMWznSYxHsjZ = default(tHUXQUJruIoKJBkUPVSpWJpVAdj);

	public static readonly tHUXQUJruIoKJBkUPVSpWJpVAdj GOljOuSNlmfXlJleTGAQSmVxjDm = new tHUXQUJruIoKJBkUPVSpWJpVAdj(1f, 0f);

	public static readonly tHUXQUJruIoKJBkUPVSpWJpVAdj tCpauCghlinwPfMNnBLCyRqFpIXJ = new tHUXQUJruIoKJBkUPVSpWJpVAdj(0f, 1f);

	public static readonly tHUXQUJruIoKJBkUPVSpWJpVAdj XJdoapjLZpbCYfGLpJtZvPQIEKB = new tHUXQUJruIoKJBkUPVSpWJpVAdj(1f, 1f);

	public float xEUKPyQaTfqoROGHJowSWeletXA;

	public float VeUXJbtopZnzuPExHBOZDuueBov;

	public bool IsNormalized
	{
		get
		{
			return HKbcmtHxGOxqoUgzpNGAGbrWhWL.JvujdmhWKIkpkISLxpCQRddlJRg(xEUKPyQaTfqoROGHJowSWeletXA * xEUKPyQaTfqoROGHJowSWeletXA + VeUXJbtopZnzuPExHBOZDuueBov * VeUXJbtopZnzuPExHBOZDuueBov);
		}
	}

	public bool IsZero
	{
		get
		{
			if (xEUKPyQaTfqoROGHJowSWeletXA == 0f)
			{
				return VeUXJbtopZnzuPExHBOZDuueBov == 0f;
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
				return xEUKPyQaTfqoROGHJowSWeletXA;
			case 1:
				return VeUXJbtopZnzuPExHBOZDuueBov;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
		set
		{
			switch (index)
			{
			case 0:
				xEUKPyQaTfqoROGHJowSWeletXA = value;
				break;
			case 1:
				VeUXJbtopZnzuPExHBOZDuueBov = value;
				break;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
	}

	public tHUXQUJruIoKJBkUPVSpWJpVAdj(float value)
	{
		xEUKPyQaTfqoROGHJowSWeletXA = value;
		VeUXJbtopZnzuPExHBOZDuueBov = value;
	}

	public tHUXQUJruIoKJBkUPVSpWJpVAdj(float x, float y)
	{
		xEUKPyQaTfqoROGHJowSWeletXA = x;
		VeUXJbtopZnzuPExHBOZDuueBov = y;
	}

	public tHUXQUJruIoKJBkUPVSpWJpVAdj(float[] values)
	{
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		if (values.Length != 2)
		{
			throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
		}
		xEUKPyQaTfqoROGHJowSWeletXA = values[0];
		VeUXJbtopZnzuPExHBOZDuueBov = values[1];
	}

	public float SlBxfwphnVHsjNDErEqTEkWknTm()
	{
		return (float)Math.Sqrt(xEUKPyQaTfqoROGHJowSWeletXA * xEUKPyQaTfqoROGHJowSWeletXA + VeUXJbtopZnzuPExHBOZDuueBov * VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public float WNElnkJJRUYYhmXJwVfUUdgMPVs()
	{
		return xEUKPyQaTfqoROGHJowSWeletXA * xEUKPyQaTfqoROGHJowSWeletXA + VeUXJbtopZnzuPExHBOZDuueBov * VeUXJbtopZnzuPExHBOZDuueBov;
	}

	public void OTYhpSOKetYDGMDxuYojrJiljEC()
	{
		float num = SlBxfwphnVHsjNDErEqTEkWknTm();
		if (!HKbcmtHxGOxqoUgzpNGAGbrWhWL.DyBcjFcOBNKYVXmUGeScItqmHZr(num))
		{
			float num2 = 1f / num;
			xEUKPyQaTfqoROGHJowSWeletXA *= num2;
			VeUXJbtopZnzuPExHBOZDuueBov *= num2;
		}
	}

	public float[] tTViZFYnpiaVcBwmEzajWGeYCSL()
	{
		return new float[2] { xEUKPyQaTfqoROGHJowSWeletXA, VeUXJbtopZnzuPExHBOZDuueBov };
	}

	public static void giSjlBupDtcdbDcEsZwIQvmJBPCc(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_2)
	{
		P_2 = new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0.xEUKPyQaTfqoROGHJowSWeletXA + P_1.xEUKPyQaTfqoROGHJowSWeletXA, P_0.VeUXJbtopZnzuPExHBOZDuueBov + P_1.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj giSjlBupDtcdbDcEsZwIQvmJBPCc(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0.xEUKPyQaTfqoROGHJowSWeletXA + P_1.xEUKPyQaTfqoROGHJowSWeletXA, P_0.VeUXJbtopZnzuPExHBOZDuueBov + P_1.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static void giSjlBupDtcdbDcEsZwIQvmJBPCc(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref float P_1, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_2)
	{
		P_2 = new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0.xEUKPyQaTfqoROGHJowSWeletXA + P_1, P_0.VeUXJbtopZnzuPExHBOZDuueBov + P_1);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj giSjlBupDtcdbDcEsZwIQvmJBPCc(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, float P_1)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0.xEUKPyQaTfqoROGHJowSWeletXA + P_1, P_0.VeUXJbtopZnzuPExHBOZDuueBov + P_1);
	}

	public static void XkKAYesvjXuHQyvoyYoSwgPFjSY(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_2)
	{
		P_2 = new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0.xEUKPyQaTfqoROGHJowSWeletXA - P_1.xEUKPyQaTfqoROGHJowSWeletXA, P_0.VeUXJbtopZnzuPExHBOZDuueBov - P_1.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj XkKAYesvjXuHQyvoyYoSwgPFjSY(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0.xEUKPyQaTfqoROGHJowSWeletXA - P_1.xEUKPyQaTfqoROGHJowSWeletXA, P_0.VeUXJbtopZnzuPExHBOZDuueBov - P_1.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static void XkKAYesvjXuHQyvoyYoSwgPFjSY(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref float P_1, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_2)
	{
		P_2 = new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0.xEUKPyQaTfqoROGHJowSWeletXA - P_1, P_0.VeUXJbtopZnzuPExHBOZDuueBov - P_1);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj XkKAYesvjXuHQyvoyYoSwgPFjSY(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, float P_1)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0.xEUKPyQaTfqoROGHJowSWeletXA - P_1, P_0.VeUXJbtopZnzuPExHBOZDuueBov - P_1);
	}

	public static void XkKAYesvjXuHQyvoyYoSwgPFjSY(ref float P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_2)
	{
		P_2 = new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0 - P_1.xEUKPyQaTfqoROGHJowSWeletXA, P_0 - P_1.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj XkKAYesvjXuHQyvoyYoSwgPFjSY(float P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0 - P_1.xEUKPyQaTfqoROGHJowSWeletXA, P_0 - P_1.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static void hNqHwORgCTXJfsIhwFUzHYNOuSH(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, float P_1, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_2)
	{
		P_2 = new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0.xEUKPyQaTfqoROGHJowSWeletXA * P_1, P_0.VeUXJbtopZnzuPExHBOZDuueBov * P_1);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj hNqHwORgCTXJfsIhwFUzHYNOuSH(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, float P_1)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0.xEUKPyQaTfqoROGHJowSWeletXA * P_1, P_0.VeUXJbtopZnzuPExHBOZDuueBov * P_1);
	}

	public static void hNqHwORgCTXJfsIhwFUzHYNOuSH(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_2)
	{
		P_2 = new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0.xEUKPyQaTfqoROGHJowSWeletXA * P_1.xEUKPyQaTfqoROGHJowSWeletXA, P_0.VeUXJbtopZnzuPExHBOZDuueBov * P_1.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj hNqHwORgCTXJfsIhwFUzHYNOuSH(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0.xEUKPyQaTfqoROGHJowSWeletXA * P_1.xEUKPyQaTfqoROGHJowSWeletXA, P_0.VeUXJbtopZnzuPExHBOZDuueBov * P_1.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static void rVRBjHFVmzvZSghXunfmEZipFVkw(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, float P_1, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_2)
	{
		P_2 = new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0.xEUKPyQaTfqoROGHJowSWeletXA / P_1, P_0.VeUXJbtopZnzuPExHBOZDuueBov / P_1);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj rVRBjHFVmzvZSghXunfmEZipFVkw(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, float P_1)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0.xEUKPyQaTfqoROGHJowSWeletXA / P_1, P_0.VeUXJbtopZnzuPExHBOZDuueBov / P_1);
	}

	public static void rVRBjHFVmzvZSghXunfmEZipFVkw(float P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_2)
	{
		P_2 = new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0 / P_1.xEUKPyQaTfqoROGHJowSWeletXA, P_0 / P_1.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj rVRBjHFVmzvZSghXunfmEZipFVkw(float P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0 / P_1.xEUKPyQaTfqoROGHJowSWeletXA, P_0 / P_1.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static void GQAcsBkkNebWYeCaRxoMDStaRMyu(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_1)
	{
		P_1 = new tHUXQUJruIoKJBkUPVSpWJpVAdj(0f - P_0.xEUKPyQaTfqoROGHJowSWeletXA, 0f - P_0.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj GQAcsBkkNebWYeCaRxoMDStaRMyu(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(0f - P_0.xEUKPyQaTfqoROGHJowSWeletXA, 0f - P_0.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static void mGAXMKFepNHQlcvVtHAVmjPElEQI(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_2, float P_3, float P_4, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_5)
	{
		P_5 = new tHUXQUJruIoKJBkUPVSpWJpVAdj(P_0.xEUKPyQaTfqoROGHJowSWeletXA + P_3 * (P_1.xEUKPyQaTfqoROGHJowSWeletXA - P_0.xEUKPyQaTfqoROGHJowSWeletXA) + P_4 * (P_2.xEUKPyQaTfqoROGHJowSWeletXA - P_0.xEUKPyQaTfqoROGHJowSWeletXA), P_0.VeUXJbtopZnzuPExHBOZDuueBov + P_3 * (P_1.VeUXJbtopZnzuPExHBOZDuueBov - P_0.VeUXJbtopZnzuPExHBOZDuueBov) + P_4 * (P_2.VeUXJbtopZnzuPExHBOZDuueBov - P_0.VeUXJbtopZnzuPExHBOZDuueBov));
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj mGAXMKFepNHQlcvVtHAVmjPElEQI(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, tHUXQUJruIoKJBkUPVSpWJpVAdj P_2, float P_3, float P_4)
	{
		tHUXQUJruIoKJBkUPVSpWJpVAdj result;
		mGAXMKFepNHQlcvVtHAVmjPElEQI(ref P_0, ref P_1, ref P_2, P_3, P_4, out result);
		return result;
	}

	public static void iCBaushIlCHcpcAnsuXQPSfzVgl(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_2, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_3)
	{
		float num = P_0.xEUKPyQaTfqoROGHJowSWeletXA;
		num = ((num > P_2.xEUKPyQaTfqoROGHJowSWeletXA) ? P_2.xEUKPyQaTfqoROGHJowSWeletXA : num);
		num = ((num < P_1.xEUKPyQaTfqoROGHJowSWeletXA) ? P_1.xEUKPyQaTfqoROGHJowSWeletXA : num);
		float veUXJbtopZnzuPExHBOZDuueBov = P_0.VeUXJbtopZnzuPExHBOZDuueBov;
		veUXJbtopZnzuPExHBOZDuueBov = ((veUXJbtopZnzuPExHBOZDuueBov > P_2.VeUXJbtopZnzuPExHBOZDuueBov) ? P_2.VeUXJbtopZnzuPExHBOZDuueBov : veUXJbtopZnzuPExHBOZDuueBov);
		veUXJbtopZnzuPExHBOZDuueBov = ((veUXJbtopZnzuPExHBOZDuueBov < P_1.VeUXJbtopZnzuPExHBOZDuueBov) ? P_1.VeUXJbtopZnzuPExHBOZDuueBov : veUXJbtopZnzuPExHBOZDuueBov);
		P_3 = new tHUXQUJruIoKJBkUPVSpWJpVAdj(num, veUXJbtopZnzuPExHBOZDuueBov);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj iCBaushIlCHcpcAnsuXQPSfzVgl(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, tHUXQUJruIoKJBkUPVSpWJpVAdj P_2)
	{
		tHUXQUJruIoKJBkUPVSpWJpVAdj result;
		iCBaushIlCHcpcAnsuXQPSfzVgl(ref P_0, ref P_1, ref P_2, out result);
		return result;
	}

	public void mEZgczGABvHFxGQrxaUHGcuvTor()
	{
		xEUKPyQaTfqoROGHJowSWeletXA = ((xEUKPyQaTfqoROGHJowSWeletXA < 0f) ? 0f : ((xEUKPyQaTfqoROGHJowSWeletXA > 1f) ? 1f : xEUKPyQaTfqoROGHJowSWeletXA));
		VeUXJbtopZnzuPExHBOZDuueBov = ((VeUXJbtopZnzuPExHBOZDuueBov < 0f) ? 0f : ((VeUXJbtopZnzuPExHBOZDuueBov > 1f) ? 1f : VeUXJbtopZnzuPExHBOZDuueBov));
	}

	public static void fdsPInqATsQYujPWyEzTrtnBnuY(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, out float P_2)
	{
		float num = P_0.xEUKPyQaTfqoROGHJowSWeletXA - P_1.xEUKPyQaTfqoROGHJowSWeletXA;
		float num2 = P_0.VeUXJbtopZnzuPExHBOZDuueBov - P_1.VeUXJbtopZnzuPExHBOZDuueBov;
		P_2 = (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float fdsPInqATsQYujPWyEzTrtnBnuY(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1)
	{
		float num = P_0.xEUKPyQaTfqoROGHJowSWeletXA - P_1.xEUKPyQaTfqoROGHJowSWeletXA;
		float num2 = P_0.VeUXJbtopZnzuPExHBOZDuueBov - P_1.VeUXJbtopZnzuPExHBOZDuueBov;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static void MOnSflkGAfTfhknzPSeJkdbMEZJ(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, out float P_2)
	{
		float num = P_0.xEUKPyQaTfqoROGHJowSWeletXA - P_1.xEUKPyQaTfqoROGHJowSWeletXA;
		float num2 = P_0.VeUXJbtopZnzuPExHBOZDuueBov - P_1.VeUXJbtopZnzuPExHBOZDuueBov;
		P_2 = num * num + num2 * num2;
	}

	public static float MOnSflkGAfTfhknzPSeJkdbMEZJ(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1)
	{
		float num = P_0.xEUKPyQaTfqoROGHJowSWeletXA - P_1.xEUKPyQaTfqoROGHJowSWeletXA;
		float num2 = P_0.VeUXJbtopZnzuPExHBOZDuueBov - P_1.VeUXJbtopZnzuPExHBOZDuueBov;
		return num * num + num2 * num2;
	}

	public static void KsRoLEieKeEydHrkizOTlVHTqtaA(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, out float P_2)
	{
		P_2 = P_0.xEUKPyQaTfqoROGHJowSWeletXA * P_1.xEUKPyQaTfqoROGHJowSWeletXA + P_0.VeUXJbtopZnzuPExHBOZDuueBov * P_1.VeUXJbtopZnzuPExHBOZDuueBov;
	}

	public static float KsRoLEieKeEydHrkizOTlVHTqtaA(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1)
	{
		return P_0.xEUKPyQaTfqoROGHJowSWeletXA * P_1.xEUKPyQaTfqoROGHJowSWeletXA + P_0.VeUXJbtopZnzuPExHBOZDuueBov * P_1.VeUXJbtopZnzuPExHBOZDuueBov;
	}

	public static void OTYhpSOKetYDGMDxuYojrJiljEC(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_1)
	{
		P_1 = P_0;
		P_1.OTYhpSOKetYDGMDxuYojrJiljEC();
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj OTYhpSOKetYDGMDxuYojrJiljEC(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0)
	{
		P_0.OTYhpSOKetYDGMDxuYojrJiljEC();
		return P_0;
	}

	public static void apRQEfZVUfKVDXqqPZCWnqnsbMM(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, float P_2, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_3)
	{
		P_3.xEUKPyQaTfqoROGHJowSWeletXA = HKbcmtHxGOxqoUgzpNGAGbrWhWL.apRQEfZVUfKVDXqqPZCWnqnsbMM(P_0.xEUKPyQaTfqoROGHJowSWeletXA, P_1.xEUKPyQaTfqoROGHJowSWeletXA, P_2);
		P_3.VeUXJbtopZnzuPExHBOZDuueBov = HKbcmtHxGOxqoUgzpNGAGbrWhWL.apRQEfZVUfKVDXqqPZCWnqnsbMM(P_0.VeUXJbtopZnzuPExHBOZDuueBov, P_1.VeUXJbtopZnzuPExHBOZDuueBov, P_2);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj apRQEfZVUfKVDXqqPZCWnqnsbMM(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, float P_2)
	{
		tHUXQUJruIoKJBkUPVSpWJpVAdj result;
		apRQEfZVUfKVDXqqPZCWnqnsbMM(ref P_0, ref P_1, P_2, out result);
		return result;
	}

	public static void saMzVEjcTWVrShORdaANAhwAjMq(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, float P_2, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_3)
	{
		P_2 = HKbcmtHxGOxqoUgzpNGAGbrWhWL.saMzVEjcTWVrShORdaANAhwAjMq(P_2);
		apRQEfZVUfKVDXqqPZCWnqnsbMM(ref P_0, ref P_1, P_2, out P_3);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj saMzVEjcTWVrShORdaANAhwAjMq(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, float P_2)
	{
		tHUXQUJruIoKJBkUPVSpWJpVAdj result;
		saMzVEjcTWVrShORdaANAhwAjMq(ref P_0, ref P_1, P_2, out result);
		return result;
	}

	public static void apbbdJDrSooulBVdbpaUolfgFci(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_2, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_3, float P_4, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + P_4;
		float num6 = num2 - num;
		P_5.xEUKPyQaTfqoROGHJowSWeletXA = P_0.xEUKPyQaTfqoROGHJowSWeletXA * num3 + P_2.xEUKPyQaTfqoROGHJowSWeletXA * num4 + P_1.xEUKPyQaTfqoROGHJowSWeletXA * num5 + P_3.xEUKPyQaTfqoROGHJowSWeletXA * num6;
		P_5.VeUXJbtopZnzuPExHBOZDuueBov = P_0.VeUXJbtopZnzuPExHBOZDuueBov * num3 + P_2.VeUXJbtopZnzuPExHBOZDuueBov * num4 + P_1.VeUXJbtopZnzuPExHBOZDuueBov * num5 + P_3.VeUXJbtopZnzuPExHBOZDuueBov * num6;
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj apbbdJDrSooulBVdbpaUolfgFci(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, tHUXQUJruIoKJBkUPVSpWJpVAdj P_2, tHUXQUJruIoKJBkUPVSpWJpVAdj P_3, float P_4)
	{
		tHUXQUJruIoKJBkUPVSpWJpVAdj result;
		apbbdJDrSooulBVdbpaUolfgFci(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out result);
		return result;
	}

	public static void tzTzGWpxeQdNAULsqppaZINEucS(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_2, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_3, float P_4, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		P_5.xEUKPyQaTfqoROGHJowSWeletXA = 0.5f * (2f * P_1.xEUKPyQaTfqoROGHJowSWeletXA + (0f - P_0.xEUKPyQaTfqoROGHJowSWeletXA + P_2.xEUKPyQaTfqoROGHJowSWeletXA) * P_4 + (2f * P_0.xEUKPyQaTfqoROGHJowSWeletXA - 5f * P_1.xEUKPyQaTfqoROGHJowSWeletXA + 4f * P_2.xEUKPyQaTfqoROGHJowSWeletXA - P_3.xEUKPyQaTfqoROGHJowSWeletXA) * num + (0f - P_0.xEUKPyQaTfqoROGHJowSWeletXA + 3f * P_1.xEUKPyQaTfqoROGHJowSWeletXA - 3f * P_2.xEUKPyQaTfqoROGHJowSWeletXA + P_3.xEUKPyQaTfqoROGHJowSWeletXA) * num2);
		P_5.VeUXJbtopZnzuPExHBOZDuueBov = 0.5f * (2f * P_1.VeUXJbtopZnzuPExHBOZDuueBov + (0f - P_0.VeUXJbtopZnzuPExHBOZDuueBov + P_2.VeUXJbtopZnzuPExHBOZDuueBov) * P_4 + (2f * P_0.VeUXJbtopZnzuPExHBOZDuueBov - 5f * P_1.VeUXJbtopZnzuPExHBOZDuueBov + 4f * P_2.VeUXJbtopZnzuPExHBOZDuueBov - P_3.VeUXJbtopZnzuPExHBOZDuueBov) * num + (0f - P_0.VeUXJbtopZnzuPExHBOZDuueBov + 3f * P_1.VeUXJbtopZnzuPExHBOZDuueBov - 3f * P_2.VeUXJbtopZnzuPExHBOZDuueBov + P_3.VeUXJbtopZnzuPExHBOZDuueBov) * num2);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj tzTzGWpxeQdNAULsqppaZINEucS(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, tHUXQUJruIoKJBkUPVSpWJpVAdj P_2, tHUXQUJruIoKJBkUPVSpWJpVAdj P_3, float P_4)
	{
		tHUXQUJruIoKJBkUPVSpWJpVAdj result;
		tzTzGWpxeQdNAULsqppaZINEucS(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out result);
		return result;
	}

	public static void jBAzNbwYJeSlZimtgGkQfMwJbeR(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_2)
	{
		P_2.xEUKPyQaTfqoROGHJowSWeletXA = ((P_0.xEUKPyQaTfqoROGHJowSWeletXA > P_1.xEUKPyQaTfqoROGHJowSWeletXA) ? P_0.xEUKPyQaTfqoROGHJowSWeletXA : P_1.xEUKPyQaTfqoROGHJowSWeletXA);
		P_2.VeUXJbtopZnzuPExHBOZDuueBov = ((P_0.VeUXJbtopZnzuPExHBOZDuueBov > P_1.VeUXJbtopZnzuPExHBOZDuueBov) ? P_0.VeUXJbtopZnzuPExHBOZDuueBov : P_1.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj jBAzNbwYJeSlZimtgGkQfMwJbeR(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1)
	{
		tHUXQUJruIoKJBkUPVSpWJpVAdj result;
		jBAzNbwYJeSlZimtgGkQfMwJbeR(ref P_0, ref P_1, out result);
		return result;
	}

	public static void cXxfeXgVtgnVoNovaBlcLpCfHVDF(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_2)
	{
		P_2.xEUKPyQaTfqoROGHJowSWeletXA = ((P_0.xEUKPyQaTfqoROGHJowSWeletXA < P_1.xEUKPyQaTfqoROGHJowSWeletXA) ? P_0.xEUKPyQaTfqoROGHJowSWeletXA : P_1.xEUKPyQaTfqoROGHJowSWeletXA);
		P_2.VeUXJbtopZnzuPExHBOZDuueBov = ((P_0.VeUXJbtopZnzuPExHBOZDuueBov < P_1.VeUXJbtopZnzuPExHBOZDuueBov) ? P_0.VeUXJbtopZnzuPExHBOZDuueBov : P_1.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj cXxfeXgVtgnVoNovaBlcLpCfHVDF(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1)
	{
		tHUXQUJruIoKJBkUPVSpWJpVAdj result;
		cXxfeXgVtgnVoNovaBlcLpCfHVDF(ref P_0, ref P_1, out result);
		return result;
	}

	public static void OxUbErbsKVkBWwSKdZUiUaxuiAwF(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_1, out tHUXQUJruIoKJBkUPVSpWJpVAdj P_2)
	{
		float num = P_0.xEUKPyQaTfqoROGHJowSWeletXA * P_1.xEUKPyQaTfqoROGHJowSWeletXA + P_0.VeUXJbtopZnzuPExHBOZDuueBov * P_1.VeUXJbtopZnzuPExHBOZDuueBov;
		P_2.xEUKPyQaTfqoROGHJowSWeletXA = P_0.xEUKPyQaTfqoROGHJowSWeletXA - 2f * num * P_1.xEUKPyQaTfqoROGHJowSWeletXA;
		P_2.VeUXJbtopZnzuPExHBOZDuueBov = P_0.VeUXJbtopZnzuPExHBOZDuueBov - 2f * num * P_1.VeUXJbtopZnzuPExHBOZDuueBov;
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj OxUbErbsKVkBWwSKdZUiUaxuiAwF(tHUXQUJruIoKJBkUPVSpWJpVAdj P_0, tHUXQUJruIoKJBkUPVSpWJpVAdj P_1)
	{
		tHUXQUJruIoKJBkUPVSpWJpVAdj result;
		OxUbErbsKVkBWwSKdZUiUaxuiAwF(ref P_0, ref P_1, out result);
		return result;
	}

	public static void RJoupiibBxLyuJcaEUvgWajZbic(tHUXQUJruIoKJBkUPVSpWJpVAdj[] P_0, params tHUXQUJruIoKJBkUPVSpWJpVAdj[] P_1)
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
			tHUXQUJruIoKJBkUPVSpWJpVAdj tHUXQUJruIoKJBkUPVSpWJpVAdj2 = P_1[i];
			for (int j = 0; j < i; j++)
			{
				tHUXQUJruIoKJBkUPVSpWJpVAdj2 -= KsRoLEieKeEydHrkizOTlVHTqtaA(P_0[j], tHUXQUJruIoKJBkUPVSpWJpVAdj2) / KsRoLEieKeEydHrkizOTlVHTqtaA(P_0[j], P_0[j]) * P_0[j];
			}
			P_0[i] = tHUXQUJruIoKJBkUPVSpWJpVAdj2;
		}
	}

	public static void WBTMGgPLxnXTqmgZeGNurJHFCMh(tHUXQUJruIoKJBkUPVSpWJpVAdj[] P_0, params tHUXQUJruIoKJBkUPVSpWJpVAdj[] P_1)
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
			tHUXQUJruIoKJBkUPVSpWJpVAdj tHUXQUJruIoKJBkUPVSpWJpVAdj2 = P_1[i];
			for (int j = 0; j < i; j++)
			{
				tHUXQUJruIoKJBkUPVSpWJpVAdj2 -= KsRoLEieKeEydHrkizOTlVHTqtaA(P_0[j], tHUXQUJruIoKJBkUPVSpWJpVAdj2) * P_0[j];
			}
			tHUXQUJruIoKJBkUPVSpWJpVAdj2.OTYhpSOKetYDGMDxuYojrJiljEC();
			P_0[i] = tHUXQUJruIoKJBkUPVSpWJpVAdj2;
		}
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj operator +(tHUXQUJruIoKJBkUPVSpWJpVAdj left, tHUXQUJruIoKJBkUPVSpWJpVAdj right)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(left.xEUKPyQaTfqoROGHJowSWeletXA + right.xEUKPyQaTfqoROGHJowSWeletXA, left.VeUXJbtopZnzuPExHBOZDuueBov + right.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj operator *(tHUXQUJruIoKJBkUPVSpWJpVAdj left, tHUXQUJruIoKJBkUPVSpWJpVAdj right)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(left.xEUKPyQaTfqoROGHJowSWeletXA * right.xEUKPyQaTfqoROGHJowSWeletXA, left.VeUXJbtopZnzuPExHBOZDuueBov * right.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj operator +(tHUXQUJruIoKJBkUPVSpWJpVAdj value)
	{
		return value;
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj operator -(tHUXQUJruIoKJBkUPVSpWJpVAdj left, tHUXQUJruIoKJBkUPVSpWJpVAdj right)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(left.xEUKPyQaTfqoROGHJowSWeletXA - right.xEUKPyQaTfqoROGHJowSWeletXA, left.VeUXJbtopZnzuPExHBOZDuueBov - right.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj operator -(tHUXQUJruIoKJBkUPVSpWJpVAdj value)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(0f - value.xEUKPyQaTfqoROGHJowSWeletXA, 0f - value.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj operator *(float scale, tHUXQUJruIoKJBkUPVSpWJpVAdj value)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(value.xEUKPyQaTfqoROGHJowSWeletXA * scale, value.VeUXJbtopZnzuPExHBOZDuueBov * scale);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj operator *(tHUXQUJruIoKJBkUPVSpWJpVAdj value, float scale)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(value.xEUKPyQaTfqoROGHJowSWeletXA * scale, value.VeUXJbtopZnzuPExHBOZDuueBov * scale);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj operator /(tHUXQUJruIoKJBkUPVSpWJpVAdj value, float scale)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(value.xEUKPyQaTfqoROGHJowSWeletXA / scale, value.VeUXJbtopZnzuPExHBOZDuueBov / scale);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj operator /(float scale, tHUXQUJruIoKJBkUPVSpWJpVAdj value)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(scale / value.xEUKPyQaTfqoROGHJowSWeletXA, scale / value.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj operator /(tHUXQUJruIoKJBkUPVSpWJpVAdj value, tHUXQUJruIoKJBkUPVSpWJpVAdj scale)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(value.xEUKPyQaTfqoROGHJowSWeletXA / scale.xEUKPyQaTfqoROGHJowSWeletXA, value.VeUXJbtopZnzuPExHBOZDuueBov / scale.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj operator +(tHUXQUJruIoKJBkUPVSpWJpVAdj value, float scalar)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(value.xEUKPyQaTfqoROGHJowSWeletXA + scalar, value.VeUXJbtopZnzuPExHBOZDuueBov + scalar);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj operator +(float scalar, tHUXQUJruIoKJBkUPVSpWJpVAdj value)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(scalar + value.xEUKPyQaTfqoROGHJowSWeletXA, scalar + value.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj operator -(tHUXQUJruIoKJBkUPVSpWJpVAdj value, float scalar)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(value.xEUKPyQaTfqoROGHJowSWeletXA - scalar, value.VeUXJbtopZnzuPExHBOZDuueBov - scalar);
	}

	public static tHUXQUJruIoKJBkUPVSpWJpVAdj operator -(float scalar, tHUXQUJruIoKJBkUPVSpWJpVAdj value)
	{
		return new tHUXQUJruIoKJBkUPVSpWJpVAdj(scalar - value.xEUKPyQaTfqoROGHJowSWeletXA, scalar - value.VeUXJbtopZnzuPExHBOZDuueBov);
	}

	public static bool operator ==(tHUXQUJruIoKJBkUPVSpWJpVAdj left, tHUXQUJruIoKJBkUPVSpWJpVAdj right)
	{
		return left.bEnIwmDQBptAwhYgeoqMwSwXPKCG(ref right);
	}

	public static bool operator !=(tHUXQUJruIoKJBkUPVSpWJpVAdj left, tHUXQUJruIoKJBkUPVSpWJpVAdj right)
	{
		return !left.bEnIwmDQBptAwhYgeoqMwSwXPKCG(ref right);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", new object[2] { xEUKPyQaTfqoROGHJowSWeletXA, VeUXJbtopZnzuPExHBOZDuueBov });
	}

	public string shRdQKhcpqQbzCGymNimzIjVeDZm(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", new object[2]
		{
			xEUKPyQaTfqoROGHJowSWeletXA.ToString(P_0, CultureInfo.CurrentCulture),
			VeUXJbtopZnzuPExHBOZDuueBov.ToString(P_0, CultureInfo.CurrentCulture)
		});
	}

	public string shRdQKhcpqQbzCGymNimzIjVeDZm(IFormatProvider P_0)
	{
		return string.Format(P_0, "X:{0} Y:{1}", new object[2] { xEUKPyQaTfqoROGHJowSWeletXA, VeUXJbtopZnzuPExHBOZDuueBov });
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			shRdQKhcpqQbzCGymNimzIjVeDZm(formatProvider);
		}
		return string.Format(formatProvider, "X:{0} Y:{1}", new object[2]
		{
			xEUKPyQaTfqoROGHJowSWeletXA.ToString(format, formatProvider),
			VeUXJbtopZnzuPExHBOZDuueBov.ToString(format, formatProvider)
		});
	}

	public override int GetHashCode()
	{
		return (xEUKPyQaTfqoROGHJowSWeletXA.GetHashCode() * 397) ^ VeUXJbtopZnzuPExHBOZDuueBov.GetHashCode();
	}

	public bool bEnIwmDQBptAwhYgeoqMwSwXPKCG(ref tHUXQUJruIoKJBkUPVSpWJpVAdj P_0)
	{
		if (HKbcmtHxGOxqoUgzpNGAGbrWhWL.nFEuCHuBTekQSfrBpWHSgxqSedw(P_0.xEUKPyQaTfqoROGHJowSWeletXA, xEUKPyQaTfqoROGHJowSWeletXA))
		{
			return HKbcmtHxGOxqoUgzpNGAGbrWhWL.nFEuCHuBTekQSfrBpWHSgxqSedw(P_0.VeUXJbtopZnzuPExHBOZDuueBov, VeUXJbtopZnzuPExHBOZDuueBov);
		}
		return false;
	}

	public bool Equals(tHUXQUJruIoKJBkUPVSpWJpVAdj other)
	{
		return bEnIwmDQBptAwhYgeoqMwSwXPKCG(ref other);
	}

	public override bool Equals(object value)
	{
		if (!(value is tHUXQUJruIoKJBkUPVSpWJpVAdj))
		{
			return false;
		}
		tHUXQUJruIoKJBkUPVSpWJpVAdj tHUXQUJruIoKJBkUPVSpWJpVAdj2 = (tHUXQUJruIoKJBkUPVSpWJpVAdj)value;
		return bEnIwmDQBptAwhYgeoqMwSwXPKCG(ref tHUXQUJruIoKJBkUPVSpWJpVAdj2);
	}
}
