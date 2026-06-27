using Restory.Data.PC;
using Restory.Data.Tutorials;
using Restory.Gameplay.PC;
using Restory.UI.Presenters;
using Restory.Utils;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class FirstEmailClientOpeningTutorialHandler : TutorialHandlerBase
	{
		private readonly PcAppInfo mailClientAppInfo;

		private readonly GUI_PcWindowsXpScreen pcWindowsXpScreen;

		private readonly PcAppManager pcAppManager;

		public FirstEmailClientOpeningTutorialHandler(GUI_PcWindowsXpScreen pcWindowsXpScreen, PcAppManager pcAppManager, FirstEmailClientOpeningTutorial tutorial)
			: base(tutorial)
		{
			mailClientAppInfo = tutorial.MailClientAppInfo;
			this.pcWindowsXpScreen = pcWindowsXpScreen;
			this.pcAppManager = pcAppManager;
		}

		public override void Init()
		{
			pcWindowsXpScreen.SetFirstMailClientPreviouslyOpenedState(wasOpened: false);
			pcAppManager.OnAppLaunched += ResolveOnAppLaunched;
		}

		public override void Cleanup()
		{
			if (pcWindowsXpScreen.MonoShellExists())
			{
				pcAppManager.OnAppLaunched -= ResolveOnAppLaunched;
			}
		}

		private void ResolveOnAppLaunched(PcAppInfo appInfo)
		{
			if (appInfo == mailClientAppInfo)
			{
				pcAppManager.OnAppLaunched -= ResolveOnAppLaunched;
				pcWindowsXpScreen.SetFirstMailClientPreviouslyOpenedState(wasOpened: true);
				CompleteTutorial();
			}
		}
	}
}
