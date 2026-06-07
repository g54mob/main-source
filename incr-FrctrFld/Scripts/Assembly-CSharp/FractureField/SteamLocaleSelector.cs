using System;
using System.Collections.Generic;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace FractureField
{
	[Serializable]
	public class SteamLocaleSelector : IStartupLocaleSelector
	{
		private static readonly Dictionary<string, string> SteamToUnityLocaleMap;

		public Locale GetStartupLocale(ILocalesProvider availableLocales)
		{
			return null;
		}
	}
}
