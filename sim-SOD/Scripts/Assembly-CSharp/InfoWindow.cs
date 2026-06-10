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

public class InfoWindow : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public delegate void ResizedWindow();

	public delegate void WindowClosed();

	public delegate void WindowRefresh();

	public delegate void WorldInteractionStateUpdate();

	[CompilerGenerated]
	private sealed class _003CUpdateControllerNavigation_003Ed__118 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InfoWindow _003C_003E4__this;

		private int _003CwaitedFrame_003E5__2;

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
		public _003CUpdateControllerNavigation_003Ed__118(int _003C_003E1__state)
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

	[Header("Presets")]
	public WindowStylePreset preset;

	[Header("References")]
	public Canvas windowCanvas;

	public CanvasGroup windowCanvasGroup;

	public Canvas contentConvas;

	public CanvasGroup contentCanvasGroup;

	public RectTransform background;

	public TextMeshProUGUI titleText;

	public RectTransform rect;

	private ResizePanel[] resizeZones;

	public CustomScrollRect scrollRect;

	public GameObject tabBar;

	public ButtonController closeButton;

	public PinFolderButtonController pinButton;

	public ItemController item;

	public WindowContentController activeContent;

	public RectTransform contentRect;

	private Scrollbar horzScrollBar;

	private Scrollbar vertScrollBar;

	public RectTransform activeTabRect;

	public RectTransform pageRect;

	public Image typeIcon;

	public Image closeButtonIcon;

	public RectTransform dragZone;

	public RectTransform controllerSelect;

	public JuiceController controllerSelectJuice;

	public ControllerViewRectScroll controllerScrollView;

	public RectTransform interactionIconRect;

	public ButtonController clearTextButton;

	public ButtonController takeItemButton;

	[Header("Parameters")]
	public bool closable;

	public bool pinnable;

	public bool pinned;

	public bool selected;

	[NonSerialized]
	public Case.CaseElement currentPinnedCaseElement;

	[NonSerialized]
	public Case.CaseElement forcedPinnedCaseElement;

	public bool isOver;

	public bool isWorldInteraction;

	private bool updateNav;

	public bool forceDisablePin;

	public bool forceDisableClose;

	public bool dialogSuccess;

	[Header("Graphics")]
	public Sprite iconLarge;

	public InterfaceControls.EvidenceColours evColour;

	public Image pinOverlay;

	public Image pinColour;

	public Image pinColourPressed;

	public Color pinColourActual;

	public Color baseColour;

	public Color flashColour;

	public Color borderColour;

	[Header("Resizing")]
	public bool resizable;

	public Vector2 defaultSize;

	public float centringTollerance;

	[Header("Content")]
	public Evidence passedEvidence;

	public List<Evidence.DataKey> passedKeys;

	public List<Evidence.DataKey> evidenceKeys;

	public List<WindowContentController> contentPages;

	public List<WindowTabController> tabs;

	[NonSerialized]
	public Interactable passedInteractable;

	[NonSerialized]
	public Case passedCase;

	[Header("Debug")]
	public Evidence.DataKey debugKeyOne;

	public Evidence.DataKey debugKeyTwo;

	public Vector2 debugSetAnchoredPosition;

	public event ResizedWindow OnResizedWindow
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

	public event WindowClosed OnWindowClosed
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

	public event WindowRefresh OnWindowRefresh
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

	public event WorldInteractionStateUpdate OnUpdateWorldInteractionState
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

	public void Setup(WindowStylePreset newPreset, Evidence newEv, List<Evidence.DataKey> newKeys, bool worldInteraction = false, Interactable newInteractable = null, Case newCase = null, Case.CaseElement newForcePinnedCaseElement = null, bool passedDialogSuccess = true)
	{
	}

	private void OnDestroy()
	{
	}

	public void SetWorldInteraction(bool val)
	{
	}

	public void RefreshTakeButton()
	{
	}

	public void CancelWorldInteractionButton()
	{
	}

	public void LoadTab(WindowTabPreset tabPreset)
	{
	}

	public void OnResizeWindow()
	{
	}

	public void UpdateTabButtons()
	{
	}

	public void SetActiveContent(WindowContentController wcc)
	{
	}

	public void InstanceUpdateComplete()
	{
	}

	public void UpdateEvidenceKeys()
	{
	}

	public void SetName(string newName)
	{
	}

	public void ResizeWindow(Vector2 sizeDelta)
	{
	}

	public void CloseWindow(bool animate = true)
	{
	}

	public void TogglePinned()
	{
	}

	public void PinnedUpdateCheck()
	{
	}

	public void OnWindowPinnedChange(bool isPinned, Case.CaseElement newCaseElement)
	{
	}

	public void SetClosable(bool newClosble)
	{
	}

	public void SetAnchoredPosition(Vector2 newPos)
	{
	}

	public void SetPivot(Vector2 p)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void UpdatePinColour()
	{
	}

	public void Rename()
	{
	}

	public void OnEditName()
	{
	}

	public void SetColourRed()
	{
	}

	public void SetColourBlue()
	{
	}

	public void SetColourYellow()
	{
	}

	public void SetColourGreen()
	{
	}

	public void SetColourPurple()
	{
	}

	public void SetColourWhite()
	{
	}

	public void SetColourBlack()
	{
	}

	public void SetSelected(bool val)
	{
	}

	public void UpdateControllerSelected()
	{
	}

	public void UpdateControllerNavigationEndOfFrame()
	{
	}

	public void OnClearTextButton()
	{
	}

	public void OnTakeItemButton()
	{
	}

	public void OnTakeConfirm()
	{
	}

	public void OnTakeCancel()
	{
	}

	[IteratorStateMachine(typeof(_003CUpdateControllerNavigation_003Ed__118))]
	private IEnumerator UpdateControllerNavigation()
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ExecuteUpdateControllerNavigation()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ExecuteKeyMerge()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SpawnFingerprintOwner()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void RestoreAnchoredPosition()
	{
	}
}
