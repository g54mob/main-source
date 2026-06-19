using System.Collections;
using System.Globalization;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Localizations;
using Loxodon.Framework.Messaging;
using Loxodon.Framework.Services;
using Loxodon.Framework.Views;
using UnityEngine;

namespace Loxodon.Framework.Examples
{
	public class Launcher : MonoBehaviour
	{
		private ApplicationContext context;

		private ISubscription<WindowStateEventArgs> subscription;

		private void Awake()
		{
			if (Object.FindObjectOfType<GlobalWindowManagerBase>() == null)
			{
				throw new NotFoundException("Not found the GlobalWindowManager.");
			}
			context = Context.GetApplicationContext();
			IServiceContainer container = context.GetContainer();
			new BindingServiceBundle(context.GetContainer()).Start();
			container.Register((IUIViewLocator)new ResourcesViewLocator());
			CultureInfo cultureInfo = Locale.GetCultureInfo();
			Localization current = Localization.Current;
			current.CultureInfo = cultureInfo;
			current.AddDataProvider(new ResourcesDataProvider("LocalizationExamples", new XmlDocumentParser()));
			container.Register(current);
			IAccountRepository repository = new AccountRepository();
			container.Register((IAccountService)new AccountService(repository));
			GlobalSetting.enableWindowStateBroadcast = true;
			GlobalSetting.useBlocksRaycastsInsteadOfInteractable = true;
			subscription = Window.Messenger.Subscribe(delegate(WindowStateEventArgs e)
			{
				Debug.LogFormat("The window[{0}] state changed from {1} to {2}", e.Window.Name, e.OldState, e.State);
			});
		}

		private IEnumerator Start()
		{
			WindowContainer winContainer = WindowContainer.Create("MAIN");
			yield return null;
			StartupWindow startupWindow = context.GetService<IUIViewLocator>().LoadWindow<StartupWindow>(winContainer, "UI/Startup/Startup");
			startupWindow.Create();
			ITransition transition = startupWindow.Show().OnStateChanged(delegate
			{
			});
			yield return transition.WaitForDone();
		}
	}
}
