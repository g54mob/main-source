using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "sidejob_data", menuName = "Database/Job Preset")]
public class JobPreset : SoCustomComparison
{
	public enum JobTag
	{
		A = 0,
		B = 1,
		C = 2,
		D = 3,
		E = 4,
		F = 5,
		G = 6,
		H = 7,
		I = 8,
		J = 9,
		K = 10,
		L = 11,
		M = 12,
		N = 13,
		O = 14,
		P = 15,
		Q = 16,
		R = 17,
		S = 18,
		T = 19,
		U = 20,
		V = 21,
		W = 22,
		X = 23,
		Y = 24,
		Z = 25
	}

	[Serializable]
	public class StartingScenario
	{
		public string name;

		public string dds;

		[Space(5f)]
		public List<StartingLead> leads;
	}

	[Serializable]
	public class StartingLead
	{
		public LeadEvidence leadEvidence;

		[Space(5f)]
		[HideIf("useKeyFromLeadPool")]
		public List<Evidence.DataKey> keys;

		[Tooltip("Add to the above with keys from the lead pool (chosen first)")]
		public bool useKeyFromLeadPool;

		public bool autoPin;

		[Tooltip("Add these dialog options to the above person")]
		[Space(5f)]
		public List<DialogPreset> addDialogOptions;

		[Tooltip("Add this fact link to the post facts section")]
		public List<string> factsReveal;

		public List<Evidence.DataKey> mergeKeys;

		public List<Evidence.Discovery> discoveryApplication;
	}

	[Serializable]
	public class FactCreation
	{
		public FactPreset factPreset;

		public LeadEvidence from;

		public LeadEvidence to;

		[Space(5f)]
		public bool overrideFromKeys;

		public List<Evidence.DataKey> fromKeys;

		public bool featureKeysFromLeadPool;

		[Space(5f)]
		public bool overrideToKeys;

		public List<Evidence.DataKey> toKeys;

		public bool featureKeysFromLeadPoolTo;
	}

	public enum LeadEvidence
	{
		none = 0,
		poster = 1,
		purp = 2,
		purpsParamour = 3,
		postersHome = 4,
		purpsHome = 5,
		purpsParamourHome = 6,
		postersWorkplace = 7,
		purpsWorkplace = 8,
		purpsParamourWorkplace = 9,
		postersBuilding = 10,
		purpsBuilding = 11,
		purpsParamourBuilding = 12,
		post = 13,
		posterTelephone = 14,
		purpsTelephone = 15,
		purpsParamourTelephone = 16,
		postersWorkplaceBuilding = 17,
		purpsWorkplaceBuilding = 18,
		purpsParamourWorkplaceBuilding = 19,
		extraPerson1 = 20,
		itemA = 21,
		itemB = 22,
		itemC = 23,
		itemD = 24,
		itemE = 25
	}

	public enum BasicLeadPool
	{
		hair = 0,
		eyeColour = 1,
		shoeSize = 2,
		build = 3,
		height = 4,
		fingerprint = 5,
		age = 6,
		jobTitle = 7,
		randomInterest = 8,
		partnerFirstName = 9,
		partnerJobTitle = 10,
		firstNameInitial = 11,
		socialClub = 12,
		partnerSocialClub = 13,
		notableFeatures = 14,
		salary = 15,
		bloodType = 16,
		randomAffliction = 17,
		handwriting = 18
	}

	public enum LeadCitizen
	{
		nobody = 0,
		poster = 1,
		purp = 2,
		purpsParamour = 3
	}

	public enum JobSpawnWhere
	{
		posterHome = 0,
		posterWork = 1,
		purpHome = 2,
		purpWork = 3,
		purpsParamourHome = 4,
		purpsParamourWork = 5,
		hiddenItemPlace = 6,
		nearbyGooseChase = 7
	}

	public enum DifficultyTag
	{
		D0 = 0,
		D1 = 1,
		D2A = 2,
		D2B = 3,
		D3 = 4,
		D4A = 5,
		D4B = 6,
		D4C = 7,
		D5 = 8,
		D6 = 9
	}

	[Serializable]
	public class JobModifierRule
	{
		public LeadCitizen who;

		public CharacterTrait.RuleType rule;

		public List<CharacterTrait> traitList;

		[Tooltip("If this isn't true then it won't be picked for application at all.")]
		[ShowIf("isTrait")]
		public bool mustPassForApplication;

		[Tooltip("Add this to a default priority multiplier of 1.")]
		public float chanceModifier;
	}

	[Serializable]
	public class StartingSpawnItem
	{
		public string name;

		[Tooltip("Try and find an existing interactable that matches this criteria...")]
		public bool findExisting;

		public List<MotivePreset> compatibleWithMotives;

		public bool compatibleWithAllMotives;

		[Range(0f, 1f)]
		[DisableIf("useOrGroup")]
		[Space(7f)]
		public float chance;

		[Space(7f)]
		public bool useTraits;

		[EnableIf("useTraits")]
		public List<JobModifierRule> traitModifiers;

		[Space(7f)]
		public bool useIf;

		[Tooltip("Only spawn if a previous object of this letter is spawned...")]
		[EnableIf("useIf")]
		public JobTag ifTag;

		[Space(7f)]
		public bool useOrGroup;

		[EnableIf("useOrGroup")]
		[Tooltip("If enabled, only one chosen item from this group will be spawned...")]
		public JobTag orGroup;

		[Range(0f, 10f)]
		[EnableIf("useOrGroup")]
		public int chanceRatio;

		[Space(7f)]
		public List<DifficultyTag> disableOnDifficulties;

		[Space(7f)]
		public JobTag itemTag;

		[Tooltip("What?")]
		public InteractablePreset spawnItem;

		[Space(7f)]
		public string vmailThread;

		public Vector2 vmailProgressThreshold;

		[Tooltip("Where?")]
		public JobSpawnWhere where;

		public LeadCitizen belongsTo;

		public LeadCitizen writer;

		public LeadCitizen receiver;

		public int security;

		public int priority;

		public InteractablePreset.OwnedPlacementRule ownershipRule;
	}

	[Serializable]
	public class HandInLocation
	{
		public LeadCitizen who;
	}

	[Serializable]
	public class IntroConfig
	{
		public SideMissionIntroPreset preset;

		[Range(0f, 10f)]
		public int frequency;
	}

	[Serializable]
	public class HandInConfig
	{
		public SideMissionHandInPreset preset;

		[Range(0f, 10f)]
		public int frequency;
	}

	public enum RewardLocation
	{
		none = 0,
		postersMailbox = 1,
		cityHallDesk = 2,
		playersMailbox = 3
	}

	public enum ParticipantCompliancy
	{
		noChange = 0,
		alwaysSuccess = 1,
		alwaysFail = 2
	}

	[Serializable]
	public class DialogReference
	{
		public string name;

		public DialogPreset dialog;
	}

	[Tooltip("Disable this in-game completely.")]
	[BoxGroup("Disable")]
	public bool disabled;

	[Header("Setup")]
	public string caseName;

	public InteractablePreset jobPosting;

	[Tooltip("Spawn this subclass. If left empty it will use the base class.")]
	public string subClass;

	public bool allowSyncDiskRewards;

	[EnableIf("allowSyncDiskRewards")]
	public bool allowBlackMarketSyncDiskRewards;

	public RewardLocation physicalRewardLocation;

	[Tooltip("Generates an item hiden location on acceptance")]
	public bool generateHidingLocation;

	[Header("Frequency")]
	[Tooltip("Spawn this job according to social credit level")]
	[InfoBox("The frequency uses the below graph multiplied by the active per citizen value to calculate how many jobs should be spawned...", EInfoBoxType.Normal)]
	public AnimationCurve socialCreditLevelMinSpawnFrequency;

	[Tooltip("The number of these jobs that should be active at one time, per citizen.")]
	public float activePerCitizen;

	[Tooltip("Hard limit on maximum jobs spawned")]
	public int maxJobs;

	[Tooltip("If posted jobs count is below this, then spawn them immediately")]
	public int immediatePostCountThreshold;

	[Header("Difficulty")]
	public DifficultyTag difficultyTag;

	[Header("Characters")]
	public ParticipantCompliancy changePosterDialogCompliancy;

	public ParticipantCompliancy changePerpDialogCompliancy;

	[Header("Motives")]
	public List<MotivePreset> purpetratorMotives;

	[Space(7f)]
	[Tooltip("Minus this from the score if the purp and poster live in the same building")]
	public int penaltyForPurpAndPosterSameBuilding;

	[Header("Starting Scenarios")]
	[Tooltip("Possible starting scenarios for this job")]
	public List<StartingScenario> startingScenarios;

	[Tooltip("Scenarios that will reveal the required information for the task")]
	[Header("Intros")]
	public List<IntroConfig> compatibleIntros;

	[Tooltip("How many entries from the general lead pool should we add?")]
	[Header("On Info Acquisition")]
	[Range(0f, 5f)]
	public int leadPoolData;

	[InfoBox("Created facts here are automatically also discovered on creation", EInfoBoxType.Normal)]
	public List<FactCreation> createFactsOnInformationAcquisition;

	public List<StartingLead> informationAcquisitionLeads;

	[Header("Revenge Objectives")]
	public List<RevengeObjective> revengeObjectives;

	[Header("Spawn Items")]
	public List<StartingSpawnItem> spawnItems;

	[Header("Objectives")]
	public List<Case.ResolveQuestion> resolveQuestions;

	[Header("Additonal Main Elements")]
	public List<SideMissionIntroPreset.SideMissionObjectiveBlock> additional;

	[Header("Hand-Ins")]
	[Tooltip("Scenarios that will reveal the required information for the task")]
	public List<HandInConfig> compatibleHandIns;

	[Header("Misc References")]
	public List<DialogReference> dialogReferences;

	[Header("Debug")]
	public JobPreset debugCopyFrom;

	[Button(null, EButtonEnableMode.Always)]
	public void CopyAcquisitionData()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CopyFrequencyData()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CopyStartingScenarios()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CopyItemSpawns()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CopyResolveQuestions()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CopyIntros()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CopyHandIns()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CopyAdditionalMainElements()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CopyDialogReferences()
	{
	}

	public int GetDifficultyValue()
	{
		return 0;
	}

	public int GetFrequencyForSocialCreditLevel()
	{
		return 0;
	}
}
