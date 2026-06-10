using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StateSaveData
{
	[Serializable]
	public class CrimeSceneCleanup
	{
		public bool isStreet;

		public int id;
	}

	[Serializable]
	public class BrokenWindowSave
	{
		public Vector3 pos;

		public float brokenAt;
	}

	[Serializable]
	public class ScannedObjPrint
	{
		public int objID;

		public List<int> prints;
	}

	[Serializable]
	public class ChaperStateSave
	{
		public List<ChapterSaveData> data;

		public void AddData(string reference, int integer)
		{
		}

		public void AddData(string reference, float floatP)
		{
		}

		public void AddData(string reference, string str)
		{
		}

		public void AddData(string reference, bool b)
		{
		}

		public bool GetDataBool(string reference)
		{
			return false;
		}

		public int GetDataInt(string reference)
		{
			return 0;
		}

		public float GetDataFloat(string reference)
		{
			return 0f;
		}

		public string GetDataString(string reference)
		{
			return null;
		}
	}

	[Serializable]
	public class ChapterSaveData
	{
		public string reference;

		public string data;
	}

	[Serializable]
	public class EvidenceStateSave
	{
		public string id;

		public string dds;

		public bool found;

		public List<EvidenceDataKeyTie> keyTies;

		public List<Evidence.Discovery> discovery;

		public bool fs;

		public string n;

		public List<Evidence.CustomName> customName;

		public List<EvidenceMultiPage.MultiPageContent> mpContent;
	}

	[Serializable]
	public class EvidenceDataKeyTie
	{
		public Evidence.DataKey key;

		public List<Evidence.DataKey> tied;
	}

	[Serializable]
	public class FakeTelephone
	{
		public int number;

		public TelephoneController.CallSource source;
	}

	[Serializable]
	public class BuildingStateSav
	{
		public int id;

		public bool alarmActive;

		public float alarmTimer;

		public NewBuilding.AlarmTargetMode targetMode;

		public float targetModeSetAt;

		public List<int> targets;

		public float wanted;

		public List<ElevatorStateSave> elevators;

		public List<TelephoneController.PhoneCall> callLog;

		public List<GameplayController.LostAndFound> lostAndFound;
	}

	[Serializable]
	public class ElevatorStateSave
	{
		public int tileID;

		public float yPos;

		public int floor;
	}

	[Serializable]
	public class FloorStateSave
	{
		public int id;

		public bool alarmLockdown;
	}

	[Serializable]
	public class AddressStateSave
	{
		public int id;

		public int sale;

		public List<NewAddress.Vandalism> vandalism;

		public bool alarmActive;

		public float alarmTimer;

		public NewBuilding.AlarmTargetMode targetMode;

		public float targetModeSetAt;

		public List<int> targets;

		public List<NewGameLocation.TrespassEscalation> escalation;

		public float loiter;
	}

	[Serializable]
	public class CompanyStateSave
	{
		public int id;

		public List<Company.SalesRecord> sales;
	}

	[Serializable]
	public class GuestPassStateSave
	{
		public int id;

		public Vector2 guestPassUntil;
	}

	[Serializable]
	public class RoomStateSave
	{
		public int id;

		public int ex;

		public bool ml;

		public float gl;

		public int fID;

		public int iID;

		public List<CitySaveData.RoomCitySave> decorOverride;

		public List<ChangedLightswitch> ls;
	}

	[Serializable]
	public class CitizenStateSave
	{
		public int id;

		public Vector3 pos;

		public Quaternion rot;

		public int trespassingEscalation;

		public ClothesPreset.OutfitCategory currentOutfit;

		public float nourishment;

		public float hydration;

		public float alertness;

		public float energy;

		public float excitement;

		public float chores;

		public float hygiene;

		public float bladder;

		public float heat;

		public float drunk;

		public float breath;

		public float poisoned;

		public float blinded;

		public int poisoner;

		public int den;

		public int kidnapper;

		public bool remFromWorld;

		public float currentHealth;

		public float currentNerve;

		public float fsDirt;

		public float fsBlood;

		public List<Human.Wound> wounds;

		public Vector3Int investigateLocation;

		public Vector3 investigatePosition;

		public Vector3 investigatePositionProjection;

		public float lastInvestigate;

		public bool persuit;

		public bool seesPlayerOnPersuit;

		public float persuitChaseLogicUses;

		public int persuitTarget;

		public bool persuitPlayer;

		public int escalationLevel;

		public float minimumInvestigationTimeMultiplier;

		public NewAIController.ReactionState reactionState;

		public List<int> atHome;

		public bool convicted;

		public bool unreportable;

		public bool ko;

		public float koTime;

		public bool res;

		public float resTime;

		public float spooked;

		public int spookCount;

		public Human.Death death;

		public List<CitizenAnimationController.RagdollSnapshot> ragdollSnapshot;

		public List<CitizenAnimationController.RagdollSnapshotWorld> ragdollSnapshotWorld;

		public List<Human.WalletItem> wallet;

		public CurrentGoalStateSave currentGoal;

		public int fingerprintLoop;

		public List<string> currentConsumable;

		public List<int> trash;

		public List<int> putDown;

		public List<int> sightingCit;

		public List<Human.Sighting> sightings;

		public AvoidConfineStateSave confine;

		public List<AvoidConfineStateSave> avoid;

		public List<Human.InteractionDialogInstance> interactionDialog;
	}

	[Serializable]
	public class AvoidConfineStateSave
	{
		public int id;

		public bool st;
	}

	[Serializable]
	public class CurrentGoalStateSave
	{
		public string preset;

		public float priority;

		public float trigerTime;

		public float timestamp;

		public float duration;

		public Vector3Int passedNode;

		public int passedInteractable;

		public int gameLocation;

		public int room;

		public bool isAddress;

		public int passedGroup;

		public int jobID;

		public int var;

		public List<AIActionStateSave> actions;
	}

	[Serializable]
	public class AIActionStateSave
	{
		public string preset;

		public Vector3 node;

		public int interactable;

		public int passedInteractable;

		public int passedRoom;

		public int passedGroup;

		public Vector3Int forcedNode;

		public bool repeat;

		public bool inserted;

		public int iap;
	}

	[Serializable]
	public class DoorStateSave
	{
		public int id;

		public bool l;

		public float ds;

		public float ls;

		public float ajar;

		public bool cs;
	}

	[Serializable]
	public class MessageThreadSave
	{
		public int threadID;

		public DDSSaveClasses.TreeType msgType;

		public string treeID;

		public int participantA;

		public int participantB;

		public int participantC;

		public int participantD;

		public List<int> cc;

		public List<string> messages;

		public List<int> senders;

		public List<int> recievers;

		public List<float> timestamps;

		public float time;

		public CustomDataSource ds;

		public int dsID;
	}

	public enum CustomDataSource
	{
		sender = 0,
		groupID = 1
	}

	[Serializable]
	public class AirDuctExplorationSave
	{
		public int grpID;

		public List<int> vents;

		public List<Vector3Int> ducts;
	}

	[Serializable]
	public class ChangedLightswitch
	{
		public Vector3 locPos;

		public Vector3 locEuler;

		public bool added;
	}

	[Header("Session Data")]
	public string build;

	public string cityShare;

	public List<string> instanceIDs;

	public List<string> compositionData;

	public int dynamicPrintsCount;

	public int sceneCaptureCount;

	public int sceneCapMax;

	public string saveTime;

	public float gameTime;

	public float timeLimit;

	public int leapCycle;

	public int fingerprintLoop;

	public int assignCaptureID;

	public int assignMessageThreadID;

	public int assignGroupID;

	public int assignStickNote;

	public int assignInteractableID;

	public int assignCaseID;

	public int assignMurderID;

	public int gameLength;

	public float currentRain;

	public float desiredRain;

	public float currentWind;

	public float desiredWind;

	public float currentSnow;

	public float desiredSnow;

	public float currentLightning;

	public float desiredLightning;

	public float currentFog;

	public float desiredFog;

	public float cityWetness;

	public float citySnow;

	public float weatherChange;

	public List<SideJob> basicJobs;

	public List<SideJobAffair> affairJobs;

	public List<SideJobSabotage> sabotageJobs;

	public List<SideJobStolenItem> stolenItemJobs;

	public List<SideJobMissingPerson> missingPersonJobs;

	public List<SideJobRevenge> revengeJobs;

	public List<SideJobStealBriefcase> briefcaseJobs;

	public int jobDiffLevel;

	public int chapter;

	public int chapterPart;

	public ChaperStateSave chapterSaveState;

	public bool mapPathActive;

	public bool mapPathNodeSpecific;

	public Vector3Int mapPathNode;

	public List<Case> activeCases;

	public List<Case> archivedCases;

	public int activeCase;

	public List<GameplayController.Footprint> footprints;

	public List<GameplayController.History> history;

	public List<GameplayController.Passcode> passcodes;

	public List<GameplayController.PhoneNumber> numbers;

	public List<GameplayController.EnforcerCall> enforcerCalls;

	public List<CrimeSceneCleanup> crimeSceneCleanup;

	public List<GameplayController.HotelGuest> hotelGuests;

	public List<BrokenWindowSave> brokenWindows;

	public NewspaperController.NewspaperState newspaperState;

	public string playerFirstName;

	public string playerSurname;

	public Human.Gender playerGender;

	public Human.Gender partnerGender;

	public Color playerSkinColour;

	public int playerBirthDay;

	public int playerBirthMonth;

	public int playerBirthYear;

	public int residence;

	public List<int> apartmentsOwned;

	public bool accidentCover;

	public List<int> foodH;

	public List<int> sanitary;

	public List<int> ops;

	public List<int> knowsPasswords;

	public List<GameplayController.LoanDebt> debt;

	public int carried;

	public bool tutorial;

	public List<string> tutTextTriggered;

	public List<FirstPersonItemController.InventorySlot> firstPersonItems;

	public List<ScannedObjPrint> scannedPrints;

	public Vector3 playerPos;

	public Quaternion playerRot;

	public int money;

	public int lockpicks;

	public int socCredit;

	public List<string> socCreditPerks;

	public float health;

	public float nourishment;

	public float hydration;

	public float alertness;

	public float energy;

	public float hygiene;

	public float heat;

	public float drunk;

	public float sick;

	public float headache;

	public float wet;

	public float brokenLeg;

	public float bruised;

	public float blackEye;

	public float blackedOut;

	public float numb;

	public float poisoned;

	public float bleeding;

	public float wellRested;

	public float starchAddiction;

	public float syncDiskInstall;

	public float blinded;

	public bool crouched;

	public List<UpgradesController.Upgrades> upgrades;

	public List<string> sabotaged;

	public List<string> booksRead;

	public List<SceneRecorder.SceneCapture> playerSavedCaptures;

	public List<SpeechController.QueueElement> speech;

	public List<int> keyring;

	public List<int> keyringInt;

	public List<FakeTelephone> fakeTelephone;

	public int hideInteractable;

	public int hideRef;

	public int phoneInteractable;

	public int computerInteractable;

	public int duct;

	public Vector3 storedTransPos;

	public List<BuildingStateSav> buildings;

	public List<CompanyStateSave> companies;

	public List<MessageThreadSave> messageThreads;

	public bool pgLoop;

	public int currentMurderer;

	public int currentVictim;

	public int currentActiveCase;

	public string murderPreset;

	public string chosenMO;

	public List<int> previousMurderers;

	public float pauseBetweenMurders;

	public float pauseForKidnapperKill;

	public bool murderRoutineActive;

	public int maxMurderDiffLevel;

	public int currentVictimSite;

	public bool victimSiteIsStreet;

	public bool triggerCoverUpCall;

	public bool playerAcceptedCoverUp;

	public bool triggerCoverUpSuccess;

	public List<MurderController.Murder> murders;

	public List<MurderController.Murder> iaMurders;

	public List<EvidenceStateSave> evidence;

	public List<string> timeEvidence;

	public List<string> dateEvidence;

	public List<string> customStrings;

	public List<SpatterSimulation> spatter;

	public List<CitySaveData.FurnitureClusterObjectCitySave> furnitureStorage;

	public List<AirDuctExplorationSave> airDuctExploration;

	public bool freeHealthCareFlag;

	public int notTheAnswerFlag;

	public int privateSlyFlag;

	public List<string> allConnectedReference;

	public bool pacifistFlag;

	public bool notAScratchFlag;

	public List<int> spareNoOneReference;

	public SnailController.SnailSaveData snail;

	public List<FloorStateSave> floors;

	public List<AddressStateSave> addresses;

	public List<GuestPassStateSave> guestPasses;

	public List<RoomStateSave> rooms;

	public List<MetaObject> metas;

	public List<Interactable> interactables;

	public List<int> removedCityData;

	public List<CitizenStateSave> citizens;

	public List<DoorStateSave> doors;
}
