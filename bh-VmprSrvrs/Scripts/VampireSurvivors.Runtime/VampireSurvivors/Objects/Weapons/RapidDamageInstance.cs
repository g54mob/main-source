using UnityEngine;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Objects.Weapons
{
	public struct RapidDamageInstance
	{
		public float RemainingDamage;

		private readonly Weapon _parentWeapon;

		public readonly EnemyController Target;

		private readonly float DamagePerHit;

		private readonly float DamageInterval;

		private float _timeUntilNextDamage;

		public RapidDamageInstance(Weapon parentWeapon, EnemyController target, float remainingDamage, float damagePerHit, float damageInterval)
		{
			RemainingDamage = 0f;
			_parentWeapon = null;
			Target = null;
			DamagePerHit = 0f;
			DamageInterval = 0f;
			_timeUntilNextDamage = 0f;
		}

		public RapidDamageInstance Update(float deltaTime, SignalBus signalBus, bool showDamageNumbers)
		{
			return default(RapidDamageInstance);
		}

		private void DoDamage(float damageAmount, Vector3 damagePosition)
		{
		}
	}
}
