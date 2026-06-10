using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	public enum NavRectPoint
	{
		center = 0,
		min = 1,
		max = 2
	}

	public enum ButtonAudioType
	{
		normal = 0,
		forward = 1,
		back = 2,
		tickBox = 3
	}

	public class NavRanking
	{
		public ButtonController button;

		public float score;

		public int dir;
	}

	[Serializable]
	public class PreferNav
	{
		public ButtonController button;

		public float score;

		public NavDir dir;
	}

	public enum NavDir
	{
		up = 0,
		down = 1,
		left = 2,
		right = 3
	}

	public delegate void Press(ButtonController thisButton);

	public delegate void HoverChange(ButtonController thisButton, bool mouseOver);

	public delegate void ButtonDown(ButtonController thisButton);

	public delegate void ButtonUp(ButtonController thisButton);

	[CompilerGenerated]
	private sealed class _003CFlashColour_003Ed__116 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ButtonController _003C_003E4__this;

		public Color flashColour;

		public int repeat;

		private int _003Ccycle_003E5__2;

		private float _003Cprogress_003E5__3;

		private float _003Cspeed_003E5__4;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CFlashColour_003Ed__116(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CRefreshNavEndOfFrame_003Ed__117 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ButtonController _003C_003E4__this;

		private bool _003Cwaited_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CRefreshNavEndOfFrame_003Ed__117(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("References")]
	[Tooltip("Reference to the rect transform component (assigned if not given)")]
	public RectTransform rect;

	[Tooltip("Reference to the button component (assigned if not given)")]
	public Button button;

	[Tooltip("Reference to the canvas renderer component (assigned if not given)")]
	public CanvasRenderer rend;

	[Tooltip("The background image for this button")]
	public Image background;

	[Tooltip("The icon image for this button")]
	public Image icon;

	[Tooltip("Text for this button")]
	public TextMeshProUGUI text;

	[Tooltip("Tooltip control component")]
	public TooltipController tooltip;

	[Tooltip("Juice controller for effects")]
	public JuiceController juice;

	[Tooltip("Used for notifications")]
	public NotificationController notifications;

	[NonSerialized]
	public object genericReference;

	[ReadOnly]
	[Space(5f)]
	public InfoWindow parentWindow;

	[NonSerialized]
	public Evidence windowOf;

	[ReadOnly]
	public WindowTabController tabOf;

	[ReadOnly]
	public RectTransform additionalHighlightRect;

	[Tooltip("Is this currently moused-over?")]
	[ReadOnly]
	[Header("State")]
	[Space(5f)]
	public bool isOver;

	[ReadOnly]
	[Tooltip("Force the additional/manual highlight")]
	public bool forceAdditionalHighlighted;

	[ReadOnly]
	[Tooltip("Addition/manual highlight active")]
	public bool additionalHighlighted;

	[ReadOnly]
	[Tooltip("Interactable")]
	public bool interactable;

	public bool setupReferences;

	public bool isVirtualKeyboardCharacterButton;

	private float lastLeftClick;

	private float lastRightClick;

	[Tooltip("Base colour used for built-in flash functionality")]
	[BoxGroup("Button Setup")]
	[Space(7f)]
	public Color baseColour;

	[Tooltip("If enabled, this will detect if it's in a scroll rect, then adjust scroll accordingly when selected")]
	[BoxGroup("Button Setup")]
	public bool scrollRectAutoScroll;

	[BoxGroup("Button Setup")]
	[EnableIf("scrollRectAutoScroll")]
	public bool scrollVertical;

	[BoxGroup("Button Setup")]
	[EnableIf("scrollRectAutoScroll")]
	public bool scrollHorizontal;

	[Tooltip("Can this button be found using automatic navigation of other buttons?")]
	[BoxGroup("Auto Navigation")]
	public bool findableForAutoNavigation;

	[BoxGroup("Auto Navigation")]
	[Tooltip("Automatically refresh the controller navigation when set up")]
	public bool refreshControllerNavigationOnSetup;

	[BoxGroup("Auto Navigation")]
	[Tooltip("Automatically refresh the controller navigation when selected")]
	public bool refreshControllerNavigationOnSelect;

	[Tooltip("Automatically refresh the controller navigation when pressed")]
	[BoxGroup("Auto Navigation")]
	public bool refreshControllerNavigationOnPress;

	[BoxGroup("Auto Navigation")]
	[Tooltip("When looking for navigation selectables, include inactive objects")]
	public bool includeInactiveSelectables;

	[DisableIf("isEvidenceWindowButton")]
	[BoxGroup("Auto Navigation")]
	[Tooltip("When looking for navigation selectables, how many transform parents up should it search for other buttons?")]
	[Range(1f, 10f)]
	public int selectableSearchParentHierarchyThreshold;

	[BoxGroup("Auto Navigation")]
	[Tooltip("A shortcut instead of above; search for components within this window...")]
	public bool isEvidenceWindowButton;

	[Tooltip("When auto navigation is setup, should we allow a search for selectables on the left?")]
	[BoxGroup("Auto Navigation")]
	public bool allowLeftNavigation;

	[Tooltip("When auto navigation is setup, should we allow a search for selectables on the right?")]
	[BoxGroup("Auto Navigation")]
	public bool allowRightNavigation;

	[Tooltip("When auto navigation is setup, should we allow a search for selectables up?")]
	[BoxGroup("Auto Navigation")]
	public bool allowUpNavigation;

	[BoxGroup("Auto Navigation")]
	[Tooltip("When auto navigation is setup, should we allow a search for selectables down?")]
	public bool allowDownNavigation;

	[BoxGroup("Auto Navigation")]
	[Tooltip("When auto navigation is setup, override a found object on 'up' with a currently selected save game button (if there is one)")]
	public bool selectSaveGameObjectOnUp;

	[Tooltip("When auto navigation is setup, override a found object on 'right' with a button labeled forward, if there is one")]
	[BoxGroup("Auto Navigation")]
	public bool preferForwardButtonOnRight;

	[BoxGroup("Auto Navigation")]
	[Tooltip("When measuring distances to to other nav buttons, use this point of the rect")]
	public NavRectPoint thisNavRectPoint;

	[BoxGroup("Auto Navigation")]
	[Tooltip("When measuring distances to to other nav buttons, use this point of the other rect")]
	public NavRectPoint otherNavRectPoint;

	[BoxGroup("Auto Navigation")]
	[Tooltip("When selecting from auto navigation, ignore the following objects if they are parents")]
	public List<string> ignoreParentsNamed;

	[BoxGroup("Auto Navigation")]
	[Tooltip("When using a controller, the secondary action button is classed as a right click")]
	public bool secondaryIsRightClick;

	[BoxGroup("Auto Navigation")]
	public List<PreferNav> preferNavRankings;

	[Space(5f)]
	[BoxGroup("Text")]
	[Tooltip("Automatically set the button text")]
	public bool useAutomaticText;

	[BoxGroup("Text")]
	[EnableIf("useAutomaticText")]
	[Tooltip("Use this dictionary reference to get the text")]
	public string textDictionary;

	[Tooltip("Use this reference to get the text")]
	[BoxGroup("Text")]
	[EnableIf("useAutomaticText")]
	public string textReference;

	[BoxGroup("Text")]
	[EnableIf("useAutomaticText")]
	public Strings.Casing casing;

	[BoxGroup("Text")]
	public string menuMouseoverReference;

	[Space(5f)]
	[BoxGroup("Interactability")]
	[Range(0f, 1f)]
	public float uninteractableTextAlpha;

	[BoxGroup("Interactability")]
	[Range(0f, 1f)]
	public float interactableTextAlpha;

	[BoxGroup("Interactability")]
	[Tooltip("If nothing is selected, the priority of this button being the defauly selection vs others")]
	[Range(-2f, 2f)]
	public int defaultSelectionPriority;

	[Space(5f)]
	[BoxGroup("Additional Highlighter")]
	[Tooltip("Use the additional/manual highlight functionality")]
	public bool useAdditionalHighlight;

	[Tooltip("Prefab that acts as the additional/manual highlighter. If empty a default highlighter will be used.")]
	[BoxGroup("Additional Highlighter")]
	public GameObject additionalHighlightPrefab;

	[Tooltip("Colour applied to the additional/manual highlighter")]
	[BoxGroup("Additional Highlighter")]
	public Color additionalHighlightColour;

	[BoxGroup("Additional Highlighter")]
	[Tooltip("Colour applied to the additional/manual highlighter when uninteractable")]
	public Color additionalHighlightUninteractableColour;

	[Tooltip("Set the additional/manual highlight to the front")]
	[BoxGroup("Additional Highlighter")]
	public bool additionalHighlightAtFront;

	[BoxGroup("Additional Highlighter")]
	[Tooltip("Add to the rect size of the highlighter")]
	public Vector4 additionalHighlightRectModifier;

	private Image additionalHImage;

	[Space(5f)]
	[BoxGroup("Juice")]
	public bool nudgeOnClick;

	[BoxGroup("Juice")]
	public bool glowOnHighlight;

	[Tooltip("Use generic button sounds")]
	[Space(5f)]
	[BoxGroup("Audio")]
	public bool useGenericAudioSounds;

	[EnableIf("useGenericAudioSounds")]
	[BoxGroup("Audio")]
	public ButtonAudioType buttonType;

	[BoxGroup("Audio")]
	[DisableIf("useGenericAudioSounds")]
	public AudioEvent buttonDown;

	[DisableIf("useGenericAudioSounds")]
	[BoxGroup("Audio")]
	public AudioEvent clickPrimary;

	[DisableIf("useGenericAudioSounds")]
	[BoxGroup("Audio")]
	public AudioEvent clickSecondary;

	[DisableIf("useGenericAudioSounds")]
	[BoxGroup("Audio")]
	public AudioEvent rightClick;

	public event Press OnPress
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event HoverChange OnHoverChange
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event ButtonDown OnButtonDown
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event ButtonUp OnButtonUp
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	[Button("Setup References", EButtonEnableMode.Always)]
	public virtual void SetupReferences()
	{
	}

	private void Start()
	{
	}

	public virtual void VisualUpdate()
	{
	}

	public virtual void UpdateButtonText()
	{
	}

	public virtual void UpdateTooltipText()
	{
	}

	public virtual void SetInteractable(bool val)
	{
	}

	public virtual void OnPointerClick(PointerEventData eventData)
	{
	}

	public virtual void OnPointerDown(PointerEventData eventData)
	{
	}

	public virtual void OnPointerUp(PointerEventData eventData)
	{
	}

	public virtual void OnLeftClick()
	{
	}

	public virtual void OnRightClick()
	{
	}

	public virtual void OnLeftDoubleClick()
	{
	}

	public virtual void OnRightDoubleClick()
	{
	}

	public virtual void OnPointerEnter(PointerEventData eventData)
	{
	}

	public virtual void OnSelect()
	{
	}

	public void AutoScroll()
	{
	}

	private void SendTextContentToVirtualKeyboard()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public virtual void OnPointerExit(PointerEventData eventData)
	{
	}

	public virtual void OnDeselect()
	{
	}

	public virtual void OnHoverStart()
	{
	}

	public virtual void OnHoverEnd()
	{
	}

	public virtual void SetButtonBaseColour(Color col)
	{
	}

	public void SetupAdditionalHighlight()
	{
	}

	public virtual void UpdateAdditionalHighlight()
	{
	}

	public void SetForceAdditionalHighlight(bool newVal)
	{
	}

	public void Flash(int repeat, Color flashColour)
	{
	}

	[IteratorStateMachine(typeof(_003CFlashColour_003Ed__116))]
	public IEnumerator FlashColour(int repeat, Color flashColour)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CRefreshNavEndOfFrame_003Ed__117))]
	public IEnumerator RefreshNavEndOfFrame()
	{
		return null;
	}

	private void OnDestroy()
	{
	}

	public void RefreshAutomaticNavigation()
	{
	}

	public virtual void RefreshAutomaticNavigation(bool enableLeft, bool enableRight, bool enableUp, bool enableDown, bool includeInactive)
	{
	}
}
