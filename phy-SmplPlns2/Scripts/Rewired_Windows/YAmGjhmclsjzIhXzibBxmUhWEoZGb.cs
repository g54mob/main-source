using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[DefaultMember("Item")]
internal struct YAmGjhmclsjzIhXzibBxmUhWEoZGb : IEquatable<YAmGjhmclsjzIhXzibBxmUhWEoZGb>, IFormattable
{
	public static readonly int MOOcEDatPRPGFRjOIlpZIGVjGBkLb = Marshal.SizeOf(typeof(YAmGjhmclsjzIhXzibBxmUhWEoZGb));

	public static readonly YAmGjhmclsjzIhXzibBxmUhWEoZGb QpceehoDbpdtRcikWiIoFOldNKsvA = default(YAmGjhmclsjzIhXzibBxmUhWEoZGb);

	public static readonly YAmGjhmclsjzIhXzibBxmUhWEoZGb jBKmoCZeHGiTTaZpJATBqvKuxWhw = new YAmGjhmclsjzIhXzibBxmUhWEoZGb(1f, 0f);

	public static readonly YAmGjhmclsjzIhXzibBxmUhWEoZGb spqUvtfxTJzRVAhgcceUtOjLvpQe = new YAmGjhmclsjzIhXzibBxmUhWEoZGb(0f, 1f);

	public static readonly YAmGjhmclsjzIhXzibBxmUhWEoZGb EeKjBzXgEhofrBHBzHIlTFjxFFrv = new YAmGjhmclsjzIhXzibBxmUhWEoZGb(1f, 1f);

	public float ediFexLrNDKWaIiMhJsBUaAgVnRj;

	public float DwdfBRGyiFbfxVPCpXCjTrJddyJEA;

	public bool vnThNjejRaLKoefirhHnAfdggopU => qYLtIScOYoBsbgUqSNRAfGRHZXjDB.XNQHfXJPqKOwLDQwInHfEkYOSLrn(ediFexLrNDKWaIiMhJsBUaAgVnRj * ediFexLrNDKWaIiMhJsBUaAgVnRj + DwdfBRGyiFbfxVPCpXCjTrJddyJEA * DwdfBRGyiFbfxVPCpXCjTrJddyJEA);

	public bool dAHzfAHqQGVTGkjuGbDgHJGEtJMV
	{
		get
		{
			if (ediFexLrNDKWaIiMhJsBUaAgVnRj == 0f)
			{
				return DwdfBRGyiFbfxVPCpXCjTrJddyJEA == 0f;
			}
			return false;
		}
	}

	public float pbdbfpPTzCKxMYqHmZZTkNmykVRj
	{
		get
		{
			return P_0 switch
			{
				0 => ediFexLrNDKWaIiMhJsBUaAgVnRj, 
				1 => DwdfBRGyiFbfxVPCpXCjTrJddyJEA, 
				_ => throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive."), 
			};
		}
		set
		{
			switch (num)
			{
			case 0:
				ediFexLrNDKWaIiMhJsBUaAgVnRj = dwdfBRGyiFbfxVPCpXCjTrJddyJEA;
				break;
			case 1:
				DwdfBRGyiFbfxVPCpXCjTrJddyJEA = dwdfBRGyiFbfxVPCpXCjTrJddyJEA;
				break;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
	}

	public YAmGjhmclsjzIhXzibBxmUhWEoZGb(float P_0)
	{
		ediFexLrNDKWaIiMhJsBUaAgVnRj = P_0;
		DwdfBRGyiFbfxVPCpXCjTrJddyJEA = P_0;
	}

	public YAmGjhmclsjzIhXzibBxmUhWEoZGb(float P_0, float P_1)
	{
		ediFexLrNDKWaIiMhJsBUaAgVnRj = P_0;
		DwdfBRGyiFbfxVPCpXCjTrJddyJEA = P_1;
	}

	public YAmGjhmclsjzIhXzibBxmUhWEoZGb(float[] P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("values");
		}
		if (P_0.Length != 2)
		{
			throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
		}
		ediFexLrNDKWaIiMhJsBUaAgVnRj = P_0[0];
		DwdfBRGyiFbfxVPCpXCjTrJddyJEA = P_0[1];
	}

	public float friOFOuwMvwJIWifreTBvPFQGXGc()
	{
		return (float)Math.Sqrt(ediFexLrNDKWaIiMhJsBUaAgVnRj * ediFexLrNDKWaIiMhJsBUaAgVnRj + DwdfBRGyiFbfxVPCpXCjTrJddyJEA * DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public float IRusTvBsgretmlYnWhfWEcEdIKLB()
	{
		return ediFexLrNDKWaIiMhJsBUaAgVnRj * ediFexLrNDKWaIiMhJsBUaAgVnRj + DwdfBRGyiFbfxVPCpXCjTrJddyJEA * DwdfBRGyiFbfxVPCpXCjTrJddyJEA;
	}

	public void lxXpwIOFXCBEuXKCckkFReYawYcm()
	{
		float num = friOFOuwMvwJIWifreTBvPFQGXGc();
		if (!qYLtIScOYoBsbgUqSNRAfGRHZXjDB.tltcDnabXcCvuqGercBRksLKYydQA(num))
		{
			float num2 = 1f / num;
			ediFexLrNDKWaIiMhJsBUaAgVnRj *= num2;
			DwdfBRGyiFbfxVPCpXCjTrJddyJEA *= num2;
		}
	}

	public float[] uXwHScizAhTELvILRqAQsRbBLeeY()
	{
		return new float[2] { ediFexLrNDKWaIiMhJsBUaAgVnRj, DwdfBRGyiFbfxVPCpXCjTrJddyJEA };
	}

	public static void hYPusYlPGXhrusGfTDbdgShUsPLrA(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2)
	{
		P_2 = new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj + P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA + P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb imrojjNBEBdRvcXTKEDfrkrhypqt(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj + P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA + P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public static void QTlOymjThmzKjcEiNZcVwXaQyRIG(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref float P_1, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2)
	{
		P_2 = new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj + P_1, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA + P_1);
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb yLsJbXtWumyiLACbLJohSorPnNSu(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, float P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj + P_1, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA + P_1);
	}

	public static void xfuXylzmewKIHHgTBEwryHWCQiAg(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2)
	{
		P_2 = new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj - P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA - P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb vjeZzYhvFNifpBiBbCegHSPBHFNz(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj - P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA - P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public static void pNSdLhNlsJoMITLAunWfVxCINSud(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref float P_1, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2)
	{
		P_2 = new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj - P_1, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA - P_1);
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb mGcaQrSRzifgIliFXNKHRBOUXdhC(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, float P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj - P_1, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA - P_1);
	}

	public static void pcJMqMETAeDBRDIelpfoLRuCRdQX(ref float P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2)
	{
		P_2 = new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0 - P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0 - P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb UZFZCDdtACaLmBzvBZZiiHYxyGlrA(float P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0 - P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0 - P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public static void UPdFOQEgGvCCnhVRWsKIFdUeRDaLc(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, float P_1, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2)
	{
		P_2 = new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj * P_1, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA * P_1);
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb wUniKWhHZszcMPfPvEryAsGrdGxm(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, float P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj * P_1, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA * P_1);
	}

	public static void HOaXvBfOpAGGpauvDiqAChbrkemB(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2)
	{
		P_2 = new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj * P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA * P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb MCZRKzXMOwECTDqAijWNGwqBeieK(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj * P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA * P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public static void FGtNCRgQZPvntBEnuejxGknxEICC(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, float P_1, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2)
	{
		P_2 = new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj / P_1, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA / P_1);
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb TUEeXUBATwuRHBWpWEJOLoTwvdqC(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, float P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj / P_1, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA / P_1);
	}

	public static void ejIdrixFnZCrdDgkpbRYDCkIjtZvb(float P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2)
	{
		P_2 = new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0 / P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0 / P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb sOZzXkQLmloEmOgvOGBVKTOhyLWr(float P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0 / P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0 / P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public static void HGsluKZlzNfFOmoSOTGPeGwRmcmJ(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		P_1 = new YAmGjhmclsjzIhXzibBxmUhWEoZGb(0f - P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj, 0f - P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb ENgyTNQphMZTGJDMhgJTewmQZTslA(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(0f - P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj, 0f - P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public static void othDKqwMVCLozYFrZCibjVketddKA(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2, float P_3, float P_4, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_5)
	{
		P_5 = new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj + P_3 * (P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj - P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj) + P_4 * (P_2.ediFexLrNDKWaIiMhJsBUaAgVnRj - P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj), P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA + P_3 * (P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA - P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA) + P_4 * (P_2.DwdfBRGyiFbfxVPCpXCjTrJddyJEA - P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA));
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb rmvAOjmsyzdJNilYXQRXmQJcqkDZA(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2, float P_3, float P_4)
	{
		othDKqwMVCLozYFrZCibjVketddKA(ref P_0, ref P_1, ref P_2, P_3, P_4, out var result);
		return result;
	}

	public static void NtKwETlcwoLfRdXWvqPpmpJHwFUD(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_3)
	{
		float num = P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj;
		num = ((num > P_2.ediFexLrNDKWaIiMhJsBUaAgVnRj) ? P_2.ediFexLrNDKWaIiMhJsBUaAgVnRj : num);
		num = ((num < P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj) ? P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj : num);
		float dwdfBRGyiFbfxVPCpXCjTrJddyJEA = P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA;
		dwdfBRGyiFbfxVPCpXCjTrJddyJEA = ((dwdfBRGyiFbfxVPCpXCjTrJddyJEA > P_2.DwdfBRGyiFbfxVPCpXCjTrJddyJEA) ? P_2.DwdfBRGyiFbfxVPCpXCjTrJddyJEA : dwdfBRGyiFbfxVPCpXCjTrJddyJEA);
		dwdfBRGyiFbfxVPCpXCjTrJddyJEA = ((dwdfBRGyiFbfxVPCpXCjTrJddyJEA < P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA) ? P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA : dwdfBRGyiFbfxVPCpXCjTrJddyJEA);
		P_3 = new YAmGjhmclsjzIhXzibBxmUhWEoZGb(num, dwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb RaPiqSnIURPLJDAognMdlSQnBbUU(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2)
	{
		NtKwETlcwoLfRdXWvqPpmpJHwFUD(ref P_0, ref P_1, ref P_2, out var result);
		return result;
	}

	public void tvtdMlwAmCaogBuImbMwxIXvOzfeA()
	{
		ediFexLrNDKWaIiMhJsBUaAgVnRj = ((ediFexLrNDKWaIiMhJsBUaAgVnRj < 0f) ? 0f : ((ediFexLrNDKWaIiMhJsBUaAgVnRj > 1f) ? 1f : ediFexLrNDKWaIiMhJsBUaAgVnRj));
		DwdfBRGyiFbfxVPCpXCjTrJddyJEA = ((DwdfBRGyiFbfxVPCpXCjTrJddyJEA < 0f) ? 0f : ((DwdfBRGyiFbfxVPCpXCjTrJddyJEA > 1f) ? 1f : DwdfBRGyiFbfxVPCpXCjTrJddyJEA));
	}

	public static void RXSzatZdVmEPLKZNgPKvlcItCaWhb(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, out float P_2)
	{
		float num = P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj - P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj;
		float num2 = P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA - P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA;
		P_2 = (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float BcpCNjAnjuUDsGrurfGJSKTOCqlbA(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		float num = P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj - P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj;
		float num2 = P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA - P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static void vejPzerJjZAMjtIjmkuGWRTTvMiF(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, out float P_2)
	{
		float num = P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj - P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj;
		float num2 = P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA - P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA;
		P_2 = num * num + num2 * num2;
	}

	public static float kdScgZtUdxWEFbmDdkKObiITRPlp(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		float num = P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj - P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj;
		float num2 = P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA - P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA;
		return num * num + num2 * num2;
	}

	public static void CrJLkNAlIldVPbqaURbenDMUMqiC(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, out float P_2)
	{
		P_2 = P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj * P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj + P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA * P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA;
	}

	public static float taedKDetjffzSGNtbIidnetBDwvt(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		return P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj * P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj + P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA * P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA;
	}

	public static void gCuMrrVGhHDhpBMDwDwFXNTntYNbA(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		P_1 = P_0;
		P_1.lxXpwIOFXCBEuXKCckkFReYawYcm();
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb ydvjSKOkKDIHcAezPtKdHMGBuqYlA(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0)
	{
		P_0.lxXpwIOFXCBEuXKCckkFReYawYcm();
		return P_0;
	}

	public static void dCEYGgmOqZcfCJYbISmSSErzvNnT(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, float P_2, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_3)
	{
		P_3.ediFexLrNDKWaIiMhJsBUaAgVnRj = qYLtIScOYoBsbgUqSNRAfGRHZXjDB.LEAVQAGJZbdlgePuHbvPpwbhMYnQ(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_2);
		P_3.DwdfBRGyiFbfxVPCpXCjTrJddyJEA = qYLtIScOYoBsbgUqSNRAfGRHZXjDB.LEAVQAGJZbdlgePuHbvPpwbhMYnQ(P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA, P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA, P_2);
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb vjAAcXfqfoIWQvbSKEoBVMWhYhom(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, float P_2)
	{
		dCEYGgmOqZcfCJYbISmSSErzvNnT(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void XtMJBvcqHRGXtUQpfBOMrJRGMJgy(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, float P_2, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_3)
	{
		P_2 = qYLtIScOYoBsbgUqSNRAfGRHZXjDB.pGWRzXYTRXmKFgBIFokpnzbwXYAh(P_2);
		dCEYGgmOqZcfCJYbISmSSErzvNnT(ref P_0, ref P_1, P_2, out P_3);
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb oAWflvKpBnicjIKMKUCqUDBBIqjp(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, float P_2)
	{
		XtMJBvcqHRGXtUQpfBOMrJRGMJgy(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void TtBycwCfwStoYmYLQVwQglzjriiU(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_3, float P_4, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + P_4;
		float num6 = num2 - num;
		P_5.ediFexLrNDKWaIiMhJsBUaAgVnRj = P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj * num3 + P_2.ediFexLrNDKWaIiMhJsBUaAgVnRj * num4 + P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj * num5 + P_3.ediFexLrNDKWaIiMhJsBUaAgVnRj * num6;
		P_5.DwdfBRGyiFbfxVPCpXCjTrJddyJEA = P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA * num3 + P_2.DwdfBRGyiFbfxVPCpXCjTrJddyJEA * num4 + P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA * num5 + P_3.DwdfBRGyiFbfxVPCpXCjTrJddyJEA * num6;
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb DcCQJSYEmZPCLalyKGTypyEaDFvT(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_3, float P_4)
	{
		TtBycwCfwStoYmYLQVwQglzjriiU(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void asjNjvhrIGYmAjjqCspSLHYxtlyd(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_3, float P_4, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		P_5.ediFexLrNDKWaIiMhJsBUaAgVnRj = 0.5f * (2f * P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj + (0f - P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj + P_2.ediFexLrNDKWaIiMhJsBUaAgVnRj) * P_4 + (2f * P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj - 5f * P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj + 4f * P_2.ediFexLrNDKWaIiMhJsBUaAgVnRj - P_3.ediFexLrNDKWaIiMhJsBUaAgVnRj) * num + (0f - P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj + 3f * P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj - 3f * P_2.ediFexLrNDKWaIiMhJsBUaAgVnRj + P_3.ediFexLrNDKWaIiMhJsBUaAgVnRj) * num2);
		P_5.DwdfBRGyiFbfxVPCpXCjTrJddyJEA = 0.5f * (2f * P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA + (0f - P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA + P_2.DwdfBRGyiFbfxVPCpXCjTrJddyJEA) * P_4 + (2f * P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA - 5f * P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA + 4f * P_2.DwdfBRGyiFbfxVPCpXCjTrJddyJEA - P_3.DwdfBRGyiFbfxVPCpXCjTrJddyJEA) * num + (0f - P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA + 3f * P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA - 3f * P_2.DwdfBRGyiFbfxVPCpXCjTrJddyJEA + P_3.DwdfBRGyiFbfxVPCpXCjTrJddyJEA) * num2);
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb AaGusvfQMBeiKIhDAIyRMqOUXmRHA(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_3, float P_4)
	{
		asjNjvhrIGYmAjjqCspSLHYxtlyd(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void OpyRZdMtXgcxMfKFBCCQAZdqIocK(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2)
	{
		P_2.ediFexLrNDKWaIiMhJsBUaAgVnRj = ((P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj > P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj) ? P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj : P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj);
		P_2.DwdfBRGyiFbfxVPCpXCjTrJddyJEA = ((P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA > P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA) ? P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA : P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb tBHFpROYtGnfEyRHcEgHzTMJcHrD(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		OpyRZdMtXgcxMfKFBCCQAZdqIocK(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void tqvAFCPuzpkTSfhpXQjLZdbRbNZN(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2)
	{
		P_2.ediFexLrNDKWaIiMhJsBUaAgVnRj = ((P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj < P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj) ? P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj : P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj);
		P_2.DwdfBRGyiFbfxVPCpXCjTrJddyJEA = ((P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA < P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA) ? P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA : P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb MSzorPRIPOQkOmvHAqQznQzKRatM(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		tqvAFCPuzpkTSfhpXQjLZdbRbNZN(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void LmGbqlbjruogmDPjInHTqxRgmcQlc(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1, out YAmGjhmclsjzIhXzibBxmUhWEoZGb P_2)
	{
		float num = P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj * P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj + P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA * P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA;
		P_2.ediFexLrNDKWaIiMhJsBUaAgVnRj = P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj - 2f * num * P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj;
		P_2.DwdfBRGyiFbfxVPCpXCjTrJddyJEA = P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA - 2f * num * P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA;
	}

	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb OOlXRQhgkxsZjaEXYksCGvgMLzvP(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		LmGbqlbjruogmDPjInHTqxRgmcQlc(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void TsOEvAdbGwKUXeiHZJRJgHVcoTGLc(YAmGjhmclsjzIhXzibBxmUhWEoZGb[] P_0, params YAmGjhmclsjzIhXzibBxmUhWEoZGb[] P_1)
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
			YAmGjhmclsjzIhXzibBxmUhWEoZGb yAmGjhmclsjzIhXzibBxmUhWEoZGb = P_1[i];
			for (int j = 0; j < i; j++)
			{
				yAmGjhmclsjzIhXzibBxmUhWEoZGb = PdilEWoTyKZrEWmpKfsyGqAEdSiA(yAmGjhmclsjzIhXzibBxmUhWEoZGb, KfGDJAIsmRdXtlRHwuDZYLmZFtDC(taedKDetjffzSGNtbIidnetBDwvt(P_0[j], yAmGjhmclsjzIhXzibBxmUhWEoZGb) / taedKDetjffzSGNtbIidnetBDwvt(P_0[j], P_0[j]), P_0[j]));
			}
			P_0[i] = yAmGjhmclsjzIhXzibBxmUhWEoZGb;
		}
	}

	public static void iiBLzcLBOAlbsxaiUeARfJIuBPbRA(YAmGjhmclsjzIhXzibBxmUhWEoZGb[] P_0, params YAmGjhmclsjzIhXzibBxmUhWEoZGb[] P_1)
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
			YAmGjhmclsjzIhXzibBxmUhWEoZGb yAmGjhmclsjzIhXzibBxmUhWEoZGb = P_1[i];
			for (int j = 0; j < i; j++)
			{
				yAmGjhmclsjzIhXzibBxmUhWEoZGb = PdilEWoTyKZrEWmpKfsyGqAEdSiA(yAmGjhmclsjzIhXzibBxmUhWEoZGb, KfGDJAIsmRdXtlRHwuDZYLmZFtDC(taedKDetjffzSGNtbIidnetBDwvt(P_0[j], yAmGjhmclsjzIhXzibBxmUhWEoZGb), P_0[j]));
			}
			yAmGjhmclsjzIhXzibBxmUhWEoZGb.lxXpwIOFXCBEuXKCckkFReYawYcm();
			P_0[i] = yAmGjhmclsjzIhXzibBxmUhWEoZGb;
		}
	}

	[SpecialName]
	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb bgZLUIANnHKCczVAfqrIOkQPvWCp(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj + P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA + P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	[SpecialName]
	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb SEzICbKBigQgXzTOmNgxsHytExCc(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj * P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA * P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	[SpecialName]
	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb pVelaTLOGvrIOIeGtvfHlEZwRMdY(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0)
	{
		return P_0;
	}

	[SpecialName]
	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb PdilEWoTyKZrEWmpKfsyGqAEdSiA(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj - P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA - P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	[SpecialName]
	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb KmwSEUZIFpyPxXrFqVqnRtHMKilP(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(0f - P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj, 0f - P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	[SpecialName]
	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb KfGDJAIsmRdXtlRHwuDZYLmZFtDC(float P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj * P_0, P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA * P_0);
	}

	[SpecialName]
	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb rCsPdClPKvaeevQjFXlnCRMWSBoG(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, float P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj * P_1, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA * P_1);
	}

	[SpecialName]
	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb fANEtrqOKkqyRtHrTppqqJgYkiAc(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, float P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj / P_1, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA / P_1);
	}

	[SpecialName]
	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb tDCoakyxDPCGcKiwAbXBSuaQVWzG(float P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0 / P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0 / P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	[SpecialName]
	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb vVPWOPMegVEMiCEBIDUHqNeJOrrFb(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj / P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA / P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	[SpecialName]
	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb eSZlvgBLOFSkHubIpgkeoYvPqTzV(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, float P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj + P_1, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA + P_1);
	}

	[SpecialName]
	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb sdyFVYdaIaenlAOKAZxAgYckHQSEb(float P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0 + P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0 + P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	[SpecialName]
	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb ImcwchtiVgmZAZHzEBqNgjkBpuno(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, float P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj - P_1, P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA - P_1);
	}

	[SpecialName]
	public static YAmGjhmclsjzIhXzibBxmUhWEoZGb vjWIngjtomokwnIzYSDZvzlzeWyK(float P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		return new YAmGjhmclsjzIhXzibBxmUhWEoZGb(P_0 - P_1.ediFexLrNDKWaIiMhJsBUaAgVnRj, P_0 - P_1.DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	[SpecialName]
	public static bool QIUSGSXPFqQrWNRMnBgxkawxpedL(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		return P_0.stZVGGZfHvcxRSIqockkakuKgmqvA(ref P_1);
	}

	[SpecialName]
	public static bool wILBAVoynKWyTTKATMttKVwhFNaO(YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0, YAmGjhmclsjzIhXzibBxmUhWEoZGb P_1)
	{
		return !P_0.stZVGGZfHvcxRSIqockkakuKgmqvA(ref P_1);
	}

	public string wNGjCYFRztqHexqQrGaeIPkMiVAab()
	{
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", ediFexLrNDKWaIiMhJsBUaAgVnRj, DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public string msDdJvbtBPNujYLJgtASLsCejJubb(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", ediFexLrNDKWaIiMhJsBUaAgVnRj.ToString(P_0, CultureInfo.CurrentCulture), DwdfBRGyiFbfxVPCpXCjTrJddyJEA.ToString(P_0, CultureInfo.CurrentCulture));
	}

	public string troRcfKdDrgoCboIdRxgxXXyERQP(IFormatProvider P_0)
	{
		return string.Format(P_0, "X:{0} Y:{1}", ediFexLrNDKWaIiMhJsBUaAgVnRj, DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			troRcfKdDrgoCboIdRxgxXXyERQP(formatProvider);
		}
		return string.Format(formatProvider, "X:{0} Y:{1}", ediFexLrNDKWaIiMhJsBUaAgVnRj.ToString(format, formatProvider), DwdfBRGyiFbfxVPCpXCjTrJddyJEA.ToString(format, formatProvider));
	}

	string IFormattable.ToString(string format, IFormatProvider formatProvider)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ToString
		return this.ToString(format, formatProvider);
	}

	public int HvjpVbAmKaEatSEvdiGoQyEXJoqD()
	{
		return (ediFexLrNDKWaIiMhJsBUaAgVnRj.GetHashCode() * 397) ^ DwdfBRGyiFbfxVPCpXCjTrJddyJEA.GetHashCode();
	}

	public bool stZVGGZfHvcxRSIqockkakuKgmqvA(ref YAmGjhmclsjzIhXzibBxmUhWEoZGb P_0)
	{
		if (qYLtIScOYoBsbgUqSNRAfGRHZXjDB.gKdWOWHWdYvhMdQHzVaBufBvzlbW(P_0.ediFexLrNDKWaIiMhJsBUaAgVnRj, ediFexLrNDKWaIiMhJsBUaAgVnRj))
		{
			return qYLtIScOYoBsbgUqSNRAfGRHZXjDB.gKdWOWHWdYvhMdQHzVaBufBvzlbW(P_0.DwdfBRGyiFbfxVPCpXCjTrJddyJEA, DwdfBRGyiFbfxVPCpXCjTrJddyJEA);
		}
		return false;
	}

	public bool Equals(YAmGjhmclsjzIhXzibBxmUhWEoZGb other)
	{
		return stZVGGZfHvcxRSIqockkakuKgmqvA(ref other);
	}

	bool IEquatable<YAmGjhmclsjzIhXzibBxmUhWEoZGb>.Equals(YAmGjhmclsjzIhXzibBxmUhWEoZGb other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool zWcgxvNGgrglNcjjCGsvMEbzEawf(object P_0)
	{
		if (!(P_0 is YAmGjhmclsjzIhXzibBxmUhWEoZGb yAmGjhmclsjzIhXzibBxmUhWEoZGb))
		{
			return false;
		}
		return stZVGGZfHvcxRSIqockkakuKgmqvA(ref yAmGjhmclsjzIhXzibBxmUhWEoZGb);
	}
}
