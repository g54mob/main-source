using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[DefaultMember("Item")]
internal struct kCjLSYuWOxFKkLHyhaveFalUixUJ : IEquatable<kCjLSYuWOxFKkLHyhaveFalUixUJ>, IFormattable
{
	public static readonly int oGHwezvedEqfqnNUBKYGVBwAPvjc = Marshal.SizeOf(typeof(kCjLSYuWOxFKkLHyhaveFalUixUJ));

	public static readonly kCjLSYuWOxFKkLHyhaveFalUixUJ gpjrKScjWomBhuddDDfhBZxjAOrRA = default(kCjLSYuWOxFKkLHyhaveFalUixUJ);

	public static readonly kCjLSYuWOxFKkLHyhaveFalUixUJ VtDdAhZIeHhdfeRcCUiSKdKySEggA = new kCjLSYuWOxFKkLHyhaveFalUixUJ(1f, 0f);

	public static readonly kCjLSYuWOxFKkLHyhaveFalUixUJ CVdusEhTAIcBdAncnyPRqiODDhZgA = new kCjLSYuWOxFKkLHyhaveFalUixUJ(0f, 1f);

	public static readonly kCjLSYuWOxFKkLHyhaveFalUixUJ aAXUDCFeLmzMBPNQoBayAitjBVcU = new kCjLSYuWOxFKkLHyhaveFalUixUJ(1f, 1f);

	public float UMpmxOJnmKcyMGzVomNYJtQcNlWH;

	public float rjuddsmBOELpRNJKudGyIHZngCII;

	public bool VOEXRGkwkhmpQsizwBYwHHfqpeux => UcCeYpwbshUhRQvPRsUTXJHBTFch.jKZANgXLVNdQrLvfJUocLEUEZHkS(UMpmxOJnmKcyMGzVomNYJtQcNlWH * UMpmxOJnmKcyMGzVomNYJtQcNlWH + rjuddsmBOELpRNJKudGyIHZngCII * rjuddsmBOELpRNJKudGyIHZngCII);

	public bool PpKHdlTGvLhmsydnVcgnMiMACZDu
	{
		get
		{
			if (UMpmxOJnmKcyMGzVomNYJtQcNlWH == 0f)
			{
				return rjuddsmBOELpRNJKudGyIHZngCII == 0f;
			}
			return false;
		}
	}

	public float PXcZZKDtWPSgoSuOxasUdNkgbeAjA
	{
		get
		{
			return P_0 switch
			{
				0 => UMpmxOJnmKcyMGzVomNYJtQcNlWH, 
				1 => rjuddsmBOELpRNJKudGyIHZngCII, 
				_ => throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive."), 
			};
		}
		set
		{
			switch (num)
			{
			case 0:
				UMpmxOJnmKcyMGzVomNYJtQcNlWH = uMpmxOJnmKcyMGzVomNYJtQcNlWH;
				break;
			case 1:
				rjuddsmBOELpRNJKudGyIHZngCII = uMpmxOJnmKcyMGzVomNYJtQcNlWH;
				break;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
	}

	public kCjLSYuWOxFKkLHyhaveFalUixUJ(float P_0)
	{
		UMpmxOJnmKcyMGzVomNYJtQcNlWH = P_0;
		rjuddsmBOELpRNJKudGyIHZngCII = P_0;
	}

	public kCjLSYuWOxFKkLHyhaveFalUixUJ(float P_0, float P_1)
	{
		UMpmxOJnmKcyMGzVomNYJtQcNlWH = P_0;
		rjuddsmBOELpRNJKudGyIHZngCII = P_1;
	}

	public kCjLSYuWOxFKkLHyhaveFalUixUJ(float[] P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("values");
		}
		if (P_0.Length != 2)
		{
			throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
		}
		UMpmxOJnmKcyMGzVomNYJtQcNlWH = P_0[0];
		rjuddsmBOELpRNJKudGyIHZngCII = P_0[1];
	}

	public float DzjCssGqNaCIfaEzyVJGCeHDWEIob()
	{
		return (float)Math.Sqrt(UMpmxOJnmKcyMGzVomNYJtQcNlWH * UMpmxOJnmKcyMGzVomNYJtQcNlWH + rjuddsmBOELpRNJKudGyIHZngCII * rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public float uzdCSibNFcyWLtHFRdEyJXcrOULJA()
	{
		return UMpmxOJnmKcyMGzVomNYJtQcNlWH * UMpmxOJnmKcyMGzVomNYJtQcNlWH + rjuddsmBOELpRNJKudGyIHZngCII * rjuddsmBOELpRNJKudGyIHZngCII;
	}

	public void ZqSHRzSnyXBoYBCLjpDGQkIwvUzO()
	{
		float num = DzjCssGqNaCIfaEzyVJGCeHDWEIob();
		if (!UcCeYpwbshUhRQvPRsUTXJHBTFch.BqyrCGuMubcBSHovkhkOzQJSdqoHA(num))
		{
			float num2 = 1f / num;
			UMpmxOJnmKcyMGzVomNYJtQcNlWH *= num2;
			rjuddsmBOELpRNJKudGyIHZngCII *= num2;
		}
	}

	public float[] OPtkxTwcfiiuhxRWEviXxUnDwszJ()
	{
		return new float[2] { UMpmxOJnmKcyMGzVomNYJtQcNlWH, rjuddsmBOELpRNJKudGyIHZngCII };
	}

	public static void PcGOCxlclGZFKcfaOaUqRehKnPSx(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_2)
	{
		P_2 = new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH + P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0.rjuddsmBOELpRNJKudGyIHZngCII + P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ WuaeAGVnbWOzRcgKFqVcagxzhldW(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH + P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0.rjuddsmBOELpRNJKudGyIHZngCII + P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public static void udgSiLzfCvXXRmSxSMmYjreYUeZM(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref float P_1, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_2)
	{
		P_2 = new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH + P_1, P_0.rjuddsmBOELpRNJKudGyIHZngCII + P_1);
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ GQdszipcNvHIziYgKbJkBXnLDZDuA(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, float P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH + P_1, P_0.rjuddsmBOELpRNJKudGyIHZngCII + P_1);
	}

	public static void RftqrSzOXnVonJhUIEdsKbHUnCBwA(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_2)
	{
		P_2 = new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH - P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0.rjuddsmBOELpRNJKudGyIHZngCII - P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ PyjHExhGeWLyTVTOkRItEfLTADWS(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH - P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0.rjuddsmBOELpRNJKudGyIHZngCII - P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public static void DuZtTQRoEMAxwDYYfQxsWjiEFQtD(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref float P_1, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_2)
	{
		P_2 = new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH - P_1, P_0.rjuddsmBOELpRNJKudGyIHZngCII - P_1);
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ AipSUQMPyldNibFbEqsIGsHAkVut(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, float P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH - P_1, P_0.rjuddsmBOELpRNJKudGyIHZngCII - P_1);
	}

	public static void BuADKrAydfEzbDrpcHInAseYQnFU(ref float P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_2)
	{
		P_2 = new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0 - P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0 - P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ cYGgSajbfBvySnGuEujrYXWhYaeI(float P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0 - P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0 - P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public static void anqqAfgpawokZXKhXvPPgIbRRXnC(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, float P_1, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_2)
	{
		P_2 = new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH * P_1, P_0.rjuddsmBOELpRNJKudGyIHZngCII * P_1);
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ SbiAKrbRuxFJqBuUiwGhJiYfCAyFA(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, float P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH * P_1, P_0.rjuddsmBOELpRNJKudGyIHZngCII * P_1);
	}

	public static void bXRAxCxnridgisuvgBRhfBvdCupVA(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_2)
	{
		P_2 = new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH * P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0.rjuddsmBOELpRNJKudGyIHZngCII * P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ cXSMjGTsjppitPENjXOIFKgPAkzX(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH * P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0.rjuddsmBOELpRNJKudGyIHZngCII * P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public static void zeafrcgujSwPTbBBjZJcQDatTWPPA(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, float P_1, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_2)
	{
		P_2 = new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH / P_1, P_0.rjuddsmBOELpRNJKudGyIHZngCII / P_1);
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ lwDVKdDYvzfQfDTFFqjBCEoogrfFA(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, float P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH / P_1, P_0.rjuddsmBOELpRNJKudGyIHZngCII / P_1);
	}

	public static void ECTJZHxqQWqVDkAdqzsRVYqrJzIp(float P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_2)
	{
		P_2 = new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0 / P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0 / P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ WnSpQZSETsgxKOFsLiHGVrWjDBDm(float P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0 / P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0 / P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public static void jBlQRxBRWGkDuibvXpuYljkBEslw(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		P_1 = new kCjLSYuWOxFKkLHyhaveFalUixUJ(0f - P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH, 0f - P_0.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ irbxKkYSwVlbeDCLawbIpqeAZgbJ(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(0f - P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH, 0f - P_0.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public static void EqoajFiEuBKUBWFeQBTeCjoyxsmk(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_2, float P_3, float P_4, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_5)
	{
		P_5 = new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH + P_3 * (P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH - P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH) + P_4 * (P_2.UMpmxOJnmKcyMGzVomNYJtQcNlWH - P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH), P_0.rjuddsmBOELpRNJKudGyIHZngCII + P_3 * (P_1.rjuddsmBOELpRNJKudGyIHZngCII - P_0.rjuddsmBOELpRNJKudGyIHZngCII) + P_4 * (P_2.rjuddsmBOELpRNJKudGyIHZngCII - P_0.rjuddsmBOELpRNJKudGyIHZngCII));
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ FiaHKaFFiinhrKPCbiKjJPcJeEbA(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, kCjLSYuWOxFKkLHyhaveFalUixUJ P_2, float P_3, float P_4)
	{
		EqoajFiEuBKUBWFeQBTeCjoyxsmk(ref P_0, ref P_1, ref P_2, P_3, P_4, out var result);
		return result;
	}

	public static void hgDjQwJdRbGlrHhSEePyktlUNiTac(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_2, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_3)
	{
		float uMpmxOJnmKcyMGzVomNYJtQcNlWH = P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH;
		uMpmxOJnmKcyMGzVomNYJtQcNlWH = ((uMpmxOJnmKcyMGzVomNYJtQcNlWH > P_2.UMpmxOJnmKcyMGzVomNYJtQcNlWH) ? P_2.UMpmxOJnmKcyMGzVomNYJtQcNlWH : uMpmxOJnmKcyMGzVomNYJtQcNlWH);
		uMpmxOJnmKcyMGzVomNYJtQcNlWH = ((uMpmxOJnmKcyMGzVomNYJtQcNlWH < P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH) ? P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH : uMpmxOJnmKcyMGzVomNYJtQcNlWH);
		float num = P_0.rjuddsmBOELpRNJKudGyIHZngCII;
		num = ((num > P_2.rjuddsmBOELpRNJKudGyIHZngCII) ? P_2.rjuddsmBOELpRNJKudGyIHZngCII : num);
		num = ((num < P_1.rjuddsmBOELpRNJKudGyIHZngCII) ? P_1.rjuddsmBOELpRNJKudGyIHZngCII : num);
		P_3 = new kCjLSYuWOxFKkLHyhaveFalUixUJ(uMpmxOJnmKcyMGzVomNYJtQcNlWH, num);
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ hcKaIxjlvGbhhAXnpBxeFoUClfVQB(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, kCjLSYuWOxFKkLHyhaveFalUixUJ P_2)
	{
		hgDjQwJdRbGlrHhSEePyktlUNiTac(ref P_0, ref P_1, ref P_2, out var result);
		return result;
	}

	public void VdaMyCmXNHoYEuGFnAndBQDxBpwHA()
	{
		UMpmxOJnmKcyMGzVomNYJtQcNlWH = ((UMpmxOJnmKcyMGzVomNYJtQcNlWH < 0f) ? 0f : ((UMpmxOJnmKcyMGzVomNYJtQcNlWH > 1f) ? 1f : UMpmxOJnmKcyMGzVomNYJtQcNlWH));
		rjuddsmBOELpRNJKudGyIHZngCII = ((rjuddsmBOELpRNJKudGyIHZngCII < 0f) ? 0f : ((rjuddsmBOELpRNJKudGyIHZngCII > 1f) ? 1f : rjuddsmBOELpRNJKudGyIHZngCII));
	}

	public static void nbLKCMRLyjfYtJpQzfVehjUzkPZG(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, out float P_2)
	{
		float num = P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH - P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH;
		float num2 = P_0.rjuddsmBOELpRNJKudGyIHZngCII - P_1.rjuddsmBOELpRNJKudGyIHZngCII;
		P_2 = (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float tfsKnMQLEdilWBWziIpUaJZEZaaDA(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		float num = P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH - P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH;
		float num2 = P_0.rjuddsmBOELpRNJKudGyIHZngCII - P_1.rjuddsmBOELpRNJKudGyIHZngCII;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static void HjglfJlKEOiRRrZabJwLHBVRzZlj(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, out float P_2)
	{
		float num = P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH - P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH;
		float num2 = P_0.rjuddsmBOELpRNJKudGyIHZngCII - P_1.rjuddsmBOELpRNJKudGyIHZngCII;
		P_2 = num * num + num2 * num2;
	}

	public static float QgXkSgbBCuimldrGoNfHdgOLmXmAA(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		float num = P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH - P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH;
		float num2 = P_0.rjuddsmBOELpRNJKudGyIHZngCII - P_1.rjuddsmBOELpRNJKudGyIHZngCII;
		return num * num + num2 * num2;
	}

	public static void oYCdxNYVGyyZpfjrZtenanNEyIzQ(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, out float P_2)
	{
		P_2 = P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH * P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH + P_0.rjuddsmBOELpRNJKudGyIHZngCII * P_1.rjuddsmBOELpRNJKudGyIHZngCII;
	}

	public static float NaxoTmkmGqSNwWcwmanmCabRbowUA(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		return P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH * P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH + P_0.rjuddsmBOELpRNJKudGyIHZngCII * P_1.rjuddsmBOELpRNJKudGyIHZngCII;
	}

	public static void EUtcZYBnGIsHLWsGzCTACtTnXEYo(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		P_1 = P_0;
		P_1.ZqSHRzSnyXBoYBCLjpDGQkIwvUzO();
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ GfybstCOlExlWmwwQdjqFLGHlkLQ(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0)
	{
		P_0.ZqSHRzSnyXBoYBCLjpDGQkIwvUzO();
		return P_0;
	}

	public static void DgLesJqdRIBiwLToTZKBRttlNeoh(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, float P_2, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_3)
	{
		P_3.UMpmxOJnmKcyMGzVomNYJtQcNlWH = UcCeYpwbshUhRQvPRsUTXJHBTFch.tyXkjzGqfuPCYwdjESxMcbLzOZcd(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_2);
		P_3.rjuddsmBOELpRNJKudGyIHZngCII = UcCeYpwbshUhRQvPRsUTXJHBTFch.tyXkjzGqfuPCYwdjESxMcbLzOZcd(P_0.rjuddsmBOELpRNJKudGyIHZngCII, P_1.rjuddsmBOELpRNJKudGyIHZngCII, P_2);
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ NMThUqlzGpcrebILFNXQYDErKSxm(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, float P_2)
	{
		DgLesJqdRIBiwLToTZKBRttlNeoh(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void rlDdbIulgUSzLWXwuglZyDTWtNrR(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, float P_2, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_3)
	{
		P_2 = UcCeYpwbshUhRQvPRsUTXJHBTFch.RBPRtuCGkQlQnkrZOcFgoExwgNBz(P_2);
		DgLesJqdRIBiwLToTZKBRttlNeoh(ref P_0, ref P_1, P_2, out P_3);
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ GmVtHSKGQixQNIaTVMfvPvXPMasQ(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, float P_2)
	{
		rlDdbIulgUSzLWXwuglZyDTWtNrR(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void biCSkPQFvVYWcoGPBXeBnbCfkBtg(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_2, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_3, float P_4, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + P_4;
		float num6 = num2 - num;
		P_5.UMpmxOJnmKcyMGzVomNYJtQcNlWH = P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH * num3 + P_2.UMpmxOJnmKcyMGzVomNYJtQcNlWH * num4 + P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH * num5 + P_3.UMpmxOJnmKcyMGzVomNYJtQcNlWH * num6;
		P_5.rjuddsmBOELpRNJKudGyIHZngCII = P_0.rjuddsmBOELpRNJKudGyIHZngCII * num3 + P_2.rjuddsmBOELpRNJKudGyIHZngCII * num4 + P_1.rjuddsmBOELpRNJKudGyIHZngCII * num5 + P_3.rjuddsmBOELpRNJKudGyIHZngCII * num6;
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ jhLrsjCLPKulziRtFoZvqDCmVweJ(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, kCjLSYuWOxFKkLHyhaveFalUixUJ P_2, kCjLSYuWOxFKkLHyhaveFalUixUJ P_3, float P_4)
	{
		biCSkPQFvVYWcoGPBXeBnbCfkBtg(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void UEgIzUlvYRysqxqoZfBRWRHhcjdCA(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_2, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_3, float P_4, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		P_5.UMpmxOJnmKcyMGzVomNYJtQcNlWH = 0.5f * (2f * P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH + (0f - P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH + P_2.UMpmxOJnmKcyMGzVomNYJtQcNlWH) * P_4 + (2f * P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH - 5f * P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH + 4f * P_2.UMpmxOJnmKcyMGzVomNYJtQcNlWH - P_3.UMpmxOJnmKcyMGzVomNYJtQcNlWH) * num + (0f - P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH + 3f * P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH - 3f * P_2.UMpmxOJnmKcyMGzVomNYJtQcNlWH + P_3.UMpmxOJnmKcyMGzVomNYJtQcNlWH) * num2);
		P_5.rjuddsmBOELpRNJKudGyIHZngCII = 0.5f * (2f * P_1.rjuddsmBOELpRNJKudGyIHZngCII + (0f - P_0.rjuddsmBOELpRNJKudGyIHZngCII + P_2.rjuddsmBOELpRNJKudGyIHZngCII) * P_4 + (2f * P_0.rjuddsmBOELpRNJKudGyIHZngCII - 5f * P_1.rjuddsmBOELpRNJKudGyIHZngCII + 4f * P_2.rjuddsmBOELpRNJKudGyIHZngCII - P_3.rjuddsmBOELpRNJKudGyIHZngCII) * num + (0f - P_0.rjuddsmBOELpRNJKudGyIHZngCII + 3f * P_1.rjuddsmBOELpRNJKudGyIHZngCII - 3f * P_2.rjuddsmBOELpRNJKudGyIHZngCII + P_3.rjuddsmBOELpRNJKudGyIHZngCII) * num2);
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ svDKFOrxvSOOqnQENTWElMAQwgEK(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, kCjLSYuWOxFKkLHyhaveFalUixUJ P_2, kCjLSYuWOxFKkLHyhaveFalUixUJ P_3, float P_4)
	{
		UEgIzUlvYRysqxqoZfBRWRHhcjdCA(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void ipjshOMZsrBQatQMIarVJPxolUdQ(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_2)
	{
		P_2.UMpmxOJnmKcyMGzVomNYJtQcNlWH = ((P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH > P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH) ? P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH : P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH);
		P_2.rjuddsmBOELpRNJKudGyIHZngCII = ((P_0.rjuddsmBOELpRNJKudGyIHZngCII > P_1.rjuddsmBOELpRNJKudGyIHZngCII) ? P_0.rjuddsmBOELpRNJKudGyIHZngCII : P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ LnSsdiCozZULumJMtgvSHwBHQmaTA(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		ipjshOMZsrBQatQMIarVJPxolUdQ(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void NqsmmnJlWuoGuzIcQrxEWXbVWJGs(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_2)
	{
		P_2.UMpmxOJnmKcyMGzVomNYJtQcNlWH = ((P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH < P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH) ? P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH : P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH);
		P_2.rjuddsmBOELpRNJKudGyIHZngCII = ((P_0.rjuddsmBOELpRNJKudGyIHZngCII < P_1.rjuddsmBOELpRNJKudGyIHZngCII) ? P_0.rjuddsmBOELpRNJKudGyIHZngCII : P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ kXoTkqZwuRYHewtCXpHygahQsusG(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		NqsmmnJlWuoGuzIcQrxEWXbVWJGs(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void vRScOpEGdJECPIsiciObwJqraZbA(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_1, out kCjLSYuWOxFKkLHyhaveFalUixUJ P_2)
	{
		float num = P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH * P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH + P_0.rjuddsmBOELpRNJKudGyIHZngCII * P_1.rjuddsmBOELpRNJKudGyIHZngCII;
		P_2.UMpmxOJnmKcyMGzVomNYJtQcNlWH = P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH - 2f * num * P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH;
		P_2.rjuddsmBOELpRNJKudGyIHZngCII = P_0.rjuddsmBOELpRNJKudGyIHZngCII - 2f * num * P_1.rjuddsmBOELpRNJKudGyIHZngCII;
	}

	public static kCjLSYuWOxFKkLHyhaveFalUixUJ aNylovfiNivxFwOQLDPNTwsCpLgl(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		vRScOpEGdJECPIsiciObwJqraZbA(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void dKPLbfhnTrqkzcGeGoZCSFouLlDC(kCjLSYuWOxFKkLHyhaveFalUixUJ[] P_0, params kCjLSYuWOxFKkLHyhaveFalUixUJ[] P_1)
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
			kCjLSYuWOxFKkLHyhaveFalUixUJ kCjLSYuWOxFKkLHyhaveFalUixUJ2 = P_1[i];
			for (int j = 0; j < i; j++)
			{
				kCjLSYuWOxFKkLHyhaveFalUixUJ2 = rJkbJjjGmljtJMYxeAGvmrqKJpJEb(kCjLSYuWOxFKkLHyhaveFalUixUJ2, edPgjzaGBEvBzrzEfdBQHTNBNPWLb(NaxoTmkmGqSNwWcwmanmCabRbowUA(P_0[j], kCjLSYuWOxFKkLHyhaveFalUixUJ2) / NaxoTmkmGqSNwWcwmanmCabRbowUA(P_0[j], P_0[j]), P_0[j]));
			}
			P_0[i] = kCjLSYuWOxFKkLHyhaveFalUixUJ2;
		}
	}

	public static void WiURyDBCvNVoMrftLrIWKCCwVpoi(kCjLSYuWOxFKkLHyhaveFalUixUJ[] P_0, params kCjLSYuWOxFKkLHyhaveFalUixUJ[] P_1)
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
			kCjLSYuWOxFKkLHyhaveFalUixUJ kCjLSYuWOxFKkLHyhaveFalUixUJ2 = P_1[i];
			for (int j = 0; j < i; j++)
			{
				kCjLSYuWOxFKkLHyhaveFalUixUJ2 = rJkbJjjGmljtJMYxeAGvmrqKJpJEb(kCjLSYuWOxFKkLHyhaveFalUixUJ2, edPgjzaGBEvBzrzEfdBQHTNBNPWLb(NaxoTmkmGqSNwWcwmanmCabRbowUA(P_0[j], kCjLSYuWOxFKkLHyhaveFalUixUJ2), P_0[j]));
			}
			kCjLSYuWOxFKkLHyhaveFalUixUJ2.ZqSHRzSnyXBoYBCLjpDGQkIwvUzO();
			P_0[i] = kCjLSYuWOxFKkLHyhaveFalUixUJ2;
		}
	}

	[SpecialName]
	public static kCjLSYuWOxFKkLHyhaveFalUixUJ LlGaWxCEQYiLYxDTaIILPgINnAFO(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH + P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0.rjuddsmBOELpRNJKudGyIHZngCII + P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	[SpecialName]
	public static kCjLSYuWOxFKkLHyhaveFalUixUJ eRgDmzjYqpBetfpOjNextbZlLWudb(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH * P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0.rjuddsmBOELpRNJKudGyIHZngCII * P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	[SpecialName]
	public static kCjLSYuWOxFKkLHyhaveFalUixUJ DmhSyyZBnikPoCoVeGxEoLwgEYcC(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0)
	{
		return P_0;
	}

	[SpecialName]
	public static kCjLSYuWOxFKkLHyhaveFalUixUJ rJkbJjjGmljtJMYxeAGvmrqKJpJEb(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH - P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0.rjuddsmBOELpRNJKudGyIHZngCII - P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	[SpecialName]
	public static kCjLSYuWOxFKkLHyhaveFalUixUJ abzkkpVyFwzkZXOezDPkCFJQayuc(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(0f - P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH, 0f - P_0.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	[SpecialName]
	public static kCjLSYuWOxFKkLHyhaveFalUixUJ edPgjzaGBEvBzrzEfdBQHTNBNPWLb(float P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH * P_0, P_1.rjuddsmBOELpRNJKudGyIHZngCII * P_0);
	}

	[SpecialName]
	public static kCjLSYuWOxFKkLHyhaveFalUixUJ PFbfpbFfwcLSEctVdCgyTBZEKWvxB(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, float P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH * P_1, P_0.rjuddsmBOELpRNJKudGyIHZngCII * P_1);
	}

	[SpecialName]
	public static kCjLSYuWOxFKkLHyhaveFalUixUJ VdYCwMiejhVIGEpQASOworHETsfJA(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, float P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH / P_1, P_0.rjuddsmBOELpRNJKudGyIHZngCII / P_1);
	}

	[SpecialName]
	public static kCjLSYuWOxFKkLHyhaveFalUixUJ VGPfQFhkWYsqUDQtJvOWVZuStDyY(float P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0 / P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0 / P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	[SpecialName]
	public static kCjLSYuWOxFKkLHyhaveFalUixUJ DUQkekMXsYqZSOEMVzCvYivPrcnc(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH / P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0.rjuddsmBOELpRNJKudGyIHZngCII / P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	[SpecialName]
	public static kCjLSYuWOxFKkLHyhaveFalUixUJ IcCSRXTSpCIuxssBebDfvnfFsDyT(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, float P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH + P_1, P_0.rjuddsmBOELpRNJKudGyIHZngCII + P_1);
	}

	[SpecialName]
	public static kCjLSYuWOxFKkLHyhaveFalUixUJ MfrhgdenalVPJIFfGAXFZifyARLE(float P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0 + P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0 + P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	[SpecialName]
	public static kCjLSYuWOxFKkLHyhaveFalUixUJ uKrSEKhKwbvkyNciDZhCtiiDhkqp(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, float P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH - P_1, P_0.rjuddsmBOELpRNJKudGyIHZngCII - P_1);
	}

	[SpecialName]
	public static kCjLSYuWOxFKkLHyhaveFalUixUJ TbNcNNhiLjaASkleTMqGksjlSalmA(float P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		return new kCjLSYuWOxFKkLHyhaveFalUixUJ(P_0 - P_1.UMpmxOJnmKcyMGzVomNYJtQcNlWH, P_0 - P_1.rjuddsmBOELpRNJKudGyIHZngCII);
	}

	[SpecialName]
	public static bool gNNoglXoavaceRoQsWoyvDqtlzsR(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		return P_0.OWSgzbHacyNovGzebRzfjwMKkwve(ref P_1);
	}

	[SpecialName]
	public static bool WcCIuycAIHIQviDDQCSwRHanOHnDA(kCjLSYuWOxFKkLHyhaveFalUixUJ P_0, kCjLSYuWOxFKkLHyhaveFalUixUJ P_1)
	{
		return !P_0.OWSgzbHacyNovGzebRzfjwMKkwve(ref P_1);
	}

	public string EPLbknTJYwenSvwDoPNxEraSjFRo()
	{
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", UMpmxOJnmKcyMGzVomNYJtQcNlWH, rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public string WfIjMLdwMxOXZDQxXrBulMwrXnz(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", UMpmxOJnmKcyMGzVomNYJtQcNlWH.ToString(P_0, CultureInfo.CurrentCulture), rjuddsmBOELpRNJKudGyIHZngCII.ToString(P_0, CultureInfo.CurrentCulture));
	}

	public string JmnrrWQxekGYmjSBeMAdsEDwCZHaA(IFormatProvider P_0)
	{
		return string.Format(P_0, "X:{0} Y:{1}", UMpmxOJnmKcyMGzVomNYJtQcNlWH, rjuddsmBOELpRNJKudGyIHZngCII);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			JmnrrWQxekGYmjSBeMAdsEDwCZHaA(formatProvider);
		}
		return string.Format(formatProvider, "X:{0} Y:{1}", UMpmxOJnmKcyMGzVomNYJtQcNlWH.ToString(format, formatProvider), rjuddsmBOELpRNJKudGyIHZngCII.ToString(format, formatProvider));
	}

	string IFormattable.ToString(string format, IFormatProvider formatProvider)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ToString
		return this.ToString(format, formatProvider);
	}

	public int vgswZKOGFzeqLOcVyYLbFNkBpXbN()
	{
		return (UMpmxOJnmKcyMGzVomNYJtQcNlWH.GetHashCode() * 397) ^ rjuddsmBOELpRNJKudGyIHZngCII.GetHashCode();
	}

	public bool OWSgzbHacyNovGzebRzfjwMKkwve(ref kCjLSYuWOxFKkLHyhaveFalUixUJ P_0)
	{
		if (UcCeYpwbshUhRQvPRsUTXJHBTFch.SjigjnNDIZHEmxaSacXEnxNrIpot(P_0.UMpmxOJnmKcyMGzVomNYJtQcNlWH, UMpmxOJnmKcyMGzVomNYJtQcNlWH))
		{
			return UcCeYpwbshUhRQvPRsUTXJHBTFch.SjigjnNDIZHEmxaSacXEnxNrIpot(P_0.rjuddsmBOELpRNJKudGyIHZngCII, rjuddsmBOELpRNJKudGyIHZngCII);
		}
		return false;
	}

	public bool Equals(kCjLSYuWOxFKkLHyhaveFalUixUJ other)
	{
		return OWSgzbHacyNovGzebRzfjwMKkwve(ref other);
	}

	bool IEquatable<kCjLSYuWOxFKkLHyhaveFalUixUJ>.Equals(kCjLSYuWOxFKkLHyhaveFalUixUJ other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool RdvwYAZMpeLKtwteXjtcJkKpCIjQ(object P_0)
	{
		if (!(P_0 is kCjLSYuWOxFKkLHyhaveFalUixUJ kCjLSYuWOxFKkLHyhaveFalUixUJ2))
		{
			return false;
		}
		return OWSgzbHacyNovGzebRzfjwMKkwve(ref kCjLSYuWOxFKkLHyhaveFalUixUJ2);
	}
}
