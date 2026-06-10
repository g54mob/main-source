using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "syncdisk_data", menuName = "Database/Sync Disk Preset")]
public class SyncDiskPreset : SoCustomComparison
{
	public enum Rarity
	{
		common = 0,
		medium = 1,
		rare = 2,
		veryRare = 3
	}

	public enum Manufacturer
	{
		ElGen = 0,
		Kaizen = 1,
		KensingtonIndigo = 2,
		StarchKola = 3,
		CandorNews = 4,
		BlackMarket = 5
	}

	public enum Effect
	{
		none = 0,
		streetCleaningMoney = 1,
		readingMoney = 2,
		readingSeriesBonus = 3,
		starchLoan = 4,
		starchAddiction = 5,
		reduceMedicalCosts = 6,
		legalInsurance = 7,
		accidentCover = 8,
		awakenAtHome = 9,
		increaseHealth = 10,
		increaseInventory = 11,
		increaseRegeneration = 12,
		priceModifier = 13,
		dialogChanceModifier = 14,
		doorBargeModifier = 15,
		fallDamageModifier = 16,
		sideJobPayModifier = 17,
		punchPowerModifier = 18,
		throwPowerModifier = 19,
		blockIncoming = 20,
		focusFromDamage = 21,
		noBrokenBones = 22,
		reachModifier = 23,
		holdingBlocksBullets = 24,
		fistsThreatModifier = 25,
		noBleeding = 26,
		incomingDamageModifier = 27,
		passiveIncome = 28,
		installMalware = 29,
		malwareOwnerBonus = 30,
		footSizePerception = 31,
		heightPerception = 32,
		wealthPerception = 33,
		salaryPerception = 34,
		singlePerception = 35,
		agePerception = 36,
		starchAmbassador = 37,
		starchGive = 38,
		lockpickingSpeedModifier = 39,
		lockpickingEfficiencyModifier = 40,
		triggerIllegalOnPick = 41,
		KOTimeModifier = 42,
		securityBreakerModifier = 43,
		securityGraceTimeModifier = 44,
		noSmelly = 45,
		noCold = 46,
		noTired = 47,
		kitchenPhotos = 48,
		bathroomPhotos = 49,
		illegalOpsPhotos = 50,
		playerHeightModifier = 51,
		removeSideEffect = 52,
		moneyForLocations = 53,
		moneyForDucts = 54,
		moneyForAddresses = 55,
		moneyForPasscodes = 56,
		maxSpeedModifier = 57,
		payPhoneCostModifier = 58,
		allowApartmentPurchases = 59,
		apartmentStatusReset = 60,
		allowedAtCrimeScenes = 61,
		spookedMultiplier = 62,
		trespassGraceModifier = 63,
		guestPassIssueModifier = 64,
		fastTravelToApartment = 65,
		fastTravelFromApartment = 66,
		fastTravelUsingSignage = 67,
		allowedInEchelons = 68,
		disableLoitering = 69
	}

	public enum UpgradeEffect
	{
		none = 0,
		modifyEffect = 1,
		bothConfigurations = 2,
		readingSeriesBonus = 3,
		reduceUninstallCost = 4,
		reduceMedicalCosts = 5,
		accidentCover = 6,
		legalInsurance = 7,
		awakenAtHome = 8,
		increaseHealth = 9,
		increaseInventory = 10,
		increaseRegeneration = 11,
		priceModifier = 12,
		dialogChanceModifier = 13,
		doorBargeModifier = 14,
		fallDamageModifier = 15,
		sideJobPayModifier = 16,
		punchPowerModifier = 17,
		throwPowerModifier = 18,
		blockIncoming = 19,
		focusFromDamage = 20,
		noBrokenBones = 21,
		reachModifier = 22,
		holdingBlocksBullets = 23,
		fistsThreatModifier = 24,
		noBleeding = 25,
		incomingDamageModifier = 26,
		passiveIncome = 27,
		installMalware = 28,
		malwareOwnerBonus = 29,
		footSizePerception = 30,
		heightPerception = 31,
		wealthPerception = 32,
		removeSideEffect = 33,
		salaryPerception = 34,
		singlePerception = 35,
		agePerception = 36,
		starchAmbassador = 37,
		starchGive = 38,
		lockpickingSpeedModifier = 39,
		lockpickingEfficiencyModifier = 40,
		triggerIllegalOnPick = 41,
		KOTimeModifier = 42,
		securityBreakerModifier = 43,
		securityGraceTimeModifier = 44,
		noSmelly = 45,
		noCold = 46,
		noTired = 47,
		kitchenPhotos = 48,
		bathroomPhotos = 49,
		illegalOpsPhotos = 50,
		playerHeightModifier = 51,
		moneyForLocations = 52,
		moneyForDucts = 53,
		moneyForAddresses = 54,
		moneyForPasscodes = 55,
		maxSpeedModifier = 56
	}

	public enum SpecialCase
	{
		none = 0,
		cancelSideEffect = 1
	}

	[Serializable]
	public class TraitPick
	{
		public CharacterTrait.RuleType rule;

		public List<CharacterTrait> traitList;

		[Tooltip("If this isn't true then it won't be picked for application at all.")]
		public bool mustPassForApplication;

		public int appliedFrequency;
	}

	[Tooltip("Disable this in-game completely.")]
	[BoxGroup("Disable")]
	public bool disabled;

	[Header("Configuration")]
	public int syncDiskNumber;

	public InteractablePreset interactable;

	public Rarity rarity;

	public Manufacturer manufacturer;

	public bool canBeSideJobReward;

	[Header("Usage")]
	public string mainEffect1Name;

	public string mainEffect1Description;

	public Effect mainEffect1;

	public float mainEffect1Value;

	[ShowAssetPreview(64, 64)]
	public Sprite mainEffect1Icon;

	[Space(7f)]
	public string mainEffect2Name;

	public string mainEffect2Description;

	public Effect mainEffect2;

	public float mainEffect2Value;

	[ShowAssetPreview(64, 64)]
	public Sprite mainEffect2Icon;

	[Space(7f)]
	public string mainEffect3Name;

	public string mainEffect3Description;

	public Effect mainEffect3;

	public float mainEffect3Value;

	[ShowAssetPreview(64, 64)]
	public Sprite mainEffect3Icon;

	[Header("Upgrade Option 1")]
	public List<string> option1UpgradeNameReferences;

	public List<UpgradeEffect> option1UpgradeEffects;

	public List<float> option1UpgradeValues;

	[Header("Upgrade Option 2")]
	[Space(7f)]
	public List<string> option2UpgradeNameReferences;

	public List<UpgradeEffect> option2UpgradeEffects;

	public List<float> option2UpgradeValues;

	[Header("Upgrade Option 3")]
	[Space(7f)]
	public List<string> option3UpgradeNameReferences;

	public List<UpgradeEffect> option3UpgradeEffects;

	public List<float> option3UpgradeValues;

	[Header("Effects")]
	public string sideEffectDescription;

	public Effect sideEffect;

	public float sideEffectValue;

	[Header("Costs")]
	public int price;

	public int uninstallCost;

	[Header("Ownership")]
	[Range(0f, 1f)]
	public float minimumWealthLevel;

	[Range(0f, 5f)]
	public int traitWeight;

	[ReorderableList]
	public List<TraitPick> traits;

	[Range(0f, 5f)]
	public int occupationWeight;

	[ReorderableList]
	public List<OccupationPreset> occupation;

	[Header("Debug")]
	public SyncDiskPreset copyFrom;

	[Button(null, EButtonEnableMode.Always)]
	public void CopyOwnershipStats()
	{
	}
}
