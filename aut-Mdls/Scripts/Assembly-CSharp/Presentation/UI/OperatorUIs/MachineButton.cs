using System;
using DG.Tweening;
using Data.Variables;
using FMODUnity;
using Presentation.Locators;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Utils;

namespace Presentation.UI.OperatorUIs
{
	public class MachineButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
	{
		protected enum ButtonState
		{
			None = 0,
			Normal = 1,
			Pressed = 2,
			Disabled = 3,
			Locked = 4
		}

		private const int TopNormalPos = -24;

		private const int TopPressedPos = 0;

		private const int TopHoverWhenNormalPos = -18;

		private const float FakeDepthNormalHeight = 20f;

		private const float FakeDepthPressedHeight = 10f;

		[SerializeField]
		private Button _button;

		[SerializeField]
		private InputActionReference _inputActionShortcut;

		[SerializeField]
		private HorizontalLayoutGroup _socketLayoutGroup;

		[SerializeField]
		private Image _fakeDepth;

		[SerializeField]
		private CanvasGroup _topContent;

		[SerializeField]
		private Image _normalImageContent;

		[SerializeField]
		private TextMeshProUGUI _normalTextContent;

		[SerializeField]
		private GameObject _normalIconContent;

		[SerializeField]
		private CanvasGroup _pressedContent;

		[SerializeField]
		private BoolVariableSO _isLockedVariableSO;

		[SerializeField]
		private GameObject _lockedIconContent;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private EventReference _customAudioEvent;

		[SerializeField]
		private bool _activateWhenPressed;

		[SerializeField]
		private int _onClickParam;

		private Color _normalImageColorPressed = Color.white;

		private Color _normalImageColorNormal = new Color(1f, 1f, 1f, 0.7f);

		private bool _hasLockedVariableSO;

		private ButtonState _currentState;

		private Tweener _paddingTopTweener;

		private Tweener _fakeDepthTweener;

		private Tweener _glowColorTweener;

		public int ClickParam => _onClickParam;

		public bool ShouldBeLocked
		{
			get
			{
				if (_hasLockedVariableSO)
				{
					return _isLockedVariableSO.Value;
				}
				return false;
			}
		}

		public bool IsPressed
		{
			get
			{
				return _currentState == ButtonState.Pressed;
			}
			set
			{
				if (_currentState != ButtonState.Disabled && _currentState != ButtonState.Locked && (!value || _currentState != ButtonState.Pressed))
				{
					if (value)
					{
						TrySetState(ButtonState.Pressed);
					}
					else
					{
						TrySetState(ButtonState.Normal);
					}
				}
			}
		}

		public bool Interactable
		{
			get
			{
				return _button.interactable;
			}
			set
			{
				if (value != _button.enabled)
				{
					if (value)
					{
						TrySetState((!ShouldBeLocked) ? ButtonState.Normal : ButtonState.Locked);
					}
					else
					{
						TrySetState(ButtonState.Disabled);
					}
				}
			}
		}

		public event Action OnHoverStart;

		public event Action OnHoverEnd;

		public event Action<int, MachineButton> OnClick;

		private void Awake()
		{
			_pressedContent.alpha = 0f;
			if (_normalImageContent != null)
			{
				_normalImageContent.color = _normalImageColorNormal;
			}
			if (_inputActionShortcut != null)
			{
				_inputActionShortcut.action.performed += OnInputActionPreformed;
			}
			_hasLockedVariableSO = _isLockedVariableSO != null;
			if (_hasLockedVariableSO)
			{
				_isLockedVariableSO.ValueChanged += OnIsLockedVariableChanged;
			}
		}

		private void OnDestroy()
		{
			if (_inputActionShortcut != null)
			{
				_inputActionShortcut.action.performed -= OnInputActionPreformed;
			}
			if (_hasLockedVariableSO)
			{
				_isLockedVariableSO.ValueChanged -= OnIsLockedVariableChanged;
			}
		}

		private void OnEnable()
		{
			if (_currentState == ButtonState.None)
			{
				TrySetState((!ShouldBeLocked) ? ButtonState.Normal : ButtonState.Locked, onInitiation: true);
			}
		}

		private void OnInputActionPreformed(InputAction.CallbackContext context)
		{
			if (Interactable)
			{
				_button.PressButton();
				_audioManagerLocator?.AudioManager.PlayButtonSound(_customAudioEvent);
				this.OnClick?.Invoke(_onClickParam, this);
			}
		}

		private void OnIsLockedVariableChanged(bool isLocked)
		{
			if (isLocked)
			{
				if (_currentState != ButtonState.Disabled)
				{
					TrySetState(ButtonState.Locked);
				}
			}
			else if (_currentState == ButtonState.Locked)
			{
				TrySetState(ButtonState.Normal);
			}
		}

		protected virtual bool TrySetState(ButtonState newState, bool onInitiation = false)
		{
			if (newState == _currentState)
			{
				return false;
			}
			if (_activateWhenPressed && newState == ButtonState.Pressed && _currentState == ButtonState.Pressed)
			{
				return false;
			}
			_currentState = newState;
			if (_currentState == ButtonState.Pressed || _currentState == ButtonState.Disabled || _currentState == ButtonState.Locked)
			{
				DoTweenActions(0, 10f, _normalImageColorPressed, isActualPress: true, onInitiation);
			}
			else
			{
				DoTweenActions(-24, 20f, _normalImageColorNormal, isActualPress: true, onInitiation);
			}
			if (_pressedContent != null)
			{
				_pressedContent.DOKill();
				_pressedContent.DOFade((_currentState == ButtonState.Pressed) ? 1f : 0f, 0.2f);
			}
			bool flag = _currentState == ButtonState.Disabled || _currentState == ButtonState.Locked;
			_button.interactable = !flag;
			_button.enabled = !flag;
			if (_normalImageContent != null)
			{
				_normalImageContent.enabled = !flag;
			}
			if (_normalTextContent != null)
			{
				_normalTextContent.alpha = (flag ? 0.24f : 1f);
			}
			if (_normalIconContent != null)
			{
				_normalIconContent.SetActive(!flag);
			}
			if (_topContent != null)
			{
				_topContent.alpha = (flag ? 0f : 1f);
			}
			if (_lockedIconContent != null)
			{
				_lockedIconContent.SetActive(_currentState == ButtonState.Locked);
			}
			return true;
		}

		private void DoTweenActions(int topPos, float fakeDepthHeight, Color glowColor, bool isActualPress, bool onInitiation = false)
		{
			if (_paddingTopTweener != null)
			{
				_paddingTopTweener.Kill();
			}
			if (_fakeDepthTweener != null)
			{
				_fakeDepthTweener.Kill();
			}
			if (_glowColorTweener != null)
			{
				_glowColorTweener.Kill();
			}
			Ease ease = Ease.OutQuad;
			float duration = 0.2f;
			if (isActualPress)
			{
				ease = Ease.OutBack;
				duration = 0.3f;
			}
			if (onInitiation)
			{
				_socketLayoutGroup.padding.top = topPos;
				_fakeDepth.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, fakeDepthHeight);
				if (_normalImageContent != null)
				{
					_normalImageContent.color = glowColor;
				}
			}
			else
			{
				_paddingTopTweener = DOTween.To(TweenPaddingTop, _socketLayoutGroup.padding.top, topPos, duration).SetEase(ease);
				_fakeDepthTweener = DOTween.To(TweenFakeDepthHeight, _fakeDepth.rectTransform.rect.height, fakeDepthHeight, duration).SetEase(ease);
				if (_normalImageContent != null)
				{
					_glowColorTweener = _normalImageContent.DOColor(glowColor, duration);
				}
			}
		}

		private void TweenPaddingTop(float value)
		{
			_socketLayoutGroup.padding.top = (int)value;
		}

		private void TweenFakeDepthHeight(float value)
		{
			_fakeDepth.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, value);
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			if (Interactable)
			{
				if (_currentState == ButtonState.Normal)
				{
					DoTweenActions(-18, 18f, _normalImageColorNormal, isActualPress: false);
				}
				this.OnHoverStart?.Invoke();
			}
		}

		public virtual void OnPointerExit(PointerEventData eventData = null)
		{
			if (Interactable)
			{
				if (_currentState == ButtonState.Normal)
				{
					DoTweenActions(-24, 20f, _normalImageColorNormal, isActualPress: false);
				}
				else if (_currentState == ButtonState.Pressed)
				{
					DoTweenActions(0, 10f, _normalImageColorPressed, isActualPress: false);
				}
				this.OnHoverEnd?.Invoke();
			}
		}

		public virtual void OnPointerDown(PointerEventData eventData)
		{
			if (Interactable && (_currentState == ButtonState.Pressed || TrySetState(ButtonState.Pressed)))
			{
				_audioManagerLocator?.AudioManager.PlayButtonSound(_customAudioEvent);
				this.OnClick?.Invoke(_onClickParam, this);
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (Interactable && (!_activateWhenPressed || _currentState != ButtonState.Pressed))
			{
				TrySetState(ButtonState.Normal);
			}
		}
	}
}
