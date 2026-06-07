using System;
using System.Collections.Generic;
using FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class MinigamePanelFarming : MinigamePanelParent
{
	public GameObject terrainButtonPrefab;

	public GameObject toolButtonPrefab;

	public readonly List<FarmingTerrainChunk> chunks = new List<FarmingTerrainChunk>();

	private readonly Dictionary<Coord, FarmingMinigameButton> terrainTiles = new Dictionary<Coord, FarmingMinigameButton>();

	private readonly Dictionary<EntityId, FarmingToolButton> toolButtons = new Dictionary<EntityId, FarmingToolButton>();

	public RectTransform gridParent;

	public RectTransform toolParent;

	private const float gridSize = 40f;

	private EntityId activeTool;

	private ItemType activeItem;

	[NonSerialized]
	private SingleSelectionManager selectionManager;

	private HashSet<FarmingMinigameButton> buttonsToUpdate = new HashSet<FarmingMinigameButton>();

	private HashSet<FarmingMinigameButton> queuedButtonsToUpdate = new HashSet<FarmingMinigameButton>();

	private float waterUpdateCooldown;

	private float grassUpdateCooldown;

	private const float growthUpdateInterval = 1f;

	private bool isUpdatingButtons;

	private bool isFirstTouchRemove;

	public const float MaxGroundWater = 0.25f;

	public const float MaxFarmWater = 0.5f;

	protected override void CalcYield()
	{
		yieldBaseline = 5f;
		yieldBaselineUpgraded = yieldBaseline * MenuPanel.gm.MultiplierForGlobalUpgrade(UpgradeType.MinigameFarmingYield);
	}

	public void UpdateFarmingState()
	{
		waterUpdateCooldown -= TimeManager.MinigameDelta;
		if (waterUpdateCooldown <= 0f)
		{
			ProcessSimulation();
			waterUpdateCooldown += 0f;
		}
		grassUpdateCooldown -= TimeManager.MinigameDelta;
		if (grassUpdateCooldown <= 0f)
		{
			ProcessGrassSimulation();
			grassUpdateCooldown += 1f;
		}
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		minigameHeader.UpdateDynamicDisplay();
	}

	private void ProcessGrassSimulation()
	{
		foreach (KeyValuePair<Coord, FarmingMinigameButton> terrainTile in terrainTiles)
		{
			ProcessGrass(terrainTile.Value);
		}
		foreach (KeyValuePair<Coord, FarmingMinigameButton> terrainTile2 in terrainTiles)
		{
			FarmingMinigameButton value = terrainTile2.Value;
			value.PostProcessGrass();
			if (terrainTile2.Value.plantedResource != NaturalResource.None && value.cropAmount < 1f)
			{
				float num = 1f;
				float num2 = Mathf.Lerp(0.02f, 1f, value.waterAmount / (value.maxWater * 0.5f));
				float num3 = 0.01f * 1f * num2;
				if (value.cropAmount + num3 > 1f)
				{
					num3 = 1f - value.cropAmount;
					value.cropAmount = 1f;
				}
				else
				{
					value.cropAmount += num3;
				}
				value.waterAmount -= num3 * num;
				if (value.waterAmount < 0f)
				{
					value.waterAmount = 0f;
				}
			}
		}
	}

	private void ProcessSimulation()
	{
		isUpdatingButtons = true;
		foreach (KeyValuePair<Coord, FarmingMinigameButton> terrainTile in terrainTiles)
		{
			UpdateButton(terrainTile.Value);
		}
		foreach (KeyValuePair<Coord, FarmingMinigameButton> terrainTile2 in terrainTiles)
		{
			terrainTile2.Value.PostProcess();
		}
		isUpdatingButtons = false;
		buttonsToUpdate.Clear();
		queuedButtonsToUpdate.Clear();
	}

	private void ProcessGrass(FarmingMinigameButton b)
	{
		float num = 0.1f * 1f;
		if (b.terrainType != FarmingTerrainType.Ground)
		{
			return;
		}
		if (b.waterAmount / b.maxWater < 0.1f)
		{
			b.grassAmount -= num;
		}
		else
		{
			if (!(b.grassAmount < 1f))
			{
				return;
			}
			FarmingMinigameButton[] neighbors = b.neighbors;
			foreach (FarmingMinigameButton farmingMinigameButton in neighbors)
			{
				if (!(null == farmingMinigameButton) && farmingMinigameButton.terrainType == FarmingTerrainType.Ground && farmingMinigameButton.grassAmount > b.grassAmount)
				{
					float num2 = farmingMinigameButton.grassAmount * num;
					b.pendingGrassAmount += num2;
				}
			}
		}
	}

	private void UpdateButton(FarmingMinigameButton b)
	{
		UpdateWater4(b);
	}

	private void Evaporate(FarmingMinigameButton b)
	{
		float num = 0f;
		if (b.terrainType == FarmingTerrainType.Farm)
		{
			num = 0.01f;
		}
		else if (b.terrainType == FarmingTerrainType.Ground)
		{
			num = 0.005f * (1f - b.grassAmount);
		}
		if (num > 0f && b.waterAmount > 0f)
		{
			b.pendingWaterAmount -= num;
			queuedButtonsToUpdate.Add(b);
		}
	}

	private void UpdateWater4(FarmingMinigameButton b)
	{
		float minigameDelta = TimeManager.MinigameDelta;
		FarmingMinigameButton[] neighbors = b.neighbors;
		foreach (FarmingMinigameButton farmingMinigameButton in neighbors)
		{
			if (null == farmingMinigameButton || farmingMinigameButton.terrainType == FarmingTerrainType.Rock || farmingMinigameButton.waterAmount >= farmingMinigameButton.maxWater)
			{
				continue;
			}
			float num = b.waterAmount - farmingMinigameButton.waterAmount;
			if (farmingMinigameButton.waterAmount > b.waterAmount || (farmingMinigameButton.terrainType == FarmingTerrainType.Trench && b.terrainType != FarmingTerrainType.Trench))
			{
				continue;
			}
			if (b.isWaterSource)
			{
				num = StartupManager.Instance.waterPressure - farmingMinigameButton.waterAmount;
			}
			if (!(num < 0.001f))
			{
				float num2 = minigameDelta * (9.8f * num);
				num2 *= b.flowMultiplier;
				num2 *= farmingMinigameButton.flowMultiplier;
				if (farmingMinigameButton.waterAmount + num2 > farmingMinigameButton.maxWater)
				{
					num2 = farmingMinigameButton.maxWater - farmingMinigameButton.waterAmount;
				}
				if (GameUtility.IsNotZero(num2))
				{
					farmingMinigameButton.pendingWaterAmount += num2;
					b.pendingWaterAmount -= num2;
					QueueButtonsNear(farmingMinigameButton);
					queuedButtonsToUpdate.Add(farmingMinigameButton);
				}
			}
		}
		if (GameUtility.IsNotZero(b.pendingWaterAmount))
		{
			queuedButtonsToUpdate.Add(b);
		}
	}

	public override void ResetPanel()
	{
		base.ResetPanel();
		selectionManager?.ClearSelection();
	}

	public override void ResetMinigame()
	{
		base.ResetMinigame();
		buttonsToUpdate.Clear();
		queuedButtonsToUpdate.Clear();
		CalcYield();
	}

	public void LoadNeighbors()
	{
		foreach (KeyValuePair<Coord, FarmingMinigameButton> terrainTile in terrainTiles)
		{
			FarmingMinigameButton value = terrainTile.Value;
			for (int i = 0; i < 4; i++)
			{
				Coord key = value.coord.Offset(i);
				if (terrainTiles.TryGetValue(key, out var value2))
				{
					value.neighbors[i] = value2;
				}
				else
				{
					value.neighbors[i] = null;
				}
			}
		}
	}

	public override void CreateItems()
	{
		int num = 10;
		FarmingTerrainChunk farmingTerrainChunk = new FarmingTerrainChunk(new Coord(-num, -num), new Coord(num, num));
		chunks.Add(farmingTerrainChunk);
		for (int i = -num; i <= num; i++)
		{
			for (int j = -num; j <= num; j++)
			{
				FarmingMinigameButton item = AddButton(i, j);
				farmingTerrainChunk.tiles.Add(item);
			}
		}
		LoadNeighbors();
		ResizeContent();
		CreateTools();
		RefreshToolCosts();
		levelStat = MenuPanel.gm.minigameFarming;
		minigameHeader.rewardCapacityRegion.gameObject.SetActive(value: false);
		energyTracker = MenuPanel.gm.energyFarming;
		base.CreateItems();
	}

	private void OnSelectionChangedByManager(EntityId id, bool nextState)
	{
		if (toolButtons.TryGetValue(id, out var value))
		{
			if (nextState)
			{
				OnActivatedTool(value);
			}
			else
			{
				value.RemoveSelection();
			}
		}
	}

	private void CreateTools()
	{
		selectionManager = new SingleSelectionManager(OnSelectionChangedByManager);
		AddTool(EntityId.FromFarmingTool(FarmingToolType.TillSoil));
		AddTool(EntityId.FromFarmingTool(FarmingToolType.WateringCan));
		AddTool(EntityId.FromFarmingTool(FarmingToolType.TerrainShovel));
		AddTool(EntityId.FromFarmingTool(FarmingToolType.RockDestroyer));
		AddTool(EntityId.FromFarmingTool(FarmingToolType.CropHarvester));
		AddSpacer();
		if (!Crafting.cachedBuildingResources.TryGetValue(BuildingType.Farm, out var value))
		{
			return;
		}
		foreach (NaturalResource item in value)
		{
			ItemType itemType = Item.ItemFromNaturalResource(item);
			if (itemType != ItemType.None && itemType != ItemType.Water)
			{
				AddTool(EntityId.FromItem(itemType));
				rewardEntities.AddItem(itemType, 1.0);
			}
		}
	}

	private void RefreshToolCosts()
	{
		foreach (KeyValuePair<EntityId, FarmingToolButton> toolButton in toolButtons)
		{
			float cost = CostForTool(toolButton.Key);
			toolButton.Value.LoadCost(cost);
		}
	}

	private void ResizeContent()
	{
		int num = int.MaxValue;
		int num2 = int.MinValue;
		int num3 = int.MaxValue;
		int num4 = int.MinValue;
		foreach (KeyValuePair<Coord, FarmingMinigameButton> terrainTile in terrainTiles)
		{
			Coord key = terrainTile.Key;
			if (key.x < num)
			{
				num = key.x;
			}
			if (key.x > num2)
			{
				num2 = key.x;
			}
			if (key.y < num3)
			{
				num3 = key.y;
			}
			if (key.y > num4)
			{
				num4 = key.y;
			}
		}
		gridParent.SetWidth((float)(num2 - num) * 40f + 40f);
		gridParent.SetHeight((float)(num4 - num3) * 40f + 40f);
	}

	protected override void LoadNewMinigame()
	{
		base.LoadNewMinigame();
		foreach (KeyValuePair<Coord, FarmingMinigameButton> terrainTile in terrainTiles)
		{
			FarmingMinigameButton value = terrainTile.Value;
			float num = NoiseValue(terrainTile.Key.x, terrainTile.Key.y);
			if (num > 0.8f)
			{
				value.grassAmount = 0f;
				value.isWaterSource = false;
				value.SetTerrainType(FarmingTerrainType.Rock);
			}
			else if (num < 0.2f)
			{
				value.grassAmount = 0f;
				value.isWaterSource = true;
				value.SetTerrainType(FarmingTerrainType.Trench);
			}
			else
			{
				value.grassAmount = 1f;
				value.isWaterSource = false;
				value.SetTerrainType(FarmingTerrainType.Ground);
			}
			value.waterAmount = value.maxWater;
			buttonsToUpdate.Add(terrainTile.Value);
		}
		minigameState = MinigameState.Running;
	}

	private float NoiseValue(float x, float y)
	{
		return Mathf.PerlinNoise(x * 0.1f + 1000f, y * 0.1f + 1000f);
	}

	private void AddSpacer()
	{
		GameObject obj = new GameObject();
		obj.transform.SetParent(toolParent);
		obj.AddComponent<LayoutElement>().minWidth = 20f;
	}

	private void AddTool(EntityId t)
	{
		FarmingToolButton component = MenuManager.GetMenuObject(toolButtonPrefab, toolParent).GetComponent<FarmingToolButton>();
		component.entity = t;
		component.Init();
		component.toolImage.sprite = IconManager.SpriteForEntity(t);
		component.LoadSelectionManager(selectionManager);
		component.selectionHandle = t;
		component.buttonState = CustomButtonState.Background;
		component.tooltipEntity = t;
		toolButtons[t] = component;
	}

	private void OnActivatedTool(FarmingToolButton button)
	{
		activeTool = button.entity;
		if (button.entity.TryAsItem(out var i))
		{
			activeItem = i;
		}
		else
		{
			activeItem = ItemType.None;
		}
	}

	private FarmingMinigameButton AddButton(int x, int y)
	{
		FarmingMinigameButton component = MenuManager.GetMenuObject(terrainButtonPrefab, gridParent).GetComponent<FarmingMinigameButton>();
		component.Init(x, y);
		component.actionDelegate = OnActivatedButton;
		RectTransform component2 = component.GetComponent<RectTransform>();
		component2.SetPosX((float)x * component2.sizeDelta.x);
		component2.SetPosY((float)y * component2.sizeDelta.y);
		terrainTiles[new Coord(x, y)] = component;
		return component;
	}

	private float CostForTool(EntityId toolType)
	{
		if (toolType.TryAsFarmingTool(out var i))
		{
			return i switch
			{
				FarmingToolType.TillSoil => 10f, 
				FarmingToolType.WateringCan => 5f, 
				FarmingToolType.TerrainShovel => 5f, 
				FarmingToolType.RockDestroyer => 100f, 
				FarmingToolType.CropHarvester => 0f, 
				_ => 0f, 
			};
		}
		if (toolType.type == EntityType.Item)
		{
			return 2f;
		}
		return 0f;
	}

	private bool HasEnergyForAction(EntityId toolType, FarmingMinigameButton target)
	{
		if (GameManager.everythingUnlocked || GameManager.freeMode)
		{
			return true;
		}
		float num = CostForTool(toolType);
		return energyTracker.currentCount >= (double)num;
	}

	private InvalidReason InvalidReasonForToolOnTile(EntityId toolId, FarmingMinigameButton b)
	{
		if (toolId.TryAsFarmingTool(out var i))
		{
			switch (i)
			{
			case FarmingToolType.TillSoil:
				if (b.terrainType == FarmingTerrainType.Rock)
				{
					return InvalidReason.MustRemoveRock;
				}
				if (b.terrainType != FarmingTerrainType.Ground)
				{
					return InvalidReason.MustHaveDirt;
				}
				break;
			case FarmingToolType.WateringCan:
				if (b.maxWater <= 0f)
				{
					return InvalidReason.CanNotHoldWater;
				}
				if (b.terrainType != FarmingTerrainType.Farm)
				{
					return InvalidReason.CanOnlyWaterFarmland;
				}
				if (b.waterAmount / b.maxWater > 0.95f)
				{
					return InvalidReason.WaterIsFull;
				}
				break;
			case FarmingToolType.CropHarvester:
				if (b.plantedResource == NaturalResource.None)
				{
					return InvalidReason.NoCropPlanted;
				}
				if (b.cropAmount < 1f)
				{
					return InvalidReason.CropNotGrownYet;
				}
				break;
			case FarmingToolType.RockDestroyer:
				if (b.terrainType != FarmingTerrainType.Rock)
				{
					return InvalidReason.CanOnlyDestroyRock;
				}
				break;
			}
		}
		else if (toolId.type == EntityType.Item)
		{
			if (b.terrainType == FarmingTerrainType.Trench)
			{
				return InvalidReason.MustHaveDirt;
			}
			if (b.terrainType == FarmingTerrainType.Rock)
			{
				return InvalidReason.MustRemoveRock;
			}
			if (b.terrainType != FarmingTerrainType.Farm)
			{
				return InvalidReason.MustTillSoil;
			}
			if (b.plantedResource != NaturalResource.None)
			{
				return InvalidReason.AlreadyPlanted;
			}
		}
		if (!HasEnergyForAction(toolId, b))
		{
			return InvalidReason.NotEnoughEnergy;
		}
		return InvalidReason.None;
	}

	public void OnActivatedButton(DraggableButton sender, bool isDragging)
	{
		if (!(sender is FarmingMinigameButton farmingMinigameButton))
		{
			return;
		}
		switch (InvalidReasonForToolOnTile(activeTool, farmingMinigameButton))
		{
		case InvalidReason.NotEnoughEnergy:
			minigameHeader.RunEnergyFlashAnimation();
			break;
		case InvalidReason.None:
		{
			ItemType i2;
			if (activeTool.TryAsFarmingTool(out var i))
			{
				switch (i)
				{
				case FarmingToolType.TillSoil:
					farmingMinigameButton.grassAmount = 0f;
					farmingMinigameButton.SetTerrainType(FarmingTerrainType.Farm);
					MenuManager.Instance.PlayDigParticles(farmingMinigameButton.transform.position);
					break;
				case FarmingToolType.WateringCan:
					farmingMinigameButton.waterAmount = farmingMinigameButton.maxWater;
					break;
				case FarmingToolType.CropHarvester:
				{
					ItemType itemType = Item.ItemFromNaturalResource(farmingMinigameButton.plantedResource);
					if (itemType != ItemType.None)
					{
						float amount = yieldBaselineUpgraded * yieldMultiplier;
						float amount2 = 5f * MenuPanel.gm.MultiplierForGlobalPerk(PerkType.MinigameXPGainSpeed);
						AnimateToInventory(farmingMinigameButton.transform, itemType, amount);
						AnimateToExperience(farmingMinigameButton.transform, levelStat.iconItem, amount2);
						farmingMinigameButton.cropAmount = 0f;
						farmingMinigameButton.SetPlantedCrop(NaturalResource.None);
					}
					break;
				}
				case FarmingToolType.RockDestroyer:
					MenuManager.Instance.PlayDigParticles(farmingMinigameButton.transform.position);
					farmingMinigameButton.waterAmount = 0f;
					farmingMinigameButton.grassAmount = 0f;
					farmingMinigameButton.SetTerrainType(FarmingTerrainType.Ground);
					break;
				case FarmingToolType.TerrainShovel:
					if (farmingMinigameButton.isWaterSource)
					{
						return;
					}
					if (farmingMinigameButton.terrainType == FarmingTerrainType.Farm)
					{
						farmingMinigameButton.SetTerrainType(FarmingTerrainType.Ground);
						MenuManager.Instance.PlayDigParticles(farmingMinigameButton.transform.position);
					}
					else if (farmingMinigameButton.terrainType == FarmingTerrainType.Ground)
					{
						if (isDragging)
						{
							if (!isFirstTouchRemove)
							{
								return;
							}
						}
						else
						{
							isFirstTouchRemove = true;
						}
						farmingMinigameButton.grassAmount = 0f;
						farmingMinigameButton.waterAmount = 0f;
						farmingMinigameButton.SetTerrainType(FarmingTerrainType.Trench);
						MenuManager.Instance.PlayDigParticles(farmingMinigameButton.transform.position);
						buttonsToUpdate.Add(farmingMinigameButton);
						QueueButtonsNear(farmingMinigameButton);
					}
					else
					{
						if (farmingMinigameButton.terrainType != FarmingTerrainType.Trench)
						{
							break;
						}
						if (isDragging)
						{
							if (isFirstTouchRemove)
							{
								return;
							}
						}
						else
						{
							isFirstTouchRemove = false;
						}
						farmingMinigameButton.grassAmount = 0f;
						farmingMinigameButton.waterAmount = 0f;
						farmingMinigameButton.SetTerrainType(FarmingTerrainType.Ground);
						MenuManager.Instance.PlayDigParticles(farmingMinigameButton.transform.position);
						buttonsToUpdate.Add(farmingMinigameButton);
						QueueButtonsNear(farmingMinigameButton);
					}
					break;
				}
			}
			else if (activeTool.TryAsItem(out i2))
			{
				NaturalResource plantedCrop = Item.NaturalResourceFromItem(activeItem);
				farmingMinigameButton.SetPlantedCrop(plantedCrop);
				farmingMinigameButton.cropAmount = 0f;
			}
			float num = CostForTool(activeTool);
			energyTracker.Subtract(num);
			break;
		}
		}
	}

	public void Till(FarmingMinigameButton button)
	{
	}

	private void QueueButtonsNear(FarmingMinigameButton button)
	{
		for (int i = 0; i < 4; i++)
		{
			Coord key = button.coord.Offset(i);
			if (terrainTiles.TryGetValue(key, out var value))
			{
				if (isUpdatingButtons)
				{
					queuedButtonsToUpdate.Add(value);
				}
				else
				{
					buttonsToUpdate.Add(value);
				}
			}
		}
	}

	private void AnimateToInventory(Transform startTransform, ItemType t, float amount)
	{
		if (MenuManager.Instance.inventoryPanel.TryGetTransform(t, out var result))
		{
			int count = UnityEngine.Random.Range(3, 6);
			Vector3 position = startTransform.position;
			Vector3 to = result;
			MenuManager.Instance.AnimateItem(EntityId.FromItem(t), count, amount, position, to, OnAnimatedIconFinished);
		}
	}

	private void OnAnimatedIconFinished(AnimatedIcon i)
	{
		if (i.displayedEntity.TryAsItem(out var i2))
		{
			MenuPanel.gm.activeTown.EarnItem(i2, i.animatedValue);
		}
	}

	public override void CreateLayoutForActiveTown()
	{
		base.CreateLayoutForActiveTown();
		foreach (KeyValuePair<Coord, FarmingMinigameButton> terrainTile in terrainTiles)
		{
			terrainTile.Value.UpdateIcon();
			terrainTile.Value.UpdateColors();
		}
		EntityId key = EntityId.FromFarmingTool(FarmingToolType.TillSoil);
		if (toolButtons.TryGetValue(key, out var value))
		{
			activeTool = key;
			value.PerformSelection(sendEvent: false);
		}
	}

	public override fsData GetData()
	{
		Dictionary<string, fsData> dictionary = new Dictionary<string, fsData>();
		StoreCommonData(dictionary);
		List<fsData> list = new List<fsData>();
		foreach (FarmingTerrainChunk chunk in chunks)
		{
			list.Add(chunk.GetData());
		}
		dictionary["Chunks"] = new fsData(list);
		return new fsData(dictionary);
	}

	protected override void LoadFromDictionary(Dictionary<string, fsData> dataDict)
	{
		base.LoadFromDictionary(dataDict);
		if (dataDict.TryGetValue("Chunks", out var value) && value.TryAsList(out var result))
		{
			foreach (fsData item in result)
			{
				if (!item.TryAsDictionary(out var result2) || !result2.TryGetValue("start", out var value2) || !result2.TryGetValue("end", out var value3) || !result2.TryGetValue("Items", out var value4) || !value4.TryAsList(out var result3))
				{
					continue;
				}
				Coord coord = SaveFile.CoordFromData(value2);
				int num = SaveFile.CoordFromData(value3).x - coord.x + 1;
				for (int i = 0; i < result3.Count; i++)
				{
					int xOffset = i / num;
					int yOffset = i % num;
					Coord key = coord.Offset(xOffset, yOffset);
					if (terrainTiles.TryGetValue(key, out var value5))
					{
						value5.LoadFromData(result3[i]);
					}
				}
			}
		}
		CalcYield();
	}

	protected override void UpdateItemAvailability()
	{
		base.UpdateItemAvailability();
		foreach (KeyValuePair<EntityId, FarmingToolButton> toolButton in toolButtons)
		{
			float num = CostForTool(toolButton.Key);
			bool flag = energyTracker.maxCount >= (double)num;
			if (flag && toolButton.Key.TryAsItem(out var i))
			{
				NaturalResource key = Item.NaturalResourceFromItem(i);
				flag = MenuPanel.gm.activeTown.farmingItems.TryGetValue(key, out var value) && !value.isLocked;
			}
			toolButton.Value.gameObject.SetActive(flag);
		}
	}

	public override bool ShouldBeAvailable()
	{
		return false;
	}
}
