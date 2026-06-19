using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Inventory
{
	public static class Create
	{
		public static InventoryChangeData ConsumeObjectType(Entity inventory, ObjectID objectID, int amount)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.ConsumeObjectType,
				inventory1 = inventory,
				index1 = (int)objectID,
				amount = amount
			};
		}

		public static InventoryChangeData ConsumeEntityAt(Entity inventory, int index, int amount, bool destroy, bool dontConsume, float3 positionToSet = default(float3), int variationToInstatiate = -1, float3 direction = default(float3), ObjectID optionalTargetObjectID = ObjectID.None)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.ConsumeEntityAt,
				inventory1 = inventory,
				index1 = index,
				amount = amount,
				bool1 = destroy,
				bool2 = dontConsume,
				position1 = positionToSet,
				index2 = variationToInstatiate,
				position2 = direction,
				index3 = (int)optionalTargetObjectID
			};
		}

		public static InventoryChangeData CreateItem(Entity inventory, int index, ObjectID objectID, int amount, float3 position, int variation)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.CreateObject,
				inventory1 = inventory,
				index1 = index,
				index2 = (int)objectID,
				amount = amount,
				position1 = position,
				variation = variation
			};
		}

		public static InventoryChangeData AddAmount(Entity inventory, int index, ObjectID objectID, int amount)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.AddAmount,
				inventory1 = inventory,
				index1 = index,
				index2 = (int)objectID,
				amount = amount
			};
		}

		public static InventoryChangeData SetAmount(Entity inventory, int index, ObjectID objectID, int amount)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.SetAmount,
				inventory1 = inventory,
				index1 = index,
				index2 = (int)objectID,
				amount = amount
			};
		}

		public static InventoryChangeData SetVariation(Entity inventory, int index, ObjectID objectID, int variation)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.SetVariation,
				inventory1 = inventory,
				index1 = index,
				index2 = (int)objectID,
				variation = variation
			};
		}

		public static InventoryChangeData DropAllItemsAt(Entity inventory, int index, float3 position, Entity blockImmediatePickFor = default(Entity))
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.DropAllItemsAt,
				inventory1 = inventory,
				index1 = index,
				position1 = position,
				entityOrInventory2 = blockImmediatePickFor
			};
		}

		public static InventoryChangeData DropItem(Entity inventory, int index, int amount, float3 position, Entity blockImmediatePickFor = default(Entity))
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.DropItem,
				inventory1 = inventory,
				index1 = index,
				amount = amount,
				position1 = position,
				entityOrInventory2 = blockImmediatePickFor
			};
		}

		public static InventoryChangeData PickUpObject(Entity entityToPickUp, Entity inventory, int index, float3 position)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.PickUpObject,
				inventory1 = inventory,
				entityOrInventory2 = entityToPickUp,
				index1 = index,
				position1 = position
			};
		}

		public static InventoryChangeData MoveAmount(Entity inventoryFrom, int indexFrom, Entity inventoryTo, int indexToHint, int endIndex, int amount, bool destroyExisting)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.MoveAmount,
				inventory1 = inventoryFrom,
				entityOrInventory2 = inventoryTo,
				index1 = indexFrom,
				index2 = indexToHint,
				index3 = endIndex,
				amount = amount,
				bool1 = destroyExisting
			};
		}

		public static InventoryChangeData MoveOrDropItem(Entity inventoryFrom, int indexFrom, Entity inventoryTo, int indexToHint, int endIndex, float3 position)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.MoveOrDropItem,
				inventory1 = inventoryFrom,
				entityOrInventory2 = inventoryTo,
				index1 = indexFrom,
				index2 = indexToHint,
				index3 = endIndex,
				position1 = position
			};
		}

		public static InventoryChangeData MoveOrDropItemIgnoreGuestMode(Entity inventoryFrom, int indexFrom, Entity inventoryTo, int indexToHint, int endIndex, float3 position)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.MoveOrDropItemIgnoreGuestMode,
				inventory1 = inventoryFrom,
				entityOrInventory2 = inventoryTo,
				index1 = indexFrom,
				index2 = indexToHint,
				index3 = endIndex,
				position1 = position
			};
		}

		public static InventoryChangeData MoveOrDropAllItems(Entity inventoryFrom, Entity inventoryTo, int indexToHint, int endIndex, float3 position)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.MoveOrDropAllItems,
				inventory1 = inventoryFrom,
				entityOrInventory2 = inventoryTo,
				index2 = indexToHint,
				index3 = endIndex,
				position1 = position
			};
		}

		public static InventoryChangeData MoveOrDropAmount(Entity inventoryFrom, int indexFrom, Entity inventoryTo, int indexToHint, int endIndex, int amount, float3 position)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.MoveOrDropAmount,
				inventory1 = inventoryFrom,
				entityOrInventory2 = inventoryTo,
				index1 = indexFrom,
				index2 = indexToHint,
				index3 = endIndex,
				amount = amount,
				position1 = position
			};
		}

		public static InventoryChangeData MoveOrDropItems(Entity inventoryFrom, int indexFrom, int fromEndIndex, Entity inventoryTo, int indexToHint, int toEndIndex, float3 position)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.MoveOrDropItems,
				inventory1 = inventoryFrom,
				entityOrInventory2 = inventoryTo,
				index1 = indexFrom,
				index2 = fromEndIndex,
				index3 = toEndIndex,
				index4 = toEndIndex,
				position1 = position
			};
		}

		public static InventoryChangeData DropAllItems(Entity inventory, float3 position, Entity blockImmediatePickFor, bool randomOffset)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.DropAllItems,
				inventory1 = inventory,
				position1 = position,
				entityOrInventory2 = blockImmediatePickFor,
				bool1 = randomOffset
			};
		}

		public static InventoryChangeData Swap(Entity inventory1, Entity inventory2, int index1, int index2)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.Swap,
				inventory1 = inventory1,
				entityOrInventory2 = inventory2,
				index1 = index1,
				index2 = index2
			};
		}

		public static InventoryChangeData DestroyObjectAt(Entity inventory, int index, ObjectID objectID)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.Destroy,
				inventory1 = inventory,
				index1 = index,
				index2 = (int)objectID
			};
		}

		public static InventoryChangeData DestroyObjects(Entity inventory, int startIndex, int endIndex)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.DestroyItems,
				inventory1 = inventory,
				index1 = startIndex,
				index2 = endIndex
			};
		}

		public static InventoryChangeData Sell(Entity inventorySeller, int indexSell, Entity inventoryBuyer, int indexBuy, int endIndex, ObjectID objectID, int amount, int coinAmount, float3 position)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.Sell,
				inventory1 = inventorySeller,
				entityOrInventory2 = inventoryBuyer,
				index1 = indexSell,
				index2 = indexBuy,
				index3 = endIndex,
				objectID = objectID,
				amount = amount,
				variation = coinAmount,
				position1 = position
			};
		}

		public static InventoryChangeData QuickStack(Entity inventoryFrom, Entity inventoryTo)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.QuickStack,
				inventory1 = inventoryFrom,
				entityOrInventory2 = inventoryTo
			};
		}

		public static InventoryChangeData Sort(Entity inventory, bool isPlayerInventory)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.Sort,
				inventory1 = inventory,
				bool1 = isPlayerInventory
			};
		}

		public static InventoryChangeData ToggleLock(Entity inventory, int index)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.ToggleLock,
				inventory1 = inventory,
				index1 = index
			};
		}

		public static InventoryChangeData MoveInventory(Entity inventoryFrom, Entity inventoryTo, int fromStartIndex = 0, int amountOfSlots = -1, int toStartIndex = 0)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.MoveInventory,
				inventory1 = inventoryFrom,
				entityOrInventory2 = inventoryTo,
				index1 = fromStartIndex,
				index2 = amountOfSlots,
				index3 = toStartIndex
			};
		}

		public static InventoryChangeData Buy(Entity sellerInventoryEntity, int sellItemIndex, Entity buyerInventoryEntity, int buyerInventoryStart, int buyerInventorySize)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.Buy,
				inventory1 = sellerInventoryEntity,
				index1 = sellItemIndex,
				entityOrInventory2 = buyerInventoryEntity,
				index2 = buyerInventoryStart,
				index3 = buyerInventorySize
			};
		}

		public static InventoryChangeData QuickStackToNearbyChests(Entity playerEntity)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.QuickStackToNearbyChests,
				inventory1 = playerEntity
			};
		}

		public static InventoryChangeData SetAllItemsInInventoryToLevel(Entity inventoryEntity, int targetLevel)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.SetAllItemsInInventoryToLevel,
				inventory1 = inventoryEntity,
				index1 = targetLevel
			};
		}

		public static CraftActionData Craft(ObjectID objectId, int amount, int additionalFreeAmount, Entity playerEntity, Entity craftingEntity)
		{
			return new CraftActionData
			{
				craftAction = CraftAction.Craft,
				playerEntity = playerEntity,
				mainInventoryEntity = playerEntity,
				craftingEntity = craftingEntity,
				objectId = objectId,
				amount = amount,
				additionalFreeAmount = additionalFreeAmount
			};
		}

		public static CraftActionData CraftParchmentRecipe(Entity playerEntity, ObjectID equippedObjectID, int variation, int equippedIndex)
		{
			return new CraftActionData
			{
				craftAction = CraftAction.CraftParchmentRecipe,
				playerEntity = playerEntity,
				mainInventoryEntity = playerEntity,
				objectId = equippedObjectID,
				int0 = variation,
				int1 = equippedIndex
			};
		}

		public static CraftActionData RepairAllItems(Entity inventoryEntity, bool reinforce)
		{
			return new CraftActionData
			{
				craftAction = CraftAction.RepairOrReinforceAllItems,
				targetInventoryEntity = inventoryEntity,
				playerEntity = inventoryEntity,
				craftingEntity = inventoryEntity,
				mainInventoryEntity = inventoryEntity,
				bool0 = reinforce
			};
		}

		public static CraftActionData RepairOrReinforce(Entity inventoryEntity, int index, ObjectID objectID, int chestsStartIndex, Entity craftingEntity, Entity playerEntity, bool reinforce, bool craftingMaterialsAreNotRequired = false)
		{
			return new CraftActionData
			{
				craftAction = CraftAction.RepairOrReinforce,
				targetInventoryEntity = inventoryEntity,
				objectId = objectID,
				playerEntity = playerEntity,
				mainInventoryEntity = playerEntity,
				craftingEntity = craftingEntity,
				int0 = index,
				int1 = chestsStartIndex,
				bool0 = reinforce,
				bool1 = craftingMaterialsAreNotRequired
			};
		}

		public static CraftActionData Upgrade(Entity inventoryEntity, Entity playerEntity, Entity craftingEntity, int index, ObjectID objectID, int chestsStartIndex, bool craftingMaterialsAreNotRequired)
		{
			return new CraftActionData
			{
				craftAction = CraftAction.Upgrade,
				targetInventoryEntity = inventoryEntity,
				playerEntity = playerEntity,
				mainInventoryEntity = playerEntity,
				craftingEntity = craftingEntity,
				objectId = objectID,
				int0 = index,
				int1 = chestsStartIndex,
				bool0 = craftingMaterialsAreNotRequired
			};
		}

		public static CraftActionData SetupCookBookRecipe(Entity craftingEntity, Entity playerEntity, Entity craftingInventory, bool mod1, ObjectID objectID, int variation)
		{
			return new CraftActionData
			{
				craftAction = CraftAction.SetupCookBookRecipe,
				craftingEntity = craftingEntity,
				playerEntity = playerEntity,
				mainInventoryEntity = playerEntity,
				targetInventoryEntity = craftingInventory,
				bool0 = mod1,
				objectId = objectID,
				int0 = variation
			};
		}

		public static CraftActionData ActivateRecipeSlot(Entity craftingEntity, Entity playerEntity, int multiplier, bool mod1, int recipeIndex)
		{
			return new CraftActionData
			{
				craftAction = CraftAction.ActivateRecipeSlot,
				craftingEntity = craftingEntity,
				playerEntity = playerEntity,
				mainInventoryEntity = playerEntity,
				int0 = multiplier,
				bool0 = mod1,
				int1 = recipeIndex
			};
		}

		public static InventoryChangeData SetName(Entity inventory, int index, ObjectID objectID, FixedString64Bytes name)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.SetName,
				inventory1 = inventory,
				index1 = index,
				objectID = objectID,
				string1 = name
			};
		}

		public static InventoryChangeData SetPetTalentPoints(Entity inventory, int index, ObjectID objectID, int talentIndex, int points)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.SetPetTalentPoints,
				inventory1 = inventory,
				index1 = index,
				objectID = objectID,
				amount = points,
				index2 = talentIndex
			};
		}

		public static InventoryChangeData ResetPetTalentTree(Entity playerEntity, bool forceReset)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.ResetPetTalentTree,
				inventory1 = playerEntity,
				bool1 = forceReset
			};
		}

		public static InventoryChangeData SetInventoryObjectAuthor(Entity inventory, int index, ObjectID objectID, FixedString64Bytes author)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.SetAuthor,
				inventory1 = inventory,
				index1 = index,
				objectID = objectID,
				string1 = author
			};
		}

		public static InventoryChangeData ResetSkillTalentTree(Entity playerEntity, SkillID currentShowingSkillTreeID, bool forceReset)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.ResetSkillTalentTree,
				inventory1 = playerEntity,
				index1 = (int)currentShowingSkillTreeID,
				bool1 = forceReset
			};
		}

		public static InventoryChangeData SalvageAll(Entity inventorySalvage, Entity inventoryToGetScrapParts, float3 position, int indexStart, int size)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.SalvageAll,
				inventory1 = inventorySalvage,
				entityOrInventory2 = inventoryToGetScrapParts,
				position1 = position,
				index1 = indexStart,
				index2 = size
			};
		}

		public static InventoryChangeData SellAll(int startIndex, int size, float3 position, Entity inventoryEntity)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.SellAll,
				inventory1 = inventoryEntity,
				index1 = startIndex,
				index2 = size,
				position1 = position
			};
		}

		public static InventoryChangeData MoveAllOrDropThenTryMove(Entity replaceInventory, int replaceSlot, Entity moveToInventory, int moveToStart, int moveToEnd, Vector3 position, Entity secondMoveInventory, int secondMoveFromSlot, int amount)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.MoveAllOrDropThenTryMove,
				inventory1 = replaceInventory,
				entityOrInventory2 = moveToInventory,
				entityOrInventory3 = secondMoveInventory,
				index1 = replaceSlot,
				index2 = moveToStart,
				index3 = moveToEnd,
				index4 = secondMoveFromSlot,
				amount = amount,
				position1 = position
			};
		}

		public static InventoryChangeData TryReplaceBrokenObject(Entity inventory, int index)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.TryReplaceBrokenObject,
				inventory1 = inventory,
				index1 = index
			};
		}

		public static InventoryChangeData AddFilter(Entity inventory, ObjectID objectID, int variaton)
		{
			return new InventoryChangeData
			{
				inventoryAction = InventoryAction.AddFilter,
				inventory1 = inventory,
				objectID = objectID,
				variation = variaton
			};
		}
	}
}
