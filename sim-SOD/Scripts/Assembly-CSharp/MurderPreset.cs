using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "murder_data", menuName = "Database/Murder Preset")]
public class MurderPreset : SoCustomComparison
{
	public enum CaseType
	{
		murder = 0,
		sniper = 1,
		kidnap = 2
	}

	[Serializable]
	public class MurdererModifierRule
	{
		public CharacterTrait.RuleType rule;

		public List<CharacterTrait> traitList;

		[ShowIf("isTrait")]
		[Tooltip("If this isn't true then it won't be picked for application at all.")]
		public bool mustPassForApplication;

		[Tooltip("Add this to a default priority multiplier of 1.")]
		public float scoreModifier;
	}

	public enum SuccessfulTravelTrigger
	{
		whenMurdererIsAtTheSameLocation = 0,
		whenMurdererIsAtVantagePoint = 1
	}

	public enum LeadCitizen
	{
		nobody = 0,
		victim = 1,
		killer = 2,
		victimsClosest = 3,
		killersClosest = 4,
		victimsDoctor = 5,
		killersDoctor = 6,
		ransom = 7,
		victimsLandlord = 8,
		KillersLandlord = 9
	}

	public enum LeadSpawnWhere
	{
		victimHome = 0,
		victimWork = 1,
		killerHome = 2,
		killerWork = 3,
		ransom = 4,
		killerDen = 5
	}

	[Serializable]
	public class MurderModifierRule
	{
		public LeadCitizen who;

		public CharacterTrait.RuleType rule;

		public List<CharacterTrait> traitList;

		[ShowIf("isTrait")]
		[Tooltip("If this isn't true then it won't be picked for application at all.")]
		public bool mustPassForApplication;

		[Tooltip("Add this to a default priority multiplier of 1.")]
		public float chanceModifier;
	}

	[Serializable]
	public class MurderLeadItem
	{
		public string name;

		public bool compatibleWithAllMotives;

		[DisableIf("compatibleWithAllMotives")]
		public List<MurderMO> compatibleWithMotives;

		public MurderController.MurderState spawnOnPhase;

		public bool tryToSpawnWithEachNewMurder;

		public LeadCitizen belongsTo;

		[DisableIf("useOrGroup")]
		[Range(0f, 1f)]
		[Space(7f)]
		public float chance;

		[Space(7f)]
		public bool useTraits;

		[EnableIf("useTraits")]
		public List<MurderModifierRule> traitModifiers;

		[Space(7f)]
		public bool useIf;

		[Tooltip("Only spawn if a previous object of this letter is spawned...")]
		[EnableIf("useIf")]
		public JobPreset.JobTag ifTag;

		[Space(7f)]
		public bool useOrGroup;

		[EnableIf("useOrGroup")]
		[Tooltip("If enabled, only one chosen item from this group will be spawned...")]
		public JobPreset.JobTag orGroup;

		[Range(0f, 10f)]
		[EnableIf("useOrGroup")]
		public int chanceRatio;

		[Space(7f)]
		public JobPreset.JobTag itemTag;

		[Tooltip("What?")]
		public InteractablePreset spawnItem;

		[Space(7f)]
		public string vmailThread;

		public Vector2 vmailProgressThreshold;

		[Space(3f)]
		[Tooltip("Writer is valid for objects and V-mails (person A)")]
		public LeadCitizen writer;

		[Tooltip("Writer is valid for objects and V-mails (person B)")]
		public LeadCitizen receiver;

		[Tooltip("Only valid for v-mails (persons C & D)")]
		public List<LeadCitizen> vmailOtherParticipants;

		[Space(3f)]
		[Tooltip("Where?")]
		public LeadSpawnWhere where;

		public int security;

		public int priority;

		public InteractablePreset.OwnedPlacementRule ownershipRule;
	}

	[Header("Basic Settings")]
	public CaseType caseType;

	[Header("Preset Picking")]
	public bool disabled;

	[Tooltip("How often this is picked compared to others...")]
	[Range(0f, 10f)]
	public int frequency;

	[Header("Murderer Picking")]
	public Vector2 murdererRandomScoreRange;

	public List<MurdererModifierRule> murdererTraitModifiers;

	public bool useHexaco;

	[ShowIf("useHexaco")]
	public HEXACO hexaco;

	[Header("Other")]
	[Tooltip("Pick a den")]
	public bool pickDen;

	public float kidnapperTimeUntilKill;

	public float minimumTimeBetweenMurders;

	[Tooltip("When not at home, how many occupants are allowed here at maximum for the murder to trigger at this location")]
	[Space(5f)]
	public int nonHomeMaximumOccupantsTrigger;

	[Tooltip("When not at home, how many occupants are allowed here at maximum for the triggered murder to be cancelled")]
	public int nonHomeMaximumOccupantsCancel;

	[Header("Phase 1: Acquire Murder Weapon/Ammo")]
	public bool requiresAcquirePhase;

	public bool acquirePassInteractable;

	public bool acquirePassRoom;

	public List<AIGoalPreset.GoalActionSetup> acquireActionSetup;

	[Header("Phase 2: Research")]
	[Tooltip("Does this require a research state?")]
	public bool requiresResearchPhase;

	[EnableIf("requiresResearchPhase")]
	[Tooltip("If true this will set up a situation where the killer and victim meet at an eatery")]
	public bool killerMeetsVicim;

	[EnableIf("requiresResearchPhase")]
	public bool researchPassInteractable;

	[EnableIf("requiresResearchPhase")]
	public bool researchPassRoom;

	[EnableIf("requiresResearchPhase")]
	public List<AIGoalPreset.GoalActionSetup> researchActionSetup;

	[Header("Phase 3: Travel To")]
	[Tooltip("Once the murderer has started travelling, block the victim from leaving their location...")]
	public bool blockVictimFromLeavingLocation;

	public SuccessfulTravelTrigger travelSuccessTrigger;

	public bool travelPassInteractable;

	public bool travelPassRoom;

	public List<AIGoalPreset.GoalActionSetup> travelActionSetup;

	[Header("Phase 4: Execution")]
	public bool executePassInteractable;

	public bool executePassRoom;

	public List<AIGoalPreset.GoalActionSetup> executionActionSetup;

	[Header("Phase 5: Post")]
	public bool postPassInteractable;

	public bool postPassRoom;

	public List<AIGoalPreset.GoalActionSetup> postActionSetup;

	[Header("Phase 6: Escape")]
	public bool escapePassInteractable;

	public bool escapePassRoom;

	public List<AIGoalPreset.GoalActionSetup> escapeActionSetup;

	[Header("Leads")]
	public List<MurderLeadItem> leads;

	[Header("Resolve")]
	[Tooltip("If true the case will use custom resolve questions")]
	public bool useCustomResolveQuestions;

	[EnableIf("useCustomResolveQuestions")]
	public List<Case.ResolveQuestion> customResolveQuestions;

	[Header("Debug")]
	public MurderPreset copyFrom;

	[Button(null, EButtonEnableMode.Always)]
	public void CopyLeads()
	{
	}
}
