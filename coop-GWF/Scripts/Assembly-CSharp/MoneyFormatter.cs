using System;
using System.Globalization;

public static class MoneyFormatter
{
	private static readonly NumberFormatInfo DotSeparatorFormat = new NumberFormatInfo
	{
		NumberGroupSeparator = ".",
		NumberDecimalSeparator = "."
	};

	public static string FormatWithDollar(long amount, bool floorDecimals = false)
	{
		if (amount < 0)
		{
			return "-$" + Format(amount, floorDecimals);
		}
		return "$" + Format(amount, floorDecimals);
	}

	private static string Format(long amount, bool floorDecimals)
	{
		if (amount == 0L)
		{
			return "0";
		}
		long num = Math.Abs(amount);
		if (num < 1000)
		{
			return num.ToString("N0", DotSeparatorFormat);
		}
		double num2;
		string text;
		if (num < 1000000)
		{
			num2 = (double)num / 1000.0;
			text = "K";
		}
		else if (num < 1000000000)
		{
			num2 = (double)num / 1000000.0;
			text = "M";
		}
		else if (num < 1000000000000L)
		{
			num2 = (double)num / 1000000000.0;
			text = "B";
		}
		else if (num < 1000000000000000L)
		{
			num2 = (double)num / 1000000000000.0;
			text = "T";
		}
		else if (num < 1000000000000000000L)
		{
			num2 = (double)num / 1000000000000000.0;
			text = "Qa";
		}
		else
		{
			num2 = (double)num / 1E+18;
			text = "Qi";
		}
		if (floorDecimals)
		{
			num2 = Math.Floor(num2 * 100.0) / 100.0;
		}
		return num2.ToString("F2", CultureInfo.InvariantCulture).TrimEnd('0').TrimEnd('.') + text;
	}
}
