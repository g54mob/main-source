using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.View;
using NSMedieval.View.Animals;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class ReleaseAnimalGoal : Goal
	{
		private const string RopeEffectPrefab = "RopeEffect";

		private const float MaximumRopingRange = 6f;

		private List<MapNode> borderNodes;

		private GameObject ropeEffect;

		private AnimalInstance ropedAnimal;

		public ReleaseAnimalGoal(Agent selfAgent)
			: base("ReleaseAnimalGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<AnimalInstance>());
			AddInitStep(new ThreadSequenceStep(null, FindClosestAnimal));
			AddInitStep(new ThreadSequenceStep(null, CalculateReleasePoint));
		}

		public override bool CanStart(bool isForced = false)
		{
			if (MonoSingleton<AnimalManager>.IsInstantiated())
			{
				return MonoSingleton<AnimalManager>.Instance.HasAnimalWithOrder(AnimalOrderType.Release);
			}
			return false;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is IHarvestAgent;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (ropeEffect != null)
			{
				Object.Destroy(ropeEffect);
				ropeEffect = null;
			}
			if (ropedAnimal != null)
			{
				ropedAnimal.GetGoapAgent()?.StartTicker();
				MonoSingleton<AnimalManager>.Instance.RefreshMarkForRoping(ropedAnimal);
				ropedAnimal.RopeTo(null);
				if (condition == GoalCondition.Succeeded)
				{
					ropedAnimal.ResetWalkableModel();
				}
				ropedAnimal.GetGoapAgent().Abort();
				ropedAnimal = null;
			}
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToCreatureTarget(TargetIndex.A, 3f).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(() => !IsReleasePointReachable() || FailWhenConditionsChange());
			yield return GeneralActions.Wait(3f).TriggerAnimation("IdleHappy", ActionAnimationMode.Ignore).FailAtCondition(() => !IsReleasePointReachable() || FailWhenConditionsChange());
			GoapAction goapAction = new GoapAction("RopeAction")
			{
				CompleteMode = ActionCompleteMode.Instant,
				OnInit = delegate
				{
					CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
					AnimalInstance animalInstance = (ropedAnimal = GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>());
					animalInstance.SetWalkableModel(creatureBase.WalkableModel);
					GameObject byAddress = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("RopeEffect");
					if (byAddress == null)
					{
						animalInstance.RopeTo((IGoapTargetable)base.AgentOwner);
					}
					else
					{
						ropeEffect = Object.Instantiate(byAddress);
						RopeEffect componentInChildren = ropeEffect.GetComponentInChildren<RopeEffect>();
						if (componentInChildren == null)
						{
							Log.Warning("Rope effect failed....  Continuing goal without effect", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\ReleaseAnimalGoal.cs");
						}
						else
						{
							componentInChildren.SetStart(creatureBase.GetAgentView<WorkerView>().RopeHookBone);
							GameObject ropeHookBone = animalInstance.GetAgentView<AnimalView>().RopeHookBone;
							if (ropeHookBone == null)
							{
								componentInChildren.SetTarget(animalInstance);
							}
							else
							{
								componentInChildren.SetTarget(ropeHookBone.transform);
							}
						}
						animalInstance.RopeTo((IGoapTargetable)base.AgentOwner);
					}
				}
			};
			goapAction.FailAtCondition(() => !IsReleasePointReachable() || FailWhenConditionsChange());
			yield return goapAction;
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).FailAtCondition(() => !IsReleasePointReachable() || FailWhenConditionsChange());
			GoapAction goapAction2 = GeneralActions.Wait(1.65f);
			goapAction2.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status == ActionCompletionStatus.Success)
				{
					ropedAnimal.RopeTo(null);
					ropedAnimal.SetAnimalType(AnimalType.Wild);
					MonoSingleton<AnimalController>.Instance.MarkForOrder(AnimalOrderType.None, ropedAnimal);
				}
			};
			goapAction2.FailAtCondition(() => !IsReleasePointReachable() || FailWhenConditionsChange());
			yield return goapAction2;
		}

		private bool FindClosestAnimal()
		{
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				AnimalInstance objectAs = target.GetObjectAs<AnimalInstance>();
				if (objectAs.OrderType == AnimalOrderType.Release && (objectAs.AnimalType == AnimalType.Domestic || objectAs.AnimalType == AnimalType.Pet) && !objectAs.IsFormingCaravan() && !objectAs.PathDriver.IsClimbing && MonoSingleton<ReservationManager>.Instance.TryReserveObject(target.GetAsReservable(), base.AgentOwner))
				{
					SetTarget(TargetIndex.A, target);
					return true;
				}
			}
			List<TargetObject> list = PathfinderAnimals.FindAnimals((IPathfindingAgent)base.AgentOwner, MonoSingleton<AnimalManager>.Instance.Animals.Keys.Where((AnimalInstance x) => x.OrderType == AnimalOrderType.Release && (x.AnimalType == AnimalType.Domestic || x.AnimalType == AnimalType.Pet) && !x.IsFormingCaravan() && !x.PathDriver.IsClimbing), 1);
			if (list == null || list.Count == 0)
			{
				return false;
			}
			QueueTargets(TargetIndex.A, list);
			return ReserveAndSelectFirstTargetFromQueue(TargetIndex.A);
		}

		private bool CalculateReleasePoint()
		{
			IPathfindingAgent pathfindingAgent = (IPathfindingAgent)base.AgentOwner;
			borderNodes = MonoSingleton<World>.Instance.GetAllowedAreaBorderNodes;
			MapNode[] array = borderNodes.ToArray();
			foreach (MapNode mapNode in array)
			{
				if (!PathfinderUtil.IsPathPossible(pathfindingAgent, mapNode))
				{
					borderNodes.Remove(mapNode);
				}
			}
			if (borderNodes.Count == 0)
			{
				return false;
			}
			IOrderedEnumerable<MapNode> source = borderNodes.OrderBy((MapNode x) => Vec3Int.Distance(pathfindingAgent.GetPosition(), x.Position));
			SetTarget(TargetIndex.B, new TargetObject(source.First().Position));
			return true;
		}

		private bool FailWhenConditionsChange()
		{
			AnimalInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>();
			if (CombatUtils.IsNullOrDisposed(objectAs))
			{
				return true;
			}
			if (objectAs.OrderType != AnimalOrderType.Release)
			{
				return true;
			}
			if (objectAs.IsFormingCaravan())
			{
				return true;
			}
			if (objectAs.PathDriver.IsClimbing)
			{
				return true;
			}
			if (objectAs.GetNode().Tag.HasFlag(MapNodeTags.Ladder))
			{
				return true;
			}
			return MonoSingleton<CombatTargetManager>.Instance.CountPreferedAttackers(objectAs) > 0;
		}

		private bool IsReleasePointReachable()
		{
			return PathfinderUtil.IsPathPossible((IPathfindingAgent)base.AgentOwner, GetTarget(TargetIndex.B).ReachablePosition);
		}
	}
}
