using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.Multiplayer.FlightObjects.Damage
{
	[Serializable]
	public class DamageHandler
	{
		[SerializeField]
		[Tooltip("A flag indicating that all damage of this type should be ignored.")]
		private bool _ignoreAll;

		[SerializeField]
		[FormerlySerializedAs("__damageMultiplier")]
		[Tooltip("The multiplier applied to the incoming damage.This value is defined as a curve and evaluated using a random value between 0 and 1 for each instance of damage sustained, allowing for a randomized multiplier value.The curve's 'time' axis (x) should always start at 0 and end at 1. The curve's 'value' axis (y) represents the damage multiplier value.")]
		private AnimationCurve _damageMultiplier = AnimationCurve.Constant(0f, 1f, 1f);

		[SerializeField]
		[Tooltip("If a single source of damage surpasses this threshold, it will be considered 'notable' damage. A threshold value of zero indicates NO damage will be considered 'notable'. This threshold is defined as a curve and evaluated using a random value between 0 and 1 for each instance of damage sustained, allowing for a randomized threshold value. The curve's 'time' axis (x) should always start at 0 and end at 1. The curve's 'value' axis (y) should be defined in damage units.")]
		private AnimationCurve _notableDamageThreshold = AnimationCurve.Constant(0f, 1f, 500f);

		[SerializeField]
		[Tooltip("The amount of damaged that is soaked up. Only damage that exceeds this amount will be applied to the receiver.")]
		private float _soakAmount;

		[SerializeField]
		[Range(0f, 100f)]
		[Tooltip("The percentage of damaged that is soaked up each time damage is sustained. The remainder of the damage will be applied to the receiver.")]
		private float _soakPercentage;

		public AnimationCurve DamageMultiplier
		{
			get
			{
				return _damageMultiplier;
			}
			set
			{
				_damageMultiplier = value;
			}
		}

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

		public AnimationCurve NotableDamageThreshold
		{
			get
			{
				return _notableDamageThreshold;
			}
			set
			{
				_notableDamageThreshold = value;
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

		public void Configure(float damageMultiplier = 1f, float soakAmount = 0f, float soakPercentage = 0f, float notableDamageThreshold = 0f)
		{
			_damageMultiplier = AnimationCurve.Constant(0f, 1f, damageMultiplier);
			_soakAmount = soakAmount;
			_soakPercentage = soakPercentage;
			_notableDamageThreshold = AnimationCurve.Constant(0f, 1f, notableDamageThreshold);
		}

		public virtual float GetFinalDamage(float damage)
		{
			if (IgnoreDamage())
			{
				return 0f;
			}
			float num = _damageMultiplier.Evaluate(UnityEngine.Random.value);
			damage *= num;
			damage -= damage * _soakPercentage * 0.01f + _soakAmount;
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

		public virtual bool IsNotable(float damage)
		{
			float num = _notableDamageThreshold.Evaluate(UnityEngine.Random.value);
			if (num != 0f)
			{
				return damage >= num;
			}
			return false;
		}
	}
}
