using System;
using System.Globalization;
using I2.Loc;

namespace DV.Localization
{
	public static class LocalizationAPI
	{
		public const string N0 = "N0";

		public const string N1 = "N1";

		public const string N2 = "N2";

		public const string NX = "#,0.#";

		public const string AMOUNT_FORMAT = "N1";

		public const string MONEY_FORMAT = "N2";

		public const string SHORT_MONEY_FORMAT = "N0";

		public static CultureInfo CC => LocalizationManager.CurrentCulture;

		public static string L(string translationKey)
		{
			return L(translationKey, Array.Empty<string>());
		}

		public static string L(string translationKey, string firstParamValue)
		{
			using (PooledArray<string> pooledArray = ArrayPool<string>.New(1, firstParamValue))
			{
				return L(translationKey, pooledArray);
			}
		}

		public static string L(string translationKey, string firstParamValue, string secondParamValue)
		{
			using (PooledArray<string> pooledArray = ArrayPool<string>.New(2, firstParamValue, secondParamValue))
			{
				return L(translationKey, pooledArray);
			}
		}

		public static string L(string translationKey, params string[] paramValues)
		{
			string translation = LocalizationManager.GetTranslation(translationKey);
			translation = Sanitized(translationKey, translation);
			if (paramValues != null && paramValues.Length != 0)
			{
				LocalizationManager.ApplyLocalizationParams(ref translation, ParamGetter(paramValues));
			}
			return translation;
		}

		public static string Lo(string translationKey, string languageName, params string[] paramValues)
		{
			string translation = LocalizationManager.GetTranslation(translationKey, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters: false, null, languageName);
			translation = Sanitized(translationKey, translation, languageName);
			if (paramValues != null && paramValues.Length != 0)
			{
				LocalizationManager.ApplyLocalizationParams(ref translation, ParamGetter(paramValues));
			}
			return translation;
		}

		public static bool HasTranslation(string translationKey)
		{
			return !string.IsNullOrWhiteSpace(LocalizationManager.GetTranslation(translationKey));
		}

		public static void SetLanguage(string languageName, string languageCode)
		{
			LocalizationManager.SetLanguageAndCode(languageName, languageCode);
		}

		private static string Sanitized(string key, string translation, string languageOverride = "")
		{
			if (string.IsNullOrWhiteSpace(translation))
			{
				return "[ MISSING TRANSLATION ]";
			}
			return translation;
		}

		private static LocalizationManager._GetParam ParamGetter(string[] paramValues)
		{
			return Getter;
			object Getter(string key)
			{
				if (paramValues != null && int.TryParse(key, out var result) && result <= paramValues.Length)
				{
					return paramValues[result];
				}
				return null;
			}
		}
	}
}
