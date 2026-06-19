using Loxodon.Framework.Localizations;
using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class DatabindingForLocalizationViewModel : ViewModelBase
	{
		private Localization localization;

		public DatabindingForLocalizationViewModel(Localization localization)
		{
			this.localization = localization;
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
