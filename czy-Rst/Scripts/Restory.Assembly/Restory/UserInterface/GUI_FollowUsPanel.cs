using Restory.Data.GameConfigs;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface
{
	public class GUI_FollowUsPanel : MonoBehaviour
	{
		[SerializeField]
		private GameObject wishlistButton;

		[SerializeField]
		private GameObject discordButton;

		[SerializeField]
		private GameObject surveyButton;

		private GameConfig gameConfig;

		private VersionType gameVersionType;

		[Inject]
		private void Construct(GameConfig gameConfig)
		{
			this.gameConfig = gameConfig;
			UpdatePanel();
		}

		private void OnEnable()
		{
			if ((bool)gameConfig && gameVersionType != gameConfig.VersionType)
			{
				UpdatePanel();
			}
		}

		private void UpdatePanel()
		{
			gameVersionType = gameConfig.VersionType;
			if (gameConfig.VersionType == VersionType.Release)
			{
				wishlistButton.SetActive(value: false);
				discordButton.SetActive(value: true);
				surveyButton.SetActive(value: false);
			}
			else
			{
				wishlistButton.SetActive(value: true);
				discordButton.SetActive(value: true);
				surveyButton.SetActive(value: true);
			}
		}
	}
}
