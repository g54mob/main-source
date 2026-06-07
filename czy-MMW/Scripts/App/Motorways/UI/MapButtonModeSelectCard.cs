using System;
using System.Collections;
using Client;
using Factory;
using Motorways.Audio;
using Motorways.Themes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.UI
{
	public class MapButtonModeSelectCard : MapButtonCard, ILocalized, IThemeComponent
	{
		[SerializeField]
		private LocalizedTextUI _bestScoreText;

		[SerializeField]
		private LocalizedTextUI _modeNameText;

		[SerializeField]
		private TouchButton _infoButton;

		[SerializeField]
		private TouchButton _normalButton;

		[SerializeField]
		private TouchButton _endlessButton;

		[SerializeField]
		private TouchButton _expertButton;

		[SerializeField]
		private TouchButton _creativeButton;

		[SerializeField]
		private LocalizedTextUI _header;

		[SerializeField]
		private LocalizedTextUI[] _currentModeText;

		[SerializeField]
		private ButtonGroup _buttonGroup;

		private IScope _scope;

		private VisualConstantsData _visualConstantsData;

		private MapButton _owningMapButton;

		private ActivePlayer _player;

		private MotorwaysThemeDatabase _themeDatabase;

		[SerializeField]
		private ThemedMaterialType _classicModeTextThemeColor = ThemedMaterialType.Dark;

		private Color _classicModeTextColor = Color.black;

		private static readonly int Disabled = Animator.StringToHash("Disabled");

		private static readonly int Normal = Animator.StringToHash("Normal");

		private static readonly int Lowlight = Animator.StringToHash("Lowlight");

		private static readonly int ShouldShowLockIcon = Animator.StringToHash("ShouldShowLockIcon");

		private static readonly int IconShownStateId = Animator.StringToHash("IconShown");

		private static readonly int Selected = Animator.StringToHash("Selected");

		public GameMode GameMode { get; private set; }

		public LocalizedTextUI BestScoreText => _bestScoreText;

		public TouchButton NormalButton => _normalButton;

		public TouchButton EndlessButton => _endlessButton;

		public TouchButton ExpertButton => _expertButton;

		public TouchButton CreativeButton => _creativeButton;

		public TouchButton InfoButton => _infoButton;

		public event Action onMoreModeInfoPressed;

		public event Action onModePressed;

		public event Action onExpertLockedPressed;

		public void Initialize(IScope scope, VisualConstantsData visualConstantsData, MapButton owningButton)
		{
			_scope = scope;
			_visualConstantsData = visualConstantsData;
			_owningMapButton = owningButton;
			_player = _scope.Get<ActivePlayer>();
			_themeDatabase = _scope.Get<MotorwaysThemeDatabase>();
			GameMode = _player.GetSelectedModeForMap(_owningMapButton.MapDefinition.mapName);
			if (GameMode == GameMode.Normal)
			{
				_infoButton.interactable = false;
				_infoButton.animator.SetTrigger(Disabled);
			}
			Theme theme = _themeDatabase.GetTheme() as Theme;
			_classicModeTextColor = theme.GetColor(_classicModeTextThemeColor);
			_buttonGroup.Initialize();
			UpdateModeStringsAndColors();
			UpdateButtonLockStatus(playAnimations: false);
			_header.SetStringId(scope, _owningMapButton.MapDefinition.mapName);
			LocaleDatabase localeDatabase = scope.Get<LocaleDatabase>();
			localeDatabase.AddLocalizedObject(this);
			HandleLocaleChanged(localeDatabase.CurrentLocale);
			StartCoroutine(UpdateButtonGroup());
		}

		private void OnDestroy()
		{
			_scope.Get<LocaleDatabase>().RemoveLocalizedObject(this);
		}

		public void SetGameMode(GameMode gameMode, bool hasInfoButton)
		{
			GameMode = gameMode;
			UpdateModeStringsAndColors();
			_infoButton.interactable = hasInfoButton;
			_infoButton.animator.SetTrigger(hasInfoButton ? Normal : Disabled);
			_player.SetSelectedGameMode(_owningMapButton.MapDefinition.mapName, gameMode);
		}

		public void OnNormalModeSelected()
		{
			SetGameMode(GameMode.Normal, hasInfoButton: false);
			this.onModePressed?.Invoke();
		}

		public void OnEndlessModeSelected()
		{
			SetGameMode(GameMode.Endless, hasInfoButton: true);
			this.onModePressed?.Invoke();
		}

		public void OnExpertModeSelected()
		{
			if (!_owningMapButton.MapDefinition.IsExpertModeUnlocked(_scope))
			{
				this.onExpertLockedPressed?.Invoke();
				UpdateModeStringsAndColors();
			}
			else
			{
				SetGameMode(GameMode.Expert, hasInfoButton: true);
				this.onModePressed?.Invoke();
			}
		}

		public void OnCreativeModeSelected()
		{
			SetGameMode(GameMode.Creative, hasInfoButton: true);
			this.onModePressed?.Invoke();
		}

		public void OnRegainedFocus()
		{
			GameMode selectedModeForMap = _player.GetSelectedModeForMap(_owningMapButton.MapDefinition.mapName);
			Animator component = _endlessButton.GetComponent<Animator>();
			Animator component2 = _normalButton.GetComponent<Animator>();
			Animator component3 = _expertButton.GetComponent<Animator>();
			Animator component4 = _creativeButton.GetComponent<Animator>();
			switch (selectedModeForMap)
			{
			case GameMode.Normal:
				component.ResetTrigger(Normal);
				component3.ResetTrigger(Normal);
				component4.ResetTrigger(Normal);
				component2.SetTrigger(Selected);
				component.SetTrigger(Lowlight);
				component3.SetTrigger(Lowlight);
				component4.SetTrigger(Lowlight);
				break;
			case GameMode.Endless:
				component2.ResetTrigger(Normal);
				component.ResetTrigger(Normal);
				component3.ResetTrigger(Normal);
				component4.ResetTrigger(Normal);
				component2.SetTrigger(Lowlight);
				component.SetTrigger(Selected);
				component3.SetTrigger(Lowlight);
				component4.SetTrigger(Lowlight);
				break;
			case GameMode.Expert:
				component2.ResetTrigger(Normal);
				component.ResetTrigger(Normal);
				component3.ResetTrigger(Normal);
				component4.ResetTrigger(Normal);
				component2.SetTrigger(Lowlight);
				component.SetTrigger(Lowlight);
				component3.SetTrigger(Selected);
				component4.SetTrigger(Lowlight);
				break;
			case GameMode.Creative:
				component2.ResetTrigger(Normal);
				component.ResetTrigger(Normal);
				component3.ResetTrigger(Normal);
				component4.ResetTrigger(Normal);
				component2.SetTrigger(Lowlight);
				component.SetTrigger(Lowlight);
				component3.SetTrigger(Lowlight);
				component4.SetTrigger(Selected);
				break;
			}
		}

		public void ResetToNormal()
		{
			SetGameMode(GameMode.Normal, hasInfoButton: false);
		}

		private void UpdateModeStringsAndColors()
		{
			if (_scope != null)
			{
				MotorwaysStringKey motorwaysStringKey = _scope.Get<MotorwaysStringKey>();
				switch (GameMode)
				{
				case GameMode.Normal:
					_buttonGroup.OnButtonClicked(NormalButton);
					motorwaysStringKey.InitWithStringId(StringId.Normal);
					_modeNameText.TextField.color = _classicModeTextColor;
					break;
				case GameMode.Endless:
					_buttonGroup.OnButtonClicked(EndlessButton);
					motorwaysStringKey.InitWithStringId(StringId.Endless);
					_modeNameText.TextField.color = _visualConstantsData.EndlessTabButtonColor;
					break;
				case GameMode.Expert:
					_buttonGroup.OnButtonClicked(ExpertButton);
					motorwaysStringKey.InitWithStringId(StringId.Expert);
					_modeNameText.TextField.color = _visualConstantsData.ExpertTabButtonColor;
					break;
				case GameMode.Creative:
					_buttonGroup.OnButtonClicked(CreativeButton);
					motorwaysStringKey.InitWithStringId(StringId.Creative);
					_modeNameText.TextField.color = _visualConstantsData.CreativeTabButtonColor;
					break;
				}
				_modeNameText.LocString = StandaloneLocString.CreateString(_scope, motorwaysStringKey);
			}
		}

		public void OnInfoButtonPressed()
		{
			this.onMoreModeInfoPressed?.Invoke();
		}

		public void UpdateButtonLockStatus()
		{
			UpdateButtonLockStatus(playAnimations: true);
		}

		private IEnumerator UpdateButtonGroup()
		{
			yield return new WaitForEndOfFrame();
			_buttonGroup.OnButtonClicked(_buttonGroup.activeButton);
		}

		public void UpdateButtonLockStatus(bool playAnimations)
		{
			bool flag = !_scope.Get<ActivePlayer>().HasSeenNewContent(GetUnlockAnimationNciID(_owningMapButton.MapDefinition)) || !_owningMapButton.MapDefinition.IsExpertModeUnlocked(_scope);
			if (FeatureToggle.IsFeatureDisabled(Feature.MapUnlocks))
			{
				flag = false;
			}
			if (playAnimations && flag && _owningMapButton.MapDefinition.IsExpertModeUnlocked(_scope) && _owningMapButton.Type == MapButton.MapButtonType.City)
			{
				PlayExpertUnlockAnimation();
			}
			else
			{
				_expertButton.animator.SetBool(ShouldShowLockIcon, flag);
				if (flag)
				{
					_expertButton.animator.Play(IconShownStateId, 1);
					_expertButton.animator.Update(0f);
				}
			}
			if (GameMode == GameMode.Normal)
			{
				_infoButton.animator.Play(Disabled, -1, 1f);
			}
		}

		public static string GetUnlockAnimationNciID(MapDefinition mapDefinition)
		{
			return "ExpertUnlockAnimation-" + mapDefinition.cityName.ToLower();
		}

		public static string GetNewContentIndicatorID(MapDefinition mapDefinition)
		{
			return "ExpertModeUnlock-" + mapDefinition.cityName.ToLower();
		}

		private void PlayExpertUnlockAnimation()
		{
			_scope.Get<AudioSystem>().ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.UnlockMap));
			_scope.Get<ActivePlayer>().SetNewContentSeen(GetUnlockAnimationNciID(_owningMapButton.MapDefinition));
			_scope.Get<ActivePlayer>().SetNewContentSeen(GetNewContentIndicatorID(_owningMapButton.MapDefinition));
			_expertButton.animator.SetBool(ShouldShowLockIcon, value: false);
		}

		public override void SetVisible(bool isVisible)
		{
			base.SetVisible(isVisible);
			UpdateModeStringsAndColors();
			UpdateButtonLockStatus(playAnimations: false);
		}

		public override void SetSelected(bool isSelected)
		{
			base.SetSelected(isSelected);
			UpdateButtonLockStatus(playAnimations: false);
		}

		public void HandleLocaleChanged(Locale newLocale)
		{
			if (_currentModeText != null && _currentModeText.Length == 2)
			{
				bool flag = newLocale.TextDirection == TextDirection.LeftToRight;
				int siblingIndex = ((!flag) ? 1 : 0);
				_currentModeText[0].transform.SetSiblingIndex(siblingIndex);
				_currentModeText[0].TextField.horizontalAlignment = ((!flag) ? HorizontalAlignmentOptions.Left : HorizontalAlignmentOptions.Right);
				_currentModeText[1].TextField.horizontalAlignment = (flag ? HorizontalAlignmentOptions.Left : HorizontalAlignmentOptions.Right);
			}
		}

		public void InitializeTheme(IThemeDatabase themeDatabase)
		{
			UpdateModeStringsAndColors();
		}

		public void ApplyTheme(ITheme newTheme)
		{
			Theme theme = (Theme)newTheme;
			_classicModeTextColor = theme.GetColor(_classicModeTextThemeColor);
			UpdateModeStringsAndColors();
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			Color color = (oldTheme as Theme).GetColor(_classicModeTextThemeColor);
			Color color2 = (newTheme as Theme).GetColor(_classicModeTextThemeColor);
			_classicModeTextColor = Color.Lerp(color, color2, progress);
			UpdateModeStringsAndColors();
			if (!(color == color2))
			{
				return ThemeBlendingResult.ContinueBlending;
			}
			return ThemeBlendingResult.StopBlending;
		}

		public void ReleaseTheme(IThemeDatabase themeDatabase)
		{
		}
	}
}
