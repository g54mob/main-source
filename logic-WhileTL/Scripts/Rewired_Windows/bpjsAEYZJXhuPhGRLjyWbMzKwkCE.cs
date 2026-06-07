using System;

internal static class bpjsAEYZJXhuPhGRLjyWbMzKwkCE
{
	public enum lidqTReXjXWPMAUDRqDjIsuZccNH
	{
		None = 0,
		CombinedTriggers = 1,
		SplitTriggers = 2
	}

	private static Guid[] tMPfpnJLlScsybpWcjXYeBkUHEglB = new Guid[6]
	{
		new Guid("02D1045E-0000-0000-0000-504944564944"),
		new Guid("02DD045E-0000-0000-0000-504944564944"),
		new Guid("02E3045E-0000-0000-0000-504944564944"),
		new Guid("DEEF045E-0000-0000-0000-504944564944"),
		new Guid("02e0045e-0000-0000-0000-504944564944"),
		new Guid("02ff045e-0000-0000-0000-504944564944")
	};

	private static string[] szYCKkxHGOCtJBPNcjAmcAXbFDtVb = new string[4] { "Controller (XBOX One For Windows)", "XBOX One For Windows (Controller)", "XBOX One Controller", "Xbox Bluetooth Gamepad" };

	private const string rsIacBaaHwDWfUMMZSAtlroILPqL = ".*xbox[ \\-]one.*";

	public static string ooLEDNnXdBTKDLBFojYrhjXmiLhO(hxGDxMBOWZLMNKpfanoFVoESKLeWA P_0, Guid P_1, string P_2, string P_3)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		return ySujPrkvKOLyYALifikzBLtGPcSf(P_0.eKJaItNUABpUsMsqmfwGqAnQcgFU, P_1, P_2, P_3) switch
		{
			lidqTReXjXWPMAUDRqDjIsuZccNH.CombinedTriggers => "[CombinedTriggers]", 
			lidqTReXjXWPMAUDRqDjIsuZccNH.SplitTriggers => "[SplitTriggers]", 
			_ => string.Empty, 
		};
	}

	public static lidqTReXjXWPMAUDRqDjIsuZccNH ySujPrkvKOLyYALifikzBLtGPcSf(cPGqREbwwdzisQoEysuCBAVgnOfd[] P_0, Guid P_1, string P_2, string P_3)
	{
		if (!hArTnQoglToHWpVwegHMZxcKawyt(P_1, P_2, P_3))
		{
			return lidqTReXjXWPMAUDRqDjIsuZccNH.None;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i].cWHHTJlxwbBqFnpPZJxJBVsoCWYF == 1 && !P_0[i].eZBoIUUaEMYJmsKJaasmKTuZQRZEA && P_0[i].QtnfHyBCofqceeTFHBMGvCMuljFqB.ccJRqzCgYjAPXCgrDoojypVxFhkTA == 53)
			{
				return lidqTReXjXWPMAUDRqDjIsuZccNH.SplitTriggers;
			}
		}
		return lidqTReXjXWPMAUDRqDjIsuZccNH.CombinedTriggers;
	}

	public static bool hArTnQoglToHWpVwegHMZxcKawyt(Guid P_0, string P_1, string P_2)
	{
		if (Array.IndexOf(tMPfpnJLlScsybpWcjXYeBkUHEglB, P_0) >= 0)
		{
			return true;
		}
		if (hArTnQoglToHWpVwegHMZxcKawyt(P_1))
		{
			return true;
		}
		if (hArTnQoglToHWpVwegHMZxcKawyt(P_2))
		{
			return true;
		}
		return false;
	}

	private static bool hArTnQoglToHWpVwegHMZxcKawyt(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		for (int i = 0; i < szYCKkxHGOCtJBPNcjAmcAXbFDtVb.Length; i++)
		{
			if (szYCKkxHGOCtJBPNcjAmcAXbFDtVb[i].Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}
}
