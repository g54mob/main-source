using System;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Tools;
using NSMedieval.WorldMap;

namespace NSMedieval.UI.Utils
{
	public static class LocKeyUtils
	{
		public static string ToLocalized(this string locKey, BodyType bodyType)
		{
			return MonoSingleton<LocalizationController>.Instance.GetText(locKey, bodyType);
		}

		public static string ToLocalized(this string locKey, string style = null)
		{
			string text = MonoSingleton<LocalizationController>.Instance.GetText(locKey);
			if (style != null)
			{
				text = "<style=" + style + ">" + text + "</style>";
			}
			return text;
		}

		public static string ToLocalized(this string locKey, WorldMapPlace place)
		{
			return TextFormatting.FormatText(locKey.ToLocalized(), place);
		}

		public static string ToStyled(this string text, string styleName)
		{
			return "<style=" + styleName + ">" + text + "</style>";
		}

		public static string ToRed(this string text)
		{
			return text.ToStyled("DefaultRed");
		}

		public static string GetNameLocalized(this LocKeys[] locKeys, string style = null)
		{
			if (locKeys == null)
			{
				Log.Error("LocKeys is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\LocKeyUtils.cs");
				return string.Empty;
			}
			return GetName(locKeys).ToLocalized(style);
		}

		public static string GetInfoLocalized(this LocKeys[] locKeys, string style = null)
		{
			if (locKeys == null)
			{
				Log.Error("LocKeys is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\LocKeyUtils.cs");
				return string.Empty;
			}
			return GetInfo(locKeys).ToLocalized(style);
		}

		public static string GetDescriptionLocalized(this LocKeys[] locKeys, string style = null)
		{
			if (locKeys == null)
			{
				Log.Error("LocKeys is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\LocKeyUtils.cs");
				return string.Empty;
			}
			return GetDescription(locKeys).ToLocalized(style);
		}

		public static string GetName(LocKeys[] locKeys)
		{
			if (locKeys == null)
			{
				Log.Error("LocKeys is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\LocKeyUtils.cs");
				return string.Empty;
			}
			return GetLanguageEntry(locKeys).Name;
		}

		public static string GetInfo(LocKeys[] locKeys)
		{
			if (locKeys == null)
			{
				Log.Error("LocKeys is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\LocKeyUtils.cs");
				return string.Empty;
			}
			return GetLanguageEntry(locKeys).Info;
		}

		public static string GetDescription(LocKeys[] locKeys)
		{
			if (locKeys == null)
			{
				Log.Error("LocKeys is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\LocKeyUtils.cs");
				return string.Empty;
			}
			return GetLanguageEntry(locKeys).Description;
		}

		public static string GetType(LocKeys[] locKeys)
		{
			if (locKeys == null)
			{
				Log.Error("LocKeys is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\LocKeyUtils.cs");
				return string.Empty;
			}
			return GetLanguageEntry(locKeys).Type;
		}

		public static bool GetTooltipLines(LocKeys[] locKeys, out string[] lines)
		{
			if (locKeys == null)
			{
				Log.Error("LocKeys is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\LocKeyUtils.cs");
				lines = null;
				return false;
			}
			lines = GetLanguageEntry(locKeys).TooltipLines;
			return lines != null;
		}

		public static bool GetTooltipNotes(LocKeys[] locKeys, out string[] lines)
		{
			if (locKeys == null)
			{
				Log.Error("LocKeys is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\LocKeyUtils.cs");
				lines = null;
				return false;
			}
			lines = GetLanguageEntry(locKeys).TooltipNotes;
			return lines != null;
		}

		public static bool GetRandomVariation(LocKeys[] locKeys, out string randomVariant)
		{
			if (locKeys == null)
			{
				Log.Error("LocKeys is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\LocKeyUtils.cs");
				randomVariant = null;
				return false;
			}
			randomVariant = GetLanguageEntry(locKeys).Variations.PickRandom();
			return randomVariant != null;
		}

		private static LocKeys GetLanguageEntry(LocKeys[] locKeys)
		{
			if (locKeys == null)
			{
				Log.Error("LocKeys is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Utils\\LocKeyUtils.cs");
				return null;
			}
			if (locKeys.Length == 0)
			{
				return locKeys[0];
			}
			string currentLanguageName = UiUtils.Localize.GetCurrentLanguageName();
			try
			{
				int i = 0;
				for (int num = locKeys.Length; i < num; i++)
				{
					LocKeys locKeys2 = locKeys[i];
					if (!string.IsNullOrEmpty(locKeys2.LanguageName) && locKeys2.LanguageName.Equals(currentLanguageName))
					{
						return locKeys2;
					}
				}
				return locKeys[0];
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
				throw;
			}
		}
	}
}
