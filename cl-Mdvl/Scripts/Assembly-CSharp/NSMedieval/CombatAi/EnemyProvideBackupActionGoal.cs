using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public sealed class EnemyProvideBackupActionGoal : CombatAiActionGoal
	{
		private const int MaxCandidatesSearchLimit = 6;

		private readonly CreatureBase creatureAgent;

		private readonly bool isRanged;

		private readonly List<IDamageDealAgent> followCandidates = new List<IDamageDealAgent>();

		private HumanoidInstance lastFollowedAgent;

		public EnemyProvideBackupActionGoal(Agent selfAgent)
			: base("EnemyProvideBackupActionGoal", selfAgent)
		{
			creatureAgent = base.CombatAgent as CreatureBase;
			isRanged = CombatUtils.GetAttackType(creatureAgent) != AttackType.Melee;
			AddInitStep(new ThreadSequenceStep(FindTargetsToFollow));
		}

		public override bool CanStart(bool isForced = false)
		{
			CreatureBase creatureBase = base.CombatAi.GetState<CreatureBase>(CombatAiState.FollowTarget);
			if (creatureBase != null && !creatureBase.HasDisposed && !creatureBase.HasFainted)
			{
				return false;
			}
			CreatureBase creatureBase2 = base.CombatAi.GetState<CreatureBase>(CombatAiState.PreferedTarget);
			if (creatureBase2 != null && !creatureBase2.HasDisposed && !creatureBase2.HasFainted)
			{
				return false;
			}
			if (creatureAgent.FollowCreature == null)
			{
				return true;
			}
			IDamageTakingAgent damageTakingAgent = creatureAgent.FollowCreature.CombatAi?.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget);
			if (damageTakingAgent == null || damageTakingAgent.HasDisposed)
			{
				return false;
			}
			return Vector3.Distance(creatureAgent.GetPosition(), creatureAgent.FollowCreature.GetPosition()) > 5f;
		}

		public override void Start()
		{
			base.Start();
			if (lastFollowedAgent != null && !lastFollowedAgent.HasDisposed)
			{
				if (!followCandidates.Contains(lastFollowedAgent))
				{
					lastFollowedAgent = followCandidates.PickRandom() as HumanoidInstance;
				}
			}
			else
			{
				lastFollowedAgent = followCandidates.PickRandom() as HumanoidInstance;
			}
			creatureAgent.SetFollowCreature(lastFollowedAgent);
			ForceGoapAgentGoal("FollowGoal");
		}

		protected override void OnEnd()
		{
			base.OnEnd();
			creatureAgent.SetFollowCreature(null);
		}

		protected override bool ShouldAbort()
		{
			if (creatureAgent.FollowCreature == null)
			{
				return true;
			}
			return base.ShouldAbort();
		}

		private bool FindTargetsToFollow()
		{
			bool finalResult = true;
			followCandidates.Clear();
			MonoSingleton<CombatAgentManager>.Instance.DamageDealAgentSafeForEach(delegate(IDamageDealAgent dealAgent)
			{
				if (!(dealAgent is HumanoidInstance humanoidInstance) || !humanoidInstance.IsEnemy() || humanoidInstance == base.CombatAgent)
				{
					return true;
				}
				if (humanoidInstance.CombatAi?.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget) == null)
				{
					return true;
				}
				if (Vector3.Distance(humanoidInstance.GetPosition(), base.CombatAgent.GetPosition()) <= 5f)
				{
					finalResult = false;
					return false;
				}
				followCandidates.Add(dealAgent);
				return followCandidates.Count <= 6;
			});
			if (finalResult)
			{
				return followCandidates.Count > 0;
			}
			return false;
		}
	}
}
