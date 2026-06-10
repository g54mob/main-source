using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "aiaction_data", menuName = "Database/AI/AI Action")]
public class AIActionPreset : SoCustomComparison
{
	public enum ActionLocation
	{
		interactable = 0,
		findNearest = 1,
		investigate = 2,
		nearbyInvestigate = 3,
		pause = 4,
		randomNodeWithinLocation = 5,
		flee = 6,
		interactableLOS = 7,
		meetOther = 8,
		NearbyStreetRandomNode = 9,
		putDownInteractable = 10,
		pickUpInteractable = 11,
		randomNodeWithinHome = 12,
		interactableSpawn = 13,
		proximityToMusic = 14,
		player = 15,
		tailAndConfrontPlayer = 16,
		sniperVantagePoint = 17,
		randomNodeWithinLocationPrioritiseWindows = 18,
		randomNodeWithinDen = 19,
		victimApartmentDoor = 20,
		playerApartmentDoorOutside = 21
	}

	public enum ActionFacingDirection
	{
		towardsDestination = 0,
		awayFromDestination = 1,
		interactable = 2,
		InverseInteractable = 3,
		accessableDirection = 4,
		investigate = 5,
		door = 6,
		interactableSetting = 7,
		none = 8,
		inverseInteractableSetting = 9,
		player = 10,
		sniperVantagePoint = 11,
		victim = 12,
		awayFromSniperVantagePoint = 13
	}

	public enum ActionFinding
	{
		doNothing = 0,
		findNearest = 1,
		removeAction = 2,
		removeGoal = 3
	}

	public enum ActionBusy
	{
		findAlternate = 0,
		skipAction = 1,
		skipGoal = 2,
		standGuard = 3,
		standGuardIfEnforcerSkipGoalNot = 4
	}

	public enum FindSetting
	{
		nonTrespassing = 0,
		onlyPublic = 1,
		allAreas = 2,
		homeOnly = 3,
		workOnly = 4
	}

	[Serializable]
	public class AISpeechPreset
	{
		public string dictionaryString;

		public string ddsMessageID;

		public bool isSuccessful;

		[Range(0f, 10f)]
		public int chance;

		[Tooltip("Use parsing for special items in this string")]
		public bool useParsing;

		public bool shout;

		public bool interupt;

		public bool onlyIfEnfocerOnDuty;

		public bool onlyIfNotEnforcerOnDuty;

		[Tooltip("Must feature ANY of these character traits")]
		public List<CharacterTrait> mustFeatureTrait;

		[Tooltip("Can't feature ANY of these character traits")]
		public List<CharacterTrait> cantFeatureTrait;

		[Tooltip("Must be a killer and feature this motive")]
		public List<MurderMO> mustBeKillerWithMotive;

		[Tooltip("If true this will use the DDS reference from the killer's MO, if there is one. Make sure the dds message in this can be used as a fallback")]
		public bool useMurderMOConfession;

		public List<Evidence.DataKey> tieKeys;

		public List<Evidence.Discovery> applyDiscovery;

		public bool endsDialog;

		public bool jobHandIn;

		public bool startCombat;

		public bool flee;

		public bool giveUpSelf;
	}

	[Serializable]
	public class AutomaticAction
	{
		public AIActionPreset forcedAction;

		public bool proximityCheck;

		public float additionalDelay;
	}

	public enum SourceOfBannedRooms
	{
		none = 0,
		jobPreset = 1
	}

	public enum CombatPose
	{
		noChange = 0,
		always = 1,
		never = 2,
		onlyWhenPreviouslyPersuing = 3,
		onlyWhenAtDestination = 4
	}

	public enum ForcedActionsSearchLevel
	{
		thisObjectOnly = 0,
		otherIntegratedInteractables = 1,
		spawnInteractablesChildren = 2,
		spawnedInteractablesAll = 3,
		InteractablesOnNode = 4
	}

	[Serializable]
	public class CheckActionAgainstState
	{
		public InteractablePreset.Switch switchState;

		public bool switchIs;

		public CheckActionOutcome outcome;
	}

	public enum CheckActionOutcome
	{
		cancelAction = 0,
		cancelGoal = 1
	}

	public enum DoorRule
	{
		normal = 0,
		dontLock = 1,
		dontClose = 2,
		onlyCloseToLocation = 3,
		onlyLockToLocation = 4
	}

	public enum LightRule
	{
		normal = 0,
		dontSwitch = 1,
		onlyWhenArrived = 2
	}

	public enum ActionStateFlag
	{
		onActivation = 0,
		onArrival = 1,
		onDeactivation = 2,
		onGoalDeactivation = 3,
		none = 4
	}

	[Header("Input")]
	public InteractablePreset.InteractionKey defaultKey;

	[Tooltip("Debug this input")]
	public bool debug;

	[Range(-10f, 11f)]
	[Tooltip("Useful when there are multiple active actions, the highest takes priority.")]
	public int inputPriority;

	[Tooltip("Only available when no first person item selected")]
	public bool unavailableWhenItemSelected;

	[Tooltip("If left blank, this is available when any first person item is selected...")]
	[EnableIf("unavailableWhenItemSelected")]
	public List<FirstPersonItem> unavailableWhenItemsSelected;

	[Tooltip("Only available when this first person item selected")]
	public bool onlyAvailableWhenItemSelected;

	[EnableIf("onlyAvailableWhenItemSelected")]
	public List<FirstPersonItem> availableWhenItemsSelected;

	public bool holsterCurrentItemOnAction;

	[Tooltip("Disable display on UI")]
	public bool disableUIDisplay;

	[Tooltip("Interaction is allowed at recognition distance range")]
	public bool allowInteractionAtRecognitionRange;

	[Header("Location")]
	[InfoBox("Use this carefully in conjuction with the goal's location.\nInteractable: Checks for passed interactable, room, then location to find a destination.\nFind Nearest: Finds the nearest.\nInvestigate: Uses investigate position\nNearby Investigate: Uses a destination close to the investigation position\nPause: Uses the AI existing position\nRandom Node Within Location: A random node within the passed gamelocation\nFlee: Destination is somewhere safe\nInteractable LOS: Location within line of sight of the passed interactable\nNearby Random Street Node: Pick somewhere on a close by street.", EInfoBoxType.Normal)]
	public ActionLocation actionLocation;

	[Tooltip("Check this against the room's action reference to continue using the passed reference.")]
	public bool confirmActionLocation;

	[Tooltip("If true then AI will pick a random sublocation if no other use position is specified; if false then it will tend to pick the default (centre) or closest sublocation")]
	public bool useRandomNodeSublocation;

	[Tooltip("If unable to find a node location for this action, attempt to find one using 'nearest' fuction (can be expensive). If this isn't checked then the goal will be removed.")]
	public ActionFinding onUnableToFindLocation;

	[Tooltip("Where to search when finding a location...")]
	public FindSetting searchSetting;

	[Tooltip("If the found use point is busy, do this...")]
	public ActionBusy onUsePointBusy;

	public Interactable.UsePointSlot usageSlot;

	[Tooltip("Consider this at the destination if we're close enough")]
	public bool useCloseEnoughSetting;

	[Tooltip("How much to factor in robbery priority when searching for location...")]
	public float robberyPriorityMultiplier;

	[Tooltip("Avoid choosing repeating interactables as long as this goal exists...")]
	public bool avoidRepeatingInteractables;

	[Tooltip("Aids searching by filtering rooms types that this must be in...")]
	public bool filterSearchUsingRoomType;

	[Tooltip("Aids searching by filtering rooms types that this must be in...")]
	[EnableIf("filterSearchUsingRoomType")]
	public List<RoomTypePreset> searchRoomType;

	[Tooltip("Limit search to the goal's game location")]
	public bool limitSearchToGoalLocation;

	[Tooltip("When finding an action; Always use home as an option (even if above is true)")]
	public bool findOverrideWithHome;

	[Tooltip("Use special availability settings: Address telephone with nobody answering")]
	public bool requiresTelephone;

	[Tooltip("Use special availability settings: Address telephone with no calls active")]
	[ShowIf("requiresTelephone")]
	public bool requiresTelephoneNoCall;

	[Tooltip("Skip activation if there is no consumable to hand")]
	public bool activationRequiresConsumable;

	[Tooltip("Pull banned rooms from here...")]
	public SourceOfBannedRooms bannedRooms;

	[Header("Completion")]
	[Tooltip("If true this action will execute until it is interupted by something else")]
	public bool completableAction;

	[ShowIf("completableAction")]
	[MinMaxSlider(0f, 120f)]
	[Tooltip("Time taken in minutes")]
	public Vector2 minutesTakenRange;

	[Tooltip("Complete when AI has seen player do something illegal")]
	public bool completeOnSeeIllegal;

	[Tooltip("If true, once complete, this action will create another instance of itself, effectively repeating")]
	public bool repeatOnComplete;

	[EnableIf("repeatOnComplete")]
	[Tooltip("Repeat while the citizen has consumable items...")]
	public bool repeatWhileHavingConsumables;

	[Tooltip("AI controller will not be diabled on idle while this action is active if true")]
	public bool requiresForcedUpdate;

	[Tooltip("AI will immediately teleport & complete this action if culled and out of the vicinity")]
	public bool enableImmediateCompletionWhenFarAway;

	[Tooltip("Don't update the priority of other goals (apart from investigate) while this is active")]
	[Header("Update")]
	public bool dontUpdateGoalPriorityWhileActive;

	[DisableIf("dontUpdateGoalPriorityWhileActive")]
	[Tooltip("Don't update the priority of other goals (apart from investigate) for this long after the action has been started (minutes)")]
	public int dontUpdateGoalPriorityFor;

	[Space(5f)]
	[Tooltip("If true the tick rate can be no higher than below while performing this action")]
	public bool limitTickRate;

	[EnableIf("limitTickRate")]
	public NewAIController.AITickRate minimumTickRate;

	[EnableIf("limitTickRate")]
	public NewAIController.AITickRate maximumTickRate;

	[Tooltip("If true, this action won't be removed upon goal's RefreshActions()")]
	public bool dontRemoveOnRefresh;

	[Tooltip("If true, this action won't be replaced upon goal's RefreshActions()")]
	public bool nonRefreshable;

	[Tooltip("Once victim is in LOS, then stop")]
	public bool useLOSCheck;

	[Tooltip("Cancel if target is not a valid mugging")]
	public bool cancelIfNonValidMugging;

	[Tooltip("Cancel if player is not loitering")]
	public bool cancelIfPlayerNotLoitering;

	[Tooltip("Skip creation of this action if the AI is in the following state...")]
	public bool skipIfAIIsInState;

	[EnableIf("skipIfAIIsInState")]
	[Tooltip("Skip creation of this action if the AI is in the following state...")]
	public NewAIController.ReactionState skipIfReaction;

	[Tooltip("Skip if the player has a guest pass to here")]
	public bool skipIfGuestPass;

	[Header("Facing")]
	[Tooltip("Which way will this AI face when arrived at this action")]
	public ActionFacingDirection facing;

	[Tooltip("If true, the AI will look around randomly if they don't have a specific target")]
	public bool lookAround;

	[Tooltip("If the persuit target isn't in range, cancel this action")]
	public bool cancelIfPersuitTargetNotInRange;

	[Tooltip("Face player when interacting")]
	public bool facePlayerWhileTalkingTo;

	[BoxGroup("Idle Animations")]
	public bool changeIdleOnActivate;

	[BoxGroup("Idle Animations")]
	[EnableIf("changeIdleOnActivate")]
	public CitizenAnimationController.IdleAnimationState idleAnimationOnActivate;

	[Space(5f)]
	[BoxGroup("Idle Animations")]
	public bool changeIdleOnArrival;

	[BoxGroup("Idle Animations")]
	[EnableIf("changeIdleOnArrival")]
	public CitizenAnimationController.IdleAnimationState idleAnimationOnArrival;

	[Space(5f)]
	[BoxGroup("Idle Animations")]
	public bool changeIdleOnDeactivate;

	[BoxGroup("Idle Animations")]
	[EnableIf("changeIdleOnDeactivate")]
	public CitizenAnimationController.IdleAnimationState idleAnimationOnDeactivate;

	[Space(5f)]
	[BoxGroup("Idle Animations")]
	public bool changeIdleOnComplete;

	[EnableIf("changeIdleOnComplete")]
	[BoxGroup("Idle Animations")]
	public CitizenAnimationController.IdleAnimationState idleAnimationOnComplete;

	[BoxGroup("Arm Animations")]
	public bool changeArmsOnActivate;

	[EnableIf("changeArmsOnActivate")]
	[BoxGroup("Arm Animations")]
	public CitizenAnimationController.ArmsBoolSate armsAnimationOnActivate;

	[Space(5f)]
	[BoxGroup("Arm Animations")]
	public bool changeArmsOnArrival;

	[BoxGroup("Arm Animations")]
	[EnableIf("changeArmsOnArrival")]
	public CitizenAnimationController.ArmsBoolSate armsAnimationOnArrival;

	[BoxGroup("Arm Animations")]
	[Space(5f)]
	public bool changeArmsOnDeactivate;

	[BoxGroup("Arm Animations")]
	[EnableIf("changeArmsOnDeactivate")]
	public CitizenAnimationController.ArmsBoolSate armsAnimationOnDeactivate;

	[Space(5f)]
	[BoxGroup("Arm Animations")]
	public bool changeArmsOnComplete;

	[BoxGroup("Arm Animations")]
	[EnableIf("changeArmsOnComplete")]
	public CitizenAnimationController.ArmsBoolSate armsAnimationOnComplete;

	[Tooltip("Once destination is reached, tell the AI to lie down")]
	[Space(5f)]
	public bool lying;

	[EnableIf("lying")]
	public bool lyingOnFloor;

	[Tooltip("Pull the below from the currently-held consumable item...")]
	[Header("On Progress Stat modifiers")]
	public bool useCurrentConsumable;

	[EnableIf("completableAction")]
	[Range(-1f, 1f)]
	[Tooltip("This is applied as progress increases")]
	public float progressNourishment;

	[Range(-1f, 1f)]
	[EnableIf("completableAction")]
	[Tooltip("This is applied as progress increases")]
	public float progressHydration;

	[Range(-1f, 1f)]
	[EnableIf("completableAction")]
	[Tooltip("This is applied as progress increases")]
	public float progressAlertness;

	[Range(-1f, 1f)]
	[EnableIf("completableAction")]
	[Tooltip("This is applied as progress increases")]
	public float progressEnergy;

	[Range(-1f, 1f)]
	[EnableIf("completableAction")]
	[Tooltip("This is applied as progress increases")]
	public float progressExcitement;

	[Range(-1f, 1f)]
	[Tooltip("This is applied as progress increases")]
	[EnableIf("completableAction")]
	public float progressChores;

	[Range(-1f, 1f)]
	[EnableIf("completableAction")]
	[Tooltip("This is applied as progress increases")]
	public float progressHygeiene;

	[EnableIf("completableAction")]
	[Range(-1f, 1f)]
	[Tooltip("This is applied as progress increases")]
	public float progressBladder;

	[Tooltip("This is applied as progress increases")]
	[EnableIf("completableAction")]
	[Range(-1f, 1f)]
	public float progressHeat;

	[EnableIf("completableAction")]
	[Tooltip("This is applied as progress increases")]
	[Range(-1f, 1f)]
	public float progressDrunk;

	[Tooltip("This is applied as progress increases")]
	[Range(-1f, 1f)]
	[EnableIf("completableAction")]
	public float progressBreath;

	[Range(-1f, 1f)]
	[EnableIf("completableAction")]
	public float progressPoisoned;

	[Tooltip("This is applied over time")]
	[Range(-12f, 12f)]
	[Header("Per Hour Stat modifiers")]
	public float overtimeNourishment;

	[Tooltip("This is applied over time")]
	[Range(-12f, 12f)]
	public float overtimeHydration;

	[Tooltip("This is applied over time")]
	[Range(-12f, 12f)]
	public float overtimeAlertness;

	[Tooltip("This is applied over time")]
	[Range(-12f, 12f)]
	public float overtimeEnergy;

	[Tooltip("This is applied over time")]
	[Range(-12f, 12f)]
	public float overtimeExcitement;

	[Tooltip("This is applied over time")]
	[Range(-12f, 12f)]
	public float overtimeChores;

	[Range(-12f, 12f)]
	[Tooltip("This is applied over time")]
	public float overtimeHygiene;

	[Range(-12f, 12f)]
	[Tooltip("This is applied over time")]
	public float overtimeBladder;

	[Tooltip("This is applied over time")]
	[Range(-12f, 12f)]
	public float overtimeHeat;

	[Tooltip("This is applied over time")]
	[Range(-12f, 12f)]
	public float overtimeDrunk;

	[Tooltip("This is applied over time")]
	[Range(-12f, 12f)]
	public float overtimeBreath;

	[Tooltip("This is applied over time")]
	[Range(-12f, 12f)]
	public float overtimePoison;

	[Tooltip("If true this will use rules consistent with AI's investigate urgency state. If false and below is false, it will walk...")]
	[Header("Movement")]
	public bool useInvestigationUrgency;

	[DisableIf("useInvestigationUrgency")]
	[Tooltip("If true this will use running only")]
	public bool forceRun;

	[Tooltip("Will run if this citizen can see the player")]
	public bool runIfSeesPlayer;

	[Header("AI")]
	[Tooltip("If true this will encourage using interactable with people I know and discourgage using them with people I don't. If this has a passed human interactable, I will save a space for them.")]
	public bool socialRules;

	[Tooltip("If true, the AI will detect the player as suspicious while this is active")]
	public bool spookAction;

	[Tooltip("Disable sighting updates while this action is active")]
	public bool disableSightingUpdates;

	[Tooltip("Attack the persuit target if they are close enough")]
	public bool attackPersuitTargetOnProximity;

	[Tooltip("Throw current items if at suitable range")]
	[EnableIf("attackPersuitTargetOnProximity")]
	public bool throwObjectsAtTarget;

	[Tooltip("Put the AI in combat pose")]
	public CombatPose useCombatPose;

	[Tooltip("In addition to the above condition, only use combat pose when escalation of investiation is 1")]
	public bool onlyUseCombatPoseWithEscalationOne;

	[Tooltip("Go to sleep OnComplete, wake up on end")]
	public bool sleepOnArrival;

	[Tooltip("This action is uninteruptable after destination has been reached (overrides the goal's interuption preset settings)")]
	public bool uninteruptableWhileAtLocation;

	[Tooltip("While active, Vmail threads can be progressed")]
	public bool progressVmailThreads;

	[Tooltip("If true, will disable casual conversation triggers while this is active")]
	public bool disableConversationTriggers;

	[Tooltip("If true, will cancel any conversations when activated")]
	public bool exitConversationOnActivate;

	[Tooltip("Interactable presets related to this furniture parent must stay swtiched on while this is active...")]
	[Space(5f)]
	public List<InteractablePreset> forcedActive;

	[Tooltip("If AI, force perform these actions on the same object if they exist, if not integrated interactables on the same furniture will also be checked: On Arrival")]
	public List<AutomaticAction> forcedActionsOnArrival;

	[Tooltip("If AI, force perform these actions on the same object if they exist, if not integrated interactables on the same furniture will also be checked: On End")]
	public List<AutomaticAction> forcedActionsOnComplete;

	[Tooltip("To complete the above actions, if AI cannot find the appropriate action on the immediate interactable, search this much...")]
	public ForcedActionsSearchLevel forcedActionsSearchLevel;

	[Tooltip("Also execute the above actions if action is ended for any reason")]
	public bool executeCompleteActionsOnEnd;

	[EnableIf("executeCompleteActionsOnEnd")]
	[Tooltip("Only do the above if at location")]
	public bool executeCompleteActionsOnEndIfArrived;

	[Tooltip("Automatically execute this action on complete (action controller script)")]
	public bool executeThisOnComplete;

	[Tooltip("Execute these switch state changes on end along with the above actions...")]
	public List<InteractablePreset.SwitchState> switchStatesOnEnd;

	[Tooltip("This action will trigger an interactable being illegally activated if a character tresspassing triggers it")]
	public bool tamperAction;

	[Tooltip("This action will close/deactivate an illegally activated object (eg. turn off tv)")]
	public bool tamperResetAction;

	[EnableIf("canFallAsleep")]
	[Tooltip("If above is true then citizens can fall asleep after this time")]
	public int fallAsleepAfterMinimum;

	[Tooltip("Special case: If this is the sniper killer, allow a sniper shot while this action is active")]
	public bool allowSniperShot;

	[Space(7f)]
	[Tooltip("On tick, check state of chosen interactable. If any of these match then cancel this action.")]
	public List<CheckActionAgainstState> checkActionAgainstState;

	[Space(5f)]
	[Tooltip("Enable to force a reaction state once this action is activated. Will not switch it back once ended.")]
	public bool forceReactionState;

	[EnableIf("forceReactionState")]
	public NewAIController.ReactionState setReactionState;

	[Tooltip("Ignore door keys settings")]
	public bool ignoreLockedDoors;

	[Tooltip("Break down doors in my way!")]
	public bool breakDownDoors;

	[Header("Allowable Action Insertions")]
	public bool doorsAllowed;

	public bool deactivateAllowed;

	[Header("Delay")]
	[Tooltip("If use point is busy, delay goal from repeating for this time...")]
	public float repeatDelayOnActionFail;

	[Tooltip("If interupted by a more important goal, delay goal from repeating for this time...")]
	public float repeatDelayOnActionSuccess;

	[Tooltip("When at the gamelocation, turn all lights off, excluding the destination room.")]
	[Header("Basic Actions")]
	public bool turnAllGamelocationLightsOff;

	public bool overrideGoalLightRule;

	[EnableIf("overrideGoalLightRule")]
	public bool onlyOverrideIfAtGamelocation;

	[EnableIf("overrideGoalLightRule")]
	public List<RoomConfiguration.AILightingBehaviour> lightingBehaviour;

	public bool overrideGoalDoorRule;

	[EnableIf("overrideGoalDoorRule")]
	[Tooltip("Execute the closing of doors as below:")]
	public DoorRule doorRule;

	[Tooltip("Spawn a player taunt at the successful competion of this action")]
	public bool spawnTauntOnSuccess;

	[InfoBox("Note: This is only triggered by AI", EInfoBoxType.Normal)]
	[Header("Sounds")]
	public AudioEvent onArrivalSound;

	public bool isLoop;

	[DisableIf("isLoop")]
	public float soundDelay;

	[BoxGroup("Outfits")]
	[Tooltip("Check to see if we need outdoor clothes when 'make clothed' is enabled below...")]
	public bool outdoorClothingCheck;

	[Space(5f)]
	[BoxGroup("Outfits")]
	public bool specificOutfitOnActivate;

	[BoxGroup("Outfits")]
	[EnableIf("specificOutfitOnActivate")]
	public ClothesPreset.OutfitCategory allowedOutfitOnActivate;

	[DisableIf("specificOutfitOnActivate")]
	[Tooltip("If no specific outfit is required, make sure the citizen is at least clothed!")]
	[BoxGroup("Outfits")]
	public bool makeClothedOnActivate;

	[Space(5f)]
	[BoxGroup("Outfits")]
	public bool specificOutfitOnArrive;

	[EnableIf("specificOutfitOnArrive")]
	[BoxGroup("Outfits")]
	public ClothesPreset.OutfitCategory allowedOutfitOnArrive;

	[Tooltip("If no specific outfit is required, make sure the citizen is at least clothed!")]
	[DisableIf("specificOutfitOnArrive")]
	[BoxGroup("Outfits")]
	public bool makeClothedOnArrive;

	[BoxGroup("Outfits")]
	[Space(5f)]
	public bool specificOutfitOnDeactivate;

	[BoxGroup("Outfits")]
	[EnableIf("specificOutfitOnDeactivate")]
	public ClothesPreset.OutfitCategory allowedOutfitOnDeactivate;

	[BoxGroup("Outfits")]
	[Tooltip("If no specific outfit is required, make sure the citizen is at least clothed!")]
	[DisableIf("specificOutfitOnDeactivate")]
	public bool makeClothedOnDeactivate;

	[Space(5f)]
	[BoxGroup("Outfits")]
	public bool specificOutfitOnComplete;

	[EnableIf("specificOutfitOnComplete")]
	[BoxGroup("Outfits")]
	public ClothesPreset.OutfitCategory allowedOutfitOnComplete;

	[BoxGroup("Outfits")]
	[DisableIf("specificOutfitOnComplete")]
	[Tooltip("If no specific outfit is required, make sure the citizen is at least clothed!")]
	public bool makeClothedOnComplete;

	[BoxGroup("Expressions")]
	public bool setExpressionOnActivate;

	[EnableIf("setExpressionOnActivate")]
	[BoxGroup("Expressions")]
	public CitizenOutfitController.Expression activateExpression;

	[Space(5f)]
	[BoxGroup("Expressions")]
	public bool setExpressionOnArrive;

	[EnableIf("setExpressionOnArrive")]
	[BoxGroup("Expressions")]
	public CitizenOutfitController.Expression arriveExpression;

	[BoxGroup("Expressions")]
	[Space(5f)]
	public bool setExpressionOnDeactivate;

	[EnableIf("setExpressionOnDeactivate")]
	[BoxGroup("Expressions")]
	public CitizenOutfitController.Expression deactivateExpression;

	[Space(5f)]
	[BoxGroup("Expressions")]
	public bool setExpressionOnComplete;

	[EnableIf("setExpressionOnComplete")]
	[BoxGroup("Expressions")]
	public CitizenOutfitController.Expression completeExpression;

	[Tooltip("Allow (any) items to be held during this action")]
	[Header("Items")]
	public bool allowItems;

	[Tooltip("Allow a action-specific custom item to be held")]
	public bool enableCustomItem;

	[Tooltip("Spawn this item in right hand")]
	[EnableIf("enableCustomItem")]
	public GameObject itemRight;

	[EnableIf("enableCustomItem")]
	public Vector3 itemRightLocalPos;

	[EnableIf("enableCustomItem")]
	public Vector3 itemRightLocalEuler;

	[Space(7f)]
	[Tooltip("Spawn this item in left hand")]
	[EnableIf("enableCustomItem")]
	public GameObject itemLeft;

	[EnableIf("enableCustomItem")]
	public Vector3 itemLeftLocalPos;

	[EnableIf("enableCustomItem")]
	public Vector3 itemLeftLocalEuler;

	[EnableIf("enableCustomItem")]
	public ActionStateFlag spawnCustomItemOn;

	[EnableIf("enableCustomItem")]
	public ActionStateFlag destroyCustomItemOn;

	[EnableIf("enableCustomItem")]
	[Tooltip("Does this require a custom carrying animation?")]
	public bool requiresCarryAnimation;

	[EnableIf("enableCustomItem")]
	public int overrideCarryAnimation;

	[Space(7f)]
	[Tooltip("Drop this item on the floor when this action ends")]
	public InteractablePreset dropItemOnEnd;

	[Header("Speech")]
	[Range(0f, 1f)]
	public float chanceOfOnTrigger;

	public List<SpeechController.Bark> onTriggerBark;

	[Range(0f, 1f)]
	public float chanceOfWhileJourney;

	public List<SpeechController.Bark> whileJourneyBark;

	[Range(0f, 1f)]
	public float chanceOfOnArrival;

	public List<SpeechController.Bark> onArrivalBark;

	[Range(0f, 1f)]
	public float chanceOfWhileArrived;

	public bool mustSeeOtherCitizen;

	public List<SpeechController.Bark> whileArrivedBark;

	[Range(0f, 1f)]
	public float chanceOfOnComplete;

	public List<SpeechController.Bark> onCompleteBark;
}
