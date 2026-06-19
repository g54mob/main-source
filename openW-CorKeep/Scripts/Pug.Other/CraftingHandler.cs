using System.Collections.Generic;
using Inventory;
using Pug.Automation;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

public class CraftingHandler
{
	public struct RecipeInfo
	{
		private ObjectInfo _objectInfo;

		public int amount;

		public bool isValid => _objectInfo != null;

		public ObjectID objectID => _objectInfo.objectID;

		public int initialAmount => _objectInfo.initialAmount;

		public ObjectType objectType => _objectInfo.objectType;

		public float craftingTime => _objectInfo.craftingTime;

		public List<CraftingObject> requiredObjectsToCraft => _objectInfo.requiredObjectsToCraft;

		public Sprite icon => _objectInfo.icon;

		public Vector2 iconOffset => _objectInfo.iconOffset;

		public Rarity rarity => _objectInfo.rarity;

		public RecipeInfo(ObjectInfo objectInfo, int amount)
		{
			_objectInfo = objectInfo;
			this.amount = amount;
		}
	}

	public InventoryHandler inventoryHandler;

	public InventoryHandler outputInventoryHandler;

	private EntityMonoBehaviour entityMonoBehaviour;

	private bool _requiresElectricity;

	private CraftingType _craftingType;

	private int timeLastChecked;

	private int2 timeLastCheckedPosition;

	private List<Entity> cachedNearbyChests;

	public CraftingType craftingType => _craftingType;

	public Entity craftingEntity => entityMonoBehaviour.entity;

	private World world => entityMonoBehaviour.world;

	public CraftingHandler(EntityMonoBehaviour entityMonoBehaviour, World world, bool treatAsAllInventoriesForTransfer)
	{
		this.entityMonoBehaviour = entityMonoBehaviour;
		CraftingCD componentData = EntityUtility.GetComponentData<CraftingCD>(craftingEntity, world);
		inventoryHandler = new InventoryHandler(entityMonoBehaviour, world, isBuyInventory: false, 0, treatAsAllInventoriesForTransfer);
		if (componentData.outputSlotIndex != -1)
		{
			outputInventoryHandler = new InventoryHandler(entityMonoBehaviour, world, componentData.outputSlotIndex, 1, 1);
		}
		_craftingType = componentData.craftingType;
		_requiresElectricity = EntityUtility.HasComponentData<ElectricityCD>(entityMonoBehaviour.entity, world);
	}

	public bool IsAnySlotCrafting()
	{
		if (!EntityUtility.TryGetBuffer(craftingEntity, world, out DynamicBuffer<CraftingTimerSlotBuffer> value))
		{
			return false;
		}
		for (int i = 0; i < value.Length; i++)
		{
			if (IsCrafting(i))
			{
				return true;
			}
		}
		return false;
	}

	public bool IsCrafting(int slotIndex)
	{
		if (_requiresElectricity && !EntityUtility.GetComponentData<ElectricityCD>(craftingEntity, world).hasEnoughElectricityToPowerStuff)
		{
			return false;
		}
		if (EntityUtility.TryGetBuffer(craftingEntity, world, out DynamicBuffer<CraftingTimerSlotBuffer> value))
		{
			if (slotIndex < value.Length)
			{
				return value[slotIndex].timeLeftToCraft > 0f;
			}
			return false;
		}
		return false;
	}

	public bool HasStartedCrafting(int slotIndex)
	{
		if (EntityUtility.TryGetBuffer(craftingEntity, world, out DynamicBuffer<CraftingTimerSlotBuffer> value))
		{
			if (slotIndex < value.Length)
			{
				if (value[slotIndex].timeLeftToCraft >= 0f)
				{
					if (!IsCrafting(slotIndex))
					{
						return !Mathf.Approximately(GetNormalizedElapsedCraftingTime(slotIndex), 0f);
					}
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public bool IsAutoCrafter()
	{
		return CraftingCD.IsProcessAutoCrafter(_craftingType);
	}

	public bool RequiresElectricity()
	{
		return _requiresElectricity;
	}

	public bool HasElectricity()
	{
		if (_requiresElectricity)
		{
			return EntityUtility.GetComponentData<ElectricityCD>(craftingEntity, world).hasEnoughElectricityToPowerStuff;
		}
		return false;
	}

	public ObjectDataCD GetOutputSlot()
	{
		return outputInventoryHandler.GetObjectData(0);
	}

	public DynamicBuffer<CanCraftObjectsBuffer> GetRecipes()
	{
		if (EntityUtility.HasComponentData<CanCraftObjectsBuffer>(craftingEntity, world))
		{
			return EntityUtility.GetBuffer<CanCraftObjectsBuffer>(craftingEntity, world);
		}
		return default(DynamicBuffer<CanCraftObjectsBuffer>);
	}

	public RecipeInfo GetRecipeInfo(int index)
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return default(RecipeInfo);
		}
		PugDatabase.DatabaseBankCD singleton = player.querySystem.GetSingleton<PugDatabase.DatabaseBankCD>();
		BufferLookup<CanCraftObjectsBuffer> bufferLookup = player.querySystem.GetBufferLookup<CanCraftObjectsBuffer>(isReadOnly: true);
		ObjectWithAmount recipeInfo = InventoryUtility.GetRecipeInfo(singleton, index, craftingEntity, bufferLookup);
		if (recipeInfo.objectID != ObjectID.None)
		{
			return new RecipeInfo(PugDatabase.GetObjectInfo(recipeInfo.objectID), recipeInfo.amount);
		}
		return default(RecipeInfo);
	}

	public RecipeInfo GetRecipeInfo(ObjectID objectId, int amount = 1)
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return default(RecipeInfo);
		}
		ObjectWithAmount recipeInfo = InventoryUtility.GetRecipeInfo(player.querySystem.GetSingleton<PugDatabase.DatabaseBankCD>(), objectId, amount);
		if (recipeInfo.objectID != ObjectID.None)
		{
			return new RecipeInfo(PugDatabase.GetObjectInfo(recipeInfo.objectID), recipeInfo.amount);
		}
		return default(RecipeInfo);
	}

	public CanCraftObjectsBuffer? GetActiveRecipe(int slotIndex)
	{
		if (!EntityUtility.HasComponentData<CraftingCD>(craftingEntity, world) || !EntityUtility.HasComponentData<CanCraftObjectsBuffer>(craftingEntity, world))
		{
			return null;
		}
		DynamicBuffer<CanCraftObjectsBuffer> buffer = EntityUtility.GetBuffer<CanCraftObjectsBuffer>(craftingEntity, world);
		int currentlyCraftingIndex = EntityUtility.GetBuffer<CraftingByRecipeSlotBuffer>(craftingEntity, world)[slotIndex].currentlyCraftingIndex;
		if (currentlyCraftingIndex < 0 || currentlyCraftingIndex >= buffer.Length)
		{
			return null;
		}
		return buffer[currentlyCraftingIndex];
	}

	public float GetNormalizedElapsedCraftingTime(int slotIndex)
	{
		if (!EntityUtility.HasComponentData<CraftingCD>(craftingEntity, world))
		{
			return 0f;
		}
		float num = 0f;
		IncineratorCD value4;
		if (EntityUtility.TryGetComponentData<ExtractorCD>(craftingEntity, world, out var value))
		{
			PlayerController player = Manager.main.player;
			if (player == null)
			{
				return 0f;
			}
			PugDatabase.DatabaseBankCD singleton = player.querySystem.GetSingleton<PugDatabase.DatabaseBankCD>();
			ComponentLookup<ExtractableCD> componentLookup = player.querySystem.GetComponentLookup<ExtractableCD>();
			if (!EntityUtility.TryGetBuffer(craftingEntity, world, out DynamicBuffer<ContainedObjectsBuffer> value2))
			{
				return 0f;
			}
			ContainedObjectsBuffer containedObjectsBuffer = value2[0];
			Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(containedObjectsBuffer.objectID, singleton.databaseBankBlob, containedObjectsBuffer.variation);
			if (!componentLookup.TryGetComponent(primaryPrefabEntity, out var componentData))
			{
				return 0f;
			}
			num = value.defaultExtractionTime;
			ref ExtractableData value3 = ref componentData.extractableData.Value;
			if (value3.craftingTimeOverride > 0)
			{
				num = value3.craftingTimeOverride;
			}
		}
		else if (EntityUtility.TryGetComponentData<IncineratorCD>(craftingEntity, world, out value4))
		{
			num = value4.defaultIncinerationTime;
		}
		else
		{
			CanCraftObjectsBuffer? activeRecipe = GetActiveRecipe(slotIndex);
			if (!activeRecipe.HasValue)
			{
				return 0f;
			}
			CanCraftObjectsBuffer value5 = activeRecipe.Value;
			if (value5.objectID == ObjectID.None && !value5.allowCraftingNone)
			{
				return 0f;
			}
			if (activeRecipe.Value.objectID != ObjectID.None)
			{
				RecipeInfo recipeInfo = GetRecipeInfo(activeRecipe.Value.objectID);
				if (!recipeInfo.isValid)
				{
					return 0f;
				}
				num = recipeInfo.craftingTime;
			}
			if (activeRecipe.Value.craftingTimeOverride > 0f)
			{
				num = activeRecipe.Value.craftingTimeOverride;
			}
			if (num == 0f)
			{
				return 0f;
			}
		}
		if (num == 0f)
		{
			return 0f;
		}
		float num2 = 0f;
		if (EntityUtility.TryGetBuffer(craftingEntity, world, out DynamicBuffer<CraftingTimerSlotBuffer> value6) && slotIndex < value6.Length)
		{
			num2 = value6[slotIndex].timeLeftToCraft;
		}
		return (num - num2) / num;
	}

	public bool HasMaterialsInCraftingInventoryToCraftRecipe(int recipeIndex, bool checkPlayerInventoryToo = false, List<Entity> nearbyChestsToTakeMaterialsFrom = null, int multiplier = 1)
	{
		RecipeInfo recipeInfo = GetRecipeInfo(recipeIndex);
		return HasMaterialsInCraftingInventoryToCraftRecipe(recipeInfo, checkPlayerInventoryToo, nearbyChestsToTakeMaterialsFrom, useRequiredObjectsSetInRecipeInfo: false, multiplier);
	}

	public bool HasMaterialsInCraftingInventoryToCraftRecipe(RecipeInfo recipeInfo, bool checkPlayerInventoryToo = false, List<Entity> nearbyChestsToTakeMaterialsFrom = null, bool useRequiredObjectsSetInRecipeInfo = false, int multiplier = 1)
	{
		if (!recipeInfo.isValid)
		{
			return false;
		}
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return false;
		}
		PugDatabase.DatabaseBankCD singleton = player.querySystem.GetSingleton<PugDatabase.DatabaseBankCD>();
		BufferLookup<ContainedObjectsBuffer> bufferLookup = player.querySystem.GetBufferLookup<ContainedObjectsBuffer>();
		BufferLookup<InventoryBuffer> bufferLookup2 = player.querySystem.GetBufferLookup<InventoryBuffer>();
		ComponentLookup<AnvilCD> componentLookup = player.querySystem.GetComponentLookup<AnvilCD>();
		ComponentLookup<ObjectDataCD> componentLookup2 = player.querySystem.GetComponentLookup<ObjectDataCD>();
		BufferLookup<SummarizedConditionsBuffer> bufferLookup3 = player.querySystem.GetBufferLookup<SummarizedConditionsBuffer>();
		Entity entity = player.entity;
		using NativeList<Entity> inventoryEntities = new NativeList<Entity>(Allocator.Temp);
		if (checkPlayerInventoryToo)
		{
			inventoryEntities.Add(player.entity);
		}
		if (nearbyChestsToTakeMaterialsFrom != null)
		{
			for (int i = 0; i < nearbyChestsToTakeMaterialsFrom.Count; i++)
			{
				inventoryEntities.Add(nearbyChestsToTakeMaterialsFrom[i]);
			}
		}
		ObjectID objectID = recipeInfo.objectID;
		List<CraftingObject> list = (useRequiredObjectsSetInRecipeInfo ? recipeInfo.requiredObjectsToCraft : PugDatabase.GetObjectInfo(objectID).requiredObjectsToCraft);
		using NativeList<ObjectWithAmount> requiredObjectsToCraft = new NativeList<ObjectWithAmount>(list.Count, Allocator.Temp);
		for (int j = 0; j < list.Count; j++)
		{
			requiredObjectsToCraft.Add(new ObjectWithAmount
			{
				objectID = list[j].objectID,
				amount = list[j].amount
			});
		}
		return InventoryUtility.HasMaterialsInCraftingInventoryToCraftRecipe(bufferLookup, bufferLookup2, singleton, componentLookup, componentLookup2, bufferLookup3, craftingEntity, entity, inventoryEntities, requiredObjectsToCraft, multiplier);
	}

	public List<PugDatabase.MaterialInfo> GetCraftingMaterialInfosForRecipe(int index, List<Entity> nearbyChestsToTakeMaterialsFrom = null, bool isRepairing = false, bool isReinforcing = false)
	{
		RecipeInfo recipeInfo = GetRecipeInfo(index);
		return GetCraftingMaterialInfosForRecipe(recipeInfo, nearbyChestsToTakeMaterialsFrom, isRepairing, isReinforcing);
	}

	public List<PugDatabase.MaterialInfo> GetCraftingMaterialInfosForRecipe(RecipeInfo recipeInfo, List<Entity> nearbyChestsToTakeMaterialsFrom = null, bool isRepairing = false, bool isReinforcing = false, bool isCookedFood = false)
	{
		PlayerController player = Manager.main.player;
		if (player == null || !recipeInfo.isValid)
		{
			return new List<PugDatabase.MaterialInfo>();
		}
		PugDatabase.DatabaseBankCD singleton = player.querySystem.GetSingleton<PugDatabase.DatabaseBankCD>();
		BufferLookup<ContainedObjectsBuffer> bufferLookup = player.querySystem.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
		BufferLookup<InventoryBuffer> bufferLookup2 = player.querySystem.GetBufferLookup<InventoryBuffer>(isReadOnly: true);
		ComponentLookup<AnvilCD> componentLookup = player.querySystem.GetComponentLookup<AnvilCD>(isReadOnly: true);
		ComponentLookup<ObjectDataCD> componentLookup2 = player.querySystem.GetComponentLookup<ObjectDataCD>(isReadOnly: true);
		BufferLookup<SummarizedConditionsBuffer> bufferLookup3 = player.querySystem.GetBufferLookup<SummarizedConditionsBuffer>(isReadOnly: true);
		ComponentLookup<DurabilityCD> componentLookup3 = player.querySystem.GetComponentLookup<DurabilityCD>(isReadOnly: true);
		ComponentLookup<PrioritizedRepairMaterialCD> componentLookup4 = player.querySystem.GetComponentLookup<PrioritizedRepairMaterialCD>(isReadOnly: true);
		ComponentLookup<LevelCD> componentLookup5 = player.querySystem.GetComponentLookup<LevelCD>(isReadOnly: true);
		int num = 0;
		using NativeList<Entity> inventoryEntities = new NativeList<Entity>(Allocator.Temp);
		inventoryEntities.Add(inventoryHandler.inventoryEntity);
		if (inventoryHandler != player.playerInventoryHandler)
		{
			inventoryEntities.Add(player.playerInventoryHandler.inventoryEntity);
		}
		num = inventoryEntities.Length;
		if (nearbyChestsToTakeMaterialsFrom != null)
		{
			for (int i = 0; i < nearbyChestsToTakeMaterialsFrom.Count; i++)
			{
				inventoryEntities.Add(nearbyChestsToTakeMaterialsFrom[i]);
			}
		}
		ObjectWithAmount recipeInfo2 = new ObjectWithAmount
		{
			objectID = recipeInfo.objectID,
			amount = recipeInfo.amount
		};
		NativeList<ObjectWithAmount> cookingIngredientsRequired = default(NativeList<ObjectWithAmount>);
		if (isCookedFood)
		{
			cookingIngredientsRequired = new NativeList<ObjectWithAmount>(recipeInfo.requiredObjectsToCraft.Count, Allocator.Temp);
			for (int j = 0; j < recipeInfo.requiredObjectsToCraft.Count; j++)
			{
				cookingIngredientsRequired.Add(new ObjectWithAmount
				{
					objectID = recipeInfo.requiredObjectsToCraft[j].objectID,
					amount = recipeInfo.requiredObjectsToCraft[j].amount
				});
			}
		}
		using NativeList<PugDatabase.MaterialInfoData> materialInfoData = InventoryUtility.GetCraftingMaterialInfosForRecipe(singleton, bufferLookup, bufferLookup2, componentLookup, componentLookup2, bufferLookup3, componentLookup3, componentLookup4, componentLookup5, recipeInfo2, cookingIngredientsRequired, inventoryEntities, num, isRepairing, isReinforcing, craftingEntity, player.entity, Allocator.Temp);
		if (cookingIngredientsRequired.IsCreated)
		{
			cookingIngredientsRequired.Dispose();
		}
		return MaterialInfoListFromData(materialInfoData, nearbyChestsToTakeMaterialsFrom);
	}

	private List<PugDatabase.MaterialInfo> MaterialInfoListFromData(NativeList<PugDatabase.MaterialInfoData> materialInfoData, List<Entity> nearbyChestsToTakeMaterialsFrom)
	{
		List<PugDatabase.MaterialInfo> list = new List<PugDatabase.MaterialInfo>(materialInfoData.Length);
		for (int i = 0; i < materialInfoData.Length; i++)
		{
			Entity entity = Entity.Null;
			if (nearbyChestsToTakeMaterialsFrom != null)
			{
				for (int j = 0; j < nearbyChestsToTakeMaterialsFrom.Count; j++)
				{
					if (!(nearbyChestsToTakeMaterialsFrom[j] != materialInfoData[i].nearbyChestWithMaterial))
					{
						entity = nearbyChestsToTakeMaterialsFrom[j];
						break;
					}
				}
			}
			Sprite nearbyChestIcon = null;
			if (EntityUtility.TryGetComponentData<ObjectDataCD>(entity, Manager.ecs.ClientWorld, out var value))
			{
				nearbyChestIcon = PugDatabase.GetObjectInfo(value.objectID, value.variation)?.smallIcon ?? null;
			}
			list.Add(new PugDatabase.MaterialInfo(materialInfoData[i].objectID, materialInfoData[i].amountNeeded, materialInfoData[i].amountAvailable, entity, nearbyChestIcon));
		}
		return list;
	}

	public List<PugDatabase.MaterialInfo> GetCraftingMaterialInfosForUpgrade(int level, List<Entity> nearbyChestsToTakeMaterialsFrom = null)
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return new List<PugDatabase.MaterialInfo>();
		}
		PugDatabase.DatabaseBankCD singleton = player.querySystem.GetSingleton<PugDatabase.DatabaseBankCD>();
		UpgradeCostsTableCD singleton2 = player.querySystem.GetSingleton<UpgradeCostsTableCD>();
		BufferLookup<ContainedObjectsBuffer> bufferLookup = player.querySystem.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
		BufferLookup<InventoryBuffer> bufferLookup2 = player.querySystem.GetBufferLookup<InventoryBuffer>(isReadOnly: true);
		using NativeList<Entity> inventories = new NativeList<Entity>(Allocator.Temp);
		inventories.Add(player.entity);
		int length = inventories.Length;
		if (nearbyChestsToTakeMaterialsFrom != null)
		{
			for (int i = 0; i < nearbyChestsToTakeMaterialsFrom.Count; i++)
			{
				inventories.Add(nearbyChestsToTakeMaterialsFrom[i]);
			}
		}
		using NativeList<PugDatabase.MaterialInfoData> materialInfoData = InventoryUtility.GetCraftingMaterialInfosForUpgrade(bufferLookup, bufferLookup2, singleton, singleton2, level, inventories, length, Allocator.Temp);
		return MaterialInfoListFromData(materialInfoData, nearbyChestsToTakeMaterialsFrom);
	}

	public List<Entity> GetNearbyChests()
	{
		int2 int5 = entityMonoBehaviour.WorldPosition.RoundToInt2();
		if (timeLastChecked == Time.frameCount && cachedNearbyChests != null && math.all(timeLastCheckedPosition == int5))
		{
			return cachedNearbyChests;
		}
		timeLastChecked = Time.frameCount;
		timeLastCheckedPosition = int5;
		List<Entity> list = new List<Entity>();
		if (entityMonoBehaviour == null)
		{
			Debug.LogWarning(string.Format("{0}.{1}: entityMonoBehaviour was null. Can't retrieve nearby chests.", this, "GetNearbyChests"));
			return list;
		}
		CollisionWorld collisionWorld = Manager.main.player.querySystem.GetSingleton<PhysicsWorldSingleton>().CollisionWorld;
		ComponentLookup<InventoryAutoTransferEnabledCD> inventoryAutoTransferEnabledLookup = Manager.main.player.querySystem.GetComponentLookup<InventoryAutoTransferEnabledCD>(isReadOnly: true);
		ComponentLookup<LocalTransform> localTransformLookup = Manager.main.player.querySystem.GetComponentLookup<LocalTransform>(isReadOnly: true);
		NativeList<Entity> inventories = new NativeList<Entity>(Allocator.Temp);
		InventoryUtility.GetNearbyChestsForCraftingByDistance((float3)entityMonoBehaviour.WorldPosition, in collisionWorld, in inventoryAutoTransferEnabledLookup, in localTransformLookup, ref inventories);
		foreach (Entity item in inventories)
		{
			list.Add(item);
		}
		inventories.Dispose();
		cachedNearbyChests = list;
		return list;
	}

	public void RepairOrReinforce(PlayerController playerController, int index, InventoryHandler inventoryContainingItem, bool reinforce)
	{
		Entity entity = playerController.entity;
		bool craftingMaterialsAreNotRequired = Manager.ui.craftingMaterialsAreNotRequired;
		int index2 = inventoryContainingItem.startPosInBuffer + index;
		ObjectDataCD objectData = inventoryContainingItem.GetObjectData(index);
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.Craft,
			craftActionData = Create.RepairOrReinforce(inventoryContainingItem.inventoryEntity, index2, objectData.objectID, 1, craftingEntity, entity, reinforce, craftingMaterialsAreNotRequired)
		});
	}

	public bool CanBeRepaired(int index, InventoryHandler inventoryContainingItem, bool isReinforcing)
	{
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return false;
		}
		PugDatabase.DatabaseBankCD singleton = player.querySystem.GetSingleton<PugDatabase.DatabaseBankCD>();
		Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(inventoryContainingItem.GetObjectData(index).objectID, singleton.databaseBankBlob);
		ContainedObjectsBuffer containedObjectData = inventoryContainingItem.GetContainedObjectData(index);
		BufferLookup<LevelEntitiesBuffer> bufferLookup = player.querySystem.GetBufferLookup<LevelEntitiesBuffer>(isReadOnly: true);
		ComponentLookup<DurabilityCD> componentLookup = player.querySystem.GetComponentLookup<DurabilityCD>(isReadOnly: true);
		return InventoryUtility.CanBeRepaired(primaryPrefabEntity, containedObjectData, bufferLookup, componentLookup, isReinforcing);
	}

	public void Upgrade(PlayerController playerController, int index, InventoryHandler inventoryContainingItem)
	{
		Entity entity = playerController.entity;
		bool craftingMaterialsAreNotRequired = Manager.ui.craftingMaterialsAreNotRequired;
		int index2 = inventoryContainingItem.startPosInBuffer + index;
		ObjectDataCD objectData = inventoryContainingItem.GetObjectData(index);
		playerController.QueueInputAction(new UIInputActionData
		{
			action = UIInputAction.Craft,
			craftActionData = Create.Upgrade(inventoryContainingItem.inventoryEntity, entity, craftingEntity, index2, objectData.objectID, 1, craftingMaterialsAreNotRequired)
		});
	}

	public bool HasMaterialsToBeUpgraded(int level, List<Entity> nearbyChestsToTakeMaterialsFrom = null)
	{
		List<PugDatabase.MaterialInfo> craftingMaterialInfosForUpgrade = GetCraftingMaterialInfosForUpgrade(level, nearbyChestsToTakeMaterialsFrom);
		for (int i = 0; i < craftingMaterialInfosForUpgrade.Count; i++)
		{
			if (craftingMaterialInfosForUpgrade[i].amountAvailable < craftingMaterialInfosForUpgrade[i].amountNeeded)
			{
				return false;
			}
		}
		return true;
	}

	public ExtractorCD GetExtractor()
	{
		EntityUtility.TryGetComponentData<ExtractorCD>(craftingEntity, world, out var value);
		return value;
	}
}
