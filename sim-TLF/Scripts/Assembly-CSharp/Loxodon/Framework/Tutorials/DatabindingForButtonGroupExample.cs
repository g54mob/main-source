using System.Globalization;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Localizations;
using Loxodon.Framework.Views;
using UnityEngine.UI;

namespace Loxodon.Framework.Tutorials
{
	public class DatabindingForButtonGroupExample : UIView
	{
		public Image image1;

		public Button button1;

		public Button button2;

		public Button button3;

		public Button button4;

		public Button button5;

		public Text text;

		protected override void Awake()
		{
			new BindingServiceBundle(Context.GetApplicationContext().GetContainer()).Start();
			CultureInfo cultureInfo = Locale.GetCultureInfo();
			Localization current = Localization.Current;
			current.CultureInfo = cultureInfo;
			current.AddDataProvider(new DefaultDataProvider("LocalizationTutorials", new XmlDocumentParser()));
		}

		protected override void Start()
		{
			ButtonGroupViewModel dataContext = new ButtonGroupViewModel();
			this.BindingContext().DataContext = dataContext;
			BindingSet<DatabindingForButtonGroupExample, ButtonGroupViewModel> bindingSet = this.CreateBindingSet<DatabindingForButtonGroupExample, ButtonGroupViewModel>();
			bindingSet.Bind(button1).For((Button v) => v.onClick).To((ButtonGroupViewModel vm) => vm.Click)
				.CommandParameter(() => button1.name);
			bindingSet.Bind(button1).For((Button v) => v.onClick).To((ButtonGroupViewModel vm) => vm.ChangeColor)
				.OneWay();
			bindingSet.Bind(image1).For((Image v) => v.color).To((ButtonGroupViewModel vm) => vm.Color)
				.OneWay();
			bindingSet.Bind(button2).For((Button v) => v.onClick).To((ButtonGroupViewModel vm) => vm.Click)
				.CommandParameter(() => button2.name);
			bindingSet.Bind(button3).For((Button v) => v.onClick).To((ButtonGroupViewModel vm) => vm.Click)
				.CommandParameter(() => button3.name);
			bindingSet.Bind(button4).For((Button v) => v.onClick).To((ButtonGroupViewModel vm) => vm.Click)
				.CommandParameter(() => button4.name);
			bindingSet.Bind(button5).For((Button v) => v.onClick).To((ButtonGroupViewModel vm) => vm.Click)
				.CommandParameter(() => button5.name);
			bindingSet.Bind(text).For((Text v) => v.text).To((ButtonGroupViewModel vm) => vm.Text)
				.OneWay();
			bindingSet.Build();
		}
	}
}
