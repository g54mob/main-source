using System.Collections;
using System.Collections.Generic;
using Client;
using Easing;
using Factory;
using Factory.Pools;
using Motorways;
using Motorways.Audio;
using Motorways.UI;
using Motorways.UI.NewContentIndicators;
using Popups;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Screens
{
	[RequireComponent(typeof(RectTransform))]
	public class BaseScalingScreen : MonoBehaviour, IScreen, InputState.IObserver, MenuNavigation.IObserver, IReusable, ICreatedInScopeHandler, IReleasedFromScopeHandler
	{
		public VariableDeviceSelectable firstFocus;

		public TouchButton backButton;

		public TouchButton previousBackButton;

		[Dependency]
		protected ScreenStack _screenStack;

		[Dependency]
		protected PopupStack popupStack;

		[Dependency]
		protected IScope _appScope;

		[Dependency]
		protected GameCamera _gameCamera;

		[Dependency]
		protected IAudioSystem _audioSystem;

		[Dependency]
		protected MotorwaysThemeDatabase _themeDatabase;

		[Dependency]
		protected ActivePlayer _player;

		[Dependency]
		protected MenuNavigation _navigation;

		[Dependency]
		protected InputState _inputState;

		[Dependency]
		private LocaleDatabase _localeDatabase;

		protected RectTransform _rectTransform;

		protected DelegateCanvasGroup _canvasGroup;

		protected Canvas _canvas;

		[SerializeField]
		protected bool _alignToCamera = true;

		[SerializeField]
		protected bool _scaleToCamera = true;

		private float _transitionInPercentage = -1f;

		private float _transitionOutPercentage = -1f;

		protected bool _skipTransitions;

		protected float _overrideNextTransitionDuration = -1f;

		private float _transitionDuration;

		protected ScreenTransition _transitionDetails;

		private Vector3 _previousCameraPosition;

		private Quaternion _previousCameraRotation;

		protected float _previousCameraZoom;

		protected static readonly Vector2 referenceResolution = new Vector2(1920f, 1080f);

		protected static readonly float referenceAspectRatio = 1.7777778f;

		private List<LocalizedTextUI> allLocalizedText = new List<LocalizedTextUI>();

		private List<VariableDeviceSelectable> _allButtons = new List<VariableDeviceSelectable>();

		[SerializeField]
		public List<IThemeComponent> themeComponents = new List<IThemeComponent>();

		private readonly List<IThemeComponent> _additionalThemeComponents = new List<IThemeComponent>();

		private readonly List<IThemeComponent> _dynamicThemeComponents = new List<IThemeComponent>();

		private ITheme _lastThemeBlendedFrom;

		private ITheme _lastThemeBlendedTo;

		[SerializeField]
		protected bool PopScreenAllowed = true;

		public ScreenStack.MotorwaysScreen ScreenType => _screenStack.GetScreenEnumForSystemType(GetType());

		public virtual void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
			_canvas = GetComponent<Canvas>();
			_canvasGroup = GetComponent<DelegateCanvasGroup>();
			_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: false);
			_canvasGroup.SetInteractable(isInteractable: false);
		}

		protected void RegisterAllLocalizedTextChildren()
		{
			UnregisterLocalizedTextChildren();
			GetComponentsInChildren(includeInactive: true, allLocalizedText);
			for (int i = 0; i < allLocalizedText.Count; i++)
			{
				if (!allLocalizedText[i].isInitialized)
				{
					allLocalizedText[i].HandleParentAllocated(_appScope);
				}
				_localeDatabase.AddLocalizedObject(allLocalizedText[i]);
			}
		}

		public void RegisterAdditionalLocalizedTextChildren(List<LocalizedTextUI> additionalLocalizedTexts)
		{
			allLocalizedText.AddRange(additionalLocalizedTexts);
			for (int i = 0; i < additionalLocalizedTexts.Count; i++)
			{
				if (!additionalLocalizedTexts[i].isInitialized)
				{
					additionalLocalizedTexts[i].HandleParentAllocated(_appScope);
				}
				_localeDatabase.AddLocalizedObject(additionalLocalizedTexts[i]);
			}
		}

		public void RegisterButtons()
		{
			GetComponentsInChildren(includeInactive: true, _allButtons);
			for (int i = 0; i < _allButtons.Count; i++)
			{
				if (!_allButtons[i].IsInitialized)
				{
					_allButtons[i].Initialize(_appScope);
				}
			}
		}

		public void RegisterAdditionalButtons(List<VariableDeviceSelectable> additionalButtons)
		{
			_allButtons.AddRange(additionalButtons);
			for (int i = 0; i < additionalButtons.Count; i++)
			{
				if (!additionalButtons[i].IsInitialized)
				{
					additionalButtons[i].Initialize(_appScope);
				}
			}
		}

		public virtual void RegisterThemeComponents(ITheme theme)
		{
			UnregisterThemeComponents();
			GetAutoThemeComponents(themeComponents);
			if (themeComponents != null)
			{
				foreach (IThemeComponent themeComponent in themeComponents)
				{
					themeComponent.InitializeTheme(_themeDatabase);
				}
			}
			MotorwaysThemeDatabase.Log.Info("Registering theme components for screen: {0}", base.gameObject.name);
			if (theme != null)
			{
				ApplyTheme(theme);
			}
		}

		protected virtual void GetAutoThemeComponents(List<IThemeComponent> components)
		{
			GetComponentsInChildren(includeInactive: true, components);
		}

		protected void UnregisterLocalizedTextChildren()
		{
			foreach (LocalizedTextUI item in allLocalizedText)
			{
				item.Unregister();
				_localeDatabase.RemoveLocalizedObject(item);
			}
			allLocalizedText.Clear();
		}

		protected void UnregisterButtons()
		{
			foreach (VariableDeviceSelectable allButton in _allButtons)
			{
				allButton.Unregister();
			}
			_allButtons.Clear();
		}

		protected virtual void UnregisterThemeComponents()
		{
			foreach (IThemeComponent themeComponent in themeComponents)
			{
				themeComponent.ReleaseTheme(_themeDatabase);
			}
			themeComponents.Clear();
		}

		public void RegisterAdditionalThemeComponents(List<IThemeComponent> additionalThemeComponents)
		{
			_additionalThemeComponents.AddRange(additionalThemeComponents);
			ITheme theme = _themeDatabase.GetTheme();
			foreach (IThemeComponent additionalThemeComponent in additionalThemeComponents)
			{
				additionalThemeComponent.InitializeTheme(_themeDatabase);
				if (theme != null)
				{
					additionalThemeComponent.ApplyTheme(theme);
				}
			}
		}

		public void UnregisterAdditionalThemeComponents(List<IThemeComponent> additionalThemeComponents)
		{
			foreach (IThemeComponent additionalThemeComponent in additionalThemeComponents)
			{
				_additionalThemeComponents.Remove(additionalThemeComponent);
				additionalThemeComponent.ReleaseTheme(_themeDatabase);
			}
		}

		public virtual void ApplyTheme(ITheme newTheme)
		{
			if (newTheme != null)
			{
				for (int i = 0; i < themeComponents.Count; i++)
				{
					if (ObjectUtils.IsNullOrDestroyed(themeComponents[i]))
					{
						themeComponents.RemoveAt(i);
						i--;
					}
					else
					{
						themeComponents[i].ApplyTheme(newTheme);
					}
				}
				for (int j = 0; j < _additionalThemeComponents.Count; j++)
				{
					if (ObjectUtils.IsNullOrDestroyed(_additionalThemeComponents[j]))
					{
						_additionalThemeComponents.RemoveAt(j);
						j--;
					}
					else
					{
						_additionalThemeComponents[j].ApplyTheme(newTheme);
					}
				}
			}
			else
			{
				MotorwaysThemeDatabase.Log.Warn("Trying to apply a null theme to screen {0}", base.gameObject.name);
			}
		}

		public virtual void ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			if (newTheme != null && oldTheme != null)
			{
				if (_lastThemeBlendedFrom != oldTheme || _lastThemeBlendedTo != newTheme)
				{
					_lastThemeBlendedFrom = oldTheme;
					_lastThemeBlendedTo = newTheme;
					_dynamicThemeComponents.Clear();
					for (int i = 0; i < themeComponents.Count; i++)
					{
						IThemeComponent themeComponent = themeComponents[i];
						if (ObjectUtils.IsNullOrDestroyed(themeComponent))
						{
							themeComponents.RemoveAt(i);
							i--;
						}
						else if (themeComponent.ApplyBlendedTheme(oldTheme, newTheme, progress) == ThemeBlendingResult.ContinueBlending)
						{
							_dynamicThemeComponents.Add(themeComponent);
						}
					}
				}
				else
				{
					for (int j = 0; j < _dynamicThemeComponents.Count; j++)
					{
						IThemeComponent themeComponent2 = _dynamicThemeComponents[j];
						if (ObjectUtils.IsNullOrDestroyed(themeComponent2))
						{
							_dynamicThemeComponents.RemoveAt(j);
							j--;
						}
						else
						{
							themeComponent2.ApplyBlendedTheme(oldTheme, newTheme, progress);
						}
					}
				}
				for (int k = 0; k < _additionalThemeComponents.Count; k++)
				{
					if (ObjectUtils.IsNullOrDestroyed(_additionalThemeComponents[k]))
					{
						_additionalThemeComponents.RemoveAt(k);
						k--;
					}
					else
					{
						_additionalThemeComponents[k].ApplyBlendedTheme(oldTheme, newTheme, progress);
					}
				}
			}
			else
			{
				MotorwaysThemeDatabase.Log.Warn("Trying to apply a null theme to screen " + base.gameObject.name);
			}
		}

		public virtual void Tick(float deltaTime)
		{
			if (IsTransitioningIn())
			{
				_transitionInPercentage = Mathf.Clamp01(_transitionInPercentage + TransitionInPercentageChange(deltaTime));
				TransitionInTick();
			}
			if (IsTransitioningOut())
			{
				_transitionOutPercentage = Mathf.Clamp01(_transitionOutPercentage + TransitionOutPercentageChange(deltaTime));
				TransitionOutTick();
			}
			if (_scaleToCamera)
			{
				ScaleToCamera();
			}
			if (_alignToCamera)
			{
				Bounds screenBounds = _gameCamera.GetScreenBounds();
				_rectTransform.position = new Vector3(screenBounds.center.x, screenBounds.center.y, _rectTransform.position.z);
			}
		}

		public virtual void ScaleToCamera()
		{
			Bounds screenBounds = _gameCamera.GetScreenBounds(referenceAspectRatio);
			float num = Mathf.Max(referenceAspectRatio, _gameCamera.AspectRatio);
			float num2 = Mathf.Min(referenceAspectRatio, _gameCamera.AspectRatio);
			Vector2 vector = (screenBounds.max - screenBounds.min) / referenceResolution * (num2 / num);
			_rectTransform.localScale = vector;
			float num3 = referenceResolution.y * (num / num2);
			_rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num3);
			_rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num3 * _gameCamera.AspectRatio);
		}

		protected void ScaleToGameCamera()
		{
			Bounds screenBounds = _gameCamera.GetScreenBounds();
			Vector2 vector = (screenBounds.max - screenBounds.min) / (_rectTransform.offsetMax - _rectTransform.offsetMin);
			_rectTransform.localScale = vector;
			_rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _gameCamera.Width);
			_rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _gameCamera.Height);
		}

		public virtual void Enable(bool shouldBeVisible)
		{
			ScreenStack.Log.Info(base.gameObject, shouldBeVisible ? "Enabling a {0} screen." : "Disabling a {0} screen.", GetType());
			base.gameObject.SetActive(shouldBeVisible);
			if (_scaleToCamera)
			{
				ScaleToCamera();
			}
		}

		public virtual void TransitionInTick()
		{
			float num = Easings.CubicEaseInOut(TransitionInPercentage());
			if (_transitionDetails.cameraControl.Contains(TransitionCameraControl.Position))
			{
				Vector3 position = _transitionDetails.spline.Evaluate(num);
				_gameCamera.SetPosition(position);
			}
			if (_transitionDetails.cameraControl.Contains(TransitionCameraControl.Rotation))
			{
				_gameCamera.transform.rotation = _transitionDetails.spline.EvaluateRotation(num);
			}
			if (_transitionDetails.cameraControl.Contains(TransitionCameraControl.Scale))
			{
				_gameCamera.OrthographicSize = Mathf.Lerp(_previousCameraZoom, _screenStack.GetZoomFor(ScreenType), Easings.SineEaseInOut(num));
			}
		}

		public virtual void TransitionOutTick()
		{
		}

		public virtual void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			base.gameObject.SetActive(value: true);
			_previousCameraPosition = _gameCamera.transform.position;
			_previousCameraRotation = _gameCamera.transform.rotation;
			_previousCameraZoom = _gameCamera.OrthographicSize;
			ScreenStack.Log.Info(base.gameObject, "Starting a transition into {0} screen.", GetType());
			_transitionInPercentage = 0f;
			_transitionOutPercentage = -1f;
			_appScope.Get<IInputState>().BlockAllInput = true;
			_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: false);
			_canvasGroup.SetInteractable(isInteractable: true);
			_transitionDetails = _screenStack.GetTransitionDetailsFrom(outScreen, ScreenType);
			_transitionDuration = _transitionDetails.duration;
			if (outScreen == ScreenStack.MotorwaysScreen.None)
			{
				_overrideNextTransitionDuration = 0f;
			}
			base.transform.rotation = _screenStack.GetRotationFor(ScreenType);
			Vector3 positionFor = _screenStack.GetPositionFor(ScreenType);
			positionFor.z = base.transform.position.z;
			base.transform.position = positionFor;
			_skipTransitions = _player.HasActivePlayer && _player.IsSkipTransitionsEnabled;
			bool condition = !_skipTransitions;
			switch (ScreenType)
			{
			case ScreenStack.MotorwaysScreen.GameOver:
				Get.State |= StateType.GameOver;
				condition = false;
				_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.GameOver));
				break;
			case ScreenStack.MotorwaysScreen.Photo:
			case ScreenStack.MotorwaysScreen.Movie:
				Get.State |= StateType.MenuPhoto;
				condition = false;
				if (outScreen == ScreenStack.MotorwaysScreen.GameOver)
				{
					Get.State |= StateType.GameOver;
				}
				break;
			case ScreenStack.MotorwaysScreen.Credits:
				Get.State |= StateType.Credits;
				break;
			case ScreenStack.MotorwaysScreen.InGame:
				Get.State |= StateType.GameActive;
				break;
			case ScreenStack.MotorwaysScreen.MainMenu:
				Get.State |= StateType.MenuMain;
				break;
			case ScreenStack.MotorwaysScreen.MapSelect:
				Get.State |= StateType.MenuMapSelect;
				break;
			case ScreenStack.MotorwaysScreen.OptionsMain:
				Get.State |= StateType.MenuOptions;
				break;
			case ScreenStack.MotorwaysScreen.Pause:
			case ScreenStack.MotorwaysScreen.ChallengeInfo:
				Get.State |= StateType.MenuPause;
				break;
			case ScreenStack.MotorwaysScreen.ResumeGame:
				Get.State |= StateType.MenuResume;
				break;
			case ScreenStack.MotorwaysScreen.Startup:
				condition = false;
				break;
			case ScreenStack.MotorwaysScreen.Upgrade:
				Get.State |= StateType.MenuUpgrades;
				condition = false;
				break;
			}
			ScreenStack.MotorwaysScreen screenType = ScreenType;
			if ((screenType == ScreenStack.MotorwaysScreen.MainMenu || (uint)(screenType - 5) <= 3u) && Get.Loadout != null && Get.Loadout.MusicData != null)
			{
				Get.Loadout.MusicData.Bass?.FadeOutAndStop(0.5);
				Get.Loadout.MusicData.Bass = AudioPlayer.Default?.PlaySample("bass_" + Note.SCALE[Get.Loadout.MusicData.CurrentScale.Key], 0.5f, 0.5f, Get.State.HasFlag(StateType.ModeNight) ? (-0.5f) : 1f, 0.5);
				int commonTones = Rando.Range(2, 5);
				if (outScreen == ScreenStack.MotorwaysScreen.Startup)
				{
					commonTones = Rando.Pick<int>(0, 1);
				}
				Get.Loadout.MusicData.UpdateNoteWindow(commonTones);
				if (outScreen != ScreenStack.MotorwaysScreen.Startup)
				{
					Get.Mixbus.BoingPitchInPlace(Rando.Range(0.5f, 1.5f), Rando.Range(4f, 12f), Settings.PITCH_BOING_IN_PLACE.Random(), Rando.Pick<float>(0f, 0.5f));
				}
			}
			_audioSystem.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.Transition, UIAudioProfile.None, GetTransitionDuration(), condition, null, ScreenType, outScreen));
			ITheme theme = _themeDatabase.GetTheme();
			if (theme != null)
			{
				ApplyTheme(theme);
			}
		}

		public virtual void TransitionOut(ScreenStack.MotorwaysScreen inScreen)
		{
			ScreenStack.Log.Info(base.gameObject, "Starting a transition out from {0} screen.", GetType());
			_transitionDetails = _screenStack.GetTransitionDetailsFrom(ScreenType, inScreen);
			_transitionDuration = _transitionDetails.duration;
			_transitionOutPercentage = 0f;
			_transitionInPercentage = -1f;
			_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: false);
			_canvasGroup.SetInteractable(isInteractable: false);
			switch (ScreenType)
			{
			case ScreenStack.MotorwaysScreen.GameOver:
				Get.State &= ~StateType.GameOver;
				break;
			case ScreenStack.MotorwaysScreen.Photo:
			case ScreenStack.MotorwaysScreen.Movie:
				Get.State &= ~StateType.MenuPhoto;
				break;
			case ScreenStack.MotorwaysScreen.Credits:
				Get.State &= ~StateType.Credits;
				break;
			case ScreenStack.MotorwaysScreen.InGame:
				Get.State &= ~StateType.GameActive;
				break;
			case ScreenStack.MotorwaysScreen.MainMenu:
				Get.State &= ~StateType.MenuMain;
				break;
			case ScreenStack.MotorwaysScreen.MapSelect:
				Get.State &= ~StateType.MenuMapSelect;
				break;
			case ScreenStack.MotorwaysScreen.OptionsMain:
				Get.State &= ~StateType.MenuOptions;
				break;
			case ScreenStack.MotorwaysScreen.Pause:
			case ScreenStack.MotorwaysScreen.ChallengeInfo:
				Get.State &= ~StateType.MenuPause;
				break;
			case ScreenStack.MotorwaysScreen.ResumeGame:
				Get.State &= ~StateType.MenuResume;
				break;
			case ScreenStack.MotorwaysScreen.Upgrade:
				Get.State &= ~StateType.MenuUpgrades;
				break;
			}
			_skipTransitions = _player.IsSkipTransitionsEnabled;
		}

		public float TransitionInPercentageChange(float deltaTime)
		{
			float transitionDuration = GetTransitionDuration();
			if (transitionDuration <= float.Epsilon)
			{
				return 1.1f;
			}
			return deltaTime * (1f / transitionDuration);
		}

		public float TransitionOutPercentageChange(float deltaTime)
		{
			float transitionDuration = GetTransitionDuration();
			if (transitionDuration <= float.Epsilon)
			{
				return 1.1f;
			}
			return deltaTime * (1f / transitionDuration);
		}

		public virtual float GetTransitionDuration()
		{
			if (_overrideNextTransitionDuration > 0f)
			{
				return _overrideNextTransitionDuration;
			}
			if (_skipTransitions || Mathf.Abs(_overrideNextTransitionDuration) < float.Epsilon)
			{
				return 0f;
			}
			return _transitionDuration;
		}

		public virtual float TransitionInPercentage()
		{
			return _transitionInPercentage;
		}

		public virtual float TransitionOutPercentage()
		{
			return _transitionOutPercentage;
		}

		public virtual bool IsTransitioningIn()
		{
			if (_transitionInPercentage >= 0f)
			{
				return _transitionInPercentage < 1f;
			}
			return false;
		}

		public virtual bool IsTransitioningOut()
		{
			if (_transitionOutPercentage >= 0f)
			{
				return _transitionOutPercentage < 1f;
			}
			return false;
		}

		public virtual void OnTransitionedIn()
		{
			_overrideNextTransitionDuration = -1f;
			_appScope.Get<IInputState>().BlockAllInput = false;
			ShowNewContentIndicators();
			OnGainedFocus();
		}

		protected void ShowNewContentIndicators()
		{
			List<VariableDeviceSelectable> list = new List<VariableDeviceSelectable>();
			List<VariableDeviceSelectable> list2 = new List<VariableDeviceSelectable>();
			List<VariableDeviceSelectable> list3 = new List<VariableDeviceSelectable>();
			List<VariableDeviceSelectable> list4 = new List<VariableDeviceSelectable>();
			HashSet<string> hashSet = new HashSet<string>();
			foreach (VariableDeviceSelectable allButton in _allButtons)
			{
				if (allButton.gameObject.activeInHierarchy)
				{
					if (allButton.IsNewContentItem(_appScope))
					{
						list.Add(allButton);
					}
					else if (allButton.IsNewContentContainer(_appScope))
					{
						list2.Add(allButton);
					}
				}
			}
			foreach (VariableDeviceSelectable item in list2)
			{
				if (!hashSet.Contains(item.NewContentId))
				{
					list3.Add(item);
					hashSet.UnionWith(item.ContainedNewContentIds);
				}
				else
				{
					list4.Add(item);
				}
			}
			foreach (VariableDeviceSelectable item2 in list)
			{
				if (!hashSet.Contains(item2.NewContentId))
				{
					list3.Add(item2);
				}
				else
				{
					list4.Add(item2);
				}
			}
			foreach (VariableDeviceSelectable item3 in list4)
			{
				if (!item3.IsManuallyTriggered)
				{
					item3.ShowNewContentIndicatorIfNeeded(playIntro: false);
				}
			}
			if (list3.Count > 0 && base.gameObject.activeInHierarchy)
			{
				StartCoroutine(ShowNewContentIndicatorIntrosIfNeeded(list3));
			}
		}

		private IEnumerator ShowNewContentIndicatorIntrosIfNeeded(List<VariableDeviceSelectable> newContentWithIntro)
		{
			NewContentData newContentData = _appScope.Get<NewContentData>();
			foreach (VariableDeviceSelectable item in newContentWithIntro)
			{
				if (!item.IsManuallyTriggered && item.ShowNewContentIndicatorIfNeeded(playIntro: true))
				{
					yield return new WaitForSeconds(newContentData.DelayBetweenNciIntros);
				}
			}
		}

		public virtual void OnTransitionedOut()
		{
			_overrideNextTransitionDuration = -1f;
			base.gameObject.SetActive(value: false);
		}

		public virtual void OnLostFocus()
		{
			_canvasGroup.SetInteractable(isInteractable: false);
			_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: false);
		}

		public virtual void OnGainedFocus()
		{
			_canvasGroup.SetInteractable(isInteractable: true);
			_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: true);
			if (firstFocus != null && _appScope.Get<InputState>().CurrentInputTypeRequiresFocus)
			{
				_navigation.SetNewFocus(firstFocus);
			}
		}

		public void SkipNextTransition()
		{
			_overrideNextTransitionDuration = 0f;
		}

		public void OverrideNextTransition(float duration)
		{
			_overrideNextTransitionDuration = duration;
		}

		public virtual void OnCreatedInScope(IScope scope)
		{
			base.gameObject.SetActive(value: true);
			RegisterAllLocalizedTextChildren();
			RegisterButtons();
			_inputState.Subscribe(this);
			_navigation.Subscribe(this);
			RegisterThemeComponents(_themeDatabase.GetTheme());
			if (_canvas != null)
			{
				_canvas.worldCamera = Camera.main;
			}
		}

		public virtual void Reset()
		{
			_overrideNextTransitionDuration = -1f;
			_transitionDuration = 0f;
			_previousCameraZoom = 0f;
			_skipTransitions = false;
			base.transform.localPosition = Vector3.zero;
			base.transform.localRotation = Quaternion.identity;
			base.transform.localScale = Vector3.one;
		}

		public virtual void OnReleasedFromScope(IScope scope)
		{
			ScreenStack.Log.Info(base.gameObject, "Releasing a {0} screen.", GetType());
			UnregisterLocalizedTextChildren();
			UnregisterButtons();
			UnregisterThemeComponents();
			_inputState.Unsubscribe(this);
			_navigation.Unsubscribe(this);
			base.gameObject.SetActive(value: false);
		}

		public bool IsVisible()
		{
			if (Mathf.Approximately(TransitionInPercentage(), 1f))
			{
				return Mathf.Approximately(TransitionOutPercentage(), -1f);
			}
			return false;
		}

		public virtual bool CanTransitionIn()
		{
			return true;
		}

		public virtual void BackActivated()
		{
			if (backButton != null)
			{
				backButton.OnSubmit(null);
			}
		}

		public virtual void PageSelected(Vector2 direction)
		{
		}

		public bool CanPopScreen()
		{
			return PopScreenAllowed;
		}

		public virtual void OnCurrentDeviceInputTypeChanged(DeviceInputType newInputType)
		{
			if (InputState.DeviceInputTypeRequiresFocus(newInputType))
			{
				_navigation.SetNewFocus(firstFocus);
			}
			else
			{
				_navigation.ClearFocus(allowAutomaticFocus: false);
			}
		}

		public void OnMoveCursorWithNullFocus()
		{
			if (this == (BaseScalingScreen)_screenStack.GetTopVisibleScreen())
			{
				_navigation.SetNewFocus(firstFocus);
			}
		}

		public virtual void OnMoveCursor(Selectable currentFocus, MoveDirection direction)
		{
		}

		public virtual Selectable OverrideAutomaticNavigation()
		{
			return null;
		}

		public static void SetNavigationOnRight(Selectable selectable, Selectable selectOnRight)
		{
			Navigation navigation = selectable.navigation;
			navigation.selectOnRight = selectOnRight;
			selectable.navigation = navigation;
		}

		public static void SetNavigationOnLeft(Selectable selectable, Selectable selectOnLeft)
		{
			Navigation navigation = selectable.navigation;
			navigation.selectOnLeft = selectOnLeft;
			selectable.navigation = navigation;
		}

		public static void SetNavigationOnUp(Selectable selectable, Selectable selectOnUp)
		{
			Navigation navigation = selectable.navigation;
			navigation.selectOnUp = selectOnUp;
			selectable.navigation = navigation;
		}

		public static void SetNavigationOnDown(Selectable selectable, Selectable selectOnDown)
		{
			Navigation navigation = selectable.navigation;
			navigation.selectOnDown = selectOnDown;
			selectable.navigation = navigation;
		}
	}
}
