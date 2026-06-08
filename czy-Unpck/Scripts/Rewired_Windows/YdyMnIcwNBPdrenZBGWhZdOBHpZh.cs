using System;

internal static class YdyMnIcwNBPdrenZBGWhZdOBHpZh
{
	public enum goZGjEubhInHpoykYXdYRfLBcpR
	{
		UyGwCSXAdlJCSRSfHscRvehUkwi = 0,
		XemwcbGOqHhXWVYLKDNQOopCNDy = 1,
		ifkjFiiIjkJPtiipcmGkIuCuzLYZ = 2
	}

	private const string WETExHhSHisXVePZVdxICXgcHYrP = ".*xbox[ \\-]one.*";

	private static Guid[] IvUgjrfIrEmEKyhVzqTpzXwCDeb;

	private static string[] VSJrVsRwQKrrvMnIyFbNoNHSFEm;

	public static string BBWmVDZLrNTNlSFMsavKfXDvmGqa(OzVqfYeaMNEXzwFiuZOmGiQFiUf P_0, Guid P_1, string P_2, string P_3)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		switch (BChkudUPAQHRoJXbxsNEjNNRCWL(P_0.ValueCapabilities, P_1, P_2, P_3))
		{
		case goZGjEubhInHpoykYXdYRfLBcpR.XemwcbGOqHhXWVYLKDNQOopCNDy:
			return "[CombinedTriggers]";
		case goZGjEubhInHpoykYXdYRfLBcpR.ifkjFiiIjkJPtiipcmGkIuCuzLYZ:
			return "[SplitTriggers]";
		default:
			return string.Empty;
		}
	}

	public static goZGjEubhInHpoykYXdYRfLBcpR BChkudUPAQHRoJXbxsNEjNNRCWL(VnJBlCjBghUdCNDzwTDxPtAjFeic[] P_0, Guid P_1, string P_2, string P_3)
	{
		if (!EredcQKydBpZmabzqbkjxmmHdtjf(P_1, P_2, P_3))
		{
			return goZGjEubhInHpoykYXdYRfLBcpR.UyGwCSXAdlJCSRSfHscRvehUkwi;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i].UsagePage == 1 && !P_0[i].IsRange && P_0[i].NotRange.Usage == 53)
			{
				return goZGjEubhInHpoykYXdYRfLBcpR.ifkjFiiIjkJPtiipcmGkIuCuzLYZ;
			}
		}
		return goZGjEubhInHpoykYXdYRfLBcpR.XemwcbGOqHhXWVYLKDNQOopCNDy;
	}

	public static bool EredcQKydBpZmabzqbkjxmmHdtjf(Guid P_0, string P_1, string P_2)
	{
		if (Array.IndexOf(IvUgjrfIrEmEKyhVzqTpzXwCDeb, P_0) >= 0)
		{
			goto IL_000e;
		}
		if (EredcQKydBpZmabzqbkjxmmHdtjf(P_1))
		{
			return true;
		}
		int num;
		if (EredcQKydBpZmabzqbkjxmmHdtjf(P_2))
		{
			num = 646042144;
			goto IL_0013;
		}
		return false;
		IL_0013:
		switch (num ^ 0x2681D222)
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
		num = 646042147;
		goto IL_0013;
	}

	private static bool EredcQKydBpZmabzqbkjxmmHdtjf(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		int num = 0;
		while (num < VSJrVsRwQKrrvMnIyFbNoNHSFEm.Length)
		{
			while (true)
			{
				if (VSJrVsRwQKrrvMnIyFbNoNHSFEm[num].Equals(P_0, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
				num++;
				int num2 = -461825829;
				while (true)
				{
					switch (num2 ^ -461825830)
					{
					case 0:
						num2 = -461825832;
						continue;
					case 2:
						break;
					default:
						goto end_IL_002c;
					}
					break;
				}
				continue;
				end_IL_002c:
				break;
			}
		}
		return false;
	}

	static YdyMnIcwNBPdrenZBGWhZdOBHpZh()
	{
		Guid[] array = new Guid[6]
		{
			new Guid("02D1045E-0000-0000-0000-504944564944"),
			new Guid("02DD045E-0000-0000-0000-504944564944"),
			new Guid("02E3045E-0000-0000-0000-504944564944"),
			default(Guid),
			default(Guid),
			default(Guid)
		};
		while (true)
		{
			int num = -499925973;
			while (true)
			{
				switch (num ^ -499925974)
				{
				case 2:
					break;
				case 1:
					goto IL_0067;
				default:
					IvUgjrfIrEmEKyhVzqTpzXwCDeb = array;
					VSJrVsRwQKrrvMnIyFbNoNHSFEm = new string[4] { "Controller (XBOX One For Windows)", "XBOX One For Windows (Controller)", "XBOX One Controller", "Xbox Bluetooth Gamepad" };
					return;
				}
				break;
				IL_0067:
				ref Guid reference = ref array[3];
				reference = new Guid("DEEF045E-0000-0000-0000-504944564944");
				ref Guid reference2 = ref array[4];
				reference2 = new Guid("02e0045e-0000-0000-0000-504944564944");
				ref Guid reference3 = ref array[5];
				reference3 = new Guid("02ff045e-0000-0000-0000-504944564944");
				num = -499925974;
			}
		}
	}
}
