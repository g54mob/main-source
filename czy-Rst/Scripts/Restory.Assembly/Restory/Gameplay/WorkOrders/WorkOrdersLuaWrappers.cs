using System;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using Restory.AssetManagement;
using Restory.Data.Base;
using Restory.Data.Devices.Condition;
using Restory.Data.Devices.DeviceWorkTypes;
using Restory.Data.NPCs;
using Restory.Data.Visits;
using Restory.Gameplay.Visits;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.WorkOrders
{
	public class WorkOrdersLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string AddWorkOrder = "WorkOrders_AddOrder";

			public static readonly string AddWorkOrderWithClaimingNpcTexture = "WorkOrders_AddOrderWithClaimingNpcTexture";

			public static readonly string AddWorkOrderSetClaimingNpc = "WorkOrders_AddOrderSetClaimingNpc";

			public static readonly string AddWorkOrderSetClaimingNpcWithTexture = "WorkOrders_AddOrderSetClaimingNpcWithTexture";

			public static readonly string AddWorkOrderSetClientNpcSetClaimingNpc = "WorkOrders_AddOrderSetClientNpcSetClaimingNpc";

			public static readonly string AddWorkOrderSetClientNpcSetClaimingNpcWithTexture = "WorkOrders_AddOrderSetClientNpcSetClaimingNpcWithTexture";

			public static readonly string AddWorkOrderWithParameters = "WorkOrders_AddOrderWithParameters";

			public static readonly string AddAnyOfTwoDevicesWorkOrder = "WorkOrders_AddAnyOfTwoDevicesOrder";

			public static readonly string AddAnyOfTwoDevicesWorkOrderWithClaimingNpcTexture = "WorkOrders_AddAnyOfTwoDevicesOrderWithClaimingNpcTexture";

			public static readonly string AddAnyOfTwoDevicesWorkOrderSetClaimingNpc = "WorkOrders_AddAnyOfTwoDevicesOrderSetClaimingNpc";

			public static readonly string AddAnyOfTwoDevicesWorkOrderSetClaimingNpcWithTexture = "WorkOrders_AddAnyOfTwoDevicesOrderSetClaimingNpcWithTexture";

			public static readonly string AddAnyOfTwoDevicesWorkOrderSetClientNpcSetClaimingNpc = "WorkOrders_AddAnyOfTwoDevicesOrderSetClientNpcSetClaimingNpc";

			public static readonly string AddAnyOfTwoDevicesWorkOrderSetClientNpcSetClaimingNpcWithTexture = "WorkOrders_AddAnyOfTwoDevicesOrderSetClientNpcSetClaimingNpcWithTexture";

			public static readonly string AddAnyOfDevicesSpawnOneWorkOrder = "WorkOrders_AddAnyOfDevicesSpawnOneOrder";

			public static readonly string AddAnyOfDevicesSpawnOneWorkOrderWithClaimingNpcTexture = "WorkOrders_AddAnyOfDevicesSpawnOneOrderWithClaimingNpcTexture";

			public static readonly string AddAnyOfDevicesSpawnOneWorkOrderSetClaimingNpc = "WorkOrders_AddAnyOfDevicesSpawnOneOrderSetClaimingNpc";

			public static readonly string AddAnyOfDevicesSpawnOneWorkOrderSetClaimingNpcWithTexture = "WorkOrders_AddAnyOfDevicesSpawnOneOrderSetClaimingNpcWithTexture";

			public static readonly string AddAnyOfDevicesSpawnOneWorkOrderSetClientNpcSetClaimingNpc = "WorkOrders_AddAnyOfDevicesSpawnOneOrderSetClientNpcSetClaimingNpc";

			public static readonly string AddAnyOfDevicesSpawnOneWorkOrderSetClientNpcSetClaimingNpcWithTexture = "WorkOrders_AddAnyOfDevicesSpawnOneOrderSetClientNpcSetClaimingNpcWithTexture";

			public static readonly string GetWorkOrderRewardAmount = "WorkOrders_GetWorkOrderRewardAmount";

			public static readonly string CancelOrder = "WorkOrders_CancelOrder";

			public static readonly string SkipVisitForOrder = "WorkOrders_SkipVisitForOrder";

			public static readonly string TryReleaseReward = "WorkOrders_TryReleaseReward";

			public static readonly string TryCancelReward = "WorkOrders_TryCancelReward";

			public static readonly string TryCollectDevice = "WorkOrders_TryCollectDevice";

			public static readonly string TryCancelDevice = "WorkOrders_TryCancelDevice";
		}

		private readonly GameEntityDataBaseProvider gameEntityDataBaseProvider;

		private readonly WorkOrdersService workOrdersService;

		private readonly DialogueSystemController dialogueSystemController;

		private readonly WorkOrdersPricesTableProvidingService workOrdersPricesTableProvider;

		private readonly CurrentDayVisitsQueueService currentDayVisitsQueueTracker;

		private readonly AvailableDevicesWorkTypesTrackingService availableDevicesWorkTypesTracker;

		public WorkOrdersLuaWrappers(GameEntityDataBaseProvider gameEntityDataBaseProvider, WorkOrdersService workOrdersService, DialogueSystemController dialogueSystemController, WorkOrdersPricesTableProvidingService workOrdersPricesTableProvider, CurrentDayVisitsQueueService currentDayVisitsQueueTracker, AvailableDevicesWorkTypesTrackingService availableDevicesWorkTypesTracker)
		{
			this.dialogueSystemController = dialogueSystemController;
			this.gameEntityDataBaseProvider = gameEntityDataBaseProvider;
			this.workOrdersService = workOrdersService;
			this.workOrdersPricesTableProvider = workOrdersPricesTableProvider;
			this.currentDayVisitsQueueTracker = currentDayVisitsQueueTracker;
			this.availableDevicesWorkTypesTracker = availableDevicesWorkTypesTracker;
		}

		public void Initialize()
		{
			Subscribe();
		}

		public void Dispose()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			Lua.RegisterFunction(LuaNames.AddWorkOrder, this, SymbolExtensions.GetMethodInfo(() => AddWorkOrder(string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddWorkOrderWithParameters, this, SymbolExtensions.GetMethodInfo(() => AddWorkOrderWithParameters(string.Empty)));
			Lua.RegisterFunction(LuaNames.AddWorkOrderWithClaimingNpcTexture, this, SymbolExtensions.GetMethodInfo(() => AddWorkOrderWithClaimingNpcTexture(string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddWorkOrderSetClaimingNpc, this, SymbolExtensions.GetMethodInfo(() => AddWorkOrder(string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddWorkOrderSetClaimingNpcWithTexture, this, SymbolExtensions.GetMethodInfo(() => AddWorkOrderWithClaimingNpcTexture(string.Empty, string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddWorkOrderSetClientNpcSetClaimingNpc, this, SymbolExtensions.GetMethodInfo(() => AddWorkOrder(string.Empty, string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddWorkOrderSetClientNpcSetClaimingNpcWithTexture, this, SymbolExtensions.GetMethodInfo(() => AddWorkOrderWithClaimingNpcTexture(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddAnyOfTwoDevicesWorkOrder, this, SymbolExtensions.GetMethodInfo(() => AddAnyOfTwoDevicesWorkOrder(string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddAnyOfTwoDevicesWorkOrderSetClaimingNpc, this, SymbolExtensions.GetMethodInfo(() => AddAnyOfTwoDevicesWorkOrder(string.Empty, string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddAnyOfTwoDevicesWorkOrderSetClientNpcSetClaimingNpc, this, SymbolExtensions.GetMethodInfo(() => AddAnyOfTwoDevicesWorkOrder(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddAnyOfTwoDevicesWorkOrderWithClaimingNpcTexture, this, SymbolExtensions.GetMethodInfo(() => AddAnyOfTwoDevicesWorkOrderWithClaimingNpcTexture(string.Empty, string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddAnyOfTwoDevicesWorkOrderSetClaimingNpcWithTexture, this, SymbolExtensions.GetMethodInfo(() => AddAnyOfTwoDevicesWorkOrderWithClaimingNpcTexture(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddAnyOfTwoDevicesWorkOrderSetClientNpcSetClaimingNpcWithTexture, this, SymbolExtensions.GetMethodInfo(() => AddAnyOfTwoDevicesWorkOrderWithClaimingNpcTexture(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddAnyOfDevicesSpawnOneWorkOrder, this, SymbolExtensions.GetMethodInfo(() => AddAnyOfDevicesWorkOrderSpawnOne(string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddAnyOfDevicesSpawnOneWorkOrderSetClaimingNpc, this, SymbolExtensions.GetMethodInfo(() => AddAnyOfDevicesWorkOrderSpawnOne(string.Empty, string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddAnyOfDevicesSpawnOneWorkOrderSetClientNpcSetClaimingNpc, this, SymbolExtensions.GetMethodInfo(() => AddAnyOfDevicesWorkOrderSpawnOne(string.Empty, string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddAnyOfDevicesSpawnOneWorkOrderWithClaimingNpcTexture, this, SymbolExtensions.GetMethodInfo(() => AddAnyOfDevicesWorkOrderSpawnOneWithClaimingNpcTexture(string.Empty, string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddAnyOfDevicesSpawnOneWorkOrderSetClaimingNpcWithTexture, this, SymbolExtensions.GetMethodInfo(() => AddAnyOfDevicesWorkOrderSpawnOneWithClaimingNpcTexture(string.Empty, string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.AddAnyOfDevicesSpawnOneWorkOrderSetClientNpcSetClaimingNpcWithTexture, this, SymbolExtensions.GetMethodInfo(() => AddAnyOfDevicesWorkOrderSpawnOneWithClaimingNpcTexture(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)));
			Lua.RegisterFunction(LuaNames.GetWorkOrderRewardAmount, this, SymbolExtensions.GetMethodInfo(() => GetWorkOrderRewardAmount(string.Empty)));
			Lua.RegisterFunction(LuaNames.CancelOrder, this, SymbolExtensions.GetMethodInfo(() => CancelWorkOrder()));
			Lua.RegisterFunction(LuaNames.SkipVisitForOrder, this, SymbolExtensions.GetMethodInfo(() => SkipVisitForWorkOrder(0f)));
			Lua.RegisterFunction(LuaNames.TryReleaseReward, this, SymbolExtensions.GetMethodInfo(() => TryReleaseReward()));
			Lua.RegisterFunction(LuaNames.TryCancelReward, this, SymbolExtensions.GetMethodInfo(() => TryCancelReward()));
			Lua.RegisterFunction(LuaNames.TryCollectDevice, this, SymbolExtensions.GetMethodInfo(() => TryCollectDevice()));
			Lua.RegisterFunction(LuaNames.TryCancelDevice, this, SymbolExtensions.GetMethodInfo(() => TryCancelDevice()));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.AddWorkOrder);
			Lua.UnregisterFunction(LuaNames.AddWorkOrderWithParameters);
			Lua.UnregisterFunction(LuaNames.AddWorkOrderWithClaimingNpcTexture);
			Lua.UnregisterFunction(LuaNames.AddWorkOrderSetClaimingNpc);
			Lua.UnregisterFunction(LuaNames.AddWorkOrderSetClaimingNpcWithTexture);
			Lua.UnregisterFunction(LuaNames.AddWorkOrderSetClientNpcSetClaimingNpc);
			Lua.UnregisterFunction(LuaNames.AddWorkOrderSetClientNpcSetClaimingNpcWithTexture);
			Lua.UnregisterFunction(LuaNames.AddAnyOfTwoDevicesWorkOrder);
			Lua.UnregisterFunction(LuaNames.AddAnyOfTwoDevicesWorkOrderWithClaimingNpcTexture);
			Lua.UnregisterFunction(LuaNames.AddAnyOfTwoDevicesWorkOrderSetClaimingNpc);
			Lua.UnregisterFunction(LuaNames.AddAnyOfTwoDevicesWorkOrderSetClaimingNpcWithTexture);
			Lua.UnregisterFunction(LuaNames.AddAnyOfTwoDevicesWorkOrderSetClientNpcSetClaimingNpc);
			Lua.UnregisterFunction(LuaNames.AddAnyOfTwoDevicesWorkOrderSetClientNpcSetClaimingNpcWithTexture);
			Lua.UnregisterFunction(LuaNames.AddAnyOfDevicesSpawnOneWorkOrder);
			Lua.UnregisterFunction(LuaNames.AddAnyOfDevicesSpawnOneWorkOrderWithClaimingNpcTexture);
			Lua.UnregisterFunction(LuaNames.AddAnyOfDevicesSpawnOneWorkOrderSetClaimingNpc);
			Lua.UnregisterFunction(LuaNames.AddAnyOfDevicesSpawnOneWorkOrderSetClaimingNpcWithTexture);
			Lua.UnregisterFunction(LuaNames.AddAnyOfDevicesSpawnOneWorkOrderSetClientNpcSetClaimingNpc);
			Lua.UnregisterFunction(LuaNames.AddAnyOfDevicesSpawnOneWorkOrderSetClientNpcSetClaimingNpcWithTexture);
			Lua.UnregisterFunction(LuaNames.GetWorkOrderRewardAmount);
			Lua.UnregisterFunction(LuaNames.CancelOrder);
			Lua.UnregisterFunction(LuaNames.SkipVisitForOrder);
			Lua.UnregisterFunction(LuaNames.TryReleaseReward);
			Lua.UnregisterFunction(LuaNames.TryCancelReward);
			Lua.UnregisterFunction(LuaNames.TryCollectDevice);
		}

		private void AddWorkOrderWithParameters(string workOrderParametersID)
		{
			if (TryGetCurrentNpcInConversationWithPlayer(out var currentNpc) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<WorkOrderParameters>(workOrderParametersID, out var entityInfo))
			{
				TryGetPaintingWorkTypeFromWorkOrderParameters(entityInfo, out var paintingWorkType);
				workOrdersService.AddCleanAndRepairSingleDeviceOrder(entityInfo.DeviceCondition, currentNpc, entityInfo.ClaimingNpc ? entityInfo.ClaimingNpc : currentNpc, entityInfo.RewardID, entityInfo.ClaimingNpcTextureID, paintingWorkType);
			}
		}

		private void AddWorkOrder(string deviceConditionID, string rewardID)
		{
			if (TryGetCurrentNpcInConversationWithPlayer(out var currentNpc) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionID, out var entityInfo))
			{
				workOrdersService.AddCleanAndRepairSingleDeviceOrder(entityInfo, currentNpc, currentNpc, rewardID, "");
			}
		}

		private void AddWorkOrder(string deviceConditionID, string orderClaimingNpcID, string rewardID)
		{
			if (TryGetCurrentNpcInConversationWithPlayer(out var currentNpc) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderClaimingNpcID, out var entityInfo) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionID, out var entityInfo2))
			{
				workOrdersService.AddCleanAndRepairSingleDeviceOrder(entityInfo2, currentNpc, entityInfo, rewardID, "");
			}
		}

		private void AddWorkOrder(string deviceConditionID, string orderPlacingNpcID, string orderClaimingNpcID, string rewardID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderClaimingNpcID, out var entityInfo) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderPlacingNpcID, out var entityInfo2) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionID, out var entityInfo3))
			{
				workOrdersService.AddCleanAndRepairSingleDeviceOrder(entityInfo3, entityInfo2, entityInfo, rewardID, "");
			}
		}

		private void AddWorkOrderWithClaimingNpcTexture(string deviceConditionID, string orderClaimingNpcTextureID, string rewardID)
		{
			if (TryGetCurrentNpcInConversationWithPlayer(out var currentNpc) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionID, out var entityInfo))
			{
				workOrdersService.AddCleanAndRepairSingleDeviceOrder(entityInfo, currentNpc, currentNpc, rewardID, orderClaimingNpcTextureID);
			}
		}

		private void AddWorkOrderWithClaimingNpcTexture(string deviceConditionID, string orderClaimingNpcID, string orderClaimingNpcTextureID, string rewardID)
		{
			if (TryGetCurrentNpcInConversationWithPlayer(out var currentNpc) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderClaimingNpcID, out var entityInfo) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionID, out var entityInfo2))
			{
				workOrdersService.AddCleanAndRepairSingleDeviceOrder(entityInfo2, currentNpc, entityInfo, rewardID, orderClaimingNpcTextureID);
			}
		}

		private void AddWorkOrderWithClaimingNpcTexture(string deviceConditionID, string orderPlacingNpcID, string orderClaimingNpcID, string orderClaimingNpcTextureID, string rewardID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderClaimingNpcID, out var entityInfo) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderPlacingNpcID, out var entityInfo2) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionID, out var entityInfo3))
			{
				workOrdersService.AddCleanAndRepairSingleDeviceOrder(entityInfo3, entityInfo2, entityInfo, rewardID, orderClaimingNpcTextureID);
			}
		}

		private void AddAnyOfTwoDevicesWorkOrder(string deviceCondition1ID, string deviceCondition2ID, string rewardID)
		{
			if (TryGetCurrentNpcInConversationWithPlayer(out var currentNpc) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceCondition1ID, out var entityInfo) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceCondition2ID, out var entityInfo2))
			{
				List<DeviceCondition> list = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				list.Add(entityInfo);
				list.Add(entityInfo2);
				workOrdersService.AddCleanAndRepairAnyDeviceOrder(list, currentNpc, currentNpc, rewardID);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list);
			}
		}

		private void AddAnyOfTwoDevicesWorkOrder(string deviceCondition1ID, string deviceCondition2ID, string orderClaimingNpcID, string rewardID)
		{
			if (TryGetCurrentNpcInConversationWithPlayer(out var currentNpc) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderClaimingNpcID, out var entityInfo) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceCondition1ID, out var entityInfo2) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceCondition2ID, out var entityInfo3))
			{
				List<DeviceCondition> list = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				list.Add(entityInfo2);
				list.Add(entityInfo3);
				workOrdersService.AddCleanAndRepairAnyDeviceOrder(list, currentNpc, entityInfo, rewardID);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list);
			}
		}

		private void AddAnyOfTwoDevicesWorkOrder(string deviceCondition1ID, string deviceCondition2ID, string orderPlacingNpcID, string orderClaimingNpcID, string rewardID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderClaimingNpcID, out var entityInfo) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderPlacingNpcID, out var entityInfo2) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceCondition1ID, out var entityInfo3) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceCondition2ID, out var entityInfo4))
			{
				List<DeviceCondition> list = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				list.Add(entityInfo3);
				list.Add(entityInfo4);
				workOrdersService.AddCleanAndRepairAnyDeviceOrder(list, entityInfo2, entityInfo, rewardID);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list);
			}
		}

		private void AddAnyOfTwoDevicesWorkOrderWithClaimingNpcTexture(string deviceCondition1ID, string deviceCondition2ID, string claimingNpcTextureID, string rewardID)
		{
			if (TryGetCurrentNpcInConversationWithPlayer(out var currentNpc) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceCondition1ID, out var entityInfo) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceCondition2ID, out var entityInfo2))
			{
				List<DeviceCondition> list = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				list.Add(entityInfo);
				list.Add(entityInfo2);
				workOrdersService.AddCleanAndRepairAnyDeviceOrder(list, currentNpc, currentNpc, rewardID, claimingNpcTextureID);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list);
			}
		}

		private void AddAnyOfTwoDevicesWorkOrderWithClaimingNpcTexture(string deviceCondition1ID, string deviceCondition2ID, string orderClaimingNpcID, string claimingNpcTextureID, string rewardID)
		{
			if (TryGetCurrentNpcInConversationWithPlayer(out var currentNpc) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderClaimingNpcID, out var entityInfo) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceCondition1ID, out var entityInfo2) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceCondition2ID, out var entityInfo3))
			{
				List<DeviceCondition> list = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				list.Add(entityInfo2);
				list.Add(entityInfo3);
				workOrdersService.AddCleanAndRepairAnyDeviceOrder(list, currentNpc, entityInfo, rewardID, claimingNpcTextureID);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list);
			}
		}

		private void AddAnyOfTwoDevicesWorkOrderWithClaimingNpcTexture(string deviceCondition1ID, string deviceCondition2ID, string orderPlacingNpcID, string orderClaimingNpcID, string claimingNpcTextureID, string rewardID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderClaimingNpcID, out var entityInfo) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderPlacingNpcID, out var entityInfo2) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceCondition1ID, out var entityInfo3) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceCondition2ID, out var entityInfo4))
			{
				List<DeviceCondition> list = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				list.Add(entityInfo3);
				list.Add(entityInfo4);
				workOrdersService.AddCleanAndRepairAnyDeviceOrder(list, entityInfo2, entityInfo, rewardID, claimingNpcTextureID);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list);
			}
		}

		private void AddAnyOfDevicesWorkOrderSpawnOne(string deviceConditionToSpawnID, string deviceConditionToTrackID, string rewardID)
		{
			if (TryGetCurrentNpcInConversationWithPlayer(out var currentNpc) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionToSpawnID, out var entityInfo) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionToTrackID, out var entityInfo2))
			{
				List<DeviceCondition> list = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				List<DeviceCondition> list2 = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				list.Add(entityInfo);
				list2.Add(entityInfo2);
				workOrdersService.AddCleanAndRepairAnySpawnedAndTrackedDeviceOrder(list, list2, currentNpc, currentNpc, rewardID);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list2);
			}
		}

		private void AddAnyOfDevicesWorkOrderSpawnOne(string deviceConditionToSpawnID, string deviceConditionToTrackID, string orderClaimingNpcID, string rewardID)
		{
			if (TryGetCurrentNpcInConversationWithPlayer(out var currentNpc) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderClaimingNpcID, out var entityInfo) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionToSpawnID, out var entityInfo2) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionToTrackID, out var entityInfo3))
			{
				List<DeviceCondition> list = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				List<DeviceCondition> list2 = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				list.Add(entityInfo2);
				list2.Add(entityInfo3);
				workOrdersService.AddCleanAndRepairAnySpawnedAndTrackedDeviceOrder(list, list2, currentNpc, entityInfo, rewardID);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list2);
			}
		}

		private void AddAnyOfDevicesWorkOrderSpawnOne(string deviceConditionToSpawnID, string deviceConditionToTrackID, string orderPlacingNpcID, string orderClaimingNpcID, string rewardID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderClaimingNpcID, out var entityInfo) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderPlacingNpcID, out var entityInfo2) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionToSpawnID, out var entityInfo3) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionToTrackID, out var entityInfo4))
			{
				List<DeviceCondition> list = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				List<DeviceCondition> list2 = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				list.Add(entityInfo3);
				list2.Add(entityInfo4);
				workOrdersService.AddCleanAndRepairAnySpawnedAndTrackedDeviceOrder(list, list2, entityInfo2, entityInfo, rewardID);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list2);
			}
		}

		private void AddAnyOfDevicesWorkOrderSpawnOneWithClaimingNpcTexture(string deviceConditionToSpawnID, string deviceConditionToTrackID, string claimingNpcTextureID, string rewardID)
		{
			if (TryGetCurrentNpcInConversationWithPlayer(out var currentNpc) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionToSpawnID, out var entityInfo) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionToTrackID, out var entityInfo2))
			{
				List<DeviceCondition> list = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				List<DeviceCondition> list2 = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				list.Add(entityInfo);
				list2.Add(entityInfo2);
				workOrdersService.AddCleanAndRepairAnySpawnedAndTrackedDeviceOrder(list, list2, currentNpc, currentNpc, rewardID, claimingNpcTextureID);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list2);
			}
		}

		private void AddAnyOfDevicesWorkOrderSpawnOneWithClaimingNpcTexture(string deviceConditionToSpawnID, string deviceConditionToTrackID, string orderClaimingNpcID, string claimingNpcTextureID, string rewardID)
		{
			if (TryGetCurrentNpcInConversationWithPlayer(out var currentNpc) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderClaimingNpcID, out var entityInfo) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionToSpawnID, out var entityInfo2) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionToTrackID, out var entityInfo3))
			{
				List<DeviceCondition> list = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				List<DeviceCondition> list2 = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				list.Add(entityInfo2);
				list2.Add(entityInfo3);
				workOrdersService.AddCleanAndRepairAnySpawnedAndTrackedDeviceOrder(list, list2, currentNpc, entityInfo, rewardID, claimingNpcTextureID);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list2);
			}
		}

		private void AddAnyOfDevicesWorkOrderSpawnOneWithClaimingNpcTexture(string deviceConditionToSpawnID, string deviceConditionToTrackID, string orderPlacingNpcID, string orderClaimingNpcID, string claimingNpcTextureID, string rewardID)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderClaimingNpcID, out var entityInfo) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<StoryNpcInfo>(orderPlacingNpcID, out var entityInfo2) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionToSpawnID, out var entityInfo3) && gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<DeviceCondition>(deviceConditionToTrackID, out var entityInfo4))
			{
				List<DeviceCondition> list = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				List<DeviceCondition> list2 = CollectionPool<List<DeviceCondition>, DeviceCondition>.Get();
				list.Add(entityInfo3);
				list2.Add(entityInfo4);
				workOrdersService.AddCleanAndRepairAnySpawnedAndTrackedDeviceOrder(list, list2, entityInfo2, entityInfo, rewardID, claimingNpcTextureID);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list);
				CollectionPool<List<DeviceCondition>, DeviceCondition>.Release(list2);
			}
		}

		private int GetWorkOrderRewardAmount(string rewardID)
		{
			if (workOrdersPricesTableProvider.TryGetWorkOrderPaymentAmount(rewardID, out var moneyAmount))
			{
				return moneyAmount;
			}
			return 0;
		}

		private bool TryGetCurrentNpcInConversationWithPlayer(out StoryNpcInfo currentNpc)
		{
			currentNpc = null;
			if (!dialogueSystemController.isConversationActive)
			{
				return false;
			}
			CharacterInfo characterInfo = (dialogueSystemController.conversationController.actorInfo.isPlayer ? dialogueSystemController.conversationController.conversantInfo : dialogueSystemController.conversationController.actorInfo);
			foreach (RestoryEntityInfoBase item in gameEntityDataBaseProvider.Asset.All)
			{
				if (!(item is StoryNpcInfo storyNpcInfo))
				{
					continue;
				}
				foreach (string dialogueActor in storyNpcInfo.DialogueActors)
				{
					if (characterInfo.nameInDatabase == dialogueActor)
					{
						currentNpc = storyNpcInfo;
						return true;
					}
				}
			}
			return false;
		}

		private void CancelWorkOrder()
		{
			if (currentDayVisitsQueueTracker.VisitCurrentlyInProgress.Visit is IWorkOrderClaimingNpcVisit workOrderClaimingNpcVisit)
			{
				workOrdersService.CancelDeviceOrder(workOrderClaimingNpcVisit.WorkOrderID);
			}
		}

		private void SkipVisitForWorkOrder(float timeInGameMinutes)
		{
			if (currentDayVisitsQueueTracker.VisitCurrentlyInProgress.Visit is IWorkOrderClaimingNpcVisit workOrderClaimingNpcVisit)
			{
				workOrdersService.SetSkipVisit(workOrderClaimingNpcVisit.WorkOrderID, skipVisit: true, TimeSpan.FromMinutes(timeInGameMinutes));
			}
		}

		private void TryReleaseReward()
		{
			if (currentDayVisitsQueueTracker.VisitCurrentlyInProgress.Visit is IWorkOrderClaimingNpcVisit workOrderClaimingNpcVisit)
			{
				workOrdersService.GiveReward(workOrderClaimingNpcVisit.WorkOrderID);
			}
		}

		private void TryCancelReward()
		{
			if (currentDayVisitsQueueTracker.VisitCurrentlyInProgress.Visit is IWorkOrderClaimingNpcVisit workOrderClaimingNpcVisit)
			{
				workOrdersService.CancelGiveReward(workOrderClaimingNpcVisit.WorkOrderID);
			}
		}

		private void TryCollectDevice()
		{
			if (currentDayVisitsQueueTracker.VisitCurrentlyInProgress.Visit is IWorkOrderClaimingNpcVisit workOrderClaimingNpcVisit)
			{
				workOrdersService.GiveDevice(workOrderClaimingNpcVisit.WorkOrderID);
			}
		}

		private void TryCancelDevice()
		{
			if (currentDayVisitsQueueTracker.VisitCurrentlyInProgress.Visit is IWorkOrderClaimingNpcVisit workOrderClaimingNpcVisit)
			{
				workOrdersService.CancelGiveDevice(workOrderClaimingNpcVisit.WorkOrderID);
			}
		}

		private bool TryGetPaintingWorkTypeFromWorkOrderParameters(WorkOrderParameters workOrderParameters, out DeviceWorkTypePaintBase paintingWorkType)
		{
			paintingWorkType = null;
			if (!workOrderParameters.AddPaintingToWorkOrder)
			{
				return false;
			}
			if ((bool)workOrderParameters.ConcretePaintingPalette)
			{
				foreach (DeviceWorkType allDeviceWorkType in availableDevicesWorkTypesTracker.AllDeviceWorkTypes)
				{
					if (allDeviceWorkType is DeviceWorkTypePaintConcretePalette deviceWorkTypePaintConcretePalette)
					{
						DeviceWorkTypePaintConcretePalette deviceWorkTypePaintConcretePalette2 = deviceWorkTypePaintConcretePalette.Clone() as DeviceWorkTypePaintConcretePalette;
						deviceWorkTypePaintConcretePalette2.ConcretePalette = workOrderParameters.ConcretePaintingPalette;
						paintingWorkType = deviceWorkTypePaintConcretePalette2;
					}
				}
			}
			else
			{
				foreach (DeviceWorkType allDeviceWorkType2 in availableDevicesWorkTypesTracker.AllDeviceWorkTypes)
				{
					if (allDeviceWorkType2 is DeviceWorkTypePaintAnyColors deviceWorkTypePaintAnyColors)
					{
						paintingWorkType = deviceWorkTypePaintAnyColors.Clone() as DeviceWorkTypePaintAnyColors;
					}
				}
			}
			return true;
		}
	}
}
