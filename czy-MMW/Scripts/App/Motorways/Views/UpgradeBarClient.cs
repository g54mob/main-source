using System;
using Client;
using Factory;
using Motorways.Models;
using Motorways.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class UpgradeBarClient : MonoBehaviour, IView, ICreatedInScopeHandler, IReleasedFromScopeHandler
	{
		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("AssetBarClient");

		[Dependency]
		private IScope _scope;

		[Dependency]
		private City _city;

		[Dependency]
		protected GameUIScreen _gameUI;

		[Dependency]
		private ViewClient _viewClient;

		[Dependency]
		private ClockModel _clockModel;

		[Dependency]
		protected ClientUpgradeDatabase _clientUpgrades;

		[Dependency]
		private PlayerActionController _playerActionController;

		[Dependency]
		private MotorwaysThemeDatabase _theme;

		[Dependency]
		private VisualConstantsData _constants;

		[Dependency]
		private GameBehaviourModel _behaviour;

		[Dependency]
		protected ScreenStack _screenStack;

		[FormerlySerializedAs("upgradeButtons")]
		[EnumTypedArray(typeof(UpgradeType))]
		[SerializeField]
		[NonReorderable]
		protected UpgradeButton[] _upgradeButtons;

		[EnumTypedArray(typeof(UpgradeType))]
		[NonReorderable]
		[SerializeField]
		[FormerlySerializedAs("upgradeButtonStacks")]
		protected UpgradeButtonStack[] _upgradeButtonStacks = new UpgradeButtonStack[9];

		[SerializeField]
		[EnumTypedArray(typeof(UpgradeType))]
		[NonReorderable]
		protected FloatingElement[] _floatingUpgradeButtons = new FloatingElement[9];

		[NonSerialized]
		[EnumTypedArray(typeof(UpgradeType))]
		protected bool[] _upgradeHasBeenAwarded = new bool[9];

		[SerializeField]
		private GameObject _dividerObject;

		[SerializeField]
		private GameObject _dividerObjectInactive;

		[SerializeField]
		private GameObject _concreteSpacer;

		[SerializeField]
		private GameObject _concreteSpacerInactive;

		[SerializeField]
		private GameObject _bridgeSpacer;

		[SerializeField]
		private GameObject _bridgeSpacerInactive;

		public float UpgradeAlertSize = 4f;

		public float AlertAlpha = 0.6f;

		private bool _hasDoneRuleBasedInitialization;

		public bool IsVisible { get; protected set; }

		private bool HasBeenAwardedPlaceableAsset
		{
			get
			{
				if (!_upgradeHasBeenAwarded[4] && !_upgradeHasBeenAwarded[2])
				{
					return _upgradeHasBeenAwarded[3];
				}
				return true;
			}
		}

		public void DeselectButtons()
		{
			UpgradeButton[] upgradeButtons = _upgradeButtons;
			for (int i = 0; i < upgradeButtons.Length; i++)
			{
				upgradeButtons[i].ClearSelectionState();
			}
			UpgradeButtonStack[] upgradeButtonStacks = _upgradeButtonStacks;
			for (int i = 0; i < upgradeButtonStacks.Length; i++)
			{
				upgradeButtonStacks[i].DoStateTransition(ButtonAnimationState.Normal, instant: false);
			}
		}

		public virtual TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (!_hasDoneRuleBasedInitialization && _behaviour.HasGotRules())
			{
				for (int i = 0; i < 9; i++)
				{
					UpgradeType type = (UpgradeType)i;
					if (_behaviour.HasUnlimitedOfUpgrade(type))
					{
						_upgradeHasBeenAwarded[i] = true;
					}
					int accountedIconNumber = _upgradeButtonStacks[i].AccountedIconNumber;
					int delta = _clientUpgrades.GetAvailableOrDraftUpgradeCount((UpgradeType)i) - accountedIconNumber;
					OnUpgradeChanged(type, delta);
				}
				_hasDoneRuleBasedInitialization = true;
			}
			for (int j = 0; j < 9; j++)
			{
				int accountedIconNumber2 = _upgradeButtonStacks[j].AccountedIconNumber;
				int delta2 = _clientUpgrades.GetAvailableOrDraftUpgradeCount((UpgradeType)j) - accountedIconNumber2;
				OnUpgradeChanged((UpgradeType)j, delta2);
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void RefreshAllAvailableUpgradeStacks()
		{
			for (int i = 0; i < 9; i++)
			{
				UpgradeType type = (UpgradeType)i;
				_upgradeButtonStacks[i].IsUnlimited = _behaviour.HasUnlimitedOfUpgrade(type);
			}
		}

		protected virtual void OnUpgradeChanged(UpgradeType type, int delta)
		{
			if (_behaviour.ShouldHideStaticUpgrades && (type == UpgradeType.Concrete || type == UpgradeType.Bridge || type == UpgradeType.Tunnel))
			{
				return;
			}
			_upgradeButtonStacks[(int)type].IsUnlimited = _behaviour.HasUnlimitedOfUpgrade(type);
			_upgradeButtonStacks[(int)type].ShowNumberCounter = _behaviour.ShouldShowUpgradeCount();
			_upgradeHasBeenAwarded[(int)type] |= _clientUpgrades.GetTotalUpgradeCount(type) > 0;
			if (_upgradeHasBeenAwarded[(int)type] && !_floatingUpgradeButtons[(int)type].BaseElementActive)
			{
				SetUpgradeButtonVisible(type, IsVisible);
				SetCreativeModeColourWidgetVisible(IsVisible);
				if (_upgradeButtons[(int)type] != null)
				{
					_upgradeButtons[(int)type].enabled = true;
				}
				if (_dividerObject != null)
				{
					_dividerObject.SetActive(IsVisible && HasBeenAwardedPlaceableAsset && !_behaviour.ShouldHideStaticUpgrades);
				}
			}
			if (delta > 0)
			{
				_upgradeButtonStacks[(int)type].AddToStack(delta);
			}
			else if (delta < 0)
			{
				if (_upgradeButtonStacks[(int)type].PendingAdditionCount > 0)
				{
					_upgradeButtonStacks[(int)type].PendingAdditionCount -= Math.Abs(delta);
				}
				else
				{
					_upgradeButtonStacks[(int)type].RemoveFromStack(Math.Abs(delta));
				}
			}
		}

		public void OnAssetButtonPressed(float pressTime, GameUIButtonType upgradeType, int pointerIndex, IController onController)
		{
			Log.Info("OnAssetButtonPressed, from pointerIndex {0}", pointerIndex);
			if (Diagnostics.Verify(_scope != null))
			{
				float timestamp = pressTime;
				InputEvent inputEvent;
				if (onController == null)
				{
					inputEvent = ((pointerIndex >= 0) ? MotorwaysUIInputEvent.CreateTouchUIEvent(_scope, pointerIndex, InputEventButtonState.JustDown, upgradeType) : MotorwaysUIInputEvent.CreateMouseUIEvent(_scope, (InputEventMouseButtonType)(-pointerIndex - 1), InputEventButtonState.JustDown, upgradeType));
				}
				else
				{
					inputEvent = MotorwaysUIInputEvent.CreateGenericUIEvent(_scope, 2, onController.GetInputSource(), InputEventButtonState.JustDown, upgradeType);
					timestamp = (float)_clockModel.Time;
				}
				_playerActionController.OnInputEvent(timestamp, inputEvent);
			}
		}

		public void CreateAlertOnUpgradeButton(UpgradeType upgradeButtonType)
		{
			AlertView.Create(_viewClient, _floatingUpgradeButtons[(int)upgradeButtonType].baseElement.transform.position, _theme.GetGlobalColor(_constants.UpgradeAlertColor), UpgradeAlertSize, 1f, AlertAlpha);
		}

		public virtual void OnCreatedInScope(IScope scope)
		{
			_hasDoneRuleBasedInitialization = false;
			UpgradeButton[] upgradeButtons = _upgradeButtons;
			foreach (UpgradeButton upgradeButton in upgradeButtons)
			{
				if (upgradeButton != null)
				{
					Log.Info("Binding press event for {0}", upgradeButton.buttonType);
					upgradeButton.onPressed = (UpgradeButton.OnAssetButtonPressed)Delegate.Combine(upgradeButton.onPressed, new UpgradeButton.OnAssetButtonPressed(OnAssetButtonPressed));
				}
			}
			HideUpgradeButtons();
			SetVisibility(isVisible: false, instantly: true);
		}

		public virtual void OnReleasedFromScope(IScope scope)
		{
			UpgradeButton[] upgradeButtons = _upgradeButtons;
			foreach (UpgradeButton upgradeButton in upgradeButtons)
			{
				if (upgradeButton != null)
				{
					Log.Info("Unbinding press event for {0}", upgradeButton.buttonType);
					upgradeButton.onPressed = (UpgradeButton.OnAssetButtonPressed)Delegate.Remove(upgradeButton.onPressed, new UpgradeButton.OnAssetButtonPressed(OnAssetButtonPressed));
				}
			}
			IsVisible = false;
			HideUpgradeButtons();
			SetVisibility(isVisible: false, instantly: true);
			for (int j = 0; j < _upgradeButtonStacks.Length; j++)
			{
				_upgradeButtonStacks[j].SetCount(0);
				_upgradeButtonStacks[j].IsUnlimited = false;
			}
			Array.Clear(_upgradeHasBeenAwarded, 0, _upgradeHasBeenAwarded.Length);
		}

		public virtual void SetVisibility(bool isVisible, bool instantly = false)
		{
			IsVisible = isVisible;
			if (instantly)
			{
				for (int i = 0; i < _floatingUpgradeButtons.Length; i++)
				{
					bool visible = IsVisible && _upgradeHasBeenAwarded[i];
					SetUpgradeButtonVisible((UpgradeType)i, visible);
				}
			}
			SetCreativeModeColourWidgetVisible(isVisible);
			if (_dividerObject != null)
			{
				_dividerObject.SetActive(!_behaviour.ShouldHideStaticUpgrades && IsVisible && HasBeenAwardedPlaceableAsset);
				_dividerObjectInactive.SetActive(!_behaviour.ShouldHideStaticUpgrades);
				_concreteSpacer.SetActive(!_behaviour.ShouldHideStaticUpgrades);
				_concreteSpacerInactive.SetActive(!_behaviour.ShouldHideStaticUpgrades);
				_bridgeSpacer.SetActive(!_behaviour.ShouldHideStaticUpgrades);
				_bridgeSpacerInactive.SetActive(!_behaviour.ShouldHideStaticUpgrades);
			}
		}

		public void SetCreativeModeColourWidgetVisible(bool visible)
		{
			if (_city.Rules != null && _city.Rules.ShowColourWidget)
			{
				_gameUI.ColourWidget.FloatingElement.baseElement.SetActive(visible);
				_gameUI.ColourWidget.FloatingElement.InactiveAnchor.SetActive(visible);
			}
		}

		protected virtual void HideUpgradeButtons()
		{
			for (int i = 0; i < _floatingUpgradeButtons.Length; i++)
			{
				if (_floatingUpgradeButtons[i] != null)
				{
					SetUpgradeButtonVisible((UpgradeType)i, visible: false);
					if (_upgradeButtons[i] != null)
					{
						_upgradeButtons[i].enabled = false;
					}
				}
			}
			SetCreativeModeColourWidgetVisible(visible: false);
			if (_dividerObject != null)
			{
				_dividerObject.SetActive(value: false);
			}
		}

		public virtual void SetUpgradeButtonVisible(UpgradeType type, bool visible)
		{
			if ((type == UpgradeType.Concrete || type == UpgradeType.Bridge || type == UpgradeType.Tunnel) && _behaviour.ShouldHideStaticUpgrades)
			{
				visible = false;
			}
			_floatingUpgradeButtons[(int)type].baseElement.SetActive(visible);
			_floatingUpgradeButtons[(int)type].InactiveAnchor.SetActive(visible);
		}

		protected bool IsUpgradeButtonVisible(UpgradeType type)
		{
			return _floatingUpgradeButtons[(int)type].IsActive;
		}

		public virtual void AddToUpgradeButtonStack(UpgradeType type, bool fromAnimation = false, int count = 1)
		{
			_upgradeButtonStacks[(int)type].AddToStack(count, fromAnimation);
			_upgradeHasBeenAwarded[(int)type] = true;
		}

		public virtual void AddPendingToUpgradeButtonStack(UpgradeType type, int count = 1)
		{
			_upgradeButtonStacks[(int)type].PendingAdditionCount += count;
		}

		public virtual void RemoveFromUpgradeButtonStack(UpgradeType type, bool fromAnimation = false)
		{
			_upgradeButtonStacks[(int)type].RemoveFromStack(1, fromAnimation);
		}

		public Selectable GetFirstUpgradeIconSelectable()
		{
			int num = -1;
			for (int i = 0; i < 9; i++)
			{
				if (_upgradeButtons[i] != null && _floatingUpgradeButtons[i].BaseElementActive)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return null;
			}
			return _upgradeButtons[num].GetComponent<TouchButton>();
		}

		public virtual void PulseUpgradeIcon(UpgradeType type)
		{
			_upgradeButtonStacks[(int)type].GetTopIcon().Pulse();
		}

		public virtual void BounceUpgrade(UpgradeType type)
		{
			if (!_floatingUpgradeButtons[(int)type].IsActive)
			{
				SetUpgradeButtonVisible(type, visible: true);
			}
			if (_upgradeButtonStacks[(int)type] is UpgradeButtonCount upgradeButtonCount)
			{
				upgradeButtonCount.Bounce();
			}
		}

		public RectTransform GetRectTransformForUpgrade(UpgradeType type)
		{
			return _floatingUpgradeButtons[(int)type].GetComponent<RectTransform>();
		}

		public Sprite GetSpriteForUpgradeType(UpgradeType type)
		{
			return _upgradeButtonStacks[(int)type].referenceImage.sprite;
		}

		public bool IsSpriteForUpgradeACircle(UpgradeType type)
		{
			return _upgradeButtonStacks[(int)type].IsCircle;
		}
	}
}
