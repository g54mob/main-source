using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuButton : Selectable, IPointerClickHandler, IEventSystemHandler
{
	public delegate void ButtonDelegate();

	public delegate string StringDelegate();

	public ButtonDelegate pointerDownDelegate;

	public ButtonDelegate rightClickDownDelegate;

	private CustomButtonState _displayedState;

	public bool displayedHighlightState;

	public bool displayedSelectionState;

	public bool isPointerInsideButton;

	private bool hasClickListener;

	public ButtonSoundType buttonSoundType;

	public CustomButtonState _buttonState;

	[NonSerialized]
	public bool useVerticalTooltip;

	[NonSerialized]
	public bool isTooltipDelayed;

	[NonSerialized]
	public bool isTooltipUpdatedEverySimulationStep;

	public StringDelegate highlightTextDelegate;

	[NonSerialized]
	public bool animateSize;

	private float animationProgress;

	private bool testIsPointerDown;

	public float highlightMargin;

	public bool useOutlineHighlight;

	public Image stateImage;

	private HighlightImage highlightImage;

	public InvalidReason invalidReason;

	private CustomAnimation flashScaleAnimation;

	private PunchAnimation punchAnimation;

	private float displayedScale;

	[NonSerialized]
	public EntityId tooltipEntity;

	[NonSerialized]
	public TooltipModifier tooltipModifier;

	public TooltipOptions tooltipOptions;

	private BackgroundFlashAnimation focusHighlight;

	private bool useDynamicImages;

	public bool isImageButton;

	public bool isSelected;

	private const bool useCustomTransitions = true;

	private const int buttonDisplayFlagHighlighted = 1;

	private const int buttonDisplayFlagSelected = 2;

	private const int buttonDisplayFlagDisabled = 4;

	private const int buttonDisplayFlagInvalid = 8;

	public bool isInitialized;

	private ColorBlock defaultColorBlock;

	private ColorBlock disabledColorBlock;

	public CustomButtonState buttonState
	{
		get
		{
			return _buttonState;
		}
		set
		{
			if (value == _buttonState)
			{
				return;
			}
			_buttonState = value;
			if (_buttonState == CustomButtonState.HighlightFlashing)
			{
				ConfirmFlashAnimation();
				flashScaleAnimation.isLooping = true;
				if (!flashScaleAnimation.isRunning)
				{
					flashScaleAnimation.Run();
				}
			}
			else
			{
				flashScaleAnimation?.SetLooping(state: false);
			}
		}
	}

	public bool shouldIgnoreAction
	{
		get
		{
			if (buttonState != CustomButtonState.Disabled)
			{
				return buttonState == CustomButtonState.Invalid;
			}
			return true;
		}
	}

	public bool allowsAction
	{
		get
		{
			if (buttonState != CustomButtonState.Disabled)
			{
				return buttonState != CustomButtonState.Invalid;
			}
			return false;
		}
	}

	[field: SerializeField]
	public Button.ButtonClickedEvent onClick { get; set; } = new Button.ButtonClickedEvent();

	protected override void Awake()
	{
		if (Application.isPlaying)
		{
			base.Awake();
			if (!isInitialized)
			{
				InitializeButton();
			}
		}
	}

	public void InitializeButton()
	{
		isInitialized = true;
		Navigation navigation = base.navigation;
		navigation.mode = Navigation.Mode.None;
		base.navigation = navigation;
		if (base.gameObject.TryGetComponent<Image>(out var component))
		{
			stateImage = component;
		}
		if (null != stateImage && null != MenuManager.Instance)
		{
			useDynamicImages = stateImage.sprite == MenuManager.Instance.buttonImageDefault;
		}
		if (isImageButton)
		{
			defaultColorBlock = base.colors;
			disabledColorBlock = base.colors;
			disabledColorBlock.normalColor = Color.gray;
			disabledColorBlock.highlightedColor = Color.gray * 0.85f;
			disabledColorBlock.pressedColor = Color.gray * 0.65f;
		}
		else
		{
			base.transition = Transition.None;
			UpdateBackgroundColor();
			UpdateHighlightColor();
		}
	}

	public void CalculateButtonState()
	{
	}

	public void ReturnHighlightImageToPool()
	{
		if (null != highlightImage)
		{
			MenuManager.Instance.ReturnPooledHighlightImage(highlightImage);
			highlightImage = null;
		}
	}

	private HighlightImage ConfirmedHighlightImage()
	{
		if (null == highlightImage)
		{
			highlightImage = MenuManager.Instance.GetPooledHighlightImage(this);
		}
		return highlightImage;
	}

	protected virtual void Update()
	{
		if (buttonState != _displayedState || isSelected != displayedSelectionState || _displayedState == CustomButtonState.HighlightFlashing || _displayedState == CustomButtonState.BlueFlashing)
		{
			UpdateBackgroundColor();
			UpdateHighlightColor();
		}
		if (displayedHighlightState != isPointerInsideButton)
		{
			UpdateHighlightColor();
		}
		focusHighlight?.UpdateAnimation();
		flashScaleAnimation?.UpdateAnimation();
		punchAnimation?.UpdateAnimation();
		UpdateSize();
	}

	private float GetScaleForAnimationProgress()
	{
		return 1f + DOVirtual.EasedValue(0f, 0.075f, animationProgress, Ease.InOutSine);
	}

	private void UpdateSize()
	{
		if (punchAnimation != null && punchAnimation.isRunning)
		{
			animationProgress = punchAnimation.progress;
		}
		bool flag = false;
		if (isPointerInsideButton && !testIsPointerDown)
		{
			if (animateSize)
			{
				flag = true;
			}
			else if (flashScaleAnimation != null && flashScaleAnimation.isRunning)
			{
				flag = true;
			}
		}
		if (flag)
		{
			if (animationProgress < 1f)
			{
				animationProgress += TimeManager.MenuDelta * 6f;
				if (animationProgress > 1f)
				{
					animationProgress = 1f;
				}
			}
			if (flashScaleAnimation != null)
			{
				flashScaleAnimation.progress = 0.5f + (1f - animationProgress) * 0.5f;
			}
		}
		else if (flashScaleAnimation != null && flashScaleAnimation.isRunning)
		{
			if (flashScaleAnimation.progress < 0.5f)
			{
				animationProgress = flashScaleAnimation.progress * 2f;
			}
			else
			{
				animationProgress = 1f - (flashScaleAnimation.progress - 0.5f) * 2f;
			}
		}
		else
		{
			if (!(animationProgress > 0f))
			{
				return;
			}
			animationProgress -= TimeManager.MenuDelta * 8f;
			if (animationProgress < 0f)
			{
				animationProgress = 0f;
			}
		}
		float scaleForAnimationProgress = GetScaleForAnimationProgress();
		if (GameUtility.NotEquals(scaleForAnimationProgress, displayedScale))
		{
			displayedScale = scaleForAnimationProgress;
			base.transform.localScale = new Vector3(displayedScale, displayedScale, 1f);
		}
	}

	public virtual void UpdateBackgroundColor()
	{
		_displayedState = buttonState;
		displayedSelectionState = isSelected;
		if (_displayedState == CustomButtonState.None)
		{
			return;
		}
		if (isImageButton)
		{
			if (_displayedState == CustomButtonState.Disabled)
			{
				base.colors = disabledColorBlock;
			}
			else
			{
				base.colors = defaultColorBlock;
			}
			if (null != stateImage)
			{
				if (_displayedState == CustomButtonState.HighlightFlashing)
				{
					float t = (IsHighlighted() ? 1f : TimeManager.FlashAnimationValue);
					stateImage.color = Color.Lerp(Color.green, Color.yellow, t);
				}
				else
				{
					stateImage.color = Color.white;
				}
			}
		}
		else
		{
			if (!(null != stateImage))
			{
				return;
			}
			stateImage.color = GetColorForCurrentState();
			if (focusHighlight != null)
			{
				focusHighlight.original = stateImage.color;
			}
			if (_displayedState == CustomButtonState.HighlightFlashing)
			{
				float t2 = (IsHighlighted() ? 1f : TimeManager.FlashAnimationValue);
				stateImage.color = Color.Lerp(Color.green, Color.yellow, t2);
			}
			else if (_displayedState == CustomButtonState.BlueFlashing)
			{
				float t3 = (IsHighlighted() ? 1f : TimeManager.FlashAnimationValue);
				stateImage.color = Color.Lerp(ColorManager.blueFlash1, ColorManager.blueFlash2, t3);
			}
			if (useDynamicImages)
			{
				if (_displayedState == CustomButtonState.Disabled || _displayedState == CustomButtonState.Invalid)
				{
					stateImage.sprite = MenuManager.Instance.buttonImageDisabled;
				}
				else
				{
					stateImage.sprite = MenuManager.Instance.buttonImageDefault;
				}
			}
		}
	}

	protected virtual Color GetColorForCurrentState()
	{
		if (isSelected)
		{
			return ColorManager.defaultSelection;
		}
		return ColorManager.ColorForButtonState(_displayedState);
	}

	private void UpdateHighlightColor()
	{
		displayedHighlightState = isPointerInsideButton;
		if (isImageButton)
		{
			return;
		}
		if (displayedHighlightState)
		{
			if (null != MenuManager.Instance)
			{
				if (buttonState == CustomButtonState.HighlightFlashing)
				{
					ConfirmedHighlightImage().JumpTo(Color.yellow);
				}
				else if (buttonState == CustomButtonState.Disabled)
				{
					ConfirmedHighlightImage().JumpTo(ColorManager.disabledHighlightColor);
				}
				else
				{
					ConfirmedHighlightImage().JumpTo(ColorManager.highlightHoverColor);
				}
			}
		}
		else if (null != highlightImage)
		{
			highlightImage.BeginFade();
		}
	}

	private void ConfirmFlashAnimation()
	{
		if (flashScaleAnimation == null)
		{
			flashScaleAnimation = new CustomAnimation(0f, 1f, 1f, Ease.InOutSine);
			flashScaleAnimation.autoReverse = true;
		}
	}

	public void AddRightClickTrigger(ButtonDelegate del)
	{
		rightClickDownDelegate = del;
	}

	public void AddPointerDownTrigger(ButtonDelegate del)
	{
		_ = pointerDownDelegate;
		pointerDownDelegate = del;
	}

	public void AddPointerClickTrigger(UnityAction call)
	{
		onClick.AddListener(call);
		hasClickListener = true;
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		base.OnPointerDown(eventData);
		if (!IsActive() || !IsInteractable() || !(EventSystem.current != null))
		{
			return;
		}
		testIsPointerDown = true;
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			UserInput.Instance.OnPointerDown(this);
			pointerDownDelegate?.Invoke();
			if (pointerDownDelegate != null)
			{
				PlaySound();
			}
		}
		else if (eventData.button == PointerEventData.InputButton.Right)
		{
			rightClickDownDelegate?.Invoke();
			if (pointerDownDelegate != null)
			{
				PlaySound();
			}
		}
	}

	public override void OnPointerUp(PointerEventData eventData)
	{
		base.OnPointerUp(eventData);
		testIsPointerDown = false;
		UserInput.Instance.OnPointerUp(this);
	}

	public void Press()
	{
		if (IsActive() && IsInteractable())
		{
			onClick?.Invoke();
			if (hasClickListener)
			{
				PlaySound();
			}
		}
	}

	public virtual void PlaySound()
	{
		if (buttonSoundType == ButtonSoundType.HeavyClick)
		{
			SoundManager.PlayHeavyButton();
		}
		else if (buttonSoundType == ButtonSoundType.Default)
		{
			SoundManager.PlayButtonClickSmall();
		}
		else if (buttonSoundType == ButtonSoundType.Build)
		{
			SoundManager.PlayBuildSound();
		}
		else if (buttonSoundType == ButtonSoundType.Purchase)
		{
			SoundManager.PlayPurchaseSound();
		}
	}

	public void AnimateInstant()
	{
		UpdateBackgroundColor();
		UpdateHighlightColor();
	}

	public virtual void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			Press();
		}
	}

	public void AnimateFocusHighlight()
	{
		if (focusHighlight == null && null != stateImage)
		{
			focusHighlight = new BackgroundFlashAnimation(stateImage);
		}
		focusHighlight?.Run();
	}

	public void DoPunchAnimation()
	{
		if (punchAnimation == null)
		{
			punchAnimation = new PunchAnimation();
		}
		punchAnimation.Run();
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		isPointerInsideButton = true;
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
		base.OnPointerExit(eventData);
		isPointerInsideButton = false;
	}

	public virtual string HighlightText()
	{
		if (highlightTextDelegate != null)
		{
			return highlightTextDelegate();
		}
		if (tooltipEntity.type != EntityType.None)
		{
			if (tooltipModifier == TooltipModifier.QuestReward)
			{
				if (this is CostIcon costIcon && tooltipEntity.TryAsUpgrade(out var i))
				{
					return string.Concat(TextDisplay.FormattedRewardEntityWithType(tooltipEntity, costIcon.tooltipLevel) + TextDisplay.NewLine, TextDisplay.DescriptionForActiveTownUpgrade(i, costIcon.tooltipLevel));
				}
				if (this is CostIcon { tooltipLevel: >0 } costIcon2)
				{
					return TextDisplay.FormattedRewardEntityWithType(tooltipEntity, costIcon2.tooltipLevel);
				}
				if (tooltipEntity.TryAsItem(out var i2) && i2 == ItemType.UtilityVictory)
				{
					return TextDisplay.LabelForItem(i2);
				}
				return TextDisplay.FormattedRewardEntityWithType(tooltipEntity);
			}
			if (tooltipModifier != TooltipModifier.ShowUtility)
			{
				if (tooltipModifier == TooltipModifier.GlobalStorage)
				{
					return string.Format(TextDisplay.LocalizedTwoValueFormat(), TextDisplay.LabelForEntity(tooltipEntity), "(" + TextDisplay.LabelForBuilding(BuildingType.TradingPost) + ")");
				}
				if (tooltipModifier != TooltipModifier.ShowProductionDetails)
				{
					_ = tooltipModifier;
				}
				return TextDisplay.LabelForEntity(tooltipEntity);
			}
			if (tooltipEntity.TryAsItem(out var i3))
			{
				switch (i3)
				{
				case ItemType.Worker:
					return "Workers".Localized() + "\n" + "TooltipWorkers".Localized();
				case ItemType.UtilityPrestigePoint:
					return TextDisplay.LabelForItem(i3);
				}
			}
		}
		return null;
	}

	public virtual void OnRemoveFromList()
	{
		if (displayedHighlightState)
		{
			displayedHighlightState = false;
			UpdateHighlightColor();
		}
		isPointerInsideButton = false;
		displayedSelectionState = false;
	}

	public virtual bool DelayTooltip()
	{
		return isTooltipDelayed;
	}

	public virtual void ResetPointerAndHighlightState()
	{
		_ = null != highlightImage;
		isPointerInsideButton = false;
		ReturnHighlightImageToPool();
	}
}
