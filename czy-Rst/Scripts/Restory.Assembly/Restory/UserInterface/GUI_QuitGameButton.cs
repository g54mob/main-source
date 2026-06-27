using System;
using Restory.Data.GameConfigs;
using Restory.Data.Localization;
using Restory.UserInterface.ConfirmationDialogues;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface
{
	[RequireComponent(typeof(Button))]
	public class GUI_QuitGameButton : MonoBehaviour
	{
		[SerializeField]
		private GUI_ScreenObjectBase screenObjectBase;

		[SerializeField]
		private string exitGameDialogueLocalizationId = string.Empty;

		[SerializeField]
		private Button button;

		private GUI_FadeScreens fadeScreens;

		private GameConfig gameConfig;

		private LocalizationSystem localizationSystem;

		private GUI_ConfirmationDialog confirmationDialog;

		public event Action OnQuitShown = delegate
		{
		};

		public event Action OnQuitClosed = delegate
		{
		};

		[Inject]
		private void Construct(GUI_FadeScreens fadeScreens, LocalizationSystem localizationSystem, GameConfig gameConfig, [Inject(Id = "MainMenuWindow")] GameObject confirmationDialogueGo)
		{
			this.fadeScreens = fadeScreens;
			this.localizationSystem = localizationSystem;
			this.gameConfig = gameConfig;
			confirmationDialog = confirmationDialogueGo.GetComponent<GUI_ConfirmationDialog>();
		}

		private void Awake()
		{
			Initialize();
		}

		private void Initialize()
		{
			if (button == null)
			{
				button = GetComponent<Button>();
			}
			button.onClick.AddListener(ResolveOnButtonClick);
		}

		private void ResolveOnButtonClick()
		{
			VersionType versionType = gameConfig.VersionType;
			if ((uint)versionType <= 1u)
			{
				ShowWishlist();
			}
			else
			{
				ExitGame();
			}
		}

		private void ShowWishlist()
		{
			if (screenObjectBase != null)
			{
				screenObjectBase.Hide();
			}
		}

		private void ExitGame()
		{
			this.OnQuitShown();
			confirmationDialog.ShowChoice(localizationSystem.GetTranslation(exitGameDialogueLocalizationId), delegate
			{
				fadeScreens.FadeInDefaultScreen(-1f, null, OnConfirmationQuit);
			}, delegate
			{
				this.OnQuitClosed();
			});
		}

		private void OnConfirmationQuit()
		{
			Addressables.ClearResourceLocators();
			Resources.UnloadUnusedAssets();
			Application.Quit();
		}
	}
}
