using System;
using System.Collections;
using System.Collections.Generic;
using Client;
using Easing;
using Factory;
using JetBrains.Annotations;
using Motorways.Models;
using Motorways.UI;
using Motorways.Utility;
using Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Views
{
	public abstract class OverlayBaseScreen : InGameScalingScreen
	{
		public enum OverlayScreenType
		{
			PhotoScreen = 0,
			CinematicModeScreen = 1
		}

		[Dependency]
		protected ISoftwareCapabilities softwareCapabilities;

		[Dependency]
		protected GameCamera gameCamera;

		[SerializeField]
		private GameObject _backButtonAnchor;

		[SerializeField]
		private GameObject _pinButtonAnchor;

		[SerializeField]
		private GameObject _titleButtonAnchor;

		[SerializeField]
		private GameObject _frameButtonAnchor;

		[SerializeField]
		private FloatingElement _challengeButtonAnchor;

		[SerializeField]
		private GameObject _takePhotoButtonAnchor;

		[SerializeField]
		private TouchToggle _pinToggleButton;

		[SerializeField]
		private SymbolOptionButton _titleOptionButton;

		[SerializeField]
		private SymbolOptionButton _frameOptionButton;

		[SerializeField]
		private SymbolOptionButton _challengeOptionButton;

		[SerializeField]
		private TouchToggle _endlessOptionButton;

		[SerializeField]
		private TouchToggle _expertOptionButton;

		[SerializeField]
		private TouchToggle _creativeOptionButton;

		[SerializeField]
		private TouchButton _challengeButton;

		[SerializeField]
		private TouchButton _followNextCarButton;

		[SerializeField]
		protected TouchButton _zoomInButton;

		[SerializeField]
		protected TouchButton _zoomOutButton;

		[SerializeField]
		private GameObject _toolbarBackgroundAnchor;

		[SerializeField]
		private VariableDeviceSelectable _topButton;

		[SerializeField]
		private VariableDeviceSelectable _toggleToolbarButton;

		[SerializeField]
		private TouchButton _takePhotoButton;

		[SerializeField]
		private TouchButton _frameTouchCycleButton;

		[SerializeField]
		private LocalizedTextUI _cityTitle;

		[SerializeField]
		private LocalizedTextUI _scoreTitle;

		[SerializeField]
		private LocalizedTextUI _weekTitle;

		[SerializeField]
		private GameObject _divider;

		[SerializeField]
		private GameObject _challengeIconContainer;

		[SerializeField]
		private LocalizedTextUI _challengeTitleText;

		[SerializeField]
		private LocalizedTextUI _challengeDateText;

		[SerializeField]
		private CanvasGroup _nonPhotoLayer;

		[SerializeField]
		private CanvasGroup _cameraFramingCanvasGroup;

		[SerializeField]
		private CanvasGroup[] _displayCanvasGroups;

		[SerializeField]
		private CanvasGroup _frameCanvasGroup;

		[SerializeField]
		private ChallengeIcon[] _challengeIcons;

		private bool _isToolbarVisibilityChangeScheduled;

		private bool _scheduledToolbarVisibility;

		private List<FloatingElement> _floatingElements = new List<FloatingElement>();

		private TweenFloat _cameraFrameAlphaTween = new TweenFloat();

		protected bool isToolbarVisible;

		protected abstract OverlayScreenType overlayScreenType { get; }

		private GameObject ChallengeTextParent => _challengeTitleText.transform.parent.gameObject;

		protected CanvasGroup nonPhotoLayer => _nonPhotoLayer;

		private bool ShouldShowDivider
		{
			get
			{
				if (_cityTitle.gameObject.activeInHierarchy)
				{
					if (!_scoreTitle.gameObject.activeInHierarchy)
					{
						return _weekTitle.gameObject.activeInHierarchy;
					}
					return true;
				}
				return false;
			}
		}

		private bool IsAnimating
		{
			get
			{
				if (_cameraFrameAlphaTween.IsActive)
				{
					return true;
				}
				foreach (FloatingElement floatingElement in _floatingElements)
				{
					if (floatingElement.IsAnimating)
					{
						return true;
					}
				}
				return false;
			}
		}

		public override void Awake()
		{
			base.Awake();
			_floatingElements.AddRange(base.gameObject.GetComponentsInChildren<FloatingElement>());
		}

		public override void OnCreatedInScope(IScope scope)
		{
			base.OnCreatedInScope(scope);
			_canvas.worldCamera = gameCamera.UICamera;
			_cameraFramingCanvasGroup.gameObject.SetActive(overlayScreenType == OverlayScreenType.PhotoScreen);
		}

		public override void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			SetTimedFramesActive();
			base.TransitionIn(outScreen);
			_skipTransitions = false;
			_transitionDetails.spline = new Spline.BezierSplineWithRotation(_transitionDetails.spline.inPoint, Vector2.zero, Vector2.zero, _transitionDetails.spline.outHandle, _transitionDetails.spline.startRotation, _transitionDetails.spline.endRotation);
			SetToolbarVisible(visible: false);
			foreach (FloatingElement floatingElement in _floatingElements)
			{
				floatingElement.Snap();
			}
			_cameraFrameAlphaTween.Stop();
			_cameraFramingCanvasGroup.alpha = 0f;
			_cityTitle.SetStringId(_gameScope, GetMapDefinition().mapName);
			_cityTitle.gameObject.SetActive(value: false);
			_scoreTitle.LocString = StandaloneLocString.CreateLocalizedNumberString(_gameScope, _gameScope.Get<ScoreModel>().Score);
			_scoreTitle.gameObject.SetActive(value: false);
			MotorwaysStringKey motorwaysStringKey = _gameScope.Get<MotorwaysStringKey>();
			City city = _gameScope.Get<City>();
			if (city.Rules.ScoringMode == ScoringMode.EfficiencyMilestones)
			{
				int newCount = _gameScope.Get<UpgradeDatabaseModel>().TotalClaimedPackages + 1;
				motorwaysStringKey.InitWithStringId(StringId.MilestoneCount, newCount, new Dictionary<string, string> { 
				{
					"Num",
					newCount.ToString()
				} });
			}
			else
			{
				motorwaysStringKey.InitWithStringId(StringId.WeekCount, _gameScope.Get<ClockModel>().Week, new Dictionary<string, string> { 
				{
					"Num",
					(_gameScope.Get<ClockModel>().Week + 1).ToString()
				} });
			}
			_weekTitle.LocString = StandaloneLocString.CreateString(_gameScope, motorwaysStringKey);
			ActiveChallengesModel model = _game.Simulation.GetModel<ActiveChallengesModel>();
			ChallengeDatabase challengeDatabase = _game.Scope.Get<ChallengeDatabase>();
			for (int i = 0; i < _challengeIcons.Length; i++)
			{
				if (i < model.challenges.Count)
				{
					_challengeIcons[i].gameObject.SetActive(value: true);
					ChallengeData challengeData = model.challenges[i];
					_challengeIcons[i].SetChallengeIcons(challengeData.icon, challengeDatabase.IsChallengeWildcard(challengeData), challengeData.subIcon, challengeData.subIconBackground);
				}
				else
				{
					_challengeIcons[i].gameObject.SetActive(value: false);
				}
			}
			_challengeIconContainer.SetActive(value: false);
			ChallengeTextParent.gameObject.SetActive(value: false);
			if (overlayScreenType == OverlayScreenType.PhotoScreen)
			{
				SetupDefaultFrame();
			}
			SetFrameElementsAlpha(0f);
			foreach (VehicleView view in _gameScope.Get<ViewClient>().GetViews<VehicleView>())
			{
				view.SkipHeadlightResponseTime = true;
			}
			_gameScope.Get<TilemapView>().TurnOffMotorwayTransparency();
			if (overlayScreenType == OverlayScreenType.PhotoScreen)
			{
				_followNextCarButton.gameObject.SetActive(value: false);
				_zoomInButton.gameObject.SetActive(value: false);
				_zoomOutButton.gameObject.SetActive(value: false);
				if (city.GameMode == GameMode.Endless)
				{
					_titleOptionButton.optionCount = 3;
					_endlessOptionButton.gameObject.SetActive(value: true);
					_challengeDateText.gameObject.SetActive(value: false);
					ChallengeTextParent.SetActive(_endlessOptionButton.IsOn);
					_challengeTitleText.SetStringId(_appScope, StringId.Endless);
					BaseScalingScreen.SetNavigationOnDown(_frameTouchCycleButton, _endlessOptionButton);
				}
				else
				{
					_titleOptionButton.optionCount = 4;
					_endlessOptionButton.gameObject.SetActive(value: false);
				}
				if (city.GameMode == GameMode.Expert && !model.HasChallenges)
				{
					_expertOptionButton.gameObject.SetActive(value: true);
					_challengeDateText.gameObject.SetActive(value: false);
					ChallengeTextParent.SetActive(_expertOptionButton.IsOn);
					_challengeTitleText.SetStringId(_appScope, StringId.Expert);
					BaseScalingScreen.SetNavigationOnDown(_frameTouchCycleButton, _expertOptionButton);
				}
				else
				{
					_expertOptionButton.gameObject.SetActive(value: false);
				}
				if (city.GameMode == GameMode.Creative)
				{
					_titleOptionButton.optionCount = 3;
					_creativeOptionButton.gameObject.SetActive(value: true);
					_challengeDateText.gameObject.SetActive(value: false);
					ChallengeTextParent.SetActive(_creativeOptionButton.IsOn);
					_challengeTitleText.SetStringId(_appScope, StringId.Creative);
					BaseScalingScreen.SetNavigationOnDown(_frameTouchCycleButton, _creativeOptionButton);
				}
				else
				{
					_titleOptionButton.optionCount = 4;
					_creativeOptionButton.gameObject.SetActive(value: false);
				}
				if (model.HasChallenges)
				{
					BaseScalingScreen.SetNavigationOnDown(_frameTouchCycleButton, _challengeButton);
				}
			}
			else
			{
				_pinToggleButton.gameObject.SetActive(value: false);
				_titleOptionButton.gameObject.SetActive(value: false);
				_frameOptionButton.gameObject.SetActive(value: false);
				_challengeOptionButton.gameObject.SetActive(value: false);
				_endlessOptionButton.gameObject.SetActive(value: false);
				_expertOptionButton.gameObject.SetActive(value: false);
				_creativeOptionButton.gameObject.SetActive(value: false);
				_followNextCarButton.gameObject.SetActive(value: true);
				_zoomInButton.gameObject.SetActive(value: true);
				_zoomOutButton.gameObject.SetActive(value: true);
			}
		}

		private void SetupDefaultFrame()
		{
			if (overlayScreenType != OverlayScreenType.PhotoScreen)
			{
				return;
			}
			ActiveChallengesModel model = _game.Simulation.GetModel<ActiveChallengesModel>();
			_titleOptionButton.SetOption(1);
			_frameOptionButton.SetOption(2);
			_endlessOptionButton.Set(value: true);
			_expertOptionButton.Set(value: true);
			_creativeOptionButton.Set(value: true);
			if (model.HasChallenges)
			{
				_challengeButton.gameObject.SetActive(value: true);
				_challengeOptionButton.optionCount = 6;
				StringId result = StringId.MiniMotorways;
				if (model.challengeType == MapChallenge.ChallengeType.Daily)
				{
					result = StringId.DailyChallenge;
				}
				else if (model.challengeType == MapChallenge.ChallengeType.Weekly)
				{
					result = StringId.WeeklyChallenge;
				}
				else if (model.challengeType == MapChallenge.ChallengeType.Mystery)
				{
					result = StringId.Challenge_RandomChallengesMapTitle;
				}
				else if (model.IsCityChallenge)
				{
					Diagnostics.Verify(Enum.TryParse<StringId>(_game.MapDefinition.cityChallenges[model.cityChallengeIndex].titleStringId, out result));
					_challengeOptionButton.optionCount = 4;
				}
				_challengeTitleText.SetStringId(_appScope, result);
				DateTime dateTime = ChallengeSystem.ToDateTime(model.timeStart);
				if (FeatureToggle.IsFeatureEnabled(Feature.InjectDebugChallenges))
				{
					dateTime = GameDateTime.UtcNow;
				}
				if (FeatureToggle.IsFeatureEnabled(Feature.RandomChallengesMapButton))
				{
					dateTime = GameDateTime.UtcNow;
				}
				_challengeDateText.LocString = StandaloneLocString.CreateNonLocalizedString(_appScope, dateTime.ToString(" - yyyy-MM-dd"));
				_challengeOptionButton.SetOption(2);
			}
		}

		public override void TransitionInTick()
		{
			float num = Easings.CubicEaseInOut(TransitionInPercentage());
			Vector3 position = _transitionDetails.spline.EvaluateLinear(num);
			_gameCamera.SetPosition(position);
			_gameCamera.transform.rotation = _transitionDetails.spline.EvaluateRotation(num);
			position.z = base.transform.position.z;
			base.transform.position = position;
			_gameCamera.OrthographicSize = Mathf.Lerp(_previousCameraZoom, _screenStack.GetZoomFor(base.ScreenType), num);
		}

		public override void OnTransitionedIn()
		{
			base.OnTransitionedIn();
			if (!isToolbarVisible && overlayScreenType == OverlayScreenType.PhotoScreen)
			{
				ToggleToolbarVisibility();
			}
			StartCoroutine(FadeFrames());
		}

		private IEnumerator FadeFrames()
		{
			for (int iteration = 0; iteration < 20; iteration++)
			{
				float p = (float)iteration / 20f;
				p = Easings.CubicEaseOut(p);
				SetFrameElementsAlpha(p);
				yield return new WaitForSeconds(0.025f);
			}
		}

		private void SetFrameElementsAlpha(float alpha)
		{
			CanvasGroup[] displayCanvasGroups = _displayCanvasGroups;
			for (int i = 0; i < displayCanvasGroups.Length; i++)
			{
				displayCanvasGroups[i].alpha = alpha;
			}
		}

		public override void TransitionOut(ScreenStack.MotorwaysScreen inScreen)
		{
			base.TransitionOut(inScreen);
			SetToolbarVisible(visible: false);
			_gameScope.Get<TilemapView>().TurnOnMotorwayTransparency();
		}

		public override void TransitionOutTick()
		{
			base.TransitionOutTick();
			float frameElementsAlpha = Mathf.Clamp01(1f - TransitionOutPercentage() * 2f);
			SetFrameElementsAlpha(frameElementsAlpha);
		}

		public override void Tick(float deltaTime)
		{
			base.Tick(deltaTime);
			if (_isToolbarVisibilityChangeScheduled && !IsAnimating)
			{
				SetToolbarVisible(_scheduledToolbarVisibility);
			}
			if (_cameraFrameAlphaTween.IsActive)
			{
				_cameraFrameAlphaTween.Tick(deltaTime);
				_cameraFramingCanvasGroup.alpha = _cameraFrameAlphaTween.Value;
			}
		}

		public void OnBack()
		{
			_game.Scope.Get<NotificationView>().HideNotification();
			_screenStack.PopOneScreen();
		}

		protected void SetFrameLayer(int layerId)
		{
			foreach (Transform componentInChild in _frameCanvasGroup.GetComponentInChildren<Transform>(includeInactive: true))
			{
				componentInChild.gameObject.layer = layerId;
			}
		}

		public virtual void ToggleToolbarVisibility()
		{
			if (IsAnimating)
			{
				_isToolbarVisibilityChangeScheduled = true;
				_scheduledToolbarVisibility = !isToolbarVisible;
			}
			else
			{
				SetToolbarVisible(!isToolbarVisible, hasAudio: true);
			}
		}

		public virtual void SetToolbarVisible(bool visible, bool hasAudio = false)
		{
			isToolbarVisible = visible;
			_backButtonAnchor.SetActive(visible);
			_pinButtonAnchor.SetActive(visible);
			_toolbarBackgroundAnchor.SetActive(visible);
			City city = _gameScope.Get<City>();
			_titleButtonAnchor.SetActive(visible && !(city.Rules is TutorialGameRules));
			_frameButtonAnchor.SetActive(visible);
			bool hasChallenges = _game.Simulation.GetModel<ActiveChallengesModel>().HasChallenges;
			bool flag = city.GameMode == GameMode.Endless || city.GameMode == GameMode.Expert;
			bool flag2 = city.GameMode == GameMode.Creative;
			_challengeButtonAnchor.baseElement.SetActive((hasChallenges || flag || flag2) && visible);
			_challengeButtonAnchor.InactiveAnchor.SetActive(hasChallenges || flag || flag2);
			_challengeButton.gameObject.SetActive(hasChallenges && city.GameMode != GameMode.Cinematic);
			bool flag3 = overlayScreenType == OverlayScreenType.PhotoScreen && visible && softwareCapabilities.CanShareImage;
			_takePhotoButtonAnchor.SetActive(flag3);
			_takePhotoButton.interactable = flag3;
			if (visible)
			{
				if (_appScope.Get<InputState>().CurrentInputTypeRequiresFocus)
				{
					_appScope.Get<MenuNavigation>().SetNewFocus(_topButton);
				}
				_cameraFrameAlphaTween.Start(0f, 1f, 0.1f, Easings.Functions.Linear);
			}
			else
			{
				_appScope.Get<MenuNavigation>().SetNewFocus(_toggleToolbarButton);
				_cameraFrameAlphaTween.Start(1f, 0f, 0.1f, Easings.Functions.Linear);
			}
			_isToolbarVisibilityChangeScheduled = false;
		}

		public override void BackActivated()
		{
			_toggleToolbarButton?.OnSubmit(null);
		}

		public void OnPinToggle(bool value)
		{
			foreach (DestinationView view in _gameScope.Get<ViewClient>().GetViews<DestinationView>())
			{
				view.SetPinViewVisible(value);
			}
		}

		public void OnTitleCycle(int value)
		{
			switch (value)
			{
			case 0:
				_cityTitle.gameObject.SetActive(value: false);
				_scoreTitle.gameObject.SetActive(value: false);
				_weekTitle.gameObject.SetActive(value: false);
				break;
			case 1:
				_cityTitle.gameObject.SetActive(value: true);
				_scoreTitle.gameObject.SetActive(value: false);
				_weekTitle.gameObject.SetActive(value: false);
				break;
			case 2:
				_cityTitle.gameObject.SetActive(value: true);
				_scoreTitle.gameObject.SetActive(value: false);
				_weekTitle.gameObject.SetActive(value: true);
				break;
			case 3:
				_cityTitle.gameObject.SetActive(value: true);
				_scoreTitle.gameObject.SetActive(value: true);
				_weekTitle.gameObject.SetActive(value: false);
				break;
			}
			_divider.SetActive(ShouldShowDivider);
		}

		[UsedImplicitly]
		public void OnEndlessToggled(bool value)
		{
			ChallengeTextParent.SetActive(value);
		}

		[UsedImplicitly]
		public void OnExpertToggled(bool value)
		{
			ChallengeTextParent.SetActive(value);
		}

		[UsedImplicitly]
		public void OnCreativeToggled(bool value)
		{
			ChallengeTextParent.SetActive(value);
		}

		[UsedImplicitly]
		public void OnTitleToggle(bool value)
		{
			_cityTitle.gameObject.SetActive(value);
			_scoreTitle.gameObject.SetActive(value);
		}

		[UsedImplicitly]
		public void OnChallengeIconToggled(bool value)
		{
			_challengeIconContainer.SetActive(value);
			_divider.SetActive(ShouldShowDivider);
		}

		public void OnChallengeCycled(int value)
		{
			if (_game?.Simulation != null)
			{
				if (_game.Simulation.GetModel<ActiveChallengesModel>().IsCityChallenge)
				{
					SetCityChallengeConfiguration(value);
					return;
				}
				SetTimedChallengeConfiguration(value);
				LayoutRebuilder.ForceRebuildLayoutImmediate(_challengeTitleText.transform.parent.GetComponent<RectTransform>());
			}
		}

		private void SetCityChallengeConfiguration(int configIndex)
		{
			_challengeDateText.gameObject.SetActive(value: false);
			switch (configIndex)
			{
			case 0:
				_challengeTitleText.gameObject.SetActive(value: false);
				_challengeIconContainer.SetActive(value: false);
				break;
			case 1:
				ChallengeTextParent.SetActive(value: true);
				_challengeTitleText.gameObject.SetActive(value: true);
				_challengeIconContainer.SetActive(value: false);
				break;
			case 2:
				ChallengeTextParent.SetActive(value: true);
				_challengeTitleText.gameObject.SetActive(value: true);
				_challengeIconContainer.SetActive(value: true);
				break;
			case 3:
				ChallengeTextParent.SetActive(value: false);
				_challengeTitleText.gameObject.SetActive(value: false);
				_challengeIconContainer.SetActive(value: true);
				break;
			}
		}

		private void SetTimedChallengeConfiguration(int configIndex)
		{
			switch (configIndex)
			{
			case 0:
				_challengeTitleText.gameObject.SetActive(value: false);
				_challengeIconContainer.SetActive(value: false);
				_challengeDateText.gameObject.SetActive(value: false);
				break;
			case 1:
				ChallengeTextParent.SetActive(value: true);
				_challengeTitleText.gameObject.SetActive(value: true);
				_challengeIconContainer.SetActive(value: true);
				_challengeDateText.gameObject.SetActive(value: false);
				break;
			case 2:
				ChallengeTextParent.SetActive(value: true);
				_challengeTitleText.gameObject.SetActive(value: true);
				_challengeIconContainer.SetActive(value: true);
				_challengeDateText.gameObject.SetActive(value: true);
				break;
			case 3:
				ChallengeTextParent.SetActive(value: true);
				_challengeTitleText.gameObject.SetActive(value: true);
				_challengeIconContainer.SetActive(value: false);
				_challengeDateText.gameObject.SetActive(value: true);
				break;
			case 4:
				ChallengeTextParent.SetActive(value: true);
				_challengeTitleText.gameObject.SetActive(value: true);
				_challengeIconContainer.SetActive(value: false);
				_challengeDateText.gameObject.SetActive(value: false);
				break;
			case 5:
				ChallengeTextParent.SetActive(value: false);
				_challengeTitleText.gameObject.SetActive(value: false);
				_challengeIconContainer.SetActive(value: true);
				_challengeDateText.gameObject.SetActive(value: false);
				break;
			}
		}

		public override void Reset()
		{
			base.Reset();
			isToolbarVisible = false;
			_isToolbarVisibilityChangeScheduled = false;
			_scheduledToolbarVisibility = false;
		}

		private void SetTimedFramesActive()
		{
			DateTime dateTime = new DateTime(GameDateTime.LocalNow.Year, 11, 8);
			DateTime dateTime2 = new DateTime(GameDateTime.LocalNow.Year, 12, 22);
			DateTime dateTime3 = new DateTime(GameDateTime.LocalNow.Year, 1, 5);
			_frameOptionButton.UnskipOption(4);
			_frameOptionButton.UnskipOption(5);
			_frameOptionButton.UnskipOption(6);
			if (!(GameDateTime.LocalNow > dateTime) && !(GameDateTime.LocalNow < dateTime3))
			{
				_frameOptionButton.SkipOption(4);
				_frameOptionButton.SkipOption(5);
			}
			if (!(GameDateTime.LocalNow > dateTime2) && !(GameDateTime.LocalNow < dateTime3))
			{
				_frameOptionButton.SkipOption(6);
			}
		}
	}
}
