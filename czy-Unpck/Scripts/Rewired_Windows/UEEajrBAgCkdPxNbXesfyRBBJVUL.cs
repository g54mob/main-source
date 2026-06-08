using System.Diagnostics;
using Rewired;

internal static class UEEajrBAgCkdPxNbXesfyRBBJVUL
{
	[Conditional("WINDEBUG")]
	public static void PwCCXFaMvjzbDiRUWFLebPpkqFvG(object P_0)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_0037;
		IL_0003:
		int num = -412544030;
		goto IL_0008;
		IL_0008:
		object[] array = default(object[]);
		while (true)
		{
			switch (num ^ -412544031)
			{
			case 4:
				break;
			default:
				return;
			case 3:
				P_0 = string.Empty;
				num = -412544031;
				continue;
			case 0:
				goto IL_0037;
			case 1:
				Logger.Log(string.Concat(array), requiredThreadSafety: true);
				num = -412544029;
				continue;
			case 2:
				return;
			}
			break;
		}
		goto IL_0003;
		IL_0037:
		array = new object[4]
		{
			"[WINDEBUG][",
			ReInput.realTime.ToString("f3"),
			"] ",
			P_0
		};
		num = -412544032;
		goto IL_0008;
	}

	[Conditional("WINDEBUG")]
	public static void dAZpWBXMoQRdjNPhuyZlFpumVVg(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
			goto IL_000a;
		}
		goto IL_0028;
		IL_0028:
		object[] array = new object[4]
		{
			"[WINDEBUG][",
			ReInput.realTime.ToString("f3"),
			"] ",
			null
		};
		int num = -255085347;
		goto IL_000f;
		IL_000a:
		num = -255085348;
		goto IL_000f;
		IL_000f:
		switch (num ^ -255085347)
		{
		case 2:
			break;
		case 1:
			goto IL_0028;
		default:
			array[3] = P_0;
			Logger.LogWarning(string.Concat(array), requiredThreadSafety: true);
			return;
		}
		goto IL_000a;
	}

	[Conditional("WINDEBUG")]
	public static void KpAYSAJiWvudgqmJcWsuPLsxdmc(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
			goto IL_000a;
		}
		goto IL_0030;
		IL_0030:
		object[] array = new object[4];
		int num = -1398197007;
		goto IL_000f;
		IL_000a:
		num = -1398197001;
		goto IL_000f;
		IL_000f:
		while (true)
		{
			switch (num ^ -1398197003)
			{
			case 0:
				break;
			case 2:
				goto IL_0030;
			case 1:
				array[1] = ReInput.realTime.ToString("f3");
				array[2] = "] ";
				num = -1398197002;
				continue;
			case 4:
				array[0] = "[WINDEBUG][";
				num = -1398197004;
				continue;
			default:
				array[3] = P_0;
				Logger.LogError(string.Concat(array), requiredThreadSafety: true);
				return;
			}
			break;
		}
		goto IL_000a;
	}

	[Conditional("WINDEBUGDEEP")]
	public static void VpBCCjwLtHKSewDqiCiaATCAfcu(object P_0)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_0033;
		IL_0003:
		int num = 151238007;
		goto IL_0008;
		IL_0008:
		object[] array = default(object[]);
		while (true)
		{
			switch (num ^ 0x903B575)
			{
			case 0:
				break;
			case 2:
				P_0 = string.Empty;
				num = 151238004;
				continue;
			case 1:
				goto IL_0033;
			default:
				Logger.Log(string.Concat(array), requiredThreadSafety: true);
				return;
			}
			break;
		}
		goto IL_0003;
		IL_0033:
		array = new object[4]
		{
			"[WINDEBUG][",
			ReInput.realTime.ToString("f3"),
			"] ",
			P_0
		};
		num = 151238006;
		goto IL_0008;
	}

	[Conditional("WINDEBUGDEEP")]
	public static void tDsZIWeJCjMVRjvukAMmZpaLvnJ(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
			goto IL_000a;
		}
		goto IL_002c;
		IL_002c:
		object[] array = new object[4]
		{
			"[WINDEBUG][",
			ReInput.realTime.ToString("f3"),
			"] ",
			null
		};
		int num = -81422551;
		goto IL_000f;
		IL_000a:
		num = -81422552;
		goto IL_000f;
		IL_000f:
		while (true)
		{
			switch (num ^ -81422551)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				goto IL_002c;
			case 0:
				array[3] = P_0;
				Logger.LogWarning(string.Concat(array), requiredThreadSafety: true);
				num = -81422549;
				continue;
			case 2:
				return;
			}
			break;
		}
		goto IL_000a;
	}

	[Conditional("WINDEBUGDEEP")]
	public static void oIcbGIiBYcEkktCMyEhyludJXQgn(object P_0)
	{
		if (P_0 == null)
		{
			P_0 = string.Empty;
		}
		Logger.LogError("[WINDEBUG][" + ReInput.realTime.ToString("f3") + "] " + P_0, requiredThreadSafety: true);
	}

	[Conditional("WINDEBUGDEEPUPDATE")]
	public static void MMBTEUgAHDfYWapUWZKjHMzpjLq(object P_0)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_0033;
		IL_0003:
		int num = -1074021815;
		goto IL_0008;
		IL_0008:
		object[] array = default(object[]);
		while (true)
		{
			switch (num ^ -1074021816)
			{
			case 2:
				break;
			case 1:
				P_0 = string.Empty;
				num = -1074021816;
				continue;
			case 0:
				goto IL_0033;
			default:
				array[0] = "[WINDEBUG][";
				array[1] = ReInput.realTime.ToString("f3");
				array[2] = "] ";
				array[3] = P_0;
				Logger.Log(string.Concat(array), requiredThreadSafety: true);
				return;
			}
			break;
		}
		goto IL_0003;
		IL_0033:
		array = new object[4];
		num = -1074021813;
		goto IL_0008;
	}

	[Conditional("WINDEBUGHID")]
	public static void tQRWEukQWKoklfyorRdRKyKIQIh(object P_0)
	{
		if (P_0 == null)
		{
			goto IL_0003;
		}
		goto IL_0033;
		IL_0003:
		int num = -1121286310;
		goto IL_0008;
		IL_0008:
		while (true)
		{
			switch (num ^ -1121286311)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				P_0 = string.Empty;
				num = -1121286312;
				continue;
			case 1:
				goto IL_0033;
			case 2:
				return;
			}
			break;
		}
		goto IL_0003;
		IL_0033:
		Logger.Log("[WINDEBUGHID][" + ReInput.realTime.ToString("f3") + "] " + P_0, requiredThreadSafety: true);
		num = -1121286309;
		goto IL_0008;
	}
}
