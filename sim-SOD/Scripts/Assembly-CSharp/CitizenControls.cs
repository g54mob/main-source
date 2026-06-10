using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class CitizenControls : MonoBehaviour
{
	[Serializable]
	public class LimbPos
	{
		public CitizenOutfitController.CharacterAnchor anchor;

		public Vector3 localPosition;

		public Quaternion localRotation;
	}

	[Serializable]
	public class ManualAnimation
	{
		public float timeline;

		public List<LimbPos> limbData;
	}

	[Serializable]
	public class StartingInventory
	{
		public string name;

		public List<InteractablePreset> presets;

		public float baseChance;

		public List<MurderPreset.MurdererModifierRule> modifiers;
	}

	[Tooltip("The base speed of a citizen")]
	[Header("Movement")]
	public float baseCitizenWalkSpeed;

	[Tooltip("Citizen run speed multiplier")]
	public float baseCitizenRunSpeed;

	[Tooltip("Acceleration Curve")]
	public AnimationCurve acceleration;

	[Tooltip("Decceleration Curve")]
	public AnimationCurve decceleration;

	[Tooltip("Ranges for random speed multiplier")]
	public Vector2 movementSpeedMultiplierRange;

	[Tooltip("Speed citizen turns to face a new direction")]
	public float citizenFaceSpeed;

	[Tooltip("Range of speed of citizen turning head to face something")]
	public Vector2 citizenLookAtSpeed;

	[Tooltip("How far a citizen moves per footstep.")]
	public float citizenFootstepDistance;

	[Tooltip("Amount of movement speed to lose while drunk")]
	public float drunkMovementPenalty;

	[Tooltip("Chance of falling over while drunk")]
	public float drunkFallChance;

	[Tooltip("Capsule collider changes thickness depending on movement")]
	public Vector2 capsuleMovementThickness;

	[Header("Visuals")]
	[Tooltip("The average scale of the average in-game height (175.4). This is slightly shorter than the player who is slightly above average height.")]
	public float baseScale;

	[Header("Dialog")]
	[Tooltip("How high above a citizens head is th speech bubble?")]
	public float speechBubbleHeight;

	public DialogPreset askAboutJob;

	[Tooltip("There maximum number of existing speech bubbles onscreen for new one line dialog to be triggered")]
	public int maxSpeechBubbles;

	[Header("Bank")]
	public AnimationCurve societalClassSavingsCurve;

	[ReorderableList]
	[Tooltip("Each of the following essentially boost the soc class by 0.1")]
	public List<CharacterTrait> savingsBoostTrait;

	[ReorderableList]
	[Tooltip("Each of the following essentially reduce the soc class by 0.1")]
	public List<CharacterTrait> savingsDebuffTrait;

	[Header("Behaviour")]
	public DialogPreset telephoneGreeting;

	public DialogPreset identifyNumberDialog;

	public DialogPreset lastCallerDialog;

	public DialogPreset policeDialog;

	public DialogPreset coverUpOffer;

	public DialogPreset coverUpBodyLocation;

	public DialogPreset coverUpSuccess;

	public DialogPreset telephoneWrongPerson;

	public DialogPreset telephoneKidnapperStillAtLarge;

	public List<EvidenceWitness.DialogOption> coverUpConvoOptions;

	[Tooltip("If no valid conversation is found, use this one")]
	public string fallbackTelephoneConversation;

	[Tooltip("Minimum investigation time: The minimum time the AI is to keep the investigate goal at maximum priority (in-game time)")]
	public float minimumInvestigateTime;

	[Tooltip("How quickly the AI gains one 'persuit lead' (this added per second)")]
	public float persuitChaseLogicAdditionPerSecond;

	[Tooltip("The maximum number of persuit logic leads the AI can acculumate")]
	public int maxChaseLogic;

	[Tooltip("Persuit response addition from shortest distance to longest distance")]
	public Vector2 persuitTimerThreshold;

	[Tooltip("When target is not in range, how fast to forget them")]
	public float persuitForgetThreshold;

	[Tooltip("When heard an illegal sound, how fast to forget...")]
	public float hearingForgetThreshold;

	[Tooltip("The multiplier for the minimum investiation time if the player is persued")]
	public float persuitMinInvestigationTimeMP;

	[Tooltip("The multiplier for the minimum investiation time if the citizen investiates a sighting")]
	public float sightingMinInvestigationTimeMP;

	[Tooltip("The multiplier for the minimum investiation time if the citizen investiates a sound")]
	public float soundMinInvestigationTimeMP;

	[Space(7f)]
	[Tooltip("How much time passes after a sighting of highest rank before a citizen stops looking @ it")]
	public float lookAtGracePeriod;

	[Space(7f)]
	[Tooltip("If somebody in the same room is punched, trigger citizens in the same address within this range to respond...")]
	public float punchedResponseRange;

	[Tooltip("How many different citizens does can this person remember?")]
	[Header("Sightings")]
	public int defaultMemoryLimit;

	[Tooltip("Citizens recover this amount of health (normalized) over time (game time 1 hour)")]
	[Header("Combat")]
	public float citizenBaseRecoveryRate;

	[Tooltip("The starting value for citizen combat skill (how fast attacks are)")]
	public Vector2 citizenBaseCombatSkillRange;

	[Tooltip("Multiplier for combat heft: See descriptors for how this works")]
	public float citizenCombatHeftMultiplier;

	[Tooltip("Minimum range for throwing an object")]
	public float throwMinRange;

	[Tooltip("Minimum range for throwing an object")]
	public float throwMaxRange;

	[Space(7f)]
	[Tooltip("Shock damage on impact is multiplied by this")]
	public float nerveDamageShockMultiplier;

	[Tooltip("Nerve damage by a weapon draw is multiplied by this")]
	public float nerveWeaponDrawMultiplier;

	[Tooltip("Nerve recovery rate as a fraction of health recovery")]
	public float nerveRecoveryRateMultiplier;

	[Space(7f)]
	public float doorBargeKOForceMultiplier;

	[Tooltip("How the force multiplier scales with extra damage received")]
	public float damageRecieveForceMultiplier;

	[Header("Get up Limb Snapshot")]
	[Tooltip("How long it takes to transition from ragdoll landing position to the start of the get-up animation (seconds)")]
	public float ragdollTransitionTime;

	[Tooltip("The length of the get up animation or longer")]
	public float getUpTimer;

	public List<ManualAnimation> getUpManualAnimation;

	[Header("Skills")]
	[Tooltip("How quickly stealth skill is applied when standing still")]
	public float stealthSkillApplicationRate;

	[Tooltip("How quickly stealth skill is cancelled when moving")]
	public float stealthSkillCancelRate;

	[Header("LookAt Head Clamping")]
	public float leftExtent;

	public float rightExtent;

	public float upExtent;

	public float downExtent;

	[Tooltip("Animation offset of the citizens lower torso with a scale of 1...")]
	[Header("Animation")]
	public float sittingYOffset;

	[Tooltip("Animation offset of the citizens arms with a scale of 1...")]
	public float armsStandingYOffset;

	[Header("Fingerprints")]
	public Texture2D unknownPrint;

	[ReorderableList]
	public List<Texture2D> prints;

	[Header("Traits")]
	public CharacterTrait destitute;

	public CharacterTrait litterBug;

	public CharacterTrait likesTheRain;

	public CharacterTrait shoesNormal;

	public CharacterTrait shoesBoots;

	public CharacterTrait shoesHeels;

	public CharacterTrait coffeeLiker;

	public CharacterTrait teaLiker;

	public List<CharacterTrait> bbCardTraits;

	[Header("Physical Traits")]
	public CharacterTrait bald;

	public CharacterTrait shortHair;

	public CharacterTrait longHair;

	public Vector2 shoeSizeRange;

	[Tooltip("Subdivisions for AI navigation when inside nodes")]
	[Header("AI")]
	public List<Vector3> nodeLocalSubdivisions;

	[Header("Starting Inventory")]
	public List<StartingInventory> citizenStartingInventory;

	[Header("Misc")]
	public InteractablePreset citizenInteractable;

	public InteractablePreset handInteractable;

	public AIActionPreset sleep;

	public MatchPreset matchWithPhoto;

	public MatchPreset weakVisualSighting;

	public MatchPreset mediumVisualSighting;

	public MatchPreset strongVisualSighting;

	public CharacterTrait randomPassword;

	public InteractablePreset deadBodySearchInteractable;

	public InteractablePreset entryWound;

	public InteractablePreset exitWound;

	public InteractablePreset toothbrush;

	public InteractablePreset addressBook;

	public GameObject umbrella;

	public SpatterPatternPreset vomitSpatter;

	[Header("Debug")]
	public CitizenOutfitController debugSelectCitizen;

	private static CitizenControls _instance;

	public static CitizenControls Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ClearManualAnimation()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void AddManualKeyframe()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DebugCitizensStuck()
	{
	}
}
