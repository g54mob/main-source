using System;

internal static class lzpGQZeHakGDDmaDjJrfCidOgxoBA
{
	public enum aHsvNzJLFZsrfFMrEuXqvCNtscOA
	{
		None = 0,
		CombinedTriggers = 1,
		SplitTriggers = 2
	}

	private static Guid[] dXyfsLFDNcCwMfaopSEKJLnKVtmg = new Guid[6]
	{
		new Guid("02D1045E-0000-0000-0000-504944564944"),
		new Guid("02DD045E-0000-0000-0000-504944564944"),
		new Guid("02E3045E-0000-0000-0000-504944564944"),
		new Guid("DEEF045E-0000-0000-0000-504944564944"),
		new Guid("02e0045e-0000-0000-0000-504944564944"),
		new Guid("02ff045e-0000-0000-0000-504944564944")
	};

	private static string[] CAYpJWTBjgvpPrqZvSLFCwYaIsWj = new string[4] { "Controller (XBOX One For Windows)", "XBOX One For Windows (Controller)", "XBOX One Controller", "Xbox Bluetooth Gamepad" };

	public static string CzRoBXbUDDJJTueJveBwfDmRAYPP(fbWJHXusdeGbDiqkAkaaPIlKQOKp P_0, Guid P_1, string P_2, string P_3)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		return CiMtAyTlBxhWOwPLiOdCctyCygkn(P_0.RwrtRAthKHPjLccuWIWOtwdGvkYm, P_1, P_2, P_3) switch
		{
			aHsvNzJLFZsrfFMrEuXqvCNtscOA.CombinedTriggers => "[CombinedTriggers]", 
			aHsvNzJLFZsrfFMrEuXqvCNtscOA.SplitTriggers => "[SplitTriggers]", 
			_ => string.Empty, 
		};
	}

	public static aHsvNzJLFZsrfFMrEuXqvCNtscOA CiMtAyTlBxhWOwPLiOdCctyCygkn(skAACZTTBWIGqBZjCeplkKpqusVj[] P_0, Guid P_1, string P_2, string P_3)
	{
		if (!sylSKwqabjxyWZzhPKRDHNiOIOtQ(P_1, P_2, P_3))
		{
			return aHsvNzJLFZsrfFMrEuXqvCNtscOA.None;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i].FUwhFDCIIxbQSWmvAcLYcsmPORtW == 1 && !P_0[i].SOAflKjHIBWUrNNWWeMokkUnGdmbb && P_0[i].ONNiqBpQWmKcTxshbmfLfTPBjbum.OybLvxPAoHoTiiDmOplYQlyopjJb == 53)
			{
				return aHsvNzJLFZsrfFMrEuXqvCNtscOA.SplitTriggers;
			}
		}
		return aHsvNzJLFZsrfFMrEuXqvCNtscOA.CombinedTriggers;
	}

	public static bool sylSKwqabjxyWZzhPKRDHNiOIOtQ(Guid P_0, string P_1, string P_2)
	{
		if (Array.IndexOf(dXyfsLFDNcCwMfaopSEKJLnKVtmg, P_0) >= 0)
		{
			return true;
		}
		if (GjDnqfHTKgsPckevvdASjMutAkFoA(P_1))
		{
			return true;
		}
		if (GjDnqfHTKgsPckevvdASjMutAkFoA(P_2))
		{
			return true;
		}
		return false;
	}

	private static bool GjDnqfHTKgsPckevvdASjMutAkFoA(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		for (int i = 0; i < CAYpJWTBjgvpPrqZvSLFCwYaIsWj.Length; i++)
		{
			if (CAYpJWTBjgvpPrqZvSLFCwYaIsWj[i].Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}
}
