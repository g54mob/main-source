using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Gh.Tk.Story.Structure;
using Gh.Tk.UI.Dialogs;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class MainMenu3DUIView : MonoBehaviour
	{
		public static class ViewId
		{
			public const string MainMenu = "mainMenu";

			public const string NewGame = "scenarios";

			public const string SaveGame = "save";

			public const string LoadGame = "load";

			public const string TrophyCase = "achievements";

			public const string CollectibleCards = "collectibleCards";

			public const string Credits = "credits";

			public const string GameSettings = "gameSettings";

			public const string PlayerProfile = "playerProfile";

			public const string Closed = "closed";

			public const string ShareCodePopup = "shareCodePopup";

			public const string Newsletter = "newsletter";

			public const string TavernSettings = "tavernSettings";
		}

		[SerializeField]
		private GameObject _subHeaderParent;

		[SerializeField]
		private Button3DUIView _backToMenuButton;

		[SerializeField]
		private List<GameObject> _subHeaders;

		[SerializeField]
		private GameObject _mainMenuFogParticles;

		[SerializeField]
		private Container3DUIView _mainMenuButtonsContainer;

		[SerializeField]
		private RelativeScaler3DUIView _buttonContainerBackerScaler;

		[SerializeField]
		private Button3DUIView _continueButton;

		[SerializeField]
		private Button3DUIView _quitButton;

		[SerializeField]
		private Button3DUIView _saveButton;

		public bool allowSaveInMainMenu;

		[SerializeField]
		private Button3DUIView _importShareCodeButton;

		[SerializeField]
		private Button3DUIView _gameSettingsButton;

		[SerializeField]
		private Button3DUIView _playerProfileButton;

		[SerializeField]
		private Button3DUIView _trophyCaseButton;

		[SerializeField]
		private Button3DUIView _handbookButton;

		[SerializeField]
		private Button3DUIView _creditsButton;

		[SerializeField]
		private Button3DUIView _cinematicButton;

		[SerializeField]
		private Button3DUIView _discordButton;

		[SerializeField]
		private Button3DUIView _greenheartButton;

		[SerializeField]
		private Button3DUIView _newsletterButton;

		[SerializeField]
		private Button3DUIView _wishlistButton;

		[SerializeField]
		private Button3DUIView _newButton;

		[SerializeField]
		private Button3DUIView _loadButton;

		[SerializeField]
		private Button3DUIView _previousTavernButton;

		[SerializeField]
		private Button3DUIView _nextTavernButton;

		[SerializeField]
		private TextMeshProI18n _tavernNameText;

		[SerializeField]
		private List<TavernMapMarker> _taverns;

		[SerializeField]
		private GameObject _newButtonParticleHint;

		private bool _closeToWorldMap;

		private bool _returnToPauseMenu;

		[SerializeField]
		private ShowHideAnimation3DUIView _mainMenuNavigation;

		[SerializeField]
		private ShowHideAnimation3DUIView _regionSelection;

		[SerializeField]
		private SaveGameCardList3DUIView _saveGameCardList;

		[SerializeField]
		private NewScenarioList3DUIView _newScenarioList;

		[SerializeField]
		private SaveGameDialog3DUIView _saveGameDialog;

		[SerializeField]
		private Button3DUIView _designWorkshopButton;

		private MainMenuMiniMap3DUIView _miniMap;

		private List<GameObject> _presetLinkedObjects;

		public Ease tavernTransitionMoveEase;

		public float tavernTransitionMoveDuration;

		public AnimationCurve tavernTransitionInEase;

		public float tavernTransitionInFadeTime;

		public AnimationCurve tavernTransitionOutEase;

		public float tavernTransitionOutFadeTime;

		[SerializeField]
		private GameObject _demoMenuPrefab;

		private DemoMenu3DUIView _demoMenu;

		private List<Action> _cleanUpActions;

		public List<DirectorsToolbar3DUIView.CameraPresetData> MenuCameraPresets;

		private bool _disabled;

		public string CurrentViewId { get; private set; }

		public string CurrentLevelId { get; private set; }

		public bool IsOpen { get; private set; }

		public bool IsFreeplayView { get; private set; }

		public static event EventHandler MenuViewChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void OnDialogOpening(object sender, EventArgs eventArgs)
		{
		}

		private void OnDialogOpened(object sender, EventArgs eventArgs)
		{
		}

		private void OnDialogClosed(object sender, EventArgs eventArgs)
		{
		}

		public void UpdatePlayerProfileButton()
		{
		}

		public void SelectTavern(string levelId, bool selectFreeplay = false)
		{
		}

		private void ChangeTavernSelection(bool forward)
		{
		}

		private void FocusDesignWorkshop()
		{
		}

		private void FocusOnTavern(string levelId)
		{
		}

		public void SetMenuView(string viewId)
		{
		}

		private void UpdateRegionSelectionState()
		{
		}

		private void CloseMenuView(string viewId)
		{
		}

		private void OpenSaveGameDialog()
		{
		}

		private void QuitGame()
		{
		}

		public void Open(string viewId = "mainMenu")
		{
		}

		public void OpenFromPauseMenu(string viewId)
		{
		}

		private string GetDefaultLevel()
		{
			return null;
		}

		[ContextMenu("Set Preset For Current Tavern")]
		private void SetPresetForCurrentTavern()
		{
		}

		private void RefreshTavernSelectorButtons()
		{
		}

		private void RefreshMenuState()
		{
		}

		private void UpdatePresetObjects()
		{
		}

		public void ShowTavernDetails(string levelId, bool selectFreeplay = false)
		{
		}

		private void SetTavernSelected(string levelId)
		{
		}

		private string GetCurrentTavernNameKey()
		{
			return null;
		}

		public void RefreshSaveGameUI()
		{
		}

		private IEnumerable<SaveLoadManager.SaveGameHeader> GetUnlockedSaveHeaders()
		{
			return null;
		}

		private IEnumerable<SaveLoadManager.SaveGameHeader> GetAllSaveHeaders()
		{
			return null;
		}

		private void UpdateGameStartButtons(IEnumerable<SaveLoadManager.SaveGameHeader> saveHeaders)
		{
		}

		private void UpdateButtonLayout()
		{
		}

		public void Close()
		{
		}

		private void ShowSubHeader(string id)
		{
		}

		private void HideSubHeader()
		{
		}

		private void ShowMenuButtons()
		{
		}

		private void HideMenuButtons()
		{
		}

		public void BackOrClose()
		{
		}

		public void Back()
		{
		}

		public void ShowTavernSettings(ScenarioStoryStartNode scenario)
		{
		}

		public void ShowTavernSettings(string levelId)
		{
		}

		private void ShowTavernSettingsInternal(string scenarioId, string scenarioName, string levelId, bool isFreeplay)
		{
		}
	}
}
