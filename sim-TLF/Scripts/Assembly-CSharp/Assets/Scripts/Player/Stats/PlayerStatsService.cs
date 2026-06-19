using System;
using Player.Stats;
using UnityEngine;

namespace Assets.Scripts.Player.Stats
{
	public class PlayerStatsService : IPlayerStatsService
	{
		private float _alcoholStat;

		private float _nicotineStat;

		float IPlayerStatsService.AlcoholStat => _alcoholStat;

		float IPlayerStatsService.NicotineStat => _nicotineStat;

		public event Action<float> AlcoholChanged;

		public event Action<float> NicotineChanged;

		public PlayerStatsService()
		{
			_alcoholStat = 80f;
			_nicotineStat = 70f;
		}

		void IPlayerStatsService.AddModToAlcohol(float value)
		{
			_alcoholStat = Mathf.Clamp(_alcoholStat + value * Time.deltaTime, 0f, 150f);
			this.AlcoholChanged?.Invoke(_alcoholStat);
		}

		void IPlayerStatsService.AddModToNicotine(float value)
		{
			_nicotineStat = Mathf.Clamp(_nicotineStat + value * Time.deltaTime, 0f, 150f);
			this.NicotineChanged?.Invoke(_nicotineStat);
		}

		void IPlayerStatsService.SetAlcoholStat(float stat)
		{
			_alcoholStat = stat;
		}

		void IPlayerStatsService.SetNicotineStat(float stat)
		{
			_nicotineStat = stat;
		}
	}
}
