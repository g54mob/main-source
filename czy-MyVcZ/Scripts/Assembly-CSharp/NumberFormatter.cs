public static class NumberFormatter
{
	public static string FormatNumber(double number)
	{
		if (number < 1000.0)
		{
			return number.ToString("F0");
		}
		if (number < 1000000.0)
		{
			return (number / 1000.0).ToString("F1") + "K";
		}
		if (number < 1000000000.0)
		{
			return (number / 1000000.0).ToString("F1") + "M";
		}
		if (number < 1000000000000.0)
		{
			return (number / 1000000000.0).ToString("F1") + "B";
		}
		if (number < 1000000000000000.0)
		{
			return (number / 1000000000000.0).ToString("F1") + "T";
		}
		return "MAX";
	}

	public static string FormatWithComma(double number)
	{
		if (number % 1.0 == 0.0)
		{
			return ((long)number).ToString("N0");
		}
		return number.ToString("N1");
	}
}
