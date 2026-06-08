internal static class fTvFFMKHyahmXrAOzQxsmenVpjI
{
	public static string bAsiNcmvQWMiTuiNtHATkYhgXzTP(string P_0)
	{
		int num = default(int);
		int num2;
		if (P_0 != null)
		{
			if (P_0 == string.Empty)
			{
				goto IL_0010;
			}
			num = P_0.LastIndexOf('\\');
			num2 = -871199277;
			goto IL_0015;
		}
		goto IL_0036;
		IL_0015:
		while (true)
		{
			switch (num2 ^ -871199273)
			{
			case 0:
				break;
			case 2:
				goto IL_0036;
			case 3:
				goto IL_004c;
			case 4:
				goto IL_005e;
			default:
				return P_0;
			}
			break;
			IL_005e:
			int num3;
			if (num >= 0)
			{
				num2 = -871199276;
				num3 = num2;
			}
			else
			{
				num2 = -871199274;
				num3 = num2;
			}
			continue;
			IL_004c:
			if (num >= P_0.Length - 1)
			{
				num2 = -871199274;
				continue;
			}
			return P_0.Substring(num + 1);
		}
		goto IL_0010;
		IL_0036:
		return string.Empty;
		IL_0010:
		num2 = -871199275;
		goto IL_0015;
	}

	public static SgUbOIYhKqFHBWCjywfFXIQjDhT OstHRQsmzsFHarCvXgOBeDdabtL(uint P_0)
	{
		switch (P_0)
		{
		case 8u:
			return SgUbOIYhKqFHBWCjywfFXIQjDhT.zakHvHhdziCAqMcXKebsWnQRMld;
		case 7u:
			return SgUbOIYhKqFHBWCjywfFXIQjDhT.KGpCUIqGWWbbJgMojwaZbpHGRMq;
		default:
			return SgUbOIYhKqFHBWCjywfFXIQjDhT.UyGwCSXAdlJCSRSfHscRvehUkwi;
		}
	}
}
