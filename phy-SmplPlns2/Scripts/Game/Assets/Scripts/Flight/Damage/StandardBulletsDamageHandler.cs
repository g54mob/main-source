using System;
using UnityEngine;

namespace Assets.Scripts.Flight.Damage
{
	[Serializable]
	public class StandardBulletsDamageHandler : DamageHandler
	{
		[SerializeField]
		[Tooltip("The multiplier applied to bullet damage for each bullet that hits the object.")]
		private float _bulletDamageMultiplier = 1f;

		public float BulletDamageMultiplier
		{
			get
			{
				return _bulletDamageMultiplier;
			}
			set
			{
				_bulletDamageMultiplier = value;
			}
		}

		public StandardBulletsDamageHandler()
			: base(DamageType.StandardBullets)
		{
		}

		public override float GetFinalDamage(float damage)
		{
			return base.GetFinalDamage(damage * _bulletDamageMultiplier);
		}

		public override bool IgnoreDamage()
		{
			if (!base.IgnoreDamage())
			{
				return _bulletDamageMultiplier == 0f;
			}
			return true;
		}
	}
}
