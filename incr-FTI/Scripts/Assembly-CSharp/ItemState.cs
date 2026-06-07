using System.Collections.Generic;

public class ItemState : ConsumableState
{
	public ItemType type;

	public override string ToString()
	{
		if (parentTown == null)
		{
			return "GlobalItem " + type;
		}
		return "Item " + type;
	}

	public override EntityId AsEntity()
	{
		return EntityId.FromItem(type);
	}

	public override void AssignMaxCapacity()
	{
		isOutputCapacityInfinite = Item.MatchesFilterCache(type, ItemType.FilterCurrency);
		base.AssignMaxCapacity();
	}

	public override double DefaultCapacity()
	{
		if (isOutputCapacityInfinite)
		{
			return double.MaxValue;
		}
		if (type == ItemType.Omnistone)
		{
			return 500.0;
		}
		if (type == ItemType.Grain)
		{
			return 500.0;
		}
		if (Crafting.cachedItemDefs.TryGetValue(type, out var value))
		{
			if (value.storageType == StorageType.Ether || value.storageType == StorageType.OreSilo)
			{
				return 2000.0;
			}
			if (value.storageType == StorageType.Warehouse || value.storageType == StorageType.CropSilo)
			{
				return 100.0;
			}
			if (value.storageType == StorageType.Stockpile)
			{
				return 50.0;
			}
			if (value.storageType == StorageType.Library)
			{
				return 1000.0;
			}
			if (value.storageType == StorageType.Pantry)
			{
				return 100.0;
			}
			if (value.storageType == StorageType.Barrel)
			{
				return 100.0;
			}
			if (value.storageType == StorageType.Treasury)
			{
				return 100.0;
			}
			if (value.storageType == StorageType.ManaBattery)
			{
				return 250.0;
			}
			if (value.storageType == StorageType.Reservoir)
			{
				return 250.0;
			}
			if (value.storageType == StorageType.Energy)
			{
				return 250.0;
			}
			if (value.storageType == StorageType.Specialty)
			{
				return 100.0;
			}
			if (value.storageType == StorageType.Fire)
			{
				return 250.0;
			}
			if (value.storageType == StorageType.PressureTank)
			{
				return 1000.0;
			}
			if (value.storageType == StorageType.Crystal)
			{
				return 5000.0;
			}
		}
		if (Item.MatchesFilterCache(type, ItemType.FilterFluid))
		{
			return 25.0;
		}
		return 50.0;
	}

	public bool ShouldBeGloballyUnlocked()
	{
		return type switch
		{
			ItemType.Carrot => CountableState.gm.LevelOfBiome(BiomeType.Mountains) >= 0f, 
			ItemType.Potato => CountableState.gm.LevelOfBiome(BiomeType.Snow) >= 0f, 
			ItemType.CactusFruit => CountableState.gm.LevelOfBiome(BiomeType.Desert) >= 0f, 
			ItemType.DragonFruit => CountableState.gm.LevelOfBiome(BiomeType.Jungle) >= 0f, 
			ItemType.Mana => CountableState.gm.LevelOfBiome(BiomeType.Magic) >= 0f, 
			ItemType.Fish => CountableState.gm.LevelOfBiome(BiomeType.River) >= 0f, 
			ItemType.Herb => CountableState.gm.LevelOfBiome(BiomeType.Forest) >= 0f, 
			ItemType.Berries => GameManager.IsGlobalQuestComplete(QuestType.DiscoverBerries), 
			ItemType.Pear => GameManager.IsGlobalQuestComplete(QuestType.DiscoverPear), 
			ItemType.Sugar => GameManager.IsGlobalQuestComplete(QuestType.DiscoverSugar), 
			ItemType.Tomato => GameManager.IsGlobalQuestComplete(QuestType.DiscoverTomato), 
			ItemType.RedRuby => GameManager.IsGlobalQuestComplete(Quest.ResourceUnlockQuestRuby), 
			ItemType.BlueSapphire => GameManager.IsGlobalQuestComplete(Quest.ResourceUnlockQuestSapphire), 
			ItemType.PurpleAmethyst => GameManager.IsGlobalQuestComplete(Quest.ResourceUnlockQuestAmethyst), 
			ItemType.YellowTopaz => GameManager.IsGlobalQuestComplete(Quest.ResourceUnlockQuestTopaz), 
			ItemType.Cotton => GameManager.IsGlobalQuestComplete(Quest.ResourceUnlockQuestCotton), 
			ItemType.Apple => GameManager.IsGlobalQuestComplete(Quest.ResourceUnlockQuestApples), 
			ItemType.Grain => GameManager.IsGlobalQuestComplete(Quest.ResourceUnlockQuestGrain), 
			ItemType.Stone => GameManager.IsGlobalQuestComplete(Quest.ResourceUnlockQuestRock), 
			ItemType.IronOre => GameManager.IsGlobalQuestComplete(Quest.ResourceUnlockQuestIron), 
			ItemType.Coal => GameManager.IsGlobalQuestComplete(Quest.ResourceUnlockQuestCoal), 
			ItemType.CopperOre => GameManager.IsGlobalQuestComplete(Quest.ResourceUnlockQuestCopper), 
			ItemType.SilverOre => GameManager.IsGlobalQuestComplete(Quest.ResourceUnlockQuestSilver), 
			ItemType.GoldOre => GameManager.IsGlobalQuestComplete(Quest.ResourceUnlockQuestGold), 
			ItemType.Water => GameManager.IsGlobalQuestComplete(Quest.ResourceUnlockQuestWater), 
			_ => false, 
		};
	}

	public override bool ShouldBeUnlocked()
	{
		if (GameManager.everythingUnlocked)
		{
			return true;
		}
		if ((type == ItemType.Wood || type == ItemType.Stone || type == ItemType.ResearchTomeGeneral) && base.ShouldBeUnlocked())
		{
			return true;
		}
		if (currentCount > 0.0)
		{
			return true;
		}
		if (parentTown == null)
		{
			if (GameManager.Instance.globalProductionStats.TryGetValue(type, out var value))
			{
				return value.value > 0.0;
			}
			return false;
		}
		if (type == ItemType.Power)
		{
			return parentTown.IsCompleted(ResearchType.WaterPower);
		}
		if (Item.IsCurrency(type))
		{
			bool flag = type == ItemType.YellowCoin;
			foreach (KeyValuePair<ItemType, SellState> marketItem in parentTown.marketItems)
			{
				if (!marketItem.Value.isLocked && marketItem.Value.sellData.coinType == type)
				{
					return true;
				}
			}
		}
		foreach (KeyValuePair<RecipeType, RecipeState> recipe in parentTown.recipes)
		{
			RecipeState value2 = recipe.Value;
			if (value2.isLocked)
			{
				continue;
			}
			foreach (ItemRateData item in value2.input)
			{
				if (item.state == this)
				{
					return true;
				}
			}
			foreach (ItemRateData item2 in value2.output)
			{
				if (item2.state == this)
				{
					return true;
				}
			}
		}
		if (ShouldBeGloballyUnlocked())
		{
			return true;
		}
		foreach (KeyValuePair<HarvestRecipeType, HarvestState> item3 in parentTown.harvesting)
		{
			if (!item3.Value.isLocked && item3.Value.harvestedItemState == this)
			{
				return true;
			}
		}
		return false;
	}

	public void UnlockItem()
	{
		isLocked = false;
		if (parentTown != null)
		{
			parentTown.SetMetadataFlag(65536);
			if (parentTown == CountableState.gm.activeTown)
			{
				MenuManager.Instance.inventoryPanel.isTownLayoutStale = true;
				MenuManager.Instance.inventoryPanel.isItemAvailabilityStale = true;
				if (Item.IsCurrency(type))
				{
					MenuManager.Instance.coinPanel.isItemAvailabilityStale = true;
				}
			}
			InventoryPanel inventoryPanelPopup = MenuManager.Instance.inventoryPanelPopup;
			if (parentTown == inventoryPanelPopup.displayedTown)
			{
				inventoryPanelPopup.isTownLayoutStale = true;
				inventoryPanelPopup.isItemAvailabilityStale = true;
			}
			if (GameManager.Instance.globalInventory.TryGetValue(type, out var value) && value.isLocked)
			{
				value.UnlockItem();
			}
		}
		else
		{
			MenuManager.Instance.combinedProductionPanel.isItemAvailabilityStale = true;
			if (CountableState.gm.gameState == GameState.InGame)
			{
				GameManager.Instance.CalcNumItemsUnlocked();
			}
		}
		if (CountableState.gm.gameState != GameState.InGame)
		{
			return;
		}
		foreach (Town town in CountableState.gm.towns)
		{
			town?.SetMetadataFlag(65536);
		}
	}

	public void CalcAvailability()
	{
		if (isLocked && ShouldBeUnlocked())
		{
			UnlockItem();
		}
	}
}
