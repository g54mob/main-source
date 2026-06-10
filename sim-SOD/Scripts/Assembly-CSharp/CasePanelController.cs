using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;

public class CasePanelController : PanelController
{
	public class StringConnection
	{
		public PinnedItemController from;

		public PinnedItemController to;

		public List<Evidence.FactLink> links;

		public List<Fact> facts;

		public StringConnection(PinnedItemController fromPinned, PinnedItemController toPinned)
		{
		}
	}

	public enum ControllerSelectMode
	{
		caseBoard = 0,
		windows = 1
	}

	public delegate void PinnedChange();

	public delegate void PinEvidence(Evidence evidence);

	public delegate void UnpinEvidence(Evidence evidence);

	[CompilerGenerated]
	private sealed class _003CCustomStringLink_003Ed__86 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CasePanelController _003C_003E4__this;

		public bool holdButtonMode;

		private RectTransform _003CfromRect_003E5__2;

		private int _003CwaitFrames_003E5__3;

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
		public _003CCustomStringLink_003Ed__86(int _003C_003E1__state)
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
	public RectTransform corkBoard;

	public RectTransform pinnedContainer;

	public RectTransform stringContainer;

	public RectTransform caseButtonParent;

	public ButtonController newCaseButton;

	public ButtonController closeCaseButton;

	public RectTransform caseDisplayArea;

	public RectTransform closeCaseDisplayArea;

	public Sprite resolveSprite;

	public Sprite archiveSprite;

	public Sprite collectHandInSprite;

	[NonSerialized]
	[Header("Cases")]
	public Case activeCase;

	public List<Case> activeCases;

	public List<Case> archivedCases;

	public List<CaseButtonController> spawnedCaseButtons;

	[Header("Pick Evidence Mode")]
	public bool pickModeActive;

	public InputFieldController pickForField;

	[Header("String Link")]
	public bool customLinkSelectionMode;

	public PinnedItemController customStringLinkSelection;

	public RectTransform customString;

	private FactCustom newestCreatedFact;

	[Header("Spawned")]
	public List<PinnedItemController> spawnedPins;

	public List<StringController> spawnedStrings;

	private float caseCloseTransition;

	[Header("Controller Mode")]
	public bool controllerMode;

	public InfoWindow selectedWindow;

	public PinnedItemController selectedPinned;

	public ButtonController selectedTopBarButton;

	public ControllerSelectMode currentSelectMode;

	public RectTransform upgradesSelect;

	public JuiceController upgradesSelectJuice;

	public RectTransform boardSelect;

	public JuiceController boardSelectJuice;

	public RectTransform mapSelect;

	public JuiceController mapSelectJuice;

	public ButtonController notebookButton;

	public ButtonController stickNoteButton;

	public ButtonController selectNoCaseButton;

	public ViewportMouseOver caseboardMO;

	public ControllerViewRectScroll caseboardScroll;

	public ViewportMouseOver mapMO;

	public ControllerViewRectScroll mapScroll;

	public ViewportMouseOver upgradesMO;

	public ControllerViewRectScroll upgradesScroll;

	private static CasePanelController _instance;

	[Header("Case debugging")]
	public int debugSideMissionIndex;

	public static CasePanelController Instance => null;

	public event PinnedChange OnPinnedChange
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

	public event PinEvidence OnPinEvidence
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

	public event UnpinEvidence OnUnpinEvidence
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

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	public void UpdateCaseControls()
	{
	}

	public void SelectNoCaseButton()
	{
	}

	public void NewCustomCaseButton()
	{
	}

	public Case CreateNewCase(Case.CaseType newType, Case.CaseStatus newStatus, bool isSilent = false, string caseName = "New Case")
	{
		return null;
	}

	public void OnCreateNewCustomCase()
	{
	}

	public void OnCancelNewCustomCase()
	{
	}

	public void UpdateCloseCaseButton()
	{
	}

	private void Update()
	{
	}

	public void CloseCaseButton()
	{
	}

	public void CloseCase(Case closeThisCase)
	{
	}

	public void SetActiveCase(Case newCase)
	{
	}

	public void UpdateCaseButtonsActive()
	{
	}

	public void NewStickyNoteButton()
	{
	}

	public InfoWindow NewStickyNote()
	{
		return null;
	}

	public void OnCreateNewCasePopup()
	{
	}

	public void onCreateNewCasePopupCancel()
	{
	}

	public void PinToCasePanel(Case toCase, Evidence ev, Evidence.DataKey evKey, bool forceAutoPin = false, Vector2 localPostion = default(Vector2), bool debugFlag = false)
	{
	}

	public void PinToCasePanel(Case toCase, Evidence ev, List<Evidence.DataKey> evKeys, bool forceAutoPin = false, Vector2 localPostion = default(Vector2), bool debugFlag = false)
	{
	}

	public void UnPinFromCasePanel(Case thisCase, Evidence ev, List<Evidence.DataKey> evKeys, bool uniqueKeysOnly = false, Case.CaseElement forceElement = null)
	{
	}

	public void UpdatePinned()
	{
	}

	public void UpdateStrings()
	{
	}

	public void CustomStringLinkSelection(PinnedItemController pinnedItem, bool holdButtonMode = false)
	{
	}

	[IteratorStateMachine(typeof(_003CCustomStringLink_003Ed__86))]
	private IEnumerator CustomStringLink(bool holdButtonMode = false)
	{
		return null;
	}

	private void OnDisable()
	{
	}

	public void CancelCustomStringLinkSelection()
	{
	}

	public void FinishCustomStringLinkSelection(PinnedItemController target)
	{
	}

	public void OnContinueFactName()
	{
	}

	public void OnCancelCustomFact()
	{
	}

	public void UpdateResolveNotifications()
	{
	}

	public void SetPickModeActive(bool val, InputFieldController forField)
	{
	}

	public void OnShowCaseBoard()
	{
	}

	public void OnHideCaseBoard()
	{
	}

	public void SetControllerMode(bool isActive, ControllerSelectMode newMode)
	{
	}

	public void SetSelectedWindow(InfoWindow newWindow, bool forceUpdate = false, bool snapVirtualCursor = false)
	{
	}

	public void SetSelectedPinned(PinnedItemController newPinned, bool forceUpdate = false)
	{
	}

	public void ControllerNavigate(Vector2 direction)
	{
	}

	public void ShoulderNavigate(bool right)
	{
	}

	public PinnedItemController GetClosestPinnedToCentre()
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DisplayCorrectMurderQuestions()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ValidateCase()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void AdvanceSideMission()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CompleteSideMission()
	{
	}
}
