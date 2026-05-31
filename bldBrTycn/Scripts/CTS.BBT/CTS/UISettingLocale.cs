using System.Collections.Generic;
using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class UISettingLocale : UISetting<LocaleIdentifier>
	{
		[SerializeField]
		private UILocaleToggle _togglePrefab;

		[SerializeField]
		private Transform _toggleParent;

		public void Initialize<T>(T locales) where T : IEnumerable<LocaleList.LocaleData>
		{
			foreach (LocaleList.LocaleData item in locales)
			{
				UILocaleToggle uILocaleToggle = CTSFactory.Instantiate(_togglePrefab, _toggleParent, instantiateInWorldSpace: false, false);
				uILocaleToggle.Initialize(item.Locale, _setting, item.LocalizedName);
				uILocaleToggle.gameObject.SetActive(value: true);
			}
		}
	}
}
