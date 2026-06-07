using System;
using UnityEngine;

namespace Assets.Scripts.Flight.Damage
{
	[Serializable]
	public class ExplosionDamageHandler : DamageHandler
	{
		[SerializeField]
		[Tooltip("The amount of damage dealt by each newton of explosive force applied to the object.")]
		private float _damagePerNewton = 1f;

		public float DamagePerNewton
		{
			get
			{
				return _damagePerNewton;
			}
			set
			{
				_damagePerNewton = value;
			}
		}

		public ExplosionDamageHandler()
			: base(DamageType.Explosion)
		{
		}

		public override float GetFinalDamage(float damage)
		{
			return base.GetFinalDamage(damage * _damagePerNewton);
		}

		public override bool IgnoreDamage()
		{
			if (!base.IgnoreDamage())
			{
				return _damagePerNewton == 0f;
			}
			return true;
		}
	}
}
