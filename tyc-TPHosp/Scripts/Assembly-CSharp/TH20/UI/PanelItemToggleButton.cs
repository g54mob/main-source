using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class PanelItemToggleButton : PanelItem, IHUDSaveState
	{
		[SerializeField]
		private bool _saveState;

		[SerializeField]
		private float _buttonOffset;

		[SerializeField]
		private float _shadowInDepth;

		[SerializeField]
		private float _shadowOutDepth;

		[SerializeField]
		private Color _downColour = Color.white;

		[SerializeField]
		private Color _upColour = Color.white;

		[SerializeField]
		private Image _insetImage;

		[SerializeField]
		private Sprite _disabledSprite;

		[SerializeField]
		private Sprite _pressedSprite;

		[SerializeField]
		private Image _graphColorImage;

		private bool _enabled = true;

		private bool _doPositionAdjust;

		private bool _initialised;

		private ButtonAnimator _theButtonAnimator;

		private DynamicButton _theDynamicButton;

		private Image _theImage;

		private Shadow _theShadow;

		private Vector2 _downDepth;

		private Vector2 _downPos;

		private Vector2 _upDepth;

		private Vector2 _upPos;

		public int ButtonID { get; set; }

		public bool IsDown { get; private set; }

		public bool Enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				_enabled = value;
				if (!_enabled)
				{
					SetPressedState(state: false);
				}
				if ((bool)_theButtonAnimator)
				{
					_theButtonAnimator.enabled = _enabled;
					_theButtonAnimator.CurrentState = ((!_enabled) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
					if (!_enabled)
					{
						_theButtonAnimator.RefreshButtonSprite();
					}
				}
			}
		}

		public override void Setup()
		{
			base.Setup();
			if (!_initialised)
			{
				_theImage = GetComponent<Image>();
				_upPos = base.transform.localPosition;
				_downPos = _upPos + Vector2.one * _buttonOffset;
				_theButtonAnimator = GetComponent<ButtonAnimator>();
				if ((bool)_theButtonAnimator)
				{
					_theButtonAnimator.AddRefreshSpriteListener(RefreshImageSprite);
				}
				_theShadow = GetComponent<Shadow>();
				if ((bool)_theShadow)
				{
					_downDepth = new Vector2(_shadowInDepth, 0f - _shadowInDepth);
					_upDepth = new Vector2(_shadowOutDepth, 0f - _shadowOutDepth);
				}
				_doPositionAdjust = Mathf.Abs(_buttonOffset) > 0.1f;
				SetPressedState(state: false);
				_initialised = true;
			}
		}

		private void RefreshImageSprite(ButtonAnimator.State buttonState)
		{
			if ((bool)_theImage && (_theButtonAnimator == null || !_theButtonAnimator.PresetHasSprites))
			{
				switch (buttonState)
				{
				case ButtonAnimator.State.Selectable:
					_theImage.overrideSprite = null;
					break;
				case ButtonAnimator.State.Selected:
					_theImage.overrideSprite = _pressedSprite;
					break;
				case ButtonAnimator.State.Unselectable:
					_theImage.overrideSprite = _disabledSprite;
					break;
				}
			}
		}

		public void SetPressedState(bool state)
		{
			if (!_enabled)
			{
				return;
			}
			IsDown = state;
			if (!_theButtonAnimator || _theButtonAnimator.enabled)
			{
				if (_doPositionAdjust)
				{
					base.transform.localPosition = (state ? _downPos : _upPos);
				}
				if ((bool)_insetImage)
				{
					_insetImage.enabled = state;
				}
				if ((bool)_theShadow)
				{
					_theShadow.effectDistance = (state ? _downDepth : _upDepth);
				}
				if ((bool)_theButtonAnimator)
				{
					_theButtonAnimator.CurrentState = (state ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
				}
				if ((bool)_theImage)
				{
					_theImage.color = (state ? _downColour : _upColour);
				}
			}
		}

		public void AddButtonListener(UnityAction call)
		{
			if (_theDynamicButton == null)
			{
				_theDynamicButton = GetComponent<DynamicButton>();
			}
			if (_theDynamicButton != null)
			{
				_theDynamicButton.onPrimaryDown.AddListener(call);
			}
		}

		public void RemoveAllButtonListeners()
		{
			if (_theButtonAnimator != null)
			{
				_theButtonAnimator.OnChangeState.RemoveListener(RefreshImageSprite);
			}
			if (_theDynamicButton != null)
			{
				_theDynamicButton.onPrimaryDown.RemoveAllListeners();
			}
		}

		public void SetGraphColor(Color graphColour)
		{
			if (_graphColorImage != null)
			{
				_graphColorImage.color = graphColour;
			}
		}

		private string GetSaveKey()
		{
			return GameObjectUtils.ObjectFullPath(base.gameObject.transform) + "/PanelItemToggleButton";
		}

		public void SaveState(HUDSavedState saveState)
		{
			if (_saveState)
			{
				saveState.Set(GetSaveKey(), IsDown);
			}
		}

		public void RestoreState(HUDSavedState saveState)
		{
			if (_saveState && saveState.Get<bool>(GetSaveKey(), out var value) && value != IsDown)
			{
				DynamicButton component = GetComponent<DynamicButton>();
				if (component != null && component.onPrimaryDown != null)
				{
					component.onPrimaryDown.Invoke();
				}
			}
		}
	}
}
