using Loxodon.Framework.Commands;
using Loxodon.Framework.Contexts;
using Loxodon.Framework.Interactivity;
using Loxodon.Framework.Localizations;
using Loxodon.Framework.Messaging;
using Loxodon.Framework.Prefs;
using Loxodon.Framework.ViewModels;
using Loxodon.Log;
using UnityEngine;

namespace Loxodon.Framework.Examples
{
	public class StartupViewModel : ViewModelBase
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(StartupViewModel));

		private ProgressBar progressBar = new ProgressBar();

		private SimpleCommand command;

		private Localization localization;

		public AsyncInteractionRequest<WindowNotification> LoginRequest { get; private set; }

		public AsyncInteractionRequest<ProgressBar> LoadSceneRequest { get; private set; }

		public InteractionRequest DismissRequest { get; private set; }

		public ProgressBar ProgressBar => progressBar;

		public ICommand Click => command;

		public StartupViewModel()
			: this(null)
		{
		}

		public StartupViewModel(IMessenger messenger)
			: base(messenger)
		{
			StartupViewModel startupViewModel = this;
			ApplicationContext applicationContext = Context.GetApplicationContext();
			localization = applicationContext.GetService<Localization>();
			IAccountService service = applicationContext.GetService<IAccountService>();
			Preferences globalPreferences = applicationContext.GetGlobalPreferences();
			LoginRequest = new AsyncInteractionRequest<WindowNotification>(this);
			LoadSceneRequest = new AsyncInteractionRequest<ProgressBar>(this);
			DismissRequest = new InteractionRequest(this);
			LoginViewModel loginViewModel = new LoginViewModel(service, localization, globalPreferences);
			command = new SimpleCommand(async delegate
			{
				startupViewModel.command.Enabled = false;
				await startupViewModel.LoginRequest.Raise(WindowNotification.CreateShowNotification(loginViewModel, ignoreAnimation: false, waitDismissed: true));
				startupViewModel.command.Enabled = true;
				if (loginViewModel.Account != null)
				{
					await startupViewModel.LoadSceneRequest.Raise(startupViewModel.ProgressBar);
					startupViewModel.DismissRequest.Raise();
				}
			});
		}

		public void OnClick()
		{
			log.Debug("onClick");
		}

		public async void Unzip()
		{
			command.Enabled = false;
			progressBar.Enable = true;
			ProgressBar.Tip = R.startup_progressbar_tip_unziping;
			try
			{
				float progress = 0f;
				while (progress < 1f)
				{
					progress += 0.01f;
					ProgressBar.Progress = progress;
					await new WaitForSecondsRealtime(0.02f);
				}
			}
			finally
			{
				command.Enabled = true;
				progressBar.Enable = false;
				progressBar.Tip = "";
				command.Execute(null);
			}
		}
	}
}
