using System.Globalization;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Localizations;
using UnityEngine;
using UnityEngine.UI;

namespace Loxodon.Framework.Tutorials
{
	public class DatabindingForLocalizationExample : MonoBehaviour
	{
		public Dropdown dropdown;

		public Text text;

		private Localization localization;

		private void Awake()
		{
			new BindingServiceBundle(Context.GetApplicationContext().GetContainer()).Start();
			localization = Localization.Current;
			CultureInfo cultureInfoByLanguage = Locale.GetCultureInfoByLanguage(SystemLanguage.English);
			localization.CultureInfo = cultureInfoByLanguage;
			localization.AddDataProvider(new DefaultLocalizationSourceDataProvider("LocalizationTutorials", "LocalizationModule.asset"));
		}

		private void Start()
		{
			BindingSet<DatabindingForLocalizationExample, DatabindingForLocalizationViewModel> bindingSet = this.CreateBindingSet(new DatabindingForLocalizationViewModel(localization));
			bindingSet.Bind(dropdown).For((Dropdown v) => v.onValueChanged).To<int>((DatabindingForLocalizationViewModel vm) => vm.OnValueChanged);
			bindingSet.Build();
			BindingSet<DatabindingForLocalizationExample> bindingSet2 = this.CreateBindingSet();
			bindingSet2.Bind(text).For((Text v) => v.text).ToValue(localization.GetValue("localization.tutorials.content"))
				.OneWay();
			bindingSet2.Build();
		}
	}
}
