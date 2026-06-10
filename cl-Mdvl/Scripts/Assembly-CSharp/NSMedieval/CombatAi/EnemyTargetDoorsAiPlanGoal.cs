using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Tutorial;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.CombatAi
{
	public class EnemyTargetDoorsAiPlanGoal : CombatAiPlanningGoal
	{
		private PathfinderAgentDriver pathfinderAgentDriver;

		private Cooldown startDelay;

		public EnemyTargetDoorsAiPlanGoal(Agent selfAgent)
			: base("EnemyTargetDoorsAiPlanGoal", selfAgent)
		{
			startDelay = Cooldown.FromNowMinutes(10, TutorialManager.IsTutorialActive);
			AddInitStep(new ThreadSequenceStep(null, FindBestAttackPoint));
		}

		public override bool CanStart(bool isForced = false)
		{
			if (!startDelay.HasEnded)
			{
				return false;
			}
			if (base.CombatAgent is HumanoidInstance { ActiveBehaviour: EnemyBehaviour { CurrentOrder: not null } })
			{
				return false;
			}
			if (pathfinderAgentDriver == null)
			{
				pathfinderAgentDriver = ((IPathfindingAgent)base.AgentOwner).PathDriver;
			}
			if (pathfinderAgentDriver != null && !base.CombatAi.IsStateSet(CombatAiState.Fainted))
			{
				return !base.CombatAi.IsStateSet(CombatAiState.PreferedTarget);
			}
			return false;
		}

		private bool FindBestAttackPoint()
		{
			ReadOnlyDictionary<HumanoidInstance, NSMedieval.View.WorkerView>.KeyCollection keys = MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys;
			List<HumanoidInstance> list = ListPool<HumanoidInstance>.Get();
			foreach (HumanoidInstance item in keys)
			{
				if (!item.HasDisposed && !item.HasFainted && item.CombatAi != null && !item.CombatAi.IsStateSet(CombatAiState.IsFleeing))
				{
					list.Add(item);
				}
			}
			if (list.Count == 0)
			{
				ListPool<HumanoidInstance>.Return(list);
				return false;
			}
			while (list.Count > 0)
			{
				P2PPath p2PPath = P2PPath.Construct((IPathfindingAgent)base.AgentOwner, list.First().GetNode().Position);
				if (p2PPath == null)
				{
					return false;
				}
				p2PPath.TraversalProvider = PathTraversalProvider.DefaultProvider;
				list.RemoveAt(0);
				MonoSingleton<PathProcessorManager>.Instance.InstantProcessPath(p2PPath);
				if (p2PPath.State != PathState.Calculated)
				{
					Path.ReleasePath(p2PPath);
					continue;
				}
				DoorComponentInstance door = CombatAiUtils.GetFirstReachableDoor(p2PPath, base.CombatAgent);
				if (door == null || !CombatUtils.IsAttackPossible(base.CombatAgent, door.OwnerBuilding))
				{
					Path.ReleasePath(p2PPath);
					continue;
				}
				MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThreadBlocking(delegate
				{
					MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget((IDamageDealAgent)base.AgentOwner, door.OwnerBuilding);
				});
				Path.ReleasePath(p2PPath);
				ListPool<HumanoidInstance>.Return(list);
				return true;
			}
			ListPool<HumanoidInstance>.Return(list);
			return false;
		}
	}
}
