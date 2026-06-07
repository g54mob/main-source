using System;
using UnityEngine;

namespace Assets.Scripts.Flight.Damage
{
	[Serializable]
	public class DamageHandler
	{
		[SerializeField]
		[Tooltip("A flag indicating that all damage of this type should be ignored.")]
		private bool _ignoreAll;

		[SerializeField]
		[Tooltip("The amount of damaged that is soaked up. Only damage that exceeds this amount will be applied to the receiver.")]
		private float _soakAmount;

		[SerializeField]
		[Range(0f, 100f)]
		[Tooltip("The percentage of damaged that is soaked up each time damage is sustained. The remainder of the damage will be applied to the receiver.")]
		private float _soakPercentage;

		public DamageType DamageType { get; private set; }

		public bool IgnoreAll
		{
			get
			{
				return _ignoreAll;
			}
			set
			{
				_ignoreAll = value;
			}
		}

		public float SoakAmount
		{
			get
			{
				return _soakAmount;
			}
			set
			{
				_soakAmount = value;
			}
		}

		public float SoakPercentage
		{
			get
			{
				return _soakPercentage;
			}
			set
			{
				_soakPercentage = value;
			}
		}

		public DamageHandler(DamageType type)
		{
			DamageType = type;
		}

		public virtual float GetFinalDamage(float damage)
		{
			if (IgnoreAll)
			{
				return 0f;
			}
			damage -= damage * SoakPercentage * 0.01f + SoakAmount;
			if (!(damage < 0f))
			{
				return damage;
			}
			return 0f;
		}

		public virtual bool IgnoreDamage()
		{
			if (!_ignoreAll)
			{
				return _soakPercentage >= 100f;
			}
			return true;
		}
	}
}
