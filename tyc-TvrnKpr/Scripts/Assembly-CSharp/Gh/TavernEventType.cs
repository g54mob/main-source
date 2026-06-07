using System;

namespace Gh
{
	[Serializable]
	public enum TavernEventType
	{
		StoryEvent = 0,
		StoryMoneyEvent = 1,
		PropExploded = 2,
		PropBroke = 3,
		PropBrokeBeyondRepair = 4,
		PropInstaRepaired = 5,
		PropInstaCleaned = 6,
		PropInstaPolished = 7,
		StaffMentalBreak = 8,
		StaffGotSick = 9,
		StaffHealed = 10,
		StaffWageChange = 11,
		StaffGotHappinessBonus = 12,
		ActorStartedFight = 13,
		ItemTransformed = 14,
		ItemSpoiled = 15,
		ItemSpoilProgressChanged = 16,
		ItemStock = 17,
		ItemCrafted = 18,
		CaughtFire = 19,
		InfestationNestSpawned = 20,
		PropCoveredInFilth = 21,
		StaffHired = 22,
		StaffFired = 23,
		StaffQuit = 24,
		Achievement = 25,
		TavernContext = 26,
		LoanContext = 27,
		Trading = 28,
		TraitGained = 29,
		TraitRemoved = 30,
		TavernCleaned = 31,
		WeatherChanged = 32,
		FireExtinguished = 33,
		CollectibleCard = 34,
		WorldMapChanged = 35
	}
}
