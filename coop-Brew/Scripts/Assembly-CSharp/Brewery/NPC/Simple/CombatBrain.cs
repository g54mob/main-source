using System;
using System.Runtime.CompilerServices;
using Brewery.NPC.Data;
using UnityEngine;

namespace Brewery.NPC.Simple
{
	internal class CombatBrain
	{
		private readonly NPCContext ctx;

		private readonly INPCMotor motor;

		private readonly BarInteractor barInteractor;

		private readonly SimpleNPCPersonality personality;

		private NPCBrawlCombat combatExecutor;

		private CombatState currentState;

		private Transform currentTarget;

		private ulong currentTargetId;

		private float combatStartTime;

		private float lastDamageTime;

		private float stateTimer;

		private float fleeStartTime;

		private const float MaxCombatDuration = 60f;

		private const float FleeHomeTimeout = 30f;

		private const float CooldownDuration = 5f;

		private const float ReengageWindow = 3f;

		private const float FleeRunSpeed = 6f;

		private string AiId => null;

		public CombatState CurrentState => default(CombatState);

		public bool IsInCombat => false;

		public Transform CurrentTarget => null;

		public event Action OnCombatEnded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public CombatBrain(NPCContext context, INPCMotor agentMotor, BarInteractor bar, SimpleNPCPersonality npcPersonality)
		{
		}

		public void SetCombatExecutor(NPCBrawlCombat executor)
		{
		}

		public bool ProcessThreat(ThreatInfo threat)
		{
			return false;
		}

		public bool StartCombat(Transform target, ulong targetId, string reason)
		{
			return false;
		}

		public bool StartFlee(Transform threat, string reason)
		{
			return false;
		}

		public bool JoinBrawl(Transform target, ulong targetId)
		{
			return false;
		}

		public void StopCombat(string reason = "")
		{
		}

		public void HandleKnockout()
		{
		}

		public void Tick()
		{
		}

		private void TickCombat()
		{
		}

		private void TickFlee()
		{
		}

		private void TickCooldown()
		{
		}

		private bool IsTargetIncapacitated()
		{
			return false;
		}

		private bool ShouldFlee()
		{
			return false;
		}

		private bool SetDestination(Vector3 destination)
		{
			return false;
		}

		private bool HasArrived(float distance = 1.5f)
		{
			return false;
		}

		private void WarpHome()
		{
		}

		private void ArrivedHome()
		{
		}

		public bool CanJoinBrawl()
		{
			return false;
		}

		public void NotifyDamageReceived()
		{
		}
	}
}
