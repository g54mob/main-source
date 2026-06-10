using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Human : Actor, IComparable<Human>
{
	public enum ShoeType
	{
		normal = 0,
		boots = 1,
		heel = 2,
		barefoot = 3
	}

	public enum MovementSpeed
	{
		stopped = 0,
		walking = 1,
		running = 2
	}

	public enum Gender
	{
		male = 0,
		female = 1,
		nonBinary = 2
	}

	public enum BloodType
	{
		unassigned = 0,
		Apos = 1,
		Aneg = 2,
		Bpos = 3,
		Bneg = 4,
		Opos = 5,
		Oneg = 6,
		ABpos = 7,
		ABneg = 8
	}

	[Serializable]
	public class Trait
	{
		public string name;

		public int traitID;

		public CharacterTrait trait;

		public Trait reason;

		public string date;
	}

	[Serializable]
	public class WeightedTrait
	{
		public CharacterTrait trait;

		public float traitValue;
	}

	[Serializable]
	public class Sighting
	{
		public float time;

		public Vector3 node;

		public bool mov;

		public Vector3 dest;

		public bool run;

		public int exp;

		public bool drunk;

		public bool phone;

		public bool poi;

		public int sound;
	}

	[Serializable]
	public class ConversationInstance
	{
		[Tooltip("True if active")]
		public bool active;

		public NewRoom room;

		[NonSerialized]
		public DDSSaveClasses.DDSTreeSave tree;

		public Human participantA;

		public Human participantB;

		public Human participantC;

		public Human participantD;

		[Space(7f)]
		public Human previouslyTalking;

		public Human currentlyTalking;

		public Human currentlyTalkingTo;

		public bool speechTriggered;

		[NonSerialized]
		public DDSSaveClasses.DDSMessageSettings currentMessage;

		[NonSerialized]
		public DDSSaveClasses.DDSMessageLink currentLink;

		public float linkDelay;

		[Header("Debug")]
		public float timeUntilNextSpeech;

		public int currentlyTalkingSpeechQueue;

		public string treeName;

		public void EndConversation()
		{
		}

		public void SetCurrentMessage(string instanceID)
		{
		}
	}

	[Serializable]
	public class InteractionDialogInstance
	{
		public enum EventsTestResult
		{
			fail = 0,
			success = 1,
			wait = 2
		}

		[Serializable]
		public class Branch
		{
			public string msgInstanceID;

			public List<int> completedEventIndexes;

			[NonSerialized]
			public InteractionDialogInstance inst;

			public Branch(InteractionDialogInstance dialogInstance)
			{
			}

			public DDSSaveClasses.DDSMessageSettings GetMessageInstance()
			{
				return null;
			}

			public DDSSaveClasses.DDSMessageSave GetMessage()
			{
				return null;
			}

			public void NewInteractionInstanceMessage(string newMsgInstanceID, Human human)
			{
			}
		}

		public string id;

		public string treeID;

		public string pickedItem;

		public int pickedWorldItemID;

		public Branch mainBranch;

		public List<Branch> secondaryBranches;

		public List<NewspaperController.InteractionDialogFeature> newspaperFeatures;

		[NonSerialized]
		public DDSSaveClasses.DDSTreeSave tree;

		[NonSerialized]
		public List<EvidenceWitness.DialogOption> generatedDialogOptions;

		public InteractionDialogInstance(DDSSaveClasses.DDSTreeSave newTree)
		{
		}

		public void OnLoad(Human human)
		{
		}

		public DDSSaveClasses.DDSTreeSave GetTree()
		{
			return null;
		}

		public Interactable GetItem()
		{
			return null;
		}
	}

	public class DDSRank
	{
		public string id;

		public DDSSaveClasses.DDSMessageLink linkRef;

		public float rankRef;
	}

	public class SpeechHistory
	{
		public float timeStamp;

		public List<Human> participants;
	}

	public enum DisposalType
	{
		anywhere = 0,
		homeOnly = 1,
		workOnly = 2,
		homeOrWork = 3
	}

	[Serializable]
	public class Wound
	{
		public int humanID;

		public Interactable interactable;

		public CitizenOutfitController.CharacterAnchor anchor;

		public float timestamp;

		public int bloodPoolID;

		public float bloodPoolAmount;

		[NonSerialized]
		public Human human;

		[NonSerialized]
		public Interactable bloodPool;

		public void Load()
		{
		}

		public void ProcessBloodPoolForWound()
		{
		}
	}

	[Serializable]
	public class Death
	{
		public enum ReportType
		{
			visual = 0,
			smell = 1,
			audio = 2
		}

		[Header("Death")]
		public bool isDead;

		public Vector3 location;

		public float time;

		public Vector2 timeOfDeathRange;

		public int weapon;

		public int murder;

		public int victim;

		public int killer;

		public int discoveredBy;

		public float discoveredAt;

		public bool reported;

		public ReportType reportType;

		public float smell;

		public Death(Human newVictim, MurderController.Murder newMurder, Human newKiller, Interactable newWeapon)
		{
		}

		public void UpdateDeathLocation(NewNode newNode)
		{
		}

		public void SetReported(Human newFoundBy, ReportType newReportType)
		{
		}

		public Human GetVictim()
		{
			return null;
		}

		public Human GetKiller()
		{
			return null;
		}

		public Human GetDiscoverer()
		{
			return null;
		}

		public EvidenceTime GetTimeOfDeathEvidence()
		{
			return null;
		}

		public NewGameLocation GetDeathLocation()
		{
			return null;
		}

		public MurderController.Murder GetMurder()
		{
			return null;
		}
	}

	[Serializable]
	public class WalletItem
	{
		public WalletItemType itemType;

		public int meta;

		public int money;
	}

	public enum WalletItemType
	{
		nothing = 0,
		money = 1,
		evidence = 2,
		key = 3
	}

	public struct BookChoice
	{
		public BookPreset p;

		public float rank;
	}

	public enum NoteObject
	{
		note = 0,
		letter = 1,
		travelReceipt = 2,
		vmailLetter = 3
	}

	[Header("ID")]
	public int humanID;

	[NonSerialized]
	public static int assignID;

	[NonSerialized]
	public static int assignTraitID;

	[NonSerialized]
	public string seed;

	[Header("Current Variables")]
	public ShoeType footwear;

	[NonSerialized]
	public AudioEvent footstepEvent;

	public float footstepDirt;

	public float footstepBlood;

	public Transform leftFoot;

	public Transform rightFoot;

	public bool removedFromWorld;

	[Header("Human Attributes")]
	public NewAddress home;

	[NonSerialized]
	public ResidenceController residence;

	public NewAddress den;

	[Header("Modifier Flags")]
	public bool scaredOfRats;

	public bool likesRats;

	public bool dislikesRats;

	public bool hatesRats;

	[Header("Movement")]
	[Tooltip("Used for variation of the base values")]
	public float speedMultiplier;

	[Tooltip("Calculated walking speed")]
	public float movementWalkSpeed;

	[Tooltip("Calculated running speed")]
	public float movementRunSpeed;

	[NonSerialized]
	[Tooltip("The calculated walking speed ratio")]
	public float walkingSpeedRatio;

	[Space(5f)]
	[Tooltip("Speed as a ratio of maximum (0 - 1)")]
	public float currentNormalizedSpeed;

	[Tooltip("The desired movement speed")]
	public float desiredNormalizedSpeed;

	[Tooltip("The actual movement speed")]
	public float currentMovementSpeed;

	[Tooltip("Recovery rate")]
	public float breathRecoveryRate;

	public Transform currentVehicle;

	[Header("Job")]
	public Occupation job;

	public Company director;

	[ReadOnly]
	public float societalClass;

	[Header("Personal Data")]
	public Descriptors descriptors;

	public CitizenOutfitController outfitController;

	public HandwritingPreset handwriting;

	[ReadOnly]
	public string birthday;

	[Space(7f)]
	public string citizenName;

	[NonSerialized]
	public string firstName;

	[NonSerialized]
	public string casualName;

	[NonSerialized]
	public string surName;

	[NonSerialized]
	[Space(7f)]
	public float genderScale;

	public Gender gender;

	public Gender birthGender;

	[Space(7f)]
	[Tooltip("How often this person uses the below slang terms")]
	public float slangUsage;

	[Space(7f)]
	public float sexuality;

	public float homosexuality;

	[NonSerialized]
	public List<Gender> attractedTo;

	[Space(7f)]
	public Citizen partner;

	public string anniversary;

	public Citizen paramour;

	[NonSerialized]
	[Space(7f)]
	public int fingerprintLoop;

	public BloodType bloodType;

	[NonSerialized]
	[Space(7f)]
	public int favColourIndex;

	[Header("Human Traits & Personality")]
	[ProgressBar("Humility", 1f, EColor.Blue)]
	public float humility;

	[ProgressBar("Emotionality", 1f, EColor.Blue)]
	public float emotionality;

	[ProgressBar("Extraversion", 1f, EColor.Blue)]
	public float extraversion;

	[ProgressBar("Agreeableness", 1f, EColor.Blue)]
	public float agreeableness;

	[ProgressBar("Conscientiousness", 1f, EColor.Blue)]
	public float conscientiousness;

	[ProgressBar("Creativity", 1f, EColor.Blue)]
	public float creativity;

	[NonSerialized]
	public float sleepNeedMultiplier;

	[NonSerialized]
	public float snoring;

	[NonSerialized]
	public float snoreDelay;

	[NonSerialized]
	[Space(7f)]
	public Vector2 limitHumility;

	[NonSerialized]
	public Vector2 limitEmotionality;

	[NonSerialized]
	public Vector2 limitExtraversion;

	[NonSerialized]
	public Vector2 limitAgreeableness;

	[NonSerialized]
	public Vector2 limitConscientiousness;

	[NonSerialized]
	public Vector2 limitCreativity;

	public List<Trait> characterTraits;

	public List<WeightedTrait> aggressiveTraits;

	public List<WeightedTrait> peacefulTraits;

	public List<WeightedTrait> fearfulTraits;

	[Header("Groups")]
	public List<GroupsController.SocialGroup> groups;

	[Header("Status Stats")]
	public float nourishment;

	public float hydration;

	public float alertness;

	public float energy;

	[ProgressBar("Excitement", 1f, EColor.Yellow)]
	public float excitement;

	[ProgressBar("Chores", 1f, EColor.Yellow)]
	public float chores;

	[ProgressBar("Hygiene", 1f, EColor.Yellow)]
	public float hygiene;

	[ProgressBar("Bladder", 1f, EColor.Yellow)]
	public float bladder;

	[ProgressBar("Breath", 1f, EColor.Yellow)]
	public float breath;

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

	public Human poisoner;

	public GameObject CorpseCollisionCorrection;

	[NonSerialized]
	[Header("Acquaintances")]
	public List<Acquaintance> acquaintances;

	[Header("Vocab")]
	public Dictionary<DDSSaveClasses.TriggerPoint, List<DDSSaveClasses.DDSTreeSave>> dds;

	public List<InteractionDialogInstance> interactionEvents;

	private bool interactionEventsTestingRecursionProtect;

	[NonSerialized]
	public ConversationInstance currentConversation;

	public float nextCasualSpeechValidAt;

	public Dictionary<Human, Sighting> lastSightings;

	public int sightingMemoryLimit;

	private MovementSpeed lastMovementSpeed;

	private Dictionary<DDSSaveClasses.DDSTreeSave, List<SpeechHistory>> speechHistory;

	[NonSerialized]
	public List<StateSaveData.MessageThreadSave> messageThreadsStarted;

	[NonSerialized]
	public List<StateSaveData.MessageThreadSave> messageThreadFeatures;

	[NonSerialized]
	public List<StateSaveData.MessageThreadSave> messageThreadCCd;

	[NonSerialized]
	[Header("Possessions")]
	public Evidence addressBook;

	[NonSerialized]
	public bool setupAddressBook;

	[NonSerialized]
	public Evidence workID;

	[NonSerialized]
	public List<Interactable> birthdayCards;

	public List<InteractablePreset> currentConsumables;

	public List<int> trash;

	public int anywhereTrash;

	public Death death;

	public List<Wound> currentWounds;

	public List<WalletItem> walletItems;

	public Dictionary<string, Fact> factDictionary;

	[Header("Personal Affects")]
	public List<InteractablePreset> personalAffects;

	public List<InteractablePreset> workAffects;

	[NonSerialized]
	public Interactable workPosition;

	[NonSerialized]
	public Interactable sleepPosition;

	private int preferredBookCount;

	public List<BookPreset> library;

	public List<BookPreset> nonShelfBooks;

	[NonSerialized]
	public int booksAwayFromShelf;

	public Dictionary<RetailItemPreset, int> itemRanking;

	public Dictionary<CompanyPreset.CompanyCategory, NewAddress> favouritePlaces;

	public Dictionary<RetailItemPreset, float> recentPurchases;

	[Header("Passwords")]
	public GameplayController.Passcode passcode;

	public CharacterTrait passwordTrait;

	[Header("Simulated Behaviour")]
	private List<float> simulatedPreviousBehaviour;

	[Header("Misc")]
	public Vector2 lastUsedCCTVScreenPoint;

	public bool updateMeshList;

	[Header("Debug")]
	public ConversationInstance debugConversation;

	public float debugLastChangedNodeAt;

	public float debugLastAITick;

	public void SetJob(Occupation newJob)
	{
	}

	public void SetPlayerGender()
	{
	}

	public void SetSexualityAndGender()
	{
	}

	private void SetBirthGender()
	{
	}

	public void GenerateSuitableGenderAndSexualityForParnter(Citizen newPartner)
	{
	}

	public void SetPersonality()
	{
	}

	private void SetupPotentialModifierFlagsByTraits()
	{
	}

	private float GetTraitChance(CharacterTrait trait)
	{
		return 0f;
	}

	public bool TraitExists(CharacterTrait searchTrait)
	{
		return false;
	}

	public float GetChance(ref List<CharacterTrait.TraitPickRule> pickRules, float baseChance)
	{
		return 0f;
	}

	public Trait AddCharacterTrait(CharacterTrait newTrait)
	{
		return null;
	}

	public void SetPartner(Citizen newLover)
	{
	}

	public virtual void SetResidence(ResidenceController newHome, bool removePreviousResidence = true)
	{
	}

	public virtual void SetDen(NewAddress newAddress, MurderMO decorateUsingRules = null)
	{
	}

	public void UpdateTickRateOnProx()
	{
	}

	public void SetupGeneral()
	{
	}

	private void GenerateBloodType()
	{
	}

	public string GetBloodTypeString()
	{
		return null;
	}

	public void GenerateSlang()
	{
	}

	public void SetPhysicalModelParams()
	{
	}

	public override void CreateEvidence()
	{
	}

	public void CreateDetails()
	{
	}

	public void CalculateAge()
	{
	}

	public int GetAge()
	{
		return 0;
	}

	public Descriptors.Age GetAgeGroup()
	{
		return default(Descriptors.Age);
	}

	public void PickPassword()
	{
	}

	public virtual void PrepForStart()
	{
	}

	public void GenerateVocab()
	{
	}

	public virtual void AddDDSVocab(DDSSaveClasses.DDSTreeSave newTree)
	{
	}

	public void GeneratePastVmails()
	{
	}

	public void GenerateDDSInteractionDialog()
	{
	}

	public void TestInteractionInstances(EvidenceWitness.DialogOption justSpokeDialogOption = null)
	{
	}

	private InteractionDialogInstance.Branch StartSecondaryBranch(InteractionDialogInstance inst, DDSSaveClasses.DDSMessageLink link)
	{
		return null;
	}

	private InteractionDialogInstance.EventsTestResult ExecuteAndTestCurrentInteractionEvent(InteractionDialogInstance.Branch branch, out bool usedJustSpoken, EvidenceWitness.DialogOption justSpokeDialogOption = null)
	{
		usedJustSpoken = default(bool);
		return default(InteractionDialogInstance.EventsTestResult);
	}

	public void SetupInteractables()
	{
	}

	public void Load(CitySaveData.HumanCitySave data)
	{
	}

	public void LoadAcquaintances(CitySaveData.HumanCitySave data)
	{
	}

	public void LoadFavourites(CitySaveData.HumanCitySave data)
	{
	}

	public void GenerateRoutineGoals()
	{
	}

	public bool TraitGoalTest(AIGoalPreset goalPreset, out float priorityMultiplier)
	{
		priorityMultiplier = default(float);
		return false;
	}

	public override void SetVisible(bool vis, bool force = false)
	{
	}

	public override void OnGameLocationChange(bool enableSocialSightings = true, bool forceDisableLocationMemory = false)
	{
	}

	public override void OnRoomChange()
	{
	}

	public override void OnNodeChange()
	{
	}

	public override bool IsTrespassing(NewRoom room, out int trespassEscalation, bool enforcersAllowedEverywhere = true)
	{
		trespassEscalation = default(int);
		return false;
	}

	public void CreateAcquaintances()
	{
	}

	public bool FindAcquaintanceExists(Human findC, out Acquaintance returnAcq)
	{
		returnAcq = null;
		return false;
	}

	public void AddAcquaintance(Human addC, float known, Acquaintance.ConnectionType newConnection, bool addInverse = true, bool secretConnection = false, Acquaintance.ConnectionType newSecretConnection = Acquaintance.ConnectionType.friend, GroupsController.SocialGroup group = null)
	{
	}

	public void AddDetailToDict(string key, Fact det)
	{
	}

	public void Murder(Human killer, bool setTimeOfDeath, MurderController.Murder murder, Interactable weapon, float chanceToScream = 1f)
	{
	}

	public void RemoveFromWorld(bool val)
	{
	}

	public override void GoToSleep()
	{
	}

	public override void WakeUp(bool forceImmediate = false)
	{
	}

	public virtual void AddNourishment(float addVal)
	{
	}

	public virtual void AddHydration(float addVal)
	{
	}

	public virtual void AddAlertness(float addVal)
	{
	}

	public virtual void AddEnergy(float addVal)
	{
	}

	public virtual void AddExcitement(float addVal)
	{
	}

	public virtual void AddChores(float addVal)
	{
	}

	public virtual void AddHygiene(float addVal)
	{
	}

	public void AddBladder(float addVal)
	{
	}

	public void AddBreath(float addVal)
	{
	}

	public virtual void AddHeat(float addVal)
	{
	}

	public virtual void AddDrunk(float addVal)
	{
	}

	public virtual void AddSick(float addVal)
	{
	}

	public virtual void AddHeadache(float addVal)
	{
	}

	public virtual void AddWet(float addVal)
	{
	}

	public virtual void AddBrokenLeg(float addVal)
	{
	}

	public virtual void AddBruised(float addVal)
	{
	}

	public virtual void AddBlackEye(float addVal)
	{
	}

	public virtual void AddBlackedOut(float addVal)
	{
	}

	public virtual void AddNumb(float addVal)
	{
	}

	public virtual void AddPoisoned(float addVal, Human byWho)
	{
	}

	public virtual void AddBleeding(float addVal)
	{
	}

	public virtual void AddBlinded(float addVal)
	{
	}

	public virtual void AddStarchAddiction(float addVal)
	{
	}

	public virtual void AddWellRested(float addVal)
	{
	}

	public virtual void AddSyncDiskInstall(float addVal)
	{
	}

	public void SetAsDirector(Company newComp)
	{
	}

	public virtual void SetFootwear(ShoeType newType)
	{
	}

	public void OnFootstep(bool isRight)
	{
	}

	public void AddPersonalAffect(InteractablePreset interactable, bool isWork = false)
	{
	}

	public void RemovePersonalAffect(InteractablePreset interactable, bool isWork = false)
	{
	}

	public NewNode FindSafeTeleport(NewGameLocation gameLoc, bool prioritiseWindows = false, bool allowTrespass = true)
	{
		return null;
	}

	public NewNode FindSafeTeleport(NewRoom room, bool prioritiseWindows = false)
	{
		return null;
	}

	public NewNode FindSafeTeleport(NewRoom room, out float bestScore, bool prioritiseWindows = false)
	{
		bestScore = default(float);
		return null;
	}

	public void GenerateItemFavs()
	{
	}

	public void SpawnInventoryItems()
	{
	}

	public bool WeaponTraitTest(Citizen cit, ref List<MurderPreset.MurdererModifierRule> rules, out float output)
	{
		output = default(float);
		return false;
	}

	public void PlaceFavouriteItems()
	{
	}

	public float GetSimulatedTimeRange(NewGameLocation where, float maxTimeAgo)
	{
		return 0f;
	}

	public Interactable WriteNote(NoteObject newPresetType, string treeID, Human reciever, NewGameLocation placement, int security = 0, InteractablePreset.OwnedPlacementRule ownershipPlacement = InteractablePreset.OwnedPlacementRule.both, int priority = 1, HashSet<NewRoom> dontPlaceInRooms = null, bool printDebug = false, int toneFriendly = 0, int toneFormal = 0, string loadGUID = null)
	{
		return null;
	}

	public Interactable WriteNote(List<NoteObject> newPresetType, string treeID, Human reciever, NewGameLocation placement, int security = 0, InteractablePreset.OwnedPlacementRule ownershipPlacement = InteractablePreset.OwnedPlacementRule.both, int priority = 1, HashSet<NewRoom> dontPlaceInRooms = null, bool printDebug = false, int toneFriendly = 0, int toneFormal = 0, string loadGUID = null)
	{
		return null;
	}

	public CitySaveData.HumanCitySave GenerateSaveData()
	{
		return null;
	}

	public int CompareTo(Human comp)
	{
		return 0;
	}

	public void SpeechTriggerPoint(DDSSaveClasses.TriggerPoint triggerPoint, Actor trackedTarget, AIActionPreset onAction = null)
	{
	}

	public bool DDSParticipantConditionCheck(Human initiator, DDSSaveClasses.DDSParticipant conditions, DDSSaveClasses.TreeType treeType)
	{
		return false;
	}

	public void ExecuteConversationTree(DDSSaveClasses.DDSTreeSave newTree, List<Human> otherParticipants)
	{
	}

	public virtual void SetInConversation(ConversationInstance newInstance, bool endCall = true)
	{
	}

	public List<string> ParseDDSMessage(DDSSaveClasses.DDSMessageSettings settings, Acquaintance aq, object passedObject = null)
	{
		return null;
	}

	public List<string> ParseDDSMessage(string msgID, Acquaintance aq, out List<int> outputDisplayGroups, bool forceRealRandom = false, object passedObject = null, bool debug = false)
	{
		outputDisplayGroups = null;
		return null;
	}

	public virtual void SetDesiredSpeed(float newSpeedRatio)
	{
	}

	public virtual void SetDesiredSpeed(MovementSpeed newMovement)
	{
	}

	public virtual void UpdateMovementSpeed()
	{
	}

	public virtual void SetBed(Interactable passSpecificInteractable)
	{
	}

	public virtual void SetWorkFurniture(Interactable passSpecificInteractable)
	{
	}

	public virtual void UpdateConversation()
	{
	}

	public List<DDSRank> GetConversationTreeLinkRankings(DDSSaveClasses.DDSMessageSettings thisMsg, ref List<DDSSaveClasses.DDSMessageLink> links)
	{
		return null;
	}

	public void AddCurrentConsumable(InteractablePreset newPreset)
	{
	}

	public void RemoveCurrentConsumable(InteractablePreset newPreset)
	{
	}

	public void AddTrash(InteractablePreset trashItem, Human writer, List<Interactable.Passed> passedVars = null)
	{
	}

	public InteractablePreset PickConsumable(ref Dictionary<InteractablePreset, int> prices, out int price, List<InteractablePreset> ignore = null)
	{
		price = default(int);
		return null;
	}

	public Human GetDoctor()
	{
		return null;
	}

	public Human GetLandlord()
	{
		return null;
	}

	public virtual void AddMeshes(List<MeshRenderer> renderers, bool addToOutline = true, bool forceMeshListUpdate = false)
	{
	}

	public virtual void AddMesh(GameObject newObject, bool addToOutline = true, bool forceMeshListUpdate = false)
	{
	}

	public virtual void AddMesh(MeshRenderer newMesh, bool addToOutline = true, bool forceMeshListUpdate = false, bool addToLOD1 = false, bool addToBoth = false)
	{
	}

	public virtual void RemoveMesh(MeshRenderer newMesh, bool removeFromOutline = true, bool forceMeshListUpdate = false)
	{
	}

	public virtual void UpdateMeshList()
	{
	}

	public override void AddNerve(float amount, Actor scaredBy = null)
	{
	}

	public void UpdateLODs()
	{
	}

	public int GetHexacoScore(ref HEXACO hex)
	{
		return 0;
	}

	public void WalletItemCheck(int maxNewItems, bool dailyReplenish)
	{
	}

	public void UpdateLastSighting(Human citizen, bool phoneCall = false, int isSound = 0)
	{
	}

	public Vector2 GetSightingDirection(Sighting sighting, out NewGameLocation newDestination)
	{
		newDestination = null;
		return default(Vector2);
	}

	public void RevealSighting(Human prospectCitizen, bool allowCalls, bool allowSounds, SpeechController sc, bool allowGeneralClue = true)
	{
	}

	public void RevealSighting(Human prospectCitizen, Sighting sighting, SpeechController sc)
	{
	}

	public Vector3 GetNearestVert(Vector3 worldPosition, out CitizenOutfitController.CharacterAnchor nearestBodyPart)
	{
		nearestBodyPart = default(CitizenOutfitController.CharacterAnchor);
		return default(Vector3);
	}

	public string GetCitizenName()
	{
		return null;
	}

	public string GetFirstName()
	{
		return null;
	}

	public string GetCasualName()
	{
		return null;
	}

	public string GetSurName()
	{
		return null;
	}

	public string GetInitialledName()
	{
		return null;
	}

	public string GetInitials()
	{
		return null;
	}

	public string GetFirstInitial()
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DebugGetAge()
	{
	}

	public bool TryGiveItem(Interactable givenItem, Human givenBy, bool defaultSuccess, bool enableSpeech = true)
	{
		return false;
	}

	public int GetReceiptDifficulty()
	{
		return 0;
	}

	public string GetReceiptDifficultyBaseNameInfo(bool includeLink, out Strings.LinkData nameLink)
	{
		nameLink = null;
		return null;
	}

	public virtual void SetVehicle(Transform newVehicle)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void RemoveFromGameWorld()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void TeleportChosenInteractionWorldItemsToPlayer()
	{
	}
}
