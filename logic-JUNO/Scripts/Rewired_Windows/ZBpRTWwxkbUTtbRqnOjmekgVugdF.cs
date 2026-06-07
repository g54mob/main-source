using System;

internal static class ZBpRTWwxkbUTtbRqnOjmekgVugdF
{
	public enum WdPiGYRANQewDKQgnRXEXHdMrIbg
	{
		None = 0,
		CombinedTriggers = 1,
		SplitTriggers = 2
	}

	private static Guid[] VdkssUXGcrOZeuwDpznLjyvHSRlD = new Guid[6]
	{
		new Guid("02D1045E-0000-0000-0000-504944564944"),
		new Guid("02DD045E-0000-0000-0000-504944564944"),
		new Guid("02E3045E-0000-0000-0000-504944564944"),
		new Guid("DEEF045E-0000-0000-0000-504944564944"),
		new Guid("02e0045e-0000-0000-0000-504944564944"),
		new Guid("02ff045e-0000-0000-0000-504944564944")
	};

	private static string[] cAEkyRHurjnKpoZklvhAwFLfDNZL = new string[4] { "Controller (XBOX One For Windows)", "XBOX One For Windows (Controller)", "XBOX One Controller", "Xbox Bluetooth Gamepad" };

	private const string yzAhpPqFyHykqJrgSUhZVbjLpvdv = ".*xbox[ \\-]one.*";

	public static string ggHbEQncEAcHjjTFfGHnFynECNGU(ZeUHAGkoexvlzptmUIXbzZqFvNFR P_0, Guid P_1, string P_2, string P_3)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		return iAOaFhDNAyHIeRbXmiCVQKnFInhtA(P_0.rmnXQVfpJAaphdHiMMbTTOqNQvXT, P_1, P_2, P_3) switch
		{
			WdPiGYRANQewDKQgnRXEXHdMrIbg.CombinedTriggers => "[CombinedTriggers]", 
			WdPiGYRANQewDKQgnRXEXHdMrIbg.SplitTriggers => "[SplitTriggers]", 
			_ => string.Empty, 
		};
	}

	public static WdPiGYRANQewDKQgnRXEXHdMrIbg iAOaFhDNAyHIeRbXmiCVQKnFInhtA(IUQPDOVCUBEKWUixUUHqIKonFrCKA[] P_0, Guid P_1, string P_2, string P_3)
	{
		if (!SktyXrgkqoEeyOgpZVmQfRvLQNmt(P_1, P_2, P_3))
		{
			return WdPiGYRANQewDKQgnRXEXHdMrIbg.None;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i].jJkBqOQMTiVAuVufQFiHGPtSAQwM == 1 && !P_0[i].qtSkwBnrZAFGHCPGCFlzbUPuLszrA && P_0[i].uuNHpAjRDhbkfhyrrVEChZAUbwrsA.sfdMpyNGVOksKzXRWWdToegjioyE == 53)
			{
				return WdPiGYRANQewDKQgnRXEXHdMrIbg.SplitTriggers;
			}
		}
		return WdPiGYRANQewDKQgnRXEXHdMrIbg.CombinedTriggers;
	}

	public static bool SktyXrgkqoEeyOgpZVmQfRvLQNmt(Guid P_0, string P_1, string P_2)
	{
		if (Array.IndexOf(VdkssUXGcrOZeuwDpznLjyvHSRlD, P_0) >= 0)
		{
			return true;
		}
		if (cyFrpwTmNdgZEfjbzBbFesnAcbKNB(P_1))
		{
			return true;
		}
		if (cyFrpwTmNdgZEfjbzBbFesnAcbKNB(P_2))
		{
			return true;
		}
		return false;
	}

	private static bool cyFrpwTmNdgZEfjbzBbFesnAcbKNB(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		for (int i = 0; i < cAEkyRHurjnKpoZklvhAwFLfDNZL.Length; i++)
		{
			if (cAEkyRHurjnKpoZklvhAwFLfDNZL[i].Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}
}
