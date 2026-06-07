using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine.InputSystem;

namespace Gh.Tk
{
	public class I18n
	{
		public static string GameName;

		private static CultureInfo _currentLanguageCulture;

		public static Dictionary<string, I18nLanguageEntry> FallbackLanguageDict;

		private static Dictionary<string, I18nLanguageEntry> CurrentLanguageDict;

		private static Dictionary<string, I18nLanguageEntry> CurrentAudioLanguageDict;

		private static string _currentLanguage;

		private static string _currentAudioLanguage;

		public static EventHandler<ValueChangedEventArgs<string>> BeforeLanguageChanged;

		public static EventHandler OnLanguageChanged;

		public static EventHandler<ValueChangedEventArgs<string>> AfterLanguageChanged;

		private static string _toggleLanguage;

		public static string I18nFolder;

		public const string CustomI18nFolder = "CustomI18n";

		public const string TranslationsFolder = "translations";

		public static int NextGlobalOrder;

		[ThreadStatic]
		private static StringBuilder _trimTextSb;

		private static Dictionary<string, I18nMainDbEntry> _mainDatabase;

		private static bool _shouldUpdateGlobalOrder;

		public static CultureInfo CurrentLanguageCulture => null;

		private static Dictionary<string, Dictionary<string, I18nLanguageEntry>> LanguageDicts { get; set; }

		public static string CurrentLanguage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static string CurrentAudioLanguage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static string GetOSLanguage()
		{
			return null;
		}

		public static void InitCore(string language = "en")
		{
		}

		public static void Init(string language = "en")
		{
		}

		private static void OnToggleEnglish(InputAction.CallbackContext obj)
		{
		}

		private static void SwitchToNextLanguage(InputAction.CallbackContext obj)
		{
		}

		private static bool TryLoadLanguageDb(string language)
		{
			return false;
		}

		public static void AddEntryFor(string original, string comments, bool ignoreForTranslation, string translationType, string context, string translationComment = null, string contentOverrideForHash = null)
		{
		}

		public static string TrimText(string value)
		{
			return null;
		}

		private static void AddEntry(I18nMainDbEntry mainDbEntry)
		{
		}

		public static string GetHashWithFallback(string text)
		{
			return null;
		}

		public static string GetHash(string text)
		{
			return null;
		}

		public static string GetContent(string contentHash, bool useFallbackLanguage = false, bool returnNullIfNotFound = false, bool useAudioLanguage = false)
		{
			return null;
		}

		public static void ShowLanguageWarning(Action callback = null)
		{
		}
	}
}
