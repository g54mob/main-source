using System;

internal static class XwFnLxypphHNgefilLFbGvPLvxl
{
	public enum XCoggCWDsKdVafQbzatOdrsuUFLd
	{
		PkbJcFPqmFczuJhwlfomqbZGagG = 0,
		CQTIqiWFaxoFkXIqwzCAZhZCmFW = 1,
		tzJaHlAqNUvdJeLPAGBipltdIPk = 2
	}

	private const string JKccbIWonWAzjDgjdNoGOiNJlIP = ".*xbox[ \\-]one.*";

	private static Guid[] ZTbOyulGRucCyyilVetdBsNMlLVe;

	private static string[] EgiJTxPbcmVvXMgcAkAJhuoYElU;

	public static string WVhPWHLBAhlIDMgWMaWIAyWlQMY(bUiVDUOAHpFECnWVzgHAGOUkHLxZ P_0, Guid P_1, string P_2, string P_3)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		switch (YiWuigQavsrSYNDcJYgMifcVOIz(P_0.ValueCapabilities, P_1, P_2, P_3))
		{
		case XCoggCWDsKdVafQbzatOdrsuUFLd.CQTIqiWFaxoFkXIqwzCAZhZCmFW:
			return "[CombinedTriggers]";
		case XCoggCWDsKdVafQbzatOdrsuUFLd.tzJaHlAqNUvdJeLPAGBipltdIPk:
			return "[SplitTriggers]";
		default:
			return string.Empty;
		}
	}

	public static XCoggCWDsKdVafQbzatOdrsuUFLd YiWuigQavsrSYNDcJYgMifcVOIz(MNqabXBUGXGJuZZXArOzwUlphmK[] P_0, Guid P_1, string P_2, string P_3)
	{
		if (!RKPgaVeMTrfnKxgRCSrnhsVZRfTc(P_1, P_2, P_3))
		{
			return XCoggCWDsKdVafQbzatOdrsuUFLd.PkbJcFPqmFczuJhwlfomqbZGagG;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i].UsagePage == 1 && !P_0[i].IsRange && P_0[i].NotRange.Usage == 53)
			{
				return XCoggCWDsKdVafQbzatOdrsuUFLd.tzJaHlAqNUvdJeLPAGBipltdIPk;
			}
		}
		return XCoggCWDsKdVafQbzatOdrsuUFLd.CQTIqiWFaxoFkXIqwzCAZhZCmFW;
	}

	public static bool RKPgaVeMTrfnKxgRCSrnhsVZRfTc(Guid P_0, string P_1, string P_2)
	{
		if (Array.IndexOf(ZTbOyulGRucCyyilVetdBsNMlLVe, P_0) >= 0)
		{
			goto IL_000e;
		}
		if (RKPgaVeMTrfnKxgRCSrnhsVZRfTc(P_1))
		{
			return true;
		}
		int num;
		if (RKPgaVeMTrfnKxgRCSrnhsVZRfTc(P_2))
		{
			num = 630926172;
			goto IL_0013;
		}
		return false;
		IL_0013:
		switch (num ^ 0x259B2B5E)
		{
		case 0:
			break;
		case 1:
			return true;
		default:
			return true;
		}
		goto IL_000e;
		IL_000e:
		num = 630926175;
		goto IL_0013;
	}

	private static bool RKPgaVeMTrfnKxgRCSrnhsVZRfTc(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			int num2 = 1133590977;
			while (true)
			{
				switch (num2 ^ 0x439139C0)
				{
				case 0:
					break;
				case 1:
					num2 = 1133590978;
					continue;
				case 3:
					return true;
				case 4:
					if (!EgiJTxPbcmVvXMgcAkAJhuoYElU[num].Equals(P_0, StringComparison.OrdinalIgnoreCase))
					{
						num++;
						num2 = 1133590978;
					}
					else
					{
						num2 = 1133590979;
					}
					continue;
				default:
					if (num >= EgiJTxPbcmVvXMgcAkAJhuoYElU.Length)
					{
						return false;
					}
					goto case 4;
				}
				break;
			}
		}
	}

	static XwFnLxypphHNgefilLFbGvPLvxl()
	{
		Guid[] array = new Guid[6];
		string[] array2 = default(string[]);
		while (true)
		{
			int num = 734324897;
			while (true)
			{
				switch (num ^ 0x2BC4E8A9)
				{
				case 0:
					break;
				case 9:
					array[2] = new Guid("02E3045E-0000-0000-0000-504944564944");
					array[3] = new Guid("DEEF045E-0000-0000-0000-504944564944");
					num = 734324911;
					continue;
				case 5:
					array2[1] = "XBOX One For Windows (Controller)";
					num = 734324910;
					continue;
				case 2:
					array[5] = new Guid("02ff045e-0000-0000-0000-504944564944");
					ZTbOyulGRucCyyilVetdBsNMlLVe = array;
					num = 734324909;
					continue;
				case 6:
					array[4] = new Guid("02e0045e-0000-0000-0000-504944564944");
					num = 734324907;
					continue;
				case 8:
					array[0] = new Guid("02D1045E-0000-0000-0000-504944564944");
					num = 734324904;
					continue;
				case 7:
					array2[2] = "XBOX One Controller";
					array2[3] = "Xbox Bluetooth Gamepad";
					num = 734324906;
					continue;
				case 4:
					array2 = new string[4] { "Controller (XBOX One For Windows)", null, null, null };
					num = 734324908;
					continue;
				case 1:
					array[1] = new Guid("02DD045E-0000-0000-0000-504944564944");
					num = 734324896;
					continue;
				default:
					EgiJTxPbcmVvXMgcAkAJhuoYElU = array2;
					return;
				}
				break;
			}
		}
	}
}
