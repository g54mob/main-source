using System;

namespace Player.Stats
{
	public interface IPlayerStatsService
	{
		float AlcoholStat { get; }

		float NicotineStat { get; }

		event Action<float> AlcoholChanged;

		event Action<float> NicotineChanged;

		void SetAlcoholStat(float stat);

		void SetNicotineStat(float stat);

		void AddModToAlcohol(float value);

		void AddModToNicotine(float value);
	}
}
