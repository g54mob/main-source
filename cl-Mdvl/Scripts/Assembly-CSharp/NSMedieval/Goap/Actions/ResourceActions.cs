using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Components;
using NSMedieval.Controllers;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Sound;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Stockpiles;
using NSMedieval.StorageUniversal;
using NSMedieval.Views.Resources;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Goap.Actions
{
	public static class ResourceActions
	{
		public static GoapAction EquipItem(TargetIndex targetIndex, IEquipableAgent agent, bool isManuallyEquipped = false)
		{
			GoapAction action = new GoapAction("EquipItem");
			action.OnInit = delegate
			{
				ResourcePileInstance objectAs = action.Goal.GetTarget(targetIndex).GetObjectAs<ResourcePileInstance>();
				if (objectAs == null || objectAs.HasDisposed)
				{
					Log.Error("Target is not a pile!", "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\ResourceActions.cs");
					action.Complete(ActionCompletionStatus.Fail);
				}
				else
				{
					EquipmentInstance equipmentInstance = new EquipmentInstance(objectAs.BlueprintId, isManuallyEquipped);
					equipmentInstance.CloneStatsCurrent(objectAs.Stats);
					equipmentInstance.SetProducerUniqueId(objectAs.GetStoredResource().ProducerUniqueId);
					agent.Inventory.Equip(equipmentInstance);
					agent.Inventory.RemoveEquipOrder(objectAs);
					objectAs.GetStorage().Take(objectAs.Blueprint, 1);
				}
			};
			action.FailIfTargetDisposedOrNull(targetIndex);
			action.FailIfResourcePileHasNoResources(targetIndex);
			return action;
		}

		public static GoapAction RemoveResourceFromPile(TargetIndex index, int amount)
		{
			GoapAction action = new GoapAction("RemoveResourceFromPile");
			action.OnInit = delegate
			{
				IStorageAgent storageAgent = (IStorageAgent)action.AgentOwner;
				ResourcePileInstance objectAs = action.Goal.GetTarget(index).GetObjectAs<ResourcePileInstance>();
				objectAs.GetStorage().TransferTo(storageAgent.Storage, objectAs.Blueprint, amount);
			};
			action.CompleteMode = ActionCompleteMode.Instant;
			action.FailIfTargetIsNotType<ResourcePileInstance>(index);
			action.FailIfResourcePileHasNoResources(index);
			return action;
		}

		public static GoapAction PickupResourceFromPile(TargetIndex index, Func<Resource, int> requestedAmount, Action<Resource, int> successCallback = null, bool onlySameResourceType = true, Storage destinationStorage = null)
		{
			GoapAction action = new GoapAction("PickupResourceFromPile");
			action.OnInit = delegate
			{
				IStorageAgent storageAgent = (IStorageAgent)action.AgentOwner;
				Storage storage = destinationStorage ?? storageAgent.Storage;
				ResourcePileInstance objectAs = action.Goal.GetTarget(index).GetObjectAs<ResourcePileInstance>();
				ResourceInstance singleResource = storage.GetSingleResource();
				if (singleResource != null && onlySameResourceType && singleResource.Blueprint != objectAs.Blueprint)
				{
					action.Goal.EndGoalWith(GoalCondition.Error);
				}
				else
				{
					int num = requestedAmount(objectAs.Blueprint);
					Storage storage2 = objectAs.GetStorage();
					if (num <= 0)
					{
						num = storage2.GetSingleResource().Amount;
					}
					int num2 = storage2.TransferTo(storage, objectAs.Blueprint, num);
					if (num2 <= 0)
					{
						action.Goal.EndGoalWith(GoalCondition.Incompletable);
					}
					else
					{
						action.Complete(ActionCompletionStatus.Success);
						successCallback?.Invoke(objectAs.Blueprint, num2);
						MonoSingleton<AudioManager>.Instance.PlaySoundAtPosition("ObjectPickup", objectAs.WorldPosition);
					}
				}
			};
			action.CompleteMode = ActionCompleteMode.Instant;
			action.FailIfTargetIsNotType<ResourcePileInstance>(index);
			action.FailIfResourcePileHasNoResources(index);
			return action;
		}

		public static GoapAction PickupResourceFromPile(TargetIndex index, int requestedAmount, Action<int> successCallback = null)
		{
			return PickupResourceFromPile(index, (Resource blueprint) => requestedAmount, delegate(Resource resource, int i)
			{
				successCallback?.Invoke(i);
			});
		}

		public static GoapAction DeliverToStorageAgent(TargetIndex index)
		{
			GoapAction action = new GoapAction("DeliverToStorageAgent");
			action.OnInit = delegate
			{
				IStorageAgent storageAgent = (IStorageAgent)action.AgentOwner;
				IStorageAgent storageAgent2 = action.Goal.GetTarget(index).ObjectInstance as IStorageAgent;
				if (storageAgent == null || storageAgent2 == null)
				{
					action.Goal.EndGoalWith(GoalCondition.Incompletable);
				}
				else
				{
					storageAgent.Storage.GetSingleResource().TransferTo(storageAgent2.Storage);
				}
			};
			return action;
		}

		public static GoapAction DeliverToSiegeWeapon(TargetIndex index)
		{
			GoapAction action = new GoapAction("DeliverToStorageAgent");
			action.OnInit = delegate
			{
				IStorageAgent storageAgent = (IStorageAgent)action.AgentOwner;
				SiegeWeaponComponentInstance siegeWeaponComponentInstance = action.Goal.GetTarget(index).ObjectInstance as SiegeWeaponComponentInstance;
				if (storageAgent == null || siegeWeaponComponentInstance == null)
				{
					action.Goal.EndGoalWith(GoalCondition.Incompletable);
				}
				else
				{
					siegeWeaponComponentInstance.Storage.Add(storageAgent.Storage.Take(storageAgent.Storage.GetSingleResource()));
				}
			};
			return action;
		}

		public static GoapAction PlaceBodyInsideAGrave(TargetIndex indexBuilding)
		{
			GoapAction action = new GoapAction("PlaceBodyInsideAGrave");
			action.OnInit = delegate
			{
				TargetObject target = action.Goal.GetTarget(indexBuilding);
				IStorageAgent storageAgent = (IStorageAgent)action.AgentOwner;
				GraveComponentInstance objectAs = target.GetObjectAs<GraveComponentInstance>();
				ResourceInstance singleResource = storageAgent.Storage.GetSingleResource();
				objectAs.AddBody(storageAgent.Storage.Take(singleResource) as CarcassResourceInstance);
			};
			return action;
		}

		public static GoapAction DeliverBuildingConstructionMaterials(TargetIndex index)
		{
			GoapAction action = new GoapAction("DeliverBuildingConstructionMaterials");
			action.OnInit = delegate
			{
				TargetObject target = action.Goal.GetTarget(index);
				IStorageAgent storageAgent = (IStorageAgent)action.AgentOwner;
				BaseBuildingInstance objectAs = target.GetObjectAs<BaseBuildingInstance>();
				IEnumerable<SimpleResourceCount> resourceOrder = objectAs.GetResourceOrder(null);
				if (resourceOrder == null)
				{
					return;
				}
				using IEnumerator<SimpleResourceCount> enumerator = resourceOrder.GetEnumerator();
				if (!enumerator.MoveNext())
				{
					return;
				}
				foreach (SimpleResourceCount item in resourceOrder)
				{
					storageAgent.Storage.TransferTo(objectAs.Storage, item.Blueprint, item.Amount);
				}
			};
			return action;
		}

		public static GoapAction DeliverMoveBuildingConstructionMaterials(TargetIndex index)
		{
			GoapAction action = new GoapAction("DeliverBuildingConstructionMaterials");
			action.OnInit = delegate
			{
				TargetObject target = action.Goal.GetTarget(index);
				IStorageAgent storageAgent = (IStorageAgent)action.AgentOwner;
				BaseBuildingInstance objectAs = target.GetObjectAs<BaseBuildingInstance>();
				IEnumerable<SimpleResourceCount> resourceOrder = objectAs.GetResourceOrder(null);
				if (resourceOrder == null)
				{
					return;
				}
				using IEnumerator<SimpleResourceCount> enumerator = resourceOrder.GetEnumerator();
				if (!enumerator.MoveNext())
				{
					return;
				}
				foreach (SimpleResourceCount item in resourceOrder)
				{
					storageAgent.Storage.TransferTo(objectAs.Storage, item.Blueprint, item.Amount);
				}
			};
			return action;
		}

		public static GoapAction StoreResourceOnStockpile(TargetIndex target)
		{
			GoapAction action = new GoapAction("StoreResourceFromStorageOnStockpile");
			action.OnInit = delegate
			{
				TargetObject target2 = action.Goal.GetTarget(target);
				IStorageAgent storageAgent = (IStorageAgent)action.AgentOwner;
				Vec3Int reachablePosition = target2.ReachablePosition;
				ResourceInstance singleResource = storageAgent.Storage.GetSingleResource();
				bool isEnabled;
				if (singleResource == null)
				{
					action.Complete(ActionCompletionStatus.Error);
				}
				else if (singleResource.Amount <= 0)
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(80, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\ResourceActions.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("StoreResourceOnStockpile Tried to store 0 resources form agent's storage. ");
						messageBuilder.AppendFormatted(storageAgent);
						messageBuilder.AppendLiteral(" POS: ");
						messageBuilder.AppendFormatted(target2.ReachablePosition);
					}
					Log.Error(messageBuilder);
					action.Complete(ActionCompletionStatus.Error);
				}
				else if (target2.ObjectInstance is StockpileInstance stockpileInstance)
				{
					Vector3 worldPosition = GridUtils.GetWorldPosition(target2.ReachablePosition);
					ResourcePileInstance resourcePileGridPosition = stockpileInstance.GetResourcePileGridPosition(reachablePosition);
					if (resourcePileGridPosition != null && resourcePileGridPosition.Blueprint == singleResource.Blueprint)
					{
						storageAgent.Storage.TransferTo(resourcePileGridPosition.GetStorage(), singleResource.Blueprint, singleResource.Amount);
					}
					else if (singleResource.Amount > singleResource.Blueprint.StackingLimit)
					{
						ResourcePileView resourcePileView = MonoSingleton<ResourcePileManager>.Instance.SpawnPile(singleResource.Clone(singleResource.Blueprint.StackingLimit), worldPosition);
						MonoSingleton<ResourcePileTracker>.Instance.OnNewPileSpawnedOnStockpile(singleResource.Blueprint, resourcePileView.ResourcePileInstance);
						storageAgent.Storage.Consume(singleResource.Blueprint, singleResource.Blueprint.StackingLimit);
					}
					else
					{
						ResourcePileView resourcePileView2 = MonoSingleton<ResourcePileManager>.Instance.SpawnPile(singleResource.Clone(), worldPosition);
						if (resourcePileView2 != null)
						{
							MonoSingleton<ResourcePileTracker>.Instance.OnNewPileSpawnedOnStockpile(singleResource.Blueprint, resourcePileView2.ResourcePileInstance);
						}
						else
						{
							FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(90, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\ResourceActions.cs");
							if (isEnabled)
							{
								messageBuilder.AppendLiteral("pileView2 was null while trying to spawn pile on empty stockpile space at world position ");
								messageBuilder.AppendFormatted(worldPosition);
								messageBuilder.AppendLiteral(".");
							}
							Log.Error(messageBuilder);
						}
						storageAgent.Storage.ClearAll();
					}
				}
				else if (target2.ObjectInstance is ShelfComponentInstance shelfComponentInstance)
				{
					if (shelfComponentInstance.AllStorage.Count == 0)
					{
						action.Complete(ActionCompletionStatus.Error);
					}
					else
					{
						int num = singleResource.Amount;
						foreach (UniversalStorage item in shelfComponentInstance.AllStorage)
						{
							int num2 = item.StoreResourcePile((CreatureBase)storageAgent, singleResource.Blueprint, num);
							num -= num2;
							if (num <= 0)
							{
								return;
							}
						}
						action.Complete(ActionCompletionStatus.Fail);
					}
				}
				else
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(94, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\GOAP\\Action\\ResourceActions.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("StoreResourceOnStockpile target not universal storage or stockpile. This should never happen! ");
						messageBuilder.AppendFormatted(storageAgent);
					}
					Log.Error(messageBuilder);
					action.Goal.EndGoalWith(GoalCondition.Error);
				}
			};
			return action;
		}

		public static GoapAction DeliverProductionResource(TargetIndex index)
		{
			GoapAction action = new GoapAction("DeliverProductionResource");
			action.OnInit = delegate
			{
				TargetObject target = action.Goal.GetTarget(index);
				IStorageAgent storageAgent = (IStorageAgent)action.AgentOwner;
				ProductionComponentInstance objectAs = target.GetObjectAs<ProductionComponentInstance>();
				ResourceInstance resourceInstance = storageAgent.Storage?.GetSingleResource();
				if (resourceInstance == null || resourceInstance.HasDisposed)
				{
					action.Complete(ActionCompletionStatus.Error);
				}
				else if (objectAs == null || objectAs.HasDisposed || objectAs.ProductionSystemInstance?.CurrentProduction == null)
				{
					action.Complete(ActionCompletionStatus.Error);
				}
				else
				{
					ProductionInstance currentProduction = objectAs.ProductionSystemInstance.CurrentProduction;
					ResourceInstance resourceInstance2 = storageAgent.Storage.Take();
					if (resourceInstance2 is CarcassResourceInstance carcassResourceInstance)
					{
						carcassResourceInstance.DropInventory(storageAgent.GetPosition().ToGridVec3Int());
					}
					currentProduction.DeliverResource(resourceInstance2);
				}
			};
			return action;
		}

		public static GoapAction DeliverFuelResource(TargetIndex index)
		{
			GoapAction action = new GoapAction("DeliverFuelResource");
			action.OnInit = delegate
			{
				TargetObject target = action.Goal.GetTarget(index);
				IStorageAgent storageAgent = (IStorageAgent)action.AgentOwner;
				FuelConsumerComponentInstance objectAs = target.GetObjectAs<FuelConsumerComponentInstance>();
				ResourceInstance resourceInstance = storageAgent.Storage?.GetSingleResource();
				if (resourceInstance == null || resourceInstance.HasDisposed)
				{
					action.Complete(ActionCompletionStatus.Error);
				}
				else if (objectAs == null || objectAs.HasDisposed)
				{
					action.Complete(ActionCompletionStatus.Error);
				}
				else
				{
					int amount = (int)((float)objectAs.GetMaxCaloriesToStore() / resourceInstance.Blueprint.CaloriesCount + 0.5f);
					if (objectAs.FuelStorage.Add(storageAgent.Storage.Take(resourceInstance.Blueprint, amount)) <= 0)
					{
						action.Goal.EndGoalWith(GoalCondition.Incompletable);
					}
					else
					{
						action.Complete(ActionCompletionStatus.Success);
					}
				}
			};
			return action;
		}

		public static GoapAction ObtainWater(TargetIndex index, Resource waterBucketBlueprint, int resourceCarryAmount, Action<Resource, int> successCallback = null, MapNode waterSourceNode = null)
		{
			GoapAction obtainWater = new GoapAction("ObtainWater");
			obtainWater.OnInit = delegate
			{
				IHarvestAgent obj = obtainWater.AgentOwner as IHarvestAgent;
				float num = obj.GetAttributeValue(AttributeType.GlobalWorkSpeed);
				if (num == 0f)
				{
					num = 1f;
				}
				float num2 = obj.GetAttributeValue(AttributeType.MotorFunction);
				if (num2 == 0f)
				{
					num2 = 1f;
				}
				WellComponentInstance wellComponentInstance = obtainWater.Goal.GetTarget(index).GetObjectAs<BaseBuildingInstance>()?.GetComponentInstance<WellComponentInstance>();
				float time;
				if (wellComponentInstance != null)
				{
					time = wellComponentInstance.WellHeight / (num * num2);
					wellComponentInstance.StartObtainingWater(time);
					MonoSingleton<AnimationController>.Instance.TriggerAgentAnimation(obtainWater.AgentOwner, "PortcullisOpening");
				}
				else
				{
					time = 3f / (num * num2);
					MonoSingleton<AnimationController>.Instance.TriggerAgentAnimation(obtainWater.AgentOwner, "BucketWaterFill");
				}
				obtainWater.CompleteAfterTimeExpires(time);
				obtainWater.WithProgressBar(TargetIndex.None, OverlayProgressBarType.Circle, (IProgressBarOwner owner) => obtainWater.TotalTickingTime / time).ProgressBarDestroyOnCompletion(TargetIndex.None, OverlayProgressBarType.Circle);
			};
			obtainWater.OnComplete = delegate(ActionCompletionStatus status)
			{
				MonoSingleton<AnimationController>.Instance.ForceQuitAgentAnimation(obtainWater.AgentOwner);
				WellComponentInstance wellComponentInstance = obtainWater.Goal.GetTarget(index).GetObjectAs<BaseBuildingInstance>()?.GetComponentInstance<WellComponentInstance>();
				MonoSingleton<ReservationManager>.Instance.ReleaseObject(wellComponentInstance, obtainWater.AgentOwner);
				if (status != ActionCompletionStatus.Success)
				{
					wellComponentInstance?.BucketHardReset();
				}
				else
				{
					wellComponentInstance?.WaterObtained();
					if (obtainWater.AgentOwner is IStorageAgent storageAgent)
					{
						ResourcePileInstance resourcePileInstance = ResourcePileFactory.ProducePile(new ResourceInstance(waterBucketBlueprint, resourceCarryAmount), obtainWater.Goal.GetTarget(index).ReachablePosition.ToVector3());
						if (resourcePileInstance != null)
						{
							int num = resourcePileInstance.GetStorage().TransferTo(storageAgent.Storage, resourcePileInstance.Blueprint, resourceCarryAmount);
							waterSourceNode?.Map.WaterManager.WaterSimLogic.WaterTakenUpdateLevel(waterSourceNode.Index);
							if (num <= 0)
							{
								obtainWater.Goal.EndGoalWith(GoalCondition.Incompletable);
							}
							else
							{
								successCallback?.Invoke(waterBucketBlueprint, num);
							}
						}
					}
				}
			};
			obtainWater.CompleteMode = ActionCompleteMode.Delay;
			return obtainWater;
		}
	}
}
