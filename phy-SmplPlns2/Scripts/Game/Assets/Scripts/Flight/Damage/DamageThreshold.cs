using System;
using UnityEngine;

namespace Assets.Scripts.Flight.Damage
{
	[Serializable]
	public class DamageThreshold
	{
		[SerializeField]
		[Tooltip("The name or identifier for the damage threshold.")]
		private string _name;

		[SerializeField]
		[Tooltip("The amount of damage that can be sustained before this damage threshold is reached.")]
		private float _value;

		public string Name => _name;

		public float Value => _value;

		public DamageThreshold()
		{
		}

		public DamageThreshold(float value, string name)
		{
			_value = value;
			_name = name;
		}
	}
}
