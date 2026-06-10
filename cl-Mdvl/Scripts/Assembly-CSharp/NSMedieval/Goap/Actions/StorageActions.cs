using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap.Actions
{
	public static class StorageActions
	{
		public static GoapAction DropResourcesFromStorage(Vec3Int positionOverride)
		{
			GoapAction action = new GoapAction("DeliverProductionResource");
			action.OnInit = delegate
			{
				IStorageAgent storageAgent = (IStorageAgent)action.AgentOwner;
				if (storageAgent == null)
				{
					action.Goal.EndGoalWith(GoalCondition.Incompletable);
				}
				else
				{
					storageAgent.DropStorage(positionOverride);
				}
			};
			return action;
		}

		public static GoapAction CompleteIfNoResourceInStorage(Resource resource, GoalCondition status = GoalCondition.Incompletable)
		{
			GoapAction action = new GoapAction("CompleteIfNoResourceInStorage");
			action.OnInit = delegate
			{
				ResourceInstance resourceInstance = (action.AgentOwner as IStorageAgent)?.Storage?.GetSingleResource();
				if (resourceInstance == null || resourceInstance.Blueprint != resource)
				{
					action.Goal.EndGoalWith(status);
				}
			};
			return action;
		}

		public static GoapAction CompleteIfNoResourceInStorage(ResourceCategory resourceCategory, GoalCondition status = GoalCondition.Incompletable)
		{
			GoapAction action = new GoapAction("CompleteIfNoResourceInStorage");
			action.OnInit = delegate
			{
				ResourceInstance resourceInstance = (action.AgentOwner as IStorageAgent)?.Storage?.GetSingleResource();
				if (resourceInstance == null || !resourceInstance.Blueprint.Category.HasFlag(resourceCategory))
				{
					action.Goal.EndGoalWith(status);
				}
			};
			return action;
		}

		public static GoapAction CompleteIfOwnerStorageIsEmpty(GoalCondition status = GoalCondition.Incompletable)
		{
			GoapAction action = new GoapAction("CompleteIfOwnerStorageIsEmpty");
			action.OnInit = delegate
			{
				ResourceInstance resourceInstance = (action.AgentOwner as IStorageAgent)?.Storage?.GetSingleResource();
				if (resourceInstance == null || resourceInstance.Count.Amount == 0)
				{
					action.Goal.EndGoalWith(status);
				}
			};
			return action;
		}

		public static GoapAction FindBestStorage(TargetIndex outputQueue, ZonePriority minimumPriority = ZonePriority.None, bool enablePriorityFallback = false)
		{
			GoapAction goapAction = new GoapAction("FindBestStorage");
			goapAction.OnInit = delegate
			{
				IPathfindingAgent pathfindingAgent = goapAction.AgentOwner as IPathfindingAgent;
				ResourceInstance resourceInstance = (goapAction.AgentOwner as IStorageAgent)?.Storage?.GetSingleResource();
				if (pathfindingAgent == null || resourceInstance == null)
				{
					goapAction.Complete(ActionCompletionStatus.Error);
				}
				else
				{
					IStorage storage = PathfinderUtil.FindNearestStorage(pathfindingAgent, resourceInstance, minimumPriority, enablePriorityFallback);
					if (storage == null)
					{
						goapAction.Complete(ActionCompletionStatus.Fail);
					}
					else
					{
						goapAction.Goal.ClearTargetsQueue(outputQueue);
						goapAction.Goal.QueueTarget(outputQueue, new TargetObject(storage));
					}
				}
			};
			return goapAction;
		}

		public static GoapAction ReserveAndQueueStoragePlaces(TargetIndex storageIndex, TargetIndex outputQueueIndex, Action<IStorage, Vec3Int> onStorageReserved = null, GoapAction jumpOnFail = null)
		{
			GoapAction goapAction = new GoapAction("ReserveAndQueueStoragePlaces");
			goapAction.OnInit = delegate
			{
				IPathfindingAgent pathfindingAgent = goapAction.AgentOwner as IPathfindingAgent;
				ResourceInstance resourceInstance = (goapAction.AgentOwner as IStorageAgent)?.Storage?.GetSingleResource();
				IStorage storage = goapAction.Goal.GetTarget(storageIndex).ObjectInstance as IStorage;
				bool isEnabled;
				if (pathfindingAgent == null || resourceInstance == null || storage == null || storage.HasDisposed)
				{
					FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(42, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\StorageActions.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("ReserveAndQueueStoragePlaces failed ");
						messageBuilder.AppendFormatted(pathfindingAgent);
						messageBuilder.AppendLiteral(" | ");
						messageBuilder.AppendFormatted(resourceInstance);
						messageBuilder.AppendLiteral(" | ");
						messageBuilder.AppendFormatted(storage);
					}
					Log.Warning(messageBuilder);
					goapAction.Complete(ActionCompletionStatus.Error);
				}
				else
				{
					int num = 0;
					goapAction.Goal.ClearTargetsQueue(outputQueueIndex);
					SimpleResourceCount storedAmount;
					Vec3Int position;
					while (num < resourceInstance.Amount && storage.ReserveStorage(resourceInstance, (CreatureBase)pathfindingAgent, out storedAmount, out position) && !storage.HasDisposed)
					{
						if (storedAmount.Amount == 0)
						{
							FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(50, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\StorageActions.cs");
							if (isEnabled)
							{
								messageBuilder.AppendLiteral("ReserveAndQueueStoragePlaces failed with amount 0 ");
								messageBuilder.AppendFormatted(storage.GetPosition());
							}
							Log.Warning(messageBuilder);
							break;
						}
						num += storedAmount.Amount;
						onStorageReserved?.Invoke(storage, position);
						goapAction.Goal.QueueTarget(outputQueueIndex, new TargetObject(storage, position));
					}
					if (num == 0)
					{
						if (jumpOnFail != null)
						{
							goapAction.Goal.JumpToAction(jumpOnFail);
						}
						else
						{
							goapAction.Complete(ActionCompletionStatus.Fail);
						}
					}
				}
			};
			return goapAction;
		}
	}
}
