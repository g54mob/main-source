using System;
using System.Globalization;

namespace VampireSurvivors;

public static class UtilityExtensionMethods
{
	public unsafe static string DecimalToString(decimal dec, string customFormat = "")
	{
		string text = ((decimal*)dec)->ToString(customFormat, CultureInfo.invariant_culture_info);
		if (text != null)
		{
			if (!text.Contains("."))
			{
				return text;
			}
			object obj = default(object);
			string text2 = text.TrimHelper((char*)(&obj), 1, string.TrimType.Tail);
			if (text2 != null)
			{
				return text2.TrimHelper((char*)(&obj), 1, string.TrimType.Tail);
			}
		}
		return (string)(object)new NullReferenceException();
	}
}
