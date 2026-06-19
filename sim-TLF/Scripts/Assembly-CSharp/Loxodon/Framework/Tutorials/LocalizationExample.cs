using Loxodon.Framework.Localizations;
using UnityEngine;
using UnityEngine.UI;

namespace Loxodon.Framework.Tutorials
{
	public class LocalizationExample : MonoBehaviour
	{
		public Dropdown dropdown;

		private Localization localization;

		private void Awake()
		{
			localization = Localization.Current;
			localization.CultureInfo = Locale.GetCultureInfoByLanguage(SystemLanguage.English);
			localization.AddDataProvider(new DefaultDataProvider("LocalizationTutorials", new XmlDocumentParser()));
			dropdown.onValueChanged.AddListener(OnValueChanged);
		}

		private void OnValueChanged(int value)
		{
			switch (value)
			{
			case 0:
				localization.CultureInfo = Locale.GetCultureInfoByLanguage(SystemLanguage.English);
				break;
			case 1:
				localization.CultureInfo = Locale.GetCultureInfoByLanguage(SystemLanguage.ChineseSimplified);
				break;
			default:
				localization.CultureInfo = Locale.GetCultureInfoByLanguage(SystemLanguage.English);
				break;
			}
		}

		private void OnDestroy()
		{
			dropdown.onValueChanged.RemoveListener(OnValueChanged);
		}
	}
}
