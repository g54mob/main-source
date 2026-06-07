using System;
using UnityEngine;

namespace Assets.Scripts.Flight.Damage
{
	[Serializable]
	public class CollisionDamageHandler : DamageHandler
	{
		[SerializeField]
		[Tooltip("Collision damage is calculated by multiplying this amount by the dot product of the contact normal and the relative velocity between the colliding bodies.")]
		private float _relativeVelocityDamage = 1f;

		public float RelativeVelocityDamage
		{
			get
			{
				return _relativeVelocityDamage;
			}
			set
			{
				_relativeVelocityDamage = value;
			}
		}

		public CollisionDamageHandler()
			: base(DamageType.Collision)
		{
		}

		public override float GetFinalDamage(float damage)
		{
			return base.GetFinalDamage(damage * _relativeVelocityDamage);
		}

		public override bool IgnoreDamage()
		{
			if (!base.IgnoreDamage())
			{
				return _relativeVelocityDamage == 0f;
			}
			return true;
		}
	}
}
