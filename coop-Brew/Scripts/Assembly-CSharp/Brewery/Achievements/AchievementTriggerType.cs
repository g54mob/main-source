using System;

namespace Brewery.Achievements
{
	[Serializable]
	public enum AchievementTriggerType
	{
		None = 0,
		BrewCompleted = 1,
		BrewBeerCompleted = 2,
		BrewWineCompleted = 3,
		BrewSpiritsCompleted = 4,
		StationUsed = 5,
		CatalystApplied = 6,
		LegendaryBrewCreated = 7,
		BrewTagCreated = 8,
		BrewDiscovered = 9,
		TradeMade = 10,
		FactionTradeMade = 11,
		NPCTradeMade = 12,
		CurrencyEarned = 13,
		ReputationMaxed = 14,
		BrawlWon = 15,
		BrawlLost = 16,
		BrawlParticipated = 17,
		BrawlStarted = 18,
		BrawlHitLanded = 19,
		ThiefCampCleared = 20,
		ThiefCampTierCleared = 21,
		QuestAccepted = 22,
		QuestCompleted = 23,
		LocationUnlocked = 24,
		VehiclePurchased = 25,
		BarPurchased = 26,
		BarUpgraded = 27,
		NPCConversation = 28,
		TutorialCompleted = 29,
		Custom = 30,
		WagonBurned = 31,
		CampSuppressed = 32,
		BarFullyUpgraded = 33,
		AllBuffsActive = 34,
		BrewPerfect = 35,
		AllQuestsCompleted = 36,
		StandFullyUpgraded = 37,
		EmployeeHired = 38,
		AntennaRepaired = 39,
		HouseBuilt = 40,
		NPCResurrected = 41,
		BarFactionSaleMade = 42
	}
}
