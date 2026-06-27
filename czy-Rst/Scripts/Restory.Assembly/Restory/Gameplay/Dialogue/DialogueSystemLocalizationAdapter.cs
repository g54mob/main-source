using System;
using PixelCrushers.DialogueSystem;
using Restory.Data.Localization;
using Restory.Gameplay.GameSettings.Observers;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Dialogue
{
	public class DialogueSystemLocalizationAdapter : IInitializable, IDisposable
	{
		private GameSettingsLanguageChangeObserver languageChangeObserver;

		private DialogueSystemController dialogueSystemController;

		[Inject]
		private void Construct(GameSettingsLanguageChangeObserver languageChangeObserver, DialogueSystemController dialogueSystemController)
		{
			this.dialogueSystemController = dialogueSystemController;
			this.languageChangeObserver = languageChangeObserver;
		}

		public void Initialize()
		{
			languageChangeObserver.AddSubscriber(this, ResolveLocalizationChanged);
			ResolveLocalizationChanged(languageChangeObserver.Localization);
		}

		public void Dispose()
		{
			languageChangeObserver?.RemoveSubscriber(this);
		}

		private void ResolveLocalizationChanged(SystemLanguage newLanguage)
		{
			string text = LocalizationUtils.LanguageToISO[newLanguage];
			dialogueSystemController.SetLanguage(text.ToLower());
		}
	}
}
