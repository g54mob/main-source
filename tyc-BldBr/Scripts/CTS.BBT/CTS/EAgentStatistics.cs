using UnityEngine;

namespace CTS
{
	[InspectorOrder(InspectorSort.ByName, InspectorSortDirection.Ascending)]
	public enum EAgentStatistics
	{
		Health = 0,
		Level = 1,
		Experience = 2,
		[InspectorName("Characteristics / Strenght")]
		Strenght = 3,
		[InspectorName("Characteristics / Speed")]
		Speed = 4,
		[InspectorName("Characteristics / Intellect")]
		Intellect = 5,
		[InspectorName("Characteristics / Charisma")]
		Charisma = 6,
		Satisfaction = 7,
		[InspectorName("Hunger / Hunger")]
		Hunger = 8,
		WageSatisfaction = 9,
		[InspectorName("Fun / Fun")]
		Fun = 10,
		Environment = 11,
		Thirst = 12,
		[InspectorName("Bladder / Bladder")]
		Bladder = 13,
		Social = 14,
		[InspectorName("Alcohol/Alcohol")]
		Alcohol = 15,
		[InspectorName("Hunger / Hunger Daily Loss")]
		HungerDailyLoss = 16,
		[InspectorName("Alcohol/Alcohol Daily Loss")]
		AlcoholDailyLoss = 17,
		[InspectorName("Bladder / Bladder Daily Loss")]
		BladderDailyLoss = 18,
		SocialDailyLoss = 19,
		[InspectorName("Fun / FunDailyLoss")]
		FunDailyLoss = 20,
		ThirstDailyLoss = 21,
		[InspectorName("Characteristics gain per level / Strenght Gain Per Level")]
		StrenghtGainPerLevel = 22,
		[InspectorName("Characteristics gain per level / Speed Gain Per Level")]
		SpeedGainPerLevel = 23,
		[InspectorName("Characteristics gain per level / Intellect Gain Per Level")]
		IntellectGainPerLevel = 24,
		[InspectorName("Characteristics gain per level / Charisma Gain Per Level")]
		CharismaGainPerLevel = 25,
		ExperienceMultiplicator = 26,
		StealthMultiplicator = 27,
		BloodConsumptionMultiplicator = 28,
		NeedsThresholds = 29,
		[InspectorName("Bladder / Start Action Toilet")]
		ToiletBladderStartAction = 30,
		[InspectorName("Furnitures / Toilet / Toilet Dirtiness")]
		ToiletDirtiness = 31,
		[InspectorName("AbandonedBody / AbandonedAfterXDays")]
		AbandonedAfterXDays = 32,
		[InspectorName("AbandonedBody / AbandonedVigilance")]
		AbandonedVigilance = 33,
		[InspectorName("Alcohol/Vomit Chance")]
		VomitChance = 34,
		[InspectorName("Alcohol/Vomit Threshold")]
		VomitThreshold = 35,
		EnvironmentCheck = 36,
		HunterBaseHitChance = 37,
		HunterLevelHitChanceDecrease = 38,
		DeathPrestigeLoss = 39,
		[InspectorName("Bladder / Pee Dance Threshold")]
		ToiletBladderPeeDanceThreshold = 40,
		SlipChance = 41,
		TeleportMinDistance = 42,
		TeleportCooldownReduction = 43,
		InvisibilityDuration = 45,
		InvisibilityDurationLeveling = 44,
		HostileDetectionDistance = 46,
		HostileDetectionDistanceLeveling = 47,
		HunterReaperHitChanceMultiplier = 48,
		HungerAttackBaseChance = 49,
		HungerAttackThreshold = 50,
		[InspectorName("Hunger / Hunger Daily Loss Multiplicator")]
		HungerDailyLossMultiplicator = 51,
		[InspectorName("Salary / Salary")]
		Salary = 52,
		[InspectorName("Salary / Salary Multiplicator")]
		SalaryMultiplicator = 53,
		[InspectorName("Fun / Fun Daily Loss Multiplicator")]
		FunDailyLossMultiplicator = 54,
		[InspectorName("Worker / Debuffs Amount")]
		DebuffsAmount = 55,
		[InspectorName("Worker / Specializations Amount")]
		SpecializationsAmount = 56,
		[InspectorName("Worker / Buffs Amount")]
		BuffsAmount = 57
	}
}
