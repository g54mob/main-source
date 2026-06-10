using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
	public class InteractionSetting
	{
		public InteractablePreset.InteractionAction currentAction;

		public Interactable.InteractableCurrentAction currentSetting;

		[NonSerialized]
		public Interactable interactable;

		public bool isFPSItem;

		public AudioEvent audioEvent;

		public int priority;

		public string actionText;

		public ControlDisplayController newUIRef;

		public int GetActionCost()
		{
			return 0;
		}
	}

	public enum ConversationType
	{
		normal = 0,
		mugging = 1,
		loanSharkVisit = 2,
		accuseMurderer = 3,
		killerCleanUp = 4,
		fameAndFortune = 5
	}

	public delegate void ReturnFromLockedIn();

	public delegate void InteractionActionCompleted();

	public delegate void InteractionActionProgressChange(float amountThisFrame, float amountTotal);

	public delegate void InteractionActionLookedAway();

	public delegate void InteractionActionCancelled();

	[CompilerGenerated]
	private sealed class _003CReadingMode_003Ed__104 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InteractionController _003C_003E4__this;

		private int _003CdisplayPage_003E5__2;

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
		public _003CReadingMode_003Ed__104(int _003C_003E1__state)
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

	[Header("Interaction")]
	public Dictionary<InteractablePreset.InteractionKey, InteractionSetting> currentInteractions;

	public List<InteractablePreset.InteractionKey> allInteractionKeys;

	public List<Interactable> nearbyInteractables;

	public List<SelectionIconController> selectionIcons;

	public int nearbyInteractablesHint;

	[Header("Player State")]
	public float inputCooldown;

	public bool lookingAtInteractable;

	public bool displayingInteraction;

	private InteractableController previousLookingAtInteractable;

	public InteractableController currentLookingAtInteractable;

	public Transform currentLookAtTransform;

	private InteractableController currentLookingAtReadingRange;

	public InteractableController currentInteractable;

	public bool interactionMode;

	public bool distanceRecognitionMode;

	public bool readingMode;

	private float readingModeTransition;

	private Coroutine readingModeCoroutine;

	public float interactionAnimationModifier;

	public float interactionLookProgress;

	public InteractableController carryingObject;

	private List<NewDoor> addedToDoorInteractionList;

	public RigidbodyDragObject currentlyDragging;

	private RaycastHit playerPreviousRaycastHit;

	[NonSerialized]
	public RaycastHit playerCurrentRaycastHit;

	[NonSerialized]
	[Header("Locked-In Interaction")]
	public Interactable lockedInInteraction;

	public int lockedInInteractionRef;

	[NonSerialized]
	public Interactable hideInteractable;

	[Header("Interaction Action")]
	public bool activeInteractionAction;

	private float interactionActionThreshold;

	private float interactionActionMultiplier;

	public string interactionActionName;

	private bool activeInteractionActionLookCheck;

	private bool canFailLookCheck;

	public GameObject lockpickGraphics;

	private bool cancelInteractionIfOutOfRange;

	private float lastLookAtForInteraction;

	public Dictionary<Interactable, float> discoveryOverTime;

	public Dictionary<Evidence, float> discoveryOverTimeEvidence;

	public Dictionary<MetaObject, float> discoveryOverTimeMeta;

	public Dictionary<EvidenceMultiPage.MultiPageContent, float> discoveryOverTimeDiscovery;

	public List<LockpickProgressController> spawnedProgressControllers;

	private Interactable sabotageInteractable;

	[Header("Dialog")]
	public bool dialogMode;

	public bool isRemote;

	public float dialogTransition;

	public ConversationType dialogType;

	public TextMeshProUGUI citizenNameText;

	[NonSerialized]
	public Interactable talkingTo;

	[NonSerialized]
	public Interactable remoteOverride;

	public List<DialogButtonController> dialogOptions;

	public int dialogSelection;

	public RectTransform moreOptionsScrollUpArrow;

	public RectTransform moreOptionsScrollDownArrow;

	public Human mugger;

	public Human debtCollector;

	public Human fameAndFortune;

	[Header("Interface")]
	public bool inOut;

	public float inOutProgress;

	public float displayProgress;

	private AudioController.LoopingSoundInfo lockpickLoop;

	private static InteractionController _instance;

	public float interactionActionAmount { get; private set; }

	public Transform interactionActionLookAt { get; private set; }

	public static InteractionController Instance => null;

	public event ReturnFromLockedIn OnReturnFromLockedIn
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

	public event InteractionActionCompleted OnInteractionActionCompleted
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

	public event InteractionActionProgressChange OnInteractionActionProgressChange
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

	public event InteractionActionLookedAway OnInteractionActionLookedAway
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

	public event InteractionActionCancelled OnInteractionActionCancelled
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

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void StartDecorEdit()
	{
	}

	public void SetCurrentPlayerInteraction(InteractablePreset.InteractionKey key, Interactable newInteractable, Interactable.InteractableCurrentAction newCurrentAction, bool fpsItem = false, int forcePriority = -1)
	{
	}

	public void DisplayInteractionCursor(bool val, bool forceUpdate = false)
	{
	}

	public void AlignInteractionIcons()
	{
	}

	public void SetDistanceRecognitionMode(bool val)
	{
	}

	public void SetReadingMode(bool val, bool stopImmediately)
	{
	}

	public void UpdateReadingModeText()
	{
	}

	[IteratorStateMachine(typeof(_003CReadingMode_003Ed__104))]
	private IEnumerator ReadingMode()
	{
		return null;
	}

	public void UpdateInteractionText()
	{
	}

	public void UpdateInteractionText(string newText)
	{
	}

	public void InteractionRaycastCheck()
	{
	}

	public void OnPlayerLookAtChange()
	{
	}

	public void OnPlayerLookAtInteractableChange()
	{
	}

	public void SetLockedInInteractionMode(Interactable val, int reference = 0, bool dropCarriedCheck = true)
	{
	}

	public void SetInteractionAction(float startingValue, float newThreshold, float increaseRate, string dictName, bool isIllegal, bool useLockpicks, Transform lookAtToComplete, bool cancelIfTooFar = true)
	{
	}

	public void SetIllegalActionActive(bool val)
	{
	}

	public void CancelInteractionAction()
	{
	}

	public void CompleteInteractionAction()
	{
	}

	private void OnDisable()
	{
	}

	public void PickUp(Interactable newObj)
	{
	}

	public void SetDialog(bool val, Interactable newTalkingTo, bool newIsRemote = false, Interactable newRemoteOverrideInteractable = null, ConversationType newConvoType = ConversationType.normal)
	{
	}

	public void RefreshDialogOptions()
	{
	}

	public void SetDialogSelection(int newVal)
	{
	}

	public void OnSabotage(Interactable inter)
	{
	}

	public void OnSabotageProgressChange(float amountChangeThisFrame, float amountToal)
	{
	}

	public void OnCompleteSabotage()
	{
	}

	public void OnReturnFromSabotage()
	{
	}

	public bool GetValidPlayerActionIllegal(Interactable inter, NewNode location, bool allowPublic = true, bool illegalIfNotPlayersHome = true)
	{
		return false;
	}

	public void UpdateNearbyInteractables()
	{
	}

	public void ClearNearbyInteractables()
	{
	}

	private List<Interactable> GetValidNearbyInteractables(NewNode node)
	{
		return null;
	}

	public void FocusOnInteractable(Interactable interactable)
	{
	}

	public void UpdateInteractionIcons()
	{
	}

	public void UpdateHighlightedInteractionIcon()
	{
	}
}
