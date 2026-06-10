using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Animation;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Goap.Actions;
using NSMedieval.Pathfinding;
using NSMedieval.RoomDetection;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap.Goals
{
	public abstract class EntertainmentBaseGoal : Goal
	{
		protected VillageMap map;

		protected ReservablePosition reservablePosition;

		protected OverrideBoneAnimation overrideBoneAnimation;

		protected EntertainmentBaseGoal(string id, Agent selfAgent, GoalInterruptMode interruptMode = GoalInterruptMode.Never)
			: base(id, selfAgent, interruptMode)
		{
			map = VillageManager.ActiveVillage.Map;
			AddInitStep(new ThreadSequenceStep(null, FindEntertainmentBuildings, ReserveTargets));
		}

		public override bool CanStart(bool isForced = false)
		{
			VillageMap villageMap = map;
			if (villageMap == null)
			{
				return false;
			}
			return villageMap.EntertainmentComponentManager?.ComponentCount > 0;
		}

		public override void Dispose()
		{
			base.Dispose();
			reservablePosition = null;
			map = null;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (MonoSingleton<LoadingController>.IsApplicationIsQuitting())
			{
				return;
			}
			if (base.Agent.HasDisposed || base.AgentOwner.HasDisposed || base.AgentOwner == null || base.AgentOwner.GetTransform() == null)
			{
				base.EndGoalWith(condition);
				return;
			}
			((IToolAgent)base.AgentOwner).HideTool();
			base.EndGoalWith(condition);
			reservablePosition?.Release(base.AgentOwner);
			reservablePosition = null;
			if (!(overrideBoneAnimation == null))
			{
				overrideBoneAnimation.EndOverrideAnimation();
			}
		}

		protected virtual void SetupUsePosition(EntertainmentComponentInstance entertainmentComponentInstance, HumanoidInstance humanoid)
		{
			EntertainmentComponent component = map.EntertainmentComponentManager.GetComponent(entertainmentComponentInstance);
			if (component == null)
			{
				return;
			}
			Transform useTransform = component.BuildingUsePositionsComponent.GetUsePositionTransform(reservablePosition.Position);
			if (!(useTransform == null))
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					humanoid.FaceObject(useTransform);
				});
				if (Vector3.Distance(humanoid.GetPosition(), useTransform.position) > 0.2f)
				{
					humanoid.PathDriver.Teleport(useTransform.position);
				}
			}
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			HumanoidInstance humanoid = (HumanoidInstance)base.AgentOwner;
			yield return GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedOrNull(TargetIndex.A).FailAtCondition(FailAtCondition);
			EntertainmentComponentInstance entertainmentComponentInstance = GetTarget(TargetIndex.A).GetObjectAs<EntertainmentComponentInstance>();
			List<int> availableAnimations = new List<int>();
			for (int i = 0; i < entertainmentComponentInstance.Blueprint.InteractAnimationVariationsCount; i++)
			{
				availableAnimations.Add(i);
			}
			GoapAction entertainAction = new GoapAction("EntertainAction")
			{
				CompleteMode = ActionCompleteMode.Never
			};
			entertainAction.FailIfTargetDisposedOrNull(TargetIndex.A);
			entertainAction.OnInit = delegate
			{
				if (humanoid.HasDisposed || humanoid.Stats == null || humanoid.Stats.HasDisposed)
				{
					EndGoalWith(GoalCondition.Error);
				}
				else
				{
					EntertainmentModifier modifier = new EntertainmentModifier(entertainmentComponentInstance.Blueprint);
					humanoid.Stats.AddAttributeModifier(modifier);
					humanoid.PathDriver.IsFloatingAllowed = true;
					SetupUsePosition(entertainmentComponentInstance, humanoid);
					if (!string.IsNullOrEmpty(entertainmentComponentInstance.Blueprint.InteractAnimation))
					{
						entertainAction.TriggerAnimation(entertainmentComponentInstance.Blueprint.InteractAnimation, ActionAnimationMode.Interrupt);
						entertainAction.WithDynamicAnimatorParameter("EntertainRnd", () => GetAnimation(availableAnimations));
					}
					EntertainmentComponentBlueprint blueprint = entertainmentComponentInstance.Blueprint;
					if (blueprint != null)
					{
						foreach (string workerEffector in blueprint.WorkerEffectors)
						{
							if (!string.IsNullOrEmpty(workerEffector))
							{
								humanoid.Stats.StartEffector(workerEffector);
								bool isEnabled;
								FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(20, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Entertainment\\EntertainmentBaseGoal.cs");
								if (isEnabled)
								{
									messageBuilder.AppendLiteral("Starting ");
									messageBuilder.AppendFormatted(blueprint.GetID());
									messageBuilder.AppendLiteral(" effector: ");
									messageBuilder.AppendFormatted(workerEffector);
								}
								Log.Info(messageBuilder);
							}
						}
					}
					EntertainmentComponentInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<EntertainmentComponentInstance>();
					if (objectAs != null && !objectAs.HasDisposed)
					{
						string interactTool = objectAs.Blueprint.InteractTool;
						if (!string.IsNullOrEmpty(interactTool))
						{
							Transform socket = null;
							if (objectAs.Blueprint.ToolSocket == "left")
							{
								socket = (base.AgentOwner as HumanoidInstance)?.GetAgentView<HumanoidView>().BodyPreview.LeftHandSocket;
							}
							(base.AgentOwner as IToolAgent)?.SetTool(interactTool, socket);
						}
					}
				}
			};
			entertainAction.OnComplete = delegate
			{
				humanoid.PathDriver.IsFloatingAllowed = false;
				humanoid.Stats.RemoveAttributeModifier(ModifierType.Entertaining, string.Empty);
				EntertainmentComponentBlueprint blueprint = entertainmentComponentInstance.Blueprint;
				if (blueprint != null)
				{
					foreach (string workerEffector2 in blueprint.WorkerEffectors)
					{
						if (!string.IsNullOrEmpty(workerEffector2))
						{
							humanoid.Stats.EndEffector(workerEffector2);
							bool isEnabled;
							FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(18, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Goal\\Entertainment\\EntertainmentBaseGoal.cs");
							if (isEnabled)
							{
								messageBuilder.AppendLiteral("Ending ");
								messageBuilder.AppendFormatted(blueprint.GetID());
								messageBuilder.AppendLiteral(" effector: ");
								messageBuilder.AppendFormatted(workerEffector2);
							}
							Log.Info(messageBuilder);
						}
					}
					humanoid.AddExperience(blueprint.AddXpToSkill, blueprint.AddXpAmount);
				}
				humanoid.WorkerBehaviour?.WorkerInteraction.FireInteractionEvent("played_backgammon");
			};
			entertainAction.TickOnInterval(1f, delegate
			{
				StatInstance stat = humanoid.Stats.GetStat(StatType.Entertaiment);
				if (stat != null && stat.Current < 99f)
				{
					HumanoidView agentView = humanoid.GetAgentView<HumanoidView>();
					if (!(agentView == null))
					{
						AnimatorStateInfo currentAnimatorStateInfo = agentView.Animator.GetCurrentAnimatorStateInfo(0);
						if (currentAnimatorStateInfo.length > currentAnimatorStateInfo.normalizedTime)
						{
							entertainAction.TriggerAnimation(entertainmentComponentInstance.Blueprint.InteractAnimation, ActionAnimationMode.Interrupt);
							MonoSingleton<AnimationController>.Instance.SetAnimatorParameter(base.AgentOwner, "EntertainRnd", GetAnimation(availableAnimations));
						}
					}
				}
				else
				{
					MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
					entertainAction.Complete(ActionCompletionStatus.Success);
				}
			});
			entertainAction.FailAtCondition(FailAtCondition);
			yield return entertainAction;
		}

		private bool FindEntertainmentBuildings()
		{
			IPathfindingAgent obj = (IPathfindingAgent)base.AgentOwner;
			List<WorldObject> targets = map.EntertainmentComponentManager.IterateComponentWorldObjects((EntertainmentComponentInstance x) => !x.Underwater && !x.IsOnFire && x.Blueprint.UseGoal == base.Id).ToList();
			List<TargetObject> list = PathfinderMedieval.FindMedievalObjects(obj, targets, delegate(BaseBuildingInstance building)
			{
				Room room = building.GetRoom();
				return room == null || !room.RoomType.Prison;
			});
			if (list == null || list.Count <= 0)
			{
				return false;
			}
			List<TargetObject> list2 = new List<TargetObject>();
			foreach (TargetObject item in list)
			{
				WorldObject objectAs = item.GetObjectAs<WorldObject>();
				if (objectAs != null && !objectAs.HasDisposed && objectAs.OwnedByPlayer())
				{
					EntertainmentComponentInstance componentInstance = map.EntertainmentComponentManager.GetComponentInstance(objectAs);
					if (componentInstance != null && !componentInstance.HasDisposed)
					{
						list2.Add(new TargetObject(componentInstance, item.ReachablePosition));
					}
				}
			}
			if (list2.Count == 0)
			{
				return false;
			}
			QueueTargets(TargetIndex.A, list2);
			return true;
		}

		private bool ReserveTargets()
		{
			while (SelectNextTarget(TargetIndex.A))
			{
				EntertainmentComponentInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<EntertainmentComponentInstance>();
				if (!objectAs.ReservablePositionsComponentInstance.HasMultiPositions)
				{
					reservablePosition = objectAs.ReservablePositionsComponentInstance.ReservablePositions.FirstOrDefault((ReservablePosition item) => !item.Reserved);
					return true;
				}
				foreach (ReservablePosition reservablePosition in objectAs.ReservablePositionsComponentInstance.ReservablePositions)
				{
					if (!reservablePosition.Reserved)
					{
						this.reservablePosition = reservablePosition;
						SetSelectedTargetReachablePosition(TargetIndex.A, reservablePosition.Position);
						reservablePosition.Reserve(base.AgentOwner);
						return true;
					}
				}
			}
			return false;
		}

		private bool FailAtCondition()
		{
			EntertainmentComponentInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<EntertainmentComponentInstance>();
			if (objectAs != null && !objectAs.HasDisposed && !objectAs.Underwater && !objectAs.IsOnFire)
			{
				return !CommonGoalMethods.CheckPrisonConditions(base.AgentOwner as HumanoidInstance, objectAs.GetRoom());
			}
			return true;
		}

		private int GetAnimation(List<int> animationCollection)
		{
			if (animationCollection.Count == 0)
			{
				EntertainmentComponentInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<EntertainmentComponentInstance>();
				for (int i = 0; i < objectAs.Blueprint.InteractAnimationVariationsCount; i++)
				{
					animationCollection.Add(i);
				}
			}
			int index = Random.Range(0, animationCollection.Count - 1);
			int result = animationCollection[index];
			animationCollection.RemoveAt(index);
			return result;
		}
	}
}
