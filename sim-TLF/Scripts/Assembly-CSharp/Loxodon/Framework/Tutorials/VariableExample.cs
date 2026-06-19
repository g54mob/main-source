using System.Globalization;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Localizations;
using Loxodon.Framework.Views;
using Loxodon.Framework.Views.Variables;
using UnityEngine;
using UnityEngine.UI;

namespace Loxodon.Framework.Tutorials
{
	public class VariableExample : UIView
	{
		public VariableArray variables;

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
			VariableViewModel variableViewModel = new VariableViewModel
			{
				Username = "test",
				Email = "yangpc.china@gmail.com",
				Remember = true
			};
			variableViewModel.Color = variables.Get<Color>("color");
			variableViewModel.Vector = variables.Get<Vector3>("vector");
			this.BindingContext().DataContext = variableViewModel;
			BindingSet<VariableExample, VariableViewModel> bindingSet = this.CreateBindingSet<VariableExample, VariableViewModel>();
			bindingSet.Bind(variables.Get<InputField>("username")).For((InputField v) => v.text, (InputField v) => v.onEndEdit).To((VariableViewModel vm) => vm.Username)
				.TwoWay();
			bindingSet.Bind(variables.Get<InputField>("email")).For((InputField v) => v.text, (InputField v) => v.onEndEdit).To((VariableViewModel vm) => vm.Email)
				.TwoWay();
			bindingSet.Bind(variables.Get<Toggle>("remember")).For((Toggle v) => v.isOn, (Toggle v) => v.onValueChanged).To((VariableViewModel vm) => vm.Remember)
				.TwoWay();
			bindingSet.Bind(variables.Get<Button>("submit")).For((Button v) => v.onClick).To((VariableViewModel vm) => vm.OnSubmit);
			bindingSet.Build();
		}
	}
}
