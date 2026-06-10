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
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.CombatAi
{
	public class EnemyTargetWorkersAiPlanGoal : CombatAiPlanningGoal
	{
		private const long TargetProcessingLimit = 60L;

		private const float BestPathSearchLimit = 5f;

		private PathfinderAgentDriver pathfinderAgentDriver;

		private List<Tuple<IDamageTakingAgent, Path>> possibleAttackPoints = new List<Tuple<IDamageTakingAgent, Path>>();

		private List<Tuple<int, IDamageTakingAgent>> possibleTargets = new List<Tuple<int, IDamageTakingAgent>>();

		private volatile bool skipPathFinding;

		private readonly Stopwatch timeoutTimer = new Stopwatch();

		private bool noPerceptionTargetsFound;

		private int noPerceptionTargetsFoundCnt;

		private IDamageTakingAgent lastTarget;

		public EnemyTargetWorkersAiPlanGoal(Agent selfAgent)
			: base("EnemyTargetWorkersAiPlanGoal", selfAgent)
		{
			AddInitStep(new ThreadSequenceStep(null, TargetBestWorkerThread));
		}

		public override bool CanStart(bool isForced = false)
		{
			if (base.CombatAgent is HumanoidInstance humanoidInstance && humanoidInstance.IsEnemy() && humanoidInstance.EnemyBehaviour.CurrentOrder != null)
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
				lastTarget = possibleTargets[0].Item2;
				MonoSingleton<ThreadingJobSystem>.Instance.ExecuteOnMainThreadBlocking(delegate
				{
					MonoSingleton<CombatTargetManager>.Instance.SetPreferredTarget(base.CombatAgent, possibleTargets[0].Item2);
				});
				return true;
			}
			IDamageTakingAgent target = CombatAiUtils.PickBestTarget(base.CombatAgent, possibleTargets[0].Item2, possibleTargets[1].Item2);
			lastTarget = target;
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
			if (lastTarget != null && lastTarget.HasDisposed)
			{
				lastTarget = null;
			}
			noPerceptionTargetsFound = false;
			skipPathFinding = false;
			if ((base.CombatAgent.Stats.GetAttributeInstance(AttributeType.CombatPerception)?.Value ?? 0f) <= 0f)
			{
				Log.Warning("This should never happen", "C:\\GIT\\dev\\Assets\\Scripts\\Combat\\CombatAi\\Goal\\PlanningGoal\\EnemyTargetWorkersAiPlanGoal.cs");
				return false;
			}
			HashSet<IDamageDealAgent> hashSet = base.CombatAi.GetState<HashSet<IDamageDealAgent>>(CombatAiState.PerceptionHostiles);
			HashSet<IDamageDealAgent> hashSet2 = null;
			foreach (IDamageDealAgent item in hashSet)
			{
				if (item is HumanoidInstance { WorkerBehaviour: not null, HasFainted: false } && item.CombatAi.GetState<int>(CombatAiState.TargetersCount) < 8)
				{
					if (hashSet2 == null)
					{
						hashSet2 = HashSetPool<IDamageDealAgent>.Get();
					}
					hashSet2.Add(item);
				}
			}
			bool flag = CombatUtils.GetAttackType(base.CombatAgent) != AttackType.Melee;
			if (hashSet2 == null)
			{
				foreach (HumanoidInstance item2 in MonoSingleton<NPCManager>.Instance.IterateNPCs())
				{
					if (base.CombatAgent == item2 || item2.Faction != ((HumanoidInstance)base.CombatAgent).Faction)
					{
						continue;
					}
					foreach (IDamageDealAgent item3 in base.CombatAi.GetState<HashSet<IDamageDealAgent>>(CombatAiState.PerceptionHostiles))
					{
						if (item3 is HumanoidInstance { WorkerBehaviour: not null, HasFainted: false })
						{
							if (hashSet2 == null)
							{
								hashSet2 = HashSetPool<IDamageDealAgent>.Get();
							}
							hashSet2.Add(item3);
						}
					}
				}
			}
			if (hashSet2 == null)
			{
				noPerceptionTargetsFound = true;
				noPerceptionTargetsFoundCnt++;
				return true;
			}
			if (hashSet2.Count == 0)
			{
				HashSetPool<IDamageDealAgent>.Return(hashSet2);
				return false;
			}
			timeoutTimer.Restart();
			possibleAttackPoints.Clear();
			Vector3 position = base.CombatAgent.GetPosition();
			foreach (IDamageDealAgent item4 in hashSet2.OrderBy((IDamageDealAgent item) => (lastTarget != item) ? ((item.CombatAi == null || item.CombatAi.IsStateSet(CombatAiState.IsFleeing)) ? 1 : 0) : (-1)))
			{
				if (!(item4 is IDamageTakingAgent damageTakingAgent))
				{
					continue;
				}
				CreatureBase obj = damageTakingAgent as CreatureBase;
				if ((obj == null || !obj.HasFainted) && CombatUtils.IsAttackPossible(base.CombatAgent, damageTakingAgent) && CombatUtils.IsValidToFocus(base.CombatAgent, damageTakingAgent) && (!flag || !(Vector3.Distance(position, damageTakingAgent.GetPosition()) >= 50f)))
				{
					if (CombatAttackerPositioningManager.IsInAttackPosition(base.CombatAgent, damageTakingAgent))
					{
						skipPathFinding = true;
						possibleTargets.Clear();
						possibleTargets.Add(new Tuple<int, IDamageTakingAgent>(0, damageTakingAgent));
						HashSetPool<IDamageDealAgent>.Return(hashSet2);
						return true;
					}
					if (timeoutTimer.ElapsedMilliseconds > 60)
					{
						break;
					}
					Path path = MonoSingleton<CombatAttackerPositioningManager>.Instance.CreatePath(base.CombatAgent, damageTakingAgent);
					if (path != null)
					{
						possibleAttackPoints.Add(new Tuple<IDamageTakingAgent, Path>(damageTakingAgent, path));
					}
				}
			}
			HashSetPool<IDamageDealAgent>.Return(hashSet2);
			return possibleAttackPoints.Count > 0;
		}

		private bool FindBestPath()
		{
			if (noPerceptionTargetsFound)
			{
				if (noPerceptionTargetsFoundCnt < 5)
				{
					return false;
				}
				noPerceptionTargetsFoundCnt = 0;
				noPerceptionTargetsFound = false;
				possibleTargets.Clear();
				int num = 0;
				foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
				{
					if (!key.HasFainted && !key.HasDisposed && PathfinderUtil.IsPathPossible((IPathfindingAgent)base.AgentOwner, key.GetNode()))
					{
						possibleTargets.Add(new Tuple<int, IDamageTakingAgent>(num, key));
						num++;
					}
				}
				return possibleTargets.Count > 0;
			}
			noPerceptionTargetsFoundCnt = 0;
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
				int num2 = possibleTargets.FindIndex((Tuple<int, IDamageTakingAgent> tuple) => pathLength < tuple.Item1);
				Tuple<int, IDamageTakingAgent> item4 = new Tuple<int, IDamageTakingAgent>(pathLength, item3);
				if (num2 >= 0)
				{
					possibleTargets.Insert(num2, item4);
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
