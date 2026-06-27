using Restory.Gameplay.GameSettings.Observers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface
{
	[DisallowMultipleComponent]
	public class GUI_LocalisedImage : MonoBehaviour
	{
		[SerializeField]
		private Image targetImage;

		[SerializeField]
		private LocalisedSpriteData localisedSpriteData;

		private GameSettingsLanguageChangeObserver gameSettingsManager;

		private void Awake()
		{
			_ = (bool)localisedSpriteData;
		}

		[Inject]
		private void Construct(GameSettingsLanguageChangeObserver gameSettingsManager)
		{
			this.gameSettingsManager = gameSettingsManager;
			if (base.isActiveAndEnabled)
			{
				OnEnable();
			}
		}

		private void OnEnable()
		{
			if (gameSettingsManager != null)
			{
				gameSettingsManager.AddSubscriber(this, OnLocalisationChanged);
				OnLocalisationChanged(gameSettingsManager.Localization);
			}
		}

		private void OnDisable()
		{
			if (gameSettingsManager != null)
			{
				gameSettingsManager.RemoveSubscriber(this);
			}
		}

		private void OnLocalisationChanged(SystemLanguage newLanguage)
		{
			if (localisedSpriteData.Sprites.TryGetValue(newLanguage, out var value))
			{
				targetImage.overrideSprite = value;
			}
			else
			{
				targetImage.overrideSprite = null;
			}
		}
	}
}
