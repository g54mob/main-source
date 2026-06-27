using Restory.Gameplay.GameSettings;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Dialogue
{
	public class TemporaryLanguageSwitcher : MonoBehaviour
	{
		private GameSettingsManager gameSettings;

		public string CurrentLanguage
		{
			get
			{
				if (!gameSettings)
				{
					return "NONE";
				}
				return gameSettings.Localization.ToString();
			}
		}

		[Inject]
		private void Construct(GameSettingsManager gameSettings)
		{
			this.gameSettings = gameSettings;
		}

		private void ChangeLanguage(SystemLanguage newLanguage)
		{
			gameSettings.Localization = newLanguage;
		}
	}
}
