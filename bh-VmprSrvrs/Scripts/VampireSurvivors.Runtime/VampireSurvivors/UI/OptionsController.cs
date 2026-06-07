using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class OptionsController : MonoBehaviour
	{
		public enum OptionsTabType
		{
			QUICKACCESS = 0,
			DISPLAY = 1,
			SOUND = 2,
			GAMEPLAY = 3,
			USER = 4,
			ABOUT = 5,
			INGAME = 6,
			CHEATS = 7,
			MULTIPLAYER = 8
		}

		[CompilerGenerated]
		private sealed class _003CWaitAndFormatWidth_003Ed__65 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OptionsController _003C_003E4__this;

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
			public _003CWaitAndFormatWidth_003Ed__65(int _003C_003E1__state)
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
		private sealed class _003CWaitAndReselect_003Ed__153 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OptionsController _003C_003E4__this;

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
			public _003CWaitAndReselect_003Ed__153(int _003C_003E1__state)
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

		[SerializeField]
		private List<OptionsTabType> _OptionsConfig;

		[SerializeField]
		private Selectable OnUp;

		[SerializeField]
		private Selectable OnDown;

		[SerializeField]
		private Selectable Quit;

		[SerializeField]
		private TextMeshProUGUI _Title;

		[SerializeField]
		private RectTransform _TabContainer;

		[SerializeField]
		private RectTransform _DisplayPanel;

		[SerializeField]
		private GameObject _TabPrefab;

		[SerializeField]
		private RectTransform _Content;

		[SerializeField]
		private GameObject _TickboxPrefab;

		[SerializeField]
		private GameObject _SliderPrefab;

		[SerializeField]
		private GameObject _ButtonPrefab;

		[SerializeField]
		private GameObject _MultipleChoicePrefab;

		[SerializeField]
		private GameObject _DropdownPrefab;

		[SerializeField]
		private GameObject _DropdownImagesPrefab;

		[SerializeField]
		private GameObject _InputPrefab;

		[SerializeField]
		private GameObject _LabelPrefab;

		[SerializeField]
		private CoopConfig _CoopConfig;

		private List<IUIObject> _spawnedUnselectables;

		private List<ISelectableUI> _spawnedElements;

		private List<GameObject> _spawnedTabs;

		private ScrollEnhancer _scroller;

		private SignalBus _signalBus;

		private PlayerOptions _playerOptions;

		private AdventureManager _adventureManager;

		private CheatsController _cheatsController;

		private Resolution? _selectedResolution;

		private List<string> _resolutionStrings;

		private int _selectedRefreshRate;

		private FullScreenMode _selectedWindowMode;

		private bool _vSyncEnabled;

		private int _selectedFrameRate;

		private AchievementManager _achievementManager;

		private MultiplayerManager _multiplayer;

		private LabeledInputUI _twitchChannelNameInput;

		private LabeledButtonUI _twitchConnectButton;

		private LabeledButtonUI _twitchDisconnectButton;

		private OptionsTabType? _currentTabType;

		private CustomDropDown _screenResolutionDropdown;

		private CustomDropDown _refreshRateDropdown;

		private SliderUI _frameRateSlider;

		private TickBoxUI _vSyncTickBox;

		private LabeledButtonUI _applyGraphicsButton;

		private List<Resolution> _resolutions;

		private List<Resolution> _currentRefreshRateResolutions;

		private ScreenOrientation _currentScreenOrientation;

		private int _deleteSaveClicks;

		private int _loadSavegameClicks;

		private bool _shouldDeleteAdventureData;

		private static uint[] optionColours;

		[Inject]
		private void Construct(SignalBus signalBus, PlayerOptions player, CheatsController cheats, AchievementManager achievementManager, MultiplayerManager multi, AdventureManager adventureManager)
		{
		}

		public void Initialize()
		{
		}

		private void AddTabs()
		{
		}

		private Sprite GetTabSprite(OptionsTabType t)
		{
			return null;
		}

		private string GetTabName(OptionsTabType t)
		{
			return null;
		}

		private void SelectTab(OptionsTabType type)
		{
		}

		private void ClearPage()
		{
		}

		public GameObject GetFirstTab()
		{
			return null;
		}

		public GameObject GetFirstElement()
		{
			return null;
		}

		public Selectable GetFirstSelectable()
		{
			return null;
		}

		public Selectable GetLastSelectable()
		{
			return null;
		}

		public void ClearAll()
		{
		}

		public void RefreshTab(OptionsTabType type)
		{
		}

		private void BuildPage(OptionsTabType type)
		{
		}

		private void GenerateNavigation()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndFormatWidth_003Ed__65))]
		private IEnumerator WaitAndFormatWidth()
		{
			return null;
		}

		public void SetUpNavigation(Selectable sel)
		{
		}

		public void SetDownNavigation(Selectable sel)
		{
		}

		public void SetQuit(Selectable sel)
		{
		}

		private void AddFlashingVfxTickBox()
		{
		}

		private void BuildQuickAccessPage()
		{
		}

		private void BuildIngamePage()
		{
		}

		private void BuildDisplayPage()
		{
		}

		private void BuildSoundPage()
		{
		}

		private void BuildGameplayPage()
		{
		}

		private void BuildUserPage()
		{
		}

		private void BuildAboutPage()
		{
		}

		private void BuildCheatsPage()
		{
		}

		private List<Color> ColourDropdownValues()
		{
			return null;
		}

		private void BuildMultiplayerPage()
		{
		}

		private void AddLanguageButton()
		{
		}

		private void AddVisuallyInvertStages()
		{
		}

		private void AddDisableMovingBackground()
		{
		}

		private void AddFullScreen()
		{
		}

		private void AddJoystickTypes()
		{
		}

		private void AddOrientations()
		{
		}

		private int GetResolutionIndex(int screenWidth, int screenHeight)
		{
			return 0;
		}

		private void AddResolutions()
		{
		}

		private void HandleRefreshRateDropdown()
		{
		}

		private void AddFrameRateSlider()
		{
		}

		private void AddBorderTypes()
		{
		}

		private void AddWindowTypes()
		{
		}

		private void AddVisibleJoysticks()
		{
		}

		private void AddSoundEffectTypes()
		{
		}

		public LabeledInputUI AddLabeledInput(string labelText, string defaultValue = "", string placeholder = "", bool textIsLocalizationTerm = true)
		{
			return null;
		}

		private SliderUI AddSlider(string text, float defaultValue, Action<float> valueChangeCallback, bool textIsLocalizationTerm = true, float minValue = 0f, float maxValue = 1f)
		{
			return null;
		}

		private SliderUI AddSliderInteger(string text, int defaultValue, Action<int> valueChangeCallback, bool textIsLocalizationTerm = true, int minValue = 0, int maxValue = 100)
		{
			return null;
		}

		private CustomDropDown AddDropDown(string text, List<string> options, int selectedIndex, Action<int> callbackWithNewSelectedIndex, int howManyOptionsToShowAtOnce = 4, bool textIsLocalizationTerm = true)
		{
			return null;
		}

		private void RegenerateDropdownOptions(CustomDropDown customDropDown, List<string> options, int selectedIndex, bool textIsLocalizationTerm = true)
		{
		}

		private void AddColourDropDown(string text, List<Color> options, int selectedIndex, Action<int> callbackWithNewSelectedIndex, int howManyOptionsToShowAtOnce = 4, bool textIsLocalizationTerm = true)
		{
		}

		private TickBoxUI AddTickBox(string text, bool defaultValue, Action<bool> valueChangeCallback, bool textIsLocalizationTerm = true)
		{
			return null;
		}

		public LabeledButtonUI AddLabeledButton(string labelText, string buttonText, Action callback, bool textIsLocalizationTerm = true)
		{
			return null;
		}

		public void AddLabel(string labelText)
		{
		}

		private void AddMultipleChoice(string labelText, List<string> buttonLabels, List<Action> callbacks, int selectedIndex, bool textIsLocalizedTerm = true)
		{
		}

		private string Translate(string term)
		{
			return null;
		}

		public void ToggleVisualInvert(bool b)
		{
		}

		public void SetJoystickDefault()
		{
		}

		public void SetJoystickLegacy()
		{
		}

		private void SetOrientation(int index)
		{
		}

		public void ApplySelectedOrientation()
		{
		}

		private void SetMusic(float f)
		{
		}

		private void SetSounds(float f)
		{
		}

		private void SetClassicMusic()
		{
		}

		private void SetBlastProcessedMusic()
		{
		}

		public void FlashingVFX(bool b)
		{
		}

		public void DisableBlood(bool b)
		{
		}

		private void ScreenShake(bool value)
		{
		}

		private void PixelFont(bool value)
		{
		}

		private void DisplayDefangedEnemies(bool value)
		{
		}

		private void StageLighting(bool value)
		{
		}

		public void VisibleJoystick(bool b)
		{
		}

		public void DamageNumbers(bool b)
		{
		}

		public void GlimmerCarousel(bool b)
		{
		}

		public void SetFullscreen(bool b)
		{
		}

		public void ToggleMovingBackground(bool b)
		{
		}

		public void ToggleStageProgression(bool b)
		{
		}

		public void ToggleControllerVibration(bool value)
		{
		}

		public void ToggleAssignControllerToPlayer1(bool value)
		{
		}

		public void TogglePopupsShouldFollowPriority(bool value)
		{
		}

		public void ToggleShowPlayerIndicators(bool value)
		{
		}

		public void TogglePermanentCoopOutlines(bool value)
		{
		}

		public void ToggleTintUISelection(bool value)
		{
		}

		public void SetPlayerColourIndex(int playerIndex, int index)
		{
		}

		public void SetCoopChestMode(bool value)
		{
		}

		public void ToggleHideDebugUI(bool value)
		{
		}

		public void ToggleHideGameUI(bool value)
		{
		}

		public void ViewPonclePrivacyPolicy()
		{
		}

		public void OpenLanguagesPage()
		{
		}

		public void SetResolution(int i)
		{
		}

		public void SetRefreshRate(int i)
		{
		}

		private void SetTargetFrameRate(int targetFrameRate)
		{
		}

		public void SetBorderType(int i)
		{
		}

		public void SetWindowMode(int i)
		{
		}

		private void UpdateRefreshRateDropdownVisibility(bool forceShow = false)
		{
		}

		public void SetVsyncEnabled(bool value)
		{
		}

		public void ApplyGraphicsSettings()
		{
		}

		public void RestoreBackup()
		{
		}

		public void RecoverOldData()
		{
		}

		public void ShowDLCSelector()
		{
		}

		private void ShowDeleteAdventureDataPopup(Action onComplete)
		{
		}

		public void DeleteSave()
		{
		}

		private void ActuallyDeleteSave()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndReselect_003Ed__153))]
		private IEnumerator WaitAndReselect()
		{
			return null;
		}

		private void HideAdsButtons(bool b)
		{
		}

		private void OnTwitchConnectButtonPressed()
		{
		}

		private void OnTwitchDisconnectButtonPressed()
		{
		}

		private void UpdateTwitchButtonStates(bool updateSelection = false)
		{
		}

		private void UpdateTwitchButtonNavigation(bool isTwitchConfigured)
		{
		}
	}
}
