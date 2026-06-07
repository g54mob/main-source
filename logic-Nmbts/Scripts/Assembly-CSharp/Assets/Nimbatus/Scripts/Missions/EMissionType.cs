using System;

namespace Assets.Nimbatus.Scripts.Missions
{
	[Serializable]
	public enum EMissionType
	{
		None = 0,
		DestroyTransmitter = 1,
		DestroyHives = 2,
		DestroyHivesSmall = 3,
		DestroyBoombugHives = 4,
		DestroyBoombugQueen = 5,
		DestroySnakeEggs = 8,
		CollectBioBarrels = 9,
		FreezeVolcanos = 10,
		DestroyCaves = 11,
		KillAHammerhead = 12,
		HammerheadShoal = 13,
		DestroyLaboratory = 14,
		CollectJungleRelic = 15,
		PirateAttackEvent = 16,
		RetrieveHeatCapacitor = 17,
		OverheatingCryoTank = 18,
		FireflySwarm = 19,
		OrePlanet = 20,
		AsteroidRetrieveResearch = 21,
		AsteroidCorpFracking = 22,
		BlackBoxSignal = 23,
		TutorialSurveyPlanet = 24,
		CollectFreezer = 25,
		CollectWarpDrive = 26,
		DestroySpikeyDen = 27,
		UnearthFossil = 28,
		CollectIcemanta = 29,
		CollectLavamanta = 30,
		DestroyIceLaboratory = 31,
		DestroyJumpFishNest = 32,
		DefrostFrostBombs = 33,
		DestroyPirateMinesIce = 34,
		DestroyPirateMinesJungle = 35,
		AsteroidPirateHideout = 36
	}
}
