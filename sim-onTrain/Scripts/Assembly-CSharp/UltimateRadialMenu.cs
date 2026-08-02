using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(CanvasGroup))]
[AddComponentMenu("Ultimate Radial Menu/Ultimate Radial Menu")]
public class UltimateRadialMenu : UIPanelBase
{
	public enum ScalingAxis
	{
		Width = 0,
		Height = 1
	}

	public enum AngleOffset
	{
		Centered = 0,
		OffCenter = 1,
		OnlyEven = 2,
		OnlyOdd = 3
	}

	public enum InitialState
	{
		Enabled = 0,
		Disabled = 1
	}

	public enum RadialMenuToggle
	{
		FadeAlpha = 0,
		Scale = 1
	}

	[Serializable]
	public class UltimateRadialButton
	{
		private bool registered;

		public UltimateRadialMenu radialMenu;

		public RectTransform buttonTransform;

		public Image radialImage;

		public bool buttonDisabled;

		public string name;

		public string description;

		public int buttonIndex = -1;

		public float angle;

		public RectTransform iconTransform;

		public Image icon;

		public bool useIconUnique;

		public float iconSize;

		public float iconHorizontalPosition;

		public float iconVerticalPosition;

		public float iconRotation;

		public bool invertScaleY;

		public Vector3 iconNormalScale;

		public Text text;

		public Vector3 normalPosition;

		public Vector3 highlightedPosition;

		public Vector3 pressedPosition;

		public Vector3 selectedPosition;

		public Vector3 disabledPosition;

		public string key;

		public int id;

		public UnityEvent unityEvent;

		public float angleRange;

		public bool Registered
		{
			get
			{
				if (registered)
				{
					return true;
				}
				if (unityEvent != null && unityEvent.GetPersistentEventCount() > 0)
				{
					return true;
				}
				return false;
			}
		}

		public bool Selected
		{
			get
			{
				if (radialMenu == null)
				{
					return false;
				}
				if (radialMenu.CurrentSelectedButtonIndex >= 0 && radialMenu.CurrentSelectedButtonIndex == buttonIndex)
				{
					return true;
				}
				return false;
			}
		}

		public event Action OnRadialButtonInteract;

		public event Action<int> OnRadialButtonInteractWithId;

		public event Action<string> OnRadialButtonInteractWithKey;

		public event Action OnClearButtonInformation;

		public bool IsInAngle(float inputAngle)
		{
			if (buttonDisabled)
			{
				return false;
			}
			if (Mathf.Abs(inputAngle - angle) <= angleRange || Mathf.Abs(inputAngle - 360f - angle) <= angleRange || Mathf.Abs(inputAngle - (angle - 360f)) <= angleRange)
			{
				return true;
			}
			return false;
		}

		public void OnEnter()
		{
			if (buttonDisabled || (radialMenu.CurrentSelectedButtonIndex >= 0 && radialMenu.CurrentSelectedButtonIndex == buttonIndex))
			{
				return;
			}
			if (radialMenu.spriteSwap)
			{
				if (radialMenu.highlightedSprite != null)
				{
					radialImage.sprite = radialMenu.highlightedSprite;
				}
				else
				{
					radialImage.sprite = radialMenu.normalSprite;
				}
			}
			if (radialMenu.colorChange && radialImage.sprite != null)
			{
				radialImage.color = radialMenu.highlightedColor;
			}
			if (radialMenu.scaleTransform)
			{
				buttonTransform.localScale = Vector3.one * radialMenu.highlightedScaleModifier;
				buttonTransform.localPosition = highlightedPosition;
			}
			if (radialMenu.useButtonIcon && icon != null && icon.sprite != null)
			{
				if (radialMenu.iconColorChange)
				{
					icon.color = radialMenu.iconHighlightedColor;
				}
				if (radialMenu.iconScaleTransform)
				{
					iconTransform.localScale = iconNormalScale * radialMenu.iconHighlightedScaleModifier;
				}
			}
			if (radialMenu.useButtonText && text != null && radialMenu.textColorChange)
			{
				text.color = radialMenu.textHighlightedColor;
			}
		}

		public void OnExit()
		{
			if (buttonDisabled || (Application.isPlaying && radialMenu.CurrentSelectedButtonIndex == buttonIndex))
			{
				return;
			}
			if (radialMenu.spriteSwap && radialMenu.normalSprite != null)
			{
				radialImage.sprite = radialMenu.normalSprite;
			}
			if (radialMenu.colorChange && radialImage.sprite != null)
			{
				radialImage.color = radialMenu.normalColor;
			}
			if (radialMenu.scaleTransform)
			{
				radialImage.GetComponent<RectTransform>().localScale = Vector3.one;
				radialImage.GetComponent<RectTransform>().localPosition = normalPosition;
			}
			if (radialMenu.useButtonIcon && icon != null && icon.sprite != null)
			{
				if (radialMenu.iconColorChange)
				{
					icon.color = radialMenu.iconNormalColor;
				}
				if (radialMenu.iconScaleTransform)
				{
					iconTransform.localScale = iconNormalScale;
				}
			}
			if (radialMenu.useButtonText && text != null && radialMenu.textColorChange)
			{
				text.color = radialMenu.textNormalColor;
			}
		}

		public void OnInteract()
		{
			if (!buttonDisabled)
			{
				if (radialMenu.selectButtonOnInteract && radialMenu.CurrentSelectedButtonIndex != buttonIndex)
				{
					OnSelect();
				}
				if (unityEvent != null)
				{
					unityEvent.Invoke();
				}
				if (this.OnRadialButtonInteract != null)
				{
					this.OnRadialButtonInteract();
				}
				if (this.OnRadialButtonInteractWithId != null)
				{
					this.OnRadialButtonInteractWithId(id);
				}
				if (this.OnRadialButtonInteractWithKey != null)
				{
					this.OnRadialButtonInteractWithKey(key);
				}
				if (radialMenu.OnRadialButtonInteract != null)
				{
					radialMenu.OnRadialButtonInteract(buttonIndex);
				}
			}
		}

		public void OnSelect()
		{
			if (buttonDisabled)
			{
				return;
			}
			if (radialMenu.CurrentSelectedButtonIndex >= 0 && radialMenu.CurrentSelectedButtonIndex != buttonIndex)
			{
				radialMenu.UltimateRadialButtonList[radialMenu.CurrentSelectedButtonIndex].OnDeselect();
			}
			radialMenu.CurrentSelectedButtonIndex = buttonIndex;
			if (radialMenu.spriteSwap && radialMenu.selectedSprite != null)
			{
				radialImage.sprite = radialMenu.selectedSprite;
			}
			if (radialMenu.colorChange && radialImage.sprite != null)
			{
				radialImage.color = radialMenu.selectedColor;
			}
			if (radialMenu.scaleTransform)
			{
				buttonTransform.localScale = Vector3.one * radialMenu.selectedScaleModifier;
				buttonTransform.localPosition = selectedPosition;
			}
			if (radialMenu.useButtonIcon && icon != null && icon.sprite != null)
			{
				if (radialMenu.iconColorChange)
				{
					icon.color = radialMenu.iconSelectedColor;
				}
				if (radialMenu.iconScaleTransform)
				{
					iconTransform.localScale = iconNormalScale * radialMenu.iconSelectedScaleModifier;
				}
			}
			if (radialMenu.useButtonText && text != null && radialMenu.textColorChange)
			{
				text.color = radialMenu.textSelectedColor;
			}
			if (radialMenu.OnRadialButtonSelected != null)
			{
				radialMenu.OnRadialButtonSelected(buttonIndex);
			}
		}

		public void OnDeselect()
		{
			if (!buttonDisabled)
			{
				if (radialMenu.CurrentSelectedButtonIndex >= 0 && radialMenu.CurrentSelectedButtonIndex == buttonIndex)
				{
					radialMenu.CurrentSelectedButtonIndex = -1;
				}
				OnExit();
			}
		}

		public void DisableButton()
		{
			if (radialImage == null)
			{
				return;
			}
			if (radialMenu.CurrentSelectedButtonIndex >= 0 && radialMenu.CurrentSelectedButtonIndex == buttonIndex)
			{
				radialMenu.CurrentSelectedButtonIndex = -1;
			}
			buttonDisabled = true;
			if (radialMenu.spriteSwap && radialMenu.disabledSprite != null)
			{
				radialImage.sprite = radialMenu.disabledSprite;
			}
			if (radialMenu.colorChange && radialImage.sprite != null)
			{
				radialImage.color = radialMenu.disabledColor;
			}
			if (radialMenu.scaleTransform)
			{
				radialImage.GetComponent<RectTransform>().localScale = Vector3.one * radialMenu.disabledScaleModifier;
				radialImage.GetComponent<RectTransform>().localPosition = disabledPosition;
			}
			if (radialMenu.useButtonIcon && icon != null && icon.sprite != null)
			{
				if (radialMenu.iconColorChange)
				{
					icon.color = radialMenu.iconDisabledColor;
				}
				if (radialMenu.iconScaleTransform)
				{
					iconTransform.localScale = iconNormalScale * radialMenu.iconDisabledScaleModifier;
				}
			}
			if (radialMenu.useButtonText && text != null && radialMenu.textColorChange)
			{
				text.color = radialMenu.textDisabledColor;
			}
		}

		public void EnableButton()
		{
			if (!(radialImage == null))
			{
				buttonDisabled = false;
				OnExit();
			}
		}

		public void OnInputDown()
		{
			if (radialMenu.spriteSwap && radialMenu.pressedSprite != null)
			{
				radialImage.sprite = radialMenu.pressedSprite;
			}
			if (radialMenu.colorChange && radialImage.sprite != null)
			{
				radialImage.color = radialMenu.pressedColor;
			}
			if (radialMenu.scaleTransform)
			{
				radialImage.GetComponent<RectTransform>().localScale = Vector3.one * radialMenu.pressedScaleModifier;
				radialImage.GetComponent<RectTransform>().localPosition = pressedPosition;
			}
			if (radialMenu.useButtonIcon && icon != null && icon.sprite != null)
			{
				if (radialMenu.iconColorChange)
				{
					icon.color = radialMenu.iconPressedColor;
				}
				if (radialMenu.iconScaleTransform)
				{
					iconTransform.localScale = iconNormalScale * radialMenu.iconPressedScaleModifier;
				}
			}
			if (radialMenu.useButtonText && text != null && radialMenu.textColorChange)
			{
				text.color = radialMenu.textPressedColor;
			}
		}

		public void OnInputUp()
		{
			if (buttonIndex == radialMenu.CurrentButtonIndex)
			{
				OnEnter();
			}
			else
			{
				OnExit();
			}
		}

		public void AddCallback(Action ButtonCallback)
		{
			OnRadialButtonInteract += ButtonCallback;
		}

		public void AddCallback(Action<int> ButtonCallback)
		{
			OnRadialButtonInteractWithId += ButtonCallback;
		}

		public void AddCallback(Action<string> ButtonCallback)
		{
			OnRadialButtonInteractWithKey += ButtonCallback;
		}

		public void RegisterButtonInfo(UltimateRadialButtonInfo buttonInfo)
		{
			registered = true;
			buttonInfo.radialButton = this;
			id = buttonInfo.id;
			key = buttonInfo.key;
			name = buttonInfo.name;
			description = buttonInfo.description;
			OnClearButtonInformation += buttonInfo.OnClearButtonInformation;
			if (icon != null && radialMenu.useButtonIcon)
			{
				if (buttonInfo.icon != null)
				{
					icon.sprite = buttonInfo.icon;
					icon.color = radialMenu.iconNormalColor;
				}
				else
				{
					icon.color = Color.clear;
				}
			}
			if (text != null && radialMenu.displayNameOnButton)
			{
				text.text = buttonInfo.name;
			}
		}

		public void ClearButtonInformation()
		{
			registered = false;
			buttonDisabled = false;
			key = "";
			id = -1;
			name = "";
			description = "";
			if (radialImage.sprite != null)
			{
				radialImage.color = radialMenu.normalColor;
			}
			if (icon != null)
			{
				icon.sprite = null;
				icon.color = Color.clear;
			}
			if (text != null)
			{
				text.text = "";
			}
			if (this.OnClearButtonInformation != null)
			{
				this.OnClearButtonInformation();
			}
			this.OnRadialButtonInteract = null;
			this.OnRadialButtonInteractWithId = null;
			this.OnRadialButtonInteractWithKey = null;
			this.OnClearButtonInformation = null;
			unityEvent = null;
		}

		[Obsolete("Please use ClearButtonInformation instead.")]
		public void ResetRadialButtonInformation()
		{
			key = "";
			id = -1;
			this.OnRadialButtonInteract = null;
			this.OnRadialButtonInteractWithId = null;
			this.OnRadialButtonInteractWithKey = null;
		}
	}

	private bool inputInRangeLastFrame;

	private int buttonIndexOnInputDown = -1;

	private Vector3 defaultPosition;

	private RectTransform canvasRectTrans;

	private Vector2 parentCanvasSize;

	public int menuButtonCount = 4;

	public ScalingAxis scalingAxis = ScalingAxis.Height;

	public float menuSize = 5f;

	public float horizontalPosition = 50f;

	public float verticalPosition = 50f;

	public float depthPosition;

	public float menuButtonSize = 0.25f;

	public float radialMenuButtonRadius = 1f;

	public float startingAngle;

	public AngleOffset angleOffset;

	public bool followOrbitalRotation = true;

	public float minRange = 0.25f;

	public float maxRange = 1.5f;

	public bool infiniteMaxRange;

	public float buttonInputAngle;

	public UltimateRadialMenuStyle radialMenuStyle;

	private int currentStyleIndex;

	public Sprite normalSprite;

	public Color normalColor = Color.white;

	public InitialState initialState;

	public RadialMenuToggle radialMenuToggle;

	public float toggleInDuration = 0.25f;

	public float toggleOutDuration = 0.25f;

	private CanvasGroup canvasGroup;

	public bool displayButtonName;

	public Text nameText;

	public float nameTextRatioX = 1f;

	public float nameTextRatioY = 1f;

	public float nameTextSize = 0.25f;

	public float nameTextHorizontalPosition = 50f;

	public float nameTextVerticalPosition = 50f;

	public bool displayButtonDescription;

	public Text descriptionText;

	public float descriptionTextRatioX = 1f;

	public float descriptionTextRatioY = 1f;

	public float descriptionTextSize = 0.25f;

	public float descriptionTextHorizontalPosition = 50f;

	public float descriptionTextVerticalPosition = 50f;

	public bool useButtonIcon;

	public float iconSize = 0.25f;

	public float iconRotation;

	public float iconHorizontalPosition = 50f;

	public float iconVerticalPosition = 50f;

	public bool iconLocalRotation;

	public Color iconNormalColor = Color.white;

	public bool useButtonText;

	public float textAreaRatioX = 1f;

	public float textAreaRatioY = 0.25f;

	public float textSize = 0.25f;

	public float textHorizontalPosition = 50f;

	public float textVerticalPosition = 50f;

	public bool displayNameOnButton = true;

	public bool textLocalPosition = true;

	public bool textLocalRotation = true;

	public Color textNormalColor = Color.white;

	public Font nameFont;

	public Font descriptionFont;

	public Font buttonTextFont;

	public bool nameOutline;

	public bool descriptionOutline;

	public bool buttonTextOutline;

	public Color buttonTextOutlineColor = Color.white;

	public bool spriteSwap;

	public bool colorChange = true;

	public bool scaleTransform;

	public bool iconColorChange;

	public bool iconScaleTransform;

	public bool textColorChange;

	public Sprite highlightedSprite;

	public Color highlightedColor = Color.white;

	public float highlightedScaleModifier = 1.1f;

	public float positionModifier;

	public Color iconHighlightedColor = Color.white;

	public float iconHighlightedScaleModifier = 1.1f;

	public Color textHighlightedColor = Color.white;

	public Sprite pressedSprite;

	public Color pressedColor = Color.white;

	public float pressedScaleModifier = 1.05f;

	public float pressedPositionModifier;

	public Color iconPressedColor = Color.white;

	public float iconPressedScaleModifier = 1f;

	public Color textPressedColor = Color.white;

	public bool selectButtonOnInteract;

	public Sprite selectedSprite;

	public Color selectedColor = Color.white;

	public float selectedScaleModifier = 1f;

	public float selectedPositionModifier;

	public Color iconSelectedColor = Color.white;

	public float iconSelectedScaleModifier = 1f;

	public Color textSelectedColor = Color.white;

	public Sprite disabledSprite;

	public Color disabledColor = Color.white;

	public float disabledScaleModifier = 1f;

	public float disabledPositionModifier;

	public Color iconDisabledColor = Color.white;

	public float iconDisabledScaleModifier = 1f;

	public Color textDisabledColor = Color.white;

	public List<UltimateRadialButton> UltimateRadialButtonList = new List<UltimateRadialButton>();

	private List<UltimateRadialButton> UltimateRadialButtonPool = new List<UltimateRadialButton>();

	private static Dictionary<string, UltimateRadialMenu> UltimateRadialMenus = new Dictionary<string, UltimateRadialMenu>();

	public string radialMenuName = string.Empty;

	public Canvas ParentCanvas { get; private set; }

	public bool IsWorldSpaceRadialMenu { get; private set; }

	public float GetAnglePerButton => 360f / (float)menuButtonCount;

	public float GetCurrentInputAngle { get; private set; }

	public float CalculatedMinRange { get; private set; }

	public float CalculatedMaxRange { get; private set; }

	public RectTransform BaseTransform { get; private set; }

	public Vector3 BasePosition
	{
		get
		{
			if (BaseTransform == null)
			{
				return Vector3.zero;
			}
			return BaseTransform.position;
		}
	}

	public int CurrentButtonIndex { get; private set; }

	public int CurrentSelectedButtonIndex { get; set; }

	public bool RadialMenuActive { get; private set; }

	public bool InputInRange { get; private set; }

	public bool Interactable { get; set; }

	public bool InTransition { get; private set; }

	public event Action<int> OnRadialButtonEnter;

	public event Action<int> OnRadialButtonExit;

	public event Action<int> OnRadialButtonInputDown;

	public event Action<int> OnRadialButtonInputUp;

	public event Action<int> OnRadialButtonInteract;

	public event Action<int> OnRadialButtonSelected;

	public event Action OnRadialMenuLostFocus;

	public event Action OnRadialMenuEnabled;

	public event Action OnRadialMenuDisabled;

	public event Action OnRadialMenuStartingToDisable;

	public event Action OnUpdatePositioning;

	public event Action<int> OnRadialMenuButtonCountModified;

	[Obsolete("Please use OnUpdatePositioning instead")]
	public event Action OnUpdateSizeAndPlacement;

	private void Awake()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		if (radialMenuName != string.Empty)
		{
			if (UltimateRadialMenus.ContainsKey(radialMenuName))
			{
				UltimateRadialMenus.Remove(radialMenuName);
			}
			UltimateRadialMenus.Add(radialMenuName, GetComponent<UltimateRadialMenu>());
		}
		canvasGroup = GetComponent<CanvasGroup>();
		CurrentButtonIndex = -1;
		buttonIndexOnInputDown = -1;
		CurrentSelectedButtonIndex = -1;
		ResetRadialMenu();
		BaseTransform = GetComponent<RectTransform>();
		if (initialState == InitialState.Disabled)
		{
			RadialMenuActive = false;
			Interactable = false;
			DisableRadialMenuImmediate();
		}
		else
		{
			RadialMenuActive = true;
			Interactable = true;
		}
	}

	private void Start()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		if ((bool)UnityEngine.Object.FindObjectOfType<EventSystem>() && !UnityEngine.Object.FindObjectOfType<EventSystem>().gameObject.GetComponent<UltimateRadialMenuInputManager>())
		{
			Debug.LogWarning("Ultimate Radial Menu\nThere was no Ultimate Radial Menu Input Manager on the EventSystem in your scene. Adding a default Ultimate Radial Menu Input Manager to avoid errors, but you should ensure that you have an Ultimate Radial Menu Input Manager on your EventSystem so that you can customize the settings.");
			UnityEngine.Object.FindObjectOfType<EventSystem>().gameObject.AddComponent<UltimateRadialMenuInputManager>();
		}
		connectedPanels.Add(UnityEngine.Object.FindObjectOfType<InventoryManagerUI>());
		UltimateRadialMenuInputManager.Instance.AddRadialMenuToList(this);
		if (ParentCanvas == null)
		{
			UpdateParentCanvas();
			if (ParentCanvas == null)
			{
				Debug.LogError("Ultimate Radial Menu\nThis component is not with a Canvas object. Disabling this component to avoid any errors.");
				base.enabled = false;
				return;
			}
		}
		UpdatePositioning();
		if (!ParentCanvas.GetComponent<UltimateRadialMenuScreenSizeUpdater>())
		{
			ParentCanvas.gameObject.AddComponent<UltimateRadialMenuScreenSizeUpdater>();
		}
	}

	private void OnTransformParentChanged()
	{
		UpdateParentCanvas();
	}

	public void UpdateParentCanvas()
	{
		Transform parent = base.transform.parent;
		if (parent == null)
		{
			return;
		}
		while (parent != null)
		{
			if ((bool)parent.transform.GetComponent<Canvas>())
			{
				ParentCanvas = parent.transform.GetComponent<Canvas>();
				canvasRectTrans = ParentCanvas.GetComponent<RectTransform>();
				break;
			}
			parent = parent.transform.parent;
		}
	}

	public void ProcessInput(Vector2 input, float distance, bool inputDown, bool inputUp)
	{
		if (!RadialMenuActive || !Interactable)
		{
			return;
		}
		InputInRange = false;
		if (!IsWorldSpaceRadialMenu)
		{
			input = BaseTransform.InverseTransformPoint(BasePosition + (Vector3)input);
		}
		float num = Mathf.Atan2(input.y, input.x) * 57.29578f;
		if (num < 0f)
		{
			num += 360f;
		}
		GetCurrentInputAngle = num;
		for (int i = 0; i < UltimateRadialButtonList.Count; i++)
		{
			if (distance < CalculatedMinRange || distance > CalculatedMaxRange)
			{
				if (inputInRangeLastFrame)
				{
					ResetRadialMenu();
					if (this.OnRadialMenuLostFocus != null)
					{
						this.OnRadialMenuLostFocus();
					}
				}
				break;
			}
			if (CurrentButtonIndex >= 0 && UltimateRadialButtonList[CurrentButtonIndex].IsInAngle(num))
			{
				i = CurrentButtonIndex;
			}
			if (UltimateRadialButtonList[i].IsInAngle(num))
			{
				InputInRange = true;
				if (CurrentButtonIndex != i)
				{
					if (CurrentButtonIndex >= 0 && CurrentButtonIndex < UltimateRadialButtonList.Count)
					{
						buttonIndexOnInputDown = -1;
						UltimateRadialButtonList[CurrentButtonIndex].OnExit();
						if (this.OnRadialButtonExit != null)
						{
							this.OnRadialButtonExit(CurrentButtonIndex);
						}
					}
					CurrentButtonIndex = i;
					UltimateRadialButtonList[i].OnEnter();
					if (this.OnRadialButtonEnter != null)
					{
						this.OnRadialButtonEnter(i);
					}
				}
				if (displayButtonName && nameText != null)
				{
					nameText.text = UltimateRadialButtonList[i].name;
				}
				if (displayButtonDescription && descriptionText != null)
				{
					descriptionText.text = UltimateRadialButtonList[i].description;
				}
				break;
			}
			if (i == UltimateRadialButtonList.Count - 1)
			{
				ResetRadialMenu();
				if (this.OnRadialMenuLostFocus != null)
				{
					this.OnRadialMenuLostFocus();
				}
			}
		}
		if (inputInRangeLastFrame && UltimateRadialButtonList.Count == 0)
		{
			if (this.OnRadialMenuLostFocus != null)
			{
				this.OnRadialMenuLostFocus();
			}
			ResetRadialMenu();
		}
		if (inputDown && InputInRange && CurrentButtonIndex >= 0)
		{
			if (CurrentSelectedButtonIndex != CurrentButtonIndex)
			{
				UltimateRadialButtonList[CurrentButtonIndex].OnInputDown();
			}
			if (UltimateRadialMenuInputManager.Instance.invokeAction == UltimateRadialMenuInputManager.InvokeAction.OnButtonDown)
			{
				UltimateRadialButtonList[CurrentButtonIndex].OnInteract();
				if (UltimateRadialMenuInputManager.Instance.disableOnInteract && !IsWorldSpaceRadialMenu)
				{
					DisableRadialMenu();
				}
			}
			buttonIndexOnInputDown = CurrentButtonIndex;
			if (this.OnRadialButtonInputDown != null)
			{
				this.OnRadialButtonInputDown(CurrentButtonIndex);
			}
		}
		if (inputUp && InputInRange && CurrentButtonIndex >= 0)
		{
			if (CurrentSelectedButtonIndex != CurrentButtonIndex)
			{
				UltimateRadialButtonList[CurrentButtonIndex].OnInputUp();
			}
			if (UltimateRadialMenuInputManager.Instance.invokeAction == UltimateRadialMenuInputManager.InvokeAction.OnButtonClick && CurrentButtonIndex == buttonIndexOnInputDown)
			{
				UltimateRadialButtonList[CurrentButtonIndex].OnInteract();
				if (UltimateRadialMenuInputManager.Instance.disableOnInteract && !IsWorldSpaceRadialMenu)
				{
					DisableRadialMenu();
				}
			}
			buttonIndexOnInputDown = -1;
			if (this.OnRadialButtonInputUp != null)
			{
				this.OnRadialButtonInputUp(CurrentButtonIndex);
			}
		}
		inputInRangeLastFrame = InputInRange;
	}

	private void ResetRadialMenu()
	{
		if (CurrentButtonIndex >= 0 && CurrentButtonIndex < UltimateRadialButtonList.Count)
		{
			UltimateRadialButtonList[CurrentButtonIndex].OnExit();
		}
		CurrentButtonIndex = -1;
		buttonIndexOnInputDown = -1;
		if (displayButtonName && nameText != null)
		{
			nameText.text = "";
		}
		if (displayButtonDescription && descriptionText != null)
		{
			descriptionText.text = "";
		}
	}

	private IEnumerator FadeRadialMenu()
	{
		InTransition = true;
		Interactable = false;
		float speed = 1f / toggleInDuration;
		float startingAlpha = canvasGroup.alpha;
		for (float t = 0f; t < 1f; t += Time.unscaledDeltaTime * speed)
		{
			if (!RadialMenuActive)
			{
				break;
			}
			if (float.IsInfinity(speed))
			{
				break;
			}
			canvasGroup.alpha = Mathf.Lerp(startingAlpha, 1f, t);
			yield return null;
		}
		if (RadialMenuActive)
		{
			canvasGroup.alpha = 1f;
		}
		Interactable = true;
		while (RadialMenuActive)
		{
			yield return null;
		}
		Interactable = false;
		speed = 1f / toggleOutDuration;
		startingAlpha = canvasGroup.alpha;
		for (float t = 0f; t < 1f; t += Time.unscaledDeltaTime * speed)
		{
			if (RadialMenuActive)
			{
				break;
			}
			if (float.IsInfinity(speed))
			{
				break;
			}
			canvasGroup.alpha = Mathf.Lerp(startingAlpha, 0f, t);
			yield return null;
		}
		if (!RadialMenuActive)
		{
			canvasGroup.alpha = 0f;
		}
		if (this.OnRadialMenuDisabled != null)
		{
			this.OnRadialMenuDisabled();
		}
		InTransition = false;
	}

	private IEnumerator ScaleRadialMenu()
	{
		InTransition = true;
		Interactable = false;
		float speed = 1f / toggleInDuration;
		Vector3 startingScale = BaseTransform.localScale;
		for (float t = 0f; t < 1f; t += Time.unscaledDeltaTime * speed)
		{
			if (!RadialMenuActive)
			{
				break;
			}
			if (float.IsInfinity(speed))
			{
				break;
			}
			BaseTransform.localScale = Vector3.Lerp(startingScale, Vector3.one, t);
			yield return null;
		}
		if (RadialMenuActive)
		{
			BaseTransform.localScale = Vector3.one;
		}
		Interactable = true;
		while (RadialMenuActive)
		{
			yield return null;
		}
		Interactable = false;
		speed = 1f / toggleOutDuration;
		startingScale = BaseTransform.localScale;
		for (float t = 0f; t < 1f; t += Time.unscaledDeltaTime * speed)
		{
			if (RadialMenuActive)
			{
				break;
			}
			if (float.IsInfinity(speed))
			{
				break;
			}
			BaseTransform.localScale = Vector3.Lerp(startingScale, Vector3.zero, t);
			yield return null;
		}
		if (!RadialMenuActive)
		{
			BaseTransform.localScale = Vector3.zero;
		}
		if (this.OnRadialMenuDisabled != null)
		{
			this.OnRadialMenuDisabled();
		}
		InTransition = false;
	}

	private Vector2 GetImageAspectRatio(Sprite sprite)
	{
		Vector2 one = Vector2.one;
		Vector2 vector = new Vector2(sprite.rect.width, sprite.rect.height);
		float num = ((vector.x > vector.y) ? vector.x : vector.y);
		one.x = vector.x / num;
		one.y = vector.y / num;
		return one;
	}

	private void CreateRadialButtonAtIndex(int buttonIndex)
	{
		if (buttonIndex < 0)
		{
			buttonIndex = 0;
		}
		if (buttonIndex > UltimateRadialButtonList.Count)
		{
			buttonIndex = UltimateRadialButtonList.Count;
		}
		if (radialMenuStyle != null && UltimateRadialButtonList.Count >= radialMenuStyle.maxButtonCount)
		{
			Debug.LogWarning("Ultimate Radial Menu\nThe current radial menu button count is out of range for this style. The buttons may look strange because there is no corresponding button sprite to use with this count.");
		}
		if (UltimateRadialButtonPool.Count > 0)
		{
			UltimateRadialButtonList.Insert(buttonIndex, GetRadialButtonFromPool());
		}
		else
		{
			UltimateRadialButtonList.Insert(buttonIndex, new UltimateRadialButton());
			UltimateRadialButtonList[buttonIndex].radialMenu = this;
			GameObject gameObject = new GameObject();
			gameObject.AddComponent<RectTransform>();
			gameObject.AddComponent<CanvasRenderer>();
			gameObject.AddComponent<Image>();
			GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, Vector3.zero, Quaternion.identity);
			gameObject2.transform.SetParent(BaseTransform);
			gameObject2.gameObject.name = "Radial Menu Button";
			gameObject2.transform.SetAsLastSibling();
			UltimateRadialButtonList[buttonIndex].buttonTransform = gameObject2.GetComponent<RectTransform>();
			UltimateRadialButtonList[buttonIndex].buttonTransform.anchorMin = new Vector2(0.5f, 0.5f);
			UltimateRadialButtonList[buttonIndex].buttonTransform.anchorMax = new Vector2(0.5f, 0.5f);
			UltimateRadialButtonList[buttonIndex].buttonTransform.pivot = new Vector2(0.5f, 0.5f);
			UltimateRadialButtonList[buttonIndex].buttonTransform.localScale = Vector3.one;
			UltimateRadialButtonList[buttonIndex].radialImage = gameObject2.GetComponent<Image>();
			UltimateRadialButtonList[buttonIndex].radialImage.sprite = normalSprite;
			if (UltimateRadialButtonList[buttonIndex].radialImage.sprite != null)
			{
				UltimateRadialButtonList[buttonIndex].radialImage.color = normalColor;
			}
			else
			{
				UltimateRadialButtonList[buttonIndex].radialImage.color = Color.clear;
			}
			if (useButtonIcon)
			{
				GameObject gameObject3 = UnityEngine.Object.Instantiate(gameObject, Vector3.zero, Quaternion.identity);
				gameObject3.transform.SetParent(UltimateRadialButtonList[buttonIndex].buttonTransform);
				gameObject3.gameObject.name = "Icon " + buttonIndex.ToString("00");
				UltimateRadialButtonList[buttonIndex].iconTransform = gameObject3.GetComponent<RectTransform>();
				UltimateRadialButtonList[buttonIndex].buttonTransform.anchorMin = new Vector2(0.5f, 0.5f);
				UltimateRadialButtonList[buttonIndex].buttonTransform.anchorMax = new Vector2(0.5f, 0.5f);
				UltimateRadialButtonList[buttonIndex].buttonTransform.pivot = new Vector2(0.5f, 0.5f);
				UltimateRadialButtonList[buttonIndex].iconTransform.localScale = Vector3.one;
				UltimateRadialButtonList[buttonIndex].icon = gameObject3.GetComponent<Image>();
				UltimateRadialButtonList[buttonIndex].icon.sprite = null;
				UltimateRadialButtonList[buttonIndex].icon.color = Color.clear;
			}
			if (useButtonText)
			{
				GameObject obj = new GameObject();
				obj.AddComponent<RectTransform>();
				obj.AddComponent<CanvasRenderer>();
				GameObject gameObject4 = UnityEngine.Object.Instantiate(obj, Vector3.zero, Quaternion.identity);
				gameObject4.transform.SetParent(UltimateRadialButtonList[buttonIndex].buttonTransform);
				gameObject4.gameObject.name = "Text " + buttonIndex.ToString("00");
				UltimateRadialButtonList[buttonIndex].text = gameObject4.AddComponent<Text>();
				UltimateRadialButtonList[buttonIndex].text.text = "";
				UltimateRadialButtonList[buttonIndex].text.alignment = TextAnchor.MiddleCenter;
				UltimateRadialButtonList[buttonIndex].text.resizeTextForBestFit = true;
				UltimateRadialButtonList[buttonIndex].text.resizeTextMinSize = 0;
				UltimateRadialButtonList[buttonIndex].text.resizeTextMaxSize = 300;
				if (buttonTextFont != null)
				{
					UltimateRadialButtonList[buttonIndex].text.font = buttonTextFont;
				}
				UltimateRadialButtonList[buttonIndex].text.color = textNormalColor;
				UltimateRadialButtonList[buttonIndex].text.rectTransform.localScale = Vector3.one;
				if (buttonTextOutline)
				{
					gameObject4.AddComponent<Outline>().effectColor = buttonTextOutlineColor;
				}
				UnityEngine.Object.Destroy(obj);
			}
			UnityEngine.Object.Destroy(gameObject);
		}
		RadialMenuButtonCountModified();
	}

	private void FindRadialButtonIndex(ref int buttonIndex)
	{
		if (buttonIndex < 0)
		{
			for (int i = 0; i < UltimateRadialButtonList.Count; i++)
			{
				if (!UltimateRadialButtonList[i].Registered && !UltimateRadialButtonList[i].buttonDisabled)
				{
					buttonIndex = i;
					return;
				}
			}
			CreateRadialButtonAtIndex(1000);
			buttonIndex = UltimateRadialButtonList.Count - 1;
		}
		else if (buttonIndex > UltimateRadialButtonList.Count)
		{
			CreateRadialButtonAtIndex(1000);
			buttonIndex = UltimateRadialButtonList.Count - 1;
		}
		else if (UltimateRadialButtonList[buttonIndex].Registered || UltimateRadialButtonList[buttonIndex].buttonDisabled)
		{
			CreateRadialButtonAtIndex(buttonIndex);
		}
	}

	private UltimateRadialButton GetRadialButtonFromPool()
	{
		UltimateRadialButton ultimateRadialButton = UltimateRadialButtonPool[0];
		ultimateRadialButton.buttonTransform.gameObject.SetActive(value: true);
		UltimateRadialButtonPool.Remove(ultimateRadialButton);
		return ultimateRadialButton;
	}

	private void SendRadialButtonToPool(int buttonIndex)
	{
		UltimateRadialButtonPool.Add(UltimateRadialButtonList[buttonIndex]);
		UltimateRadialButtonList[buttonIndex].buttonTransform.gameObject.SetActive(value: false);
		UltimateRadialButtonList.RemoveAt(buttonIndex);
	}

	private void RadialMenuButtonCountModified()
	{
		menuButtonCount = UltimateRadialButtonList.Count;
		if (radialMenuStyle != null)
		{
			for (int i = 0; i < radialMenuStyle.RadialMenuStyles.Count; i++)
			{
				if (radialMenuStyle.RadialMenuStyles[i].buttonCount == menuButtonCount)
				{
					currentStyleIndex = i;
					break;
				}
			}
			normalSprite = radialMenuStyle.RadialMenuStyles[currentStyleIndex].normalSprite;
			if (spriteSwap)
			{
				highlightedSprite = radialMenuStyle.RadialMenuStyles[currentStyleIndex].highlightedSprite;
				pressedSprite = radialMenuStyle.RadialMenuStyles[currentStyleIndex].pressedSprite;
				selectedSprite = radialMenuStyle.RadialMenuStyles[currentStyleIndex].selectedSprite;
				disabledSprite = radialMenuStyle.RadialMenuStyles[currentStyleIndex].disabledSprite;
			}
			for (int j = 0; j < UltimateRadialButtonList.Count; j++)
			{
				if (UltimateRadialButtonList[j].buttonDisabled)
				{
					UltimateRadialButtonList[j].radialImage.sprite = disabledSprite;
				}
				else if (CurrentSelectedButtonIndex >= 0 && CurrentSelectedButtonIndex == j)
				{
					UltimateRadialButtonList[j].radialImage.sprite = selectedSprite;
				}
				else
				{
					UltimateRadialButtonList[j].radialImage.sprite = normalSprite;
				}
			}
		}
		if (this.OnRadialMenuButtonCountModified != null)
		{
			this.OnRadialMenuButtonCountModified(menuButtonCount);
		}
		UpdatePositioning();
	}

	public void UpdatePositioning()
	{
		if (ParentCanvas == null)
		{
			UpdateParentCanvas();
		}
		if (ParentCanvas == null)
		{
			Debug.LogError("Ultimate Radial Menu\nThere is no parent canvas object. Please make sure that the Ultimate Radial Menu is placed within a canvas.");
			return;
		}
		float num = ((scalingAxis == ScalingAxis.Height) ? canvasRectTrans.sizeDelta.y : canvasRectTrans.sizeDelta.x) * (menuSize / 10f);
		if (BaseTransform == null)
		{
			BaseTransform = GetComponent<RectTransform>();
		}
		BaseTransform.localScale = Vector3.one;
		if (BaseTransform.pivot != Vector2.one / 2f)
		{
			BaseTransform.pivot = Vector2.one / 2f;
		}
		Vector2 vector = new Vector2(horizontalPosition - 50f, verticalPosition - 50f) / 100f;
		BaseTransform.localPosition = (Vector3)(canvasRectTrans.sizeDelta * vector) - (Vector3)(Vector2.one * num * vector);
		BaseTransform.sizeDelta = new Vector2(num, num);
		BaseTransform.localRotation = Quaternion.identity;
		defaultPosition = BaseTransform.position;
		CalculatedMinRange = BaseTransform.sizeDelta.x / 2f * minRange;
		if (infiniteMaxRange)
		{
			CalculatedMaxRange = float.PositiveInfinity;
		}
		else
		{
			CalculatedMaxRange = BaseTransform.sizeDelta.x / 2f * maxRange;
		}
		if (ParentCanvas.renderMode == RenderMode.WorldSpace)
		{
			IsWorldSpaceRadialMenu = true;
			if (!BaseTransform.GetComponent<BoxCollider>())
			{
				BaseTransform.gameObject.AddComponent<BoxCollider>();
			}
			BaseTransform.GetComponent<BoxCollider>().isTrigger = true;
			BaseTransform.GetComponent<BoxCollider>().size = new Vector3(BaseTransform.sizeDelta.x * maxRange, BaseTransform.sizeDelta.y * maxRange, 0.001f);
			BaseTransform.localPosition += new Vector3(0f, 0f, depthPosition);
		}
		else
		{
			IsWorldSpaceRadialMenu = false;
			if ((bool)BaseTransform.GetComponent<BoxCollider>())
			{
				UnityEngine.Object.DestroyImmediate(BaseTransform.GetComponent<BoxCollider>());
			}
		}
		if (displayButtonName && nameText != null)
		{
			Vector2 zero = Vector2.zero;
			zero.x += BaseTransform.sizeDelta.x * ((nameTextHorizontalPosition - 50f) / 100f);
			zero.y += BaseTransform.sizeDelta.y * ((nameTextVerticalPosition - 50f) / 100f);
			nameText.rectTransform.sizeDelta = new Vector2(BaseTransform.sizeDelta.x * nameTextSize, BaseTransform.sizeDelta.x * nameTextSize) * new Vector2(nameTextRatioX, nameTextRatioY);
			nameText.rectTransform.localPosition = zero;
			nameText.rectTransform.localRotation = Quaternion.identity;
		}
		if (displayButtonDescription && descriptionText != null)
		{
			Vector2 zero2 = Vector2.zero;
			zero2.x += BaseTransform.sizeDelta.x * ((descriptionTextHorizontalPosition - 50f) / 100f);
			zero2.y += BaseTransform.sizeDelta.y * ((descriptionTextVerticalPosition - 50f) / 100f);
			descriptionText.rectTransform.sizeDelta = new Vector2(BaseTransform.sizeDelta.x * descriptionTextSize, BaseTransform.sizeDelta.x * descriptionTextSize) * new Vector2(descriptionTextRatioX, descriptionTextRatioY);
			descriptionText.rectTransform.localPosition = zero2;
			descriptionText.rectTransform.localRotation = Quaternion.identity;
		}
		float getAnglePerButton = GetAnglePerButton;
		float num2 = (0f - getAnglePerButton) * (MathF.PI / 180f);
		float num3 = 0f;
		num3 = angleOffset switch
		{
			AngleOffset.OffCenter => 0f, 
			AngleOffset.OnlyEven => (menuButtonCount % 2 != 0) ? 0f : (GetAnglePerButton / 2f), 
			AngleOffset.OnlyOdd => (menuButtonCount % 2 == 0) ? 0f : (GetAnglePerButton / 2f), 
			_ => GetAnglePerButton / 2f, 
		};
		float num4 = 0f - startingAngle + num3 - GetAnglePerButton / 2f;
		float num5 = MathF.PI / 2f + (0f - startingAngle) * (MathF.PI / 180f);
		Vector2 sizeDelta = BaseTransform.sizeDelta * menuButtonSize;
		if (normalSprite != null)
		{
			sizeDelta *= GetImageAspectRatio(normalSprite);
		}
		float num6 = BaseTransform.sizeDelta.x / 2f * radialMenuButtonRadius - sizeDelta.y / 2f;
		for (int i = 0; i < UltimateRadialButtonList.Count; i++)
		{
			UltimateRadialButtonList[i].buttonIndex = i;
			if (UltimateRadialButtonList[i].radialImage == null)
			{
				UltimateRadialButtonList[i].radialImage = UltimateRadialButtonList[i].buttonTransform.GetComponent<Image>();
			}
			UltimateRadialButtonList[i].buttonTransform.sizeDelta = sizeDelta;
			Vector3 zero3 = Vector3.zero;
			zero3.x += Mathf.Cos(num2 * (float)i + num5 + num3 * (MathF.PI / 180f) + num2 / 2f) * num6;
			zero3.y += Mathf.Sin(num2 * (float)i + num5 + num3 * (MathF.PI / 180f) + num2 / 2f) * num6;
			UltimateRadialButtonList[i].buttonTransform.localPosition = zero3;
			UltimateRadialButtonList[i].buttonTransform.localScale = ((scaleTransform && UltimateRadialButtonList[i].buttonDisabled) ? (Vector3.one * disabledScaleModifier) : Vector3.one);
			if (scaleTransform)
			{
				UltimateRadialButtonList[i].normalPosition = zero3;
				if (positionModifier != 0f)
				{
					Vector3 zero4 = Vector3.zero;
					zero4.x += Mathf.Cos(num2 * (float)i + num5 + num3 * (MathF.PI / 180f) + num2 / 2f) * (num6 + num6 * positionModifier);
					zero4.y += Mathf.Sin(num2 * (float)i + num5 + num3 * (MathF.PI / 180f) + num2 / 2f) * (num6 + num6 * positionModifier);
					UltimateRadialButtonList[i].highlightedPosition = zero4;
				}
				else
				{
					UltimateRadialButtonList[i].highlightedPosition = zero3;
				}
				if (pressedPositionModifier != 0f)
				{
					Vector3 zero5 = Vector3.zero;
					zero5.x += Mathf.Cos(num2 * (float)i + num5 + num3 * (MathF.PI / 180f) + num2 / 2f) * (num6 + num6 * selectedPositionModifier);
					zero5.y += Mathf.Sin(num2 * (float)i + num5 + num3 * (MathF.PI / 180f) + num2 / 2f) * (num6 + num6 * selectedPositionModifier);
					UltimateRadialButtonList[i].pressedPosition = zero5;
				}
				else
				{
					UltimateRadialButtonList[i].pressedPosition = zero3;
				}
				if (selectedPositionModifier != 0f)
				{
					Vector3 zero6 = Vector3.zero;
					zero6.x += Mathf.Cos(num2 * (float)i + num5 + num3 * (MathF.PI / 180f) + num2 / 2f) * (num6 + num6 * selectedPositionModifier);
					zero6.y += Mathf.Sin(num2 * (float)i + num5 + num3 * (MathF.PI / 180f) + num2 / 2f) * (num6 + num6 * selectedPositionModifier);
					UltimateRadialButtonList[i].selectedPosition = zero6;
				}
				else
				{
					UltimateRadialButtonList[i].selectedPosition = zero3;
				}
				if (disabledPositionModifier != 0f)
				{
					Vector3 zero7 = Vector3.zero;
					zero7.x += Mathf.Cos(num2 * (float)i + num5 + num3 * (MathF.PI / 180f) + num2 / 2f) * (num6 + num6 * disabledPositionModifier);
					zero7.y += Mathf.Sin(num2 * (float)i + num5 + num3 * (MathF.PI / 180f) + num2 / 2f) * (num6 + num6 * disabledPositionModifier);
					UltimateRadialButtonList[i].disabledPosition = zero7;
					if (UltimateRadialButtonList[i].buttonDisabled)
					{
						UltimateRadialButtonList[i].buttonTransform.localPosition = zero7;
					}
				}
				else
				{
					UltimateRadialButtonList[i].disabledPosition = zero3;
				}
			}
			UltimateRadialButtonList[i].angle = 90f + (0f - startingAngle) + num3 + (0f - getAnglePerButton) * (float)i - getAnglePerButton / 2f;
			UltimateRadialButtonList[i].angleRange = getAnglePerButton / 2f * buttonInputAngle;
			if (UltimateRadialButtonList[i].angle <= -360f)
			{
				UltimateRadialButtonList[i].angle += 360f;
			}
			if (UltimateRadialButtonList[i].angle < 0f)
			{
				UltimateRadialButtonList[i].angle += 360f;
			}
			Vector3 euler = Vector3.zero;
			if (followOrbitalRotation)
			{
				euler = new Vector3(0f, 0f, (0f - getAnglePerButton) * (float)i + num4);
			}
			UltimateRadialButtonList[i].buttonTransform.localRotation = Quaternion.Euler(euler);
			if (useButtonIcon && UltimateRadialButtonList[i].icon != null)
			{
				float num7 = iconHorizontalPosition;
				float num8 = iconVerticalPosition;
				float num9 = iconSize;
				float num10 = iconRotation;
				if (UltimateRadialButtonList[i].useIconUnique)
				{
					num7 = UltimateRadialButtonList[i].iconHorizontalPosition;
					num8 = UltimateRadialButtonList[i].iconVerticalPosition;
					num9 = UltimateRadialButtonList[i].iconSize;
					num10 = UltimateRadialButtonList[i].iconRotation;
				}
				Vector2 vector2 = Vector3.zero;
				vector2.x += UltimateRadialButtonList[i].buttonTransform.sizeDelta.x * (num7 / 100f) - UltimateRadialButtonList[i].buttonTransform.sizeDelta.x / 2f;
				vector2.y += UltimateRadialButtonList[i].buttonTransform.sizeDelta.y * (num8 / 100f) - UltimateRadialButtonList[i].buttonTransform.sizeDelta.y / 2f;
				UltimateRadialButtonList[i].icon.rectTransform.sizeDelta = new Vector2(BaseTransform.sizeDelta.x * num9, BaseTransform.sizeDelta.x * num9) * ((UltimateRadialButtonList[i].icon.sprite == null) ? Vector2.one : GetImageAspectRatio(UltimateRadialButtonList[i].icon.sprite));
				UltimateRadialButtonList[i].icon.rectTransform.localPosition = vector2;
				if (UltimateRadialButtonList[i].iconTransform == null)
				{
					UltimateRadialButtonList[i].iconTransform = UltimateRadialButtonList[i].icon.rectTransform;
				}
				UltimateRadialButtonList[i].iconNormalScale = (UltimateRadialButtonList[i].invertScaleY ? new Vector3(1f, -1f, 1f) : new Vector3(1f, 1f, 1f));
				UltimateRadialButtonList[i].iconTransform.localScale = (UltimateRadialButtonList[i].buttonDisabled ? (UltimateRadialButtonList[i].iconNormalScale * iconDisabledScaleModifier) : UltimateRadialButtonList[i].iconNormalScale);
				if (iconLocalRotation)
				{
					float num11 = UltimateRadialButtonList[i].radialImage.rectTransform.localRotation.eulerAngles.z;
					if (num11 < 0f)
					{
						num11 += 360f;
					}
					if (num11 > 90f && num11 < 270f)
					{
						num10 += 180f;
					}
				}
				else
				{
					num10 = 0f - UltimateRadialButtonList[i].buttonTransform.localRotation.eulerAngles.z + (UltimateRadialButtonList[i].useIconUnique ? UltimateRadialButtonList[i].iconRotation : (0f - iconRotation));
				}
				UltimateRadialButtonList[i].icon.rectTransform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, num10));
			}
			if (UltimateRadialButtonList[i].text != null)
			{
				UltimateRadialButtonList[i].text.rectTransform.sizeDelta = new Vector2(BaseTransform.sizeDelta.x * textSize, BaseTransform.sizeDelta.x * textSize) * new Vector2(textAreaRatioX, textAreaRatioY);
				if (textLocalPosition)
				{
					Vector2 zero8 = Vector2.zero;
					Vector2 vector3 = new Vector2(UltimateRadialButtonList[i].buttonTransform.sizeDelta.x, UltimateRadialButtonList[i].buttonTransform.sizeDelta.y) * 1.25f;
					zero8.x += vector3.x * (textHorizontalPosition / 100f) - vector3.x / 2f;
					zero8.y += vector3.y * (textVerticalPosition / 100f) - vector3.y / 2f;
					UltimateRadialButtonList[i].text.rectTransform.localPosition = zero8;
					if (textLocalRotation)
					{
						float num12 = UltimateRadialButtonList[i].radialImage.rectTransform.localRotation.eulerAngles.z;
						if (num12 < 0f)
						{
							num12 += 360f;
						}
						if (num12 > 90f && num12 < 270f)
						{
							UltimateRadialButtonList[i].text.rectTransform.localRotation = Quaternion.Euler(0f, 0f, 180f);
						}
						else
						{
							UltimateRadialButtonList[i].text.rectTransform.localRotation = Quaternion.identity;
						}
					}
					else
					{
						UltimateRadialButtonList[i].text.rectTransform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f - UltimateRadialButtonList[i].buttonTransform.localRotation.eulerAngles.z));
					}
				}
				else
				{
					Vector3 vector4 = Vector3.zero;
					Vector2 vector5 = new Vector2(UltimateRadialButtonList[i].buttonTransform.sizeDelta.x, UltimateRadialButtonList[i].buttonTransform.sizeDelta.y) * 1.25f;
					vector4.x += vector5.x * (textHorizontalPosition / 100f) - vector5.x / 2f;
					vector4.y += vector5.y * (textVerticalPosition / 100f) - vector5.y / 2f;
					if (IsWorldSpaceRadialMenu)
					{
						vector4 = BaseTransform.transform.TransformPoint(vector4);
						vector4 -= BaseTransform.position;
					}
					UltimateRadialButtonList[i].text.rectTransform.position = UltimateRadialButtonList[i].buttonTransform.position + vector4;
					UltimateRadialButtonList[i].text.rectTransform.localRotation = Quaternion.Euler(0f, 0f, 0f - UltimateRadialButtonList[i].buttonTransform.localRotation.eulerAngles.z);
				}
			}
			if (Application.isPlaying && scaleTransform && CurrentSelectedButtonIndex >= 0 && CurrentSelectedButtonIndex == i)
			{
				UltimateRadialButtonList[i].buttonTransform.localScale = Vector3.one * selectedScaleModifier;
				UltimateRadialButtonList[i].buttonTransform.localPosition = UltimateRadialButtonList[i].selectedPosition;
			}
		}
		CurrentButtonIndex = -1;
		BaseTransform.localScale = ((radialMenuToggle == RadialMenuToggle.Scale && !RadialMenuActive && Application.isPlaying) ? Vector3.zero : Vector3.one);
		if (this.OnUpdatePositioning != null)
		{
			this.OnUpdatePositioning();
		}
	}

	public void RegisterToRadialMenu(Action ButtonCallback, UltimateRadialButtonInfo buttonInfo, int buttonIndex = -1)
	{
		FindRadialButtonIndex(ref buttonIndex);
		UltimateRadialButtonList[buttonIndex].RegisterButtonInfo(buttonInfo);
		UltimateRadialButtonList[buttonIndex].AddCallback(ButtonCallback);
	}

	public void RegisterToRadialMenu(Action<int> ButtonCallback, UltimateRadialButtonInfo buttonInfo, int buttonIndex = -1)
	{
		FindRadialButtonIndex(ref buttonIndex);
		UltimateRadialButtonList[buttonIndex].RegisterButtonInfo(buttonInfo);
		UltimateRadialButtonList[buttonIndex].AddCallback(ButtonCallback);
	}

	public void RegisterToRadialMenu(Action<string> ButtonCallback, UltimateRadialButtonInfo buttonInfo, int buttonIndex = -1)
	{
		FindRadialButtonIndex(ref buttonIndex);
		UltimateRadialButtonList[buttonIndex].RegisterButtonInfo(buttonInfo);
		UltimateRadialButtonList[buttonIndex].AddCallback(ButtonCallback);
	}

	public void EnableRadialMenu()
	{
		if (!RadialMenuActive)
		{
			RadialMenuActive = true;
			RadialMenuToggle radialMenuToggle = this.radialMenuToggle;
			if (radialMenuToggle == RadialMenuToggle.FadeAlpha || radialMenuToggle != RadialMenuToggle.Scale)
			{
				StartCoroutine(FadeRadialMenu());
			}
			else
			{
				StartCoroutine(ScaleRadialMenu());
			}
			if (this.OnRadialMenuEnabled != null)
			{
				this.OnRadialMenuEnabled();
			}
		}
	}

	public void DisableRadialMenu()
	{
		if (!RadialMenuActive)
		{
			return;
		}
		this.OnRadialMenuStartingToDisable();
		RadialMenuActive = false;
		ResetRadialMenu();
		if (!InTransition)
		{
			RadialMenuToggle radialMenuToggle = this.radialMenuToggle;
			if (radialMenuToggle == RadialMenuToggle.FadeAlpha || radialMenuToggle != RadialMenuToggle.Scale)
			{
				StartCoroutine(FadeRadialMenu());
			}
			else
			{
				StartCoroutine(ScaleRadialMenu());
			}
		}
		InputInRange = false;
	}

	public void DisableRadialMenuImmediate()
	{
		RadialMenuActive = false;
		ResetRadialMenu();
		RadialMenuToggle radialMenuToggle = this.radialMenuToggle;
		if (radialMenuToggle == RadialMenuToggle.FadeAlpha || radialMenuToggle != RadialMenuToggle.Scale)
		{
			canvasGroup.alpha = 0f;
		}
		else
		{
			BaseTransform.localScale = Vector3.zero;
		}
		if (this.OnRadialMenuDisabled != null)
		{
			this.OnRadialMenuDisabled();
		}
	}

	public void CreateEmptyRadialButton()
	{
		CreateRadialButtonAtIndex(1000);
	}

	public void RemoveAllRadialButtons(int buttonCount = 0)
	{
		if (radialMenuStyle != null && buttonCount < radialMenuStyle.minButtonCount)
		{
			buttonCount = radialMenuStyle.minButtonCount;
		}
		for (int num = UltimateRadialButtonList.Count - 1; num >= 0; num--)
		{
			UltimateRadialButtonList[num].ClearButtonInformation();
			if (num >= buttonCount)
			{
				SendRadialButtonToPool(num);
			}
		}
		RadialMenuButtonCountModified();
		CurrentSelectedButtonIndex = -1;
	}

	public void RemoveRadialButton(int buttonIndex)
	{
		if (UltimateRadialButtonList.Count > 0)
		{
			if (buttonIndex > UltimateRadialButtonList.Count)
			{
				buttonIndex = UltimateRadialButtonList.Count - 1;
			}
			UltimateRadialButtonList[buttonIndex].ClearButtonInformation();
			if (radialMenuStyle != null && menuButtonCount - 1 < radialMenuStyle.minButtonCount)
			{
				menuButtonCount = radialMenuStyle.minButtonCount;
				return;
			}
			SendRadialButtonToPool(buttonIndex);
			RadialMenuButtonCountModified();
		}
	}

	public void ClearRadialButtonInformations()
	{
		for (int i = 0; i < UltimateRadialButtonList.Count; i++)
		{
			UltimateRadialButtonList[i].ClearButtonInformation();
		}
		ResetRadialMenu();
		CurrentSelectedButtonIndex = -1;
	}

	public void SetPosition(Vector3 position, bool local = false)
	{
		if (!(BaseTransform != null))
		{
			return;
		}
		if (IsWorldSpaceRadialMenu)
		{
			if (ParentCanvas == null)
			{
				UpdateParentCanvas();
				if (ParentCanvas == null)
				{
					Debug.LogError("Ultimate Radial Menu\nThere is no parent canvas object. Please make sure that the Ultimate Radial Menu is placed within a canvas.");
					return;
				}
			}
			ParentCanvas.GetComponent<RectTransform>().position = position;
		}
		else if (local)
		{
			BaseTransform.localPosition = position;
		}
		else
		{
			BaseTransform.position = position;
		}
	}

	public void ResetPosition()
	{
		if (BaseTransform != null)
		{
			BaseTransform.position = defaultPosition;
		}
	}

	public void SetParent(Transform parent, Vector3 localPosition, Quaternion localRotation)
	{
		if (ParentCanvas == null)
		{
			UpdateParentCanvas();
			if (ParentCanvas == null)
			{
				Debug.LogError("Ultimate Radial Menu\nThere is no parent canvas object. Please make sure that the Ultimate Radial Menu is placed within a canvas.");
				return;
			}
		}
		ParentCanvas.transform.SetParent(parent);
		ParentCanvas.GetComponent<RectTransform>().localRotation = localRotation;
		ParentCanvas.GetComponent<RectTransform>().localPosition = localPosition;
	}

	private static bool ConfirmUltimateRadialMenu(string radialMenuName)
	{
		if (!UltimateRadialMenus.ContainsKey(radialMenuName))
		{
			Debug.LogWarning("Ultimate Radial Menu\nThere is no Ultimate Radial Menu registered with the name: " + radialMenuName + " in the scene.");
			return false;
		}
		return true;
	}

	public static UltimateRadialMenu GetUltimateRadialMenu(string radialMenuName)
	{
		if (!ConfirmUltimateRadialMenu(radialMenuName))
		{
			return null;
		}
		return UltimateRadialMenus[radialMenuName];
	}

	public static void RegisterToRadialMenu(string radialMenuName, Action ButtonCallback, UltimateRadialButtonInfo buttonInfo, int buttonIndex = -1)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].RegisterToRadialMenu(ButtonCallback, buttonInfo, buttonIndex);
		}
	}

	public static void RegisterToRadialMenu(string radialMenuName, Action<int> ButtonCallback, UltimateRadialButtonInfo buttonInfo, int buttonIndex = -1)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].RegisterToRadialMenu(ButtonCallback, buttonInfo, buttonIndex);
		}
	}

	public static void RegisterToRadialMenu(string radialMenuName, Action<string> ButtonCallback, UltimateRadialButtonInfo buttonInfo, int buttonIndex = -1)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].RegisterToRadialMenu(ButtonCallback, buttonInfo, buttonIndex);
		}
	}

	public static void EnableRadialMenu(string radialMenuName)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].EnableRadialMenu();
		}
	}

	public static void DisableRadialMenu(string radialMenuName)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].DisableRadialMenu();
		}
	}

	public static void DisableRadialMenuImmediate(string radialMenuName)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].DisableRadialMenuImmediate();
		}
	}

	public static void CreateEmptyRadialButton(string radialMenuName)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].CreateEmptyRadialButton();
		}
	}

	public static void RemoveAllRadialButtons(string radialMenuName)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].RemoveAllRadialButtons();
		}
	}

	public static void RemoveRadialButton(string radialMenuName, int buttonIndex)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].RemoveRadialButton(buttonIndex);
		}
	}

	public static void ClearRadialButtonInformations(string radialMenuName)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].ClearRadialButtonInformations();
		}
	}

	public static void SetPosition(string radialMenuName, Vector3 position, bool local = false)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].SetPosition(position, local);
		}
	}

	public static void ResetPosition(string radialMenuName)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].ResetPosition();
		}
	}

	public static void SetParent(string radialMenuName, Transform parent, Vector3 localPosition, Quaternion localRotation)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].SetParent(parent, localPosition, localRotation);
		}
	}

	[Obsolete]
	private bool ConfirmRadialButtonIndex(int index)
	{
		if (index > UltimateRadialButtonList.Count || index < 0)
		{
			Debug.LogWarning("Ultimate Radial Menu\nThe index is out of range for this radial menu.");
			return false;
		}
		return true;
	}

	[Obsolete]
	private void UpdateRadialButtonInformation(int buttonIndex, UltimateRadialButtonInfo radialButtonInfo)
	{
		radialButtonInfo.radialButton = UltimateRadialButtonList[buttonIndex];
		UltimateRadialButtonList[buttonIndex].key = radialButtonInfo.key;
		UltimateRadialButtonList[buttonIndex].id = radialButtonInfo.id;
		if (radialButtonInfo.name != string.Empty)
		{
			UltimateRadialButtonList[buttonIndex].name = radialButtonInfo.name;
		}
		if (radialButtonInfo.description != string.Empty)
		{
			UltimateRadialButtonList[buttonIndex].description = radialButtonInfo.description;
		}
		UltimateRadialButtonList[buttonIndex].radialImage.enabled = true;
		if (useButtonIcon && UltimateRadialButtonList[buttonIndex].icon != null)
		{
			UltimateRadialButtonList[buttonIndex].icon.enabled = true;
			if (radialButtonInfo.icon != null)
			{
				UltimateRadialButtonList[buttonIndex].icon.sprite = radialButtonInfo.icon;
			}
		}
		if (useButtonText && UltimateRadialButtonList[buttonIndex].text != null && displayNameOnButton)
		{
			UltimateRadialButtonList[buttonIndex].text.text = radialButtonInfo.name;
		}
	}

	[Obsolete]
	private int GetRadialButtonIndexByName(string buttonName)
	{
		for (int i = 0; i < UltimateRadialButtonList.Count; i++)
		{
			if (UltimateRadialButtonList[i].name == buttonName)
			{
				return i;
			}
		}
		Debug.LogWarning("Ultimate Radial Menu\nNo radial button was found with the name: " + buttonName);
		return -1;
	}

	[Obsolete("Please use RemoveAllRadialButtons instead.")]
	public void ClearRadialButtons()
	{
		RemoveAllRadialButtons();
	}

	[Obsolete("You can reference the radial button by using the UltimateRadialButtonList")]
	public UltimateRadialButton GetUltimateRadialButton(int buttonIndex)
	{
		if (!ConfirmRadialButtonIndex(buttonIndex))
		{
			Debug.LogWarning("Ultimate Radial Menu\nThere is no button at index: " + buttonIndex + ". Please ensure that you have the right index value.");
			return null;
		}
		return UltimateRadialButtonList[buttonIndex];
	}

	[Obsolete("You can reference the radial button by using the UltimateRadialButtonList")]
	public UltimateRadialButton GetUltimateRadialButton(string buttonName)
	{
		int radialButtonIndexByName = GetRadialButtonIndexByName(buttonName);
		if (radialButtonIndexByName < 0)
		{
			Debug.LogWarning("Ultimate Radial Menu\nThere is no button registered with the name: " + buttonName + ". Please make sure that you have the name referenced correctly.");
			return null;
		}
		return UltimateRadialButtonList[radialButtonIndexByName];
	}

	[Obsolete("Please use UpdatePositioning instead")]
	public void UpdateSizeAndPlacement()
	{
		UpdatePositioning();
		if (this.OnUpdateSizeAndPlacement != null)
		{
			this.OnUpdateSizeAndPlacement();
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public void UpdateRadialButton(string buttonName, Action ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		int radialButtonIndexByName = GetRadialButtonIndexByName(buttonName);
		if (radialButtonIndexByName >= 0)
		{
			UpdateRadialButtonInformation(radialButtonIndexByName, newRadialButtonInfo);
			UltimateRadialButtonList[radialButtonIndexByName].AddCallback(ButtonCallback);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public void UpdateRadialButton(string buttonName, Action<int> ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		int radialButtonIndexByName = GetRadialButtonIndexByName(buttonName);
		if (radialButtonIndexByName >= 0)
		{
			UpdateRadialButtonInformation(radialButtonIndexByName, newRadialButtonInfo);
			UltimateRadialButtonList[radialButtonIndexByName].AddCallback(ButtonCallback);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public void UpdateRadialButton(string buttonName, Action<string> ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		int radialButtonIndexByName = GetRadialButtonIndexByName(buttonName);
		if (radialButtonIndexByName >= 0)
		{
			UpdateRadialButtonInformation(radialButtonIndexByName, newRadialButtonInfo);
			UltimateRadialButtonList[radialButtonIndexByName].AddCallback(ButtonCallback);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public void UpdateRadialButton(int buttonIndex, Action ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (ConfirmRadialButtonIndex(buttonIndex))
		{
			UpdateRadialButtonInformation(buttonIndex, newRadialButtonInfo);
			UltimateRadialButtonList[buttonIndex].AddCallback(ButtonCallback);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public void UpdateRadialButton(int buttonIndex, Action<int> ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (ConfirmRadialButtonIndex(buttonIndex))
		{
			UpdateRadialButtonInformation(buttonIndex, newRadialButtonInfo);
			UltimateRadialButtonList[buttonIndex].AddCallback(ButtonCallback);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public void UpdateRadialButton(int buttonIndex, Action<string> ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (ConfirmRadialButtonIndex(buttonIndex))
		{
			UpdateRadialButtonInformation(buttonIndex, newRadialButtonInfo);
			UltimateRadialButtonList[buttonIndex].AddCallback(ButtonCallback);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public void AddRadialButton(Action ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		CreateRadialButtonAtIndex(1000);
		UltimateRadialButtonList[UltimateRadialButtonList.Count - 1].RegisterButtonInfo(newRadialButtonInfo);
		UltimateRadialButtonList[UltimateRadialButtonList.Count - 1].AddCallback(ButtonCallback);
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public void AddRadialButton(Action<int> ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		CreateRadialButtonAtIndex(1000);
		UltimateRadialButtonList[UltimateRadialButtonList.Count - 1].RegisterButtonInfo(newRadialButtonInfo);
		UltimateRadialButtonList[UltimateRadialButtonList.Count - 1].AddCallback(ButtonCallback);
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public void AddRadialButton(Action<string> ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		CreateRadialButtonAtIndex(1000);
		UltimateRadialButtonList[UltimateRadialButtonList.Count - 1].RegisterButtonInfo(newRadialButtonInfo);
		UltimateRadialButtonList[UltimateRadialButtonList.Count - 1].AddCallback(ButtonCallback);
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public void InsertRadialButton(int buttonIndex, Action ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (buttonIndex < 0)
		{
			buttonIndex = 0;
		}
		if (buttonIndex > UltimateRadialButtonList.Count)
		{
			buttonIndex = UltimateRadialButtonList.Count;
		}
		CreateRadialButtonAtIndex(buttonIndex);
		UltimateRadialButtonList[buttonIndex].RegisterButtonInfo(newRadialButtonInfo);
		UltimateRadialButtonList[buttonIndex].AddCallback(ButtonCallback);
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public void InsertRadialButton(int buttonIndex, Action<int> ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (buttonIndex < 0)
		{
			buttonIndex = 0;
		}
		if (buttonIndex > UltimateRadialButtonList.Count)
		{
			buttonIndex = UltimateRadialButtonList.Count;
		}
		CreateRadialButtonAtIndex(buttonIndex);
		UltimateRadialButtonList[buttonIndex].RegisterButtonInfo(newRadialButtonInfo);
		UltimateRadialButtonList[buttonIndex].AddCallback(ButtonCallback);
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public void InsertRadialButton(int buttonIndex, Action<string> ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (buttonIndex < 0)
		{
			buttonIndex = 0;
		}
		if (buttonIndex > UltimateRadialButtonList.Count)
		{
			buttonIndex = UltimateRadialButtonList.Count;
		}
		CreateRadialButtonAtIndex(buttonIndex);
		UltimateRadialButtonList[buttonIndex].RegisterButtonInfo(newRadialButtonInfo);
		UltimateRadialButtonList[buttonIndex].AddCallback(ButtonCallback);
	}

	[Obsolete("Please use the Interactable variable instead")]
	public void EnableInteraction()
	{
		Interactable = true;
	}

	[Obsolete("Please use the Interactable variable instead")]
	public void DisableInteraction()
	{
		Interactable = false;
	}

	[Obsolete("Please use RemoveAllRadialButtons instead")]
	public static void ClearRadialButtons(string radialMenuName)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].RemoveAllRadialButtons();
		}
	}

	[Obsolete("You can reference the radial button by using the UltimateRadialButtonList")]
	public static UltimateRadialButton GetUltimateRadialButton(string radialMenuName, string buttonName)
	{
		if (!ConfirmUltimateRadialMenu(radialMenuName))
		{
			return null;
		}
		return UltimateRadialMenus[radialMenuName].GetUltimateRadialButton(buttonName);
	}

	[Obsolete("You can reference the radial button by using the UltimateRadialButtonList")]
	public static UltimateRadialButton GetUltimateRadialButton(string radialMenuName, int buttonIndex)
	{
		if (!ConfirmUltimateRadialMenu(radialMenuName))
		{
			return null;
		}
		return UltimateRadialMenus[radialMenuName].GetUltimateRadialButton(buttonIndex);
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public static void UpdateRadialButton(string radialMenuName, string buttonName, Action ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].UpdateRadialButton(buttonName, ButtonCallback, newRadialButtonInfo);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public static void UpdateRadialButton(string radialMenuName, string buttonName, Action<int> ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].UpdateRadialButton(buttonName, ButtonCallback, newRadialButtonInfo);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public static void UpdateRadialButton(string radialMenuName, string buttonName, Action<string> ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].UpdateRadialButton(buttonName, ButtonCallback, newRadialButtonInfo);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public static void UpdateRadialButton(string radialMenuName, int buttonIndex, Action ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].UpdateRadialButton(buttonIndex, ButtonCallback, newRadialButtonInfo);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public static void UpdateRadialButton(string radialMenuName, int buttonIndex, Action<int> ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].UpdateRadialButton(buttonIndex, ButtonCallback, newRadialButtonInfo);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public static void UpdateRadialButton(string radialMenuName, int buttonIndex, Action<string> ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].UpdateRadialButton(buttonIndex, ButtonCallback, newRadialButtonInfo);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public static void AddRadialButton(string radialMenuName, Action ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].AddRadialButton(ButtonCallback, newRadialButtonInfo);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public static void AddRadialButton(string radialMenuName, Action<int> ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].AddRadialButton(ButtonCallback, newRadialButtonInfo);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public static void AddRadialButton(string radialMenuName, Action<string> ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].AddRadialButton(ButtonCallback, newRadialButtonInfo);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public static void InsertRadialButton(string radialMenuName, int buttonIndex, Action ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].InsertRadialButton(buttonIndex, ButtonCallback, newRadialButtonInfo);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public static void InsertRadialButton(string radialMenuName, int buttonIndex, Action<int> ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].InsertRadialButton(buttonIndex, ButtonCallback, newRadialButtonInfo);
		}
	}

	[Obsolete("Please use RegisterToRadialMenu instead")]
	public static void InsertRadialButton(string radialMenuName, int buttonIndex, Action<string> ButtonCallback, UltimateRadialButtonInfo newRadialButtonInfo)
	{
		if (ConfirmUltimateRadialMenu(radialMenuName))
		{
			UltimateRadialMenus[radialMenuName].InsertRadialButton(buttonIndex, ButtonCallback, newRadialButtonInfo);
		}
	}
}
