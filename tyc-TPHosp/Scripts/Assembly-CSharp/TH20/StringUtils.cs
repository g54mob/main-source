using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public static class StringUtils
	{
		private static char cNonBreakingMinusChar = '‑';

		private static char cNonBreakingSpaceChar = '\u00a0';

		private static string cNonBreakingMinusStr = cNonBreakingMinusChar.ToString();

		public static string AddColorTag(string text, Color color)
		{
			string arg = ColorUtility.ToHtmlStringRGBA(color);
			return $"<color=#{arg}>{text}</color>";
		}

		public static string ReplaceLineBreakingCharacters(bool bReplaceLineBreakingChars, string inStr, CultureInfo culture)
		{
			string text = inStr;
			if (bReplaceLineBreakingChars)
			{
				text = text.Replace(' ', cNonBreakingSpaceChar);
				if (culture.NumberFormat.NegativeSign == "-")
				{
					text = text.Replace(culture.NumberFormat.NegativeSign, cNonBreakingMinusStr);
				}
			}
			return text;
		}

		public static string FormatCurrency(decimal value, bool prefixPlus = false, bool bReplaceLineBreakingChars = true)
		{
			CultureInfo cultureInfo = (CultureInfo)CultureInfo.CurrentCulture.Clone();
			cultureInfo.NumberFormat.CurrencySymbol = "$";
			string inStr = value.ToString("C0", cultureInfo);
			inStr = ReplaceLineBreakingCharacters(bReplaceLineBreakingChars, inStr, cultureInfo);
			if (!prefixPlus || !(value > 0m))
			{
				return inStr;
			}
			return $"+{inStr}";
		}

		public static string FormatSharePrice(float value, bool bReplaceLineBreakingChars = true)
		{
			CultureInfo cultureInfo = (CultureInfo)CultureInfo.CurrentCulture.Clone();
			cultureInfo.NumberFormat.CurrencySymbol = "$";
			string inStr = value.ToString("C", cultureInfo);
			return ReplaceLineBreakingCharacters(bReplaceLineBreakingChars, inStr, cultureInfo);
		}

		public static string FormatNumber(decimal value)
		{
			return value.ToString("N0", CultureInfo.CurrentCulture);
		}

		public static string FormatCurrencyWithoutSymbol(decimal value)
		{
			return value.ToString("N0", CultureInfo.CurrentCulture);
		}

		public static string FormatSilverCurrency(decimal value, bool bReplaceLineBreakingChars = true)
		{
			CultureInfo cultureInfo = (CultureInfo)CultureInfo.CurrentCulture.Clone();
			cultureInfo.NumberFormat.CurrencySymbol = "K";
			string inStr = value.ToString("C0", cultureInfo);
			return ReplaceLineBreakingCharacters(bReplaceLineBreakingChars, inStr, cultureInfo);
		}

		public static string FormatReputationValue(decimal value, bool bReplaceLineBreakingChars = true)
		{
			CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
			string inStr = ScriptLocalization.Misc.ReputationShort_CS.Replace("{[VALUE]}", FormatNumber(value));
			return ReplaceLineBreakingCharacters(bReplaceLineBreakingChars, inStr, culture);
		}

		public static string FormatShareValue(float value, bool bReplaceLineBreakingChars = true)
		{
			CultureInfo cultureInfo = (CultureInfo)CultureInfo.CurrentCulture.Clone();
			cultureInfo.NumberFormat.CurrencySymbol = "$";
			string inStr = value.ToString("C0", cultureInfo);
			inStr = ReplaceLineBreakingCharacters(bReplaceLineBreakingChars, inStr, cultureInfo);
			return $"{inStr} / {ScriptLocalization.Misc.Share_CS}";
		}

		public static string FormatShareValueWithoutSymbol(float value)
		{
			string arg = value.ToString("N0", CultureInfo.CurrentCulture);
			return $"{arg} / {ScriptLocalization.Misc.Share_CS}";
		}

		public static string FormatPercentageValue(float value, bool prefixPlus = false)
		{
			string text = value.ToString("P0", CultureInfo.CurrentCulture);
			if (!prefixPlus || !(value > 0f))
			{
				return text;
			}
			return $"+{text}";
		}

		public static string FormatFloat(float value, bool prefixPlus = false)
		{
			if (value >= 0f)
			{
				return prefixPlus ? $"+{value}" : $"{value}";
			}
			return $"{value}";
		}

		public static string FormatInteger(int value, bool prefixPlus = false)
		{
			if (value >= 0)
			{
				return prefixPlus ? $"+{value}" : $"{value}";
			}
			return $"{value}";
		}

		public static string FormatTimeSpan(uint seconds)
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
			if (timeSpan.Days > 9999)
			{
				return ScriptLocalization.TimeSpan.TimeSpan_LongTimeAgo_CS;
			}
			if (timeSpan.Days > 0)
			{
				if (timeSpan.Days <= 1)
				{
					return ScriptLocalization.TimeSpan.TimeSpan_DayAgo_CS;
				}
				return LocalisedString.GetTranslationPlural("TimeSpan/TimeSpan_DaysAgo_CS", timeSpan.Days).Replace("{[DAYS]}", timeSpan.Days.ToString());
			}
			if (timeSpan.Hours > 0)
			{
				if (timeSpan.Hours <= 1)
				{
					return ScriptLocalization.TimeSpan.TimeSpan_HourAgo_CS;
				}
				return LocalisedString.GetTranslationPlural("TimeSpan/TimeSpan_HoursAgo_CS", timeSpan.Hours).Replace("{[HOURS]}", timeSpan.Hours.ToString());
			}
			if (timeSpan.Minutes > 0)
			{
				if (timeSpan.Minutes <= 1)
				{
					return ScriptLocalization.TimeSpan.TimeSpan_MinuteAgo_CS;
				}
				return LocalisedString.GetTranslationPlural("TimeSpan/TimeSpan_MinutesAgo_CS", timeSpan.Minutes).Replace("{[MINUTES]}", timeSpan.Minutes.ToString());
			}
			return ScriptLocalization.TimeSpan.TimeSpan_Now_CS;
		}

		public static string FormatTimeSpanDaysMonthsYears(uint seconds)
		{
			int days = TimeSpan.FromSeconds(seconds).Days;
			if (days == 0)
			{
				return FormatTimeSpanDays(days);
			}
			int num = (int)((double)days / 365.25);
			days -= (int)((double)num * 365.25);
			int num2 = (int)((double)days / 30.4375);
			days -= (int)((double)num2 * 30.4375);
			string text = string.Empty;
			if (num > 0)
			{
				text = text + FormatTimeSpanYears(num) + " ";
			}
			if (num2 > 0 || num > 0)
			{
				text = text + FormatTimeSpanMonths(num2) + " ";
			}
			if (days > 0 || num2 > 0 || num > 0)
			{
				text += FormatTimeSpanDays(days);
			}
			return text;
		}

		public static string GetTranslatedStringWithDays(string term, int days)
		{
			string text = term;
			LocalisationParams.Set("DAYS", days);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public static string FormatTimeSpanDays(int days)
		{
			string text = ScriptLocalization.TimeSpan.Days_CS;
			LocalisationParams.Set("DAYS", days);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public static string FormatTimeSpanMonths(int months)
		{
			string text = ScriptLocalization.TimeSpan.Months_CS;
			LocalisationParams.Set("MONTHS", months);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public static string FormatTimeSpanYears(int years)
		{
			string text = ScriptLocalization.TimeSpan.Years_CS;
			LocalisationParams.Set("YEARS", years);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public static string FormatNumericDay(int day)
		{
			string newValue = (day + 1).ToString("00");
			return ScriptLocalization.TimeSpan.NumericDay_CS.Replace("{[DAYS]}", newValue);
		}

		public static string FormatNumericMonth(int month)
		{
			string newValue = (month + 1).ToString("00");
			return ScriptLocalization.TimeSpan.NumericMonth_CS.Replace("{[MONTHS]}", newValue);
		}

		public static string FormatNumericYear(int year)
		{
			string newValue = (year + 1).ToString("00");
			return ScriptLocalization.TimeSpan.NumericYear_CS.Replace("{[YEAR]}", newValue);
		}

		public static string CamelCaseStringToSentence(string camelCase)
		{
			return Regex.Replace(camelCase, "\\B[\\p{Lu}\\d]", (Match m) => " " + m.ToString().ToLower());
		}

		public static bool Contains(this string source, string toCheck, StringComparison comp)
		{
			return source.IndexOf(toCheck, comp) >= 0;
		}

		public static bool ContainsCaseInsensitive(this string source, string toCheck)
		{
			return source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
		}

		public static string LongestCommonPrefix(string[] strs)
		{
			if (strs == null || strs.Length == 0)
			{
				return "";
			}
			int num = int.MaxValue;
			for (int i = 0; i < strs.Length; i++)
			{
				num = Math.Min(num, strs[i].Length);
			}
			int num2 = 1;
			int num3 = num;
			while (num2 <= num3)
			{
				int num4 = (num2 + num3) / 2;
				if (IsCommonPrefix(strs, num4))
				{
					num2 = num4 + 1;
				}
				else
				{
					num3 = num4 - 1;
				}
			}
			return strs[0].Substring(0, (num2 + num3) / 2);
		}

		private static bool IsCommonPrefix(string[] strs, int len)
		{
			string value = strs[0].Substring(0, len);
			for (int i = 1; i < strs.Length; i++)
			{
				if (!strs[i].StartsWith(value))
				{
					return false;
				}
			}
			return true;
		}

		public static string ByteArrayToString(byte[] ba)
		{
			StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
			foreach (byte b in ba)
			{
				stringBuilder.AppendFormat("{0:x2}", b);
			}
			return stringBuilder.ToString();
		}

		public static string RemoveAllSpaces(string str)
		{
			return Regex.Replace(str, "\\s+", "");
		}

		public static string Truncate(this string value, int maxLength)
		{
			if (string.IsNullOrEmpty(value))
			{
				return value;
			}
			if (value.Length > maxLength)
			{
				return value.Substring(0, maxLength);
			}
			return value;
		}

		public static bool IsNullOrEmpty(this string value)
		{
			return string.IsNullOrEmpty(value);
		}

		public static string GetDelimitedString<T>(List<T> regions, string delimiter, Func<T, string> readFunc)
		{
			if (regions == null || regions.Count <= 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < regions.Count; i++)
			{
				stringBuilder.Append(readFunc(regions[i]));
				if (i < regions.Count - 1)
				{
					stringBuilder.Append(delimiter);
				}
			}
			return stringBuilder.ToString();
		}

		public static string TrimMiddle(string str, int maxLength)
		{
			if (str == null)
			{
				return null;
			}
			if (str.Length > maxLength)
			{
				int num = maxLength / 2;
				int length = maxLength - num;
				return str.Substring(0, length) + str.Substring(str.Length - num, num);
			}
			return str;
		}
	}
}
