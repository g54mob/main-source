using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public class MeleeEnemyTargetGlobalWorkersAiPlanGoal : CombatAiPlanningGoal
	{
		private const long TargetProcessingLimit = 24L;

		private const float BestPathSearchLimit = 5f;

		private PathfinderAgentDriver pathfinderAgentDriver;

		private List<Tuple<IDamageTakingAgent, Path>> possibleAttackPoints = new List<Tuple<IDamageTakingAgent, Path>>();

		private List<Tuple<int, IDamageTakingAgent>> possibleTargets = new List<Tuple<int, IDamageTakingAgent>>();

		private volatile bool skipPathFinding;

		private readonly Stopwatch timeoutTimer = new Stopwatch();

		public MeleeEnemyTargetGlobalWorkersAiPlanGoal(Agent selfAgent)
			: base("MeleeEnemyTargetGlobalWorkersAiPlanGoal", selfAgent)
		{
			AddInitStep(new ThreadSequenceStep(null, TargetBestWorkerThread));
		}

		public override bool CanStart(bool isForced = false)
		{
			if (base.CombatAgent is HumanoidInstance { ActiveBehaviour: EnemyBehaviour { CurrentOrder: not null } })
			{
				return false;
			}
			if (pathfinderAgentDriver == null)
			{
				pathfinderAgentDriver = ((IPathfindingAgent)base.AgentOwner).PathDriver;
			}
			if (!base.CombatAi.IsStateSet(CombatAiState.Fainted) && pathfinderAgentDriver != null)
			{
				return !base.CombatAi.IsStateSet(CombatAiState.PreferedTarget);
			}
			return false;
		}

		private bool TargetBestWorkerThread()
		{
			if (!GatherAttackPositions())
			{
				return false;
			}
			if (!FindBestPath())
			{
				return false;
			}
			if (possibleTargets.Count == 1)
			{
				MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThreadBlocking(delegate
				{
					MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(base.CombatAgent, possibleTargets[0].Item2);
				});
				return true;
			}
			IDamageTakingAgent target = CombatAiUtils.PickBestTarget(base.CombatAgent, possibleTargets[0].Item2, possibleTargets[1].Item2);
			MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThreadBlocking(delegate
			{
				MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(base.CombatAgent, target);
			});
			return true;
		}

		private bool GatherAttackPositions()
		{
			if (base.CombatAi.IsStateSet(CombatAiState.PreferedTarget) || base.CombatAi.IsStateSet(CombatAiState.NextTarget))
			{
				return false;
			}
			skipPathFinding = false;
			if ((base.CombatAgent.Stats.GetAttributeInstance(AttributeType.CombatPerception)?.Value ?? 0f) <= 0f)
			{
				Log.Warning("This should never happen", "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Goal\\PlanningGoal\\MeleeEnemyTargetGlobalWorkersAiPlanGoal.cs");
				return false;
			}
			timeoutTimer.Restart();
			possibleAttackPoints.Clear();
			Vector3 selfPos = base.CombatAgent.GetPosition();
			foreach (HumanoidInstance item in from item in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys
				where !item.HasFainted
				orderby Vector3.Distance(selfPos, item.GetPosition())
				select item)
			{
				if (CombatUtils.IsNullOrDisposed(item))
				{
					continue;
				}
				if (CombatAttackerPositioningManager.IsInAttackPosition(base.CombatAgent, item))
				{
					skipPathFinding = true;
					possibleTargets.Clear();
					possibleTargets.Add(new Tuple<int, IDamageTakingAgent>(0, item));
					return true;
				}
				if (timeoutTimer.ElapsedMilliseconds > 24)
				{
					break;
				}
				if (item.CombatAi != null && !item.CombatAi.IsStateSet(CombatAiState.IsFleeing))
				{
					Path path = MonoSingleton<CombatAttackerPositioningManager>.Instance.CreatePath(base.CombatAgent, item);
					if (path != null)
					{
						possibleAttackPoints.Add(new Tuple<IDamageTakingAgent, Path>(item, path));
					}
				}
			}
			return possibleAttackPoints.Count > 0;
		}

		private bool FindBestPath()
		{
			if (skipPathFinding)
			{
				return true;
			}
			possibleTargets.Clear();
			foreach (Tuple<IDamageTakingAgent, Path> possibleAttackPoint in possibleAttackPoints)
			{
				possibleAttackPoint.Deconstruct(out var item, out var item2);
				IDamageTakingAgent item3 = item;
				Path path = item2;
				MonoSingleton<PathProcessorManager>.Instance.InstantProcessPath(path);
				if (path.State != PathState.Calculated)
				{
					Path.ReleasePath(path);
					continue;
				}
				int pathLength = path.NodePath.Count;
				int num = possibleTargets.FindIndex((Tuple<int, IDamageTakingAgent> tuple) => pathLength < tuple.Item1);
				Tuple<int, IDamageTakingAgent> item4 = new Tuple<int, IDamageTakingAgent>(pathLength, item3);
				if (num >= 0)
				{
					possibleTargets.Insert(num, item4);
				}
				else
				{
					possibleTargets.Add(item4);
				}
				if (pathLength <= 6)
				{
					foreach (Tuple<IDamageTakingAgent, Path> possibleAttackPoint2 in possibleAttackPoints)
					{
						Path.ReleasePath(possibleAttackPoint2.Item2);
					}
					return true;
				}
				if (!((float)possibleTargets.Count > 5f))
				{
					continue;
				}
				foreach (Tuple<IDamageTakingAgent, Path> possibleAttackPoint3 in possibleAttackPoints)
				{
					Path.ReleasePath(possibleAttackPoint3.Item2);
				}
				return true;
			}
			foreach (Tuple<IDamageTakingAgent, Path> possibleAttackPoint4 in possibleAttackPoints)
			{
				Path.ReleasePath(possibleAttackPoint4.Item2);
			}
			return possibleTargets.Count > 0;
		}
	}
}
