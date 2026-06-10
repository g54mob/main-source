using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "occupation_data", menuName = "Database/Company/Occupation Preset")]
public class OccupationPreset : SoCustomComparison
{
	public enum workType
	{
		Office = 0,
		Management = 1,
		Labourer = 2,
		Janitorial = 3,
		Retail = 4,
		Service = 5,
		Driver = 6,
		PublicSector = 7,
		Enforcer = 8,
		Criminal = 9,
		Creative = 10,
		Other = 11,
		Student = 12,
		Unemployed = 13,
		Retired = 14,
		Illegal = 15
	}

	public enum ShiftType
	{
		morningShift = 0,
		dayShift = 1,
		eveningShift = 2,
		nightShift = 3
	}

	public enum JobAI
	{
		workPosition = 0,
		random = 1,
		randomBuilding = 2,
		passedCompanyPosition = 3
	}

	public enum workTags
	{
		none = 0,
		dull = 1,
		exciting = 2,
		dangerous = 3,
		menial = 4,
		intern = 5,
		stressful = 6,
		cushy = 7,
		technical = 8,
		ceo = 9,
		social = 10,
		isolated = 11,
		professional = 12
	}

	public enum Overtime
	{
		none = 0,
		low = 1,
		medium = 2,
		high = 3,
		veryHigh = 4
	}

	[Header("Category")]
	[Tooltip("Collar colour")]
	public workType work;

	[Tooltip("Additional tags to describe this work")]
	public List<workTags> tags;

	[Tooltip("The higher the priority, the more chance the position will be filled")]
	[Range(0f, 4f)]
	public int jobFillPriority;

	[Tooltip("If this job requires a certain work outfit, list it here...")]
	[Header("Outfit")]
	public List<ClothesPreset> workOutfit;

	[Header("Special Cases")]
	public bool selfEmployed;

	public bool receptionist;

	public bool canAskAboutJob;

	public bool janitor;

	public bool security;

	public bool isCriminal;

	public bool isPublicFacing;

	[EnableIf("isCriminal")]
	public int minimumPerCity;

	[EnableIf("isCriminal")]
	public float societalClass;

	[Header("Personality Fit")]
	[Tooltip("Personality is calculated after job assign; how much to scew personality towards this...")]
	public float skewPersonalityTowardsJobFit;

	public bool skewHumility;

	[Tooltip("Honesty-Humility (H): sincere, honest, faithful, loyal, modest/unassuming versus sly, deceitful, greedy, pretentious, hypocritical, boastful, pompous")]
	[EnableIf("skewHumility")]
	[Range(0f, 1f)]
	public float humility;

	public bool skewEmotionality;

	[Tooltip("Emotionality (E): emotional, oversensitive, sentimental, fearful, anxious, vulnerable versus brave, tough, independent, self-assured, stable")]
	[EnableIf("skewEmotionality")]
	[Range(0f, 1f)]
	public float emotionality;

	public bool skewExtraversion;

	[EnableIf("skewExtraversion")]
	[Tooltip("Extraversion (X): outgoing, lively, extraverted, sociable, talkative, cheerful, active versus shy, passive, withdrawn, introverted, quiet, reserved")]
	[Range(0f, 1f)]
	public float extraversion;

	public bool skewAgreeableness;

	[EnableIf("skewAgreeableness")]
	[Range(0f, 1f)]
	[Tooltip("Agreeableness (A): patient, tolerant, peaceful, mild, agreeable, lenient, gentle versus ill-tempered, quarrelsome, stubborn, choleric")]
	public float agreeableness;

	public bool skewConscientiousness;

	[Tooltip("Conscientiousness (C): organized, disciplined, diligent, careful, thorough, precise versus sloppy, negligent, reckless, lazy, irresponsible, absent-minded")]
	[EnableIf("skewConscientiousness")]
	[Range(0f, 1f)]
	public float conscientiousness;

	public bool skewCreativity;

	[Tooltip("Openness to Experience (O): intellectual, creative, unconventional, innovative, ironic versus shallow, unimaginative, conventional")]
	[EnableIf("skewCreativity")]
	[Range(0f, 1f)]
	public float creativity;

	[Header("Work Hours")]
	[Tooltip("Find a shift matching the below enum")]
	public bool shiftTimeIsImportant;

	[Tooltip("The employee works this shift (if available)")]
	public ShiftType shiftType;

	[Tooltip("Does this job count towards the open coverage of the shift they have?")]
	public bool countsTowardsOpenHoursCoverage;

	[Tooltip("The employee can take a break half way through their shift")]
	public bool lunchBreakAllowed;

	[Header("AI Behaviour")]
	[Tooltip("Where should the AI go to upon starting the goal?")]
	public JobAI jobAIPosition;

	[Tooltip("If AI behaviour is set to patrol, are there any rooms in which it is not allowed?")]
	[ReorderableList]
	public List<RoomConfiguration> bannedRooms;

	[Tooltip("The list of actions the AI will perform inside the 'Work' goal.")]
	public List<AIGoalPreset.GoalActionSetup> actionSetup;

	[Tooltip("What interactable will the AI work from?")]
	public InteractablePreset.SpecialCase jobPostion;

	[Tooltip("Does the AI own their own version of above? If not they will use free available ones.")]
	public bool ownsWorkPosition;

	[Tooltip("Where should the AI start to search for their work place?")]
	[ReorderableList]
	public List<RoomConfiguration> preferredRooms;

	[Space(5f)]
	[Tooltip("How often should the AI get up and do other tasks. Time range (game time)")]
	public Vector2 potterFrequency;

	[Tooltip("If true the AI will only potter if there is at least 1 other staff memeber on it's work postion interactable type")]
	public bool onlyPotterIfSomebodyElseWorking;

	[Tooltip("List of other tasks to randomly do while on the job.")]
	[ReorderableList]
	public List<AIActionPreset> potterActions;

	[Tooltip("Allows clean up actions to be inserted which will allow the AI to pick things up from the floor")]
	public bool canPickUpLitter;

	[Header("Items")]
	[Tooltip("This person has a name placard at work")]
	public bool namePlacard;

	[Tooltip("This person has an employee photo")]
	public bool employeePhoto;

	[Tooltip("This person has business cards")]
	public bool businessCards;

	[Tooltip("This person has a work rota")]
	public bool workRota;

	[Tooltip("This person has an employment contract")]
	public bool employmentContract;

	[Tooltip("List of items to add once this job position is filled")]
	public List<InteractablePreset> jobItems;

	[Tooltip("List of items to add to inventory")]
	public List<InteractablePreset> inventoryItems;

	public List<GroupPreset> joinGroups;

	[Header("Dialog Options")]
	public List<DialogPreset> addDialog;

	[Header("Debug")]
	public OccupationPreset selectedPreset;

	[Button(null, EButtonEnableMode.Always)]
	public void CopyOutfitFromSelectedPreset()
	{
	}
}
