using System;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	public enum GameEventOptionEffect
	{
		None = 0,
		NewWorker = 1,
		PossibleRaid = 2,
		NegativeMood = 3,
		PositiveMood = 4,
		RaidImminent = 5,
		AnimalRaidImminent = 6,
		Spring = 7,
		Summer = 8,
		Autumn = 9,
		Winter = 10,
		AgentsLeaving = 11
	}
}
