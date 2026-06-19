using System.Globalization;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Localizations;
using Loxodon.Framework.Services;
using Loxodon.Framework.Views;
using UnityEngine.UI;

namespace Loxodon.Framework.Tutorials
{
	public class DialogServiceExample : WindowView
	{
		public Button openAlert;

		public Button openAlert2;

		protected override void Awake()
		{
			ApplicationContext applicationContext = Context.GetApplicationContext();
			new BindingServiceBundle(applicationContext.GetContainer()).Start();
			IServiceContainer container = applicationContext.GetContainer();
			container.Register((IUIViewLocator)new DefaultUIViewLocator());
			CultureInfo cultureInfo = Locale.GetCultureInfo();
			Localization current = Localization.Current;
			current.CultureInfo = cultureInfo;
			current.AddDataProvider(new DefaultDataProvider("LocalizationTutorials", new XmlDocumentParser()));
			container.Register(current);
			IDialogService target = new DefaultDialogService();
			container.Register(target);
		}

		protected override void Start()
		{
			DialogServiceExampleViewModel dataContext = new DialogServiceExampleViewModel(Context.GetApplicationContext().GetService<IDialogService>());
			this.SetDataContext(dataContext);
			BindingSet<DialogServiceExample, DialogServiceExampleViewModel> bindingSet = this.CreateBindingSet<DialogServiceExample, DialogServiceExampleViewModel>();
			bindingSet.Bind(openAlert).For((Button v) => v.onClick).To((DialogServiceExampleViewModel vm) => vm.OpenAlertDialog);
			bindingSet.Bind(openAlert2).For((Button v) => v.onClick).To((DialogServiceExampleViewModel vm) => vm.OpenAlertDialog2);
			bindingSet.Build();
		}
	}
}
