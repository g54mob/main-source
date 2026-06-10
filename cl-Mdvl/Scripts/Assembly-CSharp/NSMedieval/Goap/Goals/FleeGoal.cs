using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.CombatAi;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class FleeGoal : Goal
	{
		private IDamageDealAgent combatAgent;

		public FleeGoal(Agent selfAgent)
			: base("FleeGoal", selfAgent)
		{
			combatAgent = base.AgentOwner as IDamageDealAgent;
			AddInitStep(new ThreadSequenceStep(() => true));
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IDamageTakingAgent;
		}

		public override bool CanStart(bool isForced = false)
		{
			bool flag = ((IDamageDealAgent)base.AgentOwner).CombatAi?.GetState<bool>(CombatAiState.IsFleeing) ?? false;
			return !combatAgent.HasDiedOrFainted && flag;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
			{
				base.Agent?.DelayNextTick(1f);
			});
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			float minInclusive = 15f;
			float maxInclusive = 29f;
			IDamageDealAgent damageDealAgent = combatAgent;
			if (damageDealAgent != null && damageDealAgent.CombatAi != null)
			{
				CombatAiAgent combatAi = combatAgent.CombatAi;
				if (combatAi.TryGetState<float>(CombatAiState.MinFleeDistance, out var value))
				{
					minInclusive = value;
				}
				if (combatAi.TryGetState<float>(CombatAiState.MinFleeDistance, out var value2))
				{
					maxInclusive = value2;
				}
			}
			GoapAction goapAction = GoToActions.FleeFromEnemy(Random.Range(minInclusive, maxInclusive));
			goapAction.OnInit = delegate
			{
				MonoSingleton<CombatController>.Instance.OnFleeStart(base.AgentOwner as IDamageCommonAgent);
			};
			goapAction.OnComplete = delegate
			{
				if (base.AgentOwner != null && !base.AgentOwner.HasDisposed)
				{
					MonoSingleton<CombatController>.Instance.OnFleeStop(base.AgentOwner as IDamageCommonAgent);
				}
			};
			goapAction.WithPopupText(TargetIndex.None, MonoSingleton<LocalizationController>.Instance.GetText("running_away", GetWorkerInstance()), ColorUtils.GetColor("green"));
			goapAction.WithMovementSpeedMultiplier((base.AgentOwner is AnimalInstance) ? 1.4f : 1.1f);
			yield return goapAction;
			IGoapAgentOwner agentOwner = base.AgentOwner;
			AnimalInstance animal = agentOwner as AnimalInstance;
			if (animal == null)
			{
				yield break;
			}
			yield return new GoapAction("AnimalFleeReset")
			{
				CompleteMode = ActionCompleteMode.Instant,
				OnInit = delegate
				{
					if (animal != null)
					{
						if (MonoSingleton<CombatTargetManager>.Instance.GetFirstPreferedAttacker(animal) == null)
						{
							animal.CombatAi?.SetState(CombatAiState.IsFleeing, false);
						}
						if (Random.value >= 0.4f)
						{
							animal.CombatAi?.SetState(CombatAiState.IsFleeing, false);
						}
					}
				}
			};
		}

		private HumanoidInstance GetWorkerInstance()
		{
			if (base.AgentOwner is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
			{
				return humanoidInstance;
			}
			return null;
		}
	}
}
