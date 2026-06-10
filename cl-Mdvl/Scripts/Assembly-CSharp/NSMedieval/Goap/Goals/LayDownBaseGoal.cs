using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public abstract class LayDownBaseGoal : Goal
	{
		protected static readonly float BedNearDistance = 2.55f;

		protected VillageMap Map;

		protected LayDownBaseGoal(string name, Agent selfAgent)
			: base(name, selfAgent, GoalInterruptMode.HigherPriority)
		{
			Map = VillageManager.ActiveVillage.Map;
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<BedComponentInstance>());
		}

		public override void Dispose()
		{
			base.Dispose();
			Map = null;
		}

		public override bool AgentTypeCheck()
		{
			if (base.AgentOwner is CreatureBase)
			{
				return base.AgentOwner is ISleepAgent;
			}
			return false;
		}

		public override bool CanStart(bool isForced = false)
		{
			CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
			if (creatureBase.IsWounded)
			{
				return !creatureBase.IsOnFire;
			}
			return false;
		}

		public override void Start()
		{
			if (GetTarget(TargetIndex.A).GetObjectAs<BedComponentInstance>() != null)
			{
				MonoSingleton<ReservationManager>.Instance.TryReserveObject(GetTarget(TargetIndex.A).GetAsReservable(), base.AgentOwner);
			}
			base.Start();
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (base.AgentOwner is IPathfindingAgent { PathDriver: not null } pathfindingAgent)
			{
				pathfindingAgent.PathDriver.IsFloatingAllowed = false;
			}
			if (base.Agent?.GoalToStart == null || !TryToFinishAnimation(base.Agent.GoalToStart))
			{
				if (MonoSingleton<GoapController>.IsInstantiated())
				{
					MonoSingleton<GoapController>.Instance.OnNextGoalPlannedEvent += OnNextGoalPlanned;
				}
				if (base.AgentOwner != null)
				{
					base.AgentOwner.OnDisposedEvent += OnAgentOwnerDestroyed;
				}
			}
			base.EndGoalWith(condition);
		}

		protected BedComponentInstance FindAndReserveBed(IGoapAgentOwner agentOwner)
		{
			HumanoidInstance humanoidInstance = (HumanoidInstance)agentOwner;
			if (CombatUtils.IsNullOrDisposed(humanoidInstance))
			{
				return null;
			}
			PooledDictionary<BedComponentInstance, int> bedsWithScore = DictionaryPool<BedComponentInstance, int>.GetJanitor();
			try
			{
				using PooledList<BedComponentInstance> pooledList = ListPool<BedComponentInstance>.GetJanitor(Map.BedComponentManager.GetBeds(BedType.Basic).Where(delegate(BedComponentInstance bed)
				{
					bool flag2 = bed.OwnerBuilding.BuildingOwnershipInfo == null || !bed.OwnerBuilding.BuildingOwnershipInfo.Occupied || bed.OwnerBuilding.BuildingOwnershipInfo.IsOwner(humanoidInstance);
					if (!CommonGoalMethods.CheckPrisonConditions(humanoidInstance, bed.OwnerBuilding.GetRoom()))
					{
						return false;
					}
					return !bed.HasDisposed && flag2 && !bed.IsUnavailable;
				}));
				using PooledList<BedComponentInstance> pooledList2 = ListPool<BedComponentInstance>.GetJanitor(Map.BedComponentManager.GetBeds(BedType.Medical).Where(delegate(BedComponentInstance bed)
				{
					bool flag2 = bed.OwnerBuilding.BuildingOwnershipInfo == null || !bed.OwnerBuilding.BuildingOwnershipInfo.Occupied || bed.OwnerBuilding.BuildingOwnershipInfo.IsOwner(humanoidInstance);
					if (!CommonGoalMethods.CheckPrisonConditions(humanoidInstance, bed.OwnerBuilding.GetRoom()))
					{
						return false;
					}
					return !bed.HasDisposed && flag2 && !bed.IsUnavailable && !bed.IsOnFire;
				}));
				pooledList.AddRange(pooledList2);
				bedsWithScore.Clear();
				foreach (BedComponentInstance item in pooledList)
				{
					bedsWithScore.Add(item, (int)(1000f * GetBedScore(item, humanoidInstance)));
				}
				pooledList.Sort((BedComponentInstance a, BedComponentInstance b) => bedsWithScore[b] - bedsWithScore[a]);
				ReservationManager instance = MonoSingleton<ReservationManager>.Instance;
				MapNode node = humanoidInstance.GetNode();
				HashSet<HumanoidInstance> faintedWorkers = MonoSingleton<WorkerManager>.Instance.FaintedWorkers;
				foreach (BedComponentInstance item2 in pooledList)
				{
					if (item2?.OwnerBuilding == null || item2.OwnerBuilding.HasDisposed)
					{
						continue;
					}
					if (!PathfinderUtil.IsPathPossible(humanoidInstance.WalkableModel, node, item2.GetNode()))
					{
						if (item2.OwnerBuilding.BuildingOwnershipInfo.IsOwner(humanoidInstance))
						{
							item2.OwnerBuilding.BuildingOwnershipInfo.ClearOwner();
						}
						continue;
					}
					bool flag = false;
					foreach (Vec3Int position in item2.Positions)
					{
						MapNode bedNode = item2.Map.GetNode(position);
						if (faintedWorkers.Any((HumanoidInstance faintedWorker) => !CombatUtils.IsNullOrDisposed(faintedWorker) && faintedWorker.GetNode() == bedNode))
						{
							flag = true;
							break;
						}
					}
					if (flag || (instance.IsReserved(item2) && !instance.TryReserveObject(item2, agentOwner)))
					{
						continue;
					}
					return item2;
				}
				return null;
			}
			finally
			{
				((IDisposable)bedsWithScore/*cast due to .constrained prefix*/).Dispose();
			}
		}

		protected virtual GoapAction LayDownAction(string animation, bool recoverSleepStat = false, TargetIndex target = TargetIndex.None)
		{
			ISleepAgent agent = (ISleepAgent)base.AgentOwner;
			GoapAction goapAction = new GoapAction("LayDown");
			TargetObject targetObject = GetTarget(target);
			BedComponentInstance bedComponentInstance = targetObject.GetObjectAs<BedComponentInstance>();
			goapAction.OnPreInit = delegate
			{
				MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
			};
			goapAction.OnInit = delegate
			{
				agent.PathDriver.IsFloatingAllowed = true;
				if (recoverSleepStat)
				{
					SleepingModifierInstance modifier = new SleepingModifierInstance();
					if (!agent.Stats.HasAttributeModifier(ModifierType.Sleeping))
					{
						agent.Stats.AddAttributeModifier(modifier);
					}
				}
				Vector3 worldPosition = GridUtils.GetWorldPosition(targetObject.ReachablePosition);
				if (targetObject.IsInitialized && bedComponentInstance != null && !bedComponentInstance.HasDisposed && !bedComponentInstance.Underwater && !bedComponentInstance.IsOnFire && CommonGoalMethods.CheckPrisonConditions(base.AgentOwner as HumanoidInstance, bedComponentInstance.GetRoom()))
				{
					if (Vector3.Distance(agent.GetPosition(), worldPosition) <= BedNearDistance)
					{
						agent.SnapToBed(bedComponentInstance);
						if (bedComponentInstance.OwnerBuilding.BuildingOwnershipInfo != null && bedComponentInstance.OwnerBuilding.BuildingOwnershipInfo.Owner == null && bedComponentInstance.BaseBuildingBlueprint.CanHaveOwner)
						{
							bedComponentInstance.OwnerBuilding.BuildingOwnershipInfo.SetOwner(agent as HumanoidInstance, bedComponentInstance.OwnerBuilding);
						}
					}
					else
					{
						MonoSingleton<ReservationManager>.Instance.ReleaseAll(base.AgentOwner);
					}
				}
			};
			goapAction.TriggerAnimation(animation, ActionAnimationMode.Ignore, isSequenced: true);
			goapAction.FailAtCondition(() => targetObject.IsInitialized && (bedComponentInstance == null || bedComponentInstance.HasDisposed || bedComponentInstance.OwnerBuilding == null || bedComponentInstance.OwnerBuilding.HasDisposed || !CommonGoalMethods.CheckPrisonConditions(base.AgentOwner as HumanoidInstance, bedComponentInstance.GetRoom())));
			return goapAction;
		}

		protected virtual GoapAction MoveToBed(TargetIndex targetIndex)
		{
			if (!GetTarget(targetIndex).IsInitialized)
			{
				return null;
			}
			BedComponentInstance instance = GetTarget(targetIndex).GetObjectAs<BedComponentInstance>();
			float biggestDistance = float.MinValue;
			instance.OwnerBuilding.ForEveryGridSpace(delegate(Vec3Int pos)
			{
				float num = Vector3.Distance(pos.ToVector3World(), ((ISleepAgent)base.AgentOwner).GetPosition());
				if (num > biggestDistance)
				{
					biggestDistance = num;
				}
				return true;
			});
			if (biggestDistance <= BedNearDistance)
			{
				return null;
			}
			return GoToActions.GoToTarget(targetIndex, PathCompleteMode.ExactPosition).FailIfTargetDisposedForbidenOrNull(targetIndex).FailIfTargetReservationReleases(targetIndex)
				.FailAtCondition(delegate
				{
					HumanoidInstance humanoidInstance = base.AgentOwner as HumanoidInstance;
					return (instance.OwnerBuilding.BuildingOwnershipInfo?.Owner != null && !instance.OwnerBuilding.BuildingOwnershipInfo.IsOwner(humanoidInstance)) || instance.IsOnFire || instance.Underwater || !CommonGoalMethods.CheckPrisonConditions(humanoidInstance, instance.GetRoom());
				});
		}

		protected virtual void OnAgentOwnerDestroyed(IDisposable disposable)
		{
			if (MonoSingleton<GoapController>.IsInstantiated())
			{
				MonoSingleton<GoapController>.Instance.OnNextGoalPlannedEvent -= OnNextGoalPlanned;
			}
		}

		protected virtual void OnNextGoalPlanned(Agent agent, Goal goal)
		{
			if (base.Agent == agent)
			{
				TryToFinishAnimation(goal);
				MonoSingleton<GoapController>.Instance.OnNextGoalPlannedEvent -= OnNextGoalPlanned;
			}
		}

		protected bool TryToFinishAnimation(Goal nextGoal)
		{
			MonoSingleton<AnimationController>.Instance.ResetTriggers(base.AgentOwner);
			if (!(nextGoal is LayDownBaseGoal) || base.AgentOwner is HumanoidInstance { WorkerBehaviour: { IsDrafting: not false } })
			{
				MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, "Sleep", value: false);
				MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
				if (GetTarget(TargetIndex.A).GetObjectAs<BedComponentInstance>() != null)
				{
					MonoSingleton<ReservationManager>.Instance.ReleaseObject(GetTarget(TargetIndex.A).GetAsReservable(), base.AgentOwner);
				}
				return true;
			}
			return false;
		}

		protected bool HasValidPreferedTarget()
		{
			if (!base.PreferredReservableHandler.HasTarget())
			{
				return false;
			}
			BedComponentInstance objectAs = base.PreferredReservableHandler.GetTarget().GetObjectAs<BedComponentInstance>();
			if (objectAs == null || objectAs.HasDisposed)
			{
				return false;
			}
			return true;
		}

		protected virtual float GetBedScore(BedComponentInstance bed, HumanoidInstance humanoidInstance)
		{
			float num = ((bed.BaseBuildingBlueprint != null) ? bed.BaseBuildingBlueprint.WealthPoints : 0f) * 2f;
			if (bed.IsOnFire)
			{
				return 0f;
			}
			if (bed != null && bed.Blueprint.BedType == BedType.Medical)
			{
				num += 5000f;
			}
			if (bed?.OwnerBuilding.BuildingOwnershipInfo?.IsOwner(humanoidInstance) == true)
			{
				num += 1000f;
			}
			return num;
		}
	}
}
