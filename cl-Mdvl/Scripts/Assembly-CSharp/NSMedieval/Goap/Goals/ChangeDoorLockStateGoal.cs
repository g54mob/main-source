using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap.Actions;
using NSMedieval.Manager;
using NSMedieval.Pathfinding;
using NSMedieval.State;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap.Goals
{
	public class ChangeDoorLockStateGoal : Goal
	{
		private const float AnimationSpeed = 1f;

		private readonly DoorComponentManager doorComponentManager;

		private readonly VillageMap map;

		public ChangeDoorLockStateGoal(Agent selfAgent)
			: base("ChangeDoorLockStateGoal", selfAgent)
		{
			AddInitStep(base.PreferredReservableHandler.GetInitSequenceStep<DoorComponentInstance>());
			AddInitStep(new ThreadSequenceStep(DoPrechecks, PickTarget));
			map = VillageManager.ActiveVillage.Map;
			doorComponentManager = map.DoorComponentManager;
		}

		public override bool AgentTypeCheck()
		{
			return base.AgentOwner is HumanoidInstance;
		}

		public override bool CanStart(bool isForced = false)
		{
			if (doorComponentManager == null)
			{
				return false;
			}
			foreach (DoorComponentInstance item in map.DoorComponentManager.HasDoorsWithOrder)
			{
				if (!item.IsOnFire)
				{
					return true;
				}
			}
			return false;
		}

		public override void EndGoalWith(GoalCondition condition)
		{
			if (condition == GoalCondition.Succeeded)
			{
				doorComponentManager.HasDoorsWithOrder.Remove(GetTarget(TargetIndex.A).GetObjectAs<DoorComponentInstance>());
			}
			MonoSingleton<ConstructionController>.Instance.DoorLockOrderChangedEvent -= OnDoorOrderChange;
			base.EndGoalWith(condition);
		}

		protected override IEnumerable<GoapAction> GetNextAction()
		{
			GoapAction goapAction = GoToActions.GoToTarget(TargetIndex.A, PathCompleteMode.ExactPosition).FailIfTargetDisposedOrNull(TargetIndex.A);
			goapAction.OnInit = delegate
			{
				MonoSingleton<ConstructionController>.Instance.DoorLockOrderChangedEvent += OnDoorOrderChange;
			};
			goapAction.OnTick = delegate
			{
				DoorComponentInstance objectAs = GetTarget(TargetIndex.A).GetObjectAs<DoorComponentInstance>();
				if (objectAs == null || objectAs.HasDisposed || objectAs.DoorOrder == DoorOrder.None || objectAs.IsOnFire || (!objectAs.ShouldLock() && !objectAs.ShouldUnLock() && !objectAs.ShouldAlwaysOpen()))
				{
					EndGoalWith(GoalCondition.Incompletable);
				}
			};
			yield return goapAction;
			DoorComponentInstance doorComponentInstance = GetTarget(TargetIndex.A).GetObjectAs<DoorComponentInstance>();
			GoapAction changeLockStateAction = null;
			if (doorComponentInstance.Blueprint.DoorType == DoorType.Regular)
			{
				changeLockStateAction = new GoapAction("ChangeDoorOrder").FailIfTargetDisposedOrNull(TargetIndex.A);
				changeLockStateAction.OnInit = delegate
				{
					bool num = doorComponentInstance.DoorOrder == DoorOrder.Unlock;
					bool flag = doorComponentInstance.DoorOrder == DoorOrder.Open;
					if (num)
					{
						doorComponentInstance.Unlock();
					}
					else if (flag)
					{
						doorComponentInstance.SetAlwaysOpen();
					}
					else
					{
						doorComponentInstance.Lock();
					}
				};
			}
			else if (doorComponentInstance.Blueprint.DoorType == DoorType.Portcullis || doorComponentInstance.Blueprint.DoorType == DoorType.Drawbridge)
			{
				bool isOpening = doorComponentInstance.LockState == LockState.Locked;
				changeLockStateAction = new GoapAction("ChangePortcullisLockState").FailIfTargetDisposedOrNull(TargetIndex.A);
				changeLockStateAction.OnInit = delegate
				{
					changeLockStateAction.TriggerAnimation("PortcullisOpening", ActionAnimationMode.Interrupt);
					HumanoidInstance humanoid = (HumanoidInstance)base.AgentOwner;
					DoorComponent doorComponent = doorComponentInstance.Map.DoorComponentManager.GetComponent(doorComponentInstance);
					if (doorComponent.UseTransform != null)
					{
						MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
						{
							humanoid.FaceObject(doorComponent.UseTransform);
						});
					}
					if (isOpening)
					{
						if (doorComponentInstance.Blueprint.DoorType == DoorType.Drawbridge)
						{
							doorComponentInstance.SetAlwaysOpen();
						}
						else
						{
							float num = 1f / doorComponentInstance.Blueprint.OpeningSpeedMultiplier;
							float actionDuration = doorComponentInstance.Blueprint.OpeningSpeedMultiplier + 0.1f;
							if (num <= 0f)
							{
								num = 1f;
							}
							doorComponentInstance.StartOpeningAnimation(num);
							changeLockStateAction.CompleteAfterTimeExpires(actionDuration);
							changeLockStateAction.WithProgressBar(TargetIndex.None, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => changeLockStateAction.TotalTickingTime / actionDuration).ProgressBarDestroyOnCompletion(TargetIndex.None, OverlayProgressBarType.Circle);
							changeLockStateAction.OnComplete = delegate(ActionCompletionStatus status)
							{
								MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
								if (status == ActionCompletionStatus.Success)
								{
									doorComponentInstance.SetAlwaysOpen();
								}
								else
								{
									doorComponentInstance.AbortPortcullisOpening();
									doorComponentInstance.Lock();
								}
							};
						}
					}
					else if (doorComponentInstance.Blueprint.DoorType == DoorType.Drawbridge)
					{
						float num2 = 1f / doorComponentInstance.Blueprint.OpeningSpeedMultiplier;
						float actionDuration2 = doorComponentInstance.Blueprint.OpeningSpeedMultiplier + 0.1f;
						if (num2 <= 0f)
						{
							num2 = 1f;
						}
						doorComponentInstance.StartClosingAnimation(num2);
						changeLockStateAction.CompleteAfterTimeExpires(actionDuration2);
						changeLockStateAction.WithProgressBar(TargetIndex.None, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => changeLockStateAction.TotalTickingTime / actionDuration2).ProgressBarDestroyOnCompletion(TargetIndex.None, OverlayProgressBarType.Circle);
						changeLockStateAction.OnComplete = delegate(ActionCompletionStatus status)
						{
							MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(base.AgentOwner);
							if (status == ActionCompletionStatus.Success)
							{
								doorComponentInstance.Lock();
							}
							else
							{
								doorComponentInstance.AbortDrawbridgeClosing();
								doorComponentInstance.DrawbridgeClosingCanceled();
							}
						};
					}
					else
					{
						doorComponentInstance.Lock();
					}
				};
			}
			else
			{
				bool isOpening2 = doorComponentInstance.LockState == LockState.Locked;
				changeLockStateAction = new GoapAction("ChangeLargeGateLockState").FailIfTargetDisposedOrNull(TargetIndex.A);
				changeLockStateAction.OnInit = delegate
				{
					changeLockStateAction.TriggerAnimation("Stirring", ActionAnimationMode.Interrupt);
					HumanoidInstance humanoid = (HumanoidInstance)base.AgentOwner;
					DoorComponent doorViewComponent = doorComponentInstance.Map.DoorComponentManager.GetComponent(doorComponentInstance);
					if (doorViewComponent.UseTransform != null)
					{
						MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
						{
							humanoid.FaceObject(doorViewComponent.UseTransform);
						});
					}
					if (isOpening2)
					{
						float num = 1f / doorComponentInstance.Blueprint.OpeningSpeedMultiplier;
						float actionDuration = doorComponentInstance.Blueprint.OpeningSpeedMultiplier + 0.1f;
						if (num <= 0f)
						{
							num = 1f;
						}
						doorComponentInstance.StartOpeningAnimation(num);
						changeLockStateAction.CompleteAfterTimeExpires(actionDuration);
						changeLockStateAction.WithProgressBar(TargetIndex.None, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => changeLockStateAction.TotalTickingTime / actionDuration).ProgressBarDestroyOnCompletion(TargetIndex.None, OverlayProgressBarType.Circle);
						changeLockStateAction.OnComplete = delegate(ActionCompletionStatus status)
						{
							if (status == ActionCompletionStatus.Success)
							{
								doorComponentInstance.SetAlwaysOpen();
							}
							else
							{
								doorComponentInstance.AbortGateOpening();
								doorComponentInstance.Lock();
							}
						};
					}
					else
					{
						float num2 = 1f / doorComponentInstance.Blueprint.ClosingSpeedMultiplier;
						float actionDuration2 = doorComponentInstance.Blueprint.ClosingSpeedMultiplier + 0.1f;
						if (num2 <= 0f)
						{
							num2 = 1f;
						}
						doorComponentInstance.StartClosingAnimation(num2);
						changeLockStateAction.CompleteAfterTimeExpires(actionDuration2);
						changeLockStateAction.WithProgressBar(TargetIndex.None, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => changeLockStateAction.TotalTickingTime / actionDuration2).ProgressBarDestroyOnCompletion(TargetIndex.None, OverlayProgressBarType.Circle);
						changeLockStateAction.OnComplete = delegate(ActionCompletionStatus status)
						{
							if (status == ActionCompletionStatus.Success)
							{
								doorComponentInstance.Lock();
							}
							else
							{
								doorComponentInstance.AbortGateClosing();
								doorComponentInstance.SetAlwaysOpen();
							}
						};
					}
				};
			}
			yield return changeLockStateAction;
		}

		private bool DoPrechecks()
		{
			doorComponentManager.HasDoorsWithOrder.RemoveWhere((DoorComponentInstance item) => !item.ShouldChangeLockState());
			return doorComponentManager.HasDoorsWithOrder.Count > 0;
		}

		private bool PickTarget()
		{
			CreatureBase creatureBase = base.AgentOwner as CreatureBase;
			if (base.PreferredReservableHandler.HasTarget())
			{
				TargetObject target = base.PreferredReservableHandler.GetTarget();
				DoorComponentInstance objectAs = target.GetObjectAs<DoorComponentInstance>();
				if (objectAs != null && !objectAs.HasDisposed)
				{
					BaseBuildingInstance ownerBuilding = objectAs.OwnerBuilding;
					if (ownerBuilding != null && !ownerBuilding.HasDisposed && objectAs.OwnerBuilding.OwnedByPlayer() && objectAs.ShouldChangeLockState())
					{
						if (!objectAs.HasUsePosition)
						{
							if (creatureBase != null)
							{
								Vec3Int bestReachablePosition = GetBestReachablePosition(creatureBase, objectAs.OwnerBuilding);
								TargetObject target2 = new TargetObject(objectAs, bestReachablePosition);
								QueueTarget(TargetIndex.A, target2);
							}
							else
							{
								QueueTarget(TargetIndex.A, target);
							}
							if (ReserveAndSelectFirstTargetFromQueue(TargetIndex.A))
							{
								return true;
							}
						}
						else
						{
							Vec3Int usePosition = objectAs.UsePosition;
							if (PathfinderUtil.IsPathPossible(creatureBase, usePosition))
							{
								TargetObject target3 = new TargetObject(objectAs, usePosition);
								QueueTarget(TargetIndex.A, target3);
								if (ReserveAndSelectFirstTargetFromQueue(TargetIndex.A))
								{
									return true;
								}
							}
						}
					}
				}
			}
			using PooledDictionary<IGoapTargetable, Vec3Int> searchSet = DictionaryPool<IGoapTargetable, Vec3Int>.GetJanitor();
			foreach (DoorComponentInstance item in map.DoorComponentManager.HasDoorsWithOrder)
			{
				if (!item.IsDisposedOrNull() && item.ShouldChangeLockState() && !item.IsOnFire && item.OwnerBuilding.OwnedByPlayer())
				{
					if (item.HasUsePosition)
					{
						searchSet.Add(item, item.UsePosition);
						continue;
					}
					Vec3Int bestReachablePosition2 = GetBestReachablePosition(creatureBase, item.OwnerBuilding);
					searchSet.Add(item, bestReachablePosition2);
				}
			}
			IPathfindingAgent obj = base.AgentOwner as IPathfindingAgent;
			IGoapTargetable closestReachable = PathfinderUtil.GetClosestReachable(obj, obj.GetGridPosition(), searchSet, (IGoapTargetable x) => !MonoSingleton<ReservationManager>.Instance.IsReserved(x as IReservable));
			if (closestReachable != null)
			{
				DoorComponentInstance doorComponentInstance = closestReachable as DoorComponentInstance;
				if (MonoSingleton<ReservationManager>.Instance.TryReserveObject(doorComponentInstance, base.AgentOwner))
				{
					SetTarget(TargetIndex.A, new TargetObject(doorComponentInstance, searchSet[doorComponentInstance]));
					return true;
				}
			}
			return false;
		}

		private Vec3Int GetBestReachablePosition(IPathfindingAgent agent, WorldObject obj)
		{
			if (obj == null)
			{
				return default(Vec3Int);
			}
			if (CombatUtils.IsNullOrDisposed(agent))
			{
				return obj.GridDataPosition;
			}
			Vec3Int a = agent.GetGridPosition();
			Vec3Int result = Vec3Int.zero;
			float num = float.MaxValue;
			MapNode node = agent.GetNode();
			foreach (Vec3Int reachablePosition in obj.ReachablePositions)
			{
				Vec3Int b = reachablePosition;
				MapNode node2 = map.GetNode(b);
				float num2 = Vec3Int.Distance(in a, in b);
				if (node2 != null && node != null && node2.Area != node.Area)
				{
					num2 *= 2f;
				}
				if (num2 < num && PathfinderUtil.IsPathPossible(agent, a, b))
				{
					num = num2;
					result = b;
				}
			}
			if (result.Equals(Vec3Int.zero))
			{
				return obj.GridDataPosition;
			}
			return result;
		}

		private void OnDoorOrderChange(DoorComponentInstance door)
		{
			if (GetTarget(TargetIndex.A).GetObjectAs<DoorComponentInstance>() == door && !door.ShouldChangeLockState())
			{
				EndGoalWith(GoalCondition.Incompletable);
			}
		}
	}
}
