using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MoreMountains.Tools
{
	[RequireComponent(typeof(Rect))]
	[RequireComponent(typeof(CanvasGroup))]
	[AddComponentMenu("More Mountains/Tools/Controls/MM Touch Button")]
	public class MMTouchButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler, ISubmitHandler
	{
		public enum ButtonStates
		{
			Off = 0,
			ButtonDown = 1,
			ButtonPressed = 2,
			ButtonUp = 3,
			Disabled = 4
		}

		[Header("Interaction")]
		public bool Interactable = true;

		[Header("Binding")]
		[Tooltip("The method(s) to call when the button gets pressed down")]
		public UnityEvent ButtonPressedFirstTime;

		[Tooltip("The method(s) to call when the button gets released")]
		public UnityEvent ButtonReleased;

		[Tooltip("The method(s) to call while the button is being pressed")]
		public UnityEvent ButtonPressed;

		[Header("Sprite Swap")]
		[MMInformation("Here you can define, for disabled and pressed states, if you want a different sprite, and a different color.", MMInformationAttribute.InformationType.Info, false)]
		[Tooltip("the sprite to use on the button when it's in the disabled state")]
		public Sprite DisabledSprite;

		[Tooltip("whether or not to change color when the button is disabled")]
		public bool DisabledChangeColor;

		[Tooltip("the color to use when the button is disabled")]
		[MMCondition("DisabledChangeColor", true)]
		public Color DisabledColor = Color.white;

		[Tooltip("the sprite to use on the button when it's in the pressed state")]
		public Sprite PressedSprite;

		[Tooltip("whether or not to change the button color on press")]
		public bool PressedChangeColor;

		[Tooltip("the color to use when the button is pressed")]
		[MMCondition("PressedChangeColor", true)]
		public Color PressedColor = Color.white;

		[Tooltip("the sprite to use on the button when it's in the highlighted state")]
		public Sprite HighlightedSprite;

		[Tooltip("whether or not to change color when highlighting the button")]
		public bool HighlightedChangeColor;

		[Tooltip("the color to use when the button is highlighted")]
		[MMCondition("HighlightedChangeColor", true)]
		public Color HighlightedColor = Color.white;

		[Header("Opacity")]
		[MMInformation("Here you can set different opacities for the button when it's pressed, idle, or disabled. Useful for visual feedback.", MMInformationAttribute.InformationType.Info, false)]
		[Tooltip("the opacity to apply to the canvas group when the button is pressed")]
		public float PressedOpacity = 1f;

		[Tooltip("the new opacity to apply to the canvas group when the button is idle")]
		public float IdleOpacity = 1f;

		[Tooltip("the new opacity to apply to the canvas group when the button is disabled")]
		public float DisabledOpacity = 1f;

		[Header("Delays")]
		[MMInformation("Specify here the delays to apply when the button is pressed initially, and when it gets released. Usually you'll keep them at 0.", MMInformationAttribute.InformationType.Info, false)]
		[Tooltip("the delay to apply to events when the button gets pressed for the first time")]
		public float PressedFirstTimeDelay;

		[Tooltip("the delay to apply to events when the button gets released")]
		public float ReleasedDelay;

		[Header("Buffer")]
		[Tooltip("the duration (in seconds) after a press during which the button can't be pressed again")]
		public float BufferDuration;

		[Header("Animation")]
		[MMInformation("Here you can bind an animator, and specify animation parameter names for the various states.", MMInformationAttribute.InformationType.Info, false)]
		[Tooltip("an animator you can bind to this button to have its states updated to reflect the button's states")]
		public Animator Animator;

		[Tooltip("the name of the animation parameter to turn true when the button is idle")]
		public string IdleAnimationParameterName = "Idle";

		[Tooltip("the name of the animation parameter to turn true when the button is disabled")]
		public string DisabledAnimationParameterName = "Disabled";

		[Tooltip("the name of the animation parameter to turn true when the button is pressed")]
		public string PressedAnimationParameterName = "Pressed";

		[Header("Mouse Mode")]
		[MMInformation("If you set this to true, you'll need to actually press the button for it to be triggered, otherwise a simple hover will trigger it (better to leave it unchecked if you're going for touch input).", MMInformationAttribute.InformationType.Info, false)]
		[Tooltip("If you set this to true, you'll need to actually press the button for it to be triggered, otherwise a simple hover will trigger it (better for touch input).")]
		public bool MouseMode;

		public bool PreventLeftClick;

		public bool PreventMiddleClick = true;

		public bool PreventRightClick = true;

		protected bool _zonePressed;

		protected CanvasGroup _canvasGroup;

		protected float _initialOpacity;

		protected Animator _animator;

		protected Image _image;

		protected Sprite _initialSprite;

		protected Color _initialColor;

		protected float _lastClickTimestamp;

		protected Selectable _selectable;

		public virtual bool ReturnToInitialSpriteAutomatically { get; set; }

		public virtual ButtonStates CurrentState { get; protected set; }

		public event Action<PointerEventData.FramePressState, PointerEventData> ButtonStateChange;

		protected virtual void Awake()
		{
			Initialization();
		}

		protected virtual void Initialization()
		{
			ReturnToInitialSpriteAutomatically = true;
			_selectable = GetComponent<Selectable>();
			_image = GetComponent<Image>();
			if (_image != null)
			{
				_initialColor = _image.color;
				_initialSprite = _image.sprite;
			}
			_animator = GetComponent<Animator>();
			if (Animator != null)
			{
				_animator = Animator;
			}
			_canvasGroup = GetComponent<CanvasGroup>();
			if (_canvasGroup != null)
			{
				_initialOpacity = IdleOpacity;
				_canvasGroup.alpha = _initialOpacity;
				_initialOpacity = _canvasGroup.alpha;
			}
			ResetButton();
		}

		protected virtual void Update()
		{
			switch (CurrentState)
			{
			case ButtonStates.Off:
				SetOpacity(IdleOpacity);
				if (_image != null && ReturnToInitialSpriteAutomatically)
				{
					_image.color = _initialColor;
					_image.sprite = _initialSprite;
				}
				if (!(_selectable != null))
				{
					break;
				}
				_selectable.interactable = true;
				if (EventSystem.current.currentSelectedGameObject == base.gameObject)
				{
					if (_image != null && HighlightedChangeColor)
					{
						_image.color = HighlightedColor;
					}
					if (HighlightedSprite != null)
					{
						_image.sprite = HighlightedSprite;
					}
				}
				break;
			case ButtonStates.Disabled:
				SetOpacity(DisabledOpacity);
				if (_image != null)
				{
					if (DisabledSprite != null)
					{
						_image.sprite = DisabledSprite;
					}
					if (DisabledChangeColor)
					{
						_image.color = DisabledColor;
					}
				}
				if (_selectable != null)
				{
					_selectable.interactable = false;
				}
				break;
			case ButtonStates.ButtonPressed:
				SetOpacity(PressedOpacity);
				OnPointerPressed();
				if (_image != null)
				{
					if (PressedSprite != null)
					{
						_image.sprite = PressedSprite;
					}
					if (PressedChangeColor)
					{
						_image.color = PressedColor;
					}
				}
				break;
			}
			UpdateAnimatorStates();
		}

		protected virtual void LateUpdate()
		{
			if (CurrentState == ButtonStates.ButtonUp)
			{
				CurrentState = ButtonStates.Off;
			}
			if (CurrentState == ButtonStates.ButtonDown)
			{
				CurrentState = ButtonStates.ButtonPressed;
			}
		}

		public virtual void InvokeButtonStateChange(PointerEventData.FramePressState newState, PointerEventData data)
		{
			this.ButtonStateChange?.Invoke(newState, data);
		}

		protected virtual bool AllowedClick(PointerEventData data)
		{
			if (!MouseMode)
			{
				return true;
			}
			if (PreventLeftClick && data.button == PointerEventData.InputButton.Left)
			{
				return false;
			}
			if (PreventMiddleClick && data.button == PointerEventData.InputButton.Middle)
			{
				return false;
			}
			if (PreventRightClick && data.button == PointerEventData.InputButton.Right)
			{
				return false;
			}
			return true;
		}

		public virtual void OnPointerDown(PointerEventData data)
		{
			if (Interactable && AllowedClick(data) && !(Time.unscaledTime - _lastClickTimestamp < BufferDuration) && CurrentState == ButtonStates.Off)
			{
				CurrentState = ButtonStates.ButtonDown;
				_lastClickTimestamp = Time.unscaledTime;
				InvokeButtonStateChange(PointerEventData.FramePressState.Pressed, data);
				if (Time.timeScale != 0f && PressedFirstTimeDelay > 0f)
				{
					Invoke("InvokePressedFirstTime", PressedFirstTimeDelay);
				}
				else
				{
					ButtonPressedFirstTime.Invoke();
				}
			}
		}

		protected virtual void InvokePressedFirstTime()
		{
			if (ButtonPressedFirstTime != null)
			{
				ButtonPressedFirstTime.Invoke();
			}
		}

		public virtual void OnPointerUp(PointerEventData data)
		{
			if (Interactable && AllowedClick(data) && (CurrentState == ButtonStates.ButtonPressed || CurrentState == ButtonStates.ButtonDown))
			{
				CurrentState = ButtonStates.ButtonUp;
				InvokeButtonStateChange(PointerEventData.FramePressState.Released, data);
				if (Time.timeScale != 0f && ReleasedDelay > 0f)
				{
					Invoke("InvokeReleased", ReleasedDelay);
				}
				else
				{
					ButtonReleased.Invoke();
				}
			}
		}

		protected virtual void InvokeReleased()
		{
			if (ButtonReleased != null)
			{
				ButtonReleased.Invoke();
			}
		}

		public virtual void OnPointerPressed()
		{
			if (Interactable)
			{
				CurrentState = ButtonStates.ButtonPressed;
				if (ButtonPressed != null)
				{
					ButtonPressed.Invoke();
				}
			}
		}

		protected virtual void ResetButton()
		{
			SetOpacity(_initialOpacity);
			CurrentState = ButtonStates.Off;
		}

		public virtual void OnPointerEnter(PointerEventData data)
		{
			if (Interactable && AllowedClick(data) && !MouseMode)
			{
				OnPointerDown(data);
			}
		}

		public virtual void OnPointerExit(PointerEventData data)
		{
			if (Interactable && AllowedClick(data) && !MouseMode)
			{
				OnPointerUp(data);
			}
		}

		protected virtual void OnEnable()
		{
			ResetButton();
		}

		private void OnDisable()
		{
			bool num = CurrentState != ButtonStates.Off && CurrentState != ButtonStates.Disabled && CurrentState != ButtonStates.ButtonUp;
			DisableButton();
			CurrentState = ButtonStates.Off;
			if (num)
			{
				InvokeButtonStateChange(PointerEventData.FramePressState.Released, null);
				ButtonReleased?.Invoke();
			}
		}

		public virtual void DisableButton()
		{
			CurrentState = ButtonStates.Disabled;
		}

		public virtual void EnableButton()
		{
			if (CurrentState == ButtonStates.Disabled)
			{
				CurrentState = ButtonStates.Off;
			}
		}

		protected virtual void SetOpacity(float newOpacity)
		{
			if (_canvasGroup != null)
			{
				_canvasGroup.alpha = newOpacity;
			}
		}

		protected virtual void UpdateAnimatorStates()
		{
			if (!(_animator == null))
			{
				if (DisabledAnimationParameterName != null)
				{
					_animator.SetBool(DisabledAnimationParameterName, CurrentState == ButtonStates.Disabled);
				}
				if (PressedAnimationParameterName != null)
				{
					_animator.SetBool(PressedAnimationParameterName, CurrentState == ButtonStates.ButtonPressed);
				}
				if (IdleAnimationParameterName != null)
				{
					_animator.SetBool(IdleAnimationParameterName, CurrentState == ButtonStates.Off);
				}
			}
		}

		public virtual void OnSubmit(BaseEventData eventData)
		{
			if (ButtonPressedFirstTime != null)
			{
				ButtonPressedFirstTime.Invoke();
			}
			if (ButtonReleased != null)
			{
				ButtonReleased.Invoke();
			}
		}
	}
}
