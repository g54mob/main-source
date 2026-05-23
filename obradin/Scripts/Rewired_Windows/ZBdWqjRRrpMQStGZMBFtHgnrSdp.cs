using System;

internal static class ZBdWqjRRrpMQStGZMBFtHgnrSdp
{
	public enum FzCjAnbnlZdnIAmCxWBZEdPMMETf
	{
		FIZxYpycmNmDbQxAMdnkneLgidG = 0,
		McrbwOhmUtCfnOAYJIlUYPTqNAQ = 1,
		fAfpWZthJCbsMrInzGRyFofBbPeR = 2
	}

	private const string FJCmkcpCtCtwuUPLUpmGJVLjbWH = ".*xbox[ \\-]one.*";

	private static Guid[] TfFnwWGxJkTUhfpPgbKhlWRqPcB;

	private static string[] SMSeMRCaysDKSMLSvKyBcscmcYCU;

	public static string UcFxCuePLtGkYNmCfHmGPxwJaCKI(hdKCmGlHttTBdcjeWBCjBOXCTjJ P_0, Guid P_1, string P_2, string P_3)
	{
		if (P_0 == null)
		{
			return string.Empty;
		}
		switch (IkiujOzXwutsHUDbwyOCbzevGUf(P_0.ValueCapabilities, P_1, P_2, P_3))
		{
		case FzCjAnbnlZdnIAmCxWBZEdPMMETf.McrbwOhmUtCfnOAYJIlUYPTqNAQ:
			return "[CombinedTriggers]";
		case FzCjAnbnlZdnIAmCxWBZEdPMMETf.fAfpWZthJCbsMrInzGRyFofBbPeR:
			return "[SplitTriggers]";
		default:
			return string.Empty;
		}
	}

	public static FzCjAnbnlZdnIAmCxWBZEdPMMETf IkiujOzXwutsHUDbwyOCbzevGUf(MFUrcluqOBPEvSbzhRQjzcrDggKC[] P_0, Guid P_1, string P_2, string P_3)
	{
		if (!DijjflnEZpcmHhIbjbklhBFlhtP(P_1, P_2, P_3))
		{
			return FzCjAnbnlZdnIAmCxWBZEdPMMETf.FIZxYpycmNmDbQxAMdnkneLgidG;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i].UsagePage == 1 && !P_0[i].IsRange && P_0[i].NotRange.Usage == 53)
			{
				return FzCjAnbnlZdnIAmCxWBZEdPMMETf.fAfpWZthJCbsMrInzGRyFofBbPeR;
			}
		}
		return FzCjAnbnlZdnIAmCxWBZEdPMMETf.McrbwOhmUtCfnOAYJIlUYPTqNAQ;
	}

	public static bool DijjflnEZpcmHhIbjbklhBFlhtP(Guid P_0, string P_1, string P_2)
	{
		if (Array.IndexOf(TfFnwWGxJkTUhfpPgbKhlWRqPcB, P_0) >= 0)
		{
			return true;
		}
		if (DijjflnEZpcmHhIbjbklhBFlhtP(P_1))
		{
			return true;
		}
		if (DijjflnEZpcmHhIbjbklhBFlhtP(P_2))
		{
			return true;
		}
		return false;
	}

	private static bool DijjflnEZpcmHhIbjbklhBFlhtP(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		int num = 0;
		while (num < SMSeMRCaysDKSMLSvKyBcscmcYCU.Length)
		{
			while (true)
			{
				int num2;
				if (SMSeMRCaysDKSMLSvKyBcscmcYCU[num].Equals(P_0, StringComparison.OrdinalIgnoreCase))
				{
					num2 = 1752811692;
				}
				else
				{
					num++;
					num2 = 1752811693;
				}
				while (true)
				{
					switch (num2 ^ 0x6879C8AD)
					{
					case 3:
						num2 = 1752811695;
						continue;
					case 2:
						break;
					case 1:
						return true;
					default:
						goto end_IL_0030;
					}
					break;
				}
				continue;
				end_IL_0030:
				break;
			}
		}
		return false;
	}

	static ZBdWqjRRrpMQStGZMBFtHgnrSdp()
	{
		Guid[] array = new Guid[6]
		{
			new Guid("02D1045E-0000-0000-0000-504944564944"),
			new Guid("02DD045E-0000-0000-0000-504944564944"),
			default(Guid),
			default(Guid),
			default(Guid),
			default(Guid)
		};
		while (true)
		{
			int num = 567359413;
			while (true)
			{
				switch (num ^ 0x21D137B1)
				{
				case 0:
					break;
				default:
					return;
				case 4:
					array[2] = new Guid("02E3045E-0000-0000-0000-504944564944");
					array[3] = new Guid("DEEF045E-0000-0000-0000-504944564944");
					array[4] = new Guid("02e0045e-0000-0000-0000-504944564944");
					num = 567359408;
					continue;
				case 1:
					array[5] = new Guid("02ff045e-0000-0000-0000-504944564944");
					TfFnwWGxJkTUhfpPgbKhlWRqPcB = array;
					num = 567359410;
					continue;
				case 3:
					SMSeMRCaysDKSMLSvKyBcscmcYCU = new string[4] { "Controller (XBOX One For Windows)", "XBOX One For Windows (Controller)", "XBOX One Controller", "Xbox Bluetooth Gamepad" };
					num = 567359411;
					continue;
				case 2:
					return;
				}
				break;
			}
		}
	}
}
