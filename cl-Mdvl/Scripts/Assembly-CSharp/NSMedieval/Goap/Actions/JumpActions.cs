using System;
using System.Collections.Generic;
using NSMedieval.Components;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.Types;

namespace NSMedieval.Goap.Actions
{
	public static class JumpActions
	{
		public static GoapAction ConditionalJump(GoapAction nextAction, Func<bool> condition)
		{
			GoapAction action = new GoapAction("ConditionalJump");
			action.OnInit = delegate
			{
				if (condition == null)
				{
					action.Goal.JumpToAction(nextAction);
				}
				else if (condition())
				{
					action.Goal.JumpToAction(nextAction);
				}
			};
			return action;
		}

		public static GoapAction JumpIfHaveResourceInStorage(GoapAction nextAction)
		{
			return ConditionalJump(nextAction, delegate
			{
				if (!(nextAction.Goal.AgentOwner is IStorageAgent storageAgent))
				{
					return false;
				}
				Storage storage = storageAgent.Storage;
				return storage != null && storage.GetSingleResource()?.Amount > 0;
			});
		}

		public static GoapAction JumpIfHaveNoResourceInStorage(GoapAction nextAction)
		{
			return ConditionalJump(nextAction, delegate
			{
				if (!(nextAction.Goal.AgentOwner is IStorageAgent storageAgent))
				{
					return true;
				}
				return storageAgent.Storage?.GetSingleResource() == null || storageAgent.Storage.GetSingleResource().Amount <= 0;
			});
		}

		public static GoapAction JumpIfHaveResourceInStorage(GoapAction nextAction, Resource blueprint)
		{
			return ConditionalJump(nextAction, () => nextAction.Goal.AgentOwner is IStorageAgent storageAgent && storageAgent.Storage?.GetSingleResource()?.Blueprint == blueprint);
		}

		public static GoapAction JumpIfHaveResourceInStorage(GoapAction nextAction, ResourceCategory category)
		{
			return ConditionalJump(nextAction, delegate
			{
				if (!(nextAction.Goal.AgentOwner is IStorageAgent storageAgent))
				{
					return false;
				}
				if (storageAgent.Storage?.GetSingleResource()?.Blueprint == null)
				{
					return false;
				}
				Storage storage = storageAgent.Storage;
				bool? obj;
				if (storage == null)
				{
					obj = null;
				}
				else
				{
					ResourceInstance singleResource = storage.GetSingleResource();
					obj = ((singleResource != null) ? new bool?(singleResource.Blueprint.Category.HasFlag(category)) : ((bool?)null));
				}
				bool? flag = obj;
				return flag == true;
			});
		}

		public static GoapAction JumpIfHaveResourceInStorage(GoapAction nextAction, ItemMaterialCategory category)
		{
			return ConditionalJump(nextAction, delegate
			{
				if (!(nextAction.Goal.AgentOwner is IStorageAgent storageAgent))
				{
					return false;
				}
				return !(storageAgent.Storage?.GetSingleResource()?.Blueprint == null) && storageAgent.Storage?.GetSingleResource()?.Blueprint.ItemMaterialCategory.Equals(category) == true;
			});
		}

		public static GoapAction Jump(GoapAction nextAction)
		{
			return ConditionalJump(nextAction, null);
		}

		public static GoapAction JumpIfNoTargetsInQueue(GoapAction nextAction, TargetIndex index)
		{
			GoapAction action = new GoapAction("JumpIfNoTargetsInQueue");
			action.JumpIf(nextAction, delegate
			{
				List<TargetObject> targetQueue = action.Goal.GetTargetQueue(index);
				return targetQueue != null && targetQueue.Count == 0;
			});
			return action;
		}

		public static GoapAction JumpIfHaveTargetsInQueue(GoapAction nextAction, TargetIndex index)
		{
			GoapAction action = new GoapAction("JumpIfHaveTargetsInQueue");
			action.JumpIf(nextAction, delegate
			{
				List<TargetObject> targetQueue = action.Goal.GetTargetQueue(index);
				return targetQueue != null && targetQueue.Count > 0;
			});
			return action;
		}

		public static GoapAction JumpIfHaveTargetsInQueue(GoapAction nextAction, TargetIndex index, Func<bool> condition)
		{
			GoapAction action = new GoapAction("JumpIfHaveTargetsInQueue");
			action.JumpIf(nextAction, delegate
			{
				List<TargetObject> targetQueue = action.Goal.GetTargetQueue(index);
				return targetQueue != null && targetQueue.Count > 0 && condition();
			});
			return action;
		}

		public static GoapAction JumpIfNoTargetSelected(GoapAction nextAction, TargetIndex index)
		{
			GoapAction action = new GoapAction("JumpIfNoTargetSelected");
			action.JumpIf(nextAction, () => !action.Goal.GetTarget(index).IsInitialized);
			return action;
		}
	}
}
