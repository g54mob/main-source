using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "aigoal_data", menuName = "Database/AI/AI Goal")]
public class AIGoalPreset : SoCustomComparison
{
	public enum GoalCategory
	{
		trivial = 0,
		important = 1,
		vital = 2
	}

	public enum StartingGoal
	{
		all = 0,
		nonHomelessOnly = 1,
		homelessOnly = 2
	}

	public enum RainFactor
	{
		none = 0,
		onlyDoWhenRaining = 1,
		dontDoWhenRaining = 2
	}

	[Serializable]
	public class GoalModifierRule
	{
		public CharacterTrait.RuleType rule;

		public List<CharacterTrait> traitList;

		[Tooltip("If this isn't true then it won't be picked for application at all.")]
		[ShowIf("isTrait")]
		public bool mustPassForApplication;

		[Tooltip("Add this to a default priority multiplier of 1.")]
		public float priorityMultiplier;
	}

	public enum LocationOption
	{
		useCurrent = 0,
		home = 1,
		work = 2,
		commercial = 3,
		nearestAvailable = 4,
		investigate = 5,
		commercialDecision = 6,
		patrolLocation = 7,
		passedInteractable = 8,
		passedGamelocation = 9,
		murderLocation = 10
	}

	public enum RoomOption
	{
		none = 0,
		bedroom = 1,
		job = 2
	}

	public enum FurnitureOption
	{
		none = 0,
		bed = 1,
		job = 2
	}

	[Serializable]
	public class GoalActionSetup
	{
		public List<AIActionPreset> actions;

		public ActionCondition condition;

		public float chance;

		public List<GoalModifierRule> traitModifiers;

		public List<StatusModifierRule> statusModifiers;
	}

	[Serializable]
	public class StatusModifierRule
	{
		public StatusType status;

		public StatusCondition condition;

		public float value;

		public float chanceModifier;
	}

	public enum StatusType
	{
		health = 0,
		nerve = 1,
		nourishment = 2,
		hydration = 3,
		alertness = 4,
		energy = 5,
		excitement = 6,
		chores = 7,
		hygeine = 8,
		bladder = 9,
		heat = 10,
		breath = 11,
		onDutyEnforcer = 12
	}

	public enum StatusCondition
	{
		isEqualOrAbove = 0,
		isEqualOrBelow = 1,
		isTrue = 2,
		isFalse = 3
	}

	public enum ActionCondition
	{
		always = 0,
		atHomeOnly = 1,
		inPublicOnly = 2,
		atWorkOnly = 3,
		onlyIfEscalated = 4,
		onlyIfDead = 5,
		atHomeNoGuestPass = 6,
		noGuestPass = 7,
		kidnapOnly = 8,
		nonKidnapOnly = 9,
		killerTauntChance = 10
	}

	public enum GoalActionSource
	{
		thisConfiguration = 0,
		jobPreset = 1,
		murderPreset = 2
	}

	[Header("Application")]
	[Tooltip("If true will be added to citizen upon creation")]
	public bool startingGoal;

	[Tooltip("Is this goal designed for...")]
	[EnableIf("startingGoal")]
	public StartingGoal appliesTo;

	[EnableIf("startingGoal")]
	public List<OccupationPreset> appliedToTheseJobs;

	[EnableIf("startingGoal")]
	[Tooltip("Valid if any of these items are found at home...")]
	public List<InteractablePreset> onlyIfFeaturesItemsAtHome;

	[Tooltip("If true, don't save with game state")]
	public bool disableSave;

	[Tooltip("A general category we can use to help goals interact with each other")]
	public GoalCategory category;

	[Tooltip("The base priority")]
	[Range(0f, 11f)]
	[Header("Priority")]
	public int basePriority;

	[Tooltip("Random variance to add to the priority")]
	[Range(0f, 12f)]
	public int randomVariance;

	[Tooltip("Clamp min/max priority")]
	public Vector2 minMaxPriority;

	[Tooltip("Multiply base priority by amount of trash carried")]
	public bool multiplyUsingTrashCarried;

	[Tooltip("If the player owes debt then give this maximum priority")]
	public bool useLateDebtPriority;

	[Tooltip("If true this will only be ranked within the following hours")]
	public bool onlyImportantBetweenHours;

	[EnableIf("onlyImportantBetweenHours")]
	public Vector2 validBetweenHours;

	[Tooltip("Don't update the priority of goals (apart from investigate) while this is active")]
	public bool dontUpdateGoalPriorityWhileActive;

	[Tooltip("Overrides all priority update rules when created")]
	public bool forcePriorityUpdateOnCreation;

	[Tooltip("When raining, this acts as a multiplier")]
	public RainFactor rainFactor;

	[Tooltip("Only important when music is playing in the room")]
	public bool useMusic;

	[Tooltip("Only important if this citizen is trespassing")]
	public bool useTrespassing;

	[Tooltip("Lose priority over time")]
	public bool affectPriorityOverTime;

	[Tooltip("Over the course of one hour, add this to the overall priority multiplier")]
	[EnableIf("affectPriorityOverTime")]
	public float multiplierModifierOverOneHour;

	[Tooltip("Special case which boosts if this is the sniper victim and the sniper is ready and waiting")]
	public bool sniperVictimBoost;

	[Header("Trait Modifiers")]
	public List<GoalModifierRule> goalModifiers;

	[Header("Other Goal Modifiers")]
	public List<AIGoalPreset> ifGoalsPresent;

	public float otherGoalPriorityModifier;

	[Header("Timing Priority")]
	public bool useTiming;

	[Tooltip("How important is timing to this goal? (Will add this much to overall if @ time)")]
	[EnableIf("useTiming")]
	[Range(0f, 10f)]
	public int timingImportance;

	[Tooltip("When will the priority start being boosted: From this amount of time before trigger time")]
	[EnableIf("useTiming")]
	[Range(0f, 3f)]
	public float earlyTimingWindow;

	[Tooltip("Cancel the goal if too late (below time)")]
	[EnableIf("useTiming")]
	public bool cancelIfLate;

	[Range(0f, 3f)]
	[EnableIf("cancelIfLate")]
	[Tooltip("Cancel the goal if this late to execute")]
	public float cancelIfThisLate;

	[Tooltip("Cancel if this has been active for too long")]
	public bool cancelAfterTime;

	[EnableIf("cancelAfterTime")]
	[Range(0f, 24f)]
	[Tooltip("Cancel the goal if it has been active for this time")]
	public float cancelAfter;

	[Tooltip("Run if this citizen becomes late")]
	public bool runIfLate;

	[Header("Stat Priority")]
	[Range(0f, 10f)]
	[Tooltip("Increases priority with hunger (inverse nourishment)")]
	public int nourishmentImportance;

	[Range(0f, 10f)]
	[Tooltip("Increases priority with thirst (inverse hydration)")]
	public int hydrationImportance;

	[Range(0f, 10f)]
	[Tooltip("Increases priority with laziness (inverse altertness)")]
	public int alertnessImportance;

	[Range(0f, 10f)]
	[Tooltip("Increases priority with tiredness (inverse energy)")]
	public int energyImportance;

	[Range(0f, 10f)]
	[Tooltip("Increases priority with bordem (inverse excitement)")]
	public int excitementImportance;

	[Range(0f, 10f)]
	[Tooltip("Increases priority with todo (inverse chores)")]
	public int choresImportance;

	[Range(0f, 10f)]
	[Tooltip("Increases priority with dirtiness (inverse hygiene)")]
	public int hygieneImportance;

	[Range(0f, 10f)]
	[Tooltip("Increases priority with loo (inverse bladder)")]
	public int bladderImportance;

	[Range(0f, 10f)]
	[Tooltip("Increases priority with need for heat (inverse heat)")]
	public int heatImportance;

	[Range(0f, 10f)]
	[Tooltip("Increases priority with need for heat (inverse heat)")]
	public int drunkImportance;

	[Range(0f, 10f)]
	[Tooltip("Increases priority with need for breath")]
	public int breathImportance;

	[Range(0f, 15f)]
	[Tooltip("Increases priority when poisioned")]
	public int poisonImportance;

	[Range(0f, 50f)]
	[Tooltip("Increases priority when blinded")]
	public int blindedImportance;

	[Header("Completion")]
	[Tooltip("This goal will be removed when all actions have been completed")]
	public bool completable;

	[Tooltip("When actions are completed, restart the above list")]
	[DisableIf("completable")]
	public bool loopingActions;

	[Tooltip("If false this action cannot be interupted once started")]
	[Header("Interuption")]
	public bool interuptable;

	[EnableIf("interuptable")]
	public bool unteruptableByFollowingCategories;

	[EnableIf("interuptable")]
	public List<GoalCategory> uninteruptableByCategories;

	[Tooltip("If true this action will use this threshold before it is interupted")]
	[EnableIf("interuptable")]
	public bool useInteruptionThreshold;

	[EnableIf("useInteruptionThreshold")]
	[Range(0f, 10f)]
	[Tooltip("Other goals will have to reach this much above the current priority before this one is interupted...")]
	public float interuptionThreshold;

	[Tooltip("If use point is busy, delay goal from repeating for this time...")]
	[Header("Delay")]
	public float repeatDelayOnBusy;

	[Tooltip("If interupted by a more important goal, delay goal from repeating for this time...")]
	public float repeatDelayOnInterupt;

	[Tooltip("If no actions left, delay goal from repeating for this time...")]
	public float repeatDelayOnFinishActions;

	[Tooltip("If enabled, enforcers on duty will be allowed everywhere to execute this action.")]
	[Header("Location")]
	public bool allowEnforcersEverywhere;

	[InfoBox("Select 'Use Current' when none is needed (location is selected within action).\nNearest Available: Finds the nearest interactable using the first action, and passes it along with gamelocation\nCommercial/Commercial Decision: Will execute a decision based on current stats. Will pass a gamelocation, and sometimes a specific interactable.", EInfoBoxType.Normal)]
	[Space(7f)]
	public LocationOption locationOption;

	[Tooltip("AI will avoid certain marked locations if true")]
	public bool useToiletSettings;

	[InfoBox("The below is only relevent for commerical decisions...", EInfoBoxType.Normal)]
	public CompanyPreset.CompanyCategory desireCategory;

	[Space(7f)]
	public RoomOption roomOption;

	[Space(7f)]
	public FurnitureOption furnitureOption;

	[InfoBox("If this is true, the first action's found room location (inside active action) becomes the passed room for the entire goal.", EInfoBoxType.Normal)]
	public bool actionFoundRoomBecomesPassedRoom;

	[Tooltip("If true, this goal will not be active if the actions are not at the passed gamelocation")]
	public bool passedGamelocationIsImportant;

	[Header("Action Setup")]
	[Tooltip("Where should this goal get the actions from?")]
	public GoalActionSource actionSource;

	public List<GoalActionSetup> actionsSetup;

	[Tooltip("Potentially raise alarm if certain conditions are met.")]
	public bool raiseAlarm;

	[Tooltip("Allow AI to trespass while performing this goal")]
	public bool allowTrespass;

	[Tooltip("Disable all action insertions during this goal")]
	public bool disableActionInsertions;

	[Tooltip("Send consumables to trash on activation")]
	public bool trashConsumablesOnActivate;

	[Tooltip("Disable the ability to throw objects in combat for this goal")]
	public bool disableThrowing;

	[Tooltip("Disable trigger to mugging if this goal is active")]
	public bool diabledMugging;

	[Tooltip("Pottering: Occasionally the AI will insert one of these actions into the goal.")]
	[Space(5f)]
	public bool allowPottering;

	[EnableIf("allowPottering")]
	public GoalActionSource potterSource;

	[EnableIf("allowPottering")]
	[Tooltip("How often the AI 'potters'. Can be overridden by the above setting")]
	public Vector2 potterFrequency;

	[ReorderableList]
	[EnableIf("allowPottering")]
	public List<AIActionPreset> potterActions;

	[Tooltip("Override the location's lighting behaviour")]
	public bool overrideLightingBehaviour;

	[EnableIf("overrideLightingBehaviour")]
	public bool onlyOverrideIfAtGamelocation;

	[EnableIf("overrideLightingBehaviour")]
	public List<RoomConfiguration.AILightingBehaviour> lightingBehaviour;

	[Tooltip("Execute the closing of doors as below:")]
	public AIActionPreset.DoorRule doorRule;

	[Header("Speech")]
	[Range(0f, 1f)]
	public float chanceOfOnTrigger;

	public List<SpeechController.Bark> onTriggerBark;
}
