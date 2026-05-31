using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Settings/UI/Locale Selector")]
	public class SettingCreatorLocaleToggle : SettingCreator<LocaleIdentifier>
	{
		[SerializeField]
		private UISettingLocale _prefab;

		[SerializeField]
		private LocaleList _locales;

		public override UISetting Spawn(Transform parent)
		{
			UISettingLocale uISettingLocale = CTSFactory.Instantiate(_prefab, parent, instantiateInWorldSpace: false, false);
			uISettingLocale.Initialize(base.Setting, base.SettingName);
			uISettingLocale.Initialize(_locales.AllowedLocales);
			uISettingLocale.gameObject.SetActive(value: true);
			return uISettingLocale;
		}
	}
}
