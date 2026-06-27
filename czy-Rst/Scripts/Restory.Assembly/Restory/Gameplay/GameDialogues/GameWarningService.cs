using System;
using Restory.Data.Devices;
using Restory.Data.GameWarnings;
using Restory.Data.Localization;
using Restory.Gameplay.UserInterface;
using Zenject;

namespace Restory.Gameplay.GameDialogues
{
	public class GameWarningService : IInitializable, IDisposable
	{
		private readonly LocalizationSystem localizationSystem;

		private readonly GUI_GameWarningDialogue warningDialogue;

		[Inject]
		public GameWarningService(LocalizationSystem localizationSystem, GUI_GameWarningDialogue warningDialogue)
		{
			this.localizationSystem = localizationSystem;
			this.warningDialogue = warningDialogue;
		}

		public void Initialize()
		{
			warningDialogue.OnWarningShown += ResolveWarningShown;
			warningDialogue.gameObject.SetActive(value: false);
		}

		public void Dispose()
		{
			warningDialogue.OnWarningShown -= ResolveWarningShown;
		}

		public void ShowWarning(GameWarning warning)
		{
			warningDialogue.gameObject.SetActive(value: true);
			warningDialogue.Show(localizationSystem.GetTranslation(warning.MessageLocalizationKey));
		}

		public void ShowWarning(GameWarning warning, DeviceInfo deviceInfo)
		{
			warningDialogue.gameObject.SetActive(value: true);
			warningDialogue.Show(localizationSystem.GetTranslation(warning.MessageLocalizationKey) + " " + localizationSystem.GetTranslation(deviceInfo.NameLocalizationKey));
		}

		private void ResolveWarningShown()
		{
			warningDialogue.gameObject.SetActive(value: false);
		}
	}
}
