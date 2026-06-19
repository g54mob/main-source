internal static class AXZmLhfOaXDLyYVNwRRyjGqxlFh
{
	public static string jdyktFCcimoovPTInevfRbthhhAN(string P_0)
	{
		if (P_0 == null || P_0 == string.Empty)
		{
			return string.Empty;
		}
		int num = P_0.LastIndexOf('\\');
		if (num < 0 || num >= P_0.Length - 1)
		{
			return P_0;
		}
		return P_0.Substring(num + 1);
	}

	public static LGPZdTdazZeyYZxciePBPaRUlZSd wuhXbSBbPBVNvbzCPfpeZXCUFQVb(int P_0)
	{
		switch (P_0)
		{
		case 0:
			return LGPZdTdazZeyYZxciePBPaRUlZSd.LostFocus;
		case 1:
		case 2:
			return LGPZdTdazZeyYZxciePBPaRUlZSd.GainedFocus;
		default:
			return LGPZdTdazZeyYZxciePBPaRUlZSd.None;
		}
	}
}
