using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Pathfinding;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.View;
using NSMedieval.View.Animals;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public class RopeAnimalGoal : Goal
	{
		private const string RopeEffectPrefab = "RopeEffect";

		private const float MaximumRopingRange = 6f;

		private const float RopeActionExecutionTime = 2f;

		private GameObject ropeEffect;

		private AnimalInstance ropedAnimal;

		public RopeAnimalGoal(Agent selfAgent)
			: base("RopeAnimalGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<AnimalInstance>());
			AddInitStep(new ThreadSequenceStep(null, FindClosestAnimal));
		}

		public override bool CanStart(bool isForced = false)
		{
			if (base.AgentOwner is CreatureBase { IsOnFire: not false })
			{
				return true;
			}
			foreach (AnimalInstance item in MonoSingleton<AnimalManager>.Instance.CanBeRopedToPen)
			{
				if (!item.IsOnFire)
				{
					return true;
				}
			}
			return false;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
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
				MonoSingleton<AnimalManager>.Instance.RefreshMarkForRoping(ropedAnimal);
				if (!ropedAnimal.HasDisposed && !ropedAnimal.IsFormingCaravan())
				{
					ropedAnimal.RopeTo(null);
					ropedAnimal.GetGoapAgent().Abort();
				}
				ropedAnimal = null;
			}
			MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
			base.EndGoalWith(condition);
			((CreatureBase)base.AgentOwner)?.RefreshTagTraversalNonWalkableTags();
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			yield return GoToActions.GoToCreatureTarget(TargetIndex.A, 3f).FailIfTargetDisposedForbidenOrNull(TargetIndex.A).FailIfTargetReservationReleases(TargetIndex.A)
				.FailAtCondition(FailWhenConditionsChange);
			GoapAction action = new GoapAction("ropeEquipAction")
			{
				CompleteMode = ActionCompleteMode.Instant,
				OnInit = delegate
				{
					CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
					((IToolAgent)base.AgentOwner).SetTool("rope_loops_item", creatureBase.GetAgentView<WorkerView>().BodyPreview.LeftHandSocket);
				}
			};
			yield return action.FailAtCondition(FailWhenConditionsChange);
			yield return GeneralActions.Wait(2f).TriggerAnimation("Roping", ActionAnimationMode.Ignore).FailAtCondition(FailWhenConditionsChange);
			GoapAction action2 = new GoapAction("RopeAction")
			{
				CompleteMode = ActionCompleteMode.Instant,
				OnInit = delegate
				{
					CreatureBase creatureBase = (CreatureBase)base.AgentOwner;
					AnimalInstance animalInstance = (ropedAnimal = GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>());
					if (((TagTraversalProvider)animalInstance.PathTraversalProvider).NotWalkableTags.HasFlag(MapNodeTags.Ladder))
					{
						((TagTraversalProvider)creatureBase.PathTraversalProvider).NotWalkableTags |= MapNodeTags.Ladder;
					}
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
							Log.Warning("Rope effect failed....  Continuing goal without effect", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\RopeAnimalGoal.cs");
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
			yield return action2.FailAtCondition(FailWhenConditionsChange);
			GoapAction action3 = new GoapAction("ropeHideAction")
			{
				CompleteMode = ActionCompleteMode.Instant,
				OnInit = delegate
				{
					((IToolAgent)base.AgentOwner).HideTool();
				}
			};
			yield return action3.FailAtCondition(FailWhenConditionsChange);
			yield return GoToActions.GoToTarget(TargetIndex.B, PathCompleteMode.ExactPosition).FailAtCondition(FailWhenConditionsChange);
			GoapAction goapAction = GeneralActions.Wait(1.65f);
			goapAction.OnComplete = delegate(ActionCompletionStatus status)
			{
				if (status == ActionCompletionStatus.Success)
				{
					ropedAnimal.PathDriver.Teleport(((CreatureBase)base.AgentOwner).GetPosition());
					MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
				}
			};
			yield return goapAction.FailAtCondition(FailWhenConditionsChange);
		}

		private bool FindClosestAnimal()
		{
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				AnimalInstance objectAs = target.GetObjectAs<AnimalInstance>();
				if (MonoSingleton<AnimalManager>.Instance.CanBeRopedToPen.Contains(objectAs) && !objectAs.PathDriver.IsClimbing && !objectAs.IsOnFire && MonoSingleton<ReservationManager>.Instance.TryReserveObject(objectAs, base.AgentOwner))
				{
					SetTarget(TargetIndex.A, target);
					if (FindPen())
					{
						return true;
					}
				}
			}
			List<TargetObject> list = PathfinderAnimals.FindAnimals((IPathfindingAgent)base.AgentOwner, MonoSingleton<AnimalManager>.Instance.CanBeRopedToPen, 1, (AnimalInstance instance) => MonoSingleton<ReservationManager>.Instance.CanReserve(instance, base.AgentOwner) && !instance.PathDriver.IsClimbing && !instance.IsOnFire);
			if (list == null || list.Count == 0)
			{
				return false;
			}
			QueueTargets(TargetIndex.A, list);
			if (!ReserveAndSelectFirstTargetFromQueue(TargetIndex.A))
			{
				return false;
			}
			return FindPen();
		}

		private bool FindPen()
		{
			AnimalInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>();
			if (objectAs.IsAtEvent())
			{
				return false;
			}
			MapNode availablePenNodeForAnimal = MonoSingleton<PenDetection>.Instance.GetAvailablePenNodeForAnimal(objectAs);
			if (availablePenNodeForAnimal == null)
			{
				return false;
			}
			SetTarget(TargetIndex.B, new TargetObject(availablePenNodeForAnimal.Position));
			return true;
		}

		private bool FailWhenConditionsChange()
		{
			AnimalInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<AnimalInstance>();
			if (objectAs == null || objectAs.HasDied)
			{
				return true;
			}
			if (!MonoSingleton<AnimalManager>.Instance.CanBeRopedToPen.Contains(objectAs))
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
			if (objectAs.IsOnFire)
			{
				return true;
			}
			if (base.AgentOwner is CreatureBase creatureBase && (creatureBase.IsOnFire || creatureBase.HasFainted))
			{
				return true;
			}
			return false;
		}
	}
}
