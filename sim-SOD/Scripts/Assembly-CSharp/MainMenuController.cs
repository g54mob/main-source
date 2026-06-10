using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AeLa.EasyFeedback;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
	[Serializable]
	public class MenuComponent
	{
		public Component component;

		public RectTransform rect;

		public int xPhase;

		public Vector2 onscreenAnchoredPosition;

		public List<ButtonController> buttons;

		public ButtonController previouslySelected;

		public bool skipMotion;
	}

	public enum Component
	{
		none = 0,
		mainMenuButtons = 1,
		settings = 2,
		newGameSelect = 3,
		city = 4,
		citySelect = 5,
		generateCity = 6,
		charSetup = 7,
		interfaceSettings = 8,
		graphicsSettings = 9,
		audioSettings = 10,
		gameplaySettings = 11,
		controlSettings = 12,
		devSettings = 13,
		saveGame = 14,
		loadGame = 15,
		credits = 16,
		loadingCity = 17,
		splash = 18,
		controlDetect = 19,
		streamingSettings = 20,
		bugReport = 21,
		mods = 22,
		gameplayModifiers = 23,
		controlBindings = 24
	}

	[Serializable]
	public class LoadingTip
	{
		public string dictRef;

		public Sprite image;
	}

	[CompilerGenerated]
	private sealed class _003CFadeMenu_003Ed__137 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MainMenuController _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CFadeMenu_003Ed__137(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CMenuMotion_003Ed__144 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MainMenuController _003C_003E4__this;

		public bool skipMotion;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CMenuMotion_003Ed__144(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	private struct _003CStartSaveAsync_003Ed__183 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public MainMenuController _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[Header("Background")]
	public RectTransform mainMenuContainer;

	public Image backgroundImage;

	public Image logoImage;

	public TextMeshProUGUI buildText;

	public GameObject buildNameObject;

	public float time;

	[Header("Components")]
	public Component previousComponent;

	public MenuComponent currentComponent;

	public float componentMotion;

	public FeedbackForm feedbackForm;

	public FormField feedbackPlayerInfo;

	public bool saveDof;

	public TextMeshProUGUI betaMessageText;

	public GraphicRaycaster raycaster;

	public bool askedStreamerQuestion;

	public bool acceptedEULA;

	[ReorderableList]
	public List<MenuComponent> components;

	[Header("Tips")]
	public string loadingTipsDDSTree;

	[ReorderableList]
	public List<LoadingTip> loadingTips;

	public float nextTipTimer;

	[Header("Dropdowns")]
	public DropdownController languageDropdown;

	public DropdownController resolutionsDropdown;

	public DropdownController fullScreenModeDropdown;

	public DropdownController startTimeDropdown;

	public DropdownController gameDifficultyDropdown;

	public DropdownController gameDifficultyDropdown2;

	public DropdownController gameLengthDropdown;

	public DropdownController selectCityDropdown;

	public DropdownController playerGenderDropdown;

	public DropdownController partnerGenderDropdown;

	public DropdownController citySizeDropdown;

	public DropdownController cityPopDropdown;

	public DropdownController statusEffectsDropdown;

	public DropdownController aaModeDropdown;

	public DropdownController aaQualityDropdown;

	public DropdownController dlssModeDropdown;

	public DropdownController hyperacusisDropdown;

	public DropdownController bassReductionDropdown;

	public List<ToggleController> statusEffectToggles;

	[Header("Main Menu")]
	public ButtonController saveGameButton;

	public ButtonController loadGameButton;

	public ButtonController sandboxGameButton;

	public ButtonController cityGenButton;

	public ButtonController resumeGameButton;

	public ButtonController helpButton;

	public ButtonController bugReportButton;

	public ButtonController modsButton;

	[Header("City Setup Menu")]
	public TextMeshProUGUI selectedCityShareCode;

	public TextMeshProUGUI selectedCityDetailsText;

	public ButtonController selectedCityContinueButton;

	[NonSerialized]
	public CityInfoData selectedCityInfoData;

	public ButtonController selectedCityCopyShareCodeButton;

	public ButtonController deleteCityButton;

	private List<FileInfo> cityMapFiles;

	private List<FileInfo> cityInfoFiles;

	private Dictionary<string, CityInfoData> cityInfoDict;

	[Header("Dev Controls")]
	public ButtonController developerOptionsButton;

	public Slider windSlider;

	public Slider rainSlider;

	public Slider lightningSlider;

	public Slider snowSlider;

	public Slider fogSlider;

	public Button setWeatherButton;

	public ToggleController allowLicensedMusicToggle;

	[Header("New Character")]
	public ButtonController playerNameButton;

	public MultiSelectController playerSkinToneSelect;

	[Header("Gameplay Modifiers Panel")]
	public ToggleController mousedOverModifier;

	public TMP_Text modifiersHeader;

	public TMP_Text modifiersDescription;

	[Header("City Generation")]
	public TextMeshProUGUI shareCodeText;

	public ButtonController pasteShareCodeButton;

	public ButtonController changeCityNameButton;

	public TextMeshProUGUI generationWarningText;

	[Header("Credits")]
	public TextMeshProUGUI creditsText;

	public RectTransform creditsPageContent;

	[Header("Main Menu")]
	public TextMeshProUGUI mouseOverText;

	public bool mainMenuActive;

	[Header("Language")]
	public string loadedLanguage;

	[Header("Loading Bar")]
	public TextMeshProUGUI loadingText;

	public Slider loadingSlider;

	public TextMeshProUGUI tipText;

	public Image tipImg;

	[Header("Menu Fading")]
	public CanvasRenderer fadeOverlay;

	public float desiredFade;

	public float fade;

	private bool exitMainMenuAfterFade;

	[Header("Save/Load Game")]
	public RectTransform loadGameContentRect;

	public RectTransform saveGameContentRect;

	public GameObject saveGameEntryPrefab;

	private List<SaveGameEntryController> spawnedSaveGames;

	private List<SaveGameEntryController> spawnedLoadGames;

	public SaveGameEntryController selectedSave;

	public ButtonController saveButton;

	public ButtonController loadButton;

	public ButtonController deleteButton;

	public ButtonController deleteButton2;

	public SaveGameEntryController newSaveGameEntry;

	public TextMeshProUGUI selectedSaveText1;

	public TextMeshProUGUI selectedSaveText2;

	[Header("Bug Report (New)")]
	public DropdownController bugSaveDropdown;

	public DropdownController priorityDropdown;

	public DropdownController categoryDropdown;

	public ButtonController bugNameInput;

	public ButtonController bugDetailsInput;

	public ToggleController sendScreenshotToggle;

	public ToggleController sendSystemSpecsToggle;

	public ToggleController sendPrevLogToggle;

	public float bugReportTimer;

	[Space(7f)]
	public TMP_Dropdown ffPriority;

	public TMP_Dropdown ffCategory;

	public TMP_InputField ffNameInput;

	public TMP_InputField ffDescriptionInput;

	public FormField ffSystemInfo;

	public FormElement ffPrevLogCollector;

	[Header("Special Cases")]
	public List<DropdownController> disableWithDynamicResolution;

	public List<DropdownController> enableWithDynamicResolution;

	public List<ButtonController> activeBackButtons;

	public bool gameHasBeenSaved;

	public bool exitPrompt;

	[Header("Animation")]
	public CanvasRenderer topBarRend;

	public CanvasRenderer bottomBarRend;

	public TextMeshProUGUI titleText;

	public AnimationCurve titleTextKerningAnimation;

	private static MainMenuController _instance;

	public static MainMenuController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	public void LoadDropdownContent()
	{
	}

	public void OnNewMouseOver()
	{
	}

	public void EnableMainMenu(bool val, bool useFade = false, bool exitMain = false, Component menuPhase = Component.mainMenuButtons)
	{
	}

	public void SelectHighestRankedActiveButton(bool prioritisePreviouslySelected = true)
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CFadeMenu_003Ed__137))]
	private IEnumerator FadeMenu()
	{
		return null;
	}

	public void SetMenuComponent(int newComponent)
	{
	}

	public void SetMenuComponent(Component newComponent)
	{
	}

	public void SetToStreamerMode()
	{
	}

	public void CancelStreamerMode()
	{
	}

	public void AcceptEULA()
	{
	}

	public void DeclineEULA()
	{
	}

	[IteratorStateMachine(typeof(_003CMenuMotion_003Ed__144))]
	private IEnumerator MenuMotion(bool skipMotion)
	{
		return null;
	}

	public bool IsSaveGameAllowed()
	{
		return false;
	}

	public void OnMenuComponentSwitchComplete()
	{
	}

	public void ResetBackButtonControllerIcons()
	{
	}

	public void SelectCityButton()
	{
	}

	private void RefreshMapDropdown()
	{
	}

	public void OnNewCitySelected()
	{
	}

	public void LoadCityInfo(FileInfo fileInfo)
	{
	}

	public void SelectGenNewCity()
	{
	}

	public void RandomCityName()
	{
	}

	public void PasteShareCode()
	{
	}

	private void ParseShareCode(string newCode)
	{
	}

	public void CopyShareCodeGenerate()
	{
	}

	public void CustomShareCodeButton()
	{
	}

	public void OnChangeShareCodePopupCancel()
	{
	}

	public void OnChangeShareCodePopupConfirm()
	{
	}

	public void OnGenerateNewSeed()
	{
	}

	public void OnChangeCityNameButton()
	{
	}

	public void OnChangeCityNamePopupCancel()
	{
	}

	public void OnChangeCityNamePopupConfirm()
	{
	}

	public void OnChangeCityGenerationOption()
	{
	}

	public void NewCharacter()
	{
	}

	public void SetPlayerName(string newName)
	{
	}

	public void RandomPlayerName(bool surnameOnly = false)
	{
	}

	public void OnChangeNameButton()
	{
	}

	public void OnChangeNamePopupCancel()
	{
	}

	public void OnChangeNamePopupConfirm()
	{
	}

	public void OnPlayerNameChanged()
	{
	}

	public void OnPlayerGenderChange()
	{
	}

	public void OnPartnerGenderChange()
	{
	}

	public void RandomPlayerGender()
	{
	}

	public void RandomPartnerGender()
	{
	}

	public void RandomSkinTone()
	{
	}

	public void OnSkinToneChange()
	{
	}

	public void SaveGame()
	{
	}

	public void LoadGame()
	{
	}

	public void OnSaveButton()
	{
	}

	public void CancelOverwriteSave()
	{
	}

	public void OverwriteSave()
	{
	}

	[AsyncStateMachine(typeof(_003CStartSaveAsync_003Ed__183))]
	public void StartSaveAsync()
	{
	}

	private void SaveCompleteMessage()
	{
	}

	public void OnDeleteSaveButton()
	{
	}

	public void CancelDeleteSave()
	{
	}

	public void DeleteSave()
	{
	}

	public void DeleteCurrentSaveGame()
	{
	}

	public void RefreshSaveEntries()
	{
	}

	public void SelectNewSave(SaveGameEntryController sec)
	{
	}

	public void DeleteCityButton()
	{
	}

	public void CancelDeleteCity()
	{
	}

	public void DeleteCity()
	{
	}

	public void ExitGame()
	{
	}

	public void SaveOnExitYes()
	{
	}

	public void SaveOnExitNo()
	{
	}

	public void SaveOnExitCancel()
	{
	}

	public void ResumeGame()
	{
	}

	public void Help()
	{
	}

	public void BugReport()
	{
	}

	public void FeedbackForm()
	{
	}

	public void OnFeedbackFormClosed()
	{
	}

	public void OnOpenBugReport()
	{
	}

	public void OnCloseBugReport()
	{
	}

	public void SumbitBugReport()
	{
	}

	public void RefreshSaveGameDropdown()
	{
	}

	public void ResetBugReportDetails()
	{
	}

	public void OnChangeBugNameButton()
	{
	}

	public void OnChangeBugNameCancel()
	{
	}

	public void OnChangeBugNameConfirm()
	{
	}

	public void OnChangeBugDetailsButton()
	{
	}

	public void OnChangeBugDetailsCancel()
	{
	}

	public void OnChangeBugDetailsConfirm()
	{
	}

	public void PlayButtonClick()
	{
	}

	public void PlayForwardButtonClick()
	{
	}

	public void PlayBackButtonClick()
	{
	}

	public void PlayTickbox()
	{
	}

	public void OnLanguageChange()
	{
	}

	private void LangRestartGame()
	{
	}

	private void LangCancelRestartGame()
	{
	}

	public void OnChangeResolution()
	{
	}

	public void LowResolutionTextScalingCheck()
	{
	}

	public void CopyShareCodeToClipboard()
	{
	}

	public void NewGameTypeButton(bool sandbox)
	{
	}

	public void PreviousMenu()
	{
	}

	public void LoadTip()
	{
	}

	public void ShadowsWebsiteLink()
	{
	}

	public void OnEffectStatusChange()
	{
	}

	public void SetStatusEffectOptionsAccordingToDropdown()
	{
	}

	public void SetDropdownAccordingToStatusEffects()
	{
	}

	public void ResetControls()
	{
	}

	public void OnOpenModMenu()
	{
	}

	public void OnContinueCityGeneration()
	{
	}

	public void ConfirmCityGeneration()
	{
	}

	public void RejectCityGeneration()
	{
	}

	public void CleanOrphanPhotoCacheFiles()
	{
	}

	public static void DeletePhotoCache(string target_dir)
	{
	}
}
