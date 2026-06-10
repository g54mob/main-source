using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
	[Serializable]
	public class History
	{
		public string evID;

		public List<Evidence.DataKey> keys;

		public float lastAccess;

		public int locationID;
	}

	[Serializable]
	public class LostAndFound
	{
		public string preset;

		public int ownerID;

		public int buildingID;

		public int spawnedItem;

		public int spawnedNote;

		public int rewardMoney;

		public int rewardSC;
	}

	public class DoorKnockAttempt
	{
		public Actor human;

		public float value;
	}

	[Serializable]
	public class Passcode
	{
		public List<int> digits;

		public PasscodeType type;

		public int id;

		public bool used;

		public List<int> notes;

		public Passcode(PasscodeType newType)
		{
		}

		public string GetNotePlacements()
		{
			return null;
		}

		public List<int> GetDigits()
		{
			return null;
		}

		public int GetDigit(int index)
		{
			return 0;
		}
	}

	public enum PasscodeType
	{
		citizen = 0,
		room = 1,
		address = 2,
		interactable = 3
	}

	[Serializable]
	public class PhoneNumber
	{
		public int number;

		public string textOverride;

		public bool loc;

		public List<int> p;
	}

	[Serializable]
	public class HotelGuest
	{
		public int addID;

		public int humanID;

		public int roomCost;

		public int bill;

		public float lastPayment;

		public float nextPayment;

		public Human GetHuman()
		{
			return null;
		}

		public NewAddress GetAddress()
		{
			return null;
		}

		public void PayBill(int amount)
		{
		}

		public void FromLoadGame()
		{
		}
	}

	[Serializable]
	public class EnforcerCall
	{
		public bool isStreet;

		public int id;

		public float logTime;

		public EnforcerCallState state;

		public List<int> response;

		public float arrivalTime;

		public bool isCrimeScene;

		public bool immedaiteTeleport;

		public int guard;

		public float delay;
	}

	public enum EnforcerCallState
	{
		logged = 0,
		responding = 1,
		arrived = 2,
		completed = 3
	}

	[Serializable]
	public class Footprint
	{
		public int hID;

		public int rID;

		public Vector3 wP;

		public Vector3 eU;

		public float str;

		public float bl;

		public float t;

		public Footprint(Human human, Vector3 position, Vector3 euler, float dirt, float blood, NewRoom forceRoom = null)
		{
		}
	}

	[Serializable]
	public class LoanDebt
	{
		public int companyID;

		public int debt;

		public int payments;

		public int missedPayments;

		public float nextPaymentDueBy;

		public float dueCheck;

		public int GetRepaymentAmount()
		{
			return 0;
		}
	}

	public delegate void MatchesChange();

	public delegate void NewEvidenceHistory();

	public delegate void NewPhoneData();

	[CompilerGenerated]
	private sealed class _003CWaitForEndCall_003Ed__129 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GameplayController _003C_003E4__this;

		public NewGameLocation newLocation;

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
		public _003CWaitForEndCall_003Ed__129(int _003C_003E1__state)
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
	private sealed class _003CDoorKnockSounds_003Ed__136 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public NewDoor door;

		public float nextUrgency;

		public Actor actor;

		public int knocks;

		private float _003Cvol_003E5__2;

		private float _003Cdelay_003E5__3;

		private AudioEvent _003CknockAudio_003E5__4;

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
		public _003CDoorKnockSounds_003Ed__136(int _003C_003E1__state)
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

	public Dictionary<string, Evidence> evidenceDictionary;

	public List<Fact> factList;

	public List<Evidence> singletonEvidence;

	public List<EvidenceDate> dateEvidence;

	public List<EvidenceTime> timeEvidence;

	public List<EvidenceMultiPage> multiPageEvidence;

	public List<History> history;

	[NonSerialized]
	public List<History> itemOnlyHistory;

	public Dictionary<Vector3, Interactable> confirmedPrints;

	public int printsLetterLoop;

	public HashSet<Interactable> objectsWithDynamicPrints;

	public Dictionary<MatchPreset, List<Evidence>> parentMatches;

	public Dictionary<MatchPreset, List<FactMatches>> matchesDetails;

	public Dictionary<NewAddress, Vector2> guestPasses;

	public Dictionary<int, StateSaveData.MessageThreadSave> messageThreads;

	public int assignMessageThreadID;

	public List<Human> enforcers;

	public Dictionary<NewGameLocation, EnforcerCall> enforcerCalls;

	public Dictionary<Case, float> caseProcessing;

	public List<Interactable> hospitalBeds;

	public Dictionary<Vector3, float> brokenWindows;

	public Dictionary<NewDoor, List<DoorKnockAttempt>> doorKnockAttempts;

	public List<Interactable> activeGadgets;

	public HashSet<NewGameLocation> crimeScenes;

	public List<NewDoor> policeTapeDoors;

	public List<NewGameLocation> crimeSceneCleanups;

	public List<Interactable> closedBreakers;

	public List<Interactable> turnedOffSecurity;

	public List<Interactable> burningBarrels;

	public Dictionary<Interactable, float> switchRessetingObjects;

	public List<int> playerKnowsPasswords;

	public List<NewRoom> gasRooms;

	public List<string> companiesSabotaged;

	public Dictionary<string, float> globalConversationDelay;

	public List<string> booksRead;

	public List<Interactable> activeKettles;

	public List<Interactable> activeMusicPlayers;

	public Dictionary<string, Material> graffitiCache;

	public Dictionary<Interactable, List<NewNode>> activeTrackers;

	public HashSet<NewNode> trackedNodes;

	public Dictionary<Interactable, float> proxyTrackers;

	public List<Interactable> activeGrenades;

	public GameObject setDefaultItemButton;

	public GameObject defaultItemButton;

	[Header("Player Stats")]
	public int money;

	public int lockPicks;

	public int socialCredit;

	public List<SocialControls.SocialCreditBuff> socialCreditPerks;

	public float currentLockpickStrength;

	public int perilFine;

	public string[] doeLetters;

	public float timeSinceLastUpdateLoop;

	public float lastUpdateLoop;

	[Header("Passcodes")]
	public List<Passcode> acquiredPasscodes;

	[Header("Phone Numbers")]
	public List<PhoneNumber> acquiredNumbers;

	[Header("Apartments for Sale")]
	public List<NewAddress> forSale;

	[Header("Hotel")]
	public List<HotelGuest> hotelGuests;

	[Header("Culling State")]
	public List<NewRoom> roomsVicinity;

	public List<AirDuctGroup> ductsVicinity;

	public HashSet<Human> activeRagdolls;

	public HashSet<Interactable> activePhysics;

	[Header("Clean-up")]
	public List<SpatterSimulation> spatter;

	public List<Interactable> interactablesMoved;

	public HashSet<NewDoor> damagedDoors;

	[Header("Security")]
	public List<NewBuilding> activeAlarmsBuildings;

	public List<NewAddress> activeAlarmsLocations;

	public List<NewBuilding> alteredSecurityTargetsBuildings;

	public List<NewAddress> alteredSecurityTargetsLocations;

	[Header("Footprints")]
	public List<Footprint> footprintsList;

	public Dictionary<NewRoom, List<Footprint>> activeFootprints;

	public Dictionary<Vector3, Interactable> confirmedFootprints;

	public Dictionary<ArtPreset, Material> dynamicTextImages;

	public List<Texture2D> generatedTextures;

	public List<LoanDebt> debt;

	[Header("Difficulty")]
	[Tooltip("Dictates which missions can spawn...")]
	public int jobDifficultyLevel;

	private Action UpdateMatch;

	private static GameplayController _instance;

	public static GameplayController Instance => null;

	public event MatchesChange OnMatchesChanged
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

	public event NewEvidenceHistory OnNewEvidenceHistory
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

	public event NewPhoneData OnNewPhoneData
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

	public void DestroySelf()
	{
	}

	public void UpdateConversationDelays()
	{
	}

	public void AddNewMatch(MatchPreset match, Evidence newEntry)
	{
	}

	private void OnDiscoverMatchEvidence(Evidence ev)
	{
	}

	public void UpdateMatchesEndOfFrame()
	{
	}

	public void RemoveMatch(MatchPreset match, Evidence newEntry)
	{
	}

	public void UpdateMatches()
	{
	}

	public void AddHistory(Evidence entry, List<Evidence.DataKey> keys)
	{
	}

	public void AddMoney(int addVal, bool displayMessage, string reason)
	{
	}

	public void SetMoney(int newVal)
	{
	}

	public void AddSocialCredit(int addVal, bool displayMessage, string reason)
	{
	}

	public void SetSocialCredit(int newVal)
	{
	}

	public int GetCurrentSocialCreditLevel()
	{
		return 0;
	}

	public int GetNextSocialCreditLevelThreshold()
	{
		return 0;
	}

	public int GetSocialCreditLevel(int points)
	{
		return 0;
	}

	public int GetSocialCreditThreshold(int points)
	{
		return 0;
	}

	public int GetSocialCreditThresholdForLevel(int level)
	{
		return 0;
	}

	public void AddLockpicks(int addVal, bool displayMessage)
	{
	}

	public void SetLockpicks(int newVal)
	{
	}

	public void UseLockpick(float val)
	{
	}

	public void DepleteLockpick()
	{
	}

	public void AddGuestPass(NewAddress loc, float forHours)
	{
	}

	public void AddGuestPass(NewAddress loc, Vector2 directData)
	{
	}

	public void CallEnforcers(NewGameLocation newLocation, bool forceCrimeScene = false, bool immediateTeleport = false, float delay = 0f)
	{
	}

	[IteratorStateMachine(typeof(_003CWaitForEndCall_003Ed__129))]
	private IEnumerator WaitForEndCall(NewGameLocation newLocation)
	{
		return null;
	}

	private void NewMurderCaseNotify(NewGameLocation newLocation)
	{
	}

	public void AddPasscode(Passcode newCode, bool displayMessage = true)
	{
	}

	public void AddOrMergePhoneNumberData(int newNumber, bool knowLocation, List<Human> knowCitizens, string textOverride = "", bool displayMessage = true)
	{
	}

	public void AddDoorKnockAttempt(NewDoor door, Actor human)
	{
	}

	public float GetDoorKnockAttemptValue(NewDoor door, Actor human)
	{
		return 0f;
	}

	public void KnockOnDoor(NewDoor door, Actor actor, int knocks = 2, float forceAdditionalUrgency = 0f)
	{
	}

	[IteratorStateMachine(typeof(_003CDoorKnockSounds_003Ed__136))]
	private IEnumerator DoorKnockSounds(NewDoor door, Actor actor, float nextUrgency, int knocks = 2)
	{
		return null;
	}

	public void SetJobDifficultyLevel(int newInt)
	{
	}

	public void AddToGraffitiCache(string obj, Material mat)
	{
	}

	public void AddMotionTracker(Interactable newTracker, int range)
	{
	}

	public void RemoveMotionTracker(Interactable newTracker)
	{
	}

	public void AddProxyDetonator(Interactable newTracker, float range)
	{
	}

	public void RemoveProxyDetonator(Interactable newTracker)
	{
	}

	public void SetPlayerKnowsPassword(NewAddress newAddress)
	{
	}

	public void ProcessDynamicTextImages()
	{
	}

	public void AddNewDebt(Company company, int amount, int paymentExtra, int repayments)
	{
	}

	public void DebtPayment(Company company)
	{
	}

	public void ShortDebtPayment(Company company, int amount)
	{
	}

	public void AddHotelGuest(Human human, bool expensiveRoom)
	{
	}

	public void AddHotelGuest(NewAddress address, Human human, int cost)
	{
	}

	public void RemoveHotelGuest(NewAddress address, Human human, bool removeKey = true)
	{
	}
}
