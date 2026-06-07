using Client;
using Factory;
using Motorways.Audio;
using Motorways.Models;
using Motorways.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class UpgradeBarClientHorizontal : UpgradeBarClient, InputState.IObserver
	{
		[Dependency]
		private ActivePlayer _player;

		[Dependency]
		protected InputState _inputState;

		[Dependency]
		private GameBehaviourModel _behaviour;

		[Dependency]
		private City _city;

		private float _timeConcreteButtonAppeared;

		private float _timeNonConcreteButtonAppeared;

		[SerializeField]
		private FloatingElement _entireBar;

		[SerializeField]
		private FloatingElement _handleAnchor;

		[SerializeField]
		private UpgradeBarHorizontalAnchorSizer _anchorSizer;

		[SerializeField]
		private TouchToggle _lockButton;

		[SerializeField]
		private Sprite _lockButtonLockedSprite;

		[SerializeField]
		private Sprite _lockButtonUnlockedSprite;

		[SerializeField]
		private CanvasGroup _lockLineCanvasGroup;

		[SerializeField]
		private TouchButton _hudDotButton;

		private bool _isLocked;

		[SerializeField]
		private float DurationToKeepUpgradeElementsOnScreenAfterUse = 3f;

		[SerializeField]
		private float LockLineAlphaSpeed = 2f;

		[SerializeField]
		private float AppearDelayAfterPointerEnter = 1f;

		[SerializeField]
		private RectTransform _rectTransform;

		[SerializeField]
		private RectTransform _activateHitboxRectTransform;

		[SerializeField]
		private RectTransform _deactivateHitboxRectTransform;

		private float _lastTimePointerEnteredAppearHitbox;

		private bool _appearHitboxTimerEnabled;

		private bool _pointerOverAppearHitbox;

		private bool _hudAnimationsEnabled;

		public bool IsLocked => _isLocked;

		private float GetTimeUpgradeButtonAppeared(UpgradeType upgradeType)
		{
			if (upgradeType == UpgradeType.Concrete)
			{
				return _timeConcreteButtonAppeared;
			}
			return _timeNonConcreteButtonAppeared;
		}

		private void SetTimeUpgradeButtonAppeared(UpgradeType upgradeType, float time)
		{
			if (upgradeType == UpgradeType.Concrete)
			{
				_timeConcreteButtonAppeared = time;
			}
			else
			{
				_timeNonConcreteButtonAppeared = time;
			}
		}

		protected override void OnUpgradeChanged(UpgradeType type, int delta)
		{
			if (delta != 0 && _hudAnimationsEnabled)
			{
				if (!_upgradeHasBeenAwarded[(int)type])
				{
					MakeNewUpgradeAppear(type);
				}
				if (!_behaviour.HasUnlimitedOfUpgrade(type))
				{
					SetUpgradeButtonVisible(type, visible: true);
				}
			}
			base.OnUpgradeChanged(type, delta);
			_anchorSizer.UpdateSizing();
		}

		public override TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_screenStack.IsScreenInStack(ScreenStack.MotorwaysScreen.Upgrade))
			{
				for (int i = 0; i < 9; i++)
				{
					if (_upgradeHasBeenAwarded[i])
					{
						SetUpgradeButtonVisible((UpgradeType)i, visible: true);
					}
				}
				SetCreativeModeColourWidgetVisible(visible: true);
			}
			else
			{
				TickUpgradesHud();
			}
			return base.Tick(timeInterval, stepAlpha);
		}

		private void TickUpgradesHud()
		{
			bool isHudUp = AreUpgradesShowing();
			if (!_handleAnchor.IsAnimating)
			{
				TickUpgradeHudVisibility(isHudUp);
			}
			TickUpgradeHudHitboxes(isHudUp);
			_lockLineCanvasGroup.alpha = Mathf.Clamp01(_lockLineCanvasGroup.alpha + Time.deltaTime * (_pointerOverAppearHitbox ? LockLineAlphaSpeed : (0f - LockLineAlphaSpeed)));
		}

		private void TickUpgradeHudVisibility(bool isHudUp)
		{
			if (isHudUp)
			{
				if (_isLocked)
				{
					return;
				}
				if (PointerInRectTransform(_rectTransform) || (_city.Rules.ShowColourWidget && PointerInRectTransform(_gameUI.ColourWidget.RectTransform)))
				{
					bool flag = false;
					for (UpgradeType upgradeType = UpgradeType.Concrete; upgradeType < UpgradeType.Count; upgradeType++)
					{
						if (_upgradeHasBeenAwarded[(int)upgradeType] && !IsUpgradeButtonVisible(upgradeType))
						{
							SetUpgradeButtonVisible(upgradeType, visible: true);
							flag = true;
						}
					}
					if (!flag)
					{
						return;
					}
					for (UpgradeType upgradeType2 = UpgradeType.Concrete; upgradeType2 < UpgradeType.Count; upgradeType2++)
					{
						if (IsUpgradeButtonVisible(upgradeType2))
						{
							SetTimeUpgradeButtonAppeared(upgradeType2, Time.time);
						}
					}
					return;
				}
				for (UpgradeType upgradeType3 = UpgradeType.Concrete; upgradeType3 < UpgradeType.Count; upgradeType3++)
				{
					if (IsUpgradeButtonVisible(upgradeType3) && Time.time - GetTimeUpgradeButtonAppeared(upgradeType3) > DurationToKeepUpgradeElementsOnScreenAfterUse)
					{
						if (_upgradeButtonStacks[(int)upgradeType3].PendingAdditionCount == 0)
						{
							SetUpgradeButtonVisible(upgradeType3, visible: false);
						}
						SetCreativeModeColourWidgetVisible(visible: false);
					}
				}
			}
			else if (_pointerOverAppearHitbox)
			{
				if (Time.time - _lastTimePointerEnteredAppearHitbox > AppearDelayAfterPointerEnter && _appearHitboxTimerEnabled)
				{
					ShowAllAvailableUpgrades(playSound: true);
				}
			}
			else if (!_appearHitboxTimerEnabled && _hudAnimationsEnabled && !PointerInRectTransform(_rectTransform) && !PointerInRectTransform(_gameUI.ColourWidget.RectTransform))
			{
				_appearHitboxTimerEnabled = true;
			}
		}

		private void TickUpgradeHudHitboxes(bool isHudUp)
		{
			RectTransform rectTransform;
			if (isHudUp)
			{
				rectTransform = _deactivateHitboxRectTransform;
				_activateHitboxRectTransform.gameObject.SetActive(value: false);
				_deactivateHitboxRectTransform.gameObject.SetActive(value: true);
			}
			else
			{
				rectTransform = _activateHitboxRectTransform;
				_deactivateHitboxRectTransform.gameObject.SetActive(value: false);
				_activateHitboxRectTransform.gameObject.SetActive(value: true);
			}
			bool pointerOverAppearHitbox = _pointerOverAppearHitbox;
			_pointerOverAppearHitbox = PointerInRectTransform(rectTransform) || (_city.Rules.ShowColourWidget && PointerInRectTransform(_gameUI.ColourWidget.HitboxRect));
			if (pointerOverAppearHitbox != _pointerOverAppearHitbox)
			{
				_lockButton.interactable = _pointerOverAppearHitbox;
				if (_pointerOverAppearHitbox)
				{
					_lastTimePointerEnteredAppearHitbox = Time.time;
				}
			}
			if (_pointerOverAppearHitbox)
			{
				_hudDotButton.animator.SetTrigger(_hudDotButton.animationTriggers.highlightedTrigger);
				return;
			}
			_hudDotButton.animator.ResetTrigger(_hudDotButton.animationTriggers.highlightedTrigger);
			_hudDotButton.animator.SetTrigger(_hudDotButton.animationTriggers.normalTrigger);
		}

		private bool PointerInRectTransform(RectTransform rectTransform)
		{
			Vector2 screenPoint = (_gameUI.IsFocusPointActive ? _gameUI.FocusPointPosition : _inputState.Mouse.Position);
			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPoint, Camera.main, out var localPoint))
			{
				return false;
			}
			return rectTransform.rect.Contains(localPoint);
		}

		public override void SetUpgradeButtonVisible(UpgradeType type, bool visible)
		{
			if (visible)
			{
				if (type == UpgradeType.Concrete)
				{
					bool flag = !_behaviour.ShouldHideStaticUpgrades;
					if (flag)
					{
						SetTimeUpgradeButtonAppeared(UpgradeType.Concrete, Time.time);
					}
					_upgradeButtons[(int)type].enabled = flag;
					base.SetUpgradeButtonVisible(type, flag);
					_floatingUpgradeButtons[(int)type].IsActive = flag;
				}
				else
				{
					for (UpgradeType upgradeType = UpgradeType.Concrete; upgradeType < UpgradeType.Count; upgradeType++)
					{
						int num = (int)upgradeType;
						bool flag2 = _upgradeHasBeenAwarded[num] || type == upgradeType;
						if ((upgradeType == UpgradeType.Concrete || upgradeType == UpgradeType.Bridge || upgradeType == UpgradeType.Tunnel) && _behaviour.ShouldHideStaticUpgrades)
						{
							flag2 = false;
						}
						if (flag2)
						{
							SetTimeUpgradeButtonAppeared(upgradeType, Time.time);
							_upgradeButtons[num].enabled = true;
							base.SetUpgradeButtonVisible(upgradeType, visible: true);
							_floatingUpgradeButtons[num].IsActive = true;
						}
					}
				}
			}
			else if (type == UpgradeType.Concrete)
			{
				for (UpgradeType upgradeType2 = UpgradeType.Concrete; upgradeType2 < UpgradeType.Count; upgradeType2++)
				{
					_floatingUpgradeButtons[(int)upgradeType2].IsActive = false;
				}
			}
			else
			{
				for (UpgradeType upgradeType3 = UpgradeType.Bridge; upgradeType3 < UpgradeType.Count; upgradeType3++)
				{
					_floatingUpgradeButtons[(int)upgradeType3].IsActive = false;
				}
			}
			CheckHandlePosition();
		}

		public override void AddToUpgradeButtonStack(UpgradeType type, bool fromAnimation = false, int count = 1)
		{
			base.AddToUpgradeButtonStack(type, fromAnimation, count);
			if (fromAnimation)
			{
				SetUpgradeButtonVisible(type, visible: true);
			}
			_anchorSizer.UpdateSizing();
		}

		private void MakeNewUpgradeAppear(UpgradeType type)
		{
			_upgradeButtonStacks[(int)type].SetCount(0);
			_upgradeButtons[(int)type].enabled = true;
			_upgradeButtons[(int)type]._upgradeIcon.SetVisible(nowVisible: false);
			_upgradeButtons[(int)type]._upgradeIcon.SetVisible(nowVisible: true, TransitionStyle.Tween);
			SetUpgradeButtonVisible(type, visible: true);
			Canvas.ForceUpdateCanvases();
			_floatingUpgradeButtons[(int)type].Snap();
			_upgradeHasBeenAwarded[(int)type] = true;
		}

		protected override void HideUpgradeButtons()
		{
			base.HideUpgradeButtons();
			for (int i = 0; i < _floatingUpgradeButtons.Length; i++)
			{
				base.SetUpgradeButtonVisible((UpgradeType)i, visible: false);
			}
		}

		public override void SetVisibility(bool isVisible, bool instantly = false)
		{
			if (_behaviour.HasGotRules())
			{
				bool enableLeftGroup = true;
				bool enableCenterGroup = !_behaviour.ShouldHideStaticUpgrades;
				bool enableRightGroup = !_behaviour.ShouldHideStaticUpgrades;
				_anchorSizer.ToggleUpgradeGroups(enableLeftGroup, enableCenterGroup, enableRightGroup);
			}
			_entireBar.IsActive = isVisible;
			if (instantly)
			{
				_entireBar.transform.position = (isVisible ? _entireBar.baseElement.transform.position : _entireBar.InactiveAnchor.transform.position);
			}
			if (!_hudAnimationsEnabled && isVisible)
			{
				_hudAnimationsEnabled = true;
				if (_player.DoesHudStartLocked)
				{
					ShowAllAvailableUpgrades();
					OnLockToggled(locked: true);
				}
			}
			else if (_hudAnimationsEnabled && _isLocked && isVisible)
			{
				ShowAllAvailableUpgrades();
			}
			base.SetVisibility(isVisible, instantly);
		}

		public override void AddPendingToUpgradeButtonStack(UpgradeType type, int count = 1)
		{
			base.AddPendingToUpgradeButtonStack(type, count);
			if (!_upgradeHasBeenAwarded[(int)type])
			{
				MakeNewUpgradeAppear(type);
			}
			_anchorSizer.UpdateSizing();
		}

		public override void PulseUpgradeIcon(UpgradeType type)
		{
			base.PulseUpgradeIcon(type);
			SetUpgradeButtonVisible(type, visible: true);
		}

		public void CheckHandlePosition()
		{
			for (int i = 0; i < 9; i++)
			{
				if (IsUpgradeButtonVisible((UpgradeType)i))
				{
					_handleAnchor.IsActive = true;
					return;
				}
			}
			_handleAnchor.IsActive = false;
		}

		public void OnLockClicked()
		{
			if (!_handleAnchor.IsAnimating)
			{
				OnLockToggled(!_isLocked, saveLockedStateToProfile: true);
			}
		}

		public void OnLockToggled(bool locked, bool saveLockedStateToProfile = false)
		{
			if (saveLockedStateToProfile)
			{
				_player.DoesHudStartLocked = locked;
			}
			_isLocked = locked;
			if (_isLocked)
			{
				((Image)_lockButton.targetGraphic).sprite = _lockButtonLockedSprite;
				ShowAllAvailableUpgrades();
			}
			else
			{
				((Image)_lockButton.targetGraphic).sprite = _lockButtonUnlockedSprite;
			}
		}

		public void OnHandleClicked()
		{
			if (!_handleAnchor.IsAnimating)
			{
				if (AreUpgradesShowing())
				{
					HideAllUpgrades();
					OnLockToggled(locked: false, saveLockedStateToProfile: true);
				}
				else
				{
					ShowAllAvailableUpgrades(playSound: true);
				}
				_lastTimePointerEnteredAppearHitbox = Time.time;
			}
		}

		public void ShowHud(bool locked)
		{
			ShowAllAvailableUpgrades();
			if (locked)
			{
				OnLockToggled(locked: true, saveLockedStateToProfile: true);
				_lockLineCanvasGroup.alpha = 1f;
			}
		}

		public void HideHud()
		{
			HideHud(saveLockedStateToProfile: false);
		}

		public void HideHud(bool saveLockedStateToProfile)
		{
			OnLockToggled(locked: false, saveLockedStateToProfile);
			HideAllUpgrades();
		}

		private void ShowAllAvailableUpgrades(bool playSound = false)
		{
			for (int i = 0; i < 9; i++)
			{
				if (_upgradeHasBeenAwarded[i] && !_floatingUpgradeButtons[i].IsActive)
				{
					SetUpgradeButtonVisible((UpgradeType)i, visible: true);
				}
			}
			SetCreativeModeColourWidgetVisible(visible: true);
			if (playSound)
			{
				AudioPlayer.UI?.PlaySample("iso-ui-show-controls", 0.5f, 0.5f);
			}
		}

		private void HideAllUpgrades()
		{
			SetCreativeModeColourWidgetVisible(visible: false);
			for (int i = 0; i < 9; i++)
			{
				SetUpgradeButtonVisible((UpgradeType)i, visible: false);
			}
			AudioPlayer.UI?.PlaySample("iso-ui-hide-controls", 0.5f, 0.5f);
		}

		public bool AreUpgradesShowing()
		{
			for (UpgradeType upgradeType = UpgradeType.Concrete; upgradeType < UpgradeType.Count; upgradeType++)
			{
				if (IsUpgradeButtonVisible(upgradeType))
				{
					return true;
				}
			}
			return false;
		}

		public override void OnCreatedInScope(IScope scope)
		{
			base.OnCreatedInScope(scope);
			scope.Get<ColourWidget>().FloatingElement.IsActive = false;
			scope.Get<ColourWidget>().FloatingElement.baseElement.SetActive(value: false);
			scope.Get<ColourWidget>().FloatingElement.InactiveAnchor.SetActive(value: false);
			FloatingElement[] floatingUpgradeButtons = _floatingUpgradeButtons;
			for (int i = 0; i < floatingUpgradeButtons.Length; i++)
			{
				floatingUpgradeButtons[i].IsActive = false;
			}
			OnLockToggled(locked: false);
			_lockLineCanvasGroup.alpha = 0f;
			_hudAnimationsEnabled = false;
			_lastTimePointerEnteredAppearHitbox = 0f;
			_appearHitboxTimerEnabled = false;
			_inputState.Subscribe(this);
			RefreshHudAnchor();
			_anchorSizer.Initialize(scope);
		}

		public override void OnReleasedFromScope(IScope scope)
		{
			base.OnReleasedFromScope(scope);
			FloatingElement[] floatingUpgradeButtons = _floatingUpgradeButtons;
			for (int i = 0; i < floatingUpgradeButtons.Length; i++)
			{
				floatingUpgradeButtons[i].IsActive = false;
			}
			OnLockToggled(locked: false);
			_lockLineCanvasGroup.alpha = 0f;
			_timeConcreteButtonAppeared = 0f;
			_timeNonConcreteButtonAppeared = 0f;
			_hudAnimationsEnabled = false;
			_lastTimePointerEnteredAppearHitbox = 0f;
			_appearHitboxTimerEnabled = false;
			_inputState.Unsubscribe(this);
		}

		public void OnCurrentDeviceInputTypeChanged(DeviceInputType newInputType)
		{
			RefreshHudAnchor();
		}

		private void RefreshHudAnchor()
		{
			if (_inputState.CurrentDeviceInputType == DeviceInputType.Remote)
			{
				_handleAnchor.gameObject.SetActive(value: false);
				OnLockToggled(locked: true);
			}
			else
			{
				_handleAnchor.gameObject.SetActive(value: true);
			}
		}
	}
}
