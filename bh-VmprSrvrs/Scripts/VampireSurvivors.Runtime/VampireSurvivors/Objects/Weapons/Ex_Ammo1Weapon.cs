using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Interfaces;

namespace VampireSurvivors.Objects.Weapons
{
	public class Ex_Ammo1Weapon : Weapon
	{
		[SerializeField]
		private bool _multitickDamage;

		[SerializeField]
		private float _rapidFireDamageInterval;

		[SerializeField]
		private int _ticksPerRapidFire;

		private const WeaponType _counterWeaponType = WeaponType.EX_AMMO1_COUNTER;

		private Weapon _counterWeapon;

		private readonly List<RapidDamageInstance> _rapidDamageInstances;

		public virtual bool FireInTheFacedDirection => false;

		public override void DealDamage(IDamageable other, float damage)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void CheckArcanas()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
