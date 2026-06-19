using System.Collections.Generic;
using Pug.Conversion;
using Pug.UnityExtensions;
using PugMod;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public class InventoryConverter : Converter
{
	private List<CraftingPrerequisites> _cachedPrerequisites = new List<CraftingPrerequisites>();

	private List<CanCraftObjectsBuffer> _cachedCanCraftObjects = new List<CanCraftObjectsBuffer>();

	public override void Convert(GameObject authoring)
	{
		InventoryAuthoring component;
		bool flag = TryGetActiveComponent<InventoryAuthoring>(authoring, out component);
		CraftingAuthoring component2;
		bool flag2 = TryGetActiveComponent<CraftingAuthoring>(authoring, out component2);
		EquipmentAuthoring component3;
		bool flag3 = TryGetActiveComponent<EquipmentAuthoring>(authoring, out component3);
		SellSlotsAuthoring component4;
		bool flag4 = TryGetActiveComponent<SellSlotsAuthoring>(authoring, out component4);
		TrashCanAuthoring component5;
		bool flag5 = TryGetActiveComponent<TrashCanAuthoring>(authoring, out component5);
		VanitySlotsAuthoring component6;
		bool flag6 = TryGetActiveComponent<VanitySlotsAuthoring>(authoring, out component6);
		UpgradeSlotAuthoring component7;
		bool flag7 = TryGetActiveComponent<UpgradeSlotAuthoring>(authoring, out component7);
		PlayerAuthoring component8;
		bool flag8 = TryGetActiveComponent<PlayerAuthoring>(authoring, out component8);
		PetOwnerAuthoring component9;
		bool flag9 = TryGetActiveComponent<PetOwnerAuthoring>(authoring, out component9);
		int slotIndex = 0;
		EquipmentCD[] array = new EquipmentCD[3];
		int num = -1;
		NativeList<InventoryBuffer> nativeList = new NativeList<InventoryBuffer>(Allocator.Temp);
		if (flag)
		{
			nativeList.Add(SetupInventory(component));
		}
		if (flag2)
		{
			SetupCrafting(component2);
		}
		if (flag3)
		{
			array[0].helmSlotIndex = AddToBuffer(default(ContainedObjectsBuffer));
			array[0].necklaceSlotIndex = AddToBuffer(default(ContainedObjectsBuffer));
			array[0].breastSlotIndex = AddToBuffer(default(ContainedObjectsBuffer));
			array[0].pantsSlotIndex = AddToBuffer(default(ContainedObjectsBuffer));
			array[0].ring1SlotIndex = AddToBuffer(default(ContainedObjectsBuffer));
			array[0].ring2SlotIndex = AddToBuffer(default(ContainedObjectsBuffer));
			array[0].offHandIndex = AddToBuffer(default(ContainedObjectsBuffer));
			num = AddToBuffer(default(ContainedObjectsBuffer));
			InventoryBuffer value = nativeList[0];
			value.extraInventorySizeSlot = num;
			nativeList[0] = value;
			EnsureHasComponent<ActiveEquipmentPresetCD>();
		}
		if (flag4)
		{
			int startIndex = EnsureHasBuffer<ContainedObjectsBuffer>();
			for (int i = 0; i < component4.sizeX * component4.sizeY; i++)
			{
				AddToBuffer(default(ContainedObjectsBuffer));
			}
			AddComponentData(new SellSlotsCD
			{
				startIndex = startIndex,
				sizeX = component4.sizeX,
				sizeY = component4.sizeY
			});
		}
		if (flag5)
		{
			int slotIndex2 = AddToBuffer(default(ContainedObjectsBuffer));
			AddComponentData(new TrashCanCD
			{
				slotIndex = slotIndex2
			});
		}
		if (flag6)
		{
			EnsureHasBuffer<ContainedObjectsBuffer>();
			int helmVanitySlotIndex = AddToBuffer(default(ContainedObjectsBuffer));
			int breastVanitySlotIndex = AddToBuffer(default(ContainedObjectsBuffer));
			int pantsVanitySlotIndex = AddToBuffer(default(ContainedObjectsBuffer));
			AddComponentData(new VanitySlotsCD
			{
				helmVanitySlotIndex = helmVanitySlotIndex,
				breastVanitySlotIndex = breastVanitySlotIndex,
				pantsVanitySlotIndex = pantsVanitySlotIndex
			});
		}
		if (flag3)
		{
			for (int j = 1; j < 3; j++)
			{
				array[j] = new EquipmentCD
				{
					helmSlotIndex = AddToBuffer(default(ContainedObjectsBuffer)),
					necklaceSlotIndex = AddToBuffer(default(ContainedObjectsBuffer)),
					breastSlotIndex = AddToBuffer(default(ContainedObjectsBuffer)),
					pantsSlotIndex = AddToBuffer(default(ContainedObjectsBuffer)),
					ring1SlotIndex = AddToBuffer(default(ContainedObjectsBuffer)),
					ring2SlotIndex = AddToBuffer(default(ContainedObjectsBuffer)),
					offHandIndex = AddToBuffer(default(ContainedObjectsBuffer))
				};
			}
			if (flag9)
			{
				slotIndex = AddToBuffer(default(ContainedObjectsBuffer));
			}
			int lanternIndex = AddToBuffer(default(ContainedObjectsBuffer));
			EnsureHasBuffer<EquipmentPresetsBuffer>();
			for (int k = 0; k < 3; k++)
			{
				array[k].bagIndex = num;
				array[k].lanternIndex = lanternIndex;
			}
		}
		if (flag7)
		{
			EnsureHasBuffer<ContainedObjectsBuffer>();
			AddComponentData(new UpgradeSlotCD
			{
				slotIndex = AddToBuffer(default(ContainedObjectsBuffer))
			});
		}
		if (flag3)
		{
			EnsureHasBuffer<ContainedObjectsBuffer>();
			for (int l = 0; l < 4; l++)
			{
				int num2 = AddToBuffer(default(ContainedObjectsBuffer));
				nativeList.Add(new InventoryBuffer
				{
					sizeX = 10,
					sizeY = 0,
					maxSize = 10,
					extraInventorySizeSlot = num2,
					startIndex = num2 + 1
				});
				for (int m = 0; m < 10; m++)
				{
					AddToBuffer(default(ContainedObjectsBuffer));
				}
				for (int n = 0; n < 3; n++)
				{
					array[n].SetPouchSlotIndex(l, num2);
				}
			}
			for (int num3 = 0; num3 < 3; num3++)
			{
				AddToBuffer(new EquipmentPresetsBuffer
				{
					equipment = array[num3]
				});
			}
			AddComponentData(array[0]);
		}
		if (flag8)
		{
			EnsureHasBuffer<LockedObjectsBuffer>();
		}
		if (flag9)
		{
			AddComponentData(new PetOwnerCD
			{
				SlotIndex = slotIndex,
				AllowPetToSpawn = true
			});
		}
		if (nativeList.Length > 0)
		{
			EnsureHasBuffer<InventoryBuffer>();
			foreach (InventoryBuffer item in nativeList)
			{
				AddToBuffer(item);
			}
		}
		nativeList.Dispose();
		if (flag)
		{
			EnsureHasComponent<ImmuneToSkipLootDropCD>();
		}
	}

	private InventoryBuffer SetupInventory(InventoryAuthoring inventoryAuthoring)
	{
		InventoryBuffer result = new InventoryBuffer
		{
			sizeX = inventoryAuthoring.sizeX,
			sizeY = inventoryAuthoring.sizeY,
			maxSize = inventoryAuthoring.sizeX * inventoryAuthoring.sizeY + inventoryAuthoring.maxExtraSize,
			canOnlyContainOneItemPerSlot = inventoryAuthoring.canOnlyContainOneItemPerSlot,
			objectsGetLockedInPlace = inventoryAuthoring.objectsGetLockedInPlace,
			cantAddObjectsToInventory = inventoryAuthoring.cantAddObjectsToInventory,
			extraInventorySizeSlot = -1
		};
		if (inventoryAuthoring.autoTransferEnabled)
		{
			EnsureHasComponent<InventoryAutoTransferEnabledCD>();
		}
		EnsureHasBuffer<InventorySlotRequirementBuffer>();
		for (int i = 0; i < inventoryAuthoring.slotRequirements.Count; i++)
		{
			SlotRequirement slotRequirement = inventoryAuthoring.slotRequirements[i];
			FixedList32Bytes<ObjectID> acceptsObjectIds = default(FixedList32Bytes<ObjectID>);
			foreach (ObjectID acceptsObjectId in slotRequirement.acceptsObjectIds)
			{
				acceptsObjectIds.Add(acceptsObjectId);
			}
			AddToBuffer(new InventorySlotRequirementBuffer
			{
				requirementAppliesToAllSlots = slotRequirement.requirementAppliesToAllSlots,
				inventoryIndex = 0,
				slotIndex = i,
				dontShowAnyHint = slotRequirement.dontShowAnyHint,
				showInfoText = slotRequirement.showInfoText,
				acceptsObjectIds = acceptsObjectIds,
				acceptsObjectsWithTags = ObjectCategoryTagsCD.ConvertToBitMask(slotRequirement.acceptsObjectsWithTags),
				denyLegendaryRarity = slotRequirement.denyLegendaryRarity
			});
		}
		int num = inventoryAuthoring.sizeX * inventoryAuthoring.sizeY;
		int num2 = EnsureHasBuffer<ContainedObjectsBuffer>();
		if (inventoryAuthoring.itemsInInventory != null)
		{
			foreach (ObjectData item in inventoryAuthoring.itemsInInventory)
			{
				int num3 = item.amount;
				if (item.objectID == ObjectID.None)
				{
					num3 = 0;
				}
				else
				{
					ObjectInfo objectInfo = PugDatabase.GetObjectInfo(item.objectID, item.variation);
					if (objectInfo == null)
					{
						Debug.LogError($"Object {item.objectID} {item.variation} in {inventoryAuthoring.name} not found in database");
						continue;
					}
					if (!objectInfo.isStackable)
					{
						num3 = objectInfo.initialAmount;
					}
					else if (item.objectID != ObjectID.None && num3 == 0)
					{
						Debug.LogError($"Stackable item {item.objectID} on InventoryAuthoring in {inventoryAuthoring.gameObject.name} has amount set to 0)");
					}
				}
				num2 = 1 + AddToBuffer(new ContainedObjectsBuffer
				{
					objectData = new ObjectDataCD
					{
						objectID = item.objectID,
						variation = item.variation,
						amount = num3
					}
				});
			}
		}
		int num4 = num + inventoryAuthoring.maxExtraSize;
		while (num2 < num4)
		{
			num2 = 1 + AddToBuffer(default(ContainedObjectsBuffer));
		}
		if (inventoryAuthoring.addLootFromTable != LootTableID.Empty)
		{
			AddComponentData(new AddRandomLootCD
			{
				lootTableID = inventoryAuthoring.addLootFromTable
			}, componentIsEnabled: true);
		}
		return result;
	}

	private void SetupCrafting(CraftingAuthoring craftingAuthoring)
	{
		int outputSlotIndex = -1;
		AddComponentData(new CraftingVisualCD
		{
			showLoopEffectOnOutputSlot = craftingAuthoring.showLoopEffectOnOutputSlot
		});
		if (craftingAuthoring.craftingType == CraftingType.Extract)
		{
			AddComponentData(new ExtractorCD
			{
				extractableType = craftingAuthoring.extractableType,
				defaultExtractionTime = craftingAuthoring.minMaxRandomDefaultCraftingTime.x,
				defaultMinMaxRandomExtractedOutputAmount = craftingAuthoring.minMaxRandomDefaultExtractedOutputAmount
			});
		}
		else if (craftingAuthoring.craftingType == CraftingType.Incinerate)
		{
			AddComponentData(new IncineratorCD
			{
				defaultIncinerationTime = craftingAuthoring.minMaxRandomDefaultCraftingTime.x
			});
		}
		else if (craftingAuthoring.craftingType == CraftingType.Fishing)
		{
			AddComponentData(new FishingCD
			{
				minMaxRandomDefaultCraftingTime = craftingAuthoring.minMaxRandomDefaultCraftingTime
			});
		}
		else if (craftingAuthoring.craftingType == CraftingType.CritterCatching)
		{
			AddComponentData(new CritterCatchingCD
			{
				minMaxRandomDefaultCraftingTime = craftingAuthoring.minMaxRandomDefaultCraftingTime
			});
		}
		else
		{
			SetupCanCraftBuffer(craftingAuthoring);
			if (TryGetActiveComponent<InventoryAuthoring>(craftingAuthoring, out var _))
			{
				outputSlotIndex = AddToBuffer(default(ContainedObjectsBuffer));
			}
		}
		AddComponentData(new CraftingCD
		{
			craftingType = craftingAuthoring.craftingType,
			outputSlotIndex = outputSlotIndex
		});
	}

	private void SetupCanCraftBuffer(CraftingAuthoring craftingAuthoring)
	{
		EnsureHasBuffer<CanCraftObjectsBuffer>();
		_cachedPrerequisites.Clear();
		_cachedCanCraftObjects.Clear();
		foreach (CraftingAuthoring.CraftableObject canCraftObject in craftingAuthoring.canCraftObjects)
		{
			AddRecipe(canCraftObject);
		}
		if (craftingAuthoring.includeCraftedObjectsFromBuildings != null)
		{
			foreach (CraftingAuthoring includeCraftedObjectsFromBuilding in craftingAuthoring.includeCraftedObjectsFromBuildings)
			{
				if (includeCraftedObjectsFromBuilding == null || includeCraftedObjectsFromBuilding.canCraftObjects == null)
				{
					Debug.LogError(craftingAuthoring.name + ": null in includeCraftedObjectsFromBuildings");
					continue;
				}
				foreach (CraftingAuthoring.CraftableObject canCraftObject2 in includeCraftedObjectsFromBuilding.canCraftObjects)
				{
					AddRecipe(canCraftObject2);
				}
			}
			if (craftingAuthoring.includeCraftedObjectsFromBuildings.Count > 0)
			{
				EnsureHasBuffer<IncludedCraftingBuildingsBuffer>();
				AddToBuffer(new IncludedCraftingBuildingsBuffer
				{
					objectID = (ObjectID)base.ObjectIndex,
					amountOfCraftingOptions = craftingAuthoring.canCraftObjects.Count
				});
				foreach (CraftingAuthoring includeCraftedObjectsFromBuilding2 in craftingAuthoring.includeCraftedObjectsFromBuildings)
				{
					ObjectID objectID = ObjectID.None;
					EntityMonoBehaviourData component = includeCraftedObjectsFromBuilding2.GetComponent<EntityMonoBehaviourData>();
					if (component != null)
					{
						objectID = component.objectInfo.objectID;
					}
					else if (includeCraftedObjectsFromBuilding2.GetComponent<ObjectAuthoring>() != null)
					{
						Debug.LogError("ObjectAuthoring doesn't work for includeCraftedObjectsFromBuildings currently");
					}
					if (objectID == ObjectID.None)
					{
						Debug.LogError("CraftingAuthoring needs EntityMonoBehaviourData for includeCraftedObjectsFromBuildings");
						continue;
					}
					AddToBuffer(new IncludedCraftingBuildingsBuffer
					{
						objectID = objectID,
						amountOfCraftingOptions = includeCraftedObjectsFromBuilding2.canCraftObjects.Count
					});
				}
			}
		}
		foreach (CanCraftObjectsBuffer cachedCanCraftObject in _cachedCanCraftObjects)
		{
			AddToBuffer(cachedCanCraftObject);
		}
		if (NeedsPrerequisitesCheck(_cachedPrerequisites))
		{
			EnsureHasComponent<CraftingSlotsNeedPrerequisitesCheckCD>();
			SetPropertyList("Crafting/unfilteredRecipes", _cachedCanCraftObjects.ToArray());
			SetPropertyList("Crafting/recipePrerequisites", _cachedPrerequisites.ToArray());
		}
	}

	private static bool NeedsPrerequisitesCheck(List<CraftingPrerequisites> prerequisites)
	{
		foreach (CraftingPrerequisites prerequisite in prerequisites)
		{
			if (prerequisite.HasAny())
			{
				return true;
			}
		}
		return false;
	}

	private void AddRecipe(CraftingAuthoring.CraftableObject recipe)
	{
		if (recipe.objectID == ObjectID.None && !string.IsNullOrEmpty(recipe.moddedObjectID))
		{
			ObjectID objectID = API.Authoring.GetObjectID(recipe.moddedObjectID);
			if (objectID != ObjectID.None)
			{
				recipe.objectID = objectID;
			}
		}
		_cachedCanCraftObjects.Add(new CanCraftObjectsBuffer
		{
			objectID = recipe.objectID,
			amount = math.max(1, recipe.amount),
			entityAmountToConsume = (recipe.craftingConsumesEntityAmount ? recipe.entityAmountToConsume : 0),
			allowCraftingNone = recipe.allowCraftingNone,
			craftingTimeOverride = recipe.craftingTime
		});
		CraftingPrerequisites item = default(CraftingPrerequisites);
		if (recipe.hasPrerequisites)
		{
			DataBlockRef<ContentBundleDataBlock> output;
			OptionalValue<DataBlockAddress> contentBundlePresent = (recipe.prerequisites.contentBundlePresent.TryGetValue(out output) ? new OptionalValue<DataBlockAddress>(output.address) : default(OptionalValue<DataBlockAddress>));
			DataBlockRef<ContentBundleDataBlock> output2;
			OptionalValue<DataBlockAddress> contentBundleAbsent = (recipe.prerequisites.contentBundleAbsent.TryGetValue(out output2) ? new OptionalValue<DataBlockAddress>(output2.address) : default(OptionalValue<DataBlockAddress>));
			item = new CraftingPrerequisites
			{
				ContentBundlePresent = contentBundlePresent,
				ContentBundleAbsent = contentBundleAbsent,
				BirdBossKilled = recipe.prerequisites.birdBossKilled,
				OctopusBossKilled = recipe.prerequisites.octopusBossKilled,
				ScarabBossKilled = recipe.prerequisites.scarabBossKilled,
				HydraBossNatureKilled = recipe.prerequisites.hydraBossNatureKilled,
				HydraBossSeaKilled = recipe.prerequisites.hydraBossSeaKilled,
				HydraBossDesertKilled = recipe.prerequisites.hydraBossDesertKilled
			};
		}
		_cachedPrerequisites.Add(item);
	}
}
