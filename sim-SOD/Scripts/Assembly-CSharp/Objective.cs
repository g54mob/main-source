using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class Objective
{
	public enum DisplayPhase
	{
		preDisplay = 0,
		fadeInMainText = 1,
		displayMainText = 2,
		removeText = 3,
		displayingList = 4,
		waitForComplete = 5
	}

	public enum OnCompleteAction
	{
		nextChapterPart = 0,
		nextPartWhenAllCompleted = 1,
		specificChapterByString = 2,
		specificChapterWhenAllCompleted = 3,
		nothing = 4,
		invokeFunction = 5,
		triggerSideJobFunction = 6,
		triggerSideJobHandIn = 7,
		nextSideJobPhase = 8,
		submitSideJob = 9,
		completeCoverUp = 10,
		coverUpTips = 11,
		triggerRansomDelivery = 12,
		triggerRansomCollection = 13,
		triggerKidnapperRansomCollection = 14,
		kidnapperCollectedRansom = 15,
		kidnapperVictimFreed = 16
	}

	[Serializable]
	public class ObjectiveTrigger
	{
		public ObjectiveTriggerType triggerType;

		public bool forceProgressAmount;

		public float progressAdd;

		public bool triggered;

		public string name;

		public string hightlightAction;

		public bool orTrigger;

		public int roomID;

		public int interactableID;

		public string evidenceID;

		public Vector3Int nodeCoord;

		public int doorID;

		public int addressID;

		public int streetID;

		public int jobID;

		public Vector3 position;

		[NonSerialized]
		public NewRoom room;

		[NonSerialized]
		public Interactable interactable;

		[NonSerialized]
		public Evidence evidence;

		[NonSerialized]
		public NewNode node;

		[NonSerialized]
		public NewDoor door;

		[NonSerialized]
		public NewGameLocation gameLocation;

		[NonSerialized]
		public SideJob job;

		[NonSerialized]
		public List<Objective> addedToObjectives;

		public ObjectiveTrigger(ObjectiveTriggerType newType, string newName, bool newForceProgressAmount = false, float newProgressAdd = 0f, NewRoom newRoom = null, Interactable newInteractable = null, Evidence newEvidence = null, NewNode newNode = null, NewDoor newDoor = null, NewGameLocation newGameLocation = null, SideJob newJob = null, string newHighlightAction = "", bool newOrTrigger = false, Vector3 newPosition = default(Vector3))
		{
		}

		public void SetupNonSerialized()
		{
		}

		public void Trigger(bool onSetup = false)
		{
		}
	}

	public enum ObjectiveTriggerType
	{
		playerAction = 0,
		switchStateTrue = 1,
		switchStateFalse = 2,
		roomLightOn = 3,
		inspectInteractable = 4,
		evidencePinned = 5,
		goToNode = 6,
		keyInventory = 7,
		knowDoorLockedStatus = 8,
		goToAddress = 9,
		goToRoom = 10,
		playerHidden = 11,
		escapeGameLocation = 12,
		escapeBuilding = 13,
		answerPhone = 14,
		openEvidence = 15,
		plotRoute = 16,
		gameUnpaused = 17,
		unlockDoor = 18,
		goToPublicFacingAddress = 19,
		answerPhoneAndEndCall = 20,
		switchStateTrueForType = 21,
		linkImageWithName = 22,
		viewInteractable = 23,
		noMoreObjectives = 24,
		findFingerprints = 25,
		findSurveillanceWith = 26,
		findFingerprintsOnObject = 27,
		accessCruncher = 28,
		printVmail = 29,
		successsfulSolve = 30,
		makeCall = 31,
		discoverParamour = 32,
		onCompleteJob = 33,
		identifyFinerprints = 34,
		interactableRemoved = 35,
		checkRecentCalls = 36,
		acquireLockpicks = 37,
		unlockInteractable = 38,
		gamePaused = 39,
		evidenceOpenAndDisplayed = 40,
		collectHandIn = 41,
		viewHandIn = 42,
		submitCase = 43,
		waitForCaseProcessing = 44,
		surveillanceFlagFootage = 45,
		findFingerprintsAtLocation = 46,
		plotRouteToCallInvolving = 47,
		notewriterWarned = 48,
		exploreCrimeScene = 49,
		nothing = 50,
		playerHasApartment = 51,
		answerLEMCall = 52,
		discoverEvidence = 53,
		accessApp = 54,
		syncDiskInstallTutorial = 55,
		onDialogSuccess = 56,
		raiseFirstPersonItem = 57,
		hasFPSInventory = 58,
		sideMissionMeetTriggered = 59,
		itemInInventory = 60,
		itemIsPlacedAtSecretLocation = 61,
		destroyItem = 62,
		itemIsNear = 63,
		playerActionNobodyHome = 64,
		accessAnyCruncher = 65,
		itemOfTypeIsNear = 66,
		disposeOfBody = 67,
		ifValidRansomBriefcase = 68,
		ifNoValidRansomBriefcase = 69,
		kidnapperHasValidBriefcase = 70,
		victimIsFreed = 71
	}

	public delegate void ProgressChange();

	public delegate void Completed();

	public SpeechController.QueueElement queueElement;

	public string name;

	public float progress;

	public bool isComplete;

	public bool isCancelled;

	public DisplayPhase dispPhase;

	private float fadeInProgress;

	private float displayProgress;

	private float displayTime;

	private float crouchPromtTimer;

	[NonSerialized]
	public Case thisCase;

	[NonSerialized]
	public GameObject objectiveListItem;

	[NonSerialized]
	public RectTransform objectiveListRect;

	[NonSerialized]
	public ChecklistButtonController objectiveList;

	[NonSerialized]
	private bool displayPointer;

	[NonSerialized]
	public RectTransform pointerUIObject;

	[NonSerialized]
	public InterfaceController.AwarenessIcon awarenessIcon;

	[NonSerialized]
	public UIPointerController pointer;

	[NonSerialized]
	public Sprite sprite;

	[NonSerialized]
	public bool isSetup;

	[NonSerialized]
	public List<ObjectiveTrigger> appliedProgress;

	[NonSerialized]
	public bool clearedForAnimation;

	public ObjectiveTrigger objectiveAddOn;

	public float progressAdd;

	public event ProgressChange OnProgressChange
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

	public event Completed OnComplete
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

	public Objective(SpeechController.QueueElement newQueueElement)
	{
	}

	public void Setup(Case newCase)
	{
	}

	public void Activate(bool immediate = false)
	{
	}

	public void OnPlayerAction(AIActionPreset action, Interactable what, NewNode where, Actor who)
	{
	}

	public void Complete()
	{
	}

	public void Cancel()
	{
	}

	public void Remove()
	{
	}

	public void CheckingLoop()
	{
	}

	public void SetProgress(float newProgress)
	{
	}
}
