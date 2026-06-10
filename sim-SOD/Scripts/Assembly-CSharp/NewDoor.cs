using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;

public class NewDoor : MonoBehaviour
{
	public enum DoorSetting
	{
		leaveOpen = 0,
		leaveClosed = 1
	}

	public enum LockSetting
	{
		keepUnlocked = 0,
		keepLocked = 1
	}

	public enum CitizenPassResult
	{
		success = 0,
		isLocked = 1,
		isJammed = 2,
		isForbidden = 3
	}

	[CompilerGenerated]
	private sealed class _003COpenDoor_003Ed__69 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NewDoor _003C_003E4__this;

		public float speedMultiplier;

		public Actor actor;

		private float _003Cangle_003E5__2;

		private float _003CamountToRotate_003E5__3;

		private float _003CdoorSpeedMultiplier_003E5__4;

		private int _003CaudioUpdateTicker_003E5__5;

		private bool _003CcloseSFXPlayed_003E5__6;

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
		public _003COpenDoor_003Ed__69(int _003C_003E1__state)
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

	[Header("Location")]
	[Tooltip("This will remain static: Always the parent wall")]
	public NewWall wall;

	[Tooltip("The door will always be parented to the room the player is in (or can see).")]
	public NewRoom playerRoom;

	[Tooltip("This will change with the above, the wall this is currently parented to")]
	public NewWall parentedWall;

	[Header("Details")]
	public DoorPairPreset doorPairPreset;

	public DoorPreset preset;

	[Header("Spawned Objects")]
	public GameObject spawnedDoor;

	public List<Collider> spawnedDoorColliders;

	[NonSerialized]
	public Interactable doorInteractable;

	[NonSerialized]
	public Interactable handleInteractable;

	[NonSerialized]
	public Interactable peekInteractable;

	public RectTransform mapDoorObject;

	public GameObject doorSignFront;

	public GameObject doorSignRear;

	public InteractableController doorInteractableController;

	public InteractableController doorHandleInteractableController;

	public InteractableController peekInteractableController;

	public GameObject policeTape;

	public bool policeTapeSpawned;

	[Header("Door State")]
	[Tooltip("-1 = Open, 0 = Closed, 1 = Open")]
	public float ajar;

	[Tooltip("True if closed")]
	public bool isClosed;

	[Tooltip("True if closing (animation)")]
	public bool isClosing;

	[Tooltip("Updated actual ajar value that is consistent with animation")]
	public float ajarProgress;

	[Tooltip("How fast the door opens and closes")]
	public float doorOpenSpeed;

	[Tooltip("True if animating")]
	public bool animating;

	[Tooltip("What the AI will do when passing through the door")]
	public DoorSetting doorSetting;

	[Tooltip("What the AI will do when passing through the door")]
	public LockSetting lockSetting;

	[Tooltip("If there are others on this list when it comes to the AI closing the door behind them, keep it open.")]
	public HashSet<Actor> usingDoorList;

	[Tooltip("The door is being peeked under")]
	public bool peekedUnder;

	[Tooltip("True if the other side of this door would be trespassing")]
	public bool otherSideIsTrespassing;

	public int otherSideTrespassingEscalation;

	private NewRoom playerOtherSideRoom;

	public float desiredAngle;

	[Tooltip("The maximum angle for an open door. This should be less than 90 if you don't want it to clip close walls")]
	public float openAngle;

	[Tooltip("Is this door locked?")]
	public bool isLocked;

	[Tooltip("Is this door jammed with a door wedge?")]
	public bool isJammed;

	[NonSerialized]
	public Interactable doorWedge;

	[Tooltip("Is this door marked as forbidden for public?")]
	public bool forbiddenForPublic;

	[Tooltip("Does the player know the status of the lock?")]
	public bool knowLockStatus;

	[Tooltip("Knock attempt count for the player")]
	public bool knockingInProgress;

	[Tooltip("True if this features a neon sign")]
	public bool featuresNeonSign;

	[NonSerialized]
	[Tooltip("Lock interactable")]
	public Interactable lockInteractableFront;

	[NonSerialized]
	public Interactable lockInteractableRear;

	public NewRoom passwordDoorsRoom;

	private AudioController.LoopingSoundInfo lockpickLoop;

	public List<NewNode> bothNodesForAudioSource;

	private bool audioLoopStarted;

	[Header("Debug")]
	public List<string> passwordPlacementDebug;

	public List<string> isLockedDebug;

	public void Setup(NewWall newParent)
	{
	}

	public void PlaceKeys()
	{
	}

	private void GetPreset()
	{
	}

	public void SelectColouring(bool overrideWithKey = false, Toolbox.MaterialKey keyOverride = null)
	{
	}

	public void SpawnDoor()
	{
	}

	private void UpdateMapDoor(bool updateIfDoorIsCulled = false)
	{
	}

	public void UpdateNameBasedOnPlayerPosition()
	{
	}

	private NewNode GetBehindNode()
	{
		return null;
	}

	private NewNode GetInfontNode()
	{
		return null;
	}

	public string GetNameForParent()
	{
		return null;
	}

	public string GetName()
	{
		return null;
	}

	public void ParentToRoom(NewRoom newRoom)
	{
	}

	public void SetKnowLockedStatus(bool val)
	{
	}

	public void SetPlayerHasKey(bool val)
	{
	}

	public void OpenByActor(Actor actor, bool forceInverseOpenDirection = false, float speedMultiplier = 1f)
	{
	}

	public void SetOpen(float newAjar, Actor actor, bool skipAnimation = false, float speedMultiplier = 1f)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	[IteratorStateMachine(typeof(_003COpenDoor_003Ed__69))]
	private IEnumerator OpenDoor(Actor actor, float speedMultiplier)
	{
		return null;
	}

	public void OnClose(Actor actor)
	{
	}

	public void SetCollisionsWithPlayerActive(bool val)
	{
	}

	public void OnOpen(Actor actor)
	{
	}

	public void SetLocked(bool val, Actor actor, bool playSound = true)
	{
	}

	public void SetJammed(bool val, Interactable doorWedgeUsed = null, bool createUsedWedge = true)
	{
	}

	public void SetForbidden(bool val)
	{
	}

	public void SetPoliceTape(bool policeTapActive)
	{
	}

	public bool CitizenPassCheck(Human cc, out CitizenPassResult reason)
	{
		reason = default(CitizenPassResult);
		return false;
	}

	public void Barge(Actor barger)
	{
	}

	public void OnKnock(Actor actor, int knockCount = 2, float forceAdditionalUrgency = 0f)
	{
	}

	public void OnDoorPeek()
	{
	}

	public void OnReturnFromPeek()
	{
	}

	public void OnLockpick()
	{
	}

	public void OnLockpickLookedAway()
	{
	}

	public void OnLockpickProgressChange(float amountChangeThisFrame, float amountToal)
	{
	}

	public void OnCompleteLockpick()
	{
	}

	public void OnReturnFromLockpick()
	{
	}

	public bool GetDefaultLockState()
	{
		return false;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DebugTestPlayersRelativePosition()
	{
	}
}
