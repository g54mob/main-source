using System;

internal static class ZKLIjvmxtRjTyokzJnlXgDPvgmC
{
	public enum VXRfFfiRPTFvrRPnRyWdTNHALqp
	{
		XzhcXffXatYTRpTiRyDKgAvaprhV = 0,
		KFXDVGiYuRXpXFLmEXwwOjtunUfO = 1,
		pPSmVOOLmjPodkNaOlWoDNBLQLQ = 2
	}

	private const string TmBMsdOtDmRUwBjDJOoCorgjBcu = ".*xbox[ \\-]one.*";

	private static Guid[] FHbUVChTPONoJopvbtXZOolkiWk = new Guid[6]
	{
		new Guid("02D1045E-0000-0000-0000-504944564944"),
		new Guid("02DD045E-0000-0000-0000-504944564944"),
		new Guid("02E3045E-0000-0000-0000-504944564944"),
		new Guid("DEEF045E-0000-0000-0000-504944564944"),
		new Guid("02e0045e-0000-0000-0000-504944564944"),
		new Guid("02ff045e-0000-0000-0000-504944564944")
	};

	private static string[] KTmgZJDccKnneSaugKInHJWuTfx = new string[4] { "Controller (XBOX One For Windows)", "XBOX One For Windows (Controller)", "XBOX One Controller", "Xbox Bluetooth Gamepad" };

	public static string YknolmFaNNBJmSzmqGIcasMPdBrK(VaqvDpgkuJiGiwrYcarAfGJvBwg P_0, Guid P_1, string P_2, string P_3)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		return OXORHIGCyIBWbZyJdmxoChKbRXQ(P_0.ValueCapabilities, P_1, P_2, P_3) switch
		{
			VXRfFfiRPTFvrRPnRyWdTNHALqp.KFXDVGiYuRXpXFLmEXwwOjtunUfO => "[CombinedTriggers]", 
			VXRfFfiRPTFvrRPnRyWdTNHALqp.pPSmVOOLmjPodkNaOlWoDNBLQLQ => "[SplitTriggers]", 
			_ => string.Empty, 
		};
	}

	public static VXRfFfiRPTFvrRPnRyWdTNHALqp OXORHIGCyIBWbZyJdmxoChKbRXQ(EYmOazTOIpjiDNDnyssTMNYXnGh[] P_0, Guid P_1, string P_2, string P_3)
	{
		if (!BVHeJtCJXPFBfGgHsARPRMvrhkyB(P_1, P_2, P_3))
		{
			return VXRfFfiRPTFvrRPnRyWdTNHALqp.XzhcXffXatYTRpTiRyDKgAvaprhV;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i].UsagePage == 1 && !P_0[i].IsRange && P_0[i].NotRange.Usage == 53)
			{
				return VXRfFfiRPTFvrRPnRyWdTNHALqp.pPSmVOOLmjPodkNaOlWoDNBLQLQ;
			}
		}
		return VXRfFfiRPTFvrRPnRyWdTNHALqp.KFXDVGiYuRXpXFLmEXwwOjtunUfO;
	}

	public static bool BVHeJtCJXPFBfGgHsARPRMvrhkyB(Guid P_0, string P_1, string P_2)
	{
		if (Array.IndexOf(FHbUVChTPONoJopvbtXZOolkiWk, P_0) >= 0)
		{
			return true;
		}
		if (BVHeJtCJXPFBfGgHsARPRMvrhkyB(P_1))
		{
			return true;
		}
		if (BVHeJtCJXPFBfGgHsARPRMvrhkyB(P_2))
		{
			return true;
		}
		return false;
	}

	private static bool BVHeJtCJXPFBfGgHsARPRMvrhkyB(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		for (int i = 0; i < KTmgZJDccKnneSaugKInHJWuTfx.Length; i++)
		{
			if (KTmgZJDccKnneSaugKInHJWuTfx[i].Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}
}
