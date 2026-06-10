using NSEipix;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public class OnHitAiReaction : CombatAiReaction
	{
		private bool isDisabled;

		public OnHitAiReaction(CombatAiAgent agent)
			: base(agent)
		{
		}

		public override void OnHitBlocked(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			OnHit(deal, take);
		}

		public override void OnDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			OnHit(deal, take);
		}

		private void OnHit(IDamageDealAgent deal, IDamageTakingAgent take)
		{
			if (isDisabled || take != base.CombatAgent || !CombatUtils.IsAlive(deal) || !CombatUtils.IsAlive(take) || base.CombatAi == null || base.CombatAi.HasDisposed)
			{
				return;
			}
			IDamageTakingAgent currentTarget = base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget);
			if (currentTarget == null)
			{
				currentTarget = base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.NextTarget);
			}
			if (currentTarget == deal || (currentTarget != null && ((IDamageTakingAgent)deal).DamageAgentType == take.DamageAgentType && (deal.CombatAi == null || deal.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget) != base.CombatAgent)) || (base.CombatAgent is HumanoidInstance humanoidInstance && humanoidInstance.IsWorker() && base.CombatAgent.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.LastAttackOrderTarget) == currentTarget) || (base.CombatAgent is AnimalInstance animalInstance && Random.value > animalInstance.Stats.GetAttributeInstance(AttributeType.HuntingRetaliateChance)?.Value))
			{
				return;
			}
			if (CombatUtils.GetAttackType(base.CombatAgent) == AttackType.Melee && CombatUtils.GetAttackType(deal) != AttackType.Melee)
			{
				Path path = null;
				MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(delegate
				{
					path = MonoSingleton<CombatAttackerPositioningManager>.Instance.CreatePath(base.CombatAgent, deal as IDamageTakingAgent);
					return path != null;
				}, delegate(bool result)
				{
					if (result)
					{
						isDisabled = true;
						MonoSingleton<PathProcessorManager>.Instance.ScheduleProcessPath(path);
						path.OnCalculationsDoneEvent += delegate(Path path2)
						{
							MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
							{
								Path.ReleasePath(path);
								isDisabled = false;
							});
							if (path2.State == PathState.Calculated && !base.CombatAi.IsStateSet(CombatAiState.NextTarget))
							{
								IDamageTakingAgent damageTakingAgent2 = CombatAiUtils.PickBestTarget(base.CombatAgent, (IDamageTakingAgent)deal, currentTarget);
								if (damageTakingAgent2 != currentTarget)
								{
									base.CombatAi.SetState(CombatAiState.NextTarget, damageTakingAgent2);
								}
							}
						};
					}
				});
			}
			else
			{
				IDamageTakingAgent damageTakingAgent = CombatAiUtils.PickBestTarget(base.CombatAgent, (IDamageTakingAgent)deal, currentTarget);
				if (damageTakingAgent != currentTarget)
				{
					base.CombatAi.SetState(CombatAiState.NextTarget, damageTakingAgent);
				}
			}
		}
	}
}
