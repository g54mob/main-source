using System;
using System.Collections.Generic;
using System.Linq;
using Client;
using Easing;
using Factory;
using Motorways.Audio;
using Motorways.Commands;
using Motorways.Models;
using Motorways.Processes;
using Motorways.UI;
using Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class GameUpgradeScreen : InGameScalingScreen
	{
		[System.Serializable]
		public struct RectTransformPositionOffset
		{
			public RectTransform rectTransform;

			public Vector3 positionOffset;
		}

		[Flags]
		private enum GameUIElements
		{
			None = 0,
			Clock = 1,
			Score = 2
		}

		public CanvasGroup upgradeContainer;

		[Dependency]
		private MenuNavigation _menuNavigation;

		[Dependency]
		private SimulationConstantsData _constants;

		private float _delayTimer;

		private bool _hasPopped;

		private UpgradeChoice _nextUpgradeChoice;

		[EnumTypedArray(typeof(UpgradeType))]
		[NonReorderable]
		public Sprite[] upgradeSprites = new Sprite[9];

		[SerializeField]
		private Sprite _mysterySprite;

		private const string MysteryUpgradeDescriptionContentId = "SelectedUpgradeTypeMystery";

		[SerializeField]
		private TouchButton _showMapButton;

		[SerializeField]
		private Image _showMapButtonTouchCatcher;

		public List<RectTransformPositionOffset> tutorialRectTransformOffsets = new List<RectTransformPositionOffset>();

		[SerializeField]
		private UpgradeContainer _classicUpgradeContainer;

		[SerializeField]
		private UpgradeContainer _expertUpgradeContainer;

		private UpgradeContainer _activeUpgradeContainer;

		private int[] _buttonIndexToUpgradeIndex;

		private StringId[] DescriptionIds = new StringId[6]
		{
			StringId.UpgradeConcreteDescription,
			StringId.UpgradeBridgeDescription,
			StringId.UpgradeMotorwayDescription,
			StringId.UpgradeTrafficLightDescription,
			StringId.UpgradeRoundaboutDescription,
			StringId.UpgradeTunnelDescription
		};

		private float _soakTestCountdown;

		private bool _uiHidden;

		private TweenFloat _visibilityToggleTween = new TweenFloat();

		private GameUIElements _visibleElements;

		public override void Tick(float deltaTime)
		{
			base.Tick(deltaTime);
			if (_delayTimer >= 0f)
			{
				_delayTimer -= deltaTime;
				if (_delayTimer < 0f)
				{
					if (_nextUpgradeChoice != null)
					{
						SetButtonOptions(_nextUpgradeChoice);
					}
					else if (!_hasPopped)
					{
						_screenStack.PopOneScreen();
						_hasPopped = true;
					}
					_delayTimer = -1f;
				}
			}
			if (_visibilityToggleTween.IsActive)
			{
				float alpha = _visibilityToggleTween.Tick(deltaTime);
				SetFadeAmount(alpha);
			}
			if (!FeatureToggle.IsFeatureEnabled(Feature.SoakTest) || IsTransitioningIn() || IsTransitioningOut() || !(_soakTestCountdown > 0f))
			{
				return;
			}
			UpgradeDatabaseModel model = _simulation.GetModel<UpgradeDatabaseModel>();
			if (model.pendingUpgradeChoices.Count > 0 && model.pendingUpgradeChoices[0].choices.Count > 0)
			{
				_soakTestCountdown -= deltaTime;
				if ((int)_soakTestCountdown != (int)(_soakTestCountdown + deltaTime))
				{
					Diagnostics.Log.Message(Diagnostics.Log.Level.Info, "Soak", "GameUpgradeScreen.Tick() soak countdown down to {0}.", _soakTestCountdown);
				}
				if (_soakTestCountdown <= 0f)
				{
					int value = Random.Int(model.pendingUpgradeChoices[0].choices.Count);
					int num = Array.IndexOf(_buttonIndexToUpgradeIndex, value);
					Diagnostics.Log.Message(Diagnostics.Log.Level.Info, "Soak", "GameUpgradeScreen.Tick() selecting upgrade {0}.", num);
					OnUpgradeSelect(num);
					_soakTestCountdown = 1f;
				}
			}
		}

		public override void TransitionInTick()
		{
			base.TransitionInTick();
			float p = Mathf.Clamp01(TransitionInPercentage() * 2f - 0.5f);
			SetFadeAmount(Easings.QuarticEaseOut(p), includeRootCanvasGroup: true);
		}

		public override void TransitionOutTick()
		{
			base.TransitionOutTick();
			float p = Mathf.Clamp01((1f - TransitionOutPercentage()) * 2f - 1f);
			SetFadeAmount(Easings.QuarticEaseIn(p), includeRootCanvasGroup: true);
		}

		private void SetFadeAmount(float alpha, bool includeRootCanvasGroup = false)
		{
			upgradeContainer.alpha = alpha;
			_gameCamera.customBlur.Strength = alpha;
			if (includeRootCanvasGroup)
			{
				_canvasGroup.Alpha = alpha;
			}
		}

		public void OnUpgradeSelect(int buttonIndex)
		{
			if (IsTransitioningIn() || IsTransitioningOut() || _delayTimer >= 0f || _hasPopped)
			{
				return;
			}
			int num = _buttonIndexToUpgradeIndex[buttonIndex];
			UpgradeDatabaseModel model = _simulation.GetModel<UpgradeDatabaseModel>();
			if (Diagnostics.Verify(model.pendingUpgradeChoices.Count >= 1, "We selected an upgrade but we don't actually have any pending upgrades!") && Diagnostics.Verify(num != -1, "We selected an invalid upgrade choice!"))
			{
				UpgradePackageDefinition upgradePackageDefinition = model.pendingUpgradeChoices[0].choices[num];
				int num2 = Mathf.Min(upgradePackageDefinition.amount, 5);
				if (upgradePackageDefinition.type == UpgradeType.Concrete)
				{
					num2 = 1;
				}
				bool flag = false;
				if (upgradePackageDefinition.additionalConcrete > 0)
				{
					num2++;
					flag = true;
				}
				if (model.pendingUpgradeChoices[0].choices.Count > 1)
				{
					List<UpgradeType> list = new List<UpgradeType>();
					foreach (UpgradePackageDefinition choice in model.pendingUpgradeChoices[0].choices)
					{
						if (choice.type != upgradePackageDefinition.type)
						{
							list.Add(choice.type);
						}
					}
				}
				if (!(_gameScope.Get<City>().Rules is TutorialGameRules))
				{
					if (_gameScope.Get<GameBehaviourModel>().MysteryUpgradesActive)
					{
						_player.SetNewContentSeen("SelectedUpgradeTypeMystery");
					}
					else
					{
						_player.SetNewContentSeen(GetContentIdStringForSelectedUpgradeType(upgradePackageDefinition.type));
					}
				}
				float num3 = 0f;
				float num4 = 0f;
				for (int i = 0; i < num2; i++)
				{
					NewUpgradeAnimationView newUpgradeAnimationView = _gameScope.Get<NewUpgradeAnimationView>();
					UpgradeType upgradeType = upgradePackageDefinition.type;
					int num5 = upgradePackageDefinition.amount;
					int index = 0;
					if (flag && i == num2 - 1)
					{
						upgradeType = UpgradeType.Concrete;
						num5 = upgradePackageDefinition.additionalConcrete;
						index = 1;
					}
					int num6 = (int)upgradeType;
					GameUIScreen gameUIScreen = _gameScope.Get<GameUIScreen>();
					RectTransform rectTransformForUpgrade = gameUIScreen.UpgradeBar.GetRectTransformForUpgrade(upgradeType);
					RectTransform iconRect = _activeUpgradeContainer.buttons[buttonIndex].GetIconRect(index);
					newUpgradeAnimationView.GetComponent<RectTransform>().anchoredPosition = iconRect.anchoredPosition;
					newUpgradeAnimationView.transform.SetParent(iconRect.parent, worldPositionStays: false);
					newUpgradeAnimationView.transform.SetParent(gameUIScreen.OverlayTransform, worldPositionStays: true);
					int count = ((upgradeType != UpgradeType.Concrete) ? 1 : num5);
					newUpgradeAnimationView.Initialize(iconRect.sizeDelta, rectTransformForUpgrade, upgradeSprites[num6], upgradeType, _themeDatabase.TargetTheme, num3, count);
					num3 += newUpgradeAnimationView.animationSpacing;
					num4 = ((i != 0) ? (num4 + newUpgradeAnimationView.animationSpacing) : newUpgradeAnimationView.animationDuration);
					if (gameUIScreen.UpgradeBar.IsSpriteForUpgradeACircle(upgradeType))
					{
						newUpgradeAnimationView.UpgradeIcon.SetToCircle();
					}
					else
					{
						newUpgradeAnimationView.UpgradeIcon.SetToDiamond();
					}
					_gameScope.Get<ViewClient>().AddView(newUpgradeAnimationView);
				}
				if (model.pendingUpgradeChoices.Count > 1)
				{
					SetNextButtonOptions(model.pendingUpgradeChoices[1], 0f, buttonIndex);
				}
				else
				{
					CloseScreenAfterSelection();
					_screenStack.GetActiveScreen<GameContainerScreen>()?.SkipNextTransition();
					_overrideNextTransitionDuration = num4;
				}
				model.numChoicesMade++;
				_simulation.ScheduleCommand(SelectUpgradeCommand.Create(_gameScope, num));
			}
			else
			{
				CloseScreenAfterSelection();
			}
		}

		public void SetNextButtonOptions(UpgradeChoice options, float delay, int selectedOption = -1)
		{
			if (selectedOption >= 0)
			{
				_activeUpgradeContainer.buttons[selectedOption].iconParent.gameObject.SetActive(value: false);
			}
			_delayTimer = delay;
			_nextUpgradeChoice = options;
		}

		public void CloseScreenAfterSelection()
		{
			_nextUpgradeChoice = null;
			_delayTimer = 0f;
		}

		private void SetButtonOptions(UpgradeChoice choice)
		{
			City city = _gameScope.Get<City>();
			GameRules rules = city.Rules;
			bool flag = rules is TutorialGameRules;
			MotorwaysStringKey motorwaysStringKey = _gameScope.Get<MotorwaysStringKey>();
			StringId stringId = StringId.None;
			_activeUpgradeContainer = _classicUpgradeContainer;
			UpgradeContainer upgradeContainer = _expertUpgradeContainer;
			if (choice.choices.Count > 2)
			{
				_activeUpgradeContainer = _expertUpgradeContainer;
				upgradeContainer = _classicUpgradeContainer;
			}
			_activeUpgradeContainer.root.SetActive(value: true);
			upgradeContainer.root.SetActive(value: false);
			if (rules.ScoringMode == ScoringMode.EfficiencyMilestones)
			{
				int newCount = _gameScope.Get<UpgradeDatabaseModel>().TotalClaimedPackages + 1;
				motorwaysStringKey.InitWithStringId(StringId.MilestoneCount, newCount, new Dictionary<string, string> { 
				{
					"Num",
					newCount.ToString()
				} });
			}
			else if (city.GameMode == GameMode.Expert)
			{
				UpgradeDatabaseModel upgradeDatabaseModel = _gameScope.Get<UpgradeDatabaseModel>();
				int num = _constants.MaxUpgradeChoicesAwardedInExpertMode - upgradeDatabaseModel.TotalGrantedUpgradesCount;
				if (num > 0)
				{
					motorwaysStringKey.InitWithStringId(StringId.WeeksRemaining, num + 1, new Dictionary<string, string> { 
					{
						"Num",
						(num + 1).ToString()
					} });
				}
				else if (num == 0)
				{
					motorwaysStringKey.InitWithStringId(StringId.WeeksRemainingNone);
					stringId = StringId.WeeksRemainingNone_Body;
				}
				else
				{
					int week = _gameScope.Get<ClockModel>().Week;
					motorwaysStringKey.InitWithStringId(StringId.WeekCount, week, new Dictionary<string, string> { 
					{
						"Num",
						week.ToString()
					} });
					stringId = StringId.WeekTagline_Concrete;
				}
			}
			else
			{
				int week2 = _gameScope.Get<ClockModel>().Week;
				motorwaysStringKey.InitWithStringId(StringId.WeekCount, week2, new Dictionary<string, string> { 
				{
					"Num",
					week2.ToString()
				} });
			}
			_activeUpgradeContainer.weekText.LocString = StandaloneLocString.CreateString(_gameScope, motorwaysStringKey);
			List<UpgradePackageDefinition> choices = choice.choices;
			if (stringId == StringId.None)
			{
				stringId = ((!choice.isFree) ? rules.GetUpgradeScreenDescriptionUpgrades(choices.Count) : StringId.WeekTagline_Concrete);
			}
			_activeUpgradeContainer.weekDescriptionText.LocString = StandaloneLocString.CreateString(_gameScope, stringId);
			_activeUpgradeContainer.weekText.gameObject.SetActive(!flag);
			_activeUpgradeContainer.weekDescriptionText.gameObject.SetActive(!flag);
			bool mysteryUpgradesActive = _gameScope.Get<GameBehaviourModel>().MysteryUpgradesActive;
			_buttonIndexToUpgradeIndex = BuildButtonIndexToUpgradeIndexMapping(_activeUpgradeContainer.buttons.Length, choices.Count);
			for (int i = 0; i < _activeUpgradeContainer.buttons.Length; i++)
			{
				NewUpgradeButton newUpgradeButton = _activeUpgradeContainer.buttons[i];
				int num2 = _buttonIndexToUpgradeIndex[i];
				if (num2 != -1)
				{
					newUpgradeButton.transform.gameObject.SetActive(value: true);
					newUpgradeButton.SecondaryIcon.gameObject.SetActive(value: true);
					UpgradePackageDefinition upgradePackageDefinition = choices[num2];
					if (mysteryUpgradesActive)
					{
						newUpgradeButton.Sprite = _mysterySprite;
						newUpgradeButton.PrimaryIcon.SetToDiamond();
						newUpgradeButton.SecondaryIcon.gameObject.SetActive(value: false);
						SetNumberBubbleAmount(newUpgradeButton.PrimaryNumberBubble, 1);
					}
					else
					{
						newUpgradeButton.primaryUpgradeType = upgradePackageDefinition.type;
						newUpgradeButton.Sprite = upgradeSprites[(int)upgradePackageDefinition.type];
						if (_gameScope.Get<GameUIScreen>().UpgradeBar.IsSpriteForUpgradeACircle(upgradePackageDefinition.type))
						{
							newUpgradeButton.PrimaryIcon.SetToCircle();
						}
						else
						{
							newUpgradeButton.PrimaryIcon.SetToDiamond();
						}
						SetNumberBubbleAmount(newUpgradeButton.PrimaryNumberBubble, upgradePackageDefinition.amount);
						if (upgradePackageDefinition.additionalConcrete > 0)
						{
							SetNumberBubbleAmount(newUpgradeButton.SecondaryNumberBubble, upgradePackageDefinition.additionalConcrete);
							RectTransform rect = newUpgradeButton.PrimaryIcon.Rect;
							newUpgradeButton.SecondaryIcon.SetCutoutRect(rect);
						}
						else
						{
							newUpgradeButton.SecondaryIcon.gameObject.SetActive(value: false);
						}
					}
					newUpgradeButton.iconParent.gameObject.SetActive(value: true);
					MotorwaysStringKey motorwaysStringKey2 = _gameScope.Get<MotorwaysStringKey>();
					MotorwaysStringKey motorwaysStringKey3 = _gameScope.Get<MotorwaysStringKey>();
					MotorwaysStringKey motorwaysStringKey4 = _gameScope.Get<MotorwaysStringKey>();
					if (newUpgradeButton.buttonName != null)
					{
						if (mysteryUpgradesActive)
						{
							motorwaysStringKey2.InitWithStringId(StringId.MysteryUpgradeName);
							motorwaysStringKey3.InitWithStringId(StringId.MysteryUpgradeDescription);
						}
						else
						{
							motorwaysStringKey2.InitWithString($"{upgradePackageDefinition.type}_Title", upgradePackageDefinition.amount, new Dictionary<string, string> { 
							{
								"Num",
								upgradePackageDefinition.amount.ToString()
							} });
							motorwaysStringKey3.InitWithStringId(DescriptionIds[(int)upgradePackageDefinition.type]);
							motorwaysStringKey4.InitWithString(UpgradeType.Concrete.ToString(), upgradePackageDefinition.additionalConcrete, new Dictionary<string, string> { 
							{
								"Num",
								upgradePackageDefinition.additionalConcrete.ToString()
							} });
						}
						newUpgradeButton.buttonName.LocString = StandaloneLocString.CreateString(_gameScope, motorwaysStringKey2);
					}
					if (newUpgradeButton.buttonAdditionalConcrete != null)
					{
						if (upgradePackageDefinition.additionalConcrete > 0 && !mysteryUpgradesActive)
						{
							newUpgradeButton.buttonAdditionalConcrete.LocString = StandaloneLocString.CreateString(_gameScope, motorwaysStringKey4);
						}
						else
						{
							newUpgradeButton.buttonAdditionalConcrete.LocString = StandaloneLocString.CreateNonLocalizedString(_gameScope, "");
						}
					}
					if (newUpgradeButton.buttonDescription != null)
					{
						bool flag2 = rules.ShouldShowNewUpgradeIconDescriptionForType(upgradePackageDefinition.type);
						if (mysteryUpgradesActive)
						{
							flag2 = !_player.HasSeenNewContent("SelectedUpgradeTypeMystery");
						}
						if (_game.Scope.Get<CityModel>().Mode == GameMode.Expert)
						{
							flag2 = false;
						}
						if (flag2)
						{
							newUpgradeButton.buttonDescription.LocString = StandaloneLocString.CreateString(_gameScope, motorwaysStringKey3);
						}
						else
						{
							newUpgradeButton.buttonDescription.LocString = StandaloneLocString.CreateNonLocalizedString(_gameScope, "");
						}
					}
					bool interactable = !choice.disabledOptions.HasFlag((DisabledUpgradeOptions)(1 << num2 + 1));
					newUpgradeButton.SetInteractable(interactable);
				}
				else
				{
					newUpgradeButton.transform.gameObject.SetActive(value: false);
				}
			}
			if (_inputState.CurrentInputTypeRequiresFocus)
			{
				NewUpgradeButton newFocus = _activeUpgradeContainer.buttons.FirstOrDefault((NewUpgradeButton button) => button.interactable);
				_menuNavigation.SetNewFocus(newFocus);
				firstFocus = newFocus;
			}
		}

		private static int[] BuildButtonIndexToUpgradeIndexMapping(int numButtons, int numUpgrades)
		{
			int[] array = new int[numButtons];
			for (int i = 0; i < numButtons; i++)
			{
				array[i] = -1;
			}
			if (numUpgrades <= 2)
			{
				for (int j = 0; j < numUpgrades; j++)
				{
					array[j] = j;
				}
			}
			else
			{
				int num = numUpgrades / 2;
				int num2 = numUpgrades - num;
				int num3 = 0;
				for (int k = 0; k < num; k++)
				{
					array[num3++] = k;
				}
				num3 = 3;
				for (int l = 0; l < num2; l++)
				{
					array[num3++] = num + l;
				}
			}
			return array;
		}

		private void SetNumberBubbleAmount(NumberBubble numberBubble, int amount)
		{
			if (numberBubble != null)
			{
				if (amount == 1)
				{
					numberBubble.Hide(instantly: true);
				}
				else
				{
					numberBubble.SetValue(amount, doBounce: false);
				}
			}
		}

		public static string GetContentIdStringForSelectedUpgradeType(UpgradeType type)
		{
			return $"SelectedUpgradeType{type}";
		}

		public override void ApplyTheme(ITheme newTheme)
		{
			base.ApplyTheme(newTheme);
			NewUpgradeButton[] buttons = _classicUpgradeContainer.buttons;
			for (int i = 0; i < buttons.Length; i++)
			{
				buttons[i].ApplyTheme(newTheme);
			}
			buttons = _expertUpgradeContainer.buttons;
			for (int i = 0; i < buttons.Length; i++)
			{
				buttons[i].ApplyTheme(newTheme);
			}
		}

		public override bool CanTransitionIn()
		{
			return _playerActionController.BlockingPlayerActionCount == 0;
		}

		public override void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			ApplyTheme(_themeDatabase.TargetTheme);
			base.TransitionIn(outScreen);
			_skipTransitions = false;
			_canvasGroup.Alpha = 1f;
			_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: false);
			_gameScope.Get<GameUIScreen>().IsUpgradeBarOnOverlay = true;
			MotorwaysInGameStateToggleController.SwitchToStateIfNeeded(MotorwaysInGameStateToggleController.InGameControllerState.InGameOverlayScreen, _gameScope, MotorwaysInGameStateToggleController.StateSwapActionBehaviour.CancelActions);
			_hasPopped = false;
			if (_gameScope.Get<City>().Rules.ShouldUseUpgradeScreenOffsets())
			{
				foreach (RectTransformPositionOffset tutorialRectTransformOffset in tutorialRectTransformOffsets)
				{
					tutorialRectTransformOffset.rectTransform.anchoredPosition3D += tutorialRectTransformOffset.positionOffset;
				}
			}
			_soakTestCountdown = 1.1f;
			_showMapButton.gameObject.SetActive(FeatureToggle.IsFeatureEnabled(Feature.UpgradeScreenViewMap));
			GameUIScreen gameUIScreen = _gameScope.Get<GameUIScreen>();
			_visibleElements = GameUIElements.None;
			if (gameUIScreen.IsClockVisible)
			{
				gameUIScreen.SetClockVisibility(visible: false);
				_visibleElements |= GameUIElements.Clock;
			}
			if (gameUIScreen.IsScoreVisible)
			{
				gameUIScreen.SetScoreVisible(visible: false);
				_visibleElements |= GameUIElements.Score;
			}
			gameUIScreen.SetMenuButtonVisible(visible: false);
			gameUIScreen.ExitEditModeUI();
			_showMapButtonTouchCatcher.raycastTarget = false;
		}

		public override void OnTransitionedIn()
		{
			base.OnTransitionedIn();
			_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: true);
		}

		public override void OnGainedFocus()
		{
			_canvasGroup.SetInteractable(isInteractable: true);
			_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: true);
			Selectable currentFocus = _menuNavigation.GetCurrentFocus();
			if (!_activeUpgradeContainer.buttons.Contains(currentFocus) && !(currentFocus == _showMapButton) && firstFocus != null && _appScope.Get<InputState>().CurrentInputTypeRequiresFocus)
			{
				_navigation.SetNewFocus(firstFocus);
			}
		}

		public void OnHideUIToggled()
		{
			if (FeatureToggle.IsFeatureDisabled(Feature.UpgradeScreenViewMap))
			{
				_uiHidden = false;
				return;
			}
			_uiHidden = !_uiHidden;
			GameUIScreen gameUIScreen = _gameScope.Get<GameUIScreen>();
			gameUIScreen.backButton.gameObject.SetActive(value: false);
			gameUIScreen.SetClockVisibility(visible: false);
			gameUIScreen.SetScoreVisible(visible: false);
			gameUIScreen.SetWorldGridActive(_uiHidden);
			upgradeContainer.interactable = !_uiHidden;
			upgradeContainer.blocksRaycasts = !_uiHidden;
			_showMapButtonTouchCatcher.raycastTarget = _uiHidden;
			float num = (_uiHidden ? 1 : 0);
			num = (_visibilityToggleTween.IsActive ? _visibilityToggleTween.Value : num);
			if (_uiHidden)
			{
				_visibilityToggleTween.Start(num, 0f, 0.2f, Easings.Functions.QuarticEaseIn);
			}
			else
			{
				_visibilityToggleTween.Start(num, 1f, 0.2f, Easings.Functions.QuarticEaseOut);
			}
			_menuNavigation.SetNewFocus(_showMapButton);
		}

		public override void OnTransitionedOut()
		{
			base.OnTransitionedOut();
			_canvasGroup.Alpha = 0f;
			_gameScope.Get<GameUIScreen>().IsUpgradeBarOnOverlay = false;
			if (!_gameScope.Get<City>().Rules.ShouldUseUpgradeScreenOffsets())
			{
				return;
			}
			foreach (RectTransformPositionOffset tutorialRectTransformOffset in tutorialRectTransformOffsets)
			{
				tutorialRectTransformOffset.rectTransform.anchoredPosition3D -= tutorialRectTransformOffset.positionOffset;
			}
		}

		public override void TransitionOut(ScreenStack.MotorwaysScreen inScreen)
		{
			base.TransitionOut(inScreen);
			MotorwaysInGameStateToggleController.SwitchToStateIfNeeded(MotorwaysInGameStateToggleController.InGameControllerState.EditingTiles, _gameScope);
			_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.WeekStart));
			GameUIScreen gameUIScreen = _gameScope.Get<GameUIScreen>();
			if (_visibleElements.HasFlag(GameUIElements.Clock))
			{
				gameUIScreen.SetClockVisibility(visible: true);
			}
			if (_visibleElements.HasFlag(GameUIElements.Score))
			{
				gameUIScreen.SetScoreVisible(visible: true);
			}
			gameUIScreen.backButton.gameObject.SetActive(value: true);
			gameUIScreen.SetMenuButtonVisible(visible: true);
			_visibleElements = GameUIElements.None;
		}

		public override void OnCurrentDeviceInputTypeChanged(DeviceInputType newInputType)
		{
			base.OnCurrentDeviceInputTypeChanged(newInputType);
			if (InputState.DeviceInputTypeRequiresFocus(newInputType) && _activeUpgradeContainer != null)
			{
				_menuNavigation.SetNewFocus(_activeUpgradeContainer.buttons[0]);
			}
		}

		public override void OnCreatedInScope(IScope scope)
		{
			base.OnCreatedInScope(scope);
			_canvasGroup.Alpha = 0f;
			upgradeContainer.alpha = 0f;
		}

		public override void Reset()
		{
			base.Reset();
			_visibleElements = GameUIElements.None;
			_delayTimer = 0f;
			_nextUpgradeChoice = null;
			_activeUpgradeContainer = null;
			_buttonIndexToUpgradeIndex = null;
			_hasPopped = false;
		}
	}
}
