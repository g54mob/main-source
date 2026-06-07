using System;
using UnityEngine;

namespace Kamgam.LocalizationForSettings
{
	[Serializable]
	[CreateAssetMenu(fileName = "LocalizationProvider", menuName = "SettingsGenerator/LocalizationProvider", order = 5)]
	public class LocalizationProvider : ScriptableObject, ILocalizationProvider
	{
		[SerializeField]
		protected Localization _localization;

		public static bool IsUsable(LocalizationProvider provider)
		{
			if (provider != null)
			{
				return provider.HasLocalization();
			}
			return false;
		}

		public bool HasLocalization()
		{
			return _localization != null;
		}

		public ILocalization GetLocalization()
		{
			if (_localization == null)
			{
				_localization = new Localization();
			}
			return _localization;
		}

		public string Get(string term)
		{
			return Get(term, null);
		}

		public string Get(string term, string defaultValue)
		{
			if (HasLocalization() && GetLocalization().HasTerm(term))
			{
				return GetLocalization().Get(term);
			}
			return defaultValue;
		}
	}
}
