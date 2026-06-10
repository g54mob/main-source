using System;
using System.Collections.Generic;

public static class CurrencyFormatter
{
	private static readonly List<string> Suffixes = new List<string>
	{
		"", "K", "M", "B", "T", "Q", "Qn", "S", "SE", "O",
		"N"
	};

	public static string FormatMoneyPrecise(double number)
	{
		if (number == 0.0)
		{
			return "0";
		}
		string text = ((number < 0.0) ? "-" : "");
		number = Math.Abs(number);
		int num = 0;
		while (number >= 1000.0 && num < Suffixes.Count - 1)
		{
			number /= 1000.0;
			num++;
		}
		string text2 = ((num == 0) ? ((!(number < 1.0)) ? "0" : "0.00") : ((number < 10.0) ? "0.00" : ((!(number < 100.0)) ? "0" : "0.0")));
		string text3 = number.ToString(text2);
		if (text3 == "1000" && num < Suffixes.Count - 1)
		{
			text3 = "1.00";
			num++;
		}
		return text + text3 + Suffixes[num];
	}

	public static string FormatMoney(double number)
	{
		if (number == 0.0)
		{
			return "0";
		}
		string text = ((number < 0.0) ? "-" : "");
		number = Math.Abs(number);
		int num = 0;
		while (number >= 1000.0 && num < Suffixes.Count - 1)
		{
			number /= 1000.0;
			num++;
		}
		string text2 = ((num == 0) ? ((!(number < 1.0)) ? "0" : "0.0") : ((!(number < 100.0)) ? "0" : "0.0"));
		string text3 = number.ToString(text2);
		if (text3 == "1000" && num < Suffixes.Count - 1)
		{
			text3 = "1.0";
			num++;
		}
		return text + text3 + Suffixes[num];
	}
}
