using System;
using System.Globalization;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Localizations;
using Loxodon.Framework.Views;
using UnityEngine.UI;

namespace Loxodon.Framework.Tutorials
{
	public class DatabindingExample : UIView
	{
		public Text description;

		public Text title;

		public Text username;

		public Text password;

		public Text email;

		public Text birthday;

		public Text address;

		public Text remember;

		public Text errorMessage;

		public InputField usernameEdit;

		public InputField emailEdit;

		public Toggle rememberEdit;

		public Button submit;

		private Localization localization;

		protected override void Awake()
		{
			new BindingServiceBundle(Context.GetApplicationContext().GetContainer()).Start();
			CultureInfo cultureInfo = Locale.GetCultureInfo();
			localization = Localization.Current;
			localization.CultureInfo = cultureInfo;
			localization.AddDataProvider(new DefaultDataProvider("LocalizationTutorials", new XmlDocumentParser()));
		}

		protected override void Start()
		{
			Account account = new Account
			{
				ID = 1,
				Username = "test",
				Password = "test",
				Email = "yangpc.china@gmail.com",
				Birthday = new DateTime(2000, 3, 3)
			};
			account.Address.Value = "beijing";
			AccountViewModel dataContext = new AccountViewModel
			{
				Account = account
			};
			this.BindingContext().DataContext = dataContext;
			BindingSet<DatabindingExample, AccountViewModel> bindingSet = this.CreateBindingSet<DatabindingExample, AccountViewModel>();
			bindingSet.Bind(username).For((Text v) => v.text).To((AccountViewModel vm) => vm.Account.Username)
				.OneWay();
			bindingSet.Bind(password).For((Text v) => v.text).To((AccountViewModel vm) => vm.Account.Password)
				.OneWay();
			bindingSet.Bind(email).For((Text v) => v.text).To((AccountViewModel vm) => vm.Account.Email)
				.OneWay();
			bindingSet.Bind(remember).For((Text v) => v.text).To((AccountViewModel vm) => vm.Remember)
				.OneWay();
			bindingSet.Bind(birthday).For((Text v) => v.text).ToExpression((AccountViewModel vm) => string.Format("{0} ({1})", vm.Account.Birthday.ToString("yyyy-MM-dd"), DateTime.Now.Year - vm.Account.Birthday.Year))
				.OneWay();
			bindingSet.Bind(address).For((Text v) => v.text).To((AccountViewModel vm) => vm.Account.Address)
				.OneWay();
			bindingSet.Bind(description).For((Text v) => v.text).ToExpression((AccountViewModel vm) => localization.GetFormattedText("databinding.tutorials.description", vm.Account.Username, vm.Username))
				.OneWay();
			bindingSet.Bind(errorMessage).For((Text v) => v.text).To((AccountViewModel vm) => vm.Errors["errorMessage"])
				.OneWay();
			bindingSet.Bind(usernameEdit).For((InputField v) => v.text, (InputField v) => v.onEndEdit).To((AccountViewModel vm) => vm.Username)
				.TwoWay();
			bindingSet.Bind(usernameEdit).For((InputField v) => v.onValueChanged).To<string>((AccountViewModel vm) => vm.OnUsernameValueChanged);
			bindingSet.Bind(emailEdit).For((InputField v) => v.text, (InputField v) => v.onEndEdit).To((AccountViewModel vm) => vm.Email)
				.TwoWay();
			bindingSet.Bind(emailEdit).For((InputField v) => v.onValueChanged).To<string>((AccountViewModel vm) => vm.OnEmailValueChanged);
			bindingSet.Bind(rememberEdit).For((Toggle v) => v.isOn, (Toggle v) => v.onValueChanged).To((AccountViewModel vm) => vm.Remember)
				.TwoWay();
			bindingSet.Bind(submit).For((Button v) => v.onClick).To((AccountViewModel vm) => vm.OnSubmit);
			bindingSet.Build();
			BindingSet<DatabindingExample> bindingSet2 = this.CreateBindingSet();
			bindingSet2.Bind(title).For((Text v) => v.text).To(() => Res.databinding_tutorials_title)
				.OneTime();
			bindingSet2.Build();
		}
	}
}
