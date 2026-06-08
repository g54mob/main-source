using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dorfromantik.UI.MainMenu
{
	public class UiGameModeContainer : MonoBehaviour
	{
		[SerializeField]
		private List<GameMode> gameModes;

		[SerializeField]
		private MainMenuUi mainMenuUi;

		[SerializeField]
		private SaveGameLoadingInitiator saveGameLoadingInitiator;

		[SerializeField]
		internal GameMode activeGameMode;

		[SerializeField]
		internal UiGameModeIcon activeGameModeIcon;

		private List<UiGameModeIcon> gameModeIcons;

		private Dictionary<GameModeId, GameMode> gameModeById;

		private void Awake()
		{
			gameModeById = new Dictionary<GameModeId, GameMode>();
			foreach (GameMode gameMode in gameModes)
			{
				gameModeById.Add(gameMode.id, gameMode);
			}
			gameModeIcons = new List<UiGameModeIcon>();
			gameModeIcons = Enumerable.ToList(GetComponentsInChildren<UiGameModeIcon>());
		}

		private void OnEnable()
		{
			if ((bool)OverwritingSingleton<GameSession>.Instance)
			{
				SelectGameMode((OverwritingSingleton<GameSession>.Instance.GameMode.id == GameModeId.Tutorial) ? gameModeById[GameModeId.Classic] : OverwritingSingleton<GameSession>.Instance.GameMode);
			}
		}

		public void SelectGameMode(GameMode gameMode)
		{
			activeGameMode = gameMode;
			if (Enumerable.Count(gameModeIcons, (UiGameModeIcon x) => x.gameMode == activeGameMode) > 0)
			{
				activeGameModeIcon = Enumerable.Single(gameModeIcons, (UiGameModeIcon x) => x.gameMode == activeGameMode);
			}
			else
			{
				activeGameModeIcon = null;
			}
			saveGameLoadingInitiator.SetSelectedGameMode(activeGameMode);
			if (mainMenuUi.ActiveScreen != activeGameMode.screenType)
			{
				mainMenuUi.SwitchToScreen(activeGameMode.screenType);
			}
			foreach (UiGameModeIcon gameModeIcon in gameModeIcons)
			{
				gameModeIcon.SetVisualState(UiVisualState.Default);
			}
			if ((bool)activeGameModeIcon)
			{
				activeGameModeIcon.SetVisualState(UiVisualState.Active);
			}
		}

		internal void SetVisibilityForContentContainers(UiGameModeIcon gameModeIcon, bool shouldBeVisible)
		{
			foreach (UiGameModeIcon gameModeIcon2 in gameModeIcons)
			{
				if (gameModeIcon2 == gameModeIcon)
				{
					gameModeIcon2.SetContentContainerVisible(shouldBeVisible);
					if (shouldBeVisible)
					{
						activeGameModeIcon = gameModeIcon;
					}
				}
				else
				{
					gameModeIcon2.SetContentContainerVisible(!shouldBeVisible);
				}
			}
		}

		private bool _003CSelectGameMode_003Eb__9_0(UiGameModeIcon x)
		{
			return x.gameMode == activeGameMode;
		}

		private bool _003CSelectGameMode_003Eb__9_1(UiGameModeIcon x)
		{
			return x.gameMode == activeGameMode;
		}
	}
}
