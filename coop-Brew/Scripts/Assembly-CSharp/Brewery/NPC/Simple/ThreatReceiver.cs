using System;
using Brewery.NPC.Data;
using UnityEngine;

namespace Brewery.NPC.Simple
{
	internal class ThreatReceiver
	{
		private readonly NPCContext ctx;

		private readonly SimpleNPCPersonality personality;

		private NPCHealthController healthController;

		private NPCRagdollController ragdollController;

		private Action<ThreatInfo> onThreatReceived;

		private Action onKnockedOut;

		private Action onRecovered;

		private ulong lastAttackerId;

		private Transform lastAttacker;

		private ulong _lastThreatAttackerId;

		private float _lastThreatTime;

		private const float DUPLICATE_THREAT_COOLDOWN = 0.1f;

		private string AiId => null;

		public Transform LastAttacker => null;

		public ulong LastAttackerId => 0uL;

		public ThreatReceiver(NPCContext context, SimpleNPCPersonality npcPersonality)
		{
		}

		public void Initialize(NPCHealthController health, NPCRagdollController ragdoll, Action<ThreatInfo> threatCallback, Action knockoutCallback, Action recoveryCallback)
		{
		}

		public void Cleanup()
		{
		}

		private void HandleDamageReceived(ulong attackerId, Vector3 attackPosition, float damage)
		{
		}

		private void HandleKnockout()
		{
		}

		private void HandleRecovery()
		{
		}

		private CombatIntent DetermineIntent(float damage, float healthPercent)
		{
			return default(CombatIntent);
		}

		private Transform ResolveNetworkObject(ulong networkObjectId)
		{
			return null;
		}

		public void RequestCombat(Transform target, CombatIntent intent = CombatIntent.Defend)
		{
		}

		public void ClearThreat()
		{
		}
	}
}
