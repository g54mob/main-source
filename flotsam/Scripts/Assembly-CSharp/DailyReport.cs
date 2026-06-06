using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DailyReport
{
	private float _startCommunityExperience;

	private int _startResearchPoints;

	public UnityEvent OnGatheredResourceUpdate = new UnityEvent();

	public UnityEvent OnCraftedResourceUpdate = new UnityEvent();

	public UnityEvent OnFarmedResourcesUpdate = new UnityEvent();

	public UnityEvent OnDistanceTravelledUpdate = new UnityEvent();

	public UnityEvent OnCommunityExperienceUpdate = new UnityEvent();

	public UnityEvent OnResearchPointUpdate = new UnityEvent();

	public DailyReportTableData FoodData { get; private set; }

	public DailyReportTableData WaterData { get; private set; }

	public DailyReportTableData EnergyData { get; private set; }

	public Dictionary<ItemProperties, int> GatheredResources { get; private set; }

	public Dictionary<ItemProperties, int> CraftedResources { get; private set; }

	public Dictionary<ItemProperties, int> FarmedResources { get; private set; }

	public Dictionary<ItemProperties, int> Consumed { get; private set; }

	public Dictionary<ItemProperties, int> Processed { get; private set; }

	public float TravelledDistance { get; private set; }

	public float ExperienceGained { get; private set; }

	public int ResearchPointsGained { get; private set; }

	public int LandmarksSalvaged { get; private set; }

	public List<ushort> ActorRescues { get; private set; }

	public List<ushort> ActorDeaths { get; private set; }

	public int StartAgentCount { get; private set; }

	public DailyReport()
	{
		GatheredResources = new Dictionary<ItemProperties, int>();
		CraftedResources = new Dictionary<ItemProperties, int>();
		FarmedResources = new Dictionary<ItemProperties, int>();
		Consumed = new Dictionary<ItemProperties, int>();
		Processed = new Dictionary<ItemProperties, int>();
		FoodData = new DailyReportTableData();
		WaterData = new DailyReportTableData();
		EnergyData = new DailyReportTableData();
		StartAgentCount = Community.PlayerCommunity.Agents.Count;
	}

	public DailyReport(DailyReportPersistentData data)
	{
		GatheredResources = data.ReturnResourceDictionary(data.GatheredResources);
		CraftedResources = data.ReturnResourceDictionary(data.CraftedResources);
		FarmedResources = data.ReturnResourceDictionary(data.GrownResources);
		FoodData = new DailyReportTableData(data.FoodData);
		WaterData = new DailyReportTableData(data.WaterData);
		EnergyData = new DailyReportTableData(data.EnergyData);
		Consumed = CountedItemPersistentData.ToDictionary(data.Consumed);
		Processed = CountedItemPersistentData.ToDictionary(data.Processed);
		TravelledDistance = data.TravelledDistance;
		ExperienceGained = data.ExperienceGained;
		ResearchPointsGained = data.ResearchPointsGained;
		LandmarksSalvaged = data.LandmarksSalvaged;
		ActorRescues = ((data.ActorRescues != null) ? new List<ushort>(data.ActorRescues) : null);
		ActorDeaths = ((data.ActorDeaths != null) ? new List<ushort>(data.ActorDeaths) : null);
		StartAgentCount = data.StartAgentCount;
	}

	public void Start()
	{
		GameEventDispatcher.AddListener(GameEventType.ProducerItemConsumed, OnRecipeItemConsumed);
		GameEventDispatcher.AddListener(GameEventType.ProducerItemProduced, OnItemProcuded);
		GameEventDispatcher.AddListener(GameEventType.ItemFarmed, OnItemFarmed);
		GameEventDispatcher.AddListener(GameEventType.AgentAteFood, OnItemConsume);
		GameEventDispatcher.AddListener(GameEventType.AgentDrankDrink, OnItemConsume);
		GameEventDispatcher.AddListener(GameEventType.ProducerItemConsumed, OnItemProcessed);
		GameEventDispatcher.AddListener(GameEventType.EnergyProduced, OnEnergyProduce);
		GameEventDispatcher.AddListener(GameEventType.EnergyConsumed, OnEnergyConsume);
		GameEventDispatcher.AddListener(GameEventType.FlotsamItemSalvage, OnItemSalvaged);
		GameEventDispatcher.AddListener(GameEventType.LandmarkNotificationUpdate, OnLandmarkActionEvent);
		GameEventDispatcher.AddListener(GameEventType.LandmarkNotificationIdle, OnLandmarkActionEvent);
		GameEventDispatcher.AddListener(GameEventType.LandmarkActionCompleted, OnLandmarkActionEvent);
		GameEventDispatcher.AddListener(GameEventType.TownheartMoved, OnTownheartMoved);
		GameEventDispatcher.AddListener(GameEventType.CommunityExperienceUpdated, OnCommunityExperienceUpdated);
		GameEventDispatcher.AddListener(GameEventType.ResearchPointsUpdated, OnResearchPointsUpdated);
		GameEventDispatcher.AddListener(GameEventType.ActorRescue, OnActorRescued);
		GameEventDispatcher.AddListener(GameEventType.ActorDeath, OnActorDeath);
		_startCommunityExperience = ExpertiseManager.Experience;
		_startResearchPoints = ExpertiseManager.ResearchPoints;
	}

	public void Finish()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ProducerItemConsumed, OnRecipeItemConsumed);
		GameEventDispatcher.RemoveListener(GameEventType.ProducerItemProduced, OnItemProcuded);
		GameEventDispatcher.RemoveListener(GameEventType.ItemFarmed, OnItemFarmed);
		GameEventDispatcher.RemoveListener(GameEventType.AgentAteFood, OnItemConsume);
		GameEventDispatcher.RemoveListener(GameEventType.AgentDrankDrink, OnItemConsume);
		GameEventDispatcher.RemoveListener(GameEventType.ProducerItemConsumed, OnItemProcessed);
		GameEventDispatcher.RemoveListener(GameEventType.EnergyProduced, OnEnergyProduce);
		GameEventDispatcher.RemoveListener(GameEventType.EnergyConsumed, OnEnergyConsume);
		GameEventDispatcher.RemoveListener(GameEventType.FlotsamItemSalvage, OnItemSalvaged);
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkNotificationUpdate, OnLandmarkActionEvent);
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkNotificationIdle, OnLandmarkActionEvent);
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkActionCompleted, OnLandmarkActionEvent);
		GameEventDispatcher.RemoveListener(GameEventType.TownheartMoved, OnTownheartMoved);
		GameEventDispatcher.RemoveListener(GameEventType.CommunityExperienceUpdated, OnCommunityExperienceUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchPointsUpdated, OnResearchPointsUpdated);
		GameEventDispatcher.RemoveListener(GameEventType.ActorRescue, OnActorRescued);
		GameEventDispatcher.RemoveListener(GameEventType.AgentDeath, OnActorDeath);
	}

	public void AddGatheredResource(ItemProperties properties, int amount = 1)
	{
		CountItem(GatheredResources, properties, amount);
		OnGatheredResourceUpdate.Invoke();
	}

	public void AddCraftedResources(ItemProperties properties, int amount = 1)
	{
		CountItem(CraftedResources, properties, amount);
		OnCraftedResourceUpdate.Invoke();
	}

	public void AddFarmedResources(ItemProperties properties, int amount = 1)
	{
		CountItem(FarmedResources, properties, amount);
		OnFarmedResourcesUpdate.Invoke();
	}

	private void CountItem(Dictionary<ItemProperties, int> countedItems, ItemProperties properties, int amount = 1)
	{
		if (countedItems.ContainsKey(properties))
		{
			countedItems[properties] += amount;
		}
		else
		{
			countedItems.Add(properties, amount);
		}
	}

	private void OnTownheartMoved(GameEvent gameEvent)
	{
		if (gameEvent is MovementEvent movementEvent)
		{
			TravelledDistance += movementEvent.Distance;
			OnDistanceTravelledUpdate.Invoke();
		}
	}

	private void OnRecipeItemConsumed(GameEvent gameEvent)
	{
		if (gameEvent is ItemEvent itemEvent)
		{
			ItemProperties properties = itemEvent.Item.Properties;
			if (properties.Tags.IsFlagSet(Item.Tags.Food))
			{
				FoodData.AddIngredient(properties.NutritionalValue);
			}
		}
	}

	private void OnItemProcuded(GameEvent gameEvent)
	{
		ItemProperties properties = (gameEvent as ItemEvent).Item.Properties;
		_ = GameManager.Settings.DataSettings;
		if (Item.ContainsTagSet(properties.Tags, Item.Tags.Food))
		{
			FoodData.AddGained(properties.NutritionalValue);
		}
		if (Item.ContainsTagSet(properties.Tags, Item.Tags.Drink))
		{
			WaterData.AddGained(properties.NutritionalValue);
		}
		AddCraftedResources(properties);
	}

	private void OnItemFarmed(GameEvent gameEvent)
	{
		if (gameEvent is ItemEvent itemEvent)
		{
			AddFarmedResources(itemEvent.ItemProperties, itemEvent.Amount);
		}
	}

	private void OnEnergyProduce(GameEvent gameEvent)
	{
		EnergyEvent energyEvent = gameEvent as EnergyEvent;
		EnergyData.AddGained(energyEvent.Amount);
	}

	private void OnEnergyConsume(GameEvent gameEvent)
	{
		EnergyEvent energyEvent = gameEvent as EnergyEvent;
		EnergyData.AddLost(energyEvent.Amount);
	}

	private void OnItemConsume(GameEvent gameEvent)
	{
		if (gameEvent is AgentItemPropertiesEvent { ItemProperties: var itemProperties })
		{
			CountItem(Consumed, itemProperties);
			if (Item.ContainsTagSet(itemProperties.Tags, Item.Tags.Food))
			{
				FoodData.AddLost(itemProperties.NutritionalValue);
			}
			if (Item.ContainsTagSet(itemProperties.Tags, Item.Tags.Drink))
			{
				WaterData.AddLost(itemProperties.NutritionalValue);
			}
		}
	}

	private void OnItemProcessed(GameEvent gameEvent)
	{
		if (gameEvent is ItemEvent itemEvent)
		{
			CountItem(Processed, itemEvent.ItemProperties);
		}
	}

	private void OnItemSalvaged(GameEvent gameEvent)
	{
		ItemEvent itemEvent = gameEvent as ItemEvent;
		AddGatheredResource(itemEvent.Item.Properties);
	}

	private void OnLandmarkActionEvent(GameEvent gameEvent)
	{
		if (!(gameEvent is LandmarkNotificationEvent { LandmarkAction: LandmarkActionSalvage landmarkAction }))
		{
			return;
		}
		foreach (LandmarkActionSalvage.Category category in landmarkAction.Categories)
		{
			if (!category.IsCompleted && !category.RequiresAssignmentType && !category.RequiresBuildable)
			{
				return;
			}
		}
		LandmarksSalvaged++;
	}

	private void OnCommunityExperienceUpdated(GameEvent gameEvent)
	{
		ExperienceGained = Mathf.Max(ExpertiseManager.Experience - _startCommunityExperience, 0f);
		OnCommunityExperienceUpdate.Invoke();
	}

	private void OnResearchPointsUpdated(GameEvent gameEvent)
	{
		ResearchPointsGained = Mathf.Max(ExpertiseManager.ResearchPoints - _startResearchPoints, 0);
		OnResearchPointUpdate.Invoke();
	}

	private void OnActorRescued(GameEvent gameEvent)
	{
		if (gameEvent is ActorEvent { ActorDescriptor: not null } actorEvent)
		{
			if (ActorRescues == null)
			{
				ActorRescues = new List<ushort>();
			}
			ActorRescues.AddUnique(actorEvent.ActorDescriptor.UniqueID);
		}
	}

	private void OnActorDeath(GameEvent gameEvent)
	{
		if (gameEvent is ActorEvent { ActorDescriptor: not null } actorEvent)
		{
			if (ActorDeaths == null)
			{
				ActorDeaths = new List<ushort>();
			}
			ActorDeaths.AddUnique(actorEvent.ActorDescriptor.UniqueID);
		}
	}

	public bool HasActorRescue(ActorType actorType)
	{
		if (ActorRescues.IsNullOrEmpty())
		{
			return false;
		}
		foreach (ushort actorDeath in ActorDeaths)
		{
			if (ActorDescriptor.TryGet<ActorDescriptor>(out var actorDescriptor, actorDeath) && actorDescriptor.ActorType == actorType)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasActorDeath(ActorType actorType)
	{
		if (ActorDeaths.IsNullOrEmpty())
		{
			return false;
		}
		foreach (ushort actorDeath in ActorDeaths)
		{
			if (ActorDescriptor.TryGet<ActorDescriptor>(out var actorDescriptor, actorDeath) && actorDescriptor.ActorType == actorType)
			{
				return true;
			}
		}
		return false;
	}

	public bool WasActorRescued(ActorDescriptor actorDescriptor)
	{
		if (ActorRescues.IsNullOrEmpty())
		{
			return false;
		}
		return ActorRescues.Contains(actorDescriptor.UniqueID);
	}

	public bool HasActorFied(ActorDescriptor actorDescriptor)
	{
		if (ActorDeaths.IsNullOrEmpty())
		{
			return false;
		}
		return ActorDeaths.Contains(actorDescriptor.UniqueID);
	}
}
