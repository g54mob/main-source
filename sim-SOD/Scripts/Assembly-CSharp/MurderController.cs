using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;

public class MurderController : MonoBehaviour
{
	[Serializable]
	public class MurderMethod
	{
		public MurderWeaponPreset.WeaponType type;

		public string blockDDS;
	}

	public struct CachedSniperLocation
	{
		public NewWall location;

		public float score;
	}

	public enum MurderState
	{
		none = 0,
		acquireEuipment = 1,
		research = 2,
		waitForLocation = 3,
		travellingTo = 4,
		executing = 5,
		post = 6,
		escaping = 7,
		unsolved = 8,
		solved = 9
	}

	public enum KidnapRansomPhase
	{
		none = 0,
		travellingToRansom = 1,
		collectedRansom = 2,
		freeingVictim = 3,
		finishedFailed = 4,
		finishedSuccess = 5
	}

	[Serializable]
	public class MurderPick
	{
		public Human person;

		public MurderMO mo;

		public float score;
	}

	[Serializable]
	public class Murder
	{
		public delegate void OnMurderStateChange(MurderState newState);

		[Header("Serializable Data")]
		public string presetStr;

		public string moStr;

		public float creationTime;

		public int murderID;

		public int murdererID;

		public int victimID;

		public int streetID;

		public MurderState state;

		public int addressID;

		public float waitingTimestamp;

		public float time;

		public string monkierPre;

		public string monkierPost;

		public int victimSiteID;

		public bool victimSiteIsStreet;

		public bool kidnapKillPhase;

		public Vector3Int sniperKillShotNode;

		[Space(7f)]
		public int ransomSiteID;

		public int ransomAmount;

		public int fakeNumber;

		public string fakeNumberStr;

		public KidnapRansomPhase ransomPhase;

		public float killTime;

		public int meetRestaurantID;

		public int boothSeat1ID;

		public int boothSeat2ID;

		public float meetTimeTotal;

		public float meetTime;

		[Space(7f)]
		public string weaponStr;

		public string ammoStr;

		public int weaponID;

		public int ammoID;

		public int weaponSourceID;

		public bool acquiredEquipment;

		public float dropChance;

		[Space(7f)]
		public string callingCardStr;

		public MurderMO.CallingCardOrigin callingCardOrigin;

		public int callingCardID;

		public List<int> graffitiIDs;

		public string graffitiMsg;

		[Space(7f)]
		public List<int> cullingActiveRooms;

		[NonSerialized]
		[Header("NonSerialzed Data")]
		public MurderPreset preset;

		[NonSerialized]
		public MurderMO mo;

		[NonSerialized]
		public Human murderer;

		[NonSerialized]
		public Human victim;

		[NonSerialized]
		public NewAIGoal murderGoal;

		[NonSerialized]
		public NewGameLocation location;

		[NonSerialized]
		public Human.Death death;

		[NonSerialized]
		public Dictionary<JobPreset.JobTag, Interactable> activeMurderItems;

		[NonSerialized]
		public InteractablePreset weaponPreset;

		[NonSerialized]
		public InteractablePreset ammoPreset;

		[NonSerialized]
		public Interactable weapon;

		[NonSerialized]
		public Interactable ammo;

		[NonSerialized]
		public InteractablePreset callingCardPreset;

		[NonSerialized]
		public Interactable callingCard;

		[NonSerialized]
		public Company weaponSource;

		[NonSerialized]
		public List<Interactable> graffiti;

		[NonSerialized]
		public NewGameLocation sniperVictimSite;

		[NonSerialized]
		public NewBuilding ransomSite;

		[NonSerialized]
		public NewAddress meetRestaurant;

		[NonSerialized]
		public Interactable boothSeat1;

		[NonSerialized]
		public Interactable boothSeat2;

		[NonSerialized]
		public NewAIGoal meetGoal1;

		[NonSerialized]
		public NewAIGoal meetGoal2;

		public event OnMurderStateChange OnStateChanged
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

		public Murder(Human newMurderer, Human newVictim, MurderPreset newPreset, MurderMO newMotive, NewGameLocation newVictimSite = null)
		{
		}

		public void LoadSerializedData()
		{
		}

		public void CreateMurderGoal()
		{
		}

		public void SetMurderState(MurderState newState, bool force = false, bool doSpawnItemsCheck = true)
		{
		}

		public void CancelCurrentMurder()
		{
		}

		public bool IsValidLocation(NewGameLocation newLoc)
		{
			return false;
		}

		public void PickNewMurderWeapon()
		{
		}

		public void PickNewCallingCard()
		{
		}

		public void SetMurderWeaponActual(Interactable newObj)
		{
		}

		public void SetMurderLocation(NewGameLocation newLoc)
		{
		}

		public void EuipmentCheck()
		{
		}

		public string GetMonkier()
		{
			return null;
		}

		public void GenerateMoniker()
		{
		}

		public void PlaceCallingCard()
		{
		}

		public void WeaponDisposal()
		{
		}

		public void GenerateGraffiti()
		{
		}

		public void OnCleanCrimeScene()
		{
		}

		public void GenerateRansomDetails()
		{
		}

		public virtual void GenerateFakeNumber()
		{
		}

		public void SetRansomPhase(KidnapRansomPhase newPhase)
		{
		}

		public bool TryPickNewVictimSite(out NewGameLocation newTargetSite)
		{
			newTargetSite = null;
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CCleanUpKidnapCall_003Ed__67 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MurderController _003C_003E4__this;

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
		public _003CCleanUpKidnapCall_003Ed__67(int _003C_003E1__state)
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

	[Header("Debug")]
	public bool useDebugOverride;

	[ShowIf("useDebugOverride")]
	public MurderPreset debugMurderPreset;

	[ShowIf("useDebugOverride")]
	public MurderMO debugMO;

	[Header("State")]
	public bool procGenLoopActive;

	public bool murderRoutineActive;

	public Human currentMurderer;

	public Human currentVictim;

	[NonSerialized]
	public Case currentActiveCase;

	public bool debugActiveCaseExists;

	public MurderPreset murderPreset;

	public MurderMO chosenMO;

	public List<Human> previousMurderers;

	public float pauseBetweenMurders;

	public float pauseBeforeKidnapperKill;

	private float locationUpdateTimer;

	public int maxDifficultyLevel;

	public NewGameLocation currentVictimSite;

	public bool triggerCoverUpCall;

	private TelephoneController.PhoneCall coverUpCall;

	public bool playerAcceptedCoverUp;

	public bool triggerCoverUpSuccess;

	private TelephoneController.PhoneCall successCall;

	private bool triggeredSeenWarning;

	private TelephoneController.PhoneCall kidnapperNotCaughtCall;

	private Objective.ObjectiveTrigger answerCall;

	private bool kidnapperTauntCallTriggered;

	private float kidnapperTauntCallTime;

	public int kidnapperTauntPhone;

	public int kidnapperTauntFromPhone;

	private List<NewGameLocation> sniperVictimSites;

	[Header("DDS")]
	public List<MurderMethod> methodTypes;

	[Header("Murder")]
	public int assignMurderID;

	public List<Murder> activeMurders;

	public List<Murder> inactiveMurders;

	public float sniperShotDelay;

	public float limbTargetCycleCounter;

	public int limbTargetCycle;

	[Header("References")]
	public AIGoalPreset murderGoalPreset;

	[Header("Debug")]
	public List<MurderPick> debugLastMurderPicks;

	public int debugMurderID;

	private static MurderController _instance;

	public static MurderController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetProcGenKillerLoop(bool val)
	{
	}

	public Murder GetCurrentMurder()
	{
		return null;
	}

	public void Tick(float timePassed)
	{
	}

	public void PickNewMurderer()
	{
	}

	private void OnValidate()
	{
	}

	public void OnVictimDiscovery()
	{
	}

	public void OnVictimKilled()
	{
	}

	public void TriggerCoverUpTelephoneCall()
	{
	}

	public void OnCoverUpAccept()
	{
	}

	public void OnCoverUpReject()
	{
	}

	public void TriggerCoverUpObjective()
	{
	}

	public void TriggerKidnappingCase()
	{
	}

	public void TriggerRansomDelivery()
	{
	}

	public void KidnapperCollectsRansom()
	{
	}

	public void KidnapperCollectedRansom()
	{
	}

	public void TriggerRansomFail()
	{
	}

	[IteratorStateMachine(typeof(_003CCleanUpKidnapCall_003Ed__67))]
	private IEnumerator CleanUpKidnapCall()
	{
		return null;
	}

	public void VictimFreed()
	{
	}

	public void ResetKidnapper()
	{
	}

	public void OnCaseSolved()
	{
	}

	public void CitizenHasSeenBody(Human seenBody, Human seenBy)
	{
	}

	public void CoverUpFailCheck(Human seenBody)
	{
	}

	public void TriggerSuccessfulCoverUp(Evidence passedCitizen)
	{
	}

	public void TriggerCoverUpSuccessCall()
	{
	}

	public void OnCoverUpSuccessEnd()
	{
	}

	public void DisplayCoverUpTips()
	{
	}

	public void AssignActiveCase(Case newCase)
	{
	}

	public void UpdateCorrectResolveAnswers()
	{
	}

	public void UpdateResolveQuestions(bool clearExisting)
	{
	}

	public void PickNewVictim()
	{
	}

	public bool TraitTest(Citizen cit, ref List<MurderPreset.MurdererModifierRule> rules, out float output)
	{
		output = default(float);
		return false;
	}

	public Murder ExecuteNewMurder(Human newMurderer, Human newVictim, MurderPreset preset, MurderMO motive, NewGameLocation victimSite = null)
	{
		return null;
	}

	private void Update()
	{
	}

	public void ExecuteSniperShot(Human victim, Human killer, Ray confirmationRay, RaycastHit confirmationHit, Transform victimTargetTransform, bool forceKill = false)
	{
	}

	private void CleanupKidnapperTaunt()
	{
	}

	public void SetUpdateEnabled(bool val)
	{
	}

	public void OnStartGame()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TriggerNextMurder()
	{
	}

	public virtual void SpawnItemsCheck(Murder murder)
	{
	}

	private bool SpawnItemIsValid(Murder murder, MurderPreset.MurderLeadItem spawn, ref List<MurderPreset.MurderLeadItem> successsfullySpawned, bool useChance)
	{
		return false;
	}

	public Interactable SpawnItem(Murder murder, InteractablePreset spawnItem, MurderPreset.LeadSpawnWhere spawnWhere, MurderPreset.LeadCitizen spawnBelongsTo, MurderPreset.LeadCitizen spawnWriter, MurderPreset.LeadCitizen spawnReceiver, int security, InteractablePreset.OwnedPlacementRule ownedRule, int priority, JobPreset.JobTag itemTag)
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void LastMurderLocation()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ListSpawnedMurderItems()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void SpawnPlayerTaunt()
	{
	}
}
