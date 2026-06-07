using System;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects.Damage
{
	[Serializable]
	public class DamageLevel
	{
		[SerializeField]
		[Tooltip("The amount of damage that can be sustained before this damage level is reached.")]
		private short _damage;

		private int _level;

		[SerializeField]
		[Tooltip("The name or identifier for the damage level.")]
		private string _name;

		public short Damage => _damage;

		public int Level => _level;

		public string Name => _name;

		public DamageLevel()
		{
		}

		public DamageLevel(short value, string name)
		{
			_damage = value;
			_name = name;
		}

		public void Initialize(int level)
		{
			_level = level;
		}
	}
}
