using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects
{
	public class DebuffZoneFlexible : DamageZoneFlexible
	{
		public enum DebuffType
		{
			SLOW = 0,
			MONEY_DRAIN = 1
		}

		private DebuffType _debuffZoneType;

		private float _slowAmount;

		private float _moneyDrainAmount;

		private List<VampireSurvivors.Objects.Characters.CharacterController> _currentlyDebuffedPlayers;

		public static DebuffZoneFlexible CreateDebuffZone(Camera targetCamera)
		{
			return null;
		}

		public void InitDebuffZoneBehaviour(DebuffType debuffType, float debuffValue)
		{
		}

		protected override void UpdatePlayerEffects()
		{
		}

		private void HandleSlowDebuff(List<VampireSurvivors.Objects.Characters.CharacterController> players)
		{
		}

		private void HandleMoneyDrain(List<VampireSurvivors.Objects.Characters.CharacterController> players)
		{
		}

		protected override void Despawn()
		{
		}
	}
}
