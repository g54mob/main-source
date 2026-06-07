using System;

internal static class MwoFssxjTIQzJQFdgnRgTEwkueQ
{
	public enum HiPjBFnUFvidmUeGHCKmAGHBzjU
	{
		CEUjyvGIbsPgNjwVqrjvtItjjrS = 0,
		VKytTcJCvUxmixijnABPAIVvMlL = 1,
		wXsBKWETrjbTTcUVaPFlDuqTKEBM = 2
	}

	private const string ElBCqbIDBdOTvkrfcVsBLZWmyTyC = ".*xbox[ \\-]one.*";

	private static Guid[] MoUtnPijiZgowEjAKxRqdMMlCCc = new Guid[6]
	{
		new Guid("02D1045E-0000-0000-0000-504944564944"),
		new Guid("02DD045E-0000-0000-0000-504944564944"),
		new Guid("02E3045E-0000-0000-0000-504944564944"),
		new Guid("DEEF045E-0000-0000-0000-504944564944"),
		new Guid("02e0045e-0000-0000-0000-504944564944"),
		new Guid("02ff045e-0000-0000-0000-504944564944")
	};

	private static string[] JLJMGIWIINZhXiFcRNeWsCptQFn = new string[4] { "Controller (XBOX One For Windows)", "XBOX One For Windows (Controller)", "XBOX One Controller", "Xbox Bluetooth Gamepad" };

	public static string FUEfOdGwzMIRJkpsPreVXOvWCDd(MFFbigtCSAERTKmOTUlnAJmgNhe P_0, Guid P_1, string P_2, string P_3)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		return ZIvhbHHvUFBBSrcVQBEDfxzcbRYE(P_0.ValueCapabilities, P_1, P_2, P_3) switch
		{
			HiPjBFnUFvidmUeGHCKmAGHBzjU.VKytTcJCvUxmixijnABPAIVvMlL => "[CombinedTriggers]", 
			HiPjBFnUFvidmUeGHCKmAGHBzjU.wXsBKWETrjbTTcUVaPFlDuqTKEBM => "[SplitTriggers]", 
			_ => string.Empty, 
		};
	}

	public static HiPjBFnUFvidmUeGHCKmAGHBzjU ZIvhbHHvUFBBSrcVQBEDfxzcbRYE(HUXGqmGKaytnimdNVoGehreiWbbz[] P_0, Guid P_1, string P_2, string P_3)
	{
		if (!IkwbPuTwnCFjSIUFHddovCKshqw(P_1, P_2, P_3))
		{
			return HiPjBFnUFvidmUeGHCKmAGHBzjU.CEUjyvGIbsPgNjwVqrjvtItjjrS;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i].UsagePage == 1 && !P_0[i].IsRange && P_0[i].NotRange.Usage == 53)
			{
				return HiPjBFnUFvidmUeGHCKmAGHBzjU.wXsBKWETrjbTTcUVaPFlDuqTKEBM;
			}
		}
		return HiPjBFnUFvidmUeGHCKmAGHBzjU.VKytTcJCvUxmixijnABPAIVvMlL;
	}

	public static bool IkwbPuTwnCFjSIUFHddovCKshqw(Guid P_0, string P_1, string P_2)
	{
		if (Array.IndexOf(MoUtnPijiZgowEjAKxRqdMMlCCc, P_0) >= 0)
		{
			return true;
		}
		if (IkwbPuTwnCFjSIUFHddovCKshqw(P_1))
		{
			return true;
		}
		if (IkwbPuTwnCFjSIUFHddovCKshqw(P_2))
		{
			return true;
		}
		return false;
	}

	private static bool IkwbPuTwnCFjSIUFHddovCKshqw(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		for (int i = 0; i < JLJMGIWIINZhXiFcRNeWsCptQFn.Length; i++)
		{
			if (JLJMGIWIINZhXiFcRNeWsCptQFn[i].Equals(P_0, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}
}
