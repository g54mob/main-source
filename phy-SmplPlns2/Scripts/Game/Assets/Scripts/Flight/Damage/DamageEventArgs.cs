using System;
using UnityEngine;

namespace Assets.Scripts.Flight.Damage
{
	public class DamageEventArgs : EventArgs
	{
		public int? PlayerId { get; }

		public float Damage { get; private set; }

		public DamageType DamageType { get; private set; }

		public Vector3? LocalNormal { get; }

		public Vector3? LocalPosition { get; }

		public float TotalDamage { get; private set; }

		public DamageEventArgs()
		{
		}

		public DamageEventArgs(DamageType type, float damage, float totalDamage, int? playerId, Vector3? localPosition, Vector3? localNormal)
		{
			DamageType = type;
			Damage = damage;
			TotalDamage = totalDamage;
			LocalPosition = localPosition;
			LocalNormal = localNormal;
			PlayerId = playerId;
		}
	}
}
