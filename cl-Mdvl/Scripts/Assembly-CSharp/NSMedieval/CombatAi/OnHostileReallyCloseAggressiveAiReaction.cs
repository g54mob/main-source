using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.CombatAi
{
	public class OnHostileReallyCloseAggressiveAiReaction : CombatAiReaction
	{
		private bool isDisabled;

		public OnHostileReallyCloseAggressiveAiReaction(CombatAiAgent agent)
			: base(agent)
		{
		}

		internal override void Refresh()
		{
			base.Refresh();
			if (isDisabled || base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.PreferedTarget) is CreatureBase || base.CombatAi.IsStateSet(CombatAiState.NextTarget))
			{
				return;
			}
			IDamageTakingAgent nearestHostile = base.CombatAi.GetState<IDamageTakingAgent>(CombatAiState.NearestHostile);
			if (CombatUtils.IsNullOrDisposed(nearestHostile) || nearestHostile is BaseBuildingInstance || !CombatUtils.IsAttackPossible(base.CombatAgent, nearestHostile) || !PathfinderUtil.IsPathPossible((IPathfindingAgent)base.CombatAgent, nearestHostile.GetNode()) || !CombatUtils.IsValidToFocus(base.CombatAgent, nearestHostile) || (nearestHostile is AnimalInstance animalInstance && ((animalInstance.CombatAi != null && !animalInstance.CombatAi.IsStateSet(CombatAiState.IsAggressive)) || animalInstance.CombatAi == null)) || (nearestHostile is CreatureBase creatureBase && (creatureBase.HasFainted || (creatureBase.CombatAi != null && creatureBase.CombatAi.IsStateSet(CombatAiState.IsFleeing)))))
			{
				return;
			}
			Path path = null;
			MonoSingleton<ThreadingJobSystem>.Instance.QueueTask(delegate
			{
				path = MonoSingleton<CombatAttackerPositioningManager>.Instance.CreatePath(base.CombatAgent, nearestHostile);
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
							base.CombatAi.SetState(CombatAiState.NextTarget, nearestHostile);
						}
					};
				}
			});
		}
	}
}
