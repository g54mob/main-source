using System;
using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Locale List")]
	public class LocaleList : ScriptableObject
	{
		[Serializable]
		public struct LocaleData
		{
			public SystemLanguage SystemLang;

			public string SteamLang;

			public LocaleIdentifier Locale;

			public LocalizedString LocalizedName;
		}

		[SerializeField]
		private List<LocaleData> _allowedLocales = new List<LocaleData>();

		[field: SerializeField]
		public LocaleIdentifier DefaultLocale { get; private set; }

		public ReadOnlyList<LocaleData> AllowedLocales => _allowedLocales;

		public bool TryGetSystemLanguage(SystemLanguage systemLanguage, out LocaleIdentifier outLocale)
		{
			foreach (LocaleData allowedLocale in _allowedLocales)
			{
				if (allowedLocale.SystemLang == systemLanguage)
				{
					outLocale = allowedLocale.Locale;
					return true;
				}
			}
			return false;
		}

		public bool TryGetSteamLanguage(string steamLanguage, out LocaleIdentifier outLocale)
		{
			foreach (LocaleData allowedLocale in _allowedLocales)
			{
				if (allowedLocale.SteamLang == steamLanguage)
				{
					outLocale = allowedLocale.Locale;
					return true;
				}
			}
			return false;
		}
	}
}
