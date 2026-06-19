using System.Globalization;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Localizations;
using UnityEngine;
using UnityEngine.UI;

namespace Loxodon.Framework.Tutorials
{
	public class LocalizedDataBinderExample : MonoBehaviour
	{
		public Dropdown dropdown;

		private Localization localization;

		private void Awake()
		{
			new BindingServiceBundle(Context.GetApplicationContext().GetContainer()).Start();
			localization = Localization.Current;
			CultureInfo cultureInfoByLanguage = Locale.GetCultureInfoByLanguage(SystemLanguage.English);
			localization.CultureInfo = cultureInfoByLanguage;
			localization.AddDataProvider(new DefaultDataProvider("LocalizationTutorials", new XmlDocumentParser()));
			dropdown.onValueChanged.AddListener(OnValueChanged);
		}

		public void OnValueChanged(int value)
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
	}
}
