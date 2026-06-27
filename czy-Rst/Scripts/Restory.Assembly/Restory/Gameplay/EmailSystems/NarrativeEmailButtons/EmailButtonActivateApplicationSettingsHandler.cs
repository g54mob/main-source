using Restory.Data.Email;
using Restory.Gameplay.PC;
using Restory.UI.Presenters;

namespace Restory.Gameplay.EmailSystems.NarrativeEmailButtons
{
	public class EmailButtonActivateApplicationSettingsHandler : EmailButtonHandlerBase<EmailButtonActivateApplicationSettings>
	{
		private readonly GUI_PcWindowsXpScreen pcWindowsXpScreen;

		private readonly PcAppManager pcAppManager;

		public EmailButtonActivateApplicationSettingsHandler(PcAppManager pcAppManager, GUI_PcWindowsXpScreen pcWindowsXpScreen)
		{
			this.pcAppManager = pcAppManager;
			this.pcWindowsXpScreen = pcWindowsXpScreen;
		}

		protected override void HandleButtonPress(EmailButtonActivateApplicationSettings buttonSettings)
		{
			pcAppManager.ActivatePcApp(buttonSettings.PcAppInfo);
			pcWindowsXpScreen.CurrentState = PcScreenStates.InstallingApp;
		}
	}
}
