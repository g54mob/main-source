using System.Collections.Generic;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using TMPro;

namespace NSMedieval.UI
{
	public class FontFallbackSwitcher
	{
		private readonly Dictionary<string, string> fontNamesByLanguage = new Dictionary<string, string>
		{
			{ "Chinese", "SCHFont" },
			{ "Korean", "KOFOnt SDF" },
			{ "Russian", "RUFont" },
			{ "Japanese", "JPFont" },
			{ "Thai", "THFont" }
		};

		public void OnLanguageChange(string language)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(18, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\FontFallbackSwitcher.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("OnLanguageChange: ");
				messageBuilder.AppendFormatted(language);
			}
			Log.Trace(messageBuilder);
			if (fontNamesByLanguage.TryGetValue(language, out var value))
			{
				UpdateFallbackOrder(value);
			}
		}

		private static void UpdateFallbackOrder(string fontName)
		{
			LogFallbackOrder();
			List<TMP_FontAsset> fallbackFontAssets = TMP_Settings.fallbackFontAssets;
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\FontFallbackSwitcher.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(fontName);
				messageBuilder.AppendLiteral(" moving to the top of the list");
			}
			Log.Info(messageBuilder);
			TMP_FontAsset tMP_FontAsset = fallbackFontAssets.Find((TMP_FontAsset x) => x.name == fontName);
			if (tMP_FontAsset == null)
			{
				FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\FontFallbackSwitcher.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Could not find fallback font: ");
					messageBuilder2.AppendFormatted(fontName);
				}
				Log.Error(messageBuilder2);
			}
			else if (fallbackFontAssets.IndexOf(tMP_FontAsset) == 0)
			{
				FVLogDebugInterpolationHandler messageBuilder3 = new FVLogDebugInterpolationHandler(42, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\FontFallbackSwitcher.cs");
				if (isEnabled)
				{
					messageBuilder3.AppendFormatted(tMP_FontAsset);
					messageBuilder3.AppendLiteral(" already at the top of the list. Skipping.");
				}
				Log.Debug(messageBuilder3);
			}
			else
			{
				fallbackFontAssets.Remove(tMP_FontAsset);
				fallbackFontAssets.Insert(0, tMP_FontAsset);
				TMPro_EventManager.ON_TMP_SETTINGS_CHANGED();
				LogFallbackOrder();
			}
		}

		private static void LogFallbackOrder()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Font Fallback Order:");
			int num = 1;
			foreach (TMP_FontAsset fallbackFontAsset in TMP_Settings.fallbackFontAssets)
			{
				stringBuilder.AppendLine($"  {num}: {fallbackFontAsset.name}");
				num++;
			}
			Log.Info(stringBuilder.ToString(), "C:\\GIT\\dev\\Assets\\Scripts\\UI\\FontFallbackSwitcher.cs");
		}
	}
}
