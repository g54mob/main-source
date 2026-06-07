using Brewery.NPC;
using Brewery.NPC.Simple;
using UnityEngine;

namespace Brewery.Bar.Brawl.States
{
	public class BrawlStateContext
	{
		public NPCBrawlAgent Brain { get; }

		public NPCBrawlCombat CombatMotor { get; }

		public INPCMotor Motor { get; }

		public Animator Animator { get; }

		public NPCHealthController HealthController { get; }

		public NPCRagdollController RagdollController { get; }

		public SimpleNPCController NPCController { get; }

		public Transform Transform => null;

		public ulong NetworkObjectId => 0uL;

		public bool ShowDebugLogs { get; set; }

		public BarBrawlManager Coordinator { get; set; }

		public Transform TargetTransform { get; set; }

		public NPCBrawlAgent TargetBrawlAgent { get; set; }

		public bool HasValidTarget => false;

		public float DistanceToTarget => 0f;

		public Vector3 WatchingBrawlPosition { get; set; }

		public bool IsWatchingBrawl { get; set; }

		public bool IsInSelfDefenseMode { get; set; }

		public float SelfDefenseLastDamageTime { get; set; }

		public Vector3 HomePosition { get; set; }

		public float FleeStartTime { get; set; }

		public float PersonalCooldownEndTime { get; set; }

		public float NextSpectatorJoinCheck { get; set; }

		public float NextSpectatorDetectionCheck { get; set; }

		public BarBrawlConfig Config { get; set; }

		public float CandidateTimeout => 0f;

		public float SpectatorTimeout => 0f;

		public float FleeTimeout => 0f;

		public float SelfDefenseTimeout => 0f;

		public float SpectatorDetectionRange => 0f;

		public float SpectatorDetectionInterval => 0f;

		public BrawlStateContext(NPCBrawlAgent brain, NPCBrawlCombat combatMotor, INPCMotor motor, Animator animator, NPCHealthController healthController, NPCRagdollController ragdollController, SimpleNPCController npcController, bool showDebugLogs = false)
		{
		}

		public bool IsNearBar()
		{
			return false;
		}

		public bool IsMotorReady()
		{
			return false;
		}

		public void EnsureMotorReady()
		{
		}

		public void StopNavigation()
		{
		}

		public void ResumeNavigation()
		{
		}

		public bool SetDestination(Vector3 destination)
		{
			return false;
		}

		public bool IsNavAgentReady()
		{
			return false;
		}

		public void EnsureNavAgentReady()
		{
		}

		public void Log(string message)
		{
		}

		public void LogWarning(string message)
		{
		}

		public void LogError(string message)
		{
		}
	}
}
