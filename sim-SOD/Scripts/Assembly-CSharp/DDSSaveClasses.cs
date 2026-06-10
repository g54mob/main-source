using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DDSSaveClasses
{
	public enum TreeTriggers
	{
		awake = 0,
		dead = 1,
		asleep = 2,
		unconscious = 3,
		noReactionState = 4,
		investigating = 5,
		investigatingVisual = 6,
		investigatingSound = 7,
		persuing = 8,
		searching = 9,
		notInCombat = 10,
		inCombat = 11,
		legal = 12,
		illegal = 13,
		travelling = 14,
		sat = 15,
		employee = 16,
		nonEmployee = 17,
		carrying = 18,
		notCarrying = 19,
		privateLocation = 20,
		publicLocation = 21,
		onStreet = 22,
		atHome = 23,
		atWork = 24,
		lightOnAny = 25,
		lightOnMain = 26,
		allLightsOff = 27,
		rain = 28,
		indoors = 29,
		brokenSign = 30,
		travellingToWork = 31,
		notPresent = 32,
		atEatery = 33,
		hasJob = 34,
		unemployed = 35,
		homeIntenseWallpaper = 36,
		homeBrightSign = 37,
		enforcerOnDuty = 38,
		notEnforcerOnDuty = 39,
		trespassing = 40,
		locationOfAuthority = 41,
		drunk = 42,
		restrained = 43,
		sober = 44,
		hasRoomAtHotel = 45,
		hotelPaymentDue = 46,
		hasNoRoomAtHotel = 47,
		single = 48,
		notSingle = 49
	}

	public enum RepeatSetting
	{
		oneHour = 0,
		sixHours = 1,
		twelveHours = 2,
		oneDay = 3,
		twoDays = 4,
		threeDays = 5,
		oneWeek = 6,
		never = 7,
		noLimit = 8
	}

	public enum TriggerPoint
	{
		onNewTrackTarget = 0,
		onNewAction = 1,
		whileTickOnTrackTarget = 2,
		vmail = 3,
		telephone = 4,
		never = 5,
		newspaperArticle = 6,
		onGameStart = 7
	}

	public enum TraitConditionType
	{
		IfAnyOfThese = 0,
		IfAllOfThese = 1,
		IfNoneOfThese = 2,
		otherAnyOfThese = 3,
		otherAllOfThese = 4,
		otherNoneOfThese = 5
	}

	[Serializable]
	public class DDSComponent
	{
		public string name;

		public string id;
	}

	[Serializable]
	public class DDSBlockSave : DDSComponent
	{
		public List<DDSReplacement> replacements;

		public DDSReplacement AddReplacement()
		{
			return null;
		}
	}

	[Serializable]
	public class DDSReplacement
	{
		public string replaceWithID;

		public bool useConnection;

		public Acquaintance.ConnectionType connection;

		public bool useDislikeLike;

		public float strangerKnown;

		public float dislikeLike;

		public bool useTraits;

		public TraitConditionType traitCondition;

		public List<string> traits;
	}

	[Serializable]
	public class DDSMessageSave : DDSComponent
	{
		public List<DDSBlockCondition> blocks;

		public float baseSuccessChance;

		public List<DDSInteractionEvent> events;

		public void AddBlock(string newBlockID)
		{
		}

		public void RemoveBlock(string instID)
		{
		}
	}

	[Serializable]
	public class DDSBlockCondition
	{
		public string blockID;

		public string instanceID;

		public bool alwaysDisplay;

		public int group;

		public bool useTraits;

		public TraitConditionType traitConditions;

		public List<string> traits;
	}

	public enum TreeType
	{
		conversation = 0,
		vmail = 1,
		document = 2,
		newspaper = 3,
		misc = 4,
		interactionDialog = 5
	}

	[Serializable]
	public class DDSTreeSave : DDSComponent
	{
		public DDSParticipant participantA;

		public DDSParticipant participantB;

		public DDSParticipant participantC;

		public DDSParticipant participantD;

		public RepeatSetting repeat;

		public TriggerPoint triggerPoint;

		public List<DDSMessageSettings> messages;

		public bool stopMovement;

		public bool ignoreGlobalRepeat;

		public TreeType treeType;

		public DDSDocument document;

		public string startingMessage;

		public float treeChance;

		public int priority;

		public int newspaperCategory;

		public int newspaperContext;

		public int interactionCitizenLimitation;

		public List<string> itemPool;

		public bool interactionOnePerCity;

		[NonSerialized]
		public Dictionary<string, DDSMessageSettings> messageRef;

		[NonSerialized]
		public int citizenAddCount;

		public string AddMessage(string newMsgID)
		{
			return null;
		}

		public void RemoveMessage(string instID)
		{
		}

		public string AddElement(string elementName)
		{
			return null;
		}
	}

	[Serializable]
	public class DDSDocument
	{
		public string background;

		public Image.Type fill;

		public Vector2 size;

		public Color colour;
	}

	public enum ElementType
	{
		messageText = 0,
		special = 1
	}

	[Serializable]
	public class DDSMessageSettings
	{
		public string msgID;

		public string elementName;

		public string instanceID;

		public int saidBy;

		public int saidTo;

		public Vector2 pos;

		public Vector2 size;

		public float rot;

		public string font;

		public Color col;

		public float fontSize;

		public float charSpace;

		public float wordSpace;

		public float lineSpace;

		public float paraSpace;

		public int alignH;

		public int alignV;

		public int fontStyle;

		public int order;

		public bool usePages;

		public bool isHandwriting;

		public List<DDSMessageLink> links;
	}

	[Serializable]
	public class DDSMessageLink
	{
		public string from;

		public string to;

		public Vector2 delayInterval;

		public bool useWeights;

		public float choiceWeight;

		public bool useKnowLike;

		public float know;

		public float like;

		public bool isDialogSuccess;

		public bool secondaryBranchTrigger;

		public float dialogSuccessModifier;

		public bool useTraits;

		public List<string> traits;

		public TraitConditionType traitConditions;
	}

	[Serializable]
	public class DDSParticipant
	{
		public bool required;

		public Acquaintance.ConnectionType connection;

		public bool useJobs;

		public bool disableInbox;

		public List<string> jobs;

		public bool useTraits;

		public List<string> traits;

		public TraitConditionType traitConditions;

		public List<TreeTriggers> triggers;
	}

	[Serializable]
	public class DDSInteractionEvent
	{
		public InteractionEvent on;

		public string param;
	}

	public enum InteractionEvent
	{
		none = 0,
		isInteractionDialog = 1,
		generateNewItemFromPool = 2,
		findWorldItemFromPool = 3,
		giveMoney = 4,
		testHasItem = 5,
		testHasItemSameType = 6,
		testHasItemSameTypeAndOwner = 7,
		testHasItemSameTypeAndOwnerStat = 8,
		clearItem = 9,
		deleteItem = 10,
		clearAllAddedDialogOptions = 11,
		postNewspaperAd = 12,
		generateNewItem = 13,
		moveItemToInventory = 14,
		moveItem = 15,
		setItem = 16,
		postJobNote = 17,
		goTo = 18,
		setNourishment = 19,
		setHydration = 20,
		setAlertness = 21,
		setEnergy = 22,
		setExcitement = 23,
		setChores = 24,
		setHygeine = 25,
		setBladder = 26,
		setHeat = 27,
		setDrunk = 28,
		setPoisoned = 29,
		setHealth = 30
	}
}
