using UnityEngine;

namespace Brewery.NPC.Simple
{
	public struct ThreatInfo
	{
		public CombatIntent Intent;

		public Transform Attacker;

		public ulong AttackerId;

		public Vector3 AttackPosition;

		public float Damage;

		public float HealthPercent;

		public bool HasValidTarget => false;
	}
}
