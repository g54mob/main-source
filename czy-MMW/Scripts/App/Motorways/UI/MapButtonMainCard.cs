using System;
using Client;
using Factory;
using JetBrains.Annotations;
using Motorways.Themes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.UI
{
	public class MapButtonMainCard : MapButtonCard, ILocalized, IThemeComponent
	{
		[SerializeField]
		private LocalizedTextUI header;

		[SerializeField]
		private LocalizedTextUI description;

		[SerializeField]
		private LocalizedTextUI bestScoreText;

		[SerializeField]
		private LocalizedTextUI currentModeText;

		[SerializeField]
		private LocalizedTextUI timeLeftText;

		[SerializeField]
		private Image previewImage;

		[SerializeField]
		private ThemeSelectButton colorfulSelect;

		[SerializeField]
		private ThemeSelectButton darkSelect;

		[SerializeField]
		private ThemeSelectButton mapsSelect;

		[SerializeField]
		private TouchButton moreInfoButton;

		[SerializeField]
		private ChallengeIcon[] challengeIcons;

		[SerializeField]
		private TouchButton _challengeButtonSet;

		[SerializeField]
		private DelegateCanvasGroup _moreInfoButtonCanvas;

		[SerializeField]
		private HorizontalLayoutGroup _modeTextHorizontalLayoutGroup;

		[SerializeField]
		private LocalizedTextUI[] _currentModeText;

		[SerializeField]
		[Header("Map Type Icon Settings")]
		private Image _mapTypeIcon;

		[SerializeField]
		private Image _mapTypeTrainSprite;

		[SerializeField]
		private Image _mapTypeBoatSprite;

		[SerializeField]
		private Image _shadowWithMapTypeIcon;

		[SerializeField]
		private Image _shadowWithoutMapTypeIcon;

		[Space(20f)]
		[SerializeField]
		private ThemedMaterialType _classicModeTextThemeColor = ThemedMaterialType.Dark;

		private bool _showMoreInfoButton;

		private IScope _scope;

		private VisualConstantsData _visualConstantsData;

		private ActivePlayer _player;

		private MotorwaysThemeDatabase _themeDatabase;

		private Color _classicModeTextColor = Color.black;

		private const int ModeTextEndlessPadding = 30;

		public LocalizedTextUI Header => header;

		public LocalizedTextUI Description => description;

		public LocalizedTextUI BestScoreText => bestScoreText;

		public LocalizedTextUI CurrentModeText => currentModeText;

		public LocalizedTextUI TimeLeftText => timeLeftText;

		public Image PreviewImage => previewImage;

		public ThemeSelectButton ColorfulSelect => colorfulSelect;

		public ThemeSelectButton DarkSelect => darkSelect;

		public ThemeSelectButton MapsSelect => mapsSelect;

		public TouchButton MoreInfoButton => moreInfoButton;

		public TouchButton ChallengeButtonSet => _challengeButtonSet;

		public MapButton parentMapButton { get; set; }

		public event Action onMoreChallengeInfoPressed;

		public void Initialize(IScope scope, VisualConstantsData visualConstantsData)
		{
			_scope = scope;
			_visualConstantsData = visualConstantsData;
			_player = _scope.Get<ActivePlayer>();
			_themeDatabase = _scope.Get<MotorwaysThemeDatabase>();
			Theme theme = _themeDatabase.GetTheme() as Theme;
			_classicModeTextColor = theme.GetColor(_classicModeTextThemeColor);
			GameMode selectedModeForMap = _player.GetSelectedModeForMap(parentMapButton.MapDefinition.mapName);
			UpdateModeStrings(selectedModeForMap);
			LocaleDatabase localeDatabase = scope.Get<LocaleDatabase>();
			localeDatabase.AddLocalizedObject(this);
			HandleLocaleChanged(localeDatabase.CurrentLocale);
		}

		public void SetMapType(bool isTrainMap, bool isBoatMap)
		{
			_mapTypeIcon.gameObject.SetActive(isTrainMap || isBoatMap);
			_mapTypeTrainSprite.gameObject.SetActive(isTrainMap);
			_mapTypeBoatSprite.gameObject.SetActive(isBoatMap);
			_shadowWithMapTypeIcon.gameObject.SetActive(isTrainMap || isBoatMap);
			_shadowWithoutMapTypeIcon.gameObject.SetActive(!isTrainMap && !isBoatMap);
		}

		private void OnDestroy()
		{
			_scope.Get<LocaleDatabase>().RemoveLocalizedObject(this);
		}

		public override void OnMapButtonSelected(bool newIsMapButtonSelected)
		{
			base.OnMapButtonSelected(newIsMapButtonSelected);
			bool shouldShow = newIsMapButtonSelected && parentMapButton.CurrentCard == MapButton.Card.Main;
			ShowHideMoreInfoButton(shouldShow);
		}

		public override void SetSelected(bool isSelected)
		{
			base.SetSelected(isSelected);
			bool shouldShow = parentMapButton.IsSelected() && isSelected;
			ShowHideMoreInfoButton(shouldShow);
			if (_player != null)
			{
				GameMode selectedModeForMap = _player.GetSelectedModeForMap(parentMapButton.MapDefinition.mapName);
				UpdateModeStrings(selectedModeForMap);
			}
		}

		private void ShowHideMoreInfoButton(bool shouldShow)
		{
			_showMoreInfoButton = shouldShow;
		}

		private void Update()
		{
			if (_moreInfoButtonCanvas != null)
			{
				_moreInfoButtonCanvas.Alpha = Mathf.Clamp01(_moreInfoButtonCanvas.Alpha + (_showMoreInfoButton ? 0.2f : (-0.2f)));
			}
		}

		public void ScrollToMe()
		{
			parentMapButton.ScrollToMe();
		}

		public void OnChallengeButtonsPressed()
		{
			parentMapButton.ShowChallengeInfo();
		}

		public void SetChallengeIcons(ChallengeData[] challenges, ChallengeDatabase challengeDatabase)
		{
			for (int i = 0; i < challengeIcons.Length; i++)
			{
				if (i < challenges.Length)
				{
					ChallengeData challengeData = challenges[i];
					bool isWildcardChallenge = challengeDatabase.IsChallengeWildcard(challengeData);
					challengeIcons[i].SetChallengeIcons(challengeData.icon, isWildcardChallenge, challengeData.subIcon, challengeData.subIconBackground);
					challengeIcons[i].gameObject.SetActive(value: true);
				}
				else
				{
					challengeIcons[i].gameObject.SetActive(value: false);
				}
			}
		}

		[UsedImplicitly]
		public void MoreInfoSelected()
		{
			if (Diagnostics.Verify(parentMapButton != null))
			{
				parentMapButton.ScrollToMe();
			}
		}

		[UsedImplicitly]
		public void MoreChallengeInfoPressed()
		{
			this.onMoreChallengeInfoPressed?.Invoke();
		}

		public void UpdateModeStrings(GameMode gameMode)
		{
			if (!(currentModeText == null))
			{
				MotorwaysStringKey motorwaysStringKey = _scope.Get<MotorwaysStringKey>();
				switch (gameMode)
				{
				case GameMode.Normal:
					currentModeText.TextField.color = _classicModeTextColor;
					motorwaysStringKey.InitWithStringId(StringId.Normal);
					BestScoreText.gameObject.SetActive(value: true);
					_modeTextHorizontalLayoutGroup.padding.bottom = 0;
					break;
				case GameMode.Endless:
					motorwaysStringKey.InitWithStringId(StringId.Endless);
					currentModeText.TextField.color = _visualConstantsData.EndlessTabButtonColor;
					BestScoreText.gameObject.SetActive(value: false);
					_modeTextHorizontalLayoutGroup.padding.bottom = 30;
					break;
				case GameMode.Expert:
					motorwaysStringKey.InitWithStringId(StringId.Expert);
					currentModeText.TextField.color = _visualConstantsData.ExpertTabButtonColor;
					BestScoreText.gameObject.SetActive(value: true);
					_modeTextHorizontalLayoutGroup.padding.bottom = 0;
					break;
				case GameMode.Creative:
					motorwaysStringKey.InitWithStringId(StringId.Creative);
					currentModeText.TextField.color = _visualConstantsData.CreativeTabButtonColor;
					BestScoreText.gameObject.SetActive(value: false);
					_modeTextHorizontalLayoutGroup.padding.bottom = 30;
					break;
				}
				currentModeText.LocString = StandaloneLocString.CreateString(_scope, motorwaysStringKey);
			}
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
		}

		public void ApplyTheme(ITheme newTheme)
		{
			Theme theme = (Theme)newTheme;
			_classicModeTextColor = theme.GetColor(_classicModeTextThemeColor);
			if (_player != null)
			{
				GameMode selectedModeForMap = _player.GetSelectedModeForMap(parentMapButton.MapDefinition.mapName);
				UpdateModeStrings(selectedModeForMap);
			}
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			Color color = (oldTheme as Theme).GetColor(_classicModeTextThemeColor);
			Color color2 = (newTheme as Theme).GetColor(_classicModeTextThemeColor);
			_classicModeTextColor = Color.Lerp(color, color2, progress);
			if (_player != null)
			{
				GameMode selectedModeForMap = _player.GetSelectedModeForMap(parentMapButton.MapDefinition.mapName);
				UpdateModeStrings(selectedModeForMap);
			}
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
